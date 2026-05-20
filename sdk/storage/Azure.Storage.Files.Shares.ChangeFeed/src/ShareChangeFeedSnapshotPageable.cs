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
        private readonly string _continuation;

        internal ShareChangeFeedSnapshotPageable(
            ShareChangeFeedClient client,
            long? maxTransferSize,
            string beginSnapshot,
            string endSnapshot)
        {
            SnapshotInputValidator.ValidateInputStrings(beginSnapshot, endSnapshot);
            _client = client;
            _maxTransferSize = maxTransferSize;
            _beginSnapshot = beginSnapshot;
            _endSnapshot = endSnapshot;
            _continuation = null;
        }

        internal ShareChangeFeedSnapshotPageable(
            ShareChangeFeedClient client,
            long? maxTransferSize,
            string continuation)
        {
            if (string.IsNullOrEmpty(continuation))
                throw new ArgumentNullException(nameof(continuation));
            _client = client;
            _maxTransferSize = maxTransferSize;
            _continuation = continuation;
            // beginSnapshot/endSnapshot are recovered from the cursor envelope at enumeration time.
            _beginSnapshot = null;
            _endSnapshot = null;
        }

        public override IEnumerable<Page<ShareChangeFeedEvent>> AsPages(
            string continuationToken = null,
            int? pageSizeHint = null)
        {
            // Prefer a token supplied directly to AsPages (the standard Azure.Core pattern)
            // over the one captured at construction by GetChangesBetweenSnapshots(string).
            string effectiveContinuation = continuationToken ?? _continuation;

            (BlobContainerClient containerClient, ChangeFeedConfiguration<ShareChangeFeedEvent> config) = _client.ResolveContainerAsync(
                async: false,
                cancellationToken: default)
                .EnsureCompleted();

            ShareChangeFeedSnapshotIteration iter = ShareChangeFeedSnapshotIteration.CreateAsync(
                containerClient,
                config,
                _maxTransferSize,
                _beginSnapshot,
                _endSnapshot,
                effectiveContinuation,
                async: false,
                cancellationToken: default)
                .EnsureCompleted();

            int pageSize = pageSizeHint ?? Constants.ChangeFeed.DefaultPageSize;
            while (iter.ChangeFeed.HasNext())
            {
                Page<ShareChangeFeedEvent> rawPage = iter.ChangeFeed
                    .GetPage(async: false, pageSize: pageSize)
                    .EnsureCompleted();

                List<ShareChangeFeedEvent> filtered = new List<ShareChangeFeedEvent>();
                foreach (ShareChangeFeedEvent evt in rawPage.Values)
                {
                    if (SnapshotEventFilter.IsInRange(evt, iter.BeginCvId, iter.EndCvId))
                        filtered.Add(evt);
                }

                if (filtered.Count > 0)
                {
                    string outerToken = iter.WrapInnerCursor(containerClient, iter.ChangeFeed.GetCursor());
                    yield return new ChangeFeedEventPageBase<ShareChangeFeedEvent>(filtered, outerToken);
                }
            }
        }
    }
}
