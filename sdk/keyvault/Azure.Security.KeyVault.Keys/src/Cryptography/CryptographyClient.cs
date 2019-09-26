// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Cryptography;
using Azure.Core.Pipeline;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    /// <summary>
    /// A client used to perform cryptographic operations with Azure Key Vault keys
    /// </summary>
    public class CryptographyClient : IKeyEncryptionKey
    {
        private readonly Uri _keyId;
        private readonly KeyVaultPipeline _pipeline;
        private readonly RemoteCryptographyClient _remoteProvider;
        private ICryptographyProvider _provider;

        /// <summary>
        /// Initializes a new instance of the <see cref="CryptographyClient"/> class for mocking.
        /// </summary>
        protected CryptographyClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CryptographyClient"/> class.
        /// </summary>
        /// <param name="keyId">The <see cref="KeyProperties.Id"/> of the <see cref="Key"/> which will be used for cryptographic operations.</param>
        /// <param name="credential">A <see cref="TokenCredential"/> capable of providing an OAuth token.</param>
        /// <exception cref="ArgumentNullException"><paramref name="keyId"/> or <paramref name="credential"/> is null.</exception>
        public CryptographyClient(Uri keyId, TokenCredential credential)
            : this(keyId, credential, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CryptographyClient"/> class.
        /// </summary>
        /// <param name="keyId">The <see cref="KeyProperties.Id"/> of the <see cref="Key"/> which will be used for cryptographic operations.</param>
        /// <param name="credential">A <see cref="TokenCredential"/> capable of providing an OAuth token.</param>
        /// <param name="options">Options to configure the management of the request sent to Key Vault.</param>
        /// <exception cref="ArgumentNullException"><paramref name="keyId"/> or <paramref name="credential"/> is null.</exception>
        /// <exception cref="NotSupportedException">The <see cref="CryptographyClientOptions.Version"/> is not supported.</exception>
        public CryptographyClient(Uri keyId, TokenCredential credential, CryptographyClientOptions options) : this(keyId, credential, options, false)
        {
        }

        internal CryptographyClient(Uri keyId, TokenCredential credential, CryptographyClientOptions options, bool forceRemote)
        {
            Argument.AssertNotNull(keyId, nameof(keyId));
            Argument.AssertNotNull(credential, nameof(credential));

            _keyId = keyId;
            options ??= new CryptographyClientOptions();

            RemoteCryptographyClient remoteClient = new RemoteCryptographyClient(_keyId, credential, options);

            _pipeline = remoteClient.Pipeline;
            _remoteProvider = remoteClient;

            if (forceRemote)
            {
                _provider = remoteClient;
            }
        }

        internal CryptographyClient(JsonWebKey keyMaterial, TokenCredential credential, CryptographyClientOptions options)
        {
            Argument.AssertNotNull(keyMaterial, nameof(keyMaterial));
            Argument.AssertNotNull(credential, nameof(credential));

            if (string.IsNullOrEmpty(keyMaterial.KeyId))
            {
                throw new ArgumentException($"{nameof(keyMaterial.KeyId)} is required", nameof(keyMaterial));
            }

            _keyId = new Uri(keyMaterial.KeyId);
            options ??= new CryptographyClientOptions();

            RemoteCryptographyClient remoteClient = new RemoteCryptographyClient(_keyId, credential, options);

            _pipeline = remoteClient.Pipeline;
            _remoteProvider = remoteClient;
            _provider = LocalCryptographyProviderFactory.Create(keyMaterial);
        }

        internal ICryptographyProvider RemoteClient => _remoteProvider;

        /// <summary>
        /// The <see cref="Key.Id"/> of the key used to perform cryptographic operations for the client.
        /// </summary>
        public Uri KeyId => _keyId;

        /// <summary>
        /// Encrypts the specified plain text.
        /// </summary>
        /// <param name="algorithm">The <see cref="EncryptionAlgorithm"/> to use.</param>
        /// <param name="plaintext">The data to encrypt.</param>
        /// <param name="iv">
        /// The initialization vector. This should only be specified when using symmetric encryption algorithms;
        /// otherwise, the caller must omit the parameter or pass null.
        /// </param>
        /// <param name="authenticationData">
        /// The authentication data. This should only be specified when using authenticated symmetric encryption algorithms;
        /// otherwise, the caller must omit the parameter or pass null.
        /// </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to cancel the operation.</param>
        /// <returns>
        /// The result of the encrypt operation. The returned <see cref="EncryptResult"/> contains the encrypted data
        /// along with all other information needed to decrypt it. This information should be stored with the encrypted data.
        /// </returns>
        /// <exception cref="ArgumentException">The specified <paramref name="algorithm"/> does not match the key corresponding to the key identifier.</exception>
        /// <exception cref="NotSupportedException">The operation is not supported with the specified key.</exception>
        /// <exception cref="RequestFailedException">The server returned an error.</exception>
        public virtual async Task<EncryptResult> EncryptAsync(EncryptionAlgorithm algorithm, byte[] plaintext, byte[] iv = default, byte[] authenticationData = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient.Encrypt");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                if (_provider is null)
                {
                    await InitializeAsync(cancellationToken).ConfigureAwait(false);
                }

                EncryptResult result = null;
                if (_provider.SupportsOperation(KeyOperation.Encrypt))
                {
                    try
                    {
                        result = await _provider.EncryptAsync(algorithm, plaintext, iv, authenticationData, cancellationToken).ConfigureAwait(false);
                    }
                    catch (CryptographicException) when (_provider.ShouldRemote)
                    {
                        // TODO: Log that a cryptographic exception occured and we'll try remotely.
                    }
                }

                if (result is null)
                {
                    result = await _remoteProvider.EncryptAsync(algorithm, plaintext, iv, authenticationData, cancellationToken).ConfigureAwait(false);
                }

                return result;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Encrypts the specified plain text.
        /// </summary>
        /// <param name="algorithm">The <see cref="EncryptionAlgorithm"/> to use.</param>
        /// <param name="plaintext">The data to encrypt.</param>
        /// <param name="iv">
        /// The initialization vector. This should only be specified when using symmetric encryption algorithms;
        /// otherwise, the caller must omit the parameter or pass null.
        /// </param>
        /// <param name="authenticationData">
        /// The authentication data. This should only be specified when using authenticated symmetric encryption algorithms;
        /// otherwise, the caller must omit the parameter or pass null.
        /// </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to cancel the operation.</param>
        /// <returns>
        /// The result of the encrypt operation. The returned <see cref="EncryptResult"/> contains the encrypted data
        /// along with all other information needed to decrypt it. This information should be stored with the encrypted data.
        /// </returns>
        /// <exception cref="ArgumentException">The specified <paramref name="algorithm"/> does not match the key corresponding to the key identifier.</exception>
        /// <exception cref="NotSupportedException">The operation is not supported with the specified key.</exception>
        /// <exception cref="RequestFailedException">The server returned an error.</exception>
        public virtual EncryptResult Encrypt(EncryptionAlgorithm algorithm, byte[] plaintext, byte[] iv = default, byte[] authenticationData = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient.Encrypt");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                if (_provider is null)
                {
                    Initialize(cancellationToken);
                }

                EncryptResult result = null;
                if (_provider.SupportsOperation(KeyOperation.Encrypt))
                {
                    try
                    {
                        result = _provider.Encrypt(algorithm, plaintext, iv, authenticationData, cancellationToken);
                    }
                    catch (CryptographicException) when (_provider.ShouldRemote)
                    {
                        // TODO: Log that a cryptographic exception occured and we'll try remotely.
                    }
                }

                if (result is null)
                {
                    result = _remoteProvider.Encrypt(algorithm, plaintext, iv, authenticationData, cancellationToken);
                }

                return result;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Decrypts the specified cipher text.
        /// </summary>
        /// <param name="algorithm">The <see cref="EncryptionAlgorithm"/> to use.</param>
        /// <param name="ciphertext">The encrypted data to decrypt.</param>
        /// <param name="iv">
        /// The initialization vector. This should only be specified when using symmetric encryption algorithms;
        /// otherwise, the caller must omit the parameter or pass null.
        /// </param>
        /// <param name="authenticationData">
        /// The authentication data. This should only be specified when using authenticated symmetric encryption algorithms;
        /// otherwise, the caller must omit the parameter or pass null.
        /// </param>
        /// <param name="authenticationTag">The authentication tag. This should only be specified when using authenticated
        /// symmetric encryption algorithms; otherwise, the caller must omit the parameter or pass null.
        /// </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to cancel the operation.</param>
        /// <returns>
        /// The result of the decrypt operation. The returned <see cref="DecryptResult"/> contains the encrypted data
        /// along with information regarding the algorithm and key used to decrypt it.
        /// </returns>
        /// <exception cref="ArgumentException">The specified <paramref name="algorithm"/> does not match the key corresponding to the key identifier.</exception>
        /// <exception cref="NotSupportedException">The operation is not supported with the specified key.</exception>
        /// <exception cref="RequestFailedException">The server returned an error.</exception>
        public virtual async Task<DecryptResult> DecryptAsync(EncryptionAlgorithm algorithm, byte[] ciphertext, byte[] iv = default, byte[] authenticationData = default, byte[] authenticationTag = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient.Decrypt");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                if (_provider is null)
                {
                    await InitializeAsync(cancellationToken).ConfigureAwait(false);
                }

                DecryptResult result = null;
                if (_provider.SupportsOperation(KeyOperation.Decrypt))
                {
                    try
                    {
                        result = await _provider.DecryptAsync(algorithm, ciphertext, iv, authenticationData, authenticationTag, cancellationToken).ConfigureAwait(false);
                    }
                    catch (CryptographicException) when (_provider.ShouldRemote)
                    {
                        // TODO: Log that a cryptographic exception occured and we'll try remotely.
                    }
                }

                if (result is null)
                {
                    result = await _remoteProvider.DecryptAsync(algorithm, ciphertext, iv, authenticationData, authenticationTag, cancellationToken).ConfigureAwait(false);
                }

                return result;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Decrypts the specified cipher text.
        /// </summary>
        /// <param name="algorithm">The <see cref="EncryptionAlgorithm"/> to use.</param>
        /// <param name="ciphertext">The encrypted data to decrypt.</param>
        /// <param name="iv">
        /// The initialization vector. This should only be specified when using symmetric encryption algorithms;
        /// otherwise, the caller must omit the parameter or pass null.
        /// </param>
        /// <param name="authenticationData">
        /// The authentication data. This should only be specified when using authenticated symmetric encryption algorithms;
        /// otherwise, the caller must omit the parameter or pass null.
        /// </param>
        /// <param name="authenticationTag">The authentication tag. This should only be specified when using authenticated
        /// symmetric encryption algorithms; otherwise, the caller must omit the parameter or pass null.
        /// </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to cancel the operation.</param>
        /// <returns>
        /// The result of the decrypt operation. The returned <see cref="DecryptResult"/> contains the encrypted data
        /// along with information regarding the algorithm and key used to decrypt it.
        /// </returns>
        /// <exception cref="ArgumentException">The specified <paramref name="algorithm"/> does not match the key corresponding to the key identifier.</exception>
        /// <exception cref="NotSupportedException">The operation is not supported with the specified key.</exception>
        /// <exception cref="RequestFailedException">The server returned an error.</exception>
        public virtual DecryptResult Decrypt(EncryptionAlgorithm algorithm, byte[] ciphertext, byte[] iv = default, byte[] authenticationData = default, byte[] authenticationTag = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient.Decrypt");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                if (_provider is null)
                {
                    Initialize(cancellationToken);
                }

                DecryptResult result = null;
                if (_provider.SupportsOperation(KeyOperation.Decrypt))
                {
                    try
                    {
                        result = _provider.Decrypt(algorithm, ciphertext, iv, authenticationData, authenticationTag, cancellationToken);
                    }
                    catch (CryptographicException) when (_provider.ShouldRemote)
                    {
                        // TODO: Log that a cryptographic exception occured and we'll try remotely.
                    }
                }

                if (result is null)
                {
                    result = _remoteProvider.Decrypt(algorithm, ciphertext, iv, authenticationData, authenticationTag, cancellationToken);
                }

                return result;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Encrypts the specified key material.
        /// </summary>
        /// <param name="algorithm">The <see cref="KeyWrapAlgorithm"/> to use.</param>
        /// <param name="key">The key material to encrypt.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to cancel the operation.</param>
        /// <returns>
        /// The result of the wrap operation. The returned <see cref="WrapResult"/> contains the wrapped key
        /// along with all other information needed to unwrap it. This information should be stored with the wrapped key.
        /// </returns>
        /// <exception cref="ArgumentException">The specified <paramref name="algorithm"/> does not match the key corresponding to the key identifier.</exception>
        /// <exception cref="NotSupportedException">The operation is not supported with the specified key.</exception>
        /// <exception cref="RequestFailedException">The server returned an error.</exception>
        public virtual async Task<WrapResult> WrapKeyAsync(KeyWrapAlgorithm algorithm, byte[] key, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient.WrapKey");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                if (_provider is null)
                {
                    await InitializeAsync(cancellationToken).ConfigureAwait(false);
                }

                WrapResult result = null;
                if (_provider.SupportsOperation(KeyOperation.WrapKey))
                {
                    try
                    {
                        result = await _provider.WrapKeyAsync(algorithm, key, cancellationToken).ConfigureAwait(false);
                    }
                    catch (CryptographicException) when (_provider.ShouldRemote)
                    {
                        // TODO: Log that a cryptographic exception occured and we'll try remotely.
                    }
                }

                if (result is null)
                {
                    result = await _remoteProvider.WrapKeyAsync(algorithm, key, cancellationToken).ConfigureAwait(false);
                }

                return result;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Encrypts the specified key material.
        /// </summary>
        /// <param name="algorithm">The <see cref="KeyWrapAlgorithm"/> to use.</param>
        /// <param name="key">The key material to encrypt.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to cancel the operation.</param>
        /// <returns>
        /// The result of the wrap operation. The returned <see cref="WrapResult"/> contains the wrapped key
        /// along with all other information needed to unwrap it. This information should be stored with the wrapped key.
        /// </returns>
        /// <exception cref="ArgumentException">The specified <paramref name="algorithm"/> does not match the key corresponding to the key identifier.</exception>
        /// <exception cref="NotSupportedException">The operation is not supported with the specified key.</exception>
        /// <exception cref="RequestFailedException">The server returned an error.</exception>
        public virtual WrapResult WrapKey(KeyWrapAlgorithm algorithm, byte[] key, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient.WrapKey");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                if (_provider is null)
                {
                    Initialize(cancellationToken);
                }

                WrapResult result = null;
                if (_provider.SupportsOperation(KeyOperation.WrapKey))
                {
                    try
                    {
                        result = _provider.WrapKey(algorithm, key, cancellationToken);
                    }
                    catch (CryptographicException) when (_provider.ShouldRemote)
                    {
                        // TODO: Log that a cryptographic exception occured and we'll try remotely.
                    }
                }

                if (result is null)
                {
                    result = _remoteProvider.WrapKey(algorithm, key, cancellationToken);
                }

                return result;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Decrypts the specified encrypted key material.
        /// </summary>
        /// <param name="algorithm">The <see cref="KeyWrapAlgorithm"/> to use.</param>
        /// <param name="encryptedKey">The encrypted key material.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to cancel the operation.</param>
        /// <returns>
        /// The result of the unwrap operation. The returned <see cref="UnwrapResult"/> contains the key
        /// along with information regarding the algorithm and key used to unwrap it.
        /// </returns>
        /// <exception cref="ArgumentException">The specified <paramref name="algorithm"/> does not match the key corresponding to the key identifier.</exception>
        /// <exception cref="NotSupportedException">The operation is not supported with the specified key.</exception>
        /// <exception cref="RequestFailedException">The server returned an error.</exception>
        public virtual async Task<UnwrapResult> UnwrapKeyAsync(KeyWrapAlgorithm algorithm, byte[] encryptedKey, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient.UnwrapKey");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                if (_provider is null)
                {
                    await InitializeAsync(cancellationToken).ConfigureAwait(false);
                }

                UnwrapResult result = null;
                if (_provider.SupportsOperation(KeyOperation.UnwrapKey))
                {
                    try
                    {
                        result = await _provider.UnwrapKeyAsync(algorithm, encryptedKey, cancellationToken).ConfigureAwait(false);
                    }
                    catch (CryptographicException) when (_provider.ShouldRemote)
                    {
                        // TODO: Log that a cryptographic exception occured and we'll try remotely.
                    }
                }

                if (result is null)
                {
                    result = await _remoteProvider.UnwrapKeyAsync(algorithm, encryptedKey, cancellationToken).ConfigureAwait(false);
                }

                return result;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Decrypts the specified encrypted key material.
        /// </summary>
        /// <param name="algorithm">The <see cref="KeyWrapAlgorithm"/> to use.</param>
        /// <param name="encryptedKey">The encrypted key material.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to cancel the operation.</param>
        /// <returns>
        /// The result of the unwrap operation. The returned <see cref="UnwrapResult"/> contains the key
        /// along with information regarding the algorithm and key used to unwrap it.
        /// </returns>
        /// <exception cref="ArgumentException">The specified <paramref name="algorithm"/> does not match the key corresponding to the key identifier.</exception>
        /// <exception cref="NotSupportedException">The operation is not supported with the specified key.</exception>
        /// <exception cref="RequestFailedException">The server returned an error.</exception>
        public virtual UnwrapResult UnwrapKey(KeyWrapAlgorithm algorithm, byte[] encryptedKey, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient.UnwrapKey");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                if (_provider is null)
                {
                    Initialize(cancellationToken);
                }

                UnwrapResult result = null;
                if (_provider.SupportsOperation(KeyOperation.UnwrapKey))
                {
                    try
                    {
                        result = _provider.UnwrapKey(algorithm, encryptedKey, cancellationToken);
                    }
                    catch (CryptographicException) when (_provider.ShouldRemote)
                    {
                        // TODO: Log that a cryptographic exception occured and we'll try remotely.
                    }
                }

                if (result is null)
                {
                    result = _remoteProvider.UnwrapKey(algorithm, encryptedKey, cancellationToken);
                }

                return result;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Signs the specified digest.
        /// </summary>
        /// <param name="algorithm">The <see cref="SignatureAlgorithm"/> to use.</param>
        /// <param name="digest">The pre-hashed digest to sign. The hash algorithm used to compute the digest must be compatable with the specified algorithm.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to cancel the operation.</param>
        /// <returns>
        /// The result of the sign operation. The returned <see cref="SignResult"/> contains the signature
        /// along with all other information needed to verify it. This information should be stored with the signature.
        /// </returns>
        /// <exception cref="ArgumentException">The specified <paramref name="algorithm"/> does not match the key corresponding to the key identifier.</exception>
        /// <exception cref="NotSupportedException">The operation is not supported with the specified key.</exception>
        /// <exception cref="RequestFailedException">The server returned an error.</exception>
        public virtual async Task<SignResult> SignAsync(SignatureAlgorithm algorithm, byte[] digest, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient.Sign");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                if (_provider is null)
                {
                    await InitializeAsync(cancellationToken).ConfigureAwait(false);
                }

                SignResult result = null;
                if (_provider.SupportsOperation(KeyOperation.Sign))
                {
                    try
                    {
                        result = await _provider.SignAsync(algorithm, digest, cancellationToken).ConfigureAwait(false);
                    }
                    catch (CryptographicException) when (_provider.ShouldRemote)
                    {
                        // TODO: Log that a cryptographic exception occured and we'll try remotely.
                    }
                }

                if (result is null)
                {
                    result = await _remoteProvider.SignAsync(algorithm, digest, cancellationToken).ConfigureAwait(false);
                }

                return result;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Signs the specified digest.
        /// </summary>
        /// <param name="algorithm">The <see cref="SignatureAlgorithm"/> to use.</param>
        /// <param name="digest">The pre-hashed digest to sign. The hash algorithm used to compute the digest must be compatable with the specified algorithm.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to cancel the operation.</param>
        /// <returns>
        /// The result of the sign operation. The returned <see cref="SignResult"/> contains the signature
        /// along with all other information needed to verify it. This information should be stored with the signature.
        /// </returns>
        /// <exception cref="ArgumentException">The specified <paramref name="algorithm"/> does not match the key corresponding to the key identifier.</exception>
        /// <exception cref="NotSupportedException">The operation is not supported with the specified key.</exception>
        /// <exception cref="RequestFailedException">The server returned an error.</exception>
        public virtual SignResult Sign(SignatureAlgorithm algorithm, byte[] digest, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient.Sign");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                if (_provider is null)
                {
                    Initialize(cancellationToken);
                }

                SignResult result = null;
                if (_provider.SupportsOperation(KeyOperation.Sign))
                {
                    try
                    {
                        result = _provider.Sign(algorithm, digest, cancellationToken);
                    }
                    catch (CryptographicException) when (_provider.ShouldRemote)
                    {
                        // TODO: Log that a cryptographic exception occured and we'll try remotely.
                    }
                }

                if (result is null)
                {
                    result = _remoteProvider.Sign(algorithm, digest, cancellationToken);
                }

                return result;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Verifies the specified signature.
        /// </summary>
        /// <param name="algorithm">The <see cref="SignatureAlgorithm"/> to use. This must be the same algorithm used to sign the digest.</param>
        /// <param name="digest">The pre-hashed digest corresponding to the signature. The hash algorithm used to compute the digest must be compatable with the specified algorithm.</param>
        /// <param name="signature">The signature to verify.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to cancel the operation.</param>
        /// <returns>
        /// The result of the verify operation. If the signature is valid the <see cref="VerifyResult.IsValid"/> property of the returned <see cref="VerifyResult"/> will be set to true.
        /// </returns>
        /// <exception cref="ArgumentException">The specified <paramref name="algorithm"/> does not match the key corresponding to the key identifier.</exception>
        /// <exception cref="NotSupportedException">The operation is not supported with the specified key.</exception>
        /// <exception cref="RequestFailedException">The server returned an error.</exception>
        public virtual async Task<VerifyResult> VerifyAsync(SignatureAlgorithm algorithm, byte[] digest, byte[] signature, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient.Verify");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                if (_provider is null)
                {
                    await InitializeAsync(cancellationToken).ConfigureAwait(false);
                }

                VerifyResult result = null;
                if (_provider.SupportsOperation(KeyOperation.Verify))
                {
                    try
                    {
                        result = await _provider.VerifyAsync(algorithm, digest, signature, cancellationToken).ConfigureAwait(false);
                    }
                    catch (CryptographicException) when (_provider.ShouldRemote)
                    {
                        // TODO: Log that a cryptographic exception occured and we'll try remotely.
                    }
                }

                if (result is null)
                {
                    result = await _remoteProvider.VerifyAsync(algorithm, digest, signature, cancellationToken).ConfigureAwait(false);
                }

                return result;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Verifies the specified signature.
        /// </summary>
        /// <param name="algorithm">The <see cref="SignatureAlgorithm"/> to use. This must be the same algorithm used to sign the digest.</param>
        /// <param name="digest">The pre-hashed digest corresponding to the signature. The hash algorithm used to compute the digest must be compatable with the specified algorithm.</param>
        /// <param name="signature">The signature to verify.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to cancel the operation.</param>
        /// <returns>
        /// The result of the verify operation. If the signature is valid the <see cref="VerifyResult.IsValid"/> property of the returned <see cref="VerifyResult"/> will be set to true.
        /// </returns>
        /// <exception cref="ArgumentException">The specified <paramref name="algorithm"/> does not match the key corresponding to the key identifier.</exception>
        /// <exception cref="NotSupportedException">The operation is not supported with the specified key.</exception>
        /// <exception cref="RequestFailedException">The server returned an error.</exception>
        public virtual VerifyResult Verify(SignatureAlgorithm algorithm, byte[] digest, byte[] signature, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient.Verify");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                if (_provider is null)
                {
                    Initialize(cancellationToken);
                }

                VerifyResult result = null;
                if (_provider.SupportsOperation(KeyOperation.Verify))
                {
                    try
                    {
                        result = _provider.Verify(algorithm, digest, signature, cancellationToken);
                    }
                    catch (CryptographicException) when (_provider.ShouldRemote)
                    {
                        // TODO: Log that a cryptographic exception occured and we'll try remotely.
                    }
                }

                if (result is null)
                {
                    result = _remoteProvider.Verify(algorithm, digest, signature, cancellationToken);
                }

                return result;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Signs the specified data.
        /// </summary>
        /// <param name="algorithm">The <see cref="SignatureAlgorithm"/> to use.</param>
        /// <param name="data">The data to sign.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to cancel the operation.</param>
        /// <returns>
        /// The result of the sign operation. The returned <see cref="SignResult"/> contains the signature
        /// along with all other information needed to verify it. This information should be stored with the signature.
        /// </returns>
        /// <exception cref="ArgumentException">The specified <paramref name="algorithm"/> does not match the key corresponding to the key identifier.</exception>
        /// <exception cref="NotSupportedException">The operation is not supported with the specified key.</exception>
        /// <exception cref="RequestFailedException">The server returned an error.</exception>
        public virtual async Task<SignResult> SignDataAsync(SignatureAlgorithm algorithm, byte[] data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient.SignData");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                byte[] digest = CreateDigest(algorithm, data);

                if (_provider is null)
                {
                    await InitializeAsync(cancellationToken).ConfigureAwait(false);
                }

                SignResult result = null;
                if (_provider.SupportsOperation(KeyOperation.Sign))
                {
                    try
                    {
                        result = await _provider.SignAsync(algorithm, digest, cancellationToken).ConfigureAwait(false);
                    }
                    catch (CryptographicException) when (_provider.ShouldRemote)
                    {
                        // TODO: Log that a cryptographic exception occured and we'll try remotely.
                    }
                }

                if (result is null)
                {
                    result = await _remoteProvider.SignAsync(algorithm, digest, cancellationToken).ConfigureAwait(false);
                }

                return result;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Signs the specified data.
        /// </summary>
        /// <param name="algorithm">The <see cref="SignatureAlgorithm"/> to use.</param>
        /// <param name="data">The data to sign.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to cancel the operation.</param>
        /// <returns>
        /// The result of the sign operation. The returned <see cref="SignResult"/> contains the signature
        /// along with all other information needed to verify it. This information should be stored with the signature.
        /// </returns>
        /// <exception cref="ArgumentException">The specified <paramref name="algorithm"/> does not match the key corresponding to the key identifier.</exception>
        /// <exception cref="NotSupportedException">The operation is not supported with the specified key.</exception>
        /// <exception cref="RequestFailedException">The server returned an error.</exception>
        public virtual SignResult SignData(SignatureAlgorithm algorithm, byte[] data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient.SignData");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                byte[] digest = CreateDigest(algorithm, data);

                if (_provider is null)
                {
                    Initialize(cancellationToken);
                }

                SignResult result = null;
                if (_provider.SupportsOperation(KeyOperation.Sign))
                {
                    try
                    {
                        result = _provider.Sign(algorithm, digest, cancellationToken);
                    }
                    catch (CryptographicException) when (_provider.ShouldRemote)
                    {
                        // TODO: Log that a cryptographic exception occured and we'll try remotely.
                    }
                }

                if (result is null)
                {
                    result = _remoteProvider.Sign(algorithm, digest, cancellationToken);
                }

                return result;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Signs the specified data.
        /// </summary>
        /// <param name="algorithm">The <see cref="SignatureAlgorithm"/> to use.</param>
        /// <param name="data">The data to sign.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to cancel the operation.</param>
        /// <returns>
        /// The result of the sign operation. The returned <see cref="SignResult"/> contains the signature
        /// along with all other information needed to verify it. This information should be stored with the signature.
        /// </returns>
        /// <exception cref="ArgumentException">The specified <paramref name="algorithm"/> does not match the key corresponding to the key identifier.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="data"/> is null.</exception>
        /// <exception cref="NotSupportedException">The operation is not supported with the specified key.</exception>
        /// <exception cref="RequestFailedException">The server returned an error.</exception>
        public virtual async Task<SignResult> SignDataAsync(SignatureAlgorithm algorithm, Stream data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient.SignData");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                byte[] digest = CreateDigest(algorithm, data);

                if (_provider is null)
                {
                    await InitializeAsync(cancellationToken).ConfigureAwait(false);
                }

                SignResult result = null;
                if (_provider.SupportsOperation(KeyOperation.Sign))
                {
                    try
                    {
                        result = await _provider.SignAsync(algorithm, digest, cancellationToken).ConfigureAwait(false);
                    }
                    catch (CryptographicException) when (_provider.ShouldRemote)
                    {
                        // TODO: Log that a cryptographic exception occured and we'll try remotely.
                    }
                }

                if (result is null)
                {
                    result = await _remoteProvider.SignAsync(algorithm, digest, cancellationToken).ConfigureAwait(false);
                }

                return result;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Signs the specified data.
        /// </summary>
        /// <param name="algorithm">The <see cref="SignatureAlgorithm"/> to use.</param>
        /// <param name="data">The data to sign.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to cancel the operation.</param>
        /// <returns>
        /// The result of the sign operation. The returned <see cref="SignResult"/> contains the signature
        /// along with all other information needed to verify it. This information should be stored with the signature.
        /// </returns>
        /// <exception cref="ArgumentException">The specified <paramref name="algorithm"/> does not match the key corresponding to the key identifier.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="data"/> is null.</exception>
        /// <exception cref="NotSupportedException">The operation is not supported with the specified key.</exception>
        /// <exception cref="RequestFailedException">The server returned an error.</exception>
        public virtual SignResult SignData(SignatureAlgorithm algorithm, Stream data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient.SignData");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                byte[] digest = CreateDigest(algorithm, data);

                if (_provider is null)
                {
                    Initialize(cancellationToken);
                }

                SignResult result = null;
                if (_provider.SupportsOperation(KeyOperation.Sign))
                {
                    try
                    {
                        result = _provider.Sign(algorithm, digest, cancellationToken);
                    }
                    catch (CryptographicException) when (_provider.ShouldRemote)
                    {
                        // TODO: Log that a cryptographic exception occured and we'll try remotely.
                    }
                }

                if (result is null)
                {
                    result = _remoteProvider.Sign(algorithm, digest, cancellationToken);
                }

                return result;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Verifies the specified signature.
        /// </summary>
        /// <param name="algorithm">The <see cref="SignatureAlgorithm"/> to use. This must be the same algorithm used to sign the data.</param>
        /// <param name="data">The data corresponding to the signature.</param>
        /// <param name="signature">The signature to verify.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to cancel the operation.</param>
        /// <returns>
        /// The result of the verify operation. If the signature is valid the <see cref="VerifyResult.IsValid"/> property of the returned <see cref="VerifyResult"/> will be set to true.
        /// </returns>
        /// <exception cref="ArgumentException">The specified <paramref name="algorithm"/> does not match the key corresponding to the key identifier.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="data"/> is null.</exception>
        /// <exception cref="NotSupportedException">The operation is not supported with the specified key.</exception>
        /// <exception cref="RequestFailedException">The server returned an error.</exception>
        public virtual async Task<VerifyResult> VerifyDataAsync(SignatureAlgorithm algorithm, byte[] data, byte[] signature, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient.VerifyData");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                byte[] digest = CreateDigest(algorithm, data);

                if (_provider is null)
                {
                    await InitializeAsync(cancellationToken).ConfigureAwait(false);
                }

                VerifyResult result = null;
                if (_provider.SupportsOperation(KeyOperation.Verify))
                {
                    try
                    {
                        result = await _provider.VerifyAsync(algorithm, digest, signature, cancellationToken).ConfigureAwait(false);
                    }
                    catch (CryptographicException) when (_provider.ShouldRemote)
                    {
                        // TODO: Log that a cryptographic exception occured and we'll try remotely.
                    }
                }

                if (result is null)
                {
                    result = await _remoteProvider.VerifyAsync(algorithm, digest, signature, cancellationToken).ConfigureAwait(false);
                }

                return result;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Verifies the specified signature.
        /// </summary>
        /// <param name="algorithm">The <see cref="SignatureAlgorithm"/> to use. This must be the same algorithm used to sign the data.</param>
        /// <param name="data">The data corresponding to the signature.</param>
        /// <param name="signature">The signature to verify.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to cancel the operation.</param>
        /// <returns>
        /// The result of the verify operation. If the signature is valid the <see cref="VerifyResult.IsValid"/> property of the returned <see cref="VerifyResult"/> will be set to true.
        /// </returns>
        /// <exception cref="ArgumentException">The specified <paramref name="algorithm"/> does not match the key corresponding to the key identifier.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="data"/> is null.</exception>
        /// <exception cref="NotSupportedException">The operation is not supported with the specified key.</exception>
        /// <exception cref="RequestFailedException">The server returned an error.</exception>
        public virtual VerifyResult VerifyData(SignatureAlgorithm algorithm, byte[] data, byte[] signature, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient.VerifyData");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                byte[] digest = CreateDigest(algorithm, data);

                if (_provider is null)
                {
                    Initialize(cancellationToken);
                }

                VerifyResult result = null;
                if (_provider.SupportsOperation(KeyOperation.Verify))
                {
                    try
                    {
                        result = _provider.Verify(algorithm, digest, signature, cancellationToken);
                    }
                    catch (CryptographicException) when (_provider.ShouldRemote)
                    {
                        // TODO: Log that a cryptographic exception occured and we'll try remotely.
                    }
                }

                if (result is null)
                {
                    result = _remoteProvider.Verify(algorithm, digest, signature, cancellationToken);
                }

                return result;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Verifies the specified signature.
        /// </summary>
        /// <param name="algorithm">The <see cref="SignatureAlgorithm"/> to use. This must be the same algorithm used to sign the data.</param>
        /// <param name="data">The data corresponding to the signature.</param>
        /// <param name="signature">The signature to verify.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to cancel the operation.</param>
        /// <returns>
        /// The result of the verify operation. If the signature is valid the <see cref="VerifyResult.IsValid"/> property of the returned <see cref="VerifyResult"/> will be set to true.
        /// </returns>
        /// <exception cref="ArgumentException">The specified <paramref name="algorithm"/> does not match the key corresponding to the key identifier.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="data"/> is null.</exception>
        /// <exception cref="NotSupportedException">The operation is not supported with the specified key.</exception>
        /// <exception cref="RequestFailedException">The server returned an error.</exception>
        public virtual async Task<VerifyResult> VerifyDataAsync(SignatureAlgorithm algorithm, Stream data, byte[] signature, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient.VerifyData");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                byte[] digest = CreateDigest(algorithm, data);

                if (_provider is null)
                {
                    await InitializeAsync(cancellationToken).ConfigureAwait(false);
                }

                VerifyResult result = null;
                if (_provider.SupportsOperation(KeyOperation.Verify))
                {
                    try
                    {
                        result = await _provider.VerifyAsync(algorithm, digest, signature, cancellationToken).ConfigureAwait(false);
                    }
                    catch (CryptographicException) when (_provider.ShouldRemote)
                    {
                        // TODO: Log that a cryptographic exception occured and we'll try remotely.
                    }
                }

                if (result is null)
                {
                    result = await _remoteProvider.VerifyAsync(algorithm, digest, signature, cancellationToken).ConfigureAwait(false);
                }

                return result;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Verifies the specified signature.
        /// </summary>
        /// <param name="algorithm">The <see cref="SignatureAlgorithm"/> to use. This must be the same algorithm used to sign the data.</param>
        /// <param name="data">The data corresponding to the signature.</param>
        /// <param name="signature">The signature to verify.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to cancel the operation.</param>
        /// <returns>
        /// The result of the verify operation. If the signature is valid the <see cref="VerifyResult.IsValid"/> property of the returned <see cref="VerifyResult"/> will be set to true.
        /// </returns>
        /// <exception cref="ArgumentException">The specified <paramref name="algorithm"/> does not match the key corresponding to the key identifier.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="data"/> is null.</exception>
        /// <exception cref="NotSupportedException">The operation is not supported with the specified key.</exception>
        /// <exception cref="RequestFailedException">The server returned an error.</exception>
        public virtual VerifyResult VerifyData(SignatureAlgorithm algorithm, Stream data, byte[] signature, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient.VerifyData");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                byte[] digest = CreateDigest(algorithm, data);

                if (_provider is null)
                {
                    Initialize(cancellationToken);
                }

                VerifyResult result = null;
                if (_provider.SupportsOperation(KeyOperation.Verify))
                {
                    try
                    {
                        result = _provider.Verify(algorithm, digest, signature, cancellationToken);
                    }
                    catch (CryptographicException) when (_provider.ShouldRemote)
                    {
                        // TODO: Log that a cryptographic exception occured and we'll try remotely.
                    }
                }

                if (result is null)
                {
                    result = _remoteProvider.Verify(algorithm, digest, signature, cancellationToken);
                }

                return result;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc/>
        Memory<byte> IKeyEncryptionKey.WrapKey(string algorithm, ReadOnlyMemory<byte> key, CancellationToken cancellationToken)
        {
            WrapResult result = WrapKey(new KeyWrapAlgorithm(algorithm), key.ToArray(), cancellationToken);

            return result.EncryptedKey;
        }

        /// <inheritdoc/>
        async Task<Memory<byte>> IKeyEncryptionKey.WrapKeyAsync(string algorithm, ReadOnlyMemory<byte> key, CancellationToken cancellationToken)
        {
            WrapResult result = await WrapKeyAsync(new KeyWrapAlgorithm(algorithm), key.ToArray(), cancellationToken).ConfigureAwait(false);

            return result.EncryptedKey;
        }

        /// <inheritdoc/>
        Memory<byte> IKeyEncryptionKey.UnwrapKey(string algorithm, ReadOnlyMemory<byte> encryptedKey, CancellationToken cancellationToken)
        {
            byte[] buffer = MemoryMarshal.TryGetArray(encryptedKey, out ArraySegment<byte> segment) ? segment.Array : encryptedKey.ToArray();
            UnwrapResult result = UnwrapKey(new KeyWrapAlgorithm(algorithm), buffer, cancellationToken);

            return new Memory<byte>(result.Key);
        }

        /// <inheritdoc/>
        async Task<Memory<byte>> IKeyEncryptionKey.UnwrapKeyAsync(string algorithm, ReadOnlyMemory<byte> encryptedKey, CancellationToken cancellationToken)
        {
            byte[] buffer = MemoryMarshal.TryGetArray(encryptedKey, out ArraySegment<byte> segment) ? segment.Array : encryptedKey.ToArray();
            UnwrapResult result = await UnwrapKeyAsync(new KeyWrapAlgorithm(algorithm), buffer, cancellationToken).ConfigureAwait(false);

            return new Memory<byte>(result.Key);
        }

        private static byte[] CreateDigest(SignatureAlgorithm algorithm, byte[] data)
        {
            using HashAlgorithm hashAlgo = algorithm.GetHashAlgorithm();
            return hashAlgo.ComputeHash(data);
        }

        private static byte[] CreateDigest(SignatureAlgorithm algorithm, Stream data)
        {
            using HashAlgorithm hashAlgo = algorithm.GetHashAlgorithm();
            return hashAlgo.ComputeHash(data);
        }

        private async Task InitializeAsync(CancellationToken cancellationToken)
        {
            if (_provider != null)
            {
                return;
            }

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient.Initialize");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                Response<Key> key = await _remoteProvider.GetKeyAsync(cancellationToken).ConfigureAwait(false);
                _provider = LocalCryptographyProviderFactory.Create(key.Value.KeyMaterial);
            }
            catch (RequestFailedException e) when (e.Status == 403)
            {
                scope.AddAttribute("status", e.Status);

                _provider = _remoteProvider;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private void Initialize(CancellationToken cancellationToken)
        {
            if (_provider != null)
            {
                return;
            }

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient.Initialize");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                Response<Key> key = _remoteProvider.GetKey(cancellationToken);
                _provider = LocalCryptographyProviderFactory.Create(key.Value.KeyMaterial);
            }
            catch (RequestFailedException e) when (e.Status == 403)
            {
                scope.AddAttribute("status", e.Status);

                _provider = _remoteProvider;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
