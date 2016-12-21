// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Models;

    /// <summary>
    /// The implementation for VirtualMachineSize.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uVmlydHVhbE1hY2hpbmVTaXplSW1wbA==
    internal partial class VirtualMachineSizeImpl :
        IVirtualMachineSize
    {
        private VirtualMachineSize innerModel;

        internal VirtualMachineSizeImpl (VirtualMachineSize innerModel)
        {
            this.innerModel = innerModel;
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:695A2F3ADEAF98F73A9D3DB7D6467F07
        public string Name()
        {
            return innerModel.Name;
        }

        ///GENMHASH:37DA3A355454B471775FD9E1BCDB8C8B:E2B0626BB8660CB2912F6B537C6C2776
        public int NumberOfCores()
        {
            return innerModel.NumberOfCores.Value;
        }

        ///GENMHASH:845FBD8ADE79EEE8EFF759CB350BCAEC:D44E5029C8A19439E10477CD39524531
        public int OsDiskSizeInMB()
        {
            return innerModel.OsDiskSizeInMB.Value;
        }

        ///GENMHASH:F2AD2AC0A07F724B0BC279CCEFCF7803:58426CC2D4F69A8C462B9C10F5482042
        public int ResourceDiskSizeInMB()
        {
            return innerModel.ResourceDiskSizeInMB.Value;
        }

        ///GENMHASH:C3098D9CAFCB24F61E03E6540D6AA5B5:EFF8100377F022ECFD2249059345D971
        public int MemoryInMB()
        {
            return innerModel.MemoryInMB.Value;
        }

        ///GENMHASH:9A2F2A9AFC20C4420484E2609EEA3C8F:828EF41F231ACEDE2285509939EB2438
        public int MaxDataDiskCount()
        {
            return innerModel.MaxDataDiskCount.Value;
        }
    }
}
