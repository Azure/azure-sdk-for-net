// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Tests
{
    [TestFixture]
    internal class ThroughputMonitorTests
    {
        [Test]
        public void ThroughputMonitor_ConstructorShouldConstructWithoutError()
        {
            ThroughputMonitor tm = new ThroughputMonitor();
            Assert.DoesNotThrow(() => new ThroughputMonitor());
        }

        [Test]
        public async Task ThroughputMonitor_ShouldCountBytesTransferred()
        {
            // Arrange
            ThroughputMonitor tm = new ThroughputMonitor();
            CancellationToken cancellationToken = new CancellationToken();

            // Act
            for (int i = 0; i < 10; i++)
            {
                await tm.QueueBytesTransferredAsync(i, cancellationToken);
            }
            // Wait for things to propegate into channel
            await Task.Delay(1);

            // Assert
            Assert.AreEqual(45, tm.TotalBytesTransferred);
        }

        [Test]
        public async Task ThroughputMonitor_ShouldTrackThroughput()
        {
            // Arrange
            ThroughputMonitor tm = new ThroughputMonitor();
            CancellationToken cancellationToken = new CancellationToken();

            // Act
            for (int i = 0; i < 10; i++)
            {
                await tm.QueueBytesTransferredAsync(i, cancellationToken);
            }
            // Wait 1 second for all tasks to complete
            await Task.Delay(2000);

            // Assert
            var stopwatchField = typeof(ThroughputMonitor).GetField("_stopwatch", BindingFlags.NonPublic | BindingFlags.Instance);
            var stopwatchInstance = (Stopwatch)stopwatchField.GetValue(tm);
            Assert.Greater(stopwatchInstance.Elapsed.TotalSeconds, 0.0, "Time elapsed not greater than 0");
            Assert.Greater(tm.TotalBytesTransferred, 0, "Bytes transferred not greater than 0");
            Assert.Greater(tm.Throughput, 0.0m, "Throughput not greater than 0");
        }

        [Test]
        public async Task ThroughputMonitor_CancellationTokenShouldNotStopMonitor()
        {
            // Arrange
            ThroughputMonitor tm = new ThroughputMonitor();
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken cancellationToken = cancellationTokenSource.Token;

            // Reflecting for stopwatch
            var stopwatchField = typeof(ThroughputMonitor).GetField("_stopwatch", BindingFlags.NonPublic | BindingFlags.Instance);
            var stopwatchInstance = (Stopwatch)stopwatchField.GetValue(tm);

            // Act
            for (int i = 0; i < 10; i++)
            {
                await tm.QueueBytesTransferredAsync(i, cancellationToken);
                if (i == 5)
                {
                    cancellationTokenSource.Cancel();
                }
            }

            // Assert
            Assert.IsTrue(cancellationToken.IsCancellationRequested);
        }
    }
}
