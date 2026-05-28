// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Azure.Core
{
    /// <summary>
    /// Represents an Azure geography region where supported resource providers live.
    /// </summary>
    public readonly struct AzureLocation : IEquatable<AzureLocation>
    {
        private const char Space = ' ';

        private static Dictionary<string, AzureLocation> PublicCloudLocations { get; } = new Dictionary<string, AzureLocation>();

        #region Public Cloud Locations

        /// <summary>
        /// Public cloud location for East Asia.
        /// </summary>
        public static AzureLocation EastAsia { get; } = CreateStaticReference("eastasia", "East Asia");

        /// <summary>
        /// Public cloud location for Southeast Asia.
        /// </summary>
        public static AzureLocation SoutheastAsia { get; } = CreateStaticReference("southeastasia", "Southeast Asia");

        /// <summary>
        /// Public cloud location for Central US.
        /// </summary>
        public static AzureLocation CentralUS { get; } = CreateStaticReference("centralus", "Central US");

        /// <summary>
        /// Public cloud location for East US.
        /// </summary>
        public static AzureLocation EastUS { get; } = CreateStaticReference("eastus", "East US");

        /// <summary>
        /// Public cloud location for East US 2.
        /// </summary>
        public static AzureLocation EastUS2 { get; } = CreateStaticReference("eastus2", "East US 2");

        /// <summary>
        /// Public cloud location for West US.
        /// </summary>
        public static AzureLocation WestUS { get; } = CreateStaticReference("westus", "West US");

        /// <summary>
        /// Public cloud location for West US 2.
        /// </summary>
        public static AzureLocation WestUS2 { get; } = CreateStaticReference("westus2", "West US 2");

        /// <summary>
        /// Public cloud location for West US 3.
        /// </summary>
        public static AzureLocation WestUS3 { get; } = CreateStaticReference("westus3", "West US 3");

        /// <summary>
        /// Public cloud location for North Central US.
        /// </summary>
        public static AzureLocation NorthCentralUS { get; } = CreateStaticReference("northcentralus", "North Central US");

        /// <summary>
        /// Public cloud location for South Central US.
        /// </summary>
        public static AzureLocation SouthCentralUS { get; } = CreateStaticReference("southcentralus", "South Central US");

        /// <summary>
        /// Public cloud location for North Europe.
        /// </summary>
        public static AzureLocation NorthEurope { get; } = CreateStaticReference("northeurope", "North Europe");

        /// <summary>
        /// Public cloud location for West Europe.
        /// </summary>
        public static AzureLocation WestEurope { get; } = CreateStaticReference("westeurope", "West Europe");

        /// <summary>
        /// Public cloud location for Japan West.
        /// </summary>
        public static AzureLocation JapanWest { get; } = CreateStaticReference("japanwest", "Japan West");

        /// <summary>
        /// Public cloud location for Japan East.
        /// </summary>
        public static AzureLocation JapanEast { get; } = CreateStaticReference("japaneast", "Japan East");

        /// <summary>
        /// Public cloud location for Brazil South.
        /// </summary>
        public static AzureLocation BrazilSouth { get; } = CreateStaticReference("brazilsouth", "Brazil South");

        /// <summary>
        /// Public cloud location for Australia East.
        /// </summary>
        public static AzureLocation AustraliaEast { get; } = CreateStaticReference("australiaeast", "Australia East");

        /// <summary>
        /// Public cloud location for Australia Southeast.
        /// </summary>
        public static AzureLocation AustraliaSoutheast { get; } = CreateStaticReference("australiasoutheast", "Australia Southeast");

        /// <summary>
        /// Public cloud location for South India.
        /// </summary>
        public static AzureLocation SouthIndia { get; } = CreateStaticReference("southindia", "South India");

        /// <summary>
        /// Public cloud location for Central India.
        /// </summary>
        public static AzureLocation CentralIndia { get; } = CreateStaticReference("centralindia", "Central India");

        /// <summary>
        /// Public cloud location for West India.
        /// </summary>
        public static AzureLocation WestIndia { get; } = CreateStaticReference("westindia", "West India");

        /// <summary>
        /// Public cloud location for Canada Central.
        /// </summary>
        public static AzureLocation CanadaCentral { get; } = CreateStaticReference("canadacentral", "Canada Central");

        /// <summary>
        /// Public cloud location for Canada East.
        /// </summary>
        public static AzureLocation CanadaEast { get; } = CreateStaticReference("canadaeast", "Canada East");

        /// <summary>
        /// Public cloud location for UK South.
        /// </summary>
        public static AzureLocation UKSouth { get; } = CreateStaticReference("uksouth", "UK South");

        /// <summary>
        /// Public cloud location for UK West.
        /// </summary>
        public static AzureLocation UKWest { get; } = CreateStaticReference("ukwest", "UK West");

        /// <summary>
        /// Public cloud location for West Central US.
        /// </summary>
        public static AzureLocation WestCentralUS { get; } = CreateStaticReference("westcentralus", "West Central US");

        /// <summary>
        /// Public cloud location for Korea Central.
        /// </summary>
        public static AzureLocation KoreaCentral { get; } = CreateStaticReference("koreacentral", "Korea Central");

        /// <summary>
        /// Public cloud location for Korea South.
        /// </summary>
        public static AzureLocation KoreaSouth { get; } = CreateStaticReference("koreasouth", "Korea South");

        /// <summary>
        /// Public cloud location for France Central.
        /// </summary>
        public static AzureLocation FranceCentral { get; } = CreateStaticReference("francecentral", "France Central");

        /// <summary>
        /// Public cloud location for France South.
        /// </summary>
        public static AzureLocation FranceSouth { get; } = CreateStaticReference("francesouth", "France South");

        /// <summary>
        /// Public cloud location for Australia Central.
        /// </summary>
        public static AzureLocation AustraliaCentral { get; } = CreateStaticReference("australiacentral", "Australia Central");

        /// <summary>
        /// Public cloud location for Australia Central 2.
        /// </summary>
        public static AzureLocation AustraliaCentral2 { get; } = CreateStaticReference("australiacentral2", "Australia Central 2");

        /// <summary>
        /// Public cloud location for UAE Central.
        /// </summary>
        public static AzureLocation UAECentral { get; } = CreateStaticReference("uaecentral", "UAE Central");

        /// <summary>
        /// Public cloud location for UAE North.
        /// </summary>
        public static AzureLocation UAENorth { get; } = CreateStaticReference("uaenorth", "UAE North");

        /// <summary>
        /// Public cloud location for South Africa North.
        /// </summary>
        public static AzureLocation SouthAfricaNorth { get; } = CreateStaticReference("southafricanorth", "South Africa North");

        /// <summary>
        /// Public cloud location for South Africa West.
        /// </summary>
        public static AzureLocation SouthAfricaWest { get; } = CreateStaticReference("southafricawest", "South Africa West");

        /// <summary>
        /// Public cloud location for Sweden Central.
        /// </summary>
        public static AzureLocation SwedenCentral { get; } = CreateStaticReference("swedencentral", "Sweden Central");

        /// <summary>
        /// Public cloud location for Sweden South.
        /// </summary>
        public static AzureLocation SwedenSouth { get; } = CreateStaticReference("swedensouth", "Sweden South");

        /// <summary>
        /// Public cloud location for Switzerland North.
        /// </summary>
        public static AzureLocation SwitzerlandNorth { get; } = CreateStaticReference("switzerlandnorth", "Switzerland North");

        /// <summary>
        /// Public cloud location for Switzerland West.
        /// </summary>
        public static AzureLocation SwitzerlandWest { get; } = CreateStaticReference("switzerlandwest", "Switzerland West");

        /// <summary>
        /// Public cloud location for Germany North.
        /// </summary>
        public static AzureLocation GermanyNorth { get; } = CreateStaticReference("germanynorth", "Germany North");

        /// <summary>
        /// Public cloud location for Germany West Central.
        /// </summary>
        public static AzureLocation GermanyWestCentral { get; } = CreateStaticReference("germanywestcentral", "Germany West Central");

        /// <summary>
        /// Public cloud location for Germany Central.
        /// </summary>
        public static AzureLocation GermanyCentral { get; } = CreateStaticReference("germanycentral", "Germany Central");

        /// <summary>
        /// Public cloud location for Germany NorthEast.
        /// </summary>
        public static AzureLocation GermanyNorthEast { get; } = CreateStaticReference("germanynortheast", "Germany Northeast");

        /// <summary>
        /// Public cloud location for Norway West.
        /// </summary>
        public static AzureLocation NorwayWest { get; } = CreateStaticReference("norwaywest", "Norway West");

        /// <summary>
        /// Public cloud location for Norway East.
        /// </summary>
        public static AzureLocation NorwayEast { get; } = CreateStaticReference("norwayeast", "Norway East");

        /// <summary>
        /// Public cloud location for Brazil Southeast.
        /// </summary>
        public static AzureLocation BrazilSoutheast { get; } = CreateStaticReference("brazilsoutheast", "Brazil Southeast");

        /// <summary>
        /// Public cloud location for China North.
        /// </summary>
        public static AzureLocation ChinaNorth { get; } = CreateStaticReference("chinanorth", "China North");

        /// <summary>
        /// Public cloud location for China East.
        /// </summary>
        public static AzureLocation ChinaEast { get; } = CreateStaticReference("chinaeast", "China East");

        /// <summary>
        /// Public cloud location for China North 2.
        /// </summary>
        public static AzureLocation ChinaNorth2 { get; } = CreateStaticReference("chinanorth2", "China North 2");

        /// <summary>
        /// Public cloud location for China North 3.
        /// </summary>
        public static AzureLocation ChinaNorth3 { get; } = CreateStaticReference("chinanorth3", "China North 3");

        /// <summary>
        /// Public cloud location for China East 2.
        /// </summary>
        public static AzureLocation ChinaEast2 { get; } = CreateStaticReference("chinaeast2", "China East 2");

        /// <summary>
        /// Public cloud location for China East 3.
        /// </summary>
        public static AzureLocation ChinaEast3 { get; } = CreateStaticReference("chinaeast3", "China East 3");

        /// <summary>
        /// Public cloud location for Qatar Central.
        /// </summary>
        public static AzureLocation QatarCentral { get; } = CreateStaticReference("qatarcentral", "Qatar Central");

        /// <summary>
        /// Public cloud location for US DoD Central.
        /// </summary>
        public static AzureLocation USDoDCentral { get; } = CreateStaticReference("usdodcentral", "US DoD Central");

        /// <summary>
        /// Public cloud location for US DoD East.
        /// </summary>
        public static AzureLocation USDoDEast { get; } = CreateStaticReference("usdodeast", "US DoD East");

        /// <summary>
        /// Public cloud location for US Gov Arizona.
        /// </summary>
        public static AzureLocation USGovArizona { get; } = CreateStaticReference("usgovarizona", "US Gov Arizona");

        /// <summary>
        /// Public cloud location for US Gov Texas.
        /// </summary>
        public static AzureLocation USGovTexas { get; } = CreateStaticReference("usgovtexas", "US Gov Texas");

        /// <summary>
        /// Public cloud location for US Gov Virginia.
        /// </summary>
        public static AzureLocation USGovVirginia { get; } = CreateStaticReference("usgovvirginia", "US Gov Virginia");

        /// <summary>
        /// Public cloud location for US Gov Iowa.
        /// </summary>
        public static AzureLocation USGovIowa { get; } = CreateStaticReference("usgoviowa", "US Gov Iowa");

        /// <summary>
        /// Public cloud location for Israel Central.
        /// </summary>
        public static AzureLocation IsraelCentral { get; } = CreateStaticReference("israelcentral", "Israel Central");

        /// <summary>
        /// Public cloud location for Italy North.
        /// </summary>
        public static AzureLocation ItalyNorth { get; } = CreateStaticReference("italynorth", "Italy North");

        /// <summary>
        /// Public cloud location for Poland Central.
        /// </summary>
        public static AzureLocation PolandCentral { get; } = CreateStaticReference("polandcentral", "Poland Central");

        /// <summary>
        /// Public cloud location for Mexico Central.
        /// </summary>
        public static AzureLocation MexicoCentral { get; } = CreateStaticReference("mexicocentral", "Mexico Central");

        /// <summary>
        /// Public cloud location for Spain Central.
        /// </summary>
        public static AzureLocation SpainCentral { get; } = CreateStaticReference("spaincentral", "Spain Central");

        #endregion

        /// <summary> Initializes a new instance of Location. </summary>
        /// <param name="location"> The location name or the display name. </param>
        public AzureLocation(string location)
        {
            if (ReferenceEquals(location, null))
                throw new ArgumentNullException(nameof(location));

            Name = GetNameFromDisplayName(location, out bool wasConverted);
            var lookUp = wasConverted ? Name : location.ToLowerInvariant();
            if (PublicCloudLocations.TryGetValue(lookUp, out AzureLocation loc))
            {
                Name = loc.Name;
                DisplayName = loc.DisplayName;
            }
            else
            {
                DisplayName = wasConverted ? location : null;
            }
        }

        /// <summary> Initializes a new instance of Location. </summary>
        /// <param name="name"> The location name. </param>
        /// <param name="displayName"> The display name of the location. </param>
        public AzureLocation(string name, string displayName)
        {
            if (ReferenceEquals(name, null))
                throw new ArgumentNullException(nameof(name));

            Name = name;
            DisplayName = displayName;
        }

        private static string GetNameFromDisplayName(string name, out bool foundSpace)
        {
            foundSpace = false;
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
        /// Gets a location name consisting of only lowercase characters without white spaces or any separation character between words, e.g. "westus".
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets a location display name consisting of titlecase words or alphanumeric characters separated by whitespaces, e.g. "West US".
        /// </summary>
        public string? DisplayName { get; }

        private static AzureLocation CreateStaticReference(string name, string displayName)
        {
            AzureLocation location = new AzureLocation(name, displayName);
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
        /// <param name="location"> String to be assigned in the Name form. </param>
        public static implicit operator AzureLocation(string location)
        {
            if (!ReferenceEquals(location, null))
            {
                AzureLocation value;
                if (PublicCloudLocations.TryGetValue(location, out value))
                {
                    return value;
                }
            }

            return new AzureLocation(location!);
        }

        /// <summary>
        /// Detects if a location object is equal to another location instance or a string representing the location name.
        /// </summary>
        /// <param name="other"> AzureLocation object or name as a string. </param>
        /// <returns> True or false. </returns>
        public bool Equals(AzureLocation other)
        {
            return Name == other.Name;
        }

        /// <summary>
        /// Creates a string implicitly from a AzureLocation object.
        /// </summary>
        /// <param name="location"> AzureLocation object to be assigned. </param>
        public static implicit operator string(AzureLocation location)
        {
            return location.ToString();
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object? obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (obj is not AzureLocation other)
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
        /// Compares this <see cref="AzureLocation"/> instance with another object and determines if they are equals.
        /// </summary>
        /// <param name="left"> The object on the left side of the operator. </param>
        /// <param name="right"> The object on the right side of the operator. </param>
        /// <returns> True if they are equal, otherwise false. </returns>
        public static bool operator ==(AzureLocation left, AzureLocation right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares this <see cref="AzureLocation"/> instance with another object and determines if they are equals.
        /// </summary>
        /// <param name="left"> The object on the left side of the operator. </param>
        /// <param name="right"> The object on the right side of the operator. </param>
        /// <returns> True if they are not equal, otherwise false. </returns>
        public static bool operator !=(AzureLocation left, AzureLocation right)
        {
            return !left.Equals(right);
        }
    }
}
