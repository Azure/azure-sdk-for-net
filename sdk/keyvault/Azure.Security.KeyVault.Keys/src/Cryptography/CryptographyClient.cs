// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Azure.Core;
using Azure.Core.Pipeline;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    /// <summary>
    /// A client used to perform cryptographic operations with Azure Key Vault keys 
    /// </summary>
    public class CryptographyClient
    {
        private readonly Uri _keyId;
        private readonly ICryptographyProvider _cryptoProvider;
        private HttpPipeline _pipeline;

        /// <summary>
        /// Protected cosntructor for mocking
        /// </summary>
        protected CryptographyClient()
        {

        }

        /// <summary>
        /// Initializes a new instance of the CryptographyClient class.
        /// </summary>
        /// <param name="keyId">The <see cref="KeyBase.Id"/> of the <see cref="Key"/> which will be used for cryptographic operations</param>
        /// <param name="credential">Represents a credential capable of providing an OAuth token.</param>
        public CryptographyClient(Uri keyId, TokenCredential credential)
            : this(keyId, credential, null)
        {

        }

        /// <summary>
        /// Initializes a new instance of the CryptographyClient class.
        /// </summary>
        /// <param name="keyId">The <see cref="KeyBase.Id"/> of the <see cref="Key"/> which will be used for cryptographic operations</param>
        /// <param name="credential">Represents a credential capable of providing an OAuth token.</param>
        /// <param name="options">Options that allow to configure the management of the request sent to Key Vault.</param>
        public CryptographyClient(Uri keyId, TokenCredential credential, CryptographyClientOptions options)
        {
            _keyId = keyId ?? throw new ArgumentNullException(nameof(keyId));

            if (credential == null) throw new ArgumentNullException(nameof(credential));

            options ??= new CryptographyClientOptions();

            var remoteProvider = new RemoteCryptographyClient(keyId, credential, options);

            _pipeline = remoteProvider.Pipeline;

            _cryptoProvider = remoteProvider;
        }

        /// <summary>
        /// Encrypts the specified plain text.
        /// </summary>
        /// <param name="algorithm">The algorithm to use</param>
        /// <param name="plaintext">The data to encrypt</param>
        /// <param name="iv">
        /// The initialization vector. This should only be specified when using symmetric encryption algorithms, 
        /// otherwise the caller must omit the parameter or pass null.
        /// </param>
        /// <param name="authenticationData">
        /// The authentication data. This should only be specified when using authenticated symmetric encryption algorithms,
        /// otherwise the caller must omit the parameter or pass null.
        /// </param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>
        /// The result of the encrypt operation. The returned <see cref="EncryptResult"/> contains the encrypted data 
        /// along with all other information needed to decrypt it. This information should be stored with the encrypted data.
        /// </returns>
        public virtual async Task<EncryptResult> EncryptAsync(EncryptionAlgorithm algorithm, byte[] plaintext, byte[] iv = default, byte[] authenticationData = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient.Encrypt");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                return await _cryptoProvider.EncryptAsync(algorithm, plaintext, iv, authenticationData, cancellationToken).ConfigureAwait(false);
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
        /// <param name="algorithm">The algorithm to use</param>
        /// <param name="plaintext">The data to encrypt</param>
        /// <param name="iv">
        /// The initialization vector. This should only be specified when using symmetric encryption algorithms, 
        /// otherwise the caller must omit the parameter or pass null.
        /// </param>
        /// <param name="authenticationData">
        /// The authentication data. This should only be specified when using authenticated symmetric encryption algorithms,
        /// otherwise the caller must omit the parameter or pass null.
        /// </param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>
        /// The result of the encrypt operation. The returned <see cref="EncryptResult"/> contains the encrypted data 
        /// along with all other information needed to decrypt it. This information should be stored with the encrypted data.
        /// </returns>
        public virtual EncryptResult Encrypt(EncryptionAlgorithm algorithm, byte[] plaintext, byte[] iv = default, byte[] authenticationData = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient.Encrypt");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                return _cryptoProvider.Encrypt(algorithm, plaintext, iv, authenticationData, cancellationToken);
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
        /// <param name="algorithm">The algorithm to use</param>
        /// <param name="ciphertext">The encrypted data to decrypt</param>
        /// <param name="iv">
        /// The initialization vector. This should only be specified when using symmetric encryption algorithms, 
        /// otherwise the caller must omit the parameter or pass null.
        /// </param>
        /// <param name="authenticationData">
        /// The authentication data. This should only be specified when using authenticated symmetric encryption algorithms,
        /// otherwise the caller must omit the parameter or pass null.
        /// </param>
        /// <param name="authenticationTag">The authentication tag. This should only be specified when using authenticated 
        /// symmetric encryption algorithms, otherwise the caller must omit the parameter or pass null.
        /// </param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>
        /// The result of the decrypt operation. The returned <see cref="DecryptResult"/> contains the encrypted data 
        /// along with information regarding the algorithm and key used to decrypt it.
        /// </returns>
        public virtual async Task<DecryptResult> DecryptAsync(EncryptionAlgorithm algorithm, byte[] ciphertext, byte[] iv = default, byte[] authenticationData = default, byte[] authenticationTag = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient.Decrypt");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                return await _cryptoProvider.DecryptAsync(algorithm, ciphertext, iv, authenticationData, authenticationTag, cancellationToken).ConfigureAwait(false);
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
        /// <param name="algorithm">The algorithm to use</param>
        /// <param name="ciphertext">The encrypted data to decrypt</param>
        /// <param name="iv">
        /// The initialization vector. This should only be specified when using symmetric encryption algorithms, 
        /// otherwise the caller must omit the parameter or pass null.
        /// </param>
        /// <param name="authenticationData">
        /// The authentication data. This should only be specified when using authenticated symmetric encryption algorithms,
        /// otherwise the caller must omit the parameter or pass null.
        /// </param>
        /// <param name="authenticationTag">The authentication tag. This should only be specified when using authenticated 
        /// symmetric encryption algorithms, otherwise the caller must omit the parameter or pass null.
        /// </param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>
        /// The result of the decrypt operation. The returned <see cref="DecryptResult"/> contains the encrypted data 
        /// along with information regarding the algorithm and key used to decrypt it.
        /// </returns>
        public virtual DecryptResult Decrypt(EncryptionAlgorithm algorithm, byte[] ciphertext, byte[] iv = default, byte[] authenticationData = default, byte[] authenticationTag = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient.Decrypt");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                return _cryptoProvider.Decrypt(algorithm, ciphertext, iv, authenticationData, authenticationTag, cancellationToken);
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
        /// <param name="key">The key material to encrypt</param>
        /// <param name="algorithm">The algorithm to use</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>
        /// The result of the wrap operation. The returned <see cref="WrapResult"/> contains the wrapped key 
        /// along with all other information needed to unwrap it. This information should be stored with the wrapped key.
        /// </returns>
        public virtual async Task<WrapResult> WrapKeyAsync(KeyWrapAlgorithm algorithm, byte[] key, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient.WrapKey");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                return await _cryptoProvider.WrapKeyAsync(algorithm, key, cancellationToken).ConfigureAwait(false);
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
        /// <param name="key">The key material to encrypt</param>
        /// <param name="algorithm">The algorithm to use</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>
        /// The result of the wrap operation. The returned <see cref="WrapResult"/> contains the wrapped key 
        /// along with all other information needed to unwrap it. This information should be stored with the wrapped key.
        /// </returns>
        public virtual WrapResult WrapKey(KeyWrapAlgorithm algorithm, byte[] key, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient.WrapKey");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                return _cryptoProvider.WrapKey(algorithm, key, cancellationToken);
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
        /// <param name="encryptedKey">The encrypted key material</param>
        /// <param name="algorithm">The algorithm to use</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>
        /// The result of the unwrap operation. The returned <see cref="UnwrapResult"/> contains the key 
        /// along with information regarding the algorithm and key used to unwrap it.
        /// </returns>
        public virtual async Task<UnwrapResult> UnwrapKeyAsync(KeyWrapAlgorithm algorithm, byte[] encryptedKey, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient.UnwrapKey");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                return await _cryptoProvider.UnwrapKeyAsync(algorithm, encryptedKey, cancellationToken).ConfigureAwait(false);
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
        /// <param name="encryptedKey">The encrypted key material</param>
        /// <param name="algorithm">The algorithm to use</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>
        /// The result of the unwrap operation. The returned <see cref="UnwrapResult"/> contains the key 
        /// along with information regarding the algorithm and key used to unwrap it.
        /// </returns>
        public virtual UnwrapResult UnwrapKey(KeyWrapAlgorithm algorithm, byte[] encryptedKey, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient.UnwrapKey");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                return _cryptoProvider.UnwrapKey(algorithm, encryptedKey, cancellationToken);
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
        /// <param name="digest">The pre-hashed digest to sign. The hash algorithm used to compute the digest must be compatable with the specified algorithm.</param>
        /// <param name="algorithm">The signing algorithm to use</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>
        /// The result of the sign operation. The returned <see cref="SignResult"/> contains the signature 
        /// along with all other information needed to verify it. This information should be stored with the signature.
        /// </returns>
        public virtual async Task<SignResult> SignAsync(SignatureAlgorithm algorithm, byte[] digest, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient.Sign");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                return await _cryptoProvider.SignAsync(algorithm, digest, cancellationToken).ConfigureAwait(false);
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
        /// <param name="digest">The pre-hashed digest to sign. The hash algorithm used to compute the digest must be compatable with the specified algorithm.</param>
        /// <param name="algorithm">The signing algorithm to use</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>
        /// The result of the sign operation. The returned <see cref="SignResult"/> contains the signature 
        /// along with all other information needed to verify it. This information should be stored with the signature.
        /// </returns>
        public virtual SignResult Sign(SignatureAlgorithm algorithm, byte[] digest, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient.Sign");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                return _cryptoProvider.Sign(algorithm, digest, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Verifies the specified signature
        /// </summary>
        /// <param name="digest">The pre-hashed digest corresponding to the signature. The hash algorithm used to compute the digest must be compatable with the specified algorithm.</param>
        /// <param name="signature">The signature to verify</param>
        /// <param name="algorithm">The signature algorithm to use. This must be the same algorithm used to sign the digest.</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>
        /// The result of the verify operation. If the signature is valid the <see cref="VerifyResult.IsValid"/> property of the returned <see cref="VerifyResult"/> will be set to true.
        /// </returns>
        public virtual async Task<VerifyResult> VerifyAsync(SignatureAlgorithm algorithm, byte[] digest, byte[] signature, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient.Verify");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                return await _cryptoProvider.VerifyAsync(algorithm, digest, signature, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Verifies the specified signature
        /// </summary>
        /// <param name="digest">The pre-hashed digest corresponding to the signature. The hash algorithm used to compute the digest must be compatable with the specified algorithm.</param>
        /// <param name="signature">The signature to verify</param>
        /// <param name="algorithm">The signature algorithm to use. This must be the same algorithm used to sign the digest.</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>
        /// The result of the verify operation. If the signature is valid the <see cref="VerifyResult.IsValid"/> property of the returned <see cref="VerifyResult"/> will be set to true.
        /// </returns>
        public virtual VerifyResult Verify(SignatureAlgorithm algorithm, byte[] digest, byte[] signature, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient.Verify");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                return _cryptoProvider.Verify(algorithm, digest, signature, cancellationToken);
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
        /// <param name="data">The data to sign.</param>
        /// <param name="algorithm">The signing algorithm to use</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>
        /// The result of the sign operation. The returned <see cref="SignResult"/> contains the signature 
        /// along with all other information needed to verify it. This information should be stored with the signature.
        /// </returns>
        public virtual async Task<SignResult> SignDataAsync(SignatureAlgorithm algorithm, byte[] data, CancellationToken cancellationToken = default)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient.SignData");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                byte[] digest = CreateDigest(algorithm, data);

            return await _cryptoProvider.SignAsync(algorithm, digest, cancellationToken).ConfigureAwait(false);
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
        /// <param name="data">The data to sign.</param>
        /// <param name="algorithm">The signing algorithm to use</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>
        /// The result of the sign operation. The returned <see cref="SignResult"/> contains the signature 
        /// along with all other information needed to verify it. This information should be stored with the signature.
        /// </returns>
        public virtual SignResult SignData(SignatureAlgorithm algorithm, byte[] data, CancellationToken cancellationToken = default)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient.SignData");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                byte[] digest = CreateDigest(algorithm, data);

            return _cryptoProvider.Sign(algorithm, digest, cancellationToken);
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
        /// <param name="data">The data to sign.</param>
        /// <param name="algorithm">The signing algorithm to use</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>
        /// The result of the sign operation. The returned <see cref="SignResult"/> contains the signature 
        /// along with all other information needed to verify it. This information should be stored with the signature.
        /// </returns>
        public virtual async Task<SignResult> SignDataAsync(SignatureAlgorithm algorithm, Stream data, CancellationToken cancellationToken = default)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient.SignData");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                byte[] digest = CreateDigest(algorithm, data);

            return await _cryptoProvider.SignAsync(algorithm, digest, cancellationToken).ConfigureAwait(false);
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
        /// <param name="data">The data to sign.</param>
        /// <param name="algorithm">The signing algorithm to use</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>
        /// The result of the sign operation. The returned <see cref="SignResult"/> contains the signature 
        /// along with all other information needed to verify it. This information should be stored with the signature.
        /// </returns>
        public virtual SignResult SignData(SignatureAlgorithm algorithm, Stream data, CancellationToken cancellationToken = default)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient.SignData");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                byte[] digest = CreateDigest(algorithm, data);

            return _cryptoProvider.Sign(algorithm, digest, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Verifies the specified signature
        /// </summary>
        /// <param name="data">The data corresponding to the signature.</param>
        /// <param name="signature">The signature to verify</param>
        /// <param name="algorithm">The signature algorithm to use. This must be the same algorithm used to sign the data.</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>
        /// The result of the verify operation. If the signature is valid the <see cref="VerifyResult.IsValid"/> property of the returned <see cref="VerifyResult"/> will be set to true.
        /// </returns>
        public virtual async Task<VerifyResult> VerifyDataAsync(SignatureAlgorithm algorithm, byte[] data, byte[] signature, CancellationToken cancellationToken = default)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient.VerifyData");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                byte[] digest = CreateDigest(algorithm, data);

            return await _cryptoProvider.VerifyAsync(algorithm, digest, signature, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Verifies the specified signature
        /// </summary>
        /// <param name="data">The data corresponding to the signature.</param>
        /// <param name="signature">The signature to verify</param>
        /// <param name="algorithm">The signature algorithm to use. This must be the same algorithm used to sign the data.</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>
        /// The result of the verify operation. If the signature is valid the <see cref="VerifyResult.IsValid"/> property of the returned <see cref="VerifyResult"/> will be set to true.
        /// </returns>
        public virtual VerifyResult VerifyData(SignatureAlgorithm algorithm, byte[] data, byte[] signature, CancellationToken cancellationToken = default)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient.VerifyData");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                byte[] digest = CreateDigest(algorithm, data);

            return _cryptoProvider.Verify(algorithm, digest, signature, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Verifies the specified signature
        /// </summary>
        /// <param name="data">The data corresponding to the signature.</param>
        /// <param name="signature">The signature to verify</param>
        /// <param name="algorithm">The signature algorithm to use. This must be the same algorithm used to sign the data.</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>
        /// The result of the verify operation. If the signature is valid the <see cref="VerifyResult.IsValid"/> property of the returned <see cref="VerifyResult"/> will be set to true.
        /// </returns>
        public virtual async Task<VerifyResult> VerifyDataAsync(SignatureAlgorithm algorithm, Stream data, byte[] signature, CancellationToken cancellationToken = default)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient.VerifyData");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                byte[] digest = CreateDigest(algorithm, data);

            return await _cryptoProvider.VerifyAsync(algorithm, digest, signature, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Verifies the specified signature
        /// </summary>
        /// <param name="data">The data corresponding to the signature.</param>
        /// <param name="signature">The signature to verify</param>
        /// <param name="algorithm">The signature algorithm to use. This must be the same algorithm used to sign the data.</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>
        /// The result of the verify operation. If the signature is valid the <see cref="VerifyResult.IsValid"/> property of the returned <see cref="VerifyResult"/> will be set to true.
        /// </returns>
        public virtual VerifyResult VerifyData(SignatureAlgorithm algorithm, Stream data, byte[] signature, CancellationToken cancellationToken = default)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient.VerifyData");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                byte[] digest = CreateDigest(algorithm, data);

            return _cryptoProvider.Verify(algorithm, digest, signature, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private static byte[] CreateDigest(SignatureAlgorithm algorithm, byte[] data)
        {
            using(HashAlgorithm hashAlgo = algorithm.GetHashAlgorithm())
            {
                return hashAlgo.ComputeHash(data);
            }
        }

        private static byte[] CreateDigest(SignatureAlgorithm algorithm, Stream data)
        {
            using (HashAlgorithm hashAlgo = algorithm.GetHashAlgorithm())
            {
                return hashAlgo.ComputeHash(data);
            }
        }
    }
}
