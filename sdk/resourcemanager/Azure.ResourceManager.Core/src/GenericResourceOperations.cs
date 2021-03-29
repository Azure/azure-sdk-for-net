// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing the operations that can be performed over a specific ArmResource.
    /// </summary>
    public class GenericResourceOperations : ResourceOperationsBase<TenantResourceIdentifier, GenericResource>, ITaggableResource<TenantResourceIdentifier, GenericResource>, IDeletableResource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GenericResourceOperations"/> class.
        /// </summary>
        /// <param name="operations"> The resource operations to copy the options from. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal GenericResourceOperations(ResourceOperationsBase operations, TenantResourceIdentifier id)
            : base(operations, id)
        {
        }

        /// <inheritdoc/>
        protected override ResourceType ValidResourceType => ResourceGroupOperations.ResourceType;

        private ResourcesOperations Operations
        {
            get
            {
                string subscription;
                if (!Id.TryGetSubscriptionId(out subscription))
                {
                    subscription = Guid.Empty.ToString();
                }

                return new ResourcesManagementClient(
                    BaseUri,
                    subscription,
                    Credential,
                    ClientOptions.Convert<ResourcesManagementClientOptions>()).Resources;
            }
        }

        /// <summary>
        /// Delete the resource.
        /// </summary>
        /// <param name="cancellationToken"> A token allowing immediate cancellation of any blocking call performed during the deletion. </param>
        /// <returns> The status of the delete operation. </returns>
        public ArmResponse<Response> Delete(CancellationToken cancellationToken = default)
        {
            return new ArmResponse(Operations.StartDeleteById(Id, GetApiVersion(cancellationToken), cancellationToken).WaitForCompletion(cancellationToken));
        }

        /// <summary>
        /// Delete the resource.
        /// </summary>
        /// <param name="cancellationToken"> A token allowing immediate cancellation of any blocking call performed during the deletion. </param>
        /// <returns> A <see cref="Task"/> that on completion returns the status of the delete operation. </returns>
        public async Task<ArmResponse<Response>> DeleteAsync(CancellationToken cancellationToken = default)
        {
            var operation = await Operations.StartDeleteByIdAsync(Id, await GetApiVersionAsync(cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
            var result = await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
            return new ArmResponse(result);
        }

        /// <summary>
        /// Delete the resource.
        /// </summary>
        /// <param name="cancellationToken"> A token allowing immediate cancellation of any blocking call performed during the deletion. </param>
        /// <returns> A <see cref="ArmOperation{Response}"/> which allows the caller to control polling and waiting for resource deletion.
        /// The operation yields the final http response to the delete request when complete. </returns>
        /// <remarks>
        /// <see href="https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning">Details on long running operation object.</see>
        /// </remarks>
        public ArmOperation<Response> StartDelete(CancellationToken cancellationToken = default)
        {
            return new ArmVoidOperation(Operations.StartDeleteById(Id, GetApiVersion(cancellationToken), cancellationToken));
        }

        /// <summary>
        /// Delete the resource.  This call returns a Task that blocks until the delete operation is accepted on the service.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service.
        /// The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A <see cref="Task"/> that on completion returns a <see cref="ArmOperation{Response}"/> which
        /// allows the caller to control polling and waiting for resource deletion.
        /// The operation yields the final http response to the delete request when complete. </returns>
        /// <remarks>
        /// <see href="https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning">Details on long running operation object.</see>
        /// </remarks>
        public async Task<ArmOperation<Response>> StartDeleteAsync(CancellationToken cancellationToken = default)
        {
            var operation = await Operations.StartDeleteByIdAsync(Id, await GetApiVersionAsync(cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
            return new ArmVoidOperation(operation);
        }

        /// <inheritdoc/>
        public ArmResponse<GenericResource> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            GenericResource resource = GetResource();
            // Potential optimization on tags set, remove NOOP to bypass the call.
            resource.Data.Tags[key] = value;
            return new PhArmResponse<GenericResource, ResourceManager.Resources.Models.GenericResource>(
                Operations.StartUpdateById(Id, GetApiVersion(cancellationToken), resource.Data, cancellationToken).WaitForCompletionAsync(cancellationToken).EnsureCompleted(),
                v => new GenericResource(this, new GenericResourceData(v)));
        }

        /// <inheritdoc/>
        public async Task<ArmResponse<GenericResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            GenericResource resource = await GetResourceAsync(cancellationToken).ConfigureAwait(false);
            resource.Data.Tags[key] = value;
            var op = await Operations.StartUpdateByIdAsync(Id, await GetApiVersionAsync(cancellationToken).ConfigureAwait(false), resource.Data, cancellationToken).ConfigureAwait(false);
            return new PhArmResponse<GenericResource, ResourceManager.Resources.Models.GenericResource>(
                await op.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false),
                v => new GenericResource(this, new GenericResourceData(v)));
        }

        /// <inheritdoc/>
        public ArmOperation<GenericResource> StartAddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            GenericResource resource = GetResource();
            resource.Data.Tags[key] = value;
            return new PhArmOperation<GenericResource, ResourceManager.Resources.Models.GenericResource>(
                Operations.StartUpdateById(Id, GetApiVersion(cancellationToken), resource.Data, cancellationToken).WaitForCompletionAsync(cancellationToken).EnsureCompleted(),
                v => new GenericResource(this, new GenericResourceData(v)));
        }

        /// <inheritdoc/>
        public async Task<ArmOperation<GenericResource>> StartAddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            GenericResource resource = await GetResourceAsync(cancellationToken).ConfigureAwait(false);
            resource.Data.Tags[key] = value;
            var op = await Operations.StartUpdateByIdAsync(Id, await GetApiVersionAsync(cancellationToken).ConfigureAwait(false), resource.Data, cancellationToken).ConfigureAwait(false);
            return new PhArmOperation<GenericResource, ResourceManager.Resources.Models.GenericResource>(
                await op.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false),
                v => new GenericResource(this, new GenericResourceData(v)));
        }

        /// <inheritdoc/>
        public override ArmResponse<GenericResource> Get(CancellationToken cancellationToken = default)
        {
            return new PhArmResponse<GenericResource, ResourceManager.Resources.Models.GenericResource>(
                Operations.GetById(Id, GetApiVersion(cancellationToken), cancellationToken),
                v => new GenericResource(this, new GenericResourceData(v)));
        }

        /// <inheritdoc/>
        public override async Task<ArmResponse<GenericResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            return new PhArmResponse<GenericResource, ResourceManager.Resources.Models.GenericResource>(
                await Operations.GetByIdAsync(Id, await GetApiVersionAsync(cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false),
                v => new GenericResource(this, new GenericResourceData(v)));
        }

        /// <inheritdoc/>
        protected override void Validate(ResourceIdentifier identifier)
        {
            // TODO: Reenable after Azure.ResourceManager.Resource model has been regenerated
            // Currently test cases uses GenericResourceExpended that does not allow construction
            // with id.
            // if (identifier is null)
            //    throw new ArgumentNullException(nameof(identifier));
        }

        /// <inheritdoc/>
        public ArmResponse<GenericResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            GenericResource resource = GetResource();
            resource.Data.Tags.ReplaceWith(tags);
            return new PhArmResponse<GenericResource, ResourceManager.Resources.Models.GenericResource>(
                Operations.StartUpdateById(Id, GetApiVersion(cancellationToken), resource.Data, cancellationToken).WaitForCompletionAsync(cancellationToken).EnsureCompleted(),
                v => new GenericResource(this, new GenericResourceData(v)));
        }

        /// <inheritdoc/>
        public async Task<ArmResponse<GenericResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            GenericResource resource = await GetResourceAsync(cancellationToken).ConfigureAwait(false);
            resource.Data.Tags.ReplaceWith(tags);
            var op = await Operations.StartUpdateByIdAsync(Id, await GetApiVersionAsync(cancellationToken).ConfigureAwait(false), resource.Data, cancellationToken).ConfigureAwait(false);
            return new PhArmResponse<GenericResource, ResourceManager.Resources.Models.GenericResource>(
                await op.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false),
                v => new GenericResource(this, new GenericResourceData(v)));
        }

        /// <inheritdoc/>
        public ArmOperation<GenericResource> StartSetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            GenericResource resource = GetResource();
            resource.Data.Tags.ReplaceWith(tags);
            return new PhArmOperation<GenericResource, ResourceManager.Resources.Models.GenericResource>(
                Operations.StartUpdateById(Id, GetApiVersion(cancellationToken), resource.Data, cancellationToken).WaitForCompletionAsync(cancellationToken).EnsureCompleted(),
                v => new GenericResource(this, new GenericResourceData(v)));
        }

        /// <inheritdoc/>
        public async Task<ArmOperation<GenericResource>> StartSetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            GenericResource resource = await GetResourceAsync(cancellationToken).ConfigureAwait(false);
            resource.Data.Tags.ReplaceWith(tags);
            var op = await Operations.StartUpdateByIdAsync(Id, await GetApiVersionAsync(cancellationToken).ConfigureAwait(false), resource.Data, cancellationToken).ConfigureAwait(false);
            return new PhArmOperation<GenericResource, ResourceManager.Resources.Models.GenericResource>(
                await op.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false),
                v => new GenericResource(this, new GenericResourceData(v)));
        }

        /// <inheritdoc/>
        public ArmResponse<GenericResource> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            GenericResource resource = GetResource();
            resource.Data.Tags.Remove(key);
            return new PhArmResponse<GenericResource, ResourceManager.Resources.Models.GenericResource>(
                Operations.StartUpdateById(Id, GetApiVersion(cancellationToken), resource.Data, cancellationToken).WaitForCompletionAsync(cancellationToken).EnsureCompleted(),
                v => new GenericResource(this, new GenericResourceData(v)));
        }

        /// <inheritdoc/>
        public async Task<ArmResponse<GenericResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            GenericResource resource = await GetResourceAsync(cancellationToken).ConfigureAwait(false);
            resource.Data.Tags.Remove(key);
            var op = await Operations.StartUpdateByIdAsync(Id,  await GetApiVersionAsync(cancellationToken).ConfigureAwait(false), resource.Data, cancellationToken).ConfigureAwait(false);
            return new PhArmResponse<GenericResource, ResourceManager.Resources.Models.GenericResource>(
                await op.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false),
                v => new GenericResource(this, new GenericResourceData(v)));
        }

        /// <inheritdoc/>
        public ArmOperation<GenericResource> StartRemoveTag(string key, CancellationToken cancellationToken = default)
        {
            GenericResource resource = GetResource();
            resource.Data.Tags.Remove(key);
            return new PhArmOperation<GenericResource, ResourceManager.Resources.Models.GenericResource>(
                Operations.StartUpdateById(Id, GetApiVersion(cancellationToken), resource.Data, cancellationToken).WaitForCompletionAsync(cancellationToken).EnsureCompleted(),
                v => new GenericResource(this, new GenericResourceData(v)));
        }

        /// <inheritdoc/>
        public async Task<ArmOperation<GenericResource>> StartRemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            GenericResource resource = await GetResourceAsync(cancellationToken).ConfigureAwait(false);
            resource.Data.Tags.Remove(key);
            var op = await Operations.StartUpdateByIdAsync(Id, await GetApiVersionAsync(cancellationToken).ConfigureAwait(false), resource.Data, cancellationToken).ConfigureAwait(false);
            return new PhArmOperation<GenericResource, ResourceManager.Resources.Models.GenericResource>(
                await op.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false),
                v => new GenericResource(this, new GenericResourceData(v)));
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
