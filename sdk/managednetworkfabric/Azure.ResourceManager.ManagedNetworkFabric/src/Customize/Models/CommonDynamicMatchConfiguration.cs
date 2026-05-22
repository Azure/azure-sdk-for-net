// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    public partial class CommonDynamicMatchConfiguration
    {
        /// <summary> List of IP Groups. </summary>
        public IList<MatchConfigurationIPGroupProperties> IPGroups => IpGroups;
    }
}
