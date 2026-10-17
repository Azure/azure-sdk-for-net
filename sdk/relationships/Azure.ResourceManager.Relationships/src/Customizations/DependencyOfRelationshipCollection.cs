// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;

namespace Azure.ResourceManager.Relationships
{
    public partial class DependencyOfRelationshipCollection
    {
        // Remove after regenerating with the fixes for:
        // https://github.com/Azure/azure-sdk-for-net/issues/63507 (relative continuation tokens).
        // https://github.com/Azure/azure-sdk-for-net/issues/63508 (enumeration cancellation).
        /// <summary> Lists DependencyOfRelationship resources by parent. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of resources that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DependencyOfRelationshipResource> GetAllAsync(CancellationToken cancellationToken = default) =>
            new RelationshipsAsyncPageable<DependencyOfRelationshipResource>(token =>
            {
                var context = new RequestContext { CancellationToken = token };
                return new AsyncPageableWrapper<DependencyOfRelationshipData, DependencyOfRelationshipResource>(
                    new DependencyOfRelationshipsGetByParentAsyncCollectionResultOfT(_dependencyOfRelationshipsRestClient, Id.ToString(), context, "DependencyOfRelationshipCollection.GetAll"),
                    data => new DependencyOfRelationshipResource(Client, data));
            }, Endpoint, cancellationToken);

        /// <summary> Lists DependencyOfRelationship resources by parent. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of resources that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DependencyOfRelationshipResource> GetAll(CancellationToken cancellationToken = default)
        {
            var context = new RequestContext { CancellationToken = cancellationToken };
            var source = new PageableWrapper<DependencyOfRelationshipData, DependencyOfRelationshipResource>(
                new DependencyOfRelationshipsGetByParentCollectionResultOfT(_dependencyOfRelationshipsRestClient, Id.ToString(), context, "DependencyOfRelationshipCollection.GetAll"),
                data => new DependencyOfRelationshipResource(Client, data));
            return new RelationshipsPageable<DependencyOfRelationshipResource>(source, Endpoint);
        }
    }
}
