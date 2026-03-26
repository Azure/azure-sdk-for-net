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
        /// Converts a snapshot timestamp string to the blob path for its meta.json.
        /// e.g., "2023-07-18T08:00:00.000Z" -> "idx/snapshots/2023/07/18/08/00/00/meta.json"
        /// </summary>
        internal static string SnapshotTimestampToPath(string snapshotTimestamp)
        {
            DateTimeOffset ts = DateTimeOffset.Parse(snapshotTimestamp, CultureInfo.InvariantCulture);
            return string.Format(
                CultureInfo.InvariantCulture,
                "idx/snapshots/{0:D4}/{1:D2}/{2:D2}/{3:D2}/{4:D2}/{5:D2}/meta.json",
                ts.Year,
                ts.Month,
                ts.Day,
                ts.Hour,
                ts.Minute,
                ts.Second);
        }

        /// <summary>
        /// Reads and parses a snapshot meta.json from the change feed container.
        /// </summary>
        internal static async Task<SnapshotMetadata> ReadSnapshotMetadataAsync(
            BlobContainerClient containerClient,
            string snapshotTimestamp,
            bool async,
            CancellationToken cancellationToken)
        {
            string path = SnapshotTimestampToPath(snapshotTimestamp);

            BlobClient blobClient = containerClient.GetBlobClient(path);
            BlobDownloadStreamingResult result;

            if (async)
            {
                result = await blobClient.DownloadStreamingAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
            }
            else
            {
                result = blobClient.DownloadStreaming(cancellationToken: cancellationToken);
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
                    SnapshotTimestamp = root.GetProperty("snapshotTimestamp").GetDateTimeOffset(),
                    CvId = root.GetProperty("cvId").GetInt64(),
                    MinLogWindowForNextSnapshot = root.GetProperty("minLogWindowForNextSnapshot").GetDateTimeOffset(),
                    MaxLogWindowForCurrentSnapshot = root.GetProperty("maxLogWindowForCurrentSnapshot").GetDateTimeOffset(),
                    Status = root.TryGetProperty("status", out JsonElement status)
                        ? status.GetString()
                        : null,
                };
            }
            finally
            {
                json?.Dispose();
            }
        }
    }
}
