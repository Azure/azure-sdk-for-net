// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // The latest TypeSpec removed or reshaped this legacy model/member, so the generator cannot recreate the previous GA signature; keep a hidden shim for ApiCompat and throw because the wire shape is no longer supported.
    /// <summary>
    /// Provides a compatibility shim for the GovernanceEmailNotification class.
    /// </summary>
    public partial class GovernanceEmailNotification
    {
        /// <summary>
        /// Gets or sets the IsManagerEmailNotificationDisabled value preserved from the previous public API surface.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsManagerEmailNotificationDisabled { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Gets or sets the IsOwnerEmailNotificationDisabled value preserved from the previous public API surface.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsOwnerEmailNotificationDisabled { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
    }
}
