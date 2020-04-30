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
        private ChangeFeed _changeFeed;

        internal BlobChangeFeedPagable(
            BlobServiceClient serviceClient,
            DateTimeOffset? startTime = default,
            DateTimeOffset? endTime = default)
        {
            _changeFeed = new ChangeFeed(
                serviceClient,
                startTime,
                endTime);
        }

        internal BlobChangeFeedPagable(
            BlobServiceClient serviceClient,
            string continuation)
        {
            _changeFeed = new ChangeFeed(
                serviceClient,
                continuation);
        }

        /// <summary>
        /// AsPages.
        /// </summary>
        /// <param name="continuationToken"></param>
        /// <param name="pageSizeHint"></param>
        /// <returns></returns>
        public override IEnumerable<Page<BlobChangeFeedEvent>> AsPages(string continuationToken = null, int? pageSizeHint = null)
        {
            while (_changeFeed.HasNext())
            {
                yield return _changeFeed.GetPage(
                    async: false,
                    pageSize: pageSizeHint ?? 512).EnsureCompleted();
            }
        }
    }
}