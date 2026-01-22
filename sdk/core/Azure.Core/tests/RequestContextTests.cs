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

            Assert.That(context.ErrorOptions, Is.EqualTo(ErrorOptions.Default));
        }

        [Test]
        public void CanSetErrorOptions()
        {
            #region Snippet:ErrorOptionsNoThrow
            RequestContext context = new RequestContext { ErrorOptions = ErrorOptions.NoThrow };
            #endregion

            Assert.That(context.ErrorOptions, Is.EqualTo(ErrorOptions.NoThrow));
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
            Assert.That(request.Headers.TryGetValues("PerCallHeader", out var values), Is.True);
            Assert.That(values.Count(), Is.EqualTo(1));
            Assert.That(values.ElementAt(0), Is.EqualTo("Value"));
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
            Assert.That(request.Headers.TryGetValues("PerRetryHeader", out var values), Is.True);
            Assert.That(values.Count(), Is.EqualTo(3));
            Assert.That(values.ElementAt(0), Is.EqualTo("Value"));
            Assert.That(values.ElementAt(1), Is.EqualTo("Value"));
            Assert.That(values.ElementAt(2), Is.EqualTo("Value"));
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

            Assert.That(request.Headers.TryGetValues("BeforeTransportHeader", out var values), Is.True);
            Assert.That(values.Count(), Is.EqualTo(3));
            Assert.That(values.ElementAt(0), Is.EqualTo("Value"));
            Assert.That(values.ElementAt(1), Is.EqualTo("Value"));
            Assert.That(values.ElementAt(2), Is.EqualTo("Value"));
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

            Assert.That(request.Headers.TryGetValues("PerCallHeader1", out var perCall1Values), Is.True);
            Assert.That(perCall1Values.Count(), Is.EqualTo(1));
            Assert.That(perCall1Values.ElementAt(0), Is.EqualTo("PerCall1"));

            Assert.That(request.Headers.TryGetValues("PerCallHeader2", out var perCall2Values), Is.True);
            Assert.That(perCall2Values.Count(), Is.EqualTo(1));
            Assert.That(perCall2Values.ElementAt(0), Is.EqualTo("PerCall2"));

            Assert.That(request.Headers.TryGetValues("PerRetryHeader", out var perRetryValues), Is.True);
            Assert.That(perRetryValues.ElementAt(0), Is.EqualTo("PerRetry"));
            Assert.That(perRetryValues.ElementAt(1), Is.EqualTo("PerRetry"));
            Assert.That(perRetryValues.ElementAt(2), Is.EqualTo("PerRetry"));

            Assert.That(request.Headers.TryGetValues("BeforeTransportHeader", out var beforeTransportValues), Is.True);
            Assert.That(beforeTransportValues.ElementAt(0), Is.EqualTo("BeforeTransport"));
            Assert.That(beforeTransportValues.ElementAt(1), Is.EqualTo("BeforeTransport"));
            Assert.That(beforeTransportValues.ElementAt(2), Is.EqualTo("BeforeTransport"));
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

            Assert.That(request.Headers.TryGetValues("PerCall", out var perCallValues), Is.True);
            Assert.That(perCallValues.Count(), Is.EqualTo(3));
            Assert.That(perCallValues.ElementAt(0), Is.EqualTo("Builder"));
            Assert.That(perCallValues.ElementAt(1), Is.EqualTo("ClientOptions"));
            Assert.That(perCallValues.ElementAt(2), Is.EqualTo("RequestContext"));

            Assert.That(request.Headers.TryGetValues("PerRetry", out var perRetryValues), Is.True);
            Assert.That(perRetryValues.Count(), Is.EqualTo(3));
            Assert.That(perRetryValues.ElementAt(0), Is.EqualTo("Builder"));
            Assert.That(perRetryValues.ElementAt(1), Is.EqualTo("ClientOptions"));
            Assert.That(perRetryValues.ElementAt(2), Is.EqualTo("RequestContext"));

            Assert.That(request.Headers.TryGetValues("BeforeTransport", out var beforeTransportValues), Is.True);
            Assert.That(beforeTransportValues.Count(), Is.EqualTo(2));
            Assert.That(beforeTransportValues.ElementAt(0), Is.EqualTo("ClientOptions"));
            Assert.That(beforeTransportValues.ElementAt(1), Is.EqualTo("RequestContext"));
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

            Assert.That(message.Response.IsError, Is.False);

            EventWrittenEventArgs e = listener.SingleEventById(5); // ResponseEvent
            Assert.That(e.Level, Is.EqualTo(EventLevel.Informational));
            Assert.That(e.Level, Is.Not.EqualTo(EventLevel.Warning));
            Assert.That(e.Level, Is.Not.EqualTo(EventLevel.Error));
            Assert.That(e.EventName, Is.EqualTo("Response"));
            Assert.That(e.GetProperty<int>("status"), Is.EqualTo(404));
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

            Assert.That(activity.Tags, Has.No.Member(new KeyValuePair<string, string>("otel.status_code", "ERROR")));
            Assert.That(activity.Tags, Has.Member(new KeyValuePair<string, string>("otel.status_code", "UNSET")));
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
