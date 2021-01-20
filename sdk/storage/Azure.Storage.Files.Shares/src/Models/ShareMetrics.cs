// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// ShareMetrics.
    /// </summary>
    [CodeGenModel("Metrics")]
    public partial class ShareMetrics
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public ShareMetrics() { }

        /// <summary>
        /// Indicates whether metrics should generate summary statistics for called API operations.
        /// </summary>
        [CodeGenMember("IncludeAPIs")]
        public bool? IncludeApis { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        internal ShareMetrics(string version, bool enabled)
        {
            Version = version;
            Enabled = enabled;
        }
    }
}
