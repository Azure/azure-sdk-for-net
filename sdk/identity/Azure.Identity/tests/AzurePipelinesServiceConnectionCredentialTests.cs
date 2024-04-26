// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class AzurePipelinesServiceConnectionCredentialTests : CredentialTestBase<AzurePipelinesServiceConnectionCredentialOptions>
    {
        public AzurePipelinesServiceConnectionCredentialTests(bool isAsync) : base(isAsync)
        { }

        public override TokenCredential GetTokenCredential(TokenCredentialOptions options)
        {
            var clientAssertionOptions = new AzurePipelinesServiceConnectionCredentialOptions { Diagnostics = { IsAccountIdentifierLoggingEnabled = options.Diagnostics.IsAccountIdentifierLoggingEnabled }, MsalClient = mockConfidentialMsalClient, Pipeline = CredentialPipeline.GetInstance(null) };

            return InstrumentClient(new AzurePipelinesServiceConnectionCredential(expectedTenantId, ClientId, "serviceConnectionId", clientAssertionOptions));
        }

        public override TokenCredential GetTokenCredential(CommonCredentialTestConfig config)
        {
            if (config.TenantId == null)
            {
                Assert.Ignore("Null TenantId test does not apply to this credential");
            }

            var options = new AzurePipelinesServiceConnectionCredentialOptions
            {
                DisableInstanceDiscovery = config.DisableInstanceDiscovery,
                AdditionallyAllowedTenants = config.AdditionallyAllowedTenants,
                IsUnsafeSupportLoggingEnabled = config.IsUnsafeSupportLoggingEnabled,
                MsalClient = config.MockConfidentialMsalClient,
                CollectionUri = "https://dev.azure.com/myorg/myproject/_apis/serviceendpoint/endpoints?api-version=2.2.2",
                HubName = "myhub",
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
            return InstrumentClient(new AzurePipelinesServiceConnectionCredential(config.TenantId, ClientId, "serviceConnectionId", options));
        }
    }
}
