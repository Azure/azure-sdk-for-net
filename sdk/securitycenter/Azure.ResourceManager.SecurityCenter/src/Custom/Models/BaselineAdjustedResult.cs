// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // The current TypeSpec renamed, nested, or removed these legacy model members, so generation omits the GA constructor/property shape; reintroduce the source-compatible member in this partial.
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
