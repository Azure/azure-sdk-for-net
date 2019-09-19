// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Testing;
using Azure.Core.Tests;
using Azure.Identity;
using Azure.Security.KeyVault.Keys.Cryptography;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using static Azure.Core.Tests.ClientDiagnosticListener;

namespace Azure.Security.KeyVault.Keys.Tests
{
    public class CryptographyClientLiveTests : KeysTestBase
    {
        public CryptographyClientLiveTests(bool isAsync)
            : base(isAsync)
        {

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
        public async Task EncryptDecryptRoundTrip([Fields]EncryptionAlgorithm algorithm)
        {
            Key key = await CreateTestKey(algorithm);
            RegisterForCleanup(key);

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
        public async Task WrapUnwrapRoundTrip([Fields]KeyWrapAlgorithm algorithm)
        {
            Key key = await CreateTestKey(algorithm);
            RegisterForCleanup(key);

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
        public async Task SignVerifyDataRoundTrip([Fields]SignatureAlgorithm algorithm)
        {
            Key key = await CreateTestKey(algorithm);
            RegisterForCleanup(key);

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
        public async Task SignVerifyDataStreamRoundTrip([Fields]SignatureAlgorithm algorithm)
        {
            Key key = await CreateTestKey(algorithm);
            RegisterForCleanup(key);

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

#if !NET461
        [Test]
        public async Task LocalSignVerifyRoundTrip([Fields(nameof(SignatureAlgorithm.ES256), nameof(SignatureAlgorithm.ES256K), nameof(SignatureAlgorithm.ES384), nameof(SignatureAlgorithm.ES512))]SignatureAlgorithm algorithm)
        {
            using ClientDiagnosticListener listener = new ClientDiagnosticListener();

            Key key = await CreateTestKeyWithKeyMaterial(algorithm);
            RegisterForCleanup(key);

            (CryptographyClient client, ICryptographyProvider remoteClient) = GetCryptoClient(key.KeyMaterial);

            byte[] data = new byte[32];
            Recording.Random.NextBytes(data);

            using HashAlgorithm hashAlgo = algorithm.GetHashAlgorithm();
            byte[] digest = hashAlgo.ComputeHash(data);

            // Sign locally...
            SignResult signResult = await client.SignAsync(algorithm, digest);

            Assert.AreEqual(algorithm, signResult.Algorithm);
            Assert.AreEqual(key.KeyMaterial.KeyId, signResult.KeyId);
            Assert.NotNull(signResult.Signature);

            listener.AssertScopeNotStarted("Azure.Security.KeyVault.Keys.Cryptography.RemoteCryptographyClient.Sign");
            listener.Scopes.Clear();

            // ...and verify remotely.
            VerifyResult verifyResult = await remoteClient.VerifyAsync(algorithm, digest, signResult.Signature);

            Assert.AreEqual(algorithm, verifyResult.Algorithm);
            Assert.AreEqual(key.KeyMaterial.KeyId, verifyResult.KeyId);
            Assert.IsTrue(verifyResult.IsValid);
        }

        [Test]
        public async Task SignLocalVerifyRoundTrip([Fields(nameof(SignatureAlgorithm.ES256), nameof(SignatureAlgorithm.ES256K), nameof(SignatureAlgorithm.ES384), nameof(SignatureAlgorithm.ES512))]SignatureAlgorithm algorithm)
        {
            using ClientDiagnosticListener listener = new ClientDiagnosticListener();

            Key key = await CreateTestKey(algorithm);
            RegisterForCleanup(key);

            CryptographyClient client = GetCryptoClient(key.Id);

            byte[] data = new byte[32];
            Recording.Random.NextBytes(data);

            using HashAlgorithm hashAlgo = algorithm.GetHashAlgorithm();
            byte[] digest = hashAlgo.ComputeHash(data);

            // Should sign remotely...
            SignResult signResult = await client.SignAsync(algorithm, digest);

            // Check if we failed to create the key when fetched from the server. Currently, macOS doesn't support ES256K.
            ProducedDiagnosticScope scope = listener.GetScope("Azure.Security.KeyVault.Keys.Cryptography.EcCryptographyClient.Sign");
            if (scope != null && scope.Activity.Tags.Contains(new KeyValuePair<string, string>("skip", "PlatformNotSupported")))
            {
                Assert.Inconclusive("This platform does not support {0}", algorithm);
            }

            Assert.AreEqual(algorithm, signResult.Algorithm);
            Assert.AreEqual(key.KeyMaterial.KeyId, signResult.KeyId);
            Assert.NotNull(signResult.Signature);

            listener.AssertScope("Azure.Security.KeyVault.Keys.Cryptography.EcCryptographyClient.Sign", new KeyValuePair<string, string>("skip", "NoPrivateKeyMaterial"));
            listener.Scopes.Clear();

            // ...and verify locally.
            VerifyResult verifyResult = await client.VerifyAsync(algorithm, digest, signResult.Signature);

            Assert.AreEqual(algorithm, verifyResult.Algorithm);
            Assert.AreEqual(key.KeyMaterial.KeyId, verifyResult.KeyId);
            Assert.IsTrue(verifyResult.IsValid);

            listener.AssertScope("Azure.Security.KeyVault.Keys.Cryptography.EcCryptographyClient.Verify");
            listener.AssertScopeNotStarted("Azure.Security.KeyVault.Keys.Cryptography.RemoteCryptographyClient.Verify");
        }
#endif

        private async Task<Key> CreateTestKey(EncryptionAlgorithm algorithm)
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

        private async Task<Key> CreateTestKey(KeyWrapAlgorithm algorithm)
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

            CryptographyClient client = new CryptographyClient(keyId, recording.GetCredential(new DefaultAzureCredential()), recording.InstrumentClientOptions(new CryptographyClientOptions()), forceRemote);
            return InstrumentClient(client);
        }

        private (CryptographyClient, ICryptographyProvider) GetCryptoClient(JsonWebKey keyMaterial, TestRecording recording = null)
        {
            recording ??= Recording;

            CryptographyClient client = new CryptographyClient(keyMaterial, recording.GetCredential(new DefaultAzureCredential()), recording.InstrumentClientOptions(new CryptographyClientOptions()));
            CryptographyClient clientProxy = InstrumentClient(client);

            ICryptographyProvider remoteClientProxy = null;
            if (client.RemoteClient != null)
            {
                RemoteCryptographyClientBroker remoteClientAdapter = new RemoteCryptographyClientBroker(client.RemoteClient);
                remoteClientProxy = InstrumentClient(remoteClientAdapter);
            }

            return (clientProxy, remoteClientProxy);
        }

        private async Task<Key> CreateTestKey(SignatureAlgorithm algorithm)
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
                    return await Client.CreateEcKeyAsync(new EcKeyCreateOptions(keyName, false, KeyCurveName.P256));
                case SignatureAlgorithm.ES256KValue:
                    return await Client.CreateEcKeyAsync(new EcKeyCreateOptions(keyName, false, KeyCurveName.P256K));
                case SignatureAlgorithm.ES384Value:
                    return await Client.CreateEcKeyAsync(new EcKeyCreateOptions(keyName, false, KeyCurveName.P384));
                case SignatureAlgorithm.ES512Value:
                    return await Client.CreateEcKeyAsync(new EcKeyCreateOptions(keyName, false, KeyCurveName.P521));
                default:
                    throw new ArgumentException("Invalid Algorithm", nameof(algorithm));
            }
        }

        private async Task<Key> CreateTestKeyWithKeyMaterial(SignatureAlgorithm algorithm)
        {
            string keyName = Recording.GenerateId();

            JsonWebKey keyMaterial = null;
            switch (algorithm.ToString())
            {
                case SignatureAlgorithm.ES256Value:
                case SignatureAlgorithm.ES256KValue:
                case SignatureAlgorithm.ES384Value:
                case SignatureAlgorithm.ES512Value:
#if NET461
                    Assert.Ignore("Creating JsonWebKey with ECDsa is not supported on net461.");
#else
                    KeyCurveName curveName = algorithm.GetKeyCurveName();
                    ECCurve curve = ECCurve.CreateFromOid(curveName._oid);

                    using (ECDsa ecdsa = ECDsa.Create())
                    {
                        try
                        {
                            ecdsa.GenerateKey(curve);
                            keyMaterial = new JsonWebKey(ecdsa, includePrivateParameters: true);
                        }
                        catch (NotSupportedException)
                        {
                            Assert.Inconclusive("This platform does not support OID {0}", curveName._oid);
                        }
                    }
#endif

                    break;

                default:
                    throw new ArgumentException("Invalid Algorithm", nameof(algorithm));
            }

            Key key = await Client.ImportKeyAsync(keyName, keyMaterial);

            keyMaterial.KeyId = key.KeyMaterial.KeyId;
            key.KeyMaterial = keyMaterial;

            return key;
        }
    }
}
