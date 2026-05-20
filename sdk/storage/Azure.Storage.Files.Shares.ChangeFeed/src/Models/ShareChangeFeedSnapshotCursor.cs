// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.ChangeFeed.Common;

namespace Azure.Storage.Files.Shares.ChangeFeed
{
    /// <summary>
    /// Resume envelope produced by <see cref="ShareChangeFeedSnapshotPageable"/> and
    /// <see cref="ShareChangeFeedSnapshotAsyncPageable"/>. Wraps the underlying change-feed
    /// cursor plus the snapshot context (snapshot identifiers and container version range)
    /// needed to keep applying the cvId filter when resuming after a page boundary.
    /// </summary>
    /// <remarks>
    /// Persisted as the JSON-serialized <see cref="Page{T}.ContinuationToken"/> string on
    /// pages emitted by the snapshot pageables. Carrying the cvId range and snapshot
    /// strings on the token lets resume skip re-downloading both snapshot
    /// <c>meta.json</c> blobs (and re-running their validation) on every restart.
    /// </remarks>
    internal class ShareChangeFeedSnapshotCursor
    {
        /// <summary>
        /// Schema version of the snapshot cursor envelope. Pinned at 1 today; bump and gate
        /// in <see cref="SnapshotCursorSerializer.Validate"/> when the shape changes.
        /// </summary>
        public int CursorVersion { get; set; }

        /// <summary>
        /// Host portion of the change-feed container URL, used to validate that a cursor
        /// matches the target account. Mirrors <c>ChangeFeedCursor.UrlHost</c> from common.
        /// </summary>
        public string UrlHost { get; set; }

        /// <summary>
        /// The begin snapshot timestamp string originally supplied to
        /// <c>GetChangesBetweenSnapshots</c>. Round-tripped on every emitted page so a
        /// caller resuming via <c>GetChangesBetweenSnapshots(continuationToken)</c> does
        /// not need to retain the original input strings.
        /// </summary>
        public string BeginSnapshot { get; set; }

        /// <summary>
        /// The end snapshot timestamp string originally supplied to
        /// <c>GetChangesBetweenSnapshots</c>.
        /// </summary>
        public string EndSnapshot { get; set; }

        /// <summary>
        /// Cached container version id from the begin snapshot's <c>meta.json</c>. Carrying
        /// this on the token lets resume skip re-downloading the begin snapshot meta blob.
        /// </summary>
        public long BeginCvId { get; set; }

        /// <summary>
        /// Cached container version id from the end snapshot's <c>meta.json</c>.
        /// </summary>
        public long EndCvId { get; set; }

        /// <summary>
        /// Typed inner cursor from the underlying change-feed reader, captured on the raw
        /// page that produced the events in this envelope. Forwarded back into
        /// <see cref="ChangeFeedFactoryBase{TEvent}.BuildChangeFeed(ChangeFeedCursor, bool, System.Threading.CancellationToken, bool)"/>
        /// on resume so the cursor crosses the layer boundary as an object instead of being
        /// re-serialized to a string only to be re-parsed inside common.
        /// </summary>
        public ChangeFeedCursor InnerCursor { get; set; }

        /// <summary>
        /// Parameterless constructor for <c>JsonSerializer</c>.
        /// </summary>
        public ShareChangeFeedSnapshotCursor() { }

        /// <summary>
        /// Initializes a new envelope with the snapshot context and typed inner cursor.
        /// </summary>
        internal ShareChangeFeedSnapshotCursor(
            string urlHost,
            string beginSnapshot,
            string endSnapshot,
            long beginCvId,
            long endCvId,
            ChangeFeedCursor innerCursor)
        {
            CursorVersion = 1;
            UrlHost = urlHost;
            BeginSnapshot = beginSnapshot;
            EndSnapshot = endSnapshot;
            BeginCvId = beginCvId;
            EndCvId = endCvId;
            InnerCursor = innerCursor;
        }
    }
}
