// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Search.Models;

namespace Azure.ResourceManager.Search
{
    /// <summary>
    /// A class representing the SearchService data model.
    /// Describes a search service and its current state.
    /// </summary>
    public partial class SearchServiceData : TrackedResourceData
    {
        /// <summary> A list of IP restriction rules used for an IP firewall. Any IPs that do not match the rules are blocked by the firewall. These rules are only applied when the 'publicNetworkAccess' of the search service is 'enabled'. </summary>
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

        /// <summary> This value can be set to 'enabled' to avoid breaking changes on existing customer resources and templates. If set to 'disabled', traffic over public interface is not allowed, and private endpoint connections would be the exclusive access method. </summary>
        [WirePath("properties.publicNetworkAccess")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SearchServicePublicNetworkAccess? PublicNetworkAccess
        {
            get => PublicInternetAccess.ToString().ToSearchServicePublicNetworkAccess();
            set => PublicInternetAccess = value?.ToSerialString();
        }

        /// <summary> The SKU of the search service. Valid values include: 'free': Shared service. 'basic': Dedicated service with up to 3 replicas. 'standard': Dedicated service with up to 12 partitions and 12 replicas. 'standard2': Similar to standard, but with more capacity per search unit. 'standard3': The largest Standard offering with up to 12 partitions and 12 replicas (or up to 3 partitions with more indexes if you also set the hostingMode property to 'highDensity'). 'storage_optimized_l1': Supports 1TB per partition, up to 12 partitions. 'storage_optimized_l2': Supports 2TB per partition, up to 12 partitions.'. </summary>
        [WirePath("sku.name")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SearchSkuName? SkuName
        {
            get => SearchSkuName.ToString().ToSearchSkuName();
            set => SearchSkuName = value?.ToSerialString();
        }
    }
}
