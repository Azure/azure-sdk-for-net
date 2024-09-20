// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Messaging.ServiceBus.Amqp;
using Microsoft.Azure.Amqp;

namespace Azure.Messaging.ServiceBus.Tests
{
    [LiveOnly(true)]
    public abstract class ServiceBusLiveTestBase : LiveTestBase<ServiceBusTestEnvironment>
    {
        private const int DefaultTryTimeout = 15;

        protected TimeSpan ShortLockDuration = TimeSpan.FromSeconds(10);

        protected ServiceBusClient CreateNoRetryClient(int tryTimeout = DefaultTryTimeout) => CreateClient(tryTimeout, 0);

        protected ServiceBusClient CreateClient(int tryTimeout = DefaultTryTimeout, int maxRetries = 3)
        {
            var options =
                new ServiceBusClientOptions
                {
                    RetryOptions = new ServiceBusRetryOptions
                    {
                        TryTimeout = TimeSpan.FromSeconds(tryTimeout),
                        MaxRetries = maxRetries
                    }
                };
            return new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential, options);
        }

        protected static async Task SendMessagesAsync(
            ServiceBusClient client,
            string entityPath,
            int numberOfMessages)
        {
            await using var sender = client.CreateSender(entityPath);

            var batch = default(ServiceBusMessageBatch);

            while (numberOfMessages > 0)
            {
                batch ??= await sender.CreateMessageBatchAsync();

                while ((numberOfMessages > 0)
                    && (batch.Count < 4000)
                    && (batch.TryAddMessage(new ServiceBusMessage(Guid.NewGuid().ToString()))))
                {
                    --numberOfMessages;
                }

                await sender.SendMessagesAsync(batch);

                batch.Dispose();
                batch = default;
            }
        }

        protected static void SimulateNetworkFailure(ServiceBusClient client)
        {
            var amqpClient = client.Connection.InnerClient;
            AmqpConnectionScope scope = (AmqpConnectionScope) typeof(AmqpClient).GetProperty(
                "ConnectionScope",
                BindingFlags.Instance | BindingFlags.NonPublic).GetValue(amqpClient);
            ((FaultTolerantAmqpObject<AmqpConnection>) typeof(AmqpConnectionScope).GetProperty(
                "ActiveConnection",
                BindingFlags.Instance | BindingFlags.NonPublic).GetValue(scope)).TryGetOpenedObject(out AmqpConnection activeConnection);

            activeConnection.Abort();
        }
    }
}
