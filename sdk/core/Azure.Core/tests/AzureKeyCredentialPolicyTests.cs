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
    public class AzureKeyCredentialPolicyTests : PolicyTestBase
    {
        [Test]
        public async Task SetsKey()
        {
            string keyValue = "test_key";
            string header = "api_key";
            var transport = new MockTransport(new MockResponse(200));
            var keyPolicy = new AzureKeyCredentialPolicy(new AzureKeyCredential(keyValue), header);

            await SendGetRequest(transport, keyPolicy);

            Assert.True(transport.SingleRequest.TryGetHeader(header, out var key));
            Assert.AreEqual(key, keyValue);
        }

        [Test]
        public async Task VerifyRetry()
        {
            string keyValue = "test_key";
            string header = "api_key";
            var transport = new MockTransport(new MockResponse(200), new MockResponse(200));
            var keyPolicy = new AzureKeyCredentialPolicy(new AzureKeyCredential(keyValue), header);

            using (Request request = transport.CreateRequest())
            {
                request.Method = RequestMethod.Get;
                var pipeline = new HttpPipeline(transport, new[] { keyPolicy });
                await pipeline.SendRequestAsync(request, CancellationToken.None);
                await pipeline.SendRequestAsync(request, CancellationToken.None);
            }

            Assert.True(transport.Requests[0].TryGetHeader(header, out var key));
            Assert.AreEqual(key, keyValue);
        }
    }
}
