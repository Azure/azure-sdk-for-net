// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// A native data disk of a virtual machine.
    /// </summary>
    public interface IVirtualMachineUnmanagedDataDisk  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.DataDisk>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IChildResource<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine>
    {
        /// <summary>
        /// Gets Uri to the source virtual hard disk user image from which this disk was created.
        /// null will be returned if this disk is not based on an image.
        /// </summary>
        /// <summary>
        /// Gets the URI of the source VHD image.
        /// </summary>
        string SourceImageUri { get; }

        /// <summary>
        /// Gets the logical unit number assigned to this data disk.
        /// </summary>
        int Lun { get; }

        /// <summary>
        /// Gets URI to the virtual hard disk backing this data disk.
        /// </summary>
        string VhdUri { get; }

        /// <summary>
        /// Gets the creation method used while creating this disk.
        /// </summary>
        Models.DiskCreateOptionTypes CreationMethod { get; }

        /// <summary>
        /// Gets the disk caching type.
        /// possible values are: 'None', 'ReadOnly', 'ReadWrite'.
        /// </summary>
        /// <summary>
        /// Gets the caching type.
        /// </summary>
        Models.CachingTypes CachingType { get; }

        /// <summary>
        /// Gets the size of this data disk in GB.
        /// </summary>
        int Size { get; }
    }
}