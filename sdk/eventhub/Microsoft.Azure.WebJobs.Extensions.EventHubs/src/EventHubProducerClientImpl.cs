// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Producer;
using Microsoft.Azure.WebJobs.Logging;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs
{
    /// TODO: Remove when https://github.com/Azure/azure-sdk-for-net/issues/9117 is fixed
    internal class EventHubProducerClientImpl : IEventHubProducerClient
    {
        private readonly EventHubProducerClient _client;
        private readonly ILogger _logger;

        public EventHubProducerClientImpl(EventHubProducerClient client, ILoggerFactory loggerFactory)
        {
            _client = client;
            _logger = loggerFactory?.CreateLogger(LogCategories.Executor);
        }

        public async Task<IEventDataBatch> CreateBatchAsync(CancellationToken cancellationToken)
        {
            return new EventDataBatchImpl(await _client.CreateBatchAsync(cancellationToken).ConfigureAwait(false));
        }

        public async Task SendAsync(IEventDataBatch batch, CancellationToken cancellationToken)
        {
            _logger?.LogDebug("Sending events to EventHub");
            var eventDataBatch = ((EventDataBatchImpl) batch).Batch;
            await _client.SendAsync(eventDataBatch, cancellationToken).ConfigureAwait(false);
        }
    }
}