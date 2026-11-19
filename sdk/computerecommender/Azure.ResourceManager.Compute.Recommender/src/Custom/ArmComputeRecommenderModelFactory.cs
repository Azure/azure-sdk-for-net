// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.ResourceManager.Compute.Recommender.Models
{
    public static partial class ArmComputeRecommenderModelFactory
    {
        /// <summary> Initializes a placement score for mocking. </summary>
        /// <param name="sku"> The virtual machine SKU size. </param>
        /// <param name="region"> The region. </param>
        /// <param name="availabilityZone"> The availability zone. </param>
        /// <param name="score"> The placement score. </param>
        /// <param name="isQuotaAvailable"> Whether quota is available, when returned by an earlier API version. </param>
        /// <returns> A placement score for mocking. </returns>
        public static ComputeRecommenderPlacementScore ComputeRecommenderPlacementScore(string sku = default, AzureLocation? region = default, string availabilityZone = default, string score = default, bool? isQuotaAvailable = default)
        {
            return ComputeRecommenderPlacementScore(sku, region, availabilityZone, score, null, isQuotaAvailable);
        }

        /// <summary> Initializes a placement score with placement preference for mocking. </summary>
        /// <param name="sku"> The virtual machine SKU size. </param>
        /// <param name="region"> The region. </param>
        /// <param name="availabilityZone"> The availability zone. </param>
        /// <param name="score"> The placement score. </param>
        /// <param name="placementPreference"> Placement preference from 0 to 10 (inclusive). Higher is better. </param>
        /// <param name="isQuotaAvailable"> Whether quota is available, when returned by an earlier API version. </param>
        /// <returns> A placement score for mocking. </returns>
        // Required arguments keep short and null calls bound to the GA overload.
        public static ComputeRecommenderPlacementScore ComputeRecommenderPlacementScore(string sku, AzureLocation? region, string availabilityZone, string score, int? placementPreference, bool? isQuotaAvailable)
        {
            return new ComputeRecommenderPlacementScore(sku, region, availabilityZone, score, placementPreference, isQuotaAvailable, additionalBinaryDataProperties: null);
        }
    }
}
