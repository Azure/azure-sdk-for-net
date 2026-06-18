// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Compatibility customization: preserves Azure.ResourceManager.SecurityCenter 1.1.0 public API shape during the MPG migration.
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
