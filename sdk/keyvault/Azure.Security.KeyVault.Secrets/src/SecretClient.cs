// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Security.KeyVault.Secrets
{
    /// <summary>
    /// The SecretClient provides synchronous and asynchronous methods to manage <see cref="KeyVaultSecret"/> in the Azure Key Vault. The client
    /// supports creating, retrieving, updating, deleting, purging, backing up, restoring, and listing <see cref="KeyVaultSecret"/>.
    /// The client also supports listing <see cref="DeletedSecret"/> for a soft-delete enabled Azure Key Vault.
    /// </summary>
    public class SecretClient
    {
        internal const string SecretsPath = "/secrets/";
        internal const string DeletedSecretsPath = "/deletedsecrets/";

        private readonly KeyVaultPipeline _pipeline;

        /// <summary>
        /// Initializes a new instance of the <see cref="SecretClient"/> class for mocking.
        /// </summary>
        protected SecretClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SecretClient"/> class for the specified vault.
        /// </summary>
        /// <param name="vaultUri">
        /// A <see cref="Uri"/> to the vault on which the client operates. Appears as "DNS Name" in the Azure portal.
        /// If you have a secret <see cref="Uri"/>, use <see cref="KeyVaultSecretIdentifier"/> to parse the <see cref="KeyVaultSecretIdentifier.VaultUri"/> and other information.
        /// </param>
        /// <param name="credential">A <see cref="TokenCredential"/> used to authenticate requests to the vault, such as DefaultAzureCredential.</param>
        /// <exception cref="ArgumentNullException"><paramref name="vaultUri"/> or <paramref name="credential"/> is null.</exception>
        public SecretClient(Uri vaultUri, TokenCredential credential)
            : this(vaultUri, credential, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SecretClient"/> class for the specified vault.
        /// </summary>
        /// <param name="vaultUri">
        /// A <see cref="Uri"/> to the vault on which the client operates. Appears as "DNS Name" in the Azure portal.
        /// If you have a secret <see cref="Uri"/>, use <see cref="KeyVaultSecretIdentifier"/> to parse the <see cref="KeyVaultSecretIdentifier.VaultUri"/> and other information.
        /// </param>
        /// <param name="credential">A <see cref="TokenCredential"/> used to authenticate requests to the vault, such as DefaultAzureCredential.</param>
        /// <param name="options"><see cref="SecretClientOptions"/> that allow to configure the management of the request sent to Key Vault.</param>
        /// <exception cref="ArgumentNullException"><paramref name="vaultUri"/> or <paramref name="credential"/> is null.</exception>
        public SecretClient(Uri vaultUri, TokenCredential credential, SecretClientOptions options)
        {
            Argument.AssertNotNull(vaultUri, nameof(vaultUri));
            Argument.AssertNotNull(credential, nameof(credential));

            options ??= new SecretClientOptions();
            string apiVersion = options.GetVersionString();

            HttpPipeline pipeline = HttpPipelineBuilder.Build(options,
                    new ChallengeBasedAuthenticationPolicy(credential));

            _pipeline = new KeyVaultPipeline(vaultUri, apiVersion, pipeline, new ClientDiagnostics(options));
        }

        /// <summary>
        /// Gets the <see cref="Uri"/> of the vault used to create this instance of the <see cref="SecretClient"/>.
        /// </summary>
        public virtual Uri VaultUri => _pipeline.VaultUri;

        /// <summary>
        /// Get a specified secret from a given key vault.
        /// </summary>
        /// <remarks>
        /// The get operation is applicable to any secret stored in Azure Key Vault.
        /// This operation requires the secrets/get permission.
        /// </remarks>
        /// <param name="name">The name of the secret.</param>
        /// <param name="version">The version of the secret.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<KeyVaultSecret>> GetSecretAsync(string name, string version = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(SecretClient)}.{nameof(GetSecret)}");
            scope.AddAttribute("secret", name);
            scope.Start();

            try
            {
                return await _pipeline.SendRequestAsync(RequestMethod.Get, () => new KeyVaultSecret(), cancellationToken, SecretsPath, name, "/", version).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get a specified secret from a given key vault.
        /// </summary>
        /// <remarks>
        /// The get operation is applicable to any secret stored in Azure Key Vault.
        /// This operation requires the secrets/get permission.
        /// </remarks>
        /// <param name="name">The name of the secret.</param>
        /// <param name="version">The version of the secret.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<KeyVaultSecret> GetSecret(string name, string version = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(SecretClient)}.{nameof(GetSecret)}");
            scope.AddAttribute("secret", name);
            scope.Start();

            try
            {
                return _pipeline.SendRequest(RequestMethod.Get, () => new KeyVaultSecret(), cancellationToken, SecretsPath, name, "/", version);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists the properties of all versions of the specified secret. You can use the returned <see cref="SecretProperties.Name"/> and <see cref="SecretProperties.Version"/> in subsequent calls to <see cref="GetSecretAsync"/>.
        /// </summary>
        /// <remarks>
        /// The full secret identifier and attributes are provided in the response. No
        /// values are returned for the secrets. This operations requires the
        /// secrets/list permission.
        /// </remarks>
        /// <param name="name">The name of the secret.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual AsyncPageable<SecretProperties> GetPropertiesOfSecretVersionsAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            Uri firstPageUri = new Uri(VaultUri, $"{SecretsPath}{name}/versions?api-version={_pipeline.ApiVersion}");

            return PageResponseEnumerator.CreateAsyncEnumerable(nextLink => _pipeline.GetPageAsync(firstPageUri, nextLink, () => new SecretProperties(), "SecretClient.GetPropertiesOfSecretVersions", cancellationToken));
        }

        /// <summary>
        /// Lists the properties of all versions of the specified secret. You can use the returned <see cref="SecretProperties.Name"/> and <see cref="SecretProperties.Version"/> in subsequent calls to <see cref="GetSecret"/>.
        /// </summary>
        /// <remarks>
        /// The full secret identifier and attributes are provided in the response. No
        /// values are returned for the secrets. This operations requires the
        /// secrets/list permission.
        /// </remarks>
        /// <param name="name">The name of the secret.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Pageable<SecretProperties> GetPropertiesOfSecretVersions(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            Uri firstPageUri = new Uri(VaultUri, $"{SecretsPath}{name}/versions?api-version={_pipeline.ApiVersion}");

            return PageResponseEnumerator.CreateEnumerable(nextLink => _pipeline.GetPage(firstPageUri, nextLink, () => new SecretProperties(), "SecretClient.GetPropertiesOfSecretVersions", cancellationToken));
        }

        /// <summary>
        /// Lists the properties of all secrets in the specified vault. You can use the returned <see cref="SecretProperties.Name"/> in subsequent calls to <see cref="GetSecretAsync"/>.
        /// </summary>
        /// <remarks>
        /// The Get Secrets operation is applicable to the entire vault. However, only
        /// the base secret identifier and its attributes are provided in the response.
        /// Individual secret versions are not listed in the response. This operation
        /// requires the secrets/list permission.
        /// </remarks>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual AsyncPageable<SecretProperties> GetPropertiesOfSecretsAsync(CancellationToken cancellationToken = default)
        {
            Uri firstPageUri = new Uri(VaultUri, SecretsPath + $"?api-version={_pipeline.ApiVersion}");

            return PageResponseEnumerator.CreateAsyncEnumerable(nextLink => _pipeline.GetPageAsync(firstPageUri, nextLink, () => new SecretProperties(), "SecretClient.GetPropertiesOfSecrets", cancellationToken));
        }

        /// <summary>
        /// Lists the properties of all secrets in the specified vault. You can use the returned <see cref="SecretProperties.Name"/> in subsequent calls to <see cref="GetSecret"/>.
        /// </summary>
        /// <remarks>
        /// The Get Secrets operation is applicable to the entire vault. However, only
        /// the base secret identifier and its attributes are provided in the response.
        /// Individual secret versions are not listed in the response. This operation
        /// requires the secrets/list permission.
        /// </remarks>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Pageable<SecretProperties> GetPropertiesOfSecrets(CancellationToken cancellationToken = default)
        {
            Uri firstPageUri = new Uri(VaultUri, SecretsPath + $"?api-version={_pipeline.ApiVersion}");

            return PageResponseEnumerator.CreateEnumerable(nextLink => _pipeline.GetPage(firstPageUri, nextLink, () => new SecretProperties(), "SecretClient.GetPropertiesOfSecrets", cancellationToken));
        }

        /// <summary>
        /// Updates the attributes associated with a specified secret.
        /// </summary>
        /// <remarks>
        /// The update operation changes specified attributes of an existing stored
        /// secret. Attributes that are not specified in the request are left
        /// unchanged. The value of a secret itself cannot be changed. This operation
        /// requires the secrets/set permission.
        /// </remarks>
        /// <param name="properties">The secret object with updated properties.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentNullException"><paramref name="properties"/> or <see cref="SecretProperties.Version"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<SecretProperties>> UpdateSecretPropertiesAsync(SecretProperties properties, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(properties, nameof(properties));
            Argument.AssertNotNull(properties.Version, nameof(properties.Version));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(SecretClient)}.{nameof(UpdateSecretProperties)}");
            scope.AddAttribute("secret", properties.Name);
            scope.Start();

            try
            {
                return await _pipeline.SendRequestAsync(RequestMethod.Patch, properties, () => new SecretProperties(), cancellationToken, SecretsPath, properties.Name, "/", properties.Version).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Updates the attributes associated with a specified secret.
        /// </summary>
        /// <remarks>
        /// The update operation changes specified attributes of an existing stored
        /// secret. Attributes that are not specified in the request are left
        /// unchanged. The value of a secret itself cannot be changed. This operation
        /// requires the secrets/set permission.
        /// </remarks>
        /// <param name="properties">The secret object with updated properties.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentNullException"><paramref name="properties"/> or <see cref="SecretProperties.Version"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<SecretProperties> UpdateSecretProperties(SecretProperties properties, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(properties, nameof(properties));
            Argument.AssertNotNull(properties.Version, nameof(properties.Version));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(SecretClient)}.{nameof(UpdateSecretProperties)}");
            scope.AddAttribute("secret", properties.Name);
            scope.Start();

            try
            {
                return _pipeline.SendRequest(RequestMethod.Patch, properties, () => new SecretProperties(), cancellationToken, SecretsPath, properties.Name, "/", properties.Version);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Sets a secret in a specified key vault.
        /// </summary>
        /// <remarks>
        /// The set operation adds a secret to the Azure Key Vault. If the named secret
        /// already exists, Azure Key Vault creates a new version of that secret. This
        /// operation requires the secrets/set permission.
        /// </remarks>
        /// <param name="secret">The Secret object containing information about the secret and its properties. The properties secret.Name and secret.Value must be non null.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentNullException"><paramref name="secret"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<KeyVaultSecret>> SetSecretAsync(KeyVaultSecret secret, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(secret, nameof(secret));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(SecretClient)}.{nameof(SetSecret)}");
            scope.AddAttribute("secret", secret.Name);
            scope.Start();

            try
            {
                return await _pipeline.SendRequestAsync(RequestMethod.Put, secret, () => new KeyVaultSecret(), cancellationToken, SecretsPath, secret.Name).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Sets a secret in a specified key vault.
        /// </summary>
        /// <remarks>
        /// The set operation adds a secret to the Azure Key Vault. If the named secret
        /// already exists, Azure Key Vault creates a new version of that secret. This
        /// operation requires the secrets/set permission.
        /// </remarks>
        /// <param name="secret">The Secret object containing information about the secret and its properties. The properties secret.Name and secret.Value must be non null.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentNullException"><paramref name="secret"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<KeyVaultSecret> SetSecret(KeyVaultSecret secret, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(secret, nameof(secret));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(SecretClient)}.{nameof(SetSecret)}");
            scope.AddAttribute("secret", secret.Name);
            scope.Start();

            try
            {
                return _pipeline.SendRequest(RequestMethod.Put, secret, () => new KeyVaultSecret(), cancellationToken, SecretsPath, secret.Name);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Sets a secret in a specified key vault.
        /// </summary>
        /// <remarks>
        /// The set operation adds a secret to the Azure Key Vault. If the named secret
        /// already exists, Azure Key Vault creates a new version of that secret. This
        /// operation requires the secrets/set permission.
        /// </remarks>
        /// <param name="name">The name of the secret. It must not be null.</param>
        /// <param name="value">The value of the secret. It must not be null.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<KeyVaultSecret>> SetSecretAsync(string name, string value, CancellationToken cancellationToken = default)
        {
            return await SetSecretAsync(new KeyVaultSecret(name, value), cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Sets a secret in a specified key vault.
        /// </summary>
        /// <remarks>
        /// The set operation adds a secret to the Azure Key Vault. If the named secret
        /// already exists, Azure Key Vault creates a new version of that secret. This
        /// operation requires the secrets/set permission.
        /// </remarks>
        /// <param name="name">The name of the secret.</param>
        /// <param name="value">The value of the secret.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<KeyVaultSecret> SetSecret(string name, string value, CancellationToken cancellationToken = default)
        {
            return SetSecret(new KeyVaultSecret(name, value), cancellationToken);
        }

        /// <summary>
        /// Deletes a secret from a specified key vault.
        /// </summary>
        /// <remarks>
        /// The delete operation applies to any secret stored in Azure Key Vault.
        /// Delete cannot be applied to an individual version of a secret. This
        /// operation requires the secrets/delete permission.
        /// </remarks>
        /// <param name="name">The name of the secret.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="DeleteSecretOperation"/> to wait on this long-running operation.
        /// If the Key Vault is soft delete-enabled, you only need to wait for the operation to complete if you need to recover or purge the secret;
        /// otherwise, the secret is deleted automatically on the <see cref="DeletedSecret.ScheduledPurgeDate"/>.
        /// </returns>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<DeleteSecretOperation> StartDeleteSecretAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(SecretClient)}.{nameof(StartDeleteSecret)}");
            scope.AddAttribute("secret", name);
            scope.Start();

            try
            {
                Response<DeletedSecret> response = await _pipeline.SendRequestAsync(RequestMethod.Delete, () => new DeletedSecret(), cancellationToken, SecretsPath, name).ConfigureAwait(false);
                return new DeleteSecretOperation(_pipeline, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes a secret from a specified key vault.
        /// </summary>
        /// <remarks>
        /// The delete operation applies to any secret stored in Azure Key Vault.
        /// Delete cannot be applied to an individual version of a secret. This
        /// operation requires the secrets/delete permission.
        /// </remarks>
        /// <param name="name">The name of the secret.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="DeleteSecretOperation"/> to wait on this long-running operation.
        /// If the Key Vault is soft delete-enabled, you only need to wait for the operation to complete if you need to recover or purge the secret;
        /// otherwise, the secret is deleted automatically on the <see cref="DeletedSecret.ScheduledPurgeDate"/>.
        /// </returns>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual DeleteSecretOperation StartDeleteSecret(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(SecretClient)}.{nameof(StartDeleteSecret)}");
            scope.AddAttribute("secret", name);
            scope.Start();

            try
            {
                Response<DeletedSecret> response = _pipeline.SendRequest(RequestMethod.Delete, () => new DeletedSecret(), cancellationToken, SecretsPath, name);
                return new DeleteSecretOperation(_pipeline, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the specified deleted secret.
        /// </summary>
        /// <remarks>
        /// The Get Deleted Secret operation returns the specified deleted secret along
        /// with its attributes. This operation requires the secrets/get permission.
        /// </remarks>
        /// <param name="name">The name of the secret.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<DeletedSecret>> GetDeletedSecretAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(SecretClient)}.{nameof(GetDeletedSecret)}");
            scope.AddAttribute("secret", name);
            scope.Start();

            try
            {
                return await _pipeline.SendRequestAsync(RequestMethod.Get, () => new DeletedSecret(), cancellationToken, DeletedSecretsPath, name).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the specified deleted secret.
        /// </summary>
        /// <remarks>
        /// The Get Deleted Secret operation returns the specified deleted secret along
        /// with its attributes. This operation requires the secrets/get permission.
        /// </remarks>
        /// <param name="name">The name of the secret.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<DeletedSecret> GetDeletedSecret(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(SecretClient)}.{nameof(GetDeletedSecret)}");
            scope.AddAttribute("secret", name);
            scope.Start();

            try
            {
                return _pipeline.SendRequest(RequestMethod.Get, () => new DeletedSecret(), cancellationToken, DeletedSecretsPath, name);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists deleted secrets for the specified vault.
        /// </summary>
        /// <remarks>
        /// The Get Deleted Secrets operation returns the secrets that have been
        /// deleted for a vault enabled for soft-delete. This operation requires the
        /// secrets/list permission.
        /// </remarks>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual AsyncPageable<DeletedSecret> GetDeletedSecretsAsync(CancellationToken cancellationToken = default)
        {
            Uri firstPageUri = new Uri(VaultUri, DeletedSecretsPath + $"?api-version={_pipeline.ApiVersion}");

            return PageResponseEnumerator.CreateAsyncEnumerable(nextLink => _pipeline.GetPageAsync(firstPageUri, nextLink, () => new DeletedSecret(), "SecretClient.GetDeletedSecrets", cancellationToken));
        }

        /// <summary>
        /// Lists deleted secrets for the specified vault.
        /// </summary>
        /// <remarks>
        /// The Get Deleted Secrets operation returns the secrets that have been
        /// deleted for a vault enabled for soft-delete. This operation requires the
        /// secrets/list permission.
        /// </remarks>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Pageable<DeletedSecret> GetDeletedSecrets(CancellationToken cancellationToken = default)
        {
            Uri firstPageUri = new Uri(VaultUri, DeletedSecretsPath + $"?api-version={_pipeline.ApiVersion}");

            return PageResponseEnumerator.CreateEnumerable(nextLink => _pipeline.GetPage(firstPageUri, nextLink, () => new DeletedSecret(), "SecretClient.GetDeletedSecrets", cancellationToken));
        }

        /// <summary>
        /// Recovers the deleted secret to the latest version.
        /// </summary>
        /// <remarks>
        /// Recovers the deleted secret in the specified vault. This operation can only
        /// be performed on a soft-delete enabled vault. This operation requires the
        /// secrets/recover permission.
        /// </remarks>
        /// <param name="name">The name of the secret.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecoverDeletedSecretOperation"/> to wait on this long-running operation.</returns>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<RecoverDeletedSecretOperation> StartRecoverDeletedSecretAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(SecretClient)}.{nameof(StartRecoverDeletedSecret)}");
            scope.AddAttribute("secret", name);
            scope.Start();

            try
            {
                Response<SecretProperties> response = await _pipeline.SendRequestAsync(RequestMethod.Post, () => new SecretProperties(), cancellationToken, DeletedSecretsPath, name, "/recover").ConfigureAwait(false);
                return new RecoverDeletedSecretOperation(_pipeline, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Recovers the deleted secret to the latest version.
        /// </summary>
        /// <remarks>
        /// Recovers the deleted secret in the specified vault. This operation can only
        /// be performed on a soft-delete enabled vault. This operation requires the
        /// secrets/recover permission.
        /// </remarks>
        /// <param name="name">The name of the secret.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecoverDeletedSecretOperation"/> to wait on this long-running operation.</returns>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual RecoverDeletedSecretOperation StartRecoverDeletedSecret(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(SecretClient)}.{nameof(StartRecoverDeletedSecret)}");
            scope.AddAttribute("secret", name);
            scope.Start();

            try
            {
                Response<SecretProperties> response = _pipeline.SendRequest(RequestMethod.Post, () => new SecretProperties(), cancellationToken, DeletedSecretsPath, name, "/recover");
                return new RecoverDeletedSecretOperation(_pipeline, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Permanently deletes the specified secret.
        /// </summary>
        /// <remarks>
        /// The purge deleted secret operation removes the secret permanently, without
        /// the possibility of recovery. This operation can only be enabled on a
        /// soft-delete enabled vault. This operation requires the secrets/purge
        /// permission.
        /// </remarks>
        /// <param name="name">The name of the secret.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> PurgeDeletedSecretAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(SecretClient)}.{nameof(PurgeDeletedSecret)}");
            scope.AddAttribute("secret", name);
            scope.Start();

            try
            {
                return await _pipeline.SendRequestAsync(RequestMethod.Delete, cancellationToken, DeletedSecretsPath, name).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Permanently deletes the specified secret.
        /// </summary>
        /// <remarks>
        /// The purge deleted secret operation removes the secret permanently, without
        /// the possibility of recovery. This operation can only be enabled on a
        /// soft-delete enabled vault. This operation requires the secrets/purge
        /// permission.
        /// </remarks>
        /// <param name="name">The name of the secret.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response PurgeDeletedSecret(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(SecretClient)}.{nameof(PurgeDeletedSecret)}");
            scope.AddAttribute("secret", name);
            scope.Start();

            try
            {
                return _pipeline.SendRequest(RequestMethod.Delete, cancellationToken, DeletedSecretsPath, name);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Backs up the specified secret.
        /// </summary>
        /// <remarks>
        /// Requests that a backup of the specified secret be downloaded to the client.
        /// All versions of the secret will be downloaded. This operation requires the
        /// secrets/backup permission.
        /// </remarks>
        /// <param name="name">The name of the secret.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<byte[]>> BackupSecretAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(SecretClient)}.{nameof(BackupSecret)}");
            scope.AddAttribute("secret", name);
            scope.Start();

            try
            {
                Response<SecretBackup> backup = await _pipeline.SendRequestAsync(RequestMethod.Post, () => new SecretBackup(), cancellationToken, SecretsPath, name, "/backup").ConfigureAwait(false);

                return Response.FromValue(backup.Value.Value, backup.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Backs up the specified secret.
        /// </summary>
        /// <remarks>
        /// Requests that a backup of the specified secret be downloaded to the client.
        /// All versions of the secret will be downloaded. This operation requires the
        /// secrets/backup permission.
        /// </remarks>
        /// <param name="name">The name of the secret.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<byte[]> BackupSecret(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(SecretClient)}.{nameof(BackupSecret)}");
            scope.AddAttribute("secret", name);
            scope.Start();

            try
            {
                Response<SecretBackup> backup = _pipeline.SendRequest(RequestMethod.Post, () => new SecretBackup(), cancellationToken, SecretsPath, name, "/backup");

                return Response.FromValue(backup.Value.Value, backup.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Restores a backed up secret to a vault.
        /// </summary>
        /// <remarks>
        /// Restores a backed up secret, and all its versions, to a vault. This
        /// operation requires the secrets/restore permission.
        /// </remarks>
        /// <param name="backup">The backup blob associated with a secret.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentNullException"><paramref name="backup"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<SecretProperties>> RestoreSecretBackupAsync(byte[] backup, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(backup, nameof(backup));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(SecretClient)}.{nameof(RestoreSecretBackup)}");
            scope.Start();

            try
            {
                return await _pipeline.SendRequestAsync(RequestMethod.Post, new SecretBackup { Value = backup }, () => new SecretProperties(), cancellationToken, SecretsPath, "restore").ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Restores a backed up secret to a vault.
        /// </summary>
        /// <remarks>
        /// Restores a backed up secret, and all its versions, to a vault. This
        /// operation requires the secrets/restore permission.
        /// </remarks>
        /// <param name="backup">The backup blob associated with a secret.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentNullException"><paramref name="backup"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<SecretProperties> RestoreSecretBackup(byte[] backup, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(backup, nameof(backup));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(SecretClient)}.{nameof(RestoreSecretBackup)}");
            scope.Start();

            try
            {
                return _pipeline.SendRequest(RequestMethod.Post, new SecretBackup { Value = backup }, () => new SecretProperties(), cancellationToken, SecretsPath, "restore");
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
