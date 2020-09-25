// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Azure.WebJobs.Host.Queues;
using Microsoft.Extensions.Logging;
using Xunit;
using Azure.Storage.Queues;
using Azure.WebJobs.Extensions.Storage.Common.Tests;

namespace Microsoft.Azure.WebJobs.Host.UnitTests.Queues
{
    public class QueueProcessorFactoryContextTests
    {
        [Fact]
        public void Constructor_DefaultsValues()
        {
            QueueClient queue = new QueueClient(new Uri("https://test.queue.core.windows.net/testqueue"));
            QueueClient poisonQueue = new QueueClient(new Uri("https://test.queue.core.windows.net/poisonqueue"));
            ILoggerFactory loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new TestLoggerProvider());
            QueuesOptions queuesOptions = new QueuesOptions();

            QueueProcessorFactoryContext context = new QueueProcessorFactoryContext(queue, loggerFactory, queuesOptions, poisonQueue);

            Assert.Same(queue, context.Queue);
            Assert.Same(poisonQueue, context.PoisonQueue);
            Assert.NotNull(context.Logger);

            Assert.Equal(queuesOptions.BatchSize, context.BatchSize);
            Assert.Equal(queuesOptions.NewBatchThreshold, context.NewBatchThreshold);
            Assert.Equal(queuesOptions.MaxDequeueCount, context.MaxDequeueCount);
            Assert.Equal(queuesOptions.MaxPollingInterval, context.MaxPollingInterval);
        }
    }
}
