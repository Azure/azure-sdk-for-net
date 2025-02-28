// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Tests
{
    [TestFixture]
    internal class CpuMonitorTests
    {
        [Test]
        public void MemoryUsage_MemoryUsageShouldBeGreaterThan0()
        {
            // Arrange
            CpuMonitor cpuMonitor = new CpuMonitor(TimeSpan.FromMilliseconds(1000));

            // Act
            cpuMonitor.StartMonitoring();
            SimulateCpuLoad(1);
            cpuMonitor.StopMonitoring();

            // Assert
            Assert.Greater(cpuMonitor.MemoryUsage, 0);
        }

        [Test]
        public void MemoryUsage_ShouldBeLessThan1()
        {
            // Arrange
            CpuMonitor cpuMonitor = new CpuMonitor(TimeSpan.FromMilliseconds(1000));

            // Act
            cpuMonitor.StartMonitoring();
            SimulateCpuLoad(1);
            cpuMonitor.StopMonitoring();

            // Assert
            Assert.Less(cpuMonitor.MemoryUsage, 1);
        }

        [Test]
        public void MemoryUsage_ShouldNotBeNull()
        {
            // Arrange
            CpuMonitor cpuMonitor = new CpuMonitor(TimeSpan.FromMilliseconds(1000));

            // Act
            cpuMonitor.StartMonitoring();
            SimulateCpuLoad(1);
            cpuMonitor.StopMonitoring();

            // Assert
            Assert.NotNull(cpuMonitor.MemoryUsage);
        }

        private void SimulateCpuLoad(int durationInSeconds)
        {
            Thread.Sleep(100);
            DateTime end = DateTime.Now.AddSeconds(durationInSeconds);
            while (DateTime.Now < end)
            {
                // Perform a CPU-intensive operation
                double result = (new Random()).Next();
                for (int i = 0; i < 1000000; i++)
                {
                    result += Math.Sqrt(i);
                }
            }
            Thread.Sleep(100);
        }
    }
}
