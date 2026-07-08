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
        private readonly ShareChangeFeedResetPolicy _policy;

        internal ShareChangeFeedSnapshotPageable(
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
        internal ShareChangeFeedSnapshotPageable(
            ShareChangeFeedClient client,
            long? maxTransferSize,
            string beginSnapshot,
            string endSnapshot)
            : this(client, maxTransferSize, ShareChangeFeedResetPolicy.ThrowOnReset, beginSnapshot, endSnapshot)
        {
        }

        internal ShareChangeFeedSnapshotPageable(
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
        internal ShareChangeFeedSnapshotPageable(
            ShareChangeFeedClient client,
            long? maxTransferSize,
            string continuation)
            : this(client, maxTransferSize, ShareChangeFeedResetPolicy.ThrowOnReset, continuation)
        {
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

            // Reset detection: read the pointer once. Range for snapshot APIs is
            // [BeginSnapshotTimestamp, EndSnapshotTimestamp] on fresh enumerations; on resume,
            // use last-seen FILETIME as the comparison anchor.
            ShareChangeFeedResetPointer pointer = ResetMarkerReader.TryReadPointerAsync(
                containerClient,
                async: false,
                cancellationToken: default)
                .EnsureCompleted();

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
                    // On resume without begin/end snapshot timestamps, the fact that the
                    // pointer is strictly newer than the token's last-seen is enough — the
                    // caller was mid-way through a snapshot enumeration when the reset landed.
                    || (!iter.BeginSnapshotTimestamp.HasValue && !iter.EndSnapshotTimestamp.HasValue));

                if (shouldSurface)
                {
                    ShareChangeFeedResetMarker perEvent = ResetMarkerReader.ReadPerEventAsync(
                        containerClient,
                        pointer.LatestMarkerPath,
                        async: false,
                        cancellationToken: default)
                        .EnsureCompleted();

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
                Page<ShareChangeFeedEvent> rawPage = iter.ChangeFeed
                    .GetPage(async: false, pageSize: pageSize)
                    .EnsureCompleted();

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

            // Emit any pending reset event that hadn't yet been surfaced (e.g. reset time
            // sits after every filtered event, or no cvId-in-range events existed).
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
