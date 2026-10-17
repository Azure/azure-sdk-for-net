// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using Azure.Core;
using Azure.ResourceManager.Relationships.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Relationships
{
    public static partial class RelationshipsExtensions
    {
        // Customizing the mockable operations also removes these generated forwarders.
        // Remove after regenerating with the fixes for:
        // https://github.com/Azure/azure-sdk-for-net/issues/63507 (relative continuation tokens).
        // https://github.com/Azure/azure-sdk-for-net/issues/63508 (enumeration cancellation).
        /// <summary> Lists ContainsRelationship resources by resource group. </summary>
        /// <param name="resourceGroupResource"> The resource group to list relationships for. </param>
        /// <param name="filter"> Filters the results by target resource type. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of relationships that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<ContainsRelationship> GetByResourceGroupContainsRelationshipsAsync(this ResourceGroupResource resourceGroupResource, string filter = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableRelationshipsResourceGroupResource(resourceGroupResource).GetByResourceGroupContainsRelationshipsAsync(filter, cancellationToken);
        }

        /// <summary> Lists ContainsRelationship resources by resource group. </summary>
        /// <param name="resourceGroupResource"> The resource group to list relationships for. </param>
        /// <param name="filter"> Filters the results by target resource type. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of relationships that may take multiple service requests to iterate over. </returns>
        public static Pageable<ContainsRelationship> GetByResourceGroupContainsRelationships(this ResourceGroupResource resourceGroupResource, string filter = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableRelationshipsResourceGroupResource(resourceGroupResource).GetByResourceGroupContainsRelationships(filter, cancellationToken);
        }

        /// <summary> Lists ContainsRelationship resources by subscription ID. </summary>
        /// <param name="subscriptionResource"> The subscription to list relationships for. </param>
        /// <param name="filter"> Filters the results by target resource type. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of relationships that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<ContainsRelationship> GetBySubscriptionContainsRelationshipsAsync(this SubscriptionResource subscriptionResource, string filter = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableRelationshipsSubscriptionResource(subscriptionResource).GetBySubscriptionContainsRelationshipsAsync(filter, cancellationToken);
        }

        /// <summary> Lists ContainsRelationship resources by subscription ID. </summary>
        /// <param name="subscriptionResource"> The subscription to list relationships for. </param>
        /// <param name="filter"> Filters the results by target resource type. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of relationships that may take multiple service requests to iterate over. </returns>
        public static Pageable<ContainsRelationship> GetBySubscriptionContainsRelationships(this SubscriptionResource subscriptionResource, string filter = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableRelationshipsSubscriptionResource(subscriptionResource).GetBySubscriptionContainsRelationships(filter, cancellationToken);
        }
    }
}
