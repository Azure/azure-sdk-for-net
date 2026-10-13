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

        // Retain the obsolete 1.15 compatibility API as local storage; it had no wire mapping then.
        // There is no current coverage field or verified replacement to connect it to.
        /// <summary> Compatibility member. </summary>
        [Obsolete("This property is obsolete and might be removed in a future version", false)]
        public DdosSettingsProtectionCoverage? ProtectionCoverage { get; set; }
    }
}
