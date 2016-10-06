// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent.VirtualMachineDataDisk.Update
{

    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResourceActions;
    /// <summary>
    /// The stage of the virtual machine data disk update allowing to set the disk size.
    /// </summary>
    public interface IWithDiskSize 
    {
        /// <summary>
        /// Specifies the new size in GB for data disk.
        /// </summary>
        /// <param name="sizeInGB">sizeInGB the disk size in GB</param>
        /// <returns>the next stage of data disk update</returns>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineDataDisk.Update.IUpdate WithSizeInGB(int sizeInGB);

    }
    /// <summary>
    /// The stage of the virtual machine data disk update allowing to set the disk lun.
    /// </summary>
    public interface IWithDiskLun 
    {
        /// <summary>
        /// Specifies the new logical unit number for the data disk.
        /// </summary>
        /// <param name="lun">lun the logical unit number</param>
        /// <returns>the next stage of data disk update</returns>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineDataDisk.Update.IUpdate WithLun(int lun);

    }
    /// <summary>
    /// The stage of the virtual machine data disk update allowing to set the disk caching type.
    /// </summary>
    public interface IWithDiskCaching 
    {
        /// <summary>
        /// Specifies the new caching type for the data disk.
        /// </summary>
        /// <param name="cachingType">cachingType the disk caching type. Possible values include: 'None', 'ReadOnly', 'ReadWrite'</param>
        /// <returns>the next stage of data disk update</returns>
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineDataDisk.Update.IUpdate WithCaching(CachingTypes cachingType);

    }
    /// <summary>
    /// The entirety of a data disk update as part of a virtual machine update.
    /// </summary>
    public interface IUpdate  :
        IWithDiskSize,
        IWithDiskLun,
        IWithDiskCaching,
        ISettable<Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update.IUpdate>
    {
    }
}