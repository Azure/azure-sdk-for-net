// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Security.KeyVault.Tests;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Keys.Tests
{
    public partial class KeyClientLiveTests
    {
        [RecordedTest]
        [IgnoreServiceError(403, "Forbidden", Message = "Target environment attestation statement cannot be verified.")] // TODO: Remove once the attestation issue is resolved: https://github.com/Azure/azure-sdk-for-net/issues/27957
        [IgnoreServiceError(400, "BadParameter")] // TODO: Remove once SKR is deployed to sovereign clouds.
        [PremiumOnly]
        [ServiceVersion(Min = KeyClientOptions.ServiceVersion.V7_3)]
        [KeyVaultOnly] // https://github.com/Azure/azure-sdk-for-net/issues/38375 still a problem for Managed HSM.
        public async Task ReleaseCreatedKey()
        {
            string keyName = Recording.GenerateId();

            CreateRsaKeyOptions options = new(keyName, hardwareProtected: true)
            {
                Exportable = true,
                KeySize = 2048,
                ReleasePolicy = GetReleasePolicy(),
            };

            KeyVaultKey key = await Client.CreateRsaKeyAsync(options);
            RegisterForCleanup(key.Name);

            JwtSecurityToken jws = await ReleaseKeyAsync(keyName);
            Assert.IsTrue(jws.Payload.TryGetValue("response", out object response));

            JsonDocument doc = JsonDocument.Parse(response.ToString());
            JsonElement keyElement = doc.RootElement.GetProperty("key").GetProperty("key");
            Assert.AreEqual(key.Id, keyElement.GetProperty("kid").GetString());
            Assert.AreEqual(JsonValueKind.String, keyElement.GetProperty("key_hsm").ValueKind);
        }

        [RecordedTest]
        [IgnoreServiceError(403, "Forbidden", Message = "Target environment attestation statement cannot be verified.")] // TODO: Remove once the attestation issue is resolved: https://github.com/Azure/azure-sdk-for-net/issues/27957
        [IgnoreServiceError(400, "BadParameter")] // TODO: Remove once SKR is deployed to sovereign clouds.
        [PremiumOnly]
        [ServiceVersion(Min = KeyClientOptions.ServiceVersion.V7_3)]
        public async Task ReleaseUpdatedKey()
        {
            string keyName = Recording.GenerateId();

            CreateRsaKeyOptions options = new(keyName, hardwareProtected: true)
            {
                KeySize = 2048,
            };

            KeyVaultKey key = await Client.CreateRsaKeyAsync(options);
            RegisterForCleanup(key.Name);

            KeyProperties keyProperties = new(key.Id)
            {
                Exportable = true,
                ReleasePolicy = GetReleasePolicy(),
            };

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await Client.UpdateKeyPropertiesAsync(keyProperties));
            Assert.AreEqual(400, ex.Status);
            Assert.AreEqual("BadParameter", ex.ErrorCode);
        }

        [RecordedTest]
        [IgnoreServiceError(403, "Forbidden", Message = "Target environment attestation statement cannot be verified.")] // TODO: Remove once the attestation issue is resolved: https://github.com/Azure/azure-sdk-for-net/issues/27957
        [IgnoreServiceError(400, "BadParameter")] // TODO: Remove once SKR is deployed to sovereign clouds.
        [PremiumOnly]
        [ServiceVersion(Min = KeyClientOptions.ServiceVersion.V7_3)]
        [KeyVaultOnly] // https://github.com/Azure/azure-sdk-for-net/issues/38375 still a problem for Managed HSM.
        public async Task UpdateReleasePolicy([Values] bool immutable)
        {
            string keyName = Recording.GenerateId();

            CreateRsaKeyOptions options = new(keyName, hardwareProtected: true)
            {
                Exportable = true,
                KeySize = 2048,
                ReleasePolicy = GetReleasePolicy(immutable),
            };

            KeyVaultKey key = await Client.CreateRsaKeyAsync(options);
            RegisterForCleanup(key.Name);

            Assert.AreEqual(immutable, key.Properties.ReleasePolicy.Immutable);
            KeyProperties properties = new(key.Name)
            {
                Exportable = true,
                ReleasePolicy = GetReleasePolicy(),
            };

            if (immutable)
            {
                RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await Client.UpdateKeyPropertiesAsync(properties));
                Assert.AreEqual(400, ex.Status);
                Assert.AreEqual("BadParameter", ex.ErrorCode);
            }
            else
            {
                key = await Client.UpdateKeyPropertiesAsync(properties);
                Assert.IsFalse(key.Properties.ReleasePolicy.Immutable);
            }
        }

        private AttestationClient CreateAttestationClient() => InstrumentClient(
            new AttestationClient(
                TestEnvironment.AttestationUri,
                InstrumentClientOptions(
                    new KeyClientOptions(_serviceVersion))));

        protected KeyReleasePolicy GetReleasePolicy(bool? immutable = null)
        {
            string releasePolicy = $@"{{
    ""anyOf"": [
        {{
            ""anyOf"": [
                {{
                    ""claim"": ""sdk-test"",
                    ""equals"": ""true""
                }}
            ],
            ""authority"": ""{TestEnvironment.AttestationUri}""
        }}
    ],
    ""version"": ""1.0.0""
}}";

            BinaryData releasePolicyData = BinaryData.FromString(releasePolicy);
            return new(releasePolicyData)
            {
                Immutable = immutable,
            };
        }

        protected async Task<JwtSecurityToken> ReleaseKeyAsync(string keyName)
        {
            AttestationClient attestationClient = CreateAttestationClient();

            string target = await attestationClient.GetTokenAsync();

            ReleaseKeyResult result = await Client.ReleaseKeyAsync(keyName, target);
            return new(result.Value);
        }
    }
}
