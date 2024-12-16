// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Security.KeyVault.Tests;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Certificates.Tests
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

            MockResponse responseWithSecret = new MockResponse(200)
            .WithContent(@"{
              ""id"": ""https://foo.vault.azure.net/certificates/1/foo"",
              ""cer"": ""Zm9v"",
              ""attributes"": {
              },
              ""pending"": {
                ""id"": ""foo""
              }
            }");

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

            CertificateClient client = new(
            VaultUri,
            credential,
            new CertificateClientOptions()
            {
                Transport = transport,
            });

            Response<KeyVaultCertificateWithPolicy> response = await client.GetCertificateAsync("certificate");
            Assert.AreEqual(200, response.GetRawResponse().Status);
        }

        [Test]
        public void ThrowsWithTwoConsecutiveCaeChallenges()
        {
            MockTransport keyVaultTransport = GetMockTransportWithCaeChallenges(numberOfCaeChallenges: 2);

            MockTransport credentialTransport = GetMockCredentialTransport(2);

            CertificateClient client = new(
                VaultUri,
                new MockCredential(credentialTransport),
                new CertificateClientOptions()
                {
                    Transport = keyVaultTransport,
                });

            try
            {
                client.GetCertificate("certificate");
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
