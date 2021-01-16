// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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

            Assert.True(request.TryGetHeader("x-ms-client-request-id", out string requestId));
            Assert.True(request.TryGetHeader("x-ms-return-client-request-id", out string returnRequestId));
            Assert.AreEqual(request.ClientRequestId, requestId);
            Assert.AreEqual("true", returnRequestId);
        }

        [Test]
        public async Task ReadsRequestIdValueOfRequest()
        {
            var policy = new Mock<HttpPipelineSynchronousPolicy>();
            policy.CallBase = true;
            policy.Setup(p => p.OnReceivedResponse(It.IsAny<HttpMessage>()))
                .Callback<HttpMessage>(message =>
                {
                    Assert.AreEqual("ExternalClientId",message.Request.ClientRequestId);
                    Assert.True(message.Request.TryGetHeader("x-ms-client-request-id", out string requestId));
                    Assert.AreEqual("ExternalClientId", requestId);
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

            Assert.AreEqual(transport.SingleRequest.ClientRequestId, "custom-id");
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

            Assert.AreEqual(transport.SingleRequest.ClientRequestId, "nested-custom-id");
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

            Assert.IsNotEmpty(transport.SingleRequest.ClientRequestId);
        }
    }
}
