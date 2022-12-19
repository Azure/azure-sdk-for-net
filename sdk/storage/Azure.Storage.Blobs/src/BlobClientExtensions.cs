// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;

namespace Azure.Storage.Blobs
{
    /// <summary>
    /// Add easy to discover methods to <see cref="BlobBaseClient"/> and it's derived
    /// clients.
    /// </summary>
    public static class BlobClientExtensions
    {
        #region Blob Item To Blob Client

        /// <summary>
        /// Create a new <see cref="BlobBaseClient"/> object based on the properties
        /// of the <paramref name="blobItem"/>.  The
        /// new <see cref="BlobBaseClient"/> uses the same request policy
        /// pipeline as the <see cref="BlobContainerClient"/>.
        /// </summary>
        /// <param name="blobItem"></param>
        /// <param name="withVersion"></param>
        /// <param name="withSnapshot"></param>
        public static BlobBaseClient ToBlobBaseClient(
            this BlobItem blobItem,
            bool withVersion = false,
            bool withSnapshot = false)
        {
            return blobItem._containerClient.GetBlobBaseClientCore(blobItem, withVersion, withSnapshot);
        }

        /// <summary>
        /// Create a new <see cref="BlobBaseClient"/> object based on the properties
        /// of the <paramref name="blobItem"/>.  The
        /// new <see cref="BlobBaseClient"/> uses the same request policy
        /// pipeline as the <see cref="BlobContainerClient"/>.
        /// </summary>
        /// <param name="blobItem"></param>
        /// <param name="withVersion"></param>
        /// <param name="withSnapshot"></param>
        public static PageBlobClient ToPageBlobClient(
            this BlobItem blobItem,
            bool withVersion = false,
            bool withSnapshot = false)
        {
            return blobItem._containerClient.GetPageBlobClientCore(blobItem, withVersion, withSnapshot);
        }
        #endregion Blob Item To Blob Client
    }
}
