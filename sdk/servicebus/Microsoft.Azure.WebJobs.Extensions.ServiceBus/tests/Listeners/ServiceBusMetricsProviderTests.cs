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

            Assert.That(metrics.PartitionCount, Is.EqualTo(0));
            Assert.That(metrics.MessageCount, Is.EqualTo(0));
            Assert.That(metrics.QueueTime, Is.EqualTo(TimeSpan.FromSeconds(0)));
            Assert.That(metrics.Timestamp, Is.Not.EqualTo(default(DateTime)));

            // Test messages on main queue
            metrics = ServiceBusMetricsProvider.CreateTriggerMetrics(message, 10, 0, 0, false);

            Assert.That(metrics.PartitionCount, Is.EqualTo(0));
            Assert.That(metrics.MessageCount, Is.EqualTo(10));
            Assert.That(metrics.QueueTime, Is.GreaterThanOrEqualTo(TimeSpan.FromSeconds(10)));
            Assert.That(metrics.Timestamp, Is.Not.EqualTo(default(DateTime)));

            // Test listening on dead letter queue
            metrics = ServiceBusMetricsProvider.CreateTriggerMetrics(message, 10, 100, 0, true);

            Assert.That(metrics.PartitionCount, Is.EqualTo(0));
            Assert.That(metrics.MessageCount, Is.EqualTo(100));
            Assert.That(metrics.QueueTime, Is.GreaterThanOrEqualTo(TimeSpan.FromSeconds(10)));
            Assert.That(metrics.Timestamp, Is.Not.EqualTo(default(DateTime)));

            // Test partitions
            metrics = ServiceBusMetricsProvider.CreateTriggerMetrics(null, 0, 0, 16, false);

            Assert.That(metrics.PartitionCount, Is.EqualTo(16));
            Assert.That(metrics.MessageCount, Is.EqualTo(0));
            Assert.That(metrics.QueueTime, Is.EqualTo(TimeSpan.FromSeconds(0)));
            Assert.That(metrics.Timestamp, Is.Not.EqualTo(default(DateTime)));
        }
    }
}
