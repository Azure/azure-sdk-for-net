// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Azure.ResourceManager.Resources.Models
{
    /// <summary>
    /// Represents an Azure geography region where supported resource providers live.
    /// </summary>
    public partial class Location : IEquatable<Location>, IComparable<Location>
    {
        private const char Space = ' ';

        #region Public Cloud Locations

        /// <summary>
        /// Public cloud location for East Asia.
        /// </summary>
        public static readonly Location EastAsia = new Location { Name = "eastasia", DisplayName = "East Asia", RegionalDisplayName = "(Asia Pacific) East Asia" };

        /// <summary>
        /// Public cloud location for Southeast Asia.
        /// </summary>
        public static readonly Location SoutheastAsia = new Location { Name = "southeastasia", DisplayName = "Southeast Asia", RegionalDisplayName = "(Asia Pacific) Southeast Asia" };

        /// <summary>
        /// Public cloud location for Central US.
        /// </summary>
        public static readonly Location CentralUS = new Location { Name = "centralus", DisplayName = "Central US", RegionalDisplayName = "(US) Central US" };

        /// <summary>
        /// Public cloud location for East US.
        /// </summary>
        public static readonly Location EastUS = new Location { Name = "eastus", DisplayName = "East US", RegionalDisplayName = "(US) East US" };

        /// <summary>
        /// Public cloud location for East US 2.
        /// </summary>
        public static readonly Location EastUS2 = new Location { Name = "eastus2", DisplayName = "East US 2", RegionalDisplayName = "(US) East US 2" };

        /// <summary>
        /// Public cloud location for West US.
        /// </summary>
        public static readonly Location WestUS = new Location { Name = "westus", DisplayName = "West US", RegionalDisplayName = "(US) West US" };

        /// <summary>
        /// Public cloud location for North Central US.
        /// </summary>
        public static readonly Location NorthCentralUS = new Location { Name = "northcentralus", DisplayName = "North Central US", RegionalDisplayName = "(US) North Central US" };

        /// <summary>
        /// Public cloud location for South Central US.
        /// </summary>
        public static readonly Location SouthCentralUS = new Location { Name = "southcentralus", DisplayName = "South Central US", RegionalDisplayName = "(US) South Central US" };

        /// <summary>
        /// Public cloud location for North Europe.
        /// </summary>
        public static readonly Location NorthEurope = new Location { Name = "northeurope", DisplayName = "North Europe", RegionalDisplayName = "(Europe) North Europe" };

        /// <summary>
        /// Public cloud location for West Europe.
        /// </summary>
        public static readonly Location WestEurope = new Location { Name = "westeurope", DisplayName = "West Europe", RegionalDisplayName = "(Europe) West Europe" };

        /// <summary>
        /// Public cloud location for Japan West.
        /// </summary>
        public static readonly Location JapanWest = new Location { Name = "japanwest", DisplayName = "Japan West", RegionalDisplayName = "(Asia Pacific) Japan West" };

        /// <summary>
        /// Public cloud location for Japan East.
        /// </summary>
        public static readonly Location JapanEast = new Location { Name = "japaneast", DisplayName = "Japan East", RegionalDisplayName = "(Asia Pacific) Japan East" };

        /// <summary>
        /// Public cloud location for Brazil South.
        /// </summary>
        public static readonly Location BrazilSouth = new Location { Name = "brazilsouth", DisplayName = "Brazil South", RegionalDisplayName = "(South America) Brazil South" };

        /// <summary>
        /// Public cloud location for Australia East.
        /// </summary>
        public static readonly Location AustraliaEast = new Location { Name = "australiaeast", DisplayName = "Australia East", RegionalDisplayName = "(Asia Pacific) Australia East" };

        /// <summary>
        /// Public cloud location for Australia Southeast.
        /// </summary>
        public static readonly Location AustraliaSoutheast = new Location { Name = "australiasoutheast", DisplayName = "Australia Southeast", RegionalDisplayName = "(Asia Pacific) Australia Southeast" };

        /// <summary>
        /// Public cloud location for South India.
        /// </summary>
        public static readonly Location SouthIndia = new Location { Name = "southindia", DisplayName = "South India", RegionalDisplayName = "(Asia Pacific) South India" };

        /// <summary>
        /// Public cloud location for Central India.
        /// </summary>
        public static readonly Location CentralIndia = new Location { Name = "centralindia", DisplayName = "Central India", RegionalDisplayName = "(Asia Pacific) Central India" };

        /// <summary>
        /// Public cloud location for West India.
        /// </summary>
        public static readonly Location WestIndia = new Location { Name = "westindia", DisplayName = "West India", RegionalDisplayName = "(Asia Pacific) West India" };

        /// <summary>
        /// Public cloud location for Canada Central.
        /// </summary>
        public static readonly Location CanadaCentral = new Location { Name = "canadacentral", DisplayName = "Canada Central", RegionalDisplayName = "(Canada) Canada Central" };

        /// <summary>
        /// Public cloud location for Canada East.
        /// </summary>
        public static readonly Location CanadaEast = new Location { Name = "canadaeast", DisplayName = "Canada East", RegionalDisplayName = "(Canada) Canada East" };

        /// <summary>
        /// Public cloud location for UK South.
        /// </summary>
        public static readonly Location UKSouth = new Location { Name = "uksouth", DisplayName = "UK South", RegionalDisplayName = "(Europe) UK South" };

        /// <summary>
        /// Public cloud location for UK West.
        /// </summary>
        public static readonly Location UKWest = new Location { Name = "ukwest", DisplayName = "UK West", RegionalDisplayName = "(Europe) UK West" };

        /// <summary>
        /// Public cloud location for West Central US.
        /// </summary>
        public static readonly Location WestCentralUS = new Location { Name = "westcentralus", DisplayName = "West Central US", RegionalDisplayName = "(US) West Central US" };

        /// <summary>
        /// Public cloud location for West US 2.
        /// </summary>
        public static readonly Location WestUS2 = new Location { Name = "westus2", DisplayName = "West US 2", RegionalDisplayName = "(US) West US 2" };

        /// <summary>
        /// Public cloud location for Korea Central.
        /// </summary>
        public static readonly Location KoreaCentral = new Location { Name = "koreacentral", DisplayName = "Korea Central", RegionalDisplayName = "(Asia Pacific) Korea Central" };

        /// <summary>
        /// Public cloud location for Korea South.
        /// </summary>
        public static readonly Location KoreaSouth = new Location { Name = "koreasouth", DisplayName = "Korea South", RegionalDisplayName = "(Asia Pacific) Korea South" };

        /// <summary>
        /// Public cloud location for France Central.
        /// </summary>
        public static readonly Location FranceCentral = new Location { Name = "francecentral", DisplayName = "France Central", RegionalDisplayName = "(Europe) France Central" };

        /// <summary>
        /// Public cloud location for France South.
        /// </summary>
        public static readonly Location FranceSouth = new Location { Name = "francesouth", DisplayName = "France South", RegionalDisplayName = "(Europe) France South" };

        /// <summary>
        /// Public cloud location for Australia Central.
        /// </summary>
        public static readonly Location AustraliaCentral = new Location { Name = "australiacentral", DisplayName = "Australia Central", RegionalDisplayName = "(Asia Pacific) Australia Central" };

        /// <summary>
        /// Public cloud location for Australia Central 2.
        /// </summary>
        public static readonly Location AustraliaCentral2 = new Location { Name = "australiacentral2", DisplayName = "Australia Central 2", RegionalDisplayName = "(Asia Pacific) Australia Central 2" };

        /// <summary>
        /// Public cloud location for UAE Central.
        /// </summary>
        public static readonly Location UAECentral = new Location { Name = "uaecentral", DisplayName = "UAE Central", RegionalDisplayName = "(Middle East) UAE Central" };

        /// <summary>
        /// Public cloud location for UAE North.
        /// </summary>
        public static readonly Location UAENorth = new Location { Name = "uaenorth", DisplayName = "UAE North", RegionalDisplayName = "(Middle East) UAE North" };

        /// <summary>
        /// Public cloud location for South Africa North.
        /// </summary>
        public static readonly Location SouthAfricaNorth = new Location { Name = "southafricanorth", DisplayName = "South Africa North", RegionalDisplayName = "(Africa) South Africa North" };

        /// <summary>
        /// Public cloud location for South Africa West.
        /// </summary>
        public static readonly Location SouthAfricaWest = new Location { Name = "southafricawest", DisplayName = "South Africa West", RegionalDisplayName = "(Africa) South Africa West" };

        /// <summary>
        /// Public cloud location for Switzerland North.
        /// </summary>
        public static readonly Location SwitzerlandNorth = new Location { Name = "switzerlandnorth", DisplayName = "Switzerland North", RegionalDisplayName = "(Europe) Switzerland North" };

        /// <summary>
        /// Public cloud location for Switzerland West.
        /// </summary>
        public static readonly Location SwitzerlandWest = new Location { Name = "switzerlandwest", DisplayName = "Switzerland West", RegionalDisplayName = "(Europe) Switzerland West" };

        /// <summary>
        /// Public cloud location for Germany North.
        /// </summary>
        public static readonly Location GermanyNorth = new Location { Name = "germanynorth", DisplayName = "Germany North", RegionalDisplayName = "(Europe) Germany North" };

        /// <summary>
        /// Public cloud location for Germany West Central.
        /// </summary>
        public static readonly Location GermanyWestCentral = new Location { Name = "germanywestcentral", DisplayName = "Germany West Central", RegionalDisplayName = "(Europe) Germany West Central" };

        /// <summary>
        /// Public cloud location for Norway West.
        /// </summary>
        public static readonly Location NorwayWest = new Location { Name = "norwaywest", DisplayName = "Norway West", RegionalDisplayName = "(Europe) Norway West" };

        /// <summary>
        /// Public cloud location for Brazil Southeast.
        /// </summary>
        public static readonly Location BrazilSoutheast = new Location { Name = "brazilsoutheast", DisplayName = "Brazil Southeast", RegionalDisplayName = "(South America) Brazil Southeast" };

        #endregion
        private static readonly Dictionary<string, Location> PublicCloudLocations = new Dictionary<string, Location>()
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

        /// <summary> Initializes a new instance of Location. </summary>
        /// <param name="location"> The location name or the display name. </param>
        public Location(string location)
        {
            Name = GetNameFromDisplayName(location);
            DisplayName = location;
        }

        private static string GetNameFromDisplayName(string name)
        {
            bool foundSpace = false;
            StringBuilder sb = new StringBuilder();
            foreach (char c in name)
            {
                if (c == Space)
                {
                    foundSpace = true;
                    continue;
                }

                sb.Append(char.ToLowerInvariant(c));
            }
            return foundSpace ? sb.ToString() : name;
        }

        /// <summary>
        /// Gets the name of a location object.
        /// </summary>
        /// <returns> The name. </returns>
        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// Creates a new location from a string.
        /// </summary>
        /// <param name="name"> String to convert to Location from. </param>
        /// <exception cref="ArgumentNullException"> Throws if name is null. </exception>
        /// <exception cref="ArgumentException"> Throws if name is not a known public cloud. </exception>
        public static Location FromName(string name)
        {
            if (ReferenceEquals(name, null))
                throw new ArgumentNullException(nameof(name));

            var normalizedName = NormalizationUtility(name);
            Location value;
            if (PublicCloudLocations.TryGetValue(normalizedName, out value))
            {
                return value;
            }

            return new Location(name);
        }

        /// <summary>
        /// Creates a new location implicitly from a string.
        /// </summary>
        /// <param name="other"> String to be assigned in the Name, CanonicalName or DisplayName form. </param>
        public static implicit operator Location(string other)
        {
            if (ReferenceEquals(other, null))
            {
                return null;
            }

            return FromName(other);
        }

        /// <summary>
        /// Detects if a location object is equal to another location instance or a string representing the location name.
        /// </summary>
        /// <param name="other"> Location object or name as a string. </param>
        /// <returns> True or false. </returns>
        public bool Equals(Location other)
        {
            if (ReferenceEquals(other, null))
                return false;

            return Name == other.Name && DisplayName == other.DisplayName;
        }

        /// <summary>
        /// Creates a string implicitly from a Location object.
        /// </summary>
        /// <param name="other"> Location object to be assigned. </param>
        public static implicit operator string(Location other)
        {
            if (ReferenceEquals(other, null))
            {
                return null;
            }

            return other.ToString();
        }

        /// <summary>
        /// Compares this Location name to another Location to expose if it is greater, less or equal than this one.
        /// </summary>
        /// <param name="other"> Location object or name as a string. </param>
        /// <returns> -1 for less than, 0 for equals, 1 for greater than. </returns>
        public int CompareTo(Location other)
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
                    sb.Append(char.ToUpperInvariant(c));
                }
            }

            return sb.ToString();
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            if (obj is not Location other)
                return false;

            return Equals(other);
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        /// <summary>
        /// Compares this <see cref="Location"/> instance with another object and determines if they are equals.
        /// </summary>
        /// <param name="left"> The object on the left side of the operator. </param>
        /// <param name="right"> The object on the right side of the operator. </param>
        /// <returns> True if they are equal, otherwise false. </returns>
        public static bool operator ==(Location left, Location right)
        {
            if (ReferenceEquals(left, null))
            {
                return ReferenceEquals(right, null);
            }

            return left.Equals(right);
        }

        /// <summary>
        /// Compares this <see cref="Location"/> instance with another object and determines if they are equals.
        /// </summary>
        /// <param name="left"> The object on the left side of the operator. </param>
        /// <param name="right"> The object on the right side of the operator. </param>
        /// <returns> True if they are not equal, otherwise false. </returns>
        public static bool operator !=(Location left, Location right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Compares one <see cref="Location"/> with another instance.
        /// </summary>
        /// <param name="left"> The object on the left side of the operator. </param>
        /// <param name="right"> The object on the right side of the operator. </param>
        /// <returns> True if the left object is less than the right. </returns>
        public static bool operator <(Location left, Location right)
        {
            return ReferenceEquals(left, null) ? !ReferenceEquals(right, null) : left.CompareTo(right) < 0;
        }

        /// <summary>
        /// Compares one <see cref="Location"/> with another instance.
        /// </summary>
        /// <param name="left"> The object on the left side of the operator. </param>
        /// <param name="right"> The object on the right side of the operator. </param>
        /// <returns> True if the left object is less than or equal to the right. </returns>
        public static bool operator <=(Location left, Location right)
        {
            return ReferenceEquals(left, null) || left.CompareTo(right) <= 0;
        }

        /// <summary>
        /// Compares one <see cref="Location"/> with another instance.
        /// </summary>
        /// <param name="left"> The object on the left side of the operator. </param>
        /// <param name="right"> The object on the right side of the operator. </param>
        /// <returns> True if the left object is greater than the right. </returns>
        public static bool operator >(Location left, Location right)
        {
            return !ReferenceEquals(left, null) && left.CompareTo(right) > 0;
        }

        /// <summary>
        /// Compares one <see cref="Location"/> with another instance.
        /// </summary>
        /// <param name="left"> The object on the left side of the operator. </param>
        /// <param name="right"> The object on the right side of the operator. </param>
        /// <returns> True if the left object is greater than or equal to the right. </returns>
        public static bool operator >=(Location left, Location right)
        {
            return ReferenceEquals(left, null) ? ReferenceEquals(right, null) : left.CompareTo(right) >= 0;
        }
    }
}
