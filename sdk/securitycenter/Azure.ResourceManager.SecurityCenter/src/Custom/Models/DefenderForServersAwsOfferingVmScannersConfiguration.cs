// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0618
#pragma warning disable CS0169
#pragma warning disable SA1508
#pragma warning disable SA1516
#pragma warning disable CA1822

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Compatibility customization: preserves Azure.ResourceManager.SecurityCenter 1.1.0 public API shape during the MPG migration.
    /// <summary>
    /// Provides a compatibility shim for the DefenderForServersAwsOfferingVmScannersConfiguration class.
    /// </summary>
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class DefenderForServersAwsOfferingVmScannersConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DefenderForServersAwsOfferingVmScannersConfiguration"/> type for compatibility with the previous public API surface.
        /// </summary>
        public DefenderForServersAwsOfferingVmScannersConfiguration() { }
        /// <summary>
        /// Gets or sets the CloudRoleArn value preserved from the previous public API surface.
        /// </summary>
        public string CloudRoleArn { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Gets the ExclusionTags value preserved from the previous public API surface.
        /// </summary>
        public System.Collections.Generic.IDictionary<string, string> ExclusionTags { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Gets or sets the ScanningMode value preserved from the previous public API surface.
        /// </summary>
        public Azure.ResourceManager.SecurityCenter.Models.DefenderForServersScanningMode? ScanningMode { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
    }
}
