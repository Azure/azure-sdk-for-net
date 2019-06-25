// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.Pipeline.Policies;

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
        private const string ApiVersion = "7.0";
        private readonly HttpPipeline _pipeline;

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
        public SecretClient(Uri vaultUri, TokenCredential credential, SecretClientOptions options)
        {
            _vaultUri = vaultUri ?? throw new ArgumentNullException(nameof(credential));
            options = options ?? new SecretClientOptions();

            _pipeline = HttpPipelineBuilder.Build(options,
                    bufferResponse: true,
                    new BearerTokenAuthenticationPolicy(credential, "https://vault.azure.net/.default"));
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
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} must not be null or empty", nameof(name));

            return await SendRequestAsync(HttpPipelineMethod.Get, () => new Secret(), cancellationToken, SecretsPath, name, "/", version);
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
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} must not be null or empty", nameof(name));

            return SendRequest(HttpPipelineMethod.Get, () => new Secret(), cancellationToken, SecretsPath, name, "/", version);
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
        public virtual IAsyncEnumerable<Response<SecretBase>> GetSecretVersionsAsync(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} must not be null or empty", nameof(name));

            Uri firstPageUri = new Uri(_vaultUri, $"{SecretsPath}{name}/versions?api-version={ApiVersion}");

            return PageResponseEnumerator.CreateAsyncEnumerable(nextLink => GetPageAsync(firstPageUri, nextLink, () => new SecretBase(), cancellationToken));
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
        public virtual IEnumerable<Response<SecretBase>> GetSecretVersions(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} must not be null or empty", nameof(name));

            Uri firstPageUri = new Uri(_vaultUri, $"{SecretsPath}{name}/versions?api-version={ApiVersion}");

            return PageResponseEnumerator.CreateEnumerable(nextLink => GetPage(firstPageUri, nextLink, () => new SecretBase(), cancellationToken));
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
        public virtual IAsyncEnumerable<Response<SecretBase>> GetSecretsAsync(CancellationToken cancellationToken = default)
        {
            Uri firstPageUri = new Uri(_vaultUri, SecretsPath + $"?api-version={ApiVersion}");

            return PageResponseEnumerator.CreateAsyncEnumerable(nextLink => GetPageAsync(firstPageUri, nextLink, () => new SecretBase(), cancellationToken));
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
        public virtual IEnumerable<Response<SecretBase>> GetSecrets(CancellationToken cancellationToken = default)
        {
            Uri firstPageUri = new Uri(_vaultUri, SecretsPath + $"?api-version={ApiVersion}");

            return PageResponseEnumerator.CreateEnumerable(nextLink => GetPage(firstPageUri, nextLink, () => new SecretBase(), cancellationToken));
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
        public virtual async Task<Response<SecretBase>> UpdateAsync(SecretBase secret, CancellationToken cancellationToken = default)
        {
            if (secret == null) throw new ArgumentNullException(nameof(secret));
            if (secret.Version == null) throw new ArgumentNullException($"{nameof(secret)}.{nameof(secret.Version)}");

            return await SendRequestAsync(HttpPipelineMethod.Patch, secret, () => new SecretBase(), cancellationToken, SecretsPath, secret.Name, "/", secret.Version);
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
        public virtual Response<SecretBase> Update(SecretBase secret, CancellationToken cancellationToken = default)
        {
            if (secret == null) throw new ArgumentNullException(nameof(secret));
            if (secret.Version == null) throw new ArgumentNullException($"{nameof(secret)}.{nameof(secret.Version)}");

            return SendRequest(HttpPipelineMethod.Patch, secret, () => new SecretBase(), cancellationToken, SecretsPath, secret.Name, "/", secret.Version);
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
            if (secret == null) throw new ArgumentNullException(nameof(secret));

            return await SendRequestAsync(HttpPipelineMethod.Put, secret, () => new Secret(), cancellationToken, SecretsPath, secret.Name);
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
            if (secret == null) throw new ArgumentNullException(nameof(secret));

            return SendRequest(HttpPipelineMethod.Put, secret, () => new Secret(), cancellationToken, SecretsPath, secret.Name);
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
            return await SetAsync(new Secret(name, value), cancellationToken);
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
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} must not be null or empty", nameof(name));

            return await SendRequestAsync(HttpPipelineMethod.Delete, () => new DeletedSecret(), cancellationToken, SecretsPath, name);
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
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} must not be null or empty", nameof(name));

            return SendRequest(HttpPipelineMethod.Delete, () => new DeletedSecret(), cancellationToken, SecretsPath, name);
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
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} must not be null or empty", nameof(name));

            return await SendRequestAsync(HttpPipelineMethod.Get, () => new DeletedSecret(), cancellationToken, DeletedSecretsPath, name);
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
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} must not be null or empty", nameof(name));

            return SendRequest(HttpPipelineMethod.Get, () => new DeletedSecret(), cancellationToken, DeletedSecretsPath, name);
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
        public virtual IAsyncEnumerable<Response<DeletedSecret>> GetDeletedSecretsAsync(CancellationToken cancellationToken = default)
        {
            Uri firstPageUri = new Uri(_vaultUri, DeletedSecretsPath + $"?api-version={ApiVersion}");

            return PageResponseEnumerator.CreateAsyncEnumerable(nextLink => GetPageAsync(firstPageUri, nextLink, () => new DeletedSecret(), cancellationToken));
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
        public virtual IEnumerable<Response<DeletedSecret>> GetDeletedSecrets(CancellationToken cancellationToken = default)
        {
            Uri firstPageUri = new Uri(_vaultUri, DeletedSecretsPath + $"?api-version={ApiVersion}");

            return PageResponseEnumerator.CreateEnumerable(nextLink => GetPage(firstPageUri, nextLink, () => new DeletedSecret(), cancellationToken));
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
        public virtual async Task<Response<SecretBase>> RecoverDeletedAsync(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} must not be null or empty", nameof(name));

            return await SendRequestAsync(HttpPipelineMethod.Post, () => new SecretBase(), cancellationToken, DeletedSecretsPath, name, "/recover");
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
        public virtual Response<SecretBase> RecoverDeleted(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} must not be null or empty", nameof(name));

            return SendRequest(HttpPipelineMethod.Post, () => new SecretBase(), cancellationToken, DeletedSecretsPath, name, "/recover");
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
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} must not be null or empty", nameof(name));

            return await SendRequestAsync(HttpPipelineMethod.Delete, cancellationToken, DeletedSecretsPath, name);
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
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} must not be null or empty", nameof(name));

            return SendRequest(HttpPipelineMethod.Delete, cancellationToken, DeletedSecretsPath, name);
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
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} must not be null or empty", nameof(name));

            var backup = await SendRequestAsync(HttpPipelineMethod.Post, () => new VaultBackup(), cancellationToken, SecretsPath, name, "/backup");

            return new Response<byte[]>(backup.GetRawResponse(), backup.Value.Value);
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
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} must not be null or empty", nameof(name));

            var backup = SendRequest(HttpPipelineMethod.Post, () => new VaultBackup(), cancellationToken, SecretsPath, name, "/backup");

            return new Response<byte[]>(backup.GetRawResponse(), backup.Value.Value);
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
        public virtual async Task<Response<SecretBase>> RestoreAsync(byte[] backup, CancellationToken cancellationToken = default)
        {
            if (backup == null) throw new ArgumentNullException(nameof(backup));

            return await SendRequestAsync(HttpPipelineMethod.Post, new VaultBackup { Value = backup }, () => new SecretBase(), cancellationToken, SecretsPath, "restore");
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
        public virtual Response<SecretBase> Restore(byte[] backup, CancellationToken cancellationToken = default)
        {
            if (backup == null) throw new ArgumentNullException(nameof(backup));

            return SendRequest(HttpPipelineMethod.Post, new VaultBackup { Value = backup }, () => new SecretBase(), cancellationToken, SecretsPath, "restore");
        }

        private async Task<Response<TResult>> SendRequestAsync<TContent, TResult>(HttpPipelineMethod method, TContent content, Func<TResult> resultFactory, CancellationToken cancellationToken, params string[] path)
            where TContent : Model
            where TResult : Model
        {
            using (Request request = CreateRequest(method, path))
            {
                request.Content = HttpPipelineRequestContent.Create(content.Serialize());

                Response response = await SendRequestAsync(request, cancellationToken);

                return CreateResponse(response, resultFactory());
            }
        }

        private Response<TResult> SendRequest<TContent, TResult>(HttpPipelineMethod method, TContent content, Func<TResult> resultFactory, CancellationToken cancellationToken, params string[] path)
            where TContent : Model
            where TResult : Model
        {
            using (Request request = CreateRequest(method, path))
            {
                request.Content = HttpPipelineRequestContent.Create(content.Serialize());

                Response response = SendRequest(request, cancellationToken);

                return CreateResponse(response, resultFactory());
            }
        }

        private async Task<Response<TResult>> SendRequestAsync<TResult>(HttpPipelineMethod method, Func<TResult> resultFactory, CancellationToken cancellationToken, params string[] path)
            where TResult : Model
        {
            using (Request request = CreateRequest(method, path))
            {
                Response response = await SendRequestAsync(request, cancellationToken);

                return CreateResponse(response, resultFactory());
            }
        }

        private Response<TResult> SendRequest<TResult>(HttpPipelineMethod method, Func<TResult> resultFactory, CancellationToken cancellationToken, params string[] path)
            where TResult : Model
        {
            using (Request request = CreateRequest(method, path))
            {
                Response response = SendRequest(request, cancellationToken);

                return CreateResponse(response, resultFactory());
            }
        }
        private async Task<Response> SendRequestAsync(HttpPipelineMethod method, CancellationToken cancellationToken, params string[] path)
        {
            using (Request request = CreateRequest(method, path))
            {
                return await SendRequestAsync(request, cancellationToken);
            }
        }

        private Response SendRequest(HttpPipelineMethod method, CancellationToken cancellationToken, params string[] path)
        {
            using (Request request = CreateRequest(method, path))
            {
                return SendRequest(request, cancellationToken);
            }
        }

        private async Task<Response> SendRequestAsync(Request request, CancellationToken cancellationToken)
        {
            var response = await _pipeline.SendRequestAsync(request, cancellationToken);

            switch (response.Status)
            {
                case 200:
                case 201:
                case 204:
                    return response;
                default:
                    throw await response.CreateRequestFailedExceptionAsync();
            }
        }
        private Response SendRequest(Request request, CancellationToken cancellationToken)
        {
            var response = _pipeline.SendRequest(request, cancellationToken);

            switch (response.Status)
            {
                case 200:
                case 201:
                case 204:
                    return response;
                default:
                    throw response.CreateRequestFailedException();
            }
        }

        private async Task<PageResponse<T>> GetPageAsync<T>(Uri firstPageUri, string nextLink, Func<T> itemFactory, CancellationToken cancellationToken)
                where T : Model
        {
            // if we don't have a nextLink specified, use firstPageUri
            if (nextLink != null)
            {
                firstPageUri = new Uri(nextLink);
            }

            using (Request request = CreateRequest(HttpPipelineMethod.Get, firstPageUri))
            {
                Response response = await SendRequestAsync(request, cancellationToken);

                // read the respose
                Page<T> responseAsPage = new Page<T>(itemFactory);
                responseAsPage.Deserialize(response.ContentStream);

                // convert from the Page<T> to PageResponse<T>
                return new PageResponse<T>(responseAsPage.Items.ToArray(), response, responseAsPage.NextLink?.ToString());
            }
        }

        private PageResponse<T> GetPage<T>(Uri firstPageUri, string nextLink, Func<T> itemFactory, CancellationToken cancellationToken)
            where T : Model
        {
            // if we don't have a nextLink specified, use firstPageUri
            if (nextLink != null)
            {
                firstPageUri = new Uri(nextLink);
            }

            using (Request request = CreateRequest(HttpPipelineMethod.Get, firstPageUri))
            {
                Response response = SendRequest(request, cancellationToken);

                // read the respose
                Page<T> responseAsPage = new Page<T>(itemFactory);
                responseAsPage.Deserialize(response.ContentStream);

                // convert from the Page<T> to PageResponse<T>
                return new PageResponse<T>(responseAsPage.Items.ToArray(), response, responseAsPage.NextLink?.ToString());
            }
        }

        private Request CreateRequest(HttpPipelineMethod method, Uri uri)
        {
            Request request = _pipeline.CreateRequest();

            request.Headers.Add(HttpHeader.Common.JsonContentType);
            request.Headers.Add(HttpHeader.Names.Accept, "application/json");
            request.Method = method;
            request.UriBuilder.Uri = uri;

            return request;
        }

        private Request CreateRequest(HttpPipelineMethod method, params string[] path)
        {
            Request request = _pipeline.CreateRequest();

            request.Headers.Add(HttpHeader.Common.JsonContentType);
            request.Headers.Add(HttpHeader.Names.Accept, "application/json");
            request.Method = method;
            request.UriBuilder.Uri = _vaultUri;

            foreach (var p in path)
            {
                request.UriBuilder.AppendPath(p);
            }

            request.UriBuilder.AppendQuery("api-version", ApiVersion);

            return request;
        }

        private Response<T> CreateResponse<T>(Response response, T result)
            where T : Model
        {
            result.Deserialize(response.ContentStream);

            return new Response<T>(response, result);
        }
    }
}
