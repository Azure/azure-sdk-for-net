using Azure;
using Azure.ResourceManager.Compute;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Core.Adapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Proto.Compute
{
    /// <summary>
    /// A class representing the operations that can be performed over a specific VirtualMachine.
    /// </summary>
    public class VirtualMachineOperations : ResourceOperationsBase<VirtualMachine>, ITaggableResource<VirtualMachine>, IDeletableResource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VirtualMachineOperations"/> class.
        /// </summary>
        /// <param name="genericOperations"> An instance of <see cref="GenericResourceOperations"/> that has an id for a virtual machine. </param>
        internal VirtualMachineOperations(GenericResourceOperations genericOperations)
            : base(genericOperations)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VirtualMachineOperations"/> class.
        /// </summary>
        /// <param name="resourceGroup"> The client parameters to use in these operations. </param>
        /// <param name="vmName"> The identifier of the resource that is the target of operations. </param>
        internal VirtualMachineOperations(ResourceGroupOperations resourceGroup, string vmName)
            : base(resourceGroup, $"{resourceGroup.Id}/providers/Microsoft.Compute/virtualMachines/{vmName}")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VirtualMachineOperations"/> class.
        /// </summary>
        /// <param name="operation"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        protected VirtualMachineOperations(ResourceOperationsBase operation, ResourceIdentifier id)
            : base(operation, id)
        {
        }

        /// <summary>
        /// Gets the resource type definition for a virtual machine.
        /// </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Compute/virtualMachines";

        /// <summary>
        /// Gets the valid resources for virtual machines.
        /// </summary>
        protected override ResourceType ValidResourceType => ResourceType;

        private VirtualMachinesOperations Operations => new ComputeManagementClient(
            BaseUri,
            Id.Subscription,
            Credential,
            ClientOptions.Convert<ComputeManagementClientOptions>()).VirtualMachines;

        /// <summary>
        /// Initializes a new instance of the <see cref="VirtualMachineOperations"/> class from a <see cref="GenericResourceOperations"/>.
        /// </summary>
        /// <param name="genericOperations"> An instance of <see cref="GenericResourceOperations"/> that has an id for a virtual machine. </param>
        /// <returns> A new instance of the <see cref="VirtualMachineOperations"/> class. </returns>
        public static VirtualMachineOperations FromGeneric(GenericResourceOperations genericOperations)
        {
            return new VirtualMachineOperations(genericOperations);
        }

        /// <summary>
        /// The operation to delete a virtual machine. 
        /// </summary>
        /// <returns> A response with the <see cref="ArmResponse{Response}"/> operation for this resource. </returns>
        public ArmResponse<Response> Delete()
        {
            return new ArmResponse(Operations.StartDelete(Id.ResourceGroup, Id.Name).WaitForCompletionAsync().ConfigureAwait(false).GetAwaiter().GetResult());
        }

        /// <summary>
        /// The operation to delete a virtual machine. 
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A <see cref="Task"/> that on completion returns a response with the <see cref="ArmResponse{Response}"/> operation for this resource. </returns>
        public async Task<ArmResponse<Response>> DeleteAsync(CancellationToken cancellationToken = default)
        {
            return new ArmResponse((await Operations.StartDeleteAsync(Id.ResourceGroup, Id.Name)).WaitForCompletionAsync().ConfigureAwait(false).GetAwaiter().GetResult());
        }

        /// <summary>
        /// The operation to delete a virtual machine. 
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <remarks>
        /// <see href="https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning">Details on long running operation object.</see>
        /// </remarks>
        /// <returns> An <see cref="ArmOperation{Response}"/> that allows polling for completion of the operation. </returns>
        public ArmOperation<Response> StartDelete(CancellationToken cancellationToken = default)
        {
            return new ArmVoidOperation(Operations.StartDelete(Id.ResourceGroup, Id.Name, cancellationToken));
        }

        /// <summary>
        /// The operation to delete a virtual machine. 
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <remarks>
        /// <see href="https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning">Details on long running operation object.</see>
        /// </remarks>
        /// <returns> A <see cref="Task"/> that on completion returns an <see cref="ArmOperation{Response}"/> that allows polling for completion of the operation. </returns>
        public async Task<ArmOperation<Response>> StartDeleteAsync(CancellationToken cancellationToken = default)
        {
            return new ArmVoidOperation(await Operations.StartDeleteAsync(Id.ResourceGroup, Id.Name, cancellationToken));
        }

        #region PowerOn
        /// <summary>
        ///  The operation to start a virtual machine. 
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A response with the <see cref="ArmResponse{Response}"/> operation for this resource. </returns>
        public ArmResponse<Response> PowerOn(CancellationToken cancellationToken = default)
        {
            var operation = Operations.StartStart(Id.ResourceGroup, Id.Name, cancellationToken);
            return new ArmResponse(operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false).GetAwaiter().GetResult());
        }

        /// <summary>
        ///  The operation to start a virtual machine. 
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A <see cref="Task"/> that on completion returns a response with the <see cref="ArmResponse{Response}"/> operation for this resource. </returns>
        public async Task<ArmResponse<Response>> PowerOnAsync(CancellationToken cancellationToken = default)
        {
            var operation = await Operations.StartStartAsync(Id.ResourceGroup, Id.Name, cancellationToken).ConfigureAwait(false);
            return new ArmResponse(await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false));
        }

        /// <summary>
        ///  The operation to start a virtual machine. 
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An <see cref="ArmOperation{Response}"/> that allows polling for completion of the operation. </returns>
        public ArmOperation<Response> StartPowerOn(CancellationToken cancellationToken = default)
        {
            return new ArmVoidOperation(Operations.StartStart(Id.ResourceGroup, Id.Name, cancellationToken));
        }

        /// <summary>
        ///  The operation to start a virtual machine. 
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A <see cref="Task"/> that on completion returns an <see cref="ArmOperation{Response}"/> that allows polling for completion of the operation. </returns>
        public async Task<ArmOperation<Response>> StartPowerOnAsync(CancellationToken cancellationToken = default)
        {
            return new ArmVoidOperation(await Operations.StartStartAsync(Id.ResourceGroup, Id.Name, cancellationToken).ConfigureAwait(false));
        }
        #endregion

        #region PowerOff
        /// <summary>
        ///  The operation to power off (stop) a virtual machine. The virtual machine can be restarted with the same provisioned resources. You are still charged for this virtual machine. 
        /// </summary>
        /// <param name="skipShutdown"> The parameter to request non-graceful VM shutdown. True value for this flag indicates non-graceful shutdown whereas false indicates otherwise. Default value for this flag is false if not specified. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A response with the <see cref="ArmResponse{Response}"/> operation for this resource. </returns>
        public ArmResponse<Response> PowerOff(bool? skipShutdown = null, CancellationToken cancellationToken = default)
        {
            var operation = Operations.StartPowerOff(Id.ResourceGroup, Id.Name, skipShutdown, cancellationToken);
            return new ArmResponse(operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false).GetAwaiter().GetResult());
        }

        /// <summary>
        ///  The operation to power off (stop) a virtual machine. The virtual machine can be restarted with the same provisioned resources. You are still charged for this virtual machine. 
        /// </summary>
        /// <param name="skipShutdown"> The parameter to request non-graceful VM shutdown. True value for this flag indicates non-graceful shutdown whereas false indicates otherwise. Default value for this flag is false if not specified. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A <see cref="Task"/> that on completion returns a response with the <see cref="ArmResponse{Response}"/> operation for this resource. </returns>
        public async Task<ArmResponse<Response>> PowerOffAsync(bool? skipShutdown = null, CancellationToken cancellationToken = default)
        {
            var operation = await Operations.StartPowerOffAsync(Id.ResourceGroup, Id.Name, skipShutdown, cancellationToken).ConfigureAwait(false);
            return new ArmResponse(await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false));
        }

        /// <summary>
        ///  The operation to power off (stop) a virtual machine. The virtual machine can be restarted with the same provisioned resources. You are still charged for this virtual machine. 
        /// </summary>
        /// <param name="skipShutdown"> The parameter to request non-graceful VM shutdown. True value for this flag indicates non-graceful shutdown whereas false indicates otherwise. Default value for this flag is false if not specified. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An <see cref="ArmOperation{Response}"/> that allows polling for completion of the operation. </returns>
        public ArmOperation<Response> StartPowerOff(bool? skipShutdown = null, CancellationToken cancellationToken = default)
        {
            return new ArmVoidOperation(Operations.StartPowerOff(Id.ResourceGroup, Id.Name, skipShutdown, cancellationToken));
        }

        /// <summary>
        ///  The operation to power off (stop) a virtual machine. The virtual machine can be restarted with the same provisioned resources. You are still charged for this virtual machine. 
        /// </summary>
        /// <param name="skipShutdown"> The parameter to request non-graceful VM shutdown. True value for this flag indicates non-graceful shutdown whereas false indicates otherwise. Default value for this flag is false if not specified. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A <see cref="Task"/> that on completion returns an <see cref="ArmOperation{Response}"/> that allows polling for completion of the operation. </returns>
        public async Task<ArmOperation<Response>> StartPowerOffAsync(bool? skipShutdown = null, CancellationToken cancellationToken = default)
        {
            return new ArmVoidOperation(await Operations.StartPowerOffAsync(Id.ResourceGroup, Id.Name, skipShutdown, cancellationToken).ConfigureAwait(false));
        }
        #endregion

        /// <inheritdoc/>
        public override ArmResponse<VirtualMachine> Get()
        {
            return new PhArmResponse<VirtualMachine, Azure.ResourceManager.Compute.Models.VirtualMachine>(
                Operations.Get(Id.ResourceGroup, Id.Name),
                v => new VirtualMachine(this, new VirtualMachineData(v)));
        }

        /// <inheritdoc/>
        public override async Task<ArmResponse<VirtualMachine>> GetAsync(CancellationToken cancellationToken = default)
        {
            return new PhArmResponse<VirtualMachine, Azure.ResourceManager.Compute.Models.VirtualMachine>(
                await Operations.GetAsync(Id.ResourceGroup, Id.Name, cancellationToken),
                v => new VirtualMachine(this, new VirtualMachineData(v)));
        }

        /// <summary>
        ///  The operation to update a virtual machine. Please note some properties can be set only during virtual machine creation. 
        /// </summary>
        /// <param name="patchable"> The parameters to update. </param>
        /// <returns> An <see cref="ArmOperation{VirtualMachine}"/> that allows polling for completion of the operation. </returns>
        public ArmOperation<VirtualMachine> StartUpdate(VirtualMachineUpdate patchable)
        {
            return new PhArmOperation<VirtualMachine, Azure.ResourceManager.Compute.Models.VirtualMachine>(
                Operations.StartUpdate(Id.ResourceGroup, Id.Name, patchable),
                v => new VirtualMachine(this, new VirtualMachineData(v)));
        }

        /// <summary>
        ///  The operation to update a virtual machine. Please note some properties can be set only during virtual machine creation. 
        /// </summary>
        /// <param name="patchable"> The parameters to update. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A <see cref="Task"/> that on completion returns an <see cref="ArmOperation{VirtualMachine}"/> that allows polling for completion of the operation. </returns>
        public async Task<ArmOperation<VirtualMachine>> StartUpdateAsync(VirtualMachineUpdate patchable, CancellationToken cancellationToken = default)
        {
            return new PhArmOperation<VirtualMachine, Azure.ResourceManager.Compute.Models.VirtualMachine>(
                await Operations.StartUpdateAsync(Id.ResourceGroup, Id.Name, patchable, cancellationToken),
                v => new VirtualMachine(this, new VirtualMachineData(v)));
        }

        /// <summary>
        /// Add a tag to a virtual machine.
        /// If the tag already exists it will be modified.
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <returns> An <see cref="ArmResponse{VirtualMachine}"/> that allows polling for completion of the operation. </returns>
        public ArmResponse<VirtualMachine> AddTag(string key, string value)
        {
            var vm = GetResource();
            var patchable = new VirtualMachineUpdate { Tags = vm.Data.Tags };
            UpdateTags(key, value, patchable.Tags);

            return new PhArmResponse<VirtualMachine, Azure.ResourceManager.Compute.Models.VirtualMachine>(
                Operations.StartUpdate(Id.ResourceGroup, Id.Name, patchable).WaitForCompletionAsync().ConfigureAwait(false).GetAwaiter().GetResult(),
                v => new VirtualMachine(this, new VirtualMachineData(v)));
        }

        /// <summary>
        /// Add a tag to a virtual machine.
        /// If the tag already exists it will be modified.
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A <see cref="Task"/> that on completion returns an <see cref="ArmResponse{VirtualMachine}"/> that allows polling for completion of the operation. </returns>
        public async Task<ArmResponse<VirtualMachine>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            var vm = await GetResourceAsync();
            var patchable = new VirtualMachineUpdate { Tags = vm.Data.Tags };
            UpdateTags(key, value, patchable.Tags);

            return new PhArmResponse<VirtualMachine, Azure.ResourceManager.Compute.Models.VirtualMachine>(
                await Operations.StartUpdateAsync(Id.ResourceGroup, Id.Name, patchable, cancellationToken).Result.WaitForCompletionAsync(),
                v => new VirtualMachine(this, new VirtualMachineData(v)));
        }

        /// <summary>
        /// Add a tag to a virtual machine.
        /// If the tag already exists it will be modified.
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <returns> An <see cref="ArmOperation{VirtualMachine}"/> that allows polling for completion of the operation. </returns>
        public ArmOperation<VirtualMachine> StartAddTag(string key, string value)
        {
            var vm = GetResource();
            var patchable = new VirtualMachineUpdate { Tags = vm.Data.Tags };
            UpdateTags(key, value, patchable.Tags);

            return new PhArmOperation<VirtualMachine, Azure.ResourceManager.Compute.Models.VirtualMachine>(
                Operations.StartUpdate(Id.ResourceGroup, Id.Name, patchable),
                v => new VirtualMachine(this, new VirtualMachineData(v)));
        }

        /// <summary>
        /// Add a tag to a virtual machine.
        /// If the tag already exists it will be modified.
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A <see cref="Task"/> that on completion returns an <see cref="ArmOperation{VirtualMachine}"/> that allows polling for completion of the operation. </returns>
        public async Task<ArmOperation<VirtualMachine>> StartAddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            var vm = await GetResourceAsync();
            var patchable = new VirtualMachineUpdate { Tags = vm.Data.Tags };
            UpdateTags(key, value, patchable.Tags);

            return new PhArmOperation<VirtualMachine, Azure.ResourceManager.Compute.Models.VirtualMachine>(
                await Operations.StartUpdateAsync(Id.ResourceGroup, Id.Name, patchable, cancellationToken),
                v => new VirtualMachine(this, new VirtualMachineData(v)));
        }

        /// <inheritdoc/>
        public ArmResponse<VirtualMachine> SetTags(IDictionary<string, string> tags)
        {
            var vm = GetResource();
            var patchable = new VirtualMachineUpdate { Tags = vm.Data.Tags };
            ReplaceTags(tags, patchable.Tags);

            return new PhArmResponse<VirtualMachine, Azure.ResourceManager.Compute.Models.VirtualMachine>(
                Operations.StartUpdate(Id.ResourceGroup, Id.Name, patchable).WaitForCompletionAsync().ConfigureAwait(false).GetAwaiter().GetResult(),
                v => new VirtualMachine(this, new VirtualMachineData(v)));
        }

        /// <inheritdoc/>
        public async Task<ArmResponse<VirtualMachine>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            var vm = await GetResourceAsync();
            var patchable = new VirtualMachineUpdate { Tags = vm.Data.Tags };
            ReplaceTags(tags, patchable.Tags);

            return new PhArmResponse<VirtualMachine, Azure.ResourceManager.Compute.Models.VirtualMachine>(
                await Operations.StartUpdateAsync(Id.ResourceGroup, Id.Name, patchable, cancellationToken).Result.WaitForCompletionAsync(),
                v => new VirtualMachine(this, new VirtualMachineData(v)));
        }

        /// <inheritdoc/>
        public ArmOperation<VirtualMachine> StartSetTags(IDictionary<string, string> tags)
        {
            var vm = GetResource();
            var patchable = new VirtualMachineUpdate { Tags = vm.Data.Tags };
            ReplaceTags(tags, patchable.Tags);

            return new PhArmOperation<VirtualMachine, Azure.ResourceManager.Compute.Models.VirtualMachine>(
                Operations.StartUpdate(Id.ResourceGroup, Id.Name, patchable).WaitForCompletionAsync().ConfigureAwait(false).GetAwaiter().GetResult(),
                v => new VirtualMachine(this, new VirtualMachineData(v)));
        }

        /// <inheritdoc/>
        public async Task<ArmOperation<VirtualMachine>> StartSetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            var vm = await GetResourceAsync();
            var patchable = new VirtualMachineUpdate { Tags = vm.Data.Tags };
            ReplaceTags(tags, patchable.Tags);

            return new PhArmOperation<VirtualMachine, Azure.ResourceManager.Compute.Models.VirtualMachine>(
                await Operations.StartUpdateAsync(Id.ResourceGroup, Id.Name, patchable, cancellationToken).Result.WaitForCompletionAsync(),
                v => new VirtualMachine(this, new VirtualMachineData(v)));
        }

        /// <inheritdoc/>
        public ArmResponse<VirtualMachine> RemoveTag(string key)
        {
            var vm = GetResource();
            var patchable = new VirtualMachineUpdate { Tags = vm.Data.Tags };
            DeleteTag(key, patchable.Tags);

            return new PhArmResponse<VirtualMachine, Azure.ResourceManager.Compute.Models.VirtualMachine>(
                Operations.StartUpdate(Id.ResourceGroup, Id.Name, patchable).WaitForCompletionAsync().ConfigureAwait(false).GetAwaiter().GetResult(),
                v => new VirtualMachine(this, new VirtualMachineData(v)));
        }

        /// <inheritdoc/>
        public async Task<ArmResponse<VirtualMachine>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            var vm = await GetResourceAsync();
            var patchable = new VirtualMachineUpdate { Tags = vm.Data.Tags };
            DeleteTag(key, patchable.Tags);

            return new PhArmResponse<VirtualMachine, Azure.ResourceManager.Compute.Models.VirtualMachine>(
                await Operations.StartUpdateAsync(Id.ResourceGroup, Id.Name, patchable, cancellationToken).Result.WaitForCompletionAsync(),
                v => new VirtualMachine(this, new VirtualMachineData(v)));
        }

        /// <inheritdoc/>
        public ArmOperation<VirtualMachine> StartRemoveTag(string key)
        {
            var vm = GetResource();
            var patchable = new VirtualMachineUpdate { Tags = vm.Data.Tags };
            DeleteTag(key, patchable.Tags);

            return new PhArmOperation<VirtualMachine, Azure.ResourceManager.Compute.Models.VirtualMachine>(
                Operations.StartUpdate(Id.ResourceGroup, Id.Name, patchable).WaitForCompletionAsync().ConfigureAwait(false).GetAwaiter().GetResult(),
                v => new VirtualMachine(this, new VirtualMachineData(v)));
        }

        /// <inheritdoc/>
        public async Task<ArmOperation<VirtualMachine>> StartRemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            var vm = await GetResourceAsync();
            var patchable = new VirtualMachineUpdate { Tags = vm.Data.Tags };
            DeleteTag(key, patchable.Tags);

            return new PhArmOperation<VirtualMachine, Azure.ResourceManager.Compute.Models.VirtualMachine>(
                await Operations.StartUpdateAsync(Id.ResourceGroup, Id.Name, patchable, cancellationToken).Result.WaitForCompletionAsync(),
                v => new VirtualMachine(this, new VirtualMachineData(v)));
        }

        /// <summary>
        /// Lists all available geo-locations.
        /// </summary>
        /// <returns> A collection of location that may take multiple service requests to iterate over. </returns>
        public IEnumerable<LocationData> ListAvailableLocations()
        {
            var pageableProvider = ResourcesClient.Providers.List(expand: "metadata");
            var vmProvider = pageableProvider.FirstOrDefault(p => string.Equals(p.Namespace, ResourceType?.Namespace, StringComparison.InvariantCultureIgnoreCase));
            var vmResource = vmProvider.ResourceTypes.FirstOrDefault(r => ResourceType.Type.Equals(r.ResourceType));
            return vmResource.Locations.Select(l => (LocationData)l);
        }

        /// <summary>
        /// Lists all available geo-locations.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of location that may take multiple service requests to iterate over. </returns>
        /// <exception cref="InvalidOperationException"> The default subscription id is null. </exception>
        public async Task<IEnumerable<LocationData>> ListAvailableLocationsAsync(CancellationToken cancellationToken = default)
        {
            var asyncpageableProvider = ResourcesClient.Providers.ListAsync(expand: "metadata", cancellationToken: cancellationToken);
            var vmProvider = await asyncpageableProvider.FirstOrDefaultAsync(p => string.Equals(p.Namespace, ResourceType?.Namespace, StringComparison.InvariantCultureIgnoreCase));
            var vmResource = vmProvider.ResourceTypes.FirstOrDefault(r => ResourceType.Type.Equals(r.ResourceType)); 
            return vmResource.Locations.Select(l => (LocationData)l);
        }
    }
}
