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
        internal AesCryptographyProvider(JsonWebKey keyMaterial, KeyProperties keyProperties, bool localOnly) : base(keyMaterial, keyProperties, localOnly)
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

        public override DecryptResult Decrypt(DecryptParameters parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(parameters, nameof(parameters));

            ThrowIfTimeInvalid();

            EncryptionAlgorithm algorithm = parameters.Algorithm;
            if (algorithm.GetAesCbcEncryptionAlgorithm() is AesCbc aesCbc)
            {
                using ICryptoTransform decryptor = aesCbc.CreateDecryptor(KeyMaterial.K, parameters.Iv);

                byte[] ciphertext = parameters.Ciphertext;
                byte[] plaintext = decryptor.TransformFinalBlock(ciphertext, 0, ciphertext.Length);

                return new DecryptResult
                {
                    Algorithm = algorithm,
                    KeyId = KeyMaterial.Id,
                    Plaintext = plaintext,
                };
            }
            else
            {
                KeysEventSource.Singleton.AlgorithmNotSupported(nameof(Decrypt), algorithm);
                return null;
            }
        }

        public override EncryptResult Encrypt(EncryptParameters parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(parameters, nameof(parameters));

            ThrowIfTimeInvalid();

            EncryptionAlgorithm algorithm = parameters.Algorithm;
            if (algorithm.GetAesCbcEncryptionAlgorithm() is AesCbc aesCbc)
            {
                // Make sure the IV is initialized.
                parameters.Initialize();

                using ICryptoTransform encryptor = aesCbc.CreateEncryptor(KeyMaterial.K, parameters.Iv);

                byte[] plaintext = parameters.Plaintext;
                byte[] ciphertext = encryptor.TransformFinalBlock(plaintext, 0, plaintext.Length);

                return new EncryptResult
                {
                    Algorithm = algorithm,
                    KeyId = KeyMaterial.Id,
                    Ciphertext = ciphertext,
                    Iv = parameters.Iv,
                };
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
