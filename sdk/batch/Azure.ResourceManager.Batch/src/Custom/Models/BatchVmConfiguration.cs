// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Batch.Models
{
    /// <summary> The configuration for compute nodes in a pool based on the Azure Virtual Machines infrastructure. </summary>
    public partial class BatchVmConfiguration
    {
        /// <summary> This property can be used by user in the request to choose which location the operating system should be in. e.g., cache disk space for Ephemeral OS disk provisioning. For more information on Ephemeral OS disk size requirements, please refer to Ephemeral OS disk size requirements for Windows VMs at https://docs.microsoft.com/en-us/azure/virtual-machines/windows/ephemeral-os-disks#size-requirements and Linux VMs at https://docs.microsoft.com/en-us/azure/virtual-machines/linux/ephemeral-os-disks#size-requirements. </summary>
        public BatchDiffDiskPlacement? EphemeralOSDiskPlacement { get; [EditorBrowsable(EditorBrowsableState.Never)] set; }
    }
}