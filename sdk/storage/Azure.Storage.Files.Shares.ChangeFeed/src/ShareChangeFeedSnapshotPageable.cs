// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs;
using Azure.Storage.ChangeFeed.Common;

namespace Azure.Storage.Files.Shares.ChangeFeed
{
    internal class ShareChangeFeedSnapshotPageable : Pageable<ShareChangeFeedEvent>
    {
        private readonly ShareChangeFeedClient _client;
        private readonly long? _maxTransferSize;
        private readonly string _beginSnapshot;
        private readonly string _endSnapshot;

        internal ShareChangeFeedSnapshotPageable(
            ShareChangeFeedClient client,
            long? maxTransferSize,
            string beginSnapshot,
            string endSnapshot)
        {
            _client = client;
            _maxTransferSize = maxTransferSize;
            _beginSnapshot = beginSnapshot;
            _endSnapshot = endSnapshot;
        }

        public override IEnumerable<Page<ShareChangeFeedEvent>> AsPages(
            string continuationToken = null,
            int? pageSizeHint = null)
        {
            if (continuationToken != null)
                throw new ArgumentException("Continuation not supported for snapshot queries.");

            (BlobContainerClient containerClient, ChangeFeedConfiguration<ShareChangeFeedEvent> config) = _client.ResolveContainerAsync(
                async: false,
                cancellationToken: default)
                .EnsureCompleted();

            SnapshotMetadata beginMeta = SnapshotQueryHelper.ReadSnapshotMetadataAsync(
                containerClient,
                _beginSnapshot,
                async: false,
                cancellationToken: default)
                .EnsureCompleted();

            SnapshotMetadata endMeta = SnapshotQueryHelper.ReadSnapshotMetadataAsync(
                containerClient,
                _endSnapshot,
                async: false,
                cancellationToken: default)
                .EnsureCompleted();

            if (endMeta.Status != null && !endMeta.Status.Equals("Finalized", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException(
                    $"End snapshot '{_endSnapshot}' is not finalized (status: {endMeta.Status}). " +
                    "Wait for the snapshot to be finalized before querying.");
            }

            long beginCvId = beginMeta.CvId;
            long endCvId = endMeta.CvId;
            DateTimeOffset startTime = beginMeta.MinLogWindowForNextSnapshot;
            DateTimeOffset endTime = endMeta.MaxLogWindowForCurrentSnapshot;

            ChangeFeedFactoryBase<ShareChangeFeedEvent> factory = new ChangeFeedFactoryBase<ShareChangeFeedEvent>(
                containerClient,
                _maxTransferSize,
                config);

            ChangeFeedBase<ShareChangeFeedEvent> changeFeed = factory.BuildChangeFeed(
                startTime,
                endTime,
                continuation: null,
                async: false,
                cancellationToken: default)
                .EnsureCompleted();

            int pageSize = pageSizeHint ?? Constants.FilesChangeFeed.DefaultPageSize;
            while (changeFeed.HasNext())
            {
                Page<ShareChangeFeedEvent> rawPage = changeFeed.GetPage(async: false, pageSize: pageSize).EnsureCompleted();

                List<ShareChangeFeedEvent> filtered = new List<ShareChangeFeedEvent>();
                foreach (ShareChangeFeedEvent evt in rawPage.Values)
                {
                    if (evt.ContainerVersionNumber > beginCvId && evt.ContainerVersionNumber <= endCvId)
                        filtered.Add(evt);
                }

                if (filtered.Count > 0)
                    yield return new ChangeFeedEventPageBase<ShareChangeFeedEvent>(filtered, rawPage.ContinuationToken);
            }
        }
    }
}
