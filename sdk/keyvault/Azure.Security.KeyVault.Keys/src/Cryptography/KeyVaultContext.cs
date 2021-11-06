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

        /// <summary>
        /// Creates a new Key Vault context.
        /// </summary>
        public KeyVaultContext(TokenCredential credential, Uri keyId, JsonWebKey key)
        {
            if (credential is null)
            {
                throw new ArgumentNullException(nameof(credential));
            }

            KeyIdentifier = keyId ?? throw new ArgumentNullException(nameof(keyId));
            Key = key ?? throw new ArgumentNullException(nameof(key));

            _cryptographyClient = new CryptographyClient(keyId, credential);
            Certificate = null;
        }

        /// <summary>
        /// Creates a new Key Vault context.
        /// </summary>
        public KeyVaultContext(TokenCredential credential, Uri keyId, X509Certificate2 publicCertificate)
        {
            if (credential is null)
            {
                throw new ArgumentNullException(nameof(credential));
            }

            Certificate = publicCertificate ?? throw new ArgumentNullException(nameof(publicCertificate));
            KeyIdentifier = keyId ?? throw new ArgumentNullException(nameof(keyId));

            _cryptographyClient = new CryptographyClient(keyId, credential);

            string algorithm = publicCertificate.GetKeyAlgorithm();

            switch (algorithm)
            {
                case "1.2.840.113549.1.1.1": //rsa
                    using (var rsa = publicCertificate.GetRSAPublicKey())
                    {
                        Key = new JsonWebKey(rsa, includePrivateParameters: false);
                    }
                    break;
                case "1.2.840.10045.2.1": //ec
                    using (var ecdsa = publicCertificate.GetECDsaPublicKey())
                    {
                        Key = new JsonWebKey(ecdsa, includePrivateParameters: false);
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
        /// Identifyer of current key
        /// </summary>
        public Uri KeyIdentifier { get; }

        /// <summary>
        /// Public key
        /// </summary>
        public JsonWebKey Key { get; }

        internal byte[] SignDigest(byte[] digest, HashAlgorithmName hashAlgorithm, KeyVaultSignatureAlgorithm signatureAlgorithm)
        {
            var algorithm = SignatureAlgorithmTranslator.SignatureAlgorithmToJwsAlgId(signatureAlgorithm, hashAlgorithm);

            if (hashAlgorithm == HashAlgorithmName.SHA1)
            {
                if (signatureAlgorithm != KeyVaultSignatureAlgorithm.RSAPkcs15)
                    throw new InvalidOperationException("SHA1 algorithm is not supported for this signature algorithm.");

                digest = Sha1Helper.CreateDigest(digest);
            }

            var sigResult = _cryptographyClient.Sign(algorithm, digest);

            return sigResult.Signature;
        }

        internal byte[] DecryptData(byte[] cipherText, RSAEncryptionPadding padding)
        {
            var algorithm = EncryptionPaddingTranslator.EncryptionPaddingToJwsAlgId(padding);

            var dataResult = _cryptographyClient.Decrypt(algorithm, cipherText);
            return dataResult.Plaintext;
        }

        /// <summary>
        /// Returns true if properly constructed. If default, then false.
        /// </summary>
        public bool IsValid => _cryptographyClient != null;
    }
}
