// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    public partial class ExternalNetworkOptionAProperties
    {
        /// <summary> Initializes a new instance of <see cref="ExternalNetworkOptionAProperties"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ExternalNetworkOptionAProperties() : this(default, default)
        {
        }

        /// <summary> Fabric ASN number. </summary>
        public long? FabricAsn => FabricASN;

        /// <summary> Peer ASN number. </summary>
        public long? PeerAsn
        {
            get => PeerASN;
            set => PeerASN = value.GetValueOrDefault();
        }
    }
}
