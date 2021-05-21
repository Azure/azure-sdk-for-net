// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Security.Cryptography;
using System.Threading;
using Azure.Core;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    internal class RsaCryptographyProvider : LocalCryptographyProvider
    {
        internal RsaCryptographyProvider(JsonWebKey keyMaterial, KeyProperties keyProperties, bool localOnly) : base(keyMaterial, keyProperties, localOnly)
        {
        }

        public override bool SupportsOperation(KeyOperation operation)
        {
            if (KeyMaterial != null)
            {
                if (operation == KeyOperation.Encrypt || operation == KeyOperation.Decrypt || operation == KeyOperation.Sign || operation == KeyOperation.Verify || operation == KeyOperation.WrapKey || operation == KeyOperation.UnwrapKey)
                {
                    return KeyMaterial.SupportsOperation(operation);
                }
            }

            return false;
        }

        public override EncryptResult Encrypt(EncryptParameters parameters, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(parameters, nameof(parameters));

            ThrowIfTimeInvalid();

            EncryptionAlgorithm algorithm = parameters.Algorithm;
            RSAEncryptionPadding padding = algorithm.GetRsaEncryptionPadding();
            if (padding is null)
            {
                KeysEventSource.Singleton.AlgorithmNotSupported(nameof(Encrypt), algorithm);
                return null;
            }

            byte[] ciphertext = Encrypt(parameters.Plaintext, padding);
            EncryptResult result = null;

            if (ciphertext != null)
            {
                result = new EncryptResult
                {
                    Algorithm = algorithm,
                    Ciphertext = ciphertext,
                    KeyId = KeyMaterial.Id,
                };
            }

            return result;
        }

        public override DecryptResult Decrypt(DecryptParameters parameters, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(parameters, nameof(parameters));

            if (MustRemote)
            {
                // A private key is required to decrypt. Send to the server.
                KeysEventSource.Singleton.PrivateKeyRequired(nameof(Decrypt));
                return null;
            }

            EncryptionAlgorithm algorithm = parameters.Algorithm;
            RSAEncryptionPadding padding = algorithm.GetRsaEncryptionPadding();
            if (padding is null)
            {
                KeysEventSource.Singleton.AlgorithmNotSupported(nameof(Decrypt), algorithm);
                return null;
            }

            byte[] plaintext = Decrypt(parameters.Ciphertext, padding);
            DecryptResult result = null;

            if (plaintext != null)
            {
                result = new DecryptResult
                {
                    Algorithm = algorithm,
                    KeyId = KeyMaterial.Id,
                    Plaintext = plaintext,
                };
            }

            return result;
        }

        public override SignResult Sign(SignatureAlgorithm algorithm, byte[] digest, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(digest, nameof(digest));

            ThrowIfTimeInvalid();

            // A private key is required to sign. Send to the server.
            if (MustRemote)
            {
                KeysEventSource.Singleton.PrivateKeyRequired(nameof(Sign));
                return null;
            }

            HashAlgorithmName hashAlgorithm = algorithm.GetHashAlgorithmName();
            if (hashAlgorithm == default)
            {
                KeysEventSource.Singleton.AlgorithmNotSupported(nameof(Sign), algorithm);
                return null;
            }

            RSASignaturePadding padding = algorithm.GetRsaSignaturePadding();
            if (padding is null)
            {
                KeysEventSource.Singleton.AlgorithmNotSupported(nameof(Sign), algorithm);
                return null;
            }

            using RSA rsa = KeyMaterial.ToRSA(true);
            byte[] signature = rsa.SignHash(digest, hashAlgorithm, padding);

            return new SignResult
            {
                Algorithm = algorithm,
                KeyId = KeyMaterial.Id,
                Signature = signature,
            };
        }

        public override VerifyResult Verify(SignatureAlgorithm algorithm, byte[] digest, byte[] signature, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(digest, nameof(digest));
            Argument.AssertNotNull(signature, nameof(signature));

            HashAlgorithmName hashAlgorithm = algorithm.GetHashAlgorithmName();
            if (hashAlgorithm == default)
            {
                KeysEventSource.Singleton.AlgorithmNotSupported(nameof(Verify), algorithm);
                return null;
            }

            RSASignaturePadding padding = algorithm.GetRsaSignaturePadding();
            if (padding is null)
            {
                KeysEventSource.Singleton.AlgorithmNotSupported(nameof(Verify), algorithm);
                return null;
            }

            using RSA rsa = KeyMaterial.ToRSA();
            bool isValid = rsa.VerifyHash(digest, signature, hashAlgorithm, padding);

            return new VerifyResult
            {
                Algorithm = algorithm,
                IsValid = isValid,
                KeyId = KeyMaterial.Id,
            };
        }

        public override WrapResult WrapKey(KeyWrapAlgorithm algorithm, byte[] key, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(key, nameof(key));

            ThrowIfTimeInvalid();

            RSAEncryptionPadding padding = algorithm.GetRsaEncryptionPadding();
            if (padding is null)
            {
                KeysEventSource.Singleton.AlgorithmNotSupported(nameof(WrapKey), algorithm);
                return null;
            }

            byte[] encryptedKey = Encrypt(key, padding);
            WrapResult result = null;

            if (encryptedKey != null)
            {
                result = new WrapResult
                {
                    Algorithm = algorithm,
                    EncryptedKey = encryptedKey,
                    KeyId = KeyMaterial.Id,
                };
            }

            return result;
        }

        public override UnwrapResult UnwrapKey(KeyWrapAlgorithm algorithm, byte[] encryptedKey, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(encryptedKey, nameof(encryptedKey));

            if (MustRemote)
            {
                // A private key is required to decrypt. Send to the server.
                KeysEventSource.Singleton.PrivateKeyRequired(nameof(UnwrapKey));
                return null;
            }

            RSAEncryptionPadding padding = algorithm.GetRsaEncryptionPadding();
            if (padding is null)
            {
                KeysEventSource.Singleton.AlgorithmNotSupported(nameof(UnwrapKey), algorithm);
                return null;
            }

            byte[] key = Decrypt(encryptedKey, padding);
            UnwrapResult result = null;

            if (key != null)
            {
                result = new UnwrapResult
                {
                    Algorithm = algorithm,
                    Key = key,
                    KeyId = KeyMaterial.Id,
                };
            }

            return result;
        }

        private byte[] Encrypt(byte[] data, RSAEncryptionPadding padding)
        {
            using RSA rsa = KeyMaterial.ToRSA();
            return rsa.Encrypt(data, padding);
        }

        private byte[] Decrypt(byte[] data, RSAEncryptionPadding padding)
        {
            using RSA rsa = KeyMaterial.ToRSA(true);
            return rsa.Decrypt(data, padding);
        }
    }
}
