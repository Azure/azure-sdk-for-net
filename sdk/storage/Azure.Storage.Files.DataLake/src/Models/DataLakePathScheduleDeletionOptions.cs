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
        public TimeSpan? TimeToExpire { get; private set; }

        /// <summary>
        /// The <see cref="DateTimeOffset"/> to set for when
        /// the file will be deleted.  If null, the existing
        /// ExpiresOn time on the file will be removed, if it exists.
        /// Does not apply to directories.
        /// <see cref="ExpiresOn"/> and <see cref="TimeToExpire"/> cannot both be set.
        /// </summary>
        public DateTimeOffset? ExpiresOn { get; private set; }

        /// <summary>
        /// Constructor.  Sets the <see cref="DateTimeOffset"/> when the path will
        /// be deleted.
        /// </summary>
        /// <param name="expiresOn">
        /// The DateTimeOffset when the file will be deleted.
        /// </param>
        public DataLakePathScheduleDeletionOptions(DateTimeOffset? expiresOn)
        {
            ExpiresOn = expiresOn;
        }

        /// <summary>
        /// Constructor.  Sets time when the path will be deleted, relative to the current time.
        /// </summary>
        /// <param name="timeToExpire">
        /// Duration before path will be deleted.
        /// </param>
        public DataLakePathScheduleDeletionOptions(TimeSpan? timeToExpire)
        {
            TimeToExpire = timeToExpire;
        }
    }
}
