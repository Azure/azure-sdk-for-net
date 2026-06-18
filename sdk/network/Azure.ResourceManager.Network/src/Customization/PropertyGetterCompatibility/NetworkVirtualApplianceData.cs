// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the NetworkVirtualApplianceData type. </summary>
    public partial class NetworkVirtualApplianceData
    {
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Resources.Models.WritableSubResource> InternetIngressPublicIPs { get; } = new global::System.Collections.Generic.List<global::Azure.ResourceManager.Resources.Models.WritableSubResource>();
        /// <summary> Compatibility member. </summary>
        public global::System.Net.IPAddress PrivateIPAddress { get; }
    }
}
