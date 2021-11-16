// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Template.LLC;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class RequestContextTests
    {
        private readonly Uri _url = new Uri("https://example.azuretemplateservice.com");

        public TemplateServiceClient CreateClient(HttpPipelineTransport transport)
        {
            var options = new TemplateServiceClientOptions()
            {
                Transport = transport
            };

            // TODO: Fix ordering
            return new TemplateServiceClient(new MockCredential(), _url, options);
        }

        [Test]
        public void CanCastFromErrorOptions()
        {
            RequestContext context = ErrorOptions.Default;

            Assert.IsTrue(context.ErrorOptions == ErrorOptions.Default);
        }

        [Test]
        public void CanSetErrorOptions()
        {
            RequestContext context = new RequestContext { ErrorOptions = ErrorOptions.NoThrow };

            Assert.IsTrue(context.ErrorOptions == ErrorOptions.NoThrow);
        }

        [Test]
        public async Task CanAddPolicy_PerCall()
        {
            var resourceResponse = new MockResponse(200);

            var resource =
            @"{
                name = ""snoopy"",
                id = ""beagle""
            }";

            resourceResponse.SetContent(resource);

            var mockTransport = new MockTransport(resourceResponse);
            TemplateServiceClient client = CreateClient(mockTransport);

            var context = new RequestContext();
            context.AddPolicy(new AddHeaderPolicy("PerCallHeader", "Value"), HttpPipelinePosition.PerCall);

            Response response = await client.GetAsync("snoopy", context);

            Request request = mockTransport.Requests[0];
            Assert.IsTrue(request.Headers.TryGetValues("PerCallHeader", out var values));
            Assert.AreEqual(1, values.Count());
            Assert.AreEqual("Value", values.ElementAt(0));
        }

        [Test]
        public async Task CanAddPolicy_PerRetry()
        {
            var retryResponse = new MockResponse(408); // Request Timeout
            var resourceResponse = new MockResponse(200);

            var resource =
            @"{
                name = ""snoopy"",
                id = ""beagle""
            }";

            resourceResponse.SetContent(resource);

            // retry twice
            var mockTransport = new MockTransport(retryResponse, retryResponse, resourceResponse);
            TemplateServiceClient client = CreateClient(mockTransport);

            var context = new RequestContext();
            context.AddPolicy(new AddHeaderPolicy("PerRetryHeader", "Value"), HttpPipelinePosition.PerRetry);

            Response response = await client.GetAsync("snoopy", context);

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
            var resourceResponse = new MockResponse(200);

            var resource =
            @"{
                name = ""snoopy"",
                id = ""beagle""
            }";

            resourceResponse.SetContent(resource);

            // retry twice
            var mockTransport = new MockTransport(retryResponse, retryResponse, resourceResponse);
            TemplateServiceClient client = CreateClient(mockTransport);

            var context = new RequestContext();
            context.AddPolicy(new AddHeaderPolicy("BeforeTransportHeader", "Value"), HttpPipelinePosition.BeforeTransport);

            Response response = await client.GetAsync("snoopy", context);

            Request request = mockTransport.Requests[0];
            Assert.IsTrue(request.Headers.TryGetValues("BeforeTransportHeader", out var values));
            Assert.AreEqual(3, values.Count());
            Assert.AreEqual("Value", values.ElementAt(0));
            Assert.AreEqual("Value", values.ElementAt(1));
            Assert.AreEqual("Value", values.ElementAt(2));
        }

        [Test]
        public async Task CanAddPolicies_AllPositions()
        {
            var retryResponse = new MockResponse(408); // Request Timeout
            var resourceResponse = new MockResponse(200);

            var resource =
            @"{
                name = ""snoopy"",
                id = ""beagle""
            }";

            resourceResponse.SetContent(resource);

            // retry twice -- this will add the header three times.
            var mockTransport = new MockTransport(retryResponse, retryResponse, resourceResponse);
            TemplateServiceClient client = CreateClient(mockTransport);

            var context = new RequestContext();
            context.AddPolicy(new AddHeaderPolicy("PerCallHeader1", "PerCall1"), HttpPipelinePosition.PerCall);
            context.AddPolicy(new AddHeaderPolicy("PerCallHeader2", "PerCall2"), HttpPipelinePosition.PerCall);
            context.AddPolicy(new AddHeaderPolicy("PerRetryHeader", "PerRetry"), HttpPipelinePosition.PerRetry);
            context.AddPolicy(new AddHeaderPolicy("BeforeTransportHeader", "BeforeTransport"), HttpPipelinePosition.BeforeTransport);

            // TODO: Should be Get<Resource>
            Response response = await client.GetAsync("snoopy", context);

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
            var retryResponse = new MockResponse(408); // Request Timeout
            var resourceResponse = new MockResponse(200);
            var resource =
            @"{
                name = ""snoopy"",
                id = ""beagle""
            }";
            resourceResponse.SetContent(resource);

            var mockTransport = new MockTransport(retryResponse, resourceResponse);
            var options = new TemplateServiceClientOptions()
            {
                Transport = mockTransport,
            };

            var perCallPolicies = new HttpPipelinePolicy[] { new AddHeaderPolicy("PerCall", "Builder") };
            var perRetryPolicies = new HttpPipelinePolicy[] { new AddHeaderPolicy("PerRetry", "Builder") };

            options.AddPolicy(new AddHeaderPolicy("BeforeTransport", "ClientOptions"), HttpPipelinePosition.BeforeTransport);
            options.AddPolicy(new AddHeaderPolicy("PerRetry", "ClientOptions"), HttpPipelinePosition.PerRetry);
            options.AddPolicy(new AddHeaderPolicy("PerCall", "ClientOptions"), HttpPipelinePosition.PerCall);

            var pipeline = HttpPipelineBuilder.Build(options, perCallPolicies, perRetryPolicies, null);

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
            Assert.AreEqual(6, perRetryValues.Count());
            Assert.AreEqual("Builder", perRetryValues.ElementAt(0));
            Assert.AreEqual("ClientOptions", perRetryValues.ElementAt(1));
            Assert.AreEqual("RequestContext", perRetryValues.ElementAt(2));
            Assert.AreEqual("Builder", perRetryValues.ElementAt(3));
            Assert.AreEqual("ClientOptions", perRetryValues.ElementAt(4));
            Assert.AreEqual("RequestContext", perRetryValues.ElementAt(5));

            Assert.IsTrue(request.Headers.TryGetValues("BeforeTransport", out var beforeTransportValues));
            Assert.AreEqual(4, beforeTransportValues.Count());
            Assert.AreEqual("ClientOptions", beforeTransportValues.ElementAt(0));
            Assert.AreEqual("RequestContext", beforeTransportValues.ElementAt(1));
            Assert.AreEqual("ClientOptions", beforeTransportValues.ElementAt(2));
            Assert.AreEqual("RequestContext", beforeTransportValues.ElementAt(3));
        }

        [Test]
        public async Task ThrowsIfUsePipelineConstructor()
        {
            HttpPipeline pipeline = new HttpPipeline(new MockTransport());

            var context = new RequestContext();
            context.AddPolicy(new AddHeaderPolicy("PerCallHeader", "Value"), HttpPipelinePosition.PerCall);

            var message = pipeline.CreateMessage(context);

            bool throws = false;
            try
            {
                await pipeline.SendAsync(message, context.CancellationToken);
            }
            catch (InvalidOperationException)
            {
                throws = true;
            }

            Assert.IsTrue(throws);
        }

        #region Helpers
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
        #endregion
    }
}
