// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the VirtualNetworkData type. </summary>
    public partial class VirtualNetworkData
    {
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IList<global::System.String> AddressPrefixes
        {
            get
            {
                AddressSpace ??= new global::Azure.ResourceManager.Network.Models.VirtualNetworkAddressSpace();
                return AddressSpace.AddressPrefixes;
            }
        }

        internal global::Azure.ResourceManager.Network.Models.DhcpOptions DhcpOptions
        {
            get => new global::Azure.ResourceManager.Network.Models.DhcpOptions(DhcpOptionsDnsServers, default);
            set
            {
                DhcpOptionsDnsServers.Clear();
                if (value is not null)
                {
                    foreach (var dnsServer in value.DnsServers)
                    {
                        DhcpOptionsDnsServers.Add(dnsServer);
                    }
                }
            }
        }
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Resources.Models.WritableSubResource> IPAllocations { get; } = new global::System.Collections.Generic.List<global::Azure.ResourceManager.Resources.Models.WritableSubResource>();
        /// <summary> Compatibility member. </summary>
        public global::System.Nullable<global::Azure.ResourceManager.Network.Models.PrivateEndpointVnetPolicy> PrivateEndpointVnetPolicy { get; set; }
    }
}
