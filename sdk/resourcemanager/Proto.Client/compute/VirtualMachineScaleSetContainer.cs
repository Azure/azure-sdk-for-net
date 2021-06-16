// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure;
using Azure.ResourceManager.Compute;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Core;
using System.Threading;
using System.Threading.Tasks;

namespace Proto.Compute
{
    /// <summary>
    /// A class representing collection of VirtualMachineScaleSet and their operations over a ResourceGroup.
    /// </summary>
    public class VirtualMachineScaleSetContainer : ResourceContainerBase<ResourceGroupResourceIdentifier, VirtualMachineScaleSet, VirtualMachineScaleSetData>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VirtualMachineScaleSetContainer"/> class.
        /// </summary>
        /// <param name="resourceGroup"> The ResourceGroup that is the parent of the VirtualMachineScaleSets. </param>
        internal VirtualMachineScaleSetContainer(ResourceGroupOperations resourceGroup)
            : base(resourceGroup)
        {
        }

        /// <summary>
        /// Typed Resource Identifier for the container.
        /// </summary>
        public new ResourceGroupResourceIdentifier Id => base.Id as ResourceGroupResourceIdentifier;

        private VirtualMachineScaleSetsOperations Operations => new ComputeManagementClient(
            BaseUri,
            Id.SubscriptionId,
            Credential,
            ClientOptions.Convert<ComputeManagementClientOptions>()).VirtualMachineScaleSets;

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
        /// <returns> A response with the <see cref="Response{VirtualMachineScaleSet}"/> operation for this resource. </returns>
        public Response<VirtualMachineScaleSet> CreateOrUpdate(string name, VirtualMachineScaleSetData resourceDetails, CancellationToken cancellationToken = default)
        {
            var response = Operations.StartCreateOrUpdate(Id.ResourceGroupName, name, resourceDetails.Model, cancellationToken).WaitForCompletionAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            return Response.FromValue(new VirtualMachineScaleSet(Parent, new VirtualMachineScaleSetData(response.Value)), response.GetRawResponse());
        }

        /// <summary>
        /// The operation to create a virtual machine.
        /// </summary>
        /// <param name="name"> The name of the virtual machine. </param>
        /// <param name="resourceDetails"> Parameters supplied to the Create Virtual Machine operation. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A <see cref="Task"/> that on completion returns a response with the <see cref="Response{VirtualMachineScaleSet}"/> operation for this resource. </returns>
        public async Task<Response<VirtualMachineScaleSet>> CreateOrUpdateAsync(string name, VirtualMachineScaleSetData resourceDetails, CancellationToken cancellationToken = default)
        {
            var response = await Operations.StartCreateOrUpdateAsync(Id.ResourceGroupName, name, resourceDetails.Model, cancellationToken).ConfigureAwait(false).GetAwaiter().GetResult().WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new VirtualMachineScaleSet(Parent, new VirtualMachineScaleSetData(response.Value)), response.GetRawResponse());
        }

        /// <inheritdoc />
        public override Response<VirtualMachineScaleSet> Get(string virtualMachineScaleSetName, CancellationToken cancellationToken = default)
        {
            var response = Operations.Get(Id.ResourceGroupName, virtualMachineScaleSetName, cancellationToken);
            return Response.FromValue(new VirtualMachineScaleSet(Parent, new VirtualMachineScaleSetData(response.Value)), response.GetRawResponse());
        }

        /// <inheritdoc/>
        public override async Task<Response<VirtualMachineScaleSet>> GetAsync(string virtualMachineScaleSetName, CancellationToken cancellationToken = default)
        {
            var response = await Operations.GetAsync(Id.ResourceGroupName, virtualMachineScaleSetName, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new VirtualMachineScaleSet(Parent, new VirtualMachineScaleSetData(response.Value)), response.GetRawResponse());
        }

        /// <summary>
        /// List the virtual machines for this resource group.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of <see cref="VirtualMachineScaleSet"/> that may take multiple service requests to iterate over. </returns>
        public Pageable<VirtualMachineScaleSet> List(CancellationToken cancellationToken = default)
        {
            var result = Operations.List(Id.Name, cancellationToken);
            return new PhWrappingPageable<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSet, VirtualMachineScaleSet>(
                result,
                s => new VirtualMachineScaleSet(Parent, new VirtualMachineScaleSetData(s)));
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
            ResourceFilterCollection filters = new ResourceFilterCollection(VirtualMachineScaleSetOperations.ResourceType);
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
            ResourceFilterCollection filters = new ResourceFilterCollection(VirtualMachineScaleSetOperations.ResourceType);
            filters.SubstringFilter = nameFilter;
            return ResourceListOperations.ListAtContextAsync(Parent as ResourceGroupOperations, filters, top, cancellationToken);
        }

        /// <summary>
        /// List the virtual machines for this resource group.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of <see cref="VirtualMachineScaleSet"/> that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<VirtualMachineScaleSet> ListAsync(CancellationToken cancellationToken = default)
        {
            var result = Operations.ListAsync(Id.Name, cancellationToken);
            return new PhWrappingAsyncPageable<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSet, VirtualMachineScaleSet>(
                result,
                s => new VirtualMachineScaleSet(Parent, new VirtualMachineScaleSetData(s)));
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
        /// <returns> An <see cref="Operation{VirtualMachineScaleSet}"/> that allows polling for completion of the operation. </returns>
        public Operation<VirtualMachineScaleSet> StartCreateOrUpdate(string name, VirtualMachineScaleSetData resourceDetails, CancellationToken cancellationToken = default)
        {
            return new PhArmOperation<VirtualMachineScaleSet, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSet>(
                Operations.StartCreateOrUpdate(Id.ResourceGroupName, name, resourceDetails.Model, cancellationToken),
                v => new VirtualMachineScaleSet(Parent, new VirtualMachineScaleSetData(v)));
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
        /// <returns> A <see cref="Task"/> that on completion returns an <see cref="Operation{VirtualMachineScaleSet}"/> that allows polling for completion of the operation. </returns>
        public async Task<Operation<VirtualMachineScaleSet>> StartCreateOrUpdateAsync(string name, VirtualMachineScaleSetData resourceDetails, CancellationToken cancellationToken = default)
        {
            return new PhArmOperation<VirtualMachineScaleSet, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSet>(
                await Operations.StartCreateOrUpdateAsync(Id.ResourceGroupName, name, resourceDetails.Model, cancellationToken).ConfigureAwait(false),
                v => new VirtualMachineScaleSet(Parent, new VirtualMachineScaleSetData(v)));
        }

        /// <summary>
        /// Construct an object used to create a VirtualMachine.
        /// </summary>
        /// <param name="hostName"> The hostname for the virtual machine. </param>
        /// <param name="location"> The location to create the Virtual Machine. </param>
        /// <returns> Object used to create a <see cref="VirtualMachine"/>. </returns>
        public VirtualMachineScaleSetBuilder Construct(string hostName, LocationData location = null)
        {
            var parent = GetParentResource<ResourceGroup, ResourceGroupResourceIdentifier, ResourceGroupOperations>();
            var vmss = new Azure.ResourceManager.Compute.Models.VirtualMachineScaleSet(location ?? parent.Data.Location)
            {
                // TODO SKU should not be hardcoded
                Sku = new Azure.ResourceManager.Compute.Models.Sku() { Name = "Standard_DS1_v2", Capacity = 2 },
                Overprovision = false,
                VirtualMachineProfile = new Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVMProfile()
                {
                    NetworkProfile = new VirtualMachineScaleSetNetworkProfile(),
                    StorageProfile = new VirtualMachineScaleSetStorageProfile()
                    {
                        OsDisk = new VirtualMachineScaleSetOSDisk(DiskCreateOptionTypes.FromImage),
                        ImageReference = new ImageReference()
                        {
                            Offer = "WindowsServer",
                            Publisher = "MicrosoftWindowsServer",
                            Sku = "2019-Datacenter",
                            Version = "latest"
                        },
                    }
                },
                UpgradePolicy = new UpgradePolicy() {  Mode = UpgradeMode.Automatic },
            };

            var nicConfig = new VirtualMachineScaleSetNetworkConfiguration("scaleSetNic")
            {
                Primary = true,
            };
            var ipconfig = new VirtualMachineScaleSetIPConfiguration("scaleSetIPConfig")
            {
                Subnet = new ApiEntityReference() { Id = "" },
            };
            ipconfig.LoadBalancerBackendAddressPools.Add(null);
            ipconfig.LoadBalancerInboundNatPools.Add(null);
            nicConfig.IpConfigurations.Add(ipconfig);

            vmss.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations.Add(nicConfig);

            return new VirtualMachineScaleSetBuilder(this, new VirtualMachineScaleSetData(vmss));
        }
    }
}
