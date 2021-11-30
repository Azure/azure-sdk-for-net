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
        public static readonly Location EastAsia = new Location { Name = "eastasia", DisplayName = "East Asia" };

        /// <summary>
        /// Public cloud location for Southeast Asia.
        /// </summary>
        public static readonly Location SoutheastAsia = new Location { Name = "southeastasia", DisplayName = "Southeast Asia" };

        /// <summary>
        /// Public cloud location for Central US.
        /// </summary>
        public static readonly Location CentralUS = new Location { Name = "centralus", DisplayName = "Central US" };

        /// <summary>
        /// Public cloud location for East US.
        /// </summary>
        public static readonly Location EastUS = new Location { Name = "eastus", DisplayName = "East US" };

        /// <summary>
        /// Public cloud location for East US 2.
        /// </summary>
        public static readonly Location EastUS2 = new Location { Name = "eastus2", DisplayName = "East US 2" };

        /// <summary>
        /// Public cloud location for West US.
        /// </summary>
        public static readonly Location WestUS = new Location { Name = "westus", DisplayName = "West US" };

        /// <summary>
        /// Public cloud location for North Central US.
        /// </summary>
        public static readonly Location NorthCentralUS = new Location { Name = "northcentralus", DisplayName = "North Central US" };

        /// <summary>
        /// Public cloud location for South Central US.
        /// </summary>
        public static readonly Location SouthCentralUS = new Location { Name = "southcentralus", DisplayName = "South Central US" };

        /// <summary>
        /// Public cloud location for North Europe.
        /// </summary>
        public static readonly Location NorthEurope = new Location { Name = "northeurope", DisplayName = "North Europe" };

        /// <summary>
        /// Public cloud location for West Europe.
        /// </summary>
        public static readonly Location WestEurope = new Location { Name = "westeurope", DisplayName = "West Europe" };

        /// <summary>
        /// Public cloud location for Japan West.
        /// </summary>
        public static readonly Location JapanWest = new Location { Name = "japanwest", DisplayName = "Japan West" };

        /// <summary>
        /// Public cloud location for Japan East.
        /// </summary>
        public static readonly Location JapanEast = new Location { Name = "japaneast", DisplayName = "Japan East" };

        /// <summary>
        /// Public cloud location for Brazil South.
        /// </summary>
        public static readonly Location BrazilSouth = new Location { Name = "brazilsouth", DisplayName = "Brazil South" };

        /// <summary>
        /// Public cloud location for Australia East.
        /// </summary>
        public static readonly Location AustraliaEast = new Location { Name = "australiaeast", DisplayName = "Australia East" };

        /// <summary>
        /// Public cloud location for Australia Southeast.
        /// </summary>
        public static readonly Location AustraliaSoutheast = new Location { Name = "australiasoutheast", DisplayName = "Australia Southeast" };

        /// <summary>
        /// Public cloud location for South India.
        /// </summary>
        public static readonly Location SouthIndia = new Location { Name = "southindia", DisplayName = "South India" };

        /// <summary>
        /// Public cloud location for Central India.
        /// </summary>
        public static readonly Location CentralIndia = new Location { Name = "centralindia", DisplayName = "Central India" };

        /// <summary>
        /// Public cloud location for West India.
        /// </summary>
        public static readonly Location WestIndia = new Location { Name = "westindia", DisplayName = "West India" };

        /// <summary>
        /// Public cloud location for Canada Central.
        /// </summary>
        public static readonly Location CanadaCentral = new Location { Name = "canadacentral", DisplayName = "Canada Central" };

        /// <summary>
        /// Public cloud location for Canada East.
        /// </summary>
        public static readonly Location CanadaEast = new Location { Name = "canadaeast", DisplayName = "Canada East" };

        /// <summary>
        /// Public cloud location for UK South.
        /// </summary>
        public static readonly Location UKSouth = new Location { Name = "uksouth", DisplayName = "UK South" };

        /// <summary>
        /// Public cloud location for UK West.
        /// </summary>
        public static readonly Location UKWest = new Location { Name = "ukwest", DisplayName = "UK West" };

        /// <summary>
        /// Public cloud location for West Central US.
        /// </summary>
        public static readonly Location WestCentralUS = new Location { Name = "westcentralus", DisplayName = "West Central US" };

        /// <summary>
        /// Public cloud location for West US 2.
        /// </summary>
        public static readonly Location WestUS2 = new Location { Name = "westus2", DisplayName = "West US 2" };

        /// <summary>
        /// Public cloud location for Korea Central.
        /// </summary>
        public static readonly Location KoreaCentral = new Location { Name = "koreacentral", DisplayName = "Korea Central" };

        /// <summary>
        /// Public cloud location for Korea South.
        /// </summary>
        public static readonly Location KoreaSouth = new Location { Name = "koreasouth", DisplayName = "Korea South" };

        /// <summary>
        /// Public cloud location for France Central.
        /// </summary>
        public static readonly Location FranceCentral = new Location { Name = "francecentral", DisplayName = "France Central" };

        /// <summary>
        /// Public cloud location for France South.
        /// </summary>
        public static readonly Location FranceSouth = new Location { Name = "francesouth", DisplayName = "France South" };

        /// <summary>
        /// Public cloud location for Australia Central.
        /// </summary>
        public static readonly Location AustraliaCentral = new Location { Name = "australiacentral", DisplayName = "Australia Central" };

        /// <summary>
        /// Public cloud location for Australia Central 2.
        /// </summary>
        public static readonly Location AustraliaCentral2 = new Location { Name = "australiacentral2", DisplayName = "Australia Central 2" };

        /// <summary>
        /// Public cloud location for UAE Central.
        /// </summary>
        public static readonly Location UAECentral = new Location { Name = "uaecentral", DisplayName = "UAE Central" };

        /// <summary>
        /// Public cloud location for UAE North.
        /// </summary>
        public static readonly Location UAENorth = new Location { Name = "uaenorth", DisplayName = "UAE North" };

        /// <summary>
        /// Public cloud location for South Africa North.
        /// </summary>
        public static readonly Location SouthAfricaNorth = new Location { Name = "southafricanorth", DisplayName = "South Africa North" };

        /// <summary>
        /// Public cloud location for South Africa West.
        /// </summary>
        public static readonly Location SouthAfricaWest = new Location { Name = "southafricawest", DisplayName = "South Africa West" };

        /// <summary>
        /// Public cloud location for Switzerland North.
        /// </summary>
        public static readonly Location SwitzerlandNorth = new Location { Name = "switzerlandnorth", DisplayName = "Switzerland North" };

        /// <summary>
        /// Public cloud location for Switzerland West.
        /// </summary>
        public static readonly Location SwitzerlandWest = new Location { Name = "switzerlandwest", DisplayName = "Switzerland West" };

        /// <summary>
        /// Public cloud location for Germany North.
        /// </summary>
        public static readonly Location GermanyNorth = new Location { Name = "germanynorth", DisplayName = "Germany North" };

        /// <summary>
        /// Public cloud location for Germany West Central.
        /// </summary>
        public static readonly Location GermanyWestCentral = new Location { Name = "germanywestcentral", DisplayName = "Germany West Central" };

        /// <summary>
        /// Public cloud location for Norway West.
        /// </summary>
        public static readonly Location NorwayWest = new Location { Name = "norwaywest", DisplayName = "Norway West" };

        /// <summary>
        /// Public cloud location for Brazil Southeast.
        /// </summary>
        public static readonly Location BrazilSoutheast = new Location { Name = "brazilsoutheast", DisplayName = "Brazil Southeast" };

        #endregion
        private static readonly Dictionary<string, Location> PublicCloudLocations = new Dictionary<string, Location>()
        {
            { "eastasia", EastAsia },
            { "southeastasia", SoutheastAsia },
            { "centralus", CentralUS },
            { "eastus", EastUS },
            { "eastus2", EastUS2 },
            { "westus", WestUS },
            { "northcentralus", NorthCentralUS },
            { "southcentralus", SouthCentralUS },
            { "northeurope", NorthEurope },
            { "westeurope", WestEurope },
            { "japanwest", JapanWest },
            { "japaneast", JapanEast },
            { "brazilsouth", BrazilSouth },
            { "australiaeast", AustraliaEast },
            { "australiasoutheast", AustraliaSoutheast },
            { "southindia", SouthIndia },
            { "centralindia", CentralIndia },
            { "westindia", WestIndia },
            { "canadacentral", CanadaCentral },
            { "canadaeast", CanadaEast },
            { "uksouth", UKSouth },
            { "ukwest", UKWest },
            { "westcentralus", WestCentralUS },
            { "westus2", WestUS2 },
            { "koreacentral", KoreaCentral },
            { "koreasouth", KoreaSouth },
            { "francecentral", FranceCentral },
            { "francesouth", FranceSouth },
            { "australiacentral", AustraliaCentral },
            { "australiacentral2", AustraliaCentral2 },
            { "uaecentral", UAECentral },
            { "uaenorth", UAENorth },
            { "southafricanorth", SouthAfricaNorth },
            { "southafricawest", SouthAfricaWest },
            { "switzerlandnorth", SwitzerlandNorth },
            { "switzerlandwest", SwitzerlandWest },
            { "germanynorth", GermanyNorth },
            { "germanywestcentral", GermanyWestCentral },
            { "norwaywest", NorwayWest },
            { "brazilsoutheast", BrazilSoutheast },
        };

        /// <summary> Initializes a new instance of Location. </summary>
        /// <param name="name"> The location name or the display name. </param>
        public Location(string name)
        {
            Name = name;
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
        /// <param name="displayName"> String to convert to Location from. </param>
        /// <exception cref="ArgumentNullException"> Throws if name is null. </exception>
        /// <exception cref="ArgumentException"> Throws if name is not a known public cloud. </exception>
        public static Location FromDisplayName(string displayName)
        {
            if (ReferenceEquals(displayName, null))
                throw new ArgumentNullException(nameof(displayName));

            string name = GetNameFromDisplayName(displayName);
            Location value;
            if (PublicCloudLocations.TryGetValue(name, out value))
            {
                return value;
            }

            return new Location(name, displayName);
        }

        /// <summary>
        /// Creates a new location implicitly from a string.
        /// </summary>
        /// <param name="other"> String to be assigned in the Name form </param>
        public static implicit operator Location(string other)
        {
            if (ReferenceEquals(other, null))
            {
                return null;
            }

            Location value;
            if (PublicCloudLocations.TryGetValue(other, out value))
            {
                return value;
            }

            return new Location(other);
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

            return Name == other.Name;
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
