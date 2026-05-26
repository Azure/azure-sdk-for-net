// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    /// <summary> The NetworkFabricPatchablePropertiesTerminalServerConfiguration. </summary>
    // The base generated type uses Ipv4/Ipv6 casing, but this derived public type previously exposed
    // IPv4/IPv6 aliases. Removing these aliases would drop the shipped properties from the patch model.
    public partial class NetworkFabricPatchablePropertiesTerminalServerConfiguration
    {
        /// <summary> IPv4 Address Prefix. </summary>
        public string PrimaryIPv4Prefix
        {
            get => PrimaryIpv4Prefix;
            set => PrimaryIpv4Prefix = value;
        }

        /// <summary> IPv6 Address Prefix. </summary>
        public string PrimaryIPv6Prefix
        {
            get => PrimaryIpv6Prefix;
            set => PrimaryIpv6Prefix = value;
        }

        /// <summary> Secondary IPv4 Address Prefix. </summary>
        public string SecondaryIPv4Prefix
        {
            get => SecondaryIpv4Prefix;
            set => SecondaryIpv4Prefix = value;
        }

        /// <summary> Secondary IPv6 Address Prefix. </summary>
        public string SecondaryIPv6Prefix
        {
            get => SecondaryIpv6Prefix;
            set => SecondaryIpv6Prefix = value;
        }
    }
}
