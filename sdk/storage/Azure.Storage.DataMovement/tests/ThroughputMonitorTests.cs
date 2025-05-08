// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Tests
{
    [TestFixture]
    internal class ThroughputMonitorTests
    {
        private const int ProcessingDelayMilliseconds = 100; // Allow time for channel processing

        [Test]
        public void Constructor_InitializesProperties()
        {
            // Arrange & Act
            var monitor = new ThroughputMonitor();

            // Assert
            Assert.AreEqual(0, monitor.TotalBytesTransferred);
            Assert.AreEqual(0.0d, monitor.Throughput);
            Assert.AreEqual(0.0d, monitor.AvgThroughput);
            Assert.AreEqual(0.0d, monitor.ThroughputInMb);
            Assert.AreEqual(0.0d, monitor.AvgThroughputInMb);

            // Check internal fields via reflection for initial state
            var transferCountField = typeof(ThroughputMonitor).GetField("_transferCount", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.AreEqual(0L, transferCountField?.GetValue(monitor));

            var startTimeField = typeof(ThroughputMonitor).GetField("_startTime", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.AreEqual(default(DateTimeOffset), startTimeField?.GetValue(monitor));

            var previousTransferTimeField = typeof(ThroughputMonitor).GetField("_previousTransferTime", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.AreEqual(default(DateTimeOffset), previousTransferTimeField?.GetValue(monitor));
        }

        [Test]
        public async Task QueueBytesTransferredAsync_UpdatesTotalBytesTransferred()
        {
            // Arrange
            var monitor = new ThroughputMonitor();

            // Act
            await monitor.QueueBytesTransferredAsync(100);
            await monitor.QueueBytesTransferredAsync(200);
            await Task.Delay(ProcessingDelayMilliseconds); // Allow channel to process

            // Assert
            Assert.AreEqual(300, monitor.TotalBytesTransferred);
        }

        [Test]
        public async Task ProcessBytesTransferredAsync_FirstTransfer_SetsInitialValues()
        {
            // Arrange
            var monitor = new ThroughputMonitor();

            // Act
            await monitor.QueueBytesTransferredAsync(100);
            await Task.Delay(ProcessingDelayMilliseconds);

            // Assert
            Assert.AreEqual(100, monitor.TotalBytesTransferred);
            Assert.AreEqual(0.0d, monitor.Throughput, "Throughput should be 0 for the first transfer.");

            var transferCountField = typeof(ThroughputMonitor).GetField("_transferCount", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.AreEqual(1L, transferCountField?.GetValue(monitor));

            var startTimeField = typeof(ThroughputMonitor).GetField("_startTime", BindingFlags.NonPublic | BindingFlags.Instance);
            var previousTransferTimeField = typeof(ThroughputMonitor).GetField("_previousTransferTime", BindingFlags.NonPublic | BindingFlags.Instance);
            var startTime = (DateTimeOffset)(startTimeField?.GetValue(monitor) ?? default(DateTimeOffset));
            var previousTime = (DateTimeOffset)(previousTransferTimeField?.GetValue(monitor) ?? default(DateTimeOffset));

            Assert.AreNotEqual(default(DateTimeOffset), startTime);
            Assert.AreEqual(startTime, previousTime);
        }

        [Test]
        public async Task ProcessBytesTransferredAsync_SubsequentTransfer_CalculatesThroughput()
        {
            // Arrange
            var monitor = new ThroughputMonitor();
            await monitor.QueueBytesTransferredAsync(100); // First transfer
            await Task.Delay(ProcessingDelayMilliseconds);

            // Act
            await Task.Delay(100); // Introduce a delay between transfers for time difference
            await monitor.QueueBytesTransferredAsync(200); // Second transfer
            await Task.Delay(ProcessingDelayMilliseconds);

            // Assert
            Assert.AreEqual(300, monitor.TotalBytesTransferred);
            Assert.Greater(monitor.Throughput, 0.0d, "Throughput should be positive after a subsequent transfer with delay.");

            var transferCountField = typeof(ThroughputMonitor).GetField("_transferCount", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.AreEqual(2L, transferCountField?.GetValue(monitor));
        }

        //[Test]
        //public async Task ProcessBytesTransferredAsync_SubsequentTransfer_ZeroInterval_PositiveBytes_MaxThroughput()
        //{
        //    // Arrange
        //    var monitor = new ThroughputMonitor();
        //    var previousTransferTimeField = typeof(ThroughputMonitor).GetField("_previousTransferTime", BindingFlags.NonPublic | BindingFlags.Instance);
        //    var startTimeField = typeof(ThroughputMonitor).GetField("_startTime", BindingFlags.NonPublic | BindingFlags.Instance);
        //    var transferCountField = typeof(ThroughputMonitor).GetField("_transferCount", BindingFlags.NonPublic | BindingFlags.Instance);

        //    // Simulate first transfer processed
        //    DateTimeOffset simulatedTime = DateTimeOffset.UtcNow;
        //    startTimeField?.SetValue(monitor, simulatedTime);
        //    previousTransferTimeField?.SetValue(monitor, simulatedTime);
        //    transferCountField?.SetValue(monitor, 1L);
        //    // Manually update total bytes as if ProcessBytesTransferredAsync was called for the first item
        //    var totalBytesField = typeof(ThroughputMonitor).GetField("_totalBytesTransferred", BindingFlags.NonPublic | BindingFlags.Instance);
        //    totalBytesField?.SetValue(monitor, 50L);

        //    // Act: Queue a second transfer that will be processed as if no time has passed
        //    await monitor.QueueBytesTransferredAsync(100);
        //    await Task.Delay(ProcessingDelayMilliseconds); // Allow channel to process

        //    // Assert
        //    Assert.AreEqual(150, monitor.TotalBytesTransferred); // 50 (simulated) + 100 (actual)
        //    Assert.AreEqual(double.MaxValue, monitor.Throughput, "Throughput should be double.MaxValue for zero interval and positive bytes.");
        //}

        [Test]
        public async Task ProcessBytesTransferredAsync_SubsequentTransfer_ZeroInterval_ZeroBytes_ZeroThroughput()
        {
            // Arrange
            var monitor = new ThroughputMonitor();
            var previousTransferTimeField = typeof(ThroughputMonitor).GetField("_previousTransferTime", BindingFlags.NonPublic | BindingFlags.Instance);
            var startTimeField = typeof(ThroughputMonitor).GetField("_startTime", BindingFlags.NonPublic | BindingFlags.Instance);
            var transferCountField = typeof(ThroughputMonitor).GetField("_transferCount", BindingFlags.NonPublic | BindingFlags.Instance);

            // Simulate first transfer processed
            DateTimeOffset simulatedTime = DateTimeOffset.UtcNow;
            startTimeField?.SetValue(monitor, simulatedTime);
            previousTransferTimeField?.SetValue(monitor, simulatedTime);
            transferCountField?.SetValue(monitor, 1L);
            var totalBytesField = typeof(ThroughputMonitor).GetField("_totalBytesTransferred", BindingFlags.NonPublic | BindingFlags.Instance);
            totalBytesField?.SetValue(monitor, 50L);

            // Act: Queue a second transfer with zero bytes
            await monitor.QueueBytesTransferredAsync(0);
            await Task.Delay(ProcessingDelayMilliseconds);

            // Assert
            Assert.AreEqual(50, monitor.TotalBytesTransferred);
            Assert.AreEqual(0.0d, monitor.Throughput, "Throughput should be 0.0 for zero interval and zero bytes.");
        }

        [Test]
        public void AvgThroughput_NoTransfers_ReturnsZero()
        {
            // Arrange
            var monitor = new ThroughputMonitor();

            // Act & Assert
            Assert.AreEqual(0.0d, monitor.AvgThroughput);
        }

        [Test]
        public async Task AvgThroughput_SingleTransfer_CalculatesCorrectly()
        {
            // Arrange
            var monitor = new ThroughputMonitor();

            // Act
            await monitor.QueueBytesTransferredAsync(1000);
            await Task.Delay(ProcessingDelayMilliseconds); // Ensure processing
            await Task.Delay(100); // Ensure some time passes for AvgThroughput calculation

            // Assert
            Assert.Greater(monitor.AvgThroughput, 0.0d);
            Assert.Less(monitor.AvgThroughput, double.MaxValue); // Should not be infinite if time has passed
        }

        [Test]
        public async Task AvgThroughput_MultipleTransfers_CalculatesCorrectly()
        {
            // Arrange
            var monitor = new ThroughputMonitor();
            // Using a relative tolerance to account for timing variations in tests.
            const double relativeTolerance = 0.20; // 20%

            // Act
            await monitor.QueueBytesTransferredAsync(1000);
            await Task.Delay(ProcessingDelayMilliseconds + 50); // Ensure processing & time passes

            double firstAvg = monitor.AvgThroughput;
            // firstAvg should be positive here due to bytes transferred and elapsed time.
            Assert.Greater(firstAvg, 0.0d, "First average throughput should be positive.");

            await monitor.QueueBytesTransferredAsync(1000);
            await Task.Delay(ProcessingDelayMilliseconds + 50); // Ensure processing & more time passes

            // Assert
            Assert.AreEqual(2000, monitor.TotalBytesTransferred);
            Assert.Greater(monitor.AvgThroughput, 0.0d, "Final average throughput should be positive.");

            // Assert that the new average throughput is close to the first one,
            // using a relative tolerance. This suggests that the average rate
            // remains somewhat consistent under these test conditions.
            double delta = Math.Abs(firstAvg * relativeTolerance);
            Assert.AreEqual(firstAvg, monitor.AvgThroughput, delta,
                $"Final AvgThroughput ({monitor.AvgThroughput:F2}) should be within {relativeTolerance * 100}% of firstAvg ({firstAvg:F2}).");
        }

        //[Test]
        //public void AvgThroughput_ZeroElapsedTime_PositiveBytes_ReturnsMaxValue()
        //{
        //    // Arrange
        //    var monitor = new ThroughputMonitor();
        //    var startTimeField = typeof(ThroughputMonitor).GetField("_startTime", BindingFlags.NonPublic | BindingFlags.Instance);
        //    var transferCountField = typeof(ThroughputMonitor).GetField("_transferCount", BindingFlags.NonPublic | BindingFlags.Instance);
        //    var totalBytesField = typeof(ThroughputMonitor).GetField("_totalBytesTransferred", BindingFlags.NonPublic | BindingFlags.Instance);

        //    monitor.QueueBytesTransferredAsync(100).AsTask().Wait();
        //    Task.Delay(ProcessingDelayMilliseconds).Wait();

        //    var now = DateTimeOffset.UtcNow;
        //    startTimeField.SetValue(monitor, now);

        //    Assert.IsTrue((long)(totalBytesField?.GetValue(monitor) ?? 0L) > 0);
        //    Assert.IsTrue((long)(transferCountField?.GetValue(monitor) ?? 0L) > 0);

        //    double avg = monitor.AvgThroughput;
        //    Assert.IsTrue(avg == double.MaxValue || avg > 1000000000.0, // Arbitrary large number if not exactly MaxValue
        //        "AvgThroughput should be MaxValue or very large if elapsed time is near zero with positive bytes.");
        //}

        [Test]
        public async Task AvgThroughput_ZeroElapsedTime_ZeroBytes_ReturnsZero()
        {
            // Arrange
            var monitor = new ThroughputMonitor();
            // Ensure _transferCount is 0, which is the default state.
            // This path `if (_transferCount == 0)` in AvgThroughput returns 0.

            // Assert
            Assert.AreEqual(0.0d, monitor.AvgThroughput);

            // Test the other path: _transferCount > 0, _totalBytesTransferred == 0, elapsedTime.Ticks == 0
            var startTimeField = typeof(ThroughputMonitor).GetField("_startTime", BindingFlags.NonPublic | BindingFlags.Instance);
            var transferCountField = typeof(ThroughputMonitor).GetField("_transferCount", BindingFlags.NonPublic | BindingFlags.Instance);
            var totalBytesField = typeof(ThroughputMonitor).GetField("_totalBytesTransferred", BindingFlags.NonPublic | BindingFlags.Instance);

            await monitor.QueueBytesTransferredAsync(0); // First transfer, but zero bytes
            await Task.Delay(ProcessingDelayMilliseconds);

            Assert.AreEqual(0L, (long)(totalBytesField?.GetValue(monitor) ?? -1L));
            Assert.AreEqual(1L, (long)(transferCountField?.GetValue(monitor) ?? 0L));

            // Force start time to now to try and get Ticks == 0
            var now = DateTimeOffset.UtcNow;
            startTimeField?.SetValue(monitor, now);

            double avg = monitor.AvgThroughput;
            Assert.AreEqual(0.0d, avg, "AvgThroughput should be 0.0 if total bytes is 0, even if time is near zero.");
        }

        [Test]
        public async Task ThroughputInMb_And_AvgThroughputInMb_CalculatedCorrectly()
        {
            // Arrange
            var monitor = new ThroughputMonitor();
            var bytes = 1024 * 1024 * 2; // 2 MB

            // Act
            await monitor.QueueBytesTransferredAsync(bytes); // First transfer
            await Task.Delay(ProcessingDelayMilliseconds);
            await Task.Delay(1000); // Wait 1 second

            await monitor.QueueBytesTransferredAsync(bytes); // Second transfer
            await Task.Delay(ProcessingDelayMilliseconds);

            // Assert
            // Throughput is for the last event (bytes / interval_seconds)
            // AvgThroughput is for all events (total_bytes / total_elapsed_seconds)

            const double tolerance = 0.05; // Tolerance of 0.05 Mbps

            double expectedThroughputMb = (monitor.Throughput * 8) / (1024 * 1024);
            Assert.AreEqual(expectedThroughputMb, monitor.ThroughputInMb, tolerance);

            double expectedAvgThroughputMb = (monitor.AvgThroughput * 8) / (1024 * 1024);
            Assert.AreEqual(expectedAvgThroughputMb, monitor.AvgThroughputInMb, tolerance);

            Assert.Greater(monitor.ThroughputInMb, 0.0d);
            Assert.Greater(monitor.AvgThroughputInMb, 0.0d);
        }

        [Test]
        public void Dispose_CanBeCalledWithoutError()
        {
            // Arrange
            var monitor = new ThroughputMonitor();

            // Act & Assert
            Assert.DoesNotThrow(() => monitor.Dispose());
            Assert.DoesNotThrow(() => monitor.Dispose()); // Call again
        }

        [Test]
        public async Task QueueBytesTransferredAsync_WithCancellation_DoesNotStopProcessingOfQueuedItems()
        {
            // Arrange
            var monitor = new ThroughputMonitor();
            var cts = new CancellationTokenSource();

            // Act
            await monitor.QueueBytesTransferredAsync(100, CancellationToken.None);
            await monitor.QueueBytesTransferredAsync(200, cts.Token);
            cts.Cancel(); // Cancel token for future calls, but already queued items should process.
            await monitor.QueueBytesTransferredAsync(300, cts.Token); // This might not queue if channel respects token on write.
                                                                    // However, our DefaultProcessor's QueueAsync might not check token before enqueuing.
                                                                    // The key is that ProcessBytesTransferredAsync itself doesn't use the token.

            await Task.Delay(ProcessingDelayMilliseconds * 2); // Allow ample time for processing

            // Assert
            // The behavior of QueueAsync on a cancelled token depends on the IProcessor implementation.
            // Assuming ChannelProcessing.NewProcessor().QueueAsync might throw or ignore if token is cancelled.
            // Let's check if at least the first two items were processed.
            // If the third one (queued with cancelled token) is also processed, it means QueueAsync didn't prevent it.
            // The current ThroughputMonitor passes CancellationToken.None to the processor's QueueAsync,
            // so the token passed to ThroughputMonitor.QueueBytesTransferredAsync is effectively ignored by the processor.
            Assert.AreEqual(100 + 200 + 300, monitor.TotalBytesTransferred,
                "All items should be processed as the CancellationToken is not used by the internal processor queue or processing method.");
            Assert.IsTrue(cts.IsCancellationRequested);
        }

        [Test]
        public async Task ThroughputAndAvgThroughput_WithZeroBytesTransferred_RemainZero()
        {
            // Arrange
            var monitor = new ThroughputMonitor();

            // Act
            await monitor.QueueBytesTransferredAsync(0);
            await Task.Delay(ProcessingDelayMilliseconds);
            await Task.Delay(100); // time passes

            await monitor.QueueBytesTransferredAsync(0);
            await Task.Delay(ProcessingDelayMilliseconds);

            // Assert
            Assert.AreEqual(0, monitor.TotalBytesTransferred);
            Assert.AreEqual(0.0d, monitor.Throughput);
            Assert.AreEqual(0.0d, monitor.AvgThroughput);
            Assert.AreEqual(0.0d, monitor.ThroughputInMb);
            Assert.AreEqual(0.0d, monitor.AvgThroughputInMb);
        }
    }
}
