// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using System.Threading.Tasks;
    using System.Threading;
    using ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// Type that can be used to monitor encryption enable and disable status of a virtual machine.
    /// User get access to implementation of this interface from following methods:
    /// 1. VirtualMachineEncryption.[Enable|Disable]{1}[Async]{0-1}
    /// 2. VirtualMachineEncryption.GetMonitor[Async]{0-1}
    /// It is possible that user first get monitor instance via 2 then starts encrypting the virtual
    /// machine, in this case he can still use the same monitor instance to monitor the encryption
    /// progress.
    /// </summary>
    public interface IDiskVolumeEncryptionMonitor  :
        IRefreshable<Microsoft.Azure.Management.Compute.Fluent.IDiskVolumeEncryptionMonitor>
    {
        /// <summary>
        /// Gets operating system type of the virtual machine.
        /// </summary>
        Models.OperatingSystemTypes OsType { get; }

        /// <summary>
        /// Gets operating system disk encryption status.
        /// </summary>
        EncryptionStatus OsDiskStatus { get; }

        /// <summary>
        /// Gets observable that emits encryption status once the refresh is done.
        /// </summary>
        Task<Microsoft.Azure.Management.Compute.Fluent.IDiskVolumeEncryptionMonitor> RefreshAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Gets data disks encryption status.
        /// </summary>
        EncryptionStatus DataDiskStatus { get; }

        /// <summary>
        /// Gets the encryption progress message.
        /// </summary>
        string ProgressMessage { get; }
    }
}