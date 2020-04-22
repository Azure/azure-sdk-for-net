// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Parameters for Schedule Deletion.
    /// </summary>
    public class BlobScheduleDeletionOptions
    {
        /// <summary>
        /// Duration before blob should be deleted.
        /// </summary>
        public TimeSpan? TimeToExpire { get; private set; }

        /// <summary>
        /// Specifies if TimeToExpire should be
        /// set relative to the blob's creation time, or the current
        /// time.  Defaults to current time.
        /// </summary>
        public BlobExpirationOffset? SetExpiryRelativeTo { get; private set; }

        /// <summary>
        /// The <see cref="DateTimeOffset"/> to set for when
        /// the blob will be deleted.  If null, the existing
        /// ExpiresOn time on the blob will be removed, if it exists.
        /// </summary>
        public DateTimeOffset? ExpiresOn { get; private set; }

        /// <summary>
        /// Constructor.  Sets the <see cref="DateTimeOffset"/> when the blob will
        /// be deleted.
        /// </summary>
        /// <param name="expiresOn">
        /// The DateTimeOffset when the blob will be deleted.
        /// </param>
        public BlobScheduleDeletionOptions(DateTimeOffset? expiresOn)
        {
            ExpiresOn = expiresOn;
        }

        /// <summary>
        /// Constructor.  Sets time when the blob will be deleted, relative to the blob
        /// creation time or the current time.
        /// </summary>
        /// <param name="timeToExpire">
        /// Duration before blob will be deleted.
        /// </param>
        /// <param name="setRelativeTo">
        /// Specifies if TimeToExpire should be
        /// set relative to the blob's creation time, or the current
        /// time.
        /// </param>
        public BlobScheduleDeletionOptions(TimeSpan timeToExpire, BlobExpirationOffset setRelativeTo)
        {
            TimeToExpire = timeToExpire;
            SetExpiryRelativeTo = setRelativeTo;
        }

        /// <summary>
        /// Constructor.  If the blob was scheduled for deletetion, the deletion will be cancelled.
        /// </summary>
        public BlobScheduleDeletionOptions()
        {
        }
    }
}
