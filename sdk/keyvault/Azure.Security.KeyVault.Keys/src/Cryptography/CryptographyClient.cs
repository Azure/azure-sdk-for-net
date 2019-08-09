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
    /// A client used to perform cryptographic operations with 
    /// </summary>
    public class CryptographyClient
    {
        private Uri _keyId;
        private ICryptographyProvider _cryptoProvider;
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
        /// <param name="keyId">And endpoint URL for an Azure Key Vault key</param>
        /// <param name="credential">Represents a credential capable of providing an OAuth token.</param>
        public CryptographyClient(Uri keyId, TokenCredential credential)
            : this(keyId, credential, null)
        {

        }

        /// <summary>
        /// Initializes a new instance of the CryptographyClient class.
        /// </summary>
        /// <param name="keyId">Endpoint URL for the Azure Key</param>
        /// <param name="credential">Represents a credential capable of providing an OAuth token.</param>
        /// <param name="options">Options that allow to configure the management of the request sent to Key Vault.</param>
        public CryptographyClient(Uri keyId, TokenCredential credential, CryptographyClientOptions options)
        {
            _keyId = keyId ?? throw new ArgumentNullException(nameof(keyId));

            if (credential == null) throw new ArgumentNullException(nameof(credential));

            var remoteProvider = new RemoteCryptographyClient(keyId, credential, options);

            _pipeline = remoteProvider.Pipeline;

            _cryptoProvider = remoteProvider;
        }

        /// <summary>
        /// Encrypts the specified plain text.
        /// </summary>
        /// <param name="algorithm">The algorithm to use</param>
        /// <param name="plaintext">The plain text to encrypt</param>
        /// <param name="iv">The initialization vector</param>
        /// <param name="authenticationData">The authentication data</param>
        /// <param name="cancellationToken">Cancellation token</param>
        public virtual async Task<EncryptResult> EncryptAsync(EncryptionAlgorithm algorithm, byte[] plaintext, byte[] iv = default, byte[] authenticationData = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient.Encrypt");
            scope.AddAttribute("key", _keyId.ToString());
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
        /// <param name="plaintext">The plain text to encrypt</param>
        /// <param name="iv">The initialization vector</param>
        /// <param name="authenticationData">The authentication data</param>
        /// <param name="cancellationToken">Cancellation token</param>
        public virtual EncryptResult Encrypt(EncryptionAlgorithm algorithm, byte[] plaintext, byte[] iv = default, byte[] authenticationData = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient.Encrypt");
            scope.AddAttribute("key", _keyId.ToString());
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
        /// <param name="ciphertext">The cipher text to decrypt</param>
        /// <param name="iv">The initialization vector</param>
        /// <param name="authenticationData">The authentication data</param>
        /// <param name="authenticationTag">The authentication tag</param>
        /// <param name="cancellationToken">Cancellation token</param>
        public virtual async Task<DecryptResult> DecryptAsync(EncryptionAlgorithm algorithm, byte[] ciphertext, byte[] iv = default, byte[] authenticationData = default, byte[] authenticationTag = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient.Decrypt");
            scope.AddAttribute("key", _keyId.ToString());
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
        /// <param name="ciphertext">The cipher text to decrypt</param>
        /// <param name="iv">The initialization vector</param>
        /// <param name="authenticationData">The authentication data</param>
        /// <param name="authenticationTag">The authentication tag</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        public virtual DecryptResult Decrypt(EncryptionAlgorithm algorithm, byte[] ciphertext, byte[] iv = default, byte[] authenticationData = default, byte[] authenticationTag = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient.Decrypt");
            scope.AddAttribute("key", _keyId.ToString());
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
        public virtual async Task<WrapResult> WrapKeyAsync(KeyWrapAlgorithm algorithm, byte[] key, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient.WrapKey");
            scope.AddAttribute("key", _keyId.ToString());
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
        public virtual WrapResult WrapKey(KeyWrapAlgorithm algorithm, byte[] key, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient.WrapKey");
            scope.AddAttribute("key", _keyId.ToString());
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
        /// <param name="algorithm"></param>
        /// <param name="encryptedKey"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<UnwrapResult> UnwrapKeyAsync(KeyWrapAlgorithm algorithm, byte[] encryptedKey, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient.UnwrapKey");
            scope.AddAttribute("key", _keyId.ToString());
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
        public virtual UnwrapResult UnwrapKey(KeyWrapAlgorithm algorithm, byte[] encryptedKey, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient.UnwrapKey");
            scope.AddAttribute("key", _keyId.ToString());
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
        /// <param name="digest">The digest to sign</param>
        /// <param name="algorithm">The algorithm to use</param>
        /// <param name="cancellationToken">Cancellation token</param>
        public virtual async Task<SignResult> SignAsync(SignatureAlgorithm algorithm, byte[] digest, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient.Sign");
            scope.AddAttribute("key", _keyId.ToString());
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
        /// <param name="digest">The digest to sign</param>
        /// <param name="algorithm">The algorithm to use</param>
        /// <param name="cancellationToken">Cancellation token</param>
        public virtual SignResult Sign(SignatureAlgorithm algorithm, byte[] digest, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient.Sign");
            scope.AddAttribute("key", _keyId.ToString());
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
        /// Verifies the specified signature value
        /// </summary>
        /// <param name="digest">The digest</param>
        /// <param name="signature">The signature value</param>
        /// <param name="algorithm">The algorithm to use</param>
        /// <param name="cancellationToken">Cancellation token</param>
        public virtual async Task<VerifyResult> VerifyAsync(SignatureAlgorithm algorithm, byte[] digest, byte[] signature, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient.Verify");
            scope.AddAttribute("key", _keyId.ToString());
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
        /// Verifies the specified signature value
        /// </summary>
        /// <param name="digest">The digest</param>
        /// <param name="signature">The signature value</param>
        /// <param name="algorithm">The algorithm to use</param>
        /// <param name="cancellationToken">Cancellation token</param>
        public virtual VerifyResult Verify(SignatureAlgorithm algorithm, byte[] digest, byte[] signature, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient.Verify");
            scope.AddAttribute("key", _keyId.ToString());
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
        /// Signs the specified data
        /// </summary>
        /// <param name="data">The data to sign</param>
        /// <param name="algorithm">The algorithm to use</param>
        /// <param name="cancellationToken">Cancellation token</param>
        public virtual async Task<SignResult> SignDataAsync(SignatureAlgorithm algorithm, byte[] data, CancellationToken cancellationToken = default)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient.SignData");
            scope.AddAttribute("key", _keyId.ToString());
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
        /// Signs the specified data
        /// </summary>
        /// <param name="data">The data to sign</param>
        /// <param name="algorithm">The algorithm to use</param>
        /// <param name="cancellationToken">Cancellation token</param>
        public virtual SignResult SignData(SignatureAlgorithm algorithm, byte[] data, CancellationToken cancellationToken = default)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient.SignData");
            scope.AddAttribute("key", _keyId.ToString());
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
        /// Signs the specified data
        /// </summary>
        /// <param name="data">The data to sign</param>
        /// <param name="algorithm">The algorithm to use</param>
        /// <param name="cancellationToken">Cancellation token</param>
        public virtual async Task<SignResult> SignDataAsync(SignatureAlgorithm algorithm, Stream data, CancellationToken cancellationToken = default)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient.SignData");
            scope.AddAttribute("key", _keyId.ToString());
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
        /// Signs the specified data
        /// </summary>
        /// <param name="data">The data to sign</param>
        /// <param name="algorithm">The algorithm to use</param>
        /// <param name="cancellationToken">Cancellation token</param>
        public virtual SignResult SignData(SignatureAlgorithm algorithm, Stream data, CancellationToken cancellationToken = default)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient.SignData");
            scope.AddAttribute("key", _keyId.ToString());
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
        /// <param name="data">The data</param>
        /// <param name="signature">The signature value</param>
        /// <param name="algorithm">The algorithm to use</param>
        /// <param name="cancellationToken">Cancellation token</param>
        public virtual async Task<VerifyResult> VerifyDataAsync(SignatureAlgorithm algorithm, byte[] data, byte[] signature, CancellationToken cancellationToken = default)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient.VerifyData");
            scope.AddAttribute("key", _keyId.ToString());
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
        /// <param name="data">The data</param>
        /// <param name="signature">The signature value</param>
        /// <param name="algorithm">The algorithm to use</param>
        /// <param name="cancellationToken">Cancellation token</param>
        public virtual VerifyResult VerifyData(SignatureAlgorithm algorithm, byte[] data, byte[] signature, CancellationToken cancellationToken = default)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient.VerifyData");
            scope.AddAttribute("key", _keyId.ToString());
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
        /// <param name="data">The raw data</param>
        /// <param name="signature">The signature value</param>
        /// <param name="algorithm">The algorithm to use</param>
        /// <param name="cancellationToken">Cancellation token</param>
        public virtual async Task<VerifyResult> VerifyDataAsync(SignatureAlgorithm algorithm, Stream data, byte[] signature, CancellationToken cancellationToken = default)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient.VerifyData");
            scope.AddAttribute("key", _keyId.ToString());
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
        /// <param name="data">The raw data</param>
        /// <param name="signature">The signature value</param>
        /// <param name="algorithm">The algorithm to use</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        public virtual VerifyResult VerifyData(SignatureAlgorithm algorithm, Stream data, byte[] signature, CancellationToken cancellationToken = default)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient.VerifyData");
            scope.AddAttribute("key", _keyId.ToString());
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
