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
                TenantId = TenantId,
                ClientId = ClientId
            };

            return InstrumentClient(new AzurePipelinesCredential("mytoken", options: pipelineOptions));
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
                TenantId = config.TenantId,
                ClientId = ClientId,
                ServiceConnectionId = "myConnectionId"
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
            return InstrumentClient(new AzurePipelinesCredential("mytoken", options: options));
        }

        [Test]
        public void AzurePipelinesCredentialOptions_Loads_From_Env()
        {
            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "SYSTEM_OIDCREQUESTURI", "mockCollectionUri" },
                { "AZURESUBSCRIPTION_SERVICE_CONNECTION_ID", "myConnectionId" },
                { "AZURESUBSCRIPTION_TENANT_ID", "myTenantId" },
                { "AZURESUBSCRIPTION_CLIENT_ID", "myClientId" },
            }))
            {
                var options = new AzurePipelinesCredentialOptions();
                Assert.AreEqual("mockCollectionUri", options.OidcRequestUri);
                Assert.AreEqual("myTenantId", options.TenantId);
                Assert.AreEqual("myClientId", options.ClientId);
            }
        }

        [Test]
        public async Task AzurePipelineCredentialWorksInChainedCredential()
        {
            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "AZURESUBSCRIPTION_CLIENT_ID", "myClientId" },
                { "AZURESUBSCRIPTION_TENANT_ID", "myTenantId" }}))
            {
                var chainedCred = new ChainedTokenCredential(new AzurePipelinesCredential("mytoken"), new MockCredential());

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

                var options = new AzurePipelinesCredentialOptions { Transport = mockTransport };
                var cred = new AzurePipelinesCredential(systemAccessToken, clientId, tenantId, serviceConnectionId, options);

                Assert.ThrowsAsync<AuthenticationFailedException>(async () => await cred.GetTokenAsync(new TokenRequestContext(new[] { "scope" }), CancellationToken.None));
            }
        }

        [Test]
        public async Task AzurePipelineCredentialLiveTest_GetToken()
        {
            var systemAccessToken = Environment.GetEnvironmentVariable("SYSTEM_ACCESSTOKEN");
            var tenantId = Environment.GetEnvironmentVariable("AZURE_SERVICE_CONNECTION_TENANT_ID");
            var clientId = Environment.GetEnvironmentVariable("AZURE_SERVICE_CONNECTION_CLIENT_ID");
            var serviceConnectionId = Environment.GetEnvironmentVariable("AZURE_SERVICE_CONNECTION_ID");

            if (string.IsNullOrEmpty(systemAccessToken) || string.IsNullOrEmpty(tenantId) || string.IsNullOrEmpty(clientId) || string.IsNullOrEmpty(serviceConnectionId))
            {
                var envVars = Environment.GetEnvironmentVariables();
                StringBuilder sb = new StringBuilder();
                foreach (var key in envVars.Keys)
                {
                    sb.AppendLine($"{key}: {envVars[key]}");
                }
                Console.WriteLine(sb);
                Assert.Fail($"{sb} SYSTEM_ACCESSTOKEN: {systemAccessToken}, AZURE_SERVICE_CONNECTION_TENANT_ID: {tenantId}, AZURE_SERVICE_CONNECTION_CLIENT_ID: {clientId}, AZURE_SERVICE_CONNECTION_ID: {serviceConnectionId}");
                Assert.Ignore("AzurePipelinesCredentialLiveTests disabled because required environment variables are not set");
            }

            var cred = new AzurePipelinesCredential(systemAccessToken, clientId, tenantId, serviceConnectionId);

            AccessToken token = await cred.GetTokenAsync(new TokenRequestContext(new[] { "https://management.azure.com//.default" }), CancellationToken.None);

            Assert.IsNotNull(token.Token);
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
