// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs.Models;

namespace Azure.Storage.Blobs.ChangeFeed
{
    /// <summary>
    /// Previous info for Change Feed Event.
    /// </summary>
    public class ChangeFeedEventPreviousInfo
    {
        internal ChangeFeedEventPreviousInfo() { }

        /// <summary>
        /// Soft delete snapshot.
        /// </summary>
        public string SoftDeleteSnapshot { get; internal set; }

        /// <summary>
        /// If the blob was soft deleted.
        /// </summary>
        public bool WasBlobSoftDeleted { get; internal set; }

        /// <summary>
        /// Blob version.
        /// </summary>
        public string NewBlobVersion { get; internal set; }

        /// <summary>
        /// Last version.
        /// </summary>
        public string OldBlobVersion { get; internal set; }

        /// <summary>
        /// Previous Access Tier.
        /// </summary>
        public AccessTier? PreviousTier { get; internal set; }
    }
}
