// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests.DelayStrategies
{
    internal class OperationPollerTests
    {
        [Test]
        public void ShouldDefaultToConstantFallback()
        {
            OperationPoller poller = new OperationPoller();
            var delayStrategy = poller.GetType().GetField("_delayStrategy", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(poller);

            Assert.IsNotNull(delayStrategy);
            Assert.AreEqual(typeof(FixedDelayStrategy), delayStrategy.GetType());
        }

        [Test]
        public void CanOverrideFallbackStrategy()
        {
            SequentialDelayStrategy sequentialDelayStrategy = new SequentialDelayStrategy();
            OperationPoller poller = new OperationPoller(sequentialDelayStrategy);
            var delayStrategy = poller.GetType().GetField("_delayStrategy", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(poller);

            Assert.IsNotNull(delayStrategy);
            Assert.AreEqual(typeof(SequentialDelayStrategy), delayStrategy.GetType());
        }

        [Test]
        public void WaitForCompletionResponseAsyncCancelled()
        {
            var cts = new CancellationTokenSource();
            var poller = new OperationPoller(new TestDelayStrategy(TimeSpan.FromSeconds(10), TimeSpan.FromSeconds(1), cts));
            var operation = new OperationInternal(new ClientDiagnostics(ClientOptions.Default), new EndlessOperation(), new MockResponse(200));
            Assert.CatchAsync<OperationCanceledException>(async () => await poller.WaitForCompletionResponseAsync(operation, null, cts.Token));
        }

        [Test]
        public void WaitForCompletionResponseCancelled()
        {
            var cts = new CancellationTokenSource();
            var poller = new OperationPoller(new TestDelayStrategy(TimeSpan.FromSeconds(10), TimeSpan.FromSeconds(1), cts));
            var operation = new OperationInternal(new ClientDiagnostics(ClientOptions.Default), new EndlessOperation(), new MockResponse(200));
            Assert.Catch<OperationCanceledException>(() => poller.WaitForCompletionResponse(operation, null, cts.Token));
        }

        private class EndlessOperation : IOperation
        {
            public ValueTask<OperationState> UpdateStateAsync(bool async, CancellationToken cancellationToken) => new(OperationState.Pending(new MockResponse(200)));
        }

        private class TestDelayStrategy : DelayStrategy
        {
            private readonly TimeSpan _delay;
            private readonly TimeSpan _cancelAfter;
            private readonly CancellationTokenSource _cts;

            public TestDelayStrategy(TimeSpan delay, TimeSpan cancelAfter, CancellationTokenSource cts)
            {
                _delay = delay;
                _cancelAfter = cancelAfter;
                _cts = cts;
            }

            public override TimeSpan GetNextDelay(Response response, int retryNumber, TimeSpan? clientDelayHint, TimeSpan? serverDelayHint)
            {
                _cts.CancelAfter(_cancelAfter);
                return _delay;
            }
        }
    }
}
