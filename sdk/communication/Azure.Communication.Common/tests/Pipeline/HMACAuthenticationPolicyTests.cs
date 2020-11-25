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
        private const string SecretKey = "68810419818922fb0263dd6ee4b9c56537dbad914aa7324a119fce26778a286e";

        [Test]
        public async Task TestHMACPolicyProcess()
        {
            var expectedShaValue = "47DEQpj8HBSa+/TImW+5JCeuQeRkm5NMpJWZG3hSuFU=";
            var authPolicy = new HMACAuthenticationPolicy(SecretKey);
            var transport = new MockTransport(new MockResponse(200));
            await SendGetRequest(transport, authPolicy);
            var headers = transport.SingleRequest.Headers;

            Assert.True(headers.Contains("Date"));
            Assert.True(headers.Contains("Authorization"));

            Assert.True(headers.TryGetValue("x-ms-content-sha256", out var shaValue));
            Assert.AreEqual(expectedShaValue, shaValue);

            var expectedAuthHeader = "HMAC-SHA256 SignedHeaders=date;host;x-ms-content-sha256";
            Assert.True(headers.TryGetValue("Authorization", out var authValue));
            Assert.NotNull(authValue);
            Assert.True(authValue!.Contains(expectedAuthHeader));
        }
    }
}
