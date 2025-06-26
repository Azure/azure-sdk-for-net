// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using Azure.Security.KeyVault.Keys.Cryptography;
using NUnit.Framework;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Keys.Tests
{
    public class CryptographyClientLiveTests : KeysTestBase
    {
        private readonly KeyClientOptions.ServiceVersion _serviceVersion;

        public CryptographyClientLiveTests(bool isAsync, KeyClientOptions.ServiceVersion serviceVersion)
            : this(isAsync, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        protected CryptographyClientLiveTests(bool isAsync, KeyClientOptions.ServiceVersion serviceVersion, RecordedTestMode? mode)
            : base(isAsync, serviceVersion, mode)
        {
            _serviceVersion = serviceVersion;

            // TODO: https://github.com/Azure/azure-sdk-for-net/issues/11634
            CompareBodies = false;
        }

        [RecordedTest]
        public async Task EncryptDecryptRoundTrip([EnumValues(nameof(EncryptionAlgorithm.Rsa15), nameof(EncryptionAlgorithm.RsaOaep), nameof(EncryptionAlgorithm.RsaOaep256))]EncryptionAlgorithm algorithm)
        {
            KeyVaultKey key = await CreateTestKey(algorithm);
            RegisterForCleanup(key.Name);

            CryptographyClient cryptoClient = GetCryptoClient(key.Id, forceRemote: true);

            byte[] data = new byte[32];
            Recording.Random.NextBytes(data);

            EncryptResult encResult = await cryptoClient.EncryptAsync(algorithm, data);

            Assert.AreEqual(algorithm, encResult.Algorithm);
            Assert.AreEqual(key.Id, encResult.KeyId);
            Assert.IsNotNull(encResult.Ciphertext);

            DecryptResult decResult = await cryptoClient.DecryptAsync(algorithm, encResult.Ciphertext);

            Assert.AreEqual(algorithm, decResult.Algorithm);
            Assert.AreEqual(key.Id, decResult.KeyId);
            Assert.IsNotNull(decResult.Plaintext);

            CollectionAssert.AreEqual(data, decResult.Plaintext);
        }

        [RecordedTest]
        public async Task WrapUnwrapRoundTrip([EnumValues(Exclude = new[] { nameof(KeyWrapAlgorithm.A128KW), nameof(KeyWrapAlgorithm.A192KW), nameof(KeyWrapAlgorithm.A256KW), nameof(KeyWrapAlgorithm.CkmAesKeyWrap), nameof(KeyWrapAlgorithm.CkmAesKeyWrapPad) })]KeyWrapAlgorithm algorithm)
        {
            KeyVaultKey key = await CreateTestKey(algorithm);
            RegisterForCleanup(key.Name);

            CryptographyClient cryptoClient = GetCryptoClient(key.Id, forceRemote: true);

            byte[] data = new byte[32];
            Recording.Random.NextBytes(data);

            WrapResult encResult = await cryptoClient.WrapKeyAsync(algorithm, data);

            Assert.AreEqual(algorithm, encResult.Algorithm);
            Assert.AreEqual(key.Id, encResult.KeyId);
            Assert.IsNotNull(encResult.EncryptedKey);

            UnwrapResult decResult = await cryptoClient.UnwrapKeyAsync(algorithm, encResult.EncryptedKey);

            Assert.AreEqual(algorithm, decResult.Algorithm);
            Assert.AreEqual(key.Id, decResult.KeyId);
            Assert.IsNotNull(decResult.Key);

            CollectionAssert.AreEqual(data, decResult.Key);
        }

        [RecordedTest]
        public async Task SignVerifyDataRoundTrip([EnumValues(Exclude = new[] { nameof(SignatureAlgorithm.HS256), nameof(SignatureAlgorithm.HS384), nameof(SignatureAlgorithm.HS512) })] SignatureAlgorithm algorithm)
        {
            await SignVerifyDataRoundTripInternal(algorithm);
        }

        protected async Task SignVerifyDataRoundTripInternal(SignatureAlgorithm algorithm)
        {
            KeyVaultKey key = await CreateTestKey(algorithm);
            RegisterForCleanup(key.Name);

            CryptographyClient cryptoClient = GetCryptoClient(key.Id, forceRemote: true);

            byte[] data = new byte[32];
            Recording.Random.NextBytes(data);

            using HashAlgorithm hashAlgo = algorithm.GetHashAlgorithm();

            byte[] digest = hashAlgo.ComputeHash(data);

            SignResult signResult = await cryptoClient.SignAsync(algorithm, digest);

            SignResult signDataResult = await cryptoClient.SignDataAsync(algorithm, data);

            Assert.AreEqual(algorithm, signResult.Algorithm);
            Assert.AreEqual(algorithm, signDataResult.Algorithm);

            Assert.AreEqual(key.Id, signResult.KeyId);
            Assert.AreEqual(key.Id, signDataResult.KeyId);

            Assert.NotNull(signResult.Signature);
            Assert.NotNull(signDataResult.Signature);

            VerifyResult verifyResult = await cryptoClient.VerifyAsync(algorithm, digest, signDataResult.Signature);

            VerifyResult verifyDataResult = await cryptoClient.VerifyDataAsync(algorithm, data, signResult.Signature);

            Assert.AreEqual(algorithm, verifyResult.Algorithm);
            Assert.AreEqual(algorithm, verifyDataResult.Algorithm);

            Assert.AreEqual(key.Id, verifyResult.KeyId);
            Assert.AreEqual(key.Id, verifyDataResult.KeyId);

            Assert.True(verifyResult.IsValid);
            Assert.True(verifyResult.IsValid);
        }

        [RecordedTest]
        public async Task SignVerifyDataStreamRoundTrip([EnumValues(Exclude = new[] { nameof(SignatureAlgorithm.HS256), nameof(SignatureAlgorithm.HS384), nameof(SignatureAlgorithm.HS512) })] SignatureAlgorithm algorithm)
        {
            await SignVerifyDataStreamRoundTripInternal(algorithm);
        }

        protected async Task SignVerifyDataStreamRoundTripInternal(SignatureAlgorithm algorithm)
        {
            KeyVaultKey key = await CreateTestKey(algorithm);
            RegisterForCleanup(key.Name);

            CryptographyClient cryptoClient = GetCryptoClient(key.Id, forceRemote: true);

            byte[] data = new byte[8000];
            Recording.Random.NextBytes(data);

            using MemoryStream dataStream = new MemoryStream(data);

            using HashAlgorithm hashAlgo = algorithm.GetHashAlgorithm();

            byte[] digest = hashAlgo.ComputeHash(dataStream);

            dataStream.Seek(0, SeekOrigin.Begin);

            SignResult signResult = await cryptoClient.SignAsync(algorithm, digest);

            SignResult signDataResult = await cryptoClient.SignDataAsync(algorithm, dataStream);

            Assert.AreEqual(algorithm, signResult.Algorithm);
            Assert.AreEqual(algorithm, signDataResult.Algorithm);

            Assert.AreEqual(key.Id, signResult.KeyId);
            Assert.AreEqual(key.Id, signDataResult.KeyId);

            Assert.NotNull(signResult.Signature);
            Assert.NotNull(signDataResult.Signature);

            dataStream.Seek(0, SeekOrigin.Begin);

            VerifyResult verifyResult = await cryptoClient.VerifyAsync(algorithm, digest, signDataResult.Signature);

            VerifyResult verifyDataResult = await cryptoClient.VerifyDataAsync(algorithm, dataStream, signResult.Signature);

            Assert.AreEqual(algorithm, verifyResult.Algorithm);
            Assert.AreEqual(algorithm, verifyDataResult.Algorithm);

            Assert.AreEqual(key.Id, verifyResult.KeyId);
            Assert.AreEqual(key.Id, verifyDataResult.KeyId);

            Assert.True(verifyResult.IsValid);
            Assert.True(verifyDataResult.IsValid);
        }

        // We do not test using ES256K below since macOS doesn't support it; various ideas to work around that adversely affect runtime code too much.

        [RecordedTest]
        public async Task LocalSignVerifyRoundTrip([EnumValues(Exclude = new[] { nameof(SignatureAlgorithm.ES256K), nameof(SignatureAlgorithm.HS256), nameof(SignatureAlgorithm.HS384), nameof(SignatureAlgorithm.HS512) })] SignatureAlgorithm algorithm)
        {
            await LocalSignVerifyRoundTripInternal(algorithm);
        }

        protected async Task LocalSignVerifyRoundTripInternal(SignatureAlgorithm algorithm)
        {
#if NET462
            if (algorithm.GetEcKeyCurveName() != default)
            {
                Assert.Ignore("Creating JsonWebKey with ECDsa is not supported on net462.");
            }
#endif

#if NETFRAMEWORK
            if (algorithm.GetRsaSignaturePadding() == RSASignaturePadding.Pss)
            {
                Assert.Ignore("RSA-PSS signature padding is not supported on .NET Framework.");
            }
#endif

            KeyVaultKey key = await CreateTestKeyWithKeyMaterial(algorithm);
            RegisterForCleanup(key.Name);

            (CryptographyClient client, ICryptographyProvider remoteClient) = GetCryptoClient(key);

            byte[] data = new byte[32];
            Recording.Random.NextBytes(data);

            using HashAlgorithm hashAlgo = algorithm.GetHashAlgorithm();
            byte[] digest = hashAlgo.ComputeHash(data);

            // Sign locally...
            SignResult signResult = await client.SignAsync(algorithm, digest);

            Assert.AreEqual(algorithm, signResult.Algorithm);
            Assert.AreEqual(key.Key.Id, signResult.KeyId);
            Assert.NotNull(signResult.Signature);

            // ...and verify remotely.
            VerifyResult verifyResult = await remoteClient.VerifyAsync(algorithm, digest, signResult.Signature);

            Assert.AreEqual(algorithm, verifyResult.Algorithm);
            Assert.AreEqual(key.Key.Id, verifyResult.KeyId);
            Assert.IsTrue(verifyResult.IsValid);
        }

        [RecordedTest]
        public async Task LocalSignVerifyRoundTripOnFramework([EnumValues(nameof(SignatureAlgorithm.PS256), nameof(SignatureAlgorithm.PS384), nameof(SignatureAlgorithm.PS512))]SignatureAlgorithm algorithm)
        {
#if !NETFRAMEWORK
            // RSA-PSS is not supported on .NET Framework so recorded tests will fall back to the remote client.
            Assert.Ignore("RSA-PSS is supported on .NET Core so local tests will pass. This test method is to test that on .NET Framework RSA-PSS sign/verify attempts fall back to the remote client.");
#endif

            KeyVaultKey key = await CreateTestKeyWithKeyMaterial(algorithm);
            RegisterForCleanup(key.Name);

            (CryptographyClient client, ICryptographyProvider remoteClient) = GetCryptoClient(key);

            byte[] data = new byte[32];
            Recording.Random.NextBytes(data);

            using HashAlgorithm hashAlgo = algorithm.GetHashAlgorithm();
            byte[] digest = hashAlgo.ComputeHash(data);

            // Sign locally...
            SignResult signResult = await client.SignAsync(algorithm, digest);

            Assert.AreEqual(algorithm, signResult.Algorithm);
            Assert.AreEqual(key.Key.Id, signResult.KeyId);
            Assert.NotNull(signResult.Signature);

            // ...and verify remotely.
            VerifyResult verifyResult = await remoteClient.VerifyAsync(algorithm, digest, signResult.Signature);

            Assert.AreEqual(algorithm, verifyResult.Algorithm);
            Assert.AreEqual(key.Key.Id, verifyResult.KeyId);
            Assert.IsTrue(verifyResult.IsValid);
        }

        [RecordedTest]
        public async Task SignLocalVerifyRoundTrip([EnumValues(Exclude = new[] { nameof(SignatureAlgorithm.ES256K), nameof(SignatureAlgorithm.HS256), nameof(SignatureAlgorithm.HS384), nameof(SignatureAlgorithm.HS512) })] SignatureAlgorithm algorithm)
        {
            await SignLocalVerifyRoundTripInternal(algorithm);
        }

        protected async Task SignLocalVerifyRoundTripInternal(SignatureAlgorithm algorithm)
        {
#if NET462
            if (algorithm.GetEcKeyCurveName() != default)
            {
                Assert.Ignore("Creating JsonWebKey with ECDsa is not supported on net462.");
            }
#endif

#if NETFRAMEWORK
            if (algorithm.GetRsaSignaturePadding() == RSASignaturePadding.Pss)
            {
                Assert.Ignore("RSA-PSS signature padding is not supported on .NET Framework.");
            }
#endif

            if ((algorithm == SignatureAlgorithm.HS256 ||
                 algorithm == SignatureAlgorithm.HS384 ||
                 algorithm == SignatureAlgorithm.HS512) && !IsManagedHSM)
            {
                Assert.Ignore("HMAC signature algorithms are only supported in Managed HSM");
            }

            KeyVaultKey key = await CreateTestKey(algorithm);
            RegisterForCleanup(key.Name);

            CryptographyClient client = GetCryptoClient(key.Id);

            byte[] data = new byte[32];
            Recording.Random.NextBytes(data);

            using HashAlgorithm hashAlgo = algorithm.GetHashAlgorithm();
            byte[] digest = hashAlgo.ComputeHash(data);

            // Should sign remotely...
            SignResult signResult = await client.SignAsync(algorithm, digest);

            Assert.AreEqual(algorithm, signResult.Algorithm);
            Assert.AreEqual(key.Key.Id, signResult.KeyId);
            Assert.NotNull(signResult.Signature);

            // ...and verify locally.
            VerifyResult verifyResult = await client.VerifyAsync(algorithm, digest, signResult.Signature);

            Assert.AreEqual(algorithm, verifyResult.Algorithm);
            Assert.AreEqual(key.Key.Id, verifyResult.KeyId);
            Assert.IsTrue(verifyResult.IsValid);
        }

        [RecordedTest]
        public async Task SignLocalVerifyRoundTripFramework([EnumValues(nameof(SignatureAlgorithm.PS256), nameof(SignatureAlgorithm.PS384), nameof(SignatureAlgorithm.PS512))]SignatureAlgorithm algorithm)
        {
#if !NETFRAMEWORK
            // RSA-PSS is not supported on .NET Framework so recorded tests will fall back to the remote client.
            Assert.Ignore("RSA-PSS is supported on .NET Core so local tests will pass. This test method is to test that on .NET Framework RSA-PSS sign/verify attempts fall back to the remote client.");
#endif

            KeyVaultKey key = await CreateTestKey(algorithm);
            RegisterForCleanup(key.Name);

            CryptographyClient client = GetCryptoClient(key.Properties.Id);

            byte[] data = new byte[32];
            Recording.Random.NextBytes(data);

            using HashAlgorithm hashAlgo = algorithm.GetHashAlgorithm();
            byte[] digest = hashAlgo.ComputeHash(data);

            // Should sign remotely...
            SignResult signResult = await client.SignAsync(algorithm, digest);

            Assert.AreEqual(algorithm, signResult.Algorithm);
            Assert.AreEqual(key.Key.Id, signResult.KeyId);
            Assert.NotNull(signResult.Signature);

            // ...and verify locally.
            VerifyResult verifyResult = await client.VerifyAsync(algorithm, digest, signResult.Signature);

            Assert.AreEqual(algorithm, verifyResult.Algorithm);
            Assert.AreEqual(key.Key.Id, verifyResult.KeyId);
            Assert.IsTrue(verifyResult.IsValid);
        }

        [RecordedTest]
        public async Task EncryptLocalDecryptOnKeyVault([EnumValues(nameof(EncryptionAlgorithm.Rsa15), nameof(EncryptionAlgorithm.RsaOaep), nameof(EncryptionAlgorithm.RsaOaep256))] EncryptionAlgorithm algorithm)
        {
            KeyVaultKey key = await CreateTestKey(algorithm);
            RegisterForCleanup(key.Name);

            CryptographyClient remoteClient = GetCryptoClient(key.Id, forceRemote: true);
            CryptographyClient localClient = GetLocalCryptoClient(key.Key);

            byte[] plaintext = new byte[32];
            Recording.Random.NextBytes(plaintext);

            EncryptResult encrypted = await localClient.EncryptAsync(algorithm, plaintext);

            Assert.AreEqual(algorithm, encrypted.Algorithm);
            Assert.AreEqual(key.Id, encrypted.KeyId);
            Assert.IsNotNull(encrypted.Ciphertext);

            DecryptResult decrypted = await remoteClient.DecryptAsync(algorithm, encrypted.Ciphertext);

            Assert.AreEqual(algorithm, decrypted.Algorithm);
            Assert.AreEqual(key.Id, decrypted.KeyId);
            Assert.IsNotNull(decrypted.Plaintext);

            CollectionAssert.AreEqual(plaintext, decrypted.Plaintext);
        }

        [RecordedTest]
        public async Task EncryptDecryptFromKeyClient()
        {
            KeyVaultKey key = await CreateTestKey(EncryptionAlgorithm.RsaOaep);
            RegisterForCleanup(key.Name);

            byte[] plaintext = Encoding.UTF8.GetBytes("A single block of plaintext");

            // Make sure the same (instrumented) pipeline is used from the KeyClient.
            CryptographyClient cryptoClient = Client.GetCryptographyClient(key.Name, key.Properties.Version);
            EncryptResult encryptResult = await cryptoClient.EncryptAsync(EncryptionAlgorithm.RsaOaep, plaintext);
            DecryptResult decryptResult = await cryptoClient.DecryptAsync(EncryptionAlgorithm.RsaOaep, encryptResult.Ciphertext);

            Assert.AreEqual(plaintext, decryptResult.Plaintext);
        }

        [RecordedTest]
        public async Task EncryptWithKeyNameReturnsFullKeyId()
        {
            KeyVaultKey key = await CreateTestKey(EncryptionAlgorithm.RsaOaep);
            RegisterForCleanup(key.Name);

            byte[] plaintext = Encoding.UTF8.GetBytes("A single block of plaintext");

            Uri keyId = new UriBuilder(Client.VaultUri)
            {
                Path = KeyClient.KeysPath + key.Name,
            }.Uri;

            CryptographyClient client = GetCryptoClient(keyId, forceRemote: true);
            EncryptResult encrypted = await client.EncryptAsync(EncryptionAlgorithm.RsaOaep, plaintext);

            Assert.AreEqual(key.Id.ToString(), encrypted.KeyId);
        }

        [RecordedTest]
        public async Task CreateRSAEncryptDecrypt()
        {
            EncryptionAlgorithm algorithm = EncryptionAlgorithm.RsaOaep256;
            KeyVaultKey key = await CreateTestKey(algorithm);
            RegisterForCleanup(key.Name);

            CryptographyClient client = GetCryptoClient(key.Id);
            using RSA rsa = await client.CreateRSAAsync();

            byte[] plaintext = Encoding.UTF8.GetBytes("A single block of plaintext");
            byte[] ciphertext = rsa.Encrypt(plaintext, RSAEncryptionPadding.OaepSHA256);
            Assert.AreEqual(plaintext, rsa.Decrypt(ciphertext, RSAEncryptionPadding.OaepSHA256));
        }

        [RecordedTest]
        public async Task CreateRSAEncryptDecryptRemote()
        {
            EncryptionAlgorithm algorithm = EncryptionAlgorithm.RsaOaep256;
            KeyVaultKey key = await CreateTestKey(algorithm);
            RegisterForCleanup(key.Name);

            CryptographyClient client = GetCryptoClient(key.Id, forceRemote: true);
            using RSA rsa = await client.CreateRSAAsync();

            byte[] plaintext = Encoding.UTF8.GetBytes("A single block of plaintext");
            byte[] ciphertext = rsa.Encrypt(plaintext, RSAEncryptionPadding.OaepSHA256);
            Assert.AreEqual(plaintext, rsa.Decrypt(ciphertext, RSAEncryptionPadding.OaepSHA256));
        }

        [RecordedTest]
        public async Task CreateRSASignVerify()
        {
            KeyVaultKey key = await CreateTestKey(EncryptionAlgorithm.RsaOaep256);
            RegisterForCleanup(key.Name);

            CryptographyClient client = GetCryptoClient(key.Id);
            using RSA rsa = await client.CreateRSAAsync();

            byte[] plaintext = Encoding.UTF8.GetBytes("A single block of plaintext");
            byte[] hash = rsa.SignData(plaintext, 0, plaintext.Length, HashAlgorithmName.SHA256, RSASignaturePadding.Pss);
            Assert.IsTrue(rsa.VerifyData(plaintext, hash, HashAlgorithmName.SHA256, RSASignaturePadding.Pss));
        }

        [RecordedTest]
        public async Task CreateRSASignVerifyRemote()
        {
            KeyVaultKey key = await CreateTestKey(EncryptionAlgorithm.RsaOaep256);
            RegisterForCleanup(key.Name);

            CryptographyClient client = GetCryptoClient(key.Id, forceRemote: true);
            using RSA rsa = await client.CreateRSAAsync();

            byte[] plaintext = Encoding.UTF8.GetBytes("A single block of plaintext");
            byte[] hash = rsa.SignData(plaintext, 0, plaintext.Length, HashAlgorithmName.SHA256, RSASignaturePadding.Pss);
            Assert.IsTrue(rsa.VerifyData(plaintext, hash, HashAlgorithmName.SHA256, RSASignaturePadding.Pss));
        }

        private async Task<KeyVaultKey> CreateTestKey(EncryptionAlgorithm algorithm)
        {
            string keyName = Recording.GenerateId();

            switch (algorithm.ToString())
            {
                case EncryptionAlgorithm.Rsa15Value:
                case EncryptionAlgorithm.RsaOaepValue:
                case EncryptionAlgorithm.RsaOaep256Value:
                    return await Client.CreateKeyAsync(keyName, KeyType.Rsa);
                default:
                    throw new ArgumentException("Invalid Algorithm", nameof(algorithm));
            }
        }

        protected async Task<KeyVaultKey> CreateTestKey(KeyWrapAlgorithm algorithm)
        {
            string keyName = Recording.GenerateId();

            switch (algorithm.ToString())
            {
                case KeyWrapAlgorithm.Rsa15Value:
                case KeyWrapAlgorithm.RsaOaepValue:
                case KeyWrapAlgorithm.RsaOaep256Value:
                    return await Client.CreateKeyAsync(keyName, KeyType.Rsa);

                case KeyWrapAlgorithm.A128KWValue:
                    return await Client.CreateOctKeyAsync(
                        new CreateOctKeyOptions(keyName) { KeySize = 128 });

                case KeyWrapAlgorithm.A192KWValue:
                    return await Client.CreateOctKeyAsync(
                        new CreateOctKeyOptions(keyName) { KeySize = 192 });

                case KeyWrapAlgorithm.A256KWValue:
                    return await Client.CreateOctKeyAsync(
                        new CreateOctKeyOptions(keyName) { KeySize = 256 });

                case KeyWrapAlgorithm.CkmAesKeyWrapValue:
                case KeyWrapAlgorithm.CkmAesKeyWrapPadValue:
                    if (!IsManagedHSM)
                    {
                        Assert.Ignore("CKM key wrap algorithms are only supported on Managed HSM.");
                    }

                    return await Client.CreateOctKeyAsync(
                        new CreateOctKeyOptions(keyName, hardwareProtected: true) { KeySize = 256 });

                default:
                    throw new ArgumentException("Invalid Algorithm", nameof(algorithm));
            }
        }

        protected CryptographyClient GetCryptoClient(Uri keyId, bool forceRemote = false)
        {
            CryptographyClientOptions options = InstrumentClientOptions(new CryptographyClientOptions((CryptographyClientOptions.ServiceVersion)_serviceVersion));
            CryptographyClient client = new CryptographyClient(keyId, TestEnvironment.Credential, options, forceRemote);
            return InstrumentClient(client);
        }

        private (CryptographyClient ClientProxy, ICryptographyProvider RemoteClientProxy) GetCryptoClient(KeyVaultKey key)
        {
            CryptographyClientOptions options = InstrumentClientOptions(new CryptographyClientOptions((CryptographyClientOptions.ServiceVersion)_serviceVersion));
            CryptographyClient client = new CryptographyClient(key, TestEnvironment.Credential, options);
            CryptographyClient clientProxy = InstrumentClient(client);

            ICryptographyProvider remoteClientProxy = null;
            if (client.RemoteClient is RemoteCryptographyClient remoteClient)
            {
                remoteClientProxy = InstrumentClient(remoteClient);
            }

            return (clientProxy, remoteClientProxy);
        }

        protected CryptographyClient GetLocalCryptoClient(JsonWebKey key)
        {
            LocalCryptographyClientOptions options = InstrumentClientOptions(new LocalCryptographyClientOptions());
            return InstrumentClient(new CryptographyClient(key, options));
        }

        protected async Task<KeyVaultKey> CreateTestKey(SignatureAlgorithm algorithm)
        {
            string keyName = Recording.GenerateId();

            switch (algorithm.ToString())
            {
                case SignatureAlgorithm.RS256Value:
                case SignatureAlgorithm.RS384Value:
                case SignatureAlgorithm.RS512Value:
                case SignatureAlgorithm.PS256Value:
                case SignatureAlgorithm.PS384Value:
                case SignatureAlgorithm.PS512Value:
                    return await Client.CreateKeyAsync(keyName, KeyType.Rsa);
                case SignatureAlgorithm.ES256Value:
                    return await Client.CreateEcKeyAsync(new CreateEcKeyOptions(keyName, false) { CurveName = KeyCurveName.P256 });
                case SignatureAlgorithm.ES256KValue:
                    return await Client.CreateEcKeyAsync(new CreateEcKeyOptions(keyName, false) { CurveName = KeyCurveName.P256K });
                case SignatureAlgorithm.ES384Value:
                    return await Client.CreateEcKeyAsync(new CreateEcKeyOptions(keyName, false) { CurveName = KeyCurveName.P384 });
                case SignatureAlgorithm.ES512Value:
                    return await Client.CreateEcKeyAsync(new CreateEcKeyOptions(keyName, false) { CurveName = KeyCurveName.P521 });
                case SignatureAlgorithm.HS256Value:
                    return await Client.CreateOctKeyAsync(new CreateOctKeyOptions(keyName) { KeySize = 256 });
                case SignatureAlgorithm.HS384Value:
                    return await Client.CreateOctKeyAsync(new CreateOctKeyOptions(keyName) { KeySize = 512});
                case SignatureAlgorithm.HS512Value:
                    return await Client.CreateOctKeyAsync(new CreateOctKeyOptions(keyName) { KeySize = 512 });
                default:
                    throw new ArgumentException("Invalid Algorithm", nameof(algorithm));
            }
        }

        private async Task<KeyVaultKey> CreateTestKeyWithKeyMaterial(SignatureAlgorithm algorithm)
        {
            string keyName = Recording.GenerateId();

            JsonWebKey keyMaterial = KeyUtilities.CreateKey(algorithm, includePrivateParameters: true);
            KeyVaultKey key = await Client.ImportKeyAsync(keyName, keyMaterial);

            keyMaterial.Id = key.Key.Id;
            key.Key = keyMaterial;

            return key;
        }
    }
}
