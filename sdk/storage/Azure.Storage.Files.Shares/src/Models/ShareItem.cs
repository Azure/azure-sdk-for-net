// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// A listed Azure Storage share item.
    /// </summary>
    public class ShareItem
    {
        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// Snapshot.
        /// </summary>
        public string Snapshot { get; internal set; }

        /// <summary>
        /// Deleted.
        /// </summary>
        public bool? IsDeleted { get; internal set; }

        /// <summary>
        /// Version.
        /// </summary>
        public string VersionId { get; internal set; }

        /// <summary>
        /// Properties of a share.
        /// </summary>
        public ShareProperties Properties { get; internal set; }

        /// <summary>
        /// Internal constructor.
        /// </summary>
        internal ShareItem() { }
    }
}
