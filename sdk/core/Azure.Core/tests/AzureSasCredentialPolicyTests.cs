// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Azure.Core.Tests
{
    public class AzureSasCredentialPolicyTests : PolicyTestBase
    {
        [Test]
        public async Task SetsSignatureEmptyQuery()
        {
            string signatureValue = "sig=test_signature_value";
            var transport = new MockTransport(new MockResponse(200));
            var sasPolicy = new AzureSasCredentialPolicy(new AzureSasCredential(signatureValue));

            await SendGetRequest(transport, sasPolicy);

            Assert.AreEqual($"?{signatureValue}", transport.SingleRequest.Uri.Query);
        }

        [Test]
        public async Task SetsSignatureNonEmptyQuery()
        {
            string signatureValue = "sig=test_signature_value";
            var transport = new MockTransport(new MockResponse(200));
            var sasPolicy = new AzureSasCredentialPolicy(new AzureSasCredential(signatureValue));
            string query = "?foo=bar";

            await SendGetRequest(transport, sasPolicy, query: query);

            Assert.AreEqual($"{query}&{signatureValue}", transport.SingleRequest.Uri.Query);
        }

        [Test]
        public async Task SetsSignatureThatHasQuestionMarkEmptyQuery()
        {
            string signatureValue = "?sig=test_signature_value";
            var transport = new MockTransport(new MockResponse(200));
            var sasPolicy = new AzureSasCredentialPolicy(new AzureSasCredential(signatureValue));

            await SendGetRequest(transport, sasPolicy);

            Assert.AreEqual(signatureValue, transport.SingleRequest.Uri.Query);
        }

        [Test]
        public async Task SetsSignatureThatHasQuestionMarkNonEmptyQuery()
        {
            string signatureValue = "?sig=test_signature_value";
            var transport = new MockTransport(new MockResponse(200));
            var sasPolicy = new AzureSasCredentialPolicy(new AzureSasCredential(signatureValue));
            string query = "?foo=bar";

            await SendGetRequest(transport, sasPolicy, query: query);

            Assert.AreEqual("?foo=bar&sig=test_signature_value", transport.SingleRequest.Uri.Query);
        }

        [Test]
        public async Task VerifyRetry()
        {
            string signatureValue = "sig=test_signature_value";
            var transport = new MockTransport(new MockResponse(200), new MockResponse(200));
            var sasPolicy = new AzureSasCredentialPolicy(new AzureSasCredential(signatureValue));

            using (Request request = transport.CreateRequest())
            {
                request.Method = RequestMethod.Get;
                var pipeline = new HttpPipeline(transport, new[] { sasPolicy });
                await pipeline.SendRequestAsync(request, CancellationToken.None);
                await pipeline.SendRequestAsync(request, CancellationToken.None);
            }

            Assert.AreEqual($"?{signatureValue}", transport.Requests[0].Uri.Query);
        }
    }
}
