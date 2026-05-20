// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.ChangeFeed.Common;

namespace Azure.Storage.Files.Shares.ChangeFeed
{
    /// <summary>
    /// Shared setup state for <see cref="ShareChangeFeedSnapshotPageable"/> and
    /// <see cref="ShareChangeFeedSnapshotAsyncPageable"/>. Resolves the snapshot context
    /// (either by reading the begin/end <c>meta.json</c> blobs on a fresh enumeration
    /// or by deserializing a <see cref="ShareChangeFeedSnapshotCursor"/> on resume),
    /// builds the underlying <see cref="ChangeFeedBase{TEvent}"/>, and emits the
    /// snapshot-aware continuation token wrapping the inner change-feed cursor.
    /// </summary>
    internal class ShareChangeFeedSnapshotIteration
    {
        public ChangeFeedBase<ShareChangeFeedEvent> ChangeFeed { get; }
        public string BeginSnapshot { get; }
        public string EndSnapshot { get; }
        public long BeginCvId { get; }
        public long EndCvId { get; }

        private ShareChangeFeedSnapshotIteration(
            ChangeFeedBase<ShareChangeFeedEvent> changeFeed,
            string beginSnapshot,
            string endSnapshot,
            long beginCvId,
            long endCvId)
        {
            ChangeFeed = changeFeed;
            BeginSnapshot = beginSnapshot;
            EndSnapshot = endSnapshot;
            BeginCvId = beginCvId;
            EndCvId = endCvId;
        }

        /// <summary>
        /// Builds the iteration state. When <paramref name="continuation"/> is non-null, the
        /// snapshot context is recovered from the cursor envelope and the inner change-feed
        /// reader is resumed from its embedded position; otherwise both snapshot
        /// <c>meta.json</c> blobs are downloaded and validated.
        /// </summary>
        public static async Task<ShareChangeFeedSnapshotIteration> CreateAsync(
            BlobContainerClient containerClient,
            ChangeFeedConfiguration<ShareChangeFeedEvent> config,
            long? maxTransferSize,
            string beginSnapshot,
            string endSnapshot,
            string continuation,
            bool async,
            CancellationToken cancellationToken)
        {
            string effectiveBegin;
            string effectiveEnd;
            long beginCvId;
            long endCvId;
            string innerContinuation;
            DateTimeOffset? startTime = null;
            DateTimeOffset? endTime = null;

            if (continuation != null)
            {
                ShareChangeFeedSnapshotCursor cursor = SnapshotCursorSerializer.Deserialize(continuation);
                SnapshotCursorSerializer.Validate(containerClient, cursor);

                // If the caller also supplied begin/end snapshot strings (i.e. they kept calling
                // GetChangesBetweenSnapshots(begin, end) and then passed a token to AsPages),
                // require those strings to match the ones captured on the cursor. Mismatch means
                // the caller is trying to splice resume state from a different query, which would
                // silently change the cvId filter range.
                if (beginSnapshot != null
                    && !string.Equals(beginSnapshot, cursor.BeginSnapshot, StringComparison.Ordinal))
                {
                    throw new ArgumentException(
                        "Begin snapshot supplied to the pageable does not match the snapshot " +
                        "embedded in the continuation token.",
                        nameof(continuation));
                }
                if (endSnapshot != null
                    && !string.Equals(endSnapshot, cursor.EndSnapshot, StringComparison.Ordinal))
                {
                    throw new ArgumentException(
                        "End snapshot supplied to the pageable does not match the snapshot " +
                        "embedded in the continuation token.",
                        nameof(continuation));
                }

                effectiveBegin = cursor.BeginSnapshot;
                effectiveEnd = cursor.EndSnapshot;
                beginCvId = cursor.BeginCvId;
                endCvId = cursor.EndCvId;
                innerContinuation = cursor.InnerContinuation;
                // startTime/endTime stay null: the inner cursor encodes its own position and
                // ChangeFeedFactoryBase.BuildChangeFeed will overwrite both from the cursor.
            }
            else
            {
                SnapshotMetadata beginMeta = await SnapshotQueryHelper.ReadSnapshotMetadataAsync(
                    containerClient,
                    beginSnapshot,
                    async: async,
                    cancellationToken: cancellationToken)
                    .ConfigureAwait(false);

                SnapshotMetadata endMeta = await SnapshotQueryHelper.ReadSnapshotMetadataAsync(
                    containerClient,
                    endSnapshot,
                    async: async,
                    cancellationToken: cancellationToken)
                    .ConfigureAwait(false);

                SnapshotInputValidator.ValidateMetadata(beginMeta, beginSnapshot, endMeta, endSnapshot);

                effectiveBegin = beginSnapshot;
                effectiveEnd = endSnapshot;
                beginCvId = beginMeta.CvId;
                endCvId = endMeta.CvId;
                innerContinuation = null;

                // The log-window times bound only which Avro segments are read. Rows inside those
                // segments are filtered solely by container version id (see SnapshotEventFilter):
                // disableEventTimeFilter keeps the segment selection but suppresses any per-event
                // EventTime filtering, which would otherwise drop every row when the begin/end log
                // windows fall in the same minute bucket.
                startTime = beginMeta.MinLogWindowForNextSnapshot;
                endTime = endMeta.MaxLogWindowForCurrentSnapshot;
            }

            ChangeFeedFactoryBase<ShareChangeFeedEvent> factory = new ChangeFeedFactoryBase<ShareChangeFeedEvent>(
                containerClient,
                maxTransferSize,
                config);

            ChangeFeedBase<ShareChangeFeedEvent> changeFeed = await factory.BuildChangeFeed(
                startTime,
                endTime,
                continuation: innerContinuation,
                async: async,
                cancellationToken: cancellationToken,
                disableEventTimeFilter: true)
                .ConfigureAwait(false);

            return new ShareChangeFeedSnapshotIteration(
                changeFeed,
                effectiveBegin,
                effectiveEnd,
                beginCvId,
                endCvId);
        }

        /// <summary>
        /// Wraps the raw inner continuation token from a <see cref="ChangeFeedBase{TEvent}"/>
        /// page in a <see cref="ShareChangeFeedSnapshotCursor"/> envelope carrying the snapshot
        /// context, then serializes it for use as the outer page's continuation token.
        /// Returns <c>null</c> when the inner reader did not emit a token (terminal page).
        /// </summary>
        public string WrapInnerContinuation(BlobContainerClient containerClient, string innerContinuation)
        {
            if (innerContinuation == null)
                return null;

            ShareChangeFeedSnapshotCursor envelope = new ShareChangeFeedSnapshotCursor(
                urlHost: containerClient.Uri.Host,
                beginSnapshot: BeginSnapshot,
                endSnapshot: EndSnapshot,
                beginCvId: BeginCvId,
                endCvId: EndCvId,
                innerContinuation: innerContinuation);

            return SnapshotCursorSerializer.Serialize(envelope);
        }
    }
}
