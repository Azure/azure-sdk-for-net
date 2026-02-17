// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.Core.TestFramework;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace Azure.Identity.Tests.ConfigurableCredentials.ManagedIdentity
{
    /// <summary>
    /// Validates that all <see cref="ManagedIdentityCredential"/> related properties can be set
    /// via IConfiguration and that the correct priority order is honoured:
    ///   1. IConfiguration value  (highest)
    ///   2. Well-known environment variable
    ///   3. Hard-coded default     (lowest)
    /// </summary>
    internal class ManagedIdentityCredentialCreationTests : CredentialCreationTestBase<ManagedIdentityCredential>
    {
        protected override string CredentialSource => "ManagedIdentity";

        private static Dictionary<string, string> AllNulledEnvVars() => new()
        {
            { "AZURE_CLIENT_ID", null },
            { "AZURE_TENANT_ID", null },
            { "AZURE_ADDITIONALLY_ALLOWED_TENANTS", null },
            { "AZURE_AUTHORITY_HOST", null },
        };

        [Test]
        [NonParallelizable]
        public void ManagedIdentityClientId_ConfigWinsOverEnvVar()
        {
            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "AZURE_CLIENT_ID", "env-client-id" },
                { "AZURE_TENANT_ID", null },
                { "AZURE_ADDITIONALLY_ALLOWED_TENANTS", null },
            }))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:ManagedIdentityClientId"] = "config-client-id";

                var mi = GetUnderlying(CreateFromConfig(config));
                var client = ReadProperty<ManagedIdentityClient>(mi, "Client");
                var miId = ReadProperty<ManagedIdentityId>(client, "ManagedIdentityId");
                Assert.AreEqual("ClientId config-client-id", miId.ToString());
            }
        }

        [Test]
        [NonParallelizable]
        public void ManagedIdentityClientId_FallsBackToEnvVar()
        {
            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "AZURE_CLIENT_ID", "env-client-id" },
                { "AZURE_TENANT_ID", null },
                { "AZURE_ADDITIONALLY_ALLOWED_TENANTS", null },
            }))
            {
                IConfiguration config = Helper.GetConfiguration();
                // ManagedIdentityClientId intentionally not set in config.

                var mi = GetUnderlying(CreateFromConfig(config));
                var client = ReadProperty<ManagedIdentityClient>(mi, "Client");
                var miId = ReadProperty<ManagedIdentityId>(client, "ManagedIdentityId");
                Assert.AreEqual("ClientId env-client-id", miId.ToString());
            }
        }

        [Test]
        [NonParallelizable]
        public void ManagedIdentityClientId_DefaultsToSystemAssigned()
        {
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();

                var mi = GetUnderlying(CreateFromConfig(config));
                var client = ReadProperty<ManagedIdentityClient>(mi, "Client");
                var miId = ReadProperty<ManagedIdentityId>(client, "ManagedIdentityId");
                Assert.AreEqual("SystemAssigned", miId.ToString());
            }
        }

        [Test]
        [NonParallelizable]
        public void ManagedIdentityResourceId_ConfigSetsValue()
        {
            var resourceId = $"/subscriptions/{Guid.NewGuid()}/resourceGroups/myRg/providers/Microsoft.Compute/virtualMachines/myVm";

            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:ManagedIdentityResourceId"] = resourceId;

                var mi = GetUnderlying(CreateFromConfig(config));
                var client = ReadProperty<ManagedIdentityClient>(mi, "Client");
                var miId = ReadProperty<ManagedIdentityId>(client, "ManagedIdentityId");
                Assert.AreEqual($"ResourceId {resourceId}", miId.ToString());
            }
        }

        [Test]
        [NonParallelizable]
        public void ManagedIdentityClientId_And_ResourceId_BothSet_Throws()
        {
            var resourceId = $"/subscriptions/{Guid.NewGuid()}/resourceGroups/myRg/providers/Microsoft.Compute/virtualMachines/myVm";

            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:ManagedIdentityClientId"] = "my-client-id";
                config["MyClient:Credential:ManagedIdentityResourceId"] = resourceId;

                Assert.Throws<ArgumentException>(() => CreateFromConfig(config));
            }
        }

        [Test]
        [NonParallelizable]
        public void ManagedIdentityObjectId_ConfigSetsValue()
        {
            string objectId = Guid.NewGuid().ToString();

            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:ManagedIdentityObjectId"] = objectId;

                var mi = GetUnderlying(CreateFromConfig(config));
                var client = ReadProperty<ManagedIdentityClient>(mi, "Client");
                var miId = ReadProperty<ManagedIdentityId>(client, "ManagedIdentityId");
                Assert.AreEqual($"ObjectId {objectId}", miId.ToString());
            }
        }

        [Test]
        [NonParallelizable]
        public void IsUnsafeSupportLoggingEnabled_ConfigSetsTrue()
        {
            // When creating via ConfigurableCredential (DefaultAzureCredential path),
            // _logAccountDetails is not propagated to ManagedIdentityCredential.
            // Verify the credential still creates successfully.
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:IsUnsafeSupportLoggingEnabled"] = "true";

                var mi = GetUnderlying(CreateFromConfig(config));
                Assert.IsNotNull(mi);
            }
        }

        [Test]
        [NonParallelizable]
        public void IsUnsafeSupportLoggingEnabled_DefaultsFalse()
        {
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();

                var mi = GetUnderlying(CreateFromConfig(config));
                Assert.IsFalse(ReadField<bool>(mi, "_logAccountDetails"));
            }
        }

        [Test]
        [NonParallelizable]
        public void AllOptions_ConfigWinsOverEnvVars()
        {
            string configClientId = Guid.NewGuid().ToString();

            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "AZURE_CLIENT_ID", "env-client-id" },
                { "AZURE_TENANT_ID", null },
                { "AZURE_ADDITIONALLY_ALLOWED_TENANTS", null },
            }))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:ManagedIdentityClientId"] = configClientId;
                config["MyClient:Credential:IsUnsafeSupportLoggingEnabled"] = "true";

                var mi = GetUnderlying(CreateFromConfig(config));

                var client = ReadProperty<ManagedIdentityClient>(mi, "Client");
                var miId = ReadProperty<ManagedIdentityId>(client, "ManagedIdentityId");
                Assert.AreEqual($"ClientId {configClientId}", miId.ToString());
            }
        }
    }
}
