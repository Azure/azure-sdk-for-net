// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core.TestFramework;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
#if !IDENTITY_TESTS
using Azure.Identity.Tests.ConfigurableCredentials;
#endif

#if IDENTITY_TESTS
namespace Azure.Identity.Tests.ConfigurableCredentials.Broker
#else
namespace Azure.Identity.Broker.Tests.ConfigurableCredentials.Broker
#endif
{
    /// <summary>
    /// Validates that BrokerCredential properties can be set via IConfiguration and
    /// that the correct priority order is honoured:
    ///   1. IConfiguration value  (highest)
    ///   2. Well-known environment variable
    ///   3. Hard-coded default     (lowest)
    ///
    /// BrokerCredential inherits from InteractiveBrowserCredential, so these tests
    /// cover all InteractiveBrowserCredentialOptions properties.  The broker factory
    /// path (CreateBrokerCredential) passes through a subset of them; the remaining
    /// IBC properties are verified to have their expected defaults.
    /// </summary>
    internal class BrokerCredentialCreationTests : CredentialCreationTestBase<BrokerCredential>
    {
        protected override string CredentialSource => nameof(BrokerCredential);

        private static Dictionary<string, string> AllNulledEnvVars() => new()
        {
            { "AZURE_TENANT_ID", null },
            { "AZURE_ADDITIONALLY_ALLOWED_TENANTS", null },
        };

        // ── TenantId ───────────────────────────────────────────────────────

        [Test]
        [NonParallelizable]
        public void TenantId_ConfigSetsValue()
        {
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:TenantId"] = "config-tenant";

                var broker = GetUnderlying(CreateFromConfig(config));
                Assert.AreEqual("config-tenant", ReadProperty<string>(broker, "TenantId"));
            }
        }

        [Test]
        [NonParallelizable]
        public void TenantId_ConfigWinsOverEnvVar()
        {
            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "AZURE_TENANT_ID", "env-tenant" },
                { "AZURE_ADDITIONALLY_ALLOWED_TENANTS", null },
            }))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:TenantId"] = "config-tenant";

                var broker = GetUnderlying(CreateFromConfig(config));
                Assert.AreEqual("config-tenant", ReadProperty<string>(broker, "TenantId"));
            }
        }

        [Test]
        [NonParallelizable]
        public void TenantId_FallsBackToEnvVar()
        {
            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "AZURE_TENANT_ID", "env-tenant" },
                { "AZURE_ADDITIONALLY_ALLOWED_TENANTS", null },
            }))
            {
                IConfiguration config = Helper.GetConfiguration();

                var broker = GetUnderlying(CreateFromConfig(config));
                Assert.AreEqual("env-tenant", ReadProperty<string>(broker, "TenantId"));
            }
        }

        [Test]
        [NonParallelizable]
        public void TenantId_DefaultsToNull()
        {
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();

                var broker = GetUnderlying(CreateFromConfig(config));
                Assert.IsNull(ReadProperty<string>(broker, "TenantId"));
            }
        }

        // ── AdditionallyAllowedTenants ─────────────────────────────────────

        [Test]
        [NonParallelizable]
        public void AdditionallyAllowedTenants_ConfigSetsSingleValue()
        {
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:AdditionallyAllowedTenants:0"] = "tenant-a";

                var broker = GetUnderlying(CreateFromConfig(config));
                var tenants = ReadProperty<string[]>(broker, "AdditionallyAllowedTenantIds");
                Assert.AreEqual(1, tenants.Length);
                Assert.AreEqual("tenant-a", tenants[0]);
            }
        }

        [Test]
        [NonParallelizable]
        public void AdditionallyAllowedTenants_ConfigSetsMultipleValues()
        {
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:AdditionallyAllowedTenants:0"] = "tenant-a";
                config["MyClient:Credential:AdditionallyAllowedTenants:1"] = "tenant-b";
                config["MyClient:Credential:AdditionallyAllowedTenants:2"] = "tenant-c";

                var broker = GetUnderlying(CreateFromConfig(config));
                var tenants = ReadProperty<string[]>(broker, "AdditionallyAllowedTenantIds");
                Assert.AreEqual(3, tenants.Length);
                CollectionAssert.Contains(tenants, "tenant-a");
                CollectionAssert.Contains(tenants, "tenant-b");
                CollectionAssert.Contains(tenants, "tenant-c");
            }
        }

        [Test]
        [NonParallelizable]
        public void AdditionallyAllowedTenants_Wildcard()
        {
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:AdditionallyAllowedTenants:0"] = "*";

                var broker = GetUnderlying(CreateFromConfig(config));
                var tenants = ReadProperty<string[]>(broker, "AdditionallyAllowedTenantIds");
                CollectionAssert.Contains(tenants, "*");
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
            }))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:AdditionallyAllowedTenants:0"] = "config-tenant-a";

                var broker = GetUnderlying(CreateFromConfig(config));
                var tenants = ReadProperty<string[]>(broker, "AdditionallyAllowedTenantIds");
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
            }))
            {
                IConfiguration config = Helper.GetConfiguration();

                var broker = GetUnderlying(CreateFromConfig(config));
                var tenants = ReadProperty<string[]>(broker, "AdditionallyAllowedTenantIds");
                Assert.IsNotNull(tenants);
                CollectionAssert.Contains(tenants, "env-tenant-x");
                CollectionAssert.Contains(tenants, "env-tenant-y");
            }
        }

        [Test]
        [NonParallelizable]
        public void AdditionallyAllowedTenants_DefaultsToEmpty()
        {
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();

                var broker = GetUnderlying(CreateFromConfig(config));
                var tenants = ReadProperty<string[]>(broker, "AdditionallyAllowedTenantIds");
                Assert.IsNotNull(tenants);
                Assert.IsEmpty(tenants);
            }
        }

        // ── ClientId ───────────────────────────────────────────────────────

        [Test]
        [NonParallelizable]
        public void ClientId_ConfigSetsValue()
        {
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:ClientId"] = "my-client-id";

                var broker = GetUnderlying(CreateFromConfig(config));
                Assert.AreEqual("my-client-id", ReadProperty<string>(broker, "ClientId"));
            }
        }

        [Test]
        [NonParallelizable]
        public void ClientId_DefaultsToDeveloperSignOnClientId()
        {
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();

                var broker = GetUnderlying(CreateFromConfig(config));
                Assert.AreEqual(Constants.DeveloperSignOnClientId, ReadProperty<string>(broker, "ClientId"));
            }
        }

        // ── DisableAutomaticAuthentication ─────────────────────────────────

        [Test]
        [NonParallelizable]
        public void DisableAutomaticAuthentication_ConfigSetsTrue()
        {
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:DisableAutomaticAuthentication"] = "true";

                var broker = GetUnderlying(CreateFromConfig(config));
                Assert.IsTrue(ReadProperty<bool>(broker, "DisableAutomaticAuthentication"));
            }
        }

        [Test]
        [NonParallelizable]
        public void DisableAutomaticAuthentication_ConfigSetsFalseExplicitly()
        {
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:DisableAutomaticAuthentication"] = "false";

                var broker = GetUnderlying(CreateFromConfig(config));
                Assert.IsFalse(ReadProperty<bool>(broker, "DisableAutomaticAuthentication"));
            }
        }

        [Test]
        [NonParallelizable]
        public void DisableAutomaticAuthentication_DefaultsFalse()
        {
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();

                var broker = GetUnderlying(CreateFromConfig(config));
                Assert.IsFalse(ReadProperty<bool>(broker, "DisableAutomaticAuthentication"));
            }
        }

        // ── LoginHint ──────────────────────────────────────────────────────

        [Test]
        [NonParallelizable]
        public void LoginHint_ConfigSetsValue()
        {
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:LoginHint"] = "user@example.com";

                var broker = GetUnderlying(CreateFromConfig(config));
                Assert.AreEqual("user@example.com", ReadProperty<string>(broker, "LoginHint"));
            }
        }

        [Test]
        [NonParallelizable]
        public void LoginHint_DefaultsToNull()
        {
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();

                var broker = GetUnderlying(CreateFromConfig(config));
                Assert.IsNull(ReadProperty<string>(broker, "LoginHint"));
            }
        }

        // ── BrowserCustomization ───────────────────────────────────────────

        [Test]
        [NonParallelizable]
        public void BrowserCustomization_SuccessMessage_ConfigSetsValue()
        {
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:BrowserCustomization:SuccessMessage"] = "<p>Login successful</p>";

                var broker = GetUnderlying(CreateFromConfig(config));
                var bc = ReadProperty<BrowserCustomizationOptions>(broker, "BrowserCustomization");
                Assert.IsNotNull(bc);
                Assert.AreEqual("<p>Login successful</p>", bc.SuccessMessage);
            }
        }

        [Test]
        [NonParallelizable]
        public void BrowserCustomization_ErrorMessage_ConfigSetsValue()
        {
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:BrowserCustomization:ErrorMessage"] = "<p>Error: {0}</p>";

                var broker = GetUnderlying(CreateFromConfig(config));
                var bc = ReadProperty<BrowserCustomizationOptions>(broker, "BrowserCustomization");
                Assert.IsNotNull(bc);
                Assert.AreEqual("<p>Error: {0}</p>", bc.ErrorMessage);
            }
        }

        [Test]
        [NonParallelizable]
        public void BrowserCustomization_BothFieldsSet()
        {
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:BrowserCustomization:SuccessMessage"] = "<p>OK</p>";
                config["MyClient:Credential:BrowserCustomization:ErrorMessage"] = "<p>Fail</p>";

                var broker = GetUnderlying(CreateFromConfig(config));
                var bc = ReadProperty<BrowserCustomizationOptions>(broker, "BrowserCustomization");
                Assert.IsNotNull(bc);
                Assert.AreEqual("<p>OK</p>", bc.SuccessMessage);
                Assert.AreEqual("<p>Fail</p>", bc.ErrorMessage);
            }
        }

        [Test]
        [NonParallelizable]
        public void BrowserCustomization_DefaultsToNull()
        {
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();

                var broker = GetUnderlying(CreateFromConfig(config));
                Assert.IsNull(ReadProperty<BrowserCustomizationOptions>(broker, "BrowserCustomization"));
            }
        }

        // ── AuthenticationRecord ───────────────────────────────────────────

        [Test]
        [NonParallelizable]
        public void AuthenticationRecord_ConfigSetsAllFields()
        {
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:AuthenticationRecord:Username"] = "user@contoso.com";
                config["MyClient:Credential:AuthenticationRecord:Authority"] = "login.microsoftonline.com";
                config["MyClient:Credential:AuthenticationRecord:HomeAccountId"] = "object-id.tenant-id";
                config["MyClient:Credential:AuthenticationRecord:TenantId"] = "record-tenant";
                config["MyClient:Credential:AuthenticationRecord:ClientId"] = "record-client";

                var broker = GetUnderlying(CreateFromConfig(config));
                var record = ReadProperty<AuthenticationRecord>(broker, "Record");
                Assert.IsNotNull(record);
                Assert.AreEqual("user@contoso.com", record.Username);
                Assert.AreEqual("login.microsoftonline.com", record.Authority);
                Assert.AreEqual("object-id.tenant-id", record.HomeAccountId);
                Assert.AreEqual("record-tenant", record.TenantId);
                Assert.AreEqual("record-client", record.ClientId);
            }
        }

        [Test]
        [NonParallelizable]
        public void AuthenticationRecord_DefaultsToNull()
        {
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();

                var broker = GetUnderlying(CreateFromConfig(config));
                Assert.IsNull(ReadProperty<AuthenticationRecord>(broker, "Record"));
            }
        }

        // ── RedirectUri ─────────────────────────────────────────────────────

        [Test]
        [NonParallelizable]
        public void RedirectUri_ConfigSetsValue()
        {
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:RedirectUri"] = "http://localhost:12345/";

                var broker = GetUnderlying(CreateFromConfig(config));
                var client = ReadProperty<MsalPublicClient>(broker, "Client");
                Assert.AreEqual("http://localhost:12345/", ReadProperty<string>(client, "RedirectUrl"));
            }
        }

        [Test]
        [NonParallelizable]
        public void RedirectUri_DefaultsToLocalhost()
        {
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();

                string expectedRedirectUrl = "http://localhost";
#if !IDENTITY_TESTS
                // When the broker package is available, the Broker DBO sets a
                // platform-specific redirect URI on macOS.
                if (System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(
                    System.Runtime.InteropServices.OSPlatform.OSX))
                {
                    expectedRedirectUrl = new Uri(Constants.MacBrokerRedirectUri).ToString();
                }
#endif

                var broker = GetUnderlying(CreateFromConfig(config));
                var client = ReadProperty<MsalPublicClient>(broker, "Client");
                Assert.AreEqual(expectedRedirectUrl, ReadProperty<string>(client, "RedirectUrl"));
            }
        }

        // ── TokenCachePersistenceOptions ────────────────────────────────────

        [Test]
        [NonParallelizable]
        public void TokenCachePersistenceOptions_ConfigSetsName()
        {
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:TokenCachePersistenceOptions:Name"] = "my-cache";

                var broker = GetUnderlying(CreateFromConfig(config));
                var client = ReadProperty<MsalPublicClient>(broker, "Client");
                var cacheOptions = ReadField<TokenCachePersistenceOptions>(client, "_tokenCachePersistenceOptions");
                Assert.IsNotNull(cacheOptions);
                Assert.AreEqual("my-cache", cacheOptions.Name);
                Assert.IsFalse(cacheOptions.UnsafeAllowUnencryptedStorage);
            }
        }

        [Test]
        [NonParallelizable]
        public void TokenCachePersistenceOptions_ConfigSetsUnsafeAllowUnencryptedStorage()
        {
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:TokenCachePersistenceOptions:UnsafeAllowUnencryptedStorage"] = "true";

                var broker = GetUnderlying(CreateFromConfig(config));
                var client = ReadProperty<MsalPublicClient>(broker, "Client");
                var cacheOptions = ReadField<TokenCachePersistenceOptions>(client, "_tokenCachePersistenceOptions");
                Assert.IsNotNull(cacheOptions);
                Assert.IsNull(cacheOptions.Name);
                Assert.IsTrue(cacheOptions.UnsafeAllowUnencryptedStorage);
            }
        }

        [Test]
        [NonParallelizable]
        public void TokenCachePersistenceOptions_ConfigSetsBothProperties()
        {
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:TokenCachePersistenceOptions:Name"] = "my-cache";
                config["MyClient:Credential:TokenCachePersistenceOptions:UnsafeAllowUnencryptedStorage"] = "true";

                var broker = GetUnderlying(CreateFromConfig(config));
                var client = ReadProperty<MsalPublicClient>(broker, "Client");
                var cacheOptions = ReadField<TokenCachePersistenceOptions>(client, "_tokenCachePersistenceOptions");
                Assert.IsNotNull(cacheOptions);
                Assert.AreEqual("my-cache", cacheOptions.Name);
                Assert.IsTrue(cacheOptions.UnsafeAllowUnencryptedStorage);
            }
        }

        [Test]
        [NonParallelizable]
        public void TokenCachePersistenceOptions_DefaultsToEmptyInstance()
        {
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();

                var broker = GetUnderlying(CreateFromConfig(config));
                var client = ReadProperty<MsalPublicClient>(broker, "Client");
                var cacheOptions = ReadField<TokenCachePersistenceOptions>(client, "_tokenCachePersistenceOptions");
                Assert.IsNotNull(cacheOptions);
                Assert.IsNull(cacheOptions.Name);
                Assert.IsFalse(cacheOptions.UnsafeAllowUnencryptedStorage);
            }
        }

        // ── DisableInstanceDiscovery ────────────────────────────────────────

        [Test]
        [NonParallelizable]
        public void DisableInstanceDiscovery_ConfigSetsTrue()
        {
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:DisableInstanceDiscovery"] = "true";

                var broker = GetUnderlying(CreateFromConfig(config));
                var client = ReadProperty<MsalPublicClient>(broker, "Client");
                Assert.IsTrue(ReadProperty<bool>(client, "DisableInstanceDiscovery"));
            }
        }

        [Test]
        [NonParallelizable]
        public void DisableInstanceDiscovery_DefaultsFalse()
        {
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();

                var broker = GetUnderlying(CreateFromConfig(config));
                var client = ReadProperty<MsalPublicClient>(broker, "Client");
                Assert.IsFalse(ReadProperty<bool>(client, "DisableInstanceDiscovery"));
            }
        }

        // ── AuthorityHost ──────────────────────────────────────────────────

        [Test]
        [NonParallelizable]
        public void AuthorityHost_ConfigSetsValue()
        {
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:AuthorityHost"] = "https://login.microsoftonline.us/";

                var broker = GetUnderlying(CreateFromConfig(config));
                Assert.AreEqual("https://management.usgovcloudapi.net/.default", ReadProperty<string>(broker, "DefaultScope"));
            }
        }

        [Test]
        [NonParallelizable]
        public void AuthorityHost_DefaultsToPublicCloud()
        {
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();

                var broker = GetUnderlying(CreateFromConfig(config));
                Assert.AreEqual("https://management.azure.com//.default", ReadProperty<string>(broker, "DefaultScope"));
            }
        }

        // ── IsUnsafeSupportLoggingEnabled ──────────────────────────────────

        [Test]
        [NonParallelizable]
        public void IsUnsafeSupportLoggingEnabled_ConfigSetsTrue()
        {
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:IsUnsafeSupportLoggingEnabled"] = "true";

                var broker = GetUnderlying(CreateFromConfig(config));
                var client = ReadProperty<MsalPublicClient>(broker, "Client");
                Assert.IsTrue(ReadProperty<bool>(client, "IsSupportLoggingEnabled"));
            }
        }

        [Test]
        [NonParallelizable]
        public void IsUnsafeSupportLoggingEnabled_DefaultsFalse()
        {
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();

                var broker = GetUnderlying(CreateFromConfig(config));
                var client = ReadProperty<MsalPublicClient>(broker, "Client");
                Assert.IsFalse(ReadProperty<bool>(client, "IsSupportLoggingEnabled"));
            }
        }

        // ── UseDefaultBrokerAccount ────────────────────────────────────────

#if !IDENTITY_TESTS
        // UseDefaultBrokerAccount can only flow through to the underlying credential
        // when the broker package is available, because the fallback IBC options do
        // not implement IMsalSettablePublicClientInitializerOptions.
        [Test]
        [NonParallelizable]
        public void UseDefaultBrokerAccount_ConfigSetsTrue()
        {
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:UseDefaultBrokerAccount"] = "true";

                var broker = GetUnderlying(CreateFromConfig(config));
                Assert.IsTrue(ReadProperty<bool>(broker, "UseOperatingSystemAccount"));
            }
        }
#endif

        [Test]
        [NonParallelizable]
        public void UseDefaultBrokerAccount_ConfigSetsFalseExplicitly()
        {
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:UseDefaultBrokerAccount"] = "false";

                var broker = GetUnderlying(CreateFromConfig(config));
                Assert.IsFalse(ReadProperty<bool>(broker, "UseOperatingSystemAccount"));
            }
        }

        [Test]
        [NonParallelizable]
        public void UseDefaultBrokerAccount_DefaultsFalse()
        {
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();

                var broker = GetUnderlying(CreateFromConfig(config));
                Assert.IsFalse(ReadProperty<bool>(broker, "UseOperatingSystemAccount"));
            }
        }

        // ── IsLegacyMsaPassthroughEnabled ─────────────────────────────────

#if !IDENTITY_TESTS
        // IsLegacyMsaPassthroughEnabled is a DBO-only property that is only meaningful
        // when the broker package is available. These tests require the Broker DBO to
        // override CopyMsalSettableProperties, which will be added once Azure.Identity
        // is published with the internal virtual method.
        [Test]
        [NonParallelizable]
        public void IsLegacyMsaPassthroughEnabled_ConfigSetsFalse()
        {
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:IsLegacyMsaPassthroughEnabled"] = "false";

                // Verify the credential is created without error and broker path is enabled.
                var broker = GetUnderlying(CreateFromConfig(config));
                Assert.IsTrue(ReadField<bool>(broker, "_isBrokerOptionsEnabled"));
            }
        }

        [Test]
        [NonParallelizable]
        public void IsLegacyMsaPassthroughEnabled_ConfigSetsTrue()
        {
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:IsLegacyMsaPassthroughEnabled"] = "true";

                var broker = GetUnderlying(CreateFromConfig(config));
                Assert.IsTrue(ReadField<bool>(broker, "_isBrokerOptionsEnabled"));
            }
        }
#endif

        // ── AllOptions ─────────────────────────────────────────────────────

        [Test]
        [NonParallelizable]
        public void AllOptions_ConfigSetsAllValues()
        {
            string configTenant = Guid.NewGuid().ToString();

            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "AZURE_TENANT_ID", "env-tenant" },
                { "AZURE_ADDITIONALLY_ALLOWED_TENANTS", "env-extra" },
            }))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:TenantId"] = configTenant;
                config["MyClient:Credential:ClientId"] = "my-client-id";
                config["MyClient:Credential:AdditionallyAllowedTenants:0"] = "*";
                config["MyClient:Credential:DisableAutomaticAuthentication"] = "true";
#if !IDENTITY_TESTS
                config["MyClient:Credential:UseDefaultBrokerAccount"] = "true";
#endif
                config["MyClient:Credential:LoginHint"] = "user@example.com";
                config["MyClient:Credential:BrowserCustomization:SuccessMessage"] = "<p>OK</p>";
                config["MyClient:Credential:BrowserCustomization:ErrorMessage"] = "<p>Fail</p>";
                config["MyClient:Credential:AuthenticationRecord:Username"] = "user@contoso.com";
                config["MyClient:Credential:AuthenticationRecord:Authority"] = "login.microsoftonline.com";
                config["MyClient:Credential:AuthenticationRecord:HomeAccountId"] = "oid.tid";
                config["MyClient:Credential:AuthenticationRecord:TenantId"] = "rec-tenant";
                config["MyClient:Credential:AuthenticationRecord:ClientId"] = "rec-client";

                var broker = GetUnderlying(CreateFromConfig(config));

                Assert.AreEqual(configTenant, ReadProperty<string>(broker, "TenantId"));
                Assert.AreEqual("my-client-id", ReadProperty<string>(broker, "ClientId"));

                var tenants = ReadProperty<string[]>(broker, "AdditionallyAllowedTenantIds");
                CollectionAssert.Contains(tenants, "*");
                CollectionAssert.DoesNotContain(tenants, "env-extra");

                Assert.IsTrue(ReadProperty<bool>(broker, "DisableAutomaticAuthentication"));
#if !IDENTITY_TESTS
                Assert.IsTrue(ReadProperty<bool>(broker, "UseOperatingSystemAccount"));
#endif
                Assert.AreEqual("user@example.com", ReadProperty<string>(broker, "LoginHint"));

                var bc = ReadProperty<BrowserCustomizationOptions>(broker, "BrowserCustomization");
                Assert.IsNotNull(bc);
                Assert.AreEqual("<p>OK</p>", bc.SuccessMessage);
                Assert.AreEqual("<p>Fail</p>", bc.ErrorMessage);

                var record = ReadProperty<AuthenticationRecord>(broker, "Record");
                Assert.IsNotNull(record);
                Assert.AreEqual("user@contoso.com", record.Username);
                Assert.AreEqual("login.microsoftonline.com", record.Authority);
                Assert.AreEqual("oid.tid", record.HomeAccountId);
                Assert.AreEqual("rec-tenant", record.TenantId);
                Assert.AreEqual("rec-client", record.ClientId);
            }
        }

        [Test]
        [NonParallelizable]
        public void AllOptions_DefaultsWhenNothingSet()
        {
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();

                var broker = GetUnderlying(CreateFromConfig(config));

                Assert.IsNull(ReadProperty<string>(broker, "TenantId"));
                Assert.AreEqual(Constants.DeveloperSignOnClientId, ReadProperty<string>(broker, "ClientId"));
                Assert.IsEmpty(ReadProperty<string[]>(broker, "AdditionallyAllowedTenantIds"));
                Assert.IsFalse(ReadProperty<bool>(broker, "DisableAutomaticAuthentication"));
#if !IDENTITY_TESTS
                Assert.IsFalse(ReadProperty<bool>(broker, "UseOperatingSystemAccount"));
#endif
                Assert.IsNull(ReadProperty<string>(broker, "LoginHint"));
                Assert.IsNull(ReadProperty<BrowserCustomizationOptions>(broker, "BrowserCustomization"));
                Assert.IsNull(ReadProperty<AuthenticationRecord>(broker, "Record"));
            }
        }
    }
}
