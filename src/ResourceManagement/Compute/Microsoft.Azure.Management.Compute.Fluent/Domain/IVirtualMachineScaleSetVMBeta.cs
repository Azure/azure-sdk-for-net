// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// Members of IVirtualMachineScaleSetVM that are in Beta.
    /// </summary>
    public interface IVirtualMachineScaleSetVMBeta  : IBeta
    {
        /// <summary>
        /// Starts the virtual machine instance.
        /// </summary>
        /// <return>The observable to the start action.</return>
        Task StartAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Stops the virtual machine instance.
        /// </summary>
        /// <return>The observable to the poweroff action.</return>
        Task PowerOffAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates the version of the installed operating system in the virtual machine instance.
        /// </summary>
        /// <return>The observable to the reimage action.</return>
        Task ReimageAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Restarts the virtual machine instance.
        /// </summary>
        /// <return>The observable to the restart action.</return>
        Task RestartAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deletes the virtual machine instance.
        /// </summary>
        /// <return>The observable to the delete action.</return>
        Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Shuts down the virtual machine instance and releases the associated compute resources.
        /// </summary>
        /// <return>The observable to the deallocate action.</return>
        Task DeallocateAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}