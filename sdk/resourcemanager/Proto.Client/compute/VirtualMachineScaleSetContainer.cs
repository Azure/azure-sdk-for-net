// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.ResourceManager.Compute;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Core.Resources;

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
        /// <returns> A response with the <see cref="ArmResponse{VirtualMachineScaleSet}"/> operation for this resource. </returns>
        public override ArmResponse<VirtualMachineScaleSet> CreateOrUpdate(string name, VirtualMachineScaleSetData resourceDetails, CancellationToken cancellationToken = default)
        {
            var operation = Operations.StartCreateOrUpdate(Id.ResourceGroupName, name, resourceDetails.Model, cancellationToken);
            return new PhArmResponse<VirtualMachineScaleSet, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSet>(
                operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false).GetAwaiter().GetResult(),
                v => new VirtualMachineScaleSet(Parent, new VirtualMachineScaleSetData(v)));
        }

        /// <summary>
        /// The operation to create a virtual machine.
        /// </summary>
        /// <param name="name"> The name of the virtual machine. </param>
        /// <param name="resourceDetails"> Parameters supplied to the Create Virtual Machine operation. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A <see cref="Task"/> that on completion returns a response with the <see cref="ArmResponse{VirtualMachineScaleSet}"/> operation for this resource. </returns>
        public async override Task<ArmResponse<VirtualMachineScaleSet>> CreateOrUpdateAsync(string name, VirtualMachineScaleSetData resourceDetails, CancellationToken cancellationToken = default)
        {
            var operation = await Operations.StartCreateOrUpdateAsync(Id.ResourceGroupName, name, resourceDetails.Model, cancellationToken).ConfigureAwait(false);
            return new PhArmResponse<VirtualMachineScaleSet, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSet>(
                await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false),
                v => new VirtualMachineScaleSet(Parent, new VirtualMachineScaleSetData(v)));
        }

        /// <inheritdoc />
        public override ArmResponse<VirtualMachineScaleSet> Get(string VirtualMachineScaleSetName, CancellationToken cancellationToken = default)
        {
            return new PhArmResponse<VirtualMachineScaleSet, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSet>(Operations.Get(Id.ResourceGroupName, VirtualMachineScaleSetName, cancellationToken),
                v => new VirtualMachineScaleSet(Parent, new VirtualMachineScaleSetData(v)));
        }

        /// <inheritdoc/>
        public override async Task<ArmResponse<VirtualMachineScaleSet>> GetAsync(string VirtualMachineScaleSetName, CancellationToken cancellationToken = default)
        {
            return new PhArmResponse<VirtualMachineScaleSet, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSet>(await Operations.GetAsync(Id.ResourceGroupName, VirtualMachineScaleSetName, cancellationToken),
                v => new VirtualMachineScaleSet(Parent, new VirtualMachineScaleSetData(v)));
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
        /// Makes an additional network call to retrieve the full data model for each virtual machine.
        /// </summary>
        /// <param name="nameFilter"> The substring to filter by. </param>
        /// <param name="top"> The number of items to truncate by. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of <see cref="VirtualMachineScaleSet"/> that may take multiple service requests to iterate over. </returns>
        public Pageable<VirtualMachineScaleSet> List(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            var results = ListAsGenericResource(nameFilter, top, cancellationToken);
            return new PhWrappingPageable<GenericResource, VirtualMachineScaleSet>(results, s => (new VirtualMachineScaleSetOperations(s)).Get().Value);
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
        /// Filters the list of virtual machines for this resource group represented as generic resources.
        /// Makes an additional network call to retrieve the full data model for each virtual machine.
        /// </summary>
        /// <param name="nameFilter"> The substring to filter by. </param>
        /// <param name="top"> The number of items to truncate by. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of <see cref="VirtualMachineScaleSet"/> that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<VirtualMachineScaleSet> ListAsync(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            var results = ListAsGenericResourceAsync(nameFilter, top, cancellationToken);
            return new PhWrappingAsyncPageable<GenericResource, VirtualMachineScaleSet>(results, s => (new VirtualMachineScaleSetOperations(s)).Get().Value);
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
        /// <returns> An <see cref="ArmOperation{VirtualMachineScaleSet}"/> that allows polling for completion of the operation. </returns>
        public override ArmOperation<VirtualMachineScaleSet> StartCreateOrUpdate(string name, VirtualMachineScaleSetData resourceDetails, CancellationToken cancellationToken = default)
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
        /// <returns> A <see cref="Task"/> that on completion returns an <see cref="ArmOperation{VirtualMachineScaleSet}"/> that allows polling for completion of the operation. </returns>
        public async override Task<ArmOperation<VirtualMachineScaleSet>> StartCreateOrUpdateAsync(string name, VirtualMachineScaleSetData resourceDetails, CancellationToken cancellationToken = default)
        {
            return new PhArmOperation<VirtualMachineScaleSet, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSet>(
                await Operations.StartCreateOrUpdateAsync(Id.ResourceGroupName, name, resourceDetails.Model, cancellationToken).ConfigureAwait(false),
                v => new VirtualMachineScaleSet(Parent, new VirtualMachineScaleSetData(v)));
        }
    }
}
