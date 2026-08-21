// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Blobs.ChangeFeed
{
    /// <summary>
    /// BlobChangeFeedExtensions.
    /// </summary>
    public static class BlobChangeFeedExtensions
    {
        /// <summary>
        /// GetChangeFeedClient.
        /// </summary>
        /// <param name="serviceClient"></param>
        /// <param name="options"></param>
        /// <returns><see cref="BlobChangeFeedClient"/>.</returns>
        public static BlobChangeFeedClient GetChangeFeedClient(
            this BlobServiceClient serviceClient,
            BlobChangeFeedClientOptions options = default)
        {
            return new BlobChangeFeedClient(serviceClient, options);
        }
    }
}
