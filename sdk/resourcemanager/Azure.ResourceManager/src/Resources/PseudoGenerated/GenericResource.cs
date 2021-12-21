// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Resources
{
    /// <summary>
    /// A class representing the operations that can be performed over a specific ArmResource.
    /// </summary>
    public class GenericResource : ArmResource
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly ResourcesRestOperations _restClient;
        private readonly GenericResourceData _data;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericResource"/> class for mocking.
        /// </summary>
        protected GenericResource()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericResource"/> class.
        /// </summary>
        /// <param name="operations"> The operation to get the client properties from. </param>
        /// <param name="id"> The id of the resource. </param>
        internal GenericResource(ArmResource operations, ResourceIdentifier id)
            : base(operations, id)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _restClient = new ResourcesRestOperations(_clientDiagnostics, Pipeline, ClientOptions, Id.SubscriptionId, BaseUri);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericResource"/> class.
        /// </summary>
        /// <param name="operations"> The operations object to copy the client parameters from. </param>
        /// <param name="resource"> The data model representing the generic azure resource. </param>
        /// <exception cref="ArgumentNullException"> If <see cref="ArmClientOptions"/> or <see cref="TokenCredential"/> is null. </exception>
        internal GenericResource(ArmResource operations, GenericResourceData resource)
            : base(operations, resource.Id)
        {
            _data = resource;
            HasData = true;
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _restClient = new ResourcesRestOperations(_clientDiagnostics, Pipeline, ClientOptions, Id.SubscriptionId, BaseUri);
        }

        /// <inheritdoc/>
        protected override ResourceType ValidResourceType => ResourceGroup.ResourceType;

        /// <summary>
        /// Gets whether or not the current instance has data.
        /// </summary>
        public bool HasData { get; }

        /// <summary>
        /// Gets the data representing this generic azure resource.
        /// </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual GenericResourceData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data you must call Get first");
                return _data;
            }
        }

        /// <summary>
        /// Delete the resource.
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> A token allowing immediate cancellation of any blocking call performed during the deletion. </param>
        /// <returns> The status of the delete operation. </returns>
        public virtual ResourceDeleteByIdOperation Delete(bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("GenericResource.Delete");
            scope.Start();
            try
            {
                var apiVersion = GetApiVersion(cancellationToken);
                var originalResponse = _restClient.DeleteById(Id, apiVersion, cancellationToken);
                var operation = new ResourceDeleteByIdOperation(_clientDiagnostics, Pipeline, _restClient.CreateDeleteByIdRequest(Id, apiVersion).Request, originalResponse);
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

        /// <summary>
        /// Delete the resource.
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> A token allowing immediate cancellation of any blocking call performed during the deletion. </param>
        /// <returns> A <see cref="Task"/> that on completion returns the status of the delete operation. </returns>
        public virtual async Task<ResourceDeleteByIdOperation> DeleteAsync(bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("GenericResource.Delete");
            scope.Start();
            try
            {
                var apiVersion = await GetApiVersionAsync(cancellationToken).ConfigureAwait(false);
                var originalResponse = await _restClient.DeleteByIdAsync(Id, apiVersion, cancellationToken).ConfigureAwait(false);
                var operation = new ResourceDeleteByIdOperation(_clientDiagnostics, Pipeline, _restClient.CreateDeleteByIdRequest(Id, apiVersion).Request, originalResponse);
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

        /// <summary>
        /// Add a tag to the current resource.
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The updated resource with the tag added. </returns>
        public virtual Response<GenericResource> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("GenericResource.AddTag");
            scope.Start();
            try
            {
                var apiVersion = GetApiVersion(cancellationToken);
                var originalTags = TagResource.Get(cancellationToken).Value;
                originalTags.Data.Properties.TagsValue[key] = value;
                TagResource.CreateOrUpdate(originalTags.Data, cancellationToken: cancellationToken);
                var originalResponse = _restClient.GetById(Id, apiVersion, cancellationToken);
                return Response.FromValue(new GenericResource(this, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Add a tag to the current resource.
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The updated resource with the tag added. </returns>
        public virtual async Task<Response<GenericResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("GenericResource.AddTag");
            scope.Start();
            try
            {
                var apiVersion = await GetApiVersionAsync(cancellationToken).ConfigureAwait(false);
                var originalTags = (await TagResource.GetAsync(cancellationToken).ConfigureAwait(false)).Value;
                originalTags.Data.Properties.TagsValue[key] = value;
                await TagResource.CreateOrUpdateAsync(originalTags.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalResponse = await _restClient.GetByIdAsync(Id, apiVersion, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new GenericResource(this, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets the current GenericResource from Azure. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<GenericResource> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("GenericResource.Get");
            scope.Start();
            try
            {
                var apiVersion = GetApiVersion(cancellationToken);
                var result = _restClient.GetById(Id, apiVersion, cancellationToken);
                if (result.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(result.GetRawResponse());

                return Response.FromValue(new GenericResource(this, result), result.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets the current GenericResource from Azure. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<GenericResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("GenericResource.Get");
            scope.Start();
            try
            {
                var apiVersion = await GetApiVersionAsync(cancellationToken).ConfigureAwait(false);
                var response = await _restClient.GetByIdAsync(Id, apiVersion, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);

                return Response.FromValue(new GenericResource(this, response), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc/>
        protected override void ValidateResourceType(ResourceIdentifier identifier)
        {
            if (identifier is null)
                throw new ArgumentNullException(nameof(identifier));
        }

        /// <summary>
        /// Replace the tags on the resource with the given set.
        /// </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The updated resource with the tag added. </returns>
        public virtual Response<GenericResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("GenericResource.SetTags");
            scope.Start();
            try
            {
                var apiVersion = GetApiVersion(cancellationToken);
                TagResource.Delete(cancellationToken: cancellationToken);
                var newTags = TagResource.Get(cancellationToken);
                newTags.Value.Data.Properties.TagsValue.ReplaceWith(tags);
                TagResource.CreateOrUpdate(new TagResourceData(newTags.Value.Data.Properties), cancellationToken: cancellationToken);
                var originalResponse = _restClient.GetById(Id, apiVersion, cancellationToken);
                return Response.FromValue(new GenericResource(this, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Replace the tags on the resource with the given set.
        /// </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The updated resource with the tag added. </returns>
        public virtual async Task<Response<GenericResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("GenericResource.SetTags");
            scope.Start();
            try
            {
                var apiVersion = await GetApiVersionAsync(cancellationToken).ConfigureAwait(false);
                await TagResource.DeleteAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
                var newTags = await TagResource.GetAsync(cancellationToken).ConfigureAwait(false);
                newTags.Value.Data.Properties.TagsValue.ReplaceWith(tags);
                await TagResource.CreateOrUpdateAsync(new TagResourceData(newTags.Value.Data.Properties), cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalResponse = await _restClient.GetByIdAsync(Id, apiVersion, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new GenericResource(this, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Removes a tag by key from the resource.
        /// </summary>
        /// <param name="key"> The key of the tag to remove. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The updated resource with the tag added. </returns>
        public virtual Response<GenericResource> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("GenericResource.RemoveTag");
            scope.Start();
            try
            {
                var apiVersion = GetApiVersion(cancellationToken);
                var originalTags = TagResource.Get(cancellationToken).Value;
                originalTags.Data.Properties.TagsValue.Remove(key);
                TagResource.CreateOrUpdate(originalTags.Data, cancellationToken: cancellationToken);
                var originalResponse = _restClient.GetById(Id, apiVersion, cancellationToken);
                return Response.FromValue(new GenericResource(this, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Removes a tag by key from the resource.
        /// </summary>
        /// <param name="key"> The key of the tag to remove. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The updated resource with the tag added. </returns>
        public virtual async Task<Response<GenericResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("GenericResource.RemoveTag");
            scope.Start();
            try
            {
                var apiVersion = await GetApiVersionAsync(cancellationToken).ConfigureAwait(false);
                var originalTags = (await TagResource.GetAsync(cancellationToken).ConfigureAwait(false)).Value;
                originalTags.Data.Properties.TagsValue.Remove(key);
                await TagResource.CreateOrUpdateAsync(originalTags.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalResponse = await _restClient.GetByIdAsync(Id, apiVersion, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new GenericResource(this, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

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
                var originalResponse = _restClient.UpdateById(Id, apiVersion, parameters, cancellationToken);
                var operation = new ResourceUpdateByIdOperation(this, _clientDiagnostics, Pipeline, _restClient.CreateUpdateByIdRequest(Id, apiVersion, parameters).Request, originalResponse);
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

        /// <summary> Updates a resource by ID. </summary>
        /// <param name="parameters"> Update resource parameters. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public virtual async Task<ResourceUpdateByIdOperation> UpdateAsync(GenericResourceData parameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
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
                var originalResponse = await _restClient.UpdateByIdAsync(Id, apiVersion, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new ResourceUpdateByIdOperation(this, _clientDiagnostics, Pipeline, _restClient.CreateUpdateByIdRequest(Id, apiVersion, parameters).Request, originalResponse);
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

        private string GetApiVersion(CancellationToken cancellationToken)
        {
            string version = ClientOptions.ApiVersions.TryGetApiVersion(Id.ResourceType, cancellationToken);
            if (version is null)
            {
                throw new InvalidOperationException($"An invalid resouce id was given {Id}");
            }
            return version;
        }

        private async Task<string> GetApiVersionAsync(CancellationToken cancellationToken)
        {
            string version = await ClientOptions.ApiVersions.TryGetApiVersionAsync(Id.ResourceType, cancellationToken).ConfigureAwait(false);
            if (version is null)
            {
                throw new InvalidOperationException($"An invalid resouce id was given {Id}");
            }
            return version;
        }
    }
}
