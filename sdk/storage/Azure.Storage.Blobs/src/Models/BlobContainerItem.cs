// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// An Azure Storage container.
    /// </summary>
    public class BlobContainerItem
    {
        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// Deleted.
        /// </summary>
        public bool? IsDeleted { get; internal set; }

        /// <summary>
        /// Version.
        /// </summary>
        public string VersionId { get; internal set; }

        /// <summary>
        /// Properties of a container.
        /// </summary>
        public BlobContainerProperties Properties { get; internal set; }

        /// <summary>
        /// Creates a new BlobContainerItem instance.
        /// </summary>
        internal BlobContainerItem() {}
    }
}
