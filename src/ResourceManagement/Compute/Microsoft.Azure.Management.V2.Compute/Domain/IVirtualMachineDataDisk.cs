/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Compute
{

    using Microsoft.Azure.Management.Compute.Models;
    using Microsoft.Azure.Management.V2.Resource.Core;
    /// <summary>
    /// A data disk of a virtual machine.
    /// </summary>
    public interface IVirtualMachineDataDisk  :
        IWrapper<DataDisk>,
        IChildResource
    {
        /// <returns>the size of this data disk in GB</returns>
        int? Size { get; }

        /// <returns>the logical unit number assigned to this data disk</returns>
        int? Lun { get; }

        /// <returns>uri to the virtual hard disk backing this data disk</returns>
        string VhdUri { get; }

        /// <summary>
        /// Gets the disk caching type.
        /// <p>
        /// possible values are: 'None', 'ReadOnly', 'ReadWrite'
        /// </summary>
        /// <returns>the caching type</returns>
        CachingTypes? CachingType { get; }

        /// <summary>
        /// Uri to the source virtual hard disk user image from which this disk was created.
        /// <p>
        /// null will be returned if this disk is not based on an image
        /// </summary>
        /// <returns>the uri of the source vhd image</returns>
        string SourceImageUri { get; }

        /// <summary>
        /// Gets the create option used while creating this disk.
        /// <p>
        /// Possible values include: 'fromImage', 'empty', 'attach'
        /// 'fromImage' - if data disk was created from a user image
        /// 'attach' - if an existing vhd was usd to back the data disk
        /// 'empty' - if the disk was created as an empty disk
        /// when disk is created using 'fromImage' option, a copy of user image vhd will be created first
        /// and it will be used as the vhd to back the data disk.
        /// </summary>
        /// <returns>disk create option</returns>
        DiskCreateOptionTypes? CreateOption { get; }

    }
}