// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.Blobs.Models
{
    internal class GetBlobContainersAsyncCollection : StorageCollectionEnumerator<BlobContainerItem>
    {
        private readonly BlobServiceClient _client;
        private readonly BlobContainerTraits _traits;
        private readonly string _prefix;

        public GetBlobContainersAsyncCollection(
            BlobServiceClient client,
            BlobContainerTraits traits,
            string prefix = default)
        {
            _client = client;
            _traits = traits;
            _prefix = prefix;
        }

        public override async ValueTask<Page<BlobContainerItem>> GetNextPageAsync(
            string continuationToken,
            int? pageSizeHint,
            bool isAsync,
            CancellationToken cancellationToken)
        {
            Task<Response<BlobContainersSegment>> task = _client.GetBlobContainersInternal(
                continuationToken,
                _traits,
                _prefix,
                pageSizeHint,
                isAsync,
                cancellationToken);
            Response<BlobContainersSegment> response = isAsync ?
                await task.ConfigureAwait(false) :
                task.EnsureCompleted();
            return Page<BlobContainerItem>.FromValues(
                response.Value.BlobContainerItems.ToArray(),
                response.Value.NextMarker,
                response.GetRawResponse());
        }
    }
}
