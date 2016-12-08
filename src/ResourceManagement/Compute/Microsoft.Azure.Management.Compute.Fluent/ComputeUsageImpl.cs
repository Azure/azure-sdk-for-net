// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Management.Fluent.Compute;

    /// <summary>
    /// The implementation of ComputeUsage.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uQ29tcHV0ZVVzYWdlSW1wbA==
    internal partial class ComputeUsageImpl :
        Wrapper<Usage>,
        IComputeUsage
    {
        ///GENMHASH:98D67B93923AC46ECFE338C62748BCCB:AE70F51B2F784C2A02F858F867A2AA34
        public ComputeUsageUnit Unit()
        {
            return new ComputeUsageUnit(Usage.Unit);
        }

        ///GENMHASH:A5E7AF81C3FDCACFFFE1D6B50B56161F:C0C35E00AF4E17F141675A2C05C7067B
        internal ComputeUsageImpl(Usage innerObject) : base(innerObject)
        {
        }

        ///GENMHASH:9D196E486CC1E35756FD0BEDAB3F3BE4:D46EE1115C895668AEAF34537890C3E6
        public int Limit()
        {
            return (int) Inner.Limit;
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:0EDBC6F12844C2F2056BFF916F51853B
        public Models.UsageName Name()
        {
            return Inner.Name;
        }

        ///GENMHASH:4CC577A7C618816C07F6CE452B96D1E6:29527C7282619FD9197A428D8ADA0490
        public int CurrentValue()
        {
            return  Inner.CurrentValue;
        }
    }
}