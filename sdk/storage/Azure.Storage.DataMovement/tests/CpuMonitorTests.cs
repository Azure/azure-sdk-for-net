// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#define TESTING

using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Tests
{
    [TestFixture]
    public class CpuMonitorTests
    {
        [Test]
        public async Task CpuUsage_ShouldBeMonitoredCorrectly()
        {
            // Arrange
            var cpuMonitor = new CpuMonitor(TimeSpan.FromMilliseconds(100));

            // Act
            cpuMonitor.StartMonitoring();
            await Task.Delay(500); // Allow some time for monitoring
            cpuMonitor.StopMonitoring();

            // Assert
            Assert.That(cpuMonitor.CpuUsage, Is.GreaterThan(0));
        }
    }
}
