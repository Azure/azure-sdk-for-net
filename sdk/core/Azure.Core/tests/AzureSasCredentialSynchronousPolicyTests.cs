// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
        [Ignore("Re-enable when AzureSasCredential change merges")]
        public async Task VerifyRetryAfterSasCredentialUpdateOperation()
        {
            // Arrange
            const string INITIAL_QUERY_URI = "?foo=bar";
            const string FIRST_SIGNATURE_VALUE = "?sig=first_signature_value";
            const string SECOND_SIGNATURE_VALUE = "?sig=second_signature_value";
            int callCount = 0;
            var azureSasCredential = new AzureSasCredential(FIRST_SIGNATURE_VALUE);
            var transport = new MockTransport((req) =>
            {
                if (callCount++ == 0)
                {
                    Assert.AreEqual("?foo=bar&sig=first_signature_value", req.Uri.Query);
                    Thread.Sleep(100);
                    azureSasCredential.Update(SECOND_SIGNATURE_VALUE);
                    return new MockResponse(429);
                }
                else
                {
                    Assert.AreEqual("?foo=bar&sig=second_signature_value", req.Uri.Query);
                    return new MockResponse(200);
                }
            });
            var sasPolicy = new AzureSasCredentialSynchronousPolicy(azureSasCredential);

            // Act + Assert
            using (Request request = transport.CreateRequest())
            {
                request.Method = RequestMethod.Get;
                request.Uri.Query = INITIAL_QUERY_URI;
                var pipeline = new HttpPipeline(transport, new HttpPipelinePolicy[] { new DefaultRetryPolicy(new RetryOptions()), sasPolicy });

                Response response = await pipeline.SendRequestAsync(request, CancellationToken.None).ConfigureAwait(false);
                Assert.AreEqual((int)HttpStatusCode.OK, response.Status);
            }
        }
    }
}
