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

        internal BlobChangeFeedPagable(
            BlobServiceClient blobServiceClient,
            DateTimeOffset? startTime = default,
            DateTimeOffset? endTime = default)
        {
            _changeFeedFactory = new ChangeFeedFactory(blobServiceClient);
            _blobServiceClient = blobServiceClient;
            _startTime = startTime;
            _endTime = endTime;
        }

        internal BlobChangeFeedPagable(
            BlobServiceClient blobServiceClient,
            string continuation)
        {
            _changeFeedFactory = new ChangeFeedFactory(blobServiceClient);
            _blobServiceClient = blobServiceClient;
            _continuation = continuation;
        }

        /// <summary>
        /// Returns <see cref="BlobChangeFeedEvent"/>s as Pages.
        /// </summary>
        /// <param name="continuationToken">
        /// Throws an <see cref="ArgumentException"/>.  To use contination, call
        /// <see cref="BlobChangeFeedClient.GetChanges(string)"/>.
        /// </param>
        /// <param name="pageSizeHint">
        /// Page size.
        /// </param>
        /// <returns>
        /// <see cref="IEnumerable{Page}"/>.
        /// </returns>
        public override IEnumerable<Page<BlobChangeFeedEvent>> AsPages(string continuationToken = null, int? pageSizeHint = null)
        {
            if (continuationToken != null)
            {
                throw new ArgumentException($"Continuation not supported.  Use BlobChangeFeedClient.GetChanges(string) instead");
            }

            ChangeFeed changeFeed = _changeFeedFactory.BuildChangeFeed(
                async: false,
                _startTime,
                _endTime,
                _continuation)
                .EnsureCompleted();

            while (changeFeed.HasNext())
            {
                yield return changeFeed.GetPage(
                    async: false,
                    pageSize: pageSizeHint ?? 512).EnsureCompleted();
            }
        }
    }
}
