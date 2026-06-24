// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;

namespace Azure.ResourceManager.IotHub
{
    // Customization justification:
    // GroupIdInformation stays a plain TypeSpec model to preserve swagger. The C# generator therefore
    // emits data-returning operations on the parent resource instead of ARM child resource wrappers. This
    // custom collection restores the previous GA child-resource API surface while using the generated REST
    // client and data model.
    /// <summary>
    /// A class representing a collection of <see cref="IotHubPrivateEndpointGroupInformationResource"/> and their operations.
    /// Each <see cref="IotHubPrivateEndpointGroupInformationResource"/> in the collection will belong to the same instance of <see cref="IotHubDescriptionResource"/>.
    /// </summary>
    public partial class IotHubPrivateEndpointGroupInformationCollection : ArmCollection, IEnumerable<IotHubPrivateEndpointGroupInformationResource>, IAsyncEnumerable<IotHubPrivateEndpointGroupInformationResource>
    {
        private readonly ClientDiagnostics _privateLinkResourcesClientDiagnostics;
        private readonly PrivateLinkResources _privateLinkResourcesRestClient;

        /// <summary> Initializes a new instance of IotHubPrivateEndpointGroupInformationCollection for mocking. </summary>
        protected IotHubPrivateEndpointGroupInformationCollection()
        {
        }

        /// <summary> Initializes a new instance of <see cref="IotHubPrivateEndpointGroupInformationCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal IotHubPrivateEndpointGroupInformationCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            TryGetApiVersion(IotHubPrivateEndpointGroupInformationResource.ResourceType, out string iotHubPrivateEndpointGroupInformationApiVersion);
            _privateLinkResourcesClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.IotHub", IotHubPrivateEndpointGroupInformationResource.ResourceType.Namespace, Diagnostics);
            _privateLinkResourcesRestClient = new PrivateLinkResources(_privateLinkResourcesClientDiagnostics, Pipeline, Endpoint, iotHubPrivateEndpointGroupInformationApiVersion ?? "2026-03-01-preview");
            ValidateResourceId(id);
        }

        /// <param name="id"></param>
        [Conditional("DEBUG")]
        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != IotHubDescriptionResource.ResourceType)
            {
                throw new ArgumentException(string.Format("Invalid resource type {0} expected {1}", id.ResourceType, IotHubDescriptionResource.ResourceType), nameof(id));
            }
        }

        /// <summary> Get the specified private link resource for the given IotHub. </summary>
        /// <param name="groupId"> The name of the private link resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IotHubPrivateEndpointGroupInformationResource>> GetAsync(string groupId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(groupId, nameof(groupId));

            using DiagnosticScope scope = _privateLinkResourcesClientDiagnostics.CreateScope("IotHubPrivateEndpointGroupInformationCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _privateLinkResourcesRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, groupId, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<IotHubPrivateEndpointGroupInformationData> response = Response.FromValue(IotHubPrivateEndpointGroupInformationData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new IotHubPrivateEndpointGroupInformationResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get the specified private link resource for the given IotHub. </summary>
        /// <param name="groupId"> The name of the private link resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IotHubPrivateEndpointGroupInformationResource> Get(string groupId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(groupId, nameof(groupId));

            using DiagnosticScope scope = _privateLinkResourcesClientDiagnostics.CreateScope("IotHubPrivateEndpointGroupInformationCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _privateLinkResourcesRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, groupId, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<IotHubPrivateEndpointGroupInformationData> response = Response.FromValue(IotHubPrivateEndpointGroupInformationData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new IotHubPrivateEndpointGroupInformationResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> List private link resources for the given IotHub. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<IotHubPrivateEndpointGroupInformationResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new AsyncPageableWrapper<IotHubPrivateEndpointGroupInformationData, IotHubPrivateEndpointGroupInformationResource>(
                new PrivateLinkResourcesGetAllAsyncCollectionResultOfT(_privateLinkResourcesRestClient, Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context, "IotHubPrivateEndpointGroupInformationCollection.GetAll"),
                data => new IotHubPrivateEndpointGroupInformationResource(Client, data));
        }

        /// <summary> List private link resources for the given IotHub. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<IotHubPrivateEndpointGroupInformationResource> GetAll(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new PageableWrapper<IotHubPrivateEndpointGroupInformationData, IotHubPrivateEndpointGroupInformationResource>(
                new PrivateLinkResourcesGetAllCollectionResultOfT(_privateLinkResourcesRestClient, Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context, "IotHubPrivateEndpointGroupInformationCollection.GetAll"),
                data => new IotHubPrivateEndpointGroupInformationResource(Client, data));
        }

        /// <summary> Checks whether a private link resource exists. </summary>
        /// <param name="groupId"> The name of the private link resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<bool>> ExistsAsync(string groupId, CancellationToken cancellationToken = default)
        {
            NullableResponse<IotHubPrivateEndpointGroupInformationResource> response = await GetIfExistsAsync(groupId, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(response.HasValue, response.GetRawResponse());
        }

        /// <summary> Checks whether a private link resource exists. </summary>
        /// <param name="groupId"> The name of the private link resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<bool> Exists(string groupId, CancellationToken cancellationToken = default)
        {
            NullableResponse<IotHubPrivateEndpointGroupInformationResource> response = GetIfExists(groupId, cancellationToken);
            return Response.FromValue(response.HasValue, response.GetRawResponse());
        }

        /// <summary> Tries to get details for this private link resource. </summary>
        /// <param name="groupId"> The name of the private link resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<NullableResponse<IotHubPrivateEndpointGroupInformationResource>> GetIfExistsAsync(string groupId, CancellationToken cancellationToken = default)
        {
            try
            {
                Response<IotHubPrivateEndpointGroupInformationResource> response = await GetAsync(groupId, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value, response.GetRawResponse());
            }
            catch (RequestFailedException e) when (e.Status == 404 && e.GetRawResponse() != null)
            {
                return new NoValueResponse<IotHubPrivateEndpointGroupInformationResource>(e.GetRawResponse());
            }
        }

        /// <summary> Tries to get details for this private link resource. </summary>
        /// <param name="groupId"> The name of the private link resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual NullableResponse<IotHubPrivateEndpointGroupInformationResource> GetIfExists(string groupId, CancellationToken cancellationToken = default)
        {
            try
            {
                Response<IotHubPrivateEndpointGroupInformationResource> response = Get(groupId, cancellationToken);
                return Response.FromValue(response.Value, response.GetRawResponse());
            }
            catch (RequestFailedException e) when (e.Status == 404 && e.GetRawResponse() != null)
            {
                return new NoValueResponse<IotHubPrivateEndpointGroupInformationResource>(e.GetRawResponse());
            }
        }

        /// <inheritdoc/>
        IAsyncEnumerator<IotHubPrivateEndpointGroupInformationResource> IAsyncEnumerable<IotHubPrivateEndpointGroupInformationResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
            => GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);

        /// <inheritdoc/>
        IEnumerator<IotHubPrivateEndpointGroupInformationResource> IEnumerable<IotHubPrivateEndpointGroupInformationResource>.GetEnumerator()
            => GetAll().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetAll().GetEnumerator();
    }
}
