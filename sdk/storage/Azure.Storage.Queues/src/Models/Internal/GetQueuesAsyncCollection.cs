// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Storage.Queues.Models
{
    internal class GetQueuesAsyncCollection : StorageCollectionEnumerator<QueueItem>
    {
        private readonly QueueServiceClient _client;
        private readonly QueueTraits _traits;
        private readonly string _prefix;

        public GetQueuesAsyncCollection(
            QueueServiceClient client,
            QueueTraits traits,
            string prefix)
        {
            _client = client;
            _traits = traits;
            _prefix = prefix;
        }

        public override async ValueTask<Page<QueueItem>> GetNextPageAsync(
            string continuationToken,
            int? pageSizeHint,
            bool async,
            CancellationToken cancellationToken)
        {
            Response<ListQueuesSegmentResponse> response = await _client.GetQueuesInternal(
                continuationToken,
                _traits,
                _prefix,
                pageSizeHint,
                async,
                cancellationToken).ConfigureAwait(false);

            return Page<QueueItem>.FromValues(
                response.Value.QueueItems.ToArray(),
                response.Value.NextMarker,
                response.GetRawResponse());
        }
    }
}
