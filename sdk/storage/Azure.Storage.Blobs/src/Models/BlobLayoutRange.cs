// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// A byte range of a blob and the index of the endpoint in
    /// <see cref="BlobLayoutInfo.Endpoints"/> that serves it.
    /// </summary>
    internal class BlobLayoutRange
    {
        /// <summary>
        /// The start byte offset of the range.
        /// </summary>
        public long Start { get; internal set; }

        /// <summary>
        /// The end byte offset of the range, inclusive.
        /// </summary>
        public long End { get; internal set; }

        /// <summary>
        /// The <see cref="BlobLayoutEndpoint.Index"/> of the endpoint that serves this range.
        /// </summary>
        public int EndpointIndex { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of <see cref="BlobLayoutRange"/> instances.
        /// You can use <see cref="BlobsModelFactory"/> instead.
        /// </summary>
        internal BlobLayoutRange() { }
    }
}
