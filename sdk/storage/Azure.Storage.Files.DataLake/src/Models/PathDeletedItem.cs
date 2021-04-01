// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// A path that has been soft deleted.
    /// </summary>
    public class PathDeletedItem
    {
        /// <summary>
        /// The name of the path.
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// The deletion ID associated with the deleted path.
        /// </summary>
        public string DeletionId { get; internal set; }

        /// <summary>
        /// When the path was deleted.
        /// </summary>
        public DateTimeOffset? DeletedOn { get; internal set; }

        /// <summary>
        /// The number of days left before the soft deleted path will be permanently deleted.
        /// </summary>
        public int? RemainingRetentionDays { get; internal set; }

        /// <summary>
        /// Internal constructor.
        /// </summary>
        internal PathDeletedItem() { }
    }
}
