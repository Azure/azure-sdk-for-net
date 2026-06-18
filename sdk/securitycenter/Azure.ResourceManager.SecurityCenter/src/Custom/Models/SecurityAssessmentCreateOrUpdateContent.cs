// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // The latest TypeSpec removed or reshaped this legacy model/member, so the generator cannot recreate the previous GA signature; keep a hidden shim for ApiCompat and throw because the wire shape is no longer supported.
    /// <summary>
    /// Provides a compatibility shim for the SecurityAssessmentCreateOrUpdateContent class.
    /// </summary>
    public partial class SecurityAssessmentCreateOrUpdateContent
    {
        /// <summary>
        /// Provides a compatibility shim for the NotSupportedException operation preserved from the previous public API surface.
        /// </summary>
        /// <returns>The compatibility result.</returns>
        public Uri LinksAzurePortalUri => throw new NotSupportedException("This API is no longer supported by the service.");
        /// <summary>
        /// Gets or sets the Status value preserved from the previous public API surface.
        /// </summary>
        public SecurityAssessmentStatus Status { get; set; }
    }
}
