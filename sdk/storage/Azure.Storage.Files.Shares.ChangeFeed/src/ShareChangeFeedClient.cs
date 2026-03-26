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
    /// <see cref="ShareChangeFeedClient"/> provides operations to read the
    /// Azure Files Change Feed for a specific file share. The change feed records
    /// all file and directory mutations (creates, renames, deletes, writes, etc.)
    /// and is backed by Avro log segments stored in a blob container whose name
    /// is discovered via the share properties REST API.
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
        /// using a storage connection string.
        /// </summary>
        /// <param name="connectionString">A connection string that includes the account name and key or SAS token.</param>
        /// <param name="shareName">The name of the file share whose change feed will be read.</param>
        /// <param name="changeFeedOptions">Optional <see cref="ShareChangeFeedClientOptions"/> for tuning change feed behavior.</param>
        public ShareChangeFeedClient(
            string connectionString,
            string shareName,
            ShareChangeFeedClientOptions changeFeedOptions = default)
        {
            _shareName = shareName ?? throw new ArgumentNullException(nameof(shareName));
            _maxTransferSize = changeFeedOptions?.MaximumTransferSize;

            // Parse the connection string to extract the file service endpoint for container discovery.
            StorageConnectionString connString = StorageConnectionString.Parse(connectionString);
            _fileServiceUri = connString.FileEndpoint;

            // Build an HTTP pipeline with shared key auth so we can call the file service
            // Get Share Properties endpoint to discover the change feed blob container name.
            StorageSharedKeyCredential sharedKeyCredential = connString.Credentials as StorageSharedKeyCredential;
            var blobOptions = new BlobClientOptions();
            _pipeline = HttpPipelineBuilder.Build(
                blobOptions,
                sharedKeyCredential != null
                    ? new StorageSharedKeyPipelinePolicy(sharedKeyCredential)
                    : null);

            _blobServiceClient = new BlobServiceClient(connectionString, blobOptions);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="ShareChangeFeedClient"/>
        /// using a file service URI and shared key credential.
        /// </summary>
        /// <param name="fileServiceUri">The URI of the file service endpoint (e.g., https://account.file.core.windows.net).</param>
        /// <param name="shareName">The name of the file share whose change feed will be read.</param>
        /// <param name="credential">A <see cref="StorageSharedKeyCredential"/> for authenticating requests.</param>
        /// <param name="changeFeedOptions">Optional <see cref="ShareChangeFeedClientOptions"/> for tuning change feed behavior.</param>
        public ShareChangeFeedClient(
            Uri fileServiceUri,
            string shareName,
            StorageSharedKeyCredential credential,
            ShareChangeFeedClientOptions changeFeedOptions = default)
        {
            _shareName = shareName ?? throw new ArgumentNullException(nameof(shareName));
            _fileServiceUri = fileServiceUri ?? throw new ArgumentNullException(nameof(fileServiceUri));
            _maxTransferSize = changeFeedOptions?.MaximumTransferSize;

            var blobOptions = new BlobClientOptions();
            _pipeline = HttpPipelineBuilder.Build(
                blobOptions,
                new StorageSharedKeyPipelinePolicy(credential));

            // Derive the blob service endpoint from the file endpoint (e.g., .file. -> .blob.)
            // so we can read the change feed Avro segments from blob storage.
            Uri blobEndpoint = ContainerDiscovery.FileToBlobEndpoint(fileServiceUri);
            _blobServiceClient = new BlobServiceClient(blobEndpoint, credential, blobOptions);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="ShareChangeFeedClient"/>
        /// using a file service URI and Azure Active Directory token credential.
        /// </summary>
        /// <param name="fileServiceUri">The URI of the file service endpoint (e.g., https://account.file.core.windows.net).</param>
        /// <param name="shareName">The name of the file share whose change feed will be read.</param>
        /// <param name="credential">A <see cref="TokenCredential"/> (e.g., DefaultAzureCredential) for authenticating requests.</param>
        /// <param name="changeFeedOptions">Optional <see cref="ShareChangeFeedClientOptions"/> for tuning change feed behavior.</param>
        public ShareChangeFeedClient(
            Uri fileServiceUri,
            string shareName,
            TokenCredential credential,
            ShareChangeFeedClientOptions changeFeedOptions = default)
        {
            _shareName = shareName ?? throw new ArgumentNullException(nameof(shareName));
            _fileServiceUri = fileServiceUri ?? throw new ArgumentNullException(nameof(fileServiceUri));
            _maxTransferSize = changeFeedOptions?.MaximumTransferSize;

            var blobOptions = new BlobClientOptions();
            _pipeline = HttpPipelineBuilder.Build(
                blobOptions,
                new BearerTokenAuthenticationPolicy(credential, Constants.DefaultScope));

            // Derive the blob service endpoint from the file endpoint (e.g., .file. -> .blob.)
            // so we can read the change feed Avro segments from blob storage.
            Uri blobEndpoint = ContainerDiscovery.FileToBlobEndpoint(fileServiceUri);
            _blobServiceClient = new BlobServiceClient(blobEndpoint, credential, blobOptions);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="ShareChangeFeedClient"/> for mocking purposes.
        /// </summary>
        protected ShareChangeFeedClient() { }

        /// <summary>
        /// Internal constructor used by extension methods or tests to supply pre-built dependencies.
        /// </summary>
        /// <param name="blobServiceClient">The pre-configured blob service client.</param>
        /// <param name="pipeline">The HTTP pipeline for file service discovery calls.</param>
        /// <param name="fileServiceUri">The file service endpoint URI.</param>
        /// <param name="shareName">The name of the file share.</param>
        /// <param name="changeFeedOptions">Optional change feed client options.</param>
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
        /// Returns all change feed events for the file share as a synchronous pageable sequence.
        /// </summary>
        /// <returns>A <see cref="Pageable{ShareChangeFeedEvent}"/> enumerating all change feed events.</returns>
        public virtual Pageable<ShareChangeFeedEvent> GetChanges()
            => new ShareChangeFeedPageable(
                _blobServiceClient,
                _pipeline,
                _fileServiceUri,
                _shareName,
                _maxTransferSize);

        /// <summary>
        /// Returns all change feed events for the file share as an asynchronous pageable sequence.
        /// </summary>
        /// <returns>An <see cref="AsyncPageable{ShareChangeFeedEvent}"/> enumerating all change feed events.</returns>
        public virtual AsyncPageable<ShareChangeFeedEvent> GetChangesAsync()
            => new ShareChangeFeedAsyncPageable(
                _blobServiceClient,
                _pipeline,
                _fileServiceUri,
                _shareName,
                _maxTransferSize);

        /// <summary>
        /// Returns change feed events within the specified time range as a synchronous pageable sequence.
        /// </summary>
        /// <param name="start">The optional inclusive start time for filtering events.</param>
        /// <param name="end">The optional exclusive end time for filtering events.</param>
        /// <returns>A <see cref="Pageable{ShareChangeFeedEvent}"/> enumerating matching change feed events.</returns>
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
        /// Returns change feed events within the specified time range as an asynchronous pageable sequence.
        /// </summary>
        /// <param name="start">The optional inclusive start time for filtering events.</param>
        /// <param name="end">The optional exclusive end time for filtering events.</param>
        /// <returns>An <see cref="AsyncPageable{ShareChangeFeedEvent}"/> enumerating matching change feed events.</returns>
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
        /// Resumes reading change feed events from a previously obtained continuation token.
        /// </summary>
        /// <param name="continuationToken">A continuation token returned from a previous change feed enumeration.</param>
        /// <returns>A <see cref="Pageable{ShareChangeFeedEvent}"/> resuming from the continuation point.</returns>
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
        /// Resumes reading change feed events from a previously obtained continuation token.
        /// </summary>
        /// <param name="continuationToken">A continuation token returned from a previous change feed enumeration.</param>
        /// <returns>An <see cref="AsyncPageable{ShareChangeFeedEvent}"/> resuming from the continuation point.</returns>
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
        /// Gets the last consumable timestamp from the change feed, indicating the most recent
        /// time up to which events are guaranteed to be available.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for the operation.</param>
        /// <returns>The last consumable <see cref="DateTimeOffset"/>, or <c>null</c> if the change feed has no data.</returns>
        public virtual DateTimeOffset? GetLastConsumable(
            CancellationToken cancellationToken = default)
            => GetLastConsumableInternal(
                async: false,
                cancellationToken).EnsureCompleted();

        /// <summary>
        /// Asynchronously gets the last consumable timestamp from the change feed, indicating the most recent
        /// time up to which events are guaranteed to be available.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for the operation.</param>
        /// <returns>The last consumable <see cref="DateTimeOffset"/>, or <c>null</c> if the change feed has no data.</returns>
        public virtual async Task<DateTimeOffset?> GetLastConsumableAsync(
            CancellationToken cancellationToken = default)
            => await GetLastConsumableInternal(
                async: true,
                cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Shared implementation for <see cref="GetLastConsumable"/> and <see cref="GetLastConsumableAsync"/>.
        /// </summary>
        private async Task<DateTimeOffset?> GetLastConsumableInternal(
            bool async,
            CancellationToken cancellationToken)
        {
            // First discover the blob container name by querying the file share properties.
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

        /// <summary>
        /// Creates a <see cref="ChangeFeedConfiguration{ShareChangeFeedEvent}"/> that defines
        /// the time-window interval, blob path conventions, event parser, and other settings
        /// specific to the Azure Files Change Feed format.
        /// </summary>
        /// <param name="containerName">The discovered blob container name that holds the change feed data.</param>
        /// <returns>A configuration instance for building a change feed reader.</returns>
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
