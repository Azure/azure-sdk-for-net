// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs;
using Azure.Storage.ChangeFeed.Common;

namespace Azure.Storage.Files.Shares.ChangeFeed
{
    /// <summary>
    /// ShareChangeFeedClient provides operations to read the change feed
    /// for an Azure File Share.
    /// </summary>
    public class ShareChangeFeedClient
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly string _shareName;
        private readonly long? _maxTransferSize;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _fileServiceUri;

        #region ctors
        /// <summary>
        /// Initializes a new instance of <see cref="ShareChangeFeedClient"/>
        /// using a connection string.
        /// </summary>
        public ShareChangeFeedClient(
            string connectionString,
            string shareName,
            BlobClientOptions blobOptions = default,
            ShareChangeFeedClientOptions changeFeedOptions = default)
        {
            _shareName = shareName ?? throw new ArgumentNullException(nameof(shareName));
            _maxTransferSize = changeFeedOptions?.MaximumTransferSize;

            StorageConnectionString connString = StorageConnectionString.Parse(connectionString);
            _fileServiceUri = connString.FileEndpoint;

            // Build pipeline with shared key for the file endpoint discovery call
            StorageSharedKeyCredential sharedKeyCredential = connString.Credentials as StorageSharedKeyCredential;
            blobOptions ??= new BlobClientOptions();
            _pipeline = HttpPipelineBuilder.Build(
                blobOptions,
                sharedKeyCredential != null
                    ? new StorageSharedKeyPipelinePolicy(sharedKeyCredential)
                    : null);

            _blobServiceClient = new BlobServiceClient(connectionString, blobOptions);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="ShareChangeFeedClient"/>
        /// with a storage account URI and shared key credential.
        /// </summary>
        public ShareChangeFeedClient(
            Uri fileServiceUri,
            string shareName,
            StorageSharedKeyCredential credential,
            BlobClientOptions blobOptions = default,
            ShareChangeFeedClientOptions changeFeedOptions = default)
        {
            _shareName = shareName ?? throw new ArgumentNullException(nameof(shareName));
            _fileServiceUri = fileServiceUri ?? throw new ArgumentNullException(nameof(fileServiceUri));
            _maxTransferSize = changeFeedOptions?.MaximumTransferSize;

            blobOptions ??= new BlobClientOptions();
            _pipeline = HttpPipelineBuilder.Build(
                blobOptions,
                new StorageSharedKeyPipelinePolicy(credential));

            Uri blobEndpoint = ContainerDiscovery.FileToBlobEndpoint(fileServiceUri);
            _blobServiceClient = new BlobServiceClient(blobEndpoint, credential, blobOptions);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="ShareChangeFeedClient"/>
        /// with a storage account URI and token credential.
        /// </summary>
        public ShareChangeFeedClient(
            Uri fileServiceUri,
            string shareName,
            TokenCredential credential,
            BlobClientOptions blobOptions = default,
            ShareChangeFeedClientOptions changeFeedOptions = default)
        {
            _shareName = shareName ?? throw new ArgumentNullException(nameof(shareName));
            _fileServiceUri = fileServiceUri ?? throw new ArgumentNullException(nameof(fileServiceUri));
            _maxTransferSize = changeFeedOptions?.MaximumTransferSize;

            blobOptions ??= new BlobClientOptions();
            _pipeline = HttpPipelineBuilder.Build(
                blobOptions,
                new BearerTokenAuthenticationPolicy(credential, Constants.DefaultScope));

            Uri blobEndpoint = ContainerDiscovery.FileToBlobEndpoint(fileServiceUri);
            _blobServiceClient = new BlobServiceClient(blobEndpoint, credential, blobOptions);
        }

        /// <summary>
        /// Constructor for mocking.
        /// </summary>
        protected ShareChangeFeedClient() { }

        /// <summary>
        /// Internal constructor for use by extension methods.
        /// </summary>
        internal ShareChangeFeedClient(
            BlobServiceClient blobServiceClient,
            HttpPipeline pipeline,
            Uri fileServiceUri,
            string shareName,
            ShareChangeFeedClientOptions changeFeedOptions)
        {
            _blobServiceClient = blobServiceClient;
            _pipeline = pipeline;
            _fileServiceUri = fileServiceUri;
            _shareName = shareName;
            _maxTransferSize = changeFeedOptions?.MaximumTransferSize;
        }
        #endregion ctors

        #region GetChanges
        /// <summary>
        /// Returns all change feed events for the file share.
        /// </summary>
        public virtual Pageable<ShareChangeFeedEvent> GetChanges()
            => new ShareChangeFeedPageable(
                _blobServiceClient,
                _pipeline,
                _fileServiceUri,
                _shareName,
                _maxTransferSize);

        /// <summary>
        /// Returns all change feed events for the file share.
        /// </summary>
        public virtual AsyncPageable<ShareChangeFeedEvent> GetChangesAsync()
            => new ShareChangeFeedAsyncPageable(
                _blobServiceClient,
                _pipeline,
                _fileServiceUri,
                _shareName,
                _maxTransferSize);

        /// <summary>
        /// Returns change feed events within the specified time range.
        /// </summary>
        public virtual Pageable<ShareChangeFeedEvent> GetChanges(
            DateTimeOffset? start,
            DateTimeOffset? end)
            => new ShareChangeFeedPageable(
                _blobServiceClient,
                _pipeline,
                _fileServiceUri,
                _shareName,
                _maxTransferSize,
                startTime: start,
                endTime: end);

        /// <summary>
        /// Returns change feed events within the specified time range.
        /// </summary>
        public virtual AsyncPageable<ShareChangeFeedEvent> GetChangesAsync(
            DateTimeOffset? start,
            DateTimeOffset? end)
            => new ShareChangeFeedAsyncPageable(
                _blobServiceClient,
                _pipeline,
                _fileServiceUri,
                _shareName,
                _maxTransferSize,
                startTime: start,
                endTime: end);

        /// <summary>
        /// Resumes reading change feed events from a continuation token.
        /// </summary>
        public virtual Pageable<ShareChangeFeedEvent> GetChanges(
            string continuationToken)
            => new ShareChangeFeedPageable(
                _blobServiceClient,
                _pipeline,
                _fileServiceUri,
                _shareName,
                _maxTransferSize,
                continuation: continuationToken);

        /// <summary>
        /// Resumes reading change feed events from a continuation token.
        /// </summary>
        public virtual AsyncPageable<ShareChangeFeedEvent> GetChangesAsync(
            string continuationToken)
            => new ShareChangeFeedAsyncPageable(
                _blobServiceClient,
                _pipeline,
                _fileServiceUri,
                _shareName,
                _maxTransferSize,
                continuation: continuationToken);
        #endregion GetChanges

        #region GetChangesBetweenSnapshots
        /// <summary>
        /// Returns change feed events between two snapshots, filtered by container version ID.
        /// </summary>
        /// <param name="beginSnapshot">The begin snapshot timestamp (e.g., "2023-07-18T08:00:00.000Z").</param>
        /// <param name="endSnapshot">The end snapshot timestamp (e.g., "2023-07-19T08:00:00.000Z").</param>
        public virtual Pageable<ShareChangeFeedEvent> GetChangesBetweenSnapshots(
            string beginSnapshot,
            string endSnapshot)
            => new ShareChangeFeedSnapshotPageable(
                _blobServiceClient,
                _pipeline,
                _fileServiceUri,
                _shareName,
                _maxTransferSize,
                beginSnapshot,
                endSnapshot);

        /// <summary>
        /// Returns change feed events between two snapshots, filtered by container version ID.
        /// </summary>
        /// <param name="beginSnapshot">The begin snapshot timestamp (e.g., "2023-07-18T08:00:00.000Z").</param>
        /// <param name="endSnapshot">The end snapshot timestamp (e.g., "2023-07-19T08:00:00.000Z").</param>
        public virtual AsyncPageable<ShareChangeFeedEvent> GetChangesBetweenSnapshotsAsync(
            string beginSnapshot,
            string endSnapshot)
            => new ShareChangeFeedSnapshotAsyncPageable(
                _blobServiceClient,
                _pipeline,
                _fileServiceUri,
                _shareName,
                _maxTransferSize,
                beginSnapshot,
                endSnapshot);
        #endregion GetChangesBetweenSnapshots

        #region GetLastConsumable
        /// <summary>
        /// Gets the last consumable timestamp from the change feed.
        /// </summary>
        public virtual DateTimeOffset? GetLastConsumable(
            CancellationToken cancellationToken = default)
            => GetLastConsumableInternal(
                async: false,
                cancellationToken).EnsureCompleted();

        /// <summary>
        /// Gets the last consumable timestamp from the change feed.
        /// </summary>
        public virtual async Task<DateTimeOffset?> GetLastConsumableAsync(
            CancellationToken cancellationToken = default)
            => await GetLastConsumableInternal(
                async: true,
                cancellationToken).ConfigureAwait(false);

        private async Task<DateTimeOffset?> GetLastConsumableInternal(
            bool async,
            CancellationToken cancellationToken)
        {
            string containerName = await ContainerDiscovery.DiscoverContainerNameAsync(
                _pipeline,
                _fileServiceUri,
                _shareName,
                async,
                cancellationToken).ConfigureAwait(false);

            BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient(containerName);

            return await ChangeFeedFactoryBase<ShareChangeFeedEvent>.GetLastConsumableInternal(
                containerClient,
                Constants.FilesChangeFeed.MetaSegmentsPath,
                async,
                cancellationToken).ConfigureAwait(false);
        }
        #endregion GetLastConsumable

        internal static ChangeFeedConfiguration<ShareChangeFeedEvent> CreateConfiguration(string containerName)
            => new ChangeFeedConfiguration<ShareChangeFeedEvent>
            {
                TimeWindowInterval = TimeSpan.FromMinutes(Constants.FilesChangeFeed.TimeWindowMinutes),
                ContainerPrefix = containerName + "/",
                EventParser = record => new ShareChangeFeedEvent(record),
                DefaultPageSize = Constants.FilesChangeFeed.DefaultPageSize,
                ChunkBlockDownloadSize = Constants.FilesChangeFeed.ChunkBlockDownloadSize,
                InitializationSegment = Constants.FilesChangeFeed.InitializationSegment,
                SegmentPrefix = Constants.FilesChangeFeed.SegmentPrefix,
                MetaSegmentsPath = Constants.FilesChangeFeed.MetaSegmentsPath,
            };
    }
}
