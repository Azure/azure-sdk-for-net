// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Tests
{
    [TestFixture]
    public class ResourceMonitorTests
    {
        [Test]
        public void CpuUsage_ShouldBeGreaterThan0()
        {
            // Arrange
            var resourceMonitor = new ResourceMonitor();
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;

            // Act
            resourceMonitor.StartMonitoring(cancellationToken);
            SimulateCpuLoad(10);
            cancellationTokenSource.Cancel();

            // Assert
            Assert.That(resourceMonitor.CpuUsage, Is.GreaterThan(0));
        }

        [Test]
        public void CpuUsage_ShouldNeverGoAbove1()
        {
            // Arrange
            var resourceMonitor = new ResourceMonitor();
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;

            // Act
            resourceMonitor.StartMonitoring(cancellationToken);
            SimulateCpuLoad(10);
            cancellationTokenSource.Cancel();
            // Assert
            //for (var i = 0; i < 1000; i++)
            //{
            //    Assert.That(cpuMonitor.CpuUsage, Is.LessThan(1));
            //}
            Assert.That(resourceMonitor.CpuUsage, Is.LessThan(1));
            Assert.Greater(resourceMonitor.CpuUsage, 0);
        }

        [Test]
        public void CpuMonitor_ShouldDoNothingIfCallingStopOnMonitorWhenNotRunning()
        {
            // Arrange
            var resourceMonitor = new ResourceMonitor(TimeSpan.FromMilliseconds(100));
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;

            // Assert
            Assert.DoesNotThrow(() => cancellationTokenSource.Cancel(), "No error thrown");
        }

        [Test]
        public void MemoryUsage_MemoryUsageShouldBeGreaterThan0()
        {
            // Arrange
            var resourceMonitor = new ResourceMonitor();
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;

            // Act
            resourceMonitor.StartMonitoring(cancellationToken);
            SimulateCpuLoad(1);
            cancellationTokenSource.Cancel();

            // Assert
            Assert.Greater(resourceMonitor.MemoryUsage, 0);
        }

        [Test]
        public void MemoryUsage_ShouldNotBeNull()
        {
            // Arrange
            var resourceMonitor = new ResourceMonitor();
            using var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;

            // Act
            resourceMonitor.StartMonitoring(cancellationToken);
            SimulateCpuLoad(1);
            cancellationTokenSource.Cancel();

            // Assert
            Assert.NotNull(resourceMonitor.MemoryUsage);
        }

        [Test]
        public void ResourceMonitorConstructor_ShouldNotAllowLessThan0ms()
        {
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new ResourceMonitor(TimeSpan.FromMilliseconds(-1)));
        }

        //[Test]

        /* Unmerged change from project 'Azure.Storage.DataMovement.Tests (net462)'
        Before:
                public void ResourceMonitorConstructor_LowMonitorIntervalsShouldNotAddOverhead()
                {
        After:
                public void ResourceMonitorConstructor_LowMonitorIntervalsShouldNotAddOverheadAsync()
                {
        */

        // This test is for checking whether a higher frequency check was using more resources than a lower
        // frequency check. This fails when running the entire testing suite because other tests are running
        // which causes the measurements to be off

        //public async Task ResourceMonitorConstructor_HigherFrequencyChecksShouldTakeMoreResources()
        //{
        //    // Arrange
        //    float cpuUsageStart = 0.0F;
        //    float cpuUsageEnd = 0.0F;
        //    double memoryUsageStart = 0L;
        //    double memoryUsageEnd = 0L;
        //    Stopwatch watch = new();
        //    List<float> lowerMonitorCpuUsages = new();
        //    List<double> lowerMonitorMemoryUsages = new();
        //    List<float> higherMonitorCpuUsages = new();
        //    List<double> higherMonitorMemoryUsages = new();

        //    TimeSpan endTime = TimeSpan.FromSeconds(5);
        //    TimeSpan monitorInterval = TimeSpan.FromMilliseconds(1000);

        //    // Act
        //    // The lower frequency check
        //    ResourceMonitor resourceMonitor = new(monitorInterval);
        //    using var cancellationTokenSource = new CancellationTokenSource();
        //    var cancellationToken = cancellationTokenSource.Token;
        //    watch.Start();
        //    resourceMonitor.StartMonitoring(cancellationToken);

        //    while (watch.Elapsed < endTime)
        //    {
        //        // Sleeping here so that resource monitor has time to take readings
        //        await Task.Delay(monitorInterval);
        //        cpuUsageEnd = resourceMonitor.CpuUsage;
        //        memoryUsageEnd = resourceMonitor.MemoryUsage;

        //        // Add to respective lists
        //        lowerMonitorCpuUsages.Add(cpuUsageEnd);
        //        lowerMonitorMemoryUsages.Add(memoryUsageEnd);

        //        cpuUsageStart = cpuUsageEnd;
        //        memoryUsageStart = memoryUsageEnd;
        //    }
        //    cancellationTokenSource.Cancel();
        //    watch.Stop();

        //    watch.Restart();

        //    // The higher frequency check
        //    monitorInterval = TimeSpan.FromMilliseconds(1);
        //    resourceMonitor = new(monitorInterval);
        //    cancellationTokenSource = new CancellationTokenSource();
        //    cancellationToken = cancellationTokenSource.Token;
        //    resourceMonitor.StartMonitoring(cancellationToken);

        //    cpuUsageStart = 0.0F;
        //    cpuUsageEnd = 0.0F;
        //    memoryUsageStart = 0L;
        //    memoryUsageEnd = 0L;

        //    while (watch.Elapsed < endTime)
        //    {
        //        // Sleeping here so that resource monitor has time to take readings
        //        await Task.Delay(monitorInterval);
        //        cpuUsageEnd = resourceMonitor.CpuUsage;
        //        memoryUsageEnd = resourceMonitor.MemoryUsage;

        //        // Add to respective lists
        //        higherMonitorCpuUsages.Add(cpuUsageEnd);
        //        higherMonitorMemoryUsages.Add(memoryUsageEnd);

        //        cpuUsageStart = cpuUsageEnd;
        //        memoryUsageStart = memoryUsageEnd;
        //    }
        //    cancellationTokenSource.Cancel();
        //    watch.Stop();

        //    // Assert
        //    Assert.Less(lowerMonitorCpuUsages.Average(), higherMonitorCpuUsages.Average(), "Lower frequencies caused higher CPU usage");
        //    Assert.Less(lowerMonitorMemoryUsages.Average(), higherMonitorMemoryUsages.Average(), "Lower frequencies caused higher memory usage");
        //}

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
