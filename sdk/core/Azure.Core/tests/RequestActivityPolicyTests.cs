// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Azure.Core.Http;
using Azure.Core.Pipeline;
using Azure.Core.Testing;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class RequestActivityPolicyTests : SyncAsyncPolicyTestBase
    {
        public RequestActivityPolicyTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [NonParallelizable]
        public async Task ActivityIsCreatedForRequest()
        {
            Activity activity = null;
            KeyValuePair<string, object> startEvent = default;
            using var testListener = new TestDiagnosticListener("Azure.Pipeline");

            MockTransport mockTransport = CreateMockTransport(_ =>
            {
                activity = Activity.Current;
                startEvent = testListener.Events.Dequeue();
                return new MockResponse(201);
            });

            using Request request = mockTransport.CreateRequest();
            request.Method = RequestMethod.Get;
            request.UriBuilder.Uri = new Uri("http://example.com");
            request.Headers.Add("User-Agent", "agent");

            Task<Response> requestTask = SendRequestAsync(mockTransport, request, RequestActivityPolicy.Shared);

            await requestTask;

            KeyValuePair<string, object> stopEvent = testListener.Events.Dequeue();

            Assert.AreEqual("Azure.Core.Http.Request.Start", startEvent.Key);
            Assert.AreEqual("Azure.Core.Http.Request.Stop", stopEvent.Key);

            Assert.AreEqual("Azure.Core.Http.Request", activity.OperationName);

            CollectionAssert.Contains(activity.Tags, new KeyValuePair<string, string>("http.status_code", "201"));
            CollectionAssert.Contains(activity.Tags, new KeyValuePair<string, string>("http.url", "http://example.com/"));
            CollectionAssert.Contains(activity.Tags, new KeyValuePair<string, string>("http.method", "GET"));
            CollectionAssert.Contains(activity.Tags, new KeyValuePair<string, string>("http.user_agent", "agent"));
        }


        [Test]
        [NonParallelizable]
        public async Task ActivityIdIsStampedOnRequest()
        {
            using var testListener = new TestDiagnosticListener("Azure.Pipeline");

            var previousFormat = Activity.DefaultIdFormat;
            Activity.DefaultIdFormat = ActivityIdFormat.W3C;
            try
            {
                Activity activity = null;

                MockTransport mockTransport = CreateMockTransport(_ =>
                {
                    activity = Activity.Current;
                    return new MockResponse(201);
                });

                using Request request = mockTransport.CreateRequest();
                request.Method = RequestMethod.Get;
                request.UriBuilder.Uri = new Uri("http://example.com");

                Task<Response> requestTask = SendRequestAsync(mockTransport, request, RequestActivityPolicy.Shared);

                await requestTask;

                Assert.True(mockTransport.SingleRequest.TryGetHeader("traceparent", out string requestId));
                Assert.AreEqual(activity.Id, requestId);
            }
            finally
            {
                Activity.DefaultIdFormat = previousFormat;
            }
        }

        [Test]
        [NonParallelizable]
        public async Task CurrentActivityIsInjectedIntoRequest()
        {
            var transport = new MockTransport(new MockResponse(200));

            var activity = new Activity("Dummy");

            activity.Start();

            await SendGetRequest(transport, RequestActivityPolicy.Shared);

            activity.Stop();

            Assert.True(transport.SingleRequest.TryGetHeader("Request-Id", out string requestId));
            Assert.AreEqual(activity.Id, requestId);
        }

        [Test]
        [NonParallelizable]
        public async Task CurrentActivityIsInjectedIntoRequestW3C()
        {
            var previousFormat = Activity.DefaultIdFormat;
            Activity.DefaultIdFormat = ActivityIdFormat.W3C;
            try
            {
                var transport = new MockTransport(new MockResponse(200));

                var activity = new Activity("Dummy");

                activity.Start();
                activity.TraceStateString = "trace";

                await SendGetRequest(transport, RequestActivityPolicy.Shared);

                activity.Stop();

                Assert.True(transport.SingleRequest.TryGetHeader("traceparent", out string requestId));
                Assert.AreEqual(activity.Id, requestId);

                Assert.True(transport.SingleRequest.TryGetHeader("tracestate", out string traceState));
                Assert.AreEqual("trace", traceState);
            }
            finally
            {
                Activity.DefaultIdFormat = previousFormat;
            }
        }

        [Test]
        [NonParallelizable]
        public async Task PassesMessageIntoIsEnabledStartAndStopEvents()
        {
            using var testListener = new TestDiagnosticListener("Azure.Pipeline");

            var transport = new MockTransport(new MockResponse(200));

            await SendGetRequest(transport, RequestActivityPolicy.Shared);

            KeyValuePair<string, object> startEvent = testListener.Events.Dequeue();
            KeyValuePair<string, object> stopEvent = testListener.Events.Dequeue();
            var isEnabledCall = testListener.IsEnabledCalls.Dequeue();

            Assert.AreEqual("Azure.Core.Http.Request.Start", startEvent.Key);
            Assert.IsInstanceOf<HttpPipelineMessage>(startEvent.Value);

            Assert.AreEqual("Azure.Core.Http.Request.Stop", stopEvent.Key);
            Assert.IsInstanceOf<HttpPipelineMessage>(stopEvent.Value);

            Assert.AreEqual("Azure.Core.Http.Request", isEnabledCall.Item1);
            Assert.IsInstanceOf<HttpPipelineMessage>(isEnabledCall.Item2);
        }

    }
}
