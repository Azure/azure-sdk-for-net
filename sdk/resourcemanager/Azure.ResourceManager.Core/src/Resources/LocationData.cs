// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// Represents an Azure geography region where supported resource providers live.
    /// </summary>
    public class LocationData : IEquatable<LocationData>, IComparable<LocationData>
    {
        #region Public Cloud Locations

        /// <summary>
        /// Public cloud location for East Asia.
        /// </summary>
        public static readonly LocationData EastAsia = new LocationData { Name = "eastasia", CanonicalName = "east-asia", DisplayName = "East Asia" };

        /// <summary>
        /// Public cloud location for Southeast Asia.
        /// </summary>
        public static readonly LocationData SoutheastAsia = new LocationData { Name = "southeastasia", CanonicalName = "southeast-asia", DisplayName = "Southeast Asia" };

        /// <summary>
        /// Public cloud location for Central US.
        /// </summary>
        public static readonly LocationData CentralUS = new LocationData { Name = "centralus", CanonicalName = "central-us", DisplayName = "Central US" };

        /// <summary>
        /// Public cloud location for East US.
        /// </summary>
        public static readonly LocationData EastUS = new LocationData { Name = "eastus", CanonicalName = "east-us", DisplayName = "East US" };

        /// <summary>
        /// Public cloud location for East US 2.
        /// </summary>
        public static readonly LocationData EastUS2 = new LocationData { Name = "eastus2", CanonicalName = "east-us-2", DisplayName = "East US 2" };

        /// <summary>
        /// Public cloud location for West US.
        /// </summary>
        public static readonly LocationData WestUS = new LocationData { Name = "westus", CanonicalName = "west-us", DisplayName = "West US" };

        /// <summary>
        /// Public cloud location for North Central US.
        /// </summary>
        public static readonly LocationData NorthCentralUS = new LocationData { Name = "northcentralus", CanonicalName = "north-central-us", DisplayName = "North Central US" };

        /// <summary>
        /// Public cloud location for South Central US.
        /// </summary>
        public static readonly LocationData SouthCentralUS = new LocationData { Name = "southcentralus", CanonicalName = "south-central-us", DisplayName = "South Central US" };

        /// <summary>
        /// Public cloud location for North Europe.
        /// </summary>
        public static readonly LocationData NorthEurope = new LocationData { Name = "northeurope", CanonicalName = "north-europe", DisplayName = "North Europe" };

        /// <summary>
        /// Public cloud location for West Europe.
        /// </summary>
        public static readonly LocationData WestEurope = new LocationData { Name = "westeurope", CanonicalName = "west-europe", DisplayName = "West Europe" };

        /// <summary>
        /// Public cloud location for Japan West.
        /// </summary>
        public static readonly LocationData JapanWest = new LocationData { Name = "japanwest", CanonicalName = "japan-west", DisplayName = "Japan West" };

        /// <summary>
        /// Public cloud location for Japan East.
        /// </summary>
        public static readonly LocationData JapanEast = new LocationData { Name = "japaneast", CanonicalName = "japan-east", DisplayName = "Japan East" };

        /// <summary>
        /// Public cloud location for Brazil South.
        /// </summary>
        public static readonly LocationData BrazilSouth = new LocationData { Name = "brazilsouth", CanonicalName = "brazil-south", DisplayName = "Brazil South" };

        /// <summary>
        /// Public cloud location for Australia East.
        /// </summary>
        public static readonly LocationData AustraliaEast = new LocationData { Name = "australiaeast", CanonicalName = "australia-east", DisplayName = "Australia East" };

        /// <summary>
        /// Public cloud location for Australia Southeast.
        /// </summary>
        public static readonly LocationData AustraliaSoutheast = new LocationData { Name = "australiasoutheast", CanonicalName = "australia-southeast", DisplayName = "Australia Southeast" };

        /// <summary>
        /// Public cloud location for South India.
        /// </summary>
        public static readonly LocationData SouthIndia = new LocationData { Name = "southindia", CanonicalName = "south-india", DisplayName = "South India" };

        /// <summary>
        /// Public cloud location for Central India.
        /// </summary>
        public static readonly LocationData CentralIndia = new LocationData { Name = "centralindia", CanonicalName = "central-india", DisplayName = "Central India" };

        /// <summary>
        /// Public cloud location for West India.
        /// </summary>
        public static readonly LocationData WestIndia = new LocationData { Name = "westindia", CanonicalName = "west-india", DisplayName = "West India" };

        /// <summary>
        /// Public cloud location for Canada Central.
        /// </summary>
        public static readonly LocationData CanadaCentral = new LocationData { Name = "canadacentral", CanonicalName = "canada-central", DisplayName = "Canada Central" };

        /// <summary>
        /// Public cloud location for Canada East.
        /// </summary>
        public static readonly LocationData CanadaEast = new LocationData { Name = "canadaeast", CanonicalName = "canada-east", DisplayName = "Canada East" };

        /// <summary>
        /// Public cloud location for UK South.
        /// </summary>
        public static readonly LocationData UKSouth = new LocationData { Name = "uksouth", CanonicalName = "uk-south", DisplayName = "UK South" };

        /// <summary>
        /// Public cloud location for UK West.
        /// </summary>
        public static readonly LocationData UKWest = new LocationData { Name = "ukwest", CanonicalName = "uk-west", DisplayName = "UK West" };

        /// <summary>
        /// Public cloud location for West Central US.
        /// </summary>
        public static readonly LocationData WestCentralUS = new LocationData { Name = "westcentralus", CanonicalName = "west-central-us", DisplayName = "West Central US" };

        /// <summary>
        /// Public cloud location for West US 2.
        /// </summary>
        public static readonly LocationData WestUS2 = new LocationData { Name = "westus2", CanonicalName = "west-us-2", DisplayName = "West US 2" };

        /// <summary>
        /// Public cloud location for Korea Central.
        /// </summary>
        public static readonly LocationData KoreaCentral = new LocationData { Name = "koreacentral", CanonicalName = "korea-central", DisplayName = "Korea Central" };

        /// <summary>
        /// Public cloud location for Korea South.
        /// </summary>
        public static readonly LocationData KoreaSouth = new LocationData { Name = "koreasouth", CanonicalName = "korea-south", DisplayName = "Korea South" };

        /// <summary>
        /// Public cloud location for France Central.
        /// </summary>
        public static readonly LocationData FranceCentral = new LocationData { Name = "francecentral", CanonicalName = "france-central", DisplayName = "France Central" };

        /// <summary>
        /// Public cloud location for France South.
        /// </summary>
        public static readonly LocationData FranceSouth = new LocationData { Name = "francesouth", CanonicalName = "france-south", DisplayName = "France South" };

        /// <summary>
        /// Public cloud location for Australia Central.
        /// </summary>
        public static readonly LocationData AustraliaCentral = new LocationData { Name = "australiacentral", CanonicalName = "australia-central", DisplayName = "Australia Central" };

        /// <summary>
        /// Public cloud location for Australia Central 2.
        /// </summary>
        public static readonly LocationData AustraliaCentral2 = new LocationData { Name = "australiacentral2", CanonicalName = "australia-central-2", DisplayName = "Australia Central 2" };

        /// <summary>
        /// Public cloud location for UAE Central.
        /// </summary>
        public static readonly LocationData UAECentral = new LocationData { Name = "uaecentral", CanonicalName = "uae-central", DisplayName = "UAE Central" };

        /// <summary>
        /// Public cloud location for UAE North.
        /// </summary>
        public static readonly LocationData UAENorth = new LocationData { Name = "uaenorth", CanonicalName = "uae-north", DisplayName = "UAE North" };

        /// <summary>
        /// Public cloud location for South Africa North.
        /// </summary>
        public static readonly LocationData SouthAfricaNorth = new LocationData { Name = "southafricanorth", CanonicalName = "south-africa-north", DisplayName = "South Africa North" };

        /// <summary>
        /// Public cloud location for South Africa West.
        /// </summary>
        public static readonly LocationData SouthAfricaWest = new LocationData { Name = "southafricawest", CanonicalName = "south-africa-west", DisplayName = "South Africa West" };

        /// <summary>
        /// Public cloud location for Switzerland North.
        /// </summary>
        public static readonly LocationData SwitzerlandNorth = new LocationData { Name = "switzerlandnorth", CanonicalName = "switzerland-north", DisplayName = "Switzerland North" };

        /// <summary>
        /// Public cloud location for Switzerland West.
        /// </summary>
        public static readonly LocationData SwitzerlandWest = new LocationData { Name = "switzerlandwest", CanonicalName = "switzerland-west", DisplayName = "Switzerland West" };

        /// <summary>
        /// Public cloud location for Germany North.
        /// </summary>
        public static readonly LocationData GermanyNorth = new LocationData { Name = "germanynorth", CanonicalName = "germany-north", DisplayName = "Germany North" };

        /// <summary>
        /// Public cloud location for Germany West Central.
        /// </summary>
        public static readonly LocationData GermanyWestCentral = new LocationData { Name = "germanywestcentral", CanonicalName = "germany-west-central", DisplayName = "Germany West Central" };

        /// <summary>
        /// Public cloud location for Norway West.
        /// </summary>
        public static readonly LocationData NorwayWest = new LocationData { Name = "norwaywest", CanonicalName = "norway-west", DisplayName = "Norway West" };

        /// <summary>
        /// Public cloud location for Brazil Southeast.
        /// </summary>
        public static readonly LocationData BrazilSoutheast = new LocationData { Name = "brazilsoutheast", CanonicalName = "brazil-southeast", DisplayName = "Brazil Southeast" };

        #endregion
        private static readonly Dictionary<string, LocationData> PublicCloudLocations = new Dictionary<string, LocationData>()
        {
            { "EASTASIA", EastAsia },
            { "SOUTHEASTASIA", SoutheastAsia },
            { "CENTRALUS", CentralUS },
            { "EASTUS", EastUS },
            { "EASTUS2", EastUS2 },
            { "WESTUS", WestUS },
            { "NORTHCENTRALUS", NorthCentralUS },
            { "SOUTHCENTRALUS", SouthCentralUS },
            { "NORTHEUROPE", NorthEurope },
            { "WESTEUROPE", WestEurope },
            { "JAPANWEST", JapanWest },
            { "JAPANEAST", JapanEast },
            { "BRAZILSOUTH", BrazilSouth },
            { "AUSTRALIAEAST", AustraliaEast },
            { "AUSTRALIASOUTHEAST", AustraliaSoutheast },
            { "SOUTHINDIA", SouthIndia },
            { "CENTRALINDIA", CentralIndia },
            { "WESTINDIA", WestIndia },
            { "CANADACENTRAL", CanadaCentral },
            { "CANADAEAST", CanadaEast },
            { "UKSOUTH", UKSouth },
            { "UKWEST", UKWest },
            { "WESTCENTRALUS", WestCentralUS },
            { "WESTUS2", WestUS2 },
            { "KOREACENTRAL", KoreaCentral },
            { "KOREASOUTH", KoreaSouth },
            { "FRANCECENTRAL", FranceCentral },
            { "FRANCESOUTH", FranceSouth },
            { "AUSTRALIACENTRAL", AustraliaCentral },
            { "AUSTRALIACENTRAL2", AustraliaCentral2 },
            { "UAECENTRAL", UAECentral },
            { "UAENORTH", UAENorth },
            { "SOUTHAFRICANORTH", SouthAfricaNorth },
            { "SOUTHAFRICAWEST", SouthAfricaWest },
            { "SWITZERLANDNORTH", SwitzerlandNorth },
            { "SWITZERLANDWEST", SwitzerlandWest },
            { "GERMANYNORTH", GermanyNorth },
            { "GERMANYWESTCENTRAL", GermanyWestCentral },
            { "NORWAYWEST", NorwayWest },
            { "BRAZILSOUTHEAST", BrazilSoutheast },
        };

        private const string CanonicalPattern = "^[a-z]+(-[a-z]+)+(-[1-9])?$";
        private const string DisplayPattern = "^[A-Z]+[a-z]*( [A-Z]+[a-z]*)+( [1-9])?$";
        private const string RegexDash = @"-";
        private const string RegexWhitespace = @" ";

        private LocationData()
        {
        }

        private LocationData(string location)
        {
            switch (DetectNameType(location))
            {
                case NameType.Name:
                    Name = location;
                    CanonicalName = location;
                    DisplayName = location;
                    break;
                case NameType.CanonicalName:
                    Name = GetDefaultNameFromCanonicalName(location);
                    CanonicalName = location;
                    DisplayName = GetDisplayNameFromCanonicalName(location);
                    break;
                case NameType.DisplayName:
                    Name = GetDefaultNameFromDisplayName(location);
                    CanonicalName = GetCanonicalNameFromDisplayName(location);
                    DisplayName = location;
                    break;
            }
        }

        private enum NameType
        {
            Name,
            CanonicalName,
            DisplayName,
        }

        /// <summary>
        /// Gets default Location object: West US.
        /// </summary>
        public static ref readonly LocationData Default => ref WestUS;

        /// <summary>
        /// Gets a location name consisting of only lowercase characters without white spaces or any separation character between words, e.g. "westus".
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets a location canonical name consisting of only lowercase chararters with a '-' between words, e.g. "west-us".
        /// </summary>
        public string CanonicalName { get; private set; }

        /// <summary>
        /// Gets a location display name consisting of titlecase words or alphanumeric characters separated by whitespaces, e.g. "West US"
        /// </summary>
        public string DisplayName { get; private set; }

        /// <summary>
        /// Creates a new location implicitly from a string.
        /// </summary>
        /// <param name="other"> String to be assigned in the Name, CanonicalName or DisplayName form. </param>
        public static implicit operator LocationData(string other)
        {
            if (other == null)
                return null;

            var normalizedName = NormalizationUtility(other);
            LocationData value;
            if (PublicCloudLocations.TryGetValue(normalizedName, out value))
            {
                return value;
            }

            return new LocationData(other);
        }

        /// <summary>
        /// Creates a string implicitly from a Location object.
        /// </summary>
        /// <param name="other"> Location object to be assigned. </param>
        public static implicit operator string(LocationData other)
        {
            if (other == null)
            {
                return null;
            }

            return other.ToString();
        }

        /// <summary>
        /// Detects if a location object is equal to another location instance or a string representing the location name.
        /// </summary>
        /// <param name="other"> Location object or name as a string. </param>
        /// <returns> True or false. </returns>
        public bool Equals(LocationData other)
        {
            if (other == null)
                return false;

            return Name == other.Name && CanonicalName == other.CanonicalName && DisplayName == other.DisplayName;
        }

        /// <summary>
        /// Gets the display name of a location object.
        /// </summary>
        /// <returns> Display name. </returns>
        public override string ToString()
        {
            return DisplayName;
        }

        /// <summary>
        /// Compares this Location name to another Location to expose if it is greater, less or equal than this one.
        /// </summary>
        /// <param name="other"> Location object or name as a string. </param>
        /// <returns> -1 for less than, 0 for equals, 1 for greater than. </returns>
        public int CompareTo(LocationData other)
        {
            if (ReferenceEquals(other, null))
            {
                return 1;
            }

            return string.Compare(Name, other.Name, StringComparison.InvariantCulture);
        }

        private static string NormalizationUtility(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }

            var sb = new StringBuilder(value.Length);
            for (var index = 0; index < value.Length; ++index)
            {
                var c = value[index];
                if (char.IsLetterOrDigit(c))
                {
                    sb.Append(c);
                }
            }

            return sb.ToString().ToUpperInvariant();
        }

        private static NameType DetectNameType(string location)
        {
            if (Regex.IsMatch(location, CanonicalPattern))
            {
                return NameType.CanonicalName;
            }
            else if (Regex.IsMatch(location, DisplayPattern))
            {
                return NameType.DisplayName;
            }
            else
            {
                return NameType.Name;
            }
        }

        private static string GetCanonicalNameFromDisplayName(string name)
        {
            return name.Replace(RegexWhitespace, RegexDash).ToLower(CultureInfo.InvariantCulture);
        }

        private static string GetDisplayNameFromCanonicalName(string name)
        {
            char[] chName = name.ToCharArray();
            chName[0] = char.ToUpper(chName[0], CultureInfo.InvariantCulture);

            for (int i = 0; i < chName.Length - 1; i++)
            {
                if (chName[i] == '-')
                {
                    chName[i] = ' ';
                    chName[i + 1] = char.ToUpper(chName[i + 1], CultureInfo.InvariantCulture);
                }
            }

            return new string(chName);
        }

        private static string GetDefaultNameFromCanonicalName(string name)
        {
            return name.Replace(RegexDash, string.Empty);
        }

        private static string GetDefaultNameFromDisplayName(string name)
        {
            return name.Replace(RegexWhitespace, string.Empty).ToLower(CultureInfo.InvariantCulture);
        }
    }
}
