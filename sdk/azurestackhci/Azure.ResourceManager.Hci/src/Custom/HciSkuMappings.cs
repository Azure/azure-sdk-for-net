// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Hci.Models
{
    [CodeGenSuppress("HciSkuMappings")]
    [CodeGenSuppress("CatalogPlanId")]
    [CodeGenSuppress("MarketplaceSkuId")]
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
