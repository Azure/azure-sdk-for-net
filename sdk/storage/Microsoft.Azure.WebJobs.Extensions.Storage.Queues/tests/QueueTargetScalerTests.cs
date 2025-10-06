// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Queues;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Listeners;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Tests;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Scale;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Queues.Tests
{
    public class QueueTargetScalerTests
    {
        private ILoggerFactory _loggerFactory;
        private TestLoggerProvider _loggerProvider;

        [SetUp]
        public void Setup()
        {
            _loggerFactory = new LoggerFactory();
            _loggerProvider = new TestLoggerProvider();
            _loggerFactory.AddProvider(_loggerProvider);
        }

        [Test]
        [TestCase(160, null, 10)]
        [TestCase(150, null, 10)]
        [TestCase(144, null, 9)]
        [TestCase(160, 20, 8)]
        public void QueueTargetScaler_Returns_Expected(int queueLength, int? concurrency, int expectedTargetWorkerCount)
        {
            QueuesOptions options = new QueuesOptions { BatchSize = 8, NewBatchThreshold = 8 };

            TargetScalerContext context = new TargetScalerContext
            {
                InstanceConcurrency = concurrency
            };

            _loggerFactory = new LoggerFactory();
            _loggerProvider = new TestLoggerProvider();
            _loggerFactory.AddProvider(_loggerProvider);

            Mock<QueueClient> mockQueueClient = new Mock<QueueClient>();
            mockQueueClient.Setup(q => q.Name).Returns("testQueue");

            QueueTargetScaler targetScaler = new QueueTargetScaler("testFunctionId", mockQueueClient.Object, options, _loggerFactory);
            TargetScalerResult result = targetScaler.GetScaleResultInternal(context, queueLength);
            Assert.AreEqual(expectedTargetWorkerCount, result.TargetWorkerCount);
        }
    }
}
