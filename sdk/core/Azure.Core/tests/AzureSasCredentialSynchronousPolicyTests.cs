// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class AzureSasCredentialSynchronousPolicyTests : PolicyTestBase
    {
        private const string INITIAL_QUERY_URI = "?foo=bar";
        private const string FIRST_SIGNATURE_VALUE = "sig=first_signature_value";
        private const string SECOND_SIGNATURE_VALUE = "sig=second_signature_value";
        private const string THIRD_SIGNATURE_VALUE = "sig=third_signature_value";

        [TestCase("sig=test_signature_value")]
        [TestCase("?sig=test_signature_value")]
        public async Task SetsSignatureEmptyQuery(string signatureValue)
        {
            var transport = new MockTransport(new MockResponse(200));
            var sasPolicy = new AzureSasCredentialSynchronousPolicy(new AzureSasCredential(signatureValue));

            await SendGetRequest(transport, sasPolicy);

            Assert.AreEqual("?sig=test_signature_value", transport.SingleRequest.Uri.Query);
        }

        [TestCase("sig=test_signature_value")]
        [TestCase("?sig=test_signature_value")]
        public async Task SetsSignatureNonEmptyQuery(string signatureValue)
        {
            var transport = new MockTransport(new MockResponse(200));
            var sasPolicy = new AzureSasCredentialSynchronousPolicy(new AzureSasCredential(signatureValue));
            string query = "?foo=bar";

            await SendGetRequest(transport, sasPolicy, query: query);

            Assert.AreEqual($"?foo=bar&sig=test_signature_value", transport.SingleRequest.Uri.Query);
        }

        [TestCase("sig=test_signature_value")]
        [TestCase("?sig=test_signature_value")]
        public async Task VerifyRetryEmptyQuery(string signatureValue)
        {
            var transport = new MockTransport(new MockResponse(200), new MockResponse(200));
            var sasPolicy = new AzureSasCredentialSynchronousPolicy(new AzureSasCredential(signatureValue));

            using (Request request = transport.CreateRequest())
            {
                request.Method = RequestMethod.Get;
                var pipeline = new HttpPipeline(transport, new[] { sasPolicy });
                await pipeline.SendRequestAsync(request, CancellationToken.None);
                await pipeline.SendRequestAsync(request, CancellationToken.None);
            }

            Assert.AreEqual("?sig=test_signature_value", transport.Requests[0].Uri.Query);
        }

        [TestCase("sig=test_signature_value")]
        [TestCase("?sig=test_signature_value")]
        public async Task VerifyRetryNonEmptyQuery(string signatureValue)
        {
            var transport = new MockTransport(new MockResponse(200), new MockResponse(200));
            var sasPolicy = new AzureSasCredentialSynchronousPolicy(new AzureSasCredential(signatureValue));
            string query = "?foo=bar";

            using (Request request = transport.CreateRequest())
            {
                request.Method = RequestMethod.Get;
                request.Uri.Query = query;
                var pipeline = new HttpPipeline(transport, new[] { sasPolicy });
                await pipeline.SendRequestAsync(request, CancellationToken.None);
                await pipeline.SendRequestAsync(request, CancellationToken.None);
            }

            Assert.AreEqual("?foo=bar&sig=test_signature_value", transport.Requests[0].Uri.Query);
        }

        [TestCase("sig=test_signature_value")]
        [TestCase("?sig=test_signature_value")]
        public async Task IgnoreDuplicateSas(string signatureValue)
        {
            var transport = new MockTransport(new MockResponse(200), new MockResponse(200));
            var sasPolicy = new AzureSasCredentialSynchronousPolicy(new AzureSasCredential(signatureValue));
            string query = $"?{signatureValue}";

            using (Request request = transport.CreateRequest())
            {
                request.Method = RequestMethod.Get;
                request.Uri.Query = query;
                var pipeline = new HttpPipeline(transport, new[] { sasPolicy });
                await pipeline.SendRequestAsync(request, CancellationToken.None);
            }

            Assert.AreEqual(query, transport.Requests[0].Uri.Query);
        }

        [Test]
        public async Task VerifyRetryAfterMultipleSasCredentialUpdate()
        {
            // Arrange

            string[] signatures = new string[] { FIRST_SIGNATURE_VALUE, SECOND_SIGNATURE_VALUE, THIRD_SIGNATURE_VALUE };
            int callCount = 0;
            var azureSasCredential = new AzureSasCredential(FIRST_SIGNATURE_VALUE);

            var transport = new MockTransport((req) =>
            {
                Assert.AreEqual($"{INITIAL_QUERY_URI}&{signatures[callCount]}", req.Uri.Query);
                if (callCount < 2)
                {
                    azureSasCredential.Update(signatures[callCount + 1]);
                }
                return callCount++ == 2 ? new MockResponse(200) : new MockResponse(429);
            });

            var sasPolicy = new AzureSasCredentialSynchronousPolicy(azureSasCredential);

            // Act + Assert
            using (Request request = transport.CreateRequest())
            {
                request.Method = RequestMethod.Get;
                request.Uri.Query = INITIAL_QUERY_URI;
                var pipeline = new HttpPipeline(transport, new HttpPipelinePolicy[] { new RetryPolicy(delayStrategy: Delay.CreateExponentialDelay(TimeSpan.FromMilliseconds(100))), sasPolicy });

                Response response = await pipeline.SendRequestAsync(request, CancellationToken.None).ConfigureAwait(false);
                Assert.AreEqual((int)HttpStatusCode.OK, response.Status);
            }
        }
    }
}
