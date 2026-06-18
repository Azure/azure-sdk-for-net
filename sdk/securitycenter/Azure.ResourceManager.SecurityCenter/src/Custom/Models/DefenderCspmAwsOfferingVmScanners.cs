// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Compatibility customization: preserves Azure.ResourceManager.SecurityCenter 1.1.0 public API shape during the MPG migration.
    /// <summary>
    /// Provides a compatibility shim for the DefenderCspmAwsOfferingVmScanners class.
    /// </summary>
    public partial class DefenderCspmAwsOfferingVmScanners
    {
        /// <summary>
        /// Gets or sets the Configuration value preserved from the previous public API surface.
        /// </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public new Azure.ResourceManager.SecurityCenter.Models.DefenderCspmAwsOfferingVmScannersConfiguration Configuration { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
    }
}
