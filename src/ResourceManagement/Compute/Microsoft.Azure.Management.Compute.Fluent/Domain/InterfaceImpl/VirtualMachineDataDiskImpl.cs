// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    internal partial class VirtualMachineDataDiskImpl 
    {
        /// <summary>
        /// Gets the name of the resource.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Gets the resource ID string.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasId.Id
        {
            get
            {
                return this.Id();
            }
        }

        /// <summary>
        /// Gets Gets the disk caching type.
        /// possible values are: 'None', 'ReadOnly', 'ReadWrite'.
        /// </summary>
        /// <summary>
        /// Gets the caching type.
        /// </summary>
        Models.CachingTypes? Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineDataDisk.CachingType
        {
            get
            {
                return this.CachingType();
            }
        }

        /// <summary>
        /// Gets the storage account type of the disk.
        /// </summary>
        Models.StorageAccountTypes? Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineDataDisk.StorageAccountType
        {
            get
            {
                return this.StorageAccountType();
            }
        }

        /// <summary>
        /// Gets the size of this data disk in GB.
        /// </summary>
        int Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineDataDisk.Size
        {
            get
            {
                return this.Size();
            }
        }

        /// <summary>
        /// Gets the creation method used while creating this disk.
        /// </summary>
        Models.DiskCreateOptionTypes Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineDataDisk.CreationMethod
        {
            get
            {
                return this.CreationMethod();
            }
        }

        /// <summary>
        /// Gets the logical unit number assigned to this data disk.
        /// </summary>
        int Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineDataDisk.Lun
        {
            get
            {
                return this.Lun();
            }
        }
    }
}