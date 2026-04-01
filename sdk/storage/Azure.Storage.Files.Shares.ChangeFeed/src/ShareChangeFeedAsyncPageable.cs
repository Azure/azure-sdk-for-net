// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Storage.Blobs;
using Azure.Storage.ChangeFeed.Common;

namespace Azure.Storage.Files.Shares.ChangeFeed
{
    internal class ShareChangeFeedAsyncPageable : AsyncPageable<ShareChangeFeedEvent>
    {
        private readonly ShareChangeFeedClient _client;
        private readonly long? _maxTransferSize;
        private readonly DateTimeOffset? _startTime;
        private readonly DateTimeOffset? _endTime;
        private readonly string _continuation;

        internal ShareChangeFeedAsyncPageable(
            ShareChangeFeedClient client,
            long? maxTransferSize,
            DateTimeOffset? startTime = default,
            DateTimeOffset? endTime = default,
            string continuation = default)
        {
            _client = client;
            _maxTransferSize = maxTransferSize;
            _startTime = startTime;
            _endTime = endTime;
            _continuation = continuation;
        }

        public override async IAsyncEnumerable<Page<ShareChangeFeedEvent>> AsPages(
            string continuationToken = null,
            int? pageSizeHint = null)
        {
            if (continuationToken != null)
                throw new ArgumentException("Continuation not supported. Use ShareChangeFeedClient.GetChangesAsync(string) instead.");

            (BlobContainerClient containerClient, ChangeFeedConfiguration<ShareChangeFeedEvent> config) = await _client.ResolveContainerAsync(
                async: true,
                cancellationToken: default)
                .ConfigureAwait(false);

            ChangeFeedFactoryBase<ShareChangeFeedEvent> factory = new ChangeFeedFactoryBase<ShareChangeFeedEvent>(
                containerClient,
                _maxTransferSize,
                config);

            ChangeFeedBase<ShareChangeFeedEvent> changeFeed = await factory.BuildChangeFeed(
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
                    pageSize: pageSizeHint ?? Constants.FilesChangeFeed.DefaultPageSize)
                    .ConfigureAwait(false);
            }
        }
    }
}
