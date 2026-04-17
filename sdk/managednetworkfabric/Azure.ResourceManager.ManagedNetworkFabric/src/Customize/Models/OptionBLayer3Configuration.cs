// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    // Backward compatibility shims for the swagger upgrade from package-2023-06-15 to package-2025-07-15.
    // The new API version added peerAsn and vlanId as required constructor parameters and changed their
    // property types from long?/int? to int/int. This preserves the parameterless constructor
    // and the nullable property types from v1.1.2.
    public partial class OptionBLayer3Configuration
    {
        /// <summary> Initializes a new instance of <see cref="OptionBLayer3Configuration"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public OptionBLayer3Configuration() : this(default(long?), default(int?))
        {
        }

        /// <summary> ASN of PE devices for CE/PE connectivity.Example : 28. </summary>
        public long? PeerAsn { get; set; }
        /// <summary> VLAN for CE/PE Layer 3 connectivity.Example : 501. </summary>
        public int? VlanId { get; set; }
    }
}
