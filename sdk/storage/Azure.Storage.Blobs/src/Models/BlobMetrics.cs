// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// BlobMetrics.
    /// </summary>
    [CodeGenModel("Metrics")]
    public partial class BlobMetrics
    {
        /// <summary>
        /// Indicates whether metrics should generate summary statistics for called API operations.
        /// </summary>
        [CodeGenMember("IncludeAPIs")]
        public bool? IncludeApis { get; set; }

        /// <summary>
        /// Creates a new BlobMetrics instance.
        /// </summary>
        public BlobMetrics() { }

        internal BlobMetrics(bool enabled)
        {
            Enabled = enabled;
        }
    }
}
