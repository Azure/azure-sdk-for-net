// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Azure.Identity.Tests
{
    public class DefaultAzureCredentialImdsRetryPolicyTests : SyncAsyncPolicyTestBase
    {
        public DefaultAzureCredentialImdsRetryPolicyTests(bool isAsync) : base(isAsync)
        { }

        [Test]
        public async Task NoRetriesOnImdsProbeRequestButNormalRetriesAfter()
        {
            int tryCount = 0;
            var options = new DefaultAzureCredentialOptions();
            options.Retry.MaxRetries = 7;
            HttpPipelinePolicy policy = new DefaultAzureCredentialImdsRetryPolicy(options.Retry, new MockDelayStrategy((resp, count) => TimeSpan.Zero));
            MockTransport mockTransport = CreateMockTransport(req =>
            {
                tryCount++;
                if (!req.Headers.TryGetValue(ImdsManagedIdentityProbeSource.metadataHeaderName, out _))
                {
                    return new MockResponse(400).WithJson("""{"error":"invalid_request","error_description":"Required query variable 'resource' is missing"}""");
                }
                return new MockResponse(500);
            });
            Uri imdsUri = new Uri(ImdsManagedIdentityProbeSource.GetImdsUri().ToString() + "?api-version=2018-02-01&resource=test");

            // The first request should only try once
            var response = await SendGetRequest(mockTransport, policy, uri: imdsUri);
            Assert.AreEqual(1, tryCount);
            Assert.Greater(options.Retry.MaxRetries, 1);
            Assert.AreEqual(400, response.Status);

            tryCount = 0;
            // Subsequent requests should default to the retry options behavior
            response = await SendRequestAsync(mockTransport, req =>
            {
                req.Method = RequestMethod.Get;
                req.Uri.Reset(imdsUri);
                req.Headers.Add(ImdsManagedIdentityProbeSource.metadataHeaderName, "true");
            }, policy);
            Assert.AreEqual(options.Retry.MaxRetries + 1, tryCount);
            Assert.AreEqual(500, response.Status);

            tryCount = 0;
            response = await SendRequestAsync(mockTransport, req =>
            {
                req.Method = RequestMethod.Get;
                req.Uri.Reset(imdsUri);
                req.Headers.Add(ImdsManagedIdentityProbeSource.metadataHeaderName, "true");
            }, policy);
            Assert.AreEqual(options.Retry.MaxRetries + 1, tryCount);
            Assert.AreEqual(500, response.Status);
        }

        [Test]
        public async Task NormalRetryBehaviorForNonImdsUri()
        {
            int tryCount = 0;
            var options = new DefaultAzureCredentialOptions();
            options.Retry.MaxRetries = 7;
            HttpPipelinePolicy policy = new DefaultAzureCredentialImdsRetryPolicy(options.Retry, new MockDelayStrategy((resp, count) => TimeSpan.Zero));
            MockTransport mockTransport = CreateMockTransport(req =>
            {
                tryCount++;
                return new MockResponse(500);
            });
            Uri imdsUri = new Uri(ImdsManagedIdentityProbeSource.GetImdsUri().ToString() + "?api-version=2018-02-01&resource=test");

            // non-IMDS requests should default to the retry options behavior
            var response = await SendGetRequest(mockTransport, policy);
            Assert.AreEqual(options.Retry.MaxRetries + 1, tryCount);
            Assert.AreEqual(500, response.Status);

            tryCount = 0;
            response = await SendGetRequest(mockTransport, policy);
            Assert.AreEqual(options.Retry.MaxRetries + 1, tryCount);
            Assert.AreEqual(500, response.Status);
        }

        public class MockDelayStrategy : DelayStrategy
        {
            private readonly Func<Response, int, TimeSpan> _delayFactory;

            public MockDelayStrategy(Func<Response, int, TimeSpan> delayFactory)
            {
                _delayFactory = delayFactory;
            }
            protected override TimeSpan GetNextDelayCore(Response response, int retryNumber)
                => _delayFactory(response, retryNumber);
        }
    }
}
