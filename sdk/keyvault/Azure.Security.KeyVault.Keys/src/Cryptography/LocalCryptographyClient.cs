// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Cryptography;

#pragma warning disable AZC0015 // Unexpected client method return type.

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    /// <summary>
    /// A client used to perform local cryptographic operations without connecting to Azure Key Vault.
    /// </summary>
    public class LocalCryptographyClient : IKeyEncryptionKey
    {
        private readonly JsonWebKey _jsonWebKey;
        private readonly ICryptographyProvider _provider;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalCryptographyClient"/> class.
        /// </summary>
        /// <param name="jsonWebKey">A <see cref="JsonWebKey"/> used for cryptographic operations.</param>
        /// <exception cref="ArgumentNullException"><paramref name="jsonWebKey"/> is null.</exception>
        /// <exception cref="NotSupportedException">The <paramref name="jsonWebKey"/> has a <see cref="JsonWebKey.KeyType"/> that is not supported.</exception>
#pragma warning disable AZC0007 // DO provide a minimal constructor that takes only the parameters required to connect to the service.
        public LocalCryptographyClient(JsonWebKey jsonWebKey)
        {
            _jsonWebKey = jsonWebKey ?? throw new ArgumentNullException(nameof(jsonWebKey));
            _provider = LocalCryptographyProviderFactory.Create(jsonWebKey, null) ?? throw new NotSupportedException(@$"Key type ""{jsonWebKey.KeyType}"" is not supported");
        }
#pragma warning restore AZC0007 // DO provide a minimal constructor that takes only the parameters required to connect to the service.

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalCryptographyClient"/> class for mocking.
        /// </summary>
        protected LocalCryptographyClient()
        {
        }

        /// <summary>
        /// Gets the <see cref="JsonWebKey.Id"/> of the key used to perform local cryptographic operations for the client.
        /// </summary>
        public string KeyId => _jsonWebKey.Id;

        /// <summary>
        /// Encrypts the specified plaintext.
        /// </summary>
        /// <param name="algorithm">The <see cref="EncryptionAlgorithm"/> to use.</param>
        /// <param name="plaintext">The data to encrypt.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to cancel the operation.</param>
        /// <returns>
        /// The result of the encrypt operation. The returned <see cref="EncryptResult"/> contains the encrypted data
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
        /// The result of the encrypt operation. The returned <see cref="EncryptResult"/> contains the encrypted data
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
        /// The result of the encrypt operation. The returned <see cref="EncryptResult"/> contains the encrypted data
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

            EncryptResult result = null;
            if (_provider.SupportsOperation(KeyOperation.Encrypt))
            {
                result = await _provider.EncryptAsync(options, cancellationToken).ConfigureAwait(false);
            }

            return result ?? throw LocalCryptographyProvider.CreateOperationNotSupported(nameof(KeyOperation.Encrypt));
        }

        /// <summary>
        /// Encrypts plaintext.
        /// </summary>
        /// <param name="options">An <see cref="EncryptOptions"/> containing the data to encrypt and other options for algorithm-dependent encryption.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to cancel the operation.</param>
        /// <returns>
        /// The result of the encrypt operation. The returned <see cref="EncryptResult"/> contains the encrypted data
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

            EncryptResult result = null;
            if (_provider.SupportsOperation(KeyOperation.Encrypt))
            {
                result = _provider.Encrypt(options, cancellationToken);
            }

            return result ?? throw LocalCryptographyProvider.CreateOperationNotSupported(nameof(KeyOperation.Encrypt));
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

            DecryptResult result = null;
            if (_provider.SupportsOperation(KeyOperation.Decrypt))
            {
                result = await _provider.DecryptAsync(options, cancellationToken).ConfigureAwait(false);
            }

            return result ?? throw LocalCryptographyProvider.CreateOperationNotSupported(nameof(KeyOperation.Decrypt));
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

            DecryptResult result = null;
            if (_provider.SupportsOperation(KeyOperation.Decrypt))
            {
                result = _provider.Decrypt(options, cancellationToken);
            }

            return result ?? throw LocalCryptographyProvider.CreateOperationNotSupported(nameof(KeyOperation.Decrypt));
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
        public virtual async Task<WrapResult> WrapKeyAsync(KeyWrapAlgorithm algorithm, byte[] key, CancellationToken cancellationToken = default)
        {
            WrapResult result = null;
            if (_provider.SupportsOperation(KeyOperation.WrapKey))
            {
                result = await _provider.WrapKeyAsync(algorithm, key, cancellationToken).ConfigureAwait(false);
            }

            return result ?? throw LocalCryptographyProvider.CreateOperationNotSupported(nameof(KeyOperation.WrapKey));
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

        public virtual WrapResult WrapKey(KeyWrapAlgorithm algorithm, byte[] key, CancellationToken cancellationToken = default)
        {
            WrapResult result = null;
            if (_provider.SupportsOperation(KeyOperation.WrapKey))
            {
                result = _provider.WrapKey(algorithm, key, cancellationToken);
            }

            return result ?? throw LocalCryptographyProvider.CreateOperationNotSupported(nameof(KeyOperation.WrapKey));
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

        public virtual async Task<UnwrapResult> UnwrapKeyAsync(KeyWrapAlgorithm algorithm, byte[] encryptedKey, CancellationToken cancellationToken = default)
        {
            UnwrapResult result = null;
            if (_provider.SupportsOperation(KeyOperation.UnwrapKey))
            {
                result = await _provider.UnwrapKeyAsync(algorithm, encryptedKey, cancellationToken).ConfigureAwait(false);
            }

            return result ?? throw LocalCryptographyProvider.CreateOperationNotSupported(nameof(KeyOperation.UnwrapKey));
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

        public virtual UnwrapResult UnwrapKey(KeyWrapAlgorithm algorithm, byte[] encryptedKey, CancellationToken cancellationToken = default)
        {
            UnwrapResult result = null;
            if (_provider.SupportsOperation(KeyOperation.UnwrapKey))
            {
                result = _provider.UnwrapKey(algorithm, encryptedKey, cancellationToken);
            }

            return result ?? throw LocalCryptographyProvider.CreateOperationNotSupported(nameof(KeyOperation.UnwrapKey));
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

        public virtual async Task<SignResult> SignAsync(SignatureAlgorithm algorithm, byte[] digest, CancellationToken cancellationToken = default)
        {
            SignResult result = null;
            if (_provider.SupportsOperation(KeyOperation.Sign))
            {
                result = await _provider.SignAsync(algorithm, digest, cancellationToken).ConfigureAwait(false);
            }

            return result ?? throw LocalCryptographyProvider.CreateOperationNotSupported(nameof(KeyOperation.Sign));
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

        public virtual SignResult Sign(SignatureAlgorithm algorithm, byte[] digest, CancellationToken cancellationToken = default)
        {
            SignResult result = null;
            if (_provider.SupportsOperation(KeyOperation.Sign))
            {
                result = _provider.Sign(algorithm, digest, cancellationToken);
            }

            return result ?? throw LocalCryptographyProvider.CreateOperationNotSupported(nameof(KeyOperation.Sign));
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

        public virtual async Task<VerifyResult> VerifyAsync(SignatureAlgorithm algorithm, byte[] digest, byte[] signature, CancellationToken cancellationToken = default)
        {
            VerifyResult result = null;
            if (_provider.SupportsOperation(KeyOperation.Verify))
            {
                result = await _provider.VerifyAsync(algorithm, digest, signature, cancellationToken).ConfigureAwait(false);
            }

            return result ?? throw LocalCryptographyProvider.CreateOperationNotSupported(nameof(KeyOperation.Verify));
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

        public virtual VerifyResult Verify(SignatureAlgorithm algorithm, byte[] digest, byte[] signature, CancellationToken cancellationToken = default)
        {
            VerifyResult result = null;
            if (_provider.SupportsOperation(KeyOperation.Verify))
            {
                result = _provider.Verify(algorithm, digest, signature, cancellationToken);
            }

            return result ?? throw LocalCryptographyProvider.CreateOperationNotSupported(nameof(KeyOperation.Verify));
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

        public virtual async Task<SignResult> SignDataAsync(SignatureAlgorithm algorithm, byte[] data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            SignResult result = null;
            if (_provider.SupportsOperation(KeyOperation.Sign))
            {
                byte[] digest = CryptographyClient.CreateDigest(algorithm, data);
                result = await _provider.SignAsync(algorithm, digest,  cancellationToken).ConfigureAwait(false);
            }

            return result ?? throw LocalCryptographyProvider.CreateOperationNotSupported(nameof(KeyOperation.Sign));
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

        public virtual SignResult SignData(SignatureAlgorithm algorithm, byte[] data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            SignResult result = null;
            if (_provider.SupportsOperation(KeyOperation.Sign))
            {
                byte[] digest = CryptographyClient.CreateDigest(algorithm, data);
                result = _provider.Sign(algorithm, digest, cancellationToken);
            }

            return result ?? throw LocalCryptographyProvider.CreateOperationNotSupported(nameof(KeyOperation.Sign));
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

        public virtual async Task<SignResult> SignDataAsync(SignatureAlgorithm algorithm, Stream data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            SignResult result = null;
            if (_provider.SupportsOperation(KeyOperation.Sign))
            {
                byte[] digest = CryptographyClient.CreateDigest(algorithm, data);
                result = await _provider.SignAsync(algorithm, digest, cancellationToken).ConfigureAwait(false);
            }

            return result ?? throw LocalCryptographyProvider.CreateOperationNotSupported(nameof(KeyOperation.Sign));
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

        public virtual SignResult SignData(SignatureAlgorithm algorithm, Stream data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            SignResult result = null;
            if (_provider.SupportsOperation(KeyOperation.Sign))
            {
                byte[] digest = CryptographyClient.CreateDigest(algorithm, data);
                result = _provider.Sign(algorithm, digest, cancellationToken);
            }

            return result ?? throw LocalCryptographyProvider.CreateOperationNotSupported(nameof(KeyOperation.Sign));
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

        public virtual async Task<VerifyResult> VerifyDataAsync(SignatureAlgorithm algorithm, byte[] data, byte[] signature, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            VerifyResult result = null;
            if (_provider.SupportsOperation(KeyOperation.Verify))
            {
                byte[] digest = CryptographyClient.CreateDigest(algorithm, data);
                result = await _provider.VerifyAsync(algorithm, digest, signature, cancellationToken).ConfigureAwait(false);
            }

            return result ?? throw LocalCryptographyProvider.CreateOperationNotSupported(nameof(KeyOperation.Verify));
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

        public virtual VerifyResult VerifyData(SignatureAlgorithm algorithm, byte[] data, byte[] signature, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            VerifyResult result = null;
            if (_provider.SupportsOperation(KeyOperation.Verify))
            {
                byte[] digest = CryptographyClient.CreateDigest(algorithm, data);
                result = _provider.Verify(algorithm, digest, signature, cancellationToken);
            }

            return result ?? throw LocalCryptographyProvider.CreateOperationNotSupported(nameof(KeyOperation.Verify));
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

        public virtual async Task<VerifyResult> VerifyDataAsync(SignatureAlgorithm algorithm, Stream data, byte[] signature, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            VerifyResult result = null;
            if (_provider.SupportsOperation(KeyOperation.Verify))
            {
                byte[] digest = CryptographyClient.CreateDigest(algorithm, data);
                result = await _provider.VerifyAsync(algorithm, digest, signature, cancellationToken).ConfigureAwait(false);
            }

            return result ?? throw LocalCryptographyProvider.CreateOperationNotSupported(nameof(KeyOperation.Verify));
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

        public virtual VerifyResult VerifyData(SignatureAlgorithm algorithm, Stream data, byte[] signature, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            VerifyResult result = null;
            if (_provider.SupportsOperation(KeyOperation.Verify))
            {
                byte[] digest = CryptographyClient.CreateDigest(algorithm, data);
                result = _provider.Verify(algorithm, digest, signature, cancellationToken);
            }

            return result ?? throw LocalCryptographyProvider.CreateOperationNotSupported(nameof(KeyOperation.Verify));
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
    }
}
