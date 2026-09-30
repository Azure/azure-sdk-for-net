// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.ResourceManager.Relationships.Models;

namespace Azure.ResourceManager.Relationships.Mocking
{
    public partial class MockableRelationshipsSubscriptionResource
    {
        // Remove after regenerating with the fixes for:
        // https://github.com/Azure/azure-sdk-for-net/issues/63507 (relative continuation tokens).
        // https://github.com/Azure/azure-sdk-for-net/issues/63508 (enumeration cancellation).
        /// <summary> Lists ContainsRelationship resources by subscription ID. </summary>
        /// <param name="filter"> Filters the results by target resource type. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of relationships that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ContainsRelationship> GetBySubscriptionContainsRelationshipsAsync(string filter = default, CancellationToken cancellationToken = default) =>
            new RelationshipsAsyncPageable<ContainsRelationship>(token =>
            {
                var context = new RequestContext { CancellationToken = token };
                return new ContainsRelationshipsGetBySubscriptionContainsRelationshipsAsyncCollectionResultOfT(
                    ContainsRelationshipsRestClient, Guid.Parse(Id.SubscriptionId), filter, context,
                    "MockableRelationshipsSubscriptionResource.GetBySubscriptionContainsRelationships");
            }, Endpoint, cancellationToken);

        /// <summary> Lists ContainsRelationship resources by subscription ID. </summary>
        /// <param name="filter"> Filters the results by target resource type. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of relationships that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ContainsRelationship> GetBySubscriptionContainsRelationships(string filter = default, CancellationToken cancellationToken = default)
        {
            var context = new RequestContext { CancellationToken = cancellationToken };
            var source = new ContainsRelationshipsGetBySubscriptionContainsRelationshipsCollectionResultOfT(
                ContainsRelationshipsRestClient, Guid.Parse(Id.SubscriptionId), filter, context,
                "MockableRelationshipsSubscriptionResource.GetBySubscriptionContainsRelationships");
            return new RelationshipsPageable<ContainsRelationship>(source, Endpoint);
        }
    }
}
