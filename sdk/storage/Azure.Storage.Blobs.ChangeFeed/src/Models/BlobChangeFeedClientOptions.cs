// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Blobs.ChangeFeed
{
    /// <summary>
    ///  Blob Change Feed client options.
    /// </summary>
    public class BlobChangeFeedClientOptions
    {
        /// <summary>
        /// The maximum length of an transfer in bytes.
        /// </summary>
        public long? MaximumTransferSize { get; set; }
    }
}
