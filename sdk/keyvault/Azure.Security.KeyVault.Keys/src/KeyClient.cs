// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// The KeyClient provides synchronous and asynchronous methods to manage <see cref="KeyVaultKey"/> in the Azure Key Vault. The client
    /// supports creating, retrieving, updating, deleting, purging, backing up, restoring, and listing the <see cref="KeyVaultKey"/>.
    /// The client also supports listing <see cref="DeletedKey"/> for a soft-delete enabled Azure Key Vault.
    /// </summary>
    public class KeyClient
    {
        internal const string KeysPath = "/keys/";
        internal const string DeletedKeysPath = "/deletedkeys/";

        private readonly KeyVaultPipeline _pipeline;

        private readonly ClientDiagnostics _clientDiagnostics;

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyClient"/> class for mocking.
        /// </summary>
        protected KeyClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyClient"/> class for the specified vault.
        /// </summary>
        /// <param name="vaultUri">
        /// A <see cref="Uri"/> to the vault on which the client operates. Appears as "DNS Name" in the Azure portal.
        /// If you have a key <see cref="Uri"/>, use <see cref="KeyVaultKeyIdentifier"/> to parse the <see cref="KeyVaultKeyIdentifier.VaultUri"/> and other information.
        /// </param>
        /// <param name="credential">A <see cref="TokenCredential"/> used to authenticate requests to the vault, such as DefaultAzureCredential.</param>
        /// <exception cref="ArgumentNullException"><paramref name="vaultUri"/> or <paramref name="credential"/> is null.</exception>
        public KeyClient(Uri vaultUri, TokenCredential credential)
            : this(vaultUri, credential, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyClient"/> class for the specified vault.
        /// </summary>
        /// <param name="vaultUri">
        /// A <see cref="Uri"/> to the vault on which the client operates. Appears as "DNS Name" in the Azure portal.
        /// If you have a key <see cref="Uri"/>, use <see cref="KeyVaultKeyIdentifier"/> to parse the <see cref="KeyVaultKeyIdentifier.VaultUri"/> and other information.
        /// </param>
        /// <param name="credential">A <see cref="TokenCredential"/> used to authenticate requests to the vault, such as DefaultAzureCredential.</param>
        /// <param name="options"><see cref="KeyClientOptions"/> that allow to configure the management of the request sent to Key Vault.</param>
        /// <exception cref="ArgumentNullException"><paramref name="vaultUri"/> or <paramref name="credential"/> is null.</exception>
        public KeyClient(Uri vaultUri, TokenCredential credential, KeyClientOptions options)
        {
            Argument.AssertNotNull(vaultUri, nameof(vaultUri));
            Argument.AssertNotNull(credential, nameof(credential));

            options ??= new KeyClientOptions();
            string apiVersion = options.GetVersionString();

            HttpPipeline pipeline = HttpPipelineBuilder.Build(options,
                    new ChallengeBasedAuthenticationPolicy(credential));

            _clientDiagnostics = new ClientDiagnostics(options);
            _pipeline = new KeyVaultPipeline(vaultUri, apiVersion, pipeline, _clientDiagnostics);
        }

        /// <summary>
        /// Gets the <see cref="Uri"/> of the vault used to create this instance of the <see cref="KeyClient"/>.
        /// </summary>
        public virtual Uri VaultUri => _pipeline.VaultUri;

        /// <summary>
        /// Creates and stores a new key in Key Vault. The create key operation can be used to create any key type in Azure Key Vault.
        /// If the named key already exists, Azure Key Vault creates a new version of the key. It requires the keys/create permission.
        /// </summary>
        /// <param name="name">The name of the key.</param>
        /// <param name="keyType">The type of key to create. See <see cref="KeyType"/> for valid values.</param>
        /// <param name="keyOptions">Specific attributes with information about the key.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string, or <paramref name="keyType"/> contains no value.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<KeyVaultKey> CreateKey(string name, KeyType keyType, CreateKeyOptions keyOptions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotDefault(ref keyType, nameof(keyType));

            var parameters = new KeyRequestParameters(keyType, keyOptions);

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(KeyClient)}.{nameof(CreateKey)}");
            scope.AddAttribute("key", name);
            scope.Start();

            try
            {
                return _pipeline.SendRequest(RequestMethod.Post, parameters, () => new KeyVaultKey(name), cancellationToken, KeysPath, name, "/create");
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Creates and stores a new key in Key Vault. The create key operation can be used to create any key type in Azure Key Vault.
        /// If the named key already exists, Azure Key Vault creates a new version of the key. It requires the keys/create permission.
        /// </summary>
        /// <param name="name">The name of the key.</param>
        /// <param name="keyType">The type of key to create. See <see cref="KeyType"/> for valid values.</param>
        /// <param name="keyOptions">Specific attributes with information about the key.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string, or <paramref name="keyType"/> contains no value.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<KeyVaultKey>> CreateKeyAsync(string name, KeyType keyType, CreateKeyOptions keyOptions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotDefault(ref keyType, nameof(keyType));

            var parameters = new KeyRequestParameters(keyType, keyOptions);

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(KeyClient)}.{nameof(CreateKey)}");
            scope.AddAttribute("key", name);
            scope.Start();

            try
            {
                return await _pipeline.SendRequestAsync(RequestMethod.Post, parameters, () => new KeyVaultKey(name), cancellationToken, KeysPath, name, "/create").ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Creates and stores a new Elliptic Curve key in Key Vault. If the named key already exists,
        /// Azure Key Vault creates a new version of the key. It requires the keys/create permission.
        /// </summary>
        /// <param name="ecKeyOptions">The key options object containing information about the Elliptic Curve key being created.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentNullException"><paramref name="ecKeyOptions"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<KeyVaultKey> CreateEcKey(CreateEcKeyOptions ecKeyOptions, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(ecKeyOptions, nameof(ecKeyOptions));

            var parameters = new KeyRequestParameters(ecKeyOptions);

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(KeyClient)}.{nameof(CreateEcKey)}");
            scope.AddAttribute("key", ecKeyOptions.Name);
            scope.Start();

            try
            {
                return _pipeline.SendRequest(RequestMethod.Post, parameters, () => new KeyVaultKey(ecKeyOptions.Name), cancellationToken, KeysPath, ecKeyOptions.Name, "/create");
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Creates and stores a new Elliptic Curve key in Key Vault. If the named key already exists,
        /// Azure Key Vault creates a new version of the key. It requires the keys/create permission.
        /// </summary>
        /// <param name="ecKeyOptions">The key options object containing information about the Elliptic Curve key being created.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentNullException"><paramref name="ecKeyOptions"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<KeyVaultKey>> CreateEcKeyAsync(CreateEcKeyOptions ecKeyOptions, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(ecKeyOptions, nameof(ecKeyOptions));

            var parameters = new KeyRequestParameters(ecKeyOptions);

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(KeyClient)}.{nameof(CreateEcKey)}");
            scope.AddAttribute("key", ecKeyOptions.Name);
            scope.Start();

            try
            {
                return await _pipeline.SendRequestAsync(RequestMethod.Post, parameters, () => new KeyVaultKey(ecKeyOptions.Name), cancellationToken, KeysPath, ecKeyOptions.Name, "/create").ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Creates and stores a new RSA key in Key Vault. If the named key already exists, Azure Key Vault creates a new
        /// version of the key. It requires the keys/create permission.
        /// </summary>
        /// <param name="rsaKeyOptions">The key options object containing information about the RSA key being created.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentNullException"><paramref name="rsaKeyOptions"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<KeyVaultKey> CreateRsaKey(CreateRsaKeyOptions rsaKeyOptions, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(rsaKeyOptions, nameof(rsaKeyOptions));

            var parameters = new KeyRequestParameters(rsaKeyOptions);

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(KeyClient)}.{nameof(CreateRsaKey)}");
            scope.AddAttribute("key", rsaKeyOptions.Name);
            scope.Start();

            try
            {
                return _pipeline.SendRequest(RequestMethod.Post, parameters, () => new KeyVaultKey(rsaKeyOptions.Name), cancellationToken, KeysPath, rsaKeyOptions.Name, "/create");
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Creates and stores a new RSA key in Key Vault. If the named key already exists, Azure Key Vault creates a new
        /// version of the key. It requires the keys/create permission.
        /// </summary>
        /// <param name="rsaKeyOptions">The key options object containing information about the RSA key being created.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentNullException"><paramref name="rsaKeyOptions"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<KeyVaultKey>> CreateRsaKeyAsync(CreateRsaKeyOptions rsaKeyOptions, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(rsaKeyOptions, nameof(rsaKeyOptions));

            var parameters = new KeyRequestParameters(rsaKeyOptions);

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(KeyClient)}.{nameof(CreateRsaKey)}");
            scope.AddAttribute("key", rsaKeyOptions.Name);
            scope.Start();

            try
            {
                return await _pipeline.SendRequestAsync(RequestMethod.Post, parameters, () => new KeyVaultKey(rsaKeyOptions.Name), cancellationToken, KeysPath, rsaKeyOptions.Name, "/create").ConfigureAwait(false);
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
        /// <param name="properties">The <see cref="KeyProperties"/> object with updated properties.</param>
        /// <param name="keyOperations">Optional list of supported <see cref="KeyOperation"/>. If null, no changes will be made to existing key operations.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentNullException"><paramref name="properties"/> is null, or <see cref="KeyProperties.Version"/> of <paramref name="properties"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<KeyVaultKey> UpdateKeyProperties(KeyProperties properties, IEnumerable<KeyOperation> keyOperations = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(properties, nameof(properties));
            Argument.AssertNotNull(properties.Version, $"{nameof(properties)}.{nameof(properties.Version)}");

            var parameters = new KeyRequestParameters(properties, keyOperations);

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(KeyClient)}.{nameof(UpdateKeyProperties)}");
            scope.AddAttribute("key", properties.Name);
            scope.Start();

            try
            {
                return _pipeline.SendRequest(RequestMethod.Patch, parameters, () => new KeyVaultKey(properties.Name), cancellationToken, KeysPath, properties.Name, "/", properties.Version);
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
        /// <param name="properties">The <see cref="KeyProperties"/> object with updated properties.</param>
        /// <param name="keyOperations">Optional list of supported <see cref="KeyOperation"/>. If null, no changes will be made to existing key operations.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentNullException"><paramref name="properties"/> or <paramref name="keyOperations"/> is null, or <see cref="KeyProperties.Version"/> of <paramref name="properties"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<KeyVaultKey>> UpdateKeyPropertiesAsync(KeyProperties properties, IEnumerable<KeyOperation> keyOperations = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(properties, nameof(properties));
            Argument.AssertNotNull(properties.Version, $"{nameof(properties)}.{nameof(properties.Version)}");

            var parameters = new KeyRequestParameters(properties, keyOperations);

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(KeyClient)}.{nameof(UpdateKeyProperties)}");
            scope.AddAttribute("key", properties.Name);
            scope.Start();

            try
            {
                return await _pipeline.SendRequestAsync(RequestMethod.Patch, parameters, () => new KeyVaultKey(properties.Name), cancellationToken, KeysPath, properties.Name, "/", properties.Version).ConfigureAwait(false);
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
        /// is symmetric, then no key is released in the response. This
        /// operation requires the keys/get permission.
        /// </remarks>
        /// <param name="name">The name of the key.</param>
        /// <param name="version">The version of the key.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<KeyVaultKey> GetKey(string name, string version = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(KeyClient)}.{nameof(GetKey)}");
            scope.AddAttribute("key", name);
            scope.Start();

            try
            {
                return _pipeline.SendRequest(RequestMethod.Get, () => new KeyVaultKey(name), cancellationToken, KeysPath, name, "/", version);
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
        /// is symmetric, then no key is released in the response. This
        /// operation requires the keys/get permission.
        /// </remarks>
        /// <param name="name">The name of the key.</param>
        /// <param name="version">The version of the key.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<KeyVaultKey>> GetKeyAsync(string name, string version = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(KeyClient)}.{nameof(GetKey)}");
            scope.AddAttribute("key", name);
            scope.Start();

            try
            {
                return await _pipeline.SendRequestAsync(RequestMethod.Get, () => new KeyVaultKey(name), cancellationToken, KeysPath, name, "/", version).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists the properties of all keys in the specified vault. You can use the returned <see cref="KeyProperties.Name"/> in subsequent calls to <see cref="GetKey"/>.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of the keys in the Key Vault that contains the public part of a stored key.
        /// The list operation is applicable to all key types, however only the base key identifier,
        /// attributes, and tags are provided in the response. Individual versions of a
        /// key are not listed in the response. This operation requires the keys/list
        /// permission.
        /// </remarks>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Pageable<KeyProperties> GetPropertiesOfKeys(CancellationToken cancellationToken = default)
        {
            Uri firstPageUri = _pipeline.CreateFirstPageUri(KeysPath);

            return PageResponseEnumerator.CreateEnumerable(nextLink => _pipeline.GetPage(firstPageUri, nextLink, () => new KeyProperties(), $"{nameof(KeyClient)}.{nameof(GetPropertiesOfKeys)}", cancellationToken));
        }

        /// <summary>
        /// Lists the properties of all keys in the specified vault. You can use the returned <see cref="KeyProperties.Name"/> in subsequent calls to <see cref="GetKeyAsync"/>.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of the keys in the Key Vault that contains the public part of a stored key.
        /// The list operation is applicable to all key types, however only the base key identifier,
        /// attributes, and tags are provided in the response. Individual versions of a
        /// key are not listed in the response. This operation requires the keys/list
        /// permission.
        /// </remarks>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual AsyncPageable<KeyProperties> GetPropertiesOfKeysAsync(CancellationToken cancellationToken = default)
        {
            Uri firstPageUri = _pipeline.CreateFirstPageUri(KeysPath);

            return PageResponseEnumerator.CreateAsyncEnumerable(nextLink => _pipeline.GetPageAsync(firstPageUri, nextLink, () => new KeyProperties(), $"{nameof(KeyClient)}.{nameof(GetPropertiesOfKeys)}", cancellationToken));
        }

        /// <summary>
        /// Lists the properties of all versions of the specified key. You can use the returned <see cref="KeyProperties.Name"/> and <see cref="KeyProperties.Version"/> in subsequent calls to <see cref="GetKey"/>.
        /// </summary>
        /// <remarks>
        /// The full key identifier, attributes, and tags are provided in the response.
        /// This operation requires the keys/list permission.
        /// </remarks>
        /// <param name="name">The name of the key.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Pageable<KeyProperties> GetPropertiesOfKeyVersions(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            Uri firstPageUri = _pipeline.CreateFirstPageUri($"{KeysPath}{name}/versions");

            return PageResponseEnumerator.CreateEnumerable(nextLink => _pipeline.GetPage(firstPageUri, nextLink, () => new KeyProperties(), $"{nameof(KeyClient)}.{nameof(GetPropertiesOfKeyVersions)}", cancellationToken));
        }

        /// <summary>
        /// Lists the properties of all versions of the specified key. You can use the returned <see cref="KeyProperties.Name"/> and <see cref="KeyProperties.Version"/> in subsequent calls to <see cref="GetKeyAsync"/>.
        /// </summary>
        /// <remarks>
        /// The full key identifier, attributes, and tags are provided in the response.
        /// This operation requires the keys/list permission.
        /// </remarks>
        /// <param name="name">The name of the key.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual AsyncPageable<KeyProperties> GetPropertiesOfKeyVersionsAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            Uri firstPageUri = _pipeline.CreateFirstPageUri($"{KeysPath}{name}/versions");

            return PageResponseEnumerator.CreateAsyncEnumerable(nextLink => _pipeline.GetPageAsync(firstPageUri, nextLink, () => new KeyProperties(), $"{nameof(KeyClient)}.{nameof(GetPropertiesOfKeyVersions)}", cancellationToken));
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
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<DeletedKey> GetDeletedKey(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(KeyClient)}.{nameof(GetDeletedKey)}");
            scope.AddAttribute("key", name);
            scope.Start();

            try
            {
                return _pipeline.SendRequest(RequestMethod.Get, () => new DeletedKey(name), cancellationToken, DeletedKeysPath, name);
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
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<DeletedKey>> GetDeletedKeyAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(KeyClient)}.{nameof(GetDeletedKey)}");
            scope.AddAttribute("key", name);
            scope.Start();

            try
            {
                return await _pipeline.SendRequestAsync(RequestMethod.Get, () => new DeletedKey(name), cancellationToken, DeletedKeysPath, name).ConfigureAwait(false);
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
        /// <returns>
        /// A <see cref="DeleteKeyOperation"/> to wait on this long-running operation.
        /// If the Key Vault is soft delete-enabled, you only need to wait for the operation to complete if you need to recover or purge the key;
        /// otherwise, the key is deleted automatically on the <see cref="DeletedKey.ScheduledPurgeDate"/>.
        /// </returns>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual DeleteKeyOperation StartDeleteKey(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(KeyClient)}.{nameof(StartDeleteKey)}");
            scope.AddAttribute("key", name);
            scope.Start();

            try
            {
                Response<DeletedKey> response = _pipeline.SendRequest(RequestMethod.Delete, () => new DeletedKey(name), cancellationToken, KeysPath, name);
                return new DeleteKeyOperation(_pipeline, response);
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
        /// <returns>
        /// A <see cref="DeleteKeyOperation"/> to wait on this long-running operation.
        /// If the Key Vault is soft delete-enabled, you only need to wait for the operation to complete if you need to recover or purge the key;
        /// otherwise, the key is deleted automatically on the <see cref="DeletedKey.ScheduledPurgeDate"/>.
        /// </returns>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<DeleteKeyOperation> StartDeleteKeyAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(KeyClient)}.{nameof(StartDeleteKey)}");
            scope.AddAttribute("key", name);
            scope.Start();

            try
            {
                Response<DeletedKey> response = await _pipeline.SendRequestAsync(RequestMethod.Delete, () => new DeletedKey(name), cancellationToken, KeysPath, name).ConfigureAwait(false);
                return new DeleteKeyOperation(_pipeline, response);
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
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Pageable<DeletedKey> GetDeletedKeys(CancellationToken cancellationToken = default)
        {
            Uri firstPageUri = _pipeline.CreateFirstPageUri(DeletedKeysPath);

            return PageResponseEnumerator.CreateEnumerable(nextLink => _pipeline.GetPage(firstPageUri, nextLink, () => new DeletedKey(), $"{nameof(KeyClient)}.{nameof(GetDeletedKeys)}", cancellationToken));
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
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual AsyncPageable<DeletedKey> GetDeletedKeysAsync(CancellationToken cancellationToken = default)
        {
            Uri firstPageUri = _pipeline.CreateFirstPageUri(DeletedKeysPath);

            return PageResponseEnumerator.CreateAsyncEnumerable(nextLink => _pipeline.GetPageAsync(firstPageUri, nextLink, () => new DeletedKey(), $"{nameof(KeyClient)}.{nameof(GetDeletedKeys)}", cancellationToken));
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
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response PurgeDeletedKey(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(KeyClient)}.{nameof(PurgeDeletedKey)}");
            scope.AddAttribute("key", name);
            scope.Start();

            try
            {
                return _pipeline.SendRequest(RequestMethod.Delete, cancellationToken, DeletedKeysPath, name);
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
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> PurgeDeletedKeyAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(KeyClient)}.{nameof(PurgeDeletedKey)}");
            scope.AddAttribute("key", name);
            scope.Start();

            try
            {
                return await _pipeline.SendRequestAsync(RequestMethod.Delete, cancellationToken, DeletedKeysPath, name).ConfigureAwait(false);
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
        /// <returns>A <see cref="RecoverDeletedKeyOperation"/> to wait on this long-running operation.</returns>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual RecoverDeletedKeyOperation StartRecoverDeletedKey(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(KeyClient)}.{nameof(StartRecoverDeletedKey)}");
            scope.AddAttribute("key", name);
            scope.Start();

            try
            {
                Response<KeyVaultKey> response = _pipeline.SendRequest(RequestMethod.Post, () => new KeyVaultKey(name), cancellationToken, DeletedKeysPath, name, "/recover");
                return new RecoverDeletedKeyOperation(_pipeline, response);
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
        /// <returns>A <see cref="RecoverDeletedKeyOperation"/> to wait on this long-running operation.</returns>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<RecoverDeletedKeyOperation> StartRecoverDeletedKeyAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(KeyClient)}.{nameof(StartRecoverDeletedKey)}");
            scope.AddAttribute("key", name);
            scope.Start();

            try
            {
                Response<KeyVaultKey> response = await _pipeline.SendRequestAsync(RequestMethod.Post, () => new KeyVaultKey(name), cancellationToken, DeletedKeysPath, name, "/recover").ConfigureAwait(false);
                return new RecoverDeletedKeyOperation(_pipeline, response);
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
        /// form. Note that this operation does NOT return the actual key in a form that
        /// can be used outside the Azure Key Vault system, the returned key
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
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<byte[]> BackupKey(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(KeyClient)}.{nameof(BackupKey)}");
            scope.AddAttribute("key", name);
            scope.Start();

            try
            {
                Response<KeyBackup> backup = _pipeline.SendRequest(RequestMethod.Post, () => new KeyBackup(), cancellationToken, KeysPath, name, "/backup");

                return Response.FromValue(backup.Value.Value, backup.GetRawResponse());
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
        /// form. Note that this operation does NOT return the actual key in a form that
        /// can be used outside the Azure Key Vault system, the returned key
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
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<byte[]>> BackupKeyAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(KeyClient)}.{nameof(BackupKey)}");
            scope.AddAttribute("key", name);
            scope.Start();

            try
            {
                Response<KeyBackup> backup = await _pipeline.SendRequestAsync(RequestMethod.Post, () => new KeyBackup(), cancellationToken, KeysPath, name, "/backup").ConfigureAwait(false);

                return Response.FromValue(backup.Value.Value, backup.GetRawResponse());
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
        /// its key identifier, attributes, and access control policies. The RESTORE
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
        /// <exception cref="ArgumentException"><paramref name="backup"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="backup"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<KeyVaultKey> RestoreKeyBackup(byte[] backup, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(backup, nameof(backup));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(KeyClient)}.{nameof(RestoreKeyBackup)}");
            scope.Start();

            try
            {
                return _pipeline.SendRequest(RequestMethod.Post, new KeyBackup { Value = backup }, () => new KeyVaultKey(), cancellationToken, KeysPath, "/restore");
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
        /// its key identifier, attributes, and access control policies. The RESTORE
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
        /// <exception cref="ArgumentException"><paramref name="backup"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="backup"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<KeyVaultKey>> RestoreKeyBackupAsync(byte[] backup, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(backup, nameof(backup));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(KeyClient)}.{nameof(RestoreKeyBackup)}");
            scope.Start();

            try
            {
                return await _pipeline.SendRequestAsync(RequestMethod.Post, new KeyBackup { Value = backup }, () => new KeyVaultKey(), cancellationToken, KeysPath, "/restore").ConfigureAwait(false);
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
        /// <returns>The <see cref="KeyVaultKey"/> that was imported.</returns>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> or <paramref name="keyMaterial"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<KeyVaultKey> ImportKey(string name, JsonWebKey keyMaterial, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(keyMaterial, nameof(keyMaterial));

            var importKeyOptions = new ImportKeyOptions(name, keyMaterial);

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(KeyClient)}.{nameof(ImportKey)}");
            scope.AddAttribute("key", name);
            scope.Start();

            try
            {
                return _pipeline.SendRequest(RequestMethod.Put, importKeyOptions, () => new KeyVaultKey(name), cancellationToken, KeysPath, name);
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
        /// <returns>The <see cref="KeyVaultKey"/> that was imported.</returns>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> or <paramref name="keyMaterial"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<KeyVaultKey>> ImportKeyAsync(string name, JsonWebKey keyMaterial, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(keyMaterial, nameof(keyMaterial));

            var importKeyOptions = new ImportKeyOptions(name, keyMaterial);

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(KeyClient)}.{nameof(ImportKey)}");
            scope.AddAttribute("key", name);
            scope.Start();

            try
            {
                return await _pipeline.SendRequestAsync(RequestMethod.Put, importKeyOptions, () => new KeyVaultKey(name), cancellationToken, KeysPath, name).ConfigureAwait(false);
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
        /// <param name="importKeyOptions">The key import configuration object containing information about the <see cref="JsonWebKey"/> being imported.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The <see cref="KeyVaultKey"/> that was imported.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="importKeyOptions"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<KeyVaultKey> ImportKey(ImportKeyOptions importKeyOptions, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(importKeyOptions, nameof(importKeyOptions));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(KeyClient)}.{nameof(ImportKey)}");
            scope.AddAttribute("key", importKeyOptions.Name);
            scope.Start();

            try
            {
                return _pipeline.SendRequest(RequestMethod.Put, importKeyOptions, () => new KeyVaultKey(importKeyOptions.Name), cancellationToken, KeysPath, importKeyOptions.Name);
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
        /// <param name="importKeyOptions">The key import configuration object containing information about the <see cref="JsonWebKey"/> being imported.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The <see cref="KeyVaultKey"/> that was imported.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="importKeyOptions"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<KeyVaultKey>> ImportKeyAsync(ImportKeyOptions importKeyOptions, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(importKeyOptions, nameof(importKeyOptions));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(KeyClient)}.{nameof(ImportKey)}");
            scope.AddAttribute("key", importKeyOptions.Name);
            scope.Start();

            try
            {
                return await _pipeline.SendRequestAsync(RequestMethod.Put, importKeyOptions, () => new KeyVaultKey(importKeyOptions.Name), cancellationToken, KeysPath, importKeyOptions.Name).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Exports the latest version of a <see cref="KeyVaultKey"/> including the private key if originally created with <see cref="CreateKeyOptions.Exportable"/> set to true,
        /// or imported with <see cref="KeyProperties.Exportable"/> in <see cref="ImportKeyOptions"/> set to true.
        /// </summary>
        /// <remarks>
        /// Requires the <see cref="KeyOperation.Export"/> permission.
        /// </remarks>
        /// <param name="name">The name of the key to export.</param>
        /// <param name="environment">The target environment assertion.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The <see cref="KeyVaultKey"/> that was exported along with the private key if exportable.</returns>
        /// <exception cref="ArgumentException"><paramref name="name"/> or <paramref name="environment"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> or <paramref name="environment"/> is null.</exception>
        /// <seealso cref="ExportKey(string, string, string, CancellationToken)"/>
        public virtual Response<KeyVaultKey> ExportKey(string name, string environment, CancellationToken cancellationToken = default) =>
            ExportKey(name, null, environment, cancellationToken);

        /// <summary>
        /// Exports the latest version of a <see cref="KeyVaultKey"/> including the private key if originally created with <see cref="CreateKeyOptions.Exportable"/> set to true,
        /// or imported with <see cref="KeyProperties.Exportable"/> in <see cref="ImportKeyOptions"/> set to true.
        /// </summary>
        /// <remarks>
        /// Requires the <see cref="KeyOperation.Export"/> permission.
        /// </remarks>
        /// <param name="name">The name of the key to export.</param>
        /// <param name="environment">The target environment assertion.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The <see cref="KeyVaultKey"/> that was exported along with the private key if exportable.</returns>
        /// <exception cref="ArgumentException"><paramref name="name"/> or <paramref name="environment"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> or <paramref name="environment"/> is null.</exception>
        /// <seealso cref="ExportKeyAsync(string, string, string, CancellationToken)"/>
        public virtual async Task<Response<KeyVaultKey>> ExportKeyAsync(string name, string environment, CancellationToken cancellationToken = default) =>
            await ExportKeyAsync(name, null, environment, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Exports a specific version of a <see cref="KeyVaultKey"/> including the private key if originally created with <see cref="CreateKeyOptions.Exportable"/> set to true,
        /// or imported with <see cref="KeyProperties.Exportable"/> in <see cref="ImportKeyOptions"/> set to true.
        /// </summary>
        /// <remarks>
        /// Requires the <see cref="KeyOperation.Export"/> permission.
        /// </remarks>
        /// <param name="name">The name of the key to export.</param>
        /// <param name="version">The optional version of the key to export.</param>
        /// <param name="environment">The target environment assertion.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The <see cref="KeyVaultKey"/> that was exported along with the private key if exportable.</returns>
        /// <exception cref="ArgumentException"><paramref name="name"/> or <paramref name="environment"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> or <paramref name="environment"/> is null.</exception>
        /// <seealso cref="ExportKey(string, string, CancellationToken)"/>
        public virtual Response<KeyVaultKey> ExportKey(string name, string version, string environment, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNullOrEmpty(environment, nameof(environment));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(KeyClient)}.{nameof(ExportKey)}");
            scope.AddAttribute("key", name);
            scope.Start();

            try
            {
                return _pipeline.SendRequest(RequestMethod.Post, new KeyExportParameters(environment), () => new KeyVaultKey(name), cancellationToken, KeysPath, name, "/", version, "/export");
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Exports a specific version of a <see cref="KeyVaultKey"/> including the private key if originally created with <see cref="CreateKeyOptions.Exportable"/> set to true,
        /// or imported with <see cref="KeyProperties.Exportable"/> in <see cref="ImportKeyOptions"/> set to true.
        /// </summary>
        /// <remarks>
        /// Requires the <see cref="KeyOperation.Export"/> permission.
        /// </remarks>
        /// <param name="name">The name of the key to export.</param>
        /// <param name="version">The optional version of the key to export.</param>
        /// <param name="environment">The target environment assertion.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The <see cref="KeyVaultKey"/> that was exported along with the private key if exportable.</returns>
        /// <exception cref="ArgumentException"><paramref name="name"/> or <paramref name="environment"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> or <paramref name="environment"/> is null.</exception>
        /// <seealso cref="ExportKeyAsync(string, string, CancellationToken)"/>
        public virtual async Task<Response<KeyVaultKey>> ExportKeyAsync(string name, string version, string environment, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNullOrEmpty(environment, nameof(environment));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(KeyClient)}.{nameof(ExportKey)}");
            scope.AddAttribute("key", name);
            scope.Start();

            try
            {
                return await _pipeline.SendRequestAsync(RequestMethod.Post, new KeyExportParameters(environment), () => new KeyVaultKey(name), cancellationToken, KeysPath, name, "/", version, "/export").ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
