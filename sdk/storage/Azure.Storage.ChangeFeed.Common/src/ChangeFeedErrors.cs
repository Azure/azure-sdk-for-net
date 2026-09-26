// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.ChangeFeed.Common
{
    /// <summary>
    /// Creates exceptions for error cases shared across the Change Feed packages.
    /// Factory methods return (rather than throw) the exception so callers write
    /// <c>throw ChangeFeedErrors.X(...)</c> at the throw site.
    /// </summary>
    internal static class ChangeFeedErrors
    {
        public static InvalidOperationException ChangeFeedNotEnabled()
            => new InvalidOperationException(
                "Change Feed is not enabled on this account, or is currently being enabled.");

        public static ArgumentException CursorHostMismatch(string paramName)
            => new ArgumentException(
                "The continuation token was issued for a different storage account host and cannot be used here.",
                paramName);

        public static ArgumentException UnsupportedCursorVersion(string paramName)
            => new ArgumentException(
                "The continuation token uses an unsupported cursor version.",
                paramName);

        public static ArgumentException MalformedContinuationToken(string paramName, Exception inner)
            => new ArgumentException(
                "The continuation token is malformed and could not be parsed.",
                paramName,
                inner);

        public static ArgumentException InvalidSegmentPath(string segmentPath)
            => new ArgumentException(
                $"'{segmentPath}' is not a valid change feed segment path.");

        public static ArgumentException StartAfterEnd(DateTimeOffset start, DateTimeOffset end, string paramName)
            => new ArgumentException(
                $"'{start:O}' must be earlier than or equal to '{end:O}'.",
                paramName);

        public static ArgumentException ContinuationNotSupportedWithNonFinalized(string optionsTypeName, string paramName)
            => new ArgumentException(
                $"Resuming from a continuation token is not supported when IncludeNonFinalizedEvents is enabled on {optionsTypeName}. " +
                "Non-finalized reads do not produce continuation tokens because segments past the finalized watermark may change between calls. " +
                "Disable IncludeNonFinalizedEvents to resume from a saved position.",
                paramName);

        public static ArgumentNullException NullContinuation(string paramName)
            => new ArgumentNullException(paramName);
    }
}
