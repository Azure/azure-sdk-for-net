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
using Azure.Core.Samples;
using Azure.Core.Shared;
using Azure.Core.TestFramework;
using Moq;
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
        public async Task OnlyRetriesRetriableCodes()
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
        public async Task ShouldRetryIsCalledOnlyForErrors()
        {
            (HttpPipelinePolicy policy, AsyncGate<TimeSpan, object> gate) = CreateRetryPolicy(maxRetries: 3);
            MockTransport mockTransport = CreateMockTransport();

            var beforeSend = DateTimeOffset.UtcNow;
            var pipeline = new HttpPipeline(mockTransport, new[] { policy });
            HttpMessage message = pipeline.CreateMessage();
            Task<HttpMessage> task = SendMessageGetRequest(pipeline, message);
            RetryPolicyMock mockPolicy = (RetryPolicyMock) policy;

            await mockTransport.RequestGate.Cycle(new MockResponse(500));
            Assert.GreaterOrEqual(message.ProcessingStartTime, beforeSend);
            Assert.AreEqual(0, message.ProcessingContext.RetryNumber);
            await gate.Cycle();
            Assert.IsTrue(mockPolicy.ShouldRetryCalled);
            mockPolicy.ShouldRetryCalled = false;

            var exception = new IOException();
            await mockTransport.RequestGate.CycleWithException(exception);
            Assert.AreEqual(1, message.ProcessingContext.RetryNumber);

            await gate.Cycle();
            Assert.AreSame(exception, mockPolicy.LastException);
            mockPolicy.LastException = null;

            Assert.IsTrue(mockPolicy.ShouldRetryCalled);
            mockPolicy.ShouldRetryCalled = false;

            await mockTransport.RequestGate.Cycle(new MockResponse(200));

            await task.TimeoutAfterDefault();
            Assert.IsFalse(mockPolicy.ShouldRetryCalled);
            Assert.AreEqual(2, message.ProcessingContext.RetryNumber);
            Assert.IsNull(mockPolicy.LastException);
        }

        [Test]
        public async Task OnRequestSentIsCalledForErrorResponseAndException()
        {
            (HttpPipelinePolicy policy, AsyncGate<TimeSpan, object> gate) = CreateRetryPolicy(maxRetries: 3);
            MockTransport mockTransport = CreateMockTransport();

            var pipeline = new HttpPipeline(mockTransport, new[] { policy });
            HttpMessage message = pipeline.CreateMessage();
            Task<HttpMessage> task = SendMessageGetRequest(pipeline, message);
            RetryPolicyMock mockPolicy = (RetryPolicyMock) policy;

            await mockTransport.RequestGate.Cycle(new MockResponse(500));
            Assert.AreEqual(0, message.ProcessingContext.RetryNumber);

            await gate.Cycle();
            Assert.IsTrue(mockPolicy.OnRequestSentCalled);
            mockPolicy.OnRequestSentCalled = false;

            var exception = new IOException();
            await mockTransport.RequestGate.CycleWithException(exception);
            Assert.AreEqual(1, message.ProcessingContext.RetryNumber);

            await gate.Cycle();
            Assert.IsTrue(mockPolicy.OnRequestSentCalled);
            mockPolicy.OnRequestSentCalled = false;

            Assert.AreSame(exception, mockPolicy.LastException);
            mockPolicy.LastException = null;

            await mockTransport.RequestGate.Cycle(new MockResponse(200));

            await task.TimeoutAfterDefault();
            Assert.IsTrue(mockPolicy.OnRequestSentCalled);
            Assert.AreEqual(2, message.ProcessingContext.RetryNumber);
            Assert.IsNull(mockPolicy.LastException);
        }

        [Test]
        public async Task RetriesOnException()
        {
            var responseClassifier = new MockResponseClassifier(retriableCodes: new[] { 500 }, exceptionFilter: ex => ex is InvalidOperationException);
            (HttpPipelinePolicy policy, AsyncGate<TimeSpan, object> gate) = CreateRetryPolicy();
            MockTransport mockTransport = CreateMockTransport();
            Task<Response> task = SendGetRequest(mockTransport, policy, responseClassifier);

            // this validates that the base RetryPolicy respects the custom response classifier
            await mockTransport.RequestGate.CycleWithException(new InvalidOperationException());

            await gate.Cycle();

            await mockTransport.RequestGate.Cycle(new MockResponse(200));

            Response response = await task.TimeoutAfterDefault();
            Assert.AreEqual(200, response.Status);
        }

        [Test]
        public async Task RetriesWithPolly()
        {
            var policy = new PollyPolicy();
            MockTransport mockTransport = CreateMockTransport();

            var pipeline = new HttpPipeline(mockTransport, new[] { policy });
            HttpMessage message = pipeline.CreateMessage();
            Task<HttpMessage> task = SendMessageGetRequest(pipeline, message);

            await mockTransport.RequestGate.Cycle(new MockResponse(500));
            await mockTransport.RequestGate.CycleWithException(new IOException());
            await mockTransport.RequestGate.Cycle(new MockResponse(200));

            message = await task.TimeoutAfterDefault();

            Assert.AreEqual(2, message.ProcessingContext.RetryNumber);
            Assert.AreEqual(200, message.Response.Status);
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
            using var listener = new TestEventListener();
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

        [Test]
        public async Task CyclesThroughReadHosts()
        {
           (HttpPipelinePolicy policy, AsyncGate<TimeSpan, object> gate) = CreateRetryPolicy(maxRetries: 3);
            MockTransport mockTransport = CreateMockTransport();
            var geoPolicy = new GeoRedundantFallbackPolicy(new[] { "host1", "host2" }, null);
            var pipeline = new HttpPipeline(mockTransport, new[] { policy, geoPolicy });
            var message = pipeline.CreateMessage();
            Task<HttpMessage> task = SendMessageGetRequest(pipeline, message);

            MockRequest request = await mockTransport.RequestGate.Cycle(new MockResponse(500));
            await gate.Cycle();

            request = await mockTransport.RequestGate.CycleWithException(new IOException());
            Assert.AreEqual("example.com", request.Uri.Host);

            await gate.Cycle();

            request = await mockTransport.RequestGate.CycleWithException(new IOException());
            Assert.AreEqual("host1", request.Uri.Host);
            await gate.Cycle();

            request = await mockTransport.RequestGate.Cycle(new MockResponse(200));
            Assert.AreEqual("host2", request.Uri.Host);

            await task;
        }

        [Test]
        public async Task DoesNotCycleThroughWriteHostsOnReads()
        {
            (HttpPipelinePolicy policy, AsyncGate<TimeSpan, object> gate) = CreateRetryPolicy(maxRetries: 3);
            MockTransport mockTransport = CreateMockTransport();
            var geoPolicy = new GeoRedundantFallbackPolicy(null, new[] { "host1", "host2" });
            var pipeline = new HttpPipeline(mockTransport, new[] { policy, geoPolicy });
            var message = pipeline.CreateMessage();
            Task<HttpMessage> task = SendMessageGetRequest(pipeline, message);

            MockRequest request = await mockTransport.RequestGate.Cycle(new MockResponse(500));
            await gate.Cycle();

            request = await mockTransport.RequestGate.CycleWithException(new IOException());
            Assert.AreEqual("example.com", request.Uri.Host);

            await gate.Cycle();

            request = await mockTransport.RequestGate.CycleWithException(new IOException());
            Assert.AreEqual("example.com", request.Uri.Host);
            await gate.Cycle();

            request = await mockTransport.RequestGate.Cycle(new MockResponse(200));
            Assert.AreEqual("example.com", request.Uri.Host);

            await task;
        }

        [Test]
        public async Task CyclesThroughWriteHosts()
        {
            (HttpPipelinePolicy policy, AsyncGate<TimeSpan, object> gate) = CreateRetryPolicy(maxRetries: 3);
            MockTransport mockTransport = CreateMockTransport();
            var geoPolicy = new GeoRedundantFallbackPolicy(null, new[] { "host1", "host2" });
            var pipeline = new HttpPipeline(mockTransport, new[] { policy, geoPolicy });

            var task = Send();

            async Task<Response> Send()
            {
                await Task.Yield();
                return await SendRequestAsync(pipeline, request =>
                {
                    request.Method = RequestMethod.Put;
                    request.Uri.Reset(new Uri("https://example.com/update"));
                    request.Content = RequestContent.Create(new byte[] { 1, 2, 3, 4, 5 });
                });
            }

            MockRequest request = await mockTransport.RequestGate.Cycle(new MockResponse(500));
            await gate.Cycle();

            request = await mockTransport.RequestGate.CycleWithException(new IOException());
            Assert.AreEqual("example.com", request.Uri.Host);

            await gate.Cycle();

            request = await mockTransport.RequestGate.CycleWithException(new IOException());
            Assert.AreEqual("host1", request.Uri.Host);
            await gate.Cycle();

            request = await mockTransport.RequestGate.Cycle(new MockResponse(200));
            Assert.AreEqual("host2", request.Uri.Host);

            await task;
        }

        [Test]
        public async Task DoesNotCycleThroughReadHostsOnWrites()
        {
            (HttpPipelinePolicy policy, AsyncGate<TimeSpan, object> gate) = CreateRetryPolicy(maxRetries: 3);
            MockTransport mockTransport = CreateMockTransport();
            var geoPolicy = new GeoRedundantFallbackPolicy(new[] { "host1", "host2" }, null);
            var pipeline = new HttpPipeline(mockTransport, new[] { policy, geoPolicy });
            var task = Send();

            async Task<Response> Send()
            {
                await Task.Yield();
                return await SendRequestAsync(pipeline, request =>
                {
                    request.Method = RequestMethod.Put;
                    request.Uri.Reset(new Uri("https://example.com/update"));
                    request.Content = RequestContent.Create(new byte[] { 1, 2, 3, 4, 5 });
                });
            }
            MockRequest request = await mockTransport.RequestGate.Cycle(new MockResponse(500));
            await gate.Cycle();

            request = await mockTransport.RequestGate.CycleWithException(new IOException());
            Assert.AreEqual("example.com", request.Uri.Host);

            await gate.Cycle();

            request = await mockTransport.RequestGate.CycleWithException(new IOException());
            Assert.AreEqual("example.com", request.Uri.Host);
            await gate.Cycle();

            request = await mockTransport.RequestGate.Cycle(new MockResponse(200));
            Assert.AreEqual("example.com", request.Uri.Host);

            await task;
        }

        [Test]
        public async Task RespectsHostAffinity()
        {
            (HttpPipelinePolicy policy, AsyncGate<TimeSpan, object> gate) = CreateRetryPolicy(maxRetries: 3);
            MockTransport mockTransport = CreateMockTransport();
            var geoPolicy = new GeoRedundantFallbackPolicy(new[] { "host1", "host2" }, null);
            var pipeline = new HttpPipeline(mockTransport, new[] { policy, geoPolicy });
            var message = pipeline.CreateMessage();
            GeoRedundantFallbackPolicy.SetHostAffinity(message, true);
            Task<HttpMessage> task = SendMessageGetRequest(pipeline, message);

            MockRequest request = await mockTransport.RequestGate.Cycle(new MockResponse(500));
            await gate.Cycle();

            Assert.AreEqual("example.com", request.Uri.Host);

            request = await mockTransport.RequestGate.CycleWithException(new IOException());
            await gate.Cycle();

            request = await mockTransport.RequestGate.CycleWithException(new IOException());
            Assert.AreEqual("example.com", request.Uri.Host);
            await gate.Cycle();

            request = await mockTransport.RequestGate.Cycle(new MockResponse(200));
            Assert.AreEqual("example.com", request.Uri.Host);

            await task;
        }

        public async Task RespectsPrimaryCoolDown_InitialAttempt()
        {
            (HttpPipelinePolicy policy, AsyncGate<TimeSpan, object> gate) = CreateRetryPolicy(maxRetries: 3);
            MockTransport mockTransport = CreateMockTransport();
            var geoPolicy = new GeoRedundantFallbackPolicy(new[] { "host1", "host2" }, null, TimeSpan.FromSeconds(3));
            var pipeline = new HttpPipeline(mockTransport, new[] { policy, geoPolicy });
            var message = pipeline.CreateMessage();
            Task<HttpMessage> task = SendMessageGetRequest(pipeline, message);

            MockRequest request = await mockTransport.RequestGate.CycleWithException(new IOException());
            await gate.Cycle();

            request = await mockTransport.RequestGate.CycleWithException(new IOException());
            Assert.AreEqual("host1", request.Uri.Host);
            await Task.Delay(TimeSpan.FromSeconds(5));
            await gate.Cycle();

            request = await mockTransport.RequestGate.Cycle(new MockResponse(200));
            Assert.AreEqual("example.com", request.Uri.Host);

            await task;
        }

        [Test]
        public async Task RespectsPrimaryCoolDown()
        {
            (HttpPipelinePolicy policy, AsyncGate<TimeSpan, object> gate) = CreateRetryPolicy(maxRetries: 3);
            MockTransport mockTransport = CreateMockTransport();
            var geoPolicy = new GeoRedundantFallbackPolicy(new[] { "host1", "host2" }, null, TimeSpan.FromSeconds(3));
            var pipeline = new HttpPipeline(mockTransport, new[] { policy, geoPolicy });
            var message = pipeline.CreateMessage();
            Task<HttpMessage> task = SendMessageGetRequest(pipeline, message);

            MockRequest request = await mockTransport.RequestGate.Cycle(new MockResponse(500));
            await gate.Cycle();

            Assert.AreEqual("example.com", request.Uri.Host);

            request = await mockTransport.RequestGate.CycleWithException(new IOException());
            await gate.Cycle();

            request = await mockTransport.RequestGate.CycleWithException(new IOException());
            Assert.AreEqual("host1", request.Uri.Host);
            await Task.Delay(TimeSpan.FromSeconds(5));
            await gate.Cycle();

            request = await mockTransport.RequestGate.Cycle(new MockResponse(200));
            Assert.AreEqual("example.com", request.Uri.Host);

            await task;
        }

        [Test]
        public async Task DoesNotAdvanceHostWhenAdvancedByOtherThread()
        {
            (HttpPipelinePolicy policy1, AsyncGate<TimeSpan, object> gate1) = CreateRetryPolicy(maxRetries: 3);
            MockTransport mockTransport1 = CreateMockTransport();
            var geoPolicy = new GeoRedundantFallbackPolicy(new[] { "host1", "host2" }, null);
            var pipeline1 = new HttpPipeline(mockTransport1, new[] { policy1, geoPolicy });
            var message1 = pipeline1.CreateMessage();
            var task1 = SendMessageGetRequest(pipeline1, message1);

            var request1 = await mockTransport1.RequestGate.CycleWithException(new IOException());
            await gate1.Cycle();
            // use a delay before asserting unlike in the other tests because this becomes too difficult to reason about otherwise
            // as we are simulating two threads
            await Task.Delay(TimeSpan.FromSeconds(1));
            Assert.AreEqual("host1", request1.Uri.Host);

            (HttpPipelinePolicy policy2, AsyncGate<TimeSpan, object> gate2) = CreateRetryPolicy(maxRetries: 3);
            MockTransport mockTransport2 = CreateMockTransport();

            var pipeline2 = new HttpPipeline(mockTransport2, new[] { policy2, geoPolicy });
            var message2 = pipeline2.CreateMessage();
            var task2 = SendMessageGetRequest(pipeline2, message2);
            var request2 = await mockTransport2.RequestGate.CycleWithException(new IOException());
            await gate2.Cycle();
            await Task.Delay(TimeSpan.FromSeconds(1));
            Assert.AreEqual("host2", request2.Uri.Host);

            request1 = await mockTransport1.RequestGate.CycleWithException(new IOException());
            await gate1.Cycle();
            await Task.Delay(TimeSpan.FromSeconds(1));
            Assert.AreEqual("host2", request1.Uri.Host);

            await mockTransport1.RequestGate.Cycle(new MockResponse(200));
            await mockTransport2.RequestGate.Cycle(new MockResponse(200));

            await task1;
            await task2;
        }

        private static void AssertRetryEvent(TestEventListener listener, MockRequest request, int retryNumber)
        {
            EventWrittenEventArgs e = listener.SingleEventById(10, args => args.GetProperty<int>("retryNumber") == retryNumber);

            Assert.AreEqual(EventLevel.Informational, e.Level);
            Assert.AreEqual("RequestRetrying", e.EventName);
            Assert.AreEqual(request.ClientRequestId, e.GetProperty<string>("requestId"));
            Assert.IsTrue(e.GetProperty<double>("seconds") > 0);
        }

        protected (HttpPipelinePolicy Policy, AsyncGate<TimeSpan, object> Gate) CreateRetryPolicy(int maxRetries = 3)
        {
            var policy = new RetryPolicyMock(_mode, maxRetries, TimeSpan.FromSeconds(3), maxDelay: TimeSpan.MaxValue);
            return (policy, policy.DelayGate);
        }

        internal class RetryPolicyMock : RetryPolicy
        {
            internal bool ShouldRetryCalled { get; set; }

            internal bool OnRequestSentCalled { get; set; }

            internal Exception LastException { get; set; }

            public RetryPolicyMock(RetryMode mode, int maxRetries = 3, TimeSpan delay = default, TimeSpan maxDelay = default) : base(
                new RetryOptions
                {
                    Mode = mode,
                    Delay = delay,
                    MaxDelay = maxDelay,
                    MaxRetries = maxRetries
                })
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

            protected internal override void OnRequestSent(HttpMessage message)
            {
                OnRequestSentCalled = true;
                base.OnRequestSent(message);
            }

            protected internal override ValueTask OnRequestSentAsync(HttpMessage message)
            {
                OnRequestSentCalled = true;
                return base.OnRequestSentAsync(message);
            }

            protected internal override bool ShouldRetry(HttpMessage message, Exception exception)
            {
                LastException = exception;
                ShouldRetryCalled = true;
                return base.ShouldRetry(message, exception);
            }

            protected internal override ValueTask<bool> ShouldRetryAsync(HttpMessage message, Exception exception)
            {
                LastException = exception;
                ShouldRetryCalled = true;
                return base.ShouldRetryAsync(message, exception);
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
