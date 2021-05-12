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
        internal ShareFileItemProperties() { }

        /// <summary>
        /// The time this item was created.
        /// </summary>
        public DateTimeOffset? CreatedOn { get; internal set; }

        /// <summary>
        /// The time this item was last accessed.
        /// </summary>
        public DateTimeOffset? LastAccessedOn { get; internal set; }

        /// <summary>
        /// The time this item was last written on.
        /// </summary>
        public DateTimeOffset? LastWrittenOn { get; internal set; }

        /// <summary>
        /// The time this time was changed.
        /// </summary>
        public DateTimeOffset? ChangedOn { get; internal set; }

        /// <summary>
        /// The time the item as last last modified.
        /// </summary>
        public DateTimeOffset? LastModified { get; internal set; }

        /// <summary>
        /// The ETag of the item.
        /// </summary>
        public ETag? ETag { get; internal set; }
    }
}
