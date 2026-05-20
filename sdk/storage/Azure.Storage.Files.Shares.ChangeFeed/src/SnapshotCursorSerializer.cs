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
                throw new ArgumentNullException(nameof(continuationToken));

            ShareChangeFeedSnapshotCursor cursor;
            try
            {
                cursor = JsonSerializer.Deserialize<ShareChangeFeedSnapshotCursor>(continuationToken);
            }
            catch (JsonException ex)
            {
                throw new ArgumentException(
                    "Continuation token is not a valid snapshot cursor envelope.",
                    nameof(continuationToken),
                    ex);
            }

            if (cursor == null)
                throw new ArgumentException(
                    "Continuation token is not a valid snapshot cursor envelope.",
                    nameof(continuationToken));

            if (string.IsNullOrEmpty(cursor.BeginSnapshot)
                || string.IsNullOrEmpty(cursor.EndSnapshot)
                || string.IsNullOrEmpty(cursor.UrlHost))
            {
                throw new ArgumentException(
                    "Continuation token is missing required snapshot context.",
                    nameof(continuationToken));
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
                throw new ArgumentException("Cursor URL Host does not match container URL host.");

            if (cursor.CursorVersion != 1)
                throw new ArgumentException("Unsupported cursor version.");
        }
    }
}
