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
    internal class ShareChangeFeedPageable : Pageable<ShareChangeFeedEvent>
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _fileServiceUri;
        private readonly string _shareName;
        private readonly long? _maxTransferSize;
        private readonly DateTimeOffset? _startTime;
        private readonly DateTimeOffset? _endTime;
        private readonly string _continuation;

        internal ShareChangeFeedPageable(
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

        public override IEnumerable<Page<ShareChangeFeedEvent>> AsPages(
            string continuationToken = null,
            int? pageSizeHint = null)
        {
            if (continuationToken != null)
            {
                throw new ArgumentException("Continuation not supported. Use ShareChangeFeedClient.GetChanges(string) instead.");
            }

            string containerName = ContainerDiscovery.DiscoverContainerNameAsync(
                _pipeline,
                _fileServiceUri,
                _shareName,
                async: false,
                cancellationToken: default).EnsureCompleted();

            BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            ChangeFeedConfiguration<ShareChangeFeedEvent> config = ShareChangeFeedClient.CreateConfiguration(containerName);

            ChangeFeedFactoryBase<ShareChangeFeedEvent> factory = new ChangeFeedFactoryBase<ShareChangeFeedEvent>(
                containerClient,
                _maxTransferSize,
                config);

            ChangeFeedBase<ShareChangeFeedEvent> changeFeed = factory.BuildChangeFeed(
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
                    pageSize: pageSizeHint ?? Constants.FilesChangeFeed.DefaultPageSize).EnsureCompleted();
            }
        }
    }
}
