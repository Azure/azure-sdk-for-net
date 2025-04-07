// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
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
                chunkProcessor));
        }

        [Test]
        public async Task ConcurrencyTuner_InitialConcurrencyShouldGoDownFromMax()
        {
            // Arrange
            var throughputMonitor = new MockThroughputMonitor(10_000);
            var chunkProcessor = new MockProcessor();
            var tuner = new ConcurrencyTuner(
                throughputMonitor,
                chunkProcessor
                );

            // Act
            await Task.Delay(1);

            // Assert
            //var chunkProcessorProperty = typeof(ConcurrencyTuner).GetField("_chunkProcessor", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            //var reflectedChunkProcessor = (IProcessor<Func<Task>>)chunkProcessorProperty.GetValue(tuner);

            Assert.Less(chunkProcessor.MaxConcurrentProcessing, DataMovementConstants.ConcurrencyTuner.ConcurrencyUpperLimit);
            Assert.Greater(chunkProcessor.MaxConcurrentProcessing, 0, "Concurrency not greater than 0");
        }

        //[Test]
        //public async Task StoreFinalState_SavesFinalState()
        //{
        //    // Arrange
        //    var throughputMonitor = new MockThroughputMonitor(100);
        //    var chunkProcessor = new MockProcessor();
        //    var tuner = new ConcurrencyTuner(
        //        throughputMonitor,
        //        chunkProcessor,
        //        TimeSpan.FromSeconds(1),
        //        maxMemoryUsage: 1024,
        //        initialConcurrency: 5,
        //        maxConcurrency: 10,
        //        maxCpuUsage: 0.8f);

        //    var recommendation = new ConcurrencyRecommendation
        //    {
        //        Concurrency = 8,
        //        State = ConcurrencyTunerState.ConcurrencyReasonAtOptimum
        //    };

        //    // Act
        //    tuner.StoreFinalState(recommendation);
        //    var finalState = tuner.GetFinalState();

        //    // Assert
        //    Assert.AreEqual(8, finalState.Concurrency);
        //    Assert.AreEqual(ConcurrencyTunerState.ConcurrencyReasonAtOptimum, finalState.State);
        //}
    }
}
