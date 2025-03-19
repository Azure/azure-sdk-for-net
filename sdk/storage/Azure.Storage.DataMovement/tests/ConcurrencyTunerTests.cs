// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using System.Reflection;

namespace Azure.Storage.DataMovement.Tests
{
    [TestFixture]
    internal class ConcurrencyTunerTests
    {
        [Test]
        public void Constructor_ShouldNotThrowExceptionWithValidArguments()
        {
            //Act
            ResourceMonitor monitor = new ResourceMonitor();

            // Assert
            Assert.DoesNotThrow(() => new ConcurrencyTuner(
                monitor,
                TimeSpan.FromSeconds(1),
                1000000,
                1,
                Environment.ProcessorCount * 8,
                1));
        }

        [Test]
        public void Constructor_ShouldRun()
        {
            // Arrange
            ResourceMonitor rm = new ResourceMonitor();
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;
            var ct = new ConcurrencyTuner(
                rm,
                TimeSpan.FromSeconds(1),
                1000000,
                1,
                Environment.ProcessorCount * 8,
                1);

            // Act
            ct.Start(token);
            cts.Cancel();
        }
    }
}
