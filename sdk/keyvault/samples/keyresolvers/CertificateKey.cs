// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Cryptography;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace KeyResolvers
{
    internal class CertificateKey : IKeyEncryptionKey, IDisposable
    {
        private const string DefaultKeyWrapAlgorithm = "RSA-OAEP";
        private readonly X509Certificate2 _certificate;

        internal CertificateKey(X509Certificate2 certificate)
        {
            _certificate = certificate ?? throw new ArgumentNullException(nameof(certificate));
            if (_certificate.GetRSAPublicKey() is null)
            {
                throw new InvalidOperationException("Only certificates using RSA keys are supported for key wrap and unwrap");
            }
        }

        /// <inheritdoc/>
        public string KeyId => _certificate.Thumbprint;

        /// <inheritdoc/>
        public void Dispose() =>
            _certificate.Dispose();

        /// <inheritdoc/>
        public byte[] UnwrapKey(string algorithm, ReadOnlyMemory<byte> encryptedKey, CancellationToken cancellationToken = default)
        {
            if (!_certificate.HasPrivateKey)
            {
                throw new NotSupportedException("Certificate does not have private key");
            }

            // Retain previous behavior with internal sample.
            if (encryptedKey.Length == 0)
            {
                throw new ArgumentNullException(nameof(encryptedKey));
            }

            if (string.IsNullOrEmpty(algorithm))
            {
                algorithm = DefaultKeyWrapAlgorithm;
            }

            using RSA? rsa = _certificate.GetRSAPrivateKey() ?? throw new NotSupportedException("Certificate does not have private key");
            return rsa.Decrypt(encryptedKey.ToArray(), GetPaddingAlgorithm(algorithm));
        }

        /// <inheritdoc/>
        public Task<byte[]> UnwrapKeyAsync(string algorithm, ReadOnlyMemory<byte> encryptedKey, CancellationToken cancellationToken = default) =>
            Task.FromResult(UnwrapKey(algorithm, encryptedKey, cancellationToken));

        /// <inheritdoc/>
        public byte[] WrapKey(string algorithm, ReadOnlyMemory<byte> key, CancellationToken cancellationToken = default)
        {
            // Retain previous behavior with internal sample.
            if (key.Length == 0)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (string.IsNullOrEmpty(algorithm))
            {
                algorithm = DefaultKeyWrapAlgorithm;
            }

            using RSA rsa = _certificate.GetRSAPublicKey()!;
            return rsa.Encrypt(key.ToArray(), GetPaddingAlgorithm(algorithm));
        }

        /// <inheritdoc/>
        public Task<byte[]> WrapKeyAsync(string algorithm, ReadOnlyMemory<byte> key, CancellationToken cancellationToken = default) =>
            Task.FromResult(WrapKey(algorithm, key, cancellationToken));

        private static RSAEncryptionPadding GetPaddingAlgorithm(string algorithm) => algorithm switch
        {
            // Retain previous behavior with "RSA_15" from internal sample.
            "RSA1_5" or "RSA_15" => RSAEncryptionPadding.Pkcs1,
            "RSA-OAEP" => RSAEncryptionPadding.OaepSHA1,
            "RSA-OAEP-256" => RSAEncryptionPadding.OaepSHA256,
            _ => throw new NotSupportedException($"{algorithm} is not supported"),
        };
    }
}
