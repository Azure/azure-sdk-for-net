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

        internal ShareChangeFeedPageable(
            ShareChangeFeedClient client,
            long? maxTransferSize,
            bool includeNonFinalizedEvents,
            ShareChangeFeedResetPolicy policy = ShareChangeFeedResetPolicy.ContinueOnReset,
            DateTimeOffset? startTime = default,
            DateTimeOffset? endTime = default,
            string continuation = default)
        {
            _client = client;
            _maxTransferSize = maxTransferSize;
            _includeNonFinalizedEvents = includeNonFinalizedEvents;
            _policy = policy;
            _startTime = startTime;
            _endTime = endTime;
            _continuation = continuation;
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
            if (_continuation != null)
            {
                outerCursor = ShareChangeFeedCursorSerializer.Deserialize(_continuation);
                ShareChangeFeedCursorSerializer.Validate(containerClient, outerCursor);
                innerCursor = outerCursor.InnerCursor;
                lastSeenResetId = outerCursor.LastSeenResetId;
                lastSeenResetFileTime = outerCursor.LastSeenResetFileTime;
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
                bool resetIsNewer = !lastSeenResetFileTime.HasValue
                    || pointer.LatestResetFileTime > lastSeenResetFileTime.Value;
                bool resetInRange = _startTime.HasValue
                    && _endTime.HasValue
                    && resetTime >= _startTime.Value
                    && resetTime <= _endTime.Value;

                bool shouldSurface = resetIsNewer && (
                    // Streaming (no bounded range): surface when strictly newer than resume.
                    (!_startTime.HasValue && !_endTime.HasValue)
                    // Bounded range: surface only when reset falls inside the range.
                    || resetInRange);

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
                    nextFileTime);

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
                    pointer.LatestResetFileTime);
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
            long? lastSeenResetFileTime)
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
                lastSeenResetFileTime: lastSeenResetFileTime);

            return ShareChangeFeedCursorSerializer.Serialize(outer);
        }
    }
}
