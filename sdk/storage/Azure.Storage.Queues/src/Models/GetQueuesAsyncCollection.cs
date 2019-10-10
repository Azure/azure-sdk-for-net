// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.Queues.Models
{
    internal class GetQueuesAsyncCollection : StorageCollectionEnumerator<QueueItem>
    {
        private readonly QueueServiceClient _client;
        private readonly GetQueuesOptions? _options;

        public GetQueuesAsyncCollection(
            QueueServiceClient client,
            GetQueuesOptions? options)
        {
            _client = client;
            _options = options;
        }

        public override async ValueTask<Page<QueueItem>> GetNextPageAsync(
            string continuationToken,
            int? pageSizeHint,
            bool isAsync,
            CancellationToken cancellationToken)
        {
            Task<Response<QueuesSegment>> task = _client.GetQueuesInternal(
                continuationToken,
                _options,
                pageSizeHint,
                isAsync,
                cancellationToken);
            Response<QueuesSegment> response = isAsync ?
                await task.ConfigureAwait(false) :
                task.EnsureCompleted();

            return new Page<QueueItem>(
                response.Value.QueueItems.ToArray(),
                response.Value.NextMarker,
                response.GetRawResponse());
        }
    }
}
