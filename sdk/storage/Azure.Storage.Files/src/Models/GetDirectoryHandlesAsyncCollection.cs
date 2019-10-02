// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.Files.Models
{
    internal class GetDirectoryHandlesAsyncCollection : StorageCollectionEnumerator<StorageHandle>
    {
        private readonly DirectoryClient _client;
        private readonly bool? _recursive;

        public GetDirectoryHandlesAsyncCollection(
            DirectoryClient client,
            bool? recursive)
        {
            _client = client;
            _recursive = recursive;
        }

        public override async ValueTask<Page<StorageHandle>> GetNextPageAsync(
            string continuationToken,
            int? pageSizeHint,
            bool isAsync,
            CancellationToken cancellationToken)
        {
            Task<Response<StorageHandlesSegment>> task = _client.GetHandlesInternal(
                continuationToken,
                pageSizeHint,
                _recursive,
                isAsync,
                cancellationToken);
            Response<StorageHandlesSegment> response = isAsync ?
                await task.ConfigureAwait(false) :
                task.EnsureCompleted();
            return new Page<StorageHandle>(
                response.Value.Handles.ToArray(),
                response.Value.NextMarker,
                response.GetRawResponse());
        }
    }
}
