// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace Azure.Storage.ChangeFeed.Common
{
    /// <summary>
    /// Factory that creates <see cref="SegmentBase{TEvent}"/> instances by downloading and parsing
    /// the segment manifest JSON and building a shard for each chunkFilePath listed in it.
    /// </summary>
    internal class SegmentFactoryBase<TEvent>
    {
        private readonly BlobContainerClient _containerClient;
        private readonly ShardFactoryBase<TEvent> _shardFactory;
        private readonly ChangeFeedConfiguration<TEvent> _config;

        /// <summary>
        /// Constructor for mocking. Do not use directly.
        /// </summary>
        public SegmentFactoryBase() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SegmentFactoryBase{TEvent}"/> class.
        /// </summary>
        /// <param name="containerClient">Container client for the change feed container.</param>
        /// <param name="shardFactory">Factory used to build shard instances.</param>
        /// <param name="config">Change feed configuration.</param>
        public SegmentFactoryBase(BlobContainerClient containerClient, ShardFactoryBase<TEvent> shardFactory, ChangeFeedConfiguration<TEvent> config)
        {
            _containerClient = containerClient;
            _shardFactory = shardFactory;
            _config = config;
        }

        /// <summary>
        /// Builds a segment by downloading its manifest, constructing shards for each listed chunk file path,
        /// and optionally resuming from a cursor position.
        /// </summary>
        /// <param name="async">Whether to use async APIs.</param>
        /// <param name="manifestPath">Blob path of the segment manifest JSON.</param>
        /// <param name="cursor">Optional segment cursor to resume from a previous position.</param>
        /// <returns>A new <see cref="SegmentBase{TEvent}"/> ready to produce events.</returns>
#pragma warning disable CA1822
        public virtual async Task<SegmentBase<TEvent>> BuildSegment(bool async, string manifestPath, SegmentCursor cursor = default)
#pragma warning restore CA1822
        {
            List<ShardBase<TEvent>> shards = new List<ShardBase<TEvent>>();
            DateTimeOffset dateTime = ChangeFeedExtensionsBase.ToDateTimeOffset(manifestPath).Value;

            BlobClient blobClient = _containerClient.GetBlobClient(manifestPath);
            BlobDownloadStreamingResult blobDownloadStreamingResult;
            if (async)
                blobDownloadStreamingResult = await blobClient.DownloadStreamingAsync().ConfigureAwait(false);
            else
                blobDownloadStreamingResult = blobClient.DownloadStreaming();

            JsonDocument jsonManifest = null;
            try
            {
                if (async)
                    jsonManifest = await JsonDocument.ParseAsync(blobDownloadStreamingResult.Content).ConfigureAwait(false);
                else
                    jsonManifest = JsonDocument.Parse(blobDownloadStreamingResult.Content);

                foreach (JsonElement shardJsonElement in jsonManifest.RootElement.GetProperty("chunkFilePaths").EnumerateArray())
                {
                    string rawPath = shardJsonElement.ToString();
                    string shardPath;
                    // Strip the service-specific container prefix (e.g. "$blobchangefeed/") from the raw path
                    // so the result is a relative blob path usable with the container client.
                    if (_config.ContainerPrefix != null && rawPath.StartsWith(_config.ContainerPrefix, StringComparison.OrdinalIgnoreCase))
                        shardPath = rawPath.Substring(_config.ContainerPrefix.Length);
                    else
                        shardPath = rawPath;

                    ShardCursor shardCursor = cursor?.ShardCursors?.Find(x => x.CurrentChunkPath.StartsWith(shardPath, StringComparison.InvariantCulture));
                    ShardBase<TEvent> shard = await _shardFactory.BuildShard(async, shardPath, shardCursor).ConfigureAwait(false);
                    if (shard.HasNext()) shards.Add(shard);
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
                if (shardIndex < 0) shardIndex = 0;
            }
            return new SegmentBase<TEvent>(shards, shardIndex, dateTime, manifestPath);
        }
    }
}
