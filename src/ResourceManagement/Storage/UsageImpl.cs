// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Storage.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Storage.Fluent.Models;

    /// <summary>
    /// The implementation of  UsageInner.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnN0b3JhZ2UuaW1wbGVtZW50YXRpb24uVXNhZ2VJbXBs
    internal partial class UsageImpl : Wrapper<Models.Usage>, IStorageUsage
    {
        ///GENMHASH:2C82132661E1D40D14D20AEB0584B069:C0C35E00AF4E17F141675A2C05C7067B
        internal UsageImpl(Usage innerObject) : base(innerObject)
        { }
        
        ///GENMHASH:98D67B93923AC46ECFE338C62748BCCB:D1F0AC3814BC079D6D64A1420781A355
        public UsageUnit Unit()
        {
            return Inner.Unit.HasValue ? Inner.Unit.Value : default(UsageUnit);
        }

        ///GENMHASH:9D196E486CC1E35756FD0BEDAB3F3BE4:A17BF262D4289291AFE4CC9415BA443D
        public int Limit()
        {
            return Inner.Limit.HasValue ? Inner.Limit.Value : default(int);
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:0EDBC6F12844C2F2056BFF916F51853B
        public UsageName Name()
        {
            return Inner.Name;
        }

        ///GENMHASH:4CC577A7C618816C07F6CE452B96D1E6:B99E952C0969423EA5E48127FF2189C7
        public int CurrentValue()
        {
            return Inner.CurrentValue.HasValue ? Inner.CurrentValue.Value : default(int);
        }
    }
}