// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Models;
    using System.Collections.Generic;

    /// <summary>
    /// Entry point to virtual machine scale set network interface management API.
    /// </summary>
    public interface IVirtualMachineScaleSetNetworkInterfaces  :
        ISupportsListing<IVirtualMachineScaleSetNetworkInterface>,
        IHasInner<INetworkInterfacesOperations>,
        IHasManager<INetworkManager>
    {
        /// <summary>
        /// Gets a network interface associated with a virtual machine scale set instance.
        /// </summary>
        /// <param name="instanceId">The virtual machine scale set vm instance id.</param>
        /// <param name="name">The network interface name.</param>
        /// <return>The network interface.</return>
        Microsoft.Azure.Management.Network.Fluent.IVirtualMachineScaleSetNetworkInterface GetByVirtualMachineInstanceId(string instanceId, string name);

        /// <summary>
        /// Lists all the network interfaces associated with a virtual machine instance in the scale set.
        /// </summary>
        /// <param name="instanceId">Virtual machine scale set vm instance id.</param>
        /// <return>List of network interfaces.</return>
        IEnumerable<Microsoft.Azure.Management.Network.Fluent.IVirtualMachineScaleSetNetworkInterface> ListByVirtualMachineInstanceId(string instanceId);
    }
}