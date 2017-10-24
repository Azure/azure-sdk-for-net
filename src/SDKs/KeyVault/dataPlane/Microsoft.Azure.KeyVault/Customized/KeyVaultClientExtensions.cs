// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.KeyVault
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Models;
    using System.Security.Cryptography.X509Certificates;

    /// <summary>
    /// Extension methods for KeyVaultClient.
    /// </summary>
    public static partial class KeyVaultClientExtensions
    {

        #region Key Crypto Operations

        /// <summary>
        /// Encrypts a single block of data. The amount of data that may be encrypted is determined
        /// by the target key type and the encryption algorithm.
        /// </summary>        
        /// <param name="keyIdentifier">The full key identifier</param>
        /// <param name="algorithm">The algorithm. For more information on possible algorithm types, see JsonWebKeyEncryptionAlgorithm.</param>
        /// <param name="plainText">The plain text</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns>The encrypted text</returns>
        public static async Task<KeyOperationResult> EncryptAsync(this IKeyVaultClient operations, string keyIdentifier, string algorithm, byte[] plainText, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(keyIdentifier))
                throw new ArgumentNullException(nameof( keyIdentifier ));

            if (string.IsNullOrEmpty(algorithm))
                throw new ArgumentNullException(nameof( algorithm ));

            if (plainText == null)
                throw new ArgumentNullException(nameof( plainText ));

            var keyId = new KeyIdentifier(keyIdentifier);

            using (var _result = await operations.EncryptWithHttpMessagesAsync(keyId.Vault, keyId.Name, keyId.Version ?? string.Empty, algorithm, plainText, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Decrypts a single block of encrypted data
        /// </summary>
        /// <param name="keyIdentifier">The full key identifier</param>
        /// <param name="algorithm">The algorithm. For more information on possible algorithm types, see JsonWebKeyEncryptionAlgorithm.</param>
        /// <param name="cipherText">The cipher text</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns>The decryption result</returns>
        public static async Task<KeyOperationResult> DecryptAsync(this IKeyVaultClient operations, string keyIdentifier, string algorithm, byte[] cipherText, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(keyIdentifier))
                throw new ArgumentNullException(nameof( keyIdentifier ));

            if (string.IsNullOrEmpty(algorithm))
                throw new ArgumentNullException(nameof( algorithm ));

            if (cipherText == null)
                throw new ArgumentNullException(nameof( cipherText ));

            var keyId = new KeyIdentifier(keyIdentifier);

            // TODO: should we allow or not allow in the Key Identifier the version to be empty?

            using (var _result = await operations.DecryptWithHttpMessagesAsync(keyId.Vault, keyId.Name, keyId.Version ?? string.Empty, algorithm, cipherText, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Creates a signature from a digest using the specified key in the vault
        /// </summary>
        /// <param name="keyIdentifier"> The global key identifier of the signing key </param>
        /// <param name="algorithm">The signing algorithm. For more information on possible algorithm types, see JsonWebKeySignatureAlgorithm. </param>
        /// <param name="digest">The digest value to sign</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns>The signature value</returns>
        public static async Task<KeyOperationResult> SignAsync(this IKeyVaultClient operations, string keyIdentifier, string algorithm, byte[] digest, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(keyIdentifier))
                throw new ArgumentNullException(nameof( keyIdentifier ));

            if (string.IsNullOrEmpty(algorithm))
                throw new ArgumentNullException(nameof( algorithm ));

            if (digest == null)
                throw new ArgumentNullException(nameof( digest ));

            var keyId = new KeyIdentifier(keyIdentifier);

            using (var _result = await operations.SignWithHttpMessagesAsync(keyId.Vault, keyId.Name, keyId.Version ?? string.Empty, algorithm, digest, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Verifies a signature using the specified key
        /// </summary>
        /// <param name="keyIdentifier"> The global key identifier of the key used for signing </param>
        /// <param name="algorithm"> The signing/verification algorithm. For more information on possible algorithm types, see JsonWebKeySignatureAlgorithm.</param>
        /// <param name="digest"> The digest used for signing </param>
        /// <param name="signature"> The signature to be verified </param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns> true if the signature is verified, false otherwise. </returns>
        public static async Task<bool> VerifyAsync(this IKeyVaultClient operations, string keyIdentifier, string algorithm, byte[] digest, byte[] signature, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(keyIdentifier))
                throw new ArgumentNullException(nameof( keyIdentifier ));

            if (string.IsNullOrEmpty(algorithm))
                throw new ArgumentNullException(nameof( algorithm ));

            if (digest == null)
                throw new ArgumentNullException(nameof( digest ));

            if (signature == null)
                throw new ArgumentNullException(nameof( signature ));

            var keyId = new KeyIdentifier(keyIdentifier);

            using (var _result = await operations.VerifyWithHttpMessagesAsync(keyId.Vault, keyId.Name, keyId.Version ?? string.Empty, algorithm, digest, signature, null, cancellationToken).ConfigureAwait(false))
            {
                var verifyResult = _result.Body;
                return (verifyResult.Value == true) ? true : false;
            }
        }

        /// <summary>
        /// Wraps a symmetric key using the specified key
        /// </summary>
        /// <param name="keyIdentifier"> The global key identifier of the key used for wrapping </param>
        /// <param name="algorithm"> The wrap algorithm. For more information on possible algorithm types, see JsonWebKeySignatureAlgorithm.</param>
        /// <param name="key"> The symmetric key </param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns> The wrapped symmetric key </returns>
        public static async Task<KeyOperationResult> WrapKeyAsync(this IKeyVaultClient operations, string keyIdentifier, string algorithm, byte[] key, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(keyIdentifier))
                throw new ArgumentNullException(nameof( keyIdentifier ));

            if (string.IsNullOrEmpty(algorithm))
                throw new ArgumentNullException(nameof( algorithm ));

            if (key == null)
                throw new ArgumentNullException(nameof( key ));

            var keyId = new KeyIdentifier(keyIdentifier);

            using (var _result = await operations.WrapKeyWithHttpMessagesAsync(keyId.Vault, keyId.Name, keyId.Version ?? string.Empty, algorithm, key, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Unwraps a symmetric key using the specified key in the vault
        ///     that has initially been used for wrapping the key.
        /// </summary>
        /// <param name="keyIdentifier"> The global key identifier of the wrapping/unwrapping key </param>
        /// <param name="algorithm">The unwrap algorithm. For more information on possible algorithm types, see JsonWebKeySignatureAlgorithm.</param>
        /// <param name="wrappedKey">The wrapped symmetric key</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns>The unwrapped symmetric key</returns>
        public static async Task<KeyOperationResult> UnwrapKeyAsync(this IKeyVaultClient operations, string keyIdentifier, string algorithm, byte[] wrappedKey, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(keyIdentifier))
                throw new ArgumentNullException(nameof( keyIdentifier ));

            if (string.IsNullOrEmpty(algorithm))
                throw new ArgumentNullException(nameof( algorithm ));

            if (wrappedKey == null)
                throw new ArgumentNullException(nameof( wrappedKey ));

            var keyId = new KeyIdentifier(keyIdentifier);

            using (var _result = await operations.UnwrapKeyWithHttpMessagesAsync(keyId.Vault, keyId.Name, keyId.Version ?? string.Empty, algorithm, wrappedKey, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        #endregion

        #region Key Management

        /// <summary>
        /// Retrieves the public portion of a key plus its attributes
        /// </summary>
        /// <param name="vaultBaseUrl">The vault name, e.g. https://myvault.vault.azure.net</param>
        /// <param name="keyName">The key name</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns>A KeyBundle of the key and its attributes</returns>
        public static async Task<KeyBundle> GetKeyAsync(this IKeyVaultClient operations, string vaultBaseUrl, string keyName, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(vaultBaseUrl))
                throw new ArgumentNullException(nameof( vaultBaseUrl ));

            if (string.IsNullOrEmpty(keyName))
                throw new ArgumentNullException(nameof( keyName ));

            using (var _result = await operations.GetKeyWithHttpMessagesAsync(vaultBaseUrl, keyName, string.Empty, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Retrieves the public portion of a key plus its attributes
        /// </summary>
        /// <param name="keyIdentifier">The key identifier</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns>A KeyBundle of the key and its attributes</returns>
        public static async Task<KeyBundle> GetKeyAsync(this IKeyVaultClient operations, string keyIdentifier, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(keyIdentifier))
                throw new ArgumentNullException(nameof( keyIdentifier ));

            var keyId = new KeyIdentifier(keyIdentifier);

            using (var _result = await operations.GetKeyWithHttpMessagesAsync(keyId.Vault, keyId.Name, keyId.Version ?? string.Empty, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Updates the Key Attributes associated with the specified key
        /// </summary>
        /// <param name="vaultBaseUrl">The vault name, e.g. https://myvault.vault.azure.net</param>
        /// <param name="keyName">The key name</param>
        /// <param name="keyOps">Json web key operations. For more information on possible key operations, see JsonWebKeyOperation.</param>
        /// <param name="attributes">The new attributes for the key. For more information on key attributes, see KeyAttributes.</param>
        /// <param name="tags">Application-specific metadata in the form of key-value pairs</param>
        /// <returns> The updated key </returns>
        public static async Task<KeyBundle> UpdateKeyAsync(this IKeyVaultClient operations, string vaultBaseUrl, string keyName, string[] keyOps = null, KeyAttributes attributes = null, Dictionary<string, string> tags = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(vaultBaseUrl))
                throw new ArgumentNullException(nameof( vaultBaseUrl ));

            if (string.IsNullOrEmpty(keyName))
                throw new ArgumentNullException(nameof( keyName ));

            using (var _result = await operations.UpdateKeyWithHttpMessagesAsync(vaultBaseUrl, keyName, string.Empty, keyOps, attributes, tags, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Updates the Key Attributes associated with the specified key
        /// </summary>        
        /// <param name="keyIdentifier">The key identifier</param>
        /// <param name="keyOps">Json web key operations. For more information, see JsonWebKeyOperation.</param>
        /// <param name="attributes">The new attributes for the key. For more information on key attributes, see KeyAttributes.</param>
        /// <param name="tags">Application-specific metadata in the form of key-value pairs</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns> The updated key </returns>
        public static async Task<KeyBundle> UpdateKeyAsync(this IKeyVaultClient operations, string keyIdentifier, string[] keyOps = null, KeyAttributes attributes = null, Dictionary<string, string> tags = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(keyIdentifier))
                throw new ArgumentNullException(nameof( keyIdentifier ));

            var keyId = new KeyIdentifier(keyIdentifier);

            using (var _result = await operations.UpdateKeyWithHttpMessagesAsync(keyId.Vault, keyId.Name, keyId.Version ?? string.Empty, keyOps, attributes, tags, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        public static async Task<KeyBundle> CreateKeyAsync( this IKeyVaultClient operations, string vaultBaseUrl, string keyName, NewKeyParameters parameters, CancellationToken cancellationToken = default( CancellationToken ) )
        {
            if (string.IsNullOrEmpty( vaultBaseUrl ))
                throw new ArgumentNullException( nameof( vaultBaseUrl ) );

            if (string.IsNullOrEmpty( keyName ))
                throw new ArgumentNullException( nameof( keyName ) );

            if (parameters == null)
                throw new ArgumentNullException( nameof( parameters ) );

            using (var _result = await operations.CreateKeyWithHttpMessagesAsync(
                vaultBaseUrl,
                keyName,
                parameters.Kty,
                parameters.KeySize,
                parameters.KeyOps,
                parameters.Attributes,
                parameters.Tags,
                parameters.CurveName,
                null, // customHeaders
                cancellationToken
            ).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Imports a key into the specified vault
        /// </summary>
        /// <param name="vaultBaseUrl">The vault name, e.g. https://myvault.vault.azure.net</param>
        /// <param name="keyName">The key name</param>
        /// <param name="keyBundle"> Key bundle </param>
        /// <param name="importToHardware">Whether to import as a hardware key (HSM) or software key </param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns> Imported key bundle to the vault </returns>
        public static async Task<KeyBundle> ImportKeyAsync(this IKeyVaultClient operations, string vaultBaseUrl, string keyName, KeyBundle keyBundle, bool? importToHardware = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(vaultBaseUrl))
                throw new ArgumentNullException(nameof( vaultBaseUrl ));

            if (string.IsNullOrEmpty(keyName))
                throw new ArgumentNullException(nameof( keyName ));

            if (keyBundle == null)
                throw new ArgumentNullException(nameof( keyBundle ));

            using (var _result = await operations.ImportKeyWithHttpMessagesAsync(vaultBaseUrl, keyName, keyBundle.Key, importToHardware, keyBundle.Attributes, keyBundle.Tags, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
        #endregion

        #region Secret Management

        /// <summary>
        /// Gets a secret.
        /// </summary>
        /// <param name="vaultBaseUrl">The URL for the vault containing the secrets.</param>
        /// <param name="secretName">The name the secret in the given vault.</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns>A response message containing the secret</returns>
        public static async Task<SecretBundle> GetSecretAsync(this IKeyVaultClient operations, string vaultBaseUrl, string secretName, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(vaultBaseUrl))
                throw new ArgumentNullException(nameof( vaultBaseUrl ));

            if (string.IsNullOrEmpty(secretName))
                throw new ArgumentNullException(nameof( secretName ));

            using (var _result = await operations.GetSecretWithHttpMessagesAsync(vaultBaseUrl, secretName, string.Empty, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Gets a secret.
        /// </summary>
        /// <param name="secretIdentifier">The URL for the secret.</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns>A response message containing the secret</returns>
        public static async Task<SecretBundle> GetSecretAsync(this IKeyVaultClient operations, string secretIdentifier, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(secretIdentifier))
                throw new ArgumentNullException(nameof( secretIdentifier ));

            var secretId = new SecretIdentifier(secretIdentifier);
            using (var _result = await operations.GetSecretWithHttpMessagesAsync(secretId.Vault, secretId.Name, secretId.Version ?? string.Empty, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Updates the attributes associated with the specified secret
        /// </summary>        
        /// <param name="secretIdentifier">The URL of the secret</param>
        /// <param name="contentType">Type of the secret value such as password.</param>
        /// <param name="tags">Application-specific metadata in the form of key-value pairs</param>
        /// <param name="secretAttributes">Attributes for the secret. For more information on possible attributes, see SecretAttributes.</param>      
        /// <param name="cancellationToken">Optional cancellation token</param>  
        /// <returns>A response message containing the updated secret</returns>
        public static async Task<SecretBundle> UpdateSecretAsync(this IKeyVaultClient operations, string secretIdentifier, string contentType = null, SecretAttributes secretAttributes = null, Dictionary<string, string> tags = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(secretIdentifier))
                throw new ArgumentNullException(nameof( secretIdentifier ));

            var secretId = new SecretIdentifier(secretIdentifier);

            using (var _result = await operations.UpdateSecretWithHttpMessagesAsync(secretId.Vault, secretId.Name, secretId.Version, contentType, secretAttributes, tags, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
        #endregion

        #region Recovery Management

        /// <summary>
        /// Recovers the deleted secret.
        /// </summary>        
        /// <param name="recoveryId">The recoveryId of the deleted secret, returned from deletion.</param>
        /// <param name="cancellationToken">Optional cancellation token</param>  
        /// <returns>A response message containing the recovered secret</returns>
        public static async Task<SecretBundle> RecoverDeletedSecretAsync(this IKeyVaultClient operations, string recoveryId, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(recoveryId))
                throw new ArgumentNullException(nameof(recoveryId));
            
            var secretRecoveryId = new DeletedSecretIdentifier(recoveryId);

            using (var _result = await operations.RecoverDeletedSecretWithHttpMessagesAsync(secretRecoveryId.Vault, secretRecoveryId.Name, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Recovers the deleted key.
        /// </summary>        
        /// <param name="recoveryId">The recoveryId of the deleted key, returned from deletion.</param>
        /// <param name="cancellationToken">Optional cancellation token</param>  
        /// <returns>A response message containing the recovered key</returns>
        public static async Task<KeyBundle> RecoverDeletedKeyAsync(this IKeyVaultClient operations, string recoveryId, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(recoveryId))
                throw new ArgumentNullException(nameof(recoveryId));

            var keyRecoveryId = new DeletedKeyIdentifier(recoveryId);

            using (var _result = await operations.RecoverDeletedKeyWithHttpMessagesAsync(keyRecoveryId.Vault, keyRecoveryId.Name, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Recovers the deleted certificate.
        /// </summary>        
        /// <param name="recoveryId">The recoveryId of the deleted certificate, returned from deletion.</param>
        /// <param name="cancellationToken">Optional cancellation token</param>  
        /// <returns>A response message containing the recovered certificate</returns>
        public static async Task<CertificateBundle> RecoverDeletedCertificateAsync( this IKeyVaultClient operations, string recoveryId, CancellationToken cancellationToken = default( CancellationToken ) )
        {
            if ( string.IsNullOrEmpty( recoveryId ) )
                throw new ArgumentNullException( nameof( recoveryId ) );

            var certificateRecoveryId = new DeletedCertificateIdentifier(recoveryId);

            using ( var _result = await operations.RecoverDeletedCertificateWithHttpMessagesAsync( certificateRecoveryId.Vault, certificateRecoveryId.Name, null, cancellationToken ).ConfigureAwait( false ) )
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Purges the deleted secret immediately.
        /// </summary>        
        /// <param name="recoveryId">The recoveryId of the deleted secret, returned from deletion.</param>
        /// <param name="cancellationToken">Optional cancellation token</param>  
        /// <returns>Task representing the asynchronous execution of this request.</returns>
        public static async Task PurgeDeletedSecretAsync(this IKeyVaultClient operations, string recoveryId, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(recoveryId))
                throw new ArgumentNullException(nameof(recoveryId));

            var secretRecoveryId = new DeletedSecretIdentifier(recoveryId);

            using (var _result = await operations.PurgeDeletedSecretWithHttpMessagesAsync(secretRecoveryId.Vault, secretRecoveryId.Name, null, cancellationToken).ConfigureAwait(false))
            {
                return;
            }
        }

        /// <summary>
        /// Purges the deleted key immediately.
        /// </summary>        
        /// <param name="recoveryId">The recoveryId of the deleted key, returned from deletion.</param>
        /// <param name="cancellationToken">Optional cancellation token</param>  
        /// <returns>Task representing the asynchronous execution of this request.</returns>
        public static async Task PurgeDeletedKeyAsync(this IKeyVaultClient operations, string recoveryId, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(recoveryId))
                throw new ArgumentNullException(nameof(recoveryId));

            var keyRecoveryId = new DeletedKeyIdentifier(recoveryId);

            using (var _result = await operations.PurgeDeletedKeyWithHttpMessagesAsync(keyRecoveryId.Vault, keyRecoveryId.Name, null, cancellationToken).ConfigureAwait(false))
            {
                return;
            }
        }

        /// <summary>
        /// Purges the deleted certificate with immediate effect.
        /// </summary>        
        /// <param name="recoveryId">The recoveryId of the deleted certificate, returned from deletion.</param>
        /// <param name="cancellationToken">Optional cancellation token</param>  
        /// <returns>Task representing the asynchronous execution of this request.</returns>
        public static async Task PurgeDeletedCertificateAsync( this IKeyVaultClient operations, string recoveryId, CancellationToken cancellationToken = default( CancellationToken ) )
        {
            if ( string.IsNullOrEmpty( recoveryId ) )
                throw new ArgumentNullException( nameof( recoveryId ) );

            var certificateRecoveryId = new DeletedCertificateIdentifier(recoveryId);

            using ( var _result = await operations.PurgeDeletedCertificateWithHttpMessagesAsync( certificateRecoveryId.Vault, certificateRecoveryId.Name, null, cancellationToken ).ConfigureAwait( false ) )
            {
                return;
            }
        }

        #endregion

        #region Certificate Management

        /// <summary>
        /// Gets a certificate.
        /// </summary>
        /// <param name="vaultBaseUrl">The URL for the vault containing the certificate.</param>
        /// <param name="certificateName">The name of the certificate in the given vault.</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns>The retrieved certificate</returns>
        public static async Task<CertificateBundle> GetCertificateAsync(this IKeyVaultClient operations, string vaultBaseUrl, string certificateName, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(vaultBaseUrl))
                throw new ArgumentNullException(nameof( vaultBaseUrl ));

            if (string.IsNullOrEmpty(certificateName))
                throw new ArgumentNullException(nameof( certificateName ));

            using (var _result = await operations.GetCertificateWithHttpMessagesAsync(vaultBaseUrl, certificateName, string.Empty, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Gets a certificate.
        /// </summary>
        /// <param name="certificateIdentifier">The URL for the certificate.</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns>The retrieved certificate</returns>
        public static async Task<CertificateBundle> GetCertificateAsync(this IKeyVaultClient operations, string certificateIdentifier, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(certificateIdentifier))
                throw new ArgumentNullException(nameof( certificateIdentifier ));

            var certId = new CertificateIdentifier(certificateIdentifier);

            using (var _result = await operations.GetCertificateWithHttpMessagesAsync(certId.Vault, certId.Name, certId.Version ?? string.Empty, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Updates a certificate version.
        /// </summary>
        /// <param name="certificateIdentifier">The URL for the certificate.</param>      
        /// <param name='certificatePolicy'>The management policy for the certificate.</param>       
        /// <param name="certificateAttributes">The attributes of the certificate (optional)</param>
        /// <param name="tags">Application-specific metadata in the form of key-value pairs</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns>The updated certificate.</returns>
        public static async Task<CertificateBundle> UpdateCertificateAsync(this IKeyVaultClient operations, string certificateIdentifier, CertificatePolicy certificatePolicy = default(CertificatePolicy), CertificateAttributes certificateAttributes = null, IDictionary<string, string> tags = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrWhiteSpace(certificateIdentifier))
                throw new ArgumentNullException(nameof( certificateIdentifier ));

            var certId = new CertificateIdentifier(certificateIdentifier);
            using (var _result = await operations.UpdateCertificateWithHttpMessagesAsync(certId.Vault, certId.Name, certId.Version ?? string.Empty, certificatePolicy, certificateAttributes, tags, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }


        /// <summary>
        /// Imports a new certificate version. If this is the first version, the certificate resource is created.
        /// </summary>
        /// <param name="vaultBaseUrl">The URL for the vault containing the certificate</param>
        /// <param name="certificateName">The name of the certificate</param>
        /// <param name="certificateCollection">The certificate collection with the private key</param>
        /// <param name="certificatePolicy">The management policy for the certificate</param>
        /// <param name="certificateAttributes">The attributes of the certificate (optional)</param>
        /// <param name="tags">Application-specific metadata in the form of key-value pairs</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns>Imported certificate bundle to the vault.</returns>
        public static async Task<CertificateBundle> ImportCertificateAsync(this IKeyVaultClient operations, string vaultBaseUrl, string certificateName, X509Certificate2Collection certificateCollection, CertificatePolicy certificatePolicy, CertificateAttributes certificateAttributes = null, IDictionary<string, string> tags = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrWhiteSpace(vaultBaseUrl))
                throw new ArgumentNullException(nameof( vaultBaseUrl ));

            if (string.IsNullOrWhiteSpace(certificateName))
                throw new ArgumentNullException(nameof( certificateName ));

            if (null == certificateCollection)
                throw new ArgumentNullException(nameof( certificateCollection ));

            var base64EncodedCertificate = Convert.ToBase64String(certificateCollection.Export(X509ContentType.Pfx));
            using (var _result = await operations.ImportCertificateWithHttpMessagesAsync(vaultBaseUrl, certificateName, base64EncodedCertificate, string.Empty, certificatePolicy, certificateAttributes, tags, null, cancellationToken))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Merges a certificate or a certificate chain with a key pair existing on the server.
        /// </summary>
        /// <param name="vaultBaseUrl">The URL for the vault containing the certificate</param>
        /// <param name="certificateName">The name of the certificate</param>
        /// <param name="x509Certificates">The certificate or the certificte chain to merge</param>
        /// <param name="certificateAttributes">The attributes of the certificate (optional)</param>
        /// <param name="tags">Application-specific metadata in the form of key-value pairs</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns>A response message containing the merged certificate.</returns>
        public static async Task<CertificateBundle> MergeCertificateAsync(this IKeyVaultClient operations, string vaultBaseUrl, string certificateName, X509Certificate2Collection x509Certificates, CertificateAttributes certificateAttributes = null, IDictionary<string, string> tags = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrWhiteSpace(vaultBaseUrl))
                throw new ArgumentNullException(nameof( vaultBaseUrl ));

            if (string.IsNullOrWhiteSpace(certificateName))
                throw new ArgumentNullException(nameof( certificateName ));

            if (x509Certificates == null || x509Certificates.Count == 0)
                throw new ArgumentException("x509Certificates");

            var X5C = new List<byte[]>();
            foreach (var cert in x509Certificates)
            {
                X5C.Add(cert.Export(X509ContentType.Cert));
            }

            using (var _result = await operations.MergeCertificateWithHttpMessagesAsync(vaultBaseUrl, certificateName, X5C, certificateAttributes, tags, null, cancellationToken))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Gets the Base64 pending certificate signing request (PKCS-10) 
        /// </summary>
        /// <param name="vaultBaseUrl">The URL for the vault containing the certificate</param>
        /// <param name="certificateName">The name of the certificate</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns>The pending certificate signing request as Base64 encoded string.</returns>
        public static async Task<string> GetPendingCertificateSigningRequestAsync(this IKeyVaultClient operations, string vaultBaseUrl, string certificateName, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrWhiteSpace(vaultBaseUrl))
                throw new ArgumentNullException(nameof( vaultBaseUrl ));

            if (string.IsNullOrWhiteSpace(certificateName))
                throw new ArgumentNullException(nameof( certificateName ));
            
            using (var _result = await operations.GetPendingCertificateSigningRequestWithHttpMessagesAsync(vaultBaseUrl, certificateName, null, cancellationToken))
            {
                return _result.Body;
            }
        }

        #endregion
    }
}
