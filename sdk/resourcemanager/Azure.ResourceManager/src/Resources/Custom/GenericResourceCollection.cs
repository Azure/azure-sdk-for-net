// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

[assembly: CodeGenSuppressType("GenericResourceCollection")]
namespace Azure.ResourceManager.Resources
{
    /// <summary> A class representing collection of GenericResource and their operations over its parent. </summary>
    public partial class GenericResourceCollection : ArmCollection
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly ResourcesRestOperations _resourcesRestClient;

        /// <summary> Initializes a new instance of the <see cref="GenericResourceCollection"/> class for mocking. </summary>
        protected GenericResourceCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="GenericResourceCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal GenericResourceCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _clientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Resources", ProviderConstants.DefaultProviderNamespace, Diagnostics);
            _resourcesRestClient = new ResourcesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != TenantResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, TenantResource.ResourceType), nameof(id));
        }

        // Collection level operations.

        /// RequestPath: /{resourceId}
        /// ContextualPath: /
        /// OperationId: Resources_CreateOrUpdateById
        /// <summary> Create a resource by ID. </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="resourceId"> The fully qualified ID of the resource, including the resource name and resource type. Use the format, /subscriptions/{guid}/resourceGroups/{resource-group-name}/{resource-provider-namespace}/{resource-type}/{resource-name}. </param>
        /// <param name="data"> Create or update resource parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceId"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<GenericResource> CreateOrUpdate(WaitUntil waitUntil, ResourceIdentifier resourceId, GenericResourceData data, CancellationToken cancellationToken = default)
        {
            if (resourceId == null)
            {
                throw new ArgumentNullException(nameof(resourceId));
            }
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            using var scope = _clientDiagnostics.CreateScope("GenericResourceCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var apiVersion = GetApiVersion(new ResourceIdentifier(resourceId), cancellationToken);
                var response = _resourcesRestClient.CreateOrUpdateById(resourceId, apiVersion, data, cancellationToken);
                var operation = new ResourcesArmOperation<GenericResource>(new GenericResourceOperationSource(Client), _clientDiagnostics, Pipeline, _resourcesRestClient.CreateCreateOrUpdateByIdRequest(resourceId, apiVersion, data).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /{resourceId}
        /// ContextualPath: /
        /// OperationId: Resources_CreateOrUpdateById
        /// <summary> Create a resource by ID. </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="resourceId"> The fully qualified ID of the resource, including the resource name and resource type. Use the format, /subscriptions/{guid}/resourceGroups/{resource-group-name}/{resource-provider-namespace}/{resource-type}/{resource-name}. </param>
        /// <param name="data"> Create or update resource parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceId"/>, or <paramref name="data"/> is null. </exception>
        public async virtual Task<ArmOperation<GenericResource>> CreateOrUpdateAsync(WaitUntil waitUntil, ResourceIdentifier resourceId, GenericResourceData data, CancellationToken cancellationToken = default)
        {
            if (resourceId == null)
            {
                throw new ArgumentNullException(nameof(resourceId));
            }
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            using var scope = _clientDiagnostics.CreateScope("GenericResourceCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var apiVersion = await GetApiVersionAsync(new ResourceIdentifier(resourceId), cancellationToken).ConfigureAwait(false);
                var response = await _resourcesRestClient.CreateOrUpdateByIdAsync(resourceId, apiVersion, data, cancellationToken).ConfigureAwait(false);
                var operation = new ResourcesArmOperation<GenericResource>(new GenericResourceOperationSource(Client), _clientDiagnostics, Pipeline, _resourcesRestClient.CreateCreateOrUpdateByIdRequest(resourceId, apiVersion, data).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /{resourceId}
        /// ContextualPath: /
        /// OperationId: Resources_GetById
        /// <summary> Gets a resource by ID. </summary>
        /// <param name="resourceId"> The fully qualified ID of the resource, including the resource name and resource type. Use the format, /subscriptions/{guid}/resourceGroups/{resource-group-name}/{resource-provider-namespace}/{resource-type}/{resource-name}. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceId"/> is null. </exception>
        public virtual Response<GenericResource> Get(ResourceIdentifier resourceId, CancellationToken cancellationToken = default)
        {
            if (resourceId == null)
            {
                throw new ArgumentNullException(nameof(resourceId));
            }

            using var scope = _clientDiagnostics.CreateScope("GenericResourceCollection.Get");
            scope.Start();
            try
            {
                var apiVersion = GetApiVersion(new ResourceIdentifier(resourceId), cancellationToken);
                var response = _resourcesRestClient.GetById(resourceId, apiVersion, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new GenericResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /{resourceId}
        /// ContextualPath: /
        /// OperationId: Resources_GetById
        /// <summary> Gets a resource by ID. </summary>
        /// <param name="resourceId"> The fully qualified ID of the resource, including the resource name and resource type. Use the format, /subscriptions/{guid}/resourceGroups/{resource-group-name}/{resource-provider-namespace}/{resource-type}/{resource-name}. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceId"/> is null. </exception>
        public async virtual Task<Response<GenericResource>> GetAsync(ResourceIdentifier resourceId, CancellationToken cancellationToken = default)
        {
            if (resourceId == null)
            {
                throw new ArgumentNullException(nameof(resourceId));
            }

            using var scope = _clientDiagnostics.CreateScope("GenericResourceCollection.Get");
            scope.Start();
            try
            {
                var apiVersion = await GetApiVersionAsync(new ResourceIdentifier(resourceId), cancellationToken).ConfigureAwait(false);
                var response = await _resourcesRestClient.GetByIdAsync(resourceId, apiVersion, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new GenericResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="resourceId"> The fully qualified ID of the resource, including the resource name and resource type. Use the format, /subscriptions/{guid}/resourceGroups/{resource-group-name}/{resource-provider-namespace}/{resource-type}/{resource-name}. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceId"/> is null. </exception>
        public virtual Response<bool> Exists(ResourceIdentifier resourceId, CancellationToken cancellationToken = default)
        {
            if (resourceId == null)
            {
                throw new ArgumentNullException(nameof(resourceId));
            }

            using var scope = _clientDiagnostics.CreateScope("GenericResourceCollection.Exists");
            scope.Start();
            try
            {
                var apiVersion = GetApiVersion(new ResourceIdentifier(resourceId), cancellationToken);
                var response = _resourcesRestClient.GetById(resourceId, apiVersion, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="resourceId"> The fully qualified ID of the resource, including the resource name and resource type. Use the format, /subscriptions/{guid}/resourceGroups/{resource-group-name}/{resource-provider-namespace}/{resource-type}/{resource-name}. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceId"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(ResourceIdentifier resourceId, CancellationToken cancellationToken = default)
        {
            if (resourceId == null)
            {
                throw new ArgumentNullException(nameof(resourceId));
            }

            using var scope = _clientDiagnostics.CreateScope("GenericResourceCollection.Exists");
            scope.Start();
            try
            {
                var apiVersion = await GetApiVersionAsync(new ResourceIdentifier(resourceId), cancellationToken).ConfigureAwait(false);
                var response = await _resourcesRestClient.GetByIdAsync(resourceId, apiVersion, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private string GetApiVersion(ResourceIdentifier resourceId, CancellationToken cancellationToken)
        {
            ResourceIdentifier subscription = resourceId.GetSubscriptionResourceIdentifier();
            if (subscription == null)
            {
                throw new ArgumentException("Only resource id in a subscription is supported", nameof(resourceId));
            }
            ResourceProviderCollection collection = new ResourceProviderCollection(Client, subscription);
            string version = collection.GetApiVersion(resourceId.ResourceType, cancellationToken);
            if (version is null)
            {
                throw new InvalidOperationException($"An invalid resource id was given {resourceId}");
            }
            return version;
        }

        private async Task<string> GetApiVersionAsync(ResourceIdentifier resourceId, CancellationToken cancellationToken)
        {
            ResourceIdentifier subscription = resourceId.GetSubscriptionResourceIdentifier();
            if (subscription == null)
            {
                throw new ArgumentException("Only resource id in a subscription is supported", nameof(resourceId));
            }
            ResourceProviderCollection collection = new ResourceProviderCollection(Client, subscription);
            string version = await collection.GetApiVersionAsync(resourceId.ResourceType, cancellationToken).ConfigureAwait(false);
            if (version is null)
            {
                throw new InvalidOperationException($"An invalid resource id was given {resourceId}");
            }
            return version;
        }
    }
}
