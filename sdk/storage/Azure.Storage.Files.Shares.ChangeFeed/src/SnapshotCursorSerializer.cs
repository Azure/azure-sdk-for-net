// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Storage.Blobs;

namespace Azure.Storage.Files.Shares.ChangeFeed
{
    /// <summary>
    /// Serialization / validation helpers for <see cref="ShareChangeFeedSnapshotCursor"/>.
    /// </summary>
    internal static class SnapshotCursorSerializer
    {
        /// <summary>
        /// Serializes the snapshot cursor envelope to its on-the-wire string form.
        /// </summary>
        public static string Serialize(ShareChangeFeedSnapshotCursor cursor)
            => JsonSerializer.Serialize(cursor);

        /// <summary>
        /// Deserializes a previously-emitted snapshot cursor string. Throws
        /// <see cref="ArgumentException"/> when the input is not a valid envelope.
        /// </summary>
        public static ShareChangeFeedSnapshotCursor Deserialize(string continuationToken)
        {
            if (continuationToken == null)
                throw ShareChangeFeedErrors.ArgumentNull(nameof(continuationToken));

            ShareChangeFeedSnapshotCursor cursor;
            try
            {
                cursor = JsonSerializer.Deserialize<ShareChangeFeedSnapshotCursor>(continuationToken);
            }
            catch (JsonException ex)
            {
                throw ShareChangeFeedErrors.InvalidSnapshotCursorEnvelope(nameof(continuationToken), ex);
            }

            if (cursor == null)
                throw ShareChangeFeedErrors.InvalidSnapshotCursorEnvelope(nameof(continuationToken));

            if (string.IsNullOrEmpty(cursor.BeginSnapshot)
                || string.IsNullOrEmpty(cursor.EndSnapshot)
                || string.IsNullOrEmpty(cursor.UrlHost))
            {
                throw ShareChangeFeedErrors.MissingSnapshotContext(nameof(continuationToken));
            }

            return cursor;
        }

        /// <summary>
        /// Validates that <paramref name="cursor"/> targets the same change-feed container
        /// as <paramref name="containerClient"/> and uses a supported cursor version.
        /// Mirrors <c>ChangeFeedFactoryBase.ValidateCursor</c>.
        /// </summary>
        public static void Validate(BlobContainerClient containerClient, ShareChangeFeedSnapshotCursor cursor)
        {
            if (!string.Equals(containerClient.Uri.Host, cursor.UrlHost, StringComparison.OrdinalIgnoreCase))
                throw ShareChangeFeedErrors.CursorUrlHostMismatch();

            if (cursor.CursorVersion != Constants.FilesChangeFeed.SnapshotCursorSchemaVersion)
                throw ShareChangeFeedErrors.UnsupportedCursorVersion();
        }
    }
}
