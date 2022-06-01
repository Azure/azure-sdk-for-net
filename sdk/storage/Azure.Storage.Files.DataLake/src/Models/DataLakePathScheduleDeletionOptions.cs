// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Options for scheduling the deletion of a path.
    /// </summary>
    public class DataLakePathScheduleDeletionOptions
    {
        /// <summary>
        /// Duration before file should be deleted.
        /// Does not apply to directories.
        /// <see cref="TimeToExpire"/> and <see cref="ExpiresOn"/> cannot both be set.
        /// </summary>
        public TimeSpan? TimeToExpire { get; set; }

        /// <summary>
        /// The <see cref="DateTimeOffset"/> to set for when
        /// the file will be deleted.  If null, the existing
        /// ExpiresOn time on the file will be removed, if it exists.
        /// Does not apply to directories.
        /// <see cref="ExpiresOn"/> and <see cref="TimeToExpire"/> cannot both be set.
        /// </summary>
        public DateTimeOffset? ExpiresOn { get; set; }
    }
}
