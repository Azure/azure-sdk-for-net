// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class AzurePipelinesCredentialTests : CredentialTestBase<AzurePipelinesCredentialOptions>
    {
        public AzurePipelinesCredentialTests(bool isAsync) : base(isAsync)
        { }

        public override TokenCredential GetTokenCredential(TokenCredentialOptions options)
        {
            var clientAssertionOptions = new AzurePipelinesCredentialOptions { Diagnostics = { IsAccountIdentifierLoggingEnabled = options.Diagnostics.IsAccountIdentifierLoggingEnabled }, MsalClient = mockConfidentialMsalClient, Pipeline = CredentialPipeline.GetInstance(null) };

            return InstrumentClient(new AzurePipelinesCredential(expectedTenantId, ClientId, "serviceConnectionId", clientAssertionOptions));
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
                CollectionUri = "https://dev.azure.com/myorg/myproject/_apis/serviceendpoint/endpoints?api-version=2.2.2",
                PlanId = "myplan",
                JobId = "myjob",
                TeamProjectId = "myteamproject",
                SystemAccessToken = "mytoken"
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
                if (options.CollectionUri.Contains(req.Uri.Host))
                {
                    Assert.That(req.Headers.TryGetValue("Authorization", out var authHeader), Is.True);
                    Assert.That(authHeader, Does.Contain(options.SystemAccessToken));
                    resp.SetContent("""{"oidcToken": "myoidcToken"}""");
                }
            };

            var pipeline = CredentialPipeline.GetInstance(options);
            options.Pipeline = pipeline;
            return InstrumentClient(new AzurePipelinesCredential(config.TenantId, ClientId, "serviceConnectionId", options));
        }

        [Test]
        public void AzurePipelinesCredentialOptions_Loads_From_Env()
        {
            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "SYSTEM_TEAMFOUNDATIONCOLLECTIONURI", "mockCollectionUri" },
                { "SYSTEM_HOSTTYPE", "mockHubName" },
                { "SYSTEM_JOBID", "mockJobId" },
                { "SYSTEM_PLANID", "mockPlanId" },
                { "SYSTEM_ACCESSTOKEN", "mockSystemAccessToken" },
                { "SYSTEM_TEAMPROJECTID", "mockTeamProjectId" }}))
            {
                var options = new AzurePipelinesCredentialOptions();
                Assert.AreEqual("mockCollectionUri", options.CollectionUri);
                Assert.AreEqual("mockJobId", options.JobId);
                Assert.AreEqual("mockPlanId", options.PlanId);
                Assert.AreEqual("mockSystemAccessToken", options.SystemAccessToken);
                Assert.AreEqual("mockTeamProjectId", options.TeamProjectId);
            }
        }

        [Test]
        public async Task AzurePipelineCredentialWorksInChainedCredential()
        {
            var chainedCred = new ChainedTokenCredential(new AzurePipelinesCredential("mockTenantID", "mockClientId", "serviceConnectionId"), new MockCredential());

            AccessToken token = await chainedCred.GetTokenAsync(new TokenRequestContext(new[] { "scope" }), CancellationToken.None);

            Assert.AreEqual("mockToken", token.Token);
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
