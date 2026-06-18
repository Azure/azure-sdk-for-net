// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Compatibility customization: preserves Azure.ResourceManager.SecurityCenter 1.1.0 public API shape during the MPG migration.
    /// <summary>
    /// Provides a compatibility shim for the BaselineAdjustedResult class.
    /// </summary>
    public partial class BaselineAdjustedResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaselineAdjustedResult"/> type for compatibility with the previous public API surface.
        /// </summary>
        public BaselineAdjustedResult() { }
        /// <summary>
        /// Gets or sets the Baseline value preserved from the previous public API surface.
        /// </summary>
        public SqlVulnerabilityAssessmentBaseline Baseline { get; set; }
        /// <summary>
        /// Gets or sets the Status value preserved from the previous public API surface.
        /// </summary>
        public SqlVulnerabilityAssessmentScanResultRuleStatus? Status { get; set; }
    }
}
