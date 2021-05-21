// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Storage.Queues.Models
{
    /// <summary>
    /// QueueServiceStatistics.
    /// </summary>
    [CodeGenModel("Logging")]
    public partial class QueueAnalyticsLogging
    {
        internal QueueAnalyticsLogging(
            string version,
            bool delete,
            bool read,
            bool write,
            QueueRetentionPolicy retentionPolicy)
        {
            Version = version;
            Delete = delete;
            Read = read;
            Write = write;
            RetentionPolicy = retentionPolicy;
        }

        /// <summary>
        /// Creates a new QueueAnalyticsLogging instance
        /// </summary>
        public QueueAnalyticsLogging()
            : this(false)
        {
        }

        /// <summary>
        /// Creates a new QueueAnalyticsLogging instance
        /// </summary>
        /// <param name="skipInitialization">Whether to skip initializing nested objects.</param>
        internal QueueAnalyticsLogging(bool skipInitialization)
        {
            if (!skipInitialization)
            {
                RetentionPolicy = new Azure.Storage.Queues.Models.QueueRetentionPolicy();
            }
        }
    }
}
