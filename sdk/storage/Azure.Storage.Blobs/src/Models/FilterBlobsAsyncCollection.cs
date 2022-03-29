// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable SA1402  // File may only contain a single type

using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.Blobs.Models
{
    internal class FilterBlobsAsyncCollection : StorageCollectionEnumerator<TaggedBlobItem>
    {
        private readonly BlobServiceClient _serviceClient;
        private readonly BlobContainerClient _containerClient;
        private readonly string _expression;

        public FilterBlobsAsyncCollection(
            BlobServiceClient serviceClient,
            string expression)
        {
            _serviceClient = serviceClient;
            _expression = expression;
        }

        public FilterBlobsAsyncCollection(
            BlobContainerClient containerClient,
            string expression)
        {
            _containerClient = containerClient;
            _expression = expression;
        }

        public override async ValueTask<Page<TaggedBlobItem>> GetNextPageAsync(
            string continuationToken,
            int? pageSizeHint,
            bool async,
            CancellationToken cancellationToken)
        {
            Response<FilterBlobSegment> response;
            if (_serviceClient != null)
            {
                response = await _serviceClient.FindBlobsByTagsInternal(
                    marker: continuationToken,
                    expression: _expression,
                    pageSizeHint: pageSizeHint,
                    async: async,
                    cancellationToken: cancellationToken)
                    .ConfigureAwait(false);
            }
            else
            {
                response = await _containerClient.FindBlobsByTagsInternal(
                    marker: continuationToken,
                    expression: _expression,
                    pageSizeHint: pageSizeHint,
                    async: async,
                    cancellationToken: cancellationToken)
                    .ConfigureAwait(false);
            }

            return Page<TaggedBlobItem>.FromValues(
                response.Value.Blobs.ToBlobTagItems(),
                response.Value.NextMarker,
                response.GetRawResponse());
        }
    }
}
