// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Management.Compute.Fluent.Models;
    using System.Collections.Generic;
    using Resource.Fluent.Core;
    using Storage.Fluent;
    using Resource.Fluent.Core.ChildResourceActions;
    using System;

    /// <summary>
    /// The implementation for DataDisk and its create and update interfaces.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uRGF0YURpc2tJbXBs
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

        ///GENMHASH:4714DEB7BE5CD6EE8AD4E4E3D1C1A607:2855515496C24EA37ABEB783D3F0A978
        internal static DataDiskImpl PrepareDataDisk(string name, DiskCreateOptionTypes createOption, VirtualMachineImpl parent)
        {
            DataDisk dataDiskInner = new DataDisk();
            dataDiskInner.Lun = -1;
            dataDiskInner.Name = name;
            dataDiskInner.CreateOption = createOption;
            dataDiskInner.Vhd = null;
            return new DataDiskImpl(dataDiskInner, parent);
        }

        ///GENMHASH:BDD248ACBEC108199894A88588B02EDA:DA18B18BF6556C12F8BF56DE8A905637
        internal static DataDiskImpl CreateNewDataDisk(int sizeInGB, VirtualMachineImpl parent)
        {
            DataDiskImpl dataDiskImpl = PrepareDataDisk(null, DiskCreateOptionTypes.Empty, parent);
            dataDiskImpl.Inner.DiskSizeGB = sizeInGB;
            return dataDiskImpl;
        }

        ///GENMHASH:803C235B502174CF891C3924050B28E7:9C8D531F40ED45D3003FD4BD5F8D9E8C
        internal static DataDiskImpl CreateFromExistingDisk(string storageAccountName, string containerName, string vhdName, VirtualMachineImpl parent)
        {
            DataDiskImpl dataDiskImpl = PrepareDataDisk(null, DiskCreateOptionTypes.Attach, parent);
            VirtualHardDisk diskVhd =
                new VirtualHardDisk();
            diskVhd.Uri = BlobUrl(storageAccountName, containerName, vhdName);
            dataDiskImpl.Inner.Vhd = diskVhd;
            return dataDiskImpl;
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:61C1065B307679F3800C701AE0D87070
        public override string Name()
        {
            return Inner.Name;
        }

        ///GENMHASH:C19382933BDE655D0F0F95CD9474DFE7:4D7CB2339C530D89E88DEE5A4D761B52
        public int Size()
        {
            return (Inner.DiskSizeGB.HasValue) ? Inner.DiskSizeGB.Value : 0;
        }

        ///GENMHASH:2AACDDD3816365551D8FC102857D11E2:D89ABFB09517172FED352E3CE1BCA70F
        public int Lun()
        {
            return Inner.Lun;
        }

        ///GENMHASH:D84E9E0F357B788BCAB328D794942F08:19BC6903CCEBF10242B1E86E12D807D3
        public string VhdUri()
        {
            return Inner.Vhd.Uri;
        }

        ///GENMHASH:301C4791B0609BB2A3EF3CEB742CCE25:79B6BAD7C09953890526D60F9A4A6FDE
        public CachingTypes CachingType()
        {
            return Inner.Caching.Value;
        }

        ///GENMHASH:D80E43EEBE8880F1BADCE05BAF1042EF:0113C04AE3C15CEAB124AD90F4CAB5C2
        public string SourceImageUri()
        {
            return (Inner.Image != null) ? Inner.Image.Uri : null;
        }

        ///GENMHASH:D85E911348B4AD36294F154A7C700412:BFD5BBE75FF2933909C9A5EE4D96DB28
        public DiskCreateOptionTypes CreationMethod()
        {
            return Inner.CreateOption;
        }

        ///GENMHASH:AC482EA21839170312CF02861281C53E:2EEB08F1905FFFDC17E96448FD5AE9CC
        public DataDiskImpl From(string storageAccountName, string containerName, string vhdName)
        {
            Inner.Vhd = new VirtualHardDisk();
            //URL points to an existing data disk to be attached
            Inner.Vhd.Uri = BlobUrl(storageAccountName, containerName, vhdName);
            return this;
        }

        ///GENMHASH:88BF8FC8FF5E454A69B0A7818E15A401:0C064E5A61E8677E42E07541EB66AE74
        public DataDiskImpl WithSizeInGB(int? sizeInGB)
        {
            // Note: Size can be specified only while attaching new blank disk.
            // Size cannot be specified while attaching an existing disk.
            // Once attached both type of data disk can be resized via VM update.
            Inner.DiskSizeGB = sizeInGB;
            return this;
        }

        ///GENMHASH:567CC1FD21599D3AE5DDC911A1D01193:BCD7147646D9A4990ACAFFB2FE2E22FD
        public DataDiskImpl StoreAt(string storageAccountName, string containerName, string vhdName)
        {
            Inner.Vhd = new VirtualHardDisk();
            // URL points to where the new data disk needs to be stored
            Inner.Vhd.Uri = BlobUrl(storageAccountName, containerName, vhdName);
            return this;
        }
        
        ///GENMHASH:51D4B59B71DF10B44776B4681F73B529:D3A7D61EDBE1631F4C5B0CD3CCDF840C
        public DataDiskImpl WithLun(int lun)
        {
            Inner.Lun = lun;
            return this;
        }

        ///GENMHASH:C7091D00973B3F300E66AD6FC3B9988D:54AEB1FA4318E2287B56DE751B25DB84
        public DataDiskImpl WithCaching(CachingTypes cachingType)
        {
            Inner.Caching = cachingType;
            return this;
        }

        public VirtualMachineImpl Attach ()
        {
            Parent.WithDataDisk(this);
            return Parent;
        }

        ///GENMHASH:047C6B6C0C82720CEF92A231E7674410:6FFB08494F9F61FB79581EB993FDAB33
        internal static void SetDataDisksDefaults(IList<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineDataDisk> dataDisks, string namePrefix)
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

        ///GENMHASH:DA8BD9647B47E080B4B20CD6A80D7ED5:E05A9236FCD2E4848482EA2B4166BFD2
        internal static void EnsureDisksVhdUri(IList<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineDataDisk> dataDisks, IStorageAccount storageAccount, string namePrefix)
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

        ///GENMHASH:E5A256ABEAE72F4E208B877DC175B18B:38E3356CD49ECA71D523E70E3CCC0153
        internal static void EnsureDisksVhdUri(IList<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineDataDisk> dataDisks, string namePrefix)
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

        ///GENMHASH:6C7A66561217BAE3245D6F32A1496CC9:2923A60F8399D284424553D90A01711B
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