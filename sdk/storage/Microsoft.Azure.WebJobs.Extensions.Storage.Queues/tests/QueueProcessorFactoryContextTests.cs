// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Queues;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Tests;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Queues;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Queues
{
    public class QueueProcessorOptionsTests
    {
        [Test]
        public void Constructor_DefaultsValues()
        {
            QueueClient queue = new QueueClient(new Uri("https://test.queue.core.windows.net/testqueue"));
            QueueClient poisonQueue = new QueueClient(new Uri("https://test.queue.core.windows.net/poisonqueue"));
            ILoggerFactory loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new TestLoggerProvider());
            QueuesOptions queuesOptions = new QueuesOptions();

            QueueProcessorOptions context = new QueueProcessorOptions(queue, loggerFactory, queuesOptions, poisonQueue);

            Assert.AreSame(queue, context.Queue);
            Assert.AreSame(poisonQueue, context.PoisonQueue);
            Assert.NotNull(context.Logger);

            Assert.AreEqual(queuesOptions.BatchSize, context.Options.BatchSize);
            Assert.AreEqual(queuesOptions.NewBatchThreshold, context.Options.NewBatchThreshold);
            Assert.AreEqual(queuesOptions.MaxDequeueCount, context.Options.MaxDequeueCount);
            Assert.AreEqual(queuesOptions.MaxPollingInterval, context.Options.MaxPollingInterval);
        }
    }
}
