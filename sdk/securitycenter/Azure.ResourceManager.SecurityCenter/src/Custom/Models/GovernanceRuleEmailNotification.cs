// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // The latest TypeSpec removed or reshaped this legacy model/member, so the generator cannot recreate the previous GA signature; keep a hidden shim for ApiCompat and throw because the wire shape is no longer supported.
    /// <summary>
    /// Provides a compatibility shim for the GovernanceRuleEmailNotification class.
    /// </summary>
    public partial class GovernanceRuleEmailNotification
    {
        /// <summary>
        /// Gets or sets the IsManagerEmailNotificationDisabled value preserved from the previous public API surface.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsManagerEmailNotificationDisabled { get; set; }
        /// <summary>
        /// Gets or sets the IsOwnerEmailNotificationDisabled value preserved from the previous public API surface.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsOwnerEmailNotificationDisabled { get; set; }
    }
}
