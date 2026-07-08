// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace Azure.Storage.Files.Shares.ChangeFeed
{
    /// <summary>
    /// Helper for reading Files Change Feed reset markers from the change feed container.
    /// Reset markers are emitted on events such as HardFailover or classic account migration
    /// and signal that the log-sequence continuity has been broken from that point onward.
    /// </summary>
    internal static class ResetMarkerReader
    {
        /// <summary>
        /// Attempts to download and parse the mutable pointer blob
        /// <c>meta/reset-latest.json</c>. Returns <c>null</c> when the pointer blob does not
        /// exist (i.e. the share has never emitted a reset).
        /// </summary>
        /// <param name="containerClient">Blob container client for the change feed container.</param>
        /// <param name="async">Whether to execute the download asynchronously.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>
        /// A <see cref="ShareChangeFeedResetPointer"/> parsed from the JSON content, or
        /// <c>null</c> when the pointer blob is not found.
        /// </returns>
        internal static async Task<ShareChangeFeedResetPointer> TryReadPointerAsync(
            BlobContainerClient containerClient,
            bool async,
            CancellationToken cancellationToken)
        {
            BlobClient blobClient = containerClient.GetBlobClient(Constants.FilesChangeFeed.ResetLatestJsonPath);
            BlobDownloadStreamingResult result;

            try
            {
                if (async)
                {
                    result = await blobClient.DownloadStreamingAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    result = blobClient.DownloadStreaming(cancellationToken: cancellationToken);
                }
            }
            catch (RequestFailedException ex) when (ex.ErrorCode == BlobErrorCode.BlobNotFound)
            {
                return null;
            }

            return await ParsePointerAsync(result, async, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Downloads and parses a per-event reset marker blob referenced by
        /// <see cref="ShareChangeFeedResetPointer.LatestMarkerPath"/>. Validates that the path
        /// stays under the expected <c>meta/resets/</c> prefix to guard against a malformed
        /// pointer redirecting the reader outside the reset marker area.
        /// </summary>
        /// <param name="containerClient">Blob container client for the change feed container.</param>
        /// <param name="markerPath">Relative blob key for the per-event marker.</param>
        /// <param name="async">Whether to execute the download asynchronously.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>A <see cref="ShareChangeFeedResetMarker"/> parsed from the JSON content.</returns>
        internal static async Task<ShareChangeFeedResetMarker> ReadPerEventAsync(
            BlobContainerClient containerClient,
            string markerPath,
            bool async,
            CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(markerPath))
            {
                throw new InvalidOperationException(
                    "Reset marker pointer did not include a target marker path.");
            }

            if (!markerPath.StartsWith(Constants.FilesChangeFeed.ResetEventPrefix, StringComparison.Ordinal))
            {
                throw new InvalidOperationException(
                    $"Reset marker path '{markerPath}' does not begin with the expected prefix " +
                    $"'{Constants.FilesChangeFeed.ResetEventPrefix}'.");
            }

            BlobClient blobClient = containerClient.GetBlobClient(markerPath);
            BlobDownloadStreamingResult result;

            try
            {
                if (async)
                {
                    result = await blobClient.DownloadStreamingAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    result = blobClient.DownloadStreaming(cancellationToken: cancellationToken);
                }
            }
            catch (RequestFailedException ex) when (ex.ErrorCode == BlobErrorCode.BlobNotFound)
            {
                throw new InvalidOperationException(
                    $"Reset marker pointer references '{markerPath}' but that per-event blob was not found. " +
                    "The reset marker set may still be publishing.",
                    ex);
            }

            return await ParsePerEventAsync(result, markerPath, async, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Builds a <see cref="ShareChangeFeedResetEvent"/> from a pointer + per-event pair.
        /// The event surfaces on the change feed stream at the reset's event time.
        /// </summary>
        internal static ShareChangeFeedResetEvent BuildResetEvent(
            ShareChangeFeedResetPointer pointer,
            ShareChangeFeedResetMarker perEvent)
        {
            if (pointer == null)
                throw new ArgumentNullException(nameof(pointer));
            if (perEvent == null)
                throw new ArgumentNullException(nameof(perEvent));

            return new ShareChangeFeedResetEvent(pointer, perEvent);
        }

        private static async Task<ShareChangeFeedResetPointer> ParsePointerAsync(
            BlobDownloadStreamingResult result,
            bool async,
            CancellationToken cancellationToken)
        {
            JsonDocument json = null;
            try
            {
                if (async)
                {
                    json = await JsonDocument.ParseAsync(result.Content, cancellationToken: cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    json = JsonDocument.Parse(result.Content);
                }

                JsonElement root = json.RootElement;
                string path = Constants.FilesChangeFeed.ResetLatestJsonPath;

                return new ShareChangeFeedResetPointer
                {
                    SchemaVersion = RequireInt32(root, Constants.FilesChangeFeed.ResetPointer.SchemaVersion, path),
                    LatestResetId = RequireGuid(root, Constants.FilesChangeFeed.ResetPointer.LatestResetId, path),
                    LatestResetFileTime = RequireInt64(root, Constants.FilesChangeFeed.ResetPointer.LatestResetFileTime, path),
                    LatestResetTimeUtc = RequireDateTimeOffset(root, Constants.FilesChangeFeed.ResetPointer.LatestResetTimeUtc, path),
                    LatestMarkerPath = RequireString(root, Constants.FilesChangeFeed.ResetPointer.LatestMarkerPath, path),
                    AccountName = RequireString(root, Constants.FilesChangeFeed.ResetPointer.AccountName, path),
                    ContainerName = RequireString(root, Constants.FilesChangeFeed.ResetPointer.ContainerName, path),
                    Reason = RequireString(root, Constants.FilesChangeFeed.ResetPointer.Reason, path),
                };
            }
            finally
            {
                json?.Dispose();
            }
        }

        private static async Task<ShareChangeFeedResetMarker> ParsePerEventAsync(
            BlobDownloadStreamingResult result,
            string path,
            bool async,
            CancellationToken cancellationToken)
        {
            JsonDocument json = null;
            try
            {
                if (async)
                {
                    json = await JsonDocument.ParseAsync(result.Content, cancellationToken: cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    json = JsonDocument.Parse(result.Content);
                }

                JsonElement root = json.RootElement;

                return new ShareChangeFeedResetMarker
                {
                    SchemaVersion = RequireInt32(root, Constants.FilesChangeFeed.ResetMarker.SchemaVersion, path),
                    ResetId = RequireGuid(root, Constants.FilesChangeFeed.ResetMarker.ResetId, path),
                    ResetFileTime = RequireInt64(root, Constants.FilesChangeFeed.ResetMarker.ResetFileTime, path),
                    ResetTimeUtc = RequireDateTimeOffset(root, Constants.FilesChangeFeed.ResetMarker.ResetTimeUtc, path),
                    AccountName = RequireString(root, Constants.FilesChangeFeed.ResetMarker.AccountName, path),
                    ContainerName = RequireString(root, Constants.FilesChangeFeed.ResetMarker.ContainerName, path),
                    Reason = RequireString(root, Constants.FilesChangeFeed.ResetMarker.Reason, path),
                };
            }
            finally
            {
                json?.Dispose();
            }
        }

        private static string RequireString(JsonElement root, string field, string path)
        {
            if (!root.TryGetProperty(field, out JsonElement value))
                throw new FormatException($"Reset marker at '{path}' is missing required field '{field}'.");
            string s = value.GetString();
            if (s == null)
                throw new FormatException($"Reset marker at '{path}' field '{field}' is null.");
            return s;
        }

        private static int RequireInt32(JsonElement root, string field, string path)
        {
            if (!root.TryGetProperty(field, out JsonElement value))
                throw new FormatException($"Reset marker at '{path}' is missing required field '{field}'.");
            try
            {
                return value.GetInt32();
            }
            catch (Exception ex) when (ex is FormatException || ex is InvalidOperationException)
            {
                throw new FormatException(
                    $"Reset marker at '{path}' field '{field}' is not a valid Int32.",
                    ex);
            }
        }

        private static long RequireInt64(JsonElement root, string field, string path)
        {
            if (!root.TryGetProperty(field, out JsonElement value))
                throw new FormatException($"Reset marker at '{path}' is missing required field '{field}'.");
            try
            {
                return value.GetInt64();
            }
            catch (Exception ex) when (ex is FormatException || ex is InvalidOperationException)
            {
                throw new FormatException(
                    $"Reset marker at '{path}' field '{field}' is not a valid Int64.",
                    ex);
            }
        }

        private static Guid RequireGuid(JsonElement root, string field, string path)
        {
            if (!root.TryGetProperty(field, out JsonElement value))
                throw new FormatException($"Reset marker at '{path}' is missing required field '{field}'.");
            string s = value.GetString();
            if (s == null)
                throw new FormatException($"Reset marker at '{path}' field '{field}' is null.");
            if (!Guid.TryParse(s, out Guid guid))
                throw new FormatException($"Reset marker at '{path}' field '{field}' is not a valid GUID: '{s}'.");
            return guid;
        }

        private static DateTimeOffset RequireDateTimeOffset(JsonElement root, string field, string path)
        {
            if (!root.TryGetProperty(field, out JsonElement value))
                throw new FormatException($"Reset marker at '{path}' is missing required field '{field}'.");
            string s = value.GetString();
            if (s == null)
                throw new FormatException($"Reset marker at '{path}' field '{field}' is null.");
            if (!DateTimeOffset.TryParse(s, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal, out DateTimeOffset ts))
                throw new FormatException($"Reset marker at '{path}' field '{field}' is not a valid DateTimeOffset: '{s}'.");
            return ts;
        }
    }
}
