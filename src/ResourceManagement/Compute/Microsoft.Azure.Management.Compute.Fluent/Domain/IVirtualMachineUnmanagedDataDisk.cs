// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// A native data disk of a virtual machine.
    /// </summary>
    public interface IVirtualMachineUnmanagedDataDisk  :
        IHasInner<Models.DataDisk>,
        IChildResource<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine>
    {
        /// <summary>
        /// Gets Uri to the source virtual hard disk user image from which this disk was created.
        /// null will be returned if this disk is not based on an image.
        /// </summary>
        /// <summary>
        /// Gets the uri of the source vhd image.
        /// </summary>
        string SourceImageUri { get; }

        /// <summary>
        /// Gets the size of this data disk in GB.
        /// </summary>
        int Size { get; }

        /// <summary>
        /// Gets the logical unit number assigned to this data disk.
        /// </summary>
        int Lun { get; }

        /// <summary>
        /// Gets Gets the disk caching type.
        /// possible values are: 'None', 'ReadOnly', 'ReadWrite'.
        /// </summary>
        /// <summary>
        /// Gets the caching type.
        /// </summary>
        Models.CachingTypes CachingType { get; }

        /// <summary>
        /// Gets uri to the virtual hard disk backing this data disk.
        /// </summary>
        string VhdUri { get; }

        /// <summary>
        /// Gets the creation method used while creating this disk.
        /// </summary>
        Models.DiskCreateOptionTypes CreationMethod { get; }
    }
}