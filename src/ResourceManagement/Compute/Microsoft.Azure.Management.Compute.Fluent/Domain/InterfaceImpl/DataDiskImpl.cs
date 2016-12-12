// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using VirtualMachineDataDisk.UpdateDefinition;
    using VirtualMachine.Update;
    using System.Collections.Generic;
    using VirtualMachineDataDisk.Definition;
    using Microsoft.Azure.Management.Storage.Fluent;
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition;
    using VirtualMachineDataDisk.Update;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using VirtualMachine.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update;

    internal partial class DataDiskImpl
    {
        /// <summary>
        /// Specifies an existing VHD that needs to be attached to the virtual machine as data disk.
        /// </summary>
        /// <param name="storageAccountName">The storage account name.</param>
        /// <param name="containerName">The name of the container holding the VHD file.</param>
        /// <param name="vhdName">The name for the VHD file.</param>
        /// <return>The stage representing optional additional settings for the attachable data disk.</return>
        VirtualMachineDataDisk.UpdateDefinition.IWithAttach<VirtualMachine.Update.IUpdate> VirtualMachineDataDisk.UpdateDefinition.IAttachExistingDataDisk<VirtualMachine.Update.IUpdate>.From(string storageAccountName, string containerName, string vhdName)
        {
            return this.From(storageAccountName, containerName, vhdName) as VirtualMachineDataDisk.UpdateDefinition.IWithAttach<VirtualMachine.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies an existing VHD that needs to be attached to the virtual machine as data disk.
        /// </summary>
        /// <param name="storageAccountName">The storage account name.</param>
        /// <param name="containerName">The name of the container holding the VHD file.</param>
        /// <param name="vhdName">The name for the VHD file.</param>
        /// <return>The stage representing optional additional settings for the attachable data disk.</return>
        VirtualMachineDataDisk.Definition.IWithAttach<VirtualMachine.Definition.IWithCreate> VirtualMachineDataDisk.Definition.IAttachExistingDataDisk<VirtualMachine.Definition.IWithCreate>.From(string storageAccountName, string containerName, string vhdName)
        {
            return this.From(storageAccountName, containerName, vhdName) as VirtualMachineDataDisk.Definition.IWithAttach<VirtualMachine.Definition.IWithCreate>;
        }

        /// <return>The name of the resource.</return>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name() as string;
            }
        }

        /// <return>Uri to the virtual hard disk backing this data disk.</return>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineDataDisk.VhdUri
        {
            get
            {
                return this.VhdUri() as string;
            }
        }

        /// <return>The logical unit number assigned to this data disk.</return>
        int Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineDataDisk.Lun
        {
            get
            {
                return this.Lun();
            }
        }

        /// <return>The creation method used while creating this disk.</return>
        Models.DiskCreateOptionTypes Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineDataDisk.CreationMethod
        {
            get
            {
                return this.CreationMethod();
            }
        }

        /// <summary>
        /// Gets the disk caching type.
        /// <p>
        /// possible values are: 'None', 'ReadOnly', 'ReadWrite'.
        /// </summary>
        /// <return>The caching type.</return>
        Models.CachingTypes Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineDataDisk.CachingType
        {
            get
            {
                return this.CachingType();
            }
        }

        /// <return>The size of this data disk in GB.</return>
        int Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineDataDisk.Size
        {
            get
            {
                return this.Size();
            }
        }

        /// <summary>
        /// Uri to the source virtual hard disk user image from which this disk was created.
        /// <p>
        /// null will be returned if this disk is not based on an image.
        /// </summary>
        /// <return>The uri of the source vhd image.</return>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineDataDisk.SourceImageUri
        {
            get
            {
                return this.SourceImageUri() as string;
            }
        }

        /// <summary>
        /// Specifies the new caching type for the data disk.
        /// </summary>
        /// <param name="cachingType">The disk caching type. Possible values include: 'None', 'ReadOnly', 'ReadWrite'.</param>
        /// <return>The next stage of data disk update.</return>
        VirtualMachineDataDisk.Update.IUpdate VirtualMachineDataDisk.Update.IWithDiskCaching.WithCaching(CachingTypes cachingType)
        {
            return this.WithCaching(cachingType) as VirtualMachineDataDisk.Update.IUpdate;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource update.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        VirtualMachine.Definition.IWithCreate Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update.IInUpdate<VirtualMachine.Definition.IWithCreate>.Attach()
        {
            return this.Attach() as VirtualMachine.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the initial disk size in GB for new blank data disk.
        /// </summary>
        /// <param name="sizeInGB">The disk size in GB.</param>
        /// <return>The stage representing optional additional settings for the attachable data disk.</return>
        VirtualMachineDataDisk.UpdateDefinition.IWithStoreAt<VirtualMachine.Update.IUpdate> VirtualMachineDataDisk.UpdateDefinition.IAttachNewDataDisk<VirtualMachine.Update.IUpdate>.WithSizeInGB(int sizeInGB)
        {
            return this.WithSizeInGB(sizeInGB) as VirtualMachineDataDisk.UpdateDefinition.IWithStoreAt<VirtualMachine.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the initial disk size in GB for new blank data disk.
        /// </summary>
        /// <param name="sizeInGB">The disk size in GB.</param>
        /// <return>The stage representing optional additional settings for the attachable data disk.</return>
        VirtualMachineDataDisk.Definition.IWithStoreAt<VirtualMachine.Definition.IWithCreate> VirtualMachineDataDisk.Definition.IAttachNewDataDisk<VirtualMachine.Definition.IWithCreate>.WithSizeInGB(int sizeInGB)
        {
            return this.WithSizeInGB(sizeInGB) as VirtualMachineDataDisk.Definition.IWithStoreAt<VirtualMachine.Definition.IWithCreate>;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        VirtualMachine.Update.IUpdate Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition.IInDefinition<VirtualMachine.Update.IUpdate>.Attach()
        {
            return this.Attach() as VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the new size in GB for data disk.
        /// </summary>
        /// <param name="sizeInGB">The disk size in GB.</param>
        /// <return>The next stage of data disk update.</return>
        VirtualMachineDataDisk.Update.IUpdate VirtualMachineDataDisk.Update.IWithDiskSize.WithSizeInGB(int sizeInGB)
        {
            return this.WithSizeInGB(sizeInGB) as VirtualMachineDataDisk.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the new logical unit number for the data disk.
        /// </summary>
        /// <param name="lun">The logical unit number.</param>
        /// <return>The next stage of data disk update.</return>
        VirtualMachineDataDisk.Update.IUpdate VirtualMachineDataDisk.Update.IWithDiskLun.WithLun(int lun)
        {
            return this.WithLun(lun) as VirtualMachineDataDisk.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the logical unit number for the data disk.
        /// </summary>
        /// <param name="lun">The logical unit number.</param>
        /// <return>The next stage of data disk definition.</return>
        VirtualMachineDataDisk.UpdateDefinition.IWithAttach<VirtualMachine.Update.IUpdate> VirtualMachineDataDisk.UpdateDefinition.IWithAttach<VirtualMachine.Update.IUpdate>.WithLun(int lun)
        {
            return this.WithLun(lun) as VirtualMachineDataDisk.UpdateDefinition.IWithAttach<VirtualMachine.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the caching type for the data disk.
        /// </summary>
        /// <param name="cachingType">The disk caching type. Possible values include: 'None', 'ReadOnly', 'ReadWrite'.</param>
        /// <return>The next stage of data disk definition.</return>
        VirtualMachineDataDisk.UpdateDefinition.IWithAttach<VirtualMachine.Update.IUpdate> VirtualMachineDataDisk.UpdateDefinition.IWithAttach<VirtualMachine.Update.IUpdate>.WithCaching(CachingTypes cachingType)
        {
            return this.WithCaching(cachingType) as VirtualMachineDataDisk.UpdateDefinition.IWithAttach<VirtualMachine.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the logical unit number for the data disk.
        /// </summary>
        /// <param name="lun">The logical unit number.</param>
        /// <return>The next stage of data disk definition.</return>
        VirtualMachineDataDisk.Definition.IWithAttach<VirtualMachine.Definition.IWithCreate> VirtualMachineDataDisk.Definition.IWithAttach<VirtualMachine.Definition.IWithCreate>.WithLun(int lun)
        {
            return this.WithLun(lun) as VirtualMachineDataDisk.Definition.IWithAttach<VirtualMachine.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the caching type for the data disk.
        /// </summary>
        /// <param name="cachingType">The disk caching type. Possible values include: 'None', 'ReadOnly', 'ReadWrite'.</param>
        /// <return>The next stage of data disk definition.</return>
        VirtualMachineDataDisk.Definition.IWithAttach<VirtualMachine.Definition.IWithCreate> VirtualMachineDataDisk.Definition.IWithAttach<VirtualMachine.Definition.IWithCreate>.WithCaching(CachingTypes cachingType)
        {
            return this.WithCaching(cachingType) as VirtualMachineDataDisk.Definition.IWithAttach<VirtualMachine.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies where the VHD associated with the new blank data disk needs to be stored.
        /// </summary>
        /// <param name="storageAccountName">The storage account name.</param>
        /// <param name="containerName">The name of the container to hold the new VHD file.</param>
        /// <param name="vhdName">The name for the new VHD file.</param>
        /// <return>The stage representing optional additional configurations for the data disk.</return>
        VirtualMachineDataDisk.UpdateDefinition.IWithAttach<VirtualMachine.Update.IUpdate> VirtualMachineDataDisk.UpdateDefinition.IWithStoreAt<VirtualMachine.Update.IUpdate>.StoreAt(string storageAccountName, string containerName, string vhdName)
        {
            return this.StoreAt(storageAccountName, containerName, vhdName) as VirtualMachineDataDisk.UpdateDefinition.IWithAttach<VirtualMachine.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies where the VHD associated with the new blank data disk needs to be stored.
        /// </summary>
        /// <param name="storageAccountName">The storage account name.</param>
        /// <param name="containerName">The name of the container to hold the new VHD file.</param>
        /// <param name="vhdName">The name for the new VHD file.</param>
        /// <return>The stage representing optional additional configurations for the data disk.</return>
        VirtualMachineDataDisk.Definition.IWithAttach<VirtualMachine.Definition.IWithCreate> VirtualMachineDataDisk.Definition.IWithStoreAt<VirtualMachine.Definition.IWithCreate>.StoreAt(string storageAccountName, string containerName, string vhdName)
        {
            return this.StoreAt(storageAccountName, containerName, vhdName) as VirtualMachineDataDisk.Definition.IWithAttach<VirtualMachine.Definition.IWithCreate>;
        }
    }
}