// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using Microsoft.Azure.Management.Fluent.ServiceBus.Models;
using System;

namespace Microsoft.Azure.Management.Servicebus.Fluent
{
    /// <summary>
    /// Defines values for NamespaceSku.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNlcnZpY2VidXMuTmFtZXNwYWNlU2t1
    public class NamespaceSku
    {
        public static readonly NamespaceSku Basic = new NamespaceSku(new Sku() { Name = SkuName.Basic.ToString(), Tier = SkuTier.Basic.ToString()});
        public static readonly NamespaceSku Standard = new NamespaceSku(new Sku() { Name = SkuName.Standard.ToString(), Tier = SkuTier.Standard.ToString() });
        public static readonly NamespaceSku PremiumCapacity1 = new NamespaceSku(new Sku() { Name = SkuName.Premium.ToString(), Tier = SkuTier.Premium.ToString(), Capacity = 1 });
        public static readonly NamespaceSku PremiumCapacity2 = new NamespaceSku(new Sku() { Name = SkuName.Premium.ToString(), Tier = SkuTier.Premium.ToString(), Capacity = 2 });
        public static readonly NamespaceSku PremiumCapacity4 = new NamespaceSku(new Sku() { Name = SkuName.Premium.ToString(), Tier = SkuTier.Premium.ToString(), Capacity = 4 });

        private Sku sku;
        /// <summary>
        /// Creates Service Bus namespace sku.
        /// </summary>
        /// <param name="name">Sku name.</param>
        /// <param name="tier">Sku tier.</param>
        ///GENMHASH:B0461AE9E717F326AAD03E435B444E9F:1D2C378CEB85EF1064094C6C7A421238
        public  NamespaceSku(string name, string tier) :this(new Sku {
                Capacity = null,
                Name = name,
                Tier = tier
            })
        {
        }

        /// <summary>
        /// Creates Service Bus namespace SKU.
        /// </summary>
        /// <param name="name">Sku name.</param>
        /// <param name="tier">Sku tier.</param>
        /// <param name="capacity">Factor of resources allocated to host Service Bus.</param>
        ///GENMHASH:2A3E3FADEDCAE903C5BB842CE0CE711B:FDBF08CB10EB0889FEE74433151F2D58
        public  NamespaceSku(string name, string tier, int capacity) : this(new Sku {
            Capacity = capacity,
            Name = name,
            Tier = tier
        })
        {
        }

        /// <summary>
        /// Creates Service Bus namespace SKU.
        /// </summary>
        /// <param name="sku">Inner sku model instance.</param>
        ///GENMHASH:83A4F9D017E89DEEE0BDB30D548A3099:016E3E87610C3ACE9D8B84AD2EBB420A
        public  NamespaceSku(Sku sku)
        {
            this.sku = sku;
        }

        /// <return>Sku tier.</return>
        ///GENMHASH:F756CBB3F13EF6198269C107AED6F9A2:A44011D5F68E86AC617B996D6E97D9B5
        public SkuTier Tier
        {
            get
            {
                return SkuTier.Parse(this.sku.Tier);
            }
        }

        /// <return>Sku capacity.</return>
        ///GENMHASH:F0B439C5B2A4923B3B36B77503386DA7:DD0B5064CF829CF304917288A88042A7
        public int Capacity
        {
            get
            {
                if (this.sku.Capacity == null || !this.sku.Capacity.HasValue)
                {
                    return 0;
                }
                return this.sku.Capacity.Value;
            }
        }

        /// <return>Sku name.</return>
        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:BE2A432E51EEBF22D14FCF34FCC5C687
        public SkuName Name
        {
            get
            {
                return SkuName.Parse(this.sku.Name);
            }
        }

        ///GENMHASH:9E6C2387B371ABFFE71039FB9CDF745F:0C2D0EB9EDCADCEEA186E28FD98F6699
        public override string ToString()
        {
            if (this.sku.Capacity != null) {
                return $"{this.sku.Name}_{this.sku.Tier}_{this.sku.Capacity}";
            } else {
                return $"{this.sku.Name}_{this.sku.Tier}";
            }
        }

        public override int GetHashCode()
        {
            int hash = 0;
            if (sku != null)
            {
                if (this.sku.Name != null)
                {
                    hash ^= this.sku.Name.GetHashCode();
                }
                if (this.sku.Tier != null)
                {
                    hash ^= this.Tier.GetHashCode();
                }
                hash ^= this.Capacity.GetHashCode();
            }
            return hash;
        }

        public static bool operator ==(NamespaceSku lhs, NamespaceSku rhs)
        {
            if (ReferenceEquals(lhs, null))
            {
                return ReferenceEquals(rhs, null);
            }
            else
            {
                return lhs.Equals(rhs);
            }
        }

        public static bool operator !=(NamespaceSku lhs, NamespaceSku rhs)
        {
            return !(lhs == rhs);
        }

        public bool Equals(NamespaceSku value)
        {
            if (value == null)
            {
                return null == this.sku;
            }
            else
            {
                if (value.Name != null && !value.Name.Equals(this.sku.Name))
                {
                    return false;
                }

                if (value.Tier != null && !value.Tier.Equals(this.sku.Tier))
                {
                    return false;
                }

                if (value.Capacity != this.sku.Capacity)
                {
                    return false;
                }
                return true;
            }
        }

        public override bool Equals(object obj)
        {
            NamespaceSku rhs = (NamespaceSku)obj;
            if (!(obj is NamespaceSku))
            {
                return false;
            }
            else if (ReferenceEquals(obj, this))
            {
                return true;
            }
            else if (this.sku == null)
            {
                return rhs.sku == null;
            }
            else
            {
                if (rhs.sku.Name != null && !rhs.sku.Name.Equals(this.sku.Name))
                {
                    return false;
                }

                if (rhs.sku.Tier != null && !rhs.sku.Tier.Equals(this.sku.Tier))
                {
                    return false;
                }

                if (rhs.sku.Capacity != this.sku.Capacity)
                {
                    return false;
                }
                return true;
            }
        }
    }
}