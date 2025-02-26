// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#define TESTING

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Moq.Protected;
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
            await Task.Delay(1000); // Allow some time for monitoring
            cpuMonitor.StopMonitoring();

            // Assert
            Assert.That(cpuMonitor.CpuUsage, Is.GreaterThan(0));
        }

        [Test]
        public async Task CpuUsage_ShouldNeverGoAbove1()
        {
            // Arrange
            var cpuMonitor = new CpuMonitor(TimeSpan.FromMilliseconds(1));

            // Act
            cpuMonitor.StartMonitoring();

            // Assert
            for (var i = 0; i < 1000; i++)
            {
                Assert.That(cpuMonitor.CpuUsage, Is.LessThan(1));
                Console.WriteLine(cpuMonitor.CpuUsage);
                await Task.Delay(1);
            }
            cpuMonitor.StopMonitoring();
        }

        [Test]
        public void CpuMonitor_ShouldThrowExceptionIfNotStarted()
        {
            // Arrange
            var cpuMonitor = new CpuMonitor(TimeSpan.FromMilliseconds(100));

            // Assert
            Assert.Throws<InvalidOperationException>(() => cpuMonitor.StopMonitoring());
        }
    }
}
