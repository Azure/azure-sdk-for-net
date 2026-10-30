// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.AIInfraOptimization.Models
{
    public partial class RecommendVmSkuCost
    {
        // Use the .NET timestamp naming convention while preserving priceAsOf on the wire.
        /// <summary> The date and time the price was observed. </summary>
        [CodeGenMember("PriceAsOf")]
        public DateTimeOffset? PriceObservedOn { get; }
    }
}
