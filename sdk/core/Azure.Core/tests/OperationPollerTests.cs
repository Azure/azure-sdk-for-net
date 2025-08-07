// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.Shared;
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
            Assert.AreEqual(typeof(FixedDelayWithNoJitterStrategy), delayStrategy.GetType());
        }

        [Test]
        public void CanOverrideFallbackStrategy()
        {
            SequentialDelayStrategy sequentialDelay = new SequentialDelayStrategy();
            OperationPoller poller = new OperationPoller(sequentialDelay);
            var delayStrategy = poller.GetType().GetField("_delayStrategy", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(poller);

            Assert.IsNotNull(delayStrategy);
            Assert.AreEqual(typeof(SequentialDelayStrategy), delayStrategy.GetType());
        }

        [Test]
        public void WaitForCompletionResponseAsyncCancelled()
        {
            var cts = new CancellationTokenSource();
            var poller = new OperationPoller(new TestDelayStrategy(TimeSpan.FromSeconds(10), TimeSpan.FromSeconds(1), cts));
            var operation = new OperationInternal(new EndlessOperation(),new ClientDiagnostics(ClientOptions.Default), new MockResponse(200));
            Assert.CatchAsync<OperationCanceledException>(async () => await poller.WaitForCompletionResponseAsync(operation, null, cts.Token));
        }

        [Test]
        public void WaitForCompletionResponseCancelled()
        {
            var cts = new CancellationTokenSource();
            var poller = new OperationPoller(new TestDelayStrategy(TimeSpan.FromSeconds(10), TimeSpan.FromSeconds(1), cts));
            var operation = new OperationInternal(new EndlessOperation(), new ClientDiagnostics(ClientOptions.Default), new MockResponse(200));
            Assert.Catch<OperationCanceledException>(() => poller.WaitForCompletionResponse(operation, null, cts.Token));
        }

        private class EndlessOperation : IOperation
        {
            public ValueTask<OperationState> UpdateStateAsync(bool async, CancellationToken cancellationToken) => new(OperationState.Pending(new MockResponse(200)));

            public RehydrationToken GetRehydrationToken() =>
                throw new NotImplementedException();
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

            protected override TimeSpan GetNextDelayCore(Response response, int retryNumber)
            {
                _cts.CancelAfter(_cancelAfter);
                return _delay;
            }
        }
    }
}
