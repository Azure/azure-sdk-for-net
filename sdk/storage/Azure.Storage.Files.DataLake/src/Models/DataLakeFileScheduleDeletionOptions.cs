// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Parameters for Schedule Deletion.
    /// </summary>
    public class DataLakeFileScheduleDeletionOptions
    {
        /// <summary>
        /// Duration before file should be deleted.
        /// </summary>
        public TimeSpan? TimeToExpire { get; private set; }

        /// <summary>
        /// Specifies if TimeToExpire should be
        /// set relative to the file's creation time, or the current
        /// time.  Defaults to current time.
        /// </summary>
        public DataLakeFileExpirationOrigin? SetExpiryRelativeTo { get; private set; }

        /// <summary>
        /// The <see cref="DateTimeOffset"/> to set for when
        /// the file will be deleted.  If null, the existing
        /// ExpiresOn time on the file will be removed, if it exists.
        /// </summary>
        public DateTimeOffset? ExpiresOn { get; private set; }

        /// <summary>
        /// Optional. Sets the priority of this request, from 0 through 7.
        /// If not set, or if the value is outside that range, the service uses 3.
        /// </summary>
        public int? RequestPriority { get; set; }

        /// <summary>
        /// Constructor.  Sets the <see cref="DateTimeOffset"/> when the file will
        /// be deleted.
        /// </summary>
        /// <param name="expiresOn">
        /// The DateTimeOffset when the file will be deleted.
        /// If null, if the file was already scheduled for deletion,
        /// the deletion will be cancelled.
        /// </param>
        public DataLakeFileScheduleDeletionOptions(DateTimeOffset? expiresOn)
        {
            ExpiresOn = expiresOn;
        }

        /// <summary>
        /// Constructor.  Sets time when the file will be deleted, relative to the file
        /// creation time or the current time.
        /// </summary>
        /// <param name="timeToExpire">
        /// Duration before file will be deleted.
        /// </param>
        /// <param name="setRelativeTo">
        /// Specifies if TimeToExpire should be
        /// set relative to the file's creation time, or the current
        /// time.  Defaults to current time.
        /// </param>
        public DataLakeFileScheduleDeletionOptions(TimeSpan timeToExpire, DataLakeFileExpirationOrigin setRelativeTo)
        {
            TimeToExpire = timeToExpire;
            SetExpiryRelativeTo = setRelativeTo;
        }

        /// <summary>
        /// Constructor.  If the file was scheduled for deletetion, the deletion will be cancelled.
        /// </summary>
        public DataLakeFileScheduleDeletionOptions()
        {
        }
    }
}
