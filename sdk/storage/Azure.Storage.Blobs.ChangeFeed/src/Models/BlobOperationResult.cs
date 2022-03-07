// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs.Models;

namespace Azure.Storage.Blobs.ChangeFeed
{
    /// <summary>
    /// ChangeFeedEventAsyncOperationInfo.
    /// </summary>
    public class BlobOperationResult
    {
        internal BlobOperationResult() { }

        /// <summary>
        /// DestinationAccessTier.
        /// </summary>
        public AccessTier? DestinationAccessTier { get; internal set; }

        /// <summary>
        /// If the operation was async.
        /// </summary>
        public bool IsAsync { get; internal set; }

        /// <summary>
        /// Copy Id.
        /// </summary>
        public string CopyId { get; internal set; }
    }
}
