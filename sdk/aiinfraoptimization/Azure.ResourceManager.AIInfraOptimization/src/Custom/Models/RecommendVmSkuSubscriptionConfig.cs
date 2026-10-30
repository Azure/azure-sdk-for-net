// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.AIInfraOptimization.Models
{
    public partial class RecommendVmSkuSubscriptionConfig
    {
        // Use a boolean verb prefix without changing the service's includeQuota property.
        /// <summary> Whether to evaluate subscription quota for candidate virtual machine sizes. </summary>
        [CodeGenMember("IncludeQuota")]
        public bool? ShouldIncludeQuota { get; set; }

        // Use a boolean verb prefix without changing the service's includePlacement property.
        /// <summary> Whether to query placement scores for candidate virtual machine sizes with available quota. </summary>
        [CodeGenMember("IncludePlacement")]
        public bool? ShouldIncludePlacement { get; set; }

        // Use a boolean verb prefix without changing the service's includePricing property.
        /// <summary> Whether to fetch subscription-scoped virtual machine pricing. </summary>
        [CodeGenMember("IncludePricing")]
        public bool? ShouldIncludePricing { get; set; }
    }
}
