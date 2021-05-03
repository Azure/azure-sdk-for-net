// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests
{
    [Category(TestCategory.Live)]
    [Category(TestCategory.DisallowVisualStudioLiveUnitTesting)]
    public abstract class ServiceBusLiveTestBase : ServiceBusTestBase
    {
        public ServiceBusTestEnvironment TestEnvironment { get; } = ServiceBusTestEnvironment.Instance;

        protected ServiceBusClient CreateNoRetryClient()
        {
            var options =
                new ServiceBusClientOptions
                {
                    RetryOptions = new ServiceBusRetryOptions
                    {
                        TryTimeout = TimeSpan.FromSeconds(10),
                        MaxRetries = 0
                    }
                };
            return new ServiceBusClient(
                TestEnvironment.ServiceBusConnectionString,
                options);
        }

        protected ServiceBusClient CreateClient(int tryTimeout = 15)
        {
            var retryOptions = new ServiceBusRetryOptions();
            if (tryTimeout != default)
            {
                retryOptions.TryTimeout = TimeSpan.FromSeconds(tryTimeout);
            }
            return new ServiceBusClient(
                TestEnvironment.ServiceBusConnectionString,
                new ServiceBusClientOptions
                {
                    RetryOptions = retryOptions
                });
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

                while ((numberOfMessages > 0) && (batch.TryAddMessage(new ServiceBusMessage(Guid.NewGuid().ToString()))))
                {
                    --numberOfMessages;
                }

                await sender.SendMessagesAsync(batch);

                batch.Dispose();
                batch = default;
            }
        }
    }
}
