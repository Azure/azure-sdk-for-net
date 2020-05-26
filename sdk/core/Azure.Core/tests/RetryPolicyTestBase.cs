// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Diagnostics;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public abstract class RetryPolicyTestBase : SyncAsyncPolicyTestBase
    {
        private readonly RetryMode _mode;

        protected RetryPolicyTestBase(RetryMode mode, bool isAsync) : base(isAsync)
        {
            _mode = mode;
        }

        [Test]
        public async Task DoesNotExceedRetryCount()
        {
            var responseClassifier = new MockResponseClassifier(retriableCodes: new[] { 500 });
            (HttpPipelinePolicy policy, AsyncGate<TimeSpan, object> gate) = CreateRetryPolicy(maxRetries: 3);
            MockTransport mockTransport = CreateMockTransport();
            Task<Response> task = SendGetRequest(mockTransport, policy, responseClassifier);

            await mockTransport.RequestGate.Cycle(new MockResponse(500));

            for (int i = 0; i < 3; i++)
            {
                await gate.Cycle();
                await mockTransport.RequestGate.Cycle(new MockResponse(500));
            }

            Response response = await task.TimeoutAfterDefault();
            Assert.AreEqual(500, response.Status);
        }

        [Test]
        public async Task OnlyRetriesRetriebleCodes()
        {
            var responseClassifier = new MockResponseClassifier(retriableCodes: new[] { 500 });
            (HttpPipelinePolicy policy, AsyncGate<TimeSpan, object> gate) = CreateRetryPolicy(maxRetries: 3);
            MockTransport mockTransport = CreateMockTransport();
            Task<Response> task = SendGetRequest(mockTransport, policy, responseClassifier);

            await mockTransport.RequestGate.Cycle(new MockResponse(500));

            await gate.Cycle();

            await mockTransport.RequestGate.Cycle(new MockResponse(501));

            Response response = await task.TimeoutAfterDefault();
            Assert.AreEqual(501, response.Status);
        }

        [Test]
        public async Task RetriesOnException()
        {
            var responseClassifier = new MockResponseClassifier(retriableCodes: new[] { 500 }, exceptionFilter: ex => ex is InvalidOperationException);
            (HttpPipelinePolicy policy, AsyncGate<TimeSpan, object> gate) = CreateRetryPolicy();
            MockTransport mockTransport = CreateMockTransport();
            Task<Response> task = SendGetRequest(mockTransport, policy, responseClassifier);

            await mockTransport.RequestGate.CycleWithException(new InvalidOperationException());

            await gate.Cycle();

            await mockTransport.RequestGate.Cycle(new MockResponse(200));

            Response response = await task.TimeoutAfterDefault();
            Assert.AreEqual(200, response.Status);
        }

        [Test]
        public async Task RetriesOnlyFilteredException()
        {
            var responseClassifier = new MockResponseClassifier(retriableCodes: new[] { 500 }, exceptionFilter: ex => ex is InvalidOperationException);
            (HttpPipelinePolicy policy, AsyncGate<TimeSpan, object> gate) = CreateRetryPolicy();
            MockTransport mockTransport = CreateMockTransport();
            Task<Response> task = SendGetRequest(mockTransport, policy, responseClassifier);

            await mockTransport.RequestGate.CycleWithException(new InvalidOperationException());

            await gate.Cycle();

            await mockTransport.RequestGate.CycleWithException(new IOException());

            AggregateException exception = Assert.ThrowsAsync<AggregateException>(async () => await task.TimeoutAfterDefault());
            StringAssert.StartsWith("Retry failed after 2 tries.", exception.Message);
            Assert.IsInstanceOf<InvalidOperationException>(exception.InnerExceptions[0]);
            Assert.IsInstanceOf<IOException>(exception.InnerExceptions[1]);
        }

        [Test]
        public async Task RetriesOnlyFilteredExceptionFirst()
        {
            var responseClassifier = new MockResponseClassifier(retriableCodes: new[] { 500 }, exceptionFilter: ex => ex is InvalidOperationException);
            (HttpPipelinePolicy policy, AsyncGate<TimeSpan, object> _) = CreateRetryPolicy();
            MockTransport mockTransport = CreateMockTransport();
            Task<Response> task = SendGetRequest(mockTransport, policy, responseClassifier);

            await mockTransport.RequestGate.CycleWithException(new IOException());

            Assert.ThrowsAsync<IOException>(async () => await task.TimeoutAfterDefault());
        }

        [Test]
        public async Task RethrowsAggregateExceptionAfterMaxRetryCount()
        {
            var responseClassifier = new MockResponseClassifier(retriableCodes: new[] { 500 }, exceptionFilter: ex => ex is InvalidOperationException);
            (HttpPipelinePolicy policy, AsyncGate<TimeSpan, object> gate) = CreateRetryPolicy(maxRetries: 3);
            MockTransport mockTransport = CreateMockTransport();
            Task<Response> task = SendGetRequest(mockTransport, policy, responseClassifier);
            var exceptions = new List<Exception>
            {
                new InvalidOperationException()
            };
            await mockTransport.RequestGate.CycleWithException(exceptions.Last());

            for (int i = 0; i < 3; i++)
            {
                await gate.Cycle();

                exceptions.Add(new InvalidOperationException());
                await mockTransport.RequestGate.CycleWithException(exceptions.Last());
            }

            AggregateException exception = Assert.ThrowsAsync<AggregateException>(async () => await task.TimeoutAfterDefault());
            StringAssert.StartsWith("Retry failed after 4 tries.", exception.Message);
            CollectionAssert.AreEqual(exceptions, exception.InnerExceptions);
        }

        [Test]
        public async Task RespectsRetryAfterHeaderWithInt()
        {
            var responseClassifier = new MockResponseClassifier(retriableCodes: new[] { 500 });
            (HttpPipelinePolicy policy, AsyncGate<TimeSpan, object> gate) = CreateRetryPolicy(maxRetries: 3);
            var mockTransport = new MockTransport();
            Task<Response> task = SendGetRequest(mockTransport, policy, responseClassifier);

            MockResponse mockResponse = new MockResponse(500);
            mockResponse.AddHeader(new HttpHeader("Retry-After", "25"));

            await mockTransport.RequestGate.Cycle(mockResponse);

            TimeSpan retryDelay = await gate.Cycle();

            await mockTransport.RequestGate.Cycle(new MockResponse(501));

            Response response = await task.TimeoutAfterDefault();

            Assert.AreEqual(TimeSpan.FromSeconds(25), retryDelay);
            Assert.AreEqual(501, response.Status);
        }

        [Test]
        public async Task RespectsRetryAfterHeaderWithDate()
        {
            var responseClassifier = new MockResponseClassifier(retriableCodes: new[] { 500 });
            (HttpPipelinePolicy policy, AsyncGate<TimeSpan, object> gate) = CreateRetryPolicy(maxRetries: 3);
            var mockTransport = new MockTransport();
            Task<Response> task = SendGetRequest(mockTransport, policy, responseClassifier);

            MockResponse mockResponse = new MockResponse(500);
            // Use large value to avoid time based flakiness
            mockResponse.AddHeader(new HttpHeader("Retry-After", DateTimeOffset.Now.AddHours(5).ToString("R")));

            await mockTransport.RequestGate.Cycle(mockResponse);

            TimeSpan retryDelay = await gate.Cycle();

            await mockTransport.RequestGate.Cycle(new MockResponse(501));

            Response response = await task.TimeoutAfterDefault();

            Assert.Less(TimeSpan.FromHours(4), retryDelay);
            Assert.AreEqual(501, response.Status);
        }

        [Test]
        public async Task RetryAfterWithInvalidValueIsIgnored()
        {
            var responseClassifier = new MockResponseClassifier(retriableCodes: new[] { 500 });
            (HttpPipelinePolicy policy, AsyncGate<TimeSpan, object> gate) = CreateRetryPolicy(maxRetries: 3);
            var mockTransport = new MockTransport();
            Task<Response> task = SendGetRequest(mockTransport, policy, responseClassifier);

            MockResponse mockResponse = new MockResponse(500);
            mockResponse.AddHeader(new HttpHeader("Retry-After", "Invalid-value"));

            await mockTransport.RequestGate.Cycle(mockResponse);

            TimeSpan retryDelay = await gate.Cycle();

            await mockTransport.RequestGate.Cycle(new MockResponse(501));

            Response response = await task.TimeoutAfterDefault();

            Assert.Less(TimeSpan.Zero, retryDelay);
            Assert.AreEqual(501, response.Status);
        }

        [Theory]
        [TestCase("retry-after-ms")]
        [TestCase("x-ms-retry-after-ms")]
        public async Task RespectsRetryAfterMSHeader(string headerName)
        {
            var responseClassifier = new MockResponseClassifier(retriableCodes: new[] { 500 });
            (HttpPipelinePolicy policy, AsyncGate<TimeSpan, object> gate) = CreateRetryPolicy(maxRetries: 3);
            var mockTransport = new MockTransport();
            Task<Response> task = SendGetRequest(mockTransport, policy, responseClassifier);

            MockResponse mockResponse = new MockResponse(500);
            mockResponse.AddHeader(new HttpHeader(headerName, "120000"));

            await mockTransport.RequestGate.Cycle(mockResponse);

            TimeSpan retryDelay = await gate.Cycle();

            await mockTransport.RequestGate.Cycle(new MockResponse(501));

            Response response = await task.TimeoutAfterDefault();

            Assert.AreEqual(TimeSpan.FromMilliseconds(120000), retryDelay);
            Assert.AreEqual(501, response.Status);
        }

        [Theory]
        [TestCase("retry-after-ms")]
        [TestCase("x-ms-retry-after-ms")]
        public async Task MsHeadersArePreferredOverRetryAfter(string headerName)
        {
            var responseClassifier = new MockResponseClassifier(retriableCodes: new[] { 500 });
            (HttpPipelinePolicy policy, AsyncGate<TimeSpan, object> gate) = CreateRetryPolicy(maxRetries: 3);
            var mockTransport = new MockTransport();
            Task<Response> task = SendGetRequest(mockTransport, policy, responseClassifier);

            MockResponse mockResponse = new MockResponse(500);
            mockResponse.AddHeader(new HttpHeader("Retry-After", "1"));
            mockResponse.AddHeader(new HttpHeader(headerName, "120000"));

            await mockTransport.RequestGate.Cycle(mockResponse);

            TimeSpan retryDelay = await gate.Cycle();

            await mockTransport.RequestGate.Cycle(new MockResponse(501));

            Response response = await task.TimeoutAfterDefault();

            Assert.AreEqual(TimeSpan.FromMilliseconds(120000), retryDelay);
            Assert.AreEqual(501, response.Status);
        }

        [Test]
        [NonParallelizable]
        public async Task RetryingEmitsEventSourceEvent()
        {
            var responseClassifier = new MockResponseClassifier(retriableCodes: new[] { 500 });
            var listener = new TestEventListener();
            listener.EnableEvents(AzureCoreEventSource.Singleton, EventLevel.Informational);

            (HttpPipelinePolicy policy, AsyncGate<TimeSpan, object> gate) = CreateRetryPolicy(maxRetries: 2);
            MockTransport mockTransport = CreateMockTransport();
            Task<Response> task = SendGetRequest(mockTransport, policy, responseClassifier);

            MockRequest request = await mockTransport.RequestGate.Cycle(new MockResponse(500));

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
            EventWrittenEventArgs e = listener.SingleEventById(10, args => args.GetProperty<int>("retryNumber") == retryNumber);

            Assert.AreEqual(EventLevel.Informational, e.Level);
            Assert.AreEqual("RequestRetrying", e.EventName);
            Assert.AreEqual(request.ClientRequestId, e.GetProperty<string>("requestId"));
            Assert.IsTrue(e.GetProperty<double>("seconds") > 0);
        }

        protected (HttpPipelinePolicy, AsyncGate<TimeSpan, object>) CreateRetryPolicy(int maxRetries = 3)
        {
            var policy = new RetryPolicyMock(_mode, maxRetries, TimeSpan.FromSeconds(3), maxDelay: TimeSpan.MaxValue);
            return (policy, policy.DelayGate);
        }

        internal class RetryPolicyMock : RetryPolicy
        {
            public RetryPolicyMock(RetryMode mode, int maxRetries = 3, TimeSpan delay = default, TimeSpan maxDelay = default) : base(mode, delay, maxDelay, maxRetries)
            {
            }

            public AsyncGate<TimeSpan, object> DelayGate { get; } = new AsyncGate<TimeSpan, object>();

            internal override void Wait(TimeSpan time, CancellationToken cancellationToken)
            {
                DelayGate.WaitForRelease(time).GetAwaiter().GetResult();
            }

            internal override Task WaitAsync(TimeSpan time, CancellationToken cancellationToken)
            {
                return DelayGate.WaitForRelease(time);
            }
        }

        protected class MockResponseClassifier : ResponseClassifier
        {
            private readonly int[] _retriableCodes;

            private readonly Func<Exception, bool> _exceptionFilter;

            public MockResponseClassifier(int[] retriableCodes, Func<Exception, bool> exceptionFilter = null)
            {
                _retriableCodes = retriableCodes;
                _exceptionFilter = exceptionFilter;
            }

            public override bool IsRetriableResponse(HttpMessage message)
            {
                return Array.IndexOf(_retriableCodes, message.Response.Status) >= 0;
            }

            public override bool IsRetriableException(Exception exception)
            {
                return _exceptionFilter != null && _exceptionFilter(exception);
            }
        }
    }
}
