// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
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
        /// Initializes a new instance of the <see cref="BlobChangeFeedClient"/>
        /// class.
        /// </summary>
        /// <param name="connectionString">
        /// A connection string includes the authentication information
        /// required for your application to access data in an Azure Storage
        /// account at runtime.
        ///
        /// For more information, <see href="https://docs.microsoft.com/en-us/azure/storage/common/storage-configure-connection-string"/>.
        /// </param>
        public BlobChangeFeedClient(string connectionString)
        {
            _blobServiceClient = new BlobServiceClient(connectionString);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobChangeFeedClient"/>
        /// class.
        /// </summary>
        /// <param name="connectionString">
        /// A connection string includes the authentication information
        /// required for your application to access data in an Azure Storage
        /// account at runtime.
        ///
        /// For more information, <see href="https://docs.microsoft.com/en-us/azure/storage/common/storage-configure-connection-string"/>.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public BlobChangeFeedClient(string connectionString, BlobClientOptions options)

        {
            _blobServiceClient = new BlobServiceClient(connectionString, options);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobChangeFeedClient"/>
        /// class.
        /// </summary>
        /// <param name="serviceUri">
        /// A <see cref="Uri"/> referencing the blob service.
        /// This is likely to be similar to "https://{account_name}.blob.core.windows.net".
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public BlobChangeFeedClient(Uri serviceUri, BlobClientOptions options = default)
        {
            _blobServiceClient = new BlobServiceClient(serviceUri, options);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobChangeFeedClient"/>
        /// class.
        /// </summary>
        /// <param name="serviceUri">
        /// A <see cref="Uri"/> referencing the blob service.
        /// This is likely to be similar to "https://{account_name}.blob.core.windows.net".
        /// </param>
        /// <param name="credential">
        /// The shared key credential used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public BlobChangeFeedClient(Uri serviceUri, StorageSharedKeyCredential credential, BlobClientOptions options = default)
        {
            _blobServiceClient = new BlobServiceClient(serviceUri, credential, options);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobChangeFeedClient"/>
        /// class.
        /// </summary>
        /// <param name="serviceUri">
        /// A <see cref="Uri"/> referencing the blob service.
        /// This is likely to be similar to "https://{account_name}.blob.core.windows.net".
        /// </param>
        /// <param name="credential">
        /// The token credential used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public BlobChangeFeedClient(Uri serviceUri, TokenCredential credential, BlobClientOptions options = default)
        {
            _blobServiceClient = new BlobServiceClient(serviceUri, credential, options);
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
