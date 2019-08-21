// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.Testing;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class ActivityRequestIdHeadersPolicyTests : SyncAsyncPolicyTestBase
    {
        public ActivityRequestIdHeadersPolicyTests(bool isAsync) : base(isAsync)
        {
        }
        
        [Test]

        public async Task AllowsClientRequestIdToBeSet()
        {
            var mockTransport = new MockTransport(new MockResponse(200));

            var activity = new Activity("Azure.RequestId");

            activity.Start();
            activity.AddTag("X-MS-CLIENT-REQUEST-ID", "CustomRequestId");

            await SendGetRequest(mockTransport, new ActivityRequestIdHeadersPolicy());

            activity.Stop();

            Assert.AreEqual(mockTransport.SingleRequest.ClientRequestId, "CustomRequestId");
        }

        [Test]

        public async Task AllowsOtherTelemetryHeadersToBeSet()
        {
            var mockTransport = new MockTransport(new MockResponse(200));

            var activity = new Activity("Azure.RequestId");

            activity.Start();
            activity.AddTag("x-ms-request-id", "CustomRequestId");

            await SendGetRequest(mockTransport, new ActivityRequestIdHeadersPolicy());

            activity.Stop();

            Assert.True(mockTransport.SingleRequest.TryGetHeader("X-MS-REQUEST-ID", out string value));
            Assert.AreEqual(value, "CustomRequestId");
        }

        [Test]

        public async Task IgnoresUnsupportedHeaders()
        {
            var mockTransport = new MockTransport(new MockResponse(200));

            var activity = new Activity("Azure.RequestId");

            activity.Start();
            activity.AddTag("X-MS-RANDOM-ID", "CustomRequestId");

            await SendGetRequest(mockTransport, new ActivityRequestIdHeadersPolicy());

            activity.Stop();

            Assert.False(mockTransport.SingleRequest.TryGetHeader("X-MS-REQUEST-ID", out string value));
        }
    }
}
