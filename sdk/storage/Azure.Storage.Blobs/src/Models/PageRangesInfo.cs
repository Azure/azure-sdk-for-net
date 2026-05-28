// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable SA1402  // File may only contain a single type

using System;
using System.Collections.Generic;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Contains blob page range information returned from the PageBlobClient.GetPageRanges operations.
    /// </summary>
    public class PageRangesInfo
    {
        /// <summary>
        /// Returns the date and time the container was last modified. Any operation that modifies the blob,
        /// including an update of the blob's metadata or properties, changes the last-modified time of the blob.
        /// </summary>
        public DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// The ETag contains a value that you can use to perform operations conditionally.
        /// If the request version is 2011-08-18 or newer, the ETag value will be in quotes.
        /// </summary>
        public ETag ETag { get; internal set; }

        /// <summary>
        /// The size of the blob in bytes.
        /// </summary>
        public long BlobContentLength { get; internal set; }

        /// <summary>
        /// Page ranges for the blob.
        /// </summary>
        public IEnumerable<HttpRange> PageRanges { get; internal set; }

        /// <summary>
        /// Clear ranges for the blob.
        /// </summary>
        public IEnumerable<HttpRange> ClearRanges { get; internal set; }

        /// <summary>
        /// Creates a new PageRangesInfo instance.
        /// </summary>
        internal PageRangesInfo() {}
    }
}
