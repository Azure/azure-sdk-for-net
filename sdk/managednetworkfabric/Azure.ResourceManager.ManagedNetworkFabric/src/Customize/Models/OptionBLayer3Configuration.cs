// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    public partial class OptionBLayer3Configuration
    {
        /// <summary> Initializes a new instance of <see cref="OptionBLayer3Configuration"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public OptionBLayer3Configuration() : this(null, null)
        {
        }

        /// <summary> ASN of PE devices for CE/PE connectivity.Example : 28. </summary>
        public long? PeerAsn { get; set; }
        /// <summary> VLAN for CE/PE Layer 3 connectivity.Example : 501. </summary>
        public int? VlanId { get; set; }
    }
}
