// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// filepath: c:\Users\t-davidbrown\source\repos\Azure\azure-sdk-for-net\sdk\storage\Azure.Storage.DataMovement\tests\ThroughputMonitorTests.cs
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.DataMovement.Tests
{
    [TestFixture]
    public class ThroughputMonitorTests
    {
        private const double Tolerance = 0.01; // Tolerance for double comparisons

        [Test]
        public void Constructor_InitializesPropertiesCorrectly()
        {
            // Arrange & Act
            using var monitor = new ThroughputMonitor();

            // Assert
            Assert.AreEqual(0, monitor.TotalBytesTransferred, "TotalBytesTransferred should be 0 initially.");
            Assert.AreEqual(0.0, monitor.Throughput, "Throughput should be 0.0 initially.");
            Assert.AreEqual(0.0, monitor.ThroughputInMb, "ThroughputInMb should be 0.0 initially.");
            Assert.AreEqual(0.0, monitor.AvgThroughput, "AvgThroughput should be 0.0 initially.");
            Assert.AreEqual(0.0, monitor.AvgThroughputInMb, "AvgThroughputInMb should be 0.0 initially.");
        }

        [Test]
        public async Task QueueBytesTransferredAsync_FirstTransfer_UpdatesTotalAndSetsInitialThroughput()
        {
            // Arrange
            using var monitor = new ThroughputMonitor();
            long bytesTransferred = 100;

            // Act
            await monitor.QueueBytesTransferredAsync(bytesTransferred);
            await Task.Delay(50); // Allow time for the internal processor to handle the item.

            // Assert
            Assert.AreEqual(bytesTransferred, monitor.TotalBytesTransferred, "TotalBytesTransferred not updated correctly.");
            // As per current logic, Throughput is 0.0 after the first transfer because first transfer is tick 0.
            Assert.AreEqual(0.0, monitor.Throughput, "Throughput should be 0.0 after the first transfer");
            Assert.IsTrue(monitor.AvgThroughput >= 0, "AvgThroughput should be non-negative.");
        }

        [Test]
        public async Task QueueBytesTransferredAsync_MultipleTransfers_CalculatesThroughputAndAvgThroughput()
        {
            // Arrange
            using var monitor = new ThroughputMonitor();
            long bytes1 = 1024; // 1KB
            long bytes2 = 2048; // 2KB
            int delayMilliseconds = 200; // 0.2 seconds

            // Act - First transfer
            await monitor.QueueBytesTransferredAsync(bytes1);
            await Task.Delay(50);
            var initialTotalBytes = monitor.TotalBytesTransferred;
            var initialThroughput = monitor.Throughput;

            // Act - Second transfer
            await Task.Delay(delayMilliseconds);
            await monitor.QueueBytesTransferredAsync(bytes2);
            await Task.Delay(50);

            // Assert
            Assert.AreEqual(bytes1, initialTotalBytes, "Initial total bytes incorrect.");
            Assert.AreEqual(0.0, initialThroughput, "Initial throughput incorrect.");

            Assert.AreEqual(bytes1 + bytes2, monitor.TotalBytesTransferred, "TotalBytesTransferred not updated correctly after multiple transfers.");

            double expectedThroughputBytes2Approx = (double)bytes2 / (delayMilliseconds / 1000.0);
            Assert.IsTrue(monitor.Throughput > 0, "Throughput should be positive after second transfer.");
            Assert.GreaterOrEqual(monitor.Throughput, expectedThroughputBytes2Approx * 0.7, "Throughput seems too low.");
            Assert.LessOrEqual(monitor.Throughput, expectedThroughputBytes2Approx * 1.3, "Throughput seems too high.");

            Assert.IsTrue(monitor.AvgThroughput > 0, "Average throughput should be positive.");
            double maxPossibleAvgThroughput = (double)(bytes1 + bytes2) / (delayMilliseconds / 1000.0);
            Assert.LessOrEqual(monitor.AvgThroughput, maxPossibleAvgThroughput * 1.3, "Average throughput seems too high for the delay.");
        }

        [Test]
        public async Task QueueBytesTransferredAsync_ZeroBytesTransfer_UpdatesTotalAndThroughput()
        {
            // Arrange
            using var monitor = new ThroughputMonitor();
            long initialBytes = 100;

            // Act - First transfer (non-zero)
            await monitor.QueueBytesTransferredAsync(initialBytes);
            await Task.Delay(50);

            // Act - Second transfer (zero bytes)
            await Task.Delay(100);
            await monitor.QueueBytesTransferredAsync(0);
            await Task.Delay(50);

            // Assert
            Assert.AreEqual(initialBytes, monitor.TotalBytesTransferred, "TotalBytesTransferred should not change for zero byte transfer.");
            Assert.AreEqual(0.0, monitor.Throughput, Tolerance, "Throughput for 0 bytes transfer should be 0.0.");
            Assert.IsTrue(monitor.AvgThroughput > 0, "AvgThroughput should still be based on the first transfer.");
        }

        [Test]
        public void AvgThroughput_NoTransfers_IsZero()
        {
            // Arrange
            using var monitor = new ThroughputMonitor();

            // Act & Assert
            Assert.AreEqual(0.0, monitor.AvgThroughput, Tolerance, "AvgThroughput should be 0.0 when no transfers.");
            Assert.AreEqual(0.0, monitor.AvgThroughputInMb, Tolerance, "AvgThroughputInMb should be 0.0 when no transfers.");
        }

        [Test]
        public async Task AvgThroughput_ZeroTotalBytesAfterZeroByteTransfer_IsZero()
        {
            // Arrange
            using var monitor = new ThroughputMonitor();

            // Act
            await monitor.QueueBytesTransferredAsync(0);
            await Task.Delay(50);
            await Task.Delay(100);

            // Assert
            Assert.AreEqual(0, monitor.TotalBytesTransferred, "TotalBytesTransferred should be 0.");
            Assert.AreEqual(0.0, monitor.AvgThroughput, Tolerance, "AvgThroughput should be 0.0 if total bytes is 0.");
        }

        [Test]
        public async Task ThroughputAndAvgThroughput_InMb_Calculation()
        {
            // Arrange
            using var monitor = new ThroughputMonitor();
            long bytes1 = 1024 * 1024; // 1 MiB
            long bytes2 = 1024 * 1024; // 1 MiB
            int delaySeconds = 1;

            // Act - First transfer
            await monitor.QueueBytesTransferredAsync(bytes1);
            await Task.Delay(50);

            // Act - Second transfer
            await Task.Delay(delaySeconds * 1000);
            await monitor.QueueBytesTransferredAsync(bytes2);
            await Task.Delay(50);

            // Assert
            double currentThroughput = monitor.Throughput; // Snapshot for consistent calculation
            double expectedThroughputInMb = ((currentThroughput * 8) / 1024.0) / 1024.0; // Use .0 for double division
            Assert.AreEqual(expectedThroughputInMb, monitor.ThroughputInMb, Tolerance, "ThroughputInMb calculation is off.");

            double currentAvgThroughput = monitor.AvgThroughput; // Snapshot for consistent calculation
            Assert.IsTrue(currentAvgThroughput > 0, "AvgThroughput should be positive.");
            double expectedAvgThroughputInMb = ((currentAvgThroughput * 8) / 1024.0) / 1024.0; // Use .0 for double division
            double relativeToleranceForAvg = Math.Max(Tolerance, Math.Abs(expectedAvgThroughputInMb * 1e-7)); // Relative tolerance, ensure min absolute
            Assert.AreEqual(expectedAvgThroughputInMb, monitor.AvgThroughputInMb, relativeToleranceForAvg, "AvgThroughputInMb does not match calculation from AvgThroughput.");
        }

        [Test]
        public void Dispose_CanBeCalledWithoutError()
        {
            // Arrange
            var monitor = new ThroughputMonitor();

            // Act & Assert
            Assert.DoesNotThrow(() => monitor.Dispose(), "Dispose should not throw an exception.");
        }

        [Test]
        public async Task ProcessBytesTransferred_Subsequent_ZeroInterval_ZeroBytes_ResultsInZeroThroughput()
        {
            using var monitor = new ThroughputMonitor();
            await monitor.QueueBytesTransferredAsync(100);
            await Task.Delay(10);

            await monitor.QueueBytesTransferredAsync(0);
            await Task.Delay(50);

            // If interval was zero, logic is: if (bytesTransferred > 0) MaxValue else 0.0. So 0.0.
            // If interval was positive, 0 bytes / interval = 0.0.
            Assert.AreEqual(0.0, monitor.Throughput, Tolerance, "Throughput for zero bytes should be 0.0.");
        }
    }
}
