// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus.Tests;
using Azure.Test.Perf;

namespace Azure.Messaging.ServiceBus.Perf
{
    public abstract class ServiceBusPerfTestBase : PerfTest<SizeCountOptions>
    {
        protected ServiceBusScope.QueueScope QueueScope;
        private readonly bool _useSessions;
        protected ServiceBusClient Client { get; private set; }
        protected ServiceBusSender Sender { get; private set; }
        protected ServiceBusReceiver Receiver { get; private set; }
        protected int SeededMessageCount { get; }

        // until https://github.com/Azure/azure-sdk-for-net/issues/17248 is addressed we have to estimate how many
        // messages may be needed
        private const int OperationCountEstimate = 1000;

        protected byte[] MessageBody { get; }

        private static ServiceBusTestEnvironment TestEnvironment => ServiceBusTestEnvironment.Instance;

        protected ServiceBusPerfTestBase(SizeCountOptions options, bool useSessions = false) : base(options)
        {
            MessageBody = ServiceBusTestUtilities.GetRandomBuffer(options.Size);
            _useSessions = useSessions;
            SeededMessageCount = options.Count * OperationCountEstimate;
        }

        protected async Task SeedMessagesAsync(int? messageCount = default)
        {
            Queue<ServiceBusMessage> messages = new();
            for (int i = 0; i < (messageCount ?? SeededMessageCount); i++)
            {
                var message = new ServiceBusMessage(MessageBody)
                {
                    SessionId = _useSessions ? Guid.NewGuid().ToString() : null
                };
                messages.Enqueue(message);
            }

            int startCount = messages.Count;

            while (messages.Any())
            {
                using ServiceBusMessageBatch messageBatch = await Sender.CreateMessageBatchAsync();
                if (messageBatch.TryAddMessage(messages.Peek()))
                {
                    messages.Dequeue();
                }
                else
                {
                    // if the first message can't fit, then it is too large for the batch
                    throw new InvalidOperationException($"Message {startCount - messages.Count} is too large and cannot be sent.");
                }

                // add as many messages as possible to the current batch
                while (messages.Any() && messageBatch.TryAddMessage(messages.Peek()))
                {
                    // dequeue the message from the .NET queue as it has been added to the batch
                    messages.Dequeue();
                }
                await Sender.SendMessagesAsync(messageBatch);
            }
        }

        public override async Task GlobalSetupAsync()
        {
            await base.GlobalSetupAsync().ConfigureAwait(false);

            QueueScope = await ServiceBusScope.CreateWithQueue(
                enablePartitioning: false,
                enableSession: _useSessions,
                lockDuration: TimeSpan.FromMinutes(5));
            Client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
            Sender = Client.CreateSender(QueueScope.QueueName);
            Receiver = Client.CreateReceiver(QueueScope.QueueName);
        }

        public override async Task GlobalCleanupAsync()
        {
            await Client.DisposeAsync().ConfigureAwait(false);
            await QueueScope.DisposeAsync().ConfigureAwait(false);
            await base.GlobalCleanupAsync().ConfigureAwait(false);
        }

        public override void Run(CancellationToken cancellationToken) =>
            throw new InvalidOperationException("Only asynchronous execution is supported.");
    }
}
