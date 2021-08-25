// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// BlobAnalyticsLogging.
    /// </summary>
    [CodeGenModel("Logging")]
    public partial class BlobAnalyticsLogging
    {
        /// <summary>
        /// Creates a new BlobAnalyticsLogging instance.
        /// </summary>
        public BlobAnalyticsLogging() : this(false) { }

        internal BlobAnalyticsLogging(
            string version,
            bool delete,
            bool read,
            bool write,
            BlobRetentionPolicy retentionPolicy)
        {
            if (version == null)
            {
                throw new ArgumentNullException(nameof(version));
            }
            if (retentionPolicy == null)
            {
                throw new ArgumentNullException(nameof(retentionPolicy));
            }

            Version = version;
            Delete = delete;
            Read = read;
            Write = write;
            RetentionPolicy = retentionPolicy;
        }

        /// <summary>
        /// Creates a new BlobAnalyticsLogging instance
        /// </summary>
        /// <param name="skipInitialization">Whether to skip initializing nested objects.</param>
        internal BlobAnalyticsLogging(bool skipInitialization)
        {
            if (!skipInitialization)
            {
                RetentionPolicy = new Azure.Storage.Blobs.Models.BlobRetentionPolicy();
            }
        }
    }
}
