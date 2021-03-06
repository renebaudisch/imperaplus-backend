﻿using ImperaPlus.Domain.Exceptions;
using ImperaPlus.Domain.Map;
using System;
using System.Runtime.Serialization;

namespace ImperaPlus.Domain.Games
{
    public class Country
    {
        private int units;

        private Guid playerId;

        private Guid teamId;

        protected Country()
        {
            this.IsUpdated = false;
        }

        public Country(string countryIdentifier, int units)
            : this()
        {
            this.CountryIdentifier = countryIdentifier;
            this.units = units;
        }

        public Guid PlayerId
        {
            get
            {
                return this.playerId;
            }

            internal set
            {
                if (this.playerId != value)
                {
                    this.IsUpdated = true;
                }

                this.playerId = value;
            }
        }

        public Guid TeamId
        {
            get
            {
                return this.teamId;
            }

            internal set
            {
                if (this.teamId != value)
                {
                    this.IsUpdated = true;
                }

                this.teamId = value;
            }
        }

        public int Units
        {
            get
            {
                return this.units;
            }

            set
            {
                if (this.units != value)
                {
                    this.units = value;
                    this.IsUpdated = true;
                }
            }
        }

        public string CountryIdentifier { get; private set; }

        /// <summary>
        /// Gets a value indicating whether this country has been updated in the current turn
        /// </summary>
        [IgnoreDataMember]
        public bool IsUpdated { get; internal set; }

        public static Country CreateFromTemplate(Map map, CountryTemplate countryTemplate, int units)
        {
            return new Country(countryTemplate.Identifier, units);
        }

        public void PlaceUnits(int units)
        {
            if (units <= 0)
            {
                throw new DomainException(ErrorCode.ZeroNegativeUnits, "Cannot place zero or negative units");
            }

            this.Units += units;
        }

        public bool IsNeutral
        {
            get
            {
                return this.PlayerId == Guid.Empty;
            }
        }
    }
}