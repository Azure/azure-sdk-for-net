// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Resources.Models;

[assembly: CodeGenSuppressType("GenericResourceFilter")]
[assembly: CodeGenSuppressType("GenericResource")]
[assembly: CodeGenSuppressType("GenericResourceIdentityType")]
namespace Azure.ResourceManager.Resources
{
    /// <summary> A Class representing a GenericResource along with the instance operations that can be performed on it. </summary>
    public partial class GenericResource : ArmResource
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly ResourcesRestOperations _resourcesRestClient;
        private readonly GenericResourceData _data;
        private readonly ResourceProviderCollection _providerCollection;

        /// <summary> Initializes a new instance of the <see cref="GenericResource"/> class for mocking. </summary>
        protected GenericResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "GenericResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal GenericResource(ArmClient client, GenericResourceData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="GenericResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal GenericResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            ResourceIdentifier subscription = Id.GetSubscriptionResourceIdentifier();
            if (subscription == null)
            {
                throw new ArgumentException("Only resource in a subscription is supported");
            }
            _clientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Resources", Id.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(Id.ResourceType, out string apiVersion);
            _resourcesRestClient = new ResourcesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, apiVersion);
            _providerCollection = new ResourceProviderCollection(Client.GetSubscriptionResource(subscription));
        }

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual GenericResourceData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                return _data;
            }
        }

#pragma warning disable CA1801 // Review unused parameters
        internal static void ValidateResourceId(ResourceIdentifier id)
#pragma warning restore CA1801 // Review unused parameters
        {
            //no op but here for code generation
        }

        /// RequestPath: /{resourceId}
        /// ContextualPath: /{resourceId}
        /// OperationId: Resources_GetById
        /// <summary> Gets a resource by ID. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<GenericResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("GenericResource.Get");
            scope.Start();
            try
            {
                var apiVersion = await GetApiVersionAsync(cancellationToken).ConfigureAwait(false);
                var response = await _resourcesRestClient.GetByIdAsync(Id, apiVersion, cancellationToken).ConfigureAwait(false);
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
        /// ContextualPath: /{resourceId}
        /// OperationId: Resources_GetById
        /// <summary> Gets a resource by ID. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<GenericResource> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("GenericResource.Get");
            scope.Start();
            try
            {
                var apiVersion = GetApiVersion(cancellationToken);
                var response = _resourcesRestClient.GetById(Id, apiVersion, cancellationToken);
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
        /// ContextualPath: /{resourceId}
        /// OperationId: Resources_DeleteById
        /// <summary> Deletes a resource by ID. </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("GenericResource.Delete");
            scope.Start();
            try
            {
                var apiVersion = await GetApiVersionAsync(cancellationToken).ConfigureAwait(false);
                var response = await _resourcesRestClient.DeleteByIdAsync(Id, apiVersion, cancellationToken).ConfigureAwait(false);
                var operation = new ResourcesArmOperation(_clientDiagnostics, Pipeline, _resourcesRestClient.CreateDeleteByIdRequest(Id, apiVersion).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /{resourceId}
        /// ContextualPath: /{resourceId}
        /// OperationId: Resources_DeleteById
        /// <summary> Deletes a resource by ID. </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("GenericResource.Delete");
            scope.Start();
            try
            {
                var apiVersion = GetApiVersion(cancellationToken);
                var response = _resourcesRestClient.DeleteById(Id, apiVersion, cancellationToken);
                var operation = new ResourcesArmOperation(_clientDiagnostics, Pipeline, _resourcesRestClient.CreateDeleteByIdRequest(Id, apiVersion).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Add a tag to the current resource. </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The updated resource with the tag added. </returns>
        public async virtual Task<Response<GenericResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key), $"{nameof(key)} provided cannot be null or a whitespace.");
            }

            using var scope = _clientDiagnostics.CreateScope("GenericResource.AddTag");
            scope.Start();
            try
            {
                var apiVersion = await GetApiVersionAsync(cancellationToken).ConfigureAwait(false);
                var tagPatch = new TagResourcePatch(TagPatchMode.Merge, new Tag(new Dictionary<string, string> { { key, value } }, null), null);
                await GetTagResource().UpdateAsync(WaitUntil.Completed, tagPatch, cancellationToken).ConfigureAwait(false);
                var originalResponse = await _resourcesRestClient.GetByIdAsync(Id, apiVersion, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new GenericResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Add a tag to the current resource. </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The updated resource with the tag added. </returns>
        public virtual Response<GenericResource> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key), $"{nameof(key)} provided cannot be null or a whitespace.");
            }

            using var scope = _clientDiagnostics.CreateScope("GenericResource.AddTag");
            scope.Start();
            try
            {
                var apiVersion = GetApiVersion(cancellationToken);
                var tagPatch = new TagResourcePatch(TagPatchMode.Merge, new Tag(new Dictionary<string, string> { { key, value } }, null), null);
                GetTagResource().Update(WaitUntil.Completed, tagPatch, cancellationToken: cancellationToken);
                var originalResponse = _resourcesRestClient.GetById(Id, apiVersion, cancellationToken);
                return Response.FromValue(new GenericResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Replace the tags on the resource with the given set. </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The updated resource with the tags replaced. </returns>
        public async virtual Task<Response<GenericResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            if (tags == null)
            {
                throw new ArgumentNullException(nameof(tags), $"{nameof(tags)} provided cannot be null.");
            }

            using var scope = _clientDiagnostics.CreateScope("GenericResource.SetTags");
            scope.Start();
            try
            {
                var apiVersion = await GetApiVersionAsync(cancellationToken).ConfigureAwait(false);
                await GetTagResource().CreateOrUpdateAsync(WaitUntil.Completed, new TagResourceData(new Tag(tags, null)), cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalResponse = await _resourcesRestClient.GetByIdAsync(Id, apiVersion, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new GenericResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Replace the tags on the resource with the given set. </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The updated resource with the tags replaced. </returns>
        public virtual Response<GenericResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            if (tags == null)
            {
                throw new ArgumentNullException(nameof(tags), $"{nameof(tags)} provided cannot be null.");
            }

            using var scope = _clientDiagnostics.CreateScope("GenericResource.SetTags");
            scope.Start();
            try
            {
                var apiVersion = GetApiVersion(cancellationToken);
                GetTagResource().CreateOrUpdate(WaitUntil.Completed, new TagResourceData(new Tag(tags, null)), cancellationToken: cancellationToken);
                var originalResponse = _resourcesRestClient.GetById(Id, apiVersion, cancellationToken);
                return Response.FromValue(new GenericResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Removes a tag by key from the resource. </summary>
        /// <param name="key"> The key of the tag to remove. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The updated resource with the tag removed. </returns>
        public async virtual Task<Response<GenericResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key), $"{nameof(key)} provided cannot be null or a whitespace.");
            }

            using var scope = _clientDiagnostics.CreateScope("GenericResource.RemoveTag");
            scope.Start();
            try
            {
                var apiVersion = await GetApiVersionAsync(cancellationToken).ConfigureAwait(false);
                var tagPatch = new TagResourcePatch(TagPatchMode.Delete, new Tag(new Dictionary<string, string> { { key, string.Empty } }, null), null);
                await GetTagResource().UpdateAsync(WaitUntil.Completed, tagPatch, cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalResponse = await _resourcesRestClient.GetByIdAsync(Id, apiVersion, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new GenericResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Removes a tag by key from the resource. </summary>
        /// <param name="key"> The key of the tag to remove. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The updated resource with the tag removed. </returns>
        public virtual Response<GenericResource> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key), $"{nameof(key)} provided cannot be null or a whitespace.");
            }

            using var scope = _clientDiagnostics.CreateScope("GenericResource.RemoveTag");
            scope.Start();
            try
            {
                var apiVersion = GetApiVersion(cancellationToken);
                var tagPatch = new TagResourcePatch(TagPatchMode.Delete, new Tag(new Dictionary<string, string> { { key, string.Empty } }, null), null);
                GetTagResource().Update(WaitUntil.Completed, tagPatch, cancellationToken: cancellationToken);
                var originalResponse = _resourcesRestClient.GetById(Id, apiVersion, cancellationToken);
                return Response.FromValue(new GenericResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /{resourceId}
        /// ContextualPath: /{resourceId}
        /// OperationId: Resources_UpdateById
        /// <summary> Updates a resource by ID. </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> Update resource parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public async virtual Task<ArmOperation<GenericResource>> UpdateAsync(WaitUntil waitUntil, GenericResourceData data, CancellationToken cancellationToken = default)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            using var scope = _clientDiagnostics.CreateScope("GenericResource.Update");
            scope.Start();
            try
            {
                var apiVersion = await GetApiVersionAsync(cancellationToken).ConfigureAwait(false);
                var response = await _resourcesRestClient.UpdateByIdAsync(Id, apiVersion, data, cancellationToken).ConfigureAwait(false);
                var operation = new ResourcesArmOperation<GenericResource>(new GenericResourceOperationSource(Client), _clientDiagnostics, Pipeline, _resourcesRestClient.CreateUpdateByIdRequest(Id, apiVersion, data).Request, response, OperationFinalStateVia.Location);
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
        /// ContextualPath: /{resourceId}
        /// OperationId: Resources_UpdateById
        /// <summary> Updates a resource by ID. </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> Update resource parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<GenericResource> Update(WaitUntil waitUntil, GenericResourceData data, CancellationToken cancellationToken = default)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            using var scope = _clientDiagnostics.CreateScope("GenericResource.Update");
            scope.Start();
            try
            {
                var apiVersion = GetApiVersion(cancellationToken);
                var response = _resourcesRestClient.UpdateById(Id, apiVersion, data, cancellationToken);
                var operation = new ResourcesArmOperation<GenericResource>(new GenericResourceOperationSource(Client), _clientDiagnostics, Pipeline, _resourcesRestClient.CreateUpdateByIdRequest(Id, apiVersion, data).Request, response, OperationFinalStateVia.Location);
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

        private string GetApiVersion(CancellationToken cancellationToken)
        {
            string version = _providerCollection.GetApiVersion(Id.ResourceType, cancellationToken);
            if (version is null)
            {
                throw new InvalidOperationException($"An invalid resource id was given {Id}");
            }
            return version;
        }

        private async Task<string> GetApiVersionAsync(CancellationToken cancellationToken)
        {
            string version = await _providerCollection.GetApiVersionAsync(Id.ResourceType, cancellationToken).ConfigureAwait(false);
            if (version is null)
            {
                throw new InvalidOperationException($"An invalid resource id was given {Id}");
            }
            return version;
        }
    }
}
