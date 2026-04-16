// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    public partial class OptionBLayer3Configuration
    {
        /// <summary> ASN of PE devices for CE/PE connectivity.Example : 28. </summary>
        public long? PeerAsn { get; set; }
        /// <summary> VLAN for CE/PE Layer 3 connectivity.Example : 501. </summary>
        public int? VlanId { get; set; }
    }
}
