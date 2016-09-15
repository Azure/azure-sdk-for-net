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
    using Resource.Core.ChildResourceActions;
    using System;


    /// <summary>
    /// The implementation for {@link DataDisk} and its create and update interfaces.
    /// </summary>
    public partial class DataDiskImpl :
        ChildResource<DataDisk, IVirtualMachine>,
        IVirtualMachineDataDisk,
        IDefinition<IWithCreate>,
        IUpdateDefinition<Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update.IUpdate>,
        Microsoft.Azure.Management.V2.Compute.VirtualMachineDataDisk.Update.IUpdate
    {
        internal DataDiskImpl(DataDisk inner, IVirtualMachine parent) :
            base(inner.Name, inner, parent)
        {
        }

        internal static DataDiskImpl PrepareDataDisk(string name, DiskCreateOptionTypes createOption, IVirtualMachine parent)
        {
            DataDisk dataDiskInner = new DataDisk();
            dataDiskInner.Lun = -1;
            dataDiskInner.Name = name;
            dataDiskInner.CreateOption = createOption;
            dataDiskInner.Vhd = null;
            return new DataDiskImpl(dataDiskInner, parent);
        }

        internal static DataDiskImpl CreateNewDataDisk(int sizeInGB, IVirtualMachine parent)
        {

            DataDiskImpl dataDiskImpl = PrepareDataDisk(null, DiskCreateOptionTypes.Empty, parent);
            dataDiskImpl.Inner.DiskSizeGB = sizeInGB;
            return dataDiskImpl;
        }

        internal static DataDiskImpl CreateFromExistingDisk(string storageAccountName, string containerName, string vhdName, IVirtualMachine parent)
        {
            DataDiskImpl dataDiskImpl = PrepareDataDisk(null, DiskCreateOptionTypes.Attach, parent);
            VirtualHardDisk diskVhd = new VirtualHardDisk();
            diskVhd.Uri = BlobUrl(storageAccountName, containerName, vhdName);
            dataDiskImpl.Inner.Vhd = diskVhd;
            return dataDiskImpl;
        }

        public string Name
        {
            get
            {
                return this.Inner.Name;
            }
        }
        public int? Size
        {
            get
            {
                return this.Inner.DiskSizeGB;
            }
        }

        public int? Lun
        {
            get
            {
                return this.Inner.Lun;
            }
        }
        public string VhdUri
        {
            get
            {
                return this.Inner.Vhd.Uri;
            }
        }

        public CachingTypes? CachingType
        {
            get
            {
                return this.Inner.Caching;
            }
        }

        public string SourceImageUri
        {
            get
            {
                if (this.Inner.Image != null)
                {
                    return this.Inner.Image.Uri;

                }
                return null;
            }
        }

        public DiskCreateOptionTypes? CreateOption
        {
            get
            {
                return this.Inner.CreateOption;
            }
        }

        public DataDiskImpl From(string storageAccountName, string containerName, string vhdName)
        {
            this.Inner.Vhd = new VirtualHardDisk();
            //URL points to an existing data disk to be attached
            this.Inner.Vhd.Uri = BlobUrl(storageAccountName, containerName, vhdName);
            return this;
        }

        public DataDiskImpl WithSizeInGB(int? sizeInGB)
        {
            // Note: Size can be specified only while attaching new blank disk.
            // Size cannot be specified while attaching an existing disk.
            // Once attached both type of data disk can be resized via VM update.
            this.Inner.DiskSizeGB = sizeInGB;
            return this;
        }

        public DataDiskImpl StoreAt(string storageAccountName, string containerName, string vhdName)
        {
            this.Inner.Vhd = new VirtualHardDisk();
            // URL points to where the new data disk needs to be stored
            this.Inner.Vhd.Uri = BlobUrl(storageAccountName, containerName, vhdName);
            return this;
        }

        public DataDiskImpl WithLun(int? lun)
        {
            this.Inner.Lun = lun.HasValue ? lun.Value : 0;
            return this;
        }

        public DataDiskImpl WithCaching(CachingTypes cachingType)
        {
            this.Inner.Caching = cachingType;
            return this;
        }

        public IVirtualMachine Attach()
        {
            this.Parent.DataDisks().Add(this);
            return this.Parent;
        }

        internal static void SetDataDisksDefaults(IList<IVirtualMachineDataDisk> dataDisks, string namePrefix)
        {
            var usedLuns = new List<int?>();
            foreach (IVirtualMachineDataDisk dataDisk in dataDisks)
            {
                if (dataDisk.Lun != -1)
                {
                    usedLuns.Add(dataDisk.Lun);
                }
            }

            foreach (IVirtualMachineDataDisk dataDisk in dataDisks)
            {
                if (dataDisk.Lun == -1)
                {
                    int i = 0;
                    while (usedLuns.Contains(i))
                    {
                        i++;
                    }

                    dataDisk.Inner.Lun = i;
                    usedLuns.Add(i);
                }

                if (dataDisk.Name == null)
                {
                    dataDisk.Inner.Name = namePrefix + "-data-disk-" + dataDisk.Lun;
                }

                if (dataDisk.Inner.Caching == null)
                {
                    dataDisk.Inner.Caching = CachingTypes.ReadWrite;
                }
            }
        }

        internal static void EnsureDisksVhdUri(IList<IVirtualMachineDataDisk> dataDisks, IStorageAccount storageAccount, string namePrefix)
        {

            foreach (IVirtualMachineDataDisk dataDisk in dataDisks)
            {
                if (dataDisk.CreateOption == DiskCreateOptionTypes.Empty)
                {
                    //New data disk requires Vhd Uri to be set
                    if (dataDisk.Inner.Vhd == null)
                    {
                        dataDisk.Inner.Vhd  =new VirtualHardDisk();
                        dataDisk.Inner.Vhd.Uri = storageAccount.EndPoints.Primary.Blob
                            + "vhds/"
                            + namePrefix + "-data-disk-" + dataDisk.Lun + "-" + Guid.NewGuid().ToString() + ".vhd";
                    }
                }
            }
        }

        internal static void EnsureDisksVhdUri (IList<IVirtualMachineDataDisk> dataDisks, string namePrefix)
        {
            string containerUrl = null;
            foreach (IVirtualMachineDataDisk dataDisk in dataDisks)
            {
                if (dataDisk.CreateOption == DiskCreateOptionTypes.Empty && dataDisk.Inner.Vhd != null)
                {
                    int idx = dataDisk.Inner.Vhd.Uri.LastIndexOf('/');
                    containerUrl = dataDisk.Inner.Vhd.Uri.Substring(0, idx);
                    break;
                }
            }
            if (containerUrl != null)
            {
                foreach (IVirtualMachineDataDisk dataDisk in dataDisks)
                {
                    if (dataDisk.CreateOption == DiskCreateOptionTypes.Empty)
                    {
                        //New data disk requires Vhd Uri to be set
                        if (dataDisk.Inner.Vhd == null)
                        {
                            dataDisk.Inner.Vhd = new VirtualHardDisk();
                            dataDisk.Inner.Vhd.Uri = containerUrl
                                + namePrefix + "-data-disk-" + dataDisk.Lun + "-" + Guid.NewGuid().ToString() + ".vhd";
                        }
                    }
                }
            }
        }

        private static string BlobUrl (string storageAccountName, string containerName, string blobName)
        {

            // Future: Get the storage domain from the environment
            return  "https://" + storageAccountName + ".blob.core.windows.net" + "/" + containerName + "/" + blobName;
        }

        VirtualMachine.Update.IUpdate ISettable<VirtualMachine.Update.IUpdate>.Parent()
        {
            return base.Parent as VirtualMachine.Update.IUpdate;
        }
    }
}