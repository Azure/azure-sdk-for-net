// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update;
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Rest;

    /// <summary>
    /// Members of IVirtualMachineScaleSet that are in Beta.
    /// </summary>
    public interface IVirtualMachineScaleSetBeta : IBeta
    {
        /// <summary>
        /// Re-images (updates the version of the installed operating system) the virtual machines in the scale set asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        Task ReimageAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Starts the virtual machines in the scale set asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        Task StartAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Restarts the virtual machines in the scale set asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        Task RestartAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Powers off (stops) the virtual machines in the scale set asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        Task PowerOffAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Shuts down the virtual machines in the scale set and releases its compute resources asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        Task DeallocateAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}