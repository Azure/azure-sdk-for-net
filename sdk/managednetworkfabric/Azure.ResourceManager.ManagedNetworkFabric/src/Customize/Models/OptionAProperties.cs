// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    /// <summary> Option A properties object. </summary>
    [CodeGenType("VpnOptionAProperties")]
    public partial class OptionAProperties
    {
        /// <summary> Initializes a new instance of <see cref="OptionAProperties"/>. </summary>
        public OptionAProperties()
        {
        }

        internal OptionAProperties(int? mtu, int? vlanId, long? peerAsn, BfdConfiguration bfdConfiguration)
        {
            Mtu = mtu;
            VlanId = vlanId;
            PeerAsn = peerAsn;
            BfdConfiguration = bfdConfiguration;
        }

        /// <summary> MTU to use for option A peering. </summary>
        public int? Mtu { get; set; }
        /// <summary> VLAN identifier. </summary>
        public int? VlanId { get; set; }
        /// <summary> Peer ASN number. </summary>
        public long? PeerAsn { get; set; }
        /// <summary> BFD configuration properties. </summary>
        public BfdConfiguration BfdConfiguration { get; set; }
    }
}
