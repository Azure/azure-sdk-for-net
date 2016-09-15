/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Compute
{

    using System.Collections.Generic;
    using Microsoft.Azure.Management.Compute.Models;
    using Microsoft.Azure.Management.V2.Compute.VirtualMachineDataDisk.Definition;
    using Microsoft.Azure.Management.V2.Resource.Core.ChildResource.Update;
    using Microsoft.Azure.Management.V2.Compute.VirtualMachineDataDisk.Update;
    using Microsoft.Azure.Management.V2.Resource.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.V2.Storage;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition;
    using Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update;
    public partial class DataDiskImpl 
    {
        /// <summary>
        /// Specifies an existing VHD that needs to be attached to the virtual machine as data disk.
        /// </summary>
        /// <param name="storageAccountName">storageAccountName the storage account name</param>
        /// <param name="containerName">containerName the name of the container holding the VHD file</param>
        /// <param name="vhdName">vhdName the name for the VHD file</param>
        /// <returns>the stage representing optional additional settings for the attachable data disk</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineDataDisk.Update.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate> Microsoft.Azure.Management.V2.Compute.VirtualMachineDataDisk.Update.IAttachExistingDataDisk<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate>.From (string storageAccountName, string containerName, string vhdName) {
            return this.From( storageAccountName,  containerName,  vhdName) as Microsoft.Azure.Management.V2.Compute.VirtualMachineDataDisk.Update.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies an existing VHD that needs to be attached to the virtual machine as data disk.
        /// </summary>
        /// <param name="storageAccountName">storageAccountName the storage account name</param>
        /// <param name="containerName">containerName the name of the container holding the VHD file</param>
        /// <param name="vhdName">vhdName the name for the VHD file</param>
        /// <returns>the stage representing optional additional settings for the attachable data disk</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineDataDisk.Definition.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate> Microsoft.Azure.Management.V2.Compute.VirtualMachineDataDisk.Definition.IAttachExistingDataDisk<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate>.From (string storageAccountName, string containerName, string vhdName) {
            return this.From( storageAccountName,  containerName,  vhdName) as Microsoft.Azure.Management.V2.Compute.VirtualMachineDataDisk.Definition.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate>;
        }

        /// <returns>uri to the virtual hard disk backing this data disk</returns>
        string Microsoft.Azure.Management.V2.Compute.IVirtualMachineDataDisk.VhdUri
        {
            get
            {
                return this.VhdUri as string;
            }
        }
        /// <returns>the logical unit number assigned to this data disk</returns>
        int? Microsoft.Azure.Management.V2.Compute.IVirtualMachineDataDisk.Lun
        {
            get
            {
                return this.Lun;
            }
        }
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
        Microsoft.Azure.Management.Compute.Models.DiskCreateOptionTypes? Microsoft.Azure.Management.V2.Compute.IVirtualMachineDataDisk.CreateOption
        {
            get
            {
                return this.CreateOption;
            }
        }
        /// <summary>
        /// Gets the disk caching type.
        /// <p>
        /// possible values are: 'None', 'ReadOnly', 'ReadWrite'
        /// </summary>
        /// <returns>the caching type</returns>
        Microsoft.Azure.Management.Compute.Models.CachingTypes? Microsoft.Azure.Management.V2.Compute.IVirtualMachineDataDisk.CachingType
        {
            get
            {
                return this.CachingType;
            }
        }
        /// <returns>the size of this data disk in GB</returns>
        int? Microsoft.Azure.Management.V2.Compute.IVirtualMachineDataDisk.Size
        {
            get
            {
                return this.Size;
            }
        }
        /// <summary>
        /// Uri to the source virtual hard disk user image from which this disk was created.
        /// <p>
        /// null will be returned if this disk is not based on an image
        /// </summary>
        /// <returns>the uri of the source vhd image</returns>
        string Microsoft.Azure.Management.V2.Compute.IVirtualMachineDataDisk.SourceImageUri
        {
            get
            {
                return this.SourceImageUri as string;
            }
        }
        Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate Microsoft.Azure.Management.V2.Resource.Core.ChildResource.Update.IInUpdate<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate>.Attach () {
            return this.Attach() as Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the new size in GB for data disk.
        /// </summary>
        /// <param name="sizeInGB">sizeInGB the disk size in GB</param>
        /// <returns>the next stage of data disk update</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineDataDisk.Update.IUpdate Microsoft.Azure.Management.V2.Compute.VirtualMachineDataDisk.Update.IUpdateStages.WithSizeInGB (int? sizeInGB) {
            return this.WithSizeInGB( sizeInGB) as Microsoft.Azure.Management.V2.Compute.VirtualMachineDataDisk.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the new logical unit number for the data disk.
        /// </summary>
        /// <param name="lun">lun the logical unit number</param>
        /// <returns>the next stage of data disk update</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineDataDisk.Update.IUpdate Microsoft.Azure.Management.V2.Compute.VirtualMachineDataDisk.Update.IUpdateStages.WithLun (int? lun) {
            return this.WithLun( lun) as Microsoft.Azure.Management.V2.Compute.VirtualMachineDataDisk.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the new caching type for the data disk.
        /// </summary>
        /// <param name="cachingType">cachingType the disk caching type. Possible values include: 'None', 'ReadOnly', 'ReadWrite'</param>
        /// <returns>the next stage of data disk update</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineDataDisk.Update.IUpdate Microsoft.Azure.Management.V2.Compute.VirtualMachineDataDisk.Update.IUpdateStages.WithCaching (CachingTypes cachingType) {
            return this.WithCaching( cachingType) as Microsoft.Azure.Management.V2.Compute.VirtualMachineDataDisk.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the initial disk size in GB for new blank data disk.
        /// </summary>
        /// <param name="sizeInGB">sizeInGB the disk size in GB</param>
        /// <returns>the stage representing optional additional settings for the attachable data disk</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineDataDisk.Update.IWithStoreAt<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate> Microsoft.Azure.Management.V2.Compute.VirtualMachineDataDisk.Update.IAttachNewDataDisk<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate>.WithSizeInGB (int? sizeInGB) {
            return this.WithSizeInGB( sizeInGB) as Microsoft.Azure.Management.V2.Compute.VirtualMachineDataDisk.Update.IWithStoreAt<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the initial disk size in GB for new blank data disk.
        /// </summary>
        /// <param name="sizeInGB">sizeInGB the disk size in GB</param>
        /// <returns>the stage representing optional additional settings for the attachable data disk</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineDataDisk.Definition.IWithStoreAt<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate> Microsoft.Azure.Management.V2.Compute.VirtualMachineDataDisk.Definition.IAttachNewDataDisk<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate>.WithSizeInGB (int? sizeInGB) {
            return this.WithSizeInGB( sizeInGB) as Microsoft.Azure.Management.V2.Compute.VirtualMachineDataDisk.Definition.IWithStoreAt<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate>;
        }

        Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate Microsoft.Azure.Management.V2.Resource.Core.ChildResource.Definition.IInDefinition<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate>.Attach () {
            return this.Attach() as Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate;
        }

        /// <returns>the name of the child resource</returns>
        string Microsoft.Azure.Management.V2.Resource.Core.IChildResource.Name
        {
            get
            {
                return this.Name as string;
            }
        }
        /// <summary>
        /// Specifies the logical unit number for the data disk.
        /// </summary>
        /// <param name="lun">lun the logical unit number</param>
        /// <returns>the next stage of data disk definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineDataDisk.Update.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate> Microsoft.Azure.Management.V2.Compute.VirtualMachineDataDisk.Update.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate>.WithLun (int? lun) {
            return this.WithLun( lun) as Microsoft.Azure.Management.V2.Compute.VirtualMachineDataDisk.Update.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the caching type for the data disk.
        /// </summary>
        /// <param name="cachingType">cachingType the disk caching type. Possible values include: 'None', 'ReadOnly', 'ReadWrite'</param>
        /// <returns>the next stage of data disk definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineDataDisk.Update.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate> Microsoft.Azure.Management.V2.Compute.VirtualMachineDataDisk.Update.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate>.WithCaching (CachingTypes cachingType) {
            return this.WithCaching( cachingType) as Microsoft.Azure.Management.V2.Compute.VirtualMachineDataDisk.Update.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the logical unit number for the data disk.
        /// </summary>
        /// <param name="lun">lun the logical unit number</param>
        /// <returns>the next stage of data disk definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineDataDisk.Definition.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate> Microsoft.Azure.Management.V2.Compute.VirtualMachineDataDisk.Definition.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate>.WithLun (int? lun) {
            return this.WithLun( lun) as Microsoft.Azure.Management.V2.Compute.VirtualMachineDataDisk.Definition.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the caching type for the data disk.
        /// </summary>
        /// <param name="cachingType">cachingType the disk caching type. Possible values include: 'None', 'ReadOnly', 'ReadWrite'</param>
        /// <returns>the next stage of data disk definition</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineDataDisk.Definition.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate> Microsoft.Azure.Management.V2.Compute.VirtualMachineDataDisk.Definition.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate>.WithCaching (CachingTypes cachingType) {
            return this.WithCaching( cachingType) as Microsoft.Azure.Management.V2.Compute.VirtualMachineDataDisk.Definition.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies where the VHD associated with the new blank data disk needs to be stored.
        /// </summary>
        /// <param name="storageAccountName">storageAccountName the storage account name</param>
        /// <param name="containerName">containerName the name of the container to hold the new VHD file</param>
        /// <param name="vhdName">vhdName the name for the new VHD file</param>
        /// <returns>the stage representing optional additional configurations for the data disk</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineDataDisk.Update.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate> Microsoft.Azure.Management.V2.Compute.VirtualMachineDataDisk.Update.IWithStoreAt<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate>.StoreAt (string storageAccountName, string containerName, string vhdName) {
            return this.StoreAt( storageAccountName,  containerName,  vhdName) as Microsoft.Azure.Management.V2.Compute.VirtualMachineDataDisk.Update.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies where the VHD associated with the new blank data disk needs to be stored.
        /// </summary>
        /// <param name="storageAccountName">storageAccountName the storage account name</param>
        /// <param name="containerName">containerName the name of the container to hold the new VHD file</param>
        /// <param name="vhdName">vhdName the name for the new VHD file</param>
        /// <returns>the stage representing optional additional configurations for the data disk</returns>
        Microsoft.Azure.Management.V2.Compute.VirtualMachineDataDisk.Definition.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate> Microsoft.Azure.Management.V2.Compute.VirtualMachineDataDisk.Definition.IWithStoreAt<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate>.StoreAt (string storageAccountName, string containerName, string vhdName) {
            return this.StoreAt( storageAccountName,  containerName,  vhdName) as Microsoft.Azure.Management.V2.Compute.VirtualMachineDataDisk.Definition.IWithAttach<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition.IWithCreate>;
        }

    }
}