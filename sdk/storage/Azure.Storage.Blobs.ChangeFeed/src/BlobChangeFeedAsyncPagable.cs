// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.ChangeFeed.Models;

namespace Azure.Storage.Blobs.ChangeFeed
{
    /// <summary>
    /// BlobChangeFeedPagableAsync.
    /// </summary>
    public class BlobChangeFeedAsyncPagable : AsyncPageable<BlobChangeFeedEvent>
    {
        private readonly ChangeFeedFactory _changeFeedFactory;
        private readonly BlobServiceClient _blobServiceClient;
        private readonly DateTimeOffset? _startTime;
        private readonly DateTimeOffset? _endTime;
        private readonly string _continuation;

        private ChangeFeed _changeFeed;

        /// <summary>
        /// Internal constructor.
        /// </summary>
        internal BlobChangeFeedAsyncPagable(
            BlobServiceClient blobBerviceClient,
            DateTimeOffset? startTime = default,
            DateTimeOffset? endTime = default)
        {
            _changeFeedFactory = new ChangeFeedFactory();
            _blobServiceClient = blobBerviceClient;
            _startTime = startTime;
            _endTime = endTime;
        }

        internal BlobChangeFeedAsyncPagable(
            BlobServiceClient blobServiceClient,
            string continuation)
        {
            _changeFeedFactory = new ChangeFeedFactory();
            _blobServiceClient = blobServiceClient;
            _continuation = continuation;
        }

        /// <summary>
        /// AsPages.
        /// </summary>
        /// <param name="continuationToken"></param>
        /// <param name="pageSizeHint"></param>
        /// <returns></returns>
        public override async IAsyncEnumerable<Page<BlobChangeFeedEvent>> AsPages(
            string continuationToken = null,
            int? pageSizeHint = null)
        {
            if (_changeFeed == null)
            {
                _changeFeed = await _changeFeedFactory.BuildChangeFeed(
                    async: true,
                    _blobServiceClient,
                    _startTime,
                    _endTime,
                    _continuation)
                    .ConfigureAwait(false);
            }
            while (_changeFeed.HasNext())
            {
                yield return await _changeFeed.GetPage(
                    async: true,
                    pageSize: pageSizeHint ?? 512).ConfigureAwait(false);
            }
        }
    }
}
