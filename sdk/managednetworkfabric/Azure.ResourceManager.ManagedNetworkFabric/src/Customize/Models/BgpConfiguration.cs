// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    // Backward compatibility shims for the swagger upgrade from package-2023-06-15 to package-2025-07-15.
    // The new API version added peerAsn as a required constructor parameter and changed the PeerAsn
    // property type from long? to int. This preserves the v1.1.2 parameterless constructor and
    // the long? PeerAsn property type.
    public partial class BgpConfiguration
    {
        /// <summary> Initializes a new instance of <see cref="BgpConfiguration"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BgpConfiguration() : this(default(long?))
        {
        }

        /// <summary> Peer ASN. Example: 65047. </summary>
        public long? PeerAsn { get; set; }
    }
}
