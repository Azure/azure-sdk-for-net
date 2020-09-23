// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable SA1402  // File may only contain a single type

using System.Collections.Generic;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Contains file share range information returned from the ShareFileClient.GetRangeList operations.
    /// </summary>
    public class ShareFileRangeInfo
    {
        /// <summary>
        /// Model type expected by the protocol layer.
        /// </summary>
        private readonly ShareFileRangeInfoInternal _shareFileRangeInfoInternal;

        /// <summary>
        /// The date/time that the file was last modified. Any operation that modifies the file, including an update of the file's metadata or properties, changes the file's last modified time.
        /// </summary>
        public System.DateTimeOffset LastModified => _shareFileRangeInfoInternal.LastModified;

        /// <summary>
        /// The ETag contains a value which represents the version of the file, in quotes.
        /// </summary>
        public ETag ETag => _shareFileRangeInfoInternal.ETag;

        /// <summary>
        /// The size of the file in bytes.
        /// </summary>
        public long FileContentLength => _shareFileRangeInfoInternal.FileContentLength;

        /// <summary>
        /// A list of non-overlapping valid ranges, sorted by increasing address range.
        /// </summary>
        public IEnumerable<HttpRange> Ranges { get; internal set; }

        /// <summary>
        /// Clear ranges for the file.
        /// </summary>
        public IEnumerable<HttpRange> ClearRanges { get; internal set; }

        /// <summary>
        /// Creates a new PageRangesInfo instance
        /// </summary>
        internal ShareFileRangeInfo(ShareFileRangeInfoInternal rangesInfoInternal)
        {
            _shareFileRangeInfoInternal = rangesInfoInternal;

            // convert from internal Range type to HttpRange
            List<HttpRange> ranges = new List<HttpRange>();
            foreach (FileRange range in rangesInfoInternal.Body.Ranges)
            {
                ranges.Add(new HttpRange(range.Start, range.End - range.Start + 1));
            }
            Ranges = ranges;

            List<HttpRange> clearRanges = new List<HttpRange>();
            foreach (ClearRange clearRange in rangesInfoInternal.Body.ClearRanges)
            {
                clearRanges.Add(new HttpRange(clearRange.Start, clearRange.End - clearRange.Start + 1));
            }

            ClearRanges = clearRanges;
        }
    }

    /// <summary>
    /// ShareModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class ShareModelFactory
    {
        /// <summary>
        /// Creates a new ShareFileRangeInfo instance for mocking.
        /// </summary>
        public static ShareFileRangeInfo ShareFileRangeInfo(
            System.DateTimeOffset lastModified,
            Azure.ETag eTag,
            long fileContentLength,
            IEnumerable<HttpRange> ranges)
        {
            var shareFileRangeInfo =
                new ShareFileRangeInfo(
                    new ShareFileRangeInfoInternal()
                    {
                        LastModified = lastModified,
                        ETag = eTag,
                        FileContentLength = fileContentLength
                    }
                )
                {
                    Ranges = ranges
                };
            return shareFileRangeInfo;
        }
    }
}
