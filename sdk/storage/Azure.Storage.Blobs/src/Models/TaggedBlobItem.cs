// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Tags = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Blob info from a FindBlobsByTags.
    /// </summary>
    public class TaggedBlobItem
    {
        /// <summary>
        /// Blob Name.
        /// </summary>
        public string BlobName { get; internal set; }

        /// <summary>
        /// Container Name.
        /// </summary>
        public string BlobContainerName { get; internal set; }

        /// <summary>
        /// Blob Tags.
        /// </summary>
        public Tags Tags { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of FilterBlobItem instances.
        /// You can use BlobsModelFactory.FilterBlobItem instead.
        /// </summary>
        internal TaggedBlobItem() { }
    }
}
