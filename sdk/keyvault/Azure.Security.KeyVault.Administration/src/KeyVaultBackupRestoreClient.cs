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
    /// The KeyVaultBackupRestoreClient provides synchronous and asynchronous methods to perform full backup and restore of the Azure Key Vault.
    /// </summary>
    public class KeyVaultBackupRestoreClient
    {
        private readonly ClientDiagnostics _diagnostics;
        private readonly BackupRestoreRestClient _restClient;

        /// <summary>
        /// The vault Uri.
        /// </summary>
        /// <value></value>
        public virtual Uri VaultUri { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyVaultBackupRestoreClient"/> class for mocking.
        /// </summary>
        protected KeyVaultBackupRestoreClient()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyVaultBackupRestoreClient"/> class for the specified vault.
        /// </summary>
        /// <param name="vaultUri">A <see cref="Uri"/> to the vault on which the client operates. Appears as "DNS Name" in the Azure portal.</param>
        /// <param name="credential">A <see cref="TokenCredential"/> used to authenticate requests to the vault, such as DefaultAzureCredential.</param>
        /// <exception cref="ArgumentNullException"><paramref name="vaultUri"/> or <paramref name="credential"/> is null.</exception>
        public KeyVaultBackupRestoreClient(Uri vaultUri, TokenCredential credential)
            : this(vaultUri, credential, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyVaultBackupRestoreClient"/> class for the specified vault.
        /// </summary>
        /// <param name="vaultUri">A <see cref="Uri"/> to the vault on which the client operates. Appears as "DNS Name" in the Azure portal.</param>
        /// <param name="credential">A <see cref="TokenCredential"/> used to authenticate requests to the vault, such as DefaultAzureCredential.</param>
        /// <param name="options"><see cref="KeyVaultBackupRestoreClientOptions"/> that allow to configure the management of the request sent to Key Vault.</param>
        /// <exception cref="ArgumentNullException"><paramref name="vaultUri"/> or <paramref name="credential"/> is null.</exception>
        public KeyVaultBackupRestoreClient(Uri vaultUri, TokenCredential credential, KeyVaultBackupRestoreClientOptions options)
        {
            Argument.AssertNotNull(vaultUri, nameof(vaultUri));
            Argument.AssertNotNull(credential, nameof(credential));

            VaultUri = vaultUri;

            options ??= new KeyVaultBackupRestoreClientOptions();
            string apiVersion = options.GetVersionString();

            HttpPipeline pipeline = HttpPipelineBuilder.Build(options,
                    new ChallengeBasedAuthenticationPolicy(credential));

            _diagnostics = new ClientDiagnostics(options);
            _restClient = new BackupRestoreRestClient(_diagnostics, pipeline, apiVersion);
        }

        /// <summary>
        /// Initiates a full backup of the KeyVault.
        /// </summary>
        /// <param name="blobStorageUri">The Uri for the blob storage resource.</param>
        /// <param name="SasToken">A Shared Access Signature (SAS) token to authorize access to the blob.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentNullException"><paramref name="blobStorageUri"/> or <paramref name="SasToken"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns></returns>
        public virtual async Task<FullBackupOperation> StartFullBackupAsync(Uri blobStorageUri, string SasToken, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(KeyVaultBackupRestoreClient)}.{nameof(StartFullBackup)}");
            scope.Start();
            try
            {
                var response = await _restClient.FullBackupAsync(VaultUri.AbsoluteUri, new SASTokenParameter(blobStorageUri.AbsoluteUri, SasToken), cancellationToken)
                    .ConfigureAwait(false);

                return new FullBackupOperation(this, response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Initiates a full backup of the KeyVault.
        /// </summary>
        /// <param name="blobStorageUri">The Uri for the blob storage resource.</param>
        /// <param name="SasToken">A Shared Access Signature (SAS) token to authorize access to the blob.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentNullException"><paramref name="blobStorageUri"/> or <paramref name="SasToken"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns></returns>
        public virtual FullBackupOperation StartFullBackup(Uri blobStorageUri, string SasToken, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(KeyVaultBackupRestoreClient)}.{nameof(StartFullBackup)}");
            scope.Start();
            try
            {
                var response = _restClient.FullBackup(VaultUri.AbsoluteUri, new SASTokenParameter(blobStorageUri.AbsoluteUri, SasToken), cancellationToken);

                return new FullBackupOperation(this, response);
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
        public virtual async Task<Response<FullBackupDetails>> GetFullBackupDetailsAsync(string jobId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(KeyVaultBackupRestoreClient)}.{nameof(GetFullBackupDetails)}");
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
        public virtual Response<FullBackupDetails> GetFullBackupDetails(string jobId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(KeyVaultBackupRestoreClient)}.{nameof(GetFullBackupDetails)}");
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

        /// <summary>
        /// Initiates a full restore of the KeyVault.
        /// </summary>
        /// <param name="blobStorageUri">The Uri for the blob storage resource.</param>
        /// <param name="SasToken">A Shared Access Signature (SAS) token to authorize access to the blob.</param>
        /// <param name="folderName">The nameof the container containing the backup data to restore</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentNullException"><paramref name="blobStorageUri"/> or <paramref name="SasToken"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns></returns>
        public virtual async Task<FullRestoreOperation> StartFullRestoreAsync(Uri blobStorageUri, string SasToken, string folderName, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(KeyVaultBackupRestoreClient)}.{nameof(StartFullRestore)}");
            scope.Start();
            try
            {
                var response = await _restClient.FullRestoreOperationAsync(VaultUri.AbsoluteUri,
                                                                           new RestoreOperationParameters(new SASTokenParameter(blobStorageUri.AbsoluteUri, SasToken), folderName),
                                                                           cancellationToken).ConfigureAwait(false);

                return new FullRestoreOperation(this, response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Initiates a full Restore of the KeyVault.
        /// </summary>
        /// <param name="blobStorageUri">The Uri for the blob storage resource.</param>
        /// <param name="SasToken">A Shared Access Signature (SAS) token to authorize access to the blob.</param>
        /// <param name="folderName">The nameof the container containing the backup data to restore</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentNullException"><paramref name="blobStorageUri"/> or <paramref name="SasToken"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns></returns>
        public virtual FullRestoreOperation StartFullRestore(Uri blobStorageUri, string SasToken, string folderName, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(KeyVaultBackupRestoreClient)}.{nameof(StartFullRestore)}");
            scope.Start();
            try
            {
                var response = _restClient.FullRestoreOperation(VaultUri.AbsoluteUri,
                                                                new RestoreOperationParameters(new SASTokenParameter(blobStorageUri.AbsoluteUri, SasToken), folderName),
                                                                cancellationToken);

                return new FullRestoreOperation(this, response);
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
        public virtual async Task<Response<FullRestoreDetails>> GetFullRestoreDetailsAsync(string jobId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(KeyVaultBackupRestoreClient)}.{nameof(GetFullRestoreDetails)}");
            scope.Start();
            try
            {
                return await _restClient.FullRestoreStatusAsync(VaultUri.AbsoluteUri, jobId, cancellationToken).ConfigureAwait(false);
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
        public virtual Response<FullRestoreDetails> GetFullRestoreDetails(string jobId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(KeyVaultBackupRestoreClient)}.{nameof(GetFullRestoreDetails)}");
            scope.Start();
            try
            {
                return _restClient.FullRestoreStatus(VaultUri.AbsoluteUri, jobId, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }
    }
}
