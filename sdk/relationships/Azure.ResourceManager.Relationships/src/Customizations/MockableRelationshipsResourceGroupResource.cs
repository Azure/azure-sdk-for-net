// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.ResourceManager.Relationships.Models;

namespace Azure.ResourceManager.Relationships.Mocking
{
    public partial class MockableRelationshipsResourceGroupResource
    {
        // Remove after regenerating with the fixes for:
        // https://github.com/Azure/azure-sdk-for-net/issues/63507 (relative continuation tokens).
        // https://github.com/Azure/azure-sdk-for-net/issues/63508 (enumeration cancellation).
        /// <summary> Lists ContainsRelationship resources by resource group. </summary>
        /// <param name="filter"> Filters the results by target resource type. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of relationships that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ContainsRelationship> GetByResourceGroupContainsRelationshipsAsync(string filter = default, CancellationToken cancellationToken = default) =>
            new RelationshipsAsyncPageable<ContainsRelationship>(token =>
            {
                var context = new RequestContext { CancellationToken = token };
                return new ContainsRelationshipsGetByResourceGroupContainsRelationshipsAsyncCollectionResultOfT(
                    ContainsRelationshipsRestClient, Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, filter, context,
                    "MockableRelationshipsResourceGroupResource.GetByResourceGroupContainsRelationships");
            }, Endpoint, cancellationToken);

        /// <summary> Lists ContainsRelationship resources by resource group. </summary>
        /// <param name="filter"> Filters the results by target resource type. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of relationships that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ContainsRelationship> GetByResourceGroupContainsRelationships(string filter = default, CancellationToken cancellationToken = default)
        {
            var context = new RequestContext { CancellationToken = cancellationToken };
            var source = new ContainsRelationshipsGetByResourceGroupContainsRelationshipsCollectionResultOfT(
                ContainsRelationshipsRestClient, Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, filter, context,
                "MockableRelationshipsResourceGroupResource.GetByResourceGroupContainsRelationships");
            return new RelationshipsPageable<ContainsRelationship>(source, Endpoint);
        }
    }
}
