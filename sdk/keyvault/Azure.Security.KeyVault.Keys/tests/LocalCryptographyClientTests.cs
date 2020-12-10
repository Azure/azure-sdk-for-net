// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Security.KeyVault.Keys.Cryptography;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Azure.Security.KeyVault.Keys.Tests
{
    public class LocalCryptographyClientTests : ClientTestBase
    {
        public LocalCryptographyClientTests(bool isAsync) : base(isAsync)
        {
            TestDiagnostics = false;
        }

        private byte[] TestData { get; } = Encoding.UTF8.GetBytes("test");

        private byte[] TestKey { get; } = new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07 };

        private Stream TestStream => new MemoryStream(TestData);

        [Test]
        [SyncOnly]
        public void LocalCryptographyClientRequiresJsonWebKey()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => new LocalCryptographyClient(null));
            Assert.AreEqual("jsonWebKey", ex.ParamName);
        }

        [Test]
        [SyncOnly]
        public void LocalCryptographyClientRequiredJsonWebKeyType()
        {
            JsonWebKey jwk = new JsonWebKey(null);

            Assert.Throws<NotSupportedException>(() => new LocalCryptographyClient(jwk));
        }

        [Test]
        [SyncOnly]
        public void KeyIdFromJsonWebKey()
        {
            JsonWebKey jwk = new JsonWebKey(null)
            {
                Id = nameof(KeyIdFromJsonWebKey),
                KeyType = KeyType.Rsa,
            };

            LocalCryptographyClient client = new LocalCryptographyClient(jwk);

            Assert.AreEqual(nameof(KeyIdFromJsonWebKey), client.KeyId);
        }

        #region Encrypt / Decrypt
        [Test]
        public void EncryptOperationNotSupported()
        {
            JsonWebKey jwk = new JsonWebKey(RSA.Create(), keyOps: Array.Empty<KeyOperation>());
            LocalCryptographyClient client = CreateClient<LocalCryptographyClient>(jwk);

            Assert.ThrowsAsync<NotSupportedException>(async () => await client.EncryptAsync(new EncryptionAlgorithm("ignored"), TestData));
        }

        [Test]
        public void EncryptAlgorithmNotSupported([EnumValues(Exclude = new[] { nameof(KeyType.Rsa), nameof(KeyType.RsaHsm), nameof(KeyType.Oct), nameof(KeyType.OctHsm) })] KeyType keyType)
        {
            JsonWebKey jwk = CreateKey(keyType);
            LocalCryptographyClient client = CreateClient<LocalCryptographyClient>(jwk);

            Assert.ThrowsAsync<NotSupportedException>(async () => await client.EncryptAsync(new EncryptionAlgorithm("ignored"), TestData));
        }

        [Test]
        public void DecryptOperationNotSupported()
        {
            JsonWebKey jwk = new JsonWebKey(RSA.Create(), keyOps: Array.Empty<KeyOperation>());
            LocalCryptographyClient client = CreateClient<LocalCryptographyClient>(jwk);

            Assert.ThrowsAsync<NotSupportedException>(async () => await client.DecryptAsync(new EncryptionAlgorithm("ignored"), TestData));
        }

        [Test]
        public void DecryptAlgorithmNotSupported([EnumValues(Exclude = new[] { nameof(KeyType.Rsa), nameof(KeyType.RsaHsm), nameof(KeyType.Oct), nameof(KeyType.OctHsm) })] KeyType keyType)
        {
            JsonWebKey jwk = CreateKey(keyType);
            LocalCryptographyClient client = CreateClient<LocalCryptographyClient>(jwk);

            Assert.ThrowsAsync<NotSupportedException>(async () => await client.DecryptAsync(new EncryptionAlgorithm("ignored"), TestData));
        }

        [Test]
        public async Task DecryptRequiresPrivateKey()
        {
            JsonWebKey jwk = CreateKey(KeyType.Rsa, keyOps: new[] { KeyOperation.Encrypt, KeyOperation.Decrypt });
            LocalCryptographyClient client = CreateClient<LocalCryptographyClient>(jwk);

            EncryptResult encrypted = await client.EncryptAsync(EncryptionAlgorithm.RsaOaep, TestData);

            Assert.ThrowsAsync(new InstanceOfTypeConstraint(typeof(CryptographicException)), async () => await client.DecryptAsync(EncryptionAlgorithm.RsaOaep, encrypted.Ciphertext));
        }

        // TODO: Record tests on Managed HSM for other EncryptionAlgorithm values.
        [Test]
        public async Task EncryptDecryptRoundtrip([EnumValues(nameof(EncryptionAlgorithm.Rsa15), nameof(EncryptionAlgorithm.RsaOaep))] EncryptionAlgorithm algorithm)
        {
            JsonWebKey jwk = CreateKey(KeyType.Rsa, includePrivateParameters: true);
            LocalCryptographyClient client = CreateClient<LocalCryptographyClient>(jwk);

            EncryptResult encrypted = await client.EncryptAsync(algorithm, TestData);

            DecryptResult decrypted = await client.DecryptAsync(algorithm, encrypted.Ciphertext);
            string actual = Encoding.UTF8.GetString(decrypted.Plaintext);

            Assert.AreEqual("test", actual);
        }
        #endregion

        #region Sign / Verify
        [Test]
        public void SignOperationNotSupported()
        {
            JsonWebKey jwk = new JsonWebKey(RSA.Create(), keyOps: Array.Empty<KeyOperation>());
            LocalCryptographyClient client = CreateClient<LocalCryptographyClient>(jwk);

            Assert.ThrowsAsync<NotSupportedException>(async () => await client.SignAsync(new SignatureAlgorithm("ignored"), TestData));
        }

        [Test]
        public void SignAlgorithmNotSupported([EnumValues(Exclude = new[] { nameof(KeyType.Rsa), nameof(KeyType.RsaHsm), nameof(KeyType.Ec), nameof(KeyType.EcHsm) })] KeyType keyType)
        {
            JsonWebKey jwk = CreateKey(keyType);
            LocalCryptographyClient client = CreateClient<LocalCryptographyClient>(jwk);

            Assert.ThrowsAsync<NotSupportedException>(async () => await client.SignAsync(new SignatureAlgorithm("ignored"), TestData));
        }

        [Test]
        public void VerifyOperationNotSupported()
        {
            JsonWebKey jwk = new JsonWebKey(RSA.Create(), keyOps: Array.Empty<KeyOperation>());
            LocalCryptographyClient client = CreateClient<LocalCryptographyClient>(jwk);

            Assert.ThrowsAsync<NotSupportedException>(async () => await client.VerifyAsync(new SignatureAlgorithm("ignored"), TestData, TestData));
        }

        [Test]
        public void VerifyAlgorithmNotSupported([EnumValues(Exclude = new[] { nameof(KeyType.Rsa), nameof(KeyType.RsaHsm), nameof(KeyType.Ec), nameof(KeyType.EcHsm) })] KeyType keyType)
        {
            JsonWebKey jwk = CreateKey(keyType);
            LocalCryptographyClient client = CreateClient<LocalCryptographyClient>(jwk);

            Assert.ThrowsAsync<NotSupportedException>(async () => await client.VerifyAsync(new SignatureAlgorithm("ignored"), TestData, TestData));
        }

        [Test]
        public void SignRequiresPrivateKey([EnumValues] SignatureAlgorithm algorithm)
        {
            JsonWebKey jwk = KeyUtilities.CreateKey(algorithm, keyOps: new[] { KeyOperation.Sign, KeyOperation.Verify });
            LocalCryptographyClient client = CreateClient<LocalCryptographyClient>(jwk);

            byte[] digest = algorithm.GetHashAlgorithm().ComputeHash(TestData);
            Assert.ThrowsAsync(new InstanceOfTypeConstraint(typeof(CryptographicException)), async () => await client.SignAsync(algorithm, digest));
        }

        [Test]
        public async Task SignVerifyRoundtrip([EnumValues(Exclude = new[] { nameof(SignatureAlgorithm.PS256), nameof(SignatureAlgorithm.PS384), nameof(SignatureAlgorithm.PS512) })] SignatureAlgorithm algorithm)
        {
            JsonWebKey jwk = KeyUtilities.CreateKey(algorithm, includePrivateParameters: true);
            LocalCryptographyClient client = CreateClient<LocalCryptographyClient>(jwk);

            byte[] digest = algorithm.GetHashAlgorithm().ComputeHash(TestData);
            SignResult signed = await client.SignAsync(algorithm, digest);

            VerifyResult verified = await client.VerifyAsync(algorithm, digest, signed.Signature);
            Assert.IsTrue(verified.IsValid);
        }
        #endregion

        #region SignData / VerifyData
        [Test]
        public void SignDataOperationNotSupported()
        {
            JsonWebKey jwk = new JsonWebKey(RSA.Create(), keyOps: Array.Empty<KeyOperation>());
            LocalCryptographyClient client = CreateClient<LocalCryptographyClient>(jwk);

            Assert.ThrowsAsync<NotSupportedException>(async () => await client.SignDataAsync(new SignatureAlgorithm("ignored"), TestData));
        }

        [Test]
        public void SignDataAlgorithmNotSupported([EnumValues(Exclude = new[] { nameof(KeyType.Rsa), nameof(KeyType.RsaHsm), nameof(KeyType.Ec), nameof(KeyType.EcHsm) })] KeyType keyType)
        {
            JsonWebKey jwk = CreateKey(keyType);
            LocalCryptographyClient client = CreateClient<LocalCryptographyClient>(jwk);

            Assert.ThrowsAsync<NotSupportedException>(async () => await client.SignDataAsync(new SignatureAlgorithm("ignored"), TestData));
        }

        [Test]
        public void VerifyDataOperationNotSupported()
        {
            JsonWebKey jwk = new JsonWebKey(RSA.Create(), keyOps: Array.Empty<KeyOperation>());
            LocalCryptographyClient client = CreateClient<LocalCryptographyClient>(jwk);

            Assert.ThrowsAsync<NotSupportedException>(async () => await client.VerifyDataAsync(new SignatureAlgorithm("ignored"), TestData, TestData));
        }

        [Test]
        public void VerifyDataAlgorithmNotSupported([EnumValues(Exclude = new[] { nameof(KeyType.Rsa), nameof(KeyType.RsaHsm), nameof(KeyType.Ec), nameof(KeyType.EcHsm) })] KeyType keyType)
        {
            JsonWebKey jwk = CreateKey(keyType);
            LocalCryptographyClient client = CreateClient<LocalCryptographyClient>(jwk);

            Assert.ThrowsAsync<NotSupportedException>(async () => await client.VerifyDataAsync(new SignatureAlgorithm("ignored"), TestData, TestData));
        }

        [Test]
        public void SignDataRequiresPrivateKey([EnumValues] SignatureAlgorithm algorithm)
        {
            JsonWebKey jwk = KeyUtilities.CreateKey(algorithm, keyOps: new[] { KeyOperation.Sign, KeyOperation.Verify });
            LocalCryptographyClient client = CreateClient<LocalCryptographyClient>(jwk);

            Assert.ThrowsAsync(new InstanceOfTypeConstraint(typeof(CryptographicException)) , async () => await client.SignDataAsync(algorithm, TestData));
        }

        [Test]
        public async Task SignDataVerifyDataRoundtrip([EnumValues(Exclude = new[] { nameof(SignatureAlgorithm.PS256), nameof(SignatureAlgorithm.PS384), nameof(SignatureAlgorithm.PS512) })] SignatureAlgorithm algorithm)
        {
            JsonWebKey jwk = KeyUtilities.CreateKey(algorithm, includePrivateParameters: true);
            LocalCryptographyClient client = CreateClient<LocalCryptographyClient>(jwk);

            SignResult signed = await client.SignDataAsync(algorithm, TestData);

            VerifyResult verified = await client.VerifyDataAsync(algorithm, TestData, signed.Signature);
            Assert.IsTrue(verified.IsValid);
        }
        #endregion

        #region SignDataStream / VerifyDataStream
        [Test]
        public void SignDataStreamOperationNotSupported()
        {
            JsonWebKey jwk = new JsonWebKey(RSA.Create(), keyOps: Array.Empty<KeyOperation>());
            LocalCryptographyClient client = CreateClient<LocalCryptographyClient>(jwk);

            Assert.ThrowsAsync<NotSupportedException>(async () => await client.SignDataAsync(new SignatureAlgorithm("ignored"), TestStream));
        }

        [Test]
        public void SignDataStreamAlgorithmNotSupported([EnumValues(Exclude = new[] { nameof(KeyType.Rsa), nameof(KeyType.RsaHsm), nameof(KeyType.Ec), nameof(KeyType.EcHsm) })] KeyType keyType)
        {
            JsonWebKey jwk = CreateKey(keyType);
            LocalCryptographyClient client = CreateClient<LocalCryptographyClient>(jwk);

            Assert.ThrowsAsync<NotSupportedException>(async () => await client.SignDataAsync(new SignatureAlgorithm("ignored"), TestStream));
        }

        [Test]
        public void VerifyDataStreamOperationNotSupported()
        {
            JsonWebKey jwk = new JsonWebKey(RSA.Create(), keyOps: Array.Empty<KeyOperation>());
            LocalCryptographyClient client = CreateClient<LocalCryptographyClient>(jwk);

            Assert.ThrowsAsync<NotSupportedException>(async () => await client.VerifyDataAsync(new SignatureAlgorithm("ignored"), TestStream, TestData));
        }

        [Test]
        public void VerifyDataStreamAlgorithmNotSupported([EnumValues(Exclude = new[] { nameof(KeyType.Rsa), nameof(KeyType.RsaHsm), nameof(KeyType.Ec), nameof(KeyType.EcHsm) })] KeyType keyType)
        {
            JsonWebKey jwk = CreateKey(keyType);
            LocalCryptographyClient client = CreateClient<LocalCryptographyClient>(jwk);

            Assert.ThrowsAsync<NotSupportedException>(async () => await client.VerifyDataAsync(new SignatureAlgorithm("ignored"), TestStream, TestData));
        }

        [Test]
        public void SignDataStreamRequiresPrivateKey([EnumValues] SignatureAlgorithm algorithm)
        {
            JsonWebKey jwk = KeyUtilities.CreateKey(algorithm, keyOps: new[] { KeyOperation.Sign, KeyOperation.Verify });
            LocalCryptographyClient client = CreateClient<LocalCryptographyClient>(jwk);

            Assert.ThrowsAsync(new InstanceOfTypeConstraint(typeof(CryptographicException)), async () => await client.SignDataAsync(algorithm, TestStream));
        }

        [Test]
        public async Task SignDataStreamVerifyDataStreamRoundtrip([EnumValues(Exclude = new[] { nameof(SignatureAlgorithm.PS256), nameof(SignatureAlgorithm.PS384), nameof(SignatureAlgorithm.PS512) })] SignatureAlgorithm algorithm)
        {
            JsonWebKey jwk = KeyUtilities.CreateKey(algorithm, includePrivateParameters: true);
            LocalCryptographyClient client = CreateClient<LocalCryptographyClient>(jwk);

            SignResult signed = await client.SignDataAsync(algorithm, TestStream);

            VerifyResult verified = await client.VerifyDataAsync(algorithm, TestStream, signed.Signature);
            Assert.IsTrue(verified.IsValid);
        }
#endregion

        #region WrapKey / UnwrapKey
        [Test]
        public void WrapKeyOperationNotSupported()
        {
            JsonWebKey jwk = new JsonWebKey(RSA.Create(), keyOps: Array.Empty<KeyOperation>());
            LocalCryptographyClient client = CreateClient<LocalCryptographyClient>(jwk);

            Assert.ThrowsAsync<NotSupportedException>(async () => await client.WrapKeyAsync(new KeyWrapAlgorithm("ignored"), TestData));
        }

        [Test]
        public void WrapKeyAlgorithmNotSupported([EnumValues(Exclude = new[] { nameof(KeyType.Ec), nameof(KeyType.EcHsm) })] KeyType keyType)
        {
            JsonWebKey jwk = CreateKey(keyType);
            LocalCryptographyClient client = CreateClient<LocalCryptographyClient>(jwk);

            Assert.ThrowsAsync<NotSupportedException>(async () => await client.WrapKeyAsync(new KeyWrapAlgorithm("ignored"), TestData));
        }

        [Test]
        public void UnwrapKeyOperationNotSupported()
        {
            JsonWebKey jwk = new JsonWebKey(RSA.Create(), keyOps: Array.Empty<KeyOperation>());
            LocalCryptographyClient client = CreateClient<LocalCryptographyClient>(jwk);

            Assert.ThrowsAsync<NotSupportedException>(async () => await client.UnwrapKeyAsync(new KeyWrapAlgorithm("ignored"), TestData));
        }

        [Test]
        public void UnwrapKeyAlgorithmNotSupported([EnumValues(Exclude = new[] { nameof(KeyType.Ec), nameof(KeyType.EcHsm) })] KeyType keyType)
        {
            JsonWebKey jwk = CreateKey(keyType);
            LocalCryptographyClient client = CreateClient<LocalCryptographyClient>(jwk);

            Assert.ThrowsAsync<NotSupportedException>(async () => await client.UnwrapKeyAsync(new KeyWrapAlgorithm("ignored"), TestData));
        }

        [Test]
        public async Task UnwrapKeyRequiresPrivateKey()
        {
            JsonWebKey jwk = CreateKey(KeyType.Rsa, keyOps: new[] { KeyOperation.WrapKey, KeyOperation.UnwrapKey });
            LocalCryptographyClient client = CreateClient<LocalCryptographyClient>(jwk);

            WrapResult wrapped = await client.WrapKeyAsync(KeyWrapAlgorithm.RsaOaep, TestData);

            Assert.ThrowsAsync(new InstanceOfTypeConstraint(typeof(CryptographicException)), async () => await client.UnwrapKeyAsync(KeyWrapAlgorithm.RsaOaep, wrapped.EncryptedKey));
        }

        [Test]
        public async Task WrapKeyUnwrapKeyRoundtrip([EnumValues(Exclude = new[] { nameof(KeyWrapAlgorithm.RsaOaep256) })] KeyWrapAlgorithm algorithm)
        {
            JsonWebKey jwk = KeyUtilities.CreateKey(algorithm, includePrivateParameters: true);
            LocalCryptographyClient client = CreateClient<LocalCryptographyClient>(jwk);

            WrapResult wrapped = await client.WrapKeyAsync(algorithm, TestKey);
            UnwrapResult unwrapped = await client.UnwrapKeyAsync(algorithm, wrapped.EncryptedKey);

            CollectionAssert.AreEqual(TestKey, unwrapped.Key);
        }
        #endregion

        private static JsonWebKey CreateKey(KeyType type, bool includePrivateParameters = false, IEnumerable<KeyOperation> keyOps = null)
        {
            switch (type.ToString())
            {
#if NET461
                case KeyType.EcValue:
                case KeyType.EcHsmValue:
                    throw new IgnoreException("Creating JsonWebKey with ECDsa is not supported on net461.");
#else
                case KeyType.EcValue:
                case KeyType.EcHsmValue:
                    return new JsonWebKey(ECDsa.Create(), includePrivateParameters, keyOps);
#endif
                case KeyType.RsaValue:
                case KeyType.RsaHsmValue:
                    return new JsonWebKey(RSA.Create(), includePrivateParameters, keyOps);

                case KeyType.OctValue:
                case KeyType.OctHsmValue:
                    return new JsonWebKey(Aes.Create(), keyOps);

                default:
                    throw new NotSupportedException(@$"Key type ""{type}"" is not supported");
            }
        }
    }
}
