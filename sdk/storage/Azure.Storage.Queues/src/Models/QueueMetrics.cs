// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Storage.Queues.Models
{
    /// <summary>
    /// QueueMetrics.
    /// </summary>
    [CodeGenModel("Metrics")]
    public partial class QueueMetrics
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public QueueMetrics() { }

        internal QueueMetrics(bool enabled)
        {
            Enabled = enabled;
        }

        /// <summary>
        /// Indicates whether metrics should generate summary statistics for called API operations.
        /// </summary>
        [CodeGenMember("IncludeAPIs")]
        public bool? IncludeApis { get; set; }
    }
}
