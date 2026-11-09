// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Blobs.ChangeFeed
{
    /// <summary>
    /// Creates exceptions for error cases unique to the Blob Change Feed package.
    /// Factory methods return (rather than throw) the exception so callers write
    /// <c>throw BlobChangeFeedErrors.X(...)</c> at the throw site.
    /// </summary>
    internal static class BlobChangeFeedErrors
    {
        public static ArgumentException ContinuationNotSupportedWithNonFinalized(string paramName)
            => new ArgumentException(
                $"Resuming from a continuation token is not supported when " +
                $"{nameof(BlobChangeFeedClientOptions.IncludeNonFinalizedEvents)} is enabled on " +
                $"{nameof(BlobChangeFeedClientOptions)}. Non-finalized reads do not produce continuation tokens " +
                "because segments past the finalized watermark may change between calls. Disable " +
                $"{nameof(BlobChangeFeedClientOptions.IncludeNonFinalizedEvents)} to resume from a saved position.",
                paramName);
    }
}
