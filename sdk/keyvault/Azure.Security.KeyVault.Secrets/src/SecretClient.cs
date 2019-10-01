// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Security.KeyVault.Secrets
{
    /// <summary>
    /// The SecretClient provides synchronous and asynchronous methods to manage <see cref="Secret"/> in the Azure Key Vault. The client
    /// supports creating, retrieving, updating, deleting, purging, backing up, restoring and listing <see cref="Secret"/>.
    /// The client also supports listing <see cref="DeletedSecret"/> for a soft-delete enabled Azure Key Vault.
    /// </summary>
    public class SecretClient
    {
        private readonly Uri _vaultUri;
        private readonly KeyVaultPipeline _pipeline;

        private const string SecretsPath = "/secrets/";
        private const string DeletedSecretsPath = "/deletedsecrets/";

        /// <summary>
        /// Protected constructor to allow mocking
        /// </summary>
        protected SecretClient()
        {

        }

        /// <summary>
        /// Initializes a new instance of the SecretClient class.
        /// </summary>
        /// <param name="vaultUri">Endpoint URL for the Azure Key Vault service.</param>
        /// <param name="credential">Represents a credential capable of providing an OAuth token.</param>
        /// <exception cref="ArgumentNullException"><paramref name="vaultUri"/> or <paramref name="credential"/> is null.</exception>
        public SecretClient(Uri vaultUri, TokenCredential credential)
            : this(vaultUri, credential, null)
        {

        }

        /// <summary>
        /// Initializes a new instance of the SecretClient class.
        /// </summary>
        /// <param name="vaultUri">Endpoint URL for the Azure Key Vault service.</param>
        /// <param name="credential">Represents a credential capable of providing an OAuth token.</param>
        /// <param name="options">Options that allow to configure the management of the request sent to Key Vault.</param>
        /// <exception cref="ArgumentNullException"><paramref name="vaultUri"/> or <paramref name="credential"/> is null.</exception>
        public SecretClient(Uri vaultUri, TokenCredential credential, SecretClientOptions options)
        {
            _vaultUri = vaultUri ?? throw new ArgumentNullException(nameof(vaultUri));
            Argument.AssertNotNull(credential, nameof(credential));

            options ??= new SecretClientOptions();
            string apiVersion = options.GetVersionString();

            HttpPipeline pipeline = HttpPipelineBuilder.Build(options,
                    new ChallengeBasedAuthenticationPolicy(credential));

            _pipeline = new KeyVaultPipeline(_vaultUri, apiVersion, pipeline);
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
        public virtual async Task<Response<Secret>> GetAsync(string name, string version = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Secrets.SecretClient.Get");
            scope.AddAttribute("secret", name);
            scope.Start();

            try
            {
                return await _pipeline.SendRequestAsync(RequestMethod.Get, () => new Secret(), cancellationToken, SecretsPath, name, "/", version).ConfigureAwait(false);
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
        public virtual Response<Secret> Get(string name, string version = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Secrets.SecretClient.Get");
            scope.AddAttribute("secret", name);
            scope.Start();

            try
            {
                return _pipeline.SendRequest(RequestMethod.Get, () => new Secret(), cancellationToken, SecretsPath, name, "/", version);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// List all versions of the specified secret.
        /// </summary>
        /// <remarks>
        /// The full secret identifier and attributes are provided in the response. No
        /// values are returned for the secrets. This operations requires the
        /// secrets/list permission.
        /// </remarks>
        /// <param name="name">The name of the secret.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual AsyncCollection<SecretProperties> GetSecretVersionsAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            Uri firstPageUri = new Uri(_vaultUri, $"{SecretsPath}{name}/versions?api-version={_pipeline.ApiVersion}");

            return PageResponseEnumerator.CreateAsyncEnumerable(nextLink => _pipeline.GetPageAsync(firstPageUri, nextLink, () => new SecretProperties(), "Azure.Security.KeyVault.Secrets.SecretClient.GetSecretVersions", cancellationToken));
        }

        /// <summary>
        /// List all versions of the specified secret.
        /// </summary>
        /// <remarks>
        /// The full secret identifier and attributes are provided in the response. No
        /// values are returned for the secrets. This operations requires the
        /// secrets/list permission.
        /// </remarks>
        /// <param name="name">The name of the secret.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual SyncCollection<SecretProperties> GetSecretVersions(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            Uri firstPageUri = new Uri(_vaultUri, $"{SecretsPath}{name}/versions?api-version={_pipeline.ApiVersion}");

            return PageResponseEnumerator.CreateEnumerable(nextLink => _pipeline.GetPage(firstPageUri, nextLink, () => new SecretProperties(), "Azure.Security.KeyVault.Secrets.SecretClient.GetSecretVersions", cancellationToken));
        }

        /// <summary>
        /// List secrets in a specified key vault.
        /// </summary>
        /// <remarks>
        /// The Get Secrets operation is applicable to the entire vault. However, only
        /// the base secret identifier and its attributes are provided in the response.
        /// Individual secret versions are not listed in the response. This operation
        /// requires the secrets/list permission.
        /// </remarks>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual AsyncCollection<SecretProperties> GetSecretsAsync(CancellationToken cancellationToken = default)
        {
            Uri firstPageUri = new Uri(_vaultUri, SecretsPath + $"?api-version={_pipeline.ApiVersion}");

            return PageResponseEnumerator.CreateAsyncEnumerable(nextLink => _pipeline.GetPageAsync(firstPageUri, nextLink, () => new SecretProperties(), "Azure.Security.KeyVault.Secrets.SecretClient.GetSecrets", cancellationToken));
        }

        /// <summary>
        /// List secrets in a specified key vault.
        /// </summary>
        /// <remarks>
        /// The Get Secrets operation is applicable to the entire vault. However, only
        /// the base secret identifier and its attributes are provided in the response.
        /// Individual secret versions are not listed in the response. This operation
        /// requires the secrets/list permission.
        /// </remarks>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual SyncCollection<SecretProperties> GetSecrets(CancellationToken cancellationToken = default)
        {
            Uri firstPageUri = new Uri(_vaultUri, SecretsPath + $"?api-version={_pipeline.ApiVersion}");

            return PageResponseEnumerator.CreateEnumerable(nextLink => _pipeline.GetPage(firstPageUri, nextLink, () => new SecretProperties(), "Azure.Security.KeyVault.Secrets.SecretClient.GetSecrets", cancellationToken));
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
        /// <param name="secret">The secret object with updated properties.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual async Task<Response<SecretProperties>> UpdatePropertiesAsync(SecretProperties secret, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(secret, nameof(secret));
            Argument.AssertNotNull(secret.Version, nameof(secret.Version));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Secrets.SecretClient.UpdateProperties");
            scope.AddAttribute("secret", secret.Name);
            scope.Start();

            try
            {
                return await _pipeline.SendRequestAsync(RequestMethod.Patch, secret, () => new SecretProperties(), cancellationToken, SecretsPath, secret.Name, "/", secret.Version).ConfigureAwait(false);
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
        /// <param name="secret">The secret object with updated properties.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual Response<SecretProperties> UpdateProperties(SecretProperties secret, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(secret, nameof(secret));
            Argument.AssertNotNull(secret.Version, nameof(secret.Version));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Secrets.SecretClient.UpdateProperties");
            scope.AddAttribute("secret", secret.Name);
            scope.Start();

            try
            {
                return _pipeline.SendRequest(RequestMethod.Patch, secret, () => new SecretProperties(), cancellationToken, SecretsPath, secret.Name, "/", secret.Version);
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
        public virtual async Task<Response<Secret>> SetAsync(Secret secret, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(secret, nameof(secret));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Secrets.SecretClient.Set");
            scope.AddAttribute("secret", secret.Name);
            scope.Start();

            try
            {
                return await _pipeline.SendRequestAsync(RequestMethod.Put, secret, () => new Secret(), cancellationToken, SecretsPath, secret.Name).ConfigureAwait(false);
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
        public virtual Response<Secret> Set(Secret secret, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(secret, nameof(secret));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Secrets.SecretClient.Set");
            scope.AddAttribute("secret", secret.Name);
            scope.Start();

            try
            {
                return _pipeline.SendRequest(RequestMethod.Put, secret, () => new Secret(), cancellationToken, SecretsPath, secret.Name);
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
        public virtual async Task<Response<Secret>> SetAsync(string name, string value, CancellationToken cancellationToken = default)
        {
            return await SetAsync(new Secret(name, value), cancellationToken).ConfigureAwait(false);
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
        public virtual Response<Secret> Set(string name, string value, CancellationToken cancellationToken = default)
        {
            return Set(new Secret(name, value), cancellationToken);
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
        public virtual async Task<Response<DeletedSecret>> DeleteAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Secrets.SecretClient.Delete");
            scope.AddAttribute("secret", name);
            scope.Start();

            try
            {
                return await _pipeline.SendRequestAsync(RequestMethod.Delete, () => new DeletedSecret(), cancellationToken, SecretsPath, name).ConfigureAwait(false);
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
        public virtual Response<DeletedSecret> Delete(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Secrets.SecretClient.Delete");
            scope.AddAttribute("secret", name);
            scope.Start();

            try
            {
                return _pipeline.SendRequest(RequestMethod.Delete, () => new DeletedSecret(), cancellationToken, SecretsPath, name);
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
        public virtual async Task<Response<DeletedSecret>> GetDeletedAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Secrets.SecretClient.GetDeleted");
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
        public virtual Response<DeletedSecret> GetDeleted(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Secrets.SecretClient.GetDeleted");
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
        public virtual AsyncCollection<DeletedSecret> GetDeletedSecretsAsync(CancellationToken cancellationToken = default)
        {
            Uri firstPageUri = new Uri(_vaultUri, DeletedSecretsPath + $"?api-version={_pipeline.ApiVersion}");

            return PageResponseEnumerator.CreateAsyncEnumerable(nextLink => _pipeline.GetPageAsync(firstPageUri, nextLink, () => new DeletedSecret(), "Azure.Security.KeyVault.Secrets.SecretClient.GetDeletedSecrets", cancellationToken));
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
        public virtual SyncCollection<DeletedSecret> GetDeletedSecrets(CancellationToken cancellationToken = default)
        {
            Uri firstPageUri = new Uri(_vaultUri, DeletedSecretsPath + $"?api-version={_pipeline.ApiVersion}");

            return PageResponseEnumerator.CreateEnumerable(nextLink => _pipeline.GetPage(firstPageUri, nextLink, () => new DeletedSecret(), "Azure.Security.KeyVault.Secrets.SecretClient.GetDeletedSecrets", cancellationToken));
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
        public virtual async Task<Response<SecretProperties>> RecoverDeletedAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Secrets.SecretClient.RecoverDeleted");
            scope.AddAttribute("secret", name);
            scope.Start();

            try
            {
                return await _pipeline.SendRequestAsync(RequestMethod.Post, () => new SecretProperties(), cancellationToken, DeletedSecretsPath, name, "/recover").ConfigureAwait(false);
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
        public virtual Response<SecretProperties> RecoverDeleted(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Secrets.SecretClient.RecoverDeleted");
            scope.AddAttribute("secret", name);
            scope.Start();

            try
            {
                return _pipeline.SendRequest(RequestMethod.Post, () => new SecretProperties(), cancellationToken, DeletedSecretsPath, name, "/recover");
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
        public virtual async Task<Response> PurgeDeletedAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Secrets.SecretClient.PurgeDeleted");
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
        public virtual Response PurgeDeleted(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Secrets.SecretClient.PurgeDeleted");
            scope.AddAttribute("secret", name);
            scope.Start();

            try
            {
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
            return _pipeline.SendRequest(RequestMethod.Delete, cancellationToken, DeletedSecretsPath, name);
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
        public virtual async Task<Response<byte[]>> BackupAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Secrets.SecretClient.Backup");
            scope.AddAttribute("secret", name);
            scope.Start();

            try
            {
                Response<VaultBackup> backup = await _pipeline.SendRequestAsync(RequestMethod.Post, () => new VaultBackup(), cancellationToken, SecretsPath, name, "/backup").ConfigureAwait(false);

                return Response.FromValue(backup.GetRawResponse(), backup.Value.Value);
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
        public virtual Response<byte[]> Backup(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Secrets.SecretClient.Backup");
            scope.AddAttribute("secret", name);
            scope.Start();

            try
            {
                Response<VaultBackup> backup = _pipeline.SendRequest(RequestMethod.Post, () => new VaultBackup(), cancellationToken, SecretsPath, name, "/backup");

                return Response.FromValue(backup.GetRawResponse(), backup.Value.Value);
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
        public virtual async Task<Response<SecretProperties>> RestoreAsync(byte[] backup, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(backup, nameof(backup));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Secrets.SecretClient.Restore");
            scope.Start();

            try
            {
                return await _pipeline.SendRequestAsync(RequestMethod.Post, new VaultBackup { Value = backup }, () => new SecretProperties(), cancellationToken, SecretsPath, "restore").ConfigureAwait(false);
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
        public virtual Response<SecretProperties> Restore(byte[] backup, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(backup, nameof(backup));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Secrets.SecretClient.Restore");
            scope.Start();

            try
            {
                return _pipeline.SendRequest(RequestMethod.Post, new VaultBackup { Value = backup }, () => new SecretProperties(), cancellationToken, SecretsPath, "restore");
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
