// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Tests
{
    [TestFixture]
    public class CpuMonitorTests
    {
        [Test]
        public void CpuUsage_ShouldMonitorCpuUsage()
        {
            // Arrange
            var cpuMonitor = new CpuMonitor(TimeSpan.FromMilliseconds(1000));

            // Act
            cpuMonitor.StartMonitoring();
            SimulateCpuLoad(3);
            cpuMonitor.StopMonitoring();

            // Assert
            Assert.That(cpuMonitor.CpuUsage, Is.GreaterThan(0));
        }

        [Test]
        public void CpuUsage_ShouldNeverGoAbove1()
        {
            // Arrange
            var cpuMonitor = new CpuMonitor(TimeSpan.FromMilliseconds(1000));

            // Act
            cpuMonitor.StartMonitoring();
            SimulateCpuLoad(10);
            cpuMonitor.StopMonitoring();

            // Assert
            //for (var i = 0; i < 1000; i++)
            //{
            //    Assert.That(cpuMonitor.CpuUsage, Is.LessThan(1));
            //}
            Assert.That(cpuMonitor.CpuUsage, Is.LessThan(1));
            Assert.Greater(cpuMonitor.CpuUsage, 0);
        }

        [Test]
        public void CpuUsage_TimeSpanUnder10MillisecondsShouldHaveZeroReadings()
        {
            // Arrange
            var cpuMonitor = new CpuMonitor(TimeSpan.FromMilliseconds(10));

            // Act
            cpuMonitor.StartMonitoring();
            SimulateCpuLoad(2);
            cpuMonitor.StopMonitoring();

            // Assert
            //for (var i = 0; i < 1000; i++)
            //{
            //    Assert.That(cpuMonitor.CpuUsage, Is.LessThan(1));
            //}
            Assert.AreEqual(cpuMonitor.CpuUsage, 0);
        }

        [Test]
        public void CpuMonitor_ShouldThrowExceptionIfNotStarted()
        {
            // Arrange
            var cpuMonitor = new CpuMonitor(TimeSpan.FromMilliseconds(100));

            // Assert
            Assert.Throws<InvalidOperationException>(() => cpuMonitor.StopMonitoring());
        }

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
