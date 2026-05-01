// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Data.AppConfiguration.Tests
{
    public class CustomHeadersPolicyTests : SyncAsyncPolicyTestBase
    {
        public CustomHeadersPolicyTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task AllowsClientRequestIdToBeSet()
        {
            var mockTransport = new MockTransport(new MockResponse(200));

            var activity = new Activity("Azure.CustomDiagnosticHeaders");

            activity.Start();
            activity.AddTag("X-MS-CLIENT-REQUEST-ID", "CustomRequestId");

            await SendGetRequest(mockTransport, new CustomHeadersPolicy());

            activity.Stop();

            Assert.That(mockTransport.SingleRequest.ClientRequestId, Is.EqualTo("CustomRequestId"));
        }

        [Test]
        public async Task AllowsCorrelationRequestIdToBeSet()
        {
            var mockTransport = new MockTransport(new MockResponse(200));

            var activity = new Activity("Azure.CustomDiagnosticHeaders");

            activity.Start();
            activity.AddTag("x-ms-correlation-request-id", "CorrelationRequestId");

            await SendGetRequest(mockTransport, new CustomHeadersPolicy());

            activity.Stop();

            Assert.That(mockTransport.SingleRequest.Headers.TryGetValue("x-ms-correlation-request-id", out string value), Is.True);
            Assert.That(value, Is.EqualTo("CorrelationRequestId"));
        }

        [Test]
        public async Task AllowsCorrelationContextToBeSet()
        {
            var mockTransport = new MockTransport(new MockResponse(200));

            var activity = new Activity("Azure.CustomDiagnosticHeaders");

            activity.Start();
            activity.AddTag("correlation-context", "CorrelationContextValue");

            await SendGetRequest(mockTransport, new CustomHeadersPolicy());

            activity.Stop();

            Assert.That(mockTransport.SingleRequest.Headers.TryGetValue("correlation-context", out string value), Is.True);
            Assert.That(value, Is.EqualTo("CorrelationContextValue"));
        }

        [Test]
        public async Task IgnoresUnsupportedHeaders()
        {
            var mockTransport = new MockTransport(new MockResponse(200));

            var activity = new Activity("Azure.CustomDiagnosticHeaders");

            activity.Start();
            activity.AddTag("X-MS-RANDOM-ID", "RandomValue");

            await SendGetRequest(mockTransport, new CustomHeadersPolicy());

            activity.Stop();

            Assert.That(mockTransport.SingleRequest.Headers.TryGetValue("X-MS-RANDOM-ID", out string value), Is.False);
        }
    }
}
