// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;

    /// <summary>
    /// Entry point to network interface management.
    /// </summary>
    public interface INetworkInterfaces  :
        ISupportsCreating<NetworkInterface.Definition.IBlank>,
        ISupportsListing<Microsoft.Azure.Management.Network.Fluent.INetworkInterface>,
        ISupportsListingByResourceGroup<Microsoft.Azure.Management.Network.Fluent.INetworkInterface>,
        ISupportsGettingByResourceGroup<Microsoft.Azure.Management.Network.Fluent.INetworkInterface>,
        ISupportsGettingById<Microsoft.Azure.Management.Network.Fluent.INetworkInterface>,
        ISupportsDeletingById,
        ISupportsDeletingByResourceGroup,
        ISupportsBatchCreation<Microsoft.Azure.Management.Network.Fluent.INetworkInterface>,
        ISupportsBatchDeletion,
        IHasManager<Microsoft.Azure.Management.Network.Fluent.INetworkManager>,
        IHasInner<Microsoft.Azure.Management.Network.Fluent.INetworkInterfacesOperations>
    {
        /// <summary>
        /// List the network interfaces associated with a virtual machine scale set.
        /// </summary>
        /// <param name="resourceGroupName">Virtual machine scale set resource group name.</param>
        /// <param name="scaleSetName">Scale set name.</param>
        /// <return>List of network interfaces.</return>
        Microsoft.Azure.Management.Fluent.Resource.Core.IPagedCollection<Microsoft.Azure.Management.Network.Fluent.IVirtualMachineScaleSetNetworkInterface> ListByVirtualMachineScaleSet(string resourceGroupName, string scaleSetName);

        /// <summary>
        /// Gets a network interface associated with a virtual machine scale set instance.
        /// </summary>
        /// <param name="resourceGroupName">Virtual machine scale set resource group name.</param>
        /// <param name="scaleSetName">Scale set name.</param>
        /// <param name="instanceId">The virtual machine scale set vm instance id.</param>
        /// <param name="name">The network interface name.</param>
        /// <return>Network interface.</return>
        Microsoft.Azure.Management.Network.Fluent.IVirtualMachineScaleSetNetworkInterface GetByVirtualMachineScaleSetInstanceId(string resourceGroupName, string scaleSetName, string instanceId, string name);

        /// <summary>
        /// List the network interfaces associated with a virtual machine scale set.
        /// </summary>
        /// <param name="id">Virtual machine scale set resource id.</param>
        /// <return>List of network interfaces.</return>
        Microsoft.Azure.Management.Fluent.Resource.Core.IPagedCollection<Microsoft.Azure.Management.Network.Fluent.IVirtualMachineScaleSetNetworkInterface> ListByVirtualMachineScaleSetId(string id);

        /// <summary>
        /// List the network interfaces associated with a specific virtual machine instance in a scale set.
        /// </summary>
        /// <param name="resourceGroupName">Virtual machine scale set resource group name.</param>
        /// <param name="scaleSetName">Scale set name.</param>
        /// <param name="instanceId">The virtual machine scale set vm instance id.</param>
        /// <return>List of network interfaces.</return>
        Microsoft.Azure.Management.Fluent.Resource.Core.IPagedCollection<Microsoft.Azure.Management.Network.Fluent.IVirtualMachineScaleSetNetworkInterface> ListByVirtualMachineScaleSetInstanceId(string resourceGroupName, string scaleSetName, string instanceId);
    }
}