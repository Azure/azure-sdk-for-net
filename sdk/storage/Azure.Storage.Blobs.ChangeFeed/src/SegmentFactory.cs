// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;

namespace Azure.Storage.Blobs.ChangeFeed
{
    /// <summary>
    /// Builds <see cref="Segment"/> instances from blob storage.
    /// </summary>
    internal class SegmentFactory
    {
        private readonly BlobContainerClient _containerClient;
        private readonly ShardFactory _shardFactory;

        /// <summary>
        ///  Constructor for mocking.
        /// </summary>
        public SegmentFactory() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SegmentFactory"/> class.
        /// </summary>
        public SegmentFactory(
            BlobContainerClient containerClient,
            ShardFactory shardFactory)
        {
            _containerClient = containerClient;
            _shardFactory = shardFactory;
        }

        /// <summary>
        /// Builds a <see cref="Segment"/> from the specified manifest path, optionally
        /// resuming from the given cursor position.
        /// </summary>
#pragma warning disable CA1822 // Does not acces instance data can be marked static.
        public virtual async Task<Segment> BuildSegment(
#pragma warning restore CA1822 // Can't mock static methods in MOQ.
            bool async,
            string manifestPath,
            SegmentCursor cursor = default)
        {
            // Models we need for later
            List<Shard> shards = new List<Shard>();
            DateTimeOffset dateTime = BlobChangeFeedExtensions.ToDateTimeOffset(manifestPath).Value;

            // Download segment manifest
            BlobClient blobClient = _containerClient.GetBlobClient(manifestPath);
            BlobDownloadStreamingResult blobDownloadStreamingResult;

            if (async)
            {
                blobDownloadStreamingResult = await blobClient.DownloadStreamingAsync().ConfigureAwait(false);
            }
            else
            {
                blobDownloadStreamingResult = blobClient.DownloadStreaming();
            }

            // Parse segment manifest
            JsonDocument jsonManifest = null;
            try
            {
                if (async)
                {
                    jsonManifest = await JsonDocument.ParseAsync(blobDownloadStreamingResult.Content).ConfigureAwait(false);
                }
                else
                {
                    jsonManifest = JsonDocument.Parse(blobDownloadStreamingResult.Content);
                }

                foreach (JsonElement shardJsonElement in jsonManifest.RootElement.GetProperty("chunkFilePaths").EnumerateArray())
                {
                    string shardPath = shardJsonElement.ToString().Substring("$blobchangefeed/".Length);
                    ShardCursor shardCursor = cursor?.ShardCursors?.Find(x => x.CurrentChunkPath.StartsWith(shardPath, StringComparison.InvariantCulture));
                    Shard shard = await _shardFactory.BuildShard(
                        async,
                        shardPath,
                        shardCursor)
                        .ConfigureAwait(false);
                    if (shard.HasNext())
                    {
                        shards.Add(shard);
                    }
                }
            }
            finally
            {
                jsonManifest?.Dispose();
            }

            int shardIndex = 0;
            string currentShardPath = cursor?.CurrentShardPath;
            if (!string.IsNullOrWhiteSpace(currentShardPath))
            {
                shardIndex = shards.FindIndex(s => s.ShardPath == currentShardPath);
                if (shardIndex < 0)
                {
                    // Either shard doesn't exist or cursor is pointing to end of shard. So start from beginning.
                    shardIndex = 0;
                }
            }
            return new Segment(
                shards,
                shardIndex,
                dateTime,
                manifestPath);
        }
    }
}
