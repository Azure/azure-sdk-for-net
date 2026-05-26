// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    /// <summary> BGP configuration properties. </summary>
    public partial class BgpConfiguration
    {
        /// <summary> Initializes a new instance of <see cref="BgpConfiguration"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BgpConfiguration()
            : this(default)
        {
        }

        /// <summary> ASN of Network Fabric. </summary>
        public long? FabricAsn => FabricASN;

        /// <summary> Peer ASN. </summary>
        public long? PeerAsn
        {
            get => PeerASN;
            set => PeerASN = value.GetValueOrDefault();
        }
    }
}
