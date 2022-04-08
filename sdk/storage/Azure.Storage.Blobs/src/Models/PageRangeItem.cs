// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs.Specialized;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Represents a range of bytes returned by <see cref="PageBlobClient.GetAllPageRangesAsync(GetPageRangesOptions, System.Threading.CancellationToken)"/>.
    /// </summary>
    public class PageRangeItem
    {
        /// <summary>
        /// Range in bytes of this PageBlobRange.
        /// </summary>
        public HttpRange Range { get; internal set; }

        /// <summary>
        /// Indicates if this PageBlobRange is empty bytes.
        /// </summary>
        public bool IsClear { get; internal set; }
    }
}
