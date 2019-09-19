// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Security.KeyVault.Keys.Cryptography;

namespace Azure.Security.KeyVault.Keys.Tests
{
    // Proxy calls with Castle-accessible class to internal RemoteCryptographyProvider. Class name cannot end with "Proxy".
    public class RemoteCryptographyClientBroker : ICryptographyProvider
    {
        private readonly ICryptographyProvider _remoteClient;

        internal RemoteCryptographyClientBroker(ICryptographyProvider remoteClient)
        {
            _remoteClient = remoteClient ?? throw new ArgumentNullException(nameof(remoteClient));
        }

        protected RemoteCryptographyClientBroker()
        {
        }

        [ForwardsClientCalls]
        public virtual bool SupportsOperation(KeyOperation operation)
        {
            return _remoteClient.SupportsOperation(operation);
        }

        [ForwardsClientCalls]
        public virtual Task<EncryptResult> EncryptAsync(EncryptionAlgorithm algorithm, byte[] plaintext, byte[] iv = null, byte[] authenticationData = null, CancellationToken cancellationToken = default)
        {
            return _remoteClient.EncryptAsync(algorithm, plaintext, iv, authenticationData, cancellationToken);
        }

        [ForwardsClientCalls]
        public virtual EncryptResult Encrypt(EncryptionAlgorithm algorithm, byte[] plaintext, byte[] iv = null, byte[] authenticationData = null, CancellationToken cancellationToken = default)
        {
            return _remoteClient.Encrypt(algorithm, plaintext, iv, authenticationData, cancellationToken);
        }

        [ForwardsClientCalls]
        public virtual Task<DecryptResult> DecryptAsync(EncryptionAlgorithm algorithm, byte[] ciphertext, byte[] iv = null, byte[] authenticationData = null, byte[] authenticationTag = null, CancellationToken cancellationToken = default)
        {
            return _remoteClient.DecryptAsync(algorithm, ciphertext, iv, authenticationData, authenticationTag, cancellationToken);
        }

        [ForwardsClientCalls]
        public virtual DecryptResult Decrypt(EncryptionAlgorithm algorithm, byte[] ciphertext, byte[] iv = null, byte[] authenticationData = null, byte[] authenticationTag = null, CancellationToken cancellationToken = default)
        {
            return _remoteClient.Decrypt(algorithm, ciphertext, iv, authenticationData, authenticationTag, cancellationToken);
        }

        [ForwardsClientCalls]
        public virtual Task<WrapResult> WrapKeyAsync(KeyWrapAlgorithm algorithm, byte[] key, CancellationToken cancellationToken = default)
        {
            return _remoteClient.WrapKeyAsync(algorithm, key, cancellationToken);
        }

        [ForwardsClientCalls]
        public virtual WrapResult WrapKey(KeyWrapAlgorithm algorithm, byte[] key, CancellationToken cancellationToken = default)
        {
            return _remoteClient.WrapKey(algorithm, key, cancellationToken);
        }

        [ForwardsClientCalls]
        public virtual Task<UnwrapResult> UnwrapKeyAsync(KeyWrapAlgorithm algorithm, byte[] encryptedKey, CancellationToken cancellationToken = default)
        {
            return _remoteClient.UnwrapKeyAsync(algorithm, encryptedKey, cancellationToken);
        }

        [ForwardsClientCalls]
        public virtual UnwrapResult UnwrapKey(KeyWrapAlgorithm algorithm, byte[] encryptedKey, CancellationToken cancellationToken = default)
        {
            return _remoteClient.UnwrapKey(algorithm, encryptedKey, cancellationToken);
        }

        [ForwardsClientCalls]
        public virtual Task<SignResult> SignAsync(SignatureAlgorithm algorithm, byte[] digest, CancellationToken cancellationToken = default)
        {
            return _remoteClient.SignAsync(algorithm, digest, cancellationToken);
        }

        [ForwardsClientCalls]
        public virtual SignResult Sign(SignatureAlgorithm algorithm, byte[] digest, CancellationToken cancellationToken = default)
        {
            return _remoteClient.Sign(algorithm, digest, cancellationToken);
        }

        [ForwardsClientCalls]
        public virtual Task<VerifyResult> VerifyAsync(SignatureAlgorithm algorithm, byte[] digest, byte[] signature, CancellationToken cancellationToken = default)
        {
            return _remoteClient.VerifyAsync(algorithm, digest, signature, cancellationToken);
        }

        [ForwardsClientCalls]
        public virtual VerifyResult Verify(SignatureAlgorithm algorithm, byte[] digest, byte[] signature, CancellationToken cancellationToken = default)
        {
            return _remoteClient.Verify(algorithm, digest, signature, cancellationToken);
        }
    }
}
