// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    public partial class OptionBLayer3Configuration
    {
        /// <summary> Initializes a new instance of <see cref="OptionBLayer3Configuration"/>. </summary>
        /// <param name="peerAsn"> ASN of PE devices for CE/PE connectivity.Example : 28. </param>
        /// <param name="vlanId"> VLAN for CE/PE Layer 3 connectivity.Example : 501. </param>
        public OptionBLayer3Configuration(long peerAsn, int vlanId)
        {
            PeerAsn = peerAsn;
            VlanId = vlanId;
        }
    }
}
