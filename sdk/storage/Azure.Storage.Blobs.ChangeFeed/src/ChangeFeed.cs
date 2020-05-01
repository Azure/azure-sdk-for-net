// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.ChangeFeed.Models;

namespace Azure.Storage.Blobs.ChangeFeed
{
    internal class ChangeFeed
    {
        /// <summary>
        /// BlobContainerClient for making List Blob requests and creating Segments.
        /// </summary>
        private readonly BlobContainerClient _containerClient;

        /// <summary>
        /// Queue of paths to years we haven't processed yet.
        /// </summary>
        private Queue<string> _years;

        /// <summary>
        /// Paths to segments in the current year we haven't processed yet.
        /// </summary>
        private Queue<string> _segments;

        /// <summary>
        /// The Segment we are currently processing.
        /// </summary>
        private Segment _currentSegment;

        private readonly SegmentCursor _currentSegmentCursor;

        /// <summary>
        /// The latest time the Change Feed can safely be read from.
        /// </summary>
        //TODO this can advance while we are iterating through the Change Feed.  Figure out how to support this.
        private DateTimeOffset _lastConsumable;

        /// <summary>
        /// User-specified start time.  If the start time occurs before Change Feed was enabled
        /// for this account, we will start at the beginning of the Change Feed.
        /// </summary>
        private DateTimeOffset? _startTime;

        /// <summary>
        /// User-specified end time.  If the end time occurs after _lastConsumable, we will
        /// end at _lastConsumable.
        /// </summary>
        private DateTimeOffset? _endTime;

        /// <summary>
        /// If this ChangeFeed has been initalized.
        /// </summary>
        private bool _isInitalized;

        // Start time will be rounded down to the nearest hour.
        public ChangeFeed(
            BlobServiceClient blobServiceClient,
            DateTimeOffset? startTime = default,
            DateTimeOffset? endTime = default)
        {
            _containerClient = blobServiceClient.GetBlobContainerClient(Constants.ChangeFeed.ChangeFeedContainerName);
            _years = new Queue<string>();
            _segments = new Queue<string>();
            _isInitalized = false;
            _startTime = startTime.RoundDownToNearestHour();
            _endTime = endTime.RoundUpToNearestHour();
        }

        public ChangeFeed(
            BlobServiceClient blobServiceClient,
            string continutation)
        {
            _containerClient = blobServiceClient.GetBlobContainerClient(Constants.ChangeFeed.ChangeFeedContainerName);
            ChangeFeedCursor cursor = JsonSerializer.Deserialize<ChangeFeedCursor>(continutation);
            ValidateCursor(_containerClient, cursor);
            _years = new Queue<string>();
            _segments = new Queue<string>();
            _isInitalized = false;
            _startTime = cursor.CurrentSegmentCursor.SegmentTime;
            _endTime = cursor.EndTime;
            _currentSegmentCursor = cursor.CurrentSegmentCursor;
        }

        /// <summary>
        /// Internal constructor for unit tests.
        /// </summary>
        /// <param name="containerClient"></param>
        internal ChangeFeed(
            BlobContainerClient containerClient)
        {
            _containerClient = containerClient;
        }

        private async Task Initalize(bool async)
        {
            // Check if Change Feed has been abled for this account.
            bool changeFeedContainerExists;

            if (async)
            {
                changeFeedContainerExists = await _containerClient.ExistsAsync().ConfigureAwait(false);
            }
            else
            {
                changeFeedContainerExists = _containerClient.Exists();
            }

            if (!changeFeedContainerExists)
            {
                //TODO improve this error message
                throw new ArgumentException("Change Feed hasn't been enabled on this account, or is current being enabled.");
            }

            // Get last consumable
            BlobClient blobClient = _containerClient.GetBlobClient(Constants.ChangeFeed.MetaSegmentsPath);
            BlobDownloadInfo blobDownloadInfo;
            if (async)
            {
                blobDownloadInfo = await blobClient.DownloadAsync().ConfigureAwait(false);
            }
            else
            {
                blobDownloadInfo = blobClient.Download();
            }

            JsonDocument jsonMetaSegment;
            if (async)
            {
                jsonMetaSegment = await JsonDocument.ParseAsync(blobDownloadInfo.Content).ConfigureAwait(false);
            }
            else
            {
                jsonMetaSegment = JsonDocument.Parse(blobDownloadInfo.Content);
            }

            //TODO what happens when _lastConsumable advances an hour?
            _lastConsumable = jsonMetaSegment.RootElement.GetProperty("lastConsumable").GetDateTimeOffset();

            // Get year paths
            _years = await GetYearPaths(async).ConfigureAwait(false);

            // Dequeue any years that occur before start time
            if (_startTime.HasValue)
            {
                while (_years.Count > 0
                    && _years.Peek().ToDateTimeOffset() < _startTime.RoundDownToNearestYear())
                {
                    _years.Dequeue();
                }
            }

            if (_years.Count == 0)
            {
                return;
            }

            string firstYearPath = _years.Dequeue();

            // Get Segments for first year
            _segments = await GetSegmentsInYear(
                async: async,
                yearPath: firstYearPath,
                startTime: _startTime,
                endTime: MinDateTime(_lastConsumable, _endTime))
                .ConfigureAwait(false);

            _currentSegment = new Segment(
                _containerClient,
                _segments.Dequeue(),
                _currentSegmentCursor);
            _isInitalized = true;
        }

        //TODO current round robin strategy doesn't work for live streaming!
        // The last segment may still be adding chunks.
        public async Task<Page<BlobChangeFeedEvent>> GetPage(
            bool async,
            int pageSize = 512)
        {
            if (!_isInitalized)
            {
                await Initalize(async).ConfigureAwait(false);
            }

            if (!HasNext())
            {
                throw new InvalidOperationException("Change feed doesn't have any more events");
            }

            //TODO what should we return here?  Also do we really need to check this on every page?
            if (_currentSegment.DateTime > _endTime)
            {
                return new BlobChangeFeedEventPage();
            }

            //TODO what should we return here?  Also do we really need to check this on every page?
            if (_currentSegment.DateTime > _lastConsumable)
            {
                return new BlobChangeFeedEventPage();
            }

            // Get next page
            List<BlobChangeFeedEvent> blobChangeFeedEvents = new List<BlobChangeFeedEvent>();

            int remainingEvents = pageSize;
            while (blobChangeFeedEvents.Count < pageSize
                && HasNext())
            {
                //TODO what if segment doesn't have a page size worth of data?
                List<BlobChangeFeedEvent> newEvents = await _currentSegment.GetPage(async, remainingEvents).ConfigureAwait(false);
                blobChangeFeedEvents.AddRange(newEvents);
                remainingEvents -= newEvents.Count;
                await AdvanceSegmentIfNecessary(async).ConfigureAwait(false);
            }

            return new BlobChangeFeedEventPage(blobChangeFeedEvents, JsonSerializer.Serialize<ChangeFeedCursor>(GetCursor()));
        }



        public bool HasNext()
        {
            if (!_isInitalized)
            {
                return true;
            }

            // We have no more segments, years, and the current segment doesn't have hext.
            if (_segments.Count == 0 && _years.Count == 0  && !_currentSegment.HasNext())
            {
                return false;
            }

            DateTimeOffset end = MinDateTime(_lastConsumable, _endTime);

            return _currentSegment.DateTime <= end;
        }

        //TODO how do update this?
        public DateTimeOffset LastConsumable()
        {
            return _lastConsumable;
        }

        internal ChangeFeedCursor GetCursor()
            => new ChangeFeedCursor(
                urlHash: _containerClient.Uri.ToString().GetHashCode(),
                endDateTime: _endTime,
                currentSegmentCursor: _currentSegment.GetCursor());

        internal async Task<Queue<string>> GetSegmentsInYear(
            bool async,
            string yearPath,
            DateTimeOffset? startTime = default,
            DateTimeOffset? endTime = default)
        {
            List<string> list = new List<string>();

            if (async)
            {
                await foreach (BlobHierarchyItem blobHierarchyItem in _containerClient.GetBlobsByHierarchyAsync(
                    prefix: yearPath)
                    .ConfigureAwait(false))
                {
                    if (blobHierarchyItem.IsPrefix)
                        continue;

                    DateTimeOffset segmentDateTime = blobHierarchyItem.Blob.Name.ToDateTimeOffset().Value;
                    if (startTime.HasValue && segmentDateTime < startTime
                        || endTime.HasValue && segmentDateTime > endTime)
                        continue;

                    list.Add(blobHierarchyItem.Blob.Name);
                }
            }
            else
            {
                foreach (BlobHierarchyItem blobHierarchyItem in _containerClient.GetBlobsByHierarchy(
                    prefix: yearPath))
                {
                    if (blobHierarchyItem.IsPrefix)
                        continue;

                    DateTimeOffset segmentDateTime = blobHierarchyItem.Blob.Name.ToDateTimeOffset().Value;
                    if (startTime.HasValue && segmentDateTime < startTime
                        || endTime.HasValue && segmentDateTime > endTime)
                        continue;

                    list.Add(blobHierarchyItem.Blob.Name);
                }
            }

            return new Queue<string>(list);
        }

        private async Task AdvanceSegmentIfNecessary(bool async)
        {
            // If the current segment is completed, remove it
            if (!_currentSegment.HasNext() && _segments.Count > 0)
            {
                _currentSegment = new Segment(_containerClient, _segments.Dequeue());
            }

            // If _segments is empty, refill it
            // TODO pull this out into private method
            else if (_segments.Count == 0 && _years.Count > 0)
            {
                string yearPath = _years.Dequeue();

                // Get Segments for first year
                _segments = await GetSegmentsInYear(
                    async: async,
                    yearPath: yearPath,
                    startTime: _startTime,
                    endTime: _endTime)
                    .ConfigureAwait(false);

                if (_segments.Count > 0)
                {
                    _currentSegment = new Segment(_containerClient, _segments.Dequeue());
                }
            }
        }

        internal async Task<Queue<string>> GetYearPaths(bool async)
        {
            List<string> list = new List<string>();

            if (async)
            {
                await foreach (BlobHierarchyItem blobHierarchyItem in _containerClient.GetBlobsByHierarchyAsync(
                    prefix: Constants.ChangeFeed.SegmentPrefix,
                    delimiter: "/").ConfigureAwait(false))
                {
                    if (blobHierarchyItem.Prefix.Contains(Constants.ChangeFeed.InitalizationSegment))
                        continue;

                    list.Add(blobHierarchyItem.Prefix);
                }
            }
            else
            {
                foreach (BlobHierarchyItem blobHierarchyItem in _containerClient.GetBlobsByHierarchy(
                prefix: Constants.ChangeFeed.SegmentPrefix,
                delimiter: "/"))
                {
                    if (blobHierarchyItem.Prefix.Contains(Constants.ChangeFeed.InitalizationSegment))
                        continue;

                    list.Add(blobHierarchyItem.Prefix);
                }
            }
            return new Queue<string>(list);
        }

        private static DateTimeOffset MinDateTime(DateTimeOffset lastConsumable, DateTimeOffset? endDate)
        {
            if (endDate.HasValue && endDate.Value < lastConsumable)
            {
                return endDate.Value;
            }

            return lastConsumable;
        }

        private static void ValidateCursor(
            BlobContainerClient containerClient,
            ChangeFeedCursor cursor)
        {
            if (containerClient.Uri.ToString().GetHashCode() != cursor.UrlHash)
            {
                throw new ArgumentException("Cursor URL does not match container URL");
            }
        }
    }
}