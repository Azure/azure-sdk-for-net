// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Blobs.ChangeFeed.Models
{
    /// <summary>
    /// BlobChangeFeedEventType.
    /// </summary>
    public enum BlobChangeFeedEventType
    {
        /// <summary>
        /// Blob created.
        /// </summary>
        BlobCreated = 0,

        /// <summary>
        /// Blob deleted.
        /// </summary>
        BlobDeleted = 1,
    }
}