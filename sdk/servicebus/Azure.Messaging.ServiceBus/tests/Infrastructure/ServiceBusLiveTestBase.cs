﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
        private const int DefaultTryTimeout = 15;

        public ServiceBusTestEnvironment TestEnvironment { get; } = ServiceBusTestEnvironment.Instance;

        protected ServiceBusClient CreateNoRetryClient(int tryTimeout = DefaultTryTimeout)
        {
            var options =
                new ServiceBusClientOptions
                {
                    RetryOptions = new ServiceBusRetryOptions
                    {
                        TryTimeout = TimeSpan.FromSeconds(tryTimeout),
                        MaxRetries = 0
                    }
                };
            return new ServiceBusClient(
                TestEnvironment.ServiceBusConnectionString,
                options);
        }

        protected ServiceBusClient CreateClient(int tryTimeout = DefaultTryTimeout)
        {
            var options =
                new ServiceBusClientOptions
                {
                    RetryOptions = new ServiceBusRetryOptions
                    {
                        TryTimeout = TimeSpan.FromSeconds(tryTimeout),
                    }
                };
            return new ServiceBusClient(
                TestEnvironment.ServiceBusConnectionString,
                options);
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
