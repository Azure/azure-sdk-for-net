// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Storage.Blobs;

namespace Azure.Storage.Files.Shares.ChangeFeed
{
    /// <summary>
    /// Serialization / validation helpers for <see cref="ShareChangeFeedCursor"/>. Mirrors
    /// <see cref="SnapshotCursorSerializer"/>.
    /// </summary>
    internal static class ShareChangeFeedCursorSerializer
    {
        /// <summary>
        /// Serializes the streaming cursor envelope to its on-the-wire string form.
        /// </summary>
        public static string Serialize(ShareChangeFeedCursor cursor)
            => JsonSerializer.Serialize(cursor);

        /// <summary>
        /// Deserializes a previously-emitted streaming cursor string. Throws
        /// <see cref="ArgumentException"/> when the input is not a valid envelope.
        /// </summary>
        public static ShareChangeFeedCursor Deserialize(string continuationToken)
        {
            if (continuationToken == null)
                throw ShareChangeFeedErrors.ArgumentNull(nameof(continuationToken));

            ShareChangeFeedCursor cursor;
            try
            {
                cursor = JsonSerializer.Deserialize<ShareChangeFeedCursor>(continuationToken);
            }
            catch (JsonException ex)
            {
                throw ShareChangeFeedErrors.InvalidCursorEnvelope(nameof(continuationToken), ex);
            }

            if (cursor == null
                || string.IsNullOrEmpty(cursor.UrlHost)
                || (cursor.InnerCursor == null
                    && (!cursor.LastSeenResetId.HasValue || !cursor.LastSeenResetFileTime.HasValue)))
            {
                throw ShareChangeFeedErrors.InvalidCursorEnvelope(nameof(continuationToken));
            }

            return cursor;
        }

        /// <summary>
        /// Validates that <paramref name="cursor"/> targets the same change-feed container as
        /// <paramref name="containerClient"/> and uses a supported cursor version.
        /// </summary>
        public static void Validate(BlobContainerClient containerClient, ShareChangeFeedCursor cursor)
        {
            if (!string.Equals(containerClient.Uri.Host, cursor.UrlHost, StringComparison.OrdinalIgnoreCase))
                throw ShareChangeFeedErrors.CursorUrlHostMismatch();

            if (cursor.CursorVersion != Constants.FilesChangeFeed.CursorSchemaVersion)
                throw ShareChangeFeedErrors.UnsupportedCursorVersion();
        }
    }
}
