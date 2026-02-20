// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Storage.Blobs.Models
{
    internal class GetBlobsByHierarchyAsyncCollection : StorageCollectionEnumerator<BlobHierarchyItem>
    {
        private readonly BlobContainerClient _client;
        private readonly BlobTraits _traits;
        private readonly BlobStates _states;
        private readonly string _delimiter;
        private readonly string _prefix;
        private readonly string _startFrom;

        public GetBlobsByHierarchyAsyncCollection(
            BlobContainerClient client,
            string delimiter,
            BlobTraits traits,
            BlobStates states,
            string prefix,
            string startFrom)
        {
            _client = client;
            _delimiter = delimiter;
            _traits = traits;
            _states = states;
            _prefix = prefix;
            _startFrom = startFrom;
        }

        public override async ValueTask<Page<BlobHierarchyItem>> GetNextPageAsync(
            string continuationToken,
            int? pageSizeHint,
            bool async,
            CancellationToken cancellationToken)
        {
            Response<ListBlobsHierarchySegmentResponse> response;

            if (async)
            {
                response = await _client.GetBlobsByHierarchyInternal(
                    marker: continuationToken,
                    delimiter: _delimiter,
                    traits: _traits,
                    states: _states,
                    prefix: _prefix,
                    startFrom: _startFrom,
                    pageSizeHint: pageSizeHint,
                    async: async,
                    cancellationToken: cancellationToken)
                    .ConfigureAwait(false);
            }
            else
            {
                response = _client.GetBlobsByHierarchyInternal(
                    marker: continuationToken,
                    delimiter: _delimiter,
                    traits: _traits,
                    states: _states,
                    prefix: _prefix,
                    startFrom: _startFrom,
                    pageSizeHint: pageSizeHint,
                    async: async,
                    cancellationToken: cancellationToken)
                    .EnsureCompleted();
            }

            List<BlobHierarchyItem> items = new List<BlobHierarchyItem>();

            items.AddRange(response.Value.Segment.BlobPrefixes.Select(p => new BlobHierarchyItem(p.Name.ToBlobNameString(), null)));
            items.AddRange(response.Value.Segment.BlobItems.Select(b => new BlobHierarchyItem(null, b.ToBlobItem())));
            return Page<BlobHierarchyItem>.FromValues(
                items.ToArray(),
                response.Value.NextMarker,
                response.GetRawResponse());
        }
    }
}
