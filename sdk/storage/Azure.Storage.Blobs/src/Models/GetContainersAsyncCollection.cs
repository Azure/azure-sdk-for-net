// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.Blobs.Models
{
    internal class GetContainersAsyncCollection : StorageAsyncCollection<ContainerItem>
    {
        private readonly BlobServiceClient _client;
        private readonly GetContainersOptions? _options;

        public GetContainersAsyncCollection(
            BlobServiceClient client,
            GetContainersOptions? options,
            CancellationToken cancellationToken)
            : base(cancellationToken)
        {
            _client = client;
            _options = options;
        }

        protected override async Task<Page<ContainerItem>> GetNextPageAsync(
            string continuationToken,
            int? pageHintSize,
            bool isAsync,
            CancellationToken cancellationToken)
        {
            Task<Response<ContainersSegment>> task = _client.GetContainersInternal(
                continuationToken,
                _options,
                pageHintSize,
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
