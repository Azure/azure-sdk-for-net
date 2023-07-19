// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus.Perf;
using Azure.Messaging.ServiceBus.Tests;
using Azure.Test.Perf;

namespace Azure.Messaging.ServiceBus.Perf.Scenarios
{
    public sealed class SendMessageBatch : ServiceBusPerfTestBase
    {
        private readonly SizeCountOptions _options;

        public SendMessageBatch(SizeCountOptions options) : base(options)
        {
            _options = options;
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            var batch = await Sender.CreateMessageBatchAsync(cancellationToken);
            for (int i = 0; i < _options.Count; i++)
            {
                batch.TryAddMessage(new ServiceBusMessage(MessageBody));
            }
            await Sender.SendMessagesAsync(batch, cancellationToken);
        }
    }
}
