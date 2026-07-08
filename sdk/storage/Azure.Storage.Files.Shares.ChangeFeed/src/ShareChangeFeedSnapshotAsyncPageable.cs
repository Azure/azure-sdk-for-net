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
        private readonly string _continuation;
        private readonly ShareChangeFeedResetPolicy _policy;

        internal ShareChangeFeedSnapshotAsyncPageable(
            ShareChangeFeedClient client,
            long? maxTransferSize,
            ShareChangeFeedResetPolicy policy,
            string beginSnapshot,
            string endSnapshot)
        {
            SnapshotInputValidator.ValidateInputStrings(beginSnapshot, endSnapshot);
            _client = client;
            _maxTransferSize = maxTransferSize;
            _policy = policy;
            _beginSnapshot = beginSnapshot;
            _endSnapshot = endSnapshot;
            _continuation = null;
        }

        // Backwards-compat overload for existing tests that build the pageable directly
        // without specifying a reset policy. Defaults to the batched-API smart default.
        internal ShareChangeFeedSnapshotAsyncPageable(
            ShareChangeFeedClient client,
            long? maxTransferSize,
            string beginSnapshot,
            string endSnapshot)
            : this(client, maxTransferSize, ShareChangeFeedResetPolicy.ThrowOnReset, beginSnapshot, endSnapshot)
        {
        }

        internal ShareChangeFeedSnapshotAsyncPageable(
            ShareChangeFeedClient client,
            long? maxTransferSize,
            ShareChangeFeedResetPolicy policy,
            string continuation)
        {
            if (string.IsNullOrEmpty(continuation))
                throw new ArgumentNullException(nameof(continuation));
            _client = client;
            _maxTransferSize = maxTransferSize;
            _policy = policy;
            _continuation = continuation;
            // beginSnapshot/endSnapshot are recovered from the cursor envelope at enumeration time.
            _beginSnapshot = null;
            _endSnapshot = null;
        }

        // Backwards-compat overload for existing tests. Defaults to the batched-API smart default.
        internal ShareChangeFeedSnapshotAsyncPageable(
            ShareChangeFeedClient client,
            long? maxTransferSize,
            string continuation)
            : this(client, maxTransferSize, ShareChangeFeedResetPolicy.ThrowOnReset, continuation)
        {
        }

        public override async IAsyncEnumerable<Page<ShareChangeFeedEvent>> AsPages(
            string continuationToken = null,
            int? pageSizeHint = null)
        {
            // Prefer a token supplied directly to AsPages (the standard Azure.Core pattern)
            // over the one captured at construction by GetChangesBetweenSnapshots(string).
            string effectiveContinuation = continuationToken ?? _continuation;

            (BlobContainerClient containerClient, ChangeFeedConfiguration<ShareChangeFeedEvent> config) = await _client.ResolveContainerAsync(
                async: true,
                cancellationToken: default)
                .ConfigureAwait(false);

            ShareChangeFeedSnapshotIteration iter = await ShareChangeFeedSnapshotIteration.CreateAsync(
                containerClient,
                config,
                _maxTransferSize,
                _beginSnapshot,
                _endSnapshot,
                effectiveContinuation,
                async: true,
                cancellationToken: default)
                .ConfigureAwait(false);

            // Reset detection: read the pointer once. Range for snapshot APIs is
            // [BeginSnapshotTimestamp, EndSnapshotTimestamp] on fresh enumerations; on resume,
            // use last-seen FILETIME as the comparison anchor.
            ShareChangeFeedResetPointer pointer = await ResetMarkerReader.TryReadPointerAsync(
                containerClient,
                async: true,
                cancellationToken: default)
                .ConfigureAwait(false);

            ShareChangeFeedResetEvent resetToEmit = null;
            DateTimeOffset resetTime = default;

            if (pointer != null)
            {
                resetTime = pointer.LatestResetTimeUtc;
                bool resetIsNewer = !iter.LastSeenResetFileTime.HasValue
                    || pointer.LatestResetFileTime > iter.LastSeenResetFileTime.Value;

                bool resetInSnapshotRange = iter.BeginSnapshotTimestamp.HasValue
                    && iter.EndSnapshotTimestamp.HasValue
                    && resetTime >= iter.BeginSnapshotTimestamp.Value
                    && resetTime <= iter.EndSnapshotTimestamp.Value;

                bool shouldSurface = resetIsNewer && (
                    resetInSnapshotRange
                    || (!iter.BeginSnapshotTimestamp.HasValue && !iter.EndSnapshotTimestamp.HasValue));

                if (shouldSurface)
                {
                    ShareChangeFeedResetMarker perEvent = await ResetMarkerReader.ReadPerEventAsync(
                        containerClient,
                        pointer.LatestMarkerPath,
                        async: true,
                        cancellationToken: default)
                        .ConfigureAwait(false);

                    resetToEmit = ResetMarkerReader.BuildResetEvent(pointer, perEvent);

                    if (_policy == ShareChangeFeedResetPolicy.ThrowOnReset)
                    {
                        throw new ShareChangeFeedResetException(resetToEmit);
                    }
                }
            }

            bool resetEmitted = false;
            int pageSize = pageSizeHint ?? Constants.ChangeFeed.DefaultPageSize;

            while (iter.ChangeFeed.HasNext())
            {
                Page<ShareChangeFeedEvent> rawPage = await iter.ChangeFeed
                    .GetPage(async: true, pageSize: pageSize)
                    .ConfigureAwait(false);

                List<ShareChangeFeedEvent> filtered = new List<ShareChangeFeedEvent>();
                foreach (ShareChangeFeedEvent evt in rawPage.Values)
                {
                    if (SnapshotEventFilter.IsInRange(evt, iter.BeginCvId, iter.EndCvId))
                    {
                        if (!resetEmitted && resetToEmit != null && evt.EventTime >= resetTime)
                        {
                            filtered.Add(resetToEmit);
                            resetEmitted = true;
                        }

                        filtered.Add(evt);
                    }
                }

                if (filtered.Count > 0)
                {
                    Guid? nextId = resetEmitted
                        ? pointer?.LatestResetId ?? iter.LastSeenResetId
                        : iter.LastSeenResetId;
                    long? nextFileTime = resetEmitted
                        ? pointer?.LatestResetFileTime ?? iter.LastSeenResetFileTime
                        : iter.LastSeenResetFileTime;

                    string outerToken = iter.WrapInnerCursor(
                        containerClient,
                        iter.ChangeFeed.GetCursor(),
                        nextId,
                        nextFileTime);
                    yield return new ChangeFeedEventPageBase<ShareChangeFeedEvent>(filtered, outerToken);
                }
            }

            if (!resetEmitted && resetToEmit != null)
            {
                List<ShareChangeFeedEvent> tail = new List<ShareChangeFeedEvent> { resetToEmit };
                string outerToken = iter.WrapInnerCursor(
                    containerClient,
                    innerCursor: null,
                    pointer.LatestResetId,
                    pointer.LatestResetFileTime);
                yield return new ChangeFeedEventPageBase<ShareChangeFeedEvent>(tail, outerToken);
            }
        }
    }
}
