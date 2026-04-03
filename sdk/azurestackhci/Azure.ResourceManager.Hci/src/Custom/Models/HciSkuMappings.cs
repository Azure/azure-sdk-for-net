// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.ResourceManager.Hci.Models
{
    // Backward compat: the generator does not produce a public constructor or public
    // CatalogPlanId/MarketplaceSkuId properties for HciSkuMappings. The old SDK had them.
    public partial class HciSkuMappings
    {
        /// <summary> Initializes a new instance of <see cref="HciSkuMappings"/>. </summary>
        public HciSkuMappings()
        {
        }

        /// <summary> Initializes a new instance of <see cref="HciSkuMappings"/> for backward compatibility. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected HciSkuMappings(string catalogPlanId) : this()
        {
        }

        /// <summary> Identifier of the CatalogPlan for the sku. </summary>
        [WirePath("catalogPlanId")]
        public string CatalogPlanId { get; set; }

        /// <summary> Identifier for the sku. </summary>
        [WirePath("marketplaceSkuId")]
        public string MarketplaceSkuId { get; set; }
    }
}
