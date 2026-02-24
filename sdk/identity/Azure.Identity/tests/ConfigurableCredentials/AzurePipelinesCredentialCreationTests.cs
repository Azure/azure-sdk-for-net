// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core.TestFramework;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace Azure.Identity.Tests.ConfigurableCredentials.AzurePipelines
{
    /// <summary>
    /// Validates that all <see cref="AzurePipelinesCredentialOptions"/> properties can be set
    /// via IConfiguration and that the correct priority order is honoured:
    ///   1. IConfiguration value  (highest)
    ///   2. Well-known environment variable
    ///   3. Hard-coded default     (lowest)
    /// </summary>
    internal class AzurePipelinesCredentialCreationTests : CredentialCreationTestBase<AzurePipelinesCredential>
    {
        protected override string CredentialSource => "AzurePipelines";

        private static object GetMsalClient(AzurePipelinesCredential cred)
            => ReadProperty<object>(cred, "Client");

        private static T ReadMsalProperty<T>(object msalClient, string propertyName)
            => ReadProperty<T>(msalClient, propertyName);

        /// <summary>
        /// Returns env var dictionary with relevant vars nulled out.
        /// </summary>
        private static Dictionary<string, string> AllNulledEnvVars() => new()
        {
            { "AZURE_TENANT_ID", null },
            { "AZURE_CLIENT_ID", null },
            { "AZURE_ADDITIONALLY_ALLOWED_TENANTS", null },
            { "AZURE_AUTHORITY_HOST", null },
            { "SYSTEM_OIDCREQUESTURI", "https://dev.azure.com/myorg/_apis" },
        };

        /// <summary>
        /// Minimum config required to create an AzurePipelinesCredential.
        /// </summary>
        private static void SetRequiredConfig(IConfiguration config,
            string tenantId = "test-tenant",
            string clientId = "test-client",
            string serviceConnectionId = "test-connection",
            string systemAccessToken = "test-token")
        {
            config["MyClient:Credential:TenantId"] = tenantId;
            config["MyClient:Credential:ClientId"] = clientId;
            config["MyClient:Credential:AzurePipelinesServiceConnectionId"] = serviceConnectionId;
            config["MyClient:Credential:AzurePipelinesSystemAccessToken"] = systemAccessToken;
        }

        [Test]
        [NonParallelizable]
        public void TenantId_ConfigWinsOverEnvVar()
        {
            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "AZURE_TENANT_ID", "env-tenant" },
                { "SYSTEM_OIDCREQUESTURI", "https://dev.azure.com/myorg/_apis" },
            }))
            {
                IConfiguration config = Helper.GetConfiguration();
                SetRequiredConfig(config, tenantId: "config-tenant");

                var cred = GetUnderlying(CreateFromConfig(config));

                Assert.IsNotNull(cred);
                Assert.AreEqual("config-tenant", cred.TenantId);
            }
        }

        [Test]
        [NonParallelizable]
        public void TenantId_FallsBackToEnvVar()
        {
            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "AZURE_TENANT_ID", "env-tenant" },
                { "SYSTEM_OIDCREQUESTURI", "https://dev.azure.com/myorg/_apis" },
            }))
            {
                IConfiguration config = Helper.GetConfiguration();
                // TenantId intentionally not set in config — should fall back to env var.
                config["MyClient:Credential:ClientId"] = "test-client";
                config["MyClient:Credential:AzurePipelinesServiceConnectionId"] = "test-connection";
                config["MyClient:Credential:AzurePipelinesSystemAccessToken"] = "test-token";

                var cred = GetUnderlying(CreateFromConfig(config));

                Assert.IsNotNull(cred);
                Assert.AreEqual("env-tenant", cred.TenantId);
            }
        }

        [Test]
        [NonParallelizable]
        public void ServiceConnectionId_FromConfig()
        {
            var envVars = AllNulledEnvVars();
            using (new TestEnvVar(envVars))
            {
                IConfiguration config = Helper.GetConfiguration();
                SetRequiredConfig(config, serviceConnectionId: "my-connection-id");

                var cred = GetUnderlying(CreateFromConfig(config));

                Assert.IsNotNull(cred);
                Assert.AreEqual("my-connection-id", cred.ServiceConnectionId);
            }
        }

        [Test]
        [NonParallelizable]
        public void SystemAccessToken_FromConfig()
        {
            var envVars = AllNulledEnvVars();
            using (new TestEnvVar(envVars))
            {
                IConfiguration config = Helper.GetConfiguration();
                SetRequiredConfig(config, systemAccessToken: "my-system-token");

                var cred = GetUnderlying(CreateFromConfig(config));

                Assert.IsNotNull(cred);
                Assert.AreEqual("my-system-token", cred.SystemAccessToken);
            }
        }

        [Test]
        [NonParallelizable]
        public void MissingTenantId_Throws()
        {
            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "AZURE_TENANT_ID", null },
                { "SYSTEM_OIDCREQUESTURI", "https://dev.azure.com/myorg/_apis" },
            }))
            {
                IConfiguration config = Helper.GetConfiguration();
                // TenantId not set in config and env var is null.
                config["MyClient:Credential:ClientId"] = "test-client";
                config["MyClient:Credential:AzurePipelinesServiceConnectionId"] = "test-connection";
                config["MyClient:Credential:AzurePipelinesSystemAccessToken"] = "test-token";

                Assert.That(() => CreateFromConfig(config), Throws.InstanceOf<ArgumentException>());
            }
        }

        [Test]
        [NonParallelizable]
        public void MissingClientId_Throws()
        {
            var envVars = AllNulledEnvVars();
            using (new TestEnvVar(envVars))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:TenantId"] = "test-tenant";
                // ClientId not set.
                config["MyClient:Credential:AzurePipelinesServiceConnectionId"] = "test-connection";
                config["MyClient:Credential:AzurePipelinesSystemAccessToken"] = "test-token";

                Assert.That(() => CreateFromConfig(config), Throws.InstanceOf<ArgumentException>());
            }
        }

        [Test]
        [NonParallelizable]
        public void MissingServiceConnectionId_Throws()
        {
            var envVars = AllNulledEnvVars();
            using (new TestEnvVar(envVars))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:TenantId"] = "test-tenant";
                config["MyClient:Credential:ClientId"] = "test-client";
                // AzurePipelinesServiceConnectionId not set.
                config["MyClient:Credential:AzurePipelinesSystemAccessToken"] = "test-token";

                Assert.That(() => CreateFromConfig(config), Throws.InstanceOf<ArgumentException>());
            }
        }

        [Test]
        [NonParallelizable]
        public void MissingSystemAccessToken_Throws()
        {
            var envVars = AllNulledEnvVars();
            using (new TestEnvVar(envVars))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:TenantId"] = "test-tenant";
                config["MyClient:Credential:ClientId"] = "test-client";
                config["MyClient:Credential:AzurePipelinesServiceConnectionId"] = "test-connection";
                // AzurePipelinesSystemAccessToken not set.

                Assert.That(() => CreateFromConfig(config), Throws.InstanceOf<ArgumentException>());
            }
        }

        [Test]
        [NonParallelizable]
        public void AuthorityHost_ConfigWinsOverEnvVar()
        {
            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "AZURE_TENANT_ID", null },
                { "AZURE_AUTHORITY_HOST", AzureAuthorityHosts.AzureGovernment.ToString() },
                { "SYSTEM_OIDCREQUESTURI", "https://dev.azure.com/myorg/_apis" },
            }))
            {
                IConfiguration config = Helper.GetConfiguration();
                SetRequiredConfig(config);
                config["MyClient:Credential:AuthorityHost"] = AzureAuthorityHosts.AzureChina.ToString();

                var cred = GetUnderlying(CreateFromConfig(config));
                Assert.IsNotNull(cred);

                Uri actual = ReadMsalProperty<Uri>(GetMsalClient(cred), "AuthorityHost");
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
                { "AZURE_AUTHORITY_HOST", AzureAuthorityHosts.AzureGovernment.ToString() },
                { "SYSTEM_OIDCREQUESTURI", "https://dev.azure.com/myorg/_apis" },
            }))
            {
                IConfiguration config = Helper.GetConfiguration();
                SetRequiredConfig(config);
                // AuthorityHost intentionally not set in config.

                var cred = GetUnderlying(CreateFromConfig(config));
                Assert.IsNotNull(cred);

                Uri actual = ReadMsalProperty<Uri>(GetMsalClient(cred), "AuthorityHost");
                Assert.AreEqual(AzureAuthorityHosts.AzureGovernment, actual);
            }
        }

        [Test]
        [NonParallelizable]
        public void AuthorityHost_DefaultsToAzurePublicCloud()
        {
            var envVars = AllNulledEnvVars();
            using (new TestEnvVar(envVars))
            {
                IConfiguration config = Helper.GetConfiguration();
                SetRequiredConfig(config);

                var cred = GetUnderlying(CreateFromConfig(config));
                Assert.IsNotNull(cred);

                Uri actual = ReadMsalProperty<Uri>(GetMsalClient(cred), "AuthorityHost");
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
                SetRequiredConfig(config);
                config["MyClient:Credential:DisableInstanceDiscovery"] = "true";

                var cred = GetUnderlying(CreateFromConfig(config));
                Assert.IsNotNull(cred);
                Assert.IsTrue(ReadMsalProperty<bool>(GetMsalClient(cred), "DisableInstanceDiscovery"));
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
                SetRequiredConfig(config);

                var cred = GetUnderlying(CreateFromConfig(config));
                Assert.IsNotNull(cred);
                Assert.IsFalse(ReadMsalProperty<bool>(GetMsalClient(cred), "DisableInstanceDiscovery"));
            }
        }

        [Test]
        [NonParallelizable]
        public void AdditionallyAllowedTenants_ConfigWinsOverEnvVar()
        {
            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "AZURE_TENANT_ID", null },
                { "AZURE_ADDITIONALLY_ALLOWED_TENANTS", "env-tenant-x;env-tenant-y" },
                { "SYSTEM_OIDCREQUESTURI", "https://dev.azure.com/myorg/_apis" },
            }))
            {
                IConfiguration config = Helper.GetConfiguration();
                SetRequiredConfig(config);
                config["MyClient:Credential:AdditionallyAllowedTenants:0"] = "config-tenant-a";

                var cred = GetUnderlying(CreateFromConfig(config));
                Assert.IsNotNull(cred);

                var tenants = ReadField<string[]>(cred, "AdditionallyAllowedTenantIds");
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
                { "AZURE_TENANT_ID", null },
                { "AZURE_ADDITIONALLY_ALLOWED_TENANTS", "env-tenant-x;env-tenant-y" },
                { "SYSTEM_OIDCREQUESTURI", "https://dev.azure.com/myorg/_apis" },
            }))
            {
                IConfiguration config = Helper.GetConfiguration();
                SetRequiredConfig(config);
                // AdditionallyAllowedTenants intentionally not set in config.

                var cred = GetUnderlying(CreateFromConfig(config));
                Assert.IsNotNull(cred);

                var tenants = ReadField<string[]>(cred, "AdditionallyAllowedTenantIds");
                Assert.IsNotNull(tenants);
                CollectionAssert.Contains(tenants, "env-tenant-x");
                CollectionAssert.Contains(tenants, "env-tenant-y");
            }
        }

        [Test]
        [NonParallelizable]
        public void AdditionallyAllowedTenants_DefaultsToEmpty()
        {
            var envVars = AllNulledEnvVars();
            using (new TestEnvVar(envVars))
            {
                IConfiguration config = Helper.GetConfiguration();
                SetRequiredConfig(config);

                var cred = GetUnderlying(CreateFromConfig(config));
                Assert.IsNotNull(cred);

                var tenants = ReadField<string[]>(cred, "AdditionallyAllowedTenantIds");
                Assert.IsNotNull(tenants);
                Assert.IsEmpty(tenants);
            }
        }

        [Test]
        [NonParallelizable]
        public void AllOptions_ConfigWinsOverEnvVars()
        {
            string configTenant = Guid.NewGuid().ToString();
            string configClient = Guid.NewGuid().ToString();
            string configConnectionId = Guid.NewGuid().ToString();
            Uri configAuthority = AzureAuthorityHosts.AzureChina;

            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "AZURE_TENANT_ID", "env-tenant" },
                { "AZURE_AUTHORITY_HOST", AzureAuthorityHosts.AzureGovernment.ToString() },
                { "AZURE_ADDITIONALLY_ALLOWED_TENANTS", "env-extra" },
                { "SYSTEM_OIDCREQUESTURI", "https://dev.azure.com/myorg/_apis" },
            }))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:TenantId"] = configTenant;
                config["MyClient:Credential:ClientId"] = configClient;
                config["MyClient:Credential:AzurePipelinesServiceConnectionId"] = configConnectionId;
                config["MyClient:Credential:AzurePipelinesSystemAccessToken"] = "config-token";
                config["MyClient:Credential:AuthorityHost"] = configAuthority.ToString();
                config["MyClient:Credential:DisableInstanceDiscovery"] = "true";
                config["MyClient:Credential:AdditionallyAllowedTenants:0"] = "*";

                var credential = CreateFromConfig(config);
                var cred = GetUnderlying(credential);
                Assert.IsNotNull(cred);

                Assert.AreEqual(configTenant, cred.TenantId);
                Assert.AreEqual(configConnectionId, cred.ServiceConnectionId);
                Assert.AreEqual("config-token", cred.SystemAccessToken);

                var tenants = ReadField<string[]>(cred, "AdditionallyAllowedTenantIds");
                CollectionAssert.Contains(tenants, "*");
                CollectionAssert.DoesNotContain(tenants, "env-extra");

                var msal = GetMsalClient(cred);
                Assert.AreEqual(configAuthority, ReadMsalProperty<Uri>(msal, "AuthorityHost"));
                Assert.IsTrue(ReadMsalProperty<bool>(msal, "DisableInstanceDiscovery"));
            }
        }
    }
}
