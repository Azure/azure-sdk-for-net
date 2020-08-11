// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Security.KeyVault.Administration.Models;

namespace Azure.Security.KeyVault.Administration
{
    /// <summary>
    /// The KeyVaultBackupClient provides synchronous and asynchronous methods to perform full backup and restore of the Azure Key Vault.
    /// </summary>
    public class KeyVaultBackupClient
    {
        private readonly ClientDiagnostics _diagnostics;
        private readonly BackupRestoreRestClient _restClient;

        /// <summary>
        /// The vault Uri.
        /// </summary>
        /// <value></value>
        public virtual Uri VaultUri { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyVaultBackupClient"/> class for mocking.
        /// </summary>
        protected KeyVaultBackupClient()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyVaultBackupClient"/> class for the specified vault.
        /// </summary>
        /// <param name="vaultUri">A <see cref="Uri"/> to the vault on which the client operates. Appears as "DNS Name" in the Azure portal.</param>
        /// <param name="credential">A <see cref="TokenCredential"/> used to authenticate requests to the vault, such as DefaultAzureCredential.</param>
        /// <exception cref="ArgumentNullException"><paramref name="vaultUri"/> or <paramref name="credential"/> is null.</exception>
        public KeyVaultBackupClient(Uri vaultUri, TokenCredential credential)
            : this(vaultUri, credential, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyVaultBackupClient"/> class for the specified vault.
        /// </summary>
        /// <param name="vaultUri">A <see cref="Uri"/> to the vault on which the client operates. Appears as "DNS Name" in the Azure portal.</param>
        /// <param name="credential">A <see cref="TokenCredential"/> used to authenticate requests to the vault, such as DefaultAzureCredential.</param>
        /// <param name="options"><see cref="KeyVaultBackupClientOptions"/> that allow to configure the management of the request sent to Key Vault.</param>
        /// <exception cref="ArgumentNullException"><paramref name="vaultUri"/> or <paramref name="credential"/> is null.</exception>
        public KeyVaultBackupClient(Uri vaultUri, TokenCredential credential, KeyVaultBackupClientOptions options)
        {
            Argument.AssertNotNull(vaultUri, nameof(vaultUri));
            Argument.AssertNotNull(credential, nameof(credential));

            VaultUri = vaultUri;

            options ??= new KeyVaultBackupClientOptions();
            string apiVersion = options.GetVersionString();

            HttpPipeline pipeline = HttpPipelineBuilder.Build(options,
                    new ChallengeBasedAuthenticationPolicy(credential));

            _diagnostics = new ClientDiagnostics(options);
            _restClient = new BackupRestoreRestClient(_diagnostics, pipeline, apiVersion);
        }

        /// <summary>
        /// Initiates a full backup of the Key Vault.
        /// </summary>
        /// <param name="blobStorageUri">The <see cref="Uri"/> for the blob storage resource.</param>
        /// <param name="sasToken">A Shared Access Signature (SAS) token to authorize access to the blob.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentNullException"><paramref name="blobStorageUri"/> or <paramref name="sasToken"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns>A <see cref="BackupOperation"/> to wait on this long-running operation.</returns>
        public virtual async Task<BackupOperation> StartBackupAsync(Uri blobStorageUri, string sasToken, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(KeyVaultBackupClient)}.{nameof(StartBackup)}");
            scope.Start();
            try
            {
                var response = await _restClient.FullBackupAsync(
                    VaultUri.AbsoluteUri,
                    new SASTokenParameter(blobStorageUri.AbsoluteUri, sasToken),
                    cancellationToken)
                    .ConfigureAwait(false);

                return new BackupOperation(this, response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Initiates a full backup of the Key Vault.
        /// </summary>
        /// <param name="blobStorageUri">The <see cref="Uri"/> for the blob storage resource.</param>
        /// <param name="sasToken">A Shared Access Signature (SAS) token to authorize access to the blob.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentNullException"><paramref name="blobStorageUri"/> or <paramref name="sasToken"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns>A <see cref="BackupOperation"/> to wait on this long-running operation.</returns>
        public virtual BackupOperation StartBackup(Uri blobStorageUri, string sasToken, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(KeyVaultBackupClient)}.{nameof(StartBackup)}");
            scope.Start();
            try
            {
                var response = _restClient.FullBackup(
                    VaultUri.AbsoluteUri,
                    new SASTokenParameter(blobStorageUri.AbsoluteUri, sasToken),
                    cancellationToken);

                return new BackupOperation(this, response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Initiates a full restore of the Key Vault.
        /// </summary>
        /// <param name="blobStorageUri">The <see cref="Uri"/> for the blob storage resource.</param>
        /// <param name="sasToken">A Shared Access Signature (SAS) token to authorize access to the blob.</param>
        /// <param name="folderName">The name of the container containing the backup data to restore.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentNullException"><paramref name="blobStorageUri"/> or <paramref name="sasToken"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns>A <see cref="RestoreOperation"/> to wait on this long-running operation.</returns>
        public virtual async Task<RestoreOperation> StartRestoreAsync(Uri blobStorageUri, string sasToken, string folderName = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(KeyVaultBackupClient)}.{nameof(StartRestore)}");
            scope.Start();
            try
            {
                var response = await _restClient.FullRestoreOperationAsync(
                    VaultUri.AbsoluteUri,
                    new RestoreOperationParameters(
                    new SASTokenParameter(blobStorageUri.AbsoluteUri, sasToken),
                    folderName),
                    cancellationToken).ConfigureAwait(false);

                return new RestoreOperation(this, response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Initiates a full Restore of the Key Vault.
        /// </summary>
        /// <param name="blobStorageUri">The <see cref="Uri"/> for the blob storage resource.</param>
        /// <param name="sasToken">A Shared Access Signature (SAS) token to authorize access to the blob.</param>
        /// <param name="folderName">The name of the container containing the backup data to restore.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentNullException"><paramref name="blobStorageUri"/> or <paramref name="sasToken"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns>A <see cref="RestoreOperation"/> to wait on this long-running operation.</returns>
        public virtual RestoreOperation StartRestore(Uri blobStorageUri, string sasToken, string folderName = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(KeyVaultBackupClient)}.{nameof(StartRestore)}");
            scope.Start();
            try
            {
                var response = _restClient.FullRestoreOperation(
                    VaultUri.AbsoluteUri,
                    new RestoreOperationParameters(new SASTokenParameter(blobStorageUri.AbsoluteUri, sasToken), folderName),
                    cancellationToken);

                return new RestoreOperation(this, response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Initiates a selective restore of the Key Vault.
        /// </summary>
        /// <param name="keyName">The name of the key to be restored from the supplied backup.</param>
        /// <param name="blobStorageUri">The <see cref="Uri"/> for the blob storage resource.</param>
        /// <param name="sasToken">A Shared Access Signature (SAS) token to authorize access to the blob.</param>
        /// <param name="folderName">The name of the container containing the backup data to restore.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentNullException"><paramref name="blobStorageUri"/> or <paramref name="sasToken"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns>A <see cref="RestoreOperation"/> to wait on this long-running operation.</returns>
        public virtual async Task<RestoreOperation> StartSelectiveRestoreAsync(string keyName, Uri blobStorageUri, string sasToken, string folderName = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(KeyVaultBackupClient)}.{nameof(StartSelectiveRestore)}");
            scope.Start();
            try
            {
                var response = await _restClient.SelectiveKeyRestoreOperationAsync(
                    VaultUri.AbsoluteUri,
                    keyName,
                    new SelectiveKeyRestoreOperationParameters(new SASTokenParameter(blobStorageUri.AbsoluteUri, sasToken), folderName),
                    cancellationToken).ConfigureAwait(false);

                return new RestoreOperation(this, response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Initiates a selective Restore of the Key Vault.
        /// </summary>
        /// <param name="keyName">The name of the key to be restored from the supplied backup.</param>
        /// <param name="blobStorageUri">The <see cref="Uri"/> for the blob storage resource.</param>
        /// <param name="sasToken">A Shared Access Signature (SAS) token to authorize access to the blob.</param>
        /// <param name="folderName">The name of the container containing the backup data to restore.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentNullException"><paramref name="blobStorageUri"/> or <paramref name="sasToken"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns>A <see cref="RestoreOperation"/> to wait on this long-running operation.</returns>
        public virtual RestoreOperation StartSelectiveRestore(string keyName, Uri blobStorageUri, string sasToken, string folderName = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(KeyVaultBackupClient)}.{nameof(StartSelectiveRestore)}");
            scope.Start();
            try
            {
                var response = _restClient.SelectiveKeyRestoreOperation(
                    VaultUri.AbsoluteUri,
                    keyName,
                    new SelectiveKeyRestoreOperationParameters(new SASTokenParameter(blobStorageUri.AbsoluteUri, sasToken), folderName),
                    cancellationToken);

                return new RestoreOperation(this, response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Returns the details of full restore operation.
        /// </summary>
        /// <param name="jobId"> The Job Id returned part of the full restore operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"><paramref name="jobId"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        internal virtual async Task<Response<RestoreDetailsInternal>> GetRestoreDetailsAsync(string jobId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(KeyVaultBackupClient)}.{nameof(GetRestoreDetails)}");
            scope.Start();
            try
            {
                return await _restClient.RestoreStatusAsync(VaultUri.AbsoluteUri, jobId, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Returns the details of full restore operation.
        /// </summary>
        /// <param name="jobId"> The Job Id returned part of the full restore operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"><paramref name="jobId"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        internal virtual Response<RestoreDetailsInternal> GetRestoreDetails(string jobId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(KeyVaultBackupClient)}.{nameof(GetRestoreDetails)}");
            scope.Start();
            try
            {
                return _restClient.RestoreStatus(VaultUri.AbsoluteUri, jobId, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Returns the details of full backup operation.
        /// </summary>
        /// <param name="jobId"> The Job Id returned part of the full backup operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"><paramref name="jobId"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        internal virtual async Task<Response<FullBackupDetailsInternal>> GetBackupDetailsAsync(string jobId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(KeyVaultBackupClient)}.{nameof(GetBackupDetails)}");
            scope.Start();
            try
            {
                return await _restClient.FullBackupStatusAsync(VaultUri.AbsoluteUri, jobId, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Returns the details of full backup operation.
        /// </summary>
        /// <param name="jobId"> The Job Id returned part of the full backup operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"><paramref name="jobId"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        internal virtual Response<FullBackupDetailsInternal> GetBackupDetails(string jobId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(KeyVaultBackupClient)}.{nameof(GetBackupDetails)}");
            scope.Start();
            try
            {
                return _restClient.FullBackupStatus(VaultUri.AbsoluteUri, jobId, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }
    }
}
