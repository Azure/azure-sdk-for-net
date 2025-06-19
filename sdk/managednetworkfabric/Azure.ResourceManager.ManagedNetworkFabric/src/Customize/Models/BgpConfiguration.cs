// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    public partial class BgpConfiguration
    {
        /// <summary> Initializes a new instance of <see cref="BgpConfiguration"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BgpConfiguration() : this(null)
        {
        }

        /// <summary> Peer ASN. Example: 65047. </summary>
        public long? PeerAsn { get; set; }
    }
}
