// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;

namespace Azure.ResourceManager.Relationships
{
    public partial class ServiceGroupMemberRelationshipCollection
    {
        // Remove after regenerating with the fixes for:
        // https://github.com/Azure/azure-sdk-for-net/issues/63507 (relative continuation tokens).
        // https://github.com/Azure/azure-sdk-for-net/issues/63508 (enumeration cancellation).
        /// <summary> Lists ServiceGroupMemberRelationship resources by parent. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of resources that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ServiceGroupMemberRelationshipResource> GetAllAsync(CancellationToken cancellationToken = default) =>
            new RelationshipsAsyncPageable<ServiceGroupMemberRelationshipResource>(token =>
            {
                var context = new RequestContext { CancellationToken = token };
                return new AsyncPageableWrapper<ServiceGroupMemberRelationshipData, ServiceGroupMemberRelationshipResource>(
                    new ServiceGroupMemberRelationshipsGetByParentAsyncCollectionResultOfT(_serviceGroupMemberRelationshipsRestClient, Id.ToString(), context, "ServiceGroupMemberRelationshipCollection.GetAll"),
                    data => new ServiceGroupMemberRelationshipResource(Client, data));
            }, Endpoint, cancellationToken);

        /// <summary> Lists ServiceGroupMemberRelationship resources by parent. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of resources that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ServiceGroupMemberRelationshipResource> GetAll(CancellationToken cancellationToken = default)
        {
            var context = new RequestContext { CancellationToken = cancellationToken };
            var source = new PageableWrapper<ServiceGroupMemberRelationshipData, ServiceGroupMemberRelationshipResource>(
                new ServiceGroupMemberRelationshipsGetByParentCollectionResultOfT(_serviceGroupMemberRelationshipsRestClient, Id.ToString(), context, "ServiceGroupMemberRelationshipCollection.GetAll"),
                data => new ServiceGroupMemberRelationshipResource(Client, data));
            return new RelationshipsPageable<ServiceGroupMemberRelationshipResource>(source, Endpoint);
        }
    }
}
