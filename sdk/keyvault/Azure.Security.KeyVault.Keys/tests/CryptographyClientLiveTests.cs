// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.Security.KeyVault.Keys.Cryptography;
using NUnit.Framework;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Keys.Tests
{
    public class CryptographyClientLiveTests : KeysTestBase
    {
        private readonly KeyClientOptions.ServiceVersion _serviceVersion;
        public CryptographyClientLiveTests(bool isAsync, KeyClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion)
        {
            _serviceVersion = serviceVersion;
            // TODO: https://github.com/Azure/azure-sdk-for-net/issues/11634
            Matcher = new RecordMatcher(compareBodies: false);
        }

        [SetUp]
        public void ClearChallengeCacheforRecord()
        {
            // in record mode we reset the challenge cache before each test so that the challenge call
            // is always made.  This allows tests to be replayed independently and in any order
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                Client = GetClient();

                ChallengeBasedAuthenticationPolicy.AuthenticationChallenge.ClearCache();
            }
        }

        [Test]
        public async Task EncryptDecryptRoundTrip([EnumValues]EncryptionAlgorithm algorithm)
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

        [Test]
        public async Task WrapUnwrapRoundTrip([EnumValues(Exclude = new[] { nameof(KeyWrapAlgorithm.A128KW), nameof(KeyWrapAlgorithm.A192KW), nameof(KeyWrapAlgorithm.A256KW) })]KeyWrapAlgorithm algorithm)
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

        [Test]
        public async Task SignVerifyDataRoundTrip([EnumValues]SignatureAlgorithm algorithm)
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

        [Test]
        public async Task SignVerifyDataStreamRoundTrip([EnumValues]SignatureAlgorithm algorithm)
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
            Assert.True(verifyResult.IsValid);
        }

        // We do not test using ES256K below since macOS doesn't support it; various ideas to work around that adversely affect runtime code too much.

        [Test]
        public async Task LocalSignVerifyRoundTrip([EnumValues(Exclude = new[] { nameof(SignatureAlgorithm.ES256K) })]SignatureAlgorithm algorithm)
        {
#if NET461
            if (algorithm.GetEcKeyCurveName() != default)
            {
                Assert.Ignore("Creating JsonWebKey with ECDsa is not supported on net461.");
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

        [Test]
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

        [Test]
        public async Task SignLocalVerifyRoundTrip([EnumValues(Exclude = new[] { nameof(SignatureAlgorithm.ES256K) })]SignatureAlgorithm algorithm)
        {
#if NET461
            if (algorithm.GetEcKeyCurveName() != default)
            {
                Assert.Ignore("Creating JsonWebKey with ECDsa is not supported on net461.");
            }
#endif

#if NETFRAMEWORK
            if (algorithm.GetRsaSignaturePadding() == RSASignaturePadding.Pss)
            {
                Assert.Ignore("RSA-PSS signature padding is not supported on .NET Framework.");
            }
#endif

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

        [Test]
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

        private async Task<KeyVaultKey> CreateTestKey(KeyWrapAlgorithm algorithm)
        {
            string keyName = Recording.GenerateId();

            switch (algorithm.ToString())
            {
                case KeyWrapAlgorithm.Rsa15Value:
                case KeyWrapAlgorithm.RsaOaepValue:
                case KeyWrapAlgorithm.RsaOaep256Value:
                    return await Client.CreateKeyAsync(keyName, KeyType.Rsa);
                default:
                    throw new ArgumentException("Invalid Algorithm", nameof(algorithm));
            }
        }

        private CryptographyClient GetCryptoClient(Uri keyId, bool forceRemote = false, TestRecording recording = null)
        {
            recording ??= Recording;

            CryptographyClientOptions options = recording.InstrumentClientOptions(new CryptographyClientOptions((CryptographyClientOptions.ServiceVersion)_serviceVersion));
            CryptographyClient client = new CryptographyClient(keyId, TestEnvironment.Credential, options, forceRemote);
            return InstrumentClient(client);
        }

        private (CryptographyClient, ICryptographyProvider) GetCryptoClient(KeyVaultKey key, TestRecording recording = null)
        {
            recording ??= Recording;

            CryptographyClientOptions options = recording.InstrumentClientOptions(new CryptographyClientOptions((CryptographyClientOptions.ServiceVersion)_serviceVersion));
            CryptographyClient client = new CryptographyClient(key, TestEnvironment.Credential, options);
            CryptographyClient clientProxy = InstrumentClient(client);

            ICryptographyProvider remoteClientProxy = null;
            if (client.RemoteClient is RemoteCryptographyClient remoteClient)
            {
                remoteClientProxy = InstrumentClient(remoteClient);
            }

            return (clientProxy, remoteClientProxy);
        }

        private async Task<KeyVaultKey> CreateTestKey(SignatureAlgorithm algorithm)
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
                default:
                    throw new ArgumentException("Invalid Algorithm", nameof(algorithm));
            }
        }

        private async Task<KeyVaultKey> CreateTestKeyWithKeyMaterial(SignatureAlgorithm algorithm)
        {
            string keyName = Recording.GenerateId();

            JsonWebKey keyMaterial = null;
            switch (algorithm.ToString())
            {
                case SignatureAlgorithm.PS256Value:
                case SignatureAlgorithm.PS384Value:
                case SignatureAlgorithm.PS512Value:
                case SignatureAlgorithm.RS256Value:
                case SignatureAlgorithm.RS384Value:
                case SignatureAlgorithm.RS512Value:
                    keyMaterial = KeyUtilities.CreateRsaKey(includePrivateParameters: true);
                    break;

                case SignatureAlgorithm.ES256Value:
                case SignatureAlgorithm.ES256KValue:
                case SignatureAlgorithm.ES384Value:
                case SignatureAlgorithm.ES512Value:
#if NET461
                    Assert.Ignore("Creating JsonWebKey with ECDsa is not supported on net461.");
#else
                    KeyCurveName curveName = algorithm.GetEcKeyCurveName();
                    ECCurve curve = ECCurve.CreateFromOid(curveName.Oid);

                    using (ECDsa ecdsa = ECDsa.Create())
                    {
                        try
                        {
                            ecdsa.GenerateKey(curve);
                            keyMaterial = new JsonWebKey(ecdsa, includePrivateParameters: true);
                        }
                        catch (NotSupportedException)
                        {
                            Assert.Inconclusive("This platform does not support OID {0}", curveName.Oid);
                        }
                    }
#endif

                    break;

                default:
                    throw new ArgumentException("Invalid Algorithm", nameof(algorithm));
            }

            KeyVaultKey key = await Client.ImportKeyAsync(keyName, keyMaterial);

            keyMaterial.Id = key.Key.Id;
            key.Key = keyMaterial;

            return key;
        }
    }
}
