// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.ResourceManager.ManagedNetworkFabric.Models;

namespace Azure.ResourceManager.ManagedNetworkFabric
{
    public partial class NetworkFabricIPExtendedCommunityData
    {
        /// <summary> List of IP Extended Community Rules. </summary>
        public IList<IPExtendedCommunityRule> IPExtendedCommunityRules => IpExtendedCommunityRules;
    }
}
