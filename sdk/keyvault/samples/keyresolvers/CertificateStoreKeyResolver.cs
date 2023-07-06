// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace KeyResolvers
{
    /// <summary>
    /// Attempts to resolve a key from a given <see cref="X509Store"/>.
    /// </summary>
    public sealed class CertificateStoreKeyResolver : IKeyEncryptionKeyResolver, IDisposable
    {
        private readonly X509Store _store;

        /// <summary>
        /// Creates a new instance of the <see cref="CertificateStoreKeyResolver"/> class.
        /// </summary>
        /// <param name="storeName">Name of the X509 certificate store.</param>
        /// <param name="storeLocation">Location of the X509 certificate store.</param>
        public CertificateStoreKeyResolver(StoreName storeName, StoreLocation storeLocation)
        {
            _store = new(storeName, storeLocation);
            _store.Open(OpenFlags.ReadOnly);
        }

        /// <inheritdoc/>
        public void Dispose() =>
            _store.Dispose();

        /// <inheritdoc/>
        /// <remarks>
        /// If an RSA certificate is found, this method will return an <see cref="IKeyEncryptionKey"/> that can wrap and unwrap keys.
        /// </remarks>
        public IKeyEncryptionKey Resolve(string keyId, CancellationToken cancellationToken = default)
        {
            string thumbprint = keyId ?? throw new ArgumentNullException(nameof(keyId));
            X509Certificate2? certificate = _store.Certificates
                .Find(X509FindType.FindByThumbprint, thumbprint, false)
                .Cast<X509Certificate2>()
                .FirstOrDefault();

            if (certificate is not null)
            {
                return new CertificateKey(certificate);
            }

            return null!;
        }

        /// <inheritdoc/>
        /// <remarks>
        /// If an RSA certificate is found, this method will return an <see cref="IKeyEncryptionKey"/> that can wrap and unwrap keys.
        /// </remarks>
        public Task<IKeyEncryptionKey> ResolveAsync(string keyId, CancellationToken cancellationToken = default) =>
            Task.FromResult(Resolve(keyId, cancellationToken));
    }
}
