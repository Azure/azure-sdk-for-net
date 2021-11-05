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
        public BlobMetrics()
            : this(false)
        {
        }

        /// <summary>
        /// Creates a new BlobMetrics instance.
        /// </summary>
        /// <param name="skipInitialization">Whether to skip initializing nested objects.</param>
        internal BlobMetrics(bool skipInitialization)
        {
            if (!skipInitialization)
            {
                RetentionPolicy = new Azure.Storage.Blobs.Models.BlobRetentionPolicy();
            }
        }
    }
}
