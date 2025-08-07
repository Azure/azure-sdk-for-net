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
    [CallerShouldAudit(CallerShouldAuditReason)]
    public class CryptographyClient : IKeyEncryptionKey
    {
        private const string CallerShouldAuditReason = "https://aka.ms/azsdk/callershouldaudit/security-keyvault-keys";
        private const string GetOperation = "get";
        private const string OTelKeyIdKey = "az.keyvault.key.id";
        private readonly string _keyId;
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
        /// You should validate that this URI references a valid Key Vault or Managed HSM resource. See <see href="https://aka.ms/azsdk/blog/vault-uri"/> for details.
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
        /// You should validate that this URI references a valid Key Vault or Managed HSM resource. See <see href="https://aka.ms/azsdk/blog/vault-uri"/> for details.
        /// </param>
        /// <param name="credential">A <see cref="TokenCredential"/> used to authenticate requests to the vault, like DefaultAzureCredential.</param>
        /// <param name="options"><see cref="CryptographyClientOptions"/> the <see cref="CryptographyClient"/> for local or remote operations on Key Vault.</param>
        /// <exception cref="ArgumentNullException"><paramref name="keyId"/> or <paramref name="credential"/> is null.</exception>
        /// <exception cref="NotSupportedException">The <see cref="CryptographyClientOptions.Version"/> is not supported.</exception>
        public CryptographyClient(Uri keyId, TokenCredential credential, CryptographyClientOptions options)
            : this(keyId, credential, options, false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CryptographyClient"/> class.
        /// Cryptographic operations will be performed only on the local machine.
        /// </summary>
        /// <param name="key">A <see cref="JsonWebKey"/> used for local cryptographic operations.</param>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is null.</exception>
        /// <exception cref="NotSupportedException">The <see cref="JsonWebKey.KeyType"/> of <paramref name="key"/> is not supported.</exception>
        public CryptographyClient(JsonWebKey key)
            : this(key, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CryptographyClient"/> class.
        /// Cryptographic operations will be performed only on the local machine.
        /// </summary>
        /// <param name="key">A <see cref="JsonWebKey"/> used for local cryptographic operations.</param>
        /// <param name="options"><see cref="LocalCryptographyClientOptions"/> to configure the <see cref="CryptographyClient"/> for local-only operations.</param>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is null.</exception>
        /// <exception cref="NotSupportedException">The <see cref="JsonWebKey.KeyType"/> of <paramref name="key"/> is not supported.</exception>
        public CryptographyClient(JsonWebKey key, LocalCryptographyClientOptions options)
        {
            Argument.AssertNotNull(key, nameof(key));

            _keyId = key.Id;
            options ??= new LocalCryptographyClientOptions();

            _pipeline = new KeyVaultPipeline(new ClientDiagnostics(options));
            _provider = LocalCryptographyProviderFactory.Create(key, null, localOnly: true) ?? throw new NotSupportedException(@$"Key type ""{key.KeyType}"" is not supported");
        }

        internal CryptographyClient(Uri keyId, TokenCredential credential, CryptographyClientOptions options, bool forceRemote)
        {
            Argument.AssertNotNull(keyId, nameof(keyId));
            Argument.AssertNotNull(credential, nameof(credential));

            _keyId = keyId.AbsoluteUri;
            options ??= new CryptographyClientOptions();

            RemoteCryptographyClient remoteClient = new RemoteCryptographyClient(new Uri(_keyId), credential, options);

            _pipeline = remoteClient.Pipeline;
            _remoteProvider = remoteClient;

            // Always use the remote client if requested; otherwise, attempt to cache and use the key locally or fall back to the remote client in Initialize().
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

            _keyId = keyMaterial.Id;
            options ??= new CryptographyClientOptions();

            RemoteCryptographyClient remoteClient = new RemoteCryptographyClient(new Uri(_keyId), credential, options);

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

            _keyId = keyMaterial.Id;

            RemoteCryptographyClient remoteClient = new RemoteCryptographyClient(pipeline);

            _pipeline = pipeline;
            _remoteProvider = remoteClient;
            _provider = LocalCryptographyProviderFactory.Create(key);
        }

        internal CryptographyClient(Uri keyId, KeyVaultPipeline pipeline, bool forceRemote)
        {
            Argument.AssertNotNull(keyId, nameof(keyId));

            _keyId = keyId.AbsoluteUri;

            RemoteCryptographyClient remoteClient = new RemoteCryptographyClient(pipeline);

            _pipeline = pipeline;
            _remoteProvider = remoteClient;

            // Always use the remote client if requested; otherwise, attempt to cache and use the key locally or fall back to the remote client in Initialize().
            if (forceRemote)
            {
                _provider = remoteClient;
            }
        }

        internal ICryptographyProvider RemoteClient => _remoteProvider;

        /// <summary>
        /// Gets the <see cref="KeyVaultKey.Id"/> of the key used to perform cryptographic operations for the client.
        /// </summary>
        public virtual string KeyId => _keyId;

        /// <summary>
        /// Gets whether this <see cref="CryptographyClient"/> runs only local operations.
        /// </summary>
        private bool LocalOnly => _remoteProvider is null;

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
        /// <remarks>
        /// Microsoft recommends you not use CBC without first ensuring the integrity of the ciphertext using an HMAC, for example. See https://docs.microsoft.com/dotnet/standard/security/vulnerabilities-cbc-mode for more information.
        /// </remarks>
        /// <exception cref="ArgumentException">The specified <paramref name="algorithm"/> does not match the key corresponding to the key identifier.</exception>
        /// <exception cref="CryptographicException">The local cryptographic provider threw an exception.</exception>
        /// <exception cref="InvalidOperationException">The key is invalid for the current operation.</exception>
        /// <exception cref="NotSupportedException">The operation is not supported with the specified key.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<EncryptResult> EncryptAsync(EncryptionAlgorithm algorithm, byte[] plaintext, CancellationToken cancellationToken = default) =>
            await EncryptAsync(new EncryptParameters(algorithm, plaintext), cancellationToken).ConfigureAwait(false);

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
        /// <remarks>
        /// Microsoft recommends you not use CBC without first ensuring the integrity of the ciphertext using an HMAC, for example. See https://docs.microsoft.com/dotnet/standard/security/vulnerabilities-cbc-mode for more information.
        /// </remarks>
        /// <exception cref="ArgumentException">The specified <paramref name="algorithm"/> does not match the key corresponding to the key identifier.</exception>
        /// <exception cref="CryptographicException">The local cryptographic provider threw an exception.</exception>
        /// <exception cref="InvalidOperationException">The key is invalid for the current operation.</exception>
        /// <exception cref="NotSupportedException">The operation is not supported with the specified key.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual EncryptResult Encrypt(EncryptionAlgorithm algorithm, byte[] plaintext, CancellationToken cancellationToken = default) =>
            Encrypt(new EncryptParameters(algorithm, plaintext), cancellationToken);

        /// <summary>
        /// Encrypts plaintext.
        /// </summary>
        /// <param name="encryptParameters">An <see cref="EncryptParameters"/> containing the data to encrypt and other parameters for algorithm-dependent encryption.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to cancel the operation.</param>
        /// <returns>
        /// An <see cref="EncryptResult"/> containing the encrypted data
        /// along with all other information needed to decrypt it. This information should be stored with the encrypted data.
        /// </returns>
        /// <remarks>
        /// Microsoft recommends you not use CBC without first ensuring the integrity of the ciphertext using an HMAC, for example. See https://docs.microsoft.com/dotnet/standard/security/vulnerabilities-cbc-mode for more information.
        /// </remarks>
        /// <exception cref="ArgumentException">The specified algorithm does not match the key corresponding to the key identifier.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="encryptParameters"/> is null.</exception>
        /// <exception cref="CryptographicException">The local cryptographic provider threw an exception.</exception>
        /// <exception cref="InvalidOperationException">The key is invalid for the current operation.</exception>
        /// <exception cref="NotSupportedException">The operation is not supported with the specified key.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<EncryptResult> EncryptAsync(EncryptParameters encryptParameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(encryptParameters, nameof(encryptParameters));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CryptographyClient)}.{nameof(Encrypt)}");
            scope.AddAttribute(OTelKeyIdKey, _keyId);
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
                        result = await _provider.EncryptAsync(encryptParameters, cancellationToken).ConfigureAwait(false);
                    }
                    catch (CryptographicException ex) when (_provider.CanRemote)
                    {
                        // Use the non-async name as we do for scope.
                        KeysEventSource.Singleton.CryptographicException(nameof(Encrypt), ex);
                    }
                }

                if (result is null)
                {
                    ThrowIfLocalOnly(nameof(Encrypt));

                    result = await _remoteProvider.EncryptAsync(encryptParameters, cancellationToken).ConfigureAwait(false);
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
        /// <param name="encryptParameters">An <see cref="EncryptParameters"/> containing the data to encrypt and other parameters for algorithm-dependent encryption.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to cancel the operation.</param>
        /// <returns>
        /// An <see cref="EncryptResult"/> containing the encrypted data
        /// along with all other information needed to decrypt it. This information should be stored with the encrypted data.
        /// </returns>
        /// <remarks>
        /// Microsoft recommends you not use CBC without first ensuring the integrity of the ciphertext using an HMAC, for example. See https://docs.microsoft.com/dotnet/standard/security/vulnerabilities-cbc-mode for more information.
        /// </remarks>
        /// <exception cref="ArgumentException">The specified algorithm does not match the key corresponding to the key identifier.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="encryptParameters"/> is null.</exception>
        /// <exception cref="CryptographicException">The local cryptographic provider threw an exception.</exception>
        /// <exception cref="InvalidOperationException">The key is invalid for the current operation.</exception>
        /// <exception cref="NotSupportedException">The operation is not supported with the specified key.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual EncryptResult Encrypt(EncryptParameters encryptParameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(encryptParameters, nameof(encryptParameters));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CryptographyClient)}.{nameof(Encrypt)}");
            scope.AddAttribute(OTelKeyIdKey, _keyId);
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
                        result = _provider.Encrypt(encryptParameters, cancellationToken);
                    }
                    catch (CryptographicException ex) when (_provider.CanRemote)
                    {
                        KeysEventSource.Singleton.CryptographicException(nameof(Encrypt), ex);
                    }
                }

                if (result is null)
                {
                    ThrowIfLocalOnly(nameof(Encrypt));

                    result = _remoteProvider.Encrypt(encryptParameters, cancellationToken);
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
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<DecryptResult> DecryptAsync(EncryptionAlgorithm algorithm, byte[] ciphertext, CancellationToken cancellationToken = default) =>
            await DecryptAsync(new DecryptParameters(algorithm, ciphertext), cancellationToken).ConfigureAwait(false);

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
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual DecryptResult Decrypt(EncryptionAlgorithm algorithm, byte[] ciphertext, CancellationToken cancellationToken = default) =>
            Decrypt(new DecryptParameters(algorithm, ciphertext), cancellationToken);

        /// <summary>
        /// Decrypts ciphertext.
        /// </summary>
        /// <param name="decryptParameters">A <see cref="DecryptParameters"/> containing the data to decrypt and other parameters for algorithm-dependent decryption.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to cancel the operation.</param>
        /// <returns>
        /// The result of the decrypt operation. The returned <see cref="DecryptResult"/> contains the encrypted data
        /// along with information regarding the algorithm and key used to decrypt it.
        /// </returns>
        /// <exception cref="ArgumentException">The specified algorithm does not match the key corresponding to the key identifier.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="decryptParameters"/> is null.</exception>
        /// <exception cref="CryptographicException">The local cryptographic provider threw an exception.</exception>
        /// <exception cref="InvalidOperationException">The key is invalid for the current operation.</exception>
        /// <exception cref="NotSupportedException">The operation is not supported with the specified key.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<DecryptResult> DecryptAsync(DecryptParameters decryptParameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(decryptParameters, nameof(decryptParameters));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CryptographyClient)}.{nameof(Decrypt)}");
            scope.AddAttribute(OTelKeyIdKey, _keyId);
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
                        result = await _provider.DecryptAsync(decryptParameters, cancellationToken).ConfigureAwait(false);
                    }
                    catch (CryptographicException ex) when (_provider.CanRemote)
                    {
                        // Use the non-async name as we do for scope.
                        KeysEventSource.Singleton.CryptographicException(nameof(Decrypt), ex);
                    }
                }

                if (result is null)
                {
                    ThrowIfLocalOnly(nameof(Decrypt));

                    result = await _remoteProvider.DecryptAsync(decryptParameters, cancellationToken).ConfigureAwait(false);
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
        /// <param name="decryptParameters">A <see cref="DecryptParameters"/> containing the data to decrypt and other parameters for algorithm-dependent decryption.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to cancel the operation.</param>
        /// <returns>
        /// The result of the decrypt operation. The returned <see cref="DecryptResult"/> contains the encrypted data
        /// along with information regarding the algorithm and key used to decrypt it.
        /// </returns>
        /// <exception cref="ArgumentException">The specified algorithm does not match the key corresponding to the key identifier.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="decryptParameters"/> is null.</exception>
        /// <exception cref="CryptographicException">The local cryptographic provider threw an exception.</exception>
        /// <exception cref="InvalidOperationException">The key is invalid for the current operation.</exception>
        /// <exception cref="NotSupportedException">The operation is not supported with the specified key.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual DecryptResult Decrypt(DecryptParameters decryptParameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(decryptParameters, nameof(decryptParameters));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CryptographyClient)}.{nameof(Decrypt)}");
            scope.AddAttribute(OTelKeyIdKey, _keyId);
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
                        result = _provider.Decrypt(decryptParameters, cancellationToken);
                    }
                    catch (CryptographicException ex) when (_provider.CanRemote)
                    {
                        KeysEventSource.Singleton.CryptographicException(nameof(Decrypt), ex);
                    }
                }

                if (result is null)
                {
                    ThrowIfLocalOnly(nameof(Decrypt));

                    result = _remoteProvider.Decrypt(decryptParameters, cancellationToken);
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
            scope.AddAttribute(OTelKeyIdKey, _keyId);
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
                    catch (CryptographicException ex) when (_provider.CanRemote)
                    {
                        // Use the non-async name as we do for scope.
                        KeysEventSource.Singleton.CryptographicException(nameof(WrapKey), ex);
                    }
                }

                if (result is null)
                {
                    ThrowIfLocalOnly(nameof(WrapKey));

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
            scope.AddAttribute(OTelKeyIdKey, _keyId);
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
                    catch (CryptographicException ex) when (_provider.CanRemote)
                    {
                        KeysEventSource.Singleton.CryptographicException(nameof(WrapKey), ex);
                    }
                }

                if (result is null)
                {
                    ThrowIfLocalOnly(nameof(WrapKey));

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
            scope.AddAttribute(OTelKeyIdKey, _keyId);
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
                    catch (CryptographicException ex) when (_provider.CanRemote)
                    {
                        // Use the non-async name as we do for scope.
                        KeysEventSource.Singleton.CryptographicException(nameof(UnwrapKey), ex);
                    }
                }

                if (result is null)
                {
                    ThrowIfLocalOnly(nameof(UnwrapKey));

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
            scope.AddAttribute(OTelKeyIdKey, _keyId);
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
                    catch (CryptographicException ex) when (_provider.CanRemote)
                    {
                        KeysEventSource.Singleton.CryptographicException(nameof(UnwrapKey), ex);
                    }
                }

                if (result is null)
                {
                    ThrowIfLocalOnly(nameof(UnwrapKey));

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
        /// <param name="digest">The pre-hashed digest to sign. The hash algorithm used to compute the digest must be compatible with the specified algorithm.</param>
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
            scope.AddAttribute(OTelKeyIdKey, _keyId);
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
                    catch (CryptographicException ex) when (_provider.CanRemote)
                    {
                        // Use the non-async name as we do for scope.
                        KeysEventSource.Singleton.CryptographicException(nameof(Sign), ex);
                    }
                }

                if (result is null)
                {
                    ThrowIfLocalOnly(nameof(Sign));

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
        /// <param name="digest">The pre-hashed digest to sign. The hash algorithm used to compute the digest must be compatible with the specified algorithm.</param>
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
            scope.AddAttribute(OTelKeyIdKey, _keyId);
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
                    catch (CryptographicException ex) when (_provider.CanRemote)
                    {
                        KeysEventSource.Singleton.CryptographicException(nameof(Sign), ex);
                    }
                }

                if (result is null)
                {
                    ThrowIfLocalOnly(nameof(Sign));

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
        /// <param name="digest">The pre-hashed digest corresponding to the signature. The hash algorithm used to compute the digest must be compatible with the specified algorithm.</param>
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
            scope.AddAttribute(OTelKeyIdKey, _keyId);
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
                    catch (CryptographicException ex) when (_provider.CanRemote)
                    {
                        // Use the non-async name as we do for scope.
                        KeysEventSource.Singleton.CryptographicException(nameof(Verify), ex);
                    }
                }

                if (result is null)
                {
                    ThrowIfLocalOnly(nameof(Verify));

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
        /// <param name="digest">The pre-hashed digest corresponding to the signature. The hash algorithm used to compute the digest must be compatible with the specified algorithm.</param>
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
            scope.AddAttribute(OTelKeyIdKey, _keyId);
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
                    catch (CryptographicException ex) when (_provider.CanRemote)
                    {
                        KeysEventSource.Singleton.CryptographicException(nameof(Verify), ex);
                    }
                }

                if (result is null)
                {
                    ThrowIfLocalOnly(nameof(Verify));

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
        /// <remarks>
        /// The hash algorithm used to compute the digest is derived from the specified algorithm:
        /// <list type="bullet">
        ///   <item>
        ///     <term><see cref="SHA256"/></term>
        ///     <description><see cref="SignatureAlgorithm.ES256"/>, <see cref="SignatureAlgorithm.ES256K"/>, <see cref="SignatureAlgorithm.PS256"/>, <see cref="SignatureAlgorithm.RS256"/></description>
        ///   </item>
        ///   <item>
        ///     <term><see cref="SHA384"/></term>
        ///     <description><see cref="SignatureAlgorithm.ES384"/>, <see cref="SignatureAlgorithm.PS384"/>, <see cref="SignatureAlgorithm.RS384"/></description>
        ///   </item>
        ///   <item>
        ///     <term><see cref="SHA512"/></term>
        ///     <description><see cref="SignatureAlgorithm.ES512"/>, <see cref="SignatureAlgorithm.PS512"/>, <see cref="SignatureAlgorithm.RS512"/></description>
        ///   </item>
        /// </list>
        /// </remarks>
        /// <exception cref="ArgumentException">The specified <paramref name="algorithm"/> does not match the key corresponding to the key identifier.</exception>
        /// <exception cref="CryptographicException">The local cryptographic provider threw an exception.</exception>
        /// <exception cref="InvalidOperationException">The key is invalid for the current operation.</exception>
        /// <exception cref="NotSupportedException">The operation is not supported with the specified key.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<SignResult> SignDataAsync(SignatureAlgorithm algorithm, byte[] data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CryptographyClient)}.{nameof(SignData)}");
            scope.AddAttribute(OTelKeyIdKey, _keyId);
            scope.Start();

            try
            {
                byte[] digest = CreateDigest(algorithm, data, nameof(SignData));

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
                    catch (CryptographicException ex) when (_provider.CanRemote)
                    {
                        // Use the non-async name as we do for scope.
                        KeysEventSource.Singleton.CryptographicException(nameof(SignData), ex);
                    }
                }

                if (result is null)
                {
                    ThrowIfLocalOnly(nameof(SignData));

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
        /// <remarks>
        /// The hash algorithm used to compute the digest is derived from the specified algorithm:
        /// <list type="bullet">
        ///   <item>
        ///     <term><see cref="SHA256"/></term>
        ///     <description><see cref="SignatureAlgorithm.ES256"/>, <see cref="SignatureAlgorithm.ES256K"/>, <see cref="SignatureAlgorithm.PS256"/>, <see cref="SignatureAlgorithm.RS256"/></description>
        ///   </item>
        ///   <item>
        ///     <term><see cref="SHA384"/></term>
        ///     <description><see cref="SignatureAlgorithm.ES384"/>, <see cref="SignatureAlgorithm.PS384"/>, <see cref="SignatureAlgorithm.RS384"/></description>
        ///   </item>
        ///   <item>
        ///     <term><see cref="SHA512"/></term>
        ///     <description><see cref="SignatureAlgorithm.ES512"/>, <see cref="SignatureAlgorithm.PS512"/>, <see cref="SignatureAlgorithm.RS512"/></description>
        ///   </item>
        /// </list>
        /// </remarks>
        /// <exception cref="ArgumentException">The specified <paramref name="algorithm"/> does not match the key corresponding to the key identifier.</exception>
        /// <exception cref="CryptographicException">The local cryptographic provider threw an exception.</exception>
        /// <exception cref="InvalidOperationException">The key is invalid for the current operation.</exception>
        /// <exception cref="NotSupportedException">The operation is not supported with the specified key.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual SignResult SignData(SignatureAlgorithm algorithm, byte[] data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CryptographyClient)}.{nameof(SignData)}");
            scope.AddAttribute(OTelKeyIdKey, _keyId);
            scope.Start();

            try
            {
                byte[] digest = CreateDigest(algorithm, data, nameof(SignData));

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
                    catch (CryptographicException ex) when (_provider.CanRemote)
                    {
                        // Use the non-async name as we do for scope.
                        KeysEventSource.Singleton.CryptographicException(nameof(SignData), ex);
                    }
                }

                if (result is null)
                {
                    ThrowIfLocalOnly(nameof(SignData));

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
        /// <remarks>
        /// The hash algorithm used to compute the digest is derived from the specified algorithm:
        /// <list type="bullet">
        ///   <item>
        ///     <term><see cref="SHA256"/></term>
        ///     <description><see cref="SignatureAlgorithm.ES256"/>, <see cref="SignatureAlgorithm.ES256K"/>, <see cref="SignatureAlgorithm.PS256"/>, <see cref="SignatureAlgorithm.RS256"/></description>
        ///   </item>
        ///   <item>
        ///     <term><see cref="SHA384"/></term>
        ///     <description><see cref="SignatureAlgorithm.ES384"/>, <see cref="SignatureAlgorithm.PS384"/>, <see cref="SignatureAlgorithm.RS384"/></description>
        ///   </item>
        ///   <item>
        ///     <term><see cref="SHA512"/></term>
        ///     <description><see cref="SignatureAlgorithm.ES512"/>, <see cref="SignatureAlgorithm.PS512"/>, <see cref="SignatureAlgorithm.RS512"/></description>
        ///   </item>
        /// </list>
        /// </remarks>
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
            scope.AddAttribute(OTelKeyIdKey, _keyId);
            scope.Start();

            try
            {
                byte[] digest = CreateDigest(algorithm, data, nameof(SignData));

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
                    catch (CryptographicException ex) when (_provider.CanRemote)
                    {
                        // Use the non-async name as we do for scope.
                        KeysEventSource.Singleton.CryptographicException(nameof(SignData), ex);
                    }
                }

                if (result is null)
                {
                    ThrowIfLocalOnly(nameof(SignData));

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
        /// <remarks>
        /// The hash algorithm used to compute the digest is derived from the specified algorithm:
        /// <list type="bullet">
        ///   <item>
        ///     <term><see cref="SHA256"/></term>
        ///     <description><see cref="SignatureAlgorithm.ES256"/>, <see cref="SignatureAlgorithm.ES256K"/>, <see cref="SignatureAlgorithm.PS256"/>, <see cref="SignatureAlgorithm.RS256"/></description>
        ///   </item>
        ///   <item>
        ///     <term><see cref="SHA384"/></term>
        ///     <description><see cref="SignatureAlgorithm.ES384"/>, <see cref="SignatureAlgorithm.PS384"/>, <see cref="SignatureAlgorithm.RS384"/></description>
        ///   </item>
        ///   <item>
        ///     <term><see cref="SHA512"/></term>
        ///     <description><see cref="SignatureAlgorithm.ES512"/>, <see cref="SignatureAlgorithm.PS512"/>, <see cref="SignatureAlgorithm.RS512"/></description>
        ///   </item>
        /// </list>
        /// </remarks>
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
            scope.AddAttribute(OTelKeyIdKey, _keyId);
            scope.Start();

            try
            {
                byte[] digest = CreateDigest(algorithm, data, nameof(SignData));

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
                    catch (CryptographicException ex) when (_provider.CanRemote)
                    {
                        KeysEventSource.Singleton.CryptographicException(nameof(SignData), ex);
                    }
                }

                if (result is null)
                {
                    ThrowIfLocalOnly(nameof(SignData));

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
        /// <remarks>
        /// The hash algorithm used to compute the digest is derived from the specified algorithm:
        /// <list type="bullet">
        ///   <item>
        ///     <term><see cref="SHA256"/></term>
        ///     <description><see cref="SignatureAlgorithm.ES256"/>, <see cref="SignatureAlgorithm.ES256K"/>, <see cref="SignatureAlgorithm.PS256"/>, <see cref="SignatureAlgorithm.RS256"/></description>
        ///   </item>
        ///   <item>
        ///     <term><see cref="SHA384"/></term>
        ///     <description><see cref="SignatureAlgorithm.ES384"/>, <see cref="SignatureAlgorithm.PS384"/>, <see cref="SignatureAlgorithm.RS384"/></description>
        ///   </item>
        ///   <item>
        ///     <term><see cref="SHA512"/></term>
        ///     <description><see cref="SignatureAlgorithm.ES512"/>, <see cref="SignatureAlgorithm.PS512"/>, <see cref="SignatureAlgorithm.RS512"/></description>
        ///   </item>
        /// </list>
        /// </remarks>
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
            scope.AddAttribute(OTelKeyIdKey, _keyId);
            scope.Start();

            try
            {
                byte[] digest = CreateDigest(algorithm, data, nameof(VerifyData));

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
                    catch (CryptographicException ex) when (_provider.CanRemote)
                    {
                        // Use the non-async name as we do for scope.
                        KeysEventSource.Singleton.CryptographicException(nameof(VerifyData), ex);
                    }
                }

                if (result is null)
                {
                    ThrowIfLocalOnly(nameof(VerifyData));

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
        /// <remarks>
        /// The hash algorithm used to compute the digest is derived from the specified algorithm:
        /// <list type="bullet">
        ///   <item>
        ///     <term><see cref="SHA256"/></term>
        ///     <description><see cref="SignatureAlgorithm.ES256"/>, <see cref="SignatureAlgorithm.ES256K"/>, <see cref="SignatureAlgorithm.PS256"/>, <see cref="SignatureAlgorithm.RS256"/></description>
        ///   </item>
        ///   <item>
        ///     <term><see cref="SHA384"/></term>
        ///     <description><see cref="SignatureAlgorithm.ES384"/>, <see cref="SignatureAlgorithm.PS384"/>, <see cref="SignatureAlgorithm.RS384"/></description>
        ///   </item>
        ///   <item>
        ///     <term><see cref="SHA512"/></term>
        ///     <description><see cref="SignatureAlgorithm.ES512"/>, <see cref="SignatureAlgorithm.PS512"/>, <see cref="SignatureAlgorithm.RS512"/></description>
        ///   </item>
        /// </list>
        /// </remarks>
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
            scope.AddAttribute(OTelKeyIdKey, _keyId);
            scope.Start();

            try
            {
                byte[] digest = CreateDigest(algorithm, data, nameof(VerifyData));

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
                    catch (CryptographicException ex) when (_provider.CanRemote)
                    {
                        KeysEventSource.Singleton.CryptographicException(nameof(VerifyData), ex);
                    }
                }

                if (result is null)
                {
                    ThrowIfLocalOnly(nameof(VerifyData));

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
        /// <remarks>
        /// The hash algorithm used to compute the digest is derived from the specified algorithm:
        /// <list type="bullet">
        ///   <item>
        ///     <term><see cref="SHA256"/></term>
        ///     <description><see cref="SignatureAlgorithm.ES256"/>, <see cref="SignatureAlgorithm.ES256K"/>, <see cref="SignatureAlgorithm.PS256"/>, <see cref="SignatureAlgorithm.RS256"/></description>
        ///   </item>
        ///   <item>
        ///     <term><see cref="SHA384"/></term>
        ///     <description><see cref="SignatureAlgorithm.ES384"/>, <see cref="SignatureAlgorithm.PS384"/>, <see cref="SignatureAlgorithm.RS384"/></description>
        ///   </item>
        ///   <item>
        ///     <term><see cref="SHA512"/></term>
        ///     <description><see cref="SignatureAlgorithm.ES512"/>, <see cref="SignatureAlgorithm.PS512"/>, <see cref="SignatureAlgorithm.RS512"/></description>
        ///   </item>
        /// </list>
        /// </remarks>
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
            scope.AddAttribute(OTelKeyIdKey, _keyId);
            scope.Start();

            try
            {
                byte[] digest = CreateDigest(algorithm, data, nameof(VerifyData));

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
                    catch (CryptographicException ex) when (_provider.CanRemote)
                    {
                        // Use the non-async name as we do for scope.
                        KeysEventSource.Singleton.CryptographicException(nameof(VerifyData), ex);
                    }
                }

                if (result is null)
                {
                    ThrowIfLocalOnly(nameof(VerifyData));

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
        /// <remarks>
        /// The hash algorithm used to compute the digest is derived from the specified algorithm:
        /// <list type="bullet">
        ///   <item>
        ///     <term><see cref="SHA256"/></term>
        ///     <description><see cref="SignatureAlgorithm.ES256"/>, <see cref="SignatureAlgorithm.ES256K"/>, <see cref="SignatureAlgorithm.PS256"/>, <see cref="SignatureAlgorithm.RS256"/></description>
        ///   </item>
        ///   <item>
        ///     <term><see cref="SHA384"/></term>
        ///     <description><see cref="SignatureAlgorithm.ES384"/>, <see cref="SignatureAlgorithm.PS384"/>, <see cref="SignatureAlgorithm.RS384"/></description>
        ///   </item>
        ///   <item>
        ///     <term><see cref="SHA512"/></term>
        ///     <description><see cref="SignatureAlgorithm.ES512"/>, <see cref="SignatureAlgorithm.PS512"/>, <see cref="SignatureAlgorithm.RS512"/></description>
        ///   </item>
        /// </list>
        /// </remarks>
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
            scope.AddAttribute(OTelKeyIdKey, _keyId);
            scope.Start();

            try
            {
                byte[] digest = CreateDigest(algorithm, data, nameof(VerifyData));

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
                    catch (CryptographicException ex) when (_provider.CanRemote)
                    {
                        KeysEventSource.Singleton.CryptographicException(nameof(VerifyData), ex);
                    }
                }

                if (result is null)
                {
                    ThrowIfLocalOnly(nameof(VerifyData));

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
        /// Creates an <see cref="RSA"/> implementation backed by this <see cref="CryptographyClient"/>.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to cancel this operation.</param>
        /// <returns>An <see cref="RSAKeyVault"/> implementation backed by this <see cref="CryptographyClient"/>.</returns>
        /// <remarks>
        /// The <see cref="CryptographyClient"/> will attempt to download the public key synchronously.
        /// </remarks>
        /// <exception cref="InvalidOperationException">This key is not of type <see cref="KeyType.Rsa"/> or <see cref="KeyType.RsaHsm"/>, or one or more key parameters are invalid.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual RSAKeyVault CreateRSA(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CryptographyClient)}.{nameof(CreateRSA)}");
            scope.AddAttribute(OTelKeyIdKey, _keyId);
            scope.Start();

            try
            {
                Initialize(GetOperation, cancellationToken);
                return new RSAKeyVault(this, KeyId, KeyMaterial);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Creates an <see cref="RSA"/> implementation backed by this <see cref="CryptographyClient"/>.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to cancel this operation.</param>
        /// <returns>An <see cref="RSAKeyVault"/> implementation backed by this <see cref="CryptographyClient"/>.</returns>
        /// <remarks>
        /// The <see cref="CryptographyClient"/> will attempt to download the public key asynchronously.
        /// </remarks>
        /// <exception cref="InvalidOperationException">This key is not of type <see cref="KeyType.Rsa"/> or <see cref="KeyType.RsaHsm"/>, or one or more key parameters are invalid.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<RSAKeyVault> CreateRSAAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CryptographyClient)}.{nameof(CreateRSA)}");
            scope.AddAttribute(OTelKeyIdKey, _keyId);
            scope.Start();

            try
            {
                await InitializeAsync(GetOperation, cancellationToken).ConfigureAwait(false);
                return new RSAKeyVault(this, KeyId, KeyMaterial);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private JsonWebKey KeyMaterial => _provider is LocalCryptographyProvider local ? local.KeyMaterial : null;

        private void ThrowIfLocalOnly(string name)
        {
            if (LocalOnly)
            {
                throw LocalCryptographyProvider.CreateOperationNotSupported(name);
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

        internal byte[] CreateDigest(SignatureAlgorithm algorithm, byte[] data, string name)
        {
            try
            {
                using HashAlgorithm hashAlgorithm = algorithm.GetHashAlgorithm();
                return hashAlgorithm.ComputeHash(data);
            }
            catch (InvalidOperationException ex) when (LocalOnly)
            {
                // Normalize the exception thrown when an algorithm is not supported by local providers.
                throw LocalCryptographyProvider.CreateOperationNotSupported(name, ex);
            }
        }

        internal byte[] CreateDigest(SignatureAlgorithm algorithm, Stream data, string name)
        {
            try
            {
                using HashAlgorithm hashAlgorithm = algorithm.GetHashAlgorithm();
                return hashAlgorithm.ComputeHash(data);
            }
            catch (InvalidOperationException ex) when (LocalOnly)
            {
                // Normalize the exception thrown when an algorithm is not supported by local providers.
                throw LocalCryptographyProvider.CreateOperationNotSupported(name, ex);
            }
        }

        private async Task InitializeAsync(string operation, CancellationToken cancellationToken)
        {
            if (_provider != null)
            {
                return;
            }

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CryptographyClient)}.{nameof(Initialize)}");
            scope.AddAttribute(OTelKeyIdKey, _keyId);
            scope.Start();

            try
            {
                Response<KeyVaultKey> key = await _remoteProvider.GetKeyAsync(cancellationToken).ConfigureAwait(false);

                _provider = LocalCryptographyProviderFactory.Create(key.Value);
                if (_provider is null)
                {
                    _provider = _remoteProvider;

                    KeysEventSource.Singleton.KeyTypeNotSupported(operation, key.Value);
                }
            }
            catch (RequestFailedException e) when (e.Status == 403)
            {
                scope.Failed(e);

                _provider = _remoteProvider;

                KeysEventSource.Singleton.GetPermissionDenied(operation, _keyId);
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
            scope.AddAttribute(OTelKeyIdKey, _keyId);
            scope.Start();

            try
            {
                Response<KeyVaultKey> key = _remoteProvider.GetKey(cancellationToken);

                _provider = LocalCryptographyProviderFactory.Create(key.Value);
                if (_provider is null)
                {
                    _provider = _remoteProvider;

                    KeysEventSource.Singleton.KeyTypeNotSupported(operation, key.Value);
                }
            }
            catch (RequestFailedException e) when (e.Status == 403)
            {
                scope.Failed(e);

                _provider = _remoteProvider;

                KeysEventSource.Singleton.GetPermissionDenied(operation, _keyId);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
