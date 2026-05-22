// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.EventGrid
{
    // Workaround for https://github.com/Azure/azure-sdk-for-net/issues/59358
    // (Mgmt CodeGen Symptom #7: generated GetAll passes strongly-typed enum to a
    // string-typed REST helper, causing CS1503; only manifests on the one PEC Collection
    // that received a GetAll binding from the dynamic-parent expansion).
    //
    // Rename the Topic-prefixed PEC collection class to the back-compat name AND work around
    // a generator quirk that only affects the Topic-prefixed collection: the generated
    // GetAll/GetAllAsync pass the strongly-typed _parentType (PrivateEndpointConnectionsParentType)
    // directly to the underlying paged result helper which expects a plain string (CS1503).
    // The sibling Domain/Namespace/PartnerNamespace collections do not emit GetAll, so this
    // re-implementation is needed only here. We suppress the broken methods and re-emit them
    // with _parentType.ToString(). The other back-compat overloads (Get/Exists/GetIfExists/
    // CreateOrUpdate without parentType/parentName params) delegate to the generated 4-arg
    // operations using the stored _parentType + _parentName.
    [CodeGenType("TopicEventGridPrivateEndpointConnectionCollection")]
    [CodeGenSuppress("GetAllAsync", typeof(string), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetAll", typeof(string), typeof(int?), typeof(CancellationToken))]
    public partial class EventGridTopicPrivateEndpointConnectionCollection
    {
        /// <summary> Get a specific private endpoint connection under a topic. </summary>
        /// <param name="privateEndpointConnectionName"> The name of the private endpoint connection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Task<Response<EventGridTopicPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, CancellationToken cancellationToken = default)
        {
            return GetAsync(_parentType, _parentName, privateEndpointConnectionName, cancellationToken);
        }

        /// <summary> Get a specific private endpoint connection under a topic. </summary>
        /// <param name="privateEndpointConnectionName"> The name of the private endpoint connection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<EventGridTopicPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, CancellationToken cancellationToken = default)
        {
            return Get(_parentType, _parentName, privateEndpointConnectionName, cancellationToken);
        }

        /// <summary> Checks to see if the resource exists in azure. </summary>
        /// <param name="privateEndpointConnectionName"> The name of the private endpoint connection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Task<Response<bool>> ExistsAsync(string privateEndpointConnectionName, CancellationToken cancellationToken = default)
        {
            return ExistsAsync(_parentType, _parentName, privateEndpointConnectionName, cancellationToken);
        }

        /// <summary> Checks to see if the resource exists in azure. </summary>
        /// <param name="privateEndpointConnectionName"> The name of the private endpoint connection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<bool> Exists(string privateEndpointConnectionName, CancellationToken cancellationToken = default)
        {
            return Exists(_parentType, _parentName, privateEndpointConnectionName, cancellationToken);
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="privateEndpointConnectionName"> The name of the private endpoint connection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Task<NullableResponse<EventGridTopicPrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, CancellationToken cancellationToken = default)
        {
            return GetIfExistsAsync(_parentType, _parentName, privateEndpointConnectionName, cancellationToken);
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="privateEndpointConnectionName"> The name of the private endpoint connection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual NullableResponse<EventGridTopicPrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, CancellationToken cancellationToken = default)
        {
            return GetIfExists(_parentType, _parentName, privateEndpointConnectionName, cancellationToken);
        }

        /// <summary> Create or update a private endpoint connection under a topic. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="privateEndpointConnectionName"> The name of the private endpoint connection. </param>
        /// <param name="data"> The private endpoint connection data. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Task<ArmOperation<EventGridTopicPrivateEndpointConnectionResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string privateEndpointConnectionName, EventGridPrivateEndpointConnectionData data, CancellationToken cancellationToken = default)
        {
            return CreateOrUpdateAsync(waitUntil, _parentType, _parentName, privateEndpointConnectionName, data, cancellationToken);
        }

        /// <summary> Create or update a private endpoint connection under a topic. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="privateEndpointConnectionName"> The name of the private endpoint connection. </param>
        /// <param name="data"> The private endpoint connection data. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation<EventGridTopicPrivateEndpointConnectionResource> CreateOrUpdate(WaitUntil waitUntil, string privateEndpointConnectionName, EventGridPrivateEndpointConnectionData data, CancellationToken cancellationToken = default)
        {
            return CreateOrUpdate(waitUntil, _parentType, _parentName, privateEndpointConnectionName, data, cancellationToken);
        }

        /// <summary> Get all private endpoint connections under a topic, domain, or partner namespace or namespace. </summary>
        /// <param name="filter"> OData filter expression. </param>
        /// <param name="top"> Number of results per page (1-100, default 20). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<EventGridTopicPrivateEndpointConnectionResource> GetAllAsync(string filter = default, int? top = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new AsyncPageableWrapper<EventGridPrivateEndpointConnectionData, EventGridTopicPrivateEndpointConnectionResource>(
                new PrivateEndpointConnectionsGetByResourceAsyncCollectionResultOfT(
                    _privateEndpointConnectionsRestClient,
                    Guid.Parse(Id.SubscriptionId),
                    Id.ResourceGroupName,
                    _parentType.ToString(),
                    _parentName,
                    filter,
                    top,
                    context,
                    "EventGridTopicPrivateEndpointConnectionCollection.GetAll"),
                data => new EventGridTopicPrivateEndpointConnectionResource(Client, data));
        }

        /// <summary> Get all private endpoint connections under a topic, domain, or partner namespace or namespace. </summary>
        /// <param name="filter"> OData filter expression. </param>
        /// <param name="top"> Number of results per page (1-100, default 20). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<EventGridTopicPrivateEndpointConnectionResource> GetAll(string filter = default, int? top = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new PageableWrapper<EventGridPrivateEndpointConnectionData, EventGridTopicPrivateEndpointConnectionResource>(
                new PrivateEndpointConnectionsGetByResourceCollectionResultOfT(
                    _privateEndpointConnectionsRestClient,
                    Guid.Parse(Id.SubscriptionId),
                    Id.ResourceGroupName,
                    _parentType.ToString(),
                    _parentName,
                    filter,
                    top,
                    context,
                    "EventGridTopicPrivateEndpointConnectionCollection.GetAll"),
                data => new EventGridTopicPrivateEndpointConnectionResource(Client, data));
        }
    }
}
