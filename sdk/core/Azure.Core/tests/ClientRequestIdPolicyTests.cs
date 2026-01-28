// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Moq;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class ClientRequestIdPolicyTests : PolicyTestBase
    {
        [Test]
        public async Task SetsHeaders()
        {
            var mockTransport = new MockTransport();
            Task<Response> task = SendGetRequest(mockTransport, ClientRequestIdPolicy.Shared);
            MockRequest request = await mockTransport.RequestGate.Cycle(new MockResponse(200));
            await task;

            Assert.That(request.TryGetHeader("x-ms-client-request-id", out string requestId), Is.True);
            Assert.That(request.TryGetHeader("x-ms-return-client-request-id", out string returnRequestId), Is.True);
            Assert.That(requestId, Is.EqualTo(request.ClientRequestId));
            Assert.That(returnRequestId, Is.EqualTo("true"));
        }

        [Test]
        public async Task ReadsRequestIdValueOfRequest()
        {
            var policy = new Mock<HttpPipelineSynchronousPolicy>();
            policy.CallBase = true;
            policy.Setup(p => p.OnReceivedResponse(It.IsAny<HttpMessage>()))
                .Callback<HttpMessage>(message =>
                {
                    Assert.That(message.Request.ClientRequestId, Is.EqualTo("ExternalClientId"));
                    Assert.That(message.Request.TryGetHeader("x-ms-client-request-id", out string requestId), Is.True);
                    Assert.That(requestId, Is.EqualTo("ExternalClientId"));
                }).Verifiable();

            var transport = new MockTransport(new MockResponse(200));
            var pipeline = new HttpPipeline(transport, new[] { ReadClientRequestIdPolicy.Shared, policy.Object });

            using (Request request = pipeline.CreateRequest())
            {
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri("http://example.com"));
                request.Headers.Add("x-ms-client-request-id", "ExternalClientId");
                await pipeline.SendRequestAsync(request, CancellationToken.None);
            }

            policy.Verify();
        }

        [Test]
        public async Task ReadsRequestIdValueOfScope()
        {
            var transport = new MockTransport(r => new MockResponse(200));

            using (HttpPipeline.CreateClientRequestIdScope("custom-id"))
            {
                await SendGetRequest(transport, ReadClientRequestIdPolicy.Shared);
            }

            Assert.That(transport.SingleRequest.ClientRequestId, Is.EqualTo("custom-id"));
        }

        [Test]
        public async Task ReadsRequestIdValueOfNestedScope()
        {
            var transport = new MockTransport(r => new MockResponse(200));

            using (HttpPipeline.CreateClientRequestIdScope("custom-id"))
            using (HttpPipeline.CreateClientRequestIdScope("nested-custom-id"))
            {
                await SendGetRequest(transport, ReadClientRequestIdPolicy.Shared);
            }

            Assert.That(transport.SingleRequest.ClientRequestId, Is.EqualTo("nested-custom-id"));
        }

        [Test]
        public async Task CanResetRequestIdValueOfParentScope()
        {
            var transport = new MockTransport(r => new MockResponse(200));

            using (HttpPipeline.CreateClientRequestIdScope("custom-id"))
            using (HttpPipeline.CreateClientRequestIdScope(null))
            {
                await SendGetRequest(transport, ReadClientRequestIdPolicy.Shared);
            }

            Assert.That(transport.SingleRequest.ClientRequestId, Is.Not.Empty);
            Assert.That(transport.SingleRequest.ClientRequestId, Is.Not.EqualTo("custom-id"));
        }

        [Test]
        public void ThrowsIfRequestIdPropertyIsNotAString()
        {
            var transport = new MockTransport(r => new MockResponse(200));

            using (HttpPipeline.CreateHttpMessagePropertiesScope(
                new Dictionary<string, object> { { ReadClientRequestIdPolicy.MessagePropertyKey, new List<string>() } }))
            {
                Assert.ThrowsAsync<ArgumentException>(async () => await SendGetRequest(transport, ReadClientRequestIdPolicy.Shared));
            }
        }
    }
}
