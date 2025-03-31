// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Tests
{
    [TestFixture]
    internal class ConcurrencyTunerTests
    {
        [Test]
        public void ConcurrencyTuner_DoesNotThrowOnConcurrencyTunerCreation()
        {
            // Arrange
            var tm = new Mock<ThroughputMonitor>().Object;
            var chunkProcessor = new Mock<IProcessor<Func<Task>>>().Object;

            // Assert
            Assert.DoesNotThrow(() => new ConcurrencyTuner(
                tm,
                chunkProcessor,
                TimeSpan.FromSeconds(1),
                int.MaxValue,
                1000,
                int.MaxValue,
                1.0F
                ));
        }
    }
}
