// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.ChangeFeed.Models;
using Azure.Storage.Blobs.Models;

namespace Azure.Storage.Blobs.ChangeFeed
{
    internal class Segment
    {
        /// <summary>
        /// If this Segment is finalized.
        /// </summary>
        public bool Finalized { get; private set; }

        /// <summary>
        /// The time (to the nearest hour) associated with this Segment.
        /// </summary>
        public DateTimeOffset DateTime { get; private set; }

        /// <summary>
        /// Container client for listing Shards.
        /// </summary>
        private readonly BlobContainerClient _containerClient;

        /// <summary>
        /// The path to the manifest for this Segment.
        /// </summary>
        private readonly string _manifestPath;

        /// <summary>
        /// The Shards associated with this Segment.
        /// </summary>
        private readonly List<Shard> _shards;

        /// <summary>
        /// The index of the Shard we will return the next event from.
        /// </summary>
        private int _shardIndex;

        /// <summary>
        /// If this Segement has been initalized.
        /// </summary>
        private bool _isInitalized;

        private SegmentCursor _cursor;

        public Segment(
            BlobContainerClient containerClient,
            string manifestPath,
            SegmentCursor cursor = default)
        {
            _containerClient = containerClient;
            _manifestPath = manifestPath;
            DateTime = manifestPath.ToDateTimeOffset().Value;
            _shards = new List<Shard>();
            _cursor = cursor;
            _shardIndex = cursor?.ShardIndex ?? 0;
        }

        private async Task Initalize(bool async)
        {
            // Download segment manifest
            BlobClient blobClient = _containerClient.GetBlobClient(_manifestPath);
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
            Finalized = statusString == "Finalized";

            int i = 0;
            foreach (JsonElement shardJsonElement in jsonManifest.RootElement.GetProperty("chunkFilePaths").EnumerateArray())
            {
                //TODO cleanup this line
                string shardPath = shardJsonElement.ToString().Substring("$blobchangefeed/".Length);
                Shard shard = new Shard(_containerClient, shardPath, _cursor?.ShardCursors?[i]);
                _shards.Add(shard);
                i++;
            }
            _isInitalized = true;
        }

        public SegmentCursor GetCursor()
        {
            List<ShardCursor> shardCursors = new List<ShardCursor>();
            foreach (Shard shard in _shards)
            {
                shardCursors.Add(shard.GetCursor());
            }
            return new SegmentCursor(
                segmentDateTime: DateTime,
                shardCursors: shardCursors,
                shardIndex: _shardIndex);
        }

        public async Task<List<BlobChangeFeedEvent>> GetPage(
            bool async,
            int? pageSize,
            CancellationToken cancellationToken = default)
        {
            List<BlobChangeFeedEvent> changeFeedEventList = new List<BlobChangeFeedEvent>();

            if (!_isInitalized)
            {
                await Initalize(async).ConfigureAwait(false);
            }

            if (!HasNext())
            {
                throw new InvalidOperationException("Segment doesn't have any more events");
            }

            int i = 0;
            while (i < pageSize && _shards.Count > 0)
            {
                Shard currentShard = _shards[_shardIndex];

                BlobChangeFeedEvent changeFeedEvent = await currentShard.Next(async, cancellationToken).ConfigureAwait(false);

                changeFeedEventList.Add(changeFeedEvent);

                // If the current shard is completed, remove it from _shards
                if (!currentShard.HasNext())
                {
                    _shards.RemoveAt(_shardIndex);
                }

                i++;
                _shardIndex++;
                if (_shardIndex >= _shards.Count)
                {
                    _shardIndex = 0;
                }
            }

            //TODO how to get raw response for page?  Does it matter?
            return changeFeedEventList;
        }

        //TODO figure out if this is right.
        public bool HasNext()
        {
            if (!_isInitalized)
            {
                return true;
            }

            return _shards.Count > 0;
        }

        /// <summary>
        /// Constructor for testing.  Do not use.
        /// </summary>
        internal Segment(
            bool isInitalized = default,
            List<Shard> shards = default,
            int shardIndex = default,
            DateTimeOffset dateTime = default)
        {
            _isInitalized = isInitalized;
            _shards = shards;
            _shardIndex = shardIndex;
            DateTime = dateTime;
        }
    }
}
