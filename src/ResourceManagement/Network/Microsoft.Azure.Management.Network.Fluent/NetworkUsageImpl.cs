// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Fluent.Network
{
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    internal class NetworkUsageImpl : Wrapper<Usage>, INetworkUsage
    {
        public NetworkUsageImpl(Usage inner) : base(inner)
        {
        }

        public int CurrentValue
        {
            get
            {
                return (int) Inner.CurrentValue;
            }
        }

        public int Limit
        {
            get
            {
                return (int) Inner.Limit;
            }
        }

        public UsageName Name
        {
            get
            {
                return Inner.Name;
            }
        }

        public NetworkUsageUnit Unit
        {
            get
            {
                return NetworkUsageUnit.Parse(Usage.Unit);
            }
        }
    }
}
