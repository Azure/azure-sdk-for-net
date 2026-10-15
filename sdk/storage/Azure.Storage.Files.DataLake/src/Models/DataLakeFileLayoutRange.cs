// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// A byte range of a file and the index of the endpoint in
    /// <see cref="DataLakeFileLayoutInfo.Endpoints"/> that serves it.
    /// </summary>
    public class DataLakeFileLayoutRange
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
        /// The <see cref="DataLakeFileLayoutEndpoint.Index"/> of the optimal
        /// endpoint for reads against this range.
        /// </summary>
        public int EndpointIndex { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of <see cref="DataLakeFileLayoutRange"/> instances.
        /// You can use <see cref="DataLakeModelFactory"/> instead.
        /// </summary>
        internal DataLakeFileLayoutRange() { }
    }
}
