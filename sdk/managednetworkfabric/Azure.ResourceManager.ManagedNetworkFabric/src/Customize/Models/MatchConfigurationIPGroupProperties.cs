// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    public partial class MatchConfigurationIPGroupProperties
    {
        /// <summary> IP Address type. </summary>
        public NetworkFabricIPAddressType? IPAddressType
        {
            get => IpAddressType;
            set => IpAddressType = value;
        }

        /// <summary> List of IP Prefixes. </summary>
        public IList<string> IPPrefixes => IpPrefixes;
    }
}
