// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;

namespace Azure.Storage.Blobs.ChangeFeed
{
    internal class SegmentFactory
    {
        private readonly BlobContainerClient _containerClient;
        private readonly ShardFactory _shardFactory;

        /// <summary>
        ///  Constructor for mocking.
        /// </summary>
        public SegmentFactory() { }

        public SegmentFactory(
            BlobContainerClient containerClient,
            ShardFactory shardFactory)
        {
            _containerClient = containerClient;
            _shardFactory = shardFactory;
        }

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
            BlobDownloadInfo blobDownloadInfo;

            if (async)
            {
                blobDownloadInfo = await blobClient.DownloadAsync().ConfigureAwait(false);
            }
            else
            {
                blobDownloadInfo = blobClient.Download();
            }

            // Parse segment manifest
            JsonDocument jsonManifest;

            if (async)
            {
                jsonManifest = await JsonDocument.ParseAsync(blobDownloadInfo.Content).ConfigureAwait(false);
            }
            else
            {
                jsonManifest = JsonDocument.Parse(blobDownloadInfo.Content);
            }

            foreach (JsonElement shardJsonElement in jsonManifest.RootElement.GetProperty("chunkFilePaths").EnumerateArray())
            {
                string shardPath = shardJsonElement.ToString().Substring("$blobchangefeed/".Length);
                var shardCursor = cursor?.ShardCursors?.Find(x => x.CurrentChunkPath.StartsWith(shardPath, StringComparison.InvariantCulture));
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

            int shardIndex = 0;
            string currentShardPath = cursor?.CurrentShardPath;
            if (!string.IsNullOrWhiteSpace(currentShardPath))
            {
                shardIndex = shards.FindIndex(s => s.ShardPath == currentShardPath);
                if (shardIndex < 0)
                {
                    throw new ArgumentException($"Shard {currentShardPath} not found.");
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
