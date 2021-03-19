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
    public class ResourceGroupOperations : ResourceOperationsBase<ResourceGroupResourceIdentifier, ResourceGroup>,
        ITaggableResource<ResourceGroupResourceIdentifier, ResourceGroup>, IDeletableResource
    {
        /// <summary>
        /// Gets the resource type definition for a ResourceType.
        /// </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Resources/subscriptions/resourceGroups";

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceGroupOperations"/> class for mocking.
        /// </summary>
        protected ResourceGroupOperations()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceGroupOperations"/> class.
        /// </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="rgName"> The name of the resource group to use. </param>
        internal ResourceGroupOperations(SubscriptionOperations options, string rgName)
            : base(options, new ResourceGroupResourceIdentifier(options.Id, rgName))
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
        protected ResourceGroupOperations(ResourceOperationsBase options, ResourceGroupResourceIdentifier id)
            : base(options, id)
        {
        }

        /// <inheritdoc/>
        protected override ResourceType ValidResourceType => ResourceType;

        private ResourceGroupsOperations Operations => new ResourcesManagementClient(
            BaseUri,
            Id.SubscriptionId,
            Credential,
            ClientOptions.Convert<ResourcesManagementClientOptions>()).ResourceGroups;

        /// <summary>
        /// When you delete a resource group, all of its resources are also deleted. Deleting a resource group deletes all of its template deployments and currently stored operations.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A response with the <see cref="ArmResponse{Response}"/> operation for this resource. </returns>
        public virtual ArmResponse<Response> Delete(CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("ResourceGroupOperations.Delete");
            scope.Start();

            try
            {
                return new ArmResponse(Operations.StartDelete(Id.Name, cancellationToken).WaitForCompletion(cancellationToken));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// When you delete a resource group, all of its resources are also deleted. Deleting a resource group deletes all of its template deployments and currently stored operations.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A <see cref="Task"/> that on completion returns a response with the <see cref="ArmResponse{Response}"/> operation for this resource. </returns>
        public virtual async Task<ArmResponse<Response>> DeleteAsync(CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("ResourceGroupOperations.Delete");
            scope.Start();

            try
            {
                return new ArmResponse(await Operations.StartDelete(Id.Name, cancellationToken).WaitForCompletionAsync(cancellationToken).ConfigureAwait(false));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// When you delete a resource group, all of its resources are also deleted. Deleting a resource group deletes all of its template deployments and currently stored operations.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A response with the <see cref="ArmOperation{Response}"/> operation for this resource. </returns>
        /// <remarks>
        /// <see href="https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning">Details on long running operation object.</see>
        /// </remarks>
        public virtual ArmOperation<Response> StartDelete(CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("ResourceGroupOperations.StartDelete");
            scope.Start();

            try
            {
                return new ArmVoidOperation(Operations.StartDelete(Id.Name, cancellationToken));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// When you delete a resource group, all of its resources are also deleted. Deleting a resource group deletes all of its template deployments and currently stored operations.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A <see cref="Task"/> that on completion returns a response with the <see cref="ArmResponse{Response}"/> operation for this resource. </returns>
        /// <remarks>
        /// <see href="https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning">Details on long running operation object.</see>
        /// </remarks>
        public virtual async Task<ArmOperation<Response>> StartDeleteAsync(CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("ResourceGroupOperations.StartDelete");
            scope.Start();

            try
            {
                return new ArmVoidOperation(await Operations.StartDeleteAsync(Id.Name, cancellationToken).ConfigureAwait(false));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc/>
        public override ArmResponse<ResourceGroup> Get(CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("ResourceGroupOperations.Get");
            scope.Start();

            try
            {
                return new PhArmResponse<ResourceGroup, ResourceManager.Resources.Models.ResourceGroup>(Operations.Get(Id.Name, cancellationToken), g =>
                {
                    return new ResourceGroup(this, new ResourceGroupData(g));
                });
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc/>
        public override async Task<ArmResponse<ResourceGroup>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("ResourceGroupOperations.Get");
            scope.Start();

            try
            {
                return new PhArmResponse<ResourceGroup, ResourceManager.Resources.Models.ResourceGroup>(
                await Operations.GetAsync(Id.Name, cancellationToken).ConfigureAwait(false),
                g =>
                {
                    return new ResourceGroup(this, new ResourceGroupData(g));
                });
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc/>
        public virtual ArmResponse<ResourceGroup> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException($"{nameof(key)} provided cannot be null or a whitespace.", nameof(key));

            using var scope = Diagnostics.CreateScope("ResourceGroupOperations.AddTag");
            scope.Start();

            try
            {
                var resource = GetResource();
                var patch = new ResourceGroupPatchable();
                patch.Tags.ReplaceWith(resource.Data.Tags);
                patch.Tags[key] = value;
                return new PhArmResponse<ResourceGroup, ResourceManager.Resources.Models.ResourceGroup>(Operations.Update(Id.Name, patch, cancellationToken), g =>
                {
                    return new ResourceGroup(this, new ResourceGroupData(g));
                });
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc/>
        public virtual async Task<ArmResponse<ResourceGroup>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException($"{nameof(key)} provided cannot be null or a whitespace.", nameof(key));

            using var scope = Diagnostics.CreateScope("ResourceGroupOperations.AddTag");
            scope.Start();

            try
            {
                ResourceGroup resource = await GetResourceAsync(cancellationToken).ConfigureAwait(false);
                var patch = new ResourceGroupPatchable();
                patch.Tags.ReplaceWith(resource.Data.Tags);
                patch.Tags[key] = value;
                return new PhArmResponse<ResourceGroup, ResourceManager.Resources.Models.ResourceGroup>(
                    await Operations.UpdateAsync(Id.Name, patch, cancellationToken).ConfigureAwait(false), g =>
                {
                    return new ResourceGroup(this, new ResourceGroupData(g));
                });
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc/>
        public virtual ArmOperation<ResourceGroup> StartAddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException($"{nameof(key)} provided cannot be null or a whitespace.", nameof(key));

            using var scope = Diagnostics.CreateScope("ResourceGroupOperations.StartAddTag");
            scope.Start();

            try
            {
                var resource = GetResource();
                var patch = new ResourceGroupPatchable();
                patch.Tags.ReplaceWith(resource.Data.Tags);
                patch.Tags[key] = value;
                return new PhArmOperation<ResourceGroup, ResourceManager.Resources.Models.ResourceGroup>(Operations.Update(Id.Name, patch, cancellationToken), g =>
                {
                    return new ResourceGroup(this, new ResourceGroupData(g));
                });
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc/>
        public virtual async Task<ArmOperation<ResourceGroup>> StartAddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException($"{nameof(key)} provided cannot be null or a whitespace.", nameof(key));

            using var scope = Diagnostics.CreateScope("ResourceGroupOperations.StartAddTag");
            scope.Start();

            try
            {
                ResourceGroup resource = await GetResourceAsync(cancellationToken).ConfigureAwait(false);
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
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Create a resource with a ResourceGroupOperations.
        /// </summary>
        /// <param name="name"> A string representing the name of the resource />. </param>
        /// <param name="model"> The model representing the object to create. />. </param>
        /// <typeparam name="TContainer"> The type of the class containing the container for the specific resource. </typeparam>
        /// <typeparam name="TOperations"> The type of the operations class for a specific resource. </typeparam>
        /// <typeparam name="TIdentifier"> The type of the resource identifier. </typeparam>
        /// <typeparam name="TResource"> The type of the class containing properties for the underlying resource. </typeparam>
        /// <returns> Returns a response with the <see cref="ArmResponse{TOperations}"/> operation for this resource. </returns>
        /// <exception cref="ArgumentException"> Name cannot be null or a whitespace. </exception>
        /// <exception cref="ArgumentNullException"> Model cannot be null. </exception>
        public virtual ArmResponse<TOperations> CreateResource<TContainer, TOperations, TIdentifier, TResource>(string name, TResource model)
            where TResource : TrackedResource<TIdentifier>
            where TOperations : ResourceOperationsBase<TIdentifier, TOperations>
            where TContainer : ResourceContainerBase<TIdentifier, TOperations, TResource>
            where TIdentifier : SubscriptionResourceIdentifier
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException($"{nameof(name)} provided cannot be null or a whitespace.", nameof(name));
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            var myResource = model as TrackedResource<TIdentifier>;
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
        /// <typeparam name="TIdentifier"> The type of the operations class for a specific resource. </typeparam>
        /// <typeparam name="TOperations"> The type of the resource identifier. </typeparam>
        /// <typeparam name="TResource"> The type of the class containing properties for the underlying resource. </typeparam>
        /// <returns> A <see cref="Task"/> that on completion returns a response with the <see cref="ArmResponse{TOperations}"/> operation for this resource. </returns>
        /// <exception cref="ArgumentException"> Name cannot be null or a whitespace. </exception>
        /// <exception cref="ArgumentNullException"> Model cannot be null. </exception>
        public virtual Task<ArmResponse<TOperations>> CreateResourceAsync<TContainer, TIdentifier, TOperations, TResource>(string name, TResource model, CancellationToken cancellationToken = default)
            where TResource : TrackedResource<TIdentifier>
            where TOperations : ResourceOperationsBase<TIdentifier,TOperations>
            where TContainer : ResourceContainerBase<TIdentifier, TOperations, TResource>
            where TIdentifier : SubscriptionResourceIdentifier
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException($"{nameof(name)} provided cannot be null or a whitespace.", nameof(name));
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            var myResource = model as TrackedResource<TIdentifier>;

            TContainer container = Activator.CreateInstance(typeof(TContainer), ClientOptions, myResource) as TContainer;

            return container.CreateOrUpdateAsync(name, model, cancellationToken);
        }

        /// <inheritdoc/>
        public virtual ArmResponse<ResourceGroup> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            if (tags == null)
                throw new ArgumentNullException(nameof(tags));

            using var scope = Diagnostics.CreateScope("ResourceGroupOperations.SetTags");
            scope.Start();

            try
            {
                var resource = GetResource();
                var patch = new ResourceGroupPatchable();
                patch.Tags.ReplaceWith(tags);
                return new PhArmResponse<ResourceGroup, ResourceManager.Resources.Models.ResourceGroup>(Operations.Update(Id.Name, patch, cancellationToken), g =>
                {
                    return new ResourceGroup(this, new ResourceGroupData(g));
                });
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc/>
        public virtual async Task<ArmResponse<ResourceGroup>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            if (tags == null)
                throw new ArgumentNullException(nameof(tags));

            using var scope = Diagnostics.CreateScope("ResourceGroupOperations.SetTags");
            scope.Start();

            try
            {
                ResourceGroup resource = await GetResourceAsync(cancellationToken).ConfigureAwait(false);
                var patch = new ResourceGroupPatchable();
                patch.Tags.ReplaceWith(tags);
                return new PhArmResponse<ResourceGroup, ResourceManager.Resources.Models.ResourceGroup>(
                    await Operations.UpdateAsync(Id.Name, patch, cancellationToken).ConfigureAwait(false),
                    g =>
                    {
                        return new ResourceGroup(this, new ResourceGroupData(g));
                    });
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc/>
        public virtual ArmOperation<ResourceGroup> StartSetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            if (tags == null)
                throw new ArgumentNullException(nameof(tags));

            using var scope = Diagnostics.CreateScope("ResourceGroupOperations.StartSetTags");
            scope.Start();

            try
            {
                var resource = GetResource();
                var patch = new ResourceGroupPatchable();
                patch.Tags.ReplaceWith(tags);
                return new PhArmOperation<ResourceGroup, ResourceManager.Resources.Models.ResourceGroup>(Operations.Update(Id.Name, patch, cancellationToken), g =>
                {
                    return new ResourceGroup(this, new ResourceGroupData(g));
                });
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc/>
        public virtual async Task<ArmOperation<ResourceGroup>> StartSetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            if (tags == null)
                throw new ArgumentNullException(nameof(tags));

            using var scope = Diagnostics.CreateScope("ResourceGroupOperations.StartSetTags");
            scope.Start();

            try
            {
                ResourceGroup resource = await GetResourceAsync(cancellationToken).ConfigureAwait(false);
                var patch = new ResourceGroupPatchable();
                patch.Tags.ReplaceWith(tags);
                return new PhArmOperation<ResourceGroup, ResourceManager.Resources.Models.ResourceGroup>(
                    await Operations.UpdateAsync(Id.Name, patch, cancellationToken).ConfigureAwait(false),
                    g =>
                    {
                        return new ResourceGroup(this, new ResourceGroupData(g));
                    });
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc/>
        public virtual ArmResponse<ResourceGroup> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException($"{nameof(key)} provided cannot be null or a whitespace.", nameof(key));

            using var scope = Diagnostics.CreateScope("ResourceGroupOperations.RemoveTag");
            scope.Start();

            try
            {
                var resource = GetResource();
                var patch = new ResourceGroupPatchable();
                patch.Tags.ReplaceWith(resource.Data.Tags);
                patch.Tags.Remove(key);
                return new PhArmResponse<ResourceGroup, ResourceManager.Resources.Models.ResourceGroup>(Operations.Update(Id.Name, patch, cancellationToken), g =>
                {
                    return new ResourceGroup(this, new ResourceGroupData(g));
                });
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc/>
        public virtual async Task<ArmResponse<ResourceGroup>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException($"{nameof(key)} provided cannot be null or a whitespace.", nameof(key));

            using var scope = Diagnostics.CreateScope("ResourceGroupOperations.RemoveTag");
            scope.Start();

            try
            {
                ResourceGroup resource = await GetResourceAsync(cancellationToken).ConfigureAwait(false);
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
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc/>
        public virtual ArmOperation<ResourceGroup> StartRemoveTag(string key, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException($"{nameof(key)} provided cannot be null or a whitespace.", nameof(key));

            using var scope = Diagnostics.CreateScope("ResourceGroupOperations.StartRemoveTag");
            scope.Start();

            try
            {
                var resource = GetResource();
                var patch = new ResourceGroupPatchable();
                patch.Tags.ReplaceWith(resource.Data.Tags);
                patch.Tags.Remove(key);
                return new PhArmOperation<ResourceGroup, ResourceManager.Resources.Models.ResourceGroup>(Operations.Update(Id.Name, patch, cancellationToken), g =>
                {
                    return new ResourceGroup(this, new ResourceGroupData(g));
                });
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc/>
        public virtual async Task<ArmOperation<ResourceGroup>> StartRemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException($"{nameof(key)} provided cannot be null or a whitespace.", nameof(key));

            using var scope = Diagnostics.CreateScope("ResourceGroupOperations.StartRemoveTag");
            scope.Start();

            try
            {
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
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists all available geo-locations.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of location that may take multiple service requests to iterate over. </returns>
        public virtual IEnumerable<LocationData> ListAvailableLocations(CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("ResourceGroupOperations.ListAvailableLocations");
            scope.Start();

            try
            {
                return ListAvailableLocations(ResourceType, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists all available geo-locations.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of location that may take multiple service requests to iterate over. </returns>
        /// <exception cref="InvalidOperationException"> The default subscription id is null. </exception>
        public virtual async Task<IEnumerable<LocationData>> ListAvailableLocationsAsync(CancellationToken cancellationToken = default)
        {
            using var scope = Diagnostics.CreateScope("ResourceGroupOperations.ListAvailableLocations");
            scope.Start();

            try
            {
                return await ListAvailableLocationsAsync(ResourceType, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
