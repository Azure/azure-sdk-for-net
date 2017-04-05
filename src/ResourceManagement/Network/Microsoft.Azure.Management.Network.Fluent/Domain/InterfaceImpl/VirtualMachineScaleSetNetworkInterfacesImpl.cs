// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Management.Fluent.Resource.Core;
    using System.Collections.Generic;

    internal partial class VirtualMachineScaleSetNetworkInterfacesImpl 
    {
        /// <summary>
        /// Lists all the network interfaces associated with a virtual machine instance in the scale set.
        /// </summary>
        /// <param name="instanceId">Virtual machine scale set vm instance id.</param>
        /// <return>List of network interfaces.</return>
        Microsoft.Azure.Management.Fluent.Resource.Core.IPagedCollection<Microsoft.Azure.Management.Network.Fluent.IVirtualMachineScaleSetNetworkInterface> Microsoft.Azure.Management.Network.Fluent.IVirtualMachineScaleSetNetworkInterfaces.ListByVirtualMachineInstanceId(string instanceId)
        {
            return this.ListByVirtualMachineInstanceId(instanceId) as Microsoft.Azure.Management.Fluent.Resource.Core.IPagedCollection<Microsoft.Azure.Management.Network.Fluent.IVirtualMachineScaleSetNetworkInterface>;
        }

        /// <summary>
        /// Gets a network interface associated with a virtual machine scale set instance.
        /// </summary>
        /// <param name="instanceId">The virtual machine scale set vm instance id.</param>
        /// <param name="name">The network interface name.</param>
        /// <return>The network interface.</return>
        Microsoft.Azure.Management.Network.Fluent.IVirtualMachineScaleSetNetworkInterface Microsoft.Azure.Management.Network.Fluent.IVirtualMachineScaleSetNetworkInterfaces.GetByVirtualMachineInstanceId(string instanceId, string name)
        {
            return this.GetByVirtualMachineInstanceId(instanceId, name) as Microsoft.Azure.Management.Network.Fluent.IVirtualMachineScaleSetNetworkInterface;
        }

        /// <summary>
        /// Lists all the resources of the specified type in the currently selected subscription.
        /// </summary>
        /// <return>List of resources.</return>
        IEnumerable<Microsoft.Azure.Management.Network.Fluent.IVirtualMachineScaleSetNetworkInterface> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.Network.Fluent.IVirtualMachineScaleSetNetworkInterface>.List()
        {
            return this.List();
        }

        /// <summary>
        /// Lists all the resources of the specified type in the currently selected subscription.
        /// </summary>
        /// <return>List of resources.</return>
        async Task<IPagedCollection<Microsoft.Azure.Management.Network.Fluent.IVirtualMachineScaleSetNetworkInterface>> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.Network.Fluent.IVirtualMachineScaleSetNetworkInterface>.ListAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.ListAsync(loadAllPages, cancellationToken);
        }

        /// <summary>
        /// Gets the manager client of this resource type.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.INetworkManager Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Microsoft.Azure.Management.Network.Fluent.INetworkManager>.Manager
        {
            get
            {
                return this.Manager() as Microsoft.Azure.Management.Network.Fluent.INetworkManager;
            }
        }
    }
}