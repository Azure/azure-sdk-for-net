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

        /// <summary>
        /// Creates a new ShareMetrics instance.
        /// </summary>
        public ShareMetrics()
            : this(false)
        {
        }

        /// <summary>
        /// Creates a new ShareMetrics instance.
        /// </summary>
        /// <param name="skipInitialization">Whether to skip initializing nested objects.</param>
        internal ShareMetrics(bool skipInitialization)
        {
            if (!skipInitialization)
            {
                RetentionPolicy = new Azure.Storage.Files.Shares.Models.ShareRetentionPolicy();
            }
        }
    }
}
