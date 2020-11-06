// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Producer;

namespace Microsoft.Azure.WebJobs
{
    /// TODO: Remove when https://github.com/Azure/azure-sdk-for-net/issues/9117 is fixed
    internal class EventHubProducerClientImpl : IEventHubProducerClient
    {
        private readonly EventHubProducerClient _client;

        public EventHubProducerClientImpl(EventHubProducerClient client)
        {
            _client = client;
        }

        public async Task<IEventDataBatch> CreateBatchAsync(CancellationToken cancellationToken)
        {
            return new EventDataBatchImpl(await _client.CreateBatchAsync(cancellationToken).ConfigureAwait(false));
        }

        public async Task SendAsync(IEventDataBatch batch, CancellationToken cancellationToken)
        {
            await _client.SendAsync(((EventDataBatchImpl) batch).Batch, cancellationToken).ConfigureAwait(false);
        }
    }
}