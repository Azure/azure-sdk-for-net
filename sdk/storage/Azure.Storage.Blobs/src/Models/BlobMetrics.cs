// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// BlobMetrics.
    /// </summary>
    [CodeGenType("Metrics")]
    public partial class BlobMetrics
    {
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
