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
            bool async,
            CancellationToken cancellationToken)
        {
            Response<StorageHandlesSegment> response = await _client.GetHandlesInternal(
                continuationToken,
                pageSizeHint,
                async,
                cancellationToken).ConfigureAwait(false);

            return Page<ShareFileHandle>.FromValues(
                response.Value.Handles.ToArray(),
                response.Value.NextMarker,
                response.GetRawResponse());
        }
    }
}
