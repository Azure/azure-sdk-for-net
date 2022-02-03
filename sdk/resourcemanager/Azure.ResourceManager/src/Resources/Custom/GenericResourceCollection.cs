// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources.Models;

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
            _clientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Resources", ProviderConstants.DefaultProviderNamespace, DiagnosticOptions);
            _resourcesRestClient = new ResourcesRestOperations(_clientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri);
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != Tenant.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, Tenant.ResourceType), nameof(id));
        }

        // Collection level operations.

        /// RequestPath: /{resourceId}
        /// ContextualPath: /
        /// OperationId: Resources_CreateOrUpdateById
        /// <summary> Create a resource by ID. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="resourceId"> The fully qualified ID of the resource, including the resource name and resource type. Use the format, /subscriptions/{guid}/resourceGroups/{resource-group-name}/{resource-provider-namespace}/{resource-type}/{resource-name}. </param>
        /// <param name="parameters"> Create or update resource parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceId"/> or <paramref name="parameters"/> is null. </exception>
        public virtual GenericResourceCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, ResourceIdentifier resourceId, GenericResourceData parameters, CancellationToken cancellationToken = default)
        {
            if (resourceId == null)
            {
                throw new ArgumentNullException(nameof(resourceId));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("GenericResourceCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var apiVersion = GetApiVersion(new ResourceIdentifier(resourceId), cancellationToken);
                var response = _resourcesRestClient.CreateOrUpdateById(resourceId, apiVersion, parameters, cancellationToken);
                var operation = new GenericResourceCreateOrUpdateOperation(Client, _clientDiagnostics, Pipeline, _resourcesRestClient.CreateCreateOrUpdateByIdRequest(resourceId, apiVersion, parameters).Request, response);
                if (waitForCompletion)
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
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="resourceId"> The fully qualified ID of the resource, including the resource name and resource type. Use the format, /subscriptions/{guid}/resourceGroups/{resource-group-name}/{resource-provider-namespace}/{resource-type}/{resource-name}. </param>
        /// <param name="parameters"> Create or update resource parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceId"/>, or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<GenericResourceCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, ResourceIdentifier resourceId, GenericResourceData parameters, CancellationToken cancellationToken = default)
        {
            if (resourceId == null)
            {
                throw new ArgumentNullException(nameof(resourceId));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("GenericResourceCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var apiVersion = await GetApiVersionAsync(new ResourceIdentifier(resourceId), cancellationToken).ConfigureAwait(false);
                var response = await _resourcesRestClient.CreateOrUpdateByIdAsync(resourceId, apiVersion, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new GenericResourceCreateOrUpdateOperation(Client, _clientDiagnostics, Pipeline, _resourcesRestClient.CreateCreateOrUpdateByIdRequest(resourceId, apiVersion, parameters).Request, response);
                if (waitForCompletion)
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
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
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
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
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
        public virtual Response<GenericResource> GetIfExists(ResourceIdentifier resourceId, CancellationToken cancellationToken = default)
        {
            if (resourceId == null)
            {
                throw new ArgumentNullException(nameof(resourceId));
            }

            using var scope = _clientDiagnostics.CreateScope("GenericResourceCollection.GetIfExists");
            scope.Start();
            try
            {
                var apiVersion = GetApiVersion(new ResourceIdentifier(resourceId), cancellationToken);
                var response = _resourcesRestClient.GetById(resourceId, apiVersion, cancellationToken: cancellationToken);
                return response.Value == null
                    ? Response.FromValue<GenericResource>(null, response.GetRawResponse())
                    : Response.FromValue(new GenericResource(Client, response.Value), response.GetRawResponse());
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
        public async virtual Task<Response<GenericResource>> GetIfExistsAsync(ResourceIdentifier resourceId, CancellationToken cancellationToken = default)
        {
            if (resourceId == null)
            {
                throw new ArgumentNullException(nameof(resourceId));
            }

            using var scope = _clientDiagnostics.CreateScope("GenericResourceCollection.GetIfExists");
            scope.Start();
            try
            {
                var apiVersion = await GetApiVersionAsync(new ResourceIdentifier(resourceId), cancellationToken).ConfigureAwait(false);
                var response = await _resourcesRestClient.GetByIdAsync(resourceId, apiVersion, cancellationToken: cancellationToken).ConfigureAwait(false);
                return response.Value == null
                    ? Response.FromValue<GenericResource>(null, response.GetRawResponse())
                    : Response.FromValue(new GenericResource(Client, response.Value), response.GetRawResponse());
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
                var response = GetIfExists(resourceId, cancellationToken: cancellationToken);
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
                var response = await GetIfExistsAsync(resourceId, cancellationToken: cancellationToken).ConfigureAwait(false);
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
            string version = GetProviderCollectionForSubscription(subscription).GetApiVersion(resourceId.ResourceType, cancellationToken);
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
            string version = await GetProviderCollectionForSubscription(subscription).GetApiVersionAsync(resourceId.ResourceType, cancellationToken).ConfigureAwait(false);
            if (version is null)
            {
                throw new InvalidOperationException($"An invalid resource id was given {resourceId}");
            }
            return version;
        }

        private ProviderCollection GetProviderCollectionForSubscription(ResourceIdentifier subscriptionId)
            => GetCachedClient((client) => { return new ProviderCollection(client, subscriptionId); });
    }
}
