﻿using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AspNet.Security.OpenIdConnect.Primitives;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using DataTables.AspNet.AspNetCore;
using Hangfire;
using Hangfire.Console;
using Hangfire.MemoryStorage;
using ImperaPlus.Application;
using ImperaPlus.Application.Jobs;
using ImperaPlus.DataAccess;
using ImperaPlus.Domain;
using ImperaPlus.Domain.Repositories;
using ImperaPlus.Web.Filters;
using ImperaPlus.Web.Providers;
using ImperaPlus.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using NLog.Fluent;
using OpenIddict.Abstractions;
using StackExchange.Profiling.Storage;

namespace ImperaPlus.Web
{

    public class Startup
    {
        #region TestSupport
        /// <summary>
        /// Test support: Require user confirmation
        /// </summary>
        public static bool RequireUserConfirmation = true;

        public static bool RunningUnderTest = false;

        public static IContainer Container { get; private set; }

        public static ContainerBuilder TestContainerBuilder { get; set; }
        #endregion

        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                // Environment specific settings, i.e., setting db connection string. Do not create in version control repository.
                .AddJsonFile($"appsettings.environment.json", optional: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            if (Startup.RunningUnderTest)
            {
                builder.AddJsonFile($"appsettings.test.json", optional: true);
            }

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }

            this.Configuration = builder.Build();
            this.Environment = env;
        }

        public IConfigurationRoot Configuration { get; }

        public IWebHostEnvironment Environment { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // Work around for https://github.com/aspnet/Home/issues/3132
            var manager = new Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPartManager();
            manager.ApplicationParts.Add(new Microsoft.AspNetCore.Mvc.ApplicationParts.AssemblyPart(typeof(Startup).Assembly));
            services.AddSingleton(manager);

            services.AddDbContext<ImperaContext>(options =>
            {
                string connection = Configuration["DBConnection"];

                if (!Startup.RunningUnderTest)
                {
                    options.UseSqlServer(connection,
                        b => b
                            .MigrationsAssembly("ImperaPlus.Web")
                            .EnableRetryOnFailure());
                }

                options.UseOpenIddict();
            });

            services.AddCors(opts =>
            {
                var policy = new CorsPolicy()
                {
                    SupportsCredentials = false
                };

                policy.ExposedHeaders.Add("X-MiniProfiler-Ids");
                policy.Headers.Add("X-MiniProfiler-Ids");

                opts.AddPolicy(
                    opts.DefaultPolicyName,
                    policy);
            });

            // Auth
            services.AddIdentity<Domain.User, IdentityRole>(options =>
                {
                    options.User.RequireUniqueEmail = true;

                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireDigit = false;

                    options.SignIn.RequireConfirmedEmail = true;
                    options.SignIn.RequireConfirmedPhoneNumber = false;

                    if (this.Environment.IsDevelopment())
                    {
                        options.SignIn.RequireConfirmedEmail = false;
                    }

                    // Ensure that we never redirect when user is not authorized, but only return 401 response
                    // TODO: Fix for admin flow
                    //options.Cookies.ApplicationCookie.AutomaticAuthenticate = false;
                    //options.Cookies.ApplicationCookie.AutomaticChallenge = false;
                    //options.Cookies.ApplicationCookie.Events = new Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents
                    //{
                    //    OnRedirectToLogin = ctx =>
                    //    {
                    //        ctx.Response.StatusCode = (int)System.Net.HttpStatusCode.Unauthorized;
                    //        return Task.CompletedTask;
                    //    },

                    //    OnValidatePrincipal = ctx =>
                    //    {
                    //        return Task.CompletedTask;
                    //    }
                    //};

                    options.ClaimsIdentity.UserNameClaimType = OpenIdConnectConstants.Claims.Name;
                    options.ClaimsIdentity.UserIdClaimType = OpenIdConnectConstants.Claims.Subject;
                    options.ClaimsIdentity.RoleClaimType = OpenIdConnectConstants.Claims.Role;
                })
                .AddEntityFrameworkStores<ImperaContext>()
                .AddDefaultTokenProviders();

            services
                .AddOpenIddict(options =>
                {
                    options.AddCore(x =>
                    {
                        x.UseEntityFrameworkCore(c => c.UseDbContext<ImperaContext>());
                    });

                    options.AddServer(c =>
                    {
                        if (this.Environment.IsDevelopment())
                        {
                            c.DisableHttpsRequirement();
                            c.AddEphemeralSigningKey();
                        }

                        c.AllowPasswordFlow();
                        c.AllowRefreshTokenFlow();
                        c.EnableTokenEndpoint("/Account/Token");

                        c.RegisterScopes(OpenIddictConstants.Scopes.Roles);

                        c.AcceptAnonymousClients();
                    });

                    // TODO: FIX: Is this still required?
                    // options.AddMvcBinders();
                });

            services.AddAuthentication().AddOAuthValidation(config =>
            {
                config.Events = new AspNet.Security.OAuth.Validation.OAuthValidationEvents
                {
                    // Note: for SignalR connections, the default Authorization header does not work,
                    // because the WebSockets JS API doesn't allow setting custom parameters.
                    // To work around this limitation, the access token is retrieved from the query string.
                    OnRetrieveToken = context =>
                    {
                        context.Token = context.Request.Query["access_token"];
                        return Task.CompletedTask;
                    }
                };
            });

            services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
            });

            services.AddMvc(config =>
                {
                    config.EnableEndpointRouting = false;
                    config.Filters.Add(new CheckModelForNull());
                    config.Filters.Add(typeof(ApiExceptionFilterAttribute));
                })
                .AddNewtonsoftJson(opt =>
                {
                    opt.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                    opt.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
                    opt.SerializerSettings.Converters.Add(new StringEnumConverter
                    {
                        CamelCaseText = false,
                        AllowIntegerValues = true
                    });
                    opt.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                });

            services
                .AddMiniProfiler(config =>
                {
                    (config.Storage as MemoryCacheStorage).CacheDuration = TimeSpan.FromMinutes(60);

                    config.RouteBasePath = "/admin/profiler";
                })
                .AddEntityFramework();

            services.AddMemoryCache();

            // DataTables for the admin interface
            services.RegisterDataTables();

            // Set default authorization policy
            services.AddAuthorization(o =>
            {
                var builder = new AuthorizationPolicyBuilder();
                builder.AuthenticationSchemes.Add(AspNet.Security.OAuth.Validation.OAuthValidationDefaults.AuthenticationScheme);
                builder.RequireAuthenticatedUser();
                o.DefaultPolicy = builder.Build();
            });

            // Hangire
            services.AddHangfire(x =>
            {
                x.UseNLogLogProvider()
                 .UseFilter(new JobExpirationTimeAttribute())
                 .UseConsole();

                if (Startup.RunningUnderTest)
                {
                    x.UseMemoryStorage();
                }
                else
                {
                    x.UseSqlServerStorage(Configuration["DBConnection"]);
                }
            });

            services.AddSingleton(_ => new JsonSerializer
            {
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                DateFormatHandling = DateFormatHandling.IsoDateFormat
            });

            services
                .AddSignalR(options =>
                {
                    options.EnableDetailedErrors = true;
                })
                .AddNewtonsoftJsonProtocol(options =>
                {
                    options.PayloadSerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    options.PayloadSerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                    options.PayloadSerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
                });

            // Have SignalR use the name claim as user id
            services.AddSingleton<IUserIdProvider, NameUserIdProvider>();

            services.AddOpenApiDocument();

            return this.RegisterDependencies(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            ILoggerFactory loggerFactory,
            ImperaContext dbContext,
            DbSeed dbSeed)
        {
            if (env.IsDevelopment()) {
                app.UsePathBase("/api");
            }

            NLog.LogManager.Configuration.Variables["configDir"] = Configuration["LogDir"];

            //if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }

            // Enable Cors
            app.UseCors(b => b
                .WithOrigins("http://localhost:8080", "https://dev.imperaonline.de", "https://imperaonline.de", "https://www.imperaonline.de")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithExposedHeaders("X-MiniProfiler-Ids")
                .AllowCredentials());

            // Auth
            app.UseAuthentication();

            // TODO: Fix, how does this work?
            //app.UseOpenIddict();

            // Enable serving client and static assets
            app.UseResponseCompression();
            app.UseDefaultFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = ctx =>
                {
                    // Do not cache main entry point.
                    if (!ctx.File.Name.Contains("index.html"))
                    {
                        ctx.Context.Response.Headers.Append("Cache-Control", "public,max-age=6000000");
                    }
                }
            });

            app.UseMiniProfiler();

            // Configure swagger generation & UI
            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseMvc(routes =>
            {
                // Route for sub areas, i.e. Admin
                routes.MapRoute("areaRoute", "{area:exists}/{controller=News}/{action=Index}");

                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseWebSockets();
            app.UseSignalR(routes =>
            {
                routes.MapHub<Hubs.MessagingHub>("/signalr/chat");
                routes.MapHub<Hubs.GameHub>("/signalr/game");
            });

            // Initialize database
            Log.Info("Initializing database...").Write();
            if (env.IsDevelopment())
            {
                if (Startup.RunningUnderTest)
                {
                    dbContext.Database.EnsureDeleted();
                }
                else
                {
                    dbContext.Database.Migrate();
                }
            }
            else
            {
                Log.Info("Starting migration...").Write();
                dbContext.Database.Migrate();
                Log.Info("...done.").Write();
            }
            Log.Info("...done.").Write();

            Log.Info("Seeding database...").Write();
            dbSeed.Seed(dbContext).Wait();
            Log.Info("...done.").Write();

            // Hangfire
            app.UseHangfireServer(new BackgroundJobServerOptions
            {
                Queues = new[] { JobQueues.Critical, JobQueues.Normal },
                WorkerCount = 2,
                SchedulePollingInterval = TimeSpan.FromSeconds(30),
                ServerCheckInterval = TimeSpan.FromSeconds(60),
                HeartbeatInterval = TimeSpan.FromSeconds(60)
            });
            app.UseHangfireDashboard("/Admin/Hangfire", new DashboardOptions
            {
                Authorization = new[] { new HangfireAuthorizationFilter() }
            });

            Hangfire.Common.JobHelper.SetSerializerSettings(new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });

            // Configure Impera background jobs
            JobConfig.Configure();
        }

        private IServiceProvider RegisterDependencies(IServiceCollection services)
        {
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            var builder = TestContainerBuilder ?? new ContainerBuilder();

            // Register AutoMapper
            var assemblyNames = Assembly.GetExecutingAssembly().GetReferencedAssemblies();
            var assembliesTypes = assemblyNames
                .Where(a => a.Name.Contains("ImperaPlus", StringComparison.OrdinalIgnoreCase))
                .SelectMany(an => Assembly.Load(an).GetTypes())
                .Where(p => typeof(Profile).IsAssignableFrom(p) && p.IsPublic && !p.IsAbstract)
                .Distinct();

            var autoMapperProfiles = assembliesTypes
                .Select(p => (Profile)Activator.CreateInstance(p)).ToList();

            builder.Register(ctx => new MapperConfiguration(cfg =>
            {
                foreach (var profile in autoMapperProfiles)
                {
                    cfg.AddProfile(profile);
                }
            }));

            builder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>().InstancePerLifetimeScope();

            // Messaging
            if (Environment.IsDevelopment())
            {
                builder.RegisterType<LocalEmailService>().AsImplementedInterfaces();
            }
            else
            {
                builder.RegisterInstance(new MailGunSettings
                {
                    ApiKey = Configuration["MailGunApiKey"],
                    Domain = Configuration["MailGunDomain"]
                });
                builder.RegisterType<MailGunEmailService>().AsImplementedInterfaces();
            }

            //builder.RegisterType<OopsExceptionHandler>().As<IExceptionHandler>();

            builder.RegisterType<ImperaContext>().As<DbContext>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

            builder.RegisterType<DbSeed>().AsSelf();

            // Ensure that we can override it from a test
            builder.RegisterType<UserProvider>().As<IUserProvider>().PreserveExistingDefaults();

            // Register Domain services
            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(IGameRepository)))
                .Where(x => x.Name.EndsWith("Service", StringComparison.OrdinalIgnoreCase) && !x.IsInterface).As(x => x.GetInterfaces());

            // Notification
            builder.RegisterType<GamePushNotificationService>().AsImplementedInterfaces();
            builder.RegisterType<UserPushNotificationService>().AsImplementedInterfaces();

            var jsonSettings = new JsonSerializerSettings()
            {
                DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc,
                DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat
            };
            jsonSettings.Converters.Add(new StringEnumConverter
            {
                CamelCaseText = false,
                AllowIntegerValues = false
            });

            builder.RegisterInstance(JsonSerializer.Create(jsonSettings)).As<JsonSerializer>();

            builder.RegisterModule<Application.DependencyInjectionModule>();
            builder.RegisterModule<Domain.DependencyInjectionModule>();

            builder.RegisterType<BackgroundJobClient>().AsImplementedInterfaces();

            builder.Populate(services);

            IContainer container = builder.Build();
            Startup.Container = container;

            // return container.Resolve<IServiceProvider>();
            return new AutofacServiceProvider(Startup.Container);
        }
    }
}
