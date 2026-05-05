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
    /// Helper for reading snapshot metadata from the change feed container.
    /// </summary>
    internal static class SnapshotQueryHelper
    {
        /// <summary>
        /// Converts a snapshot timestamp string to the blob path for its <c>meta.json</c>.
        /// For example, <c>"2023-07-18T08:00:00.000Z"</c> becomes
        /// <c>"idx/snapshot/2023/07/18/08/00/00/meta.json"</c>.
        /// </summary>
        /// <param name="snapshotTimestamp">An ISO 8601 timestamp string identifying the snapshot.</param>
        /// <returns>The blob path to the snapshot's metadata JSON file.</returns>
        internal static string SnapshotTimestampToPath(string snapshotTimestamp)
        {
            // Parse the ISO 8601 timestamp and format each component into a hierarchical path.
            DateTimeOffset ts = DateTimeOffset.Parse(snapshotTimestamp, CultureInfo.InvariantCulture);
            return string.Format(
                CultureInfo.InvariantCulture,
                "idx/snapshot/{0:D4}/{1:D2}/{2:D2}/{3:D2}/{4:D2}/{5:D2}/meta.json",
                ts.Year,
                ts.Month,
                ts.Day,
                ts.Hour,
                ts.Minute,
                ts.Second);
        }

        /// <summary>
        /// Downloads and parses a snapshot <c>meta.json</c> blob from the change feed container.
        /// </summary>
        /// <param name="containerClient">The blob container client for the change feed container.</param>
        /// <param name="snapshotTimestamp">The ISO 8601 timestamp identifying the snapshot to read.</param>
        /// <param name="async">Whether to execute the download asynchronously.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>A <see cref="SnapshotMetadata"/> instance parsed from the JSON content.</returns>
        internal static async Task<SnapshotMetadata> ReadSnapshotMetadataAsync(
            BlobContainerClient containerClient,
            string snapshotTimestamp,
            bool async,
            CancellationToken cancellationToken)
        {
            string path = SnapshotTimestampToPath(snapshotTimestamp);

            BlobClient blobClient = containerClient.GetBlobClient(path);
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
                throw new ArgumentException(
                    $"Snapshot metadata not found for timestamp '{snapshotTimestamp}' (path: {path}). " +
                    $"Verify that a share snapshot was taken at this time and that the change feed has finished publishing its metadata.",
                    ex);
            }

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

                return new SnapshotMetadata
                {
                    Version = root.TryGetProperty("version", out JsonElement version)
                        ? version.GetInt32()
                        : 0,
                    SnapshotTimestamp = RequireDateTimeOffset(root, "snapshotTimestamp", path),
                    CvId = RequireInt64(root, "cvId", path),
                    MinLogWindowForNextSnapshot = RequireDateTimeOffset(root, "minLogWindowForNextSnapshot", path),
                    MaxLogWindowForCurrentSnapshot = RequireDateTimeOffset(root, "maxLogWindowForCurrentSnapshot", path),
                    Status = RequireString(root, "status", path),
                };
            }
            finally
            {
                json?.Dispose();
            }
        }

        private static DateTimeOffset RequireDateTimeOffset(JsonElement root, string field, string path)
        {
            if (!root.TryGetProperty(field, out JsonElement value))
                throw new FormatException($"Snapshot metadata at '{path}' is missing required field '{field}'.");
            try
            {
                return value.GetDateTimeOffset();
            }
            catch (Exception ex) when (ex is FormatException || ex is InvalidOperationException)
            {
                throw new FormatException(
                    $"Snapshot metadata at '{path}' field '{field}' is not a valid DateTimeOffset.",
                    ex);
            }
        }

        private static long RequireInt64(JsonElement root, string field, string path)
        {
            if (!root.TryGetProperty(field, out JsonElement value))
                throw new FormatException($"Snapshot metadata at '{path}' is missing required field '{field}'.");
            try
            {
                return value.GetInt64();
            }
            catch (Exception ex) when (ex is FormatException || ex is InvalidOperationException)
            {
                throw new FormatException(
                    $"Snapshot metadata at '{path}' field '{field}' is not a valid Int64.",
                    ex);
            }
        }

        private static string RequireString(JsonElement root, string field, string path)
        {
            if (!root.TryGetProperty(field, out JsonElement value))
                throw new FormatException($"Snapshot metadata at '{path}' is missing required field '{field}'.");
            string s = value.GetString();
            if (s == null)
                throw new FormatException($"Snapshot metadata at '{path}' field '{field}' is null.");
            return s;
        }
    }
}
