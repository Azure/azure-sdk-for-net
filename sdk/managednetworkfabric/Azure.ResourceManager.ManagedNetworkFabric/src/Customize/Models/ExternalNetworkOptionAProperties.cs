// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    public partial class ExternalNetworkOptionAProperties
    {
        /// <summary> Initializes a new instance of <see cref="ExternalNetworkOptionAProperties"/>. </summary>
        /// <param name="vlanId"> Vlan identifier. Example : 501. </param>
        /// <param name="peerAsn"> Peer ASN number.Example : 28. </param>
        public ExternalNetworkOptionAProperties(int vlanId, long peerAsn)
        {
            VlanId = vlanId;
            PeerAsn = peerAsn;
        }
    }
}
