// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class RequestActivityPolicyTests : SyncAsyncPolicyTestBase
    {
        public RequestActivityPolicyTests(bool isAsync) : base(isAsync)
        {
        }

        private static string[] s_allowedQueryParameters = new[] { "api-version" };
        private static HttpMessageSanitizer _sanitizer = new HttpMessageSanitizer(s_allowedQueryParameters, Array.Empty<string>());
        private static readonly RequestActivityPolicy s_enabledPolicy = new RequestActivityPolicy(true, "Microsoft.Azure.Core.Cool.Tests", _sanitizer);

        [Test]
        [NonParallelizable]
        public async Task ActivityIsCreatedForRequest()
        {
            Activity activity = null;
            (string Key, object Value, DiagnosticListener) startEvent = default;
            using var testListener = new TestDiagnosticListener("Azure.Core");

            MockTransport mockTransport = CreateMockTransport(_ =>
            {
                activity = Activity.Current;
                startEvent = testListener.Events.Dequeue();
                MockResponse mockResponse = new MockResponse(201);
                mockResponse.AddHeader(new HttpHeader("x-ms-request-id", "server request id"));
                return mockResponse;
            });

            string clientRequestId = null;
            Task<Response> requestTask = SendRequestAsync(mockTransport, request =>
            {
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri("http://example.com"));
                request.Headers.Add("User-Agent", "agent");
                clientRequestId = request.ClientRequestId;
            }, s_enabledPolicy);

            await requestTask;

            (string Key, object Value, DiagnosticListener) stopEvent = testListener.Events.Dequeue();

            Assert.AreEqual("Azure.Core.Http.Request.Start", startEvent.Key);
            Assert.AreEqual("Azure.Core.Http.Request.Stop", stopEvent.Key);

            Assert.AreEqual("Azure.Core.Http.Request", activity.OperationName);

            CollectionAssert.Contains(activity.Tags, new KeyValuePair<string, string>("http.status_code", "201"));
            CollectionAssert.Contains(activity.Tags, new KeyValuePair<string, string>("http.url", "http://example.com/"));
            CollectionAssert.Contains(activity.Tags, new KeyValuePair<string, string>("http.method", "GET"));
            CollectionAssert.Contains(activity.Tags, new KeyValuePair<string, string>("http.user_agent", "agent"));
            CollectionAssert.Contains(activity.Tags, new KeyValuePair<string, string>("requestId", clientRequestId));
            CollectionAssert.Contains(activity.Tags, new KeyValuePair<string, string>("serviceRequestId", "server request id"));
            CollectionAssert.Contains(activity.Tags, new KeyValuePair<string, string>("otel.status_code", "UNSET"));
            CollectionAssert.Contains(activity.Tags, new KeyValuePair<string, string>("kind", "client"));
            CollectionAssert.Contains(activity.Tags, new KeyValuePair<string, string>("az.namespace", "Microsoft.Azure.Core.Cool.Tests"));
        }

        [Test]
        [NonParallelizable]
        public async Task UriAttributeIsSanitized()
        {
            Activity activity = null;
            using var testListener = new TestDiagnosticListener("Azure.Core");

            MockTransport mockTransport = CreateMockTransport(_ =>
            {
                activity = Activity.Current;
                return new MockResponse(201);
            });

            string clientRequestId = null;
            Task<Response> requestTask = SendRequestAsync(mockTransport, request =>
            {
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri("http://example.com?api-version=v2&sas=secret value"));
                clientRequestId = request.ClientRequestId;
            }, s_enabledPolicy);

            await requestTask;

            CollectionAssert.Contains(activity.Tags, new KeyValuePair<string, string>("http.url", "http://example.com/?api-version=v2&sas=REDACTED"));
            CollectionAssert.IsEmpty(activity.Tags.Where(kvp => kvp.Value.Contains("secret")));
        }

        [Test]
        [NonParallelizable]
        public async Task ActivityMarkedAsErrorForErrorResponse()
        {
            Activity activity = null;
            using var testListener = new TestDiagnosticListener("Azure.Core");

            MockTransport mockTransport = CreateMockTransport(_ =>
            {
                activity = Activity.Current;
                MockResponse mockResponse = new MockResponse(500);
                return mockResponse;
            });

            Task<Response> requestTask = SendGetRequest(mockTransport, s_enabledPolicy);

            await requestTask;

            CollectionAssert.Contains(activity.Tags, new KeyValuePair<string, string>("otel.status_code", "ERROR"));
        }

        [Test]
        [NonParallelizable]
        public void ActivityShouldBeStoppedWhenTransportThrows()
        {
            Activity activity = null;
            (string Key, object Value, DiagnosticListener) startEvent = default;
            using var testListener = new TestDiagnosticListener("Azure.Core");

            MockTransport mockTransport = CreateMockTransport(_ =>
            {
                activity = Activity.Current;
                startEvent = testListener.Events.Dequeue();
                throw new Exception();
            });

            string clientRequestId = null;
            Assert.ThrowsAsync<Exception>(async () => await SendRequestAsync(mockTransport, request =>
            {
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri("http://example.com"));
                request.Headers.Add("User-Agent", "agent");
                clientRequestId = request.ClientRequestId;
            }, s_enabledPolicy));

            (string Key, object Value, DiagnosticListener) stopEvent = testListener.Events.Dequeue();

            Assert.AreEqual("Azure.Core.Http.Request.Start", startEvent.Key);
            Assert.AreEqual("Azure.Core.Http.Request.Stop", stopEvent.Key);

            Assert.AreEqual("Azure.Core.Http.Request", activity.OperationName);
        }

        [Test]
        [NonParallelizable]
        public async Task ActivityIdIsStampedOnRequest()
        {
            using var testListener = new TestDiagnosticListener("Azure.Core");

            ActivityIdFormat previousFormat = Activity.DefaultIdFormat;
            Activity.DefaultIdFormat = ActivityIdFormat.W3C;
            try
            {
                Activity activity = null;

                MockTransport mockTransport = CreateMockTransport(_ =>
                {
                    activity = Activity.Current;
                    return new MockResponse(201);
                });

                Task<Response> requestTask = SendRequestAsync(mockTransport, request =>
                {
                    request.Method = RequestMethod.Get;
                    request.Uri.Reset(new Uri("http://example.com"));
                }, s_enabledPolicy);

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

            await SendGetRequest(transport, s_enabledPolicy);

            activity.Stop();

#if NET5_0_OR_GREATER
            Assert.True(transport.SingleRequest.TryGetHeader("traceparent", out string requestId));
#else
            Assert.True(transport.SingleRequest.TryGetHeader("Request-Id", out string requestId));
#endif
            Assert.AreEqual(activity.Id, requestId);
        }

        [Test]
        [NonParallelizable]
        public async Task CurrentActivityIsInjectedIntoRequestW3C()
        {
            ActivityIdFormat previousFormat = Activity.DefaultIdFormat;
            Activity.DefaultIdFormat = ActivityIdFormat.W3C;
            try
            {
                var transport = new MockTransport(new MockResponse(200));

                var activity = new Activity("Dummy");

                activity.Start();
                activity.TraceStateString = "trace";

                await SendGetRequest(transport, s_enabledPolicy);

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
            using var testListener = new TestDiagnosticListener("Azure.Core");

            var transport = new MockTransport(new MockResponse(200));

            await SendGetRequest(transport, s_enabledPolicy);

            (string Key, object Value, DiagnosticListener) startEvent = testListener.Events.Dequeue();
            (string Key, object Value, DiagnosticListener) stopEvent = testListener.Events.Dequeue();
            (string, object, object) isEnabledCall = testListener.IsEnabledCalls.Dequeue();

            Assert.AreEqual("Azure.Core.Http.Request.Start", startEvent.Key);
            Assert.IsInstanceOf<HttpMessage>(startEvent.Value);

            Assert.AreEqual("Azure.Core.Http.Request.Stop", stopEvent.Key);
            Assert.IsInstanceOf<HttpMessage>(stopEvent.Value);

            Assert.AreEqual("Azure.Core.Http.Request", isEnabledCall.Item1);
            Assert.IsInstanceOf<HttpMessage>(isEnabledCall.Item2);
        }

        [Test]
        [NonParallelizable]
        public async Task ActivityIsNotCreatedWhenDisabled()
        {
            using var testListener = new TestDiagnosticListener("Azure.Core");

            var transport = new MockTransport(new MockResponse(200));

            await SendGetRequest(transport, new RequestActivityPolicy(isDistributedTracingEnabled: false, "Microsoft.Azure.Core.Cool.Tests", _sanitizer));

            Assert.AreEqual(0, testListener.Events.Count);
        }

#if NET5_0_OR_GREATER
        [SetUp]
        [TearDown]
        public void ResetFeatureSwitch()
        {
            ActivityExtensions.ResetFeatureSwitch();
        }

        private static TestAppContextSwitch SetAppConfigSwitch()
        {
            var s = new TestAppContextSwitch("Azure.Experimental.EnableActivitySource", "true");
            ActivityExtensions.ResetFeatureSwitch();
            return s;
        }

        [Test]
        [TestCase(443)]
        [TestCase(8080)]
        [TestCase(null)]
        [NonParallelizable]
        public async Task ActivitySourceActivityStartedOnRequest(int? port)
        {
            using var _ = SetAppConfigSwitch();

            ActivityIdFormat previousFormat = Activity.DefaultIdFormat;
            Activity.DefaultIdFormat = ActivityIdFormat.W3C;
            try
            {
                Activity activity = null;
                using var testListener = new TestActivitySourceListener("Azure.Core.Http");

                MockTransport mockTransport = CreateMockTransport(_ =>
                {
                    activity = Activity.Current;
                    MockResponse mockResponse = new MockResponse(201);
                    mockResponse.AddHeader(new HttpHeader("x-ms-request-id", "server request id"));
                    return mockResponse;
                });

                string clientRequestId = null;
                string url = null;
                Task<Response> requestTask = SendRequestAsync(mockTransport, request =>
                {
                    request.Method = RequestMethod.Get;
                    request.Uri.Reset(new Uri("http://example.com/path"));
                    if (port != null)
                    {
                        request.Uri.Port = port.Value;
                    }

                    url = request.Uri.ToString();

                    request.Headers.Add("User-Agent", "agent");
                    clientRequestId = request.ClientRequestId;
                }, s_enabledPolicy);

                await requestTask;

                Assert.AreEqual(activity, testListener.Activities.Single());

                CollectionAssert.Contains(activity.TagObjects, new KeyValuePair<string, int>("http.status_code", 201));
                CollectionAssert.Contains(activity.TagObjects, new KeyValuePair<string, string>("http.url", url));
                CollectionAssert.Contains(activity.TagObjects, new KeyValuePair<string, string>("http.method", "GET"));
                CollectionAssert.Contains(activity.TagObjects, new KeyValuePair<string, string>("http.user_agent", "agent"));

                CollectionAssert.DoesNotContain(activity.TagObjects, new KeyValuePair<string, string>("requestId", clientRequestId));
                CollectionAssert.Contains(activity.TagObjects, new KeyValuePair<string, string>("az.client_request_id", clientRequestId));

                CollectionAssert.DoesNotContain(activity.TagObjects, new KeyValuePair<string, string>("serviceRequestId", "server request id"));
                CollectionAssert.Contains(activity.TagObjects, new KeyValuePair<string, string>("az.service_request_id", "server request id"));

                CollectionAssert.Contains(activity.TagObjects, new KeyValuePair<string, string>("net.peer.name", "example.com"));

                if (port is null or 443)
                    CollectionAssert.DoesNotContain(activity.TagObjects, new KeyValuePair<string, int>("net.peer.port", 443));
                else
                    CollectionAssert.Contains(activity.TagObjects, new KeyValuePair<string, int>("net.peer.port", port.Value));

                CollectionAssert.Contains(activity.TagObjects, new KeyValuePair<string, string>("az.namespace", "Microsoft.Azure.Core.Cool.Tests"));
            }
            finally
            {
                Activity.DefaultIdFormat = previousFormat;
            }
        }

        [Test]
        [NonParallelizable]
        public async Task HttpActivityNeverSuppressed()
        {
            using var _ = SetAppConfigSwitch();

            ActivityIdFormat previousFormat = Activity.DefaultIdFormat;
            Activity.DefaultIdFormat = ActivityIdFormat.W3C;

            using var clientListener = new TestActivitySourceListener("Azure.Clients.ClientName");
            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory("Azure.Clients", "Microsoft.Azure.Core.Cool.Tests", true, true);
            using DiagnosticScope outerScope = clientDiagnostics.CreateScope("ClientName.ActivityName", DiagnosticScope.ActivityKind.Internal);
            outerScope.Start();

            try
            {
                using var testListener = new TestActivitySourceListener("Azure.Core.Http");

                MockTransport mockTransport = CreateMockTransport(_ => new MockResponse(201));

                Task<Response> requestTask = SendRequestAsync(mockTransport, request =>
                {
                    request.Method = RequestMethod.Get;
                }, s_enabledPolicy);

                await requestTask;

                Assert.AreEqual(1, testListener.Activities.Count);
                CollectionAssert.Contains(testListener.Activities.Single().TagObjects, new KeyValuePair<string, int>("http.status_code", 201));
            }
            finally
            {
                Activity.DefaultIdFormat = previousFormat;
            }
        }
#endif
    }
}
