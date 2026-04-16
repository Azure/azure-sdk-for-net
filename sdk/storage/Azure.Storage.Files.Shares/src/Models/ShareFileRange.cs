// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable SA1402  // File may only contain a single type

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Represents a range of bytes returned by
    /// <see cref="ShareFileClient.GetRangeListPageableAsync(ShareFileGetRangeListOptions, System.Threading.CancellationToken)"/>.
    /// </summary>
    public class ShareFileRange
    {
        /// <summary>
        /// Range in bytes of this <see cref="ShareFileRange"/>.
        /// </summary>
        public HttpRange Range { get; internal set; }

        /// <summary>
        /// Indicates whether this <see cref="ShareFileRange"/> represents a cleared range
        /// (no content) instead of a populated range.
        /// </summary>
        public bool IsClear { get; internal set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        internal ShareFileRange() { }
    }

    /// <summary>
    /// ShareModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class ShareModelFactory
    {
        /// <summary>
        /// Creates a new <see cref="ShareFileRange"/> instance for mocking.
        /// </summary>
        public static ShareFileRange ShareFileRange(
            HttpRange range,
            bool isClear)
            => new ShareFileRange
            {
                Range = range,
                IsClear = isClear
            };
    }
}
