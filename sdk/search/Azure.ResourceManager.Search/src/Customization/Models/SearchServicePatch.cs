// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.Search.Models
{
    /// <summary> The parameters used to update a search service. </summary>
    public partial class SearchServicePatch
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
        /// <remarks> Returns null for values the legacy enum cannot represent. Use <see cref="PublicInternetAccess"/> to read all public network access values. </remarks>
        [WirePath("properties.publicNetworkAccess")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SearchServicePublicNetworkAccess? PublicNetworkAccess
        {
            get => PublicInternetAccess?.ToString().ToSearchServicePublicNetworkAccess();
            set => PublicInternetAccess = value.HasValue ? new SearchServicePublicInternetAccess(value.Value.ToSerialString()) : (SearchServicePublicInternetAccess?)null;
        }

        /// <summary> The SKU of the search service. Valid values include: 'free': Shared service. 'basic': Dedicated service with up to 3 replicas. 'standard': Dedicated service with up to 12 partitions and 12 replicas. 'standard2': Similar to standard, but with more capacity per search unit. 'standard3': The largest Standard offering with up to 12 partitions and 12 replicas (or up to 3 partitions with more indexes if you also set the hostingMode property to 'highDensity'). 'storage_optimized_l1': Supports 1TB per partition, up to 12 partitions. 'storage_optimized_l2': Supports 2TB per partition, up to 12 partitions.'. </summary>
        /// <remarks> Returns null for SKUs the legacy enum cannot represent. Use <see cref="SearchSkuName"/> to read all SKU values. </remarks>
        [WirePath("sku.name")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SearchSkuName? SkuName
        {
            get => SearchSkuName?.ToString().ToSearchSkuName();
            set => SearchSkuName = value.HasValue ? new SearchServiceSkuName(value.Value.ToSerialString()) : (SearchServiceSkuName?)null;
        }

        /// <summary> Gets the legacy status of the search service. Returns null when the status cannot be represented by <see cref="SearchServiceStatus"/>. Use <see cref="ServiceStatus"/> to read all service statuses. </summary>
        [WirePath("properties.status")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use ServiceStatus instead. Status returns null for stopped services and other statuses that SearchServiceStatus cannot represent.")]
        public SearchServiceStatus? Status => ServiceStatus?.ToString().ToSearchServiceStatus();

        /// <summary> Gets the status of the search service, including stopped services and statuses added by the service in the future. </summary>
        [WirePath("properties.status")]
        public SearchServiceState? ServiceStatus => Properties?.Status;
    }
}
