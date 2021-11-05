// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core.Pipeline;

namespace Azure.Storage.Blobs.ChangeFeed
{
    /// <summary>
    /// BlobChangeFeedPagable.
    /// </summary>
    internal class BlobChangeFeedPageable : Pageable<BlobChangeFeedEvent>
    {
        private readonly ChangeFeedFactory _changeFeedFactory;
        private readonly DateTimeOffset? _startTime;
        private readonly DateTimeOffset? _endTime;
        private readonly string _continuation;

        internal BlobChangeFeedPageable(
            BlobServiceClient blobServiceClient,
            DateTimeOffset? startTime = default,
            DateTimeOffset? endTime = default)
        {
            _changeFeedFactory = new ChangeFeedFactory(blobServiceClient);
            _startTime = startTime;
            _endTime = endTime;
        }

        internal BlobChangeFeedPageable(
            BlobServiceClient blobServiceClient,
            string continuation)
        {
            _changeFeedFactory = new ChangeFeedFactory(blobServiceClient);
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
                _startTime,
                _endTime,
                _continuation,
                async: false,
                cancellationToken: default)
                .EnsureCompleted();

            while (changeFeed.HasNext())
            {
                yield return changeFeed.GetPage(
                    async: false,
                    pageSize: pageSizeHint ?? Constants.ChangeFeed.DefaultPageSize).EnsureCompleted();
            }
        }
    }
}
