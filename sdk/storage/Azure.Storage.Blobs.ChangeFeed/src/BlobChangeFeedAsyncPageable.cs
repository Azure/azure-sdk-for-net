// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Storage.Blobs;
using Azure.Storage.ChangeFeed.Common;

namespace Azure.Storage.Blobs.ChangeFeed
{
    /// <summary>
    /// BlobChangeFeedPagableAsync.
    /// </summary>
    internal class BlobChangeFeedAsyncPageable : AsyncPageable<BlobChangeFeedEvent>
    {
        private readonly BlobChangeFeedClient _client;
        private readonly long? _maxTransferSize;
        private readonly bool _includeNonFinalizedEvents;
        private readonly DateTimeOffset? _startTime;
        private readonly DateTimeOffset? _endTime;
        private readonly string _continuation;

        internal BlobChangeFeedAsyncPageable(
            BlobChangeFeedClient client,
            long? maxTransferSize,
            bool includeNonFinalizedEvents,
            DateTimeOffset? startTime = default,
            DateTimeOffset? endTime = default,
            string continuation = default)
        {
            _client = client;
            _maxTransferSize = maxTransferSize;
            _includeNonFinalizedEvents = includeNonFinalizedEvents;
            _startTime = startTime;
            _endTime = endTime;
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
                throw new ArgumentException($"{nameof(continuationToken)} not supported. Use BlobChangeFeedClient.GetChangesAsync(string) instead.");

            (BlobContainerClient containerClient, ChangeFeedConfiguration<BlobChangeFeedEvent> config) = _client.ResolveContainer();

            ChangeFeedFactoryBase<BlobChangeFeedEvent> factory = new ChangeFeedFactoryBase<BlobChangeFeedEvent>(
                containerClient,
                _maxTransferSize,
                config,
                _includeNonFinalizedEvents);

            ChangeFeedBase<BlobChangeFeedEvent> changeFeed = await factory.BuildChangeFeed(
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
                    pageSize: pageSizeHint ?? Constants.ChangeFeed.DefaultPageSize)
                    .ConfigureAwait(false);
            }
        }
    }
}
