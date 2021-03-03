// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing the operations that can be performed over a specific ResourceGroup.
    /// </summary>
    public class ResourceGroupOperations : ResourceOperationsBase<ResourceGroup>,
        ITaggableResource<ResourceGroup>, IDeletableResource
    {
        /// <summary>
        /// Gets the resource type definition for a ResourceType.
        /// </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Resources/resourceGroups";

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceGroupOperations"/> class.
        /// </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="rgName"> The name of the resource group to use. </param>
        internal ResourceGroupOperations(SubscriptionOperations options, string rgName)
            : base(options, $"{options.Id}/resourceGroups/{rgName}")
        {
            if (rgName.Length > 90)
                throw new ArgumentOutOfRangeException(nameof(rgName), "ResourceGroupName cannot be longer than 90 characters.");

            if (!ValidationPattern.IsMatch(rgName))
                throw new ArgumentException("The name of the resource group can include alphanumeric, underscore, parentheses, hyphen, period (except at end), and Unicode characters that match the allowed characters.", nameof(rgName));
        }

        private static readonly Regex ValidationPattern = new Regex(@"^[-\w\._\(\)]+$");

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceGroupOperations"/> class.
        /// </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        protected ResourceGroupOperations(ResourceOperationsBase options, ResourceIdentifier id)
            : base(options, id)
        {
        }

        /// <inheritdoc/>
        protected override ResourceType ValidResourceType => ResourceType;

        private ResourceGroupsOperations Operations => new ResourcesManagementClient(
            BaseUri,
            Id.Subscription,
            Credential,
            ClientOptions.Convert<ResourcesManagementClientOptions>()).ResourceGroups;

        /// <summary>
        /// When you delete a resource group, all of its resources are also deleted. Deleting a resource group deletes all of its template deployments and currently stored operations.
        /// </summary>
        /// <returns> A response with the <see cref="ArmResponse{Response}"/> operation for this resource. </returns>
        public ArmResponse<Response> Delete()
        {
            return new ArmResponse(Operations.StartDelete(Id.Name).WaitForCompletionAsync().EnsureCompleted());
        }

        /// <summary>
        /// When you delete a resource group, all of its resources are also deleted. Deleting a resource group deletes all of its template deployments and currently stored operations.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A <see cref="Task"/> that on completion returns a response with the <see cref="ArmResponse{Response}"/> operation for this resource. </returns>
        public async Task<ArmResponse<Response>> DeleteAsync(CancellationToken cancellationToken = default)
        {
            return new ArmResponse(await Operations.StartDelete(Id.Name, cancellationToken).WaitForCompletionAsync(cancellationToken).ConfigureAwait(false));
        }

        /// <summary>
        /// When you delete a resource group, all of its resources are also deleted. Deleting a resource group deletes all of its template deployments and currently stored operations.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A response with the <see cref="ArmOperation{Response}"/> operation for this resource. </returns>
        /// <remarks>
        /// <see href="https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning">Details on long running operation object.</see>
        /// </remarks>
        public ArmOperation<Response> StartDelete(CancellationToken cancellationToken = default)
        {
            return new ArmVoidOperation(Operations.StartDelete(Id.Name, cancellationToken));
        }

        /// <summary>
        /// When you delete a resource group, all of its resources are also deleted. Deleting a resource group deletes all of its template deployments and currently stored operations.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A <see cref="Task"/> that on completion returns a response with the <see cref="ArmResponse{Response}"/> operation for this resource. </returns>
        /// <remarks>
        /// <see href="https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning">Details on long running operation object.</see>
        /// </remarks>
        public async Task<ArmOperation<Response>> StartDeleteAsync(CancellationToken cancellationToken = default)
        {
            return new ArmVoidOperation(await Operations.StartDeleteAsync(Id.Name, cancellationToken).ConfigureAwait(false));
        }

        /// <inheritdoc/>
        public override ArmResponse<ResourceGroup> Get()
        {
            return new PhArmResponse<ResourceGroup, ResourceManager.Resources.Models.ResourceGroup>(Operations.Get(Id.Name), g =>
            {
                return new ResourceGroup(this, new ResourceGroupData(g));
            });
        }

        /// <inheritdoc/>
        public override async Task<ArmResponse<ResourceGroup>> GetAsync(CancellationToken cancellationToken = default)
        {
            return new PhArmResponse<ResourceGroup, ResourceManager.Resources.Models.ResourceGroup>(
                await Operations.GetAsync(Id.Name, cancellationToken).ConfigureAwait(false),
                g =>
                {
                    return new ResourceGroup(this, new ResourceGroupData(g));
                });
        }

        /// <summary>
        /// Add a tag to a ResourceGroup.
        /// If the tag already exists it will be modified.
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <returns> A response with the <see cref="ArmOperation{ResourceGroup}"/> operation for this resource. </returns>
        /// <exception cref="ArgumentException"> Key cannot be null or a whitespace. </exception>
        public ArmResponse<ResourceGroup> AddTag(string key, string value)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException($"{nameof(key)} provided cannot be null or a whitespace.", nameof(key));

            var resource = GetResource();
            var patch = new ResourceGroupPatchable();
            patch.Tags.ReplaceWith(resource.Data.Tags);
            patch.Tags[key] = value;
            return new PhArmResponse<ResourceGroup, ResourceManager.Resources.Models.ResourceGroup>(Operations.Update(Id.Name, patch), g =>
            {
                return new ResourceGroup(this, new ResourceGroupData(g));
            });
        }

        /// <summary>
        /// Add a tag to a ResourceGroup.
        /// If the tag already exists it will be modified.
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A <see cref="Task"/> that on completion returns a response with the <see cref="ArmOperation{ResourceGroup}"/> operation for this resource. </returns>
        /// <exception cref="ArgumentException"> Key cannot be null or a whitespace. </exception>
        public async Task<ArmResponse<ResourceGroup>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException($"{nameof(key)} provided cannot be null or a whitespace.", nameof(key));

            var resource = GetResource();
            var patch = new ResourceGroupPatchable();
            patch.Tags.ReplaceWith(resource.Data.Tags);
            patch.Tags[key] = value;
            return new PhArmResponse<ResourceGroup, ResourceManager.Resources.Models.ResourceGroup>(
                await Operations.UpdateAsync(Id.Name, patch, cancellationToken).ConfigureAwait(false), g =>
            {
                return new ResourceGroup(this, new ResourceGroupData(g));
            });
        }

        /// <summary>
        /// Add a tag to a ResourceGroup.
        /// If the tag already exists it will be modified.
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <returns> A response with the <see cref="ArmOperation{ResourceGroup}"/> operation for this resource. </returns>
        /// <remarks>
        /// <see href="https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning">Details on long running operation object.</see>
        /// </remarks>
        /// <exception cref="ArgumentException"> Key cannot be null or a whitespace. </exception>
        public ArmOperation<ResourceGroup> StartAddTag(string key, string value)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException($"{nameof(key)} provided cannot be null or a whitespace.", nameof(key));

            var resource = GetResource();
            var patch = new ResourceGroupPatchable();
            patch.Tags.ReplaceWith(resource.Data.Tags);
            patch.Tags[key] = value;
            return new PhArmOperation<ResourceGroup, ResourceManager.Resources.Models.ResourceGroup>(Operations.Update(Id.Name, patch), g =>
            {
                return new ResourceGroup(this, new ResourceGroupData(g));
            });
        }

        /// <summary>
        /// Add a tag to a ResourceGroup.
        /// If the tag already exists it will be modified.
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// /// <returns> A <see cref="Task"/> that on completion returns a response with the <see cref="ArmOperation{ResourceGroup}"/> operation for this resource. </returns>
        /// <remarks>
        /// <see href="https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning">Details on long running operation object.</see>
        /// </remarks>
        /// <exception cref="ArgumentException"> Key cannot be null or a whitespace. </exception>
        public async Task<ArmOperation<ResourceGroup>> StartAddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException($"{nameof(key)} provided cannot be null or a whitespace.", nameof(key));

            var resource = GetResource();
            var patch = new ResourceGroupPatchable();
            patch.Tags.ReplaceWith(resource.Data.Tags);
            patch.Tags[key] = value;
            return new PhArmOperation<ResourceGroup, ResourceManager.Resources.Models.ResourceGroup>(
                await Operations.UpdateAsync(Id.Name, patch, cancellationToken).ConfigureAwait(false),
                g =>
                {
                    return new ResourceGroup(this, new ResourceGroupData(g));
                });
        }

        /// <summary>
        /// Create a resource with a ResourceGroupOperations.
        /// </summary>
        /// <param name="name"> A string representing the name of the resource />. </param>
        /// <param name="model"> The model representing the object to create. />. </param>
        /// <typeparam name="TContainer"> The type of the class containing the container for the specific resource. </typeparam>
        /// <typeparam name="TOperations"> The type of the operations class for a specific resource. </typeparam>
        /// <typeparam name="TResource"> The type of the class containing properties for the underlying resource. </typeparam>
        /// <returns> Returns a response with the <see cref="ArmResponse{TOperations}"/> operation for this resource. </returns>
        /// <exception cref="ArgumentException"> Name cannot be null or a whitespace. </exception>
        /// <exception cref="ArgumentNullException"> Model cannot be null. </exception>
        public ArmResponse<TOperations> CreateResource<TContainer, TOperations, TResource>(string name, TResource model)
            where TResource : TrackedResource
            where TOperations : ResourceOperationsBase<TOperations>
            where TContainer : ResourceContainerBase<TOperations, TResource>
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException($"{nameof(name)} provided cannot be null or a whitespace.", nameof(name));
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            var myResource = model as TrackedResource;
            TContainer container = Activator.CreateInstance(typeof(TContainer), ClientOptions, myResource) as TContainer;

            return container.CreateOrUpdate(name, model);
        }

        /// <summary>
        /// Create a resource with a ResourceGroupOperations.
        /// </summary>
        /// <param name="name"> A string representing the name of the resource />. </param>
        /// <param name="model"> The model representing the object to create. />. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <typeparam name="TContainer"> The type of the class containing the container for the specific resource. </typeparam>
        /// <typeparam name="TOperations"> The type of the operations class for a specific resource. </typeparam>
        /// <typeparam name="TResource"> The type of the class containing properties for the underlying resource. </typeparam>
        /// <returns> A <see cref="Task"/> that on completion returns a response with the <see cref="ArmResponse{TOperations}"/> operation for this resource. </returns>
        /// <exception cref="ArgumentException"> Name cannot be null or a whitespace. </exception>
        /// <exception cref="ArgumentNullException"> Model cannot be null. </exception>
        public Task<ArmResponse<TOperations>> CreateResourceAsync<TContainer, TOperations, TResource>(string name, TResource model, CancellationToken cancellationToken = default)
            where TResource : TrackedResource
            where TOperations : ResourceOperationsBase<TOperations>
            where TContainer : ResourceContainerBase<TOperations, TResource>
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException($"{nameof(name)} provided cannot be null or a whitespace.", nameof(name));
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            var myResource = model as TrackedResource;

            TContainer container = Activator.CreateInstance(typeof(TContainer), ClientOptions, myResource) as TContainer;

            return container.CreateOrUpdateAsync(name, model, cancellationToken);
        }

        /// <inheritdoc/>
        public ArmResponse<ResourceGroup> SetTags(IDictionary<string, string> tags)
        {
            if (tags == null)
                throw new ArgumentNullException(nameof(tags));

            var resource = GetResource();
            var patch = new ResourceGroupPatchable();
            patch.Tags.ReplaceWith(tags);
            return new PhArmResponse<ResourceGroup, ResourceManager.Resources.Models.ResourceGroup>(Operations.Update(Id.Name, patch), g =>
            {
                return new ResourceGroup(this, new ResourceGroupData(g));
            });
        }

        /// <inheritdoc/>
        public async Task<ArmResponse<ResourceGroup>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            if (tags == null)
                throw new ArgumentNullException(nameof(tags));

            var resource = GetResource();
            var patch = new ResourceGroupPatchable();
            patch.Tags.ReplaceWith(tags);
            return new PhArmResponse<ResourceGroup, ResourceManager.Resources.Models.ResourceGroup>(
                await Operations.UpdateAsync(Id.Name, patch, cancellationToken).ConfigureAwait(false),
                g =>
                {
                    return new ResourceGroup(this, new ResourceGroupData(g));
                });
        }

        /// <inheritdoc/>
        public ArmOperation<ResourceGroup> StartSetTags(IDictionary<string, string> tags)
        {
            if (tags == null)
                throw new ArgumentNullException(nameof(tags));

            var resource = GetResource();
            var patch = new ResourceGroupPatchable();
            patch.Tags.ReplaceWith(tags);
            return new PhArmOperation<ResourceGroup, ResourceManager.Resources.Models.ResourceGroup>(Operations.Update(Id.Name, patch), g =>
            {
                return new ResourceGroup(this, new ResourceGroupData(g));
            });
        }

        /// <inheritdoc/>
        public async Task<ArmOperation<ResourceGroup>> StartSetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            if (tags == null)
                throw new ArgumentNullException(nameof(tags));

            var resource = GetResource();
            var patch = new ResourceGroupPatchable();
            patch.Tags.ReplaceWith(tags);
            return new PhArmOperation<ResourceGroup, ResourceManager.Resources.Models.ResourceGroup>(
                await Operations.UpdateAsync(Id.Name, patch, cancellationToken).ConfigureAwait(false),
                g =>
                {
                    return new ResourceGroup(this, new ResourceGroupData(g));
                });
        }

        /// <inheritdoc/>
        public ArmResponse<ResourceGroup> RemoveTag(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException($"{nameof(key)} provided cannot be null or a whitespace.", nameof(key));

            var resource = GetResource();
            var patch = new ResourceGroupPatchable();
            patch.Tags.ReplaceWith(resource.Data.Tags);
            patch.Tags.Remove(key);
            return new PhArmResponse<ResourceGroup, ResourceManager.Resources.Models.ResourceGroup>(Operations.Update(Id.Name, patch), g =>
            {
                return new ResourceGroup(this, new ResourceGroupData(g));
            });
        }

        /// <inheritdoc/>
        public async Task<ArmResponse<ResourceGroup>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException($"{nameof(key)} provided cannot be null or a whitespace.", nameof(key));

            var resource = GetResource();
            var patch = new ResourceGroupPatchable();
            patch.Tags.ReplaceWith(resource.Data.Tags);
            patch.Tags.Remove(key);
            return new PhArmResponse<ResourceGroup, ResourceManager.Resources.Models.ResourceGroup>(
                await Operations.UpdateAsync(Id.Name, patch, cancellationToken).ConfigureAwait(false),
                g =>
                {
                    return new ResourceGroup(this, new ResourceGroupData(g));
                });
        }

        /// <inheritdoc/>
        public ArmOperation<ResourceGroup> StartRemoveTag(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException($"{nameof(key)} provided cannot be null or a whitespace.", nameof(key));

            var resource = GetResource();
            var patch = new ResourceGroupPatchable();
            patch.Tags.ReplaceWith(resource.Data.Tags);
            patch.Tags.Remove(key);
            return new PhArmOperation<ResourceGroup, ResourceManager.Resources.Models.ResourceGroup>(Operations.Update(Id.Name, patch), g =>
            {
                return new ResourceGroup(this, new ResourceGroupData(g));
            });
        }

        /// <inheritdoc/>
        public async Task<ArmOperation<ResourceGroup>> StartRemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException($"{nameof(key)} provided cannot be null or a whitespace.", nameof(key));

            var resource = GetResource();
            var patch = new ResourceGroupPatchable();
            patch.Tags.ReplaceWith(resource.Data.Tags);
            patch.Tags.Remove(key);
            return new PhArmOperation<ResourceGroup, ResourceManager.Resources.Models.ResourceGroup>(
                await Operations.UpdateAsync(Id.Name, patch, cancellationToken).ConfigureAwait(false),
                g =>
                {
                    return new ResourceGroup(this, new ResourceGroupData(g));
                });
        }

        /// <summary>
        /// Lists all available geo-locations.
        /// </summary>
        /// <returns> A collection of location that may take multiple service requests to iterate over. </returns>
        public IEnumerable<LocationData> ListAvailableLocations()
        {
            return ListAvailableLocations(ResourceType);
        }

        /// <summary>
        /// Lists all available geo-locations.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of location that may take multiple service requests to iterate over. </returns>
        /// <exception cref="InvalidOperationException"> The default subscription id is null. </exception>
        public async Task<IEnumerable<LocationData>> ListAvailableLocationsAsync(CancellationToken cancellationToken = default)
        {
            return await ListAvailableLocationsAsync(ResourceType, cancellationToken).ConfigureAwait(false);
        }
    }
}
