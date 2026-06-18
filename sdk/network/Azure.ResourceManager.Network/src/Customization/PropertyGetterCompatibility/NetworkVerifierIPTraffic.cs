// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the NetworkVerifierIPTraffic type. </summary>
    public partial class NetworkVerifierIPTraffic
    {
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IList<global::System.String> DestinationIPs { get; } = new global::System.Collections.Generic.List<global::System.String>();
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IList<global::System.String> SourceIPs { get; } = new global::System.Collections.Generic.List<global::System.String>();
    }
}
