// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// Type that can be used to monitor encryption enable and disable status of a virtual machine.
    /// </summary>
    public interface IDiskVolumeEncryptionMonitor  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Compute.Fluent.IDiskVolumeEncryptionMonitor>
    {
        /// <summary>
        /// Gets operating system type of the virtual machine.
        /// </summary>
        Models.OperatingSystemTypes OSType { get; }

        /// <summary>
        /// Gets operating system disk encryption status.
        /// </summary>
        Microsoft.Azure.Management.Compute.Fluent.EncryptionStatus OSDiskStatus { get; }

        /// <return>A representation of the deferred computation of this call returning the encryption status once the refresh is done.</return>
        Task<Microsoft.Azure.Management.Compute.Fluent.IDiskVolumeEncryptionMonitor> RefreshAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets data disks encryption status.
        /// </summary>
        Microsoft.Azure.Management.Compute.Fluent.EncryptionStatus DataDiskStatus { get; }

        /// <summary>
        /// Gets the encryption progress message.
        /// </summary>
        string ProgressMessage { get; }
    }
}