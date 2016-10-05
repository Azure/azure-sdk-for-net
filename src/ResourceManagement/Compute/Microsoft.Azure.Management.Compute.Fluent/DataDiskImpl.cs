// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Fluent.Compute
{

    using Management.Compute.Models;
    using System.Collections.Generic;
    using Resource.Core;
    using Storage;
    using Resource.Core.ChildResourceActions;
    using System;

    /// <summary>
    /// The implementation for DataDisk and its create and update interfaces.
    /// </summary>
    internal partial class DataDiskImpl :
        ChildResource<DataDisk,
            VirtualMachineImpl,
            IVirtualMachine>,
        IVirtualMachineDataDisk,
        VirtualMachineDataDisk.Definition.IDefinition<VirtualMachine.Definition.IWithCreate>,
        VirtualMachineDataDisk.UpdateDefinition.IUpdateDefinition<VirtualMachine.Update.IUpdate>,
        VirtualMachineDataDisk.Update.IUpdate
    {
        internal DataDiskImpl(DataDisk inner, VirtualMachineImpl parent) : base(inner, parent)
        {
        }

        internal static DataDiskImpl PrepareDataDisk(string name, DiskCreateOptionTypes createOption, VirtualMachineImpl parent)
        {
            DataDisk dataDiskInner = new DataDisk();
            dataDiskInner.Lun = -1;
            dataDiskInner.Name = name;
            dataDiskInner.CreateOption = createOption;
            dataDiskInner.Vhd = null;
            return new DataDiskImpl(dataDiskInner, parent);
        }

        internal static DataDiskImpl CreateNewDataDisk(int sizeInGB, VirtualMachineImpl parent)
        {
            DataDiskImpl dataDiskImpl = PrepareDataDisk(null, DiskCreateOptionTypes.Empty, parent);
            dataDiskImpl.Inner.DiskSizeGB = sizeInGB;
            return dataDiskImpl;
        }

        internal static DataDiskImpl CreateFromExistingDisk(string storageAccountName, string containerName, string vhdName, VirtualMachineImpl parent)
        {
            DataDiskImpl dataDiskImpl = PrepareDataDisk(null, DiskCreateOptionTypes.Attach, parent);
            VirtualHardDisk diskVhd =
                new VirtualHardDisk();
            diskVhd.Uri = BlobUrl(storageAccountName, containerName, vhdName);
            dataDiskImpl.Inner.Vhd = diskVhd;
            return dataDiskImpl;
        }

        public override string Name()
        {
            return Inner.Name;
        }

        public int Size()
        {
            return (Inner.DiskSizeGB.HasValue) ? Inner.DiskSizeGB.Value : 0;
        }

        public int Lun()
        {
            return Inner.Lun;
        }

        public string VhdUri()
        {
            return Inner.Vhd.Uri;
        }

        public CachingTypes CachingType()
        {
            return Inner.Caching.Value;
        }

        public string SourceImageUri()
        {
            return (Inner.Image != null) ? Inner.Image.Uri : null;
        }

        public DiskCreateOptionTypes CreationMethod()
        {
            return Inner.CreateOption;
        }

        public DataDiskImpl From (string storageAccountName, string containerName, string vhdName)
        {
            Inner.Vhd = new VirtualHardDisk();
            //URL points to an existing data disk to be attached
            Inner.Vhd.Uri = BlobUrl(storageAccountName, containerName, vhdName);
            return this;
        }

        public DataDiskImpl WithSizeInGB (int? sizeInGB)
        {
            // Note: Size can be specified only while attaching new blank disk.
            // Size cannot be specified while attaching an existing disk.
            // Once attached both type of data disk can be resized via VM update.
            Inner.DiskSizeGB = sizeInGB;
            return this;
        }

        public DataDiskImpl StoreAt (string storageAccountName, string containerName, string vhdName)
        {
            Inner.Vhd = new VirtualHardDisk();
            // URL points to where the new data disk needs to be stored
            Inner.Vhd.Uri = BlobUrl(storageAccountName, containerName, vhdName);
            return this;
        }

        public DataDiskImpl WithLun (int? lun)
        {
            Inner.Lun = (lun.HasValue) ? lun.Value : 0;
            return this;
        }

        public DataDiskImpl WithCaching (CachingTypes cachingType)
        {
            Inner.Caching = cachingType;
            return this;
        }

        public VirtualMachineImpl Attach ()
        {
            Parent.WithDataDisk(this);
            return Parent;
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
                if (dataDisk.CreationMethod == DiskCreateOptionTypes.Empty)
                {
                    //New data disk requires Vhd Uri to be set
                    if (dataDisk.Inner.Vhd == null)
                    {
                        dataDisk.Inner.Vhd = new VirtualHardDisk();
                        dataDisk.Inner.Vhd.Uri = storageAccount.EndPoints.Primary.Blob
                            + "vhds/"
                            + namePrefix + "-data-disk-" + dataDisk.Lun + "-" + Guid.NewGuid().ToString() + ".vhd";
                    }
                }
            }
        }

        internal static void EnsureDisksVhdUri(IList<IVirtualMachineDataDisk> dataDisks, string namePrefix)
        {
            string containerUrl = null;
            foreach (IVirtualMachineDataDisk dataDisk in dataDisks)
            {
                if (dataDisk.CreationMethod == DiskCreateOptionTypes.Empty && dataDisk.Inner.Vhd != null)
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
                    if (dataDisk.CreationMethod == DiskCreateOptionTypes.Empty)
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

        private static string BlobUrl(string storageAccountName, string containerName, string blobName)
        {

            // Future: Get the storage domain from the environment
            return "https://" + storageAccountName + ".blob.core.windows.net" + "/" + containerName + "/" + blobName;
        }

        VirtualMachine.Update.IUpdate ISettable<VirtualMachine.Update.IUpdate>.Parent()
        {
            return Parent;
        }
    }
}