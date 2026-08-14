// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs;
using Azure.Storage.ChangeFeed.Common;

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
        internal readonly BlobServiceClient _blobServiceClient;
        internal readonly BlobContainerClient _containerClient;
        internal readonly long? _maxTransferSize;
        internal readonly bool _includeNonFinalizedEvents;

        #region ctors
        /// <summary>
        /// Constructor for mocking.
        /// </summary>
        protected BlobChangeFeedClient() { }

        internal BlobChangeFeedClient(BlobServiceClient blobServiceClient, BlobChangeFeedClientOptions changeFeedOptions = null)
        {
            _blobServiceClient = blobServiceClient;
            _containerClient = blobServiceClient.GetBlobContainerClient(Constants.ChangeFeed.ChangeFeedContainerName);
            _maxTransferSize = changeFeedOptions?.MaximumTransferSize;
            _includeNonFinalizedEvents = changeFeedOptions?.IncludeNonFinalizedEvents ?? false;
        }

        /// <summary>
        /// Internal constructor used by tests to inject a pre-built container client.
        /// </summary>
        internal BlobChangeFeedClient(BlobContainerClient containerClient, BlobChangeFeedClientOptions changeFeedOptions = null)
        {
            _containerClient = containerClient;
            _maxTransferSize = changeFeedOptions?.MaximumTransferSize;
            _includeNonFinalizedEvents = changeFeedOptions?.IncludeNonFinalizedEvents ?? false;
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
            : this(new BlobServiceClient(connectionString), changeFeedOptions: null)
        {
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
        public BlobChangeFeedClient(
            string connectionString,
            BlobClientOptions options,
            BlobChangeFeedClientOptions changeFeedOptions)
            : this(new BlobServiceClient(connectionString, options), changeFeedOptions)
        {
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
        public BlobChangeFeedClient(
            Uri serviceUri,
            BlobClientOptions options = default,
            BlobChangeFeedClientOptions changeFeedOptions = default)
            : this(new BlobServiceClient(serviceUri, options), changeFeedOptions)
        {
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
        public BlobChangeFeedClient(
            Uri serviceUri,
            StorageSharedKeyCredential credential,
            BlobClientOptions options = default,
            BlobChangeFeedClientOptions changeFeedOptions = default)
            : this(new BlobServiceClient(serviceUri, credential, options), changeFeedOptions)
        {
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
        public BlobChangeFeedClient(
            Uri serviceUri,
            AzureSasCredential credential,
            BlobClientOptions options = default,
            BlobChangeFeedClientOptions changeFeedOptions = default)
            : this(new BlobServiceClient(serviceUri, credential, options), changeFeedOptions)
        {
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
        public BlobChangeFeedClient(
            Uri serviceUri,
            TokenCredential credential,
            BlobClientOptions options = default,
            BlobChangeFeedClientOptions changeFeedOptions = default)
            : this(new BlobServiceClient(serviceUri, credential, options), changeFeedOptions)
        {
        }
        #endregion ctors

        #region GetChanges
        /// <summary>
        /// GetChanges.
        /// </summary>
        /// <returns><see cref="BlobChangeFeedPageable"/>.</returns>
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual Pageable<BlobChangeFeedEvent> GetChanges()
#pragma warning restore AZC0002
            => new BlobChangeFeedPageable(this, _maxTransferSize, _includeNonFinalizedEvents);

        /// <summary>
        /// GetChanges.
        /// </summary>
        /// <param name="continuationToken"></param>
        /// <returns><see cref="BlobChangeFeedPageable"/>.</returns>
#pragma warning disable AZC0002
        public virtual Pageable<BlobChangeFeedEvent> GetChanges(string continuationToken)
#pragma warning restore AZC0002
        {
            ThrowIfContinuationDisallowed(continuationToken);
            return new BlobChangeFeedPageable(this, _maxTransferSize, _includeNonFinalizedEvents, continuation: continuationToken);
        }

        /// <summary>
        /// GetChanges.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns><see cref="BlobChangeFeedPageable"/>.</returns>
#pragma warning disable AZC0002
        public virtual Pageable<BlobChangeFeedEvent> GetChanges(DateTimeOffset? start = default, DateTimeOffset? end = default)
#pragma warning restore AZC0002
        {
            ThrowIfStartAfterEnd(start, end);
            return new BlobChangeFeedPageable(this, _maxTransferSize, _includeNonFinalizedEvents, startTime: start, endTime: end);
        }

        /// <summary>
        /// GetChangesAsync.
        /// </summary>
        /// <returns><see cref="BlobChangeFeedAsyncPageable"/>.</returns>
#pragma warning disable AZC0002
        public virtual AsyncPageable<BlobChangeFeedEvent> GetChangesAsync()
#pragma warning restore AZC0002
            => new BlobChangeFeedAsyncPageable(this, _maxTransferSize, _includeNonFinalizedEvents);

        /// <summary>
        /// GetChangesAsync.
        /// </summary>
        /// <param name="continuationToken"></param>
        /// <returns><see cref="BlobChangeFeedAsyncPageable"/>.</returns>
#pragma warning disable AZC0002
        public virtual AsyncPageable<BlobChangeFeedEvent> GetChangesAsync(string continuationToken)
#pragma warning restore AZC0002
        {
            ThrowIfContinuationDisallowed(continuationToken);
            return new BlobChangeFeedAsyncPageable(this, _maxTransferSize, _includeNonFinalizedEvents, continuation: continuationToken);
        }

        /// <summary>
        /// GetChangesAsync.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns><see cref="BlobChangeFeedAsyncPageable"/>.</returns>
#pragma warning disable AZC0002
        public virtual AsyncPageable<BlobChangeFeedEvent> GetChangesAsync(
            DateTimeOffset? start = default,
            DateTimeOffset? end = default)
#pragma warning restore AZC0002
        {
            ThrowIfStartAfterEnd(start, end);
            return new BlobChangeFeedAsyncPageable(this, _maxTransferSize, _includeNonFinalizedEvents, startTime: start, endTime: end);
        }

        private static void ThrowIfStartAfterEnd(DateTimeOffset? start, DateTimeOffset? end)
        {
            if (start.HasValue && end.HasValue && start.Value > end.Value)
            {
                throw new ArgumentException(
                    $"{nameof(start)} ({start.Value:O}) must be earlier than or equal to {nameof(end)} ({end.Value:O}).",
                    nameof(start));
            }
        }

        private void ThrowIfContinuationDisallowed(string continuationToken)
        {
            if (continuationToken != null && _includeNonFinalizedEvents)
            {
                throw new ArgumentException(
                    "Resuming from a continuation token is not supported when " +
                    nameof(BlobChangeFeedClientOptions.IncludeNonFinalizedEvents) +
                    " is enabled on " + nameof(BlobChangeFeedClientOptions) + ". " +
                    "Non-finalized reads do not produce continuation tokens because segments past " +
                    "the finalized watermark may change between calls. Disable " +
                    nameof(BlobChangeFeedClientOptions.IncludeNonFinalizedEvents) +
                    " to resume from a saved position.",
                    nameof(continuationToken));
            }
        }
        #endregion GetChanges

        #region GetLastConsumable
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
            => ChangeFeedFactoryBase<BlobChangeFeedEvent>.GetLastConsumableInternal(
                _containerClient,
                Constants.ChangeFeed.MetaSegmentsPath,
                async: false,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Returns the LastConsumable <see cref="DateTimeOffset"/> of the ChangeFeed, or null if the ChangeFeed is empty or has not been initialized.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
#pragma warning disable AZC0015
        public virtual async Task<DateTimeOffset?> GetLastConsumableAsync(CancellationToken cancellationToken = default)
#pragma warning restore AZC0015
            => await ChangeFeedFactoryBase<BlobChangeFeedEvent>.GetLastConsumableInternal(
                _containerClient,
                Constants.ChangeFeed.MetaSegmentsPath,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);
        #endregion GetLastConsumable

        /// <summary>
        /// Returns the change feed container client and a configuration object for use by pageables.
        /// </summary>
        internal (BlobContainerClient ContainerClient, ChangeFeedConfiguration<BlobChangeFeedEvent> Config) ResolveContainer()
            => (_containerClient, CreateConfiguration());

        internal static ChangeFeedConfiguration<BlobChangeFeedEvent> CreateConfiguration()
            => new ChangeFeedConfiguration<BlobChangeFeedEvent>
            {
                ContainerPrefix = Constants.ChangeFeed.ChangeFeedContainerName + "/",
                EventParser = record => new BlobChangeFeedEvent(record),
                DefaultPageSize = Constants.ChangeFeed.DefaultPageSize,
                ChunkBlockDownloadSize = Constants.ChangeFeed.ChunkBlockDownloadSize,
                AvroHeaderDownloadSize = Constants.ChangeFeed.LazyLoadingBlobStreamBlockSize,
                InitializationSegment = Constants.ChangeFeed.InitializationSegment,
                SegmentPrefix = Constants.ChangeFeed.SegmentPrefix,
                MetaSegmentsPath = Constants.ChangeFeed.MetaSegmentsPath,
            };
    }
}
