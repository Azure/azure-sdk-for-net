using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.KeyVault
{
    /// <summary>
    /// Client class to perform cryptographic key operations and vault operations
    /// against the Key Vault service. 
    /// Thread safety: This class is thread-safe.
    /// </summary>
    public interface IKeyVaultClient
    {
        /// <summary>
        /// Encrypts a single block of data. The amount of data that may be encrypted is determined
        /// by the target key type and the encryption algorithm.
        /// </summary>
        /// <param name="vault">The URL of the vault</param>
        /// <param name="keyName">The name of the key</param>
        /// <param name="keyVersion">The version of the key (optional)</param>
        /// <param name="algorithm">The algorithm. For more information on possible algorithm types, see JsonWebKeyEncryptionAlgorithm. </param>
        /// <param name="plainText">The plain text</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns>The encrypted text</returns>
        Task<KeyOperationResult> EncryptAsync(string vault, string keyName, string keyVersion, string algorithm, byte[] plainText, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Encrypts a single block of data. The amount of data that may be encrypted is determined
        /// by the target key type and the encryption algorithm.
        /// </summary>        
        /// <param name="keyIdentifier">The full key identifier</param>
        /// <param name="algorithm">The algorithm. For more information on possible algorithm types, see JsonWebKeyEncryptionAlgorithm.</param>
        /// <param name="plainText">The plain text</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns>The encrypted text</returns>
        Task<KeyOperationResult> EncryptAsync(string keyIdentifier, string algorithm, byte[] plainText, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Decrypts a single block of encrypted data
        /// </summary>
        /// <param name="keyIdentifier">The full key identifier</param>
        /// <param name="algorithm">The algorithm. For more information on possible algorithm types, see JsonWebKeyEncryptionAlgorithm.</param>
        /// <param name="cipherText">The cipher text</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns>The decryption result</returns>
        Task<KeyOperationResult> DecryptAsync(string keyIdentifier, string algorithm, byte[] cipherText, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Creates a signature from a digest using the specified key in the vault
        /// </summary>
        /// <param name="vault">The URL of the vault</param>
        /// <param name="keyName">The name of the key</param>
        /// <param name="keyVersion">The version of the key (optional)</param>
        /// <param name="algorithm">The signing algorithm. For more information on possible algorithm types, see JsonWebKeySignatureAlgorithm. </param>
        /// <param name="digest">The digest value to sign</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns>The signature value</returns>
        Task<KeyOperationResult> SignAsync(string vault, string keyName, string keyVersion, string algorithm, byte[] digest, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Creates a signature from a digest using the specified key in the vault
        /// </summary>
        /// <param name="keyIdentifier"> The global key identifier of the signing key </param>
        /// <param name="algorithm">The signing algorithm. For more information on possible algorithm types, see JsonWebKeySignatureAlgorithm. </param>
        /// <param name="digest">The digest value to sign</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns>The signature value</returns>
        Task<KeyOperationResult> SignAsync(string keyIdentifier, string algorithm, byte[] digest, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Verifies a signature using the specified key
        /// </summary>
        /// <param name="keyIdentifier"> The global key identifier of the key used for signing </param>
        /// <param name="algorithm"> The signing/verification algorithm. For more information on possible algorithm types, see JsonWebKeySignatureAlgorithm.</param>
        /// <param name="digest"> The digest used for signing </param>
        /// <param name="signature"> The signature to be verified </param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns> true if the signature is verified, false otherwise. </returns>
        Task<bool> VerifyAsync(string keyIdentifier, string algorithm, byte[] digest, byte[] signature, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Wraps a symmetric key using the specified key
        /// </summary>
        /// <param name="vault">The URL of the vault</param>
        /// <param name="keyName">The name of the key</param>
        /// <param name="keyVersion">The version of the key (optional)</param>
        /// <param name="algorithm">The signing algorithm. For more information on possible algorithm types, see JsonWebKeySignatureAlgorithm. </param>
        /// <param name="key"> The symmetric key </param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns> The wrapped symmetric key </returns>
        Task<KeyOperationResult> WrapKeyAsync(string vault, string keyName, string keyVersion, string algorithm, byte[] key, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Wraps a symmetric key using the specified key
        /// </summary>
        /// <param name="keyIdentifier"> The global key identifier of the key used for wrapping </param>
        /// <param name="algorithm"> The wrap algorithm. For more information on possible algorithm types, see JsonWebKeySignatureAlgorithm.</param>
        /// <param name="key"> The symmetric key </param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns> The wrapped symmetric key </returns>
        Task<KeyOperationResult> WrapKeyAsync(string keyIdentifier, string algorithm, byte[] key, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Unwraps a symmetric key using the specified key in the vault
        ///     that has initially been used for wrapping the key.
        /// </summary>
        /// <param name="keyIdentifier"> The global key identifier of the wrapping/unwrapping key </param>
        /// <param name="algorithm">The unwrap algorithm. For more information on possible algorithm types, see JsonWebKeySignatureAlgorithm.</param>
        /// <param name="wrappedKey">The wrapped symmetric key</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns>The unwrapped symmetric key</returns>
        Task<KeyOperationResult> UnwrapKeyAsync(string keyIdentifier, string algorithm, byte[] wrappedKey, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Creates a new, named, key in the specified vault.
        /// </summary>
        /// <param name="vault">The URL for the vault in which the key is to be created.</param>
        /// <param name="keyName">The name for the key</param>
        /// <param name="keyType">The type of key to create. For valid key types, see WebKeyTypes.</param>       
        /// <param name="keySize">Size of the key</param>
        /// <param name="key_ops">JSON web key operations. For more information, see JsonWebKeyOperation.</param>
        /// <param name="keyAttributes">The attributes of the key. For more information on possible attributes, see KeyAttributes.</param>      
        /// <param name="tags">Application-specific metadata in the form of key-value pairs</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns>A key bundle containing the result of the create request</returns>
        Task<KeyBundle> CreateKeyAsync(string vault, string keyName, string keyType, int? keySize = null, string[] key_ops = null, KeyAttributes keyAttributes = null, Dictionary<string, string> tags = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Retrieves the public portion of a key plus its attributes
        /// </summary>
        /// <param name="vault">The vault name, e.g. https://myvault.vault.azure.net</param>
        /// <param name="keyName">The key name</param>
        /// <param name="keyVersion">The key version</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns>A KeyBundle of the key and its attributes</returns>
        Task<KeyBundle> GetKeyAsync(string vault, string keyName, string keyVersion = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Retrieves the public portion of a key plus its attributes
        /// </summary>
        /// <param name="keyIdentifier">The key identifier</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns>A KeyBundle of the key and its attributes</returns>
        Task<KeyBundle> GetKeyAsync(string keyIdentifier, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// List keys in the specified vault
        /// </summary>
        /// <param name="vault">The URL for the vault containing the keys, e.g. https://myvault.vault.azure.net</param>
        /// <param name="maxresults">Maximum number of keys to return</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns>A response message containing a list of keys in the vault along with a link to the next page of keys</returns>   
        Task<ListKeysResponseMessage> GetKeysAsync(string vault, int? maxresults = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// List the next page of keys
        /// </summary>
        /// <param name="nextLink">nextLink value from a previous call to GetKeys or GetKeysNext</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns></returns>
        Task<ListKeysResponseMessage> GetKeysNextAsync(string nextLink, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// List the versions of the specified key
        /// </summary>
        /// <param name="vault">The URL for the vault containing the key, e.g. https://myvault.vault.azure.net</param>
        /// <param name="keyName">Name of the key</param>
        /// <param name="maxresults">Maximum number of keys to return</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns>A response message containing a list of keys along with a link to the next page of keys</returns>
        Task<ListKeysResponseMessage> GetKeyVersionsAsync(string vault, string keyName, int? maxresults = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// List the next page of key versions
        /// </summary>
        /// <param name="nextLink">nextLink value from a previous call to GetKeyVersions or GetKeyVersionsNext</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns>A response message containing a list of keys along with a link to the next page of keys</returns>
        Task<ListKeysResponseMessage> GetKeyVersionsNextAsync(string nextLink, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deletes the specified key
        /// </summary>
        /// <param name="vault">The vault name, e.g. https://myvault.vault.azure.net</param>
        /// <param name="keyName">The key name</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns>The public part of the deleted key</returns>
        Task<KeyBundle> DeleteKeyAsync(string vault, string keyName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates the Key Attributes associated with the specified key
        /// </summary>
        /// <param name="vault">The vault name, e.g. https://myvault.vault.azure.net</param>
        /// <param name="keyName">The key name</param>
        /// <param name="keyOps">Json web key operations. For more information on possible key operations, see JsonWebKeyOperation.</param>
        /// <param name="attributes">The new attributes for the key. For more information on key attributes, see KeyAttributes.</param>
        /// <param name="tags">Application-specific metadata in the form of key-value pairs</param>
        /// <returns> The updated key </returns>
        Task<KeyBundle> UpdateKeyAsync(string vault, string keyName, string[] keyOps = null, KeyAttributes attributes = null, Dictionary<string, string> tags = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates the Key Attributes associated with the specified key
        /// </summary>        
        /// <param name="keyIdentifier">The key identifier</param>
        /// <param name="keyOps">Json web key operations. For more information, see JsonWebKeyOperation.</param>
        /// <param name="attributes">The new attributes for the key. For more information on key attributes, see KeyAttributes.</param>
        /// <param name="tags">Application-specific metadata in the form of key-value pairs</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns> The updated key </returns>
        Task<KeyBundle> UpdateKeyAsync(string keyIdentifier, string[] keyOps = null, KeyAttributes attributes = null, Dictionary<string, string> tags = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Imports a key into the specified vault
        /// </summary>
        /// <param name="vault">The vault name, e.g. https://myvault.vault.azure.net</param>
        /// <param name="keyName">The key name</param>
        /// <param name="keyBundle"> Key bundle </param>
        /// <param name="importToHardware">Whether to import as a hardware key (HSM) or software key </param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns> Imported key bundle to the vault </returns>
        Task<KeyBundle> ImportKeyAsync(string vault, string keyName, KeyBundle keyBundle, bool? importToHardware = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Requests that a backup of the specified key be downloaded to the client.
        /// </summary>
        /// <param name="vault">The vault name, e.g. https://myvault.vault.azure.net</param>
        /// <param name="keyName">The key name</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns>The backup blob containing the backed up key</returns>
        Task<byte[]> BackupKeyAsync(string vault, string keyName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Restores the backup key in to a vault 
        /// </summary>
        /// <param name="vault">The vault name, e.g. https://myvault.vault.azure.net</param>
        /// <param name="keyBundleBackup"> the backup blob associated with a key bundle </param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns> Restored key bundle in the vault </returns>
        Task<KeyBundle> RestoreKeyAsync(string vault, byte[] keyBundleBackup, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets a secret.
        /// </summary>
        /// <param name="vault">The URL for the vault containing the secrets.</param>
        /// <param name="secretName">The name the secret in the given vault.</param>
        /// <param name="secretVersion">The version of the secret (optional)</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns>A response message containing the secret</returns>
        Task<Secret> GetSecretAsync(string vault, string secretName, string secretVersion = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets a secret.
        /// </summary>
        /// <param name="secretIdentifier">The URL for the secret.</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns>A response message containing the secret</returns>
        Task<Secret> GetSecretAsync(string secretIdentifier, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Sets a secret in the specified vault.
        /// </summary>
        /// <param name="vault">The URL for the vault containing the secrets.</param>
        /// <param name="secretName">The name the secret in the given vault.</param>
        /// <param name="value">The value of the secret.</param>        
        /// <param name="contentType">Type of the secret value such as a password. </param>
        /// <param name="tags">Application-specific metadata in the form of key-value pairs</param>
        /// <param name="secretAttributes">Attributes for the secret. For more information on possible attributes, see SecretAttributes.</param>     
        /// <param name="cancellationToken">Optional cancellation token</param> 
        /// <returns>A response message containing the updated secret</returns>
        Task<Secret> SetSecretAsync(string vault, string secretName, string value, Dictionary<string, string> tags = null, string contentType = null, SecretAttributes secretAttributes = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates the attributes associated with the specified secret
        /// </summary>
        /// <param name="vault">The vault name, e.g. https://myvault.vault.azure.net</param>
        /// <param name="secretName">The name of the secret</param>
        /// <param name="contentType">Type of the secret value such as password.</param>
        /// <param name="tags">Application-specific metadata in the form of key-value pairs</param>
        /// <param name="secretAttributes">Attributes for the secret. For more information on possible attributes, see SecretAttributes.</param>      
        /// <param name="cancellationToken">Optional cancellation token</param>  
        /// <returns>A response message containing the updated secret</returns>
        Task<Secret> UpdateSecretAsync(string vault, string secretName, string contentType = null, SecretAttributes secretAttributes = null, Dictionary<string, string> tags = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates the attributes associated with the specified secret
        /// </summary>        
        /// <param name="secretIdentifier">The URL of the secret</param>
        /// <param name="contentType">Type of the secret value such as password.</param>
        /// <param name="tags">Application-specific metadata in the form of key-value pairs</param>
        /// <param name="secretAttributes">Attributes for the secret. For more information on possible attributes, see SecretAttributes.</param>      
        /// <param name="cancellationToken">Optional cancellation token</param>  
        /// <returns>A response message containing the updated secret</returns>
        Task<Secret> UpdateSecretAsync(string secretIdentifier, string contentType = null, SecretAttributes secretAttributes = null, Dictionary<string, string> tags = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deletes a secret from the specified vault.
        /// </summary>
        /// <param name="vault">The URL for the vault containing the secrets.</param>
        /// <param name="secretName">The name of the secret in the given vault.</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns>The deleted secret</returns>
        Task<Secret> DeleteSecretAsync(string vault, string secretName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// List secrets in the specified vault
        /// </summary>
        /// <param name="vault">The URL for the vault containing the secrets.</param>
        /// <param name="maxresults">Maximum number of secrets to return</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns>A response message containing a list of secrets in the vault along with a link to the next page of secrets</returns>              
        Task<ListSecretsResponseMessage> GetSecretsAsync(string vault, int? maxresults = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// List the next page of secrets
        /// </summary>
        /// <param name="nextLink">nextLink value from a previous call to GetSecrets or GetSecretsNext</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns>A response message containing a list of secrets in the vault along with a link to the next page of secrets</returns>
        Task<ListSecretsResponseMessage> GetSecretsNextAsync(string nextLink, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// List the versions of a secret
        /// </summary>
        /// <param name="vault">The URL for the vault containing the secret</param>
        /// <param name="secretName">The name of the secret</param>
        /// <param name="maxresults">Maximum number of secrets to return</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns>A response message containing a list of secrets along with a link to the next page of secrets</returns>
        Task<ListSecretsResponseMessage> GetSecretVersionsAsync(string vault, string secretName, int? maxresults = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// List the next page of versions of a secret
        /// </summary>
        /// <param name="nextLink">nextLink value from a previous call to GetSecretVersions or GetSecretVersionsNext</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns>A response message containing a list of secrets in the vault along with a link to the next page of secrets</returns>
        Task<ListSecretsResponseMessage> GetSecretVersionsNextAsync(string nextLink, CancellationToken cancellationToken = default(CancellationToken));
    }
}