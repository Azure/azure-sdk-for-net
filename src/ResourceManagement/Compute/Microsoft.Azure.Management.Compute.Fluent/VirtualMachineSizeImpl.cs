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

        ///GENMHASH:54DAF03887166AD77373DBD6DF3CAAE8:9DE16EE3CF4C1A1AEDF10E0F272AF8F2
        internal VirtualMachineSizeImpl (VirtualMachineSize innerModel)
        {
            this.innerModel = innerModel;
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:695A2F3ADEAF98F73A9D3DB7D6467F07
        public string Name()
        {
            return innerModel.Name;
        }

        ///GENMHASH:37DA3A355454B471775FD9E1BCDB8C8B:4249C1EA912375A38ED5A4F19994672F
        public int NumberOfCores()
        {
            return innerModel.NumberOfCores.Value;
        }

        ///GENMHASH:845FBD8ADE79EEE8EFF759CB350BCAEC:6574850C739CC5D75358E907ED488694
        public int OsDiskSizeInMB()
        {
            return innerModel.OsDiskSizeInMB.Value;
        }

        ///GENMHASH:F2AD2AC0A07F724B0BC279CCEFCF7803:FA26FC94BBB5E00C645CCF2670534C6A
        public int ResourceDiskSizeInMB()
        {
            return innerModel.ResourceDiskSizeInMB.Value;
        }

        ///GENMHASH:C3098D9CAFCB24F61E03E6540D6AA5B5:1B7F285A527F0836A4A19DD46B43120E
        public int MemoryInMB()
        {
            return innerModel.MemoryInMB.Value;
        }

        ///GENMHASH:9A2F2A9AFC20C4420484E2609EEA3C8F:F66905B778A0CFFFCDC9CAA8EB4BFA84
        public int MaxDataDiskCount()
        {
            return innerModel.MaxDataDiskCount.Value;
        }
    }
}