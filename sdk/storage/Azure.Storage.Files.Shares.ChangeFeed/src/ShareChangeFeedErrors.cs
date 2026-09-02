// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Files.Shares.ChangeFeed
{
    /// <summary>
    /// Creates exceptions for error cases unique to the Files Share Change Feed package.
    /// Factory methods return (rather than throw) the exception so callers write
    /// <c>throw ShareChangeFeedErrors.X(...)</c> at the throw site.
    /// </summary>
    internal static class ShareChangeFeedErrors
    {
        public static ArgumentNullException ArgumentNull(string paramName)
            => new ArgumentNullException(paramName);

        public static ArgumentException ContinuationNotSupportedWithNonFinalized(string paramName)
            => new ArgumentException(
                $"Resuming from a continuation token is not supported when " +
                $"{nameof(ShareChangeFeedClientOptions.IncludeNonFinalizedEvents)} is enabled on " +
                $"{nameof(ShareChangeFeedClientOptions)}. Non-finalized reads do not produce continuation tokens " +
                "because segments past the finalized watermark may change between calls. Disable " +
                $"{nameof(ShareChangeFeedClientOptions.IncludeNonFinalizedEvents)} to resume from a saved position.",
                paramName);

        public static InvalidOperationException ChangeFeedNotEnabledForShare(string shareName)
            => new InvalidOperationException(
                $"Change Feed is not enabled for share '{shareName}'. " +
                "Enable it by setting 'x-ms-file-enable-change-feed: true' when creating or updating the share.");

        public static RequestFailedException ChangeFeedContainerHeaderEmpty(Response response, string shareName)
            => new RequestFailedException(
                response,
                new InvalidOperationException(
                    $"The Change Feed container header for share '{shareName}' was present but empty. " +
                    "The service returned an unexpected response."));

        public static RequestFailedException ChangeFeedContainerBadPrefix(Response response, string containerName, string shareName)
            => new RequestFailedException(
                response,
                new InvalidOperationException(
                    $"The Change Feed container name '{containerName}' for share '{shareName}' does not begin with the expected '$' prefix. " +
                    "The service returned an unexpected response."));

        public static ArgumentException InvalidSnapshotTimestamp(string snapshot, string paramName)
            => new ArgumentException(
                $"'{snapshot}' is not a valid UTC ISO 8601 snapshot timestamp (must end with 'Z').",
                paramName);

        public static ArgumentException SnapshotNotFinalized(string snapshotLabel, string snapshot, string status, string paramName)
            => new ArgumentException(
                $"{snapshotLabel} snapshot '{snapshot}' is not finalized (status: {status}). " +
                "Wait for the snapshot to be finalized before querying.",
                paramName);

        public static ArgumentException BeginSnapshotAfterEnd(
            string beginSnapshot,
            DateTimeOffset beginTimestamp,
            string endSnapshot,
            DateTimeOffset endTimestamp,
            string paramName)
            => new ArgumentException(
                $"Begin snapshot '{beginSnapshot}' (taken {beginTimestamp:O}) is later than " +
                $"end snapshot '{endSnapshot}' (taken {endTimestamp:O}).",
                paramName);

        public static ArgumentException BeginSnapshotCvIdExceedsEnd(long beginCvId, long endCvId, string paramName)
            => new ArgumentException(
                $"Begin snapshot CvId ({beginCvId}) exceeds end snapshot CvId ({endCvId}).",
                paramName);

        public static ArgumentException EmptySnapshotRange(long cvId, string paramName)
            => new ArgumentException(
                $"Begin and end snapshots have the same CvId ({cvId}); the query range is empty.",
                paramName);
    }
}
