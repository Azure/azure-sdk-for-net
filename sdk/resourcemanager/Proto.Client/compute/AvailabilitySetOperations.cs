using Azure;
using Azure.ResourceManager.Compute;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Core;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Proto.Compute
{
    /// <summary>
    /// A class representing the operations that can be performed over a specific availability set.
    /// </summary>
    public class AvailabilitySetOperations : ResourceOperationsBase<ResourceGroupResourceIdentifier, AvailabilitySet>, ITaggableResource<ResourceGroupResourceIdentifier, AvailabilitySet>, IDeletableResource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GenericResourceOperations"/> class.
        /// </summary>
        /// <param name="genericOperations"> An instance of <see cref="GenericResourceOperations"/> that has an id for an availability set. </param>
        internal AvailabilitySetOperations(GenericResourceOperations genericOperations)
            : base(genericOperations, genericOperations.Id)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericResourceOperations"/> class.
        /// </summary>
        /// <param name="resourceGroup"> The client parameters to use in these operations. </param>
        /// <param name="availabilitySetName"> The name of the availability set to use. </param>
        internal AvailabilitySetOperations(ResourceGroupOperations resourceGroup, string availabilitySetName)
            : base(resourceGroup, resourceGroup.Id.AppendProviderResource(ResourceType.Namespace, ResourceType.Type, availabilitySetName))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericResourceOperations"/> class.
        /// </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        protected AvailabilitySetOperations(ResourceOperationsBase options, ResourceGroupResourceIdentifier id)
            : base(options, id)
        {
        }

        /// <summary>
        /// Gets the resource type definition for an availability set.
        /// </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Compute/availabilitySets";

        /// <inheritdoc/>
        protected override ResourceType ValidResourceType => ResourceType;

        private AvailabilitySetsOperations Operations => new ComputeManagementClient(
            BaseUri,
            Id.SubscriptionId,
            Credential,
            ClientOptions.Convert<ComputeManagementClientOptions>()).AvailabilitySets;

        /// <inheritdoc/>
        public ArmResponse<Response> Delete(CancellationToken cancellationToken = default)
        {
            return new ArmResponse(Operations.Delete(Id.ResourceGroupName, Id.Name, cancellationToken));
        }

        /// <inheritdoc/>
        public async Task<ArmResponse<Response>> DeleteAsync(CancellationToken cancellationToken = default)
        {
            return new ArmResponse(await Operations.DeleteAsync(Id.ResourceGroupName, Id.Name, cancellationToken));
        }

        /// <inheritdoc/>
        public ArmOperation<Response> StartDelete(CancellationToken cancellationToken = default)
        {
            return new ArmVoidOperation(Operations.Delete(Id.ResourceGroupName, Id.Name, cancellationToken));
        }

        /// <inheritdoc/>
        public async Task<ArmOperation<Response>> StartDeleteAsync(CancellationToken cancellationToken = default)
        {
            return new ArmVoidOperation(await Operations.DeleteAsync(Id.ResourceGroupName, Id.Name, cancellationToken));
        }

        /// <inheritdoc/>
        public override ArmResponse<AvailabilitySet> Get(CancellationToken cancellationToken = default)
        {
            return new PhArmResponse<AvailabilitySet, Azure.ResourceManager.Compute.Models.AvailabilitySet>(
                Operations.Get(Id.ResourceGroupName, Id.Name),
                a => new AvailabilitySet(this, new AvailabilitySetData(a)));
        }

        /// <inheritdoc/>
        public async override Task<ArmResponse<AvailabilitySet>> GetAsync(CancellationToken cancellationToken = default)
        {
            return new PhArmResponse<AvailabilitySet, Azure.ResourceManager.Compute.Models.AvailabilitySet>(
                await Operations.GetAsync(Id.ResourceGroupName, Id.Name, cancellationToken),
                a => new AvailabilitySet(this, new AvailabilitySetData(a)));
        }

        /// <summary>
        /// The operation to update an availability set. 
        /// </summary>
        /// <param name="patchable"> The parameters to update. </param>
        /// <returns> The operation of the updated resource. </returns>
        public ArmResponse<AvailabilitySet> Update(AvailabilitySetUpdate patchable, CancellationToken cancellationToken = default)
        {
            return new PhArmResponse<AvailabilitySet, Azure.ResourceManager.Compute.Models.AvailabilitySet>(
                Operations.Update(Id.ResourceGroupName, Id.Name, patchable, cancellationToken),
                a => new AvailabilitySet(this, new AvailabilitySetData(a)));
        }

        /// <summary>
        /// The operation to update an availability set.
        /// </summary>
        /// <param name="patchable">  The parameters to update. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A <see cref="Task"/> that on completion returns the operation of the updated resource. </returns>
        public async Task<ArmResponse<AvailabilitySet>> UpdateAsync(AvailabilitySetUpdate patchable, CancellationToken cancellationToken = default)
        {
            return new PhArmResponse<AvailabilitySet, Azure.ResourceManager.Compute.Models.AvailabilitySet>(
                await Operations.UpdateAsync(Id.ResourceGroupName, Id.Name, patchable, cancellationToken),
                a => new AvailabilitySet(this, new AvailabilitySetData(a)));
        }

        /// <summary>
        /// The operation to update an availability set. 
        /// </summary>
        /// <param name="patchable"> The parameters to update. </param>
        /// <returns> The operation of the updated resource. </returns>
        public ArmOperation<AvailabilitySet> StartUpdate(AvailabilitySetUpdate patchable, CancellationToken cancellationToken = default)
        {
            return new PhArmOperation<AvailabilitySet, Azure.ResourceManager.Compute.Models.AvailabilitySet>(
                Operations.Update(Id.ResourceGroupName, Id.Name, patchable, cancellationToken),
                a => new AvailabilitySet(this, new AvailabilitySetData(a)));
        }

        /// <summary>
        /// The operation to update an availability set.
        /// </summary>
        /// <param name="patchable">  The parameters to update. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A <see cref="Task"/> that on completion returns the operation of the updated resource. </returns>
        public async Task<ArmOperation<AvailabilitySet>> StartUpdateAsync(AvailabilitySetUpdate patchable, CancellationToken cancellationToken = default)
        {
            return new PhArmOperation<AvailabilitySet, Azure.ResourceManager.Compute.Models.AvailabilitySet>(
                await Operations.UpdateAsync(Id.ResourceGroupName, Id.Name, patchable, cancellationToken),
                a => new AvailabilitySet(this, new AvailabilitySetData(a)));
        }

        /// <inheritdoc/>
        public ArmResponse<AvailabilitySet> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            var resource = GetResource();
            var patchable = new AvailabilitySetUpdate();
            patchable.Tags.ReplaceWith(resource.Data.Tags);
            patchable.Tags[key] = value;
            return Update(patchable, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<ArmResponse<AvailabilitySet>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            var resource = await GetResourceAsync(cancellationToken);
            var patchable = new AvailabilitySetUpdate();
            patchable.Tags.ReplaceWith(resource.Data.Tags);
            patchable.Tags[key] = value;
            return await UpdateAsync(patchable, cancellationToken);
        }

        /// <inheritdoc/>
        public ArmOperation<AvailabilitySet> StartAddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            var resource = GetResource();
            var patchable = new AvailabilitySetUpdate();
            patchable.Tags.ReplaceWith(resource.Data.Tags);
            patchable.Tags[key] = value;
            return StartUpdate(patchable, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<ArmOperation<AvailabilitySet>> StartAddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            var resource = await GetResourceAsync(cancellationToken);
            var patchable = new AvailabilitySetUpdate();
            patchable.Tags.ReplaceWith(resource.Data.Tags);
            patchable.Tags[key] = value;
            return await StartUpdateAsync(patchable, cancellationToken);
        }

        /// <inheritdoc/>
        public ArmResponse<AvailabilitySet> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            var patchable = new AvailabilitySetUpdate();
            patchable.Tags.ReplaceWith(tags);
            return Update(patchable, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<ArmResponse<AvailabilitySet>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            var patchable = new AvailabilitySetUpdate();
            patchable.Tags.ReplaceWith(tags);
            return await UpdateAsync(patchable, cancellationToken);
        }

        /// <inheritdoc/>
        public ArmOperation<AvailabilitySet> StartSetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            var patchable = new AvailabilitySetUpdate();
            patchable.Tags.ReplaceWith(tags);
            return StartUpdate(patchable, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<ArmOperation<AvailabilitySet>> StartSetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            var patchable = new AvailabilitySetUpdate();
            patchable.Tags.ReplaceWith(tags);
            return await StartUpdateAsync(patchable, cancellationToken);
        }

        /// <inheritdoc/>
        public ArmResponse<AvailabilitySet> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            var resource = GetResource();
            var patchable = new AvailabilitySetUpdate();
            patchable.Tags.ReplaceWith(resource.Data.Tags);
            patchable.Tags.Remove(key);
            return Update(patchable, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<ArmResponse<AvailabilitySet>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            var resource = await GetResourceAsync(cancellationToken);
            var patchable = new AvailabilitySetUpdate();
            patchable.Tags.ReplaceWith(resource.Data.Tags);
            patchable.Tags.Remove(key);
            return await UpdateAsync(patchable, cancellationToken);
        }

        /// <inheritdoc/>
        public ArmOperation<AvailabilitySet> StartRemoveTag(string key, CancellationToken cancellationToken = default)
        {
            var resource = GetResource();
            var patchable = new AvailabilitySetUpdate();
            patchable.Tags.ReplaceWith(resource.Data.Tags);
            patchable.Tags.Remove(key);
            return StartUpdate(patchable, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<ArmOperation<AvailabilitySet>> StartRemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            var resource = await GetResourceAsync(cancellationToken);
            var patchable = new AvailabilitySetUpdate();
            patchable.Tags.ReplaceWith(resource.Data.Tags);
            patchable.Tags.Remove(key);
            return await StartUpdateAsync(patchable, cancellationToken);
        }

        /// <summary>
        /// Lists all available geo-locations.
        /// </summary>
        /// <returns> A collection of location that may take multiple service requests to iterate over. </returns>
        public IEnumerable<LocationData> ListAvailableLocations(CancellationToken cancellationToken = default)
        {
            return ListAvailableLocations(ResourceType, cancellationToken);
        }

        /// <summary>
        /// Lists all available geo-locations.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of location that may take multiple service requests to iterate over. </returns>
        /// <exception cref="InvalidOperationException"> The default subscription id is null. </exception>
        public async Task<IEnumerable<LocationData>> ListAvailableLocationsAsync(CancellationToken cancellationToken = default)
        {
            return await ListAvailableLocationsAsync(ResourceType, cancellationToken);
        }
    }
}
