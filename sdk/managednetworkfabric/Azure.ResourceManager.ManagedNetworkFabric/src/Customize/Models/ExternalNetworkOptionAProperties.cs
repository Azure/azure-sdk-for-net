// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    // Backward compatibility shims for the swagger upgrade from package-2023-06-15 to package-2025-07-15.
    // The new API version added vlanId and peerAsn as required constructor parameters and changed their
    // property types from int?/long? to int/int. This preserves the v1.1.2 parameterless constructor
    // and the nullable property types.
    public partial class ExternalNetworkOptionAProperties
    {
        /// <summary> Initializes a new instance of <see cref="ExternalNetworkOptionAProperties"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ExternalNetworkOptionAProperties() : this(default(int?), default(long?))
        {
        }

        /// <summary> Vlan identifier. Example : 501. </summary>
        public int? VlanId { get; set; }
        /// <summary> Peer ASN number.Example : 28. </summary>
        public long? PeerAsn { get; set; }
    }
}
