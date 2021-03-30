using Azure;
using Azure.ResourceManager.Compute;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Core.Resources;
using Proto.Compute.Convenience;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Proto.Compute
{
    /// <summary>
    /// A class representing collection of VirtualMachine and their operations over a ResourceGroup.
    /// </summary>
    public class VirtualMachineContainer : ResourceContainerBase<ResourceGroupResourceIdentifier, VirtualMachine, VirtualMachineData>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VirtualMachineContainer"/> class.
        /// </summary>
        /// <param name="resourceGroup"> The ResourceGroup that is the parent of the VirtualMachines. </param>
        internal VirtualMachineContainer(ResourceGroupOperations resourceGroup)
            : base(resourceGroup)
        {
        }

        /// <summary>
        /// Typed Resource Identifier for the container.
        /// </summary>
        public new ResourceGroupResourceIdentifier Id => base.Id as ResourceGroupResourceIdentifier;

        private VirtualMachinesOperations Operations => new ComputeManagementClient(
            BaseUri,
            Id.SubscriptionId,
            Credential,
            ClientOptions.Convert<ComputeManagementClientOptions>()).VirtualMachines;

        /// <summary>
        /// Gets the valid resource type for this object
        /// </summary>
        protected override ResourceType ValidResourceType => ResourceGroupOperations.ResourceType;

        /// <summary>
        /// The operation to create a virtual machine.
        /// </summary>
        /// <param name="name"> The name of the virtual machine. </param>
        /// <param name="resourceDetails"> Parameters supplied to the Create Virtual Machine operation. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A response with the <see cref="ArmResponse{VirtualMachine}"/> operation for this resource. </returns>
        public override ArmResponse<VirtualMachine> CreateOrUpdate(string name, VirtualMachineData resourceDetails, CancellationToken cancellationToken = default)
        {
            var operation = Operations.StartCreateOrUpdate(Id.ResourceGroupName, name, resourceDetails.Model, cancellationToken);
            return new PhArmResponse<VirtualMachine, Azure.ResourceManager.Compute.Models.VirtualMachine>(
                operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false).GetAwaiter().GetResult(),
                v => new VirtualMachine(Parent, new VirtualMachineData(v)));
        }

        /// <summary>
        /// The operation to create a virtual machine.
        /// </summary>
        /// <param name="name"> The name of the virtual machine. </param>
        /// <param name="resourceDetails"> Parameters supplied to the Create Virtual Machine operation. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A <see cref="Task"/> that on completion returns a response with the <see cref="ArmResponse{VirtualMachine}"/> operation for this resource. </returns>
        public async override Task<ArmResponse<VirtualMachine>> CreateOrUpdateAsync(string name, VirtualMachineData resourceDetails, CancellationToken cancellationToken = default)
        {
            var operation = await Operations.StartCreateOrUpdateAsync(Id.ResourceGroupName, name, resourceDetails.Model, cancellationToken).ConfigureAwait(false);
            return new PhArmResponse<VirtualMachine, Azure.ResourceManager.Compute.Models.VirtualMachine>(
                await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false),
                v => new VirtualMachine(Parent, new VirtualMachineData(v)));
        }

        /// <summary>
        /// The operation to create a virtual machine.
        /// </summary>
        /// <param name="name"> The name of the virtual machine. </param>
        /// <param name="resourceDetails"> Parameters supplied to the Create Virtual Machine operation. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <remarks>
        /// <see href="https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning">Details on long running operation object.</see>
        /// </remarks>
        /// <returns> An <see cref="ArmOperation{VirtualMachine}"/> that allows polling for completion of the operation. </returns>
        public override ArmOperation<VirtualMachine> StartCreateOrUpdate(string name, VirtualMachineData resourceDetails, CancellationToken cancellationToken = default)
        {
            return new PhArmOperation<VirtualMachine, Azure.ResourceManager.Compute.Models.VirtualMachine>(
                Operations.StartCreateOrUpdate(Id.ResourceGroupName, name, resourceDetails.Model, cancellationToken),
                v => new VirtualMachine(Parent, new VirtualMachineData(v)));
        }

        /// <summary>
        /// The operation to create a virtual machine.
        /// </summary>
        /// <param name="name"> The name of the virtual machine. </param>
        /// <param name="resourceDetails"> Parameters supplied to the Create Virtual Machine operation. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <remarks>
        /// <see href="https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning">Details on long running operation object.</see>
        /// </remarks>
        /// <returns> A <see cref="Task"/> that on completion returns an <see cref="ArmOperation{VirtualMachine}"/> that allows polling for completion of the operation. </returns>
        public async override Task<ArmOperation<VirtualMachine>> StartCreateOrUpdateAsync(string name, VirtualMachineData resourceDetails, CancellationToken cancellationToken = default)
        {
            return new PhArmOperation<VirtualMachine, Azure.ResourceManager.Compute.Models.VirtualMachine>(
                await Operations.StartCreateOrUpdateAsync(Id.ResourceGroupName, name, resourceDetails.Model, cancellationToken).ConfigureAwait(false),
                v => new VirtualMachine(Parent, new VirtualMachineData(v)));
        }

        /// <summary>
        /// Construct an object used to create a VirtualMachine.
        /// </summary>
        /// <param name="hostName"> The hostname for the virtual machine. </param>
        /// <param name="adminUser"> The admin username to use. </param>
        /// <param name="adminPassword"> The admin password to use. </param>
        /// <param name="networkInterfaceId"> The network interface id to use. </param>
        /// <param name="availabilitySetId"> The availability set id to use. </param>
        /// <param name="location"> The location to create the Virtual Machine. </param>
        /// <returns> Object used to create a <see cref="VirtualMachine"/>. </returns>
        public VirtualMachineModelBuilder Construct(string hostName, string adminUser, string adminPassword, ResourceIdentifier networkInterfaceId, ResourceIdentifier availabilitySetId, LocationData location = null)
        {
            var parent = GetParentResource<ResourceGroup, ResourceGroupResourceIdentifier,ResourceGroupOperations>();
            var vm = new Azure.ResourceManager.Compute.Models.VirtualMachine(location ?? parent.Data.Location)
            {
                NetworkProfile = new NetworkProfile(),
                OsProfile = new OSProfile
                {
                    ComputerName = hostName,
                    AdminUsername = adminUser,
                    AdminPassword = adminPassword,
                    WindowsConfiguration = new WindowsConfiguration { TimeZone = "Pacific Standard Time", ProvisionVMAgent = true }
                },
                StorageProfile = new StorageProfile()
                {
                    ImageReference = new ImageReference()
                    {
                        Offer = "WindowsServer",
                        Publisher = "MicrosoftWindowsServer",
                        Sku = "2019-Datacenter",
                        Version = "latest"
                    },
                },
                HardwareProfile = new HardwareProfile() { VmSize = VirtualMachineSizeTypes.StandardB1Ms },
                AvailabilitySet = new SubResource() { Id = availabilitySetId }
            };
            vm.NetworkProfile.NetworkInterfaces.Add(new NetworkInterfaceReference() { Id = networkInterfaceId });

            return new VirtualMachineModelBuilder(this, new VirtualMachineData(vm));
        }

        /// <summary>
        /// List the virtual machines for this resource group.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of <see cref="VirtualMachine"/> that may take multiple service requests to iterate over. </returns>
        public Pageable<VirtualMachine> List(CancellationToken cancellationToken = default)
        {
            var result = Operations.List(Id.Name, cancellationToken);
            return new PhWrappingPageable<Azure.ResourceManager.Compute.Models.VirtualMachine, VirtualMachine>(
                result,
                s => new VirtualMachine(Parent, new VirtualMachineData(s)));
        }

        /// <summary>
        /// List the virtual machines for this resource group.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of <see cref="VirtualMachine"/> that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<VirtualMachine> ListAsync(CancellationToken cancellationToken = default)
        {
            var result = Operations.ListAsync(Id.Name, cancellationToken);
            return new PhWrappingAsyncPageable<Azure.ResourceManager.Compute.Models.VirtualMachine, VirtualMachine>(
                result,
                s => new VirtualMachine(Parent, new VirtualMachineData(s)));
        }

        /// <summary>
        /// Filters the list of virtual machines for this resource group represented as generic resources.
        /// </summary>
        /// <param name="nameFilter"> The substring to filter by. </param>
        /// <param name="top"> The number of items to truncate by. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of <see cref="GenericResource"/> that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResource> ListAsGenericResource(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            ResourceFilterCollection filters = new ResourceFilterCollection(VirtualMachineOperations.ResourceType);
            filters.SubstringFilter = nameFilter;
            return ResourceListOperations.ListAtContext(Parent as ResourceGroupOperations, filters, top, cancellationToken);
        }

        /// <summary>
        /// Filters the list of virtual machines for this resource group represented as generic resources.
        /// </summary>
        /// <param name="nameFilter"> The substring to filter by. </param>
        /// <param name="top"> The number of items to truncate by. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of <see cref="GenericResource"/> that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResource> ListAsGenericResourceAsync(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            ResourceFilterCollection filters = new ResourceFilterCollection(VirtualMachineOperations.ResourceType);
            filters.SubstringFilter = nameFilter;
            return ResourceListOperations.ListAtContextAsync(Parent as ResourceGroupOperations, filters, top, cancellationToken);
        }

        /// <summary>
        /// Filters the list of virtual machines for this resource group represented as generic resources.
        /// Makes an additional network call to retrieve the full data model for each virtual machine.
        /// </summary>
        /// <param name="nameFilter"> The substring to filter by. </param>
        /// <param name="top"> The number of items to truncate by. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of <see cref="VirtualMachine"/> that may take multiple service requests to iterate over. </returns>
        public Pageable<VirtualMachine> List(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            var results = ListAsGenericResource(nameFilter, top, cancellationToken);
            return new PhWrappingPageable<GenericResource, VirtualMachine>(results, s => (new VirtualMachineOperations(s)).Get().Value);
        }

        /// <summary>
        /// Filters the list of virtual machines for this resource group represented as generic resources.
        /// Makes an additional network call to retrieve the full data model for each virtual machine.
        /// </summary>
        /// <param name="nameFilter"> The substring to filter by. </param>
        /// <param name="top"> The number of items to truncate by. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of <see cref="VirtualMachine"/> that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<VirtualMachine> ListAsync(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            var results = ListAsGenericResourceAsync(nameFilter, top, cancellationToken);
            return new PhWrappingAsyncPageable<GenericResource, VirtualMachine>(results, s => (new VirtualMachineOperations(s)).Get().Value);
        }

        /// <inheritdoc />
        public override ArmResponse<VirtualMachine> Get(string virtualMachineName, CancellationToken cancellationToken = default)
        {
            return new PhArmResponse<VirtualMachine, Azure.ResourceManager.Compute.Models.VirtualMachine>(Operations.Get(Id.ResourceGroupName, virtualMachineName, cancellationToken), 
                v => new VirtualMachine(Parent, new VirtualMachineData(v)));
        }

        /// <inheritdoc/>
        public override async Task<ArmResponse<VirtualMachine>> GetAsync(string virtualMachineName, CancellationToken cancellationToken = default)
        {
            return new PhArmResponse<VirtualMachine, Azure.ResourceManager.Compute.Models.VirtualMachine>(await Operations.GetAsync(Id.ResourceGroupName, virtualMachineName, cancellationToken),
                v => new VirtualMachine(Parent, new VirtualMachineData(v)));
        }
    }
}
