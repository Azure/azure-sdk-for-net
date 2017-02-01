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
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update;
    using Microsoft.Azure.Management.Storage.Fluent;
    using System.Collections.Generic;
    using Resource.Fluent.Core.ChildResourceActions;
    using System;

    /// <summary>
    /// The implementation for DataDisk and its create and update interfaces.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uVW5tYW5hZ2VkRGF0YURpc2tJbXBs
    internal partial class UnmanagedDataDiskImpl :
        ChildResource<Models.DataDisk, Microsoft.Azure.Management.Compute.Fluent.VirtualMachineImpl, Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine>,
        IVirtualMachineUnmanagedDataDisk,
        IDefinitionWithExistingVhd<VirtualMachine.Definition.IWithUnmanagedCreate>,
        IDefinitionWithNewVhd<VirtualMachine.Definition.IWithUnmanagedCreate>,
        IDefinitionWithImage<VirtualMachine.Definition.IWithUnmanagedCreate>,
        IUpdateDefinitionWithExistingVhd<VirtualMachine.Update.IUpdate>,
        IUpdateDefinitionWithNewVhd<VirtualMachine.Update.IUpdate>,
        VirtualMachineUnmanagedDataDisk.Update.IUpdate
    {
        ///GENMHASH:88BF8FC8FF5E454A69B0A7818E15A401:540C8E40423CBE57B12D10B8EE2CEEF4
        public UnmanagedDataDiskImpl WithSizeInGB(int sizeInGB)
        {
            Inner.DiskSizeGB = sizeInGB;
            return this;
        }

        ///GENMHASH:C750A932F4B9EE34084CA22A3E049C1A:C0847EA0CDA78F6D91EFD239C70F0FA7
        internal UnmanagedDataDiskImpl(DataDisk inner, VirtualMachineImpl parent) : base(inner, parent)
        {
        }

        ///GENMHASH:2AACDDD3816365551D8FC102857D11E2:706919D03598978742E38A749514FA0F
        public int Lun()
        {
            return Inner.Lun;
        }

        ///GENMHASH:4D03AEE57198D17CD3696CC56B467F2B:C53E1C1BD65826C0F9A2EF5BCBD283F4
        public UnmanagedDataDiskImpl FromImage(int imageLun)
        {
            this.Inner.CreateOption = DiskCreateOptionTypes.FromImage;
            this.Inner.Lun = imageLun;
            return this;
        }

        ///GENMHASH:567CC1FD21599D3AE5DDC911A1D01193:0AD0D814032A939B006CE81FEE0C0773
        public UnmanagedDataDiskImpl StoreAt(string storageAccountName, string containerName, string vhdName)
        {
            Inner.Vhd = new VirtualHardDisk();
            // URL points to where the new data disk needs to be stored
            Inner.Vhd.Uri = BlobUrl(storageAccountName, containerName, vhdName);
            return this;
        }

        ///GENMHASH:92AE46C01A63B43959FE4FF2A5F2504A:610AF42860E2EF86F5F9AC3635C2A5A9
        internal static void SetDataDisksDefaults(IList<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineUnmanagedDataDisk> dataDisks, string namePrefix)
        {
            var usedLuns = new HashSet<int>();
            foreach(var dataDisk in dataDisks)
            {
                if (dataDisk.Lun != -1)
                {
                    usedLuns.Add(dataDisk.Lun);
                }
            }
            foreach (var dataDisk in dataDisks)
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
        
        ///GENMHASH:5989C68B78A7796C5344EB1BA406F61C:CAE3210BD862043FDDDDDCEA6F38692E
        public UnmanagedDataDiskImpl WithExistingVhd(string storageAccountName, string containerName, string vhdName)
        {
            this.Inner.CreateOption = DiskCreateOptionTypes.Attach;
            this.Inner.Vhd = new VirtualHardDisk();
            this.Inner.Vhd.Uri = BlobUrl(storageAccountName, containerName, vhdName);
            return this;
        }

        ///GENMHASH:6C7A66561217BAE3245D6F32A1496CC9:2923A60F8399D284424553D90A01711B
        private static string BlobUrl(string storageAccountName, string containerName, string blobName)
        {

            // Future: Get the storage domain from the environment
            return "https://" + storageAccountName + ".blob.core.windows.net" + "/" + containerName + "/" + blobName;
        }

        ///GENMHASH:638DE13F1D4D90A0515B35BE7FE1BE5C:8FABD54B6B9CC34ECD0DAE095274C8FB
        internal static void EnsureDisksVhdUri(IList<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineUnmanagedDataDisk> dataDisks, IStorageAccount storageAccount, string namePrefix)
        {
            foreach(var dataDisk in dataDisks)  {
                if (dataDisk.CreationMethod == DiskCreateOptionTypes.Empty
                    || dataDisk.CreationMethod == DiskCreateOptionTypes.FromImage) {
                    //New empty and from image data disk requires Vhd Uri to be set
                    if (dataDisk.Inner.Vhd == null) {
                        dataDisk.Inner.Vhd = new VirtualHardDisk();
                        dataDisk.Inner.Vhd.Uri = storageAccount.EndPoints.Primary.Blob
                            + "vhds/"
                            + namePrefix + "-data-disk-" + dataDisk.Lun + "-" + Guid.NewGuid().ToString() + ".Vhd";
                    }
                }
            }
        }

        ///GENMHASH:E2572688B4B3B1EAAAB910EE8FE4FC34:F8253F56C932FDE6B3232FBAD1099CA0
        internal static void EnsureDisksVhdUri(IList<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineUnmanagedDataDisk> dataDisks, string namePrefix)
        {
            string containerUrl = null;
            foreach(var dataDisk in dataDisks)  {
                if (dataDisk.CreationMethod == DiskCreateOptionTypes.Empty && dataDisk.Inner.Vhd != null) {
                    int idx = dataDisk.Inner.Vhd.Uri.LastIndexOf('/');
                    containerUrl = dataDisk.Inner.Vhd.Uri.Substring(0, idx);
                    break;
                }
            }
            if (containerUrl != null)
            {
                foreach (var dataDisk in dataDisks)
                {
                    if (dataDisk.CreationMethod == DiskCreateOptionTypes.Empty)
                    {
                        //New data disk requires Vhd Uri to be set
                        if (dataDisk.Inner.Vhd == null)
                        {
                            dataDisk.Inner.Vhd = new VirtualHardDisk();
                            dataDisk.Inner.Vhd.Uri = containerUrl
                                + namePrefix + "-data-disk-" + dataDisk.Lun + "-" + Guid.NewGuid().ToString() + ".Vhd";
                        }
                    }
                }
            }
        }

        ///GENMHASH:D85E911348B4AD36294F154A7C700412:BFD5BBE75FF2933909C9A5EE4D96DB28
        public DiskCreateOptionTypes CreationMethod()
        {
            return Inner.CreateOption;
        }

        ///GENMHASH:C7091D00973B3F300E66AD6FC3B9988D:54AEB1FA4318E2287B56DE751B25DB84
        public UnmanagedDataDiskImpl WithCaching(CachingTypes cachingType)
        {
            Inner.Caching = cachingType;
            return this;
        }

        ///GENMHASH:85A8DBD12E0C71C6279D3BBF22920B47:7D68D29E6DB49A5E8D05A7F0E326F265
        internal static UnmanagedDataDiskImpl PrepareDataDisk(string name, VirtualMachineImpl parent)
        {
            DataDisk dataDiskInner = new DataDisk();
            dataDiskInner.Lun = -1;
            dataDiskInner.Name = name;
            dataDiskInner.Vhd = null;
            return new UnmanagedDataDiskImpl(dataDiskInner, parent);
        }

        ///GENMHASH:D80E43EEBE8880F1BADCE05BAF1042EF:0113C04AE3C15CEAB124AD90F4CAB5C2
        public string SourceImageUri()
        {
            return (Inner.Image != null) ? Inner.Image.Uri : null;
        }

        ///GENMHASH:C19382933BDE655D0F0F95CD9474DFE7:28B657BB52464897349F96AD3FEE7B7C
        public int Size()
        {
            return (Inner.DiskSizeGB.HasValue) ? Inner.DiskSizeGB.Value : 0;
        }

        ///GENMHASH:301C4791B0609BB2A3EF3CEB742CCE25:79B6BAD7C09953890526D60F9A4A6FDE
        public CachingTypes CachingType()
        {
            return Inner.Caching.Value;
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:61C1065B307679F3800C701AE0D87070
        public override string Name()
        {
            return Inner.Name;
        }

        ///GENMHASH:51D4B59B71DF10B44776B4681F73B529:D3A7D61EDBE1631F4C5B0CD3CCDF840C
        public UnmanagedDataDiskImpl WithLun(int lun)
        {
            Inner.Lun = lun;
            return this;
        }

        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:B71A21463FF02581ACF78369CF72AC50
        public VirtualMachineImpl Attach()
        {
            return this.Parent.WithUnmanagedDataDisk(this);
        }

        ///GENMHASH:D84E9E0F357B788BCAB328D794942F08:19BC6903CCEBF10242B1E86E12D807D3
        public string VhdUri()
        {
            return Inner.Vhd.Uri;
        }

        ///GENMHASH:6D0A07B7BA2CC9D76E93E7DDD3FCD168:F0DBEF25393BFAD18455A742CA0EFE14
        public UnmanagedDataDiskImpl WithNewVhd(int sizeInGB)
        {
            this.Inner.CreateOption = DiskCreateOptionTypes.Empty;
            this.Inner.DiskSizeGB = sizeInGB;
            return this;
        }

        VirtualMachine.Update.IUpdate ISettable<VirtualMachine.Update.IUpdate>.Parent()
        {
            return Parent;
        }
    }
}