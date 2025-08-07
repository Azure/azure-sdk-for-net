// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Security.KeyVault.Tests;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Secrets.Tests
{
    [NonParallelizable]
    internal class ContinousAccessEvaluationTests : ContinuousAccessEvaluationTestsBase
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

            MockResponse responseWithSecret = new MockResponse(200)
            {
                ContentStream = new KeyVaultSecret("test-secret", "secret-value").ToStream(),
            };

            MockTransport transport = GetMockTransportWithCaeChallenges(numberOfCaeChallenges: 1, final200response: responseWithSecret);

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

            SecretClient client = new(
            VaultUri,
            credential,
            new SecretClientOptions()
            {
                Transport = transport,
            });

            Response<KeyVaultSecret> response = await client.GetSecretAsync("test-secret");
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("secret-value", response.Value.Value);
        }

        [Test]
        public void ThrowsWithTwoConsecutiveCaeChallenges()
        {
            MockTransport keyVaultTransport = GetMockTransportWithCaeChallenges(numberOfCaeChallenges: 2);

            MockTransport credentialTransport = GetMockCredentialTransport(2);

            SecretClient client = new(
                VaultUri,
                new MockCredential(credentialTransport),
                new SecretClientOptions()
                {
                    Transport = keyVaultTransport,
                });

            try
            {
                client.GetSecret("test-secret");
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

        [Test]
        public void ensureTokenFromClaimsChallengeGetsUsed()
        {
            MockTransport transport = new(new[]
            {
                defaultInitialChallenge,

                new MockResponse(200)
                    .WithJson("""
                    {
                        "token_type": "Bearer",
                        "expires_in": 3599,
                        "resource": "https://vault.azure.net",
                        "access_token": "TOKEN_1"
                    }
                    """),

                new MockResponse(200)
                    {
                        ContentStream = new KeyVaultSecret("test-secret", "secret-value").ToStream(),
                    },

                defaultCaeChallenge,

                new MockResponse(200)
                .WithJson("""
                    {
                        "token_type": "Bearer",
                        "expires_in": 3599,
                        "resource": "https://vault.azure.net",
                        "access_token": "TOKEN_2"
                    }
                """),

                new MockResponse(200)
                {
                    ContentStream = new KeyVaultSecret("test-secret2", "secret-value").ToStream(),
                },
            });

            SecretClient client = new(
                VaultUri,
                new MockCredential(transport),
                new SecretClientOptions()
                {
                    Transport = transport,
                });

            _ = client.GetSecret("test-secret");
            _ = client.GetSecret("test-secret2");

            Assert.IsTrue(transport.Requests[2].Headers.TryGetValue("Authorization", out string authorizationValue));
            Assert.AreEqual("Bearer TOKEN_1", authorizationValue);

            Assert.IsTrue(transport.Requests[5].Headers.TryGetValue("Authorization", out string authorizationValue2));
            Assert.AreEqual("Bearer TOKEN_2", authorizationValue2);
        }
    }
}
