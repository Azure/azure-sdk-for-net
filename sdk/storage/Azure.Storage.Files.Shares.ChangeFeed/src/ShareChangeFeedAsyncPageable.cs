// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs;
using Azure.Storage.ChangeFeed.Common;

namespace Azure.Storage.Files.Shares.ChangeFeed
{
    /// <summary>
    /// Asynchronous pageable implementation that enumerates Azure Files Change Feed events.
    /// Discovers the change feed blob container, builds a change feed reader, and yields
    /// pages of <see cref="ShareChangeFeedEvent"/> instances.
    /// </summary>
    internal class ShareChangeFeedAsyncPageable : AsyncPageable<ShareChangeFeedEvent>
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _fileServiceUri;
        private readonly string _shareName;
        private readonly long? _maxTransferSize;
        private readonly DateTimeOffset? _startTime;
        private readonly DateTimeOffset? _endTime;
        private readonly string _continuation;

        /// <summary>
        /// Initializes a new instance of <see cref="ShareChangeFeedAsyncPageable"/>.
        /// </summary>
        /// <param name="blobServiceClient">The blob service client for reading change feed segments.</param>
        /// <param name="pipeline">The HTTP pipeline for file service container discovery.</param>
        /// <param name="fileServiceUri">The file service endpoint URI.</param>
        /// <param name="shareName">The file share name.</param>
        /// <param name="maxTransferSize">Optional maximum transfer size for blob downloads.</param>
        /// <param name="startTime">Optional inclusive start time filter.</param>
        /// <param name="endTime">Optional exclusive end time filter.</param>
        /// <param name="continuation">Optional continuation token to resume from.</param>
        internal ShareChangeFeedAsyncPageable(
            BlobServiceClient blobServiceClient,
            HttpPipeline pipeline,
            Uri fileServiceUri,
            string shareName,
            long? maxTransferSize,
            DateTimeOffset? startTime = default,
            DateTimeOffset? endTime = default,
            string continuation = default)
        {
            _blobServiceClient = blobServiceClient;
            _pipeline = pipeline;
            _fileServiceUri = fileServiceUri;
            _shareName = shareName;
            _maxTransferSize = maxTransferSize;
            _startTime = startTime;
            _endTime = endTime;
            _continuation = continuation;
        }

        /// <summary>
        /// Enumerates pages of change feed events asynchronously.
        /// </summary>
        /// <param name="continuationToken">Must be null; continuation is handled via the constructor parameter.</param>
        /// <param name="pageSizeHint">Optional hint for the number of events per page.</param>
        /// <returns>An async enumerable of pages of <see cref="ShareChangeFeedEvent"/>.</returns>
        public override async IAsyncEnumerable<Page<ShareChangeFeedEvent>> AsPages(
            string continuationToken = null,
            int? pageSizeHint = null)
        {
            if (continuationToken != null)
            {
                throw new ArgumentException("Continuation not supported. Use ShareChangeFeedClient.GetChangesAsync(string) instead.");
            }

            // Discover the blob container name by querying file share properties,
            // then build the change feed factory and reader from that container.
            string containerName = await ContainerDiscovery.DiscoverContainerNameAsync(
                _pipeline,
                _fileServiceUri,
                _shareName,
                async: true,
                cancellationToken: default).ConfigureAwait(false);

            BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            ChangeFeedConfiguration<ShareChangeFeedEvent> config = ShareChangeFeedClient.CreateConfiguration(containerName);

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
                    pageSize: pageSizeHint ?? Constants.FilesChangeFeed.DefaultPageSize).ConfigureAwait(false);
            }
        }
    }
}
