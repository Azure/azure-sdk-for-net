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

        /// <summary>
        /// The owner user identifier (UID) of the file or directory.
        /// Only applicable to NFS shares.
        /// Supported in version 2026-12-06 and above.
        /// </summary>
        public string Owner { get; }

        /// <summary>
        /// The owner group identifier (GID) of the file or directory.
        /// Only applicable to NFS shares.
        /// Supported in version 2026-12-06 and above.
        /// </summary>
        public string Group { get; }

        /// <summary>
        /// The mode permissions of the file or directory.
        /// Only applicable to NFS shares.
        /// Supported in version 2026-12-06 and above.
        /// </summary>
        public NfsFileMode FileMode { get; }

        internal ShareFileItemProperties(
            DateTimeOffset? createdOn,
            DateTimeOffset? lastAccessedOn,
            DateTimeOffset? lastWrittenOn,
            DateTimeOffset? changedOn,
            DateTimeOffset? lastModified,
            ETag? eTag,
            string owner,
            string group,
            NfsFileMode fileMode)
        {
            CreatedOn = createdOn;
            LastAccessedOn = lastAccessedOn;
            LastWrittenOn = lastWrittenOn;
            ChangedOn = changedOn;
            LastModified = lastModified;
            ETag = eTag;

            Owner = owner;
            Group = group;
            FileMode = fileMode;
        }
    }
}
