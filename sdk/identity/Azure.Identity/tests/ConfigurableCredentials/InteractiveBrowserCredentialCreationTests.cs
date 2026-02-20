// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core.TestFramework;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace Azure.Identity.Tests.ConfigurableCredentials.InteractiveBrowser
{
    /// <summary>
    /// Validates that all InteractiveBrowserCredential-specific properties can be set
    /// via IConfiguration and that the correct values are passed through to the
    /// underlying credential.
    /// </summary>
    internal class InteractiveBrowserCredentialCreationTests : CredentialCreationTestBase<InteractiveBrowserCredential>
    {
        protected override string CredentialSource => "InteractiveBrowser";

        private static Dictionary<string, string> AllNulledEnvVars() => new()
        {
            { "AZURE_TENANT_ID", null },
            { "AZURE_ADDITIONALLY_ALLOWED_TENANTS", null },
        };

        [Test]
        [NonParallelizable]
        public void TenantId_ConfigSetsValue()
        {
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:TenantId"] = "config-tenant";

                var ibc = GetUnderlying(CreateFromConfig(config));
                Assert.AreEqual("config-tenant", ReadProperty<string>(ibc, "TenantId"));
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

                var ibc = GetUnderlying(CreateFromConfig(config));
                Assert.AreEqual("env-tenant", ReadProperty<string>(ibc, "TenantId"));
            }
        }

        [Test]
        [NonParallelizable]
        public void TenantId_DefaultsToNull()
        {
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();

                var ibc = GetUnderlying(CreateFromConfig(config));
                Assert.IsNull(ReadProperty<string>(ibc, "TenantId"));
            }
        }

        [Test]
        [NonParallelizable]
        public void ClientId_ConfigSetsValue()
        {
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:InteractiveBrowserCredentialClientId"] = "my-client-id";

                var ibc = GetUnderlying(CreateFromConfig(config));
                Assert.AreEqual("my-client-id", ReadProperty<string>(ibc, "ClientId"));
            }
        }

        [Test]
        [NonParallelizable]
        public void ClientId_DefaultsToDeveloperSignOnClientId()
        {
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();

                var ibc = GetUnderlying(CreateFromConfig(config));
                Assert.AreEqual(Constants.DeveloperSignOnClientId, ReadProperty<string>(ibc, "ClientId"));
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

                var ibc = GetUnderlying(CreateFromConfig(config));
                var tenants = ReadProperty<string[]>(ibc, "AdditionallyAllowedTenantIds");
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

                var ibc = GetUnderlying(CreateFromConfig(config));
                var tenants = ReadProperty<string[]>(ibc, "AdditionallyAllowedTenantIds");
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

                var ibc = GetUnderlying(CreateFromConfig(config));
                var tenants = ReadProperty<string[]>(ibc, "AdditionallyAllowedTenantIds");
                Assert.IsNotNull(tenants);
                Assert.IsEmpty(tenants);
            }
        }

        [Test]
        [NonParallelizable]
        public void DisableAutomaticAuthentication_ConfigSetsTrue()
        {
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:DisableAutomaticAuthentication"] = "true";

                var ibc = GetUnderlying(CreateFromConfig(config));
                Assert.IsTrue(ReadProperty<bool>(ibc, "DisableAutomaticAuthentication"));
            }
        }

        [Test]
        [NonParallelizable]
        public void DisableAutomaticAuthentication_DefaultsFalse()
        {
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();

                var ibc = GetUnderlying(CreateFromConfig(config));
                Assert.IsFalse(ReadProperty<bool>(ibc, "DisableAutomaticAuthentication"));
            }
        }

        [Test]
        [NonParallelizable]
        public void LoginHint_ConfigSetsValue()
        {
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:LoginHint"] = "user@example.com";

                var ibc = GetUnderlying(CreateFromConfig(config));
                Assert.AreEqual("user@example.com", ReadProperty<string>(ibc, "LoginHint"));
            }
        }

        [Test]
        [NonParallelizable]
        public void LoginHint_DefaultsToNull()
        {
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();

                var ibc = GetUnderlying(CreateFromConfig(config));
                Assert.IsNull(ReadProperty<string>(ibc, "LoginHint"));
            }
        }

        [Test]
        [NonParallelizable]
        public void BrowserCustomization_SuccessMessage_ConfigSetsValue()
        {
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:BrowserCustomization:SuccessMessage"] = "<p>Login successful</p>";

                var ibc = GetUnderlying(CreateFromConfig(config));
                var bc = ReadProperty<BrowserCustomizationOptions>(ibc, "BrowserCustomization");
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

                var ibc = GetUnderlying(CreateFromConfig(config));
                var bc = ReadProperty<BrowserCustomizationOptions>(ibc, "BrowserCustomization");
                Assert.IsNotNull(bc);
                Assert.AreEqual("<p>Error: {0}</p>", bc.ErrorMessage);
            }
        }

        [Test]
        [NonParallelizable]
        public void BrowserCustomization_UseEmbeddedWebView_ConfigSetsTrue()
        {
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:BrowserCustomization:UseEmbeddedWebView"] = "true";

                var ibc = GetUnderlying(CreateFromConfig(config));
                var bc = ReadProperty<BrowserCustomizationOptions>(ibc, "BrowserCustomization");
                Assert.IsNotNull(bc);
#pragma warning disable CS0618 // Type or member is obsolete
                Assert.IsTrue(bc.UseEmbeddedWebView);
#pragma warning restore CS0618
            }
        }

        [Test]
        [NonParallelizable]
        public void BrowserCustomization_DefaultsToNull()
        {
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();

                var ibc = GetUnderlying(CreateFromConfig(config));
                Assert.IsNull(ReadProperty<BrowserCustomizationOptions>(ibc, "BrowserCustomization"));
            }
        }

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

                var ibc = GetUnderlying(CreateFromConfig(config));
                var record = ReadProperty<AuthenticationRecord>(ibc, "Record");
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

                var ibc = GetUnderlying(CreateFromConfig(config));
                Assert.IsNull(ReadProperty<AuthenticationRecord>(ibc, "Record"));
            }
        }

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

                var ibc = GetUnderlying(CreateFromConfig(config));

                Assert.AreEqual(configTenant, ReadProperty<string>(ibc, "TenantId"));
                Assert.AreEqual("my-client-id", ReadProperty<string>(ibc, "ClientId"));

                var tenants = ReadProperty<string[]>(ibc, "AdditionallyAllowedTenantIds");
                CollectionAssert.Contains(tenants, "*");
                CollectionAssert.DoesNotContain(tenants, "env-extra");

                Assert.IsTrue(ReadProperty<bool>(ibc, "DisableAutomaticAuthentication"));
                Assert.AreEqual("user@example.com", ReadProperty<string>(ibc, "LoginHint"));

                var bc = ReadProperty<BrowserCustomizationOptions>(ibc, "BrowserCustomization");
                Assert.IsNotNull(bc);
                Assert.AreEqual("<p>OK</p>", bc.SuccessMessage);
                Assert.AreEqual("<p>Fail</p>", bc.ErrorMessage);

                var record = ReadProperty<AuthenticationRecord>(ibc, "Record");
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
