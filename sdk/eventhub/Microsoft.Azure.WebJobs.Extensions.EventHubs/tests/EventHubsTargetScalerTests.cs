// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Azure.Messaging.EventHubs.Primitives;
using Microsoft.Azure.WebJobs.Extensions.EventHubs.Listeners;
using Microsoft.Azure.WebJobs.Host.Scale;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Azure.WebJobs.Logging;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.EventHubs.UnitTests
{
    public class EventHubsTargetScalerTests
    {
        private readonly string _functionId = "EventHubsTriggerFunction";
        private readonly string _eventHubName = "TestEventHubName";
        private readonly string _consumerGroup = "TestConsumerGroup";
        private readonly string _namespace = "TestNamespace";
        private EventHubsTargetScaler _targetScaler;
        private Mock<BlobCheckpointStoreInternal> _mockCheckpointStore;
        private TestLoggerProvider _loggerProvider;
        private LoggerFactory _loggerFactory;
        private Mock<IEventHubConsumerClient> _consumerClientMock;
        private Mock<EventHubMetricsProvider> _metricsProviderMock;
        private EventHubOptions _options;

        [SetUp]
        public void SetUp()
        {
            _loggerFactory = new LoggerFactory();
            _loggerProvider = new TestLoggerProvider();
            _loggerFactory.AddProvider(_loggerProvider);

            _consumerClientMock = new Mock<IEventHubConsumerClient>(MockBehavior.Strict);
            _consumerClientMock.Setup(c => c.ConsumerGroup).Returns(_consumerGroup);
            _consumerClientMock.Setup(c => c.EventHubName).Returns(_eventHubName);
            _consumerClientMock.Setup(c => c.FullyQualifiedNamespace).Returns(_namespace);
            _options = new EventHubOptions();
            this._mockCheckpointStore = new Mock<BlobCheckpointStoreInternal>(MockBehavior.Strict);

            _metricsProviderMock = new Mock<EventHubMetricsProvider>();

            _targetScaler = new EventHubsTargetScaler(
                                    _functionId,
                                    _consumerClientMock.Object,
                                    _options,
                                    _metricsProviderMock.Object,
                                    _loggerFactory.CreateLogger(LogCategories.CreateTriggerCategory("EventHub")));
        }

        [Test]
        public void TargetScalerDescriptor_ReturnsExpectedValue()
        {
            Assert.AreEqual($"{_functionId}", _targetScaler.TargetScalerDescriptor.FunctionId);
        }

        [Test]
        [TestCase(10, 9, 100, 10)]
        [TestCase(9, 10, 100, 10)] // Throttle scale down
        [TestCase(9, 10, 179, 10)] // Throttle scale down
        [TestCase(9, 10, 180, 9)] // Allow scale down
        [TestCase(9, 10, 181, 9)] // Allow scale down
        public void ThrottleScaleDownIfNecessaryInternal_ReturnsExpected(int currentTarget, int previousTarget, int secondsSinceLastScaleUp, int expectedTarget)
        {
            TargetScalerResult currrentResult = new TargetScalerResult() { TargetWorkerCount = currentTarget };
            TargetScalerResult previousResult = new TargetScalerResult() { TargetWorkerCount = previousTarget };

            DateTime lastScaleUp = DateTime.UtcNow.AddSeconds(-secondsSinceLastScaleUp);

            TargetScalerResult finalResult = EventHubsTargetScaler.ThrottleScaleDownIfNecessaryInternal(currrentResult, previousResult, lastScaleUp, _loggerFactory.CreateLogger<EventHubsTargetScalerTests>());

            Assert.AreEqual(finalResult.TargetWorkerCount, expectedTarget);
        }

        [Test]
        // Using default concurrency of 10.
        [TestCase(10, 10, 10, 1)]
        [TestCase(20, 10, 10, 2)]
        [TestCase(30, 10, 10, 3)]
        [TestCase(60, 10, 10, 10)]
        [TestCase(70, 10, 10, 10)]
        [TestCase(150, 10, 10, 10)]
        [TestCase(2147483650, 1, 1, 1)] // Testing eventCount > int.MaxInt is 2147483647
        [TestCase(21474836500, 1000, 1, 1000)] // Testing eventCount > int.MaxInt is 2147483647, with concurrency 1 to force overflow
        public void GetScaleResultInternal_ReturnsExpected(long eventCount, int partitionCount, int? concurrency, int expectedTargetWorkerCount)
        {
            TargetScalerResult result = _targetScaler.GetScaleResultInternal(new TargetScalerContext { InstanceConcurrency = concurrency }, eventCount, partitionCount);
            Assert.AreEqual(expectedTargetWorkerCount, result.TargetWorkerCount);
        }

        [Test]
        [TestCase(10, 20, 30, 10)] // InstanceConcurrency defined in TargetScalerContext takes precedence
        [TestCase(null, 20, 30, 30)] // TargetUnprocessedEventThreshold takes second precendence
        [TestCase(null, 20, null, 20)] // Finally MaxEventBatchSize is only used if InstanceConcurrency and TargetUnprocessedEventThreshold are both undefined
        [TestCase(null, null, null, 100)] // Using default value of MaxEventBatchSize
        public void GetDesiredConcurrencyInternal_ReturnsExpected(int? instanceConcurrency, int? maxEventBatchSize, int? targetUnprocessedEventThreshold, int expectedConcurrency)
        {
            TargetScalerContext context = new TargetScalerContext() { InstanceConcurrency = instanceConcurrency };

            if (maxEventBatchSize != null) _options.MaxEventBatchSize = maxEventBatchSize.Value;
            if (targetUnprocessedEventThreshold != null) _options.TargetUnprocessedEventThreshold = targetUnprocessedEventThreshold.Value;

            int actualConcurrency = _targetScaler.GetDesiredConcurrencyInternal(context);
            Assert.AreEqual(expectedConcurrency, actualConcurrency);
        }

        [Test]
        [TestCase(10, new[] { 0, 1, 2, 3, 4, 5, 10 })]
        [TestCase(1, new[] { 0, 1 })]
        [TestCase(5, new[] { 0, 1, 2, 3, 5 })]
        [TestCase(20, new[] { 0, 1, 2, 3, 4, 5, 7, 10, 20 })]
        public void TestGetSortedValidWorkerCountsForPartitionCount(int partitionCount, int[] expectedValidWorkerCountsOrdered)
        {
            int[] actualWorkerCounts = EventHubsTargetScaler.GetSortedValidWorkerCountsForPartitionCount(partitionCount);
            Assert.AreEqual(expectedValidWorkerCountsOrdered.Length, actualWorkerCounts.Length);

            // Checking the ordering of the lists
            for (int i = 0; i < expectedValidWorkerCountsOrdered.Length; i++)
            {
                Assert.AreEqual(expectedValidWorkerCountsOrdered[i], actualWorkerCounts[i]);
            }
        }

        [Test]
        [TestCase(2, new[] { 1, 4, 10, 20 }, 4)]
        [TestCase(21, new[] { 1, 4, 10, 20 }, 20)]
        [TestCase(0, new[] { 1, 4, 10, 20 }, 1)]
        [TestCase(10, new[] { 1, 4, 10, 20 }, 10)]
        public void GetSortedValidWorkerCountsForPartitionCount_ReturnsExpected(int workerCount, int[] sortedWorkerCountList, int expectedValidWorkerCount)
        {
            int actualValidWorkerCount = EventHubsTargetScaler.GetValidWorkerCount(workerCount, sortedWorkerCountList);
            Assert.AreEqual(expectedValidWorkerCount, actualValidWorkerCount);
        }
    }
}
