// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
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

        private BlobChangeFeedClientOptions _changeFeedOptions;

        /// <summary>
        /// Constructor.
        /// </summary>
        protected BlobChangeFeedClient() { }

        internal BlobChangeFeedClient(BlobServiceClient blobServiceClient, BlobChangeFeedClientOptions changeFeedOptions = null)
        {
            _blobServiceClient = blobServiceClient;
            _changeFeedOptions = changeFeedOptions;
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
        /// <param name="changeFeedOptions">
        /// Change Feed-specific client options.
        /// </param>
        public BlobChangeFeedClient(string connectionString,
            BlobClientOptions options,
            BlobChangeFeedClientOptions changeFeedOptions)
        {
            _blobServiceClient = new BlobServiceClient(connectionString, options);
            _changeFeedOptions = changeFeedOptions;
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
        /// <param name="changeFeedOptions">
        /// Change Feed-specific client options.
        /// </param>
        public BlobChangeFeedClient(Uri serviceUri,
            BlobClientOptions options = default,
            BlobChangeFeedClientOptions changeFeedOptions = default)
        {
            _blobServiceClient = new BlobServiceClient(serviceUri, options);
            _changeFeedOptions = changeFeedOptions;
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
        /// <param name="changeFeedOptions">
        /// Change Feed-specific client options.
        /// </param>
        public BlobChangeFeedClient(Uri serviceUri,
            StorageSharedKeyCredential credential,
            BlobClientOptions options = default,
            BlobChangeFeedClientOptions changeFeedOptions = default)
        {
            _blobServiceClient = new BlobServiceClient(serviceUri, credential, options);
            _changeFeedOptions = changeFeedOptions;
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
        /// <param name="changeFeedOptions">
        /// Change Feed-specific client options.
        /// </param>
        /// <remarks>
        /// This constructor should only be used when shared access signature needs to be updated during lifespan of this client.
        /// </remarks>
        public BlobChangeFeedClient(Uri serviceUri,
            AzureSasCredential credential,
            BlobClientOptions options = default,
            BlobChangeFeedClientOptions changeFeedOptions = default)
        {
            _blobServiceClient = new BlobServiceClient(serviceUri, credential, options);
            _changeFeedOptions = changeFeedOptions;
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
        /// <param name="changeFeedOptions">
        /// Change Feed-specific client options.
        /// </param>
        public BlobChangeFeedClient(Uri serviceUri,
            TokenCredential credential,
            BlobClientOptions options = default,
            BlobChangeFeedClientOptions changeFeedOptions = default)
        {
            _blobServiceClient = new BlobServiceClient(serviceUri, credential, options);
            _changeFeedOptions = changeFeedOptions;
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
                _blobServiceClient,
                _changeFeedOptions?.MaximumTransferSize);
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
                _changeFeedOptions?.MaximumTransferSize,
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
                _changeFeedOptions?.MaximumTransferSize,
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
            BlobChangeFeedAsyncPageable asyncPagable = new BlobChangeFeedAsyncPageable(
                _blobServiceClient,
                _changeFeedOptions?.MaximumTransferSize);
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
            BlobChangeFeedAsyncPageable asyncPagable = new BlobChangeFeedAsyncPageable(
                _blobServiceClient,
                _changeFeedOptions?.MaximumTransferSize,
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
                _changeFeedOptions?.MaximumTransferSize,
                start,
                end);
            return asyncPagable;
        }

        /// <summary>
        /// Returns the LastConsumable <see cref="DateTimeOffset"/> of the ChangeFeed, or null if the ChangeFeed is empty or has not been initialized.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
#pragma warning disable AZC0015

        public virtual DateTimeOffset? GetLastConsumable(CancellationToken cancellationToken = default)
#pragma warning restore AZC0015
        {
            BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient(Constants.ChangeFeed.ChangeFeedContainerName);
            return ChangeFeedFactory.GetLastConsumableInternal(
                containerClient,
                async: false,
                cancellationToken)
                .EnsureCompleted();
        }

        /// <summary>
        /// Returns the LastConsumable <see cref="DateTimeOffset"/> of the ChangeFeed, or null if the ChangeFeed is empty or has not been initialized.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
#pragma warning disable AZC0015
        public virtual Task<DateTimeOffset?> GetLastConsumableAsync(CancellationToken cancellationToken = default)
#pragma warning restore AZC0015
        {
            BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient(Constants.ChangeFeed.ChangeFeedContainerName);
            return ChangeFeedFactory.GetLastConsumableInternal(
                containerClient,
                async: true,
                cancellationToken);
        }
    }
}
