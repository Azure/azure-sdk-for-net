// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Microsoft.AspNetCore.Http;
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

            Assert.That(startEvent.Key, Is.EqualTo("Azure.Core.Http.Request.Start"));
            Assert.That(stopEvent.Key, Is.EqualTo("Azure.Core.Http.Request.Stop"));

            Assert.That(activity.OperationName, Is.EqualTo("Azure.Core.Http.Request"));

            Assert.That(activity.Tags, Has.Member(new KeyValuePair<string, string>("http.status_code", "201")));
            Assert.That(activity.Tags, Has.Member(new KeyValuePair<string, string>("http.url", "http://example.com/")));
            Assert.That(activity.Tags, Has.Member(new KeyValuePair<string, string>("http.method", "GET")));
            Assert.That(activity.Tags, Has.Member(new KeyValuePair<string, string>("http.user_agent", "agent")));
            Assert.That(activity.Tags, Has.Member(new KeyValuePair<string, string>("requestId", clientRequestId)));
            Assert.That(activity.Tags, Has.Member(new KeyValuePair<string, string>("serviceRequestId", "server request id")));
            Assert.That(activity.Tags, Has.Member(new KeyValuePair<string, string>("otel.status_code", "UNSET")));
            Assert.That(activity.Tags, Has.Member(new KeyValuePair<string, string>("kind", "client")));
            Assert.That(activity.Tags, Has.Member(new KeyValuePair<string, string>("az.namespace", "Microsoft.Azure.Core.Cool.Tests")));
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

            Assert.That(activity.Tags, Has.Member(new KeyValuePair<string, string>("http.url", "http://example.com/?api-version=v2&sas=REDACTED")));
            Assert.That(activity.Tags.Where(kvp => kvp.Value.Contains("secret")), Is.Empty);
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

            Assert.That(activity.Tags, Has.Member(new KeyValuePair<string, string>("otel.status_code", "ERROR")));
        }

        [Test]
        [NonParallelizable]
        public void ActivityShouldBeStoppedWhenTransportThrows()
        {
            Activity activity = null;
            Exception exception = new Exception();
            (string Key, object Value, DiagnosticListener) startEvent = default;
            using var testListener = new TestDiagnosticListener("Azure.Core");

            MockTransport mockTransport = CreateMockTransport(_ =>
            {
                activity = Activity.Current;
                startEvent = testListener.Events.Dequeue();
                throw exception;
            });

            string clientRequestId = null;
            Assert.ThrowsAsync<Exception>(async () => await SendRequestAsync(mockTransport, request =>
            {
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri("http://example.com"));
                request.Headers.Add("User-Agent", "agent");
                clientRequestId = request.ClientRequestId;
            }, s_enabledPolicy));

            (string Key, object Value, DiagnosticListener) exceptionEvent = testListener.Events.Dequeue();

            Assert.That(startEvent.Key, Is.EqualTo("Azure.Core.Http.Request.Start"));
            Assert.That(exceptionEvent.Key, Is.EqualTo("Azure.Core.Http.Request.Exception"));
            Assert.That(exceptionEvent.Value, Is.EqualTo(exception));

            (string Key, object Value, DiagnosticListener) stopEvent = testListener.Events.Dequeue();
            Assert.That(stopEvent.Key, Is.EqualTo("Azure.Core.Http.Request.Stop"));

            Assert.That(activity.OperationName, Is.EqualTo("Azure.Core.Http.Request"));
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

                Assert.That(mockTransport.SingleRequest.TryGetHeader("traceparent", out string requestId), Is.True);
                Assert.That(requestId, Is.EqualTo(activity.Id));
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

            string headerName = Activity.DefaultIdFormat == ActivityIdFormat.W3C ? "traceparent" : "Request-Id";
            Assert.That(transport.SingleRequest.TryGetHeader(headerName, out string requestId), Is.True);
            Assert.That(requestId, Is.EqualTo(activity.Id));
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

                Assert.That(transport.SingleRequest.TryGetHeader("traceparent", out string requestId), Is.True);
                Assert.That(requestId, Is.EqualTo(activity.Id));

                Assert.That(transport.SingleRequest.TryGetHeader("tracestate", out string traceState), Is.True);
                Assert.That(traceState, Is.EqualTo("trace"));
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

            Assert.That(startEvent.Key, Is.EqualTo("Azure.Core.Http.Request.Start"));
            Assert.That(startEvent.Value, Is.InstanceOf<HttpMessage>());

            Assert.That(stopEvent.Key, Is.EqualTo("Azure.Core.Http.Request.Stop"));
            Assert.That(stopEvent.Value, Is.InstanceOf<HttpMessage>());

            Assert.That(isEnabledCall.Item1, Is.EqualTo("Azure.Core.Http.Request"));
            Assert.That(isEnabledCall.Item2, Is.InstanceOf<HttpMessage>());
        }

        [Test]
        [NonParallelizable]
        public async Task ActivityIsNotCreatedWhenDisabled()
        {
            using var testListener = new TestDiagnosticListener("Azure.Core");

            var transport = new MockTransport(new MockResponse(200));

            await SendGetRequest(transport, new RequestActivityPolicy(isDistributedTracingEnabled: false, "Microsoft.Azure.Core.Cool.Tests", _sanitizer));

            Assert.That(testListener.Events.Count, Is.EqualTo(0));
        }

#if NET5_0_OR_GREATER
        [SetUp]
        [TearDown]
        public void ResetFeatureSwitch()
        {
            ActivityExtensions.ResetFeatureSwitch();
        }

        [Test]
        [TestCase(443)]
        [TestCase(8080)]
        [TestCase(null)]
        [NonParallelizable]
        public async Task ActivitySourceActivityStartedOnRequest(int? port)
        {
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
                    request.Uri.Reset(new Uri("https://example.com/path"));
                    if (port != null)
                    {
                        request.Uri.Port = port.Value;
                    }

                    url = request.Uri.ToString();

                    request.Headers.Add("User-Agent", "agent");
                    clientRequestId = request.ClientRequestId;
                }, s_enabledPolicy);

                await requestTask;

                Assert.That(testListener.Activities.Single(), Is.SameAs(activity));
                Assert.That(activity.DisplayName, Is.EqualTo("GET"));

                Assert.That(activity.Kind, Is.EqualTo(ActivityKind.Client));
                Assert.That(activity.TagObjects, Has.Member(new KeyValuePair<string, int>("http.response.status_code", 201)));
                Assert.That(activity.TagObjects, Has.Member(new KeyValuePair<string, string>("url.full", url)));
                Assert.That(activity.TagObjects, Has.Member(new KeyValuePair<string, string>("http.request.method", "GET")));
                Assert.That(activity.Tags.Where(kvp => kvp.Key == "http.user_agent"), Is.Empty);
                Assert.That(activity.Tags.Where(kvp => kvp.Key == "requestId"), Is.Empty);
                Assert.That(activity.Tags.Where(kvp => kvp.Key == "serviceRequestId"), Is.Empty);

                Assert.That(activity.TagObjects, Has.Member(new KeyValuePair<string, string>("az.client_request_id", clientRequestId)));
                Assert.That(activity.TagObjects, Has.Member(new KeyValuePair<string, string>("az.service_request_id", "server request id")));

                Assert.That(activity.TagObjects, Has.Member(new KeyValuePair<string, string>("server.address", "example.com")));
                Assert.That(activity.TagObjects, Has.Member(new KeyValuePair<string, object>("server.port", port ?? 443)));
                Assert.That(activity.TagObjects, Has.Member(new KeyValuePair<string, string>("az.namespace", "Microsoft.Azure.Core.Cool.Tests")));
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
            ActivityIdFormat previousFormat = Activity.DefaultIdFormat;
            Activity.DefaultIdFormat = ActivityIdFormat.W3C;

            using var clientListener = new TestActivitySourceListener("Azure.Clients.ClientName");
            DiagnosticScopeFactory clientDiagnostics = new DiagnosticScopeFactory("Azure.Clients", "Microsoft.Azure.Core.Cool.Tests", true, true, true);
            using DiagnosticScope outerScope = clientDiagnostics.CreateScope("ClientName.ActivityName", ActivityKind.Internal);
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

                Assert.That(testListener.Activities.Count, Is.EqualTo(1));
                Assert.That(testListener.Activities.Single().TagObjects, Has.Member(new KeyValuePair<string, int>("http.response.status_code", 201)));
            }
            finally
            {
                Activity.DefaultIdFormat = previousFormat;
            }
        }

        [Test]
        [NonParallelizable]
        public void ActivityShouldBeStoppedWhenTransportThrowsActivitySource()
        {
            HttpRequestException exception = new HttpRequestException("Test exception");
            using var clientListener = new TestActivitySourceListener("Azure.Core.Http");

            MockTransport mockTransport = CreateMockTransport(_ => throw exception);

            Assert.ThrowsAsync<HttpRequestException>(async () => await SendRequestAsync(mockTransport, request =>
            {
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri("http://example.com"));
            }, s_enabledPolicy));

            var activity = clientListener.AssertAndRemoveActivity("Azure.Core.Http.Request");

            Assert.That(activity.TagObjects, Has.Member(new KeyValuePair<string, string>("error.type", "System.Net.Http.HttpRequestException")));
            Assert.That(activity.Status, Is.EqualTo(ActivityStatusCode.Error));
            Assert.That(activity.StatusDescription, Does.Contain("Test exception"));
        }

        [Test]
        [NonParallelizable]
        public async Task ActivityMarkedAsErrorForErrorResponseActivitySource()
        {
            using var clientListener = new TestActivitySourceListener("Azure.Core.Http");

            MockTransport mockTransport = CreateMockTransport(_ =>
            {
                MockResponse mockResponse = new MockResponse(500);
                return mockResponse;
            });

            await SendGetRequest(mockTransport, s_enabledPolicy);

            var activity = clientListener.AssertAndRemoveActivity("Azure.Core.Http.Request");

            Assert.That(activity.TagObjects, Has.Member(new KeyValuePair<string, string>("error.type", "500")));
            Assert.That(activity.Status, Is.EqualTo(ActivityStatusCode.Error));
            Assert.That(activity.StatusDescription, Is.Null);
            Assert.That(activity.TagObjects.Where(t => t.Key == "otel.status_code"), Is.Empty);
        }

        [Test]
        [NonParallelizable]
        public async Task ActivityHasHttpResendCountOnRetries()
        {
            Activity.DefaultIdFormat = ActivityIdFormat.W3C;
            using var clientListener = new TestActivitySourceListener("Azure.Core.Http");

            MockTransport mockTransport = CreateMockTransport(_ =>
            {
                MockResponse mockResponse = new MockResponse(500);
                return mockResponse;
            });

            await SendRequestAsync(mockTransport, message =>
            {
                message.Request.Method = RequestMethod.Get;
                message.RetryNumber = 42;
                message.Request.Uri.Reset(new Uri("http://example.com"));
            }, s_enabledPolicy);

            var activity = clientListener.AssertAndRemoveActivity("Azure.Core.Http.Request");

            Assert.That(activity.TagObjects, Has.Member(new KeyValuePair<string, object>("http.request.resend_count", 42)));
            Assert.That(activity.TagObjects, Has.Member(new KeyValuePair<string, string>("error.type", "500")));
            Assert.That(activity.Status, Is.EqualTo(ActivityStatusCode.Error));
            Assert.That(activity.StatusDescription, Is.Null);
            Assert.That(activity.TagObjects.Where(t => t.Key == "otel.status_code"), Is.Empty);
        }
#endif
    }
}
