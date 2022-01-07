// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs.Specialized;

namespace Azure.Storage.Blobs.Models
{
    internal class GetPageRangesAsyncCollection : StorageCollectionEnumerator<PageBlobRange>
    {
        private readonly PageBlobClient _client;
        private readonly HttpRange? _range;
        private readonly string _snapshot;
        private readonly PageBlobRequestConditions _requestConditions;

        public GetPageRangesAsyncCollection(
            PageBlobClient client,
            HttpRange? range,
            string snapshot,
            PageBlobRequestConditions requestConditions)
        {
            _client = client;
            _range = range;
            _snapshot = snapshot;
            _requestConditions = requestConditions;
        }

        public override async ValueTask<Page<PageBlobRange>> GetNextPageAsync(
            string continuationToken,
            int? pageSizeHint,
            bool async,
            CancellationToken cancellationToken)
        {
            ResponseWithHeaders<PageList, PageBlobGetPageRangesHeaders> response;
            if (async)
            {
                response = await _client.GetPageRangesPageableInteral(
                    marker: continuationToken,
                    pageSizeHint: pageSizeHint,
                    range: _range,
                    snapshot: _snapshot,
                    conditions: _requestConditions,
                    async: true,
                    cancellationToken: cancellationToken)
                    .ConfigureAwait(false);
            }
            else
            {
                response = _client.GetPageRangesPageableInteral(
                    marker: continuationToken,
                    pageSizeHint: pageSizeHint,
                    range: _range,
                    snapshot: _snapshot,
                    conditions: _requestConditions,
                    async: false,
                    cancellationToken: cancellationToken)
                    .EnsureCompleted();
            }

            return Page<PageBlobRange>.FromValues(
                values: response.ToPageBlobRanges(),
                continuationToken: response.Value.NextMarker,
                response: response.GetRawResponse());
        }
    }
}
