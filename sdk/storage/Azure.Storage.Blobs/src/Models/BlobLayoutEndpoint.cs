// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// An endpoint that serves one or more ranges of a blob.
    /// </summary>
    public class BlobLayoutEndpoint
    {
        /// <summary>
        /// The index of the endpoint, referenced by <see cref="BlobLayoutRange.EndpointIndex"/>.
        /// </summary>
        public int Index { get; internal set; }

        /// <summary>
        /// The endpoint that ranges with this index should be routed to.
        /// Can be passed to <see cref="BlobDownloadOptions.LayoutEndpoint"/>.
        /// </summary>
        public Uri Value { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of <see cref="BlobLayoutEndpoint"/> instances.
        /// You can use <see cref="BlobsModelFactory"/> instead.
        /// </summary>
        internal BlobLayoutEndpoint() { }
    }
}
