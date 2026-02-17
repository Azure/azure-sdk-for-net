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
    /// via IConfiguration and that the correct priority order is honoured.
    /// Tests cover both the new ManagedIdentityIdKind/ManagedIdentityId config properties
    /// and the legacy ManagedIdentityClientId/ManagedIdentityResourceId/ManagedIdentityObjectId properties.
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

        private ManagedIdentityId GetManagedIdentityId(IConfiguration config)
        {
            var mi = GetUnderlying(CreateFromConfig(config));
            var client = ReadProperty<ManagedIdentityClient>(mi, "Client");
            return ReadProperty<ManagedIdentityId>(client, "ManagedIdentityId");
        }

        private void AssertManagedIdentityId(ManagedIdentityId miId, ManagedIdentityIdType expectedType, string expectedId = null)
        {
            Assert.AreEqual(expectedType, ReadField<ManagedIdentityIdType>(miId, "_idType"));
            Assert.AreEqual(expectedId, ReadField<string>(miId, "_userAssignedId"));
        }

        #region ManagedIdentityIdKind / ManagedIdentityId (new config properties)

        [Test]
        [NonParallelizable]
        public void IdType_SystemAssigned()
        {
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:ManagedIdentityIdKind"] = "SystemAssigned";

                AssertManagedIdentityId(GetManagedIdentityId(config), ManagedIdentityIdType.SystemAssigned);
            }
        }

        [Test]
        [NonParallelizable]
        public void IdType_ClientId()
        {
            string clientId = Guid.NewGuid().ToString();
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:ManagedIdentityIdKind"] = "ClientId";
                config["MyClient:Credential:ManagedIdentityId"] = clientId;

                AssertManagedIdentityId(GetManagedIdentityId(config), ManagedIdentityIdType.ClientId, clientId);
            }
        }

        [Test]
        [NonParallelizable]
        public void IdType_ResourceId()
        {
            var resourceId = $"/subscriptions/{Guid.NewGuid()}/resourceGroups/myRg/providers/Microsoft.Compute/virtualMachines/myVm";
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:ManagedIdentityIdKind"] = "ResourceId";
                config["MyClient:Credential:ManagedIdentityId"] = resourceId;

                AssertManagedIdentityId(GetManagedIdentityId(config), ManagedIdentityIdType.ResourceId, resourceId);
            }
        }

        [Test]
        [NonParallelizable]
        public void IdType_ObjectId()
        {
            string objectId = Guid.NewGuid().ToString();
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:ManagedIdentityIdKind"] = "ObjectId";
                config["MyClient:Credential:ManagedIdentityId"] = objectId;

                AssertManagedIdentityId(GetManagedIdentityId(config), ManagedIdentityIdType.ObjectId, objectId);
            }
        }

        [Test]
        [NonParallelizable]
        public void IdType_WinsOverLegacyClientId()
        {
            string newId = Guid.NewGuid().ToString();
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:ManagedIdentityClientId"] = "legacy-client-id";
                config["MyClient:Credential:ManagedIdentityIdKind"] = "ClientId";
                config["MyClient:Credential:ManagedIdentityId"] = newId;

                AssertManagedIdentityId(GetManagedIdentityId(config), ManagedIdentityIdType.ClientId, newId);
            }
        }

        [Test]
        [NonParallelizable]
        public void IdType_InvalidValue_Throws()
        {
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:ManagedIdentityIdKind"] = "BadValue";
                config["MyClient:Credential:ManagedIdentityId"] = "some-id";

                Assert.Throws<ArgumentException>(() => CreateFromConfig(config));
            }
        }

        [Test]
        [NonParallelizable]
        public void IdType_ClientId_MissingId_Throws()
        {
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:ManagedIdentityIdKind"] = "ClientId";
                // ManagedIdentityId intentionally not set

                Assert.Throws<ArgumentNullException>(() => CreateFromConfig(config));
            }
        }

        [Test]
        [NonParallelizable]
        public void IdType_ResourceId_MissingId_Throws()
        {
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:ManagedIdentityIdKind"] = "ResourceId";
                // ManagedIdentityId intentionally not set

                Assert.Throws<ArgumentNullException>(() => CreateFromConfig(config));
            }
        }

        [Test]
        [NonParallelizable]
        public void IdType_ObjectId_MissingId_Throws()
        {
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:ManagedIdentityIdKind"] = "ObjectId";
                // ManagedIdentityId intentionally not set

                Assert.Throws<ArgumentNullException>(() => CreateFromConfig(config));
            }
        }

        #endregion

        #region Legacy config properties (ManagedIdentityClientId, ManagedIdentityResourceId, ManagedIdentityObjectId)

        [Test]
        [NonParallelizable]
        public void LegacyClientId_ConfigWinsOverEnvVar()
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

                AssertManagedIdentityId(GetManagedIdentityId(config), ManagedIdentityIdType.ClientId, "config-client-id");
            }
        }

        [Test]
        [NonParallelizable]
        public void LegacyClientId_FallsBackToEnvVar()
        {
            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "AZURE_CLIENT_ID", "env-client-id" },
                { "AZURE_TENANT_ID", null },
                { "AZURE_ADDITIONALLY_ALLOWED_TENANTS", null },
            }))
            {
                IConfiguration config = Helper.GetConfiguration();

                AssertManagedIdentityId(GetManagedIdentityId(config), ManagedIdentityIdType.ClientId, "env-client-id");
            }
        }

        [Test]
        [NonParallelizable]
        public void LegacyClientId_DefaultsToSystemAssigned()
        {
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();

                AssertManagedIdentityId(GetManagedIdentityId(config), ManagedIdentityIdType.SystemAssigned);
            }
        }

        [Test]
        [NonParallelizable]
        public void LegacyResourceId_ConfigSetsValue()
        {
            var resourceId = $"/subscriptions/{Guid.NewGuid()}/resourceGroups/myRg/providers/Microsoft.Compute/virtualMachines/myVm";
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:ManagedIdentityResourceId"] = resourceId;

                AssertManagedIdentityId(GetManagedIdentityId(config), ManagedIdentityIdType.ResourceId, resourceId);
            }
        }

        [Test]
        [NonParallelizable]
        public void LegacyObjectId_ConfigSetsValue()
        {
            string objectId = Guid.NewGuid().ToString();
            using (new TestEnvVar(AllNulledEnvVars()))
            {
                IConfiguration config = Helper.GetConfiguration();
                config["MyClient:Credential:ManagedIdentityObjectId"] = objectId;

                AssertManagedIdentityId(GetManagedIdentityId(config), ManagedIdentityIdType.ObjectId, objectId);
            }
        }

        [Test]
        [NonParallelizable]
        public void LegacyClientId_And_ResourceId_BothSet_Throws()
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

        #endregion

        #region General options

        [Test]
        [NonParallelizable]
        public void IsUnsafeSupportLoggingEnabled_ConfigSetsTrue()
        {
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
                config["MyClient:Credential:ManagedIdentityIdKind"] = "ClientId";
                config["MyClient:Credential:ManagedIdentityId"] = configClientId;
                config["MyClient:Credential:IsUnsafeSupportLoggingEnabled"] = "true";

                var mi = GetUnderlying(CreateFromConfig(config));
                var client = ReadProperty<ManagedIdentityClient>(mi, "Client");
                var miId = ReadProperty<ManagedIdentityId>(client, "ManagedIdentityId");
                AssertManagedIdentityId(miId, ManagedIdentityIdType.ClientId, configClientId);
            }
        }

        #endregion
    }
}
