// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.ResourceManager.Compute.Recommender.Mocking;
using Azure.ResourceManager.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Compute.Recommender
{
    [CodeGenSuppress("GetComputePlacementScores", typeof(SubscriptionResource))]
    public static partial class ComputeRecommenderExtensions
    {
        /// <summary>
        /// Gets an object representing a <see cref="ComputePlacementScoresResource"/> in the subscription and location.
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock <see cref="MockableComputeRecommenderSubscriptionResource.GetComputePlacementScores(AzureLocation)"/> instead. </description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The subscription the method will execute against. </param>
        /// <param name="location"> The location to get placement scores for. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        /// <returns> An object representing a <see cref="ComputePlacementScoresResource"/>. </returns>
        public static ComputePlacementScoresResource GetComputePlacementScores(this SubscriptionResource subscriptionResource, AzureLocation location)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableComputeRecommenderSubscriptionResource(subscriptionResource).GetComputePlacementScores(location);
        }
    }
}
