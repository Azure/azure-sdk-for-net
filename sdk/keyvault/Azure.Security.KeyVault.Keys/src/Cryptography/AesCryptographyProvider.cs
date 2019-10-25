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
        internal AesCryptographyProvider(KeyVaultKey key) : base(key)
        {
        }

        public override bool SupportsOperation(KeyOperation operation)
        {
            if (KeyMaterial != null)
            {
                if (operation == KeyOperation.WrapKey || operation == KeyOperation.UnwrapKey)
                {
                    return KeyMaterial.SupportsOperation(operation);
                }
            }

            return false;
        }

        public override UnwrapResult UnwrapKey(KeyWrapAlgorithm algorithm, byte[] encryptedKey, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(encryptedKey, nameof(encryptedKey));

            int algorithmKeySizeBytes = algorithm.GetKeySizeInBytes();
            if (algorithmKeySizeBytes == 0)
            {
                KeysEventSource.Singleton.AlgorithmNotSupported(nameof(UnwrapKey), algorithm);
                return null;
            }

            int keySizeBytes = GetKeySizeInBytes();
            if (keySizeBytes < algorithmKeySizeBytes)
            {
                throw new ArgumentException($"Key wrap algorithm {algorithm} key size {algorithmKeySizeBytes} is greater than the underlying key size {keySizeBytes}");
            }

            byte[] sizedKey = (keySizeBytes == algorithmKeySizeBytes) ? KeyMaterial.K : KeyMaterial.K.Take(algorithmKeySizeBytes);

            using ICryptoTransform decryptor = AesKw.CreateDecryptor(sizedKey);

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

            int algorithmKeySizeBytes = algorithm.GetKeySizeInBytes();
            if (algorithmKeySizeBytes == 0)
            {
                KeysEventSource.Singleton.AlgorithmNotSupported(nameof(WrapKey), algorithm);
                return null;
            }

            int keySizeBytes = GetKeySizeInBytes();
            if (keySizeBytes < algorithmKeySizeBytes)
            {
                throw new ArgumentException($"Key wrap algorithm {algorithm} key size {algorithmKeySizeBytes} is greater than the underlying key size {keySizeBytes}");
            }

            byte[] sizedKey = (keySizeBytes == algorithmKeySizeBytes) ? KeyMaterial.K : KeyMaterial.K.Take(algorithmKeySizeBytes);

            using ICryptoTransform encryptor = AesKw.CreateEncryptor(sizedKey);

            byte[] encryptedKey = encryptor.TransformFinalBlock(key, 0, key.Length);
            return new WrapResult
            {
                Algorithm = algorithm,
                EncryptedKey = encryptedKey,
                KeyId = KeyMaterial.Id,
            };
        }

        private int GetKeySizeInBits()
        {
            return GetKeySizeInBytes() << 3;
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
