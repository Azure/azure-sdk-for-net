// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.Blobs;

namespace Azure.Storage.Blobs.ChangeFeed
{
    /// <summary>
    /// BlobChangeFeedClient.
    ///
    /// For more information, see
    /// <see href="https://docs.microsoft.com/en-us/azure/storage/blobs/storage-blob-change-feed?tabs=azure-portal">
    /// Change Feed</see>.
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
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/azure/storage/common/storage-configure-connection-string">
        /// Configuring Azure Storage conneciton strings</see>.
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
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/azure/storage/common/storage-configure-connection-string">
        /// Configuring Azure Storage conneciton strings</see>.
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
        /// Must not contain shared access signature, which should be passed in the second parameter.
        /// </param>
        /// <param name="credential">
        /// The shared access signature credential used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        /// <remarks>
        /// This constructor should only be used when shared access signature needs to be updated during lifespan of this client.
        /// </remarks>
        public BlobChangeFeedClient(Uri serviceUri, AzureSasCredential credential, BlobClientOptions options = default)
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
        /// <returns><see cref="BlobChangeFeedPageable"/>.</returns>
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual Pageable<BlobChangeFeedEvent> GetChanges()
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        {
            BlobChangeFeedPageable pageable = new BlobChangeFeedPageable(
                _blobServiceClient);
            return pageable;
        }

        /// <summary>
        /// GetChanges.
        /// </summary>
        /// <param name="continuationToken"></param>
        /// <returns><see cref="BlobChangeFeedPageable"/>.</returns>
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual Pageable<BlobChangeFeedEvent> GetChanges(string continuationToken)
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        {
            BlobChangeFeedPageable pageable = new BlobChangeFeedPageable(
                _blobServiceClient,
                continuationToken);
            return pageable;
        }

        /// <summary>
        /// GetChanges.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns><see cref="BlobChangeFeedPageable"/>.</returns>
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual Pageable<BlobChangeFeedEvent> GetChanges(DateTimeOffset? start = default, DateTimeOffset? end = default)
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        {
            BlobChangeFeedPageable pageable = new BlobChangeFeedPageable(
                _blobServiceClient,
                start,
                end);
            return pageable;
        }

        /// <summary>
        /// GetChangesAsync.
        /// </summary>
        /// <returns><see cref="BlobChangeFeedAsyncPageable"/>.</returns>
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual AsyncPageable<BlobChangeFeedEvent> GetChangesAsync()
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        {
            BlobChangeFeedAsyncPageable asyncPagable = new BlobChangeFeedAsyncPageable(_blobServiceClient);
            return asyncPagable;
        }

        /// <summary>
        /// GetChangesAsync.
        /// </summary>
        /// <param name="continuationToken"></param>
        /// <returns><see cref="BlobChangeFeedAsyncPageable"/>.</returns>
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual AsyncPageable<BlobChangeFeedEvent> GetChangesAsync(string continuationToken)
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        {
            BlobChangeFeedAsyncPageable asyncPagable = new BlobChangeFeedAsyncPageable(_blobServiceClient,
                continuationToken);
            return asyncPagable;
        }

        /// <summary>
        /// GetChangesAsync.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns><see cref="BlobChangeFeedAsyncPageable"/>.</returns>
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual AsyncPageable<BlobChangeFeedEvent> GetChangesAsync(
            DateTimeOffset? start = default,
            DateTimeOffset? end = default)
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        {
            BlobChangeFeedAsyncPageable asyncPagable = new BlobChangeFeedAsyncPageable(
                _blobServiceClient,
                start,
                end);
            return asyncPagable;
        }
    }
}
