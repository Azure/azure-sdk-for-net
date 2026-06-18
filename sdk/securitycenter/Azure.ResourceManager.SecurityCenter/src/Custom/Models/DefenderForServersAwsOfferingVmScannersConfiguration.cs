// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

using System.ComponentModel;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // The latest TypeSpec removed or reshaped this legacy model/member, so the generator cannot recreate the previous GA signature; keep a hidden shim for ApiCompat and throw because the wire shape is no longer supported.
    /// <summary>
    /// Provides a compatibility shim for the DefenderForServersAwsOfferingVmScannersConfiguration class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class DefenderForServersAwsOfferingVmScannersConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DefenderForServersAwsOfferingVmScannersConfiguration"/> type for compatibility with the previous public API surface.
        /// </summary>
        public DefenderForServersAwsOfferingVmScannersConfiguration() { }
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
