// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    /// <summary>
    /// A managed data disk of a virtual machine.
    /// </summary>
    public interface IVirtualMachineDataDisk  :
        IHasInner<Models.DataDisk>,
        IHasName,
        IHasId
    {
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
        Models.CachingTypes? CachingType { get; }

        /// <summary>
        /// Gets the storage account type of the disk.
        /// </summary>
        Models.StorageAccountTypes? StorageAccountType { get; }

        /// <summary>
        /// Gets the creation method used while creating this disk.
        /// </summary>
        Models.DiskCreateOptionTypes CreationMethod { get; }
    }
}