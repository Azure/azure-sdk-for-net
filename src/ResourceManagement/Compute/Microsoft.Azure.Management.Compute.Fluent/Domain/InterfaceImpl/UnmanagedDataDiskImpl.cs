// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Models;
    using VirtualMachine.Definition;
    using VirtualMachine.Update;
    using VirtualMachineUnmanagedDataDisk.Definition;
    using VirtualMachineUnmanagedDataDisk.DefinitionWithExistingVhd;
    using VirtualMachineUnmanagedDataDisk.DefinitionWithImage;
    using VirtualMachineUnmanagedDataDisk.DefinitionWithNewVhd;
    using VirtualMachineUnmanagedDataDisk.Update;
    using VirtualMachineUnmanagedDataDisk.UpdateDefinition;
    using VirtualMachineUnmanagedDataDisk.UpdateDefinitionWithExistingVhd;
    using VirtualMachineUnmanagedDataDisk.UpdateDefinitionWithNewVhd;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update;
    using Microsoft.Azure.Management.Storage.Fluent;
    using System.Collections.Generic;

    internal partial class UnmanagedDataDiskImpl 
    {
        /// <summary>
        /// Specifies the size in GB the disk needs to be resized.
        /// </summary>
        /// <param name="sizeInGB">The disk size in GB.</param>
        /// <return>The next stage of data disk definition.</return>
        VirtualMachineUnmanagedDataDisk.Definition.IWithVhdAttachedDiskSettings<VirtualMachine.Definition.IWithUnmanagedCreate> VirtualMachineUnmanagedDataDisk.Definition.IWithVhdAttachedDiskSettings<VirtualMachine.Definition.IWithUnmanagedCreate>.WithSizeInGB(int sizeInGB)
        {
            return this.WithSizeInGB(sizeInGB) as VirtualMachineUnmanagedDataDisk.Definition.IWithVhdAttachedDiskSettings<VirtualMachine.Definition.IWithUnmanagedCreate>;
        }

        /// <summary>
        /// Specifies the logical unit number for the data disk.
        /// </summary>
        /// <param name="lun">The logical unit number.</param>
        /// <return>The next stage of data disk definition.</return>
        VirtualMachineUnmanagedDataDisk.Definition.IWithVhdAttachedDiskSettings<VirtualMachine.Definition.IWithUnmanagedCreate> VirtualMachineUnmanagedDataDisk.Definition.IWithVhdAttachedDiskSettings<VirtualMachine.Definition.IWithUnmanagedCreate>.WithLun(int lun)
        {
            return this.WithLun(lun) as VirtualMachineUnmanagedDataDisk.Definition.IWithVhdAttachedDiskSettings<VirtualMachine.Definition.IWithUnmanagedCreate>;
        }

        /// <summary>
        /// Specifies the caching type for the data disk.
        /// </summary>
        /// <param name="cachingType">The disk caching type. Possible values include: 'None', 'ReadOnly', 'ReadWrite'.</param>
        /// <return>The next stage of data disk definition.</return>
        VirtualMachineUnmanagedDataDisk.Definition.IWithVhdAttachedDiskSettings<VirtualMachine.Definition.IWithUnmanagedCreate> VirtualMachineUnmanagedDataDisk.Definition.IWithVhdAttachedDiskSettings<VirtualMachine.Definition.IWithUnmanagedCreate>.WithCaching(CachingTypes cachingType)
        {
            return this.WithCaching(cachingType) as VirtualMachineUnmanagedDataDisk.Definition.IWithVhdAttachedDiskSettings<VirtualMachine.Definition.IWithUnmanagedCreate>;
        }

        /// <summary>
        /// Specifies the size in GB the disk needs to be resized.
        /// </summary>
        /// <param name="sizeInGB">The disk size in GB.</param>
        /// <return>The next stage of data disk definition.</return>
        VirtualMachineUnmanagedDataDisk.UpdateDefinition.IWithVhdAttachedDiskSettings<VirtualMachine.Update.IUpdate> VirtualMachineUnmanagedDataDisk.UpdateDefinition.IWithVhdAttachedDiskSettings<VirtualMachine.Update.IUpdate>.WithSizeInGB(int sizeInGB)
        {
            return this.WithSizeInGB(sizeInGB) as VirtualMachineUnmanagedDataDisk.UpdateDefinition.IWithVhdAttachedDiskSettings<VirtualMachine.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the logical unit number for the data disk.
        /// </summary>
        /// <param name="lun">The logical unit number.</param>
        /// <return>The next stage of data disk definition.</return>
        VirtualMachineUnmanagedDataDisk.UpdateDefinition.IWithVhdAttachedDiskSettings<VirtualMachine.Update.IUpdate> VirtualMachineUnmanagedDataDisk.UpdateDefinition.IWithVhdAttachedDiskSettings<VirtualMachine.Update.IUpdate>.WithLun(int lun)
        {
            return this.WithLun(lun) as VirtualMachineUnmanagedDataDisk.UpdateDefinition.IWithVhdAttachedDiskSettings<VirtualMachine.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the caching type for the data disk.
        /// </summary>
        /// <param name="cachingType">The disk caching type. Possible values include: 'None', 'ReadOnly', 'ReadWrite'.</param>
        /// <return>The next stage of data disk definition.</return>
        VirtualMachineUnmanagedDataDisk.UpdateDefinition.IWithVhdAttachedDiskSettings<VirtualMachine.Update.IUpdate> VirtualMachineUnmanagedDataDisk.UpdateDefinition.IWithVhdAttachedDiskSettings<VirtualMachine.Update.IUpdate>.WithCaching(CachingTypes cachingType)
        {
            return this.WithCaching(cachingType) as VirtualMachineUnmanagedDataDisk.UpdateDefinition.IWithVhdAttachedDiskSettings<VirtualMachine.Update.IUpdate>;
        }

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
        /// Specifies the new caching type for the data disk.
        /// </summary>
        /// <param name="cachingType">The disk caching type. Possible values include: 'None', 'ReadOnly', 'ReadWrite'.</param>
        /// <return>The next stage of data disk update.</return>
        VirtualMachineUnmanagedDataDisk.Update.IUpdate VirtualMachineUnmanagedDataDisk.Update.IWithDiskCaching.WithCaching(CachingTypes cachingType)
        {
            return this.WithCaching(cachingType) as VirtualMachineUnmanagedDataDisk.Update.IUpdate;
        }

        /// <summary>
        /// Gets uri to the virtual hard disk backing this data disk.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineUnmanagedDataDisk.VhdUri
        {
            get
            {
                return this.VhdUri();
            }
        }

        /// <summary>
        /// Gets the logical unit number assigned to this data disk.
        /// </summary>
        int Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineUnmanagedDataDisk.Lun
        {
            get
            {
                return this.Lun();
            }
        }

        /// <summary>
        /// Gets the creation method used while creating this disk.
        /// </summary>
        Models.DiskCreateOptionTypes Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineUnmanagedDataDisk.CreationMethod
        {
            get
            {
                return this.CreationMethod();
            }
        }

        /// <summary>
        /// Gets Gets the disk caching type.
        /// possible values are: 'None', 'ReadOnly', 'ReadWrite'.
        /// </summary>
        /// <summary>
        /// Gets the caching type.
        /// </summary>
        Models.CachingTypes Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineUnmanagedDataDisk.CachingType
        {
            get
            {
                return this.CachingType();
            }
        }

        /// <summary>
        /// Gets the size of this data disk in GB.
        /// </summary>
        int Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineUnmanagedDataDisk.Size
        {
            get
            {
                return this.Size();
            }
        }

        /// <summary>
        /// Gets Uri to the source virtual hard disk user image from which this disk was created.
        /// null will be returned if this disk is not based on an image.
        /// </summary>
        /// <summary>
        /// Gets the uri of the source vhd image.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineUnmanagedDataDisk.SourceImageUri
        {
            get
            {
                return this.SourceImageUri();
            }
        }

        /// <summary>
        /// Attaches the child definition to the parent resource update.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        VirtualMachine.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update.IInUpdate<VirtualMachine.Update.IUpdate>.Attach()
        {
            return this.Attach() as VirtualMachine.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the logical unit number for the data disk.
        /// </summary>
        /// <param name="lun">The logical unit number.</param>
        /// <return>The next stage of data disk definition.</return>
        VirtualMachineUnmanagedDataDisk.UpdateDefinition.IWithNewVhdDiskSettings<VirtualMachine.Update.IUpdate> VirtualMachineUnmanagedDataDisk.UpdateDefinition.IWithNewVhdDiskSettings<VirtualMachine.Update.IUpdate>.WithLun(int lun)
        {
            return this.WithLun(lun) as VirtualMachineUnmanagedDataDisk.UpdateDefinition.IWithNewVhdDiskSettings<VirtualMachine.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies where the VHD associated with the new blank data disk needs to be stored.
        /// </summary>
        /// <param name="storageAccountName">The storage account name.</param>
        /// <param name="containerName">The name of the container to hold the new VHD file.</param>
        /// <param name="vhdName">The name for the new VHD file.</param>
        /// <return>The next stage of data disk definition.</return>
        VirtualMachineUnmanagedDataDisk.UpdateDefinition.IWithNewVhdDiskSettings<VirtualMachine.Update.IUpdate> VirtualMachineUnmanagedDataDisk.UpdateDefinition.IWithNewVhdDiskSettings<VirtualMachine.Update.IUpdate>.StoreAt(string storageAccountName, string containerName, string vhdName)
        {
            return this.StoreAt(storageAccountName, containerName, vhdName) as VirtualMachineUnmanagedDataDisk.UpdateDefinition.IWithNewVhdDiskSettings<VirtualMachine.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the caching type for the data disk.
        /// </summary>
        /// <param name="cachingType">The disk caching type. Possible values include: 'None', 'ReadOnly', 'ReadWrite'.</param>
        /// <return>The next stage of data disk definition.</return>
        VirtualMachineUnmanagedDataDisk.UpdateDefinition.IWithNewVhdDiskSettings<VirtualMachine.Update.IUpdate> VirtualMachineUnmanagedDataDisk.UpdateDefinition.IWithNewVhdDiskSettings<VirtualMachine.Update.IUpdate>.WithCaching(CachingTypes cachingType)
        {
            return this.WithCaching(cachingType) as VirtualMachineUnmanagedDataDisk.UpdateDefinition.IWithNewVhdDiskSettings<VirtualMachine.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the logical unit number for the data disk.
        /// </summary>
        /// <param name="lun">The logical unit number.</param>
        /// <return>The next stage of data disk definition.</return>
        VirtualMachineUnmanagedDataDisk.Definition.IWithNewVhdDiskSettings<VirtualMachine.Definition.IWithUnmanagedCreate> VirtualMachineUnmanagedDataDisk.Definition.IWithNewVhdDiskSettings<VirtualMachine.Definition.IWithUnmanagedCreate>.WithLun(int lun)
        {
            return this.WithLun(lun) as VirtualMachineUnmanagedDataDisk.Definition.IWithNewVhdDiskSettings<VirtualMachine.Definition.IWithUnmanagedCreate>;
        }

        /// <summary>
        /// Specifies where the VHD associated with the new blank data disk needs to be stored.
        /// </summary>
        /// <param name="storageAccountName">The storage account name.</param>
        /// <param name="containerName">The name of the container to hold the new VHD file.</param>
        /// <param name="vhdName">The name for the new VHD file.</param>
        /// <return>The next stage of data disk definition.</return>
        VirtualMachineUnmanagedDataDisk.Definition.IWithNewVhdDiskSettings<VirtualMachine.Definition.IWithUnmanagedCreate> VirtualMachineUnmanagedDataDisk.Definition.IWithNewVhdDiskSettings<VirtualMachine.Definition.IWithUnmanagedCreate>.StoreAt(string storageAccountName, string containerName, string vhdName)
        {
            return this.StoreAt(storageAccountName, containerName, vhdName) as VirtualMachineUnmanagedDataDisk.Definition.IWithNewVhdDiskSettings<VirtualMachine.Definition.IWithUnmanagedCreate>;
        }

        /// <summary>
        /// Specifies the caching type for the data disk.
        /// </summary>
        /// <param name="cachingType">The disk caching type. Possible values include: 'None', 'ReadOnly', 'ReadWrite'.</param>
        /// <return>The next stage of data disk definition.</return>
        VirtualMachineUnmanagedDataDisk.Definition.IWithNewVhdDiskSettings<VirtualMachine.Definition.IWithUnmanagedCreate> VirtualMachineUnmanagedDataDisk.Definition.IWithNewVhdDiskSettings<VirtualMachine.Definition.IWithUnmanagedCreate>.WithCaching(CachingTypes cachingType)
        {
            return this.WithCaching(cachingType) as VirtualMachineUnmanagedDataDisk.Definition.IWithNewVhdDiskSettings<VirtualMachine.Definition.IWithUnmanagedCreate>;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        VirtualMachine.Definition.IWithUnmanagedCreate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<VirtualMachine.Definition.IWithUnmanagedCreate>.Attach()
        {
            return this.Attach() as VirtualMachine.Definition.IWithUnmanagedCreate;
        }

        /// <summary>
        /// Specifies the new size in GB for data disk.
        /// </summary>
        /// <param name="sizeInGB">The disk size in GB.</param>
        /// <return>The next stage of data disk update.</return>
        VirtualMachineUnmanagedDataDisk.Update.IUpdate VirtualMachineUnmanagedDataDisk.Update.IWithDiskSize.WithSizeInGB(int sizeInGB)
        {
            return this.WithSizeInGB(sizeInGB) as VirtualMachineUnmanagedDataDisk.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the new logical unit number for the data disk.
        /// </summary>
        /// <param name="lun">The logical unit number.</param>
        /// <return>The next stage of data disk update.</return>
        VirtualMachineUnmanagedDataDisk.Update.IUpdate VirtualMachineUnmanagedDataDisk.Update.IWithDiskLun.WithLun(int lun)
        {
            return this.WithLun(lun) as VirtualMachineUnmanagedDataDisk.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the size in GB the disk needs to be resized.
        /// </summary>
        /// <param name="sizeInGB">The disk size in GB.</param>
        /// <return>The next stage of data disk definition.</return>
        VirtualMachineUnmanagedDataDisk.Definition.IWithFromImageDiskSettings<VirtualMachine.Definition.IWithUnmanagedCreate> VirtualMachineUnmanagedDataDisk.Definition.IWithFromImageDiskSettings<VirtualMachine.Definition.IWithUnmanagedCreate>.WithSizeInGB(int sizeInGB)
        {
            return this.WithSizeInGB(sizeInGB) as VirtualMachineUnmanagedDataDisk.Definition.IWithFromImageDiskSettings<VirtualMachine.Definition.IWithUnmanagedCreate>;
        }

        /// <summary>
        /// Specifies where the VHD associated with the new blank data disk needs to be stored.
        /// </summary>
        /// <param name="storageAccountName">The storage account name.</param>
        /// <param name="containerName">The name of the container to hold the new VHD file.</param>
        /// <param name="vhdName">The name for the new VHD file.</param>
        /// <return>The next stage of data disk definition.</return>
        VirtualMachineUnmanagedDataDisk.Definition.IWithFromImageDiskSettings<VirtualMachine.Definition.IWithUnmanagedCreate> VirtualMachineUnmanagedDataDisk.Definition.IWithFromImageDiskSettings<VirtualMachine.Definition.IWithUnmanagedCreate>.StoreAt(string storageAccountName, string containerName, string vhdName)
        {
            return this.StoreAt(storageAccountName, containerName, vhdName) as VirtualMachineUnmanagedDataDisk.Definition.IWithFromImageDiskSettings<VirtualMachine.Definition.IWithUnmanagedCreate>;
        }

        /// <summary>
        /// Specifies the caching type for the data disk.
        /// </summary>
        /// <param name="cachingType">The disk caching type. Possible values include: 'None', 'ReadOnly', 'ReadWrite'.</param>
        /// <return>The next stage of data disk definition.</return>
        VirtualMachineUnmanagedDataDisk.Definition.IWithFromImageDiskSettings<VirtualMachine.Definition.IWithUnmanagedCreate> VirtualMachineUnmanagedDataDisk.Definition.IWithFromImageDiskSettings<VirtualMachine.Definition.IWithUnmanagedCreate>.WithCaching(CachingTypes cachingType)
        {
            return this.WithCaching(cachingType) as VirtualMachineUnmanagedDataDisk.Definition.IWithFromImageDiskSettings<VirtualMachine.Definition.IWithUnmanagedCreate>;
        }

        /// <summary>
        /// Specifies the existing source vhd of the disk.
        /// </summary>
        /// <param name="storageAccountName">The storage account name.</param>
        /// <param name="containerName">The name of the container holding VHD file.</param>
        /// <param name="vhdName">The name of the VHD file to attach.</param>
        /// <return>The next stage of data disk definition.</return>
        VirtualMachineUnmanagedDataDisk.Definition.IWithVhdAttachedDiskSettings<VirtualMachine.Definition.IWithUnmanagedCreate> VirtualMachineUnmanagedDataDisk.Definition.IWithDiskSource<VirtualMachine.Definition.IWithUnmanagedCreate>.WithExistingVhd(string storageAccountName, string containerName, string vhdName)
        {
            return this.WithExistingVhd(storageAccountName, containerName, vhdName) as VirtualMachineUnmanagedDataDisk.Definition.IWithVhdAttachedDiskSettings<VirtualMachine.Definition.IWithUnmanagedCreate>;
        }

        /// <summary>
        /// Specifies the image lun identifier of the source disk image.
        /// </summary>
        /// <param name="imageLun">The lun.</param>
        /// <return>The next stage of data disk definition.</return>
        VirtualMachineUnmanagedDataDisk.Definition.IWithFromImageDiskSettings<VirtualMachine.Definition.IWithUnmanagedCreate> VirtualMachineUnmanagedDataDisk.Definition.IWithDiskSource<VirtualMachine.Definition.IWithUnmanagedCreate>.FromImage(int imageLun)
        {
            return this.FromImage(imageLun) as VirtualMachineUnmanagedDataDisk.Definition.IWithFromImageDiskSettings<VirtualMachine.Definition.IWithUnmanagedCreate>;
        }

        /// <summary>
        /// Specifies that disk needs to be created with a new vhd of given size.
        /// </summary>
        /// <param name="sizeInGB">The initial disk size in GB.</param>
        /// <return>The next stage of data disk definition.</return>
        VirtualMachineUnmanagedDataDisk.Definition.IWithNewVhdDiskSettings<VirtualMachine.Definition.IWithUnmanagedCreate> VirtualMachineUnmanagedDataDisk.Definition.IWithDiskSource<VirtualMachine.Definition.IWithUnmanagedCreate>.WithNewVhd(int sizeInGB)
        {
            return this.WithNewVhd(sizeInGB) as VirtualMachineUnmanagedDataDisk.Definition.IWithNewVhdDiskSettings<VirtualMachine.Definition.IWithUnmanagedCreate>;
        }

        /// <summary>
        /// Specifies the existing source vhd of the disk.
        /// </summary>
        /// <param name="storageAccountName">The storage account name.</param>
        /// <param name="containerName">The name of the container holding VHD file.</param>
        /// <param name="vhdName">The name of the VHD file to attach.</param>
        /// <return>The next stage of data disk definition.</return>
        VirtualMachineUnmanagedDataDisk.UpdateDefinition.IWithVhdAttachedDiskSettings<VirtualMachine.Update.IUpdate> VirtualMachineUnmanagedDataDisk.UpdateDefinition.IWithDiskSource<VirtualMachine.Update.IUpdate>.WithExistingVhd(string storageAccountName, string containerName, string vhdName)
        {
            return this.WithExistingVhd(storageAccountName, containerName, vhdName) as VirtualMachineUnmanagedDataDisk.UpdateDefinition.IWithVhdAttachedDiskSettings<VirtualMachine.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies that disk needs to be created with a new vhd of given size.
        /// </summary>
        /// <param name="sizeInGB">The initial disk size in GB.</param>
        /// <return>The next stage of data disk definition.</return>
        VirtualMachineUnmanagedDataDisk.UpdateDefinition.IWithNewVhdDiskSettings<VirtualMachine.Update.IUpdate> VirtualMachineUnmanagedDataDisk.UpdateDefinition.IWithDiskSource<VirtualMachine.Update.IUpdate>.WithNewVhd(int sizeInGB)
        {
            return this.WithNewVhd(sizeInGB) as VirtualMachineUnmanagedDataDisk.UpdateDefinition.IWithNewVhdDiskSettings<VirtualMachine.Update.IUpdate>;
        }
    }
}