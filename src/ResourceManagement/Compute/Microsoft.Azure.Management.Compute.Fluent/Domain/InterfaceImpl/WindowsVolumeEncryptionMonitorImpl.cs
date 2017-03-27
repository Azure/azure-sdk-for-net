// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;

    internal partial class WindowsVolumeEncryptionMonitorImpl 
    {
        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        /// <return>The refreshed resource.</return>
        Microsoft.Azure.Management.Compute.Fluent.IDiskVolumeEncryptionMonitor ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Compute.Fluent.IDiskVolumeEncryptionMonitor>.Refresh()
        {
            return this.Refresh() as Microsoft.Azure.Management.Compute.Fluent.IDiskVolumeEncryptionMonitor;
        }

        /// <summary>
        /// Gets operating system type of the virtual machine.
        /// </summary>
        Models.OperatingSystemTypes Microsoft.Azure.Management.Compute.Fluent.IDiskVolumeEncryptionMonitor.OsType
        {
            get
            {
                return this.OsType();
            }
        }

        /// <summary>
        /// Gets operating system disk encryption status.
        /// </summary>
        EncryptionStatus Microsoft.Azure.Management.Compute.Fluent.IDiskVolumeEncryptionMonitor.OsDiskStatus
        {
            get
            {
                return this.OsDiskStatus() as EncryptionStatus;
            }
        }

        /// <summary>
        /// Gets the encryption progress message.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IDiskVolumeEncryptionMonitor.ProgressMessage
        {
            get
            {
                return this.ProgressMessage();
            }
        }

        /// <summary>
        /// Gets data disks encryption status.
        /// </summary>
        EncryptionStatus Microsoft.Azure.Management.Compute.Fluent.IDiskVolumeEncryptionMonitor.DataDiskStatus
        {
            get
            {
                return this.DataDiskStatus() as EncryptionStatus;
            }
        }

        /// <summary>
        /// Gets observable that emits encryption status once the refresh is done.
        /// </summary>
        Task<Microsoft.Azure.Management.Compute.Fluent.IDiskVolumeEncryptionMonitor> Microsoft.Azure.Management.Compute.Fluent.IDiskVolumeEncryptionMonitor.RefreshAsync(CancellationToken cancellationToken)
        {
            return this.RefreshAsync(cancellationToken);
        }
    }
}