// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Core
{
    /// <summary>
    /// Enumeration of the Azure datacenter regions. See https://azure.microsoft.com/regions/
    /// </summary>
    public partial class Region
    {
        private static IDictionary<string, Region> regions = new Dictionary<string, Region>();

        #region Americas
        public static readonly Region USWest = new Region("westus");
        public static readonly Region USWest2 = new Region("westus2");
        public static readonly Region USCentral = new Region("centralus");
        public static readonly Region USEast = new Region("eastus");
        public static readonly Region USEast2 = new Region("eastus2");
        public static readonly Region USNorthCentral = new Region("northcentralus");
        public static readonly Region USSouthCentral = new Region("southcentralus");
        public static readonly Region USWestCentral = new Region("westcentralus");
        public static readonly Region CanadaCentral = new Region("canadacentral");
        public static readonly Region CanadaEast = new Region("canadaeast");
        public static readonly Region BrazilSouth = new Region("brazilsouth");
        #endregion

        #region Europe
        public static readonly Region EuropeNorth = new Region("northeurope");
        public static readonly Region EuropeWest = new Region("westeurope");
        public static readonly Region UKSouth = new Region("uksouth");
        public static readonly Region UKWest = new Region("ukwest");
        #endregion

        #region Asia
        public static readonly Region AsiaEast = new Region("eastasia");
        public static readonly Region AsiaSouthEast = new Region("southeastasia");
        public static readonly Region JapanEast = new Region("japaneast");
        public static readonly Region JapanWest = new Region("japanwest");
        public static readonly Region AustraliaEast = new Region("australiaeast");
        public static readonly Region AustraliaSouthEast = new Region("australiasoutheast");
        public static readonly Region IndiaCentral = new Region("centralindia");
        public static readonly Region IndiaSouth = new Region("southindia");
        public static readonly Region IndiaWest = new Region("westindia");
        #endregion

        #region China
        public static readonly Region ChinaNorth = new Region("chinanorth");
        public static readonly Region ChinaEast = new Region("chinaeast");
        #endregion

        #region German
        public static readonly Region GermanyCentral = new Region("germanycentral");
        public static readonly Region GermanyNorthEast = new Region("germanynortheast");
        #endregion

        #region Government Cloud
        public static readonly Region GovernmentUSVirginia = new Region("usgovvirginia");
        public static readonly Region GovernmnetUSIowa = new Region("usgoviowa");
        #endregion

        public static IReadOnlyCollection<Region> Values
        {
            get
            {
                return regions.Values as IReadOnlyCollection<Region>;
            }
        }

        public string Name
        {
            get; private set;
        }

        private Region(string name)
        {
            Name = name.ToLowerInvariant();
            regions.Add(Name, this);
        }

        public static Region Create(string name)
        {
            name = name.Replace(" ", "").ToLowerInvariant();
            Region region = null;
            if (regions.TryGetValue(name, out region))
            {
                return region;
            }
            return new Region(name);
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }

        public static bool operator ==(Region lhs, Region rhs)
        {
            if (object.ReferenceEquals(lhs, null))
            {
                return object.ReferenceEquals(rhs, null);
            }
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Region lhs, Region rhs)
        {
            return !(lhs == rhs);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Region))
            {
                return false;
            }

            if (object.ReferenceEquals(obj, this))
            {
                return true;
            }
            Region rhs = (Region)obj;
            if (Name == null)
            {
                return rhs.Name == null;
            }
            return Name.Equals(rhs.Name, System.StringComparison.OrdinalIgnoreCase);
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}