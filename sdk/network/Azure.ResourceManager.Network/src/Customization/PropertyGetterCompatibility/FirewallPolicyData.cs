// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the FirewallPolicyData type. </summary>
    public partial class FirewallPolicyData
    {
        /// <summary> Compatibility member. </summary>
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public global::System.Collections.Generic.IList<global::System.String> SnatPrivateRanges => default;
    }
}
