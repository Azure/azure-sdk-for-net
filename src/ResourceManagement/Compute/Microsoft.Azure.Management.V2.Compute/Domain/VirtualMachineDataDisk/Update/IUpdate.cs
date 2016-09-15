/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Compute.VirtualMachineDataDisk.Update
{

    using Microsoft.Azure.Management.V2.Resource.Core.ChildResourceActions;
    using Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update;
    using Microsoft.Azure.Management.Compute.Models;
    /// <summary>
    /// The entirety of a data disk update as part of a virtual machine update.
    /// </summary>
    public interface IUpdate  :
        IUpdateStages,
        ISettable<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate>
    {
    }
    /// <summary>
    /// Grouping of data disk update stages.
    /// </summary>
    public interface IUpdateStages 
    {
        /// <summary>
        /// Specifies the new size in GB for data disk.
        /// </summary>
        /// <param name="sizeInGB">sizeInGB the disk size in GB</param>
        /// <returns>the next stage of data disk update</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineDataDisk.Update.IUpdate WithSizeInGB (int? sizeInGB);

        /// <summary>
        /// Specifies the new logical unit number for the data disk.
        /// </summary>
        /// <param name="lun">lun the logical unit number</param>
        /// <returns>the next stage of data disk update</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineDataDisk.Update.IUpdate WithLun (int? lun);

        /// <summary>
        /// Specifies the new caching type for the data disk.
        /// </summary>
        /// <param name="cachingType">cachingType the disk caching type. Possible values include: 'None', 'ReadOnly', 'ReadWrite'</param>
        /// <returns>the next stage of data disk update</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineDataDisk.Update.IUpdate WithCaching (CachingTypes cachingType);

    }
}