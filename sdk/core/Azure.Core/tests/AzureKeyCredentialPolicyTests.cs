// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.Testing;
using NUnit.Framework;

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
    }
}
