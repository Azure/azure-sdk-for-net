﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Azure.WebJobs.Host.Queues;
using Microsoft.Extensions.Logging;
using Azure.Storage.Queues;
using Azure.WebJobs.Extensions.Storage.Common.Tests;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Host.UnitTests.Queues
{
    public class QueueProcessorFactoryContextTests
    {
        [Test]
        public void Constructor_DefaultsValues()
        {
            QueueClient queue = new QueueClient(new Uri("https://test.queue.core.windows.net/testqueue"));
            QueueClient poisonQueue = new QueueClient(new Uri("https://test.queue.core.windows.net/poisonqueue"));
            ILoggerFactory loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new TestLoggerProvider());
            QueuesOptions queuesOptions = new QueuesOptions();

            QueueProcessorFactoryContext context = new QueueProcessorFactoryContext(queue, loggerFactory, queuesOptions, poisonQueue);

            Assert.AreSame(queue, context.Queue);
            Assert.AreSame(poisonQueue, context.PoisonQueue);
            Assert.NotNull(context.Logger);

            Assert.AreEqual(queuesOptions.BatchSize, context.BatchSize);
            Assert.AreEqual(queuesOptions.NewBatchThreshold, context.NewBatchThreshold);
            Assert.AreEqual(queuesOptions.MaxDequeueCount, context.MaxDequeueCount);
            Assert.AreEqual(queuesOptions.MaxPollingInterval, context.MaxPollingInterval);
        }
    }
}
