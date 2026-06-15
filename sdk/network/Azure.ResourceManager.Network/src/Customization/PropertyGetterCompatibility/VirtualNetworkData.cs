// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0612, CS0618, CS1591

namespace Azure.ResourceManager.Network
{
    public partial class VirtualNetworkData
    {
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
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Resources.Models.WritableSubResource> IPAllocations => default;
        public global::System.Nullable<global::Azure.ResourceManager.Network.Models.PrivateEndpointVnetPolicy> PrivateEndpointVnetPolicy
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }
}
