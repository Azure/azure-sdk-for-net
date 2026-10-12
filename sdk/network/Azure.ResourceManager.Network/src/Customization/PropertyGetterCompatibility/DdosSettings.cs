// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the DdosSettings type. </summary>
    public partial class DdosSettings
    {
        /// <summary> Compatibility member. </summary>

        [System.ObsoleteAttribute("This property is obsolete and might be removed in a future version, please use `TagToIPAddresses` instead", false)]
        public global::System.Nullable<global::System.Boolean> ProtectedIP { get; set; }
        /// <summary> Compatibility member. </summary>
        [System.ObsoleteAttribute("This property is obsolete and might be removed in a future version, please use `TagToIPAddresses` instead", false)]
        public global::System.Nullable<global::Azure.ResourceManager.Network.Models.DdosSettingsProtectionCoverage> ProtectionCoverage { get; set; }
    }
}
