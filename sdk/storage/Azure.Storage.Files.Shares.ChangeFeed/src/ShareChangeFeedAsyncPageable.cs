// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Storage.Blobs;
using Azure.Storage.ChangeFeed.Common;

namespace Azure.Storage.Files.Shares.ChangeFeed
{
    internal class ShareChangeFeedAsyncPageable : AsyncPageable<ShareChangeFeedEvent>
    {
        private readonly ShareChangeFeedClient _client;
        private readonly long? _maxTransferSize;
        private readonly bool _includeNonFinalizedEvents;
        private readonly DateTimeOffset? _startTime;
        private readonly DateTimeOffset? _endTime;
        private readonly string _continuation;
        private readonly ShareChangeFeedResetPolicy _policy;
        private readonly bool _isBatched;

        internal ShareChangeFeedAsyncPageable(
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

        public override async IAsyncEnumerable<Page<ShareChangeFeedEvent>> AsPages(
            string continuationToken = null,
            int? pageSizeHint = null)
        {
            if (continuationToken != null)
                throw new ArgumentException("Continuation not supported. Use ShareChangeFeedClient.GetChangesAsync(string) instead.");

            (BlobContainerClient containerClient, ChangeFeedConfiguration<ShareChangeFeedEvent> config) = await _client.ResolveContainerAsync(
                async: true,
                cancellationToken: default)
                .ConfigureAwait(false);

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

                // Resume via the single GetChangesAsync(continuationToken) overload cannot know
                // statically whether the original query was batched, so resolve the effective
                // policy from the intent persisted on the token.
                effectivePolicy = _client.ResolveEffectivePolicy(isBatched);
            }

            // Read the reset pointer once at the start of enumeration. Detection is decided
            // against either the resume state (last-seen FILETIME) or the requested range.
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
                    ShareChangeFeedResetMarker perEvent = await ResetMarkerReader.ReadPerEventAsync(
                        containerClient,
                        pointer.LatestMarkerPath,
                        async: true,
                        cancellationToken: default)
                        .ConfigureAwait(false);

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
                ? await factory.BuildChangeFeed(
                    innerCursor,
                    async: true,
                    cancellationToken: default)
                    .ConfigureAwait(false)
                : await factory.BuildChangeFeed(
                    _startTime,
                    _endTime,
                    continuation: null,
                    async: true,
                    cancellationToken: default)
                    .ConfigureAwait(false);

            bool resetEmitted = false;
            int pageSize = pageSizeHint ?? Constants.ChangeFeed.DefaultPageSize;

            while (changeFeed.HasNext())
            {
                Page<ShareChangeFeedEvent> rawPage = await changeFeed.GetPage(
                    async: true,
                    pageSize: pageSize)
                    .ConfigureAwait(false);

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

                long? nextFileTime = resetEmitted
                    ? pointer?.LatestResetFileTime ?? lastSeenResetFileTime
                    : lastSeenResetFileTime;
                Guid? nextId = resetEmitted
                    ? pointer?.LatestResetId ?? lastSeenResetId
                    : lastSeenResetId;

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
