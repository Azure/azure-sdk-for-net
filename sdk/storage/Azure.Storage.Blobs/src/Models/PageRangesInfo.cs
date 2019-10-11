// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable SA1402  // File may only contain a single type

using System.Collections.Generic;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Contains blob page range information returned from the PageBlobClient.GetPageRanges operations.
    /// </summary>
    public class PageRangesInfo
    {
        /// <summary>
        /// Model type expected by the protocol layer.
        /// </summary>
        private readonly PageRangesInfoInternal _pageRangesInfo;

        /// <summary>
        /// Returns the date and time the container was last modified. Any operation that modifies the blob, including an update of the blob's metadata or properties, changes the last-modified time of the blob.
        /// </summary>
        public System.DateTimeOffset LastModified => _pageRangesInfo.LastModified;

        /// <summary>
        /// The ETag contains a value that you can use to perform operations conditionally. If the request version is 2011-08-18 or newer, the ETag value will be in quotes.
        /// </summary>
        public ETag ETag => _pageRangesInfo.ETag;

        /// <summary>
        /// The size of the blob in bytes.
        /// </summary>
        public long BlobContentLength => _pageRangesInfo.BlobContentLength;

        /// <summary>
        /// Page ranges for the blob.
        /// </summary>
        public IEnumerable<HttpRange> PageRanges { get; internal set; }

        /// <summary>
        /// Clear ranges for the blob.
        /// </summary>
        public IEnumerable<HttpRange> ClearRanges { get; internal set; }

        /// <summary>
        /// Creates a new PageRangesInfo instance
        /// </summary>
        internal PageRangesInfo(PageRangesInfoInternal rangesInfoInternal)
        {
            _pageRangesInfo = rangesInfoInternal;

            // convert from PageRange to HttpRange
            var pageRange = new List<HttpRange>();
            foreach (PageRange range in _pageRangesInfo.Body.PageRange)
            {
                pageRange.Add(new HttpRange(range.Start, range.End - range.Start + 1));
            }
            PageRanges = pageRange;

            // convert from ClearRange to HttpRange
            var clearRange = new List<HttpRange>();
            foreach (ClearRange range in _pageRangesInfo.Body.ClearRange)
            {
                clearRange.Add(new HttpRange(range.Start, range.End - range.Start + 1));
            }
            ClearRanges = clearRange;
        }
    }

    /// <summary>
    /// BlobsModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class BlobsModelFactory
    {
        /// <summary>
        /// Creates a new PageRangesInfo instance for mocking.
        /// </summary>
        public static PageRangesInfo PageRangesInfo(
            System.DateTimeOffset lastModified,
            ETag eTag,
            long blobContentLength,
            IEnumerable<HttpRange> pageRanges,
            IEnumerable<HttpRange> clearRanges)
        {
            var pageRangesInfo =
                new PageRangesInfo(
                    new PageRangesInfoInternal()
                    {
                        LastModified = lastModified,
                        ETag = eTag,
                        BlobContentLength = blobContentLength,
                    }
                )
                {
                    PageRanges = pageRanges,
                    ClearRanges = clearRanges
                };
            return pageRangesInfo;
        }
    }
}
