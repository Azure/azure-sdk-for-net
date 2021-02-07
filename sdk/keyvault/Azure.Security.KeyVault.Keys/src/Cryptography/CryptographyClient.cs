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
    /// A client used to perform cryptographic operations with Azure Key Vault keys.
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
        /// <param name="keyId">
        /// The key identifier of the <see cref="KeyVaultKey"/> which will be used for cryptographic operations.
        /// If you have a key <see cref="Uri"/>, use <see cref="KeyVaultKeyIdentifier"/> to parse the <see cref="KeyVaultKeyIdentifier.VaultUri"/> and other information.
        /// </param>
        /// <param name="credential">A <see cref="TokenCredential"/> used to authenticate requests to the vault, like DefaultAzureCredential.</param>
        /// <exception cref="ArgumentNullException"><paramref name="keyId"/> or <paramref name="credential"/> is null.</exception>
        public CryptographyClient(Uri keyId, TokenCredential credential)
            : this(keyId, credential, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CryptographyClient"/> class.
        /// </summary>
        /// <param name="keyId">
        /// The key identifier of the <see cref="KeyVaultKey"/> which will be used for cryptographic operations.
        /// If you have a key <see cref="Uri"/>, use <see cref="KeyVaultKeyIdentifier"/> to parse the <see cref="KeyVaultKeyIdentifier.VaultUri"/> and other information.
        /// </param>
        /// <param name="credential">A <see cref="TokenCredential"/> used to authenticate requests to the vault, like DefaultAzureCredential.</param>
        /// <param name="options"><see cref="CryptographyClientOptions"/> that allow to configure the management of the request sent to Key Vault.</param>
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

        internal CryptographyClient(KeyVaultKey key, TokenCredential credential, CryptographyClientOptions options, ICryptographyProvider provider = null)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(credential, nameof(credential));

            JsonWebKey keyMaterial = key.Key;
            if (string.IsNullOrEmpty(keyMaterial?.Id))
            {
                throw new ArgumentException($"{nameof(key.Id)} is required", nameof(key));
            }

            _keyId = new Uri(keyMaterial.Id);
            options ??= new CryptographyClientOptions();

            RemoteCryptographyClient remoteClient = new RemoteCryptographyClient(_keyId, credential, options);

            _pipeline = remoteClient.Pipeline;
            _remoteProvider = remoteClient;
            _provider = provider ?? LocalCryptographyProviderFactory.Create(key);
        }

        internal CryptographyClient(KeyVaultKey key, KeyVaultPipeline pipeline)
        {
            Argument.AssertNotNull(key, nameof(key));

            JsonWebKey keyMaterial = key.Key;
            if (string.IsNullOrEmpty(keyMaterial?.Id))
            {
                throw new ArgumentException($"{nameof(key.Id)} is required", nameof(key));
            }

            _keyId = new Uri(keyMaterial.Id);

            RemoteCryptographyClient remoteClient = new RemoteCryptographyClient(pipeline);

            _pipeline = pipeline;
            _remoteProvider = remoteClient;
            _provider = LocalCryptographyProviderFactory.Create(key);
        }

        internal CryptographyClient(Uri keyId, KeyVaultPipeline pipeline)
        {
            Argument.AssertNotNull(keyId, nameof(keyId));

            _keyId = keyId;

            RemoteCryptographyClient remoteClient = new RemoteCryptographyClient(pipeline);

            _pipeline = pipeline;
            _remoteProvider = remoteClient;
            _provider = remoteClient;
        }

        internal ICryptographyProvider RemoteClient => _remoteProvider;

        /// <summary>
        /// Gets the <see cref="KeyVaultKey.Id"/> of the key used to perform cryptographic operations for the client.
        /// </summary>
        public virtual string KeyId => _keyId.ToString();

        /// <summary>
        /// Encrypts the specified plaintext.
        /// </summary>
        /// <param name="algorithm">The <see cref="EncryptionAlgorithm"/> to use.</param>
        /// <param name="plaintext">The data to encrypt.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to cancel the operation.</param>
        /// <returns>
        /// An <see cref="EncryptResult"/> containing the encrypted data
        /// along with all other information needed to decrypt it. This information should be stored with the encrypted data.
        /// </returns>
        /// <exception cref="ArgumentException">The specified <paramref name="algorithm"/> does not match the key corresponding to the key identifier.</exception>
        /// <exception cref="CryptographicException">The local cryptographic provider threw an exception.</exception>
        /// <exception cref="InvalidOperationException">The key is invalid for the current operation.</exception>
        /// <exception cref="NotSupportedException">The operation is not supported with the specified key.</exception>
        public virtual async Task<EncryptResult> EncryptAsync(EncryptionAlgorithm algorithm, byte[] plaintext, CancellationToken cancellationToken = default) =>
            await EncryptAsync(new EncryptOptions(algorithm, plaintext), cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Encrypts the specified plaintext.
        /// </summary>
        /// <param name="algorithm">The <see cref="EncryptionAlgorithm"/> to use.</param>
        /// <param name="plaintext">The data to encrypt.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to cancel the operation.</param>
        /// <returns>
        /// An <see cref="EncryptResult"/> containing the encrypted data
        /// along with all other information needed to decrypt it. This information should be stored with the encrypted data.
        /// </returns>
        /// <exception cref="ArgumentException">The specified <paramref name="algorithm"/> does not match the key corresponding to the key identifier.</exception>
        /// <exception cref="CryptographicException">The local cryptographic provider threw an exception.</exception>
        /// <exception cref="InvalidOperationException">The key is invalid for the current operation.</exception>
        /// <exception cref="NotSupportedException">The operation is not supported with the specified key.</exception>
        public virtual EncryptResult Encrypt(EncryptionAlgorithm algorithm, byte[] plaintext, CancellationToken cancellationToken = default) =>
            Encrypt(new EncryptOptions(algorithm, plaintext), cancellationToken);

        /// <summary>
        /// Encrypts plaintext.
        /// </summary>
        /// <param name="options">An <see cref="EncryptOptions"/> containing the data to encrypt and other options for algorithm-dependent encryption.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to cancel the operation.</param>
        /// <returns>
        /// An <see cref="EncryptResult"/> containing the encrypted data
        /// along with all other information needed to decrypt it. This information should be stored with the encrypted data.
        /// </returns>
        /// <exception cref="ArgumentException">The specified algorithm does not match the key corresponding to the key identifier.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="options"/> is null.</exception>
        /// <exception cref="CryptographicException">The local cryptographic provider threw an exception.</exception>
        /// <exception cref="InvalidOperationException">The key is invalid for the current operation.</exception>
        /// <exception cref="NotSupportedException">The operation is not supported with the specified key.</exception>
        public virtual async Task<EncryptResult> EncryptAsync(EncryptOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CryptographyClient)}.{nameof(Encrypt)}");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                if (_provider is null)
                {
                    await InitializeAsync(nameof(Encrypt), cancellationToken).ConfigureAwait(false);
                }

                EncryptResult result = null;
                if (_provider.SupportsOperation(KeyOperation.Encrypt))
                {
                    try
                    {
                        result = await _provider.EncryptAsync(options, cancellationToken).ConfigureAwait(false);
                    }
                    catch (CryptographicException ex) when (_provider.ShouldRemote)
                    {
                        // Use the non-async name as we do for scope.
                        KeysEventSource.Singleton.CryptographicException(nameof(Encrypt), ex);
                    }
                }

                if (result is null)
                {
                    result = await _remoteProvider.EncryptAsync(options, cancellationToken).ConfigureAwait(false);
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
        /// Encrypts plaintext.
        /// </summary>
        /// <param name="options">An <see cref="EncryptOptions"/> containing the data to encrypt and other options for algorithm-dependent encryption.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to cancel the operation.</param>
        /// <returns>
        /// An <see cref="EncryptResult"/> containing the encrypted data
        /// along with all other information needed to decrypt it. This information should be stored with the encrypted data.
        /// </returns>
        /// <exception cref="ArgumentException">The specified algorithm does not match the key corresponding to the key identifier.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="options"/> is null.</exception>
        /// <exception cref="CryptographicException">The local cryptographic provider threw an exception.</exception>
        /// <exception cref="InvalidOperationException">The key is invalid for the current operation.</exception>
        /// <exception cref="NotSupportedException">The operation is not supported with the specified key.</exception>
        public virtual EncryptResult Encrypt(EncryptOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CryptographyClient)}.{nameof(Encrypt)}");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                if (_provider is null)
                {
                    Initialize(nameof(Encrypt), cancellationToken);
                }

                EncryptResult result = null;
                if (_provider.SupportsOperation(KeyOperation.Encrypt))
                {
                    try
                    {
                        result = _provider.Encrypt(options, cancellationToken);
                    }
                    catch (CryptographicException ex) when (_provider.ShouldRemote)
                    {
                        KeysEventSource.Singleton.CryptographicException(nameof(Encrypt), ex);
                    }
                }

                if (result is null)
                {
                    result = _remoteProvider.Encrypt(options, cancellationToken);
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
        /// Decrypts the specified ciphertext.
        /// </summary>
        /// <param name="algorithm">The <see cref="EncryptionAlgorithm"/> to use.</param>
        /// <param name="ciphertext">The encrypted data to decrypt.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to cancel the operation.</param>
        /// <returns>
        /// The result of the decrypt operation. The returned <see cref="DecryptResult"/> contains the encrypted data
        /// along with information regarding the algorithm and key used to decrypt it.
        /// </returns>
        /// <exception cref="ArgumentException">The specified <paramref name="algorithm"/> does not match the key corresponding to the key identifier.</exception>
        /// <exception cref="CryptographicException">The local cryptographic provider threw an exception.</exception>
        /// <exception cref="InvalidOperationException">The key is invalid for the current operation.</exception>
        /// <exception cref="NotSupportedException">The operation is not supported with the specified key.</exception>
        public virtual async Task<DecryptResult> DecryptAsync(EncryptionAlgorithm algorithm, byte[] ciphertext, CancellationToken cancellationToken = default) =>
            await DecryptAsync(new DecryptOptions(algorithm, ciphertext), cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Decrypts ciphertext.
        /// </summary>
        /// <param name="algorithm">The <see cref="EncryptionAlgorithm"/> to use.</param>
        /// <param name="ciphertext">The encrypted data to decrypt.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to cancel the operation.</param>
        /// <returns>
        /// The result of the decrypt operation. The returned <see cref="DecryptResult"/> contains the encrypted data
        /// along with information regarding the algorithm and key used to decrypt it.
        /// </returns>
        /// <exception cref="ArgumentException">The specified <paramref name="algorithm"/> does not match the key corresponding to the key identifier.</exception>
        /// <exception cref="CryptographicException">The local cryptographic provider threw an exception.</exception>
        /// <exception cref="InvalidOperationException">The key is invalid for the current operation.</exception>
        /// <exception cref="NotSupportedException">The operation is not supported with the specified key.</exception>
        public virtual DecryptResult Decrypt(EncryptionAlgorithm algorithm, byte[] ciphertext, CancellationToken cancellationToken = default) =>
            Decrypt(new DecryptOptions(algorithm, ciphertext), cancellationToken);

        /// <summary>
        /// Decrypts ciphertext.
        /// </summary>
        /// <param name="options">A <see cref="DecryptOptions"/> containing the data to decrypt and other options for algorithm-dependent decryption.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to cancel the operation.</param>
        /// <returns>
        /// The result of the decrypt operation. The returned <see cref="DecryptResult"/> contains the encrypted data
        /// along with information regarding the algorithm and key used to decrypt it.
        /// </returns>
        /// <exception cref="ArgumentException">The specified algorithm does not match the key corresponding to the key identifier.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="options"/> is null.</exception>
        /// <exception cref="CryptographicException">The local cryptographic provider threw an exception.</exception>
        /// <exception cref="InvalidOperationException">The key is invalid for the current operation.</exception>
        /// <exception cref="NotSupportedException">The operation is not supported with the specified key.</exception>
        public virtual async Task<DecryptResult> DecryptAsync(DecryptOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CryptographyClient)}.{nameof(Decrypt)}");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                if (_provider is null)
                {
                    await InitializeAsync(nameof(Decrypt), cancellationToken).ConfigureAwait(false);
                }

                DecryptResult result = null;
                if (_provider.SupportsOperation(KeyOperation.Decrypt))
                {
                    try
                    {
                        result = await _provider.DecryptAsync(options, cancellationToken).ConfigureAwait(false);
                    }
                    catch (CryptographicException ex) when (_provider.ShouldRemote)
                    {
                        // Use the non-async name as we do for scope.
                        KeysEventSource.Singleton.CryptographicException(nameof(Decrypt), ex);
                    }
                }

                if (result is null)
                {
                    result = await _remoteProvider.DecryptAsync(options, cancellationToken).ConfigureAwait(false);
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
        /// Decrypts the specified ciphertext.
        /// </summary>
        /// <param name="options">A <see cref="DecryptOptions"/> containing the data to decrypt and other options for algorithm-dependent decryption.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to cancel the operation.</param>
        /// <returns>
        /// The result of the decrypt operation. The returned <see cref="DecryptResult"/> contains the encrypted data
        /// along with information regarding the algorithm and key used to decrypt it.
        /// </returns>
        /// <exception cref="ArgumentException">The specified algorithm does not match the key corresponding to the key identifier.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="options"/> is null.</exception>
        /// <exception cref="CryptographicException">The local cryptographic provider threw an exception.</exception>
        /// <exception cref="InvalidOperationException">The key is invalid for the current operation.</exception>
        /// <exception cref="NotSupportedException">The operation is not supported with the specified key.</exception>
        public virtual DecryptResult Decrypt(DecryptOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CryptographyClient)}.{nameof(Decrypt)}");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                if (_provider is null)
                {
                    Initialize(nameof(Decrypt), cancellationToken);
                }

                DecryptResult result = null;
                if (_provider.SupportsOperation(KeyOperation.Decrypt))
                {
                    try
                    {
                        result = _provider.Decrypt(options, cancellationToken);
                    }
                    catch (CryptographicException ex) when (_provider.ShouldRemote)
                    {
                        KeysEventSource.Singleton.CryptographicException(nameof(Decrypt), ex);
                    }
                }

                if (result is null)
                {
                    result = _remoteProvider.Decrypt(options, cancellationToken);
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
        /// Encrypts the specified key.
        /// </summary>
        /// <param name="algorithm">The <see cref="KeyWrapAlgorithm"/> to use.</param>
        /// <param name="key">The key to encrypt.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to cancel the operation.</param>
        /// <returns>
        /// The result of the wrap operation. The returned <see cref="WrapResult"/> contains the wrapped key
        /// along with all other information needed to unwrap it. This information should be stored with the wrapped key.
        /// </returns>
        /// <exception cref="ArgumentException">The specified <paramref name="algorithm"/> does not match the key corresponding to the key identifier.</exception>
        /// <exception cref="CryptographicException">The local cryptographic provider threw an exception.</exception>
        /// <exception cref="InvalidOperationException">The key is invalid for the current operation.</exception>
        /// <exception cref="NotSupportedException">The operation is not supported with the specified key.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<WrapResult> WrapKeyAsync(KeyWrapAlgorithm algorithm, byte[] key, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CryptographyClient)}.{nameof(WrapKey)}");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                if (_provider is null)
                {
                    await InitializeAsync(nameof(WrapKey), cancellationToken).ConfigureAwait(false);
                }

                WrapResult result = null;
                if (_provider.SupportsOperation(KeyOperation.WrapKey))
                {
                    try
                    {
                        result = await _provider.WrapKeyAsync(algorithm, key, cancellationToken).ConfigureAwait(false);
                    }
                    catch (CryptographicException ex) when (_provider.ShouldRemote)
                    {
                        // Use the non-async name as we do for scope.
                        KeysEventSource.Singleton.CryptographicException(nameof(WrapKey), ex);
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
        /// Encrypts the specified key.
        /// </summary>
        /// <param name="algorithm">The <see cref="KeyWrapAlgorithm"/> to use.</param>
        /// <param name="key">The key to encrypt.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to cancel the operation.</param>
        /// <returns>
        /// The result of the wrap operation. The returned <see cref="WrapResult"/> contains the wrapped key
        /// along with all other information needed to unwrap it. This information should be stored with the wrapped key.
        /// </returns>
        /// <exception cref="ArgumentException">The specified <paramref name="algorithm"/> does not match the key corresponding to the key identifier.</exception>
        /// <exception cref="CryptographicException">The local cryptographic provider threw an exception.</exception>
        /// <exception cref="InvalidOperationException">The key is invalid for the current operation.</exception>
        /// <exception cref="NotSupportedException">The operation is not supported with the specified key.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual WrapResult WrapKey(KeyWrapAlgorithm algorithm, byte[] key, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CryptographyClient)}.{nameof(WrapKey)}");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                if (_provider is null)
                {
                    Initialize(nameof(WrapKey), cancellationToken);
                }

                WrapResult result = null;
                if (_provider.SupportsOperation(KeyOperation.WrapKey))
                {
                    try
                    {
                        result = _provider.WrapKey(algorithm, key, cancellationToken);
                    }
                    catch (CryptographicException ex) when (_provider.ShouldRemote)
                    {
                        KeysEventSource.Singleton.CryptographicException(nameof(WrapKey), ex);
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
        /// Decrypts the specified encrypted key.
        /// </summary>
        /// <param name="algorithm">The <see cref="KeyWrapAlgorithm"/> to use.</param>
        /// <param name="encryptedKey">The encrypted key.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to cancel the operation.</param>
        /// <returns>
        /// The result of the unwrap operation. The returned <see cref="UnwrapResult"/> contains the key
        /// along with information regarding the algorithm and key used to unwrap it.
        /// </returns>
        /// <exception cref="ArgumentException">The specified <paramref name="algorithm"/> does not match the key corresponding to the key identifier.</exception>
        /// <exception cref="CryptographicException">The local cryptographic provider threw an exception.</exception>
        /// <exception cref="InvalidOperationException">The key is invalid for the current operation.</exception>
        /// <exception cref="NotSupportedException">The operation is not supported with the specified key.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<UnwrapResult> UnwrapKeyAsync(KeyWrapAlgorithm algorithm, byte[] encryptedKey, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CryptographyClient)}.{nameof(UnwrapKey)}");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                if (_provider is null)
                {
                    await InitializeAsync(nameof(UnwrapKey), cancellationToken).ConfigureAwait(false);
                }

                UnwrapResult result = null;
                if (_provider.SupportsOperation(KeyOperation.UnwrapKey))
                {
                    try
                    {
                        result = await _provider.UnwrapKeyAsync(algorithm, encryptedKey, cancellationToken).ConfigureAwait(false);
                    }
                    catch (CryptographicException ex) when (_provider.ShouldRemote)
                    {
                        // Use the non-async name as we do for scope.
                        KeysEventSource.Singleton.CryptographicException(nameof(UnwrapKey), ex);
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
        /// Decrypts the specified encrypted key.
        /// </summary>
        /// <param name="algorithm">The <see cref="KeyWrapAlgorithm"/> to use.</param>
        /// <param name="encryptedKey">The encrypted key.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to cancel the operation.</param>
        /// <returns>
        /// The result of the unwrap operation. The returned <see cref="UnwrapResult"/> contains the key
        /// along with information regarding the algorithm and key used to unwrap it.
        /// </returns>
        /// <exception cref="ArgumentException">The specified <paramref name="algorithm"/> does not match the key corresponding to the key identifier.</exception>
        /// <exception cref="CryptographicException">The local cryptographic provider threw an exception.</exception>
        /// <exception cref="InvalidOperationException">The key is invalid for the current operation.</exception>
        /// <exception cref="NotSupportedException">The operation is not supported with the specified key.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual UnwrapResult UnwrapKey(KeyWrapAlgorithm algorithm, byte[] encryptedKey, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CryptographyClient)}.{nameof(UnwrapKey)}");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                if (_provider is null)
                {
                    Initialize(nameof(UnwrapKey), cancellationToken);
                }

                UnwrapResult result = null;
                if (_provider.SupportsOperation(KeyOperation.UnwrapKey))
                {
                    try
                    {
                        result = _provider.UnwrapKey(algorithm, encryptedKey, cancellationToken);
                    }
                    catch (CryptographicException ex) when (_provider.ShouldRemote)
                    {
                        KeysEventSource.Singleton.CryptographicException(nameof(UnwrapKey), ex);
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
        /// <exception cref="CryptographicException">The local cryptographic provider threw an exception.</exception>
        /// <exception cref="InvalidOperationException">The key is invalid for the current operation.</exception>
        /// <exception cref="NotSupportedException">The operation is not supported with the specified key.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<SignResult> SignAsync(SignatureAlgorithm algorithm, byte[] digest, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CryptographyClient)}.{nameof(Sign)}");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                if (_provider is null)
                {
                    await InitializeAsync(nameof(Sign), cancellationToken).ConfigureAwait(false);
                }

                SignResult result = null;
                if (_provider.SupportsOperation(KeyOperation.Sign))
                {
                    try
                    {
                        result = await _provider.SignAsync(algorithm, digest, cancellationToken).ConfigureAwait(false);
                    }
                    catch (CryptographicException ex) when (_provider.ShouldRemote)
                    {
                        // Use the non-async name as we do for scope.
                        KeysEventSource.Singleton.CryptographicException(nameof(Sign), ex);
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
        /// <exception cref="CryptographicException">The local cryptographic provider threw an exception.</exception>
        /// <exception cref="InvalidOperationException">The key is invalid for the current operation.</exception>
        /// <exception cref="NotSupportedException">The operation is not supported with the specified key.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual SignResult Sign(SignatureAlgorithm algorithm, byte[] digest, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CryptographyClient)}.{nameof(Sign)}");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                if (_provider is null)
                {
                    Initialize(nameof(Sign), cancellationToken);
                }

                SignResult result = null;
                if (_provider.SupportsOperation(KeyOperation.Sign))
                {
                    try
                    {
                        result = _provider.Sign(algorithm, digest, cancellationToken);
                    }
                    catch (CryptographicException ex) when (_provider.ShouldRemote)
                    {
                        KeysEventSource.Singleton.CryptographicException(nameof(Sign), ex);
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
        /// <exception cref="CryptographicException">The local cryptographic provider threw an exception.</exception>
        /// <exception cref="InvalidOperationException">The key is invalid for the current operation.</exception>
        /// <exception cref="NotSupportedException">The operation is not supported with the specified key.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<VerifyResult> VerifyAsync(SignatureAlgorithm algorithm, byte[] digest, byte[] signature, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CryptographyClient)}.{nameof(Verify)}");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                if (_provider is null)
                {
                    await InitializeAsync(nameof(Verify), cancellationToken).ConfigureAwait(false);
                }

                VerifyResult result = null;
                if (_provider.SupportsOperation(KeyOperation.Verify))
                {
                    try
                    {
                        result = await _provider.VerifyAsync(algorithm, digest, signature, cancellationToken).ConfigureAwait(false);
                    }
                    catch (CryptographicException ex) when (_provider.ShouldRemote)
                    {
                        // Use the non-async name as we do for scope.
                        KeysEventSource.Singleton.CryptographicException(nameof(Verify), ex);
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
        /// <exception cref="CryptographicException">The local cryptographic provider threw an exception.</exception>
        /// <exception cref="InvalidOperationException">The key is invalid for the current operation.</exception>
        /// <exception cref="NotSupportedException">The operation is not supported with the specified key.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual VerifyResult Verify(SignatureAlgorithm algorithm, byte[] digest, byte[] signature, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CryptographyClient)}.{nameof(Verify)}");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                if (_provider is null)
                {
                    Initialize(nameof(Verify), cancellationToken);
                }

                VerifyResult result = null;
                if (_provider.SupportsOperation(KeyOperation.Verify))
                {
                    try
                    {
                        result = _provider.Verify(algorithm, digest, signature, cancellationToken);
                    }
                    catch (CryptographicException ex) when (_provider.ShouldRemote)
                    {
                        KeysEventSource.Singleton.CryptographicException(nameof(Verify), ex);
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
        /// <exception cref="CryptographicException">The local cryptographic provider threw an exception.</exception>
        /// <exception cref="InvalidOperationException">The key is invalid for the current operation.</exception>
        /// <exception cref="NotSupportedException">The operation is not supported with the specified key.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<SignResult> SignDataAsync(SignatureAlgorithm algorithm, byte[] data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CryptographyClient)}.{nameof(SignData)}");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                byte[] digest = CreateDigest(algorithm, data);

                if (_provider is null)
                {
                    await InitializeAsync(nameof(SignData), cancellationToken).ConfigureAwait(false);
                }

                SignResult result = null;
                if (_provider.SupportsOperation(KeyOperation.Sign))
                {
                    try
                    {
                        result = await _provider.SignAsync(algorithm, digest, cancellationToken).ConfigureAwait(false);
                    }
                    catch (CryptographicException ex) when (_provider.ShouldRemote)
                    {
                        // Use the non-async name as we do for scope.
                        KeysEventSource.Singleton.CryptographicException(nameof(SignData), ex);
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
        /// <exception cref="CryptographicException">The local cryptographic provider threw an exception.</exception>
        /// <exception cref="InvalidOperationException">The key is invalid for the current operation.</exception>
        /// <exception cref="NotSupportedException">The operation is not supported with the specified key.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual SignResult SignData(SignatureAlgorithm algorithm, byte[] data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CryptographyClient)}.{nameof(SignData)}");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                byte[] digest = CreateDigest(algorithm, data);

                if (_provider is null)
                {
                    Initialize(nameof(SignData), cancellationToken);
                }

                SignResult result = null;
                if (_provider.SupportsOperation(KeyOperation.Sign))
                {
                    try
                    {
                        result = _provider.Sign(algorithm, digest, cancellationToken);
                    }
                    catch (CryptographicException ex) when (_provider.ShouldRemote)
                    {
                        // Use the non-async name as we do for scope.
                        KeysEventSource.Singleton.CryptographicException(nameof(SignData), ex);
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
        /// <exception cref="CryptographicException">The local cryptographic provider threw an exception.</exception>
        /// <exception cref="InvalidOperationException">The key is invalid for the current operation.</exception>
        /// <exception cref="NotSupportedException">The operation is not supported with the specified key.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<SignResult> SignDataAsync(SignatureAlgorithm algorithm, Stream data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CryptographyClient)}.{nameof(SignData)}");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                byte[] digest = CreateDigest(algorithm, data);

                if (_provider is null)
                {
                    await InitializeAsync(nameof(SignData), cancellationToken).ConfigureAwait(false);
                }

                SignResult result = null;
                if (_provider.SupportsOperation(KeyOperation.Sign))
                {
                    try
                    {
                        result = await _provider.SignAsync(algorithm, digest, cancellationToken).ConfigureAwait(false);
                    }
                    catch (CryptographicException ex) when (_provider.ShouldRemote)
                    {
                        // Use the non-async name as we do for scope.
                        KeysEventSource.Singleton.CryptographicException(nameof(SignData), ex);
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
        /// <exception cref="CryptographicException">The local cryptographic provider threw an exception.</exception>
        /// <exception cref="InvalidOperationException">The key is invalid for the current operation.</exception>
        /// <exception cref="NotSupportedException">The operation is not supported with the specified key.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual SignResult SignData(SignatureAlgorithm algorithm, Stream data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CryptographyClient)}.{nameof(SignData)}");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                byte[] digest = CreateDigest(algorithm, data);

                if (_provider is null)
                {
                    Initialize(nameof(SignData), cancellationToken);
                }

                SignResult result = null;
                if (_provider.SupportsOperation(KeyOperation.Sign))
                {
                    try
                    {
                        result = _provider.Sign(algorithm, digest, cancellationToken);
                    }
                    catch (CryptographicException ex) when (_provider.ShouldRemote)
                    {
                        KeysEventSource.Singleton.CryptographicException(nameof(SignData), ex);
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
        /// <exception cref="CryptographicException">The local cryptographic provider threw an exception.</exception>
        /// <exception cref="InvalidOperationException">The key is invalid for the current operation.</exception>
        /// <exception cref="NotSupportedException">The operation is not supported with the specified key.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<VerifyResult> VerifyDataAsync(SignatureAlgorithm algorithm, byte[] data, byte[] signature, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CryptographyClient)}.{nameof(VerifyData)}");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                byte[] digest = CreateDigest(algorithm, data);

                if (_provider is null)
                {
                    await InitializeAsync(nameof(VerifyData), cancellationToken).ConfigureAwait(false);
                }

                VerifyResult result = null;
                if (_provider.SupportsOperation(KeyOperation.Verify))
                {
                    try
                    {
                        result = await _provider.VerifyAsync(algorithm, digest, signature, cancellationToken).ConfigureAwait(false);
                    }
                    catch (CryptographicException ex) when (_provider.ShouldRemote)
                    {
                        // Use the non-async name as we do for scope.
                        KeysEventSource.Singleton.CryptographicException(nameof(VerifyData), ex);
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
        /// <exception cref="CryptographicException">The local cryptographic provider threw an exception.</exception>
        /// <exception cref="InvalidOperationException">The key is invalid for the current operation.</exception>
        /// <exception cref="NotSupportedException">The operation is not supported with the specified key.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual VerifyResult VerifyData(SignatureAlgorithm algorithm, byte[] data, byte[] signature, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CryptographyClient)}.{nameof(VerifyData)}");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                byte[] digest = CreateDigest(algorithm, data);

                if (_provider is null)
                {
                    Initialize(nameof(VerifyData), cancellationToken);
                }

                VerifyResult result = null;
                if (_provider.SupportsOperation(KeyOperation.Verify))
                {
                    try
                    {
                        result = _provider.Verify(algorithm, digest, signature, cancellationToken);
                    }
                    catch (CryptographicException ex) when (_provider.ShouldRemote)
                    {
                        KeysEventSource.Singleton.CryptographicException(nameof(VerifyData), ex);
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
        /// <exception cref="CryptographicException">The local cryptographic provider threw an exception.</exception>
        /// <exception cref="InvalidOperationException">The key is invalid for the current operation.</exception>
        /// <exception cref="NotSupportedException">The operation is not supported with the specified key.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<VerifyResult> VerifyDataAsync(SignatureAlgorithm algorithm, Stream data, byte[] signature, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CryptographyClient)}.{nameof(VerifyData)}");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                byte[] digest = CreateDigest(algorithm, data);

                if (_provider is null)
                {
                    await InitializeAsync(nameof(VerifyData), cancellationToken).ConfigureAwait(false);
                }

                VerifyResult result = null;
                if (_provider.SupportsOperation(KeyOperation.Verify))
                {
                    try
                    {
                        result = await _provider.VerifyAsync(algorithm, digest, signature, cancellationToken).ConfigureAwait(false);
                    }
                    catch (CryptographicException ex) when (_provider.ShouldRemote)
                    {
                        // Use the non-async name as we do for scope.
                        KeysEventSource.Singleton.CryptographicException(nameof(VerifyData), ex);
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
        /// <exception cref="CryptographicException">The local cryptographic provider threw an exception.</exception>
        /// <exception cref="InvalidOperationException">The key is invalid for the current operation.</exception>
        /// <exception cref="NotSupportedException">The operation is not supported with the specified key.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual VerifyResult VerifyData(SignatureAlgorithm algorithm, Stream data, byte[] signature, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CryptographyClient)}.{nameof(VerifyData)}");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                byte[] digest = CreateDigest(algorithm, data);

                if (_provider is null)
                {
                    Initialize(nameof(VerifyData), cancellationToken);
                }

                VerifyResult result = null;
                if (_provider.SupportsOperation(KeyOperation.Verify))
                {
                    try
                    {
                        result = _provider.Verify(algorithm, digest, signature, cancellationToken);
                    }
                    catch (CryptographicException ex) when (_provider.ShouldRemote)
                    {
                        KeysEventSource.Singleton.CryptographicException(nameof(VerifyData), ex);
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
        byte[] IKeyEncryptionKey.WrapKey(string algorithm, ReadOnlyMemory<byte> key, CancellationToken cancellationToken)
        {
            WrapResult result = WrapKey(new KeyWrapAlgorithm(algorithm), key.ToArray(), cancellationToken);

            return result.EncryptedKey;
        }

        /// <inheritdoc/>
        async Task<byte[]> IKeyEncryptionKey.WrapKeyAsync(string algorithm, ReadOnlyMemory<byte> key, CancellationToken cancellationToken)
        {
            WrapResult result = await WrapKeyAsync(new KeyWrapAlgorithm(algorithm), key.ToArray(), cancellationToken).ConfigureAwait(false);

            return result.EncryptedKey;
        }

        /// <inheritdoc/>
        byte[] IKeyEncryptionKey.UnwrapKey(string algorithm, ReadOnlyMemory<byte> encryptedKey, CancellationToken cancellationToken)
        {
            byte[] buffer = MemoryMarshal.TryGetArray(encryptedKey, out ArraySegment<byte> segment) ? segment.Array : encryptedKey.ToArray();
            UnwrapResult result = UnwrapKey(new KeyWrapAlgorithm(algorithm), buffer, cancellationToken);

            return result.Key;
        }

        /// <inheritdoc/>
        async Task<byte[]> IKeyEncryptionKey.UnwrapKeyAsync(string algorithm, ReadOnlyMemory<byte> encryptedKey, CancellationToken cancellationToken)
        {
            byte[] buffer = MemoryMarshal.TryGetArray(encryptedKey, out ArraySegment<byte> segment) ? segment.Array : encryptedKey.ToArray();
            UnwrapResult result = await UnwrapKeyAsync(new KeyWrapAlgorithm(algorithm), buffer, cancellationToken).ConfigureAwait(false);

            return result.Key;
        }

        internal static byte[] CreateDigest(SignatureAlgorithm algorithm, byte[] data)
        {
            using HashAlgorithm hashAlgo = algorithm.GetHashAlgorithm();
            return hashAlgo.ComputeHash(data);
        }

        internal static byte[] CreateDigest(SignatureAlgorithm algorithm, Stream data)
        {
            using HashAlgorithm hashAlgo = algorithm.GetHashAlgorithm();
            return hashAlgo.ComputeHash(data);
        }

        private async Task InitializeAsync(string operation, CancellationToken cancellationToken)
        {
            if (_provider != null)
            {
                return;
            }

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CryptographyClient)}.{nameof(Initialize)}");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                Response<KeyVaultKey> key = await _remoteProvider.GetKeyAsync(cancellationToken).ConfigureAwait(false);

                _provider = LocalCryptographyProviderFactory.Create(key.Value);
                if (_provider is null)
                {
                    KeysEventSource.Singleton.KeyTypeNotSupported(operation, key.Value);

                    _provider = _remoteProvider;
                    return;
                }
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

        private void Initialize(string operation, CancellationToken cancellationToken)
        {
            if (_provider != null)
            {
                return;
            }

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CryptographyClient)}.{nameof(Initialize)}");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                Response<KeyVaultKey> key = _remoteProvider.GetKey(cancellationToken);

                _provider = LocalCryptographyProviderFactory.Create(key.Value);
                if (_provider is null)
                {
                    KeysEventSource.Singleton.KeyTypeNotSupported(operation, key.Value);

                    _provider = _remoteProvider;
                    return;
                }
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
