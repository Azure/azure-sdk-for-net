// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Client
{
    public class ServiceBusTransportMetricsTests
    {
        [Test]
        public void CanConstructMetricsWithFactory()
        {
            var now = DateTimeOffset.UtcNow;
            var yesterday = now.Subtract(TimeSpan.FromDays(1));
            var tomorrow = now.Add(TimeSpan.FromDays(1));
            var metrics = ServiceBusModelFactory.ServiceBusTransportMetrics(now, yesterday, tomorrow);

            Assert.AreEqual(now, metrics.LastHeartBeat);
            Assert.AreEqual(yesterday, metrics.LastConnectionOpen);
            Assert.AreEqual(tomorrow, metrics.LastConnectionClose);
        }

        [Test]
        public void CloneCopiesAllProperties()
        {
            var now = DateTimeOffset.UtcNow;
            var yesterday = now.Subtract(TimeSpan.FromDays(1));
            var tomorrow = now.Add(TimeSpan.FromDays(1));
            var metrics = new ServiceBusTransportMetrics
            {
                LastHeartBeat = now,
                LastConnectionOpen = yesterday,
                LastConnectionClose = tomorrow,
            };
            var cloned = metrics.Clone();

            Assert.AreEqual(metrics.LastHeartBeat, cloned.LastHeartBeat);
            Assert.AreEqual(metrics.LastConnectionOpen, cloned.LastConnectionOpen);
            Assert.AreEqual(metrics.LastConnectionClose, cloned.LastConnectionClose);
        }
    }
}