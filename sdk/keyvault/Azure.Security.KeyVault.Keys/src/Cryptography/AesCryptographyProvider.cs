// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security.Cryptography;
using System.Threading;
using Azure.Core;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    internal class AesCryptographyProvider : LocalCryptographyProvider
    {
        internal AesCryptographyProvider(JsonWebKey keyMaterial, KeyProperties keyProperties) : base(keyMaterial, keyProperties)
        {
        }

        public override bool SupportsOperation(KeyOperation operation)
        {
            if (KeyMaterial != null)
            {
                if (operation == KeyOperation.Encrypt || operation == KeyOperation.Decrypt || operation == KeyOperation.WrapKey || operation == KeyOperation.UnwrapKey)
                {
                    return KeyMaterial.SupportsOperation(operation);
                }
            }

            return false;
        }

        public override DecryptResult Decrypt(DecryptOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            ThrowIfTimeInvalid();

            EncryptionAlgorithm algorithm = options.Algorithm;
            if (algorithm.GetAesCbcEncryptionAlgorithm() is AesCbc aesCbc)
            {
                using ICryptoTransform decryptor = aesCbc.CreateDecryptor(KeyMaterial.K, options.Iv);

                byte[] ciphertext = options.Ciphertext;
                byte[] plaintext = decryptor.TransformFinalBlock(ciphertext, 0, ciphertext.Length);

                return new DecryptResult
                {
                    Algorithm = algorithm,
                    KeyId = KeyMaterial.Id,
                    Plaintext = plaintext,
                };
            }
            else if (algorithm.IsAesGcm() && AesGcmProxy.TryCreate(KeyMaterial.K, out AesGcmProxy aesGcm))
            {
                using (aesGcm)
                {
                    byte[] ciphertext = options.Ciphertext;
                    byte[] plaintext = new byte[ciphertext.Length];

                    aesGcm.Decrypt(options.Iv, ciphertext, options.AuthenticationTag, plaintext, options.AdditionalAuthenticatedData);

                    return new DecryptResult
                    {
                        Algorithm = algorithm,
                        KeyId = KeyMaterial.Id,
                        Plaintext = plaintext,
                    };
                }
            }
            else
            {
                KeysEventSource.Singleton.AlgorithmNotSupported(nameof(Decrypt), algorithm);
                return null;
            }
        }

        public override EncryptResult Encrypt(EncryptOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            ThrowIfTimeInvalid();

            EncryptionAlgorithm algorithm = options.Algorithm;
            if (algorithm.GetAesCbcEncryptionAlgorithm() is AesCbc aesCbc)
            {
                // Make sure the IV is initialized.
                options.Initialize();

                using ICryptoTransform encryptor = aesCbc.CreateEncryptor(KeyMaterial.K, options.Iv);

                byte[] plaintext = options.Plaintext;
                byte[] ciphertext = encryptor.TransformFinalBlock(plaintext, 0, plaintext.Length);

                return new EncryptResult
                {
                    Algorithm = algorithm,
                    KeyId = KeyMaterial.Id,
                    Ciphertext = ciphertext,
                    Iv = options.Iv,
                };
            }
            else if (algorithm.IsAesGcm() && AesGcmProxy.TryCreate(KeyMaterial.K, out AesGcmProxy aesGcm))
            {
                using (aesGcm)
                {
                    byte[] plaintext = options.Plaintext;
                    byte[] ciphertext = new byte[plaintext.Length];
                    byte[] tag = new byte[AesGcmProxy.NonceByteSize];

                    // Generate an nonce only for local AES-GCM; Managed HSM will do it service-side and err if serialized.
                    byte[] iv = Crypto.GenerateIv(AesGcmProxy.NonceByteSize);

                    aesGcm.Encrypt(iv, plaintext, ciphertext, tag, options.AdditionalAuthenticatedData);

                    return new EncryptResult
                    {
                        Algorithm = algorithm,
                        KeyId = KeyMaterial.Id,
                        Ciphertext = ciphertext,
                        Iv = iv,
                        AuthenticationTag = tag,
                        AdditionalAuthenticatedData = options.AdditionalAuthenticatedData,
                    };
                }
            }
            else
            {
                KeysEventSource.Singleton.AlgorithmNotSupported(nameof(Encrypt), algorithm);
                return null;
            }
        }

        public override UnwrapResult UnwrapKey(KeyWrapAlgorithm algorithm, byte[] encryptedKey, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(encryptedKey, nameof(encryptedKey));

            AesKw keyWrapAlgorithm = algorithm.GetAesKeyWrapAlgorithm();
            if (keyWrapAlgorithm == null)
            {
                KeysEventSource.Singleton.AlgorithmNotSupported(nameof(UnwrapKey), algorithm);
                return null;
            }

            int keySizeBytes = GetKeySizeInBytes();
            if (keySizeBytes < keyWrapAlgorithm.KeySizeInBytes)
            {
                throw new ArgumentException($"Key wrap algorithm {algorithm} key size {keyWrapAlgorithm.KeySizeInBytes} is greater than the underlying key size {keySizeBytes}");
            }

            using ICryptoTransform decryptor = keyWrapAlgorithm.CreateDecryptor(KeyMaterial.K);

            byte[] key = decryptor.TransformFinalBlock(encryptedKey, 0, encryptedKey.Length);
            return new UnwrapResult
            {
                Algorithm = algorithm,
                Key = key,
                KeyId = KeyMaterial.Id,
            };
        }

        public override WrapResult WrapKey(KeyWrapAlgorithm algorithm, byte[] key, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(key, nameof(key));

            ThrowIfTimeInvalid();

            AesKw keyWrapAlgorithm = algorithm.GetAesKeyWrapAlgorithm();
            if (keyWrapAlgorithm == null)
            {
                KeysEventSource.Singleton.AlgorithmNotSupported(nameof(WrapKey), algorithm);
                return null;
            }

            int keySizeBytes = GetKeySizeInBytes();
            if (keySizeBytes < keyWrapAlgorithm.KeySizeInBytes)
            {
                throw new ArgumentException($"Key wrap algorithm {algorithm} key size {keyWrapAlgorithm.KeySizeInBytes} is greater than the underlying key size {keySizeBytes}");
            }

            using ICryptoTransform encryptor = keyWrapAlgorithm.CreateEncryptor(KeyMaterial.K);

            byte[] encryptedKey = encryptor.TransformFinalBlock(key, 0, key.Length);
            return new WrapResult
            {
                Algorithm = algorithm,
                EncryptedKey = encryptedKey,
                KeyId = KeyMaterial.Id,
            };
        }

        private int GetKeySizeInBytes()
        {
            if (KeyMaterial.K != null)
            {
                return KeyMaterial.K.Length;
            }

            return 0;
        }
    }
}
