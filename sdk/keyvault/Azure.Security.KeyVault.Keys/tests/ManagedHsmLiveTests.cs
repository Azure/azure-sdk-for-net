// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Keys.Tests
{
    [ClientTestFixture(KeyClientOptions.ServiceVersion.V7_2)]
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
                // To provision Managed HSM: New-TestResources.ps1 -AdditionalParameters @{enableHsm=$true}
                : throw new IgnoreException($"Required variable 'AZURE_MANAGEDHSM_URL' is not defined");

        [Test]
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
        public async Task CreateOctHsmKey()
        {
            string keyName = Recording.GenerateId();

            CreateOctKeyOptions options = new CreateOctKeyOptions(keyName, hardwareProtected: true);
            KeyVaultKey ecHsmkey = await Client.CreateOctKeyAsync(options);
            RegisterForCleanup(keyName);

            KeyVaultKey keyReturned = await Client.GetKeyAsync(keyName);

            AssertKeyVaultKeysEqual(ecHsmkey, keyReturned);
        }

        [Test]
        public async Task CreateOctKey()
        {
            string keyName = Recording.GenerateId();

            CreateOctKeyOptions ecKey = new CreateOctKeyOptions(keyName, hardwareProtected: false);
            KeyVaultKey keyNoHsm = await Client.CreateOctKeyAsync(ecKey);
            RegisterForCleanup(keyNoHsm.Name);

            KeyVaultKey keyReturned = await Client.GetKeyAsync(keyNoHsm.Name);

            AssertKeyVaultKeysEqual(keyNoHsm, keyReturned);
        }
    }
}
