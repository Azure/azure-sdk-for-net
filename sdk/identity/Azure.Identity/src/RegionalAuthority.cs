// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Microsoft.Identity.Client;

namespace Azure.Identity
{
    /// <summary>
    /// Identifies the regional authority to be used for authentication.
    /// </summary>
    internal readonly struct RegionalAuthority : IEquatable<RegionalAuthority>
    {
        internal const string USWestValue = "westus";
        internal const string USWest2Value = "westus2";
        internal const string USCentralValue = "centralus";
        internal const string USEastValue = "eastus";
        internal const string USEast2Value = "eastus2";
        internal const string USNorthCentralValue = "northcentralus";
        internal const string USSouthCentralValue = "southcentralus";
        internal const string USWestCentralValue = "westcentralus";
        internal const string CanadaCentralValue = "canadacentral";
        internal const string CanadaEastValue = "canadaeast";
        internal const string BrazilSouthValue = "brazilsouth";
        internal const string EuropeNorthValue = "northeurope";
        internal const string EuropeWestValue = "westeurope";
        internal const string UKSouthValue = "uksouth";
        internal const string UKWestValue = "ukwest";
        internal const string FranceCentralValue = "francecentral";
        internal const string FranceSouthValue = "francesouth";
        internal const string SwitzerlandNorthValue = "switzerlandnorth";
        internal const string SwitzerlandWestValue = "switzerlandwest";
        internal const string GermanyNorthValue = "germanynorth";
        internal const string GermanyWestCentralValue = "germanywestcentral";
        internal const string NorwayWestValue = "norwaywest";
        internal const string NorwayEastValue = "norwayeast";
        internal const string AsiaEastValue = "eastasia";
        internal const string AsiaSouthEastValue = "southeastasia";
        internal const string JapanEastValue = "japaneast";
        internal const string JapanWestValue = "japanwest";
        internal const string AustraliaEastValue = "australiaeast";
        internal const string AustraliaSouthEastValue = "australiasoutheast";
        internal const string AustraliaCentralValue = "australiacentral";
        internal const string AustraliaCentral2Value = "australiacentral2";
        internal const string IndiaCentralValue = "centralindia";
        internal const string IndiaSouthValue = "southindia";
        internal const string IndiaWestValue = "westindia";
        internal const string KoreaSouthValue = "koreasouth";
        internal const string KoreaCentralValue = "koreacentral";
        internal const string UAECentralValue = "uaecentral";
        internal const string UAENorthValue = "uaenorth";
        internal const string SouthAfricaNorthValue = "southafricanorth";
        internal const string SouthAfricaWestValue = "southafricawest";
        internal const string ChinaNorthValue = "chinanorth";
        internal const string ChinaEastValue = "chinaeast";
        internal const string ChinaNorth2Value = "chinanorth2";
        internal const string ChinaEast2Value = "chinaeast2";
        internal const string GermanyCentralValue = "germanycentral";
        internal const string GermanyNorthEastValue = "germanynortheast";
        internal const string GovernmentUSVirginiaValue = "usgovvirginia";
        internal const string GovernmentUSIowaValue = "usgoviowa";
        internal const string GovernmentUSArizonaValue = "usgovarizona";
        internal const string GovernmentUSTexasValue = "usgovtexas";
        internal const string GovernmentUSDodEastValue = "usdodeast";
        internal const string GovernmentUSDodCentralValue = "usdodcentral";

        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegionalAuthority"/> structure.
        /// </summary>
        /// <param name="value">The string value of the instance.</param>
        public RegionalAuthority(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// In cases where the region is not known ahead of time, attempts to automatically discover the appropriate <see cref="RegionalAuthority"/>. This works on some azure hosts, such as some VMs (through IDMS), and Azure Functions (using host populated environment variables).
        /// If the auto-detection fails, the non-regional authority is used.
        /// </summary>
        public static RegionalAuthority AutoDiscoverRegion { get; } = new RegionalAuthority(ConfidentialClientApplication.AttemptRegionDiscovery);

        /// <summary>
        /// Uses the <see cref="RegionalAuthority"/> for the Azure 'westus' region.
        /// </summary>
        public static RegionalAuthority USWest { get; } = new RegionalAuthority(USWestValue);

        /// <summary>
        /// Uses the <see cref="RegionalAuthority"/> for the Azure 'westus2' region.
        /// </summary>
        public static RegionalAuthority USWest2 { get; } = new RegionalAuthority(USWest2Value);

        /// <summary>
        /// Uses the <see cref="RegionalAuthority"/> for the Azure 'centralus' region.
        /// </summary>
        public static RegionalAuthority USCentral { get; } = new RegionalAuthority(USCentralValue);

        /// <summary>
        /// Uses the <see cref="RegionalAuthority"/> for the Azure 'eastus' region.
        /// </summary>
        public static RegionalAuthority USEast { get; } = new RegionalAuthority(USEastValue);

        /// <summary>
        /// Uses the <see cref="RegionalAuthority"/> for the Azure 'eastus2' region.
        /// </summary>
        public static RegionalAuthority USEast2 { get; } = new RegionalAuthority(USEast2Value);

        /// <summary>
        /// Uses the <see cref="RegionalAuthority"/> for the Azure 'northcentralus' region.
        /// </summary>
        public static RegionalAuthority USNorthCentral { get; } = new RegionalAuthority(USNorthCentralValue);

        /// <summary>
        /// Uses the <see cref="RegionalAuthority"/> for the Azure 'southcentralus' region.
        /// </summary>
        public static RegionalAuthority USSouthCentral { get; } = new RegionalAuthority(USSouthCentralValue);

        /// <summary>
        /// Uses the <see cref="RegionalAuthority"/> for the Azure 'westcentralus' region.
        /// </summary>
        public static RegionalAuthority USWestCentral { get; } = new RegionalAuthority(USWestCentralValue);

        /// <summary>
        /// Uses the <see cref="RegionalAuthority"/> for the Azure 'canadacentral' region.
        /// </summary>
        public static RegionalAuthority CanadaCentral { get; } = new RegionalAuthority(CanadaCentralValue);

        /// <summary>
        /// Uses the <see cref="RegionalAuthority"/> for the Azure 'canadaeast' region.
        /// </summary>
        public static RegionalAuthority CanadaEast { get; } = new RegionalAuthority(CanadaEastValue);

        /// <summary>
        /// Uses the <see cref="RegionalAuthority"/> for the Azure 'brazilsouth' region.
        /// </summary>
        public static RegionalAuthority BrazilSouth { get; } = new RegionalAuthority(BrazilSouthValue);

        /// <summary>
        /// Uses the <see cref="RegionalAuthority"/> for the Azure 'northeurope' region.
        /// </summary>
        public static RegionalAuthority EuropeNorth { get; } = new RegionalAuthority(EuropeNorthValue);

        /// <summary>
        /// Uses the <see cref="RegionalAuthority"/> for the Azure 'westeurope' region.
        /// </summary>
        public static RegionalAuthority EuropeWest { get; } = new RegionalAuthority(EuropeWestValue);

        /// <summary>
        /// Uses the <see cref="RegionalAuthority"/> for the Azure 'uksouth' region.
        /// </summary>
        public static RegionalAuthority UKSouth { get; } = new RegionalAuthority(UKSouthValue);

        /// <summary>
        /// Uses the <see cref="RegionalAuthority"/> for the Azure 'ukwest' region.
        /// </summary>
        public static RegionalAuthority UKWest { get; } = new RegionalAuthority(UKWestValue);

        /// <summary>
        /// Uses the <see cref="RegionalAuthority"/> for the Azure 'francecentral' region.
        /// </summary>
        public static RegionalAuthority FranceCentral { get; } = new RegionalAuthority(FranceCentralValue);

        /// <summary>
        /// Uses the <see cref="RegionalAuthority"/> for the Azure 'francesouth' region.
        /// </summary>
        public static RegionalAuthority FranceSouth { get; } = new RegionalAuthority(FranceSouthValue);

        /// <summary>
        /// Uses the <see cref="RegionalAuthority"/> for the Azure 'switzerlandnorth' region.
        /// </summary>
        public static RegionalAuthority SwitzerlandNorth { get; } = new RegionalAuthority(SwitzerlandNorthValue);

        /// <summary>
        /// Uses the <see cref="RegionalAuthority"/> for the Azure 'switzerlandwest' region.
        /// </summary>
        public static RegionalAuthority SwitzerlandWest { get; } = new RegionalAuthority(SwitzerlandWestValue);

        /// <summary>
        /// Uses the <see cref="RegionalAuthority"/> for the Azure 'germanynorth' region.
        /// </summary>
        public static RegionalAuthority GermanyNorth { get; } = new RegionalAuthority(GermanyNorthValue);

        /// <summary>
        /// Uses the <see cref="RegionalAuthority"/> for the Azure 'germanywestcentral' region.
        /// </summary>
        public static RegionalAuthority GermanyWestCentral { get; } = new RegionalAuthority(GermanyWestCentralValue);

        /// <summary>
        /// Uses the <see cref="RegionalAuthority"/> for the Azure 'norwaywest' region.
        /// </summary>
        public static RegionalAuthority NorwayWest { get; } = new RegionalAuthority(NorwayWestValue);

        /// <summary>
        /// Uses the <see cref="RegionalAuthority"/> for the Azure 'norwayeast' region.
        /// </summary>
        public static RegionalAuthority NorwayEast { get; } = new RegionalAuthority(NorwayEastValue);

        /// <summary>
        /// Uses the <see cref="RegionalAuthority"/> for the Azure 'eastasia' region.
        /// </summary>
        public static RegionalAuthority AsiaEast { get; } = new RegionalAuthority(AsiaEastValue);

        /// <summary>
        /// Uses the <see cref="RegionalAuthority"/> for the Azure 'southeastasia' region.
        /// </summary>
        public static RegionalAuthority AsiaSouthEast { get; } = new RegionalAuthority(AsiaSouthEastValue);

        /// <summary>
        /// Uses the <see cref="RegionalAuthority"/> for the Azure 'japaneast' region.
        /// </summary>
        public static RegionalAuthority JapanEast { get; } = new RegionalAuthority(JapanEastValue);

        /// <summary>
        /// Uses the <see cref="RegionalAuthority"/> for the Azure 'japanwest' region.
        /// </summary>
        public static RegionalAuthority JapanWest { get; } = new RegionalAuthority(JapanWestValue);

        /// <summary>
        /// Uses the <see cref="RegionalAuthority"/> for the Azure 'australiaeast' region.
        /// </summary>
        public static RegionalAuthority AustraliaEast { get; } = new RegionalAuthority(AustraliaEastValue);

        /// <summary>
        /// Uses the <see cref="RegionalAuthority"/> for the Azure 'australiasoutheast' region.
        /// </summary>
        public static RegionalAuthority AustraliaSouthEast { get; } = new RegionalAuthority(AustraliaSouthEastValue);

        /// <summary>
        /// Uses the <see cref="RegionalAuthority"/> for the Azure 'australiacentral' region.
        /// </summary>
        public static RegionalAuthority AustraliaCentral { get; } = new RegionalAuthority(AustraliaCentralValue);

        /// <summary>
        /// Uses the <see cref="RegionalAuthority"/> for the Azure 'australiacentral2' region.
        /// </summary>
        public static RegionalAuthority AustraliaCentral2 { get; } = new RegionalAuthority(AustraliaCentral2Value);

        /// <summary>
        /// Uses the <see cref="RegionalAuthority"/> for the Azure 'centralindia' region.
        /// </summary>
        public static RegionalAuthority IndiaCentral { get; } = new RegionalAuthority(IndiaCentralValue);

        /// <summary>
        /// Uses the <see cref="RegionalAuthority"/> for the Azure 'southindia' region.
        /// </summary>
        public static RegionalAuthority IndiaSouth { get; } = new RegionalAuthority(IndiaSouthValue);

        /// <summary>
        /// Uses the <see cref="RegionalAuthority"/> for the Azure 'westindia' region.
        /// </summary>
        public static RegionalAuthority IndiaWest { get; } = new RegionalAuthority(IndiaWestValue);

        /// <summary>
        /// Uses the <see cref="RegionalAuthority"/> for the Azure 'koreasouth' region.
        /// </summary>
        public static RegionalAuthority KoreaSouth { get; } = new RegionalAuthority(KoreaSouthValue);

        /// <summary>
        /// Uses the <see cref="RegionalAuthority"/> for the Azure 'koreacentral' region.
        /// </summary>
        public static RegionalAuthority KoreaCentral { get; } = new RegionalAuthority(KoreaCentralValue);

        /// <summary>
        /// Uses the <see cref="RegionalAuthority"/> for the Azure 'uaecentral' region.
        /// </summary>
        public static RegionalAuthority UAECentral { get; } = new RegionalAuthority(UAECentralValue);

        /// <summary>
        /// Uses the <see cref="RegionalAuthority"/> for the Azure 'uaenorth' region.
        /// </summary>
        public static RegionalAuthority UAENorth { get; } = new RegionalAuthority(UAENorthValue);

        /// <summary>
        /// Uses the <see cref="RegionalAuthority"/> for the Azure 'southafricanorth' region.
        /// </summary>
        public static RegionalAuthority SouthAfricaNorth { get; } = new RegionalAuthority(SouthAfricaNorthValue);

        /// <summary>
        /// Uses the <see cref="RegionalAuthority"/> for the Azure 'southafricawest' region.
        /// </summary>
        public static RegionalAuthority SouthAfricaWest { get; } = new RegionalAuthority(SouthAfricaWestValue);

        /// <summary>
        /// Uses the <see cref="RegionalAuthority"/> for the Azure 'chinanorth' region.
        /// </summary>
        public static RegionalAuthority ChinaNorth { get; } = new RegionalAuthority(ChinaNorthValue);

        /// <summary>
        /// Uses the <see cref="RegionalAuthority"/> for the Azure 'chinaeast' region.
        /// </summary>
        public static RegionalAuthority ChinaEast { get; } = new RegionalAuthority(ChinaEastValue);

        /// <summary>
        /// Uses the <see cref="RegionalAuthority"/> for the Azure 'chinanorth2' region.
        /// </summary>
        public static RegionalAuthority ChinaNorth2 { get; } = new RegionalAuthority(ChinaNorth2Value);

        /// <summary>
        /// Uses the <see cref="RegionalAuthority"/> for the Azure 'chinaeast2' region.
        /// </summary>
        public static RegionalAuthority ChinaEast2 { get; } = new RegionalAuthority(ChinaEast2Value);

        /// <summary>
        /// Uses the <see cref="RegionalAuthority"/> for the Azure 'germanycentral' region.
        /// </summary>
        public static RegionalAuthority GermanyCentral { get; } = new RegionalAuthority(GermanyCentralValue);

        /// <summary>
        /// Uses the <see cref="RegionalAuthority"/> for the Azure 'germanynortheast' region.
        /// </summary>
        public static RegionalAuthority GermanyNorthEast { get; } = new RegionalAuthority(GermanyNorthEastValue);

        /// <summary>
        /// Uses the <see cref="RegionalAuthority"/> for the Azure 'usgovvirginia' region.
        /// </summary>
        public static RegionalAuthority GovernmentUSVirginia { get; } = new RegionalAuthority(GovernmentUSVirginiaValue);

        /// <summary>
        /// Uses the <see cref="RegionalAuthority"/> for the Azure 'usgoviowa' region.
        /// </summary>
        public static RegionalAuthority GovernmentUSIowa { get; } = new RegionalAuthority(GovernmentUSIowaValue);

        /// <summary>
        /// Uses the <see cref="RegionalAuthority"/> for the Azure 'usgovarizona' region.
        /// </summary>
        public static RegionalAuthority GovernmentUSArizona { get; } = new RegionalAuthority(GovernmentUSArizonaValue);

        /// <summary>
        /// Uses the <see cref="RegionalAuthority"/> for the Azure 'usgovtexas' region.
        /// </summary>
        public static RegionalAuthority GovernmentUSTexas { get; } = new RegionalAuthority(GovernmentUSTexasValue);

        /// <summary>
        /// Uses the <see cref="RegionalAuthority"/> for the Azure 'usdodeast' region.
        /// </summary>
        public static RegionalAuthority GovernmentUSDodEast { get; } = new RegionalAuthority(GovernmentUSDodEastValue);

        /// <summary>
        /// Uses the <see cref="RegionalAuthority"/> for the Azure 'usdodcentral' region.
        /// </summary>
        public static RegionalAuthority GovernmentUSDodCentral { get; } = new RegionalAuthority(GovernmentUSDodCentralValue);

        /// <summary>
        /// Determines if two <see cref="RegionalAuthority"/> values are the same.
        /// </summary>
        /// <param name="left">The first <see cref="RegionalAuthority"/> to compare.</param>
        /// <param name="right">The second <see cref="RegionalAuthority"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are the same; otherwise, false.</returns>
        public static bool operator ==(RegionalAuthority left, RegionalAuthority right) => left.Equals(right);

        /// <summary>
        /// Determines if two <see cref="RegionalAuthority"/> values are different.
        /// </summary>
        /// <param name="left">The first <see cref="RegionalAuthority"/> to compare.</param>
        /// <param name="right">The second <see cref="RegionalAuthority"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are different; otherwise, false.</returns>
        public static bool operator !=(RegionalAuthority left, RegionalAuthority right) => !left.Equals(right);

        /// <summary>
        /// Converts a string to a <see cref="RegionalAuthority"/>.
        /// </summary>
        /// <param name="value">The string value to convert.</param>
        public static implicit operator RegionalAuthority(string value) => new RegionalAuthority(value);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is RegionalAuthority other && Equals(other);

        /// <inheritdoc/>
        public bool Equals(RegionalAuthority other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;

        /// <inheritdoc/>
        public override string ToString() => _value;

        internal static RegionalAuthority? FromEnvironment()
        {
            return string.IsNullOrEmpty(EnvironmentVariables.AzureRegionalAuthorityName) ? (RegionalAuthority?)null : new RegionalAuthority(EnvironmentVariables.AzureRegionalAuthorityName);
        }
    }
}
