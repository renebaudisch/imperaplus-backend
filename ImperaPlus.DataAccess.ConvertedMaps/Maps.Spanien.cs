
using ImperaPlus.Domain.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImperaPlus.DataAccess.ConvertedMaps
{
    public static partial class Maps
    {
        public static MapTemplate Spanien()
        {

var mapTemplate = new MapTemplate("Spanien") { Image = "espana.png" };
var country1 = new CountryTemplate("1", "Coruna") { X = 120, Y = 61 };
mapTemplate.Countries.Add(country1);
var country2 = new CountryTemplate("2", "Lugo") { X = 186, Y = 69 };
mapTemplate.Countries.Add(country2);
var country3 = new CountryTemplate("3", "Pontevedra") { X = 110, Y = 113 };
mapTemplate.Countries.Add(country3);
var country4 = new CountryTemplate("4", "Orense") { X = 159, Y = 122 };
mapTemplate.Countries.Add(country4);
var country5 = new CountryTemplate("5", "Asturias") { X = 248, Y = 37 };
mapTemplate.Countries.Add(country5);
var country6 = new CountryTemplate("6", "Cantabria") { X = 395, Y = 47 };
mapTemplate.Countries.Add(country6);
var country7 = new CountryTemplate("7", "Pamplona") { X = 553, Y = 91 };
mapTemplate.Countries.Add(country7);
var country8 = new CountryTemplate("8", "Rioja") { X = 480, Y = 129 };
mapTemplate.Countries.Add(country8);
var country9 = new CountryTemplate("9", "Alava") { X = 477, Y = 37 };
mapTemplate.Countries.Add(country9);
var country10 = new CountryTemplate("10", "Guipuzcoa") { X = 514, Y = 43 };
mapTemplate.Countries.Add(country10);
var country11 = new CountryTemplate("11", "Viscaya") { X = 485, Y = 84 };
mapTemplate.Countries.Add(country11);
var country12 = new CountryTemplate("12", "Leon") { X = 282, Y = 97 };
mapTemplate.Countries.Add(country12);
var country13 = new CountryTemplate("13", "Zamora") { X = 286, Y = 172 };
mapTemplate.Countries.Add(country13);
var country14 = new CountryTemplate("14", "Salamanca") { X = 260, Y = 243 };
mapTemplate.Countries.Add(country14);
var country15 = new CountryTemplate("15", "Palencia") { X = 365, Y = 119 };
mapTemplate.Countries.Add(country15);
var country16 = new CountryTemplate("16", "Valladolid") { X = 341, Y = 181 };
mapTemplate.Countries.Add(country16);
var country17 = new CountryTemplate("17", "Avila") { X = 344, Y = 258 };
mapTemplate.Countries.Add(country17);
var country18 = new CountryTemplate("18", "Burgos") { X = 430, Y = 131 };
mapTemplate.Countries.Add(country18);
var country19 = new CountryTemplate("19", "Segovia") { X = 390, Y = 224 };
mapTemplate.Countries.Add(country19);
var country20 = new CountryTemplate("20", "Soria") { X = 497, Y = 179 };
mapTemplate.Countries.Add(country20);
var country21 = new CountryTemplate("21", "Huesca") { X = 648, Y = 121 };
mapTemplate.Countries.Add(country21);
var country22 = new CountryTemplate("22", "Zaragoza") { X = 579, Y = 184 };
mapTemplate.Countries.Add(country22);
var country23 = new CountryTemplate("23", "Teruel") { X = 607, Y = 262 };
mapTemplate.Countries.Add(country23);
var country24 = new CountryTemplate("24", "Lerida") { X = 726, Y = 136 };
mapTemplate.Countries.Add(country24);
var country25 = new CountryTemplate("25", "Gerona") { X = 833, Y = 126 };
mapTemplate.Countries.Add(country25);
var country26 = new CountryTemplate("26", "Barcelona") { X = 786, Y = 147 };
mapTemplate.Countries.Add(country26);
var country27 = new CountryTemplate("27", "Tarragona") { X = 696, Y = 224 };
mapTemplate.Countries.Add(country27);
var country28 = new CountryTemplate("28", "Castellon") { X = 662, Y = 302 };
mapTemplate.Countries.Add(country28);
var country29 = new CountryTemplate("29", "Valencia") { X = 623, Y = 371 };
mapTemplate.Countries.Add(country29);
var country30 = new CountryTemplate("30", "Alicante") { X = 631, Y = 451 };
mapTemplate.Countries.Add(country30);
var country31 = new CountryTemplate("31", "Mallorca") { X = 868, Y = 336 };
mapTemplate.Countries.Add(country31);
var country32 = new CountryTemplate("32", "Murcia") { X = 582, Y = 489 };
mapTemplate.Countries.Add(country32);
var country33 = new CountryTemplate("33", "Albacente") { X = 536, Y = 419 };
mapTemplate.Countries.Add(country33);
var country34 = new CountryTemplate("34", "Cuenca") { X = 526, Y = 336 };
mapTemplate.Countries.Add(country34);
var country35 = new CountryTemplate("35", "Guadalajara") { X = 476, Y = 250 };
mapTemplate.Countries.Add(country35);
var country36 = new CountryTemplate("36", "Toledo") { X = 352, Y = 326 };
mapTemplate.Countries.Add(country36);
var country37 = new CountryTemplate("37", "Ciudad_Real") { X = 419, Y = 412 };
mapTemplate.Countries.Add(country37);
var country38 = new CountryTemplate("38", "Madrid") { X = 428, Y = 271 };
mapTemplate.Countries.Add(country38);
var country39 = new CountryTemplate("39", "Caceres") { X = 263, Y = 342 };
mapTemplate.Countries.Add(country39);
var country40 = new CountryTemplate("40", "Bandajoz") { X = 247, Y = 426 };
mapTemplate.Countries.Add(country40);
var country41 = new CountryTemplate("41", "Huelva") { X = 207, Y = 518 };
mapTemplate.Countries.Add(country41);
var country42 = new CountryTemplate("42", "Sevilla") { X = 279, Y = 541 };
mapTemplate.Countries.Add(country42);
var country43 = new CountryTemplate("43", "Cadiz") { X = 267, Y = 606 };
mapTemplate.Countries.Add(country43);
var country44 = new CountryTemplate("44", "Malaga") { X = 353, Y = 583 };
mapTemplate.Countries.Add(country44);
var country45 = new CountryTemplate("45", "Cordoba") { X = 344, Y = 483 };
mapTemplate.Countries.Add(country45);
var country46 = new CountryTemplate("46", "Jaen") { X = 428, Y = 490 };
mapTemplate.Countries.Add(country46);
var country47 = new CountryTemplate("47", "Granada") { X = 437, Y = 557 };
mapTemplate.Countries.Add(country47);
var country48 = new CountryTemplate("48", "Almeria") { X = 517, Y = 556 };
mapTemplate.Countries.Add(country48);
var country49 = new CountryTemplate("49", "Santa Cruz") { X = 744, Y = 657 };
mapTemplate.Countries.Add(country49);
var country50 = new CountryTemplate("50", "Las Palmas") { X = 903, Y = 682 };
mapTemplate.Countries.Add(country50);
var continent1 = new Continent("1", 2);
continent1.Countries.Add(country1);
continent1.Countries.Add(country2);
continent1.Countries.Add(country3);
continent1.Countries.Add(country4);
mapTemplate.Continents.Add(continent1);
var continent2 = new Continent("2", 3);
continent2.Countries.Add(country5);
continent2.Countries.Add(country6);
continent2.Countries.Add(country7);
continent2.Countries.Add(country8);
mapTemplate.Continents.Add(continent2);
var continent3 = new Continent("3", 2);
continent3.Countries.Add(country9);
continent3.Countries.Add(country10);
continent3.Countries.Add(country11);
mapTemplate.Continents.Add(continent3);
var continent4 = new Continent("4", 2);
continent4.Countries.Add(country21);
continent4.Countries.Add(country22);
continent4.Countries.Add(country23);
mapTemplate.Continents.Add(continent4);
var continent5 = new Continent("5", 2);
continent5.Countries.Add(country24);
continent5.Countries.Add(country25);
continent5.Countries.Add(country26);
continent5.Countries.Add(country27);
mapTemplate.Continents.Add(continent5);
var continent6 = new Continent("6", 2);
continent6.Countries.Add(country28);
continent6.Countries.Add(country29);
continent6.Countries.Add(country30);
mapTemplate.Continents.Add(continent6);
var continent7 = new Continent("7", 1);
continent7.Countries.Add(country31);
continent7.Countries.Add(country32);
mapTemplate.Continents.Add(continent7);
var continent8 = new Continent("8", 7);
continent8.Countries.Add(country12);
continent8.Countries.Add(country13);
continent8.Countries.Add(country14);
continent8.Countries.Add(country15);
continent8.Countries.Add(country16);
continent8.Countries.Add(country17);
continent8.Countries.Add(country18);
continent8.Countries.Add(country19);
continent8.Countries.Add(country20);
mapTemplate.Continents.Add(continent8);
var continent9 = new Continent("9", 1);
continent9.Countries.Add(country38);
mapTemplate.Continents.Add(continent9);
var continent10 = new Continent("10", 4);
continent10.Countries.Add(country33);
continent10.Countries.Add(country34);
continent10.Countries.Add(country35);
continent10.Countries.Add(country36);
continent10.Countries.Add(country37);
mapTemplate.Continents.Add(continent10);
var continent11 = new Continent("11", 1);
continent11.Countries.Add(country39);
continent11.Countries.Add(country40);
mapTemplate.Continents.Add(continent11);
var continent12 = new Continent("12", 6);
continent12.Countries.Add(country41);
continent12.Countries.Add(country42);
continent12.Countries.Add(country43);
continent12.Countries.Add(country44);
continent12.Countries.Add(country45);
continent12.Countries.Add(country46);
continent12.Countries.Add(country47);
continent12.Countries.Add(country48);
mapTemplate.Continents.Add(continent12);
var continent13 = new Continent("13", 1);
continent13.Countries.Add(country49);
continent13.Countries.Add(country50);
mapTemplate.Continents.Add(continent13);
mapTemplate.Connections.Add(new Connection("1", "2"));
mapTemplate.Connections.Add(new Connection("1", "3"));
mapTemplate.Connections.Add(new Connection("2", "5"));
mapTemplate.Connections.Add(new Connection("2", "12"));
mapTemplate.Connections.Add(new Connection("2", "4"));
mapTemplate.Connections.Add(new Connection("2", "3"));
mapTemplate.Connections.Add(new Connection("2", "1"));
mapTemplate.Connections.Add(new Connection("3", "1"));
mapTemplate.Connections.Add(new Connection("3", "2"));
mapTemplate.Connections.Add(new Connection("3", "4"));
mapTemplate.Connections.Add(new Connection("4", "3"));
mapTemplate.Connections.Add(new Connection("4", "2"));
mapTemplate.Connections.Add(new Connection("4", "12"));
mapTemplate.Connections.Add(new Connection("4", "13"));
mapTemplate.Connections.Add(new Connection("5", "2"));
mapTemplate.Connections.Add(new Connection("5", "12"));
mapTemplate.Connections.Add(new Connection("5", "6"));
mapTemplate.Connections.Add(new Connection("6", "5"));
mapTemplate.Connections.Add(new Connection("6", "12"));
mapTemplate.Connections.Add(new Connection("6", "15"));
mapTemplate.Connections.Add(new Connection("6", "18"));
mapTemplate.Connections.Add(new Connection("6", "9"));
mapTemplate.Connections.Add(new Connection("7", "21"));
mapTemplate.Connections.Add(new Connection("7", "22"));
mapTemplate.Connections.Add(new Connection("7", "8"));
mapTemplate.Connections.Add(new Connection("7", "11"));
mapTemplate.Connections.Add(new Connection("7", "10"));
mapTemplate.Connections.Add(new Connection("8", "11"));
mapTemplate.Connections.Add(new Connection("8", "7"));
mapTemplate.Connections.Add(new Connection("8", "22"));
mapTemplate.Connections.Add(new Connection("8", "20"));
mapTemplate.Connections.Add(new Connection("8", "18"));
mapTemplate.Connections.Add(new Connection("9", "10"));
mapTemplate.Connections.Add(new Connection("9", "11"));
mapTemplate.Connections.Add(new Connection("9", "18"));
mapTemplate.Connections.Add(new Connection("9", "6"));
mapTemplate.Connections.Add(new Connection("10", "7"));
mapTemplate.Connections.Add(new Connection("10", "11"));
mapTemplate.Connections.Add(new Connection("10", "9"));
mapTemplate.Connections.Add(new Connection("11", "9"));
mapTemplate.Connections.Add(new Connection("11", "10"));
mapTemplate.Connections.Add(new Connection("11", "7"));
mapTemplate.Connections.Add(new Connection("11", "8"));
mapTemplate.Connections.Add(new Connection("11", "18"));
mapTemplate.Connections.Add(new Connection("12", "4"));
mapTemplate.Connections.Add(new Connection("12", "2"));
mapTemplate.Connections.Add(new Connection("12", "5"));
mapTemplate.Connections.Add(new Connection("12", "6"));
mapTemplate.Connections.Add(new Connection("12", "15"));
mapTemplate.Connections.Add(new Connection("12", "16"));
mapTemplate.Connections.Add(new Connection("12", "13"));
mapTemplate.Connections.Add(new Connection("13", "4"));
mapTemplate.Connections.Add(new Connection("13", "12"));
mapTemplate.Connections.Add(new Connection("13", "16"));
mapTemplate.Connections.Add(new Connection("13", "14"));
mapTemplate.Connections.Add(new Connection("14", "13"));
mapTemplate.Connections.Add(new Connection("14", "16"));
mapTemplate.Connections.Add(new Connection("14", "17"));
mapTemplate.Connections.Add(new Connection("14", "39"));
mapTemplate.Connections.Add(new Connection("15", "6"));
mapTemplate.Connections.Add(new Connection("15", "18"));
mapTemplate.Connections.Add(new Connection("15", "16"));
mapTemplate.Connections.Add(new Connection("15", "12"));
mapTemplate.Connections.Add(new Connection("16", "12"));
mapTemplate.Connections.Add(new Connection("16", "15"));
mapTemplate.Connections.Add(new Connection("16", "18"));
mapTemplate.Connections.Add(new Connection("16", "19"));
mapTemplate.Connections.Add(new Connection("16", "17"));
mapTemplate.Connections.Add(new Connection("16", "14"));
mapTemplate.Connections.Add(new Connection("16", "13"));
mapTemplate.Connections.Add(new Connection("17", "16"));
mapTemplate.Connections.Add(new Connection("17", "19"));
mapTemplate.Connections.Add(new Connection("17", "38"));
mapTemplate.Connections.Add(new Connection("17", "36"));
mapTemplate.Connections.Add(new Connection("17", "39"));
mapTemplate.Connections.Add(new Connection("17", "14"));
mapTemplate.Connections.Add(new Connection("18", "6"));
mapTemplate.Connections.Add(new Connection("18", "9"));
mapTemplate.Connections.Add(new Connection("18", "11"));
mapTemplate.Connections.Add(new Connection("18", "8"));
mapTemplate.Connections.Add(new Connection("18", "20"));
mapTemplate.Connections.Add(new Connection("18", "19"));
mapTemplate.Connections.Add(new Connection("18", "16"));
mapTemplate.Connections.Add(new Connection("18", "15"));
mapTemplate.Connections.Add(new Connection("19", "16"));
mapTemplate.Connections.Add(new Connection("19", "18"));
mapTemplate.Connections.Add(new Connection("19", "20"));
mapTemplate.Connections.Add(new Connection("19", "35"));
mapTemplate.Connections.Add(new Connection("19", "38"));
mapTemplate.Connections.Add(new Connection("19", "17"));
mapTemplate.Connections.Add(new Connection("20", "8"));
mapTemplate.Connections.Add(new Connection("20", "22"));
mapTemplate.Connections.Add(new Connection("20", "35"));
mapTemplate.Connections.Add(new Connection("20", "19"));
mapTemplate.Connections.Add(new Connection("20", "18"));
mapTemplate.Connections.Add(new Connection("21", "24"));
mapTemplate.Connections.Add(new Connection("21", "22"));
mapTemplate.Connections.Add(new Connection("21", "7"));
mapTemplate.Connections.Add(new Connection("22", "8"));
mapTemplate.Connections.Add(new Connection("22", "7"));
mapTemplate.Connections.Add(new Connection("22", "21"));
mapTemplate.Connections.Add(new Connection("22", "24"));
mapTemplate.Connections.Add(new Connection("22", "27"));
mapTemplate.Connections.Add(new Connection("22", "23"));
mapTemplate.Connections.Add(new Connection("22", "35"));
mapTemplate.Connections.Add(new Connection("22", "20"));
mapTemplate.Connections.Add(new Connection("23", "22"));
mapTemplate.Connections.Add(new Connection("23", "27"));
mapTemplate.Connections.Add(new Connection("23", "28"));
mapTemplate.Connections.Add(new Connection("23", "29"));
mapTemplate.Connections.Add(new Connection("23", "34"));
mapTemplate.Connections.Add(new Connection("23", "35"));
mapTemplate.Connections.Add(new Connection("24", "25"));
mapTemplate.Connections.Add(new Connection("24", "26"));
mapTemplate.Connections.Add(new Connection("24", "27"));
mapTemplate.Connections.Add(new Connection("24", "22"));
mapTemplate.Connections.Add(new Connection("24", "21"));
mapTemplate.Connections.Add(new Connection("25", "26"));
mapTemplate.Connections.Add(new Connection("25", "24"));
mapTemplate.Connections.Add(new Connection("26", "27"));
mapTemplate.Connections.Add(new Connection("26", "24"));
mapTemplate.Connections.Add(new Connection("26", "25"));
mapTemplate.Connections.Add(new Connection("27", "26"));
mapTemplate.Connections.Add(new Connection("27", "24"));
mapTemplate.Connections.Add(new Connection("27", "22"));
mapTemplate.Connections.Add(new Connection("27", "23"));
mapTemplate.Connections.Add(new Connection("27", "28"));
mapTemplate.Connections.Add(new Connection("28", "27"));
mapTemplate.Connections.Add(new Connection("28", "23"));
mapTemplate.Connections.Add(new Connection("28", "29"));
mapTemplate.Connections.Add(new Connection("29", "30"));
mapTemplate.Connections.Add(new Connection("29", "33"));
mapTemplate.Connections.Add(new Connection("29", "34"));
mapTemplate.Connections.Add(new Connection("29", "23"));
mapTemplate.Connections.Add(new Connection("29", "28"));
mapTemplate.Connections.Add(new Connection("30", "29"));
mapTemplate.Connections.Add(new Connection("30", "33"));
mapTemplate.Connections.Add(new Connection("30", "32"));
mapTemplate.Connections.Add(new Connection("31", "32"));
mapTemplate.Connections.Add(new Connection("32", "31"));
mapTemplate.Connections.Add(new Connection("32", "48"));
mapTemplate.Connections.Add(new Connection("32", "47"));
mapTemplate.Connections.Add(new Connection("32", "33"));
mapTemplate.Connections.Add(new Connection("32", "30"));
mapTemplate.Connections.Add(new Connection("33", "34"));
mapTemplate.Connections.Add(new Connection("33", "29"));
mapTemplate.Connections.Add(new Connection("33", "30"));
mapTemplate.Connections.Add(new Connection("33", "32"));
mapTemplate.Connections.Add(new Connection("33", "47"));
mapTemplate.Connections.Add(new Connection("33", "46"));
mapTemplate.Connections.Add(new Connection("33", "37"));
mapTemplate.Connections.Add(new Connection("34", "35"));
mapTemplate.Connections.Add(new Connection("34", "23"));
mapTemplate.Connections.Add(new Connection("34", "29"));
mapTemplate.Connections.Add(new Connection("34", "33"));
mapTemplate.Connections.Add(new Connection("34", "37"));
mapTemplate.Connections.Add(new Connection("34", "36"));
mapTemplate.Connections.Add(new Connection("34", "38"));
mapTemplate.Connections.Add(new Connection("35", "38"));
mapTemplate.Connections.Add(new Connection("35", "19"));
mapTemplate.Connections.Add(new Connection("35", "20"));
mapTemplate.Connections.Add(new Connection("35", "22"));
mapTemplate.Connections.Add(new Connection("35", "23"));
mapTemplate.Connections.Add(new Connection("35", "34"));
mapTemplate.Connections.Add(new Connection("36", "38"));
mapTemplate.Connections.Add(new Connection("36", "34"));
mapTemplate.Connections.Add(new Connection("36", "37"));
mapTemplate.Connections.Add(new Connection("36", "40"));
mapTemplate.Connections.Add(new Connection("36", "39"));
mapTemplate.Connections.Add(new Connection("36", "17"));
mapTemplate.Connections.Add(new Connection("37", "36"));
mapTemplate.Connections.Add(new Connection("37", "34"));
mapTemplate.Connections.Add(new Connection("37", "33"));
mapTemplate.Connections.Add(new Connection("37", "46"));
mapTemplate.Connections.Add(new Connection("37", "45"));
mapTemplate.Connections.Add(new Connection("37", "40"));
mapTemplate.Connections.Add(new Connection("38", "17"));
mapTemplate.Connections.Add(new Connection("38", "19"));
mapTemplate.Connections.Add(new Connection("38", "35"));
mapTemplate.Connections.Add(new Connection("38", "34"));
mapTemplate.Connections.Add(new Connection("38", "36"));
mapTemplate.Connections.Add(new Connection("39", "14"));
mapTemplate.Connections.Add(new Connection("39", "17"));
mapTemplate.Connections.Add(new Connection("39", "36"));
mapTemplate.Connections.Add(new Connection("39", "40"));
mapTemplate.Connections.Add(new Connection("40", "39"));
mapTemplate.Connections.Add(new Connection("40", "36"));
mapTemplate.Connections.Add(new Connection("40", "37"));
mapTemplate.Connections.Add(new Connection("40", "45"));
mapTemplate.Connections.Add(new Connection("40", "42"));
mapTemplate.Connections.Add(new Connection("40", "41"));
mapTemplate.Connections.Add(new Connection("41", "40"));
mapTemplate.Connections.Add(new Connection("41", "42"));
mapTemplate.Connections.Add(new Connection("41", "49"));
mapTemplate.Connections.Add(new Connection("42", "40"));
mapTemplate.Connections.Add(new Connection("42", "45"));
mapTemplate.Connections.Add(new Connection("42", "44"));
mapTemplate.Connections.Add(new Connection("42", "43"));
mapTemplate.Connections.Add(new Connection("42", "41"));
mapTemplate.Connections.Add(new Connection("43", "42"));
mapTemplate.Connections.Add(new Connection("43", "44"));
mapTemplate.Connections.Add(new Connection("43", "50"));
mapTemplate.Connections.Add(new Connection("44", "43"));
mapTemplate.Connections.Add(new Connection("44", "42"));
mapTemplate.Connections.Add(new Connection("44", "45"));
mapTemplate.Connections.Add(new Connection("44", "47"));
mapTemplate.Connections.Add(new Connection("45", "40"));
mapTemplate.Connections.Add(new Connection("45", "37"));
mapTemplate.Connections.Add(new Connection("45", "46"));
mapTemplate.Connections.Add(new Connection("45", "47"));
mapTemplate.Connections.Add(new Connection("45", "44"));
mapTemplate.Connections.Add(new Connection("45", "42"));
mapTemplate.Connections.Add(new Connection("46", "37"));
mapTemplate.Connections.Add(new Connection("46", "33"));
mapTemplate.Connections.Add(new Connection("46", "47"));
mapTemplate.Connections.Add(new Connection("46", "45"));
mapTemplate.Connections.Add(new Connection("47", "46"));
mapTemplate.Connections.Add(new Connection("47", "33"));
mapTemplate.Connections.Add(new Connection("47", "32"));
mapTemplate.Connections.Add(new Connection("47", "48"));
mapTemplate.Connections.Add(new Connection("47", "44"));
mapTemplate.Connections.Add(new Connection("47", "45"));
mapTemplate.Connections.Add(new Connection("48", "47"));
mapTemplate.Connections.Add(new Connection("48", "32"));
mapTemplate.Connections.Add(new Connection("49", "50"));
mapTemplate.Connections.Add(new Connection("49", "41"));
mapTemplate.Connections.Add(new Connection("50", "49"));
mapTemplate.Connections.Add(new Connection("50", "43"));

            return mapTemplate;
		}
    }
}

e;
		}
    }
}

