// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// A single byte range within a <see cref="DataLakeFileLayoutRanges"/> collection
    /// that maps to a specific endpoint in <see cref="DataLakeFileLayoutEndpoints"/>.
    /// </summary>
    public class DataLakeFileLayoutRangesRangeItem
    {
        /// <summary>
        /// The starting byte offset (inclusive) of the range within the file.
        /// </summary>
        public long Start { get; internal set; }

        /// <summary>
        /// The ending byte offset (inclusive) of the range within the file.
        /// </summary>
        public long End { get; internal set; }

        /// <summary>
        /// The index into <see cref="DataLakeFileLayoutEndpoints.Endpoint"/> that
        /// identifies the optimal endpoint for reads against this range.
        /// </summary>
        public int EndpointIndex { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of <see cref="DataLakeFileLayoutRangesRangeItem"/> instances.
        /// You can use <see cref="DataLakeModelFactory"/> instead.
        /// </summary>
        internal DataLakeFileLayoutRangesRangeItem() { }
    }
}
