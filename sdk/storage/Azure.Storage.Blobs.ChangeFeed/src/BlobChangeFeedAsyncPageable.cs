// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Storage.Blobs.ChangeFeed
{
    /// <summary>
    /// BlobChangeFeedPagableAsync.
    /// </summary>
    internal class BlobChangeFeedAsyncPageable : AsyncPageable<BlobChangeFeedEvent>
    {
        private readonly ChangeFeedFactory _changeFeedFactory;
        private readonly DateTimeOffset? _startTime;
        private readonly DateTimeOffset? _endTime;
        private readonly string _continuation;

        /// <summary>
        /// Internal constructor.
        /// </summary>
        internal BlobChangeFeedAsyncPageable(
            BlobServiceClient blobServiceClient,
            long? maxTransferSize,
            DateTimeOffset? startTime = default,
            DateTimeOffset? endTime = default)
        {
            _changeFeedFactory = new ChangeFeedFactory(
                blobServiceClient,
                maxTransferSize);
            _startTime = startTime;
            _endTime = endTime;
        }

        internal BlobChangeFeedAsyncPageable(
            BlobServiceClient blobServiceClient,
            long? maxTransferSize,
            string continuation)
        {
            _changeFeedFactory = new ChangeFeedFactory(
                blobServiceClient,
                maxTransferSize);
            _continuation = continuation;
        }

        /// <summary>
        /// Returns <see cref="BlobChangeFeedEvent"/>s as Pages.
        /// </summary>
        /// <param name="continuationToken">
        /// Throws an <see cref="ArgumentException"/>.  To use contination, call
        /// <see cref="BlobChangeFeedClient.GetChangesAsync(string)"/>.
        /// </param>
        /// <param name="pageSizeHint">
        /// Page size.
        /// </param>
        /// <returns>
        /// <see cref="IAsyncEnumerable{Page}"/>.
        /// </returns>
        public override async IAsyncEnumerable<Page<BlobChangeFeedEvent>> AsPages(
            string continuationToken = null,
            int? pageSizeHint = null)
        {
            if (continuationToken != null)
            {
                throw new ArgumentException($"{nameof(continuationToken)} not supported.  Use BlobChangeFeedClient.GetChangesAsync(string) instead");
            }

            ChangeFeed changeFeed = await _changeFeedFactory.BuildChangeFeed(
                _startTime,
                _endTime,
                _continuation,
                async: true,
                cancellationToken: default)
                .ConfigureAwait(false);

            while (changeFeed.HasNext())
            {
                yield return await changeFeed.GetPage(
                    async: true,
                    pageSize: pageSizeHint ?? Constants.ChangeFeed.DefaultPageSize).ConfigureAwait(false);
            }
        }
    }
}
