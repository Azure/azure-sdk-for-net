// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.Blobs.Models
{
    internal class GetBlobContainersAsyncCollection : StorageAsyncCollection<BlobContainerItem>
    {
        private readonly BlobServiceClient _client;
        private readonly GetBlobContainersOptions? _options;

        public GetBlobContainersAsyncCollection(
            BlobServiceClient client,
            GetContainersOptions? options)
        {
            _client = client;
            _options = options;
        }

        public override async ValueTask<Page<ContainerItem>> GetNextPageAsync(
            string continuationToken,
            int? pageSizeHint,
            bool isAsync,
            CancellationToken cancellationToken)
        {
            Task<Response<BlobContainersSegment>> task = _client.GetBlobContainersInternal(
                continuationToken,
                _options,
                pageSizeHint,
                isAsync,
                cancellationToken);
            Response<BlobContainersSegment> response = isAsync ?
                await task.ConfigureAwait(false) :
                task.EnsureCompleted();
            return new Page<BlobContainerItem>(
                response.Value.BlobContainerItems.ToArray(),
                response.Value.NextMarker,
                response.GetRawResponse());
        }
    }
}
