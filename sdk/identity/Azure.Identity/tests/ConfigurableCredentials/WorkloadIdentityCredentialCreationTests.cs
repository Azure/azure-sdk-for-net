// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core.TestFramework;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace Azure.Identity.Tests.ConfigurableCredentials.WorkloadIdentity
{
    /// <summary>
    /// Validates that all <see cref="WorkloadIdentityCredentialOptions"/> properties can be set
    /// via IConfiguration and that the correct priority order is honoured:
    ///   1. IConfiguration value  (highest)
    ///   2. Well-known environment variable
    ///   3. Hard-coded default     (lowest)
    /// </summary>
    internal class WorkloadIdentityCredentialCreationTests : CredentialCreationTestBase<WorkloadIdentityCredential>
    {
        protected override string CredentialSource => "WorkloadIdentity";

        private static ClientAssertionCredential GetClientAssertionCredential(WorkloadIdentityCredential wic)
            => ReadField<ClientAssertionCredential>(wic, "_clientAssertionCredential");

        private static object GetMsalClient(ClientAssertionCredential cac)
            => ReadProperty<object>(cac, "Client");

        private static T ReadMsalProperty<T>(object msalClient, string propertyName)
            => ReadProperty<T>(msalClient, propertyName);

        /// <summary>
        /// Returns env var dictionary with all relevant vars nulled out, plus
        /// AZURE_FEDERATED_TOKEN_FILE set so the WIC constructor creates its inner credential.
        /// </summary>
        private static Dictionary<string, string> AllNulledEnvVars(string tokenFilePath = "/fake/token") => new()
        {
            { "AZURE_TENANT_ID", null },
            { "AZURE_CLIENT_ID", null },
            { "AZURE_FEDERATED_TOKEN_FILE", tokenFilePath },
            { "AZURE_ADDITIONALLY_ALLOWED_TENANTS", null },
            { "AZURE_AUTHORITY_HOST", null },
            { "AZURE_KUBERNETES_TOKEN_PROXY", null },
        };

        [Test]
        [NonParallelizable]
        public void TenantId_ConfigWinsOverEnvVar()
        {
            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "AZURE_TENANT_ID", "env-tenant" },
                { "AZURE_CLIENT_ID", null },
                { "AZURE_FEDERATED_TOKEN_FILE", "/fake/token" },
            }))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:TenantId"] = "config-tenant";
                config["MyClient:Credential:WorkloadIdentityClientId"] = "test-client";

                var cac = GetClientAssertionCredential(GetUnderlying(CreateFromConfig(config)));

                Assert.IsNotNull(cac);
                Assert.AreEqual("config-tenant", cac.TenantId);
            }
        }

        [Test]
        [NonParallelizable]
        public void TenantId_FallsBackToEnvVar()
        {
            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "AZURE_TENANT_ID", "env-tenant" },
                { "AZURE_CLIENT_ID", "env-client" },
                { "AZURE_FEDERATED_TOKEN_FILE", "/fake/token" },
            }))
            {
                IConfiguration config = Helper.GetConfiguration();
                // TenantId intentionally not set in config.
                config["MyClient:Credential:WorkloadIdentityClientId"] = "test-client";

                var cac = GetClientAssertionCredential(GetUnderlying(CreateFromConfig(config)));

                Assert.IsNotNull(cac);
                Assert.AreEqual("env-tenant", cac.TenantId);
            }
        }

        [Test]
        [NonParallelizable]
        public void ClientId_ConfigWinsOverEnvVar()
        {
            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "AZURE_TENANT_ID", null },
                { "AZURE_CLIENT_ID", "env-client" },
                { "AZURE_FEDERATED_TOKEN_FILE", "/fake/token" },
            }))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:TenantId"] = "test-tenant";
                config["MyClient:Credential:WorkloadIdentityClientId"] = "config-client";

                var cac = GetClientAssertionCredential(GetUnderlying(CreateFromConfig(config)));

                Assert.IsNotNull(cac);
                Assert.AreEqual("config-client", cac.ClientId);
            }
        }

        [Test]
        [NonParallelizable]
        public void ClientId_FallsBackToEnvVar()
        {
            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "AZURE_TENANT_ID", "env-tenant" },
                { "AZURE_CLIENT_ID", "env-client" },
                { "AZURE_FEDERATED_TOKEN_FILE", "/fake/token" },
            }))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:TenantId"] = "test-tenant";
                // WorkloadIdentityClientId intentionally not set in config.

                var cac = GetClientAssertionCredential(GetUnderlying(CreateFromConfig(config)));

                Assert.IsNotNull(cac);
                Assert.AreEqual("env-client", cac.ClientId);
            }
        }

        [Test]
        [NonParallelizable]
        public void TokenFilePath_CreatesCredentialWhenEnvVarSet()
        {
            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "AZURE_TENANT_ID", null },
                { "AZURE_CLIENT_ID", null },
                { "AZURE_FEDERATED_TOKEN_FILE", "/my/token" },
            }))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:TenantId"] = "test-tenant";
                config["MyClient:Credential:WorkloadIdentityClientId"] = "test-client";

                var cac = GetClientAssertionCredential(GetUnderlying(CreateFromConfig(config)));

                Assert.IsNotNull(cac, "ClientAssertionCredential should be created when AZURE_FEDERATED_TOKEN_FILE is set");
            }
        }

        [Test]
        [NonParallelizable]
        public void TokenFilePath_NoCredentialWhenEnvVarMissing()
        {
            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "AZURE_TENANT_ID", null },
                { "AZURE_CLIENT_ID", null },
                { "AZURE_FEDERATED_TOKEN_FILE", null },
            }))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:TenantId"] = "test-tenant";
                config["MyClient:Credential:WorkloadIdentityClientId"] = "test-client";

                var cac = GetClientAssertionCredential(GetUnderlying(CreateFromConfig(config)));

                Assert.IsNull(cac, "ClientAssertionCredential should not be created when AZURE_FEDERATED_TOKEN_FILE is missing");
            }
        }

        [Test]
        [NonParallelizable]
        public void AuthorityHost_ConfigWinsOverEnvVar()
        {
            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "AZURE_TENANT_ID", null },
                { "AZURE_CLIENT_ID", null },
                { "AZURE_FEDERATED_TOKEN_FILE", "/fake/token" },
                { "AZURE_AUTHORITY_HOST", AzureAuthorityHosts.AzureGovernment.ToString() },
            }))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:TenantId"] = "test-tenant";
                config["MyClient:Credential:WorkloadIdentityClientId"] = "test-client";
                config["MyClient:Credential:AuthorityHost"] = AzureAuthorityHosts.AzureChina.ToString();

                var cac = GetClientAssertionCredential(GetUnderlying(CreateFromConfig(config)));
                Assert.IsNotNull(cac);

                Uri actual = ReadMsalProperty<Uri>(GetMsalClient(cac), "AuthorityHost");
                Assert.AreEqual(AzureAuthorityHosts.AzureChina, actual);
            }
        }

        [Test]
        [NonParallelizable]
        public void AuthorityHost_FallsBackToEnvVar()
        {
            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "AZURE_TENANT_ID", null },
                { "AZURE_CLIENT_ID", null },
                { "AZURE_FEDERATED_TOKEN_FILE", "/fake/token" },
                { "AZURE_AUTHORITY_HOST", AzureAuthorityHosts.AzureGovernment.ToString() },
            }))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:TenantId"] = "test-tenant";
                config["MyClient:Credential:WorkloadIdentityClientId"] = "test-client";
                // AuthorityHost intentionally not set in config.

                var cac = GetClientAssertionCredential(GetUnderlying(CreateFromConfig(config)));
                Assert.IsNotNull(cac);

                Uri actual = ReadMsalProperty<Uri>(GetMsalClient(cac), "AuthorityHost");
                Assert.AreEqual(AzureAuthorityHosts.AzureGovernment, actual);
            }
        }

        [Test]
        [NonParallelizable]
        public void AuthorityHost_DefaultsToAzurePublicCloud()
        {
            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "AZURE_TENANT_ID", null },
                { "AZURE_CLIENT_ID", null },
                { "AZURE_FEDERATED_TOKEN_FILE", "/fake/token" },
                { "AZURE_AUTHORITY_HOST", null },
            }))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:TenantId"] = "test-tenant";
                config["MyClient:Credential:WorkloadIdentityClientId"] = "test-client";

                var cac = GetClientAssertionCredential(GetUnderlying(CreateFromConfig(config)));
                Assert.IsNotNull(cac);

                Uri actual = ReadMsalProperty<Uri>(GetMsalClient(cac), "AuthorityHost");
                Assert.AreEqual(AzureAuthorityHosts.AzurePublicCloud, actual);
            }
        }

        [Test]
        [NonParallelizable]
        public void DisableInstanceDiscovery_ConfigSetsTrue()
        {
            var envVars = AllNulledEnvVars();
            using (new TestEnvVar(envVars))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:TenantId"] = "test-tenant";
                config["MyClient:Credential:WorkloadIdentityClientId"] = "test-client";
                config["MyClient:Credential:DisableInstanceDiscovery"] = "true";

                var cac = GetClientAssertionCredential(GetUnderlying(CreateFromConfig(config)));
                Assert.IsNotNull(cac);
                Assert.IsTrue(ReadMsalProperty<bool>(GetMsalClient(cac), "DisableInstanceDiscovery"));
            }
        }

        [Test]
        [NonParallelizable]
        public void DisableInstanceDiscovery_DefaultsFalse()
        {
            var envVars = AllNulledEnvVars();
            using (new TestEnvVar(envVars))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:TenantId"] = "test-tenant";
                config["MyClient:Credential:WorkloadIdentityClientId"] = "test-client";

                var cac = GetClientAssertionCredential(GetUnderlying(CreateFromConfig(config)));
                Assert.IsNotNull(cac);
                Assert.IsFalse(ReadMsalProperty<bool>(GetMsalClient(cac), "DisableInstanceDiscovery"));
            }
        }

        [Test]
        [NonParallelizable]
        public void IsUnsafeSupportLoggingEnabled_ConfigSetsTrue()
        {
            var envVars = AllNulledEnvVars();
            using (new TestEnvVar(envVars))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:TenantId"] = "test-tenant";
                config["MyClient:Credential:WorkloadIdentityClientId"] = "test-client";
                config["MyClient:Credential:IsUnsafeSupportLoggingEnabled"] = "true";

                var cac = GetClientAssertionCredential(GetUnderlying(CreateFromConfig(config)));
                Assert.IsNotNull(cac);
                Assert.IsTrue(ReadMsalProperty<bool>(GetMsalClient(cac), "IsSupportLoggingEnabled"));
            }
        }

        [Test]
        [NonParallelizable]
        public void IsUnsafeSupportLoggingEnabled_DefaultsFalse()
        {
            var envVars = AllNulledEnvVars();
            using (new TestEnvVar(envVars))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:TenantId"] = "test-tenant";
                config["MyClient:Credential:WorkloadIdentityClientId"] = "test-client";

                var cac = GetClientAssertionCredential(GetUnderlying(CreateFromConfig(config)));
                Assert.IsNotNull(cac);
                Assert.IsFalse(ReadMsalProperty<bool>(GetMsalClient(cac), "IsSupportLoggingEnabled"));
            }
        }

        [Test]
        [NonParallelizable]
        public void AdditionallyAllowedTenants_ConfigWinsOverEnvVar()
        {
            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "AZURE_TENANT_ID", null },
                { "AZURE_CLIENT_ID", null },
                { "AZURE_FEDERATED_TOKEN_FILE", "/fake/token" },
                { "AZURE_ADDITIONALLY_ALLOWED_TENANTS", "env-tenant-x;env-tenant-y" },
            }))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:TenantId"] = "test-tenant";
                config["MyClient:Credential:WorkloadIdentityClientId"] = "test-client";
                config["MyClient:Credential:AdditionallyAllowedTenants:0"] = "config-tenant-a";

                var cac = GetClientAssertionCredential(GetUnderlying(CreateFromConfig(config)));
                Assert.IsNotNull(cac);

                var tenants = ReadField<string[]>(cac, "AdditionallyAllowedTenantIds");
                Assert.IsNotNull(tenants);
                CollectionAssert.Contains(tenants, "config-tenant-a");
                CollectionAssert.DoesNotContain(tenants, "env-tenant-x");
            }
        }

        [Test]
        [NonParallelizable]
        public void AdditionallyAllowedTenants_FallsBackToEnvVar()
        {
            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "AZURE_TENANT_ID", "env-tenant" },
                { "AZURE_CLIENT_ID", "env-client" },
                { "AZURE_FEDERATED_TOKEN_FILE", "/fake/token" },
                { "AZURE_ADDITIONALLY_ALLOWED_TENANTS", "env-tenant-x;env-tenant-y" },
            }))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:TenantId"] = "test-tenant";
                config["MyClient:Credential:WorkloadIdentityClientId"] = "test-client";
                // AdditionallyAllowedTenants intentionally not set in config.

                var cac = GetClientAssertionCredential(GetUnderlying(CreateFromConfig(config)));
                Assert.IsNotNull(cac);

                var tenants = ReadField<string[]>(cac, "AdditionallyAllowedTenantIds");
                Assert.IsNotNull(tenants);
                CollectionAssert.Contains(tenants, "env-tenant-x");
                CollectionAssert.Contains(tenants, "env-tenant-y");
            }
        }

        [Test]
        [NonParallelizable]
        public void AdditionallyAllowedTenants_DefaultsToEmpty()
        {
            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "AZURE_TENANT_ID", null },
                { "AZURE_CLIENT_ID", null },
                { "AZURE_FEDERATED_TOKEN_FILE", "/fake/token" },
                { "AZURE_ADDITIONALLY_ALLOWED_TENANTS", null },
            }))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:TenantId"] = "test-tenant";
                config["MyClient:Credential:WorkloadIdentityClientId"] = "test-client";

                var cac = GetClientAssertionCredential(GetUnderlying(CreateFromConfig(config)));
                Assert.IsNotNull(cac);

                var tenants = ReadField<string[]>(cac, "AdditionallyAllowedTenantIds");
                Assert.IsNotNull(tenants);
                Assert.IsEmpty(tenants);
            }
        }

        [Test]
        [NonParallelizable]
        public void IsAzureProxyEnabled_ConfigSetsTrue()
        {
            // Set an invalid proxy URL so the WIC constructor throws, proving the option was read.
            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "AZURE_TENANT_ID", null },
                { "AZURE_CLIENT_ID", null },
                { "AZURE_FEDERATED_TOKEN_FILE", "/fake/token" },
                { "AZURE_KUBERNETES_TOKEN_PROXY", "http://not-https" },
            }))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:TenantId"] = "test-tenant";
                config["MyClient:Credential:WorkloadIdentityClientId"] = "test-client";
                config["MyClient:Credential:IsAzureProxyEnabled"] = "true";

                var ex = Assert.Throws<InvalidOperationException>(() => CreateFromConfig(config));
                Assert.That(ex.Message, Does.Contain("HTTPS"));
            }
        }

        [Test]
        [NonParallelizable]
        public void IsAzureProxyEnabled_DefaultsFalse_InvalidProxyIgnored()
        {
            // Invalid proxy URL is present but IsAzureProxyEnabled defaults to false, so no error.
            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "AZURE_TENANT_ID", null },
                { "AZURE_CLIENT_ID", null },
                { "AZURE_FEDERATED_TOKEN_FILE", "/fake/token" },
                { "AZURE_KUBERNETES_TOKEN_PROXY", "http://not-https" },
            }))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:TenantId"] = "test-tenant";
                config["MyClient:Credential:WorkloadIdentityClientId"] = "test-client";

                var credential = CreateFromConfig(config);
                Assert.IsNotNull(GetUnderlying(credential));
            }
        }

        [Test]
        [NonParallelizable]
        public void AllOptions_ConfigWinsOverEnvVars()
        {
            string configTenant = Guid.NewGuid().ToString();
            string configClient = Guid.NewGuid().ToString();
            Uri configAuthority = AzureAuthorityHosts.AzureChina;

            // Set competing env var values for everything.
            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "AZURE_TENANT_ID", "env-tenant" },
                { "AZURE_CLIENT_ID", "env-client" },
                { "AZURE_FEDERATED_TOKEN_FILE", "/fake/token" },
                { "AZURE_AUTHORITY_HOST", AzureAuthorityHosts.AzureGovernment.ToString() },
                { "AZURE_ADDITIONALLY_ALLOWED_TENANTS", "env-extra" },
            }))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:TenantId"] = configTenant;
                config["MyClient:Credential:WorkloadIdentityClientId"] = configClient;
                config["MyClient:Credential:AuthorityHost"] = configAuthority.ToString();
                config["MyClient:Credential:DisableInstanceDiscovery"] = "true";
                config["MyClient:Credential:IsUnsafeSupportLoggingEnabled"] = "true";
                config["MyClient:Credential:AdditionallyAllowedTenants:0"] = "*";

                var credential = CreateFromConfig(config);
                var wic = GetUnderlying(credential);
                var cac = GetClientAssertionCredential(wic);
                Assert.IsNotNull(cac);

                // TenantId and ClientId from config, not env var.
                Assert.AreEqual(configTenant, cac.TenantId);
                Assert.AreEqual(configClient, cac.ClientId);

                // AdditionallyAllowedTenants from config, not env var.
                var tenants = ReadField<string[]>(cac, "AdditionallyAllowedTenantIds");
                CollectionAssert.Contains(tenants, "*");
                CollectionAssert.DoesNotContain(tenants, "env-extra");

                // MSAL-level options from config.
                var msal = GetMsalClient(cac);
                Assert.AreEqual(configAuthority, ReadMsalProperty<Uri>(msal, "AuthorityHost"));
                Assert.IsTrue(ReadMsalProperty<bool>(msal, "DisableInstanceDiscovery"));
                Assert.IsTrue(ReadMsalProperty<bool>(msal, "IsSupportLoggingEnabled"));
            }
        }
    }
}
