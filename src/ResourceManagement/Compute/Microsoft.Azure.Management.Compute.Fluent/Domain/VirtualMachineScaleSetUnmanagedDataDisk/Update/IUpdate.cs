// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetUnmanagedDataDisk.Update
{
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions;
    using Microsoft.Azure.Management.Compute.Fluent.Models;

    /// <summary>
    /// The entirety of a unmanaged data disk update as part of a virtual machine scale set update.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetUnmanagedDataDisk.Update.IWithDiskSize,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetUnmanagedDataDisk.Update.IWithDiskLun,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetUnmanagedDataDisk.Update.IWithDiskCaching,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.ISettable<Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Update.IUpdate>
    {
    }

    /// <summary>
    /// The stage of the unmanaged data disk update allowing to set the disk LUN.
    /// </summary>
    public interface IWithDiskLun 
    {
        /// <summary>
        /// Specifies the new logical unit number for the unmanaged data disk.
        /// </summary>
        /// <param name="lun">The logical unit number.</param>
        /// <return>The next stage of unmanaged data disk update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetUnmanagedDataDisk.Update.IUpdate WithLun(int lun);
    }

    /// <summary>
    /// The stage of the unmanaged data disk update allowing to set the disk caching type.
    /// </summary>
    public interface IWithDiskCaching 
    {
        /// <summary>
        /// Specifies the new caching type for the unmanaged data disk.
        /// </summary>
        /// <param name="cachingType">The disk caching type. Possible values include: 'None', 'ReadOnly', 'ReadWrite'.</param>
        /// <return>The next stage of unmanaged data disk update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetUnmanagedDataDisk.Update.IUpdate WithCaching(CachingTypes cachingType);
    }

    /// <summary>
    /// The stage of the unmanaged data disk update allowing to set the disk size.
    /// </summary>
    public interface IWithDiskSize 
    {
        /// <summary>
        /// Specifies the new size in GB for data disk.
        /// </summary>
        /// <param name="sizeInGB">The disk size in GB.</param>
        /// <return>The next stage of unmanaged data disk update.</return>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetUnmanagedDataDisk.Update.IUpdate WithSizeInGB(int sizeInGB);
    }
}