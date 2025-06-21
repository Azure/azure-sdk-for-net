// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Security.KeyVault.Keys.Cryptography;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Keys.Tests
{
    [ClientTestFixture(
        KeyClientOptions.ServiceVersion.V7_6,
        KeyClientOptions.ServiceVersion.V7_5,
        KeyClientOptions.ServiceVersion.V7_4,
        KeyClientOptions.ServiceVersion.V7_3,
        KeyClientOptions.ServiceVersion.V7_2)]
    public class ManagedHsmCryptographyClientLiveTests : CryptographyClientLiveTests
    {
        private static readonly IEnumerable<KeyOperation> s_aesKeyOps = new[]
        {
            KeyOperation.Encrypt,
            KeyOperation.Decrypt,
            KeyOperation.WrapKey,
            KeyOperation.UnwrapKey,
        };

        public ManagedHsmCryptographyClientLiveTests(bool isAsync, KeyClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        protected internal override bool IsManagedHSM => true;

        public override Uri Uri =>
            Uri.TryCreate(TestEnvironment.ManagedHsmUrl, UriKind.Absolute, out Uri uri)
                ? uri
                // If the AZURE_MANAGEDHSM_URL variable is not defined, we didn't provision one
                // due to limitations: https://github.com/Azure/azure-sdk-for-net/issues/16531
                // To provision Managed HSM: New-TestResources.ps1 -AdditionalParameters @{enableHsm=$true}
                : throw new IgnoreException($"Required variable 'AZURE_MANAGEDHSM_URL' is not defined");

        [RecordedTest]
        public async Task EncryptLocalDecryptOnManagedHsm([EnumValues(
            nameof(EncryptionAlgorithm.A128Cbc),
            nameof(EncryptionAlgorithm.A192Cbc),
            nameof(EncryptionAlgorithm.A256Cbc),
            nameof(EncryptionAlgorithm.A128CbcPad),
            nameof(EncryptionAlgorithm.A192CbcPad),
            nameof(EncryptionAlgorithm.A256CbcPad)
            )] EncryptionAlgorithm algorithm)
        {
            int keySizeInBytes = algorithm.GetAesCbcEncryptionAlgorithm().KeySizeInBytes;
            JsonWebKey jwk = KeyUtilities.CreateAesKey(keySizeInBytes, s_aesKeyOps);

            string keyName = Recording.GenerateId();
            KeyVaultKey key = await Client.ImportKeyAsync(
                new ImportKeyOptions(keyName, jwk));
            RegisterForCleanup(key.Name);

            CryptographyClient remoteClient = GetCryptoClient(key.Id, forceRemote: true);
            CryptographyClient localClient = GetLocalCryptoClient(jwk);

            byte[] plaintext = new byte[32];
            Recording.Random.NextBytes(plaintext);

            byte[] iv = new byte[16];
            if (algorithm.GetAesCbcEncryptionAlgorithm() is AesCbc)
            {
                Recording.Random.NextBytes(iv);
            }

            EncryptParameters encryptParams = algorithm.ToString() switch
            {
                EncryptionAlgorithm.A128CbcValue => EncryptParameters.A128CbcParameters(plaintext, iv),
                EncryptionAlgorithm.A192CbcValue => EncryptParameters.A192CbcParameters(plaintext, iv),
                EncryptionAlgorithm.A256CbcValue => EncryptParameters.A256CbcParameters(plaintext, iv),

                EncryptionAlgorithm.A128CbcPadValue => EncryptParameters.A128CbcPadParameters(plaintext, iv),
                EncryptionAlgorithm.A192CbcPadValue => EncryptParameters.A192CbcPadParameters(plaintext, iv),
                EncryptionAlgorithm.A256CbcPadValue => EncryptParameters.A256CbcPadParameters(plaintext, iv),

                _ => throw new NotSupportedException($"{algorithm} is not supported"),
            };

            EncryptResult encrypted = await localClient.EncryptAsync(encryptParams);
            Assert.IsNotNull(encrypted.Ciphertext);

            DecryptParameters decryptParameters = algorithm.ToString() switch
            {
                EncryptionAlgorithm.A128CbcValue => DecryptParameters.A128CbcParameters(encrypted.Ciphertext, encrypted.Iv),
                EncryptionAlgorithm.A192CbcValue => DecryptParameters.A192CbcParameters(encrypted.Ciphertext, encrypted.Iv),
                EncryptionAlgorithm.A256CbcValue => DecryptParameters.A256CbcParameters(encrypted.Ciphertext, encrypted.Iv),

                EncryptionAlgorithm.A128CbcPadValue => DecryptParameters.A128CbcPadParameters(encrypted.Ciphertext, encrypted.Iv),
                EncryptionAlgorithm.A192CbcPadValue => DecryptParameters.A192CbcPadParameters(encrypted.Ciphertext, encrypted.Iv),
                EncryptionAlgorithm.A256CbcPadValue => DecryptParameters.A256CbcPadParameters(encrypted.Ciphertext, encrypted.Iv),

                _ => throw new NotSupportedException($"{algorithm} is not supported"),
            };

            DecryptResult decrypted = await remoteClient.DecryptAsync(decryptParameters);
            Assert.IsNotNull(decrypted.Plaintext);

            CollectionAssert.AreEqual(plaintext, decrypted.Plaintext);
        }

        [RecordedTest]
        public async Task AesGcmEncryptDecrypt([EnumValues(
            nameof(EncryptionAlgorithm.A128Gcm),
            nameof(EncryptionAlgorithm.A192Gcm),
            nameof(EncryptionAlgorithm.A256Gcm)
            )] EncryptionAlgorithm algorithm)
        {
            int keySizeInBytes = algorithm.ToString() switch
            {
                EncryptionAlgorithm.A128GcmValue => 128 >> 3,
                EncryptionAlgorithm.A192GcmValue => 192 >> 3,
                EncryptionAlgorithm.A256GcmValue => 256 >> 3,

                _ => throw new NotSupportedException($"{algorithm} is not supported"),
            };

            JsonWebKey jwk = KeyUtilities.CreateAesKey(keySizeInBytes, s_aesKeyOps);

            string keyName = Recording.GenerateId();
            KeyVaultKey key = await Client.ImportKeyAsync(
                new ImportKeyOptions(keyName, jwk));
            RegisterForCleanup(key.Name);

            CryptographyClient remoteClient = GetCryptoClient(key.Id, forceRemote: true);

            byte[] plaintext = new byte[32];
            Recording.Random.NextBytes(plaintext);

            byte[] iv = new byte[16];
            if (algorithm.GetAesCbcEncryptionAlgorithm() is AesCbc)
            {
                Recording.Random.NextBytes(iv);
            }

            EncryptParameters encryptParams = algorithm.ToString() switch
            {
                // TODO: Re-record with random additionalAuthenticatedData once the "aad" issue is fixed with Managed HSM.
                EncryptionAlgorithm.A128GcmValue => EncryptParameters.A128GcmParameters(plaintext),
                EncryptionAlgorithm.A192GcmValue => EncryptParameters.A192GcmParameters(plaintext),
                EncryptionAlgorithm.A256GcmValue => EncryptParameters.A256GcmParameters(plaintext),

                _ => throw new NotSupportedException($"{algorithm} is not supported"),
            };

            EncryptResult encrypted = await remoteClient.EncryptAsync(encryptParams);
            Assert.IsNotNull(encrypted.Ciphertext);

            DecryptParameters decryptParameters = algorithm.ToString() switch
            {
                // TODO: Re-record with random additionalAuthenticatedData once the "aad" issue is fixed with Managed HSM.
                EncryptionAlgorithm.A128GcmValue => DecryptParameters.A128GcmParameters(encrypted.Ciphertext, encrypted.Iv, encrypted.AuthenticationTag),
                EncryptionAlgorithm.A192GcmValue => DecryptParameters.A192GcmParameters(encrypted.Ciphertext, encrypted.Iv, encrypted.AuthenticationTag),
                EncryptionAlgorithm.A256GcmValue => DecryptParameters.A256GcmParameters(encrypted.Ciphertext, encrypted.Iv, encrypted.AuthenticationTag),

                _ => throw new NotSupportedException($"{algorithm} is not supported"),
            };

            DecryptResult decrypted = await remoteClient.DecryptAsync(decryptParameters);
            Assert.IsNotNull(decrypted.Plaintext);

            CollectionAssert.AreEqual(plaintext, decrypted.Plaintext);
        }

        [RecordedTest]
        public async Task AesKwWrapUnwrapRoundTrip([EnumValues(
            nameof(KeyWrapAlgorithm.A128KW),
            nameof(KeyWrapAlgorithm.A192KW),
            nameof(KeyWrapAlgorithm.A256KW),
            nameof(KeyWrapAlgorithm.CkmAesKeyWrap),
            nameof(KeyWrapAlgorithm.CkmAesKeyWrapPad)
            )] KeyWrapAlgorithm algorithm)
        {
            KeyVaultKey key = await CreateTestKey(algorithm);
            RegisterForCleanup(key.Name);

            CryptographyClient remoteClient = GetCryptoClient(key.Id, forceRemote: true);

            byte[] plaintext = new byte[32];
            Recording.Random.NextBytes(plaintext);

            WrapResult encrypted = await remoteClient.WrapKeyAsync(algorithm, plaintext);

            Assert.AreEqual(algorithm, encrypted.Algorithm);
            Assert.AreEqual(key.Id, encrypted.KeyId);
            Assert.IsNotNull(encrypted.EncryptedKey);

            UnwrapResult decrypted = await remoteClient.UnwrapKeyAsync(algorithm, encrypted.EncryptedKey);

            Assert.AreEqual(algorithm, decrypted.Algorithm);
            Assert.AreEqual(key.Id, decrypted.KeyId);
            Assert.IsNotNull(decrypted.Key);

            CollectionAssert.AreEqual(plaintext, decrypted.Key);
        }

        [RecordedTest]
        public async Task SignLocalVerifyRoundTripHSM([EnumValues(Exclude = new[] { nameof(SignatureAlgorithm.ES256K) })]SignatureAlgorithm algorithm)
        {
            await SignLocalVerifyRoundTripInternal(algorithm);
        }

        // We do not test using ES256K below since macOS doesn't support it; various ideas to work around that adversely affect runtime code too much.

        [RecordedTest]
        public async Task LocalSignVerifyRoundTripHSM([EnumValues(Exclude = new[] { nameof(SignatureAlgorithm.ES256K) })] SignatureAlgorithm algorithm)
        {
            await LocalSignVerifyRoundTripInternal(algorithm);
        }

        [RecordedTest]
        public async Task SignVerifyDataRoundTripHSM([EnumValues] SignatureAlgorithm algorithm)
        {
            await SignVerifyDataRoundTripInternal(algorithm);
        }

        [RecordedTest]
        public async Task SignVerifyDataStreamRoundTripHSM([EnumValues] SignatureAlgorithm algorithm)
        {
            await SignVerifyDataStreamRoundTripInternal(algorithm);
        }

        private async Task<KeyVaultKey> CreateTestKey(EncryptionAlgorithm algorithm)
        {
            string keyName = Recording.GenerateId();

            switch (algorithm.ToString())
            {
                case EncryptionAlgorithm.Rsa15Value:
                case EncryptionAlgorithm.RsaOaepValue:
                case EncryptionAlgorithm.RsaOaep256Value:
                    return await Client.CreateRsaKeyAsync(
                        new CreateRsaKeyOptions(keyName));

                case EncryptionAlgorithm.A128CbcValue:
                case EncryptionAlgorithm.A128CbcPadValue:
                case EncryptionAlgorithm.A128GcmValue:
                    return await Client.CreateOctKeyAsync(
                        new CreateOctKeyOptions(keyName)
                        {
                            KeySize = 128,
                        });

                case EncryptionAlgorithm.A192CbcValue:
                case EncryptionAlgorithm.A192CbcPadValue:
                case EncryptionAlgorithm.A192GcmValue:
                    return await Client.CreateOctKeyAsync(
                        new CreateOctKeyOptions(keyName)
                        {
                            KeySize = 192,
                        });

                case EncryptionAlgorithm.A256CbcValue:
                case EncryptionAlgorithm.A256CbcPadValue:
                case EncryptionAlgorithm.A256GcmValue:
                    return await Client.CreateOctKeyAsync(
                        new CreateOctKeyOptions(keyName)
                        {
                            KeySize = 256,
                        });

                default:
                    throw new ArgumentException("Invalid Algorithm", nameof(algorithm));
            }
        }
    }
}
