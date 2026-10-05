// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.ResourceManager.Monitor.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Monitor.Tests
{
    public class MetricAlertDataCompatibilityTests
    {
        [Test]
        public void GeneratedWindowSizeRetainsShippedConstructorAndProperty()
        {
            var windowSize = TimeSpan.FromMinutes(5);
            var alert = new MetricAlertData(AzureLocation.EastUS, 1, true,
                new[] { "/subscriptions/sub/resourceGroups/rg" }, TimeSpan.FromMinutes(1),
                windowSize, new MetricAlertSingleResourceMultipleMetricCriteria());

            Assert.That(alert.WindowSize, Is.EqualTo(windowSize));
            alert.WindowSize = TimeSpan.FromMinutes(10);
            Assert.That(alert.WindowSize, Is.EqualTo(TimeSpan.FromMinutes(10)));
        }
    }
}
