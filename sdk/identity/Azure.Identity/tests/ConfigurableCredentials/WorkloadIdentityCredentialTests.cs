// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity.Tests.Mock;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace Azure.Identity.Tests.ConfigurableCredentials.WorkloadIdentity
{
    internal class WorkloadIdentityCredentialTests : Tests.WorkloadIdentityCredentialTests
    {
        private readonly ConfigurableCredentialTestHelper<WorkloadIdentityCredential> _helper;

        public WorkloadIdentityCredentialTests(bool isAsync) : base(isAsync)
        {
            _helper = new ConfigurableCredentialTestHelper<WorkloadIdentityCredential>(
                "WorkloadIdentity",
                null,
                null,
                InstrumentClient);
        }

        private string SetupTokenFile(string tenantId, Uri authorityHost)
        {
            var certificatePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "cert.pfx");
#if NET9_0_OR_GREATER
            var mockCert = X509CertificateLoader.LoadPkcs12FromFile(certificatePath, null);
#else
            var mockCert = new X509Certificate2(certificatePath);
#endif
            var tokenFilePath = TempFiles.GetTempFilePath();
            string assertion = CredentialTestHelpers.CreateClientAssertionJWT(authorityHost, ClientId, tenantId, mockCert);
            File.WriteAllText(tokenFilePath, assertion);
            return tokenFilePath;
        }

        private ConfigurableCredential CreateConfiguredCredential(string tenantId = null, Action<IConfiguration> configureExtra = null)
        {
            var tokenFilePath = SetupTokenFile(tenantId ?? TenantId, AzureAuthorityHosts.AzurePublicCloud);

            IConfiguration config = _helper.GetConfiguration();
            if (tenantId != null)
            {
                config["MyClient:Credential:TenantId"] = tenantId;
            }
            config["MyClient:Credential:WorkloadIdentityClientId"] = ClientId;
            configureExtra?.Invoke(config);

            ConfigurableCredential credential;
            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "AZURE_TENANT_ID", null },
                { "AZURE_CLIENT_ID", null },
                { "AZURE_FEDERATED_TOKEN_FILE", tokenFilePath }
            }))
            {
                credential = _helper.GetCredentialFromConfig(config);
            }

            return credential;
        }

        private void InjectMsalClient(ConfigurableCredential credential, MsalConfidentialClient msalClient)
        {
            var wic = _helper.GetUnderlyingCredential(credential);
            var clientAssertionCred = (ClientAssertionCredential)typeof(WorkloadIdentityCredential)
                .GetField("_clientAssertionCredential", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(wic);
            if (clientAssertionCred != null && msalClient != null)
            {
                typeof(ClientAssertionCredential)
                    .GetField("<Client>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance)
                    .SetValue(clientAssertionCred, msalClient);
            }
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

            var tokenFilePath = SetupTokenFile(
                config.TenantId,
                config.AuthorityHost ?? AzureAuthorityHosts.AzurePublicCloud);

            IConfiguration configuration = _helper.GetConfigurationFromCommonCredentialTestConfig<WorkloadIdentityCredentialOptions>(config);
            configuration["MyClient:Credential:WorkloadIdentityClientId"] = ClientId;

            ConfigurableCredential credential;
            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "AZURE_TENANT_ID", null },
                { "AZURE_CLIENT_ID", null },
                { "AZURE_FEDERATED_TOKEN_FILE", tokenFilePath }
            }))
            {
                credential = _helper.GetCredentialFromConfig(configuration, config.Transport);
            }

            if (config.MockConfidentialMsalClient != null)
            {
                InjectMsalClient(credential, config.MockConfidentialMsalClient);
            }
            return _helper.InstrumentCredential(credential);
        }

        protected override TokenCredential CreateCredentialForValidation(string tenantId, string clientId, string tokenFilePath)
        {
            IConfiguration config = _helper.GetConfiguration();
            if (tenantId != null)
            {
                config["MyClient:Credential:TenantId"] = tenantId;
            }
            if (clientId != null)
            {
                config["MyClient:Credential:WorkloadIdentityClientId"] = clientId;
            }

            ConfigurableCredential credential;
            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "AZURE_TENANT_ID", null },
                { "AZURE_CLIENT_ID", null },
                { "AZURE_FEDERATED_TOKEN_FILE", tokenFilePath }
            }))
            {
                credential = _helper.GetCredentialFromConfig(config);
            }

            return _helper.InstrumentCredential(credential);
        }

        protected override TokenCredential CreateProxyTestCredential(bool isAzureProxyEnabled = false)
        {
            IConfiguration config = _helper.GetConfiguration();
            config["MyClient:Credential:TenantId"] = TenantId;
            config["MyClient:Credential:WorkloadIdentityClientId"] = ClientId;
            config["MyClient:Credential:IsAzureProxyEnabled"] = isAzureProxyEnabled.ToString();

            // The factory creates WorkloadIdentityCredentialOptions whose TokenFilePath defaults to
            // AZURE_FEDERATED_TOKEN_FILE. A non-null value is needed so the WIC constructor enters
            // the code path that validates proxy configuration.
            var oldTokenFile = System.Environment.GetEnvironmentVariable("AZURE_FEDERATED_TOKEN_FILE");
            try
            {
                System.Environment.SetEnvironmentVariable("AZURE_FEDERATED_TOKEN_FILE", "/fake/path/token");
                var credential = _helper.GetCredentialFromConfig(config);
                InjectMsalClient(credential, mockConfidentialMsalClient);
                return _helper.InstrumentCredential(credential);
            }
            finally
            {
                System.Environment.SetEnvironmentVariable("AZURE_FEDERATED_TOKEN_FILE", oldTokenFile);
            }
        }
    }
}
