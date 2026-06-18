// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // The latest TypeSpec removed or reshaped this legacy model/member, so the generator cannot recreate the previous GA signature; keep a hidden shim for ApiCompat and throw because the wire shape is no longer supported.
    /// <summary>
    /// Provides a compatibility shim for the JitNetworkAccessRequestPort class.
    /// </summary>
    public partial class JitNetworkAccessRequestPort
    {
        /// <summary>
        /// Gets or sets the EndOn value preserved from the previous public API surface.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public System.DateTimeOffset EndOn { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
    }
}
