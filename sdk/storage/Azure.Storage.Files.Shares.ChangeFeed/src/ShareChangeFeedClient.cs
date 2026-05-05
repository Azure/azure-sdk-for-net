// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs;
using Azure.Storage.ChangeFeed.Common;
using Azure.Storage.Files.Shares;

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
        private readonly ShareClient _shareClient;
        internal readonly BlobServiceClient _blobServiceClient;
        internal readonly long? _maxTransferSize;
        internal readonly bool _includeNonFinalizedEvents;

        // Lazily resolved after the first call to DiscoverContainerNameAsync.
        private string _containerName;
        private BlobContainerClient _containerClient;

        #region ctors
        /// <summary>
        /// Initializes a new instance of <see cref="ShareChangeFeedClient"/>
        /// using a storage connection string.
        /// </summary>
        public ShareChangeFeedClient(
            string connectionString,
            string shareName,
            ShareChangeFeedClientOptions changeFeedOptions = default)
        {
            if (string.IsNullOrEmpty(connectionString)) throw new ArgumentNullException(nameof(connectionString));
            if (string.IsNullOrEmpty(shareName)) throw new ArgumentNullException(nameof(shareName));
            _maxTransferSize = changeFeedOptions?.MaximumTransferSize;
            _includeNonFinalizedEvents = changeFeedOptions?.IncludeNonFinalizedEvents ?? false;

            ShareServiceClient shareServiceClient = new ShareServiceClient(connectionString);
            _shareClient = shareServiceClient.GetShareClient(shareName);
            _blobServiceClient = new BlobServiceClient(connectionString);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="ShareChangeFeedClient"/>
        /// using a file service URI and shared key credential.
        /// </summary>
        public ShareChangeFeedClient(
            Uri fileServiceUri,
            string shareName,
            StorageSharedKeyCredential credential,
            ShareChangeFeedClientOptions changeFeedOptions = default)
        {
            if (fileServiceUri == null) throw new ArgumentNullException(nameof(fileServiceUri));
            if (string.IsNullOrEmpty(shareName)) throw new ArgumentNullException(nameof(shareName));
            _maxTransferSize = changeFeedOptions?.MaximumTransferSize;
            _includeNonFinalizedEvents = changeFeedOptions?.IncludeNonFinalizedEvents ?? false;

            ShareServiceClient shareServiceClient = new ShareServiceClient(fileServiceUri, credential);
            _shareClient = shareServiceClient.GetShareClient(shareName);

            Uri blobEndpoint = ContainerDiscovery.FileToBlobEndpoint(fileServiceUri);
            _blobServiceClient = new BlobServiceClient(blobEndpoint, credential);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="ShareChangeFeedClient"/>
        /// using a file service URI and token credential.
        /// </summary>
        public ShareChangeFeedClient(
            Uri fileServiceUri,
            string shareName,
            TokenCredential credential,
            ShareChangeFeedClientOptions changeFeedOptions = default)
        {
            if (fileServiceUri == null)
                throw new ArgumentNullException(nameof(fileServiceUri));
            if (string.IsNullOrEmpty(shareName))
                throw new ArgumentNullException(nameof(shareName));

            _maxTransferSize = changeFeedOptions?.MaximumTransferSize;
            _includeNonFinalizedEvents = changeFeedOptions?.IncludeNonFinalizedEvents ?? false;

            ShareServiceClient shareServiceClient = new ShareServiceClient(fileServiceUri, credential);
            _shareClient = shareServiceClient.GetShareClient(shareName);

            Uri blobEndpoint = ContainerDiscovery.FileToBlobEndpoint(fileServiceUri);
            _blobServiceClient = new BlobServiceClient(blobEndpoint, credential);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="ShareChangeFeedClient"/>
        /// using a file service URI with SAS token.
        /// </summary>
        public ShareChangeFeedClient(
            Uri fileServiceUri,
            string shareName,
            ShareChangeFeedClientOptions changeFeedOptions = default)
        {
            if (fileServiceUri == null)
                throw new ArgumentNullException(nameof(fileServiceUri));
            if (string.IsNullOrEmpty(shareName))
                throw new ArgumentNullException(nameof(shareName));

            _maxTransferSize = changeFeedOptions?.MaximumTransferSize;
            _includeNonFinalizedEvents = changeFeedOptions?.IncludeNonFinalizedEvents ?? false;

            ShareServiceClient shareServiceClient = new ShareServiceClient(fileServiceUri);
            _shareClient = shareServiceClient.GetShareClient(shareName);

            Uri blobEndpoint = ContainerDiscovery.FileToBlobEndpoint(fileServiceUri);
            _blobServiceClient = new BlobServiceClient(blobEndpoint);
        }

        /// <summary>
        /// Constructor for mocking.
        /// </summary>
        protected ShareChangeFeedClient() { }

        /// <summary>
        /// Internal constructor used by extension methods.
        /// </summary>
        internal ShareChangeFeedClient(
            BlobServiceClient blobServiceClient,
            ShareClient shareClient,
            Uri fileServiceUri,
            string shareName,
            ShareChangeFeedClientOptions changeFeedOptions)
        {
            _blobServiceClient = blobServiceClient;
            _shareClient = shareClient;
            _maxTransferSize = changeFeedOptions?.MaximumTransferSize;
            _includeNonFinalizedEvents = changeFeedOptions?.IncludeNonFinalizedEvents ?? false;
        }
        #endregion ctors

        /// <summary>
        /// Discovers the change feed blob container (lazily, once) and returns the <see cref="BlobContainerClient"/>.
        /// </summary>
        private async Task<BlobContainerClient> GetContainerClientAsync(bool async, CancellationToken cancellationToken)
        {
            if (_containerClient != null)
            {
                return _containerClient;
            }

            _containerName = await ContainerDiscovery.DiscoverContainerNameAsync(
                _shareClient, async, cancellationToken).ConfigureAwait(false);

            // We need to strip the leading $ off the container name.
            _containerName = _containerName.Substring(1, _containerName.Length - 1);
            _containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
            return _containerClient;
        }

        #region GetChanges
        /// <summary>
        /// Returns all change feed events for the file share.
        /// </summary>
        public virtual Pageable<ShareChangeFeedEvent> GetChanges()
            => new ShareChangeFeedPageable(this, _maxTransferSize, _includeNonFinalizedEvents);

        /// <summary>
        /// Returns all change feed events for the file share.
        /// </summary>
        public virtual AsyncPageable<ShareChangeFeedEvent> GetChangesAsync()
            => new ShareChangeFeedAsyncPageable(this, _maxTransferSize, _includeNonFinalizedEvents);

        /// <summary>
        /// Returns change feed events within the specified time range.
        /// </summary>
        /// <remarks>
        /// Events near the <paramref name="start"/> and <paramref name="end"/> boundaries
        /// may be missing or unexpectedly included due to clock skew between the storage
        /// service and the client.
        /// </remarks>
        public virtual Pageable<ShareChangeFeedEvent> GetChanges(
            DateTimeOffset? start,
            DateTimeOffset? end)
            => new ShareChangeFeedPageable(
                this,
                _maxTransferSize,
                _includeNonFinalizedEvents,
                startTime: start,
                endTime: end);

        /// <summary>
        /// Returns change feed events within the specified time range.
        /// </summary>
        /// <remarks>
        /// Events near the <paramref name="start"/> and <paramref name="end"/> boundaries
        /// may be missing or unexpectedly included due to clock skew between the storage
        /// service and the client.
        /// </remarks>
        public virtual AsyncPageable<ShareChangeFeedEvent> GetChangesAsync(
            DateTimeOffset? start,
            DateTimeOffset? end)
            => new ShareChangeFeedAsyncPageable(
                this,
                _maxTransferSize,
                _includeNonFinalizedEvents,
                startTime: start,
                endTime: end);

        /// <summary>
        /// Resumes reading change feed events from a continuation token.
        /// </summary>
        public virtual Pageable<ShareChangeFeedEvent> GetChanges(
            string continuationToken)
            => new ShareChangeFeedPageable(
                this,
                _maxTransferSize,
                _includeNonFinalizedEvents,
                continuation: continuationToken);

        /// <summary>
        /// Resumes reading change feed events from a continuation token.
        /// </summary>
        public virtual AsyncPageable<ShareChangeFeedEvent> GetChangesAsync(
            string continuationToken)
            => new ShareChangeFeedAsyncPageable(
                this,
                _maxTransferSize,
                _includeNonFinalizedEvents,
                continuation: continuationToken);
        #endregion GetChanges

        #region GetChangesBetweenSnapshots
        /// <summary>
        /// Returns change feed events between two snapshots, filtered by container version ID.
        /// </summary>
        public virtual Pageable<ShareChangeFeedEvent> GetChangesBetweenSnapshots(
            string beginSnapshot,
            string endSnapshot)
            => new ShareChangeFeedSnapshotPageable(
                this,
                _maxTransferSize,
                beginSnapshot,
                endSnapshot);

        /// <summary>
        /// Returns change feed events between two snapshots, filtered by container version ID.
        /// </summary>
        public virtual AsyncPageable<ShareChangeFeedEvent> GetChangesBetweenSnapshotsAsync(
            string beginSnapshot,
            string endSnapshot)
            => new ShareChangeFeedSnapshotAsyncPageable(
                this,
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
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Gets the last consumable timestamp from the change feed.
        /// </summary>
        public virtual async Task<DateTimeOffset?> GetLastConsumableAsync(
            CancellationToken cancellationToken = default)
            => await GetLastConsumableInternal(
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

        private async Task<DateTimeOffset?> GetLastConsumableInternal(
            bool async,
            CancellationToken cancellationToken)
        {
            BlobContainerClient containerClient = await GetContainerClientAsync(async, cancellationToken).ConfigureAwait(false);

            return await ChangeFeedFactoryBase<ShareChangeFeedEvent>.GetLastConsumableInternal(
                containerClient,
                Constants.FilesChangeFeed.MetaSegmentsPath,
                async,
                cancellationToken)
                .ConfigureAwait(false);
        }
        #endregion GetLastConsumable

        /// <summary>
        /// Resolves the change feed container and builds a <see cref="BlobContainerClient"/>
        /// and <see cref="ChangeFeedConfiguration{ShareChangeFeedEvent}"/>. Called by pageables.
        /// </summary>
        internal async Task<(BlobContainerClient ContainerClient, ChangeFeedConfiguration<ShareChangeFeedEvent> Config)>
            ResolveContainerAsync(bool async, CancellationToken cancellationToken)
        {
            BlobContainerClient containerClient = await GetContainerClientAsync(async, cancellationToken).ConfigureAwait(false);
            ChangeFeedConfiguration<ShareChangeFeedEvent> config = CreateConfiguration(_containerName);
            return (containerClient, config);
        }

        internal static ChangeFeedConfiguration<ShareChangeFeedEvent> CreateConfiguration(string containerName)
            => new ChangeFeedConfiguration<ShareChangeFeedEvent>
            {
                ContainerPrefix = containerName + "/",
                EventParser = record => new ShareChangeFeedEvent(record),
                DefaultPageSize = Constants.FilesChangeFeed.DefaultPageSize,
                ChunkBlockDownloadSize = Constants.FilesChangeFeed.ChunkBlockDownloadSize,
                AvroHeaderDownloadSize = Constants.FilesChangeFeed.LazyLoadingBlobStreamBlockSize,
                InitializationSegment = Constants.FilesChangeFeed.InitializationSegment,
                SegmentPrefix = Constants.FilesChangeFeed.SegmentPrefix,
                MetaSegmentsPath = Constants.FilesChangeFeed.MetaSegmentsPath,
            };
    }
}
