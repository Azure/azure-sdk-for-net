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
        public ExternalNetworkOptionAProperties(): this(null, null)
        {
        }

        /// <summary> Vlan identifier. Example : 501. </summary>
        public int? VlanId { get; set; }
        /// <summary> Peer ASN number.Example : 28. </summary>
        public long? PeerAsn { get; set; }
    }
}
