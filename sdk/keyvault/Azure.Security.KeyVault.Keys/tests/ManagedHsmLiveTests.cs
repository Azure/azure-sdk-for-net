// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Keys.Tests
{
    public class ManagedHsmLiveTests : KeyClientLiveTests
    {
        public ManagedHsmLiveTests(bool isAsync, KeyClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        public override Uri Uri =>
            Uri.TryCreate(TestEnvironment.ManagedHsmUrl, UriKind.Absolute, out Uri uri)
                ? uri
                // If the AZURE_MANAGEDHSM_URL variable is not defined, we didn't provision one
                // due to limitations: https://github.com/Azure/azure-sdk-for-net/issues/16531
                : throw new IgnoreException($"Required variable 'AZURE_MANAGEDHSM_URL' is not defined");

        [Test]
        [Ignore("Service issue: https://github.com/Azure/azure-sdk-for-net/issues/16789")]
        public async Task CreateRsaWithPublicExponent()
        {
            CreateRsaKeyOptions options = new CreateRsaKeyOptions(Recording.GenerateId())
            {
                KeySize = 2048,
                PublicExponent = 3,
            };

            KeyVaultKey key = await Client.CreateRsaKeyAsync(options);
            RegisterForCleanup(key.Name);

            RSA rsaKey = key.Key.ToRSA();
            RSAParameters rsaParams = rsaKey.ExportParameters(false);
            Assert.AreEqual(256, rsaParams.Modulus.Length);

            int publicExponent = rsaParams.Exponent.ToInt32();
            Assert.AreEqual(3, publicExponent);
        }

        [Test]
        [Ignore("Not implemented: https://github.com/Azure/azure-sdk-for-net/issues/16792")]
        public async Task ExportCreatedKey()
        {
            SaveDebugRecordingsOnFailure = true;

            string jsonPolicy = @"{
  ""anyOf"": [
    {
      ""allOf"": [
        {
          ""claim"": ""MyClaim"",
          ""condition"": ""equals"",
          ""value"": ""abc123""
        }
      ],
      ""authority"": ""my.attestation.com""
    }
  ],
  ""version"": ""0.2""
}";
            byte[] encodedPolicy = Encoding.UTF8.GetBytes(jsonPolicy);

            CreateRsaKeyOptions options = new CreateRsaKeyOptions(Recording.GenerateId())
            {
                Exportable = true,
                KeyOperations =
                {
                    KeyOperation.UnwrapKey,
                    KeyOperation.WrapKey,
                },
                KeySize = 2048,
                ReleasePolicy = new KeyReleasePolicy(encodedPolicy),
            };

            // Not currently implemented:
            KeyVaultKey createdKey = await Client.CreateRsaKeyAsync(options);

            // This requires provisioning of an application in the enclave, which is coming soon:
            KeyVaultKey exportedKey = await Client.ExportKeyAsync(createdKey.Name, "test");
            CollectionAssert.AreEqual(createdKey.Key.N, exportedKey.Key.N);
        }

        [Test]
        [Ignore("Not implemented: https://github.com/Azure/azure-sdk-for-net/issues/16792")]
        public Task ExportImportedKey() => Task.CompletedTask;
    }
}
