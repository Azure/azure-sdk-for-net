// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable SA1402  // File may only contain a single type

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;

namespace Azure.Storage.Blobs.Models
{
    internal class GetLayoutAsyncCollection : StorageCollectionEnumerator<BlobLayoutInfo>
    {
        private readonly BlobBaseClient _client;
        private readonly HttpRange _range;
        private readonly BlobRequestConditions _conditions;
        private ETag? _etag; // the ETag from the initial Get Layout request

        public GetLayoutAsyncCollection(
            BlobBaseClient client,
            HttpRange range,
            BlobRequestConditions conditions)
        {
            _client = client;
            _range = range;
            _conditions = conditions;
        }

        public override async ValueTask<Page<BlobLayoutInfo>> GetNextPageAsync(
            string continuationToken,
            int? pageSizeHint,
            bool async,
            CancellationToken cancellationToken)
        {
            Response<BlobLayoutInfo> response;

            // ETag locking on subsequent GetLayout requests
            BlobRequestConditions conditions = _etag.HasValue
                ? (_conditions ?? new BlobRequestConditions()).WithIfMatch(_etag.Value)
                : _conditions;

            if (async)
            {
                response = await _client.GetLayoutInternal(
                    marker: continuationToken,
                    maxResults: pageSizeHint,
                    range: _range,
                    conditions: conditions,
                    async: async,
                    cancellationToken: cancellationToken)
                    .ConfigureAwait(false);
            }
            else
            {
                response = _client.GetLayoutInternal(
                    marker: continuationToken,
                    maxResults: pageSizeHint,
                    range: _range,
                    conditions: conditions,
                    async: async,
                    cancellationToken: cancellationToken)
                    .EnsureCompleted();
            }

            // Set the initial Get Layout etag for subsequent requests
            _etag ??= response.Value.ETag;

            return Page<BlobLayoutInfo>.FromValues(
                new[] { response.Value },
                response.Value.NextMarker,
                response.GetRawResponse());
        }
    }
}
