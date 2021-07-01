// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

// 

namespace Microsoft.Azure.Batch.Common
{
    /// <summary>
    /// Specifies the ephemeral disk placement for operating system disk for all compute nodes (VMs) in the pool.
    /// </summary>
    /// <remarks>
    /// This property can be used by user in the request to choose which location the operating system should be in.
    /// e.g., cache disk space for Ephemeral OS disk provisioning.
    /// For more information on Ephemeral OS disk size requirements, please refer to Ephemeral OS disk size requirements
    /// for <a href="https://docs.microsoft.com/en-us/azure/virtual-machines/windows/ephemeral-os-disks#size-requirements/">Windows VMs</a>
    /// and <a href="https://docs.microsoft.com/en-us/azure/virtual-machines/linux/ephemeral-os-disks#size-requirements/">Linux VMs</a>.
    /// </remarks>
    public enum DiffDiskPlacement
    {
        /// <summary>
        /// The Ephemeral OS Disk is stored on the VM cache.
        /// </summary>
        CacheDisk,
    }
}
