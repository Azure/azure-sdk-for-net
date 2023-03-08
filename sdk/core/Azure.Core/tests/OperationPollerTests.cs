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
            Assert.AreEqual(typeof(RetryAfterDelayStrategy), delayStrategy.GetType());

            var fallbackStrategy = delayStrategy.GetType().GetField("_fallbackStrategy", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(delayStrategy);

            Assert.IsNotNull(delayStrategy);
            Assert.AreEqual(typeof(ConstantDelayStrategy), fallbackStrategy.GetType());
        }

        [Test]
        public void CanOverrideFallbackStrategy()
        {
            ExponentialDelayStrategy exponentialDelayStrategy = new ExponentialDelayStrategy();
            OperationPoller poller = new OperationPoller(exponentialDelayStrategy);
            var delayStrategy = poller.GetType().GetField("_delayStrategy", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(poller);

            Assert.IsNotNull(delayStrategy);
            Assert.AreEqual(typeof(RetryAfterDelayStrategy), delayStrategy.GetType());

            var fallbackStrategy = delayStrategy.GetType().GetField("_fallbackStrategy", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(delayStrategy);

            Assert.IsNotNull(delayStrategy);
            Assert.AreEqual(exponentialDelayStrategy, fallbackStrategy);
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

            public string GetOperationId() => "testId";
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

            public override TimeSpan GetNextDelay(Response response, TimeSpan? suggestedInterval)
            {
                _cts.CancelAfter(_cancelAfter);
                return _delay;
            }
        }
    }
}
