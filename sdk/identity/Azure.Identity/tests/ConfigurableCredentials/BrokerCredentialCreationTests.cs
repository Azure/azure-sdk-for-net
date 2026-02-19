// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core.TestFramework;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace Azure.Identity.Tests.ConfigurableCredentials.Broker
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
        protected override string CredentialSource => "Broker";

        private static Dictionary<string, string> AllNulledEnvVars() => new()
        {
            { "AZURE_TENANT_ID", null },
            { "AZURE_ADDITIONALLY_ALLOWED_TENANTS", null },
        };

        // ── TenantId ───────────────────────────────────────────────────────

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
                config["MyClient:Credential:InteractiveBrowserCredentialClientId"] = "my-client-id";

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
        public void AuthenticationRecord_ConfigSetsValue()
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
                config["MyClient:Credential:InteractiveBrowserCredentialClientId"] = "my-client-id";
                config["MyClient:Credential:AdditionallyAllowedTenants:0"] = "*";
                config["MyClient:Credential:DisableAutomaticAuthentication"] = "true";
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
    }
}
