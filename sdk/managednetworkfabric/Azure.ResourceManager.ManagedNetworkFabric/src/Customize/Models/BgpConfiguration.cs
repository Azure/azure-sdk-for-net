// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    public partial class BgpConfiguration
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BgpConfiguration()
        {
            IPv4ListenRangePrefixes = new ChangeTrackingList<string>();
            IPv6ListenRangePrefixes = new ChangeTrackingList<string>();
            IPv4NeighborAddress = new ChangeTrackingList<NeighborAddress>();
            IPv6NeighborAddress = new ChangeTrackingList<NeighborAddress>();
        }

        /// <summary> Peer ASN. Example: 65047. </summary>
        public long? PeerAsn { get; set; }
    }
}
