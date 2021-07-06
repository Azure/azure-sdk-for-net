// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing the operations that can be performed over a specific ArmResource.
    /// </summary>
    public class GenericResourceOperations : ResourceOperationsBase<TenantResourceIdentifier, GenericResource>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceOperationsBase"/> class for mocking.
        /// </summary>
        protected GenericResourceOperations()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceOperationsBase"/> class.
        /// </summary>
        /// <param name="operations"> The operation to get the client properties from. </param>
        /// <param name="id"> The id of the resource. </param>
        internal GenericResourceOperations(OperationsBase operations, TenantResourceIdentifier id)
            : base(operations, id)
        {
        }

        /// <inheritdoc/>
        protected override ResourceType ValidResourceType => ResourceGroupOperations.ResourceType;

        private ResourcesRestOperations RestClient
        {
            get
            {
                string subscription;
                if (!Id.TryGetSubscriptionId(out subscription))
                {
                    subscription = Guid.Empty.ToString();
                }

                return new ResourcesRestOperations(
                    new Azure.Core.Pipeline.ClientDiagnostics(ClientOptions),
                    ManagementPipelineBuilder.Build(Credential, BaseUri, ClientOptions),
                    subscription,
                    BaseUri);
            }
        }

        /// <summary>
        /// Delete the resource.
        /// </summary>
        /// <param name="cancellationToken"> A token allowing immediate cancellation of any blocking call performed during the deletion. </param>
        /// <returns> The status of the delete operation. </returns>
        public virtual Response Delete(CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("GenericResourceOperations.Delete");
            scope.Start();
            try
            {
                var operation = StartDelete(cancellationToken);
                return operation.WaitForCompletion(cancellationToken);
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
        /// <param name="cancellationToken"> A token allowing immediate cancellation of any blocking call performed during the deletion. </param>
        /// <returns> A <see cref="Task"/> that on completion returns the status of the delete operation. </returns>
        public virtual async Task<Response> DeleteAsync(CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("GenericResourceOperations.Delete");
            scope.Start();
            try
            {
                var operation = await StartDeleteAsync(cancellationToken).ConfigureAwait(false);
                return await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
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
        /// <param name="cancellationToken"> A token allowing immediate cancellation of any blocking call performed during the deletion. </param>
        /// <returns> A <see cref="ResourcesDeleteByIdOperation"/> which allows the caller to control polling and waiting for resource deletion.
        /// The operation yields the final http response to the delete request when complete. </returns>
        /// <remarks>
        /// <see href="https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning">Details on long running operation object.</see>
        /// </remarks>
        public virtual ResourcesDeleteByIdOperation StartDelete(CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("GenericResourceOperations.StartDelete");
            scope.Start();
            try
            {
                var apiVersion = GetApiVersion(cancellationToken);
                var originalResponse = RestClient.DeleteById(Id, apiVersion, cancellationToken);
                return new ResourcesDeleteByIdOperation(Diagnostics, Pipeline, RestClient.CreateDeleteByIdRequest(Id, apiVersion).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Delete the resource.  This call returns a Task that blocks until the delete operation is accepted on the service.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service.
        /// The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A <see cref="Task"/> that on completion returns a <see cref="ResourcesDeleteByIdOperation"/> which
        /// allows the caller to control polling and waiting for resource deletion.
        /// The operation yields the final http response to the delete request when complete. </returns>
        /// <remarks>
        /// <see href="https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning">Details on long running operation object.</see>
        /// </remarks>
        public virtual async Task<ResourcesDeleteByIdOperation> StartDeleteAsync(CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("GenericResourceOperations.StartDelete");
            scope.Start();
            try
            {
                var apiVersion = await GetApiVersionAsync(cancellationToken).ConfigureAwait(false);
                var originalResponse = await RestClient.DeleteByIdAsync(Id, apiVersion, cancellationToken).ConfigureAwait(false);
                return new ResourcesDeleteByIdOperation(Diagnostics, Pipeline, RestClient.CreateDeleteByIdRequest(Id, apiVersion).Request, originalResponse);
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
            using var scope = Diagnostics.CreateScope("GenericResourceOperations.AddTag");
            scope.Start();
            try
            {
                var apiVersion = GetApiVersion(cancellationToken);
                var originalTags = TagResourceOperations.Get(cancellationToken).Value;
                originalTags.Data.Properties.TagsValue[key] = value;
                TagContainer.CreateOrUpdate(originalTags.Data, cancellationToken);
                var originalResponse = RestClient.GetById(Id, apiVersion, cancellationToken);
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
            using var scope = Diagnostics.CreateScope("GenericResourceOperations.AddTag");
            scope.Start();
            try
            {
                var apiVersion = await GetApiVersionAsync(cancellationToken).ConfigureAwait(false);
                var originalTags = (await TagResourceOperations.GetAsync(cancellationToken).ConfigureAwait(false)).Value;
                originalTags.Data.Properties.TagsValue[key] = value;
                await TagContainer.CreateOrUpdateAsync(originalTags.Data, cancellationToken).ConfigureAwait(false);
                var originalResponse = await RestClient.GetByIdAsync(Id, apiVersion, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new GenericResource(this, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc/>
        public override Response<GenericResource> Get(CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("GenericResourceOperations.Get");
            scope.Start();
            try
            {
                var apiVersion = GetApiVersion(cancellationToken);
                var result = RestClient.GetById(Id, apiVersion, cancellationToken);
                return Response.FromValue(new GenericResource(this, result), result.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc/>
        public override async Task<Response<GenericResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("GenericResourceOperations.Get");
            scope.Start();
            try
            {
                var apiVersion = await GetApiVersionAsync(cancellationToken).ConfigureAwait(false);
                var result = await RestClient.GetByIdAsync(Id, apiVersion, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new GenericResource(this, result), result.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc/>
        protected override void Validate(ResourceIdentifier identifier)
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
            using var scope = Diagnostics.CreateScope("GenericResourceOperations.SetTags");
            scope.Start();
            try
            {
                var apiVersion = GetApiVersion(cancellationToken);
                TagResourceOperations.Delete(cancellationToken);
                var newTags = TagResourceOperations.Get(cancellationToken);
                newTags.Value.Data.Properties.TagsValue.ReplaceWith(tags);
                TagContainer.CreateOrUpdate(new TagResourceData(newTags.Value.Data.Properties), cancellationToken);
                var originalResponse = RestClient.GetById(Id, apiVersion, cancellationToken);
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
            using var scope = Diagnostics.CreateScope("GenericResourceOperations.SetTags");
            scope.Start();
            try
            {
                var apiVersion = await GetApiVersionAsync(cancellationToken).ConfigureAwait(false);
                await TagResourceOperations.DeleteAsync(cancellationToken).ConfigureAwait(false);
                var newTags = await TagResourceOperations.GetAsync(cancellationToken).ConfigureAwait(false);
                newTags.Value.Data.Properties.TagsValue.ReplaceWith(tags);
                await TagContainer.CreateOrUpdateAsync(new TagResourceData(newTags.Value.Data.Properties), cancellationToken).ConfigureAwait(false);
                var originalResponse = await RestClient.GetByIdAsync(Id, apiVersion, cancellationToken).ConfigureAwait(false);
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
            using var scope = Diagnostics.CreateScope("GenericResourceOperations.RemoveTag");
            scope.Start();
            try
            {
                var apiVersion = GetApiVersion(cancellationToken);
                var originalTags = TagResourceOperations.Get(cancellationToken).Value;
                originalTags.Data.Properties.TagsValue.Remove(key);
                TagContainer.CreateOrUpdate(originalTags.Data, cancellationToken);
                var originalResponse = RestClient.GetById(Id, apiVersion, cancellationToken);
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
            using var scope = Diagnostics.CreateScope("GenericResourceOperations.RemoveTag");
            scope.Start();
            try
            {
                var apiVersion = await GetApiVersionAsync(cancellationToken).ConfigureAwait(false);
                var originalTags = (await TagResourceOperations.GetAsync(cancellationToken).ConfigureAwait(false)).Value;
                originalTags.Data.Properties.TagsValue.Remove(key);
                await TagContainer.CreateOrUpdateAsync(originalTags.Data, cancellationToken).ConfigureAwait(false);
                var originalResponse = await RestClient.GetByIdAsync(Id, apiVersion, cancellationToken).ConfigureAwait(false);
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
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public virtual Response<GenericResource> Update(GenericResourceData parameters, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = Diagnostics.CreateScope("GenericResourceOperations.Update");
            scope.Start();
            try
            {
                var operation = StartUpdate(parameters, cancellationToken);
                return operation.WaitForCompletion(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Updates a resource by ID. </summary>
        /// <param name="parameters"> Update resource parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public virtual async Task<Response<GenericResource>> UpdateAsync(GenericResourceData parameters, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = Diagnostics.CreateScope("GenericResourceOperations.Update");
            scope.Start();
            try
            {
                var operation = await StartUpdateAsync(parameters, cancellationToken).ConfigureAwait(false);
                return await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Updates a resource by ID. </summary>
        /// <param name="parameters"> Update resource parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public virtual ResourcesUpdateByIdOperation StartUpdate(GenericResourceData parameters, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = Diagnostics.CreateScope("GenericResourceOperations.StartUpdate");
            scope.Start();
            try
            {
                var apiVersion = GetApiVersion(cancellationToken);
                var originalResponse = RestClient.UpdateById(Id, apiVersion, parameters, cancellationToken);
                return new ResourcesUpdateByIdOperation(this, Diagnostics, Pipeline, RestClient.CreateUpdateByIdRequest(Id, apiVersion, parameters).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Updates a resource by ID. </summary>
        /// <param name="parameters"> Update resource parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public virtual async Task<ResourcesUpdateByIdOperation> StartUpdateAsync(GenericResourceData parameters, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = Diagnostics.CreateScope("GenericResourceOperations.StartUpdate");
            scope.Start();
            try
            {
                var apiVersion = await GetApiVersionAsync(cancellationToken).ConfigureAwait(false);
                var originalResponse = await RestClient.UpdateByIdAsync(Id, apiVersion, parameters, cancellationToken).ConfigureAwait(false);
                return new ResourcesUpdateByIdOperation(this, Diagnostics, Pipeline, RestClient.CreateUpdateByIdRequest(Id, apiVersion, parameters).Request, originalResponse);
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
