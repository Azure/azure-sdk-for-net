// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable SA1402  // File may only contain a single type

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.Blobs.Models
{
    internal class FilterBlobsAsyncCollection : StorageCollectionEnumerator<FilterBlobItem>
    {
        private readonly BlobServiceClient _client;
        private readonly string _expression;

        public FilterBlobsAsyncCollection(
            BlobServiceClient client,
            string expression)
        {
            _client = client;
            _expression = expression;
        }

        public override async ValueTask<Page<FilterBlobItem>> GetNextPageAsync(
            string continuationToken,
            int? pageSizeHint,
            bool async,
            CancellationToken cancellationToken)
        {
            Response<FilterBlobSegment> response = await _client.FindBlobsByTagsInternal(
                marker: continuationToken,
                expression: _expression,
                pageSizeHint: pageSizeHint,
                async: async,
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);

            return Page<FilterBlobItem>.FromValues(
                response.Value.Blobs.ToArray(),
                response.Value.NextMarker,
                response.GetRawResponse());
        }
    }
}
