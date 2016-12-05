// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Management.Resource.Fluent.Core
{
    /// <summary>
    /// Enumeration of the Azure datacenter regions. See https://azure.microsoft.com/regions/
    /// </summary>
    public partial class Region
    {
        private static IDictionary<string, Region> regions = new Dictionary<string, Region>();

        #region Americas
        public static readonly Region US_WEST = new Region("westus");
        public static readonly Region US_WEST2 = new Region("westus2");
        public static readonly Region US_CENTRAL = new Region("centralus");
        public static readonly Region US_EAST = new Region("eastus");
        public static readonly Region US_EAST2 = new Region("eastus2");
        public static readonly Region US_NORTH_CENTRAL = new Region("northcentralus");
        public static readonly Region US_SOUTH_CENTRAL = new Region("southcentralus");
        public static readonly Region US_WEST_CENTRAL = new Region("westcentralus");
        public static readonly Region CANADA_CENTRAL = new Region("canadacentral");
        public static readonly Region CANADA_EAST = new Region("canadaeast");
        public static readonly Region BRAZIL_SOUTH = new Region("brazilsouth");
        #endregion

        #region Europe
        public static readonly Region EUROPE_NORTH = new Region("northeurope");
        public static readonly Region EUROPE_WEST = new Region("westeurope");
        public static readonly Region UK_SOUTH = new Region("uksouth");
        public static readonly Region UK_WEST = new Region("ukwest");
        #endregion

        #region Asia
        public static readonly Region ASIA_EAST = new Region("eastasia");
        public static readonly Region ASIA_SOUTHEAST = new Region("southeastasia");
        public static readonly Region JAPAN_EAST = new Region("japaneast");
        public static readonly Region JAPAN_WEST = new Region("japanwest");
        public static readonly Region AUSTRALIA_EAST = new Region("australiaeast");
        public static readonly Region AUSTRALIA_SOUTHEAST = new Region("australiasoutheast");
        public static readonly Region INDIA_CENTRAL = new Region("centralindia");
        public static readonly Region INDIA_SOUTH = new Region("southindia");
        public static readonly Region INDIA_WEST = new Region("westindia");
        #endregion

        #region China
        public static readonly Region CHINA_NORTH = new Region("chinanorth");
        public static readonly Region CHINA_EAST = new Region("chinaeast");
        #endregion

        #region German
        public static readonly Region GERMANY_CENTRAL = new Region("germanycentral");
        public static readonly Region GERMANY_NORTHEAST = new Region("germanynortheast");
        #endregion

        #region Government Cloud
        public static readonly Region GOV_US_VIRGINIA = new Region("usgovvirginia");
        public static readonly Region GOV_US_IOWA = new Region("usgoviowa");
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
    }
}