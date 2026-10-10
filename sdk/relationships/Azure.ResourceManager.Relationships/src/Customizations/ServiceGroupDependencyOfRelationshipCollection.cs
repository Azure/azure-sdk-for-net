// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;

namespace Azure.ResourceManager.Relationships
{
    public partial class ServiceGroupDependencyOfRelationshipCollection
    {
        // Remove after regenerating with the fixes for:
        // https://github.com/Azure/azure-sdk-for-net/issues/63507 (relative continuation tokens).
        // https://github.com/Azure/azure-sdk-for-net/issues/63508 (enumeration cancellation).
        /// <summary> Lists DependencyOfRelationship resources in a service group. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of resources that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ServiceGroupDependencyOfRelationshipResource> GetAllAsync(CancellationToken cancellationToken = default) =>
            new RelationshipsAsyncPageable<ServiceGroupDependencyOfRelationshipResource>(token =>
            {
                var context = new RequestContext { CancellationToken = token };
                return new AsyncPageableWrapper<DependencyOfRelationshipData, ServiceGroupDependencyOfRelationshipResource>(
                    new ServiceGroupDependencyOfRelationshipGetAllAsyncCollectionResultOfT(_serviceGroupDependencyOfRelationshipRestClient, Id.Name, context, "ServiceGroupDependencyOfRelationshipCollection.GetAll"),
                    data => new ServiceGroupDependencyOfRelationshipResource(Client, data));
            }, Endpoint, cancellationToken);

        /// <summary> Lists DependencyOfRelationship resources in a service group. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of resources that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ServiceGroupDependencyOfRelationshipResource> GetAll(CancellationToken cancellationToken = default)
        {
            var context = new RequestContext { CancellationToken = cancellationToken };
            var source = new PageableWrapper<DependencyOfRelationshipData, ServiceGroupDependencyOfRelationshipResource>(
                new ServiceGroupDependencyOfRelationshipGetAllCollectionResultOfT(_serviceGroupDependencyOfRelationshipRestClient, Id.Name, context, "ServiceGroupDependencyOfRelationshipCollection.GetAll"),
                data => new ServiceGroupDependencyOfRelationshipResource(Client, data));
            return new RelationshipsPageable<ServiceGroupDependencyOfRelationshipResource>(source, Endpoint);
        }
    }
}
