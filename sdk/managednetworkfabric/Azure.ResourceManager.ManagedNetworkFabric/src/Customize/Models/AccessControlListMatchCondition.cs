// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    public partial class AccessControlListMatchCondition
    {
        /// <summary> List of IP Lengths that need to be matched. </summary>
        public IList<string> IPLengths => IpLengths;
    }
}
