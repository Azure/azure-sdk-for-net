// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace Azure.Identity.Tests.ConfigurableCredentials.AzurePipelines
{
    internal class AzurePipelinesCredentialTests : Tests.AzurePipelinesCredentialTests
    {
        private readonly ConfigurableCredentialTestHelper<AzurePipelinesCredential> _helper;

        public AzurePipelinesCredentialTests(bool isAsync) : base(isAsync)
        {
            _helper = new ConfigurableCredentialTestHelper<AzurePipelinesCredential>(
                "AzurePipelines",
                null,
                null,
                InstrumentClient);
        }

        private ConfigurableCredential CreateConfiguredCredential(string tenantId = null, Action<IConfiguration> configureExtra = null)
        {
            IConfiguration config = _helper.GetConfiguration();
            if (tenantId != null)
            {
                config["MyClient:Credential:TenantId"] = tenantId;
            }
            config["MyClient:Credential:ClientId"] = ClientId;
            config["MyClient:Credential:AzurePipelinesServiceConnectionId"] = Guid.NewGuid().ToString();
            config["MyClient:Credential:AzurePipelinesSystemAccessToken"] = "mytoken";
            configureExtra?.Invoke(config);

            ConfigurableCredential credential;
            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "AZURE_TENANT_ID", null },
                { "SYSTEM_OIDCREQUESTURI", "https://dev.azure.com/myorg/myproject/_apis/serviceendpoint/endpoints" },
            }))
            {
                credential = _helper.GetCredentialFromConfig(config);
            }

            return credential;
        }

        private void InjectMsalClient(ConfigurableCredential credential, MsalConfidentialClient msalClient)
        {
            var apc = _helper.GetUnderlyingCredential(credential);
            if (apc != null && msalClient != null)
            {
                typeof(AzurePipelinesCredential)
                    .GetField("<Client>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance)
                    .SetValue(apc, msalClient);
            }
        }

        private void RestorePipelineWithTransport(ConfigurableCredential credential, TokenCredentialOptions optionsWithTransport)
        {
            var apc = _helper.GetUnderlyingCredential(credential);
            var pipeline = CredentialPipeline.GetInstance(optionsWithTransport);
            typeof(AzurePipelinesCredential)
                .GetField("<Pipeline>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance)
                .SetValue(apc, pipeline);
        }

        public override TokenCredential GetTokenCredential(TokenCredentialOptions options)
        {
            var credential = CreateConfiguredCredential(TenantId,
                config => config["MyClient:Credential:Diagnostics:IsAccountIdentifierLoggingEnabled"] =
                    options.Diagnostics.IsAccountIdentifierLoggingEnabled.ToString());
            InjectMsalClient(credential, mockConfidentialMsalClient);
            return _helper.InstrumentCredential(credential);
        }

        public override TokenCredential GetTokenCredential(CommonCredentialTestConfig config)
        {
            if (config.TenantId == null)
            {
                Assert.Ignore("Null TenantId test does not apply to this credential");
            }

            IConfiguration configuration = _helper.GetConfigurationFromCommonCredentialTestConfig<AzurePipelinesCredentialOptions>(config);
            configuration["MyClient:Credential:ClientId"] = ClientId;
            configuration["MyClient:Credential:AzurePipelinesServiceConnectionId"] = "myConnectionId";
            configuration["MyClient:Credential:AzurePipelinesSystemAccessToken"] = "mytoken";

            ConfigurableCredential credential;
            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "AZURE_TENANT_ID", null },
                { "SYSTEM_OIDCREQUESTURI", "https://dev.azure.com/myorg/myproject/_apis/serviceendpoint/endpoints" },
            }))
            {
                IConfigurationSection credentialSection = configuration.GetSection("MyClient:Credential");
                var dacOptions = new DefaultAzureCredentialOptions(new CredentialSettings(credentialSection), credentialSection);
                if (config.Transport != null)
                {
                    dacOptions.Transport = config.Transport;
                }
                if (config.TokenCachePersistenceOptions != null)
                {
                    dacOptions.TokenCachePersistenceOptions = config.TokenCachePersistenceOptions;
                }
                credential = new ConfigurableCredential(dacOptions);
            }

            config.TransportConfig.ResponseHandler = (req, resp) =>
            {
                if (req.Uri.Host.Contains("dev.azure.com"))
                {
                    Assert.That(req.Headers.TryGetValue("Authorization", out var authHeader), Is.True);
                    Assert.That(authHeader, Does.Contain("mytoken"));
                    resp.SetContent("""{"oidcToken": "myoidcToken"}""");
                }
            };

            if (config.MockConfidentialMsalClient != null)
            {
                InjectMsalClient(credential, config.MockConfidentialMsalClient);
            }

            var instrumented = _helper.InstrumentCredential(credential);

            var optionsWithTransport = new AzurePipelinesCredentialOptions();
            if (config.Transport != null)
            {
                optionsWithTransport.Transport = config.Transport;
            }
            RestorePipelineWithTransport(instrumented, optionsWithTransport);

            return instrumented;
        }

        public override Task AzurePipelineCredentialWorksInChainedCredential()
        {
            Assert.Ignore("Chained credential is not supported by the configurable credential path.");
            return Task.CompletedTask;
        }

        protected override AzurePipelinesCredential CreateCredentialWithTransport(string tenantId, string clientId, string serviceConnectionId, string systemAccessToken, MockTransport mockTransport, string oidcRequestUri = null)
        {
            // Don't use TestEnvVar here — the calling test already manages env vars.
            IConfiguration config = _helper.GetConfiguration();
            config["MyClient:Credential:TenantId"] = tenantId;
            config["MyClient:Credential:ClientId"] = clientId;
            config["MyClient:Credential:AzurePipelinesServiceConnectionId"] = serviceConnectionId;
            config["MyClient:Credential:AzurePipelinesSystemAccessToken"] = systemAccessToken;

            IConfigurationSection credentialSection = config.GetSection("MyClient:Credential");
            var dacOptions = new DefaultAzureCredentialOptions(new CredentialSettings(credentialSection), credentialSection);
            dacOptions.Transport = mockTransport;
            var credential = new ConfigurableCredential(dacOptions);

            var apc = _helper.GetUnderlyingCredential(credential);

            // Restore pipeline with mock transport so the OIDC callback works.
            var pipelineOptions = new AzurePipelinesCredentialOptions { Transport = mockTransport };
            if (oidcRequestUri != null)
            {
                pipelineOptions.OidcRequestUri = oidcRequestUri;
            }
            var pipeline = CredentialPipeline.GetInstance(pipelineOptions);
            typeof(AzurePipelinesCredential)
                .GetField("<Pipeline>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance)
                .SetValue(apc, pipeline);

            return apc;
        }
    }
}
