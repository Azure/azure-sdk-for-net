// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.EventGrid.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.EventGrid
{
    // Workaround for https://github.com/Azure/azure-sdk-for-net/issues/59358
    // (Mgmt CodeGen dynamic-parent expansion: PR #58139 split the child Collection
    // class per parent but kept all 8 operations parameterised on parentType/parentName,
    // dropping the parent-bound back-compat shape. Restore it here by stashing the
    // parent route on a back-compat ctor and delegating the legacy (name) overloads
    // to the generator-emitted (parentType, parentName, name) methods.)
    [CodeGenType("PartnerNamespaceEventGridPrivateEndpointConnectionCollection")]
    public partial class EventGridPartnerNamespacePrivateEndpointConnectionCollection : IEnumerable<EventGridPartnerNamespacePrivateEndpointConnectionResource>,
        IAsyncEnumerable<EventGridPartnerNamespacePrivateEndpointConnectionResource>
    {
        private readonly PrivateEndpointConnectionsParentType _backCompatParentType;
        private readonly string _backCompatParentName;

        /// <summary> Initializes a new instance of <see cref="EventGridPartnerNamespacePrivateEndpointConnectionCollection"/> bound to a parent route. </summary>
        internal EventGridPartnerNamespacePrivateEndpointConnectionCollection(ArmClient client, ResourceIdentifier id, PrivateEndpointConnectionsParentType parentType, string parentName)
            : this(client, id)
        {
            _backCompatParentType = parentType;
            _backCompatParentName = parentName;
        }

        /// <summary> Get a specific private endpoint connection under a partner namespace. </summary>
        /// <param name="privateEndpointConnectionName"> The name of the private endpoint connection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Task<Response<EventGridPartnerNamespacePrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, CancellationToken cancellationToken = default)
        {
            return GetAsync(_backCompatParentType, _backCompatParentName, privateEndpointConnectionName, cancellationToken);
        }

        /// <summary> Get a specific private endpoint connection under a partner namespace. </summary>
        /// <param name="privateEndpointConnectionName"> The name of the private endpoint connection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<EventGridPartnerNamespacePrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, CancellationToken cancellationToken = default)
        {
            return Get(_backCompatParentType, _backCompatParentName, privateEndpointConnectionName, cancellationToken);
        }

        /// <summary> Checks to see if the resource exists in azure. </summary>
        /// <param name="privateEndpointConnectionName"> The name of the private endpoint connection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Task<Response<bool>> ExistsAsync(string privateEndpointConnectionName, CancellationToken cancellationToken = default)
        {
            return ExistsAsync(_backCompatParentType, _backCompatParentName, privateEndpointConnectionName, cancellationToken);
        }

        /// <summary> Checks to see if the resource exists in azure. </summary>
        /// <param name="privateEndpointConnectionName"> The name of the private endpoint connection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<bool> Exists(string privateEndpointConnectionName, CancellationToken cancellationToken = default)
        {
            return Exists(_backCompatParentType, _backCompatParentName, privateEndpointConnectionName, cancellationToken);
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="privateEndpointConnectionName"> The name of the private endpoint connection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Task<NullableResponse<EventGridPartnerNamespacePrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, CancellationToken cancellationToken = default)
        {
            return GetIfExistsAsync(_backCompatParentType, _backCompatParentName, privateEndpointConnectionName, cancellationToken);
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="privateEndpointConnectionName"> The name of the private endpoint connection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual NullableResponse<EventGridPartnerNamespacePrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, CancellationToken cancellationToken = default)
        {
            return GetIfExists(_backCompatParentType, _backCompatParentName, privateEndpointConnectionName, cancellationToken);
        }

        /// <summary> Create or update a private endpoint connection under a partner namespace. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="privateEndpointConnectionName"> The name of the private endpoint connection. </param>
        /// <param name="data"> The private endpoint connection data. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Task<ArmOperation<EventGridPartnerNamespacePrivateEndpointConnectionResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string privateEndpointConnectionName, EventGridPrivateEndpointConnectionData data, CancellationToken cancellationToken = default)
        {
            return CreateOrUpdateAsync(waitUntil, _backCompatParentType, _backCompatParentName, privateEndpointConnectionName, data, cancellationToken);
        }

        /// <summary> Create or update a private endpoint connection under a partner namespace. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="privateEndpointConnectionName"> The name of the private endpoint connection. </param>
        /// <param name="data"> The private endpoint connection data. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation<EventGridPartnerNamespacePrivateEndpointConnectionResource> CreateOrUpdate(WaitUntil waitUntil, string privateEndpointConnectionName, EventGridPrivateEndpointConnectionData data, CancellationToken cancellationToken = default)
        {
            return CreateOrUpdate(waitUntil, _backCompatParentType, _backCompatParentName, privateEndpointConnectionName, data, cancellationToken);
        }

        /// <summary> Get all the private endpoint connections under a partner namespace. </summary>
        /// <param name="filter"> OData filter expression. </param>
        /// <param name="top"> Number of results per page (1-100, default 20). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<EventGridPartnerNamespacePrivateEndpointConnectionResource> GetAllAsync(string filter = default, int? top = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new AsyncPageableWrapper<EventGridPrivateEndpointConnectionData, EventGridPartnerNamespacePrivateEndpointConnectionResource>(
                new PrivateEndpointConnectionsGetByResourceAsyncCollectionResultOfT(
                    _privateEndpointConnectionsRestClient,
                    Guid.Parse(Id.SubscriptionId),
                    Id.ResourceGroupName,
                    _backCompatParentType.ToString(),
                    _backCompatParentName,
                    filter,
                    top,
                    context,
                    "EventGridPartnerNamespacePrivateEndpointConnectionCollection.GetAll"),
                data => new EventGridPartnerNamespacePrivateEndpointConnectionResource(Client, data));
        }

        /// <summary> Get all the private endpoint connections under a partner namespace. </summary>
        /// <param name="filter"> OData filter expression. </param>
        /// <param name="top"> Number of results per page (1-100, default 20). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<EventGridPartnerNamespacePrivateEndpointConnectionResource> GetAll(string filter = default, int? top = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new PageableWrapper<EventGridPrivateEndpointConnectionData, EventGridPartnerNamespacePrivateEndpointConnectionResource>(
                new PrivateEndpointConnectionsGetByResourceCollectionResultOfT(
                    _privateEndpointConnectionsRestClient,
                    Guid.Parse(Id.SubscriptionId),
                    Id.ResourceGroupName,
                    _backCompatParentType.ToString(),
                    _backCompatParentName,
                    filter,
                    top,
                    context,
                    "EventGridPartnerNamespacePrivateEndpointConnectionCollection.GetAll"),
                data => new EventGridPartnerNamespacePrivateEndpointConnectionResource(Client, data));
        }

        IEnumerator<EventGridPartnerNamespacePrivateEndpointConnectionResource> IEnumerable<EventGridPartnerNamespacePrivateEndpointConnectionResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<EventGridPartnerNamespacePrivateEndpointConnectionResource> IAsyncEnumerable<EventGridPartnerNamespacePrivateEndpointConnectionResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
