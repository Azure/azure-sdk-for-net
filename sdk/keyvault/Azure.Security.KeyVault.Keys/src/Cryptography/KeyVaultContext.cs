// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

using Azure.Core;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    /// <summary>
    /// A signing context used for signing packages with Azure Key Vault Keys.
    /// </summary>
    public struct KeyVaultContext
    {
        private readonly CryptographyClient _cryptographyClient;

        private const string RSAAlgorithmId = "1.2.840.113549.1.1.1";
        private const string ECDsaAlgorithmId = "1.2.840.10045.2.1";

        /// <summary>
        /// Creates a new Key Vault context.
        /// </summary>
        public KeyVaultContext(CryptographyClient cryptographyClient, JsonWebKey publicKey)
        {
            Argument.AssertNotNull(cryptographyClient, nameof(cryptographyClient));
            Argument.AssertNotNull(publicKey, nameof(publicKey));

            PublicKey = publicKey;
            _cryptographyClient = cryptographyClient;
            Certificate = null;
        }

        /// <summary>
        /// Creates a new Key Vault context.
        /// </summary>
        public KeyVaultContext(CryptographyClient cryptographyClient, X509Certificate2 publicCertificate)
        {
            Argument.AssertNotNull(cryptographyClient, nameof(cryptographyClient));
            Argument.AssertNotNull(publicCertificate, nameof(publicCertificate));

            Certificate = publicCertificate;
            _cryptographyClient = cryptographyClient;

            string algorithm = publicCertificate.GetKeyAlgorithm();

            switch (algorithm)
            {
                case RSAAlgorithmId: //rsa
                    using (var rsa = publicCertificate.GetRSAPublicKey())
                    {
                        PublicKey = new JsonWebKey(rsa, includePrivateParameters: false);
                    }
                    break;
                case ECDsaAlgorithmId: //ec
                    using (var ecdsa = publicCertificate.GetECDsaPublicKey())
                    {
                        PublicKey = new JsonWebKey(ecdsa, includePrivateParameters: false);
                    }
                    break;
                default:
                    throw new NotSupportedException($"Certificate algorithm '{algorithm}' is not supported.");
            }
        }

        /// <summary>
        /// Gets the certificate and public key used to validate the signature. May be null if
        /// Key isn't part of a certificate
        /// </summary>
        public X509Certificate2 Certificate { get; }

        /// <summary>
        /// Public key
        /// </summary>
        public JsonWebKey PublicKey { get; }

        internal byte[] SignDigest(byte[] digest, HashAlgorithmName hashAlgorithm, KeyVaultSignatureAlgorithm signatureAlgorithm)
        {
            var algorithm = SignatureAlgorithm.FromHashAlgorithmName(hashAlgorithm, signatureAlgorithm);

            var sigResult = _cryptographyClient.Sign(algorithm, digest);

            return sigResult.Signature;
        }

        internal byte[] DecryptData(byte[] cipherText, RSAEncryptionPadding padding)
        {
            var algorithm = EncryptionAlgorithm.FromRsaEncryptionPadding(padding);

            var dataResult = _cryptographyClient.Decrypt(algorithm, cipherText);
            return dataResult.Plaintext;
        }

        /// <summary>
        /// Returns true if properly constructed. If default, then false.
        /// </summary>
        public bool IsValid => _cryptographyClient != null;
    }
}
