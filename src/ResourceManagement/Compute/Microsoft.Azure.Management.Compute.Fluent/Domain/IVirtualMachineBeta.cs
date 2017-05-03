// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update;
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Rest;

    /// <summary>
    /// Members of IVirtualMachine that are in Beta.
    /// </summary>
    public interface IVirtualMachineBeta  : IBeta
    {
        /// <summary>
        /// Starts the virtual machine asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        Task StartAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Generalizes the virtual machine asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        Task GeneralizeAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <return>Extensions attached to the virtual machine.</return>
        Task<IEnumerable<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtension>> ListExtensionsAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Refreshes the virtual machine instance view to sync with Azure.
        /// </summary>
        /// <return>An observable that emits the instance view of the virtual machine.</return>
        Task<Models.VirtualMachineInstanceView> RefreshInstanceViewAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Restarts the virtual machine asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        Task RestartAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Redeploys the virtual machine asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        Task RedeployAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Powers off (stops) the virtual machine asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        Task PowerOffAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Shuts down the virtual machine and releases the compute resources asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        Task DeallocateAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}