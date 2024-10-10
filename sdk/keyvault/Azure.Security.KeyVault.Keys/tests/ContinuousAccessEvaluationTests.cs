// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Security.KeyVault.Tests;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Keys.Tests
{
    [NonParallelizable]
    internal class ContinuousAccessEvaluationTests : ContinuousAccessEvaluationTestsBase
    {
        [SetUp]
        public void Setup()
        {
            ChallengeBasedAuthenticationPolicy.ClearCache();
        }

        [Test]
        [TestCase(@"Bearer realm="""", authorization_uri=""https://login.microsoftonline.com/common/oauth2/authorize"", error=""insufficient_claims"", claims=""eyJhY2Nlc3NfdG9rZW4iOnsibmJmIjp7ImVzc2VudGlhbCI6dHJ1ZSwidmFsdWUiOiIxNzI2MDc3NTk1In0sInhtc19jYWVlcnJvciI6eyJ2YWx1ZSI6IjEwMDEyIn19fQ==""", """{"access_token":{"nbf":{"essential":true,"value":"1726077595"},"xms_caeerror":{"value":"10012"}}}""")]
        public async Task VerifyCaeClaims(string challenge, string expectedClaims)
        {
            int callCount = 0;

            MockResponse responseWithKey = new MockResponse(200)
            .WithContent(@"{
                ""key"": {
                    ""kid"": ""https://heathskeyvault.vault.azure.net/keys/625710934/ef3685592e1c4e839206aaa10f0f058e"",
                    ""kty"": ""RSA"",
                    ""key_ops"": [
                        ""encrypt"",
                        ""decrypt"",
                        ""sign"",
                        ""verify"",
                        ""wrapKey"",
                        ""unwrapKey""
                    ],
                    ""n"": ""foo"",
                    ""e"": ""AQAB""
                    },
                    ""attributes"": {
                        ""enabled"": true,
                        ""created"": 1613807137,
                        ""updated"": 1613807137,
                        ""recoveryLevel"": ""Recoverable\u002BPurgeable"",
                        ""recoverableDays"": 90
                }
            }");

            MockTransport transport = GetMockTransportWithCaeChallenges(numberOfCaeChallenges: 1, final200response: responseWithKey);

            var credential = new TokenCredentialStub((r, c) =>
            {
                if (callCount == 0)
                {
                    // The first challenge should not have any claims.
                    Assert.IsNull(r.Claims);
                }
                else if (callCount == 1)
                {
                    Assert.AreEqual(expectedClaims, r.Claims);
                }
                else
                {
                    Assert.Fail("unexpected token request");
                }
                Interlocked.Increment(ref callCount);
                Assert.AreEqual(true, r.IsCaeEnabled);

                return new(callCount.ToString(), DateTimeOffset.Now.AddHours(2));
            }, true);

            KeyClient client = new(
            VaultUri,
            credential,
            new KeyClientOptions()
            {
                Transport = transport,
            });

            Response<KeyVaultKey> response = await client.GetKeyAsync("key");
            Assert.AreEqual(200, response.GetRawResponse().Status);
        }

        [Test]
        public void ThrowsWithTwoConsecutiveCaeChallenges()
        {
            MockTransport keyVaultTransport = GetMockTransportWithCaeChallenges(numberOfCaeChallenges: 2);

            MockTransport credentialTransport = GetMockCredentialTransport(2);

            KeyClient client = new(
                VaultUri,
                new MockCredential(credentialTransport),
                new KeyClientOptions()
                {
                    Transport = keyVaultTransport,
                });

            try
            {
                client.GetKey("key");
            }
            catch (RequestFailedException ex)
            {
                Assert.AreEqual(401, ex.Status);
                return;
            }
            catch (Exception ex)
            {
                Assert.Fail($"Expected RequestFailedException, but got {ex.GetType()}");
                return;
            }
            Assert.Fail("Expected RequestFailedException, but no exception was thrown.");
        }
    }
}
