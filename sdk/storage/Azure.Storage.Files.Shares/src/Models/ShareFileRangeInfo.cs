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
        /// The date/time that the file was last modified. Any operation that modifies the file, including an update of the file's metadata or properties, changes the file's last modified time.
        /// </summary>
        public System.DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// The ETag contains a value which represents the version of the file, in quotes.
        /// </summary>
        public ETag ETag { get; internal set; }

        /// <summary>
        /// The size of the file in bytes.
        /// </summary>
        public long FileContentLength { get; internal set; }

        /// <summary>
        /// A list of non-overlapping valid ranges, sorted by increasing address range.
        /// </summary>
        public IEnumerable<HttpRange> Ranges { get; internal set; }

        /// <summary>
        /// Clear ranges for the file.
        /// </summary>
        public IEnumerable<HttpRange> ClearRanges { get; internal set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        internal ShareFileRangeInfo() { }
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
            => new ShareFileRangeInfo
            {
                LastModified = lastModified,
                ETag = eTag,
                FileContentLength = fileContentLength,
                Ranges = ranges
            };
    }
}
