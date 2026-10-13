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

        public static ArgumentException StartAfterEnd(DateTimeOffset start, DateTimeOffset end)
            => new ArgumentException(
                $"start ({start:O}) must be earlier than or equal to end ({end:O}).",
                "start");

        public static ArgumentException ContinuationNotSupportedOnPageable(string resumeMethodSignature)
            => new ArgumentException(
                $"Continuation not supported. Use {resumeMethodSignature} instead.");

        public static ArgumentException BeginSnapshotDoesNotMatchCursor(string paramName)
            => new ArgumentException(
                "Begin snapshot supplied to the pageable does not match the snapshot " +
                "embedded in the continuation token.",
                paramName);

        public static ArgumentException EndSnapshotDoesNotMatchCursor(string paramName)
            => new ArgumentException(
                "End snapshot supplied to the pageable does not match the snapshot " +
                "embedded in the continuation token.",
                paramName);

        public static ArgumentException InvalidCursorEnvelope(string paramName, Exception inner = null)
            => inner == null
                ? new ArgumentException(
                    "Continuation token is not a valid Files change feed cursor envelope.",
                    paramName)
                : new ArgumentException(
                    "Continuation token is not a valid Files change feed cursor envelope.",
                    paramName,
                    inner);

        public static ArgumentException InvalidSnapshotCursorEnvelope(string paramName, Exception inner = null)
            => inner == null
                ? new ArgumentException(
                    "Continuation token is not a valid snapshot cursor envelope.",
                    paramName)
                : new ArgumentException(
                    "Continuation token is not a valid snapshot cursor envelope.",
                    paramName,
                    inner);

        public static ArgumentException MissingSnapshotContext(string paramName)
            => new ArgumentException(
                "Continuation token is missing required snapshot context.",
                paramName);

        public static ArgumentException CursorUrlHostMismatch()
            => new ArgumentException("Cursor URL Host does not match container URL host.");

        public static ArgumentException UnsupportedCursorVersion()
            => new ArgumentException("Unsupported cursor version.");

        public static InvalidOperationException MissingResetMarkerPath()
            => new InvalidOperationException(
                "Reset marker pointer did not include a target marker path.");

        public static InvalidOperationException ResetMarkerPathBadPrefix(string markerPath, string expectedPrefix)
            => new InvalidOperationException(
                $"Reset marker path '{markerPath}' does not begin with the expected prefix " +
                $"'{expectedPrefix}'.");

        public static InvalidOperationException PerEventResetMarkerNotFound(string markerPath, Exception inner)
            => new InvalidOperationException(
                $"Reset marker pointer references '{markerPath}' but that per-event blob was not found. " +
                "The reset marker set may still be publishing.",
                inner);

        public static FormatException ResetMarkerMissingField(string path, string field)
            => new FormatException($"Reset marker at '{path}' is missing required field '{field}'.");

        public static FormatException ResetMarkerFieldNull(string path, string field)
            => new FormatException($"Reset marker at '{path}' field '{field}' is null.");

        public static FormatException ResetMarkerFieldNotValidType(string path, string field, string typeName, Exception inner)
            => new FormatException(
                $"Reset marker at '{path}' field '{field}' is not a valid {typeName}.",
                inner);

        public static FormatException ResetMarkerFieldNotValidValue(string path, string field, string typeName, string value)
            => new FormatException($"Reset marker at '{path}' field '{field}' is not a valid {typeName}: '{value}'.");

        public static FormatException EventMissingField(string key)
            => new FormatException($"Change feed event is missing required field '{key}'.");

        public static FormatException EventFieldNull(string key)
            => new FormatException($"Change feed event field '{key}' is null.");

        public static FormatException EventFieldWrongType(string key, string expectedType, string actualType)
            => new FormatException($"Change feed event field '{key}' must be a {expectedType} but was {actualType}.");

        public static FormatException EventFieldNotValidDateTimeOffset(string field, string value, Exception inner)
            => new FormatException(
                $"Change feed event field '{field}' is not a valid DateTimeOffset: '{value}'.",
                inner);

        public static ArgumentException SnapshotMetadataNotFound(string snapshotTimestamp, string path, Exception inner)
            => new ArgumentException(
                $"Snapshot metadata not found for timestamp '{snapshotTimestamp}' (path: {path}). " +
                "Verify that a share snapshot was taken at this time and that the change feed has finished publishing its metadata.",
                inner);

        public static FormatException SnapshotFieldMissing(string path, string field)
            => new FormatException($"Snapshot metadata at '{path}' is missing required field '{field}'.");

        public static FormatException SnapshotFieldNull(string path, string field)
            => new FormatException($"Snapshot metadata at '{path}' field '{field}' is null.");

        public static FormatException SnapshotFieldNotValidType(string path, string field, string typeName, Exception inner)
            => new FormatException(
                $"Snapshot metadata at '{path}' field '{field}' is not a valid {typeName}.",
                inner);
    }
}
