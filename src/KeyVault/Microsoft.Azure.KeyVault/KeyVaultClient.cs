//
// Copyright © Microsoft Corporation, All Rights Reserved
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS
// OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION
// ANY IMPLIED WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A
// PARTICULAR PURPOSE, MERCHANTABILITY OR NON-INFRINGEMENT.
//
// See the Apache License, Version 2.0 for the specific language
// governing permissions and limitations under the License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security;
using System.Threading;
using System.Threading.Tasks;
using Hyak.Common;
using Microsoft.Azure.KeyVault.Internal;
using Microsoft.Azure.KeyVault.WebKey;
using Newtonsoft.Json;

namespace Microsoft.Azure.KeyVault
{
    /// <summary>
    /// Client class to perform cryptographic key operations and vault operations
    /// against the Key Vault service. 
    /// Thread safety: This class is thread-safe.
    /// </summary>
    public class KeyVaultClient
    {
        /// <summary>
        /// The authentication callback delegate which is to be implemented by the client code
        /// </summary>
        /// <param name="authority"> Identifier of the authority, a URL. </param>
        /// <param name="resource"> Identifier of the target resource that is the recipient of the requested token, a URL. </param>
        /// <param name="scope"> The scope of the authentication request. </param>
        /// <returns> access token </returns>
        public delegate Task<string> AuthenticationCallback(string authority, string resource, string scope);

        private readonly KeyVaultInternalClient _internalClient;

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="authenticationCallback">The authentication callback</param>
        public KeyVaultClient(AuthenticationCallback authenticationCallback)
        {
            var credential = new KeyVaultCredential(authenticationCallback);
            _internalClient = new KeyVaultInternalClient(credential);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="authenticationCallback">The authentication callback</param>
        /// <param name="httpClient">Customized HTTP client </param>
        public KeyVaultClient(AuthenticationCallback authenticationCallback, HttpClient httpClient)
        {
            var credential = new KeyVaultCredential(authenticationCallback);
            _internalClient = new KeyVaultInternalClient(credential, httpClient);
        }

        /// <summary>
        /// Constructor for testability
        /// </summary>
        /// <param name="credential">Credential for key vault operations</param>
        /// <param name="handlers">Custom HTTP handlers</param>
        public KeyVaultClient(KeyVaultCredential credential, DelegatingHandler[] handlers)
        {
            _internalClient = new KeyVaultInternalClient(credential);
            _internalClient = _internalClient.WithHandlers(handlers);
        }

        #endregion

        #region Key Crypto Operations

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
        public async Task<KeyOperationResult> EncryptAsync(string vault, string keyName, string keyVersion, string algorithm, byte[] plainText, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(vault))
                throw new ArgumentNullException("vault");

            if (string.IsNullOrEmpty(keyName))
                throw new ArgumentNullException("keyName");

            if (string.IsNullOrEmpty(algorithm))
                throw new ArgumentNullException("algorithm");

            if (plainText == null)
                throw new ArgumentNullException("plainText");

            var identifier = new KeyIdentifier(vault, keyName, keyVersion);

            return await EncryptAsync(
                identifier.Identifier,
                algorithm,
                plainText, 
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Encrypts a single block of data. The amount of data that may be encrypted is determined
        /// by the target key type and the encryption algorithm.
        /// </summary>        
        /// <param name="keyIdentifier">The full key identifier</param>
        /// <param name="algorithm">The algorithm. For more information on possible algorithm types, see JsonWebKeyEncryptionAlgorithm.</param>
        /// <param name="plainText">The plain text</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns>The encrypted text</returns>
        public async Task<KeyOperationResult> EncryptAsync(string keyIdentifier, string algorithm, byte[] plainText, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(keyIdentifier))
                throw new ArgumentNullException("keyIdentifier");

            if (string.IsNullOrEmpty(algorithm))
                throw new ArgumentNullException("algorithm");

            if (plainText == null)
                throw new ArgumentNullException("plainText");

            return await Do(async () =>
            {
                var response = await _internalClient.Keys.EncryptDataAsync(
                    keyIdentifier,
                    CreateKeyOpRequest(algorithm, plainText),
                    cancellationToken).ConfigureAwait(false);

                return JsonConvert.DeserializeObject<KeyOperationResult>(response.KeyOpResponse);

            }).ConfigureAwait(false);
        }

        /// <summary>
        /// Decrypts a single block of encrypted data
        /// </summary>
        /// <param name="keyIdentifier">The full key identifier</param>
        /// <param name="algorithm">The algorithm. For more information on possible algorithm types, see JsonWebKeyEncryptionAlgorithm.</param>
        /// <param name="cipherText">The cipher text</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns>The decryption result</returns>
        public async Task<KeyOperationResult> DecryptAsync(string keyIdentifier, string algorithm, byte[] cipherText, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(keyIdentifier))
                throw new ArgumentNullException("keyIdentifier");

            if (string.IsNullOrEmpty(algorithm))
                throw new ArgumentNullException("algorithm");

            if (cipherText == null)
                throw new ArgumentNullException("cipherText");

            return await Do(async () =>
            {
                var response = await _internalClient.Keys.DecryptDataAsync(
                        keyIdentifier,
                        CreateKeyOpRequest(algorithm, cipherText),
                        cancellationToken).ConfigureAwait(false);

                return JsonConvert.DeserializeObject<KeyOperationResult>(response.KeyOpResponse);

            }).ConfigureAwait(false);
        }

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
        public async Task<KeyOperationResult> SignAsync(string vault, string keyName, string keyVersion, string algorithm, byte[] digest, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(vault))
                throw new ArgumentNullException("vault");

            if (string.IsNullOrEmpty(keyName))
                throw new ArgumentNullException("keyName");

            if (string.IsNullOrEmpty(algorithm))
                throw new ArgumentNullException("algorithm");

            if (digest == null)
                throw new ArgumentNullException("digest");

            var identifier = new KeyIdentifier(vault, keyName, keyVersion);

            return await SignAsync(
                identifier.Identifier,
                algorithm,
                digest,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Creates a signature from a digest using the specified key in the vault
        /// </summary>
        /// <param name="keyIdentifier"> The global key identifier of the signing key </param>
        /// <param name="algorithm">The signing algorithm. For more information on possible algorithm types, see JsonWebKeySignatureAlgorithm. </param>
        /// <param name="digest">The digest value to sign</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns>The signature value</returns>
        public async Task<KeyOperationResult> SignAsync(string keyIdentifier, string algorithm, byte[] digest, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(keyIdentifier))
                throw new ArgumentNullException("keyIdentifier");

            if (string.IsNullOrEmpty(algorithm))
                throw new ArgumentNullException("algorithm");

            if (digest == null)
                throw new ArgumentNullException("digest");

            return await Do(async () =>
            {
                var response = await _internalClient.Keys.SignAsync(
                    keyIdentifier,
                    CreateKeyOpRequest(algorithm, digest),
                    cancellationToken).ConfigureAwait(false);

                return JsonConvert.DeserializeObject<KeyOperationResult>(response.KeyOpResponse);

            }).ConfigureAwait(false);
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
        public async Task<bool> VerifyAsync(string keyIdentifier, string algorithm, byte[] digest, byte[] signature, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(keyIdentifier))
                throw new ArgumentNullException("keyIdentifier");

            if (string.IsNullOrEmpty(algorithm))
                throw new ArgumentNullException("algorithm");

            if (digest == null)
                throw new ArgumentNullException("digest");

            if (signature == null)
                throw new ArgumentNullException("signature");

            return await Do(async () =>
            {
                var response = await _internalClient.Keys.VerifyAsync(
                    keyIdentifier,
                    CreateVerifyRequest(algorithm, digest, signature),
                    cancellationToken).ConfigureAwait(false);

                return JsonConvert.DeserializeObject<VerifyResponseMessage>(response.KeyOpResponse).Value;

            }).ConfigureAwait(false);
        }

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
        public async Task<KeyOperationResult> WrapKeyAsync(string vault, string keyName, string keyVersion, string algorithm, byte[] key, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(vault))
                throw new ArgumentNullException("vault");

            if (string.IsNullOrEmpty(keyName))
                throw new ArgumentNullException("keyName");

            if (string.IsNullOrEmpty(algorithm))
                throw new ArgumentNullException("algorithm");

            if (key == null)
                throw new ArgumentNullException("key");

            var identifier = new KeyIdentifier(vault, keyName, keyVersion);

            return await WrapKeyAsync(
                identifier.Identifier,
                algorithm,
                key,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Wraps a symmetric key using the specified key
        /// </summary>
        /// <param name="keyIdentifier"> The global key identifier of the key used for wrapping </param>
        /// <param name="algorithm"> The wrap algorithm. For more information on possible algorithm types, see JsonWebKeySignatureAlgorithm.</param>
        /// <param name="key"> The symmetric key </param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns> The wrapped symmetric key </returns>
        public async Task<KeyOperationResult> WrapKeyAsync(string keyIdentifier, string algorithm, byte[] key, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(keyIdentifier))
                throw new ArgumentNullException("keyIdentifier");

            if (string.IsNullOrEmpty(algorithm))
                throw new ArgumentNullException("algorithm");

            if (key == null)
                throw new ArgumentNullException("key");

            return await Do(async () =>
            {

                var response = await _internalClient.Keys.WrapKeyAsync(
                    keyIdentifier,
                    CreateKeyOpRequest(algorithm, key),
                    cancellationToken).ConfigureAwait(false);

                return JsonConvert.DeserializeObject<KeyOperationResult>(response.KeyOpResponse);

            }).ConfigureAwait(false);
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
        public async Task<KeyOperationResult> UnwrapKeyAsync(string keyIdentifier, string algorithm, byte[] wrappedKey, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(keyIdentifier))
                throw new ArgumentNullException("keyIdentifier");

            if (string.IsNullOrEmpty(algorithm))
                throw new ArgumentNullException("algorithm");

            if (wrappedKey == null)
                throw new ArgumentNullException("wrappedKey");

            return await Do(async () =>
            {

                var response = await _internalClient.Keys.UnwrapKeyAsync(
                    keyIdentifier,
                    CreateKeyOpRequest(algorithm, wrappedKey),
                    cancellationToken).ConfigureAwait(false);

                return JsonConvert.DeserializeObject<KeyOperationResult>(response.KeyOpResponse);

            }).ConfigureAwait(false);
        }

        #endregion

        #region Key Management

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
        public async Task<KeyBundle> CreateKeyAsync(string vault, string keyName, string keyType, int? keySize = null, string[] key_ops = null, KeyAttributes keyAttributes = null, Dictionary<string, string> tags = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(vault))
                throw new ArgumentNullException("vault");

            if (string.IsNullOrEmpty(keyName))
                throw new ArgumentNullException("keyName");

            if (string.IsNullOrEmpty(keyType))
                throw new ArgumentNullException("keyType");

            if (!JsonWebKeyType.AllTypes.Contains(keyType))
                throw new ArgumentOutOfRangeException("keyType");

            return await Do(async () =>
            {

                var keyIdentifier = new KeyIdentifier(vault, keyName);

                var response = await _internalClient.Keys.CreateAsync(
                    vault,
                    keyName,
                    CreateKeyRequest(keyType, keySize, key_ops, keyAttributes, tags),
                    cancellationToken).ConfigureAwait(false);

                return JsonConvert.DeserializeObject<KeyBundle>(response.KeyOpResponse);

            }).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves the public portion of a key plus its attributes
        /// </summary>
        /// <param name="vault">The vault name, e.g. https://myvault.vault.azure.net</param>
        /// <param name="keyName">The key name</param>
        /// <param name="keyVersion">The key version</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns>A KeyBundle of the key and its attributes</returns>
        public async Task<KeyBundle> GetKeyAsync(string vault, string keyName, string keyVersion = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(vault))
                throw new ArgumentNullException("vault");

            if (string.IsNullOrEmpty(keyName))
                throw new ArgumentNullException("keyName");

            var keyIdentifier = new KeyIdentifier(vault, keyName, keyVersion);

            return await GetKeyAsync(keyIdentifier.Identifier, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves the public portion of a key plus its attributes
        /// </summary>
        /// <param name="keyIdentifier">The key identifier</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns>A KeyBundle of the key and its attributes</returns>
        public async Task<KeyBundle> GetKeyAsync(string keyIdentifier, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(keyIdentifier))
                throw new ArgumentNullException("keyIdentifier");

            return await Do(async () =>
            {
                var response = await _internalClient.Keys.GetAsync(keyIdentifier, cancellationToken).ConfigureAwait(false);

                return JsonConvert.DeserializeObject<KeyBundle>(response.KeyOpResponse);

            }).ConfigureAwait(false);
        }

        /// <summary>
        /// List keys in the specified vault
        /// </summary>
        /// <param name="vault">The URL for the vault containing the keys, e.g. https://myvault.vault.azure.net</param>
        /// <param name="maxresults">Maximum number of keys to return</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns>A response message containing a list of keys in the vault along with a link to the next page of keys</returns>   
        public async Task<ListKeysResponseMessage> GetKeysAsync(string vault, int? maxresults = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(vault))
                throw new ArgumentNullException("vault");

            return await Do(async () =>
            {
                var response = await _internalClient.Keys.ListAsync(vault, maxresults, cancellationToken).ConfigureAwait(false);

                return JsonConvert.DeserializeObject<ListKeysResponseMessage>(response.KeyOpResponse);

            }).ConfigureAwait(false);
        }

        /// <summary>
        /// List the next page of keys
        /// </summary>
        /// <param name="nextLink">nextLink value from a previous call to GetKeys or GetKeysNext</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns></returns>
        public async Task<ListKeysResponseMessage> GetKeysNextAsync(string nextLink, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(nextLink))
                throw new ArgumentNullException("nextLink");

            return await Do(async () =>
            {
                var response = await _internalClient.Keys.ListNextAsync(nextLink, cancellationToken).ConfigureAwait(false);

                return JsonConvert.DeserializeObject<ListKeysResponseMessage>(response.KeyOpResponse);

            }).ConfigureAwait(false);
        }

        /// <summary>
        /// List the versions of the specified key
        /// </summary>
        /// <param name="vault">The URL for the vault containing the key, e.g. https://myvault.vault.azure.net</param>
        /// <param name="keyName">Name of the key</param>
        /// <param name="maxresults">Maximum number of keys to return</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns>A response message containing a list of keys along with a link to the next page of keys</returns>
        public async Task<ListKeysResponseMessage> GetKeyVersionsAsync(string vault, string keyName, int? maxresults = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(vault))
                throw new ArgumentNullException("vault");

            if (string.IsNullOrEmpty(keyName))
                throw new ArgumentNullException("keyName");

            return await Do(async () =>
            {
                var response = await _internalClient.Keys.ListVersionsAsync(vault, keyName, maxresults, cancellationToken).ConfigureAwait(false);

                return JsonConvert.DeserializeObject<ListKeysResponseMessage>(response.KeyOpResponse);

            }).ConfigureAwait(false);
        }

        /// <summary>
        /// List the next page of key versions
        /// </summary>
        /// <param name="nextLink">nextLink value from a previous call to GetKeyVersions or GetKeyVersionsNext</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns>A response message containing a list of keys along with a link to the next page of keys</returns>
        public async Task<ListKeysResponseMessage> GetKeyVersionsNextAsync(string nextLink, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(nextLink))
                throw new ArgumentNullException("nextLink");

            return await Do(async () =>
            {
                var response = await _internalClient.Keys.ListVersionsNextAsync(nextLink, cancellationToken).ConfigureAwait(false);

                return JsonConvert.DeserializeObject<ListKeysResponseMessage>(response.KeyOpResponse);

            }).ConfigureAwait(false);
        }

        /// <summary>
        /// Deletes the specified key
        /// </summary>
        /// <param name="vault">The vault name, e.g. https://myvault.vault.azure.net</param>
        /// <param name="keyName">The key name</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns>The public part of the deleted key</returns>
        public async Task<KeyBundle> DeleteKeyAsync(string vault, string keyName, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(vault))
                throw new ArgumentNullException("vault");

            if (string.IsNullOrEmpty(keyName))
                throw new ArgumentNullException("keyName");

            return await Do(async () =>
            {
                var response = await _internalClient.Keys.DeleteKeyAsync(vault, keyName, cancellationToken).ConfigureAwait(false);

                return JsonConvert.DeserializeObject<KeyBundle>(response.KeyOpResponse);

            }).ConfigureAwait(false);
        }

        /// <summary>
        /// Updates the Key Attributes associated with the specified key
        /// </summary>
        /// <param name="vault">The vault name, e.g. https://myvault.vault.azure.net</param>
        /// <param name="keyName">The key name</param>
        /// <param name="keyOps">Json web key operations. For more information on possible key operations, see JsonWebKeyOperation.</param>
        /// <param name="attributes">The new attributes for the key. For more information on key attributes, see KeyAttributes.</param>
        /// <param name="tags">Application-specific metadata in the form of key-value pairs</param>
        /// <returns> The updated key </returns>
        public async Task<KeyBundle> UpdateKeyAsync(string vault, string keyName, string[] keyOps = null, KeyAttributes attributes = null, Dictionary<string, string> tags = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(vault))
                throw new ArgumentNullException("vault");

            if (string.IsNullOrEmpty(keyName))
                throw new ArgumentNullException("keyName");

            var keyIdentifier = new KeyIdentifier(vault, keyName);

            return await UpdateKeyAsync(keyIdentifier.Identifier, keyOps, attributes, tags, cancellationToken).ConfigureAwait(false);
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
        public async Task<KeyBundle> UpdateKeyAsync(string keyIdentifier, string[] keyOps = null, KeyAttributes attributes = null, Dictionary<string, string> tags = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(keyIdentifier))
                throw new ArgumentNullException("keyIdentifier");

            return await Do(async () =>
            {
                var response = await _internalClient.Keys.UpdateAsync(
                    keyIdentifier,
                    CreateUpdateKeyRequest(keyOps, attributes, tags),
                    cancellationToken).ConfigureAwait(false);

                return JsonConvert.DeserializeObject<KeyBundle>(response.KeyOpResponse);

            }).ConfigureAwait(false);
        }

        /// <summary>
        /// Imports a key into the specified vault
        /// </summary>
        /// <param name="vault">The vault name, e.g. https://myvault.vault.azure.net</param>
        /// <param name="keyName">The key name</param>
        /// <param name="keyBundle"> Key bundle </param>
        /// <param name="importToHardware">Whether to import as a hardware key (HSM) or software key </param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns> Imported key bundle to the vault </returns>
        public async Task<KeyBundle> ImportKeyAsync(string vault, string keyName, KeyBundle keyBundle, bool? importToHardware = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(vault))
                throw new ArgumentNullException("vault");

            if (string.IsNullOrEmpty(keyName))
                throw new ArgumentNullException("keyName");

            if (keyBundle == null)
                throw new ArgumentNullException("keyBundle");

            return await Do(async () =>
            {
                var keyIdentifier = new KeyIdentifier(vault, keyName);

                var response = await _internalClient.Keys.ImportAsync(
                    keyIdentifier.Identifier,
                    CreateImportKeyRequest(importToHardware, keyBundle),
                    cancellationToken).ConfigureAwait(false);

                return JsonConvert.DeserializeObject<KeyBundle>(response.KeyOpResponse);

            }).ConfigureAwait(false);

        }

        /// <summary>
        /// Requests that a backup of the specified key be downloaded to the client.
        /// </summary>
        /// <param name="vault">The vault name, e.g. https://myvault.vault.azure.net</param>
        /// <param name="keyName">The key name</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns>The backup blob containing the backed up key</returns>
        public async Task<byte[]> BackupKeyAsync(string vault, string keyName, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(vault))
                throw new ArgumentNullException("vault");

            if (string.IsNullOrEmpty(keyName))
                throw new ArgumentNullException("keyName");

            return await Do(async () =>
            {
                var keyIdentifier = new KeyIdentifier(vault, keyName);

                var response = await _internalClient.Keys.BackupAsync(keyIdentifier.Identifier, cancellationToken).ConfigureAwait(false);

                return JsonConvert.DeserializeObject<BackupKeyResponseMessage>(response.KeyOpResponse).Value;

            }).ConfigureAwait(false);
        }

        /// <summary>
        /// Restores the backup key in to a vault 
        /// </summary>
        /// <param name="vault">The vault name, e.g. https://myvault.vault.azure.net</param>
        /// <param name="keyBundleBackup"> the backup blob associated with a key bundle </param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns> Restored key bundle in the vault </returns>
        public async Task<KeyBundle> RestoreKeyAsync(string vault, byte[] keyBundleBackup, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(vault))
                throw new ArgumentNullException("vault");

            if (keyBundleBackup == null)
                throw new ArgumentNullException("keyBundleBackup");

            return await Do(async () =>
            {
                var response = await _internalClient.Keys.RestoreAsync(
                    vault,
                    CreateRestoreKeyRequest(keyBundleBackup),
                    cancellationToken).ConfigureAwait(false);

                return JsonConvert.DeserializeObject<KeyBundle>(response.KeyOpResponse);

            }).ConfigureAwait(false);
        }

        #endregion

        #region Secrets Operations

        /// <summary>
        /// Gets a secret.
        /// </summary>
        /// <param name="vault">The URL for the vault containing the secrets.</param>
        /// <param name="secretName">The name the secret in the given vault.</param>
        /// <param name="secretVersion">The version of the secret (optional)</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns>A response message containing the secret</returns>
        public async Task<Secret> GetSecretAsync(string vault, string secretName, string secretVersion = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(vault))
                throw new ArgumentNullException("vault");

            if (string.IsNullOrEmpty(secretName))
                throw new ArgumentNullException("secretName");

            var secretIdentifier = new SecretIdentifier(vault, secretName, secretVersion);

            return await GetSecretAsync(secretIdentifier.Identifier, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a secret.
        /// </summary>
        /// <param name="secretIdentifier">The URL for the secret.</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns>A response message containing the secret</returns>
        public async Task<Secret> GetSecretAsync(string secretIdentifier, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(secretIdentifier))
                throw new ArgumentNullException("secretIdentifier");

            return await Do(async () =>
            {
                var response = await _internalClient.Secrets.GetAsync(secretIdentifier, cancellationToken).ConfigureAwait(false);

                return JsonConvert.DeserializeObject<Secret>(response.Response);

            }).ConfigureAwait(false);
        }

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
        public async Task<Secret> SetSecretAsync(string vault, string secretName, string value, Dictionary<string, string> tags = null, string contentType = null, SecretAttributes secretAttributes = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(vault))
                throw new ArgumentNullException("vault");

            if (string.IsNullOrEmpty(secretName))
                throw new ArgumentNullException("secretName");

            var secretIdentifier = new SecretIdentifier(vault, secretName);

            return await Do(async () =>
            {
                var response = await _internalClient.Secrets.SetAsync(
                    secretIdentifier.BaseIdentifier,
                    CreateSecretRequest(value, tags, contentType, secretAttributes),
                    cancellationToken).ConfigureAwait(false);

                return JsonConvert.DeserializeObject<Secret>(response.Response);

            }).ConfigureAwait(false);
        }

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
        public async Task<Secret> UpdateSecretAsync(string vault, string secretName, string contentType = null, SecretAttributes secretAttributes = null, Dictionary<string, string> tags = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(vault))
                throw new ArgumentNullException("vault");

            if (string.IsNullOrEmpty(secretName))
                throw new ArgumentNullException("secretName");

            var secretIdentifier = new SecretIdentifier(vault, secretName);

            return await UpdateSecretAsync(
                secretIdentifier.Identifier, 
                contentType, 
                secretAttributes, 
                tags, 
                cancellationToken).ConfigureAwait(false);
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
        public async Task<Secret> UpdateSecretAsync(string secretIdentifier, string contentType = null, SecretAttributes secretAttributes = null, Dictionary<string, string> tags = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(secretIdentifier))
                throw new ArgumentNullException("secretIdentifier");

            return await Do(async () =>
            {
                var response = await _internalClient.Secrets.UpdateAsync(
                    secretIdentifier,
                    CreateUpdateSecretRequest(contentType, tags, secretAttributes),
                    cancellationToken).ConfigureAwait(false);

                return JsonConvert.DeserializeObject<Secret>(response.Response);

            }).ConfigureAwait(false);
        }

        /// <summary>
        /// Deletes a secret from the specified vault.
        /// </summary>
        /// <param name="vault">The URL for the vault containing the secrets.</param>
        /// <param name="secretName">The name of the secret in the given vault.</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns>The deleted secret</returns>
        public async Task<Secret> DeleteSecretAsync(string vault, string secretName, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(vault))
                throw new ArgumentNullException("vault");

            if (string.IsNullOrEmpty(secretName))
                throw new ArgumentNullException("secretName");

            return await Do(async () =>
            {
                var secretIdentifier = new SecretIdentifier(vault, secretName);

                var response = await _internalClient.Secrets.DeleteAsync(secretIdentifier.BaseIdentifier, cancellationToken).ConfigureAwait(false);

                return JsonConvert.DeserializeObject<Secret>(response.Response);

            }).ConfigureAwait(false);
        }

        /// <summary>
        /// List secrets in the specified vault
        /// </summary>
        /// <param name="vault">The URL for the vault containing the secrets.</param>
        /// <param name="maxresults">Maximum number of secrets to return</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns>A response message containing a list of secrets in the vault along with a link to the next page of secrets</returns>              
        public async Task<ListSecretsResponseMessage> GetSecretsAsync(string vault, int? maxresults = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(vault))
                throw new ArgumentNullException("vault");

            return await Do(async () =>
            {
                var response = await _internalClient.Secrets.ListAsync(vault, maxresults, cancellationToken).ConfigureAwait(false);

                return JsonConvert.DeserializeObject<ListSecretsResponseMessage>(response.Response);

            }).ConfigureAwait(false);
        }

        /// <summary>
        /// List the next page of secrets
        /// </summary>
        /// <param name="nextLink">nextLink value from a previous call to GetSecrets or GetSecretsNext</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns>A response message containing a list of secrets in the vault along with a link to the next page of secrets</returns>
        public async Task<ListSecretsResponseMessage> GetSecretsNextAsync(string nextLink, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(nextLink))
                throw new ArgumentNullException("nextLink");

            return await Do(async () =>
            {
                var response = await _internalClient.Secrets.ListNextAsync(nextLink, cancellationToken).ConfigureAwait(false);

                return JsonConvert.DeserializeObject<ListSecretsResponseMessage>(response.Response);

            }).ConfigureAwait(false);
        }

        /// <summary>
        /// List the versions of a secret
        /// </summary>
        /// <param name="vault">The URL for the vault containing the secret</param>
        /// <param name="secretName">The name of the secret</param>
        /// <param name="maxresults">Maximum number of secrets to return</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns>A response message containing a list of secrets along with a link to the next page of secrets</returns>
        public async Task<ListSecretsResponseMessage> GetSecretVersionsAsync(string vault, string secretName, int? maxresults = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(vault))
                throw new ArgumentNullException("vault");

            if (string.IsNullOrEmpty(secretName))
                throw new ArgumentNullException("secretName");

            return await Do(async () =>
            {
                var response = await _internalClient.Secrets.ListVersionsAsync(vault, secretName, maxresults, cancellationToken).ConfigureAwait(false);

                return JsonConvert.DeserializeObject<ListSecretsResponseMessage>(response.Response);

            }).ConfigureAwait(false);
        }

        /// <summary>
        /// List the next page of versions of a secret
        /// </summary>
        /// <param name="nextLink">nextLink value from a previous call to GetSecretVersions or GetSecretVersionsNext</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns>A response message containing a list of secrets in the vault along with a link to the next page of secrets</returns>
        public async Task<ListSecretsResponseMessage> GetSecretVersionsNextAsync(string nextLink, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(nextLink))
                throw new ArgumentNullException("nextLink");

            return await Do(async () =>
            {
                var response = await _internalClient.Secrets.ListVersionsNextAsync(nextLink, cancellationToken);

                return JsonConvert.DeserializeObject<ListSecretsResponseMessage>(response.Response);
            });
        }

        #endregion

        #region Helper Methods
        private async Task<T> Do<T>(Func<Task<T>> func)
        {
            try
            {
                return await func().ConfigureAwait(false);
            }
            catch (CloudException cloudException)
            {
                ErrorResponseMessage error;

                var errorText = cloudException.Response.Content;

                try
                {
                    error = JsonConvert.DeserializeObject<ErrorResponseMessage>(errorText);
                }
                catch (Exception)
                {
                    // Error deserialization failed, attempt to get some data for the client
                    error = new ErrorResponseMessage()
                    {
                        Error = new Error()
                        {
                            Code = "Unknown",
                            Message = string.Format(
                                "HTTP {0}: {1}. Details: {2}",
                                cloudException.Response.StatusCode.ToString(),                                
                                cloudException.Response.ReasonPhrase,
                                errorText),
                        },
                    };
                }

                throw new KeyVaultClientException(
                    cloudException.Response.StatusCode,
                    cloudException.Request.RequestUri,
                    error != null ? error.Error : null);
            }
        }

        private static KeyOpRequestMessageWithRawJsonContent CreateKeyOpRequest(string algorithm, byte[] plainText)
        {
            if (string.IsNullOrEmpty(algorithm))
                throw new ArgumentNullException("algorithm");

            if (plainText == null)
                throw new ArgumentNullException("plainText");

            return new KeyOpRequestMessageWithRawJsonContent { RawJsonRequest = new KeyOperationRequest { Alg = algorithm, Value = plainText }.ToString() };
        }

        private static KeyOpRequestMessageWithRawJsonContent CreateVerifyRequest(string algorithm, byte[] digest, byte[] signature)
        {
            if (string.IsNullOrEmpty(algorithm))
                throw new ArgumentNullException("algorithm");

            if (digest == null)
                throw new ArgumentNullException("digest");

            return new KeyOpRequestMessageWithRawJsonContent { RawJsonRequest = JsonConvert.SerializeObject(new VerifyRequestMessage { Alg = algorithm, Value = signature, Digest = digest }) };
        }

        private static KeyOpRequestMessageWithRawJsonContent CreateKeyRequest(string keyType, int? keySize = null, string[] key_ops = null, KeyAttributes keyAttributes = null, Dictionary<string, string> tags = null)
        {
            if (string.IsNullOrEmpty(keyType))
                throw new ArgumentNullException("keyType");

            if (!JsonWebKeyType.AllTypes.Contains(keyType))
                throw new ArgumentOutOfRangeException("keyType");

            var request = new CreateKeyRequestMessage { Kty = keyType, KeySize = keySize, KeyOps = key_ops, Attributes = keyAttributes, Tags = tags };

            return new KeyOpRequestMessageWithRawJsonContent { RawJsonRequest = JsonConvert.SerializeObject(request) };
        }

        private static KeyOpRequestMessageWithRawJsonContent CreateUpdateKeyRequest(string[] keyOps = null, KeyAttributes keyAttributes = null, Dictionary<string, string> tags = null)
        {
            var request = new UpdateKeyRequestMessage { KeyOps = keyOps, Attributes = keyAttributes, Tags = tags };

            return new KeyOpRequestMessageWithRawJsonContent { RawJsonRequest = JsonConvert.SerializeObject(request) };
        }

        private static KeyOpRequestMessageWithRawJsonContent CreateImportKeyRequest(bool? hsm, KeyBundle keyBundle)
        {
            var request = new ImportKeyRequestMessage { Hsm = hsm, Key = keyBundle.Key, Attributes = keyBundle.Attributes, Tags = keyBundle.Tags };

            return new KeyOpRequestMessageWithRawJsonContent { RawJsonRequest = JsonConvert.SerializeObject(request) };
        }

        private static KeyOpRequestMessageWithRawJsonContent CreateRestoreKeyRequest(byte[] keyBundleBackup)
        {
            var request = new RestoreKeyRequestMessage { Value = keyBundleBackup };

            return new KeyOpRequestMessageWithRawJsonContent { RawJsonRequest = JsonConvert.SerializeObject(request) };
        }

        private static SecretRequestMessageWithRawJsonContent CreateSecretRequest(string value,
            Dictionary<string, string> tags, string contentType, SecretAttributes secretAttributes)
        {
            var request = new Secret
            {
                Value = value,
                ContentType = contentType,
                Tags = tags,
                Attributes = secretAttributes
            };

            return new SecretRequestMessageWithRawJsonContent() { RawJsonRequest = JsonConvert.SerializeObject(request) };
        }

        private static SecretRequestMessageWithRawJsonContent CreateUpdateSecretRequest(string contentType = null,
            Dictionary<string, string> tags = null, SecretAttributes secretAttributes = null)
        {
            var request = new Secret
            {
                ContentType = contentType,
                Tags = tags,
                Attributes = secretAttributes
            };

            return new SecretRequestMessageWithRawJsonContent() { RawJsonRequest = JsonConvert.SerializeObject(request) };
        }
        #endregion
    }
}
