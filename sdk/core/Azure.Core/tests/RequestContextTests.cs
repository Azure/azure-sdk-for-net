// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.Diagnostics;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class RequestContextTests
    {
        [Test]
        public void CanCastFromErrorOptions()
        {
            RequestContext context = ErrorOptions.Default;

            Assert.IsTrue(context.ErrorOptions == ErrorOptions.Default);
        }

        [Test]
        public void CanSetErrorOptions()
        {
            #region Snippet:ErrorOptionsNoThrow
            RequestContext context = new RequestContext { ErrorOptions = ErrorOptions.NoThrow };
            #endregion

            Assert.IsTrue(context.ErrorOptions == ErrorOptions.NoThrow);
        }

        [Test]
        public async Task CanAddPolicy_PerCall()
        {
            var mockTransport = new MockTransport(new MockResponse(200));
            var clientOptions = new TestOptions()
            {
                Transport = mockTransport,
            };
            var pipeline = HttpPipelineBuilder.Build(clientOptions);

            #region Snippet:AddPolicyPerCall
            var context = new RequestContext();
            context.AddPolicy(new AddHeaderPolicy("PerCallHeader", "Value"), HttpPipelinePosition.PerCall);
            #endregion

            var message = pipeline.CreateMessage(context);
            await pipeline.SendAsync(message, message.CancellationToken);

            Request request = mockTransport.Requests[0];
            Assert.IsTrue(request.Headers.TryGetValues("PerCallHeader", out var values));
            Assert.AreEqual(1, values.Count());
            Assert.AreEqual("Value", values.ElementAt(0));
        }

        [Test]
        public async Task CanAddPolicy_PerRetry()
        {
            var retryResponse = new MockResponse(408); // Request Timeout
            var mockTransport = new MockTransport(retryResponse, retryResponse, new MockResponse(200));

            var clientOptions = new TestOptions()
            {
                Transport = mockTransport,
            };
            var pipeline = HttpPipelineBuilder.Build(clientOptions);

            #region Snippet:AddPolicyPerRetry
            var context = new RequestContext();
            context.AddPolicy(new AddHeaderPolicy("PerRetryHeader", "Value"), HttpPipelinePosition.PerRetry);
            #endregion

            var message = pipeline.CreateMessage(context);
            await pipeline.SendAsync(message, message.CancellationToken);

            Request request = mockTransport.Requests[0];
            Assert.IsTrue(request.Headers.TryGetValues("PerRetryHeader", out var values));
            Assert.AreEqual(3, values.Count());
            Assert.AreEqual("Value", values.ElementAt(0));
            Assert.AreEqual("Value", values.ElementAt(1));
            Assert.AreEqual("Value", values.ElementAt(2));
        }

        [Test]
        public async Task CanAddPolicy_BeforeTransport()
        {
            var retryResponse = new MockResponse(408); // Request Timeout

            // retry twice
            var mockTransport = new MockTransport(retryResponse, retryResponse, new MockResponse(200));
            var clientOptions = new TestOptions()
            {
                Transport = mockTransport,
            };
            var pipeline = HttpPipelineBuilder.Build(clientOptions);

            #region Snippet:AddPolicyBeforeTransport
            var context = new RequestContext();
            context.AddPolicy(new AddHeaderPolicy("BeforeTransportHeader", "Value"), HttpPipelinePosition.BeforeTransport);
            #endregion

            var message = pipeline.CreateMessage(context);
            await pipeline.SendAsync(message, message.CancellationToken);

            Request request = mockTransport.Requests[0];

            Assert.IsTrue(request.Headers.TryGetValues("BeforeTransportHeader", out var values));
            Assert.AreEqual(3, values.Count());
            Assert.AreEqual("Value", values.ElementAt(0));
            Assert.AreEqual("Value", values.ElementAt(1));
            Assert.AreEqual("Value", values.ElementAt(2));
        }

        [Test]
        public async Task CanAddRequestPolicies_AllPositions()
        {
            var retryResponse = new MockResponse(408); // Request Timeout

            // retry twice -- this will add the header three times.
            var mockTransport = new MockTransport(retryResponse, retryResponse, new MockResponse(200));
            var clientOptions = new TestOptions()
            {
                Transport = mockTransport,
            };
            var pipeline = HttpPipelineBuilder.Build(clientOptions);

            var context = new RequestContext();
            context.AddPolicy(new AddHeaderPolicy("PerCallHeader1", "PerCall1"), HttpPipelinePosition.PerCall);
            context.AddPolicy(new AddHeaderPolicy("PerCallHeader2", "PerCall2"), HttpPipelinePosition.PerCall);
            context.AddPolicy(new AddHeaderPolicy("PerRetryHeader", "PerRetry"), HttpPipelinePosition.PerRetry);
            context.AddPolicy(new AddHeaderPolicy("BeforeTransportHeader", "BeforeTransport"), HttpPipelinePosition.BeforeTransport);

            var message = pipeline.CreateMessage(context);
            await pipeline.SendAsync(message, message.CancellationToken);

            Request request = mockTransport.Requests[0];

            Assert.IsTrue(request.Headers.TryGetValues("PerCallHeader1", out var perCall1Values));
            Assert.AreEqual(1, perCall1Values.Count());
            Assert.AreEqual("PerCall1", perCall1Values.ElementAt(0));

            Assert.IsTrue(request.Headers.TryGetValues("PerCallHeader2", out var perCall2Values));
            Assert.AreEqual(1, perCall2Values.Count());
            Assert.AreEqual("PerCall2", perCall2Values.ElementAt(0));

            Assert.IsTrue(request.Headers.TryGetValues("PerRetryHeader", out var perRetryValues));
            Assert.AreEqual("PerRetry", perRetryValues.ElementAt(0));
            Assert.AreEqual("PerRetry", perRetryValues.ElementAt(1));
            Assert.AreEqual("PerRetry", perRetryValues.ElementAt(2));

            Assert.IsTrue(request.Headers.TryGetValues("BeforeTransportHeader", out var beforeTransportValues));
            Assert.AreEqual("BeforeTransport", beforeTransportValues.ElementAt(0));
            Assert.AreEqual("BeforeTransport", beforeTransportValues.ElementAt(1));
            Assert.AreEqual("BeforeTransport", beforeTransportValues.ElementAt(2));
        }

        [Test]
        public async Task CanAddPolicies_ThreeWays()
        {
            var mockTransport = new MockTransport(new MockResponse(200));

            var clientOptions = new TestOptions()
            {
                Transport = mockTransport,
            };
            var perCallPolicies = new HttpPipelinePolicy[] { new AddHeaderPolicy("PerCall", "Builder") };
            var perRetryPolicies = new HttpPipelinePolicy[] { new AddHeaderPolicy("PerRetry", "Builder") };

            clientOptions.AddPolicy(new AddHeaderPolicy("BeforeTransport", "ClientOptions"), HttpPipelinePosition.BeforeTransport);
            clientOptions.AddPolicy(new AddHeaderPolicy("PerRetry", "ClientOptions"), HttpPipelinePosition.PerRetry);
            clientOptions.AddPolicy(new AddHeaderPolicy("PerCall", "ClientOptions"), HttpPipelinePosition.PerCall);

            var pipeline = HttpPipelineBuilder.Build(clientOptions, perCallPolicies, perRetryPolicies, null);

            var context = new RequestContext();
            context.AddPolicy(new AddHeaderPolicy("PerRetry", "RequestContext"), HttpPipelinePosition.PerRetry);
            context.AddPolicy(new AddHeaderPolicy("PerCall", "RequestContext"), HttpPipelinePosition.PerCall);
            context.AddPolicy(new AddHeaderPolicy("BeforeTransport", "RequestContext"), HttpPipelinePosition.BeforeTransport);

            var message = pipeline.CreateMessage(context);
            await pipeline.SendAsync(message, message.CancellationToken);

            Request request = mockTransport.Requests[0];

            Assert.IsTrue(request.Headers.TryGetValues("PerCall", out var perCallValues));
            Assert.AreEqual(3, perCallValues.Count());
            Assert.AreEqual("Builder", perCallValues.ElementAt(0));
            Assert.AreEqual("ClientOptions", perCallValues.ElementAt(1));
            Assert.AreEqual("RequestContext", perCallValues.ElementAt(2));

            Assert.IsTrue(request.Headers.TryGetValues("PerRetry", out var perRetryValues));
            Assert.AreEqual(3, perRetryValues.Count());
            Assert.AreEqual("Builder", perRetryValues.ElementAt(0));
            Assert.AreEqual("ClientOptions", perRetryValues.ElementAt(1));
            Assert.AreEqual("RequestContext", perRetryValues.ElementAt(2));

            Assert.IsTrue(request.Headers.TryGetValues("BeforeTransport", out var beforeTransportValues));
            Assert.AreEqual(2, beforeTransportValues.Count());
            Assert.AreEqual("ClientOptions", beforeTransportValues.ElementAt(0));
            Assert.AreEqual("RequestContext", beforeTransportValues.ElementAt(1));
        }

        [Test]
        public void ThrowsWhenFrozen()
        {
            RequestContext context = new RequestContext();
            context.AddClassifier(404, false);
            context.Freeze();
            Assert.Throws<InvalidOperationException>(() => context.AddClassifier(304, true));
        }

        [Test]
        public void AcceptsFullRangeofStatusCodes()
        {
            var context = new RequestContext();

            Assert.DoesNotThrow(() => context.AddClassifier(100, true));
            Assert.DoesNotThrow(() => context.AddClassifier(599, true));
        }

        [Test]
        [NonParallelizable]
        public async Task CanSuppressLoggingAsError()
        {
            // logging setup
            var listener = new TestEventListener();
            listener.EnableEvents(AzureCoreEventSource.Singleton, EventLevel.Verbose);

            // pipeline setup
            var response = new MockResponse(404);
            var mockTransport = new MockTransport(response);

            var classifier = new StatusCodeClassifier(stackalloc ushort[] { 200, 204, 304 });
            var pipeline = new HttpPipeline(mockTransport, new[] { new LoggingPolicy(logContent: true, int.MaxValue, HttpMessageSanitizer.Default, "Test SDK") });

            #region Snippet:Change404Category
            var context = new RequestContext();
            context.AddClassifier(404, isError: false);
            #endregion

            var message = pipeline.CreateMessage(context, classifier);

            await pipeline.SendAsync(message, context.CancellationToken);

            Assert.IsFalse(message.Response.IsError);

            EventWrittenEventArgs e = listener.SingleEventById(5); // ResponseEvent
            Assert.AreEqual(EventLevel.Informational, e.Level);
            Assert.AreNotEqual(EventLevel.Warning, e.Level);
            Assert.AreNotEqual(EventLevel.Error, e.Level);
            Assert.AreEqual("Response", e.EventName);
            Assert.AreEqual(e.GetProperty<int>("status"), 404);
        }

        [Test]
        [NonParallelizable]
        public async Task CanSuppressTracingAsError()
        {
            Activity activity = null;
            using var testListener = new TestDiagnosticListener("Azure.Core");

            // pipeline setup
            MockTransport mockTransport = new MockTransport(_ =>
            {
                activity = Activity.Current;
                MockResponse mockResponse = new MockResponse(409);
                return mockResponse;
            });

            var classifier = new StatusCodeClassifier(stackalloc ushort[] { 200, 204, 304 });
            var pipeline = new HttpPipeline(mockTransport, new[] { new RequestActivityPolicy(true, "Azure.Core.Tests", HttpMessageSanitizer.Default) });
            var context = new RequestContext();
            context.AddClassifier(409, isError: false);
            var message = pipeline.CreateMessage(context, classifier);

            await pipeline.SendAsync(message, context.CancellationToken);

            CollectionAssert.DoesNotContain(activity.Tags, new KeyValuePair<string, string>("otel.status_code", "ERROR"));
            CollectionAssert.Contains(activity.Tags, new KeyValuePair<string, string>("otel.status_code", "UNSET"));
        }

        #region Helpers
        private HttpMessage CreateMessage(int statusCode)
        {
            var request = new MockRequest();
            var message = new HttpMessage(request, null);
            message.Response = new MockResponse(statusCode);
            return message;
        }

        private class TestOptions : ClientOptions
        {
        }

        public class AddHeaderPolicy : HttpPipelineSynchronousPolicy
        {
            private string _headerName;
            private string _headerVaue;

            public AddHeaderPolicy(string headerName, string headerValue) : base()
            {
                _headerName = headerName;
                _headerVaue = headerValue;
            }

            public override void OnSendingRequest(HttpMessage message)
            {
                message.Request.Headers.Add(_headerName, _headerVaue);
            }
        }

        public class HeaderClassifier : ResponseClassificationHandler
        {
            public readonly string HeaderName = "ErrorCode";
            private readonly string _errorCodeValue = "LeaseNotAquired";

            public override bool TryClassify(HttpMessage message, out bool isError)
            {
                isError = false;

                if (message.Response.Status != 409)
                {
                    return false;
                }

                if (message.Response.Headers.TryGetValue(HeaderName, out string value) &&
                    _errorCodeValue == value)
                {
                    isError = true;
                }

                return true;
            }
        }

        #endregion
    }
}
