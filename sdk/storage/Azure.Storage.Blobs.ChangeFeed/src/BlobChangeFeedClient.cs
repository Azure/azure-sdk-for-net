// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.ChangeFeed.Models;

namespace Azure.Storage.Blobs.ChangeFeed
{
    /// <summary>
    /// BlobChangeFeedClient.
    /// </summary>
    public class BlobChangeFeedClient
    {
        private BlobServiceClient _blobServiceClient;

        /// <summary>
        /// Constructor.
        /// </summary>
        protected BlobChangeFeedClient() { }

        internal BlobChangeFeedClient(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        /// <summary>
        /// GetChanges.
        /// </summary>
        /// <returns><see cref="BlobChangeFeedPagable"/>.</returns>
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual BlobChangeFeedPagable GetChanges()
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        {
            BlobChangeFeedPagable pageable = new BlobChangeFeedPagable(
                _blobServiceClient);
            return pageable;
        }

        /// <summary>
        /// GetChanges.
        /// </summary>
        /// <param name="continuation"></param>
        /// <returns><see cref="BlobChangeFeedPagable"/>.</returns>
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual BlobChangeFeedPagable GetChanges(string continuation)
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        {
            BlobChangeFeedPagable pageable = new BlobChangeFeedPagable(
                _blobServiceClient,
                continuation);
            return pageable;
        }

        /// <summary>
        /// GetChanges.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns><see cref="BlobChangeFeedPagable"/>.</returns>
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual BlobChangeFeedPagable GetChanges(DateTimeOffset start = default, DateTimeOffset end = default)
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        {
            BlobChangeFeedPagable pageable = new BlobChangeFeedPagable(
                _blobServiceClient,
                start,
                end);
            return pageable;
        }

        /// <summary>
        /// GetChangesAsync.
        /// </summary>
        /// <returns><see cref="BlobChangeFeedAsyncPagable"/>.</returns>
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual BlobChangeFeedAsyncPagable GetChangesAsync()
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        {
            BlobChangeFeedAsyncPagable asyncPagable = new BlobChangeFeedAsyncPagable(_blobServiceClient);
            return asyncPagable;
        }

        /// <summary>
        /// GetChangesAsync.
        /// </summary>
        /// <param name="continuation"></param>
        /// <returns><see cref="BlobChangeFeedAsyncPagable"/>.</returns>
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual BlobChangeFeedAsyncPagable GetChangesAsync(string continuation)
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        {
            BlobChangeFeedAsyncPagable asyncPagable = new BlobChangeFeedAsyncPagable(_blobServiceClient,
                continuation);
            return asyncPagable;
        }

        /// <summary>
        /// GetChangesAsync.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns><see cref="BlobChangeFeedAsyncPagable"/>.</returns>
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual BlobChangeFeedAsyncPagable GetChangesAsync(
            DateTimeOffset start = default,
            DateTimeOffset end = default)
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        {
            BlobChangeFeedAsyncPagable asyncPagable = new BlobChangeFeedAsyncPagable(
                _blobServiceClient,
                start,
                end);
            return asyncPagable;
        }
    }
}