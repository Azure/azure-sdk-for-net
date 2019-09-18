// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Testing;
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

            RegisterForCleanup(key);
        }

        [Test]
        public async Task WrapUnwrapRoundTrip([Fields]KeyWrapAlgorithm algorithm)
        {
            if (algorithm == KeyWrapAlgorithm.A128KW || algorithm == KeyWrapAlgorithm.A192KW || algorithm == KeyWrapAlgorithm.A256KW)
            {
                Assert.Ignore("Algorithm {0} is not supported by KeyVault at this time", algorithm);
            }

            Key key = await CreateTestKey(algorithm);

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

            RegisterForCleanup(key);
        }

        [Test]
        public async Task SignVerifyDataRoundTrip([Fields]SignatureAlgorithm algorithm)
        {
            Key key = await CreateTestKey(algorithm);

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

            RegisterForCleanup(key);
        }

        [Test]
        public async Task SignVerifyDataStreamRoundTrip([Fields]SignatureAlgorithm algorithm)
        {
            Key key = await CreateTestKey(algorithm);

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

            RegisterForCleanup(key);
        }

        private async Task<Key> CreateTestKey(EncryptionAlgorithm algorithm)
        {
            string keyName = Recording.GenerateId();

            switch (algorithm.ToString())
            {
                case EncryptionAlgorithm.RSA15Value:
                case EncryptionAlgorithm.RSAOAEPValue:
                case EncryptionAlgorithm.RSAOAEP256Value:
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
                case KeyWrapAlgorithm.RSA15Value:
                case KeyWrapAlgorithm.RSAOAEPValue:
                case KeyWrapAlgorithm.RSAOAEP256Value:
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
    }
}
