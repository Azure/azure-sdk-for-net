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
    /// A class representing the operations that can be performed over a specific VirtualMachineScaleSet.
    /// </summary>
    public class VirtualMachineScaleSetOperations : ResourceOperationsBase<ResourceGroupResourceIdentifier, VirtualMachineScaleSet>, ITaggableResource<ResourceGroupResourceIdentifier, VirtualMachineScaleSet>, IDeletableResource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VirtualMachineScaleSetOperations"/> class.
        /// </summary>
        /// <param name="genericOperations"> An instance of <see cref="GenericResourceOperations"/> that has an id for a virtual machine. </param>
        internal VirtualMachineScaleSetOperations(GenericResourceOperations genericOperations)
            : base(genericOperations, genericOperations.Id)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VirtualMachineScaleSetOperations"/> class.
        /// </summary>
        /// <param name="resourceGroup"> The client parameters to use in these operations. </param>
        /// <param name="vmName"> The identifier of the resource that is the target of operations. </param>
        internal VirtualMachineScaleSetOperations(ResourceGroupOperations resourceGroup, string vmName)
            : base(resourceGroup, resourceGroup.Id.AppendProviderResource(ResourceType.Namespace, ResourceType.Type, vmName))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VirtualMachineScaleSetOperations"/> class.
        /// </summary>
        /// <param name="operation"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        protected VirtualMachineScaleSetOperations(ResourceOperationsBase operation, ResourceGroupResourceIdentifier id)
            : base(operation, id)
        {
        }

        /// <summary>
        /// Gets the resource type definition for a virtual machine.
        /// </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Compute/VirtualMachineScaleSets";

        /// <summary>
        /// Gets the valid resources for virtual machines.
        /// </summary>
        protected override ResourceType ValidResourceType => ResourceType;

        private VirtualMachineScaleSetsOperations Operations => new ComputeManagementClient(
            BaseUri,
            Id.SubscriptionId,
            Credential,
            ClientOptions.Convert<ComputeManagementClientOptions>()).VirtualMachineScaleSets;

        /// <summary>
        /// Initializes a new instance of the <see cref="VirtualMachineScaleSetOperations"/> class from a <see cref="GenericResourceOperations"/>.
        /// </summary>
        /// <param name="genericOperations"> An instance of <see cref="GenericResourceOperations"/> that has an id for a virtual machine. </param>
        /// <returns> A new instance of the <see cref="VirtualMachineScaleSetOperations"/> class. </returns>
        public static VirtualMachineScaleSetOperations FromGeneric(GenericResourceOperations genericOperations)
        {
            return new VirtualMachineScaleSetOperations(genericOperations);
        }

        /// <inheritdoc/>
        public ArmResponse<Response> Delete(CancellationToken cancellationToken = default)
        {
            return new ArmResponse(Operations.StartDelete(Id.ResourceGroupName, Id.Name, cancellationToken).WaitForCompletionAsync(cancellationToken).ConfigureAwait(false).GetAwaiter().GetResult());
        }

        /// <inheritdoc/>
        public async Task<ArmResponse<Response>> DeleteAsync(CancellationToken cancellationToken = default)
        {
            return new ArmResponse((await Operations.StartDeleteAsync(Id.ResourceGroupName, Id.Name, cancellationToken)).WaitForCompletionAsync(cancellationToken).ConfigureAwait(false).GetAwaiter().GetResult());
        }

        /// <inheritdoc/>
        public ArmOperation<Response> StartDelete(CancellationToken cancellationToken = default)
        {
            return new ArmVoidOperation(Operations.StartDelete(Id.ResourceGroupName, Id.Name, cancellationToken));
        }

        /// <inheritdoc/>
        public async Task<ArmOperation<Response>> StartDeleteAsync(CancellationToken cancellationToken = default)
        {
            return new ArmVoidOperation(await Operations.StartDeleteAsync(Id.ResourceGroupName, Id.Name, cancellationToken));
        }

        /// <inheritdoc/>
        public override ArmResponse<VirtualMachineScaleSet> Get(CancellationToken cancellationToken = default)
        {
            return new PhArmResponse<VirtualMachineScaleSet, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSet>(
                Operations.Get(Id.ResourceGroupName, Id.Name, cancellationToken),
                v => new VirtualMachineScaleSet(this, new VirtualMachineScaleSetData(v)));
        }

        /// <inheritdoc/>
        public override async Task<ArmResponse<VirtualMachineScaleSet>> GetAsync(CancellationToken cancellationToken = default)
        {
            return new PhArmResponse<VirtualMachineScaleSet, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSet>(
                await Operations.GetAsync(Id.ResourceGroupName, Id.Name, cancellationToken),
                v => new VirtualMachineScaleSet(this, new VirtualMachineScaleSetData(v)));
        }

        /// <summary>
        ///  The operation to update a virtual machine. Please note some properties can be set only during virtual machine creation. 
        /// </summary>
        /// <param name="patchable"> The parameters to update. </param>
        /// <returns> An <see cref="ArmOperation{VirtualMachineScaleSet}"/> that allows polling for completion of the operation. </returns>
        public ArmOperation<VirtualMachineScaleSet> StartUpdate(VirtualMachineScaleSetUpdate patchable, CancellationToken cancellationToken = default)
        {
            return new PhArmOperation<VirtualMachineScaleSet, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSet>(
                Operations.StartUpdate(Id.ResourceGroupName, Id.Name, patchable, cancellationToken),
                v => new VirtualMachineScaleSet(this, new VirtualMachineScaleSetData(v)));
        }

        /// <summary>
        ///  The operation to update a virtual machine. Please note some properties can be set only during virtual machine creation. 
        /// </summary>
        /// <param name="patchable"> The parameters to update. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A <see cref="Task"/> that on completion returns an <see cref="ArmOperation{VirtualMachineScaleSet}"/> that allows polling for completion of the operation. </returns>
        public async Task<ArmOperation<VirtualMachineScaleSet>> StartUpdateAsync(VirtualMachineScaleSetUpdate patchable, CancellationToken cancellationToken = default)
        {
            return new PhArmOperation<VirtualMachineScaleSet, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSet>(
                await Operations.StartUpdateAsync(Id.ResourceGroupName, Id.Name, patchable, cancellationToken),
                v => new VirtualMachineScaleSet(this, new VirtualMachineScaleSetData(v)));
        }

        /// <inheritdoc/>
        public ArmResponse<VirtualMachineScaleSet> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            var vm = GetResource();
            var patchable = new VirtualMachineScaleSetUpdate();
            patchable.Tags.ReplaceWith(vm.Data.Tags);
            patchable.Tags[key] = value;

            return new PhArmResponse<VirtualMachineScaleSet, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSet>(
                Operations.StartUpdate(Id.ResourceGroupName, Id.Name, patchable, cancellationToken).WaitForCompletionAsync(cancellationToken).ConfigureAwait(false).GetAwaiter().GetResult(),
                v => new VirtualMachineScaleSet(this, new VirtualMachineScaleSetData(v)));
        }

        /// <inheritdoc/>
        public async Task<ArmResponse<VirtualMachineScaleSet>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            var vm = await GetResourceAsync(cancellationToken);
            var patchable = new VirtualMachineScaleSetUpdate();
            patchable.Tags.ReplaceWith(vm.Data.Tags);
            patchable.Tags[key] = value;

            return new PhArmResponse<VirtualMachineScaleSet, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSet>(
                await Operations.StartUpdateAsync(Id.ResourceGroupName, Id.Name, patchable, cancellationToken).Result.WaitForCompletionAsync(),
                v => new VirtualMachineScaleSet(this, new VirtualMachineScaleSetData(v)));
        }

        /// <inheritdoc/>
        public ArmOperation<VirtualMachineScaleSet> StartAddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            var vm = GetResource();
            var patchable = new VirtualMachineScaleSetUpdate();
            patchable.Tags.ReplaceWith(vm.Data.Tags);
            patchable.Tags[key] = value;

            return new PhArmOperation<VirtualMachineScaleSet, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSet>(
                Operations.StartUpdate(Id.ResourceGroupName, Id.Name, patchable, cancellationToken),
                v => new VirtualMachineScaleSet(this, new VirtualMachineScaleSetData(v)));
        }

        /// <inheritdoc/>
        public async Task<ArmOperation<VirtualMachineScaleSet>> StartAddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            var vm = await GetResourceAsync(cancellationToken);
            var patchable = new VirtualMachineScaleSetUpdate();
            patchable.Tags.ReplaceWith(vm.Data.Tags);
            patchable.Tags[key] = value;

            return new PhArmOperation<VirtualMachineScaleSet, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSet>(
                await Operations.StartUpdateAsync(Id.ResourceGroupName, Id.Name, patchable, cancellationToken),
                v => new VirtualMachineScaleSet(this, new VirtualMachineScaleSetData(v)));
        }

        /// <inheritdoc/>
        public ArmResponse<VirtualMachineScaleSet> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            var patchable = new VirtualMachineScaleSetUpdate();
            patchable.Tags.ReplaceWith(tags);

            return new PhArmResponse<VirtualMachineScaleSet, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSet>(
                Operations.StartUpdate(Id.ResourceGroupName, Id.Name, patchable, cancellationToken).WaitForCompletionAsync(cancellationToken).ConfigureAwait(false).GetAwaiter().GetResult(),
                v => new VirtualMachineScaleSet(this, new VirtualMachineScaleSetData(v)));
        }

        /// <inheritdoc/>
        public async Task<ArmResponse<VirtualMachineScaleSet>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            var patchable = new VirtualMachineScaleSetUpdate();
            patchable.Tags.ReplaceWith(tags);

            return new PhArmResponse<VirtualMachineScaleSet, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSet>(
                await Operations.StartUpdateAsync(Id.ResourceGroupName, Id.Name, patchable, cancellationToken).Result.WaitForCompletionAsync(cancellationToken),
                v => new VirtualMachineScaleSet(this, new VirtualMachineScaleSetData(v)));
        }

        /// <inheritdoc/>
        public ArmOperation<VirtualMachineScaleSet> StartSetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            var patchable = new VirtualMachineScaleSetUpdate();
            patchable.Tags.ReplaceWith(tags);

            return new PhArmOperation<VirtualMachineScaleSet, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSet>(
                Operations.StartUpdate(Id.ResourceGroupName, Id.Name, patchable, cancellationToken).WaitForCompletionAsync(cancellationToken).ConfigureAwait(false).GetAwaiter().GetResult(),
                v => new VirtualMachineScaleSet(this, new VirtualMachineScaleSetData(v)));
        }

        /// <inheritdoc/>
        public async Task<ArmOperation<VirtualMachineScaleSet>> StartSetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            var patchable = new VirtualMachineScaleSetUpdate();
            patchable.Tags.ReplaceWith(tags);

            return new PhArmOperation<VirtualMachineScaleSet, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSet>(
                await Operations.StartUpdateAsync(Id.ResourceGroupName, Id.Name, patchable, cancellationToken).Result.WaitForCompletionAsync(cancellationToken),
                v => new VirtualMachineScaleSet(this, new VirtualMachineScaleSetData(v)));
        }

        /// <inheritdoc/>
        public ArmResponse<VirtualMachineScaleSet> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            var vm = GetResource();
            var patchable = new VirtualMachineScaleSetUpdate();
            patchable.Tags.ReplaceWith(vm.Data.Tags);
            patchable.Tags.Remove(key);

            return new PhArmResponse<VirtualMachineScaleSet, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSet>(
                Operations.StartUpdate(Id.ResourceGroupName, Id.Name, patchable, cancellationToken).WaitForCompletionAsync(cancellationToken).ConfigureAwait(false).GetAwaiter().GetResult(),
                v => new VirtualMachineScaleSet(this, new VirtualMachineScaleSetData(v)));
        }

        /// <inheritdoc/>
        public async Task<ArmResponse<VirtualMachineScaleSet>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            var vm = await GetResourceAsync(cancellationToken);
            var patchable = new VirtualMachineScaleSetUpdate();
            patchable.Tags.ReplaceWith(vm.Data.Tags);
            patchable.Tags.Remove(key);

            return new PhArmResponse<VirtualMachineScaleSet, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSet>(
                await Operations.StartUpdateAsync(Id.ResourceGroupName, Id.Name, patchable, cancellationToken).Result.WaitForCompletionAsync(cancellationToken),
                v => new VirtualMachineScaleSet(this, new VirtualMachineScaleSetData(v)));
        }

        /// <inheritdoc/>
        public ArmOperation<VirtualMachineScaleSet> StartRemoveTag(string key, CancellationToken cancellationToken = default)
        {
            var vm = GetResource();
            var patchable = new VirtualMachineScaleSetUpdate();
            patchable.Tags.ReplaceWith(vm.Data.Tags);
            patchable.Tags.Remove(key);

            return new PhArmOperation<VirtualMachineScaleSet, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSet>(
                Operations.StartUpdate(Id.ResourceGroupName, Id.Name, patchable, cancellationToken).WaitForCompletionAsync(cancellationToken).ConfigureAwait(false).GetAwaiter().GetResult(),
                v => new VirtualMachineScaleSet(this, new VirtualMachineScaleSetData(v)));
        }

        /// <inheritdoc/>
        public async Task<ArmOperation<VirtualMachineScaleSet>> StartRemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            var vm = await GetResourceAsync(cancellationToken);
            var patchable = new VirtualMachineScaleSetUpdate();
            patchable.Tags.ReplaceWith(vm.Data.Tags);
            patchable.Tags.Remove(key);

            return new PhArmOperation<VirtualMachineScaleSet, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSet>(
                await Operations.StartUpdateAsync(Id.ResourceGroupName, Id.Name, patchable, cancellationToken).Result.WaitForCompletionAsync(cancellationToken),
                v => new VirtualMachineScaleSet(this, new VirtualMachineScaleSetData(v)));
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
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of location that may take multiple service requests to iterate over. </returns>
        /// <exception cref="InvalidOperationException"> The default subscription id is null. </exception>
        public async Task<IEnumerable<LocationData>> ListAvailableLocationsAsync(CancellationToken cancellationToken = default)
        {
            return await ListAvailableLocationsAsync(ResourceType, cancellationToken);
        }

        /// <summary>
        /// Gets a list of subnet in the virtual nerwork.
        /// </summary>
        /// <returns> An object representing collection of subnets and their operations over a virtual network. </returns>
        public VirtualMachineScaleSetRollingUpgradeOperations GetRollingUpgrade()
        {
            return new VirtualMachineScaleSetRollingUpgradeOperations(this, Id);
        }
    }
}
