// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Models;
    using VirtualMachineScaleSetUnmanagedDataDisk.DefinitionWithImage;
    using VirtualMachineScaleSetUnmanagedDataDisk.DefinitionWithNewVhd;
    using VirtualMachineScaleSetUnmanagedDataDisk.UpdateDefinition;
    using ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using ResourceManager.Fluent.Core.ChildResourceActions;

    /// <summary>
    /// The implementation for VirtualMachineScaleSetUnmanagedDataDisk and its create and update interfaces.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uVmlydHVhbE1hY2hpbmVTY2FsZVNldFVubWFuYWdlZERhdGFEaXNrSW1wbA==
    internal partial class VirtualMachineScaleSetUnmanagedDataDiskImpl :
        ChildResource<VirtualMachineScaleSetDataDisk,
            VirtualMachineScaleSetImpl,
            IVirtualMachineScaleSet>,
        IDefinitionWithNewVhd<VirtualMachineScaleSet.Definition.IWithUnmanagedCreate>,
        IDefinitionWithImage<VirtualMachineScaleSet.Definition.IWithUnmanagedCreate>,
        IUpdateDefinition<VirtualMachineScaleSet.Update.IWithApply>,
        VirtualMachineScaleSetUnmanagedDataDisk.Update.IUpdate,
        IVirtualMachineScaleSetUnmanagedDataDisk
    {
        ///GENMHASH:617D48C9BF0FA6CD694A26538B906A7F:D1F3799D5CD797C8CC71EC10E206DBDA
        internal VirtualMachineScaleSetUnmanagedDataDiskImpl(VirtualMachineScaleSetDataDisk innerObject, 
            VirtualMachineScaleSetImpl parent) : base(innerObject, parent)
        {
        }

        ///GENMHASH:1A929F00DE22047370B57DA611030A23:3EE8418DD2BC67EC59EE2F0881B0BE90
        protected static VirtualMachineScaleSetUnmanagedDataDiskImpl PrepareDataDisk(string name, VirtualMachineScaleSetImpl parent)
        {
            VirtualMachineScaleSetDataDisk dataDiskInner = new VirtualMachineScaleSetDataDisk();
            dataDiskInner.Lun = -1;
            dataDiskInner.Name = name;
            return new VirtualMachineScaleSetUnmanagedDataDiskImpl(dataDiskInner, parent);
        }

        ///GENMHASH:88BF8FC8FF5E454A69B0A7818E15A401:540C8E40423CBE57B12D10B8EE2CEEF4
        public VirtualMachineScaleSetUnmanagedDataDiskImpl WithSizeInGB(int sizeInGB)
        {
            Inner.DiskSizeGB = sizeInGB;
            return this;
        }

        ///GENMHASH:4D03AEE57198D17CD3696CC56B467F2B:C53E1C1BD65826C0F9A2EF5BCBD283F4
        public VirtualMachineScaleSetUnmanagedDataDiskImpl FromImage(int imageLun)
        {
            Inner.CreateOption = DiskCreateOptionTypes.FromImage;
            Inner.Lun = imageLun;
            return this;
        }

        ///GENMHASH:2545A36B245093F3B4748F2212BB902A:D12A8F078CB07224E8B76EECBBC7F3DF
        internal static void SetDataDisksDefaults(IList<Models.VirtualMachineScaleSetDataDisk> dataDisks, string namePrefix)
        {
            if (dataDisks == null)
            {
                return;
            }
            var usedLuns = new HashSet<int>();
            foreach (var dataDisk in dataDisks)
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
                    dataDisk.Lun = i;
                    usedLuns.Add(i);
                }
                if (dataDisk.Name == null)
                {
                    dataDisk.Name = namePrefix + "-data-disk-" + dataDisk.Lun;
                }
                if (dataDisk.Caching == null)
                {
                    dataDisk.Caching = CachingTypes.ReadWrite;
                }
            }
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:61C1065B307679F3800C701AE0D87070
        public override string Name()
        {
            return Inner.Name;
        }

        ///GENMHASH:51D4B59B71DF10B44776B4681F73B529:D3A7D61EDBE1631F4C5B0CD3CCDF840C
        public VirtualMachineScaleSetUnmanagedDataDiskImpl WithLun(int lun)
        {
            Inner.Lun = lun;
            return this;
        }

        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:B71A21463FF02581ACF78369CF72AC50
        public VirtualMachineScaleSetImpl Attach()
        {
            return this.Parent.WithUnmanagedDataDisk(this);
        }

        ///GENMHASH:6D0A07B7BA2CC9D76E93E7DDD3FCD168:F0DBEF25393BFAD18455A742CA0EFE14
        public VirtualMachineScaleSetUnmanagedDataDiskImpl WithNewVhd(int sizeInGB)
        {
            Inner.CreateOption = DiskCreateOptionTypes.Empty;
            Inner.DiskSizeGB = sizeInGB;
            return this;
        }

        ///GENMHASH:C7091D00973B3F300E66AD6FC3B9988D:54AEB1FA4318E2287B56DE751B25DB84
        public VirtualMachineScaleSetUnmanagedDataDiskImpl WithCaching(CachingTypes cachingType)
        {
            Inner.Caching = cachingType;
            return this;
        }

        VirtualMachineScaleSet.Update.IUpdate ISettable<VirtualMachineScaleSet.Update.IUpdate>.Parent()
        {
            return Parent;
        }
    }
}