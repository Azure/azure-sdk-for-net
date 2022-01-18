// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Security.KeyVault.Tests;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Keys.Tests
{
    public partial class KeyClientLiveTests
    {
        [Test]
        [PremiumOnly]
        [ServiceVersion(Min = KeyClientOptions.ServiceVersion.V7_3_Preview)]
        public async Task ReleaseCreatedKey()
        {
            string keyName = Recording.GenerateId();

            CreateRsaKeyOptions options = new(keyName, hardwareProtected: true)
            {
                Exportable = true,
                KeySize = 2048,
                ReleasePolicy = GetReleasePolicy(),
            };

            // BUGBUG: Remove assert when https://github.com/Azure/azure-sdk-for-net/issues/22750 is resolved.
            KeyVaultKey key = await AssertRequestSupported(async () => await Client.CreateRsaKeyAsync(options));
            RegisterForCleanup(key.Name);

            JwtSecurityToken jws = await ReleaseKeyAsync(keyName);
            Assert.IsTrue(jws.Payload.TryGetValue("response", out object response));

            JsonDocument doc = JsonDocument.Parse(response.ToString());
            JsonElement keyElement = doc.RootElement.GetProperty("key").GetProperty("key");
            Assert.AreEqual(key.Id, keyElement.GetProperty("kid").GetString());
            Assert.AreEqual(JsonValueKind.String, keyElement.GetProperty("key_hsm").ValueKind);
        }

        [Test]
        [PremiumOnly]
        [ServiceVersion(Min = KeyClientOptions.ServiceVersion.V7_3_Preview)]
        public async Task ReleaseUpdatedKey()
        {
            string keyName = Recording.GenerateId();

            CreateRsaKeyOptions options = new(keyName, hardwareProtected: true)
            {
                KeySize = 2048,
            };

            KeyVaultKey key = await Client.CreateRsaKeyAsync(options);
            RegisterForCleanup(key.Name);

            // BUGBUG: Remove check when https://github.com/Azure/azure-sdk-for-net/issues/22750 is resolved.
            if (IsManagedHSM)
            {
                Assert.IsFalse(key.Properties.Exportable);
            }

            KeyProperties keyProperties = new(key.Id)
            {
                Exportable = true,
                ReleasePolicy = GetReleasePolicy(),
            };

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await Client.UpdateKeyPropertiesAsync(keyProperties));
            Assert.AreEqual(400, ex.Status);
            Assert.AreEqual("BadParameter", ex.ErrorCode);
        }

        [Test]
        [ServiceVersion(Min = KeyClientOptions.ServiceVersion.V7_3_Preview)]
        public async Task ReleaseImportedKey()
        {
            string keyName = Recording.GenerateId();

            JsonWebKey jwk = KeyUtilities.CreateRsaKey(includePrivateParameters: true);
            ImportKeyOptions options = new(keyName, jwk)
            {
                Properties =
                {
                    Exportable = true,
                    ReleasePolicy = GetReleasePolicy(),
                },
            };

            // BUGBUG: Remove assert when https://github.com/Azure/azure-sdk-for-net/issues/22750 is resolved.
            KeyVaultKey key = await AssertRequestSupported(async () => await Client.ImportKeyAsync(options));
            RegisterForCleanup(key.Name);

            // BUGBUG: Remove assert when https://github.com/Azure/azure-sdk-for-net/issues/22750 is resolved.
            JwtSecurityToken jws = await AssertRequestSupported(async () => await ReleaseKeyAsync(keyName));
            Assert.IsTrue(jws.Payload.TryGetValue("response", out object response));

            JsonDocument doc = JsonDocument.Parse(response.ToString());
            JsonElement keyElement = doc.RootElement.GetProperty("key").GetProperty("key");
            Assert.AreEqual(key.Id, keyElement.GetProperty("kid").GetString());
            Assert.AreEqual(JsonValueKind.String, keyElement.GetProperty("key_hsm").ValueKind);
        }

        private async Task<T> AssertRequestSupported<T>(Func<Task<T>> fn)
        {
            try
            {
                return await fn();
            }
            catch (RequestFailedException ex) when (!IsManagedHSM && ex.Status == 400 && ex.ErrorCode == "BadParameter")
            {
                // Terminate the test method but do not fail so that recordings are saved.
                throw new SuccessException("Secure Key Release is not currently supported by Azure Key Vault");
            }
        }

        private AttestationClient CreateAttestationClient() => InstrumentClient(
            new AttestationClient(
                TestEnvironment.AttestationUri,
                InstrumentClientOptions(
                    new KeyClientOptions(_serviceVersion))));

        private KeyReleasePolicy GetReleasePolicy()
        {
            string releasePolicy = $@"{{
    ""anyOf"": [
        {{
            ""anyOf"": [
                {{
                    ""claim"": ""sdk-test"",
                    ""condition"": ""equals"",
                    ""value"": ""true""
                }}
            ],
            ""authority"": ""{TestEnvironment.AttestationUri}""
        }}
    ],
    ""version"": ""1.0""
}}";

            BinaryData releasePolicyData = BinaryData.FromString(releasePolicy);
            return new(releasePolicyData);
        }

        private async Task<JwtSecurityToken> ReleaseKeyAsync(string keyName)
        {
            AttestationClient attestationClient = CreateAttestationClient();

            string target = await attestationClient.GetTokenAsync();

            ReleaseKeyResult result = await Client.ReleaseKeyAsync(keyName, target);
            return new(result.Value);
        }
    }
}
