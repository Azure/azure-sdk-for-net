// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.ChangeFeed.Models;

namespace Azure.Storage.Blobs.ChangeFeed
{
    /// <summary>
    /// BlobChangeFeedPagable.
    /// </summary>
    public class BlobChangeFeedPagable : Pageable<BlobChangeFeedEvent>
    {
        private readonly ChangeFeedFactory _changeFeedFactory;
        private readonly BlobServiceClient _blobServiceClient;
        private readonly DateTimeOffset? _startTime;
        private readonly DateTimeOffset? _endTime;
        private readonly string _continuation;

        private ChangeFeed _changeFeed;

        internal BlobChangeFeedPagable(
            BlobServiceClient blobBerviceClient,
            DateTimeOffset? startTime = default,
            DateTimeOffset? endTime = default)
        {
            _changeFeedFactory = new ChangeFeedFactory();
            _blobServiceClient = blobBerviceClient;
            _startTime = startTime;
            _endTime = endTime;
        }

        internal BlobChangeFeedPagable(
            BlobServiceClient blobBerviceClient,
            string continuation)
        {
            _changeFeedFactory = new ChangeFeedFactory();
            _blobServiceClient = blobBerviceClient;
            _continuation = continuation;
        }

        /// <summary>
        /// AsPages.
        /// </summary>
        /// <param name="continuationToken"></param>
        /// <param name="pageSizeHint"></param>
        /// <returns></returns>
        public override IEnumerable<Page<BlobChangeFeedEvent>> AsPages(string continuationToken = null, int? pageSizeHint = null)
        {
            if (_changeFeed == null)
            {
                _changeFeed = _changeFeedFactory.BuildChangeFeed(
                    async: false,
                    _blobServiceClient,
                    _startTime,
                    _endTime,
                    _continuation)
                    .EnsureCompleted();
            }

            while (_changeFeed.HasNext())
            {
                yield return _changeFeed.GetPage(
                    async: false,
                    pageSize: pageSizeHint ?? 512).EnsureCompleted();
            }
        }
    }
}
