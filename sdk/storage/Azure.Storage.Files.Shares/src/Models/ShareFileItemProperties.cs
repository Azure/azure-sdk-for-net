// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Properties of a <see cref="ShareFileItem"/>.
    /// </summary>
    public class ShareFileItemProperties
    {
        /// <summary>
        /// The time this item was created.
        /// </summary>
        public DateTimeOffset? CreatedOn { get; }

        /// <summary>
        /// The time this item was last accessed.
        /// </summary>
        public DateTimeOffset? LastAccessedOn { get; }

        /// <summary>
        /// The time this item was last written on.
        /// </summary>
        public DateTimeOffset? LastWrittenOn { get; }

        /// <summary>
        /// The time this item was changed.
        /// </summary>
        public DateTimeOffset? ChangedOn { get; }

        /// <summary>
        /// The time the item as last last modified.
        /// </summary>
        public DateTimeOffset? LastModified { get; }

        /// <summary>
        /// The ETag of the item.
        /// </summary>
        public ETag? ETag { get; }

        internal ShareFileItemProperties(
            DateTimeOffset? createdOn,
            DateTimeOffset? lastAccessedOn,
            DateTimeOffset? lastWrittenOn,
            DateTimeOffset? changedOn,
            DateTimeOffset? lastModified,
            ETag? eTag)
        {
            CreatedOn = createdOn;
            LastAccessedOn = lastAccessedOn;
            LastWrittenOn = lastWrittenOn;
            ChangedOn = changedOn;
            LastModified = lastModified;
            ETag = eTag;
        }
    }
}
