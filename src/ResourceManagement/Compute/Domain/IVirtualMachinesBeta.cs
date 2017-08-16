// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Rest;

    /// <summary>
    /// Entry point to virtual machine management API.
    /// </summary>
    public interface IVirtualMachinesBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Redeploys the virtual machine asynchronously.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine is in.</param>
        /// <param name="name">The virtual machine name.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        Task RedeployAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Restarts the virtual machine asynchronously.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine is in.</param>
        /// <param name="name">The virtual machine name.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        Task RestartAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Captures the virtual machine by copying virtual hard disks of the VM asynchronously.
        /// </summary>
        /// <param name="groupName">The resource group name.</param>
        /// <param name="name">The virtual machine name.</param>
        /// <param name="containerName">Destination container name to store the captured VHD.</param>
        /// <param name="vhdPrefix">The prefix for the VHD holding captured image.</param>
        /// <param name="overwriteVhd">Whether to overwrites destination VHD if it exists.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        Task<string> CaptureAsync(string groupName, string name, string containerName, string vhdPrefix, bool overwriteVhd, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Starts the virtual machine asynchronously.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine is in.</param>
        /// <param name="name">The virtual machine name.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        Task StartAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Converts (migrates) the virtual machine with un-managed disks to use managed disk asynchronously.
        /// </summary>
        /// <param name="groupName">The resource group name.</param>
        /// <param name="name">The virtual machine name.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        Task MigrateToManagedAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Generalizes the virtual machine asynchronously.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine is in.</param>
        /// <param name="name">The virtual machine name.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        Task GeneralizeAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Shuts down the virtual machine and releases the compute resources asynchronously.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine is in.</param>
        /// <param name="name">The virtual machine name.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        Task DeallocateAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Powers off (stops) the virtual machine asynchronously.
        /// </summary>
        /// <param name="groupName">The name of the resource group the virtual machine is in.</param>
        /// <param name="name">The virtual machine name.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        Task PowerOffAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken));

    }
}