// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Compute.Recommender.Mocking
{
    [CodeGenSuppress("GetComputePlacementScores")]
    public partial class MockableComputeRecommenderSubscriptionResource
    {
        /// <summary> Gets an object representing a <see cref="ComputePlacementScoresResource"/> in the subscription and location. </summary>
        /// <param name="location"> The location to get placement scores for. </param>
        /// <returns> An object representing a <see cref="ComputePlacementScoresResource"/>. </returns>
        public virtual ComputePlacementScoresResource GetComputePlacementScores(AzureLocation location)
        {
            return new ComputePlacementScoresResource(Client, ComputePlacementScoresResource.CreateResourceIdentifier(Id.SubscriptionId, location));
        }
    }
}
