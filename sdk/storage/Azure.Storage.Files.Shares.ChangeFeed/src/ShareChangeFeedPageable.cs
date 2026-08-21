// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs;
using Azure.Storage.ChangeFeed.Common;

namespace Azure.Storage.Files.Shares.ChangeFeed
{
    internal class ShareChangeFeedPageable : Pageable<ShareChangeFeedEvent>
    {
        private readonly ShareChangeFeedClient _client;
        private readonly long? _maxTransferSize;
        private readonly bool _includeNonFinalizedEvents;
        private readonly DateTimeOffset? _startTime;
        private readonly DateTimeOffset? _endTime;
        private readonly string _continuation;
        private readonly ShareChangeFeedResetPolicy _policy;
        private readonly bool _isBatched;

        internal ShareChangeFeedPageable(
            ShareChangeFeedClient client,
            long? maxTransferSize,
            bool includeNonFinalizedEvents,
            ShareChangeFeedResetPolicy policy = ShareChangeFeedResetPolicy.ContinueOnReset,
            DateTimeOffset? startTime = default,
            DateTimeOffset? endTime = default,
            string continuation = default,
            bool isBatched = false)
        {
            _client = client;
            _maxTransferSize = maxTransferSize;
            _includeNonFinalizedEvents = includeNonFinalizedEvents;
            _policy = policy;
            _startTime = startTime;
            _endTime = endTime;
            _continuation = continuation;
            _isBatched = isBatched;
        }

        public override IEnumerable<Page<ShareChangeFeedEvent>> AsPages(
            string continuationToken = null,
            int? pageSizeHint = null)
        {
            if (continuationToken != null)
                throw new ArgumentException("Continuation not supported. Use ShareChangeFeedClient.GetChanges(string) instead.");

            (BlobContainerClient containerClient, ChangeFeedConfiguration<ShareChangeFeedEvent> config) = _client.ResolveContainerAsync(async: false, cancellationToken: default).EnsureCompleted();

            // Deserialize the outer Files-only envelope on resume so we can compare the
            // last-seen reset marker against the current pointer.
            ShareChangeFeedCursor outerCursor = null;
            ChangeFeedCursor innerCursor = null;
            Guid? lastSeenResetId = null;
            long? lastSeenResetFileTime = null;

            // Range bounds and batched intent default to the values captured at construction.
            // On resume they are recovered from the token so a batched query keeps its range
            // (and its policy default) instead of degrading to unbounded streaming behavior.
            DateTimeOffset? rangeStart = _startTime;
            DateTimeOffset? rangeEnd = _endTime;
            bool isBatched = _isBatched;
            ShareChangeFeedResetPolicy effectivePolicy = _policy;

            if (_continuation != null)
            {
                outerCursor = ShareChangeFeedCursorSerializer.Deserialize(_continuation);
                ShareChangeFeedCursorSerializer.Validate(containerClient, outerCursor);
                innerCursor = outerCursor.InnerCursor;
                lastSeenResetId = outerCursor.LastSeenResetId;
                lastSeenResetFileTime = outerCursor.LastSeenResetFileTime;
                rangeStart = outerCursor.RangeStart;
                rangeEnd = outerCursor.RangeEnd;
                isBatched = outerCursor.IsBatched;

                // Resume via the single GetChanges(continuationToken) overload cannot know
                // statically whether the original query was batched, so resolve the effective
                // policy from the intent persisted on the token.
                effectivePolicy = _client.ResolveEffectivePolicy(isBatched);
            }

            // Read the reset pointer once at the start of enumeration. Detection is decided
            // against either the resume state (last-seen FILETIME) or the requested range.
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
                bool shouldSurface = ResetDetector.ShouldSurface(
                    resetTime,
                    pointer.LatestResetFileTime,
                    pointer.LatestResetId,
                    lastSeenResetFileTime,
                    lastSeenResetId,
                    rangeStart: rangeStart,
                    rangeEnd: rangeEnd);

                if (shouldSurface)
                {
                    ShareChangeFeedResetMarker perEvent = ResetMarkerReader.ReadPerEventAsync(
                        containerClient,
                        pointer.LatestMarkerPath,
                        async: false,
                        cancellationToken: default)
                        .EnsureCompleted();

                    resetToEmit = ResetMarkerReader.BuildResetEvent(pointer, perEvent);

                    if (effectivePolicy == ShareChangeFeedResetPolicy.ThrowOnReset)
                    {
                        throw new ShareChangeFeedResetException(resetToEmit);
                    }
                }
            }

            ChangeFeedFactoryBase<ShareChangeFeedEvent> factory = new ChangeFeedFactoryBase<ShareChangeFeedEvent>(
                containerClient,
                _maxTransferSize,
                config,
                _includeNonFinalizedEvents);

            ChangeFeedBase<ShareChangeFeedEvent> changeFeed = innerCursor != null
                ? factory.BuildChangeFeed(
                    innerCursor,
                    async: false,
                    cancellationToken: default)
                    .EnsureCompleted()
                : factory.BuildChangeFeed(
                    _startTime,
                    _endTime,
                    continuation: null,
                    async: false,
                    cancellationToken: default)
                    .EnsureCompleted();

            bool resetEmitted = false;
            int pageSize = pageSizeHint ?? Constants.ChangeFeed.DefaultPageSize;

            while (changeFeed.HasNext())
            {
                Page<ShareChangeFeedEvent> rawPage = changeFeed.GetPage(
                    async: false,
                    pageSize: pageSize)
                    .EnsureCompleted();

                List<ShareChangeFeedEvent> events = new List<ShareChangeFeedEvent>();
                foreach (ShareChangeFeedEvent evt in rawPage.Values)
                {
                    if (!resetEmitted && resetToEmit != null && evt.EventTime >= resetTime)
                    {
                        events.Add(resetToEmit);
                        resetEmitted = true;
                    }

                    events.Add(evt);
                }

                // If the reset falls after every event in this page (or the page was empty),
                // emit it on the terminal page below.

                long? nextFileTime = resetEmitted
                    ? pointer?.LatestResetFileTime ?? lastSeenResetFileTime
                    : lastSeenResetFileTime;
                Guid? nextId = resetEmitted
                    ? pointer?.LatestResetId ?? lastSeenResetId
                    : lastSeenResetId;

                // The underlying page contains a JSON-serialized ChangeFeedCursor. Use the
                // typed accessor to avoid a JSON round-trip when the read is finalized; in
                // non-finalized mode ChangeFeedBase suppresses the token and we surface null.
                ChangeFeedCursor typedInner = rawPage.ContinuationToken != null
                    ? changeFeed.GetCursor()
                    : null;

                string outerToken = BuildOuterToken(
                    containerClient,
                    typedInner,
                    nextId,
                    nextFileTime,
                    rangeStart,
                    rangeEnd,
                    isBatched);

                yield return new ChangeFeedEventPageBase<ShareChangeFeedEvent>(events, outerToken);
            }

            // Emit any pending reset event that hadn't yet been surfaced (e.g., reset time
            // sits after every event returned above, or the underlying feed was empty).
            if (!resetEmitted && resetToEmit != null)
            {
                List<ShareChangeFeedEvent> tail = new List<ShareChangeFeedEvent> { resetToEmit };
                string outerToken = BuildOuterToken(
                    containerClient,
                    innerCursor: null,
                    pointer.LatestResetId,
                    pointer.LatestResetFileTime,
                    rangeStart,
                    rangeEnd,
                    isBatched);
                yield return new ChangeFeedEventPageBase<ShareChangeFeedEvent>(tail, outerToken);
            }
        }

        /// <summary>
        /// Wraps the inner Common change-feed cursor in the Files-only outer envelope so that
        /// the last-seen reset marker travels alongside the underlying position.
        /// </summary>
        private static string BuildOuterToken(
            BlobContainerClient containerClient,
            ChangeFeedCursor innerCursor,
            Guid? lastSeenResetId,
            long? lastSeenResetFileTime,
            DateTimeOffset? rangeStart,
            DateTimeOffset? rangeEnd,
            bool isBatched)
        {
            if (innerCursor == null && !lastSeenResetId.HasValue && !lastSeenResetFileTime.HasValue)
            {
                // Terminal / non-finalized read: the underlying feed suppresses its own token
                // and no reset state to carry forward — mirror the Common contract.
                return null;
            }

            ShareChangeFeedCursor outer = new ShareChangeFeedCursor(
                urlHost: containerClient.Uri.Host,
                innerCursor: innerCursor,
                lastSeenResetId: lastSeenResetId,
                lastSeenResetFileTime: lastSeenResetFileTime,
                rangeStart: rangeStart,
                rangeEnd: rangeEnd,
                isBatched: isBatched);

            return ShareChangeFeedCursorSerializer.Serialize(outer);
        }
    }
}
