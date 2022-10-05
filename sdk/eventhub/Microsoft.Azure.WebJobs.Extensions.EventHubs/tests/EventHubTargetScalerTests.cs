// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Primitives;
using Microsoft.Azure.WebJobs.EventHubs;
using Microsoft.Azure.WebJobs.EventHubs.Listeners;
using Microsoft.Azure.WebJobs.EventHubs.UnitTests;
using Microsoft.Azure.WebJobs.Extensions.EventHubs.Listeners;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static Moq.It;

namespace Microsoft.Azure.WebJobs.Extensions.EventHubs.Tests
{
    internal class EventHubTargetScalerTests
    {
        private readonly string _functionId = "EventHubsTriggerFunction";
        private Mock<BlobCheckpointStoreInternal> _mockCheckpointStore;
        private TestLoggerProvider _loggerProvider;
        private ILoggerFactory _loggerFactory;
        private Mock<IEventHubConsumerClient> _consumerClientMock;
        private EventHubOptions _options;
        private EventHubsTriggerMetrics _eventHubsTriggerMetrics;

        [SetUp]
        public void SetUp()
        {
            _loggerFactory = new LoggerFactory();
            _loggerProvider = new TestLoggerProvider();
            _loggerFactory.AddProvider(_loggerProvider);

            _consumerClientMock = new Mock<IEventHubConsumerClient>(MockBehavior.Strict);
            _mockCheckpointStore = new Mock<BlobCheckpointStoreInternal>(MockBehavior.Strict);
            _options = new EventHubOptions();
            _eventHubsTriggerMetrics = new EventHubsTriggerMetrics();
        }

        [Test]
        public void GetScaleResultAsyncTargetWorkerCountBiggerThenPartitionCount()
        {
            //Arrange
            _eventHubsTriggerMetrics.PartitionCount = 4;
            _eventHubsTriggerMetrics.EventCount = 1000;
            _options.MaxEventBatchSize = 10;

            //Act
            EventHubTargetScaler eventHubTargetScaler = new EventHubTargetScaler(_functionId, _consumerClientMock.Object, _options,
                _loggerFactory, _mockCheckpointStore.Object);

             var result = eventHubTargetScaler.GetScaleResultInternal(new Host.Scale.TargetScalerContext(), _eventHubsTriggerMetrics);

            //Assert
            Assert.AreEqual(result.TargetWorkerCount, _eventHubsTriggerMetrics.PartitionCount);
        }

        [Test]
        public void GetScaleResultAsyncTargetWorkerCountLessThenPartitionCount()
        {
            //Arrange
            _eventHubsTriggerMetrics.PartitionCount = 4;
            _eventHubsTriggerMetrics.EventCount = 10;
            _options.MaxEventBatchSize = 10;

            //Act
            EventHubTargetScaler eventHubTargetScaler = new EventHubTargetScaler(_functionId, _consumerClientMock.Object, _options,
                _loggerFactory, _mockCheckpointStore.Object);

            var result = eventHubTargetScaler.GetScaleResultInternal(new Host.Scale.TargetScalerContext(), _eventHubsTriggerMetrics);

            //Assert
            Assert.AreEqual(result.TargetWorkerCount, 1);
        }
        [Test]
        public void GetScaleResultAsyncTargetWorkerCountEqualsPartitionCount()
        {
            //Arrange
            _eventHubsTriggerMetrics.PartitionCount = 4;
            _eventHubsTriggerMetrics.EventCount = 40;
            _options.MaxEventBatchSize = 10;

            //Act
            EventHubTargetScaler eventHubTargetScaler = new EventHubTargetScaler(_functionId, _consumerClientMock.Object, _options,
                _loggerFactory, _mockCheckpointStore.Object);

            var result = eventHubTargetScaler.GetScaleResultInternal(new Host.Scale.TargetScalerContext(), _eventHubsTriggerMetrics);

            //Assert
            Assert.AreEqual(result.TargetWorkerCount, _eventHubsTriggerMetrics.PartitionCount);
        }
    }
}
