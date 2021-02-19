// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Storage Service Properties.
    /// </summary>
    [CodeGenModel("StorageServiceProperties")]
    public partial class BlobServiceProperties
    {
        /// <summary>
        /// The set of CORS rules.
        /// </summary>
#pragma warning disable CA2227 // Collection properties should be readonly
        public IList<BlobCorsRule> Cors { get; set; }
#pragma warning restore CA2227 // Collection properties should be readonly

        /// <summary>
        /// Creates a new BlobServiceProperties instance.
        /// </summary>
        public BlobServiceProperties() : this(false) {}

        /// <summary>
        /// Creates a new BlobServiceProperties instance.
        /// </summary>
        /// <param name="skipInitialization">Whether to skip initializing nested objects.</param>
        internal BlobServiceProperties(bool skipInitialization)
        {
            if (!skipInitialization)
            {
                Logging = new Azure.Storage.Blobs.Models.BlobAnalyticsLogging();
                HourMetrics = new Azure.Storage.Blobs.Models.BlobMetrics();
                MinuteMetrics = new Azure.Storage.Blobs.Models.BlobMetrics();
                DeleteRetentionPolicy = new Azure.Storage.Blobs.Models.BlobRetentionPolicy();
                StaticWebsite = new Azure.Storage.Blobs.Models.BlobStaticWebsite();
            }
        }
    }
}
