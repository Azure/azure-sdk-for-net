// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.Testing;
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
    }
}
