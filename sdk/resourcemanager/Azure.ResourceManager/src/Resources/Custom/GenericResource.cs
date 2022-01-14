// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources.Models;

[assembly: CodeGenSuppressType("GenericResourceFilter")]
[assembly: CodeGenSuppressType("GenericResource")]
namespace Azure.ResourceManager.Resources
{
    /// <summary> A Class representing a GenericResource along with the instance operations that can be performed on it. </summary>
    public partial class GenericResource : ArmResource
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly ResourcesRestOperations _resourcesRestClient;
        private readonly GenericResourceData _data;

        /// <summary> Initializes a new instance of the <see cref="GenericResource"/> class for mocking. </summary>
        protected GenericResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "GenericResource"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="resource"> The resource that is the target of operations. </param>
        internal GenericResource(ArmResource options, GenericResourceData resource) : base(options, resource.Id)
        {
            HasData = true;
            _data = resource;
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _resourcesRestClient = new ResourcesRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri);
        }

        /// <summary> Initializes a new instance of the <see cref="GenericResource"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal GenericResource(ArmResource options, ResourceIdentifier id) : base(options, id)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _resourcesRestClient = new ResourcesRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri);
        }

        /// <summary> Initializes a new instance of the <see cref="GenericResource"/> class. </summary>
        /// <param name="clientOptions"> The client options to build client context. </param>
        /// <param name="credential"> The credential to build client context. </param>
        /// <param name="uri"> The uri to build client context. </param>
        /// <param name="pipeline"> The pipeline to build client context. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal GenericResource(ArmClientOptions clientOptions, TokenCredential credential, Uri uri, HttpPipeline pipeline, ResourceIdentifier id) : base(clientOptions, credential, uri, pipeline, id)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _resourcesRestClient = new ResourcesRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri);
        }

        /// <summary> Gets the valid resource type for the operations. </summary>
        protected override ResourceType ValidResourceType => ResourceGroup.ResourceType;

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

        /// <summary>
        /// Validate the resource identifier against current resource.
        /// </summary>
        /// <param name="identifier"> The resource identifier. </param>
        protected override void ValidateResourceType(ResourceIdentifier identifier)
        {
            if (identifier is null)
                throw new ArgumentNullException(nameof(identifier));
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
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new GenericResource(this, response.Value), response.GetRawResponse());
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
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new GenericResource(this, response.Value), response.GetRawResponse());
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
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<ResourceDeleteByIdOperation> DeleteAsync(bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("GenericResource.Delete");
            scope.Start();
            try
            {
                var apiVersion = await GetApiVersionAsync(cancellationToken).ConfigureAwait(false);
                var response = await _resourcesRestClient.DeleteByIdAsync(Id, apiVersion, cancellationToken).ConfigureAwait(false);
                var operation = new ResourceDeleteByIdOperation(_clientDiagnostics, Pipeline, _resourcesRestClient.CreateDeleteByIdRequest(Id, apiVersion).Request, response);
                if (waitForCompletion)
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
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ResourceDeleteByIdOperation Delete(bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("GenericResource.Delete");
            scope.Start();
            try
            {
                var apiVersion = GetApiVersion(cancellationToken);
                var response = _resourcesRestClient.DeleteById(Id, apiVersion, cancellationToken);
                var operation = new ResourceDeleteByIdOperation(_clientDiagnostics, Pipeline, _resourcesRestClient.CreateDeleteByIdRequest(Id, apiVersion).Request, response);
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
        /// ContextualPath: /{resourceId}
        /// OperationId: Resources_UpdateById
        /// <summary> Updates a resource by ID. </summary>
        /// <param name="parameters"> Update resource parameters. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public async virtual Task<ResourceUpdateByIdOperation> UpdateAsync(GenericResourceData parameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("GenericResource.Update");
            scope.Start();
            try
            {
                var apiVersion = await GetApiVersionAsync(cancellationToken).ConfigureAwait(false);
                var response = await _resourcesRestClient.UpdateByIdAsync(Id, apiVersion, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new ResourceUpdateByIdOperation(this, _clientDiagnostics, Pipeline, _resourcesRestClient.CreateUpdateByIdRequest(Id, apiVersion, parameters).Request, response);
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
        /// ContextualPath: /{resourceId}
        /// OperationId: Resources_UpdateById
        /// <summary> Updates a resource by ID. </summary>
        /// <param name="parameters"> Update resource parameters. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public virtual ResourceUpdateByIdOperation Update(GenericResourceData parameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("GenericResource.Update");
            scope.Start();
            try
            {
                var apiVersion = GetApiVersion(cancellationToken);
                var response = _resourcesRestClient.UpdateById(Id, apiVersion, parameters, cancellationToken);
                var operation = new ResourceUpdateByIdOperation(this, _clientDiagnostics, Pipeline, _resourcesRestClient.CreateUpdateByIdRequest(Id, apiVersion, parameters).Request, response);
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
                var originalTags = await TagResource.GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.Properties.TagsValue[key] = value;
                await TagResource.CreateOrUpdateAsync(originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalResponse = await _resourcesRestClient.GetByIdAsync(Id, apiVersion, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new GenericResource(this, originalResponse.Value), originalResponse.GetRawResponse());
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
                var originalTags = TagResource.Get(cancellationToken);
                originalTags.Value.Data.Properties.TagsValue[key] = value;
                TagResource.CreateOrUpdate(originalTags.Value.Data, cancellationToken: cancellationToken);
                var originalResponse = _resourcesRestClient.GetById(Id, apiVersion, cancellationToken);
                return Response.FromValue(new GenericResource(this, originalResponse.Value), originalResponse.GetRawResponse());
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
                await TagResource.DeleteAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalTags = await TagResource.GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.Properties.TagsValue.ReplaceWith(tags);
                await TagResource.CreateOrUpdateAsync(originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalResponse = await _resourcesRestClient.GetByIdAsync(Id, apiVersion, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new GenericResource(this, originalResponse.Value), originalResponse.GetRawResponse());
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
                TagResource.Delete(cancellationToken: cancellationToken);
                var originalTags = TagResource.Get(cancellationToken);
                originalTags.Value.Data.Properties.TagsValue.ReplaceWith(tags);
                TagResource.CreateOrUpdate(originalTags.Value.Data, cancellationToken: cancellationToken);
                var originalResponse = _resourcesRestClient.GetById(Id, apiVersion, cancellationToken);
                return Response.FromValue(new GenericResource(this, originalResponse.Value), originalResponse.GetRawResponse());
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
                var originalTags = await TagResource.GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.Properties.TagsValue.Remove(key);
                await TagResource.CreateOrUpdateAsync(originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalResponse = await _resourcesRestClient.GetByIdAsync(Id, apiVersion, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new GenericResource(this, originalResponse.Value), originalResponse.GetRawResponse());
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
                var originalTags = TagResource.Get(cancellationToken);
                originalTags.Value.Data.Properties.TagsValue.Remove(key);
                TagResource.CreateOrUpdate(originalTags.Value.Data, cancellationToken: cancellationToken);
                var originalResponse = _resourcesRestClient.GetById(Id, apiVersion, cancellationToken);
                return Response.FromValue(new GenericResource(this, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private string GetApiVersion(CancellationToken cancellationToken)
        {
            string version = ClientOptions.ApiVersions.TryGetApiVersion(Id.ResourceType, cancellationToken);
            if (version is null)
            {
                throw new InvalidOperationException($"An invalid resource id was given {Id}");
            }
            return version;
        }

        private async Task<string> GetApiVersionAsync(CancellationToken cancellationToken)
        {
            string version = await ClientOptions.ApiVersions.TryGetApiVersionAsync(Id.ResourceType, cancellationToken).ConfigureAwait(false);
            if (version is null)
            {
                throw new InvalidOperationException($"An invalid resource id was given {Id}");
            }
            return version;
        }
    }
}
