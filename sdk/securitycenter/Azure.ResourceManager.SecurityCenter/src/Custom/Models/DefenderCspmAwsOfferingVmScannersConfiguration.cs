// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

using System.ComponentModel;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Generated code only emits models and members described by the current TypeSpec shape; this previous GA signature was removed, renamed, or folded into a different model, so there is no generated backing member or serialization path to implement it. Keep a hidden ApiCompat shim and fail unsupported wire operations explicitly.
    // Compatibility customization: the generated factory overload exposes an internal AzureResourceLink type after the
    // assessmentDefinitions property is hidden behind the public SubResource compatibility property below.
    // Suppress the invalid generated overload and preserve the previous public ModelFactory signature.
    /// <summary>
    /// Provides a compatibility shim for the DefenderCspmAwsOfferingVmScannersConfiguration class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class DefenderCspmAwsOfferingVmScannersConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DefenderCspmAwsOfferingVmScannersConfiguration"/> type for compatibility with the previous public API surface.
        /// </summary>
        public DefenderCspmAwsOfferingVmScannersConfiguration() { }
        /// <summary>
        /// Gets or sets the CloudRoleArn value preserved from the previous public API surface.
        /// </summary>
        public string CloudRoleArn { get; set; }
        /// <summary>
        /// Gets the ExclusionTags value preserved from the previous public API surface.
        /// </summary>
        public IDictionary<string, string> ExclusionTags { get; } = new Dictionary<string, string>();
        /// <summary>
        /// Gets or sets the ScanningMode value preserved from the previous public API surface.
        /// </summary>
        public DefenderForServersScanningMode? ScanningMode { get; set; }
    }
}
