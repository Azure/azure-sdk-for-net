// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core.TestFramework;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace Azure.Identity.Tests.ConfigurableCredentials.VisualStudioCode
{
    /// <summary>
    /// Validates that all <see cref="VisualStudioCodeCredentialOptions"/> properties can be set
    /// via IConfiguration and that the correct priority order is honoured:
    ///   1. IConfiguration value  (highest)
    ///   2. Well-known environment variable
    ///   3. Hard-coded default     (lowest)
    /// </summary>
    internal class VisualStudioCodeCredentialCreationTests : CredentialCreationTestBase<VisualStudioCodeCredential>
    {
        protected override string CredentialSource => "VisualStudioCode";

        private static Dictionary<string, string> AllNulledEnvVars() => new()
        {
            { "AZURE_TENANT_ID", null },
            { "AZURE_ADDITIONALLY_ALLOWED_TENANTS", null },
        };

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

                var vsc = GetUnderlying(CreateFromConfig(config));
                Assert.AreEqual("config-tenant", ReadProperty<string>(vsc, "TenantId"));
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
                // TenantId intentionally not set in config.

                var vsc = GetUnderlying(CreateFromConfig(config));
                Assert.AreEqual("env-tenant", ReadProperty<string>(vsc, "TenantId"));
            }
        }

        [Test]
        [NonParallelizable]
        public void TenantId_DefaultsToNull()
        {
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();

                var vsc = GetUnderlying(CreateFromConfig(config));
                Assert.IsNull(ReadProperty<string>(vsc, "TenantId"));
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

                var vsc = GetUnderlying(CreateFromConfig(config));
                var tenants = ReadProperty<string[]>(vsc, "AdditionallyAllowedTenantIds");
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
                // AdditionallyAllowedTenants intentionally not set in config.

                var vsc = GetUnderlying(CreateFromConfig(config));
                var tenants = ReadProperty<string[]>(vsc, "AdditionallyAllowedTenantIds");
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

                var vsc = GetUnderlying(CreateFromConfig(config));
                var tenants = ReadProperty<string[]>(vsc, "AdditionallyAllowedTenantIds");
                Assert.IsNotNull(tenants);
                Assert.IsEmpty(tenants);
            }
        }

        [Test]
        [NonParallelizable]
        public void AllOptions_ConfigWinsOverEnvVars()
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
                config["MyClient:Credential:AdditionallyAllowedTenants:0"] = "*";

                var vsc = GetUnderlying(CreateFromConfig(config));

                Assert.AreEqual(configTenant, ReadProperty<string>(vsc, "TenantId"));

                var tenants = ReadProperty<string[]>(vsc, "AdditionallyAllowedTenantIds");
                CollectionAssert.Contains(tenants, "*");
                CollectionAssert.DoesNotContain(tenants, "env-extra");
            }
        }

        [Test]
        [NonParallelizable]
        public void AuthorityHost_ConfigWinsOverEnvVar()
        {
            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "AZURE_TENANT_ID", null },
                { "AZURE_ADDITIONALLY_ALLOWED_TENANTS", null },
                { "AZURE_AUTHORITY_HOST", AzureAuthorityHosts.AzureGovernment.ToString() },
            }))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:AuthorityHost"] = AzureAuthorityHosts.AzureChina.ToString();

                var vsc = GetUnderlying(CreateFromConfig(config));
                var msal = ReadProperty<object>(vsc, "Client");
                Assert.AreEqual(AzureAuthorityHosts.AzureChina, ReadProperty<Uri>(msal, "AuthorityHost"));
            }
        }

        [Test]
        [NonParallelizable]
        public void AuthorityHost_FallsBackToEnvVar()
        {
            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "AZURE_TENANT_ID", null },
                { "AZURE_ADDITIONALLY_ALLOWED_TENANTS", null },
                { "AZURE_AUTHORITY_HOST", AzureAuthorityHosts.AzureGovernment.ToString() },
            }))
            {
                IConfiguration config = Helper.GetConfiguration();

                var vsc = GetUnderlying(CreateFromConfig(config));
                var msal = ReadProperty<object>(vsc, "Client");
                Assert.AreEqual(AzureAuthorityHosts.AzureGovernment, ReadProperty<Uri>(msal, "AuthorityHost"));
            }
        }

        [Test]
        [NonParallelizable]
        public void AuthorityHost_DefaultsToAzurePublicCloud()
        {
            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "AZURE_TENANT_ID", null },
                { "AZURE_ADDITIONALLY_ALLOWED_TENANTS", null },
                { "AZURE_AUTHORITY_HOST", null },
            }))
            {
                IConfiguration config = Helper.GetConfiguration();

                var vsc = GetUnderlying(CreateFromConfig(config));
                var msal = ReadProperty<object>(vsc, "Client");
                Assert.AreEqual(AzureAuthorityHosts.AzurePublicCloud, ReadProperty<Uri>(msal, "AuthorityHost"));
            }
        }

        [Test]
        [NonParallelizable]
        public void IsUnsafeSupportLoggingEnabled_ConfigSetsTrue()
        {
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:IsUnsafeSupportLoggingEnabled"] = "true";

                var vsc = GetUnderlying(CreateFromConfig(config));
                var msal = ReadProperty<object>(vsc, "Client");
                Assert.IsTrue(ReadProperty<bool>(msal, "IsSupportLoggingEnabled"));
            }
        }

        [Test]
        [NonParallelizable]
        public void IsUnsafeSupportLoggingEnabled_DefaultsFalse()
        {
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();

                var vsc = GetUnderlying(CreateFromConfig(config));
                var msal = ReadProperty<object>(vsc, "Client");
                Assert.IsFalse(ReadProperty<bool>(msal, "IsSupportLoggingEnabled"));
            }
        }
    }
}
