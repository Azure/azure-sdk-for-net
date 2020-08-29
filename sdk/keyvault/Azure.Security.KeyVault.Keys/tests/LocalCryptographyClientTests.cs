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
        public async Task EncryptOperationNotSupported()
        {
            JsonWebKey jwk = new JsonWebKey(RSA.Create(), keyOps: Array.Empty<KeyOperation>());
            LocalCryptographyClient client = CreateClient<LocalCryptographyClient>(jwk);

            await this.CatchAsync<NotSupportedException>(async () => await client.EncryptAsync(new EncryptionAlgorithm("ignored"), TestData));
        }

        [Test]
        public async Task EncryptAlgorithmNotSupported([EnumValues(Exclude = new[] { nameof(KeyType.Rsa), nameof(KeyType.RsaHsm) })] KeyType keyType)
        {
            JsonWebKey jwk = CreateKey(keyType);
            LocalCryptographyClient client = CreateClient<LocalCryptographyClient>(jwk);

            await this.CatchAsync<NotSupportedException>(async () => await client.EncryptAsync(new EncryptionAlgorithm("ignored"), TestData));
        }


        [Test]
        public async Task DecryptOperationNotSupported()
        {
            JsonWebKey jwk = new JsonWebKey(RSA.Create(), keyOps: Array.Empty<KeyOperation>());
            LocalCryptographyClient client = CreateClient<LocalCryptographyClient>(jwk);

            await this.CatchAsync<NotSupportedException>(async () => await client.DecryptAsync(new EncryptionAlgorithm("ignored"), TestData));
        }

        [Test]
        public async Task DecryptAlgorithmNotSupported([EnumValues(Exclude = new[] { nameof(KeyType.Rsa), nameof(KeyType.RsaHsm) })] KeyType keyType)
        {
            JsonWebKey jwk = CreateKey(keyType);
            LocalCryptographyClient client = CreateClient<LocalCryptographyClient>(jwk);

            await this.CatchAsync<NotSupportedException>(async () => await client.DecryptAsync(new EncryptionAlgorithm("ignored"), TestData));
        }

        [Test]
        public async Task DecryptRequiresPrivateKey()
        {
            JsonWebKey jwk = CreateKey(KeyType.Rsa, keyOps: new[] { KeyOperation.Encrypt, KeyOperation.Decrypt });
            LocalCryptographyClient client = CreateClient<LocalCryptographyClient>(jwk);

            EncryptResult encrypted = await client.EncryptAsync(EncryptionAlgorithm.RsaOaep, TestData);

            await this.CatchAsync<CryptographicException>(async () => await client.DecryptAsync(EncryptionAlgorithm.RsaOaep, encrypted.Ciphertext));
        }

        [Test]
        public async Task EncryptDecryptRoundtrip([EnumValues(Exclude = new[] { nameof(EncryptionAlgorithm.RsaOaep256) })] EncryptionAlgorithm algorithm)
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
        public async Task SignOperationNotSupported()
        {
            JsonWebKey jwk = new JsonWebKey(RSA.Create(), keyOps: Array.Empty<KeyOperation>());
            LocalCryptographyClient client = CreateClient<LocalCryptographyClient>(jwk);

            await this.CatchAsync<NotSupportedException>(async () => await client.SignAsync(new SignatureAlgorithm("ignored"), TestData));
        }

        [Test]
        public async Task SignAlgorithmNotSupported([EnumValues(Exclude = new[] { nameof(KeyType.Rsa), nameof(KeyType.RsaHsm), nameof(KeyType.Ec), nameof(KeyType.EcHsm) })] KeyType keyType)
        {
            JsonWebKey jwk = CreateKey(keyType);
            LocalCryptographyClient client = CreateClient<LocalCryptographyClient>(jwk);

            await this.CatchAsync<NotSupportedException>(async () => await client.SignAsync(new SignatureAlgorithm("ignored"), TestData));
        }


        [Test]
        public async Task VerifyOperationNotSupported()
        {
            JsonWebKey jwk = new JsonWebKey(RSA.Create(), keyOps: Array.Empty<KeyOperation>());
            LocalCryptographyClient client = CreateClient<LocalCryptographyClient>(jwk);

            await this.CatchAsync<NotSupportedException>(async () => await client.VerifyAsync(new SignatureAlgorithm("ignored"), TestData, TestData));
        }

        [Test]
        public async Task VerifyAlgorithmNotSupported([EnumValues(Exclude = new[] { nameof(KeyType.Rsa), nameof(KeyType.RsaHsm), nameof(KeyType.Ec), nameof(KeyType.EcHsm) })] KeyType keyType)
        {
            JsonWebKey jwk = CreateKey(keyType);
            LocalCryptographyClient client = CreateClient<LocalCryptographyClient>(jwk);

            await this.CatchAsync<NotSupportedException>(async () => await client.VerifyAsync(new SignatureAlgorithm("ignored"), TestData, TestData));
        }

        [Test]
        public async Task SignRequiresPrivateKey([EnumValues] SignatureAlgorithm algorithm)
        {
            JsonWebKey jwk = KeyUtilities.CreateKey(algorithm, keyOps: new[] { KeyOperation.Sign, KeyOperation.Verify });
            LocalCryptographyClient client = CreateClient<LocalCryptographyClient>(jwk);

            byte[] digest = algorithm.GetHashAlgorithm().ComputeHash(TestData);
            await this.CatchAsync<CryptographicException>(async () => await client.SignAsync(algorithm, digest));
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
        public async Task SignDataOperationNotSupported()
        {
            JsonWebKey jwk = new JsonWebKey(RSA.Create(), keyOps: Array.Empty<KeyOperation>());
            LocalCryptographyClient client = CreateClient<LocalCryptographyClient>(jwk);

            await this.CatchAsync<NotSupportedException>(async () => await client.SignDataAsync(new SignatureAlgorithm("ignored"), TestData));
        }

        [Test]
        public async Task SignDataAlgorithmNotSupported([EnumValues(Exclude = new[] { nameof(KeyType.Rsa), nameof(KeyType.RsaHsm), nameof(KeyType.Ec), nameof(KeyType.EcHsm) })] KeyType keyType)
        {
            JsonWebKey jwk = CreateKey(keyType);
            LocalCryptographyClient client = CreateClient<LocalCryptographyClient>(jwk);

            await this.CatchAsync<NotSupportedException>(async () => await client.SignDataAsync(new SignatureAlgorithm("ignored"), TestData));
        }


        [Test]
        public async Task VerifyDataOperationNotSupported()
        {
            JsonWebKey jwk = new JsonWebKey(RSA.Create(), keyOps: Array.Empty<KeyOperation>());
            LocalCryptographyClient client = CreateClient<LocalCryptographyClient>(jwk);

            await this.CatchAsync<NotSupportedException>(async () => await client.VerifyDataAsync(new SignatureAlgorithm("ignored"), TestData, TestData));
        }

        [Test]
        public async Task VerifyDataAlgorithmNotSupported([EnumValues(Exclude = new[] { nameof(KeyType.Rsa), nameof(KeyType.RsaHsm), nameof(KeyType.Ec), nameof(KeyType.EcHsm) })] KeyType keyType)
        {
            JsonWebKey jwk = CreateKey(keyType);
            LocalCryptographyClient client = CreateClient<LocalCryptographyClient>(jwk);

            await this.CatchAsync<NotSupportedException>(async () => await client.VerifyDataAsync(new SignatureAlgorithm("ignored"), TestData, TestData));
        }

        [Test]
        public async Task SignDataRequiresPrivateKey([EnumValues] SignatureAlgorithm algorithm)
        {
            JsonWebKey jwk = KeyUtilities.CreateKey(algorithm, keyOps: new[] { KeyOperation.Sign, KeyOperation.Verify });
            LocalCryptographyClient client = CreateClient<LocalCryptographyClient>(jwk);

            await this.CatchAsync<CryptographicException>(async () => await client.SignDataAsync(algorithm, TestData));
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
        public async Task SignDataStreamOperationNotSupported()
        {
            JsonWebKey jwk = new JsonWebKey(RSA.Create(), keyOps: Array.Empty<KeyOperation>());
            LocalCryptographyClient client = CreateClient<LocalCryptographyClient>(jwk);

            await this.CatchAsync<NotSupportedException>(async () => await client.SignDataAsync(new SignatureAlgorithm("ignored"), TestStream));
        }

        [Test]
        public async Task SignDataStreamAlgorithmNotSupported([EnumValues(Exclude = new[] { nameof(KeyType.Rsa), nameof(KeyType.RsaHsm), nameof(KeyType.Ec), nameof(KeyType.EcHsm) })] KeyType keyType)
        {
            JsonWebKey jwk = CreateKey(keyType);
            LocalCryptographyClient client = CreateClient<LocalCryptographyClient>(jwk);

            await this.CatchAsync<NotSupportedException>(async () => await client.SignDataAsync(new SignatureAlgorithm("ignored"), TestStream));
        }


        [Test]
        public async Task VerifyDataStreamOperationNotSupported()
        {
            JsonWebKey jwk = new JsonWebKey(RSA.Create(), keyOps: Array.Empty<KeyOperation>());
            LocalCryptographyClient client = CreateClient<LocalCryptographyClient>(jwk);

            await this.CatchAsync<NotSupportedException>(async () => await client.VerifyDataAsync(new SignatureAlgorithm("ignored"), TestStream, TestData));
        }

        [Test]
        public async Task VerifyDataStreamAlgorithmNotSupported([EnumValues(Exclude = new[] { nameof(KeyType.Rsa), nameof(KeyType.RsaHsm), nameof(KeyType.Ec), nameof(KeyType.EcHsm) })] KeyType keyType)
        {
            JsonWebKey jwk = CreateKey(keyType);
            LocalCryptographyClient client = CreateClient<LocalCryptographyClient>(jwk);

            await this.CatchAsync<NotSupportedException>(async () => await client.VerifyDataAsync(new SignatureAlgorithm("ignored"), TestStream, TestData));
        }

        [Test]
        public async Task SignDataStreamRequiresPrivateKey([EnumValues] SignatureAlgorithm algorithm)
        {
            JsonWebKey jwk = KeyUtilities.CreateKey(algorithm, keyOps: new[] { KeyOperation.Sign, KeyOperation.Verify });
            LocalCryptographyClient client = CreateClient<LocalCryptographyClient>(jwk);

            await this.CatchAsync<CryptographicException>(async () => await client.SignDataAsync(algorithm, TestStream));
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
        public async Task WrapKeyOperationNotSupported()
        {
            JsonWebKey jwk = new JsonWebKey(RSA.Create(), keyOps: Array.Empty<KeyOperation>());
            LocalCryptographyClient client = CreateClient<LocalCryptographyClient>(jwk);

            await this.CatchAsync<NotSupportedException>(async () => await client.WrapKeyAsync(new KeyWrapAlgorithm("ignored"), TestData));
        }

        [Test]
        public async Task WrapKeyAlgorithmNotSupported([EnumValues(Exclude = new[] { nameof(KeyType.Ec), nameof(KeyType.EcHsm) })] KeyType keyType)
        {
            JsonWebKey jwk = CreateKey(keyType);
            LocalCryptographyClient client = CreateClient<LocalCryptographyClient>(jwk);

            await this.CatchAsync<NotSupportedException>(async () => await client.WrapKeyAsync(new KeyWrapAlgorithm("ignored"), TestData));
        }


        [Test]
        public async Task UnwrapKeyOperationNotSupported()
        {
            JsonWebKey jwk = new JsonWebKey(RSA.Create(), keyOps: Array.Empty<KeyOperation>());
            LocalCryptographyClient client = CreateClient<LocalCryptographyClient>(jwk);

            await this.CatchAsync<NotSupportedException>(async () => await client.UnwrapKeyAsync(new KeyWrapAlgorithm("ignored"), TestData));
        }

        [Test]
        public async Task UnwrapKeyAlgorithmNotSupported([EnumValues(Exclude = new[] { nameof(KeyType.Ec), nameof(KeyType.EcHsm) })] KeyType keyType)
        {
            JsonWebKey jwk = CreateKey(keyType);
            LocalCryptographyClient client = CreateClient<LocalCryptographyClient>(jwk);

            await this.CatchAsync<NotSupportedException>(async () => await client.UnwrapKeyAsync(new KeyWrapAlgorithm("ignored"), TestData));
        }

        [Test]
        public async Task UnwrapKeyRequiresPrivateKey()
        {
            JsonWebKey jwk = CreateKey(KeyType.Rsa, keyOps: new[] { KeyOperation.WrapKey, KeyOperation.UnwrapKey });
            LocalCryptographyClient client = CreateClient<LocalCryptographyClient>(jwk);

            WrapResult wrapped = await client.WrapKeyAsync(KeyWrapAlgorithm.RsaOaep, TestData);

            await this.CatchAsync<CryptographicException>(async () => await client.UnwrapKeyAsync(KeyWrapAlgorithm.RsaOaep, wrapped.EncryptedKey));
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
                    return new JsonWebKey(Aes.Create(), keyOps);

                default:
                    throw new NotSupportedException(@$"Key type ""{type}"" is not supported");
            }
        }
    }
}
