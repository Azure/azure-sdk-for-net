// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the PeerRouteList type. </summary>
    [System.ObsoleteAttribute("This class is obsolete and will be removed in a future release, please use `PeerRoute` instead.", false)]
    public partial class PeerRouteList
    {
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IReadOnlyList<global::Azure.ResourceManager.Network.Models.PeerRoute> Value { get; } = new global::System.Collections.Generic.List<global::Azure.ResourceManager.Network.Models.PeerRoute>();
    }
}
