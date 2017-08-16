// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Rest;

    /// <summary>
    /// Entry point to virtual machine scale set management API.
    /// </summary>
    public interface IVirtualMachineScaleSetsBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Re-images (updates the version of the installed operating system) the virtual machines in the scale set asynchronously.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine scale set is in.</param>
        /// <param name="name">The name of the virtual machine scale set.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        Task ReimageAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Restarts the virtual machines in the scale set asynchronously.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine scale set is in.</param>
        /// <param name="name">The virtual machine scale set name.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        Task RestartAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Shuts down the virtual machines in the scale set and releases the compute resources asynchronously.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine scale set is in.</param>
        /// <param name="name">The name of the virtual machine scale set.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        Task DeallocateAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Powers off (stops) the virtual machines in the scale set asynchronously.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine in the scale set is in.</param>
        /// <param name="name">The name of the virtual machine scale set.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        Task PowerOffAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Starts the virtual machines in the scale set asynchronously.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine scale set is in.</param>
        /// <param name="name">The name of the virtual machine scale set.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        Task StartAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken));
    }
}