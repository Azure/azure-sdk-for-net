// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.Files.Models
{
    internal class GetSharesAsyncCollection : StorageCollectionEnumerator<ShareItem>
    {
        private readonly FileServiceClient _client;
        private readonly GetSharesOptions? _options;

        public GetSharesAsyncCollection(
            FileServiceClient client,
            GetSharesOptions? options)
        {
            _client = client;
            _options = options;
        }

        public override async ValueTask<Page<ShareItem>> GetNextPageAsync(
            string continuationToken,
            int? pageSizeHint,
            bool isAsync,
            CancellationToken cancellationToken)
        {
            Task<Response<SharesSegment>> task = _client.GetSharesInternal(
                continuationToken,
                _options,
                pageSizeHint,
                isAsync,
                cancellationToken);
            Response<SharesSegment> response = isAsync ?
                await task.ConfigureAwait(false) :
                task.EnsureCompleted();

            return new Page<ShareItem>(
                response.Value.ShareItems.ToArray(),
                response.Value.NextMarker,
                response.GetRawResponse());
        }
    }
}
