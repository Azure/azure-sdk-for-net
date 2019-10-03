// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.Blobs.Models
{
    internal class GetBlobsAsyncCollection : StorageCollectionEnumerator<BlobItem>
    {
        private readonly BlobContainerClient _client;
        private readonly GetBlobOptions _options;
        private readonly string _prefix;

        public GetBlobsAsyncCollection(
            BlobContainerClient client,
            GetBlobOptions options,
            string prefix)
        {
            _client = client;
            _options = options;
            _prefix = prefix;
        }

        public override async ValueTask<Page<BlobItem>> GetNextPageAsync(
            string continuationToken,
            int? pageSizeHint,
            bool isAsync,
            CancellationToken cancellationToken)
        {
            Task<Response<BlobsFlatSegment>> task = _client.GetBlobsInternal(
                continuationToken,
                _options,
                _prefix,
                pageSizeHint,
                isAsync,
                cancellationToken);
            Response<BlobsFlatSegment> response = isAsync ?
                await task.ConfigureAwait(false) :
                task.EnsureCompleted();

            return new Page<BlobItem>(
                response.Value.BlobItems.ToArray(),
                response.Value.NextMarker,
                response.GetRawResponse());
        }
    }
}
