// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
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
            // Wait for things to propegate into channel
            await Task.Delay(1);

            // Assert
            var stopwatchField = typeof(ThroughputMonitor).GetField("_stopwatch", System.Reflection.BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.Greater(stopwatchField.Elap, 0, "Time elapsed not greater than 0");
            Assert.Greater(tm.Throughput, 0.0m, "Throughput not greater than 0");
        }
    }
}
