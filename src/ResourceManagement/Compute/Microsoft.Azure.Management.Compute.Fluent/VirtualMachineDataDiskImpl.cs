// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    /// <summary>
    /// The implementation for VirtualMachineDataDisk interface.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uVmlydHVhbE1hY2hpbmVEYXRhRGlza0ltcGw=
    internal partial class VirtualMachineDataDiskImpl :
        Wrapper<Models.DataDisk>,
        IVirtualMachineDataDisk
    {
        ///GENMHASH:8240626CF1A18F6A5466996742289188:6EE441451716A7DCFF423F19975ED54D
        internal VirtualMachineDataDiskImpl(DataDisk dataDiskInner) : base(dataDiskInner)
        {
        }

        ///GENMHASH:C19382933BDE655D0F0F95CD9474DFE7:28B657BB52464897349F96AD3FEE7B7C
        public int Size()
        {
            if (this.Inner.DiskSizeGB.HasValue)
            {
                return this.Inner.DiskSizeGB.Value;
            }
            return 0;
        }

        ///GENMHASH:2AACDDD3816365551D8FC102857D11E2:D89ABFB09517172FED352E3CE1BCA70F
        public int Lun()
        {
            return this.Inner.Lun;
        }

        ///GENMHASH:301C4791B0609BB2A3EF3CEB742CCE25:79B6BAD7C09953890526D60F9A4A6FDE
        public CachingTypes? CachingType()
        {
            return this.Inner.Caching;
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:61C1065B307679F3800C701AE0D87070
        public string Name()
        {
            return this.Inner.Name;
        }

        ///GENMHASH:529D413DA27B62CF8FA74DD34751A761:2AB50F106A2C0F2D00579F7B1825D8B0
        public StorageAccountTypes? StorageAccountType()
        {
            if (this.Inner.ManagedDisk == null) {
                return null;
            }
            return this.Inner.ManagedDisk.StorageAccountType;
        }

        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:FBF1D26DE5D0CBA789F0BA74B22FDAAC
        public string Id()
        {
            if (this.Inner.ManagedDisk == null) {
                return null;
            }
            return this.Inner.ManagedDisk.Id;
        }

        ///GENMHASH:D85E911348B4AD36294F154A7C700412:BFD5BBE75FF2933909C9A5EE4D96DB28
        public DiskCreateOptionTypes CreationMethod()
        {
            return this.Inner.CreateOption;
        }
    }
}