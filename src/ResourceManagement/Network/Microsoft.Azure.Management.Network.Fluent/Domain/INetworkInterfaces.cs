// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using NetworkInterface.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using ResourceManager.Fluent.Core;
    using System.Collections.Generic;

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
        IHasManager<INetworkManager>,
        IHasInner<INetworkInterfacesOperations>
    {
        /// <summary>
        /// Gets a network interface associated with a virtual machine scale set instance.
        /// </summary>
        /// <param name="resourceGroupName">Virtual machine scale set resource group name</param>
        /// <param name="scaleSetName">scale set name</param>
        /// <param name="instanceId">the virtual machine scale set vm instance id</param>
        /// <param name="name">the network interface name</param>
        /// <returns>network interface</returns>
        IVirtualMachineScaleSetNetworkInterface GetByVirtualMachineScaleSetInstanceId(string resourceGroupName, string scaleSetName, string instanceId, string name);

        /// <summary>
        /// List the network interfaces associated with a virtual machine scale set.
        /// </summary>
        /// <param name="resourceGroupName">virtual machine scale set resource group name</param>
        /// <param name="scaleSetName">scale set name</param>
        /// <returns>list of network interfaces</returns>
        IEnumerable<IVirtualMachineScaleSetNetworkInterface> ListByVirtualMachineScaleSet(string resourceGroupName, string scaleSetName);

        /// <summary>
        /// List the network interfaces associated with a virtual machine scale set.
        /// </summary>
        /// <param name="id">id virtual machine scale set resource id</param>
        /// <returns>list of network interfaces</returns>
        IEnumerable<IVirtualMachineScaleSetNetworkInterface> ListByVirtualMachineScaleSetId(string id);

        /// <summary>
        /// List the network interfaces associated with a specific virtual machine instance in a scale set.
        /// </summary>
        /// <param name="resourceGroupName">virtual machine scale set resource group name</param>
        /// <param name="scaleSetName">scale set name</param>
        /// <param name="instanceId">the virtual machine scale set vm instance id</param>
        /// <returns>list of network interfaces</returns>
        IEnumerable<IVirtualMachineScaleSetNetworkInterface> ListByVirtualMachineScaleSetInstanceId(string resourceGroupName, string scaleSetName, string instanceId);
    }
}