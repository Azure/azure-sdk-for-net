// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.Core.TestFramework;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace Azure.Identity.Tests.ConfigurableCredentials.ClientAssertion
{
    /// <summary>
    /// Validates that all properties required for ClientAssertionCredential
    /// can be set via IConfiguration and that the correct priority order is honoured:
    ///   1. IConfiguration value  (highest)
    ///   2. Well-known environment variable
    ///   3. Hard-coded default     (lowest)
    /// </summary>
    internal class ClientAssertionCredentialCreationTests : CredentialCreationTestBase<ClientAssertionCredential>
    {
        protected override string CredentialSource => "ManagedIdentityAsFederatedIdentityCredential";

        protected override Dictionary<string, string> GetRequiredConfigValues() => new()
        {
            { "TenantId", "test-tenant" },
            { "ClientId", "test-client" },
            { "AzureCloud", "public" },
            { "ManagedIdentityIdKind", "ClientId" },
            { "ManagedIdentityId", "test-mi-client-id" },
        };

        private static object GetMsalClient(ClientAssertionCredential cred)
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
        };

        /// <summary>
        /// Minimum config required to create a ClientAssertionCredential via configurable flow.
        /// </summary>
        private static void SetRequiredConfig(IConfiguration config,
            string tenantId = "test-tenant",
            string clientId = "test-client",
            string azureCloud = "public",
            string managedIdentityIdKind = "ClientId",
            string managedIdentityId = "test-mi-client-id")
        {
            config["MyClient:Credential:TenantId"] = tenantId;
            config["MyClient:Credential:ClientId"] = clientId;
            config["MyClient:Credential:AzureCloud"] = azureCloud;
            config["MyClient:Credential:ManagedIdentityIdKind"] = managedIdentityIdKind;
            config["MyClient:Credential:ManagedIdentityId"] = managedIdentityId;
        }

        [Test]
        [NonParallelizable]
        public void TenantId_ConfigWinsOverEnvVar()
        {
            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "AZURE_TENANT_ID", "env-tenant" },
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
            }))
            {
                IConfiguration config = Helper.GetConfiguration();
                // TenantId intentionally not set in config — should fall back to env var.
                config["MyClient:Credential:ClientId"] = "test-client";
                config["MyClient:Credential:AzureCloud"] = "public";
                config["MyClient:Credential:ManagedIdentityIdKind"] = "ClientId";
                config["MyClient:Credential:ManagedIdentityId"] = "test-mi-client-id";

                var cred = GetUnderlying(CreateFromConfig(config));

                Assert.IsNotNull(cred);
                Assert.AreEqual("env-tenant", cred.TenantId);
            }
        }

        [Test]
        [NonParallelizable]
        public void ClientId_FromConfig()
        {
            var envVars = AllNulledEnvVars();
            using (new TestEnvVar(envVars))
            {
                IConfiguration config = Helper.GetConfiguration();
                SetRequiredConfig(config, clientId: "my-sp-client-id");

                var cred = GetUnderlying(CreateFromConfig(config));

                Assert.IsNotNull(cred);
                Assert.AreEqual("my-sp-client-id", cred.ClientId);
            }
        }

        [Test]
        [NonParallelizable]
        public void MissingTenantId_Throws()
        {
            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "AZURE_TENANT_ID", null },
            }))
            {
                IConfiguration config = Helper.GetConfiguration();
                // TenantId not set in config and env var is null.
                config["MyClient:Credential:ClientId"] = "test-client";
                config["MyClient:Credential:AzureCloud"] = "public";
                config["MyClient:Credential:ManagedIdentityIdKind"] = "ClientId";
                config["MyClient:Credential:ManagedIdentityId"] = "test-mi-client-id";

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
                config["MyClient:Credential:AzureCloud"] = "public";
                config["MyClient:Credential:ManagedIdentityIdKind"] = "ClientId";
                config["MyClient:Credential:ManagedIdentityId"] = "test-mi-client-id";

                Assert.That(() => CreateFromConfig(config), Throws.InstanceOf<ArgumentException>());
            }
        }

        [Test]
        [NonParallelizable]
        public void MissingAzureCloud_Throws()
        {
            var envVars = AllNulledEnvVars();
            using (new TestEnvVar(envVars))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:TenantId"] = "test-tenant";
                config["MyClient:Credential:ClientId"] = "test-client";
                // AzureCloud not set.
                config["MyClient:Credential:ManagedIdentityIdKind"] = "ClientId";
                config["MyClient:Credential:ManagedIdentityId"] = "test-mi-client-id";

                Assert.That(() => CreateFromConfig(config), Throws.InstanceOf<ArgumentException>());
            }
        }

        [Test]
        [NonParallelizable]
        public void MissingManagedIdentity_Throws()
        {
            var envVars = AllNulledEnvVars();
            using (new TestEnvVar(envVars))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:TenantId"] = "test-tenant";
                config["MyClient:Credential:ClientId"] = "test-client";
                config["MyClient:Credential:AzureCloud"] = "public";
                // ManagedIdentityIdKind and ManagedIdentityId not set.

                Assert.That(() => CreateFromConfig(config), Throws.InstanceOf<ArgumentException>());
            }
        }

        [Test]
        [NonParallelizable]
        public void InvalidAzureCloud_Throws()
        {
            var envVars = AllNulledEnvVars();
            using (new TestEnvVar(envVars))
            {
                IConfiguration config = Helper.GetConfiguration();
                SetRequiredConfig(config, azureCloud: "invalid-cloud");

                Assert.That(() => CreateFromConfig(config), Throws.InstanceOf<ArgumentException>());
            }
        }

        [Test]
        [NonParallelizable]
        public void SystemAssigned_ManagedIdentityIdKind_Throws()
        {
            var envVars = AllNulledEnvVars();
            using (new TestEnvVar(envVars))
            {
                IConfiguration config = Helper.GetConfiguration();
                SetRequiredConfig(config, managedIdentityIdKind: "SystemAssigned", managedIdentityId: null);

                Assert.That(() => CreateFromConfig(config), Throws.InstanceOf<ArgumentException>());
            }
        }

        [Test]
        [NonParallelizable]
        public void ManagedIdentityIdKind_ClientId_CreatesCredential()
        {
            var envVars = AllNulledEnvVars();
            using (new TestEnvVar(envVars))
            {
                IConfiguration config = Helper.GetConfiguration();
                SetRequiredConfig(config, managedIdentityIdKind: "ClientId", managedIdentityId: "mi-client-id-123");

                var cred = GetUnderlying(CreateFromConfig(config));

                Assert.IsNotNull(cred);
                Assert.AreEqual("test-tenant", cred.TenantId);
                Assert.AreEqual("test-client", cred.ClientId);
            }
        }

        [Test]
        [NonParallelizable]
        public void ManagedIdentityIdKind_ObjectId_CreatesCredential()
        {
            var envVars = AllNulledEnvVars();
            using (new TestEnvVar(envVars))
            {
                IConfiguration config = Helper.GetConfiguration();
                SetRequiredConfig(config, managedIdentityIdKind: "ObjectId", managedIdentityId: "mi-object-id-456");

                var cred = GetUnderlying(CreateFromConfig(config));

                Assert.IsNotNull(cred);
                Assert.AreEqual("test-tenant", cred.TenantId);
                Assert.AreEqual("test-client", cred.ClientId);
            }
        }

        [Test]
        [NonParallelizable]
        public void ManagedIdentityIdKind_ResourceId_CreatesCredential()
        {
            var envVars = AllNulledEnvVars();
            using (new TestEnvVar(envVars))
            {
                IConfiguration config = Helper.GetConfiguration();
                SetRequiredConfig(config, managedIdentityIdKind: "ResourceId",
                    managedIdentityId: "/subscriptions/sub-id/resourceGroups/rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/mi-name");

                var cred = GetUnderlying(CreateFromConfig(config));

                Assert.IsNotNull(cred);
                Assert.AreEqual("test-tenant", cred.TenantId);
                Assert.AreEqual("test-client", cred.ClientId);
            }
        }

        [Test]
        [NonParallelizable]
        public void AzureCloud_Public_CreatesCredential()
        {
            var envVars = AllNulledEnvVars();
            using (new TestEnvVar(envVars))
            {
                IConfiguration config = Helper.GetConfiguration();
                SetRequiredConfig(config, azureCloud: "public");

                var cred = GetUnderlying(CreateFromConfig(config));
                Assert.IsNotNull(cred);
            }
        }

        [Test]
        [NonParallelizable]
        public void AzureCloud_USGov_CreatesCredential()
        {
            var envVars = AllNulledEnvVars();
            using (new TestEnvVar(envVars))
            {
                IConfiguration config = Helper.GetConfiguration();
                SetRequiredConfig(config, azureCloud: "usgov");

                var cred = GetUnderlying(CreateFromConfig(config));
                Assert.IsNotNull(cred);
            }
        }

        [Test]
        [NonParallelizable]
        public void AzureCloud_China_CreatesCredential()
        {
            var envVars = AllNulledEnvVars();
            using (new TestEnvVar(envVars))
            {
                IConfiguration config = Helper.GetConfiguration();
                SetRequiredConfig(config, azureCloud: "china");

                var cred = GetUnderlying(CreateFromConfig(config));
                Assert.IsNotNull(cred);
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
                { "AZURE_AUTHORITY_HOST", AzureAuthorityHosts.AzureGovernment.ToString() },
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
                { "AZURE_CLIENT_ID", null },
                { "AZURE_AUTHORITY_HOST", AzureAuthorityHosts.AzureGovernment.ToString() },
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
                { "AZURE_CLIENT_ID", null },
                { "AZURE_ADDITIONALLY_ALLOWED_TENANTS", "env-tenant-x;env-tenant-y" },
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
                { "AZURE_CLIENT_ID", null },
                { "AZURE_ADDITIONALLY_ALLOWED_TENANTS", "env-tenant-x;env-tenant-y" },
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
            Uri configAuthority = AzureAuthorityHosts.AzureChina;

            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "AZURE_TENANT_ID", "env-tenant" },
                { "AZURE_CLIENT_ID", null },
                { "AZURE_AUTHORITY_HOST", AzureAuthorityHosts.AzureGovernment.ToString() },
                { "AZURE_ADDITIONALLY_ALLOWED_TENANTS", "env-extra" },
            }))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:TenantId"] = configTenant;
                config["MyClient:Credential:ClientId"] = configClient;
                config["MyClient:Credential:AzureCloud"] = "usgov";
                config["MyClient:Credential:ManagedIdentityIdKind"] = "ClientId";
                config["MyClient:Credential:ManagedIdentityId"] = "mi-client-id-123";
                config["MyClient:Credential:AuthorityHost"] = configAuthority.ToString();
                config["MyClient:Credential:DisableInstanceDiscovery"] = "true";
                config["MyClient:Credential:AdditionallyAllowedTenants:0"] = "*";

                var credential = CreateFromConfig(config);
                var cred = GetUnderlying(credential);
                Assert.IsNotNull(cred);

                Assert.AreEqual(configTenant, cred.TenantId);
                Assert.AreEqual(configClient, cred.ClientId);

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
