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
        public static readonly ResourceType ResourceType = "Microsoft.Compute/virtualMachineScaleSets";

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
        public Response Delete(CancellationToken cancellationToken = default)
        {
            return Operations.StartDelete(Id.ResourceGroupName, Id.Name, cancellationToken).WaitForCompletionAsync(cancellationToken).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<Response> DeleteAsync(CancellationToken cancellationToken = default)
        {
            return (await Operations.StartDeleteAsync(Id.ResourceGroupName, Id.Name, cancellationToken)).WaitForCompletionAsync(cancellationToken).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public Operation StartDelete(CancellationToken cancellationToken = default)
        {
            return new PhVoidArmOperation(Operations.StartDelete(Id.ResourceGroupName, Id.Name, cancellationToken));
        }

        /// <inheritdoc/>
        public async Task<Operation> StartDeleteAsync(CancellationToken cancellationToken = default)
        {
            return new PhVoidArmOperation(await Operations.StartDeleteAsync(Id.ResourceGroupName, Id.Name, cancellationToken));
        }

        /// <inheritdoc/>
        public override Response<VirtualMachineScaleSet> Get(CancellationToken cancellationToken = default)
        {
            return new PhArmResponse<VirtualMachineScaleSet, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSet>(
                Operations.Get(Id.ResourceGroupName, Id.Name, cancellationToken),
                v => new VirtualMachineScaleSet(this, new VirtualMachineScaleSetData(v)));
        }

        /// <inheritdoc/>
        public override async Task<Response<VirtualMachineScaleSet>> GetAsync(CancellationToken cancellationToken = default)
        {
            return new PhArmResponse<VirtualMachineScaleSet, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSet>(
                await Operations.GetAsync(Id.ResourceGroupName, Id.Name, cancellationToken),
                v => new VirtualMachineScaleSet(this, new VirtualMachineScaleSetData(v)));
        }

        /// <summary>
        ///  The operation to update a virtual machine. Please note some properties can be set only during virtual machine creation. 
        /// </summary>
        /// <param name="patchable"> The parameters to update. </param>
        /// <returns> An <see cref="Operation{VirtualMachineScaleSet}"/> that allows polling for completion of the operation. </returns>
        public Operation<VirtualMachineScaleSet> StartUpdate(VirtualMachineScaleSetUpdate patchable, CancellationToken cancellationToken = default)
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
        /// <returns> A <see cref="Task"/> that on completion returns an <see cref="Operation{VirtualMachineScaleSet}"/> that allows polling for completion of the operation. </returns>
        public async Task<Operation<VirtualMachineScaleSet>> StartUpdateAsync(VirtualMachineScaleSetUpdate patchable, CancellationToken cancellationToken = default)
        {
            return new PhArmOperation<VirtualMachineScaleSet, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSet>(
                await Operations.StartUpdateAsync(Id.ResourceGroupName, Id.Name, patchable, cancellationToken),
                v => new VirtualMachineScaleSet(this, new VirtualMachineScaleSetData(v)));
        }

        /// <inheritdoc/>
        public Response<VirtualMachineScaleSet> AddTag(string key, string value, CancellationToken cancellationToken = default)
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
        public async Task<Response<VirtualMachineScaleSet>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
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
        public Operation<VirtualMachineScaleSet> StartAddTag(string key, string value, CancellationToken cancellationToken = default)
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
        public async Task<Operation<VirtualMachineScaleSet>> StartAddTagAsync(string key, string value, CancellationToken cancellationToken = default)
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
        public Response<VirtualMachineScaleSet> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            var patchable = new VirtualMachineScaleSetUpdate();
            patchable.Tags.ReplaceWith(tags);

            return new PhArmResponse<VirtualMachineScaleSet, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSet>(
                Operations.StartUpdate(Id.ResourceGroupName, Id.Name, patchable, cancellationToken).WaitForCompletionAsync(cancellationToken).ConfigureAwait(false).GetAwaiter().GetResult(),
                v => new VirtualMachineScaleSet(this, new VirtualMachineScaleSetData(v)));
        }

        /// <inheritdoc/>
        public async Task<Response<VirtualMachineScaleSet>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            var patchable = new VirtualMachineScaleSetUpdate();
            patchable.Tags.ReplaceWith(tags);

            return new PhArmResponse<VirtualMachineScaleSet, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSet>(
                await Operations.StartUpdateAsync(Id.ResourceGroupName, Id.Name, patchable, cancellationToken).Result.WaitForCompletionAsync(cancellationToken),
                v => new VirtualMachineScaleSet(this, new VirtualMachineScaleSetData(v)));
        }

        /// <inheritdoc/>
        public Operation<VirtualMachineScaleSet> StartSetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            var patchable = new VirtualMachineScaleSetUpdate();
            patchable.Tags.ReplaceWith(tags);

            return new PhArmOperation<VirtualMachineScaleSet, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSet>(
                Operations.StartUpdate(Id.ResourceGroupName, Id.Name, patchable, cancellationToken).WaitForCompletionAsync(cancellationToken).ConfigureAwait(false).GetAwaiter().GetResult(),
                v => new VirtualMachineScaleSet(this, new VirtualMachineScaleSetData(v)));
        }

        /// <inheritdoc/>
        public async Task<Operation<VirtualMachineScaleSet>> StartSetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            var patchable = new VirtualMachineScaleSetUpdate();
            patchable.Tags.ReplaceWith(tags);

            return new PhArmOperation<VirtualMachineScaleSet, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSet>(
                await Operations.StartUpdateAsync(Id.ResourceGroupName, Id.Name, patchable, cancellationToken).Result.WaitForCompletionAsync(cancellationToken),
                v => new VirtualMachineScaleSet(this, new VirtualMachineScaleSetData(v)));
        }

        /// <inheritdoc/>
        public Response<VirtualMachineScaleSet> RemoveTag(string key, CancellationToken cancellationToken = default)
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
        public async Task<Response<VirtualMachineScaleSet>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
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
        public Operation<VirtualMachineScaleSet> StartRemoveTag(string key, CancellationToken cancellationToken = default)
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
        public async Task<Operation<VirtualMachineScaleSet>> StartRemoveTagAsync(string key, CancellationToken cancellationToken = default)
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
        public RollingUpgradeOperations GetRollingUpgrade()
        {
            return new RollingUpgradeOperations(this);
        }
    }
}
