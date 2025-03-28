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
    internal class ThroughputMonitorTests
    {
        [Test]
        public void ThroughputMonitor_ConstructorShouldConstructWithoutError()
        {
            ThroughputMonitor tm = new ThroughputMonitor();
            Assert.DoesNotThrow(() => new ThroughputMonitor());
        }

        [Test]
        public async Task ThroughputMonitor_ShouldAllowAsync()
        {
            // Arrange
            ThroughputMonitor tm = new ThroughputMonitor();
            CancellationToken cancellationToken = new CancellationToken();

            // Act
            for (int i = 0; i < 10; i++)
            {
                await tm.EnqueueBytesTransferredAsync(i, cancellationToken);
            }
            // Wait for things to propegate into channel
            await Task.Delay(1);

            // Assert
            Assert.AreEqual(45, tm.TotalBytesTransferred);
        }
    }
}
