// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    public partial class BgpConfiguration
    {
        /// <summary> Initializes a new instance of <see cref="BgpConfiguration"/>. </summary>
        /// <param name="peerAsn"> Peer ASN. Example: 65047. </param>
        public BgpConfiguration(long peerAsn) : this()
        {
            PeerAsn = peerAsn;
        }
    }
}
