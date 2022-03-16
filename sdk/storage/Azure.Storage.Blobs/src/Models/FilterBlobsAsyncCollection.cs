// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable SA1402  // File may only contain a single type

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;

namespace Azure.Storage.Blobs.Models
{
    internal class FilterBlobsAsyncCollection : StorageCollectionEnumerator<TaggedBlobItem>
    {
        private readonly BlobServiceClient _serviceClient;
        private readonly BlobContainerClient _containerClient;
        private readonly string _expression;
        private readonly BlobStates _blobStates;

        public FilterBlobsAsyncCollection(
            BlobServiceClient serviceClient,
            string expression,
            BlobStates states)
        {
            _serviceClient = serviceClient;
            _expression = expression;
            _blobStates = states;
        }

        public FilterBlobsAsyncCollection(
            BlobContainerClient containerClient,
            string expression,
            BlobStates states)
        {
            _containerClient = containerClient;
            _expression = expression;
            _blobStates = states;
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
                    states: _blobStates,
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
                    states: _blobStates,
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

namespace Azure.Storage.Blobs
{
    internal static partial class BlobExtensions
    {
        internal static IEnumerable<FilterBlobsIncludeItem> AsIncludeItems(BlobStates states)
        {
            List<FilterBlobsIncludeItem> items = new List<FilterBlobsIncludeItem>();
            if ((states & BlobStates.Version) == BlobStates.Version)
            {
                items.Add(FilterBlobsIncludeItem.Versions);
            }
            return items.Count > 0 ? items : null;
        }
    }
}
