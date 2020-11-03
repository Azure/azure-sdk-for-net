// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Azure.Communication.Pipeline
{
    public class HMACAuthenticationPolicyTests : PolicyTestBase
    {
        private const string secret_key = "68810419818922fb0263dd6ee4b9c56537dbad914aa7324a119fce26778a286e";

        [Test]
        public async Task TestHMACPolicyProcess()
        {
            var shaValue = "47DEQpj8HBSa+/TImW+5JCeuQeRkm5NMpJWZG3hSuFU=";
            var authPolicy = new HMACAuthenticationPolicy(secret_key);
            var transport = new MockTransport(new MockResponse(200));
            await SendGetRequest(transport, authPolicy);
            var headers = transport.SingleRequest.Headers;

            Assert.True(headers.Contains("Date"));
            Assert.True(headers.Contains("x-ms-content-sha256"));
            Assert.True(headers.Contains("Authorization"));

            foreach (HttpHeader h in headers) {
                if (h.Name == "x-ms-content-sha256") {
                    Assert.AreEqual(h.Value, shaValue);
                } else if (h.Name == "Authorization") {
                    var authValueContains = h.Value.Contains("HMAC-SHA256 SignedHeaders=date;host;x-ms-content-sha256");
                    Assert.True(authValueContains);
                }
            }
        }
    }
}
