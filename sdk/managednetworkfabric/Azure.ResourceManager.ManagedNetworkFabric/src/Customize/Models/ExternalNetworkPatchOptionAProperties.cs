// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    public partial class ExternalNetworkPatchOptionAProperties
    {
        /// <summary> Fabric ASN number. </summary>
        public long? FabricAsn => FabricASN;

        /// <summary> Peer ASN number. </summary>
        public long? PeerAsn
        {
            get => PeerASN;
            set => PeerASN = value;
        }
    }
}
