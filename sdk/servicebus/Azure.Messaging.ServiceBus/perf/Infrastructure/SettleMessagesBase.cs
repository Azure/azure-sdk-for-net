// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Test.Perf;

namespace Azure.Messaging.ServiceBus.Perf
{
    public abstract class SettleMessagesBase : ServiceBusPerfTestBase
    {
        protected readonly Queue<ServiceBusReceivedMessage> ReceivedMessages;
        private readonly SizeCountOptions _options;

        protected SettleMessagesBase(SizeCountOptions options) : base(options)
        {
            ReceivedMessages = new Queue<ServiceBusReceivedMessage>();
            _options = options;
        }

        public override async Task SetupAsync()
        {
            await SeedMessagesAsync(1000);
            int remaining = 1000;
            while (remaining > 0)
            {
                IReadOnlyList<ServiceBusReceivedMessage> messages = await Receiver.ReceiveMessagesAsync(remaining);
                remaining -= messages.Count;
                foreach (ServiceBusReceivedMessage message in messages)
                {
                    ReceivedMessages.Enqueue(message);
                }
            }
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            for (int i = 0; i < _options.Count; i++)
            {
                await SettleAsync(ReceivedMessages.Dequeue(), cancellationToken);
            }
        }

        protected abstract Task SettleAsync(ServiceBusReceivedMessage message, CancellationToken cancellationToken);
    }
}
