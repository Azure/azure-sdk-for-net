// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the DdosSettings type. </summary>
    public partial class DdosSettings
    {
        // Preserve the 1.15 behavioral alias, including null and unknown protection modes.
        /// <summary> Compatibility member. </summary>
        [Obsolete("This property is obsolete and might be removed in a future version, use ProtectionMode instead", false)]
        public bool? ProtectedIP
        {
            get => ProtectionMode != DdosSettingsProtectionMode.Disabled;
            set => ProtectionMode = value == true ? DdosSettingsProtectionMode.Enabled : DdosSettingsProtectionMode.Disabled;
        }
        /// <summary> Compatibility member. </summary>
        [Obsolete("This property is obsolete and might be removed in a future version, please use `TagToIPAddresses` instead", false)]
        public DdosSettingsProtectionCoverage? ProtectionCoverage { get; set; }
    }
}
