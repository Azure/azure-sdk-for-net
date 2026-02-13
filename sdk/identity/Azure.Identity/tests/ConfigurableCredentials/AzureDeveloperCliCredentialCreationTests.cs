// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core.TestFramework;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace Azure.Identity.Tests.ConfigurableCredentials.AzureDeveloperCli
{
    /// <summary>
    /// Validates that all <see cref="AzureDeveloperCliCredentialOptions"/> properties can be set
    /// via IConfiguration and that the correct priority order is honoured:
    ///   1. IConfiguration value  (highest)
    ///   2. Well-known environment variable
    ///   3. Hard-coded default     (lowest)
    /// </summary>
    internal class AzureDeveloperCliCredentialCreationTests : CredentialCreationTestBase<AzureDeveloperCliCredential>
    {
        protected override string CredentialSource => "AzureDeveloperCli";

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

                var azd = GetUnderlying(CreateFromConfig(config));
                Assert.AreEqual("config-tenant", ReadProperty<string>(azd, "TenantId"));
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

                var azd = GetUnderlying(CreateFromConfig(config));
                Assert.AreEqual("env-tenant", ReadProperty<string>(azd, "TenantId"));
            }
        }

        [Test]
        [NonParallelizable]
        public void TenantId_DefaultsToNull()
        {
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();

                var azd = GetUnderlying(CreateFromConfig(config));
                Assert.IsNull(ReadProperty<string>(azd, "TenantId"));
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

                var azd = GetUnderlying(CreateFromConfig(config));
                var tenants = ReadProperty<string[]>(azd, "AdditionallyAllowedTenantIds");
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

                var azd = GetUnderlying(CreateFromConfig(config));
                var tenants = ReadProperty<string[]>(azd, "AdditionallyAllowedTenantIds");
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

                var azd = GetUnderlying(CreateFromConfig(config));
                var tenants = ReadProperty<string[]>(azd, "AdditionallyAllowedTenantIds");
                Assert.IsNotNull(tenants);
                Assert.IsEmpty(tenants);
            }
        }

        [Test]
        [NonParallelizable]
        public void ProcessTimeout_ConfigSetsValue()
        {
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:CredentialProcessTimeout"] = "00:00:45";

                var azd = GetUnderlying(CreateFromConfig(config));
                Assert.AreEqual(TimeSpan.FromSeconds(45), ReadProperty<TimeSpan>(azd, "ProcessTimeout"));
            }
        }

        [Test]
        [NonParallelizable]
        public void ProcessTimeout_DefaultsToThirtySeconds()
        {
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();

                var azd = GetUnderlying(CreateFromConfig(config));
                // DefaultAzureCredentialOptions.CredentialProcessTimeout defaults to 30s.
                Assert.AreEqual(TimeSpan.FromSeconds(30), ReadProperty<TimeSpan>(azd, "ProcessTimeout"));
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
                config["MyClient:Credential:CredentialProcessTimeout"] = "00:01:00";

                var azd = GetUnderlying(CreateFromConfig(config));

                Assert.AreEqual(configTenant, ReadProperty<string>(azd, "TenantId"));

                var tenants = ReadProperty<string[]>(azd, "AdditionallyAllowedTenantIds");
                CollectionAssert.Contains(tenants, "*");
                CollectionAssert.DoesNotContain(tenants, "env-extra");

                Assert.AreEqual(TimeSpan.FromMinutes(1), ReadProperty<TimeSpan>(azd, "ProcessTimeout"));
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

                var azd = GetUnderlying(CreateFromConfig(config));
                Assert.IsTrue(ReadField<bool>(azd, "_logPII"));
            }
        }

        [Test]
        [NonParallelizable]
        public void IsUnsafeSupportLoggingEnabled_DefaultsFalse()
        {
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();

                var azd = GetUnderlying(CreateFromConfig(config));
                Assert.IsFalse(ReadField<bool>(azd, "_logPII"));
            }
        }
    }
}
