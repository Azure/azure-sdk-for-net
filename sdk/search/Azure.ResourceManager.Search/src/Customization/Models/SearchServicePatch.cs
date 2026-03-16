// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Search.Models
{
    // Backward-compat wrapper properties for SearchServicePatch
    public partial class SearchServicePatch
    {
        /// <summary> Initializes a new instance of <see cref="SearchServicePatch"/>. </summary>
        /// <param name="location"> The location. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SearchServicePatch(AzureLocation location) : this()
        {
            Location = location.ToString();
        }

        /// <summary> A list of IP restriction rules used for an IP firewall. </summary>
        [WirePath("properties.networkRuleSet.ipRules")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<SearchServiceIPRule> IPRules
        {
            get
            {
                if (NetworkRuleSet is null)
                    NetworkRuleSet = new SearchServiceNetworkRuleSet();
                return NetworkRuleSet.IPRules;
            }
        }

        /// <summary> This value can be set to enabled or disabled. </summary>
        [WirePath("properties.publicNetworkAccess")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SearchServicePublicNetworkAccess? PublicNetworkAccess
        {
            get => PublicInternetAccess.ToString().ToSearchServicePublicNetworkAccess();
            set => PublicInternetAccess = value?.ToSerialString();
        }

        /// <summary> The SKU of the search service. </summary>
        [WirePath("sku.name")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SearchSkuName? SkuName
        {
            get => SearchSkuName.ToString().ToSearchSkuName();
            set => SearchSkuName = value?.ToSerialString();
        }
    }
}
