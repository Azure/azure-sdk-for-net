// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.WebJobs.EventHubs;
using Microsoft.Azure.WebJobs.EventHubs.Listeners;
using Microsoft.Azure.WebJobs.Extensions.EventHubs.Listeners;
using Microsoft.Azure.WebJobs.Host.Scale;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Azure.WebJobs.Logging;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using static Azure.Messaging.EventHubs.Primitives.BlobCheckpointStoreInternal;

namespace Microsoft.Azure.WebJobs.Extensions.EventHubs.Tests
{
    internal class TargetScaleThrottlerTest
    {
        private TestLoggerProvider _loggerProvider;
        private LoggerFactory _loggerFactory;

        [SetUp]
        public void SetUp()
        {
            _loggerFactory = new LoggerFactory();
            _loggerProvider = new TestLoggerProvider();
            _loggerFactory.AddProvider(_loggerProvider);
        }

        [Test]
        [TestCase( // Scale down based on last scale up operation - trottle
            new int[] { 0, 0, 0, 70 },
            new int[] { 1000, 1000, 0, 60 },
            new int[] { 2000, 2000, 0, 50 },
            new int[] { 3000, 3000, 0, 40 },
            new int[] { 4000, 4000, 0, 30 },
            new int[] { 5000, 5000, 0, 20 },
            new int[] { 6000, 6000, 0, 10 },
            new int[] { 7000, 7000, 0, 0 },
            10, 120, 2, "Throttling scale down, since last scaling operation time was within")]
        [TestCase( // Scale down based on last scale up operation - no trottle
            new int[] { 0, 0, 0, 70 },
            new int[] { 1000, 1000, 0, 60 },
            new int[] { 2000, 2000, 0, 50 },
            new int[] { 3000, 3000, 0, 40 },
            new int[] { 4000, 4000, 0, 30 },
            new int[] { 5000, 5000, 0, 20 },
            new int[] { 6000, 6000, 0, 10 },
            new int[] { 7000, 7000, 0, 0 },
            10, 260, 2, "")]
        [TestCase( // Scale up throttle based on executions - trottle
            new int[] { 0, 0, 150, 70 },
            new int[] { 1000, 1000, 150, 60 },
            new int[] { 2000, 2000, 180, 50 },
            new int[] { 3000, 3000, 190, 40 },
            new int[] { 4000, 4000, 170, 30 },
            new int[] { 5000, 5000, 200, 20 },
            new int[] { 6000, 6000, 200, 10 },
            new int[] { 7000, 7000, 210, 0 },
            200, null, null, "Throttling scale up because average backlog")]
        [TestCase( // Scale up throttle based on executions - no trottle
            new int[] { 0, 0, 150, 70 },
            new int[] { 1000, 1000, 250, 60 },
            new int[] { 2000, 2000, 280, 50 },
            new int[] { 3000, 3000, 290, 40 },
            new int[] { 4000, 4000, 170, 30 },
            new int[] { 5000, 5000, 200, 20 },
            new int[] { 6000, 6000, 200, 10 },
            new int[] { 7000, 7000, 210, 0 },
            10, null, null, "")]
        [TestCase(
            new int[] { 0, 0, 0, 70 },
            new int[] { 1000, 1000, 0, 60 },
            new int[] { 2000, 2000, 0, 50 },
            new int[] { 3000, 3000, 0, 40 },
            new int[] { 4000, 4000, 5, 30 },
            new int[] { 5000, 5000, 0, 20 },
            new int[] { 6000, 6000, 0, 10 },
            new int[] { 7000, 7000, 0, 0 },
            10, 182, 2, "Throttling scale down because there was at least one non-scale down vote")]
        public void ThrottleScaleDown_ReturnsExpected
            (int[] items0, int[] items1, int[] items2, int[] items3, int[] items4, int[] items5, int[] items6, int[] items7,
            int concurrecy,
            int? whenLastScaleUpInSec,
            int? targetWorkerCountOnLastScale,
            string expectedMessage)
        {
            var logger = _loggerFactory.CreateLogger(LogCategories.CreateTriggerCategory("EventHub"));

            var testStart = DateTime.UtcNow;

            TargetScaleThrottler throttler = new TargetScaleThrottler(
                whenLastScaleUpInSec.HasValue ? testStart - TimeSpan.FromSeconds(whenLastScaleUpInSec.Value) : DateTime.MinValue,
                targetWorkerCountOnLastScale.HasValue ? new TargetScalerResult() { TargetWorkerCount = targetWorkerCountOnLastScale.Value } : new TargetScalerResult(),
                logger);

            Mock <IEventHubConsumerClient> mockEventHubConsumerClient = new Mock<IEventHubConsumerClient>();
            mockEventHubConsumerClient.Setup(x => x.EventHubName).Returns("test");

            EventHubsTargetScaler scaler = new EventHubsTargetScaler("test", mockEventHubConsumerClient.Object, new EventHubOptions(), null, logger);

            AddHistoryToThrotller(scaler, throttler, items0, concurrecy, testStart, logger);
            AddHistoryToThrotller(scaler, throttler, items1, concurrecy, testStart, logger);
            AddHistoryToThrotller(scaler, throttler, items2, concurrecy, testStart, logger);
            AddHistoryToThrotller(scaler, throttler, items3, concurrecy, testStart, logger);
            AddHistoryToThrotller(scaler, throttler, items4, concurrecy, testStart, logger);
            AddHistoryToThrotller(scaler, throttler, items5, concurrecy, testStart, logger);
            AddHistoryToThrotller(scaler, throttler, items6, concurrecy, testStart, logger);
            AddHistoryToThrotller(scaler, throttler, items7, concurrecy, testStart, logger);

            var logs = _loggerProvider.GetAllLogMessages().ToArray();
            if (!string.IsNullOrEmpty(expectedMessage))
            {
                Assert.IsTrue(logs.Where(x => x.FormattedMessage.Contains(expectedMessage)).Count() > 0);
            }
            else
            {
                Assert.IsTrue(logs.Where(x => x.FormattedMessage.Contains("Throttling scale down because last scale up time was within")).Count() == 0);
                Assert.IsTrue(logs.Where(x => x.FormattedMessage.Contains("Throttling scale up because average backlog is less than")).Count() == 0);
                Assert.IsTrue(logs.Where(x => x.FormattedMessage.Contains("Throttling scale down because there was at least one non-scale down vote")).Count() == 0);
            }
        }

        private void AddHistoryToThrotller(EventHubsTargetScaler scaler, TargetScaleThrottler throttler, int[] items, int concurrecy, DateTime testStart, Microsoft.Extensions.Logging.ILogger logger)
        {
            if (items != null)
            {
                List<BlobStorageCheckpoint> checkpoints = new List<BlobStorageCheckpoint>();
                checkpoints.Add(new BlobStorageCheckpoint()
                {
                    PartitionId = "0",
                    SequenceNumber = items[0]
                });
                checkpoints.Add(new BlobStorageCheckpoint()
                {
                    PartitionId = "1",
                    SequenceNumber = items[1]
                });

                var executionTime = testStart - TimeSpan.FromSeconds(items[3]);
                EventHubsTriggerMetrics metrics = new EventHubsTriggerMetrics()
                {
                    Checkpoints = checkpoints,
                    PartitionCount = 2,
                    EventCount = items[2],
                    Timestamp = executionTime
                };
                TargetScalerResult targetScalerResult = scaler.GetScaleResultInternal(concurrecy, metrics.EventCount, metrics.PartitionCount);

                throttler.ThrottleIfNeeded(targetScalerResult, metrics, executionTime,out string log);
                logger.LogInformation(log);
            }
        }
    }
}
