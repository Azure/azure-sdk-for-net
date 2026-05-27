// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    /// <summary> OptionB Layer3 Configuration properties. </summary>
    public partial class OptionBLayer3Configuration : Layer3IPPrefixProperties
    {
        /// <summary> Initializes a new instance of <see cref="OptionBLayer3Configuration"/>. </summary>
        public OptionBLayer3Configuration()
        {
            PeLoopbackIPAddress = new ChangeTrackingList<string>();
            PrefixLimits = new ChangeTrackingList<OptionBLayer3PrefixLimitProperties>();
        }

        /// <summary> Initializes a new instance of <see cref="OptionBLayer3Configuration"/>. </summary>
        /// <param name="peerAsn"> ASN of PE devices for CE/PE connectivity. </param>
        /// <param name="vlanId"> VLAN for CE/PE Layer 3 connectivity. </param>
        public OptionBLayer3Configuration(long? peerAsn, int? vlanId) : this()
        {
            PeerAsn = peerAsn;
            VlanId = vlanId;
        }

        /// <summary> BGP Monitoring Protocol (BMP) Configuration State. </summary>
        public BmpConfigurationState? BmpConfigurationState { get; set; }

        /// <summary> ASN of CE devices for CE/PE connectivity. </summary>
        public long? FabricAsn { get; }

        /// <summary> ASN of PE devices for CE/PE connectivity. </summary>
        public long? PeerAsn { get; set; }

        /// <summary> Provider Edge (PE) Loopback IP Address. </summary>
        public IList<string> PeLoopbackIPAddress { get; }

        /// <summary> OptionB Layer3 prefix limit configuration. </summary>
        public IList<OptionBLayer3PrefixLimitProperties> PrefixLimits { get; }

        /// <summary> VLAN for CE/PE Layer 3 connectivity. </summary>
        public int? VlanId { get; set; }
    }
}
