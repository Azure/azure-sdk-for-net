// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core.TestFramework;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace Azure.Identity.Tests.ConfigurableCredentials.Environment
{
    /// <summary>
    /// Validates that all <see cref="EnvironmentCredentialOptions"/> properties can be set
    /// via IConfiguration and that the correct priority order is honoured:
    ///   1. IConfiguration value  (highest)
    ///   2. Well-known environment variable
    ///   3. Hard-coded default     (lowest)
    /// </summary>
    internal class EnvironmentCredentialCreationTests : CredentialCreationTestBase<EnvironmentCredential>
    {
        protected override string CredentialSource => "Environment";

        /// <summary>
        /// Env vars needed for EnvironmentCredential to construct a ClientSecretCredential internally.
        /// TenantId, ClientId, and ClientSecret must all be non-empty.
        /// </summary>
        private static Dictionary<string, string> BaseEnvVars(
            string tenantId = "env-tenant",
            string clientId = "env-client",
            string clientSecret = "env-secret") => new()
        {
            { "AZURE_TENANT_ID", tenantId },
            { "AZURE_CLIENT_ID", clientId },
            { "AZURE_CLIENT_SECRET", clientSecret },
            { "AZURE_CLIENT_CERTIFICATE_PATH", null },
            { "AZURE_CLIENT_CERTIFICATE_PASSWORD", null },
            { "AZURE_CLIENT_SEND_CERTIFICATE_CHAIN", null },
            { "AZURE_USERNAME", null },
            { "AZURE_PASSWORD", null },
            { "AZURE_ADDITIONALLY_ALLOWED_TENANTS", null },
            { "AZURE_AUTHORITY_HOST", null },
        };

        /// <summary>
        /// Gets the inner ClientSecretCredential from an EnvironmentCredential.
        /// </summary>
        private static ClientSecretCredential GetInner(EnvironmentCredential envCred)
        {
            var inner = ReadProperty<Azure.Core.TokenCredential>(envCred, "Credential") as ClientSecretCredential;
            Assert.IsNotNull(inner, "EnvironmentCredential should contain a ClientSecretCredential when TENANT+CLIENT+SECRET are set.");
            return inner;
        }

        [Test]
        [NonParallelizable]
        public void TenantId_ConfigWinsOverEnvVar()
        {
            var env = BaseEnvVars();
            using (new TestEnvVar(env))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:TenantId"] = "config-tenant";

                var inner = GetInner(GetUnderlying(CreateFromConfig(config)));
                Assert.AreEqual("config-tenant", ReadProperty<string>(inner, "TenantId"));
            }
        }

        [Test]
        [NonParallelizable]
        public void TenantId_FallsBackToEnvVar()
        {
            var env = BaseEnvVars(tenantId: "env-tenant");
            using (new TestEnvVar(env))
            {
                IConfiguration config = Helper.GetConfiguration();

                var inner = GetInner(GetUnderlying(CreateFromConfig(config)));
                Assert.AreEqual("env-tenant", ReadProperty<string>(inner, "TenantId"));
            }
        }

        [Test]
        [NonParallelizable]
        public void ClientId_ComesFromEnvVar()
        {
            var env = BaseEnvVars(clientId: "my-client-id");
            using (new TestEnvVar(env))
            {
                IConfiguration config = Helper.GetConfiguration();

                var inner = GetInner(GetUnderlying(CreateFromConfig(config)));
                Assert.AreEqual("my-client-id", ReadProperty<string>(inner, "ClientId"));
            }
        }

        [Test]
        [NonParallelizable]
        public void NoCredential_WhenRequiredEnvVarsMissing()
        {
            var env = BaseEnvVars(tenantId: null, clientId: null, clientSecret: null);
            using (new TestEnvVar(env))
            {
                IConfiguration config = Helper.GetConfiguration();

                var envCred = GetUnderlying(CreateFromConfig(config));
                var inner = ReadProperty<Azure.Core.TokenCredential>(envCred, "Credential");
                Assert.IsNull(inner, "EnvironmentCredential should not create an inner credential when env vars are missing.");
            }
        }

        [Test]
        [NonParallelizable]
        public void AuthorityHost_ConfigWinsOverEnvVar()
        {
            var env = BaseEnvVars();
            env["AZURE_AUTHORITY_HOST"] = AzureAuthorityHosts.AzureGovernment.ToString();
            using (new TestEnvVar(env))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:AuthorityHost"] = AzureAuthorityHosts.AzureChina.ToString();

                var inner = GetInner(GetUnderlying(CreateFromConfig(config)));
                var msal = ReadProperty<object>(inner, "Client");
                Assert.AreEqual(AzureAuthorityHosts.AzureChina, ReadProperty<Uri>(msal, "AuthorityHost"));
            }
        }

        [Test]
        [NonParallelizable]
        public void AuthorityHost_FallsBackToEnvVar()
        {
            var env = BaseEnvVars();
            env["AZURE_AUTHORITY_HOST"] = AzureAuthorityHosts.AzureGovernment.ToString();
            using (new TestEnvVar(env))
            {
                IConfiguration config = Helper.GetConfiguration();

                var inner = GetInner(GetUnderlying(CreateFromConfig(config)));
                var msal = ReadProperty<object>(inner, "Client");
                Assert.AreEqual(AzureAuthorityHosts.AzureGovernment, ReadProperty<Uri>(msal, "AuthorityHost"));
            }
        }

        [Test]
        [NonParallelizable]
        public void AuthorityHost_DefaultsToAzurePublicCloud()
        {
            var env = BaseEnvVars();
            using (new TestEnvVar(env))
            {
                IConfiguration config = Helper.GetConfiguration();

                var inner = GetInner(GetUnderlying(CreateFromConfig(config)));
                var msal = ReadProperty<object>(inner, "Client");
                Assert.AreEqual(AzureAuthorityHosts.AzurePublicCloud, ReadProperty<Uri>(msal, "AuthorityHost"));
            }
        }

        [Test]
        [NonParallelizable]
        public void DisableInstanceDiscovery_ConfigSetsTrue()
        {
            var env = BaseEnvVars();
            using (new TestEnvVar(env))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:DisableInstanceDiscovery"] = "true";

                var inner = GetInner(GetUnderlying(CreateFromConfig(config)));
                var msal = ReadProperty<object>(inner, "Client");
                Assert.IsTrue(ReadProperty<bool>(msal, "DisableInstanceDiscovery"));
            }
        }

        [Test]
        [NonParallelizable]
        public void DisableInstanceDiscovery_DefaultsFalse()
        {
            var env = BaseEnvVars();
            using (new TestEnvVar(env))
            {
                IConfiguration config = Helper.GetConfiguration();

                var inner = GetInner(GetUnderlying(CreateFromConfig(config)));
                var msal = ReadProperty<object>(inner, "Client");
                Assert.IsFalse(ReadProperty<bool>(msal, "DisableInstanceDiscovery"));
            }
        }

        [Test]
        [NonParallelizable]
        public void IsUnsafeSupportLoggingEnabled_ConfigSetsTrue()
        {
            var env = BaseEnvVars();
            using (new TestEnvVar(env))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:IsUnsafeSupportLoggingEnabled"] = "true";

                var inner = GetInner(GetUnderlying(CreateFromConfig(config)));
                var msal = ReadProperty<object>(inner, "Client");
                Assert.IsTrue(ReadProperty<bool>(msal, "IsSupportLoggingEnabled"));
            }
        }

        [Test]
        [NonParallelizable]
        public void IsUnsafeSupportLoggingEnabled_DefaultsFalse()
        {
            var env = BaseEnvVars();
            using (new TestEnvVar(env))
            {
                IConfiguration config = Helper.GetConfiguration();

                var inner = GetInner(GetUnderlying(CreateFromConfig(config)));
                var msal = ReadProperty<object>(inner, "Client");
                Assert.IsFalse(ReadProperty<bool>(msal, "IsSupportLoggingEnabled"));
            }
        }

        [Test]
        [NonParallelizable]
        public void AdditionallyAllowedTenants_ConfigWinsOverEnvVar()
        {
            var env = BaseEnvVars();
            env["AZURE_ADDITIONALLY_ALLOWED_TENANTS"] = "env-t1;env-t2";
            using (new TestEnvVar(env))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:AdditionallyAllowedTenants:0"] = "config-t1";

                var inner = GetInner(GetUnderlying(CreateFromConfig(config)));
                var tenants = ReadField<string[]>(inner, "AdditionallyAllowedTenantIds");
                CollectionAssert.Contains(tenants, "config-t1");
                CollectionAssert.DoesNotContain(tenants, "env-t1");
            }
        }

        [Test]
        [NonParallelizable]
        public void AdditionallyAllowedTenants_FallsBackToEnvVar()
        {
            var env = BaseEnvVars();
            env["AZURE_ADDITIONALLY_ALLOWED_TENANTS"] = "env-t1;env-t2";
            using (new TestEnvVar(env))
            {
                IConfiguration config = Helper.GetConfiguration();

                var inner = GetInner(GetUnderlying(CreateFromConfig(config)));
                var tenants = ReadField<string[]>(inner, "AdditionallyAllowedTenantIds");
                CollectionAssert.Contains(tenants, "env-t1");
                CollectionAssert.Contains(tenants, "env-t2");
            }
        }

        [Test]
        [NonParallelizable]
        public void AdditionallyAllowedTenants_DefaultsToEmpty()
        {
            var env = BaseEnvVars();
            using (new TestEnvVar(env))
            {
                IConfiguration config = Helper.GetConfiguration();

                var inner = GetInner(GetUnderlying(CreateFromConfig(config)));
                var tenants = ReadField<string[]>(inner, "AdditionallyAllowedTenantIds");
                Assert.IsNotNull(tenants);
                Assert.IsEmpty(tenants);
            }
        }

        [Test]
        [NonParallelizable]
        public void AllOptions_ConfigWinsOverEnvVars()
        {
            string configTenant = Guid.NewGuid().ToString();

            var env = BaseEnvVars();
            env["AZURE_ADDITIONALLY_ALLOWED_TENANTS"] = "env-extra";
            env["AZURE_AUTHORITY_HOST"] = AzureAuthorityHosts.AzureGovernment.ToString();
            using (new TestEnvVar(env))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:TenantId"] = configTenant;
                config["MyClient:Credential:AuthorityHost"] = AzureAuthorityHosts.AzureChina.ToString();
                config["MyClient:Credential:DisableInstanceDiscovery"] = "true";
                config["MyClient:Credential:IsUnsafeSupportLoggingEnabled"] = "true";
                config["MyClient:Credential:AdditionallyAllowedTenants:0"] = "*";

                var inner = GetInner(GetUnderlying(CreateFromConfig(config)));

                Assert.AreEqual(configTenant, ReadProperty<string>(inner, "TenantId"));

                var tenants = ReadField<string[]>(inner, "AdditionallyAllowedTenantIds");
                CollectionAssert.Contains(tenants, "*");
                CollectionAssert.DoesNotContain(tenants, "env-extra");

                var msal = ReadProperty<object>(inner, "Client");
                Assert.AreEqual(AzureAuthorityHosts.AzureChina, ReadProperty<Uri>(msal, "AuthorityHost"));
                Assert.IsTrue(ReadProperty<bool>(msal, "DisableInstanceDiscovery"));
                Assert.IsTrue(ReadProperty<bool>(msal, "IsSupportLoggingEnabled"));
            }
        }
    }
}
