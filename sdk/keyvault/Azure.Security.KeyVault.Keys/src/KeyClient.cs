// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Azure.Core;
using Azure.Core.Pipeline;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// The KeyClient provides synchronous and asynchronous methods to manage <see cref="Key"/> in the Azure Key Vault. The client
    /// supports creating, retrieving, updating, deleting, purging, backing up, restoring and listing the <see cref="Key"/>.
    /// The client also supports listing <see cref="DeletedKey"/> for a soft-delete enabled Azure Key Vault.
    /// </summary>
    public partial class KeyClient
    {
        private readonly Uri _vaultUri;
        private readonly HttpPipeline _pipeline;

        /// <summary>
        /// Protected constructor to allow mocking
        /// </summary>
        protected KeyClient()
        {

        }

        /// <summary>
        /// Initializes a new instance of the KeyClient class.
        /// </summary>
        /// <param name="vaultUri">Endpoint URL for the Azure Key Vault service.</param>
        /// <param name="credential">Represents a credential capable of providing an OAuth token.</param>
        public KeyClient(Uri vaultUri, TokenCredential credential)
            : this(vaultUri, credential, null)
        {

        }

        /// <summary>
        /// Initializes a new instance of the KeyClient class.
        /// </summary>
        /// <param name="vaultUri">Endpoint URL for the Azure Key Vault service.</param>
        /// <param name="credential">Represents a credential capable of providing an OAuth token.</param>
        /// <param name="options">Options that allow to configure the management of the request sent to Key Vault.</param>
        public KeyClient(Uri vaultUri, TokenCredential credential, KeyClientOptions options)
        {
            _vaultUri = vaultUri ?? throw new ArgumentNullException(nameof(credential));
            options = options ?? new KeyClientOptions();
            this.ApiVersion = options.GetVersionString();

            _pipeline = HttpPipelineBuilder.Build(options,
                    bufferResponse: true,
                    new BearerTokenAuthenticationPolicy(credential, "https://vault.azure.net/.default"));
        }

        /// <summary>
        /// Creates and stores a new key in Key Vault.
        /// </summary>
        /// <remarks>
        /// The create key operation can be used to create any key type in Azure Key
        /// Vault. If the named key already exists, Azure Key Vault creates a new
        /// version of the key. It requires the keys/create permission.
        /// </remarks>
        /// <param name="name">The name of the key.</param>
        /// <param name="keyType">The type of key to create. See <see cref="KeyType"/> for valid values.</param>
        /// <param name="keyOptions">Specific attributes with information about the key.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual Response<Key> CreateKey(string name, KeyType keyType, KeyCreateOptions keyOptions = default, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} can't be empty or null");
            if (keyType == default) throw new ArgumentNullException(nameof(keyType));

            var parameters = new KeyRequestParameters(keyType, keyOptions);

            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Security.KeyVault.Keys.KeyClient.CreateKey");
            scope.AddAttribute("key", name);
            scope.Start();

            try
            {
                return SendRequest(RequestMethod.Post, parameters, () => new Key(name), cancellationToken, KeysPath, name, "/create");
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Creates and stores a new key in Key Vault.
        /// </summary>
        /// <remarks>
        /// The create key operation can be used to create any key type in Azure Key
        /// Vault. If the named key already exists, Azure Key Vault creates a new
        /// version of the key. It requires the keys/create permission.
        /// </remarks>
        /// <param name="name">The name of the key.</param>
        /// <param name="keyType">The type of key to create. See <see cref="KeyType"/> for valid values.</param>
        /// <param name="keyOptions">Specific attributes with information about the key.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual async Task<Response<Key>> CreateKeyAsync(string name, KeyType keyType, KeyCreateOptions keyOptions = default, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} can't be empty or null");
            if (keyType == default) throw new ArgumentNullException(nameof(keyType));

            var parameters = new KeyRequestParameters(keyType, keyOptions);

            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Security.KeyVault.Keys.KeyClient.CreateKey");
            scope.AddAttribute("key", name);
            scope.Start();

            try
            {
                return await SendRequestAsync(RequestMethod.Post, parameters, () => new Key(name), cancellationToken, KeysPath, name, "/create").ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Creates and stores a new Elliptic Curve key in Key Vault.
        /// </summary>
        /// <remarks>
        /// If the named key already exists, Azure Key Vault creates a new
        /// version of the key. It requires the keys/create permission.
        /// </remarks>
        /// <param name="ecKey">The key options object containing information about the Elliptic Curve key being created.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual Response<Key> CreateEcKey(EcKeyCreateOptions ecKey, CancellationToken cancellationToken = default)
        {
            if (ecKey == default) throw new ArgumentNullException(nameof(ecKey));

            var parameters = new KeyRequestParameters(ecKey);

            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Security.KeyVault.Keys.KeyClient.CreateEcKey");
            scope.AddAttribute("key", ecKey.Name);
            scope.Start();

            try
            {
                return SendRequest(RequestMethod.Post, parameters, () => new Key(ecKey.Name), cancellationToken, KeysPath, ecKey.Name, "/create");
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Creates and stores a new Elliptic Curve key in Key Vault.
        /// </summary>
        /// <remarks>
        /// If the named key already exists, Azure Key Vault creates a new
        /// version of the key. It requires the keys/create permission.
        /// </remarks>
        /// <param name="ecKey">The key options object containing information about the Elliptic Curve key being created.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual async Task<Response<Key>> CreateEcKeyAsync(EcKeyCreateOptions ecKey, CancellationToken cancellationToken = default)
        {
            if (ecKey == default) throw new ArgumentNullException(nameof(ecKey));

            var parameters = new KeyRequestParameters(ecKey);

            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Security.KeyVault.Keys.KeyClient.CreateEcKey");
            scope.AddAttribute("key", ecKey.Name);
            scope.Start();

            try
            {
                return await SendRequestAsync(RequestMethod.Post, parameters, () => new Key(ecKey.Name), cancellationToken, KeysPath, ecKey.Name, "/create").ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Creates and stores a new RSA key in Key Vault.
        /// </summary>
        /// <remarks>
        /// If the named key already exists, Azure Key Vault creates a new
        /// version of the key. It requires the keys/create permission.
        /// </remarks>
        /// <param name="rsaKey">The key options object containing information about the RSA key being created.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual Response<Key> CreateRsaKey(RsaKeyCreateOptions rsaKey, CancellationToken cancellationToken = default)
        {
            if (rsaKey == default) throw new ArgumentNullException(nameof(rsaKey));

            var parameters = new KeyRequestParameters(rsaKey);

            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Security.KeyVault.Keys.KeyClient.CreateRsaKey");
            scope.AddAttribute("key", rsaKey.Name);
            scope.Start();

            try
            {
                return SendRequest(RequestMethod.Post, parameters, () => new Key(rsaKey.Name), cancellationToken, KeysPath, rsaKey.Name, "/create");
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Creates and stores a new RSA key in Key Vault.
        /// </summary>
        /// <remarks>
        /// If the named key already exists, Azure Key Vault creates a new
        /// version of the key. It requires the keys/create permission.
        /// </remarks>
        /// <param name="rsaKey">The key options object containing information about the RSA key being created.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual async Task<Response<Key>> CreateRsaKeyAsync(RsaKeyCreateOptions rsaKey, CancellationToken cancellationToken = default)
        {
            if (rsaKey == default) throw new ArgumentNullException(nameof(rsaKey));

            var parameters = new KeyRequestParameters(rsaKey);

            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Security.KeyVault.Keys.KeyClient.CreateRsaKey");
            scope.AddAttribute("key", rsaKey.Name);
            scope.Start();

            try
            {
                return await SendRequestAsync(RequestMethod.Post, parameters, () => new Key(rsaKey.Name), cancellationToken, KeysPath, rsaKey.Name, "/create").ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The update key operation changes specified attributes of a stored key and
        /// can be applied to any key type and key version stored in Azure Key Vault.
        /// </summary>
        /// <remarks>
        /// In order to perform this operation, the key must already exist in the Key
        /// Vault. Note: The cryptographic material of a key itself cannot be changed.
        /// This operation requires the keys/update permission.
        /// </remarks>
        /// <param name="key">The <see cref="KeyBase"/> object with updated properties.</param>
        /// <param name="keyOperations">List of supported <see cref="KeyOperations"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual Response<Key> UpdateKey(KeyBase key, IEnumerable<KeyOperations> keyOperations, CancellationToken cancellationToken = default)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));
            if (key.Version == null) throw new ArgumentNullException($"{nameof(key)}.{nameof(key.Version)}");
            if (keyOperations == null) throw new ArgumentNullException(nameof(keyOperations));

            var parameters = new KeyRequestParameters(key, keyOperations);

            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Security.KeyVault.Keys.KeyClient.UpdateKey");
            scope.AddAttribute("key", key.Name);
            scope.Start();

            try
            {
                return SendRequest(RequestMethod.Patch, parameters, () => new Key(key.Name), cancellationToken, KeysPath, key.Name, "/", key.Version);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The update key operation changes specified attributes of a stored key and
        /// can be applied to any key type and key version stored in Azure Key Vault.
        /// </summary>
        /// <remarks>
        /// In order to perform this operation, the key must already exist in the Key
        /// Vault. Note: The cryptographic material of a key itself cannot be changed.
        /// This operation requires the keys/update permission.
        /// </remarks>
        /// <param name="key">The <see cref="KeyBase"/> object with updated properties.</param>
        /// <param name="keyOperations">List of supported <see cref="KeyOperations"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual async Task<Response<Key>> UpdateKeyAsync(KeyBase key, IEnumerable<KeyOperations> keyOperations, CancellationToken cancellationToken = default)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));
            if (key.Version == null) throw new ArgumentNullException($"{nameof(key)}.{nameof(key.Version)}");
            if (keyOperations == null) throw new ArgumentNullException(nameof(keyOperations));

            var parameters = new KeyRequestParameters(key, keyOperations);

            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Security.KeyVault.Keys.KeyClient.UpdateKey");
            scope.AddAttribute("key", key.Name);
            scope.Start();

            try
            {
                return await SendRequestAsync(RequestMethod.Patch, parameters, () => new Key(key.Name), cancellationToken, KeysPath, key.Name, "/", key.Version).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the public part of a stored key.
        /// </summary>
        /// <remarks>
        /// The get key operation is applicable to all key types. If the requested key
        /// is symmetric, then no key material is released in the response. This
        /// operation requires the keys/get permission.
        /// </remarks>
        /// <param name="name">The name of the key.</param>
        /// <param name="version">The version of the key.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual Response<Key> GetKey(string name, string version = null, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} can't be empty or null");

            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Security.KeyVault.Keys.KeyClient.GetKey");
            scope.AddAttribute("key", name);
            scope.Start();

            try
            {
                return SendRequest(RequestMethod.Get, () => new Key(name), cancellationToken, KeysPath, name, "/", version);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the public part of a stored key.
        /// </summary>
        /// <remarks>
        /// The get key operation is applicable to all key types. If the requested key
        /// is symmetric, then no key material is released in the response. This
        /// operation requires the keys/get permission.
        /// </remarks>
        /// <param name="name">The name of the key.</param>
        /// <param name="version">The version of the key.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual async Task<Response<Key>> GetKeyAsync(string name, string version = null, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} can't be empty or null");

            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Security.KeyVault.Keys.KeyClient.GetKey");
            scope.AddAttribute("key", name);
            scope.Start();

            try
            {
                return await SendRequestAsync(RequestMethod.Get, () => new Key(name), cancellationToken, KeysPath, name, "/", version).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// List keys in the specified vault.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of the keys in the Key Vault that contains the public part of a stored key.
        /// The list operation is applicable to all key types, however only the base key identifier,
        /// attributes, and tags are provided in the response. Individual versions of a
        /// key are not listed in the response. This operation requires the keys/list
        /// permission.
        /// </remarks>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual IEnumerable<Response<KeyBase>> GetKeys(CancellationToken cancellationToken = default)
        {
            Uri firstPageUri = CreateFirstPageUri(KeysPath);

            return PageResponseEnumerator.CreateEnumerable(nextLink => GetPage(firstPageUri, nextLink, () => new KeyBase(), "Azure.Security.KeyVault.Keys.KeyClient.GetKeys", cancellationToken));
        }

        /// <summary>
        /// List keys in the specified vault.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of the keys in the Key Vault that contains the public part of a stored key.
        /// The list operation is applicable to all key types, however only the base key identifier,
        /// attributes, and tags are provided in the response. Individual versions of a
        /// key are not listed in the response. This operation requires the keys/list
        /// permission.
        /// </remarks>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual AsyncCollection<KeyBase> GetKeysAsync(CancellationToken cancellationToken = default)
        {
            Uri firstPageUri = CreateFirstPageUri(KeysPath);

            return PageResponseEnumerator.CreateAsyncEnumerable(nextLink => GetPageAsync(firstPageUri, nextLink, () => new KeyBase(), "Azure.Security.KeyVault.Keys.KeyClient.GetKeys", cancellationToken));
        }

        /// <summary>
        /// Retrieves a list of individual key versions with the same key name.
        /// </summary>
        /// <remarks>
        /// The full key identifier, attributes, and tags are provided in the response.
        /// This operation requires the keys/list permission.
        /// </remarks>
        /// <param name="name">The name of the key.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual IEnumerable<Response<KeyBase>> GetKeyVersions(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} can't be empty or null");

            Uri firstPageUri = CreateFirstPageUri($"{KeysPath}{name}/versions");

            return PageResponseEnumerator.CreateEnumerable(nextLink => GetPage(firstPageUri, nextLink, () => new KeyBase(), "Azure.Security.KeyVault.Keys.KeyClient.GetKeyVersions", cancellationToken));
        }

        /// <summary>
        /// Retrieves a list of individual key versions with the same key name.
        /// </summary>
        /// <remarks>
        /// The full key identifier, attributes, and tags are provided in the response.
        /// This operation requires the keys/list permission.
        /// </remarks>
        /// <param name="name">The name of the key.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual AsyncCollection<KeyBase> GetKeyVersionsAsync(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} can't be empty or null");

            Uri firstPageUri = CreateFirstPageUri($"{KeysPath}{name}/versions");

            return PageResponseEnumerator.CreateAsyncEnumerable(nextLink => GetPageAsync(firstPageUri, nextLink, () => new KeyBase(), "Azure.Security.KeyVault.Keys.KeyClient.GetKeyVersions", cancellationToken));
        }

        /// <summary>
        /// Gets the public part of a deleted key.
        /// </summary>
        /// <remarks>
        /// The Get Deleted Key operation is applicable for soft-delete enabled vaults.
        /// While the operation can be invoked on any vault, it will return an error if
        /// invoked on a non soft-delete enabled vault. This operation requires the
        /// keys/get permission.
        /// </remarks>
        /// <param name="name">The name of the key.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual Response<DeletedKey> GetDeletedKey(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} can't be empty or null");

            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Security.KeyVault.Keys.KeyClient.GetDeletedKey");
            scope.AddAttribute("key", name);
            scope.Start();

            try
            {
                return SendRequest(RequestMethod.Get, () => new DeletedKey(name), cancellationToken, DeletedKeysPath, name);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the public part of a deleted key.
        /// </summary>
        /// <remarks>
        /// The Get Deleted Key operation is applicable for soft-delete enabled vaults.
        /// While the operation can be invoked on any vault, it will return an error if
        /// invoked on a non soft-delete enabled vault. This operation requires the
        /// keys/get permission.
        /// </remarks>
        /// <param name="name">The name of the key.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual async Task<Response<DeletedKey>> GetDeletedKeyAsync(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} can't be empty or null");

            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Security.KeyVault.Keys.KeyClient.GetDeletedKey");
            scope.AddAttribute("key", name);
            scope.Start();

            try
            {
                return await SendRequestAsync(RequestMethod.Get, () => new DeletedKey(name), cancellationToken, DeletedKeysPath, name).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes a key of any type from storage in Azure Key Vault.
        /// </summary>
        /// <remarks>
        /// The delete key operation cannot be used to remove individual versions of a
        /// key. This operation removes the cryptographic material associated with the
        /// key, which means the key is not usable for Sign/Verify, Wrap/Unwrap or
        /// Encrypt/Decrypt operations. This operation requires the keys/delete
        /// permission.
        /// </remarks>
        /// <param name="name">The name of the key.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual Response<DeletedKey> DeleteKey(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} can't be empty or null");

            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Security.KeyVault.Keys.KeyClient.DeleteKey");
            scope.AddAttribute("key", name);
            scope.Start();

            try
            {
                return SendRequest(RequestMethod.Delete, () => new DeletedKey(name), cancellationToken, KeysPath, name);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes a key of any type from storage in Azure Key Vault.
        /// </summary>
        /// <remarks>
        /// The delete key operation cannot be used to remove individual versions of a
        /// key. This operation removes the cryptographic material associated with the
        /// key, which means the key is not usable for Sign/Verify, Wrap/Unwrap or
        /// Encrypt/Decrypt operations. This operation requires the keys/delete
        /// permission.
        /// </remarks>
        /// <param name="name">The name of the key.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual async Task<Response<DeletedKey>> DeleteKeyAsync(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} can't be empty or null");

            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Security.KeyVault.Keys.KeyClient.DeleteKey");
            scope.AddAttribute("key", name);
            scope.Start();

            try
            {
                return await SendRequestAsync(RequestMethod.Delete, () => new DeletedKey(name), cancellationToken, KeysPath, name).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists the deleted keys in the specified vault.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of the keys in the Key Vault that contains the public part of a deleted key.
        /// This operation includes deletion-specific information.
        /// The Get Deleted Keys operation is applicable
        /// for vaults enabled for soft-delete. While the operation can be invoked on
        /// any vault, it will return an error if invoked on a non soft-delete enabled
        /// vault. This operation requires the keys/list permission.
        /// </remarks>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual IEnumerable<Response<DeletedKey>> GetDeletedKeys(CancellationToken cancellationToken = default)
        {
            Uri firstPageUri = CreateFirstPageUri(DeletedKeysPath);

            return PageResponseEnumerator.CreateEnumerable(nextLink => GetPage(firstPageUri, nextLink, () => new DeletedKey(), "Azure.Security.KeyVault.Keys.KeyClient.GetDeletedKeys", cancellationToken));
        }

        /// <summary>
        /// Lists the deleted keys in the specified vault.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of the keys in the Key Vault that contains the public part of a deleted key.
        /// This operation includes deletion-specific information.
        /// The Get Deleted Keys operation is applicable
        /// for vaults enabled for soft-delete. While the operation can be invoked on
        /// any vault, it will return an error if invoked on a non soft-delete enabled
        /// vault. This operation requires the keys/list permission.
        /// </remarks>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual AsyncCollection<DeletedKey> GetDeletedKeysAsync(CancellationToken cancellationToken = default)
        {
            Uri firstPageUri = CreateFirstPageUri(DeletedKeysPath);

            return PageResponseEnumerator.CreateAsyncEnumerable(nextLink => GetPageAsync(firstPageUri, nextLink, () => new DeletedKey(), "Azure.Security.KeyVault.Keys.KeyClient.GetDeletedKeys", cancellationToken));
        }

        /// <summary>
        /// Permanently deletes the specified key.
        /// </summary>
        /// <remarks>
        /// The Purge Deleted Key operation is applicable for soft-delete enabled
        /// vaults. While the operation can be invoked on any vault, it will return an
        /// error if invoked on a non soft-delete enabled vault. This operation
        /// requires the keys/purge permission.
        /// </remarks>
        /// <param name="name">The name of the key.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual Response PurgeDeletedKey(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} can't be empty or null");

            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Security.KeyVault.Keys.KeyClient.PurgeDeletedKey");
            scope.AddAttribute("key", name);
            scope.Start();

            try
            {
                return SendRequest(RequestMethod.Delete, cancellationToken, DeletedKeysPath, name);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Permanently deletes the specified key.
        /// </summary>
        /// <remarks>
        /// The Purge Deleted Key operation is applicable for soft-delete enabled
        /// vaults. While the operation can be invoked on any vault, it will return an
        /// error if invoked on a non soft-delete enabled vault. This operation
        /// requires the keys/purge permission.
        /// </remarks>
        /// <param name="name">The name of the key.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual async Task<Response> PurgeDeletedKeyAsync(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} can't be empty or null");

            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Security.KeyVault.Keys.KeyClient.PurgeDeletedKey");
            scope.AddAttribute("key", name);
            scope.Start();

            try
            {
                return await SendRequestAsync(RequestMethod.Delete, cancellationToken, DeletedKeysPath, name).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Recovers the deleted key to its latest version.
        /// </summary>
        /// <remarks>
        /// The Recover Deleted Key operation is applicable for deleted keys in
        /// soft-delete enabled vaults. It recovers the deleted key back to its latest
        /// version under /keys. An attempt to recover an non-deleted key will return
        /// an error. Consider this the inverse of the delete operation on soft-delete
        /// enabled vaults. This operation requires the keys/recover permission.
        /// </remarks>
        /// <param name="name">The name of the key.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual Response<Key> RecoverDeletedKey(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} can't be empty or null");

            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Security.KeyVault.Keys.KeyClient.RecoverDeletedKey");
            scope.AddAttribute("key", name);
            scope.Start();

            try
            {
                return SendRequest(RequestMethod.Post, () => new Key(name), cancellationToken, DeletedKeysPath, name, "/recover");
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Recovers the deleted key to its latest version.
        /// </summary>
        /// <remarks>
        /// The Recover Deleted Key operation is applicable for deleted keys in
        /// soft-delete enabled vaults. It recovers the deleted key back to its latest
        /// version under /keys. An attempt to recover an non-deleted key will return
        /// an error. Consider this the inverse of the delete operation on soft-delete
        /// enabled vaults. This operation requires the keys/recover permission.
        /// </remarks>
        /// <param name="name">The name of the key.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual async Task<Response<Key>> RecoverDeletedKeyAsync(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} can't be empty or null");

            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Security.KeyVault.Keys.KeyClient.RecoverDeletedKey");
            scope.AddAttribute("key", name);
            scope.Start();

            try
            {
                return await SendRequestAsync(RequestMethod.Post, () => new Key(name), cancellationToken, DeletedKeysPath, name, "/recover").ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Requests that a backup of the specified key be downloaded to the client.
        /// </summary>
        /// <remarks>
        /// The Key Backup operation exports a key from Azure Key Vault in a protected
        /// form. Note that this operation does NOT return key material in a form that
        /// can be used outside the Azure Key Vault system, the returned key material
        /// is either protected to a Azure Key Vault HSM or to Azure Key Vault itself.
        /// The intent of this operation is to allow a client to GENERATE a key in one
        /// Azure Key Vault instance, BACKUP the key, and then RESTORE it into another
        /// Azure Key Vault instance. The BACKUP operation may be used to export, in
        /// protected form, any key type from Azure Key Vault. Individual versions of a
        /// key cannot be backed up. BACKUP / RESTORE can be performed within
        /// geographical boundaries only; meaning that a BACKUP from one geographical
        /// area cannot be restored to another geographical area. For example, a backup
        /// from the US geographical area cannot be restored in an EU geographical
        /// area. This operation requires the key/backup permission.
        /// </remarks>
        /// <param name="name">The name of the key.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual Response<byte[]> BackupKey(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} can't be empty or null");

            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Security.KeyVault.Keys.KeyClient.BackupKey");
            scope.AddAttribute("key", name);
            scope.Start();

            try
            {
                var backup = SendRequest(RequestMethod.Post, () => new KeyBackup(), cancellationToken, KeysPath, name, "/backup");

                return new Response<byte[]>(backup.GetRawResponse(), backup.Value.Value);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Requests that a backup of the specified key be downloaded to the client.
        /// </summary>
        /// <remarks>
        /// The Key Backup operation exports a key from Azure Key Vault in a protected
        /// form. Note that this operation does NOT return key material in a form that
        /// can be used outside the Azure Key Vault system, the returned key material
        /// is either protected to a Azure Key Vault HSM or to Azure Key Vault itself.
        /// The intent of this operation is to allow a client to GENERATE a key in one
        /// Azure Key Vault instance, BACKUP the key, and then RESTORE it into another
        /// Azure Key Vault instance. The BACKUP operation may be used to export, in
        /// protected form, any key type from Azure Key Vault. Individual versions of a
        /// key cannot be backed up. BACKUP / RESTORE can be performed within
        /// geographical boundaries only; meaning that a BACKUP from one geographical
        /// area cannot be restored to another geographical area. For example, a backup
        /// from the US geographical area cannot be restored in an EU geographical
        /// area. This operation requires the key/backup permission.
        /// </remarks>
        /// <param name="name">The name of the key.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual async Task<Response<byte[]>> BackupKeyAsync(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} can't be empty or null");

            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Security.KeyVault.Keys.KeyClient.BackupKey");
            scope.AddAttribute("key", name);
            scope.Start();

            try
            {
                var backup = await SendRequestAsync(RequestMethod.Post, () => new KeyBackup(), cancellationToken, KeysPath, name, "/backup").ConfigureAwait(false);

                return new Response<byte[]>(backup.GetRawResponse(), backup.Value.Value);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Restores a backed up key to a vault.
        /// </summary>
        /// <remarks>
        /// Imports a previously backed up key into Azure Key Vault, restoring the key,
        /// its key identifier, attributes and access control policies. The RESTORE
        /// operation may be used to import a previously backed up key. Individual
        /// versions of a key cannot be restored. The key is restored in its entirety
        /// with the same key name as it had when it was backed up. If the key name is
        /// not available in the target Key Vault, the RESTORE operation will be
        /// rejected. While the key name is retained during restore, the final key
        /// identifier will change if the key is restored to a different vault. Restore
        /// will restore all versions and preserve version identifiers. The RESTORE
        /// operation is subject to security constraints: The target Key Vault must be
        /// owned by the same Microsoft Azure Subscription as the source Key Vault The
        /// user must have RESTORE permission in the target Key Vault. This operation
        /// requires the keys/restore permission.
        /// </remarks>
        /// <param name="backup">The backup blob associated with a key.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual Response<Key> RestoreKey(byte[] backup, CancellationToken cancellationToken = default)
        {
            if (backup == null) throw new ArgumentNullException(nameof(backup));

            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Security.KeyVault.Keys.KeyClient.RestoreKey");
            scope.Start();

            try
            {
                return SendRequest(RequestMethod.Post, new KeyBackup { Value = backup }, () => new Key(), cancellationToken, KeysPath, "/restore");
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Restores a backed up key to a vault.
        /// </summary>
        /// <remarks>
        /// Imports a previously backed up key into Azure Key Vault, restoring the key,
        /// its key identifier, attributes and access control policies. The RESTORE
        /// operation may be used to import a previously backed up key. Individual
        /// versions of a key cannot be restored. The key is restored in its entirety
        /// with the same key name as it had when it was backed up. If the key name is
        /// not available in the target Key Vault, the RESTORE operation will be
        /// rejected. While the key name is retained during restore, the final key
        /// identifier will change if the key is restored to a different vault. Restore
        /// will restore all versions and preserve version identifiers. The RESTORE
        /// operation is subject to security constraints: The target Key Vault must be
        /// owned by the same Microsoft Azure Subscription as the source Key Vault The
        /// user must have RESTORE permission in the target Key Vault. This operation
        /// requires the keys/restore permission.
        /// </remarks>
        /// <param name="backup">The backup blob associated with a key.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual async Task<Response<Key>> RestoreKeyAsync(byte[] backup, CancellationToken cancellationToken = default)
        {
            if (backup == null) throw new ArgumentNullException(nameof(backup));

            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Security.KeyVault.Keys.KeyClient.RestoreKey");
            scope.Start();

            try
            {
                return await SendRequestAsync(RequestMethod.Post, new KeyBackup { Value = backup }, () => new Key(), cancellationToken, KeysPath, "/restore").ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Imports an externally created key, stores it, and returns key parameters
        /// and attributes to the client.
        /// </summary>
        /// <remarks>
        /// The import key operation may be used to import any key type into an Azure
        /// Key Vault. If the named key already exists, Azure Key Vault creates a new
        /// version of the key. This operation requires the keys/import permission.
        /// </remarks>
        /// <param name="name">The name of the key.</param>
        /// <param name="keyMaterial">The <see cref="JsonWebKey"/> being imported.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual Response<Key> ImportKey(string name, JsonWebKey keyMaterial, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} can't be empty or null");
            if (keyMaterial == default) throw new ArgumentNullException(nameof(keyMaterial));

            var keyImportOptions = new KeyImportOptions(name, keyMaterial);

            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Security.KeyVault.Keys.KeyClient.ImportKey");
            scope.AddAttribute("key", name);
            scope.Start();

            try
            {
                return SendRequest(RequestMethod.Put, keyImportOptions, () => new Key(name), cancellationToken, KeysPath, name);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Imports an externally created key, stores it, and returns key parameters
        /// and attributes to the client.
        /// </summary>
        /// <remarks>
        /// The import key operation may be used to import any key type into an Azure
        /// Key Vault. If the named key already exists, Azure Key Vault creates a new
        /// version of the key. This operation requires the keys/import permission.
        /// </remarks>
        /// <param name="name">The name of the key.</param>
        /// <param name="keyMaterial">The <see cref="JsonWebKey"/> being imported.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual async Task<Response<Key>> ImportKeyAsync(string name, JsonWebKey keyMaterial, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} can't be empty or null");
            if (keyMaterial == default) throw new ArgumentNullException(nameof(keyMaterial));

            var keyImportOptions = new KeyImportOptions(name, keyMaterial);

            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Security.KeyVault.Keys.KeyClient.ImportKey");
            scope.AddAttribute("key", name);
            scope.Start();

            try
            {
                return await SendRequestAsync(RequestMethod.Put, keyImportOptions, () => new Key(name), cancellationToken, KeysPath, name).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Imports an externally created key, stores it, and returns key parameters
        /// and attributes to the client.
        /// </summary>
        /// <remarks>
        /// The import key operation may be used to import any key type into an Azure
        /// Key Vault. If the named key already exists, Azure Key Vault creates a new
        /// version of the key. This operation requires the keys/import permission.
        /// </remarks>
        /// <param name="keyImportOptions">The key import configuration object containing information about the <see cref="JsonWebKey"/> being imported.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual Response<Key> ImportKey(KeyImportOptions keyImportOptions, CancellationToken cancellationToken = default)
        {
            if (keyImportOptions == default) throw new ArgumentNullException(nameof(keyImportOptions));

            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Security.KeyVault.Keys.KeyClient.ImportKey");
            scope.AddAttribute("key", keyImportOptions.Name);
            scope.Start();

            try
            {

                return SendRequest(RequestMethod.Put, keyImportOptions, () => new Key(keyImportOptions.Name), cancellationToken, KeysPath, keyImportOptions.Name);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Imports an externally created key, stores it, and returns key parameters
        /// and attributes to the client.
        /// </summary>
        /// <remarks>
        /// The import key operation may be used to import any key type into an Azure
        /// Key Vault. If the named key already exists, Azure Key Vault creates a new
        /// version of the key. This operation requires the keys/import permission.
        /// </remarks>
        /// <param name="keyImportOptions">The key import configuration object containing information about the <see cref="JsonWebKey"/> being imported.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual async Task<Response<Key>> ImportKeyAsync(KeyImportOptions keyImportOptions, CancellationToken cancellationToken = default)
        {
            if (keyImportOptions == default) throw new ArgumentNullException(nameof(keyImportOptions));

            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Security.KeyVault.Keys.KeyClient.ImportKey");
            scope.AddAttribute("key", keyImportOptions.Name);
            scope.Start();

            try
            {
                return await SendRequestAsync(RequestMethod.Put, keyImportOptions, () => new Key(keyImportOptions.Name), cancellationToken, KeysPath, keyImportOptions.Name).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
