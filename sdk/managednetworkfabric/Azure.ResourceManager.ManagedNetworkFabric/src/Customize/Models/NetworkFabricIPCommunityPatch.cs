// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    /// <summary> The IP Community patch resource definition. </summary>
    public partial class NetworkFabricIPCommunityPatch
    {
        /// <summary> List of IP Community Rules. </summary>
        public IList<IPCommunityRule> IPCommunityRules => IpCommunityRules;
    }
}
