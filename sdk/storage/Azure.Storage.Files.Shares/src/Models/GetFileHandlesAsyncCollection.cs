// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.Files.Shares.Models
{
    internal class GetFileHandlesAsyncCollection : StorageCollectionEnumerator<ShareFileHandle>
    {
        private readonly ShareFileClient _client;

        public GetFileHandlesAsyncCollection(
            ShareFileClient client)
        {
            _client = client;
        }

        public override async ValueTask<Page<ShareFileHandle>> GetNextPageAsync(
            string continuationToken,
            int? pageSizeHint,
            bool isAsync,
            CancellationToken cancellationToken)
        {
            Task<Response<StorageHandlesSegment>> task = _client.GetHandlesInternal(
                continuationToken,
                pageSizeHint,
                isAsync,
                cancellationToken);
            Response<StorageHandlesSegment> response = isAsync ?
                await task.ConfigureAwait(false) :
                task.EnsureCompleted();
            return Page<ShareFileHandle>.FromValues(
                response.Value.Handles.ToArray(),
                response.Value.NextMarker,
                response.GetRawResponse());
        }
    }
}
