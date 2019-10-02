// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.Blobs.Models
{
    internal class GetContainersAsyncCollection : StorageCollectionEnumerator<ContainerItem>
    {
        private readonly BlobServiceClient _client;
        private readonly GetContainersOptions? _options;

        public GetContainersAsyncCollection(
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
            Task<Response<ContainersSegment>> task = _client.GetContainersInternal(
                continuationToken,
                _options,
                pageSizeHint,
                isAsync,
                cancellationToken);
            Response<ContainersSegment> response = isAsync ?
                await task.ConfigureAwait(false) :
                task.EnsureCompleted();
            return new Page<ContainerItem>(
                response.Value.ContainerItems.ToArray(),
                response.Value.NextMarker,
                response.GetRawResponse());
        }
    }
}
