// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Messaging.ServiceBus;
using Microsoft.Azure.WebJobs.Extensions.ServiceBus.Listeners;
using NUnit.Framework;
using System;

namespace Microsoft.Azure.WebJobs.Extensions.ServiceBus.Tests.Listeners
{
    internal class ServiceBusMetricsProviderTests
    {
        [Test]
        public void GetMetrics_ReturnsExpectedResult()
        {
            var utcNow = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromSeconds(10));

            var message = ServiceBusModelFactory.ServiceBusReceivedMessage(enqueuedTime: utcNow);

            // Test base case
            var metrics = ServiceBusMetricsProvider.CreateTriggerMetrics(null, 0, 0, 0, false);

            Assert.AreEqual(0, metrics.PartitionCount);
            Assert.AreEqual(0, metrics.MessageCount);
            Assert.AreEqual(TimeSpan.FromSeconds(0), metrics.QueueTime);
            Assert.AreNotEqual(default(DateTime), metrics.Timestamp);

            // Test messages on main queue
            metrics = ServiceBusMetricsProvider.CreateTriggerMetrics(message, 10, 0, 0, false);

            Assert.AreEqual(0, metrics.PartitionCount);
            Assert.AreEqual(10, metrics.MessageCount);
            Assert.That(metrics.QueueTime, Is.GreaterThanOrEqualTo(TimeSpan.FromSeconds(10)));
            Assert.AreNotEqual(default(DateTime), metrics.Timestamp);

            // Test listening on dead letter queue
            metrics = ServiceBusMetricsProvider.CreateTriggerMetrics(message, 10, 100, 0, true);

            Assert.AreEqual(0, metrics.PartitionCount);
            Assert.AreEqual(100, metrics.MessageCount);
            Assert.That(metrics.QueueTime, Is.GreaterThanOrEqualTo(TimeSpan.FromSeconds(10)));
            Assert.AreNotEqual(default(DateTime), metrics.Timestamp);

            // Test partitions
            metrics = ServiceBusMetricsProvider.CreateTriggerMetrics(null, 0, 0, 16, false);

            Assert.AreEqual(16, metrics.PartitionCount);
            Assert.AreEqual(0, metrics.MessageCount);
            Assert.AreEqual(TimeSpan.FromSeconds(0), metrics.QueueTime);
            Assert.AreNotEqual(default(DateTime), metrics.Timestamp);
        }
    }
}
