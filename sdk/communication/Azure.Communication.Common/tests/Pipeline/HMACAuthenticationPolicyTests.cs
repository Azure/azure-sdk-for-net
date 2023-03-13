// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Azure.Communication.Pipeline
{
    [ExcludeFromCodeCoverage]
    public class HMACAuthenticationPolicyTests : PolicyTestBase
    {
        private const string SecretKey = "68810419818922fb0263dd6ee4b9c56537dbad914aa7324a119fce26778a286e";

        [Test]
        public async Task TestHMACPolicyProcess()
        {
            var expectedShaValue = "47DEQpj8HBSa+/TImW+5JCeuQeRkm5NMpJWZG3hSuFU=";
            var authPolicy = new HMACAuthenticationPolicy(new AzureKeyCredential(SecretKey));
            var transport = new MockTransport(new MockResponse(200));
            await SendGetRequest(transport, authPolicy);
            var headers = transport.SingleRequest.Headers;

            Assert.True(headers.Contains("x-ms-date"));
            Assert.True(headers.Contains("Authorization"));

            Assert.True(headers.TryGetValue("x-ms-content-sha256", out var shaValue));
            Assert.AreEqual(expectedShaValue, shaValue);

            var expectedAuthHeader = "HMAC-SHA256 SignedHeaders=x-ms-date;host;x-ms-content-sha256";
            Assert.True(headers.TryGetValue("Authorization", out var authValue));
            Assert.NotNull(authValue);
            Assert.True(authValue!.Contains(expectedAuthHeader));
        }
    }
}
