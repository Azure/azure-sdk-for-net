// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    /// <summary> The IP Prefix patch resource definition. </summary>
    public partial class NetworkFabricIPPrefixPatch
    {
        /// <summary> The list of IP Prefix Rules. </summary>
        public IList<IPPrefixRule> IPPrefixRules => IpPrefixRules;
    }
}
