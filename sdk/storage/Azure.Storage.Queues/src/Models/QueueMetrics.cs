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
        /// Indicates whether metrics should generate summary statistics for called API operations.
        /// </summary>
        [CodeGenMember("IncludeAPIs")]
        public bool? IncludeApis { get; set; }

        /// <summary>
        /// Creates a new QueueMetrics instance
        /// </summary>
        public QueueMetrics()
            : this(false)
        {
        }

        /// <summary>
        /// Creates a new QueueMetrics instance
        /// </summary>
        /// <param name="skipInitialization">Whether to skip initializing nested objects.</param>
        internal QueueMetrics(bool skipInitialization)
        {
            if (!skipInitialization)
            {
                RetentionPolicy = new Azure.Storage.Queues.Models.QueueRetentionPolicy();
            }
        }
    }
}
