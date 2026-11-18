// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Compute.Recommender.Models
{
    [CodeGenSerialization(nameof(IsQuotaAvailable), "isQuotaAvailable")]
    public partial class ComputeRecommenderPlacementScore
    {
        // A private setter preserves GA wire serialization without exposing public mutability.
        /// <summary> Indicates whether quota is available, when returned by an earlier API version. </summary>
        public bool? IsQuotaAvailable { get; private set; }
    }
}
