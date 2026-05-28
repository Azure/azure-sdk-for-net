// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    [NonParallelizable]
    public class AzurePipelinesCredentialTests : CredentialTestBase<AzurePipelinesCredentialOptions>
    {
        public AzurePipelinesCredentialTests(bool isAsync) : base(isAsync)
        { }

        public override TokenCredential GetTokenCredential(TokenCredentialOptions options)
        {
            var pipelineOptions = new AzurePipelinesCredentialOptions
            {
                Diagnostics = { IsAccountIdentifierLoggingEnabled = options.Diagnostics.IsAccountIdentifierLoggingEnabled },
                MsalClient = mockConfidentialMsalClient,
                Pipeline = CredentialPipeline.GetInstance(null),
            };

            return InstrumentClient(new AzurePipelinesCredential(TenantId, ClientId, Guid.NewGuid().ToString(), "mytoken", options: pipelineOptions));
        }

        public override TokenCredential GetTokenCredential(CommonCredentialTestConfig config)
        {
            if (config.TenantId == null)
            {
                Assert.Ignore("Null TenantId test does not apply to this credential");
            }

            var options = new AzurePipelinesCredentialOptions
            {
                DisableInstanceDiscovery = config.DisableInstanceDiscovery,
                AdditionallyAllowedTenants = config.AdditionallyAllowedTenants,
                IsUnsafeSupportLoggingEnabled = config.IsUnsafeSupportLoggingEnabled,
                MsalClient = config.MockConfidentialMsalClient,
                OidcRequestUri = "https://dev.azure.com/myorg/myproject/_apis/serviceendpoint/endpoints?api-version=2.2.2",
                AuthorityHost = config.AuthorityHost,
            };
            if (config.Transport != null)
            {
                options.Transport = config.Transport;
            }
            if (config.TokenCachePersistenceOptions != null)
            {
                options.TokenCachePersistenceOptions = config.TokenCachePersistenceOptions;
            }
            config.TransportConfig.ResponseHandler = (req, resp) =>
            {
                if (options.OidcRequestUri.Contains(req.Uri.Host))
                {
                    Assert.That(req.Headers.TryGetValue("Authorization", out var authHeader), Is.True);
                    Assert.That(authHeader, Does.Contain("mytoken"));
                    resp.SetContent("""{"oidcToken": "myoidcToken"}""");
                }
            };

            var pipeline = CredentialPipeline.GetInstance(options);
            options.Pipeline = pipeline;
            return InstrumentClient(new AzurePipelinesCredential(config.TenantId, ClientId, "myConnectionId", "mytoken", options: options));
        }

        [Test]
        public void AzurePipelinesCredentialOptions_Loads_From_Env()
        {
            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "SYSTEM_OIDCREQUESTURI", "mockCollectionUri" },
            }))
            {
                var options = new AzurePipelinesCredentialOptions();
                Assert.AreEqual("mockCollectionUri", options.OidcRequestUri);
            }
        }

        [Test]
        public async Task AzurePipelineCredentialWorksInChainedCredential()
        {
            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "SYSTEM_OIDCREQUESTURI", null },
            }))
            {
                var chainedCred = new ChainedTokenCredential(new AzurePipelinesCredential("myTenantId", "myClientId", "myConnectionId", "mytoken"), new MockCredential());

                AccessToken token = await chainedCred.GetTokenAsync(new TokenRequestContext(new[] { "scope" }), CancellationToken.None);

                Assert.AreEqual("mockToken", token.Token);
            }
        }

        [Test]
        public void AzurePipelineCredentialReturnsErrorInformation()
        {
            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "SYSTEM_OIDCREQUESTURI", "mockCollectionUri" },
            }))
            {
                var systemAccessToken = "mytoken";
                var tenantId = "myTenantId";
                var clientId = "myClientId";
                var serviceConnectionId = "myConnectionId";

                var mockTransport = new MockTransport(req => new MockResponse(200).WithContent(
                            $"{{\"token_type\": \"Bearer\",\"expires_in\": 9999,\"ext_expires_in\": 9999,\"access_token\": \"mytoken\" }}"));

                var options = new AzurePipelinesCredentialOptions { Transport = mockTransport, OidcRequestUri = "https://mockCollectionUri" };
                var cred = new AzurePipelinesCredential(tenantId, clientId, serviceConnectionId, systemAccessToken, options);

                var ex = Assert.ThrowsAsync<AuthenticationFailedException>(async () => await cred.GetTokenAsync(new TokenRequestContext(new[] { "scope" }), CancellationToken.None));
                Assert.That(ex.Message, Does.Contain(AzurePipelinesCredential.Troubleshooting));
            }
        }

        [Test]
        [TestCase(200)]
        [TestCase(400)]
        public void AzurePipelineCredentialReturnsNonJsonErrorInformation(int responseStatusCode)
        {
            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "SYSTEM_OIDCREQUESTURI", "https://mockCollectionUri" },
            }))
            {
                var systemAccessToken = "mytoken";
                var tenantId = "myTenantId";
                var clientId = "myClientId";
                var serviceConnectionId = "myConnectionId";

                var mockTransport = new MockTransport(req =>
                {
                    if (req.Uri.Host == "mockcollectionuri")
                    {
                        return new MockResponse(responseStatusCode)
                            .WithContent($"< not json, but an error >")
                            .WithHeader("x-vss-e2eid", "myE2EId")
                            .WithHeader("x-msedge-ref", "myRef");
                    }
                    return new MockResponse(200).WithContent(
                            $"{{\"token_type\": \"Bearer\",\"expires_in\": 9999,\"ext_expires_in\": 9999,\"access_token\": \"mytoken\" }}");
                });

                var options = new AzurePipelinesCredentialOptions { Transport = mockTransport };
                var cred = new AzurePipelinesCredential(tenantId, clientId, serviceConnectionId, systemAccessToken, options);

                var ex = Assert.ThrowsAsync<AuthenticationFailedException>(async () => await cred.GetTokenAsync(new TokenRequestContext(new[] { "scope" }), CancellationToken.None));

                if (responseStatusCode == 200)
                {
                    Assert.That(ex.Message, Does.Not.Contain("< not json, but an error >"));
                }
                else
                {
                    Assert.That(ex.Message, Does.Contain("< not json, but an error >"));
                    Assert.That(ex.Message, Does.Contain(AzurePipelinesCredential.Troubleshooting));
                    Assert.That(ex.Message, Does.Contain("myE2EId"));
                    Assert.That(ex.Message, Does.Contain("myRef"));
                }
            }
        }

        public class MockCredential : TokenCredential
        {
            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                return new AccessToken("mockToken", DateTimeOffset.MaxValue);
            }

            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                return new ValueTask<AccessToken>(GetToken(requestContext, cancellationToken));
            }
        }
    }
}
