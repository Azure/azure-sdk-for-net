// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// The details and Content returned from downloading a blob.
    /// </summary>
    public class BlobDownloadResult
    {
        internal BlobDownloadResult() { }

        /// <summary>
        /// Details returned when downloading a Blob
        /// </summary>
        public BlobDownloadDetails Details { get; internal set; }

        /// <summary>
        /// Content.
        /// </summary>
        public BinaryData Content { get; internal set; }
    }
}
