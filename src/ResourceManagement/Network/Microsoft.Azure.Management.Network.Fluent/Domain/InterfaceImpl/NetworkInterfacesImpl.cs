// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;

    internal partial class NetworkInterfacesImpl 
    {
        /// <summary>
        /// Begins a definition for a new resource.
        /// This is the beginning of the builder pattern used to create top level resources
        /// in Azure. The final method completing the definition and starting the actual resource creation
        /// process in Azure is  Creatable.create().
        /// Note that the  Creatable.create() method is
        /// only available at the stage of the resource definition that has the minimum set of input
        /// parameters specified. If you do not see  Creatable.create() among the available methods, it
        /// means you have not yet specified all the required input settings. Input settings generally begin
        /// with the word "with", for example: <code>.withNewResourceGroup()</code> and return the next stage
        /// of the resource definition, as an interface in the "fluent interface" style.
        /// </summary>
        /// <param name="name">The name of the new resource.</param>
        /// <return>The first stage of the new resource definition.</return>
        NetworkInterface.Definition.IBlank Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<NetworkInterface.Definition.IBlank>.Define(string name)
        {
            return this.Define(name) as NetworkInterface.Definition.IBlank;
        }

        /// <summary>
        /// List the network interfaces associated with a virtual machine scale set.
        /// </summary>
        /// <param name="id">Virtual machine scale set resource id.</param>
        /// <return>List of network interfaces.</return>
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<Microsoft.Azure.Management.Network.Fluent.IVirtualMachineScaleSetNetworkInterface> Microsoft.Azure.Management.Network.Fluent.INetworkInterfaces.ListByVirtualMachineScaleSetId(string id)
        {
            return this.ListByVirtualMachineScaleSetId(id) as Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<Microsoft.Azure.Management.Network.Fluent.IVirtualMachineScaleSetNetworkInterface>;
        }

        /// <summary>
        /// Gets a network interface associated with a virtual machine scale set instance.
        /// </summary>
        /// <param name="resourceGroupName">Virtual machine scale set resource group name.</param>
        /// <param name="scaleSetName">Scale set name.</param>
        /// <param name="instanceId">The virtual machine scale set vm instance id.</param>
        /// <param name="name">The network interface name.</param>
        /// <return>Network interface.</return>
        Microsoft.Azure.Management.Network.Fluent.IVirtualMachineScaleSetNetworkInterface Microsoft.Azure.Management.Network.Fluent.INetworkInterfaces.GetByVirtualMachineScaleSetInstanceId(string resourceGroupName, string scaleSetName, string instanceId, string name)
        {
            return this.GetByVirtualMachineScaleSetInstanceId(resourceGroupName, scaleSetName, instanceId, name) as Microsoft.Azure.Management.Network.Fluent.IVirtualMachineScaleSetNetworkInterface;
        }

        /// <summary>
        /// List the network interfaces associated with a specific virtual machine instance in a scale set.
        /// </summary>
        /// <param name="resourceGroupName">Virtual machine scale set resource group name.</param>
        /// <param name="scaleSetName">Scale set name.</param>
        /// <param name="instanceId">The virtual machine scale set vm instance id.</param>
        /// <return>List of network interfaces.</return>
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<Microsoft.Azure.Management.Network.Fluent.IVirtualMachineScaleSetNetworkInterface> Microsoft.Azure.Management.Network.Fluent.INetworkInterfaces.ListByVirtualMachineScaleSetInstanceId(string resourceGroupName, string scaleSetName, string instanceId)
        {
            return this.ListByVirtualMachineScaleSetInstanceId(resourceGroupName, scaleSetName, instanceId) as Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<Microsoft.Azure.Management.Network.Fluent.IVirtualMachineScaleSetNetworkInterface>;
        }

        /// <summary>
        /// List the network interfaces associated with a virtual machine scale set.
        /// </summary>
        /// <param name="resourceGroupName">Virtual machine scale set resource group name.</param>
        /// <param name="scaleSetName">Scale set name.</param>
        /// <return>List of network interfaces.</return>
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<Microsoft.Azure.Management.Network.Fluent.IVirtualMachineScaleSetNetworkInterface> Microsoft.Azure.Management.Network.Fluent.INetworkInterfaces.ListByVirtualMachineScaleSet(string resourceGroupName, string scaleSetName)
        {
            return this.ListByVirtualMachineScaleSet(resourceGroupName, scaleSetName) as Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<Microsoft.Azure.Management.Network.Fluent.IVirtualMachineScaleSetNetworkInterface>;
        }
    }
}