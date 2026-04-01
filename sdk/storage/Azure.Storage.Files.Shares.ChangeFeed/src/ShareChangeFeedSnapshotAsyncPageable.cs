// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Storage.Blobs;
using Azure.Storage.ChangeFeed.Common;

namespace Azure.Storage.Files.Shares.ChangeFeed
{
    internal class ShareChangeFeedSnapshotAsyncPageable : AsyncPageable<ShareChangeFeedEvent>
    {
        private readonly ShareChangeFeedClient _client;
        private readonly long? _maxTransferSize;
        private readonly string _beginSnapshot;
        private readonly string _endSnapshot;

        internal ShareChangeFeedSnapshotAsyncPageable(
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

        public override async IAsyncEnumerable<Page<ShareChangeFeedEvent>> AsPages(
            string continuationToken = null,
            int? pageSizeHint = null)
        {
            if (continuationToken != null)
                throw new ArgumentException("Continuation not supported for snapshot queries.");

            (BlobContainerClient containerClient, ChangeFeedConfiguration<ShareChangeFeedEvent> config) = await _client.ResolveContainerAsync(
                async: true,
                cancellationToken: default)
                .ConfigureAwait(false);

            SnapshotMetadata beginMeta = await SnapshotQueryHelper.ReadSnapshotMetadataAsync(
                containerClient,
                _beginSnapshot,
                async: true,
                cancellationToken: default)
                .ConfigureAwait(false);

            SnapshotMetadata endMeta = await SnapshotQueryHelper.ReadSnapshotMetadataAsync(
                containerClient,
                _endSnapshot,
                async: true,
                cancellationToken: default)
                .ConfigureAwait(false);

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

            ChangeFeedBase<ShareChangeFeedEvent> changeFeed = await factory.BuildChangeFeed(
                startTime,
                endTime,
                continuation:
                null,
                async: true,
                cancellationToken: default)
                .ConfigureAwait(false);

            int pageSize = pageSizeHint ?? Constants.FilesChangeFeed.DefaultPageSize;
            while (changeFeed.HasNext())
            {
                Page<ShareChangeFeedEvent> rawPage = await changeFeed.GetPage(async: true, pageSize: pageSize).ConfigureAwait(false);

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
