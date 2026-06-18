// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the DdosCustomPolicyData type. </summary>
    public partial class DdosCustomPolicyData
    {
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Resources.Models.WritableSubResource> FrontEndIPConfiguration { get; } = new global::System.Collections.Generic.List<global::Azure.ResourceManager.Resources.Models.WritableSubResource>();
        /// <summary> Compatibility member. </summary>
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release", false)]
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.Models.ProtocolCustomSettings> ProtocolCustomSettings { get; } = new global::System.Collections.Generic.List<global::Azure.ResourceManager.Network.Models.ProtocolCustomSettings>();
    }
}
