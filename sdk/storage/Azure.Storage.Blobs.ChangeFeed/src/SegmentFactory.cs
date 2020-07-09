// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Storage.Blobs.ChangeFeed.Models;
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
            DateTimeOffset dateTime = manifestPath.ToDateTimeOffset().Value;
            int shardIndex = cursor?.ShardIndex ?? 0;

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

            // Initalized Finalized field
            string statusString = jsonManifest.RootElement.GetProperty("status").GetString();
            bool finalized = statusString == "Finalized";

            int i = 0;
            foreach (JsonElement shardJsonElement in jsonManifest.RootElement.GetProperty("chunkFilePaths").EnumerateArray())
            {
                string shardPath = shardJsonElement.ToString().Substring("$blobchangefeed/".Length);
                Shard shard = await _shardFactory.BuildShard(
                    async,
                    shardPath,
                    cursor?.ShardCursors?[i])
                    .ConfigureAwait(false);

                shards.Add(shard);
                i++;
            }

            return new Segment(
                shards,
                shardIndex,
                dateTime,
                finalized);
        }
    }
}
