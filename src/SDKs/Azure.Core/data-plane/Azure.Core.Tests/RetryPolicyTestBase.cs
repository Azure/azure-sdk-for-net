﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.Diagnostics;
using Azure.Core.Pipeline;
using Azure.Core.Testing;
using Azure.Core.Tests.Testing;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public abstract class RetryPolicyTestBase: PolicyTestBase
    {
        [Test]
        public async Task DoesNotExceedRetryCount()
        {
            var responseClassifier = new MockResponseClassifier(retriableCodes: new [] { 500 });
            var (policy, gate) = CreateRetryPolicy(maxRetries: 3);
            var mockTransport = new MockTransport();
            var task = SendRequest(mockTransport, policy, responseClassifier);

            await mockTransport.RequestGate.Cycle(new MockResponse(500));

            for (int i = 0; i < 3; i++)
            {
                await gate.Cycle();
                await mockTransport.RequestGate.Cycle(new MockResponse(500));
            }

            var response = await task.TimeoutAfterDefault();
            Assert.AreEqual(500, response.Status);
        }

        [Test]
        public async Task OnlyRetriesRetriebleCodes()
        {
            var responseClassifier = new MockResponseClassifier(retriableCodes: new [] { 500 });
            var (policy, gate) = CreateRetryPolicy(maxRetries: 3);
            var mockTransport = new MockTransport();
            var task = SendRequest(mockTransport, policy, responseClassifier);

            await mockTransport.RequestGate.Cycle(new MockResponse(500));

            await gate.Cycle();

            await mockTransport.RequestGate.Cycle(new MockResponse(501));

            var response = await task.TimeoutAfterDefault();
            Assert.AreEqual(501, response.Status);
        }

        [Test]
        public async Task RetriesOnException()
        {
            var responseClassifier = new MockResponseClassifier(retriableCodes: new [] { 500 }, exceptionFilter: ex => ex is InvalidOperationException);
            var (policy, gate) = CreateRetryPolicy();
            var mockTransport = new MockTransport();
            var task = SendRequest(mockTransport, policy, responseClassifier);

            await mockTransport.RequestGate.CycleWithException(new InvalidOperationException());

            await gate.Cycle();

            await mockTransport.RequestGate.Cycle(new MockResponse(200));

            var response = await task.TimeoutAfterDefault();
            Assert.AreEqual(200, response.Status);
        }

        [Test]
        public async Task RetriesOnlyFilteredException()
        {
            var responseClassifier = new MockResponseClassifier(retriableCodes: new [] { 500 }, exceptionFilter: ex => ex is InvalidOperationException);
            var (policy, gate) = CreateRetryPolicy();
            var mockTransport = new MockTransport();
            var task = SendRequest(mockTransport, policy, responseClassifier);

            await mockTransport.RequestGate.CycleWithException(new InvalidOperationException());

            await gate.Cycle();

            await mockTransport.RequestGate.CycleWithException(new IOException());

            var exception = Assert.ThrowsAsync<AggregateException>(async () => await task.TimeoutAfterDefault());
            StringAssert.StartsWith("Retry failed after 2 tries.", exception.Message);
            Assert.IsInstanceOf<InvalidOperationException>(exception.InnerExceptions[0]);
            Assert.IsInstanceOf<IOException>(exception.InnerExceptions[1]);
        }

        [Test]
        public async Task RetriesOnlyFilteredExceptionFirst()
        {
            var responseClassifier = new MockResponseClassifier(retriableCodes: new [] { 500 }, exceptionFilter: ex => ex is InvalidOperationException);
            var (policy, _) = CreateRetryPolicy();
            var mockTransport = new MockTransport();
            var task = SendRequest(mockTransport, policy, responseClassifier);

            await mockTransport.RequestGate.CycleWithException(new IOException());

            Assert.ThrowsAsync<IOException>(async () => await task.TimeoutAfterDefault());
        }

        [Test]
        public async Task RethrowsAggregateExceptionAfterMaxRetryCount()
        {
            var responseClassifier = new MockResponseClassifier(retriableCodes: new [] { 500 }, exceptionFilter: ex => ex is InvalidOperationException);
            var (policy, gate) = CreateRetryPolicy(maxRetries: 3);
            var mockTransport = new MockTransport();
            var task = SendRequest(mockTransport, policy, responseClassifier);
            var exceptions = new List<Exception>();

            exceptions.Add(new InvalidOperationException());
            await mockTransport.RequestGate.CycleWithException(exceptions.Last());

            for (int i = 0; i < 3; i++)
            {
                await gate.Cycle();

                exceptions.Add(new InvalidOperationException());
                await mockTransport.RequestGate.CycleWithException(exceptions.Last());
            }

            var exception = Assert.ThrowsAsync<AggregateException>(async () => await task.TimeoutAfterDefault());
            StringAssert.StartsWith("Retry failed after 4 tries.", exception.Message);
            CollectionAssert.AreEqual(exceptions, exception.InnerExceptions);
        }

        [Test]
        [NonParallelizable]
        public async Task RetryingEmitsEventSourceEvent()
        {
            var responseClassifier = new MockResponseClassifier(retriableCodes: new [] { 500 });
            var listener = new TestEventListener();
            listener.EnableEvents(HttpPipelineEventSource.Singleton, EventLevel.Informational);

            var (policy, gate) = CreateRetryPolicy(maxRetries: 2);
            var mockTransport = new MockTransport();
            var task = SendRequest(mockTransport, policy, responseClassifier);

            var request = await mockTransport.RequestGate.Cycle(new MockResponse(500));

            for (int i = 0; i < 2; i++)
            {
                await gate.Cycle();
                await mockTransport.RequestGate.Cycle(new MockResponse(500));
            }

            await task.TimeoutAfterDefault();

            AssertRetryEvent(listener, request, 1);
            AssertRetryEvent(listener, request, 2);
        }

        private static void AssertRetryEvent(TestEventListener listener, MockRequest request, int retryNumber)
        {
            var e = listener.SingleEventById(10, args => args.GetProperty<int>("retryNumber") == retryNumber);

            Assert.AreEqual(EventLevel.Informational, e.Level);
            Assert.AreEqual("RequestRetrying", e.EventName);
            Assert.AreEqual(request.RequestId, e.GetProperty<string>("requestId"));
        }

        protected static Task<Response> SendRequest(MockTransport mockTransport, HttpPipelinePolicy policy, ResponseClassifier responseClassifier)
        {
            return SendGetRequest(mockTransport, policy, responseClassifier);
        }

        protected abstract (HttpPipelinePolicy, AsyncGate<TimeSpan, object>) CreateRetryPolicy(int maxRetries = 3);

        protected class MockResponseClassifier: ResponseClassifier
        {
            private readonly int[] _retriableCodes;

            private readonly Func<Exception, bool> _exceptionFilter;

            public MockResponseClassifier(int[] retriableCodes, Func<Exception, bool> exceptionFilter = null)
            {
                _retriableCodes = retriableCodes;
                _exceptionFilter = exceptionFilter;
            }

            public override bool IsRetriableResponse(HttpPipelineResponse response)
            {
                return Array.IndexOf(_retriableCodes, response.Status) >= 0;
            }

            public override bool IsRetriableException(Exception exception)
            {
                return _exceptionFilter != null && _exceptionFilter(exception);
            }
        }
    }
}
