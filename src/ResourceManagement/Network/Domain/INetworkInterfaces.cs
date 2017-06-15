// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Entry point to network interface management.
    /// </summary>
    public interface INetworkInterfaces  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<NetworkInterface.Definition.IBlank>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.Network.Fluent.INetworkInterface>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListingByResourceGroup<Microsoft.Azure.Management.Network.Fluent.INetworkInterface>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingByResourceGroup<Microsoft.Azure.Management.Network.Fluent.INetworkInterface>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingById<Microsoft.Azure.Management.Network.Fluent.INetworkInterface>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingById,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingByResourceGroup,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsBatchCreation<Microsoft.Azure.Management.Network.Fluent.INetworkInterface>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsBatchDeletion,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Microsoft.Azure.Management.Network.Fluent.INetworkManager>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Microsoft.Azure.Management.Network.Fluent.INetworkInterfacesOperations>
    {
        /// <summary>
        /// List the network interfaces associated with a virtual machine scale set.
        /// </summary>
        /// <param name="resourceGroupName">Virtual machine scale set resource group name.</param>
        /// <param name="scaleSetName">Scale set name.</param>
        /// <return>List of network interfaces.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Network.Fluent.IVirtualMachineScaleSetNetworkInterface> ListByVirtualMachineScaleSet(string resourceGroupName, string scaleSetName);

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
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Network.Fluent.IVirtualMachineScaleSetNetworkInterface> ListByVirtualMachineScaleSetId(string id);

        /// <summary>
        /// List the network interfaces associated with a specific virtual machine instance in a scale set.
        /// </summary>
        /// <param name="resourceGroupName">Virtual machine scale set resource group name.</param>
        /// <param name="scaleSetName">Scale set name.</param>
        /// <param name="instanceId">The virtual machine scale set vm instance id.</param>
        /// <return>List of network interfaces.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Network.Fluent.IVirtualMachineScaleSetNetworkInterface> ListByVirtualMachineScaleSetInstanceId(string resourceGroupName, string scaleSetName, string instanceId);
    }
}