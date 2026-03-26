// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs;
using Azure.Storage.ChangeFeed.Common;

namespace Azure.Storage.Files.Shares.ChangeFeed
{
    /// <summary>
    /// Pageable that returns change feed events between two snapshots,
    /// filtered by container version ID (cvId).
    /// </summary>
    internal class ShareChangeFeedSnapshotPageable : Pageable<ShareChangeFeedEvent>
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _fileServiceUri;
        private readonly string _shareName;
        private readonly long? _maxTransferSize;
        private readonly string _beginSnapshot;
        private readonly string _endSnapshot;

        /// <summary>
        /// Initializes a new instance of <see cref="ShareChangeFeedSnapshotPageable"/>.
        /// </summary>
        /// <param name="blobServiceClient">The blob service client for reading change feed segments.</param>
        /// <param name="pipeline">The HTTP pipeline for file service container discovery.</param>
        /// <param name="fileServiceUri">The file service endpoint URI.</param>
        /// <param name="shareName">The file share name.</param>
        /// <param name="maxTransferSize">Optional maximum transfer size for blob downloads.</param>
        /// <param name="beginSnapshot">The begin snapshot timestamp string.</param>
        /// <param name="endSnapshot">The end snapshot timestamp string.</param>
        internal ShareChangeFeedSnapshotPageable(
            BlobServiceClient blobServiceClient,
            HttpPipeline pipeline,
            Uri fileServiceUri,
            string shareName,
            long? maxTransferSize,
            string beginSnapshot,
            string endSnapshot)
        {
            _blobServiceClient = blobServiceClient;
            _pipeline = pipeline;
            _fileServiceUri = fileServiceUri;
            _shareName = shareName;
            _maxTransferSize = maxTransferSize;
            _beginSnapshot = beginSnapshot;
            _endSnapshot = endSnapshot;
        }

        /// <summary>
        /// Enumerates pages of change feed events between two snapshots, filtered by container version ID.
        /// </summary>
        /// <param name="continuationToken">Must be null; continuation is not supported for snapshot queries.</param>
        /// <param name="pageSizeHint">Optional hint for the number of events per page.</param>
        /// <returns>An enumerable of pages of <see cref="ShareChangeFeedEvent"/> filtered by cvId range.</returns>
        public override IEnumerable<Page<ShareChangeFeedEvent>> AsPages(
            string continuationToken = null,
            int? pageSizeHint = null)
        {
            if (continuationToken != null)
            {
                throw new ArgumentException("Continuation not supported for snapshot queries.");
            }

            // Discover the blob container name from the file share properties.
            string containerName = ContainerDiscovery.DiscoverContainerNameAsync(
                _pipeline,
                _fileServiceUri,
                _shareName,
                async: false,
                cancellationToken: default).EnsureCompleted();

            BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient(containerName);

            // Read snapshot metadata to get cvId values and time window boundaries.
            SnapshotMetadata beginMeta = SnapshotQueryHelper.ReadSnapshotMetadataAsync(
                containerClient, _beginSnapshot, async: false, cancellationToken: default).EnsureCompleted();
            SnapshotMetadata endMeta = SnapshotQueryHelper.ReadSnapshotMetadataAsync(
                containerClient, _endSnapshot, async: false, cancellationToken: default).EnsureCompleted();

            if (endMeta.Status != null && !endMeta.Status.Equals("Finalized", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException(
                    $"End snapshot '{_endSnapshot}' is not finalized (status: {endMeta.Status}). " +
                    "Wait for the snapshot to be finalized before querying.");
            }

            // Derive the cvId range and time window from the two snapshot metadata objects.
            // The begin snapshot's MinLogWindowForNextSnapshot is the earliest time events may appear,
            // and the end snapshot's MaxLogWindowForCurrentSnapshot is the latest.
            long beginCvId = beginMeta.CvId;
            long endCvId = endMeta.CvId;
            DateTimeOffset startTime = beginMeta.MinLogWindowForNextSnapshot;
            DateTimeOffset endTime = endMeta.MaxLogWindowForCurrentSnapshot;

            ChangeFeedConfiguration<ShareChangeFeedEvent> config = ShareChangeFeedClient.CreateConfiguration(containerName);
            ChangeFeedFactoryBase<ShareChangeFeedEvent> factory = new ChangeFeedFactoryBase<ShareChangeFeedEvent>(
                containerClient, _maxTransferSize, config);

            ChangeFeedBase<ShareChangeFeedEvent> changeFeed = factory.BuildChangeFeed(
                startTime, endTime, continuation: null, async: false, cancellationToken: default).EnsureCompleted();

            int pageSize = pageSizeHint ?? Constants.FilesChangeFeed.DefaultPageSize;
            while (changeFeed.HasNext())
            {
                Page<ShareChangeFeedEvent> rawPage = changeFeed.GetPage(
                    async: false, pageSize: pageSize).EnsureCompleted();

                // Filter events by container version number: only include events where
                // beginCvId < ContainerVersionNumber <= endCvId (exclusive begin, inclusive end).
                List<ShareChangeFeedEvent> filtered = new List<ShareChangeFeedEvent>();
                foreach (ShareChangeFeedEvent evt in rawPage.Values)
                {
                    if (evt.ContainerVersionNumber > beginCvId && evt.ContainerVersionNumber <= endCvId)
                    {
                        filtered.Add(evt);
                    }
                }

                if (filtered.Count > 0)
                {
                    yield return new ChangeFeedEventPageBase<ShareChangeFeedEvent>(filtered, rawPage.ContinuationToken);
                }
            }
        }
    }
}
