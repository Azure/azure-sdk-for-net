// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

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
        public System.Collections.Generic.IList<string> IPPrefixes => IpPrefixes;
    }
}
