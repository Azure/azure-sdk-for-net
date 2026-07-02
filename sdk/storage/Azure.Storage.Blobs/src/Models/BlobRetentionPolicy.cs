// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// BlobRetentionPolicy.
    /// </summary>
    [CodeGenType("RetentionPolicy")]
    public partial class BlobRetentionPolicy
    {
        /// <summary>
        /// Creates a new BlobRetentionPolicy instance.
        /// </summary>
        public BlobRetentionPolicy() { }

        internal BlobRetentionPolicy(bool enabled)
        {
            Enabled = enabled;
        }

        /// <summary>
        /// Indicates whether permanent delete is allowed on this storage account.
        /// </summary>
        internal bool? AllowPermanentDelete { get; set; }
    }
}
