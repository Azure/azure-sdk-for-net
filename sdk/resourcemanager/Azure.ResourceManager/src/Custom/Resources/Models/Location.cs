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
        private static Dictionary<string, Location> PublicCloudLocations { get; } = new Dictionary<string, Location>();

        #region Public Cloud Locations

        /// <summary>
        /// Public cloud location for East Asia.
        /// </summary>
        public static Location EastAsia { get; } = CreateStaticReference("eastasia", "East Asia");

        /// <summary>
        /// Public cloud location for Southeast Asia.
        /// </summary>
        public static Location SoutheastAsia { get; } = CreateStaticReference("southeastasia", "Southeast Asia");

        /// <summary>
        /// Public cloud location for Central US.
        /// </summary>
        public static Location CentralUS { get; } = CreateStaticReference("centralus", "Central US");

        /// <summary>
        /// Public cloud location for East US.
        /// </summary>
        public static Location EastUS { get; } = CreateStaticReference("eastus", "East US");

        /// <summary>
        /// Public cloud location for East US 2.
        /// </summary>
        public static Location EastUS2 { get; } = CreateStaticReference("eastus2", "East US 2");

        /// <summary>
        /// Public cloud location for West US.
        /// </summary>
        public static Location WestUS { get; } = CreateStaticReference("westus", "West US");

        /// <summary>
        /// Public cloud location for North Central US.
        /// </summary>
        public static Location NorthCentralUS { get; } = CreateStaticReference("northcentralus", "North Central US");

        /// <summary>
        /// Public cloud location for South Central US.
        /// </summary>
        public static Location SouthCentralUS { get; } = CreateStaticReference("southcentralus", "South Central US");

        /// <summary>
        /// Public cloud location for North Europe.
        /// </summary>
        public static Location NorthEurope { get; } = CreateStaticReference("northeurope", "North Europe");

        /// <summary>
        /// Public cloud location for West Europe.
        /// </summary>
        public static Location WestEurope { get; } = CreateStaticReference("westeurope", "West Europe");

        /// <summary>
        /// Public cloud location for Japan West.
        /// </summary>
        public static Location JapanWest { get; } = CreateStaticReference("japanwest", "Japan West");

        /// <summary>
        /// Public cloud location for Japan East.
        /// </summary>
        public static Location JapanEast { get; } = CreateStaticReference("japaneast", "Japan East");

        /// <summary>
        /// Public cloud location for Brazil South.
        /// </summary>
        public static Location BrazilSouth { get; } = CreateStaticReference("brazilsouth", "Brazil South");

        /// <summary>
        /// Public cloud location for Australia East.
        /// </summary>
        public static Location AustraliaEast { get; } = CreateStaticReference("australiaeast", "Australia East");

        /// <summary>
        /// Public cloud location for Australia Southeast.
        /// </summary>
        public static Location AustraliaSoutheast { get; } = CreateStaticReference("australiasoutheast", "Australia Southeast");

        /// <summary>
        /// Public cloud location for South India.
        /// </summary>
        public static Location SouthIndia { get; } = CreateStaticReference("southindia", "South India");

        /// <summary>
        /// Public cloud location for Central India.
        /// </summary>
        public static Location CentralIndia { get; } = CreateStaticReference("centralindia", "Central India");

        /// <summary>
        /// Public cloud location for West India.
        /// </summary>
        public static Location WestIndia { get; } = CreateStaticReference("westindia", "West India");

        /// <summary>
        /// Public cloud location for Canada Central.
        /// </summary>
        public static Location CanadaCentral { get; } = CreateStaticReference("canadacentral", "Canada Central");

        /// <summary>
        /// Public cloud location for Canada East.
        /// </summary>
        public static Location CanadaEast { get; } = CreateStaticReference("canadaeast", "Canada East");

        /// <summary>
        /// Public cloud location for UK South.
        /// </summary>
        public static Location UKSouth { get; } = CreateStaticReference("uksouth", "UK South");

        /// <summary>
        /// Public cloud location for UK West.
        /// </summary>
        public static Location UKWest { get; } = CreateStaticReference("ukwest", "UK West");

        /// <summary>
        /// Public cloud location for West Central US.
        /// </summary>
        public static Location WestCentralUS { get; } = CreateStaticReference("westcentralus", "West Central US");

        /// <summary>
        /// Public cloud location for West US 2.
        /// </summary>
        public static Location WestUS2 { get; } = CreateStaticReference("westus2", "West US 2");

        /// <summary>
        /// Public cloud location for Korea Central.
        /// </summary>
        public static Location KoreaCentral { get; } = CreateStaticReference("koreacentral", "Korea Central");

        /// <summary>
        /// Public cloud location for Korea South.
        /// </summary>
        public static Location KoreaSouth { get; } = CreateStaticReference("koreasouth", "Korea South");

        /// <summary>
        /// Public cloud location for France Central.
        /// </summary>
        public static Location FranceCentral { get; } = CreateStaticReference("francecentral", "France Central");

        /// <summary>
        /// Public cloud location for France South.
        /// </summary>
        public static Location FranceSouth { get; } = CreateStaticReference("francesouth", "France South");

        /// <summary>
        /// Public cloud location for Australia Central.
        /// </summary>
        public static Location AustraliaCentral { get; } = CreateStaticReference("australiacentral", "Australia Central");

        /// <summary>
        /// Public cloud location for Australia Central 2.
        /// </summary>
        public static Location AustraliaCentral2 { get; } = CreateStaticReference("australiacentral2", "Australia Central 2");

        /// <summary>
        /// Public cloud location for UAE Central.
        /// </summary>
        public static Location UAECentral { get; } = CreateStaticReference("uaecentral", "UAE Central");

        /// <summary>
        /// Public cloud location for UAE North.
        /// </summary>
        public static Location UAENorth { get; } = CreateStaticReference("uaenorth", "UAE North");

        /// <summary>
        /// Public cloud location for South Africa North.
        /// </summary>
        public static Location SouthAfricaNorth { get; } = CreateStaticReference("southafricanorth", "South Africa North");

        /// <summary>
        /// Public cloud location for South Africa West.
        /// </summary>
        public static Location SouthAfricaWest { get; } = CreateStaticReference("southafricawest", "South Africa West");

        /// <summary>
        /// Public cloud location for Switzerland North.
        /// </summary>
        public static Location SwitzerlandNorth { get; } = CreateStaticReference("switzerlandnorth", "Switzerland North");

        /// <summary>
        /// Public cloud location for Switzerland West.
        /// </summary>
        public static Location SwitzerlandWest { get; } = CreateStaticReference("switzerlandwest", "Switzerland West");

        /// <summary>
        /// Public cloud location for Germany North.
        /// </summary>
        public static Location GermanyNorth { get; } = CreateStaticReference("germanynorth", "Germany North");

        /// <summary>
        /// Public cloud location for Germany West Central.
        /// </summary>
        public static Location GermanyWestCentral { get; } = CreateStaticReference("germanywestcentral", "Germany West Central");

        /// <summary>
        /// Public cloud location for Norway West.
        /// </summary>
        public static Location NorwayWest { get; } = CreateStaticReference("norwaywest", "Norway West");

        /// <summary>
        /// Public cloud location for Brazil Southeast.
        /// </summary>
        public static Location BrazilSoutheast { get; } = CreateStaticReference("brazilsoutheast", "Brazil Southeast");

        #endregion

        /// <summary> Initializes a new instance of Location. </summary>
        /// <param name="name"> The location name or the display name. </param>
        public Location(string name)
        {
            if (ReferenceEquals(name, null))
                throw new ArgumentNullException(nameof(name));

            Name = name;
            Location loc;
            if (PublicCloudLocations.TryGetValue(name, out loc))
            {
                DisplayName = loc.DisplayName;
            }
        }

        /// <summary>
        /// Returns the instance of a known cloud by its name if it exists.
        /// </summary>
        /// <param name="name"> The name of the known cloud. </param>
        /// <param name="location"> The location instance returned if found. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool TryGetKnownCloud(string name, out Location location)
        {
            return PublicCloudLocations.TryGetValue(name, out location);
        }

        private static Location CreateStaticReference(string name, string displayName)
        {
            Location location = new Location(name, displayName);
            PublicCloudLocations.Add(name, location);
            return location;
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

            if (ReferenceEquals(this, other))
                return true;

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
