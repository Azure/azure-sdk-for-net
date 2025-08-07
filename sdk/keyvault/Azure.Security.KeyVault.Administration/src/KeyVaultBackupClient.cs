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
    /// The KeyVaultBackupClient provides synchronous and asynchronous methods to perform full and selective key backup and restore of the Azure Managed HSM.
    /// </summary>
    public class KeyVaultBackupClient
    {
        private readonly ClientDiagnostics _diagnostics;
        private readonly KeyVaultRestClient _restClient;

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
        /// <param name="vaultUri">A <see cref="Uri"/> to the vault on which the client operates. Appears as "DNS Name" in the Azure portal. You should validate that this URI references a valid Managed HSM resource. See <see href="https://aka.ms/azsdk/blog/vault-uri"/> for details.</param>
        /// <param name="credential">A <see cref="TokenCredential"/> used to authenticate requests to the vault, such as DefaultAzureCredential.</param>
        /// <exception cref="ArgumentNullException"><paramref name="vaultUri"/> or <paramref name="credential"/> is null.</exception>
        public KeyVaultBackupClient(Uri vaultUri, TokenCredential credential)
            : this(vaultUri, credential, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyVaultBackupClient"/> class for the specified vault.
        /// </summary>
        /// <param name="vaultUri">A <see cref="Uri"/> to the vault on which the client operates. Appears as "DNS Name" in the Azure portal You should validate that this URI references a valid Managed HSM resource. See <see href="https://aka.ms/azsdk/blog/vault-uri"/> for details..</param>
        /// <param name="credential">A <see cref="TokenCredential"/> used to authenticate requests to the vault, such as DefaultAzureCredential.</param>
        /// <param name="options"><see cref="KeyVaultAdministrationClientOptions"/> that allow to configure the management of the request sent to Key Vault.</param>
        /// <exception cref="ArgumentNullException"><paramref name="vaultUri"/> or <paramref name="credential"/> is null.</exception>
        public KeyVaultBackupClient(Uri vaultUri, TokenCredential credential, KeyVaultAdministrationClientOptions options)
        {
            Argument.AssertNotNull(vaultUri, nameof(vaultUri));
            Argument.AssertNotNull(credential, nameof(credential));

            VaultUri = vaultUri;

            options ??= new KeyVaultAdministrationClientOptions();
            _diagnostics = new ClientDiagnostics(options, true);
            _restClient = new KeyVaultRestClient(VaultUri, credential, options);
        }

        /// <summary>
        /// Initiates a full key backup of the Key Vault.
        /// </summary>
        /// <param name="blobStorageUri">The <see cref="Uri"/> for the blob storage resource.</param>
        /// <param name="sasToken">Optional Shared Access Signature (SAS) token to authorize access to the blob. If null, Managed Identity will be used to authenticate instead.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentNullException"><paramref name="blobStorageUri"/> or <paramref name="sasToken"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns>A <see cref="KeyVaultBackupOperation"/> to wait on this long-running operation.</returns>
        public virtual async Task<KeyVaultBackupOperation> StartBackupAsync(Uri blobStorageUri, string sasToken = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(KeyVaultBackupClient)}.{nameof(StartBackup)}");
            scope.Start();
            try
            {
                var operation = await _restClient.FullBackupAsync(
                    WaitUntil.Started,
                    new SASTokenParameter(blobStorageUri.AbsoluteUri, sasToken),
                    cancellationToken)
                    .ConfigureAwait(false);

                // Rest client returns an Operation without headers, so we need to create a new response with headers.
                var headers = new AzureSecurityKeyVaultAdministrationFullBackupHeaders(operation.GetRawResponse());
                var responseWithHeaders = ResponseWithHeaders.FromValue(headers,operation.GetRawResponse());

                return new KeyVaultBackupOperation(this, responseWithHeaders);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Initiates a full key backup of the Key Vault.
        /// </summary>
        /// <param name="blobStorageUri">The <see cref="Uri"/> for the blob storage resource.</param>
        /// <param name="sasToken">Optional Shared Access Signature (SAS) token to authorize access to the blob. If null, Managed Identity will be used to authenticate instead.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentNullException"><paramref name="blobStorageUri"/> or <paramref name="sasToken"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns>A <see cref="KeyVaultBackupOperation"/> to wait on this long-running operation.</returns>
        public virtual KeyVaultBackupOperation StartBackup(Uri blobStorageUri, string sasToken = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(KeyVaultBackupClient)}.{nameof(StartBackup)}");
            scope.Start();
            try
            {
                var operation = _restClient.FullBackup(
                    WaitUntil.Started,
                    new SASTokenParameter(blobStorageUri.AbsoluteUri, sasToken),
                    cancellationToken);

                // Rest client returns an Operation without headers, so we need to create a new response with headers.
                var headers = new AzureSecurityKeyVaultAdministrationFullBackupHeaders(operation.GetRawResponse());
                var responseWithHeaders = ResponseWithHeaders.FromValue(headers, operation.GetRawResponse());

                return new KeyVaultBackupOperation(this, responseWithHeaders);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Initiates a full key restore of the Key Vault.
        /// </summary>
        /// <param name="folderUri">
        /// The <see cref="Uri"/> for the blob storage resource, including the path to the blob container where the backup resides.
        /// This would be the exact value that is returned as the result of a <see cref="KeyVaultBackupOperation"/>.
        /// An example Uri may look like the following: https://contoso.blob.core.windows.net/backup/mhsm-contoso-2020090117323313.
        /// </param>
        /// <param name="sasToken">Optional Shared Access Signature (SAS) token to authorize access to the blob. If null, Managed Identity will be used to authenticate instead.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentNullException"><paramref name="folderUri"/> or <paramref name="sasToken"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns>A <see cref="KeyVaultRestoreOperation"/> to wait on this long-running operation.</returns>
        [CallerShouldAudit(KeyVaultAdministrationClientOptions.CallerShouldAuditReason)]
        public virtual async Task<KeyVaultRestoreOperation> StartRestoreAsync(Uri folderUri, string sasToken = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(KeyVaultBackupClient)}.{nameof(StartRestore)}");
            scope.Start();
            try
            {
                // Get the folder name from the backupBlobUri returned from a previous BackupOperation
                ParseFolderName(folderUri, out string containerUriString, out string folderName);

                var operation = await _restClient.FullRestoreOperationAsync(
                   WaitUntil.Started,
                    new RestoreOperationParameters(
                        new SASTokenParameter(containerUriString, sasToken),
                            folderName),
                    cancellationToken).ConfigureAwait(false);

                // Rest client returns an Operation without headers, so we need to create a new response with headers.
                var headers = new AzureSecurityKeyVaultAdministrationFullRestoreOperationHeaders(operation.GetRawResponse());
                var responseWithHeaders = ResponseWithHeaders.FromValue(headers, operation.GetRawResponse());

                return new KeyVaultRestoreOperation(this, responseWithHeaders);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Initiates a full key restore of the Key Vault.
        /// </summary>
        /// <param name="folderUri">
        /// The <see cref="Uri"/> for the blob storage resource, including the path to the blob container where the backup resides.
        /// This would be the exact value that is returned as the result of a <see cref="KeyVaultBackupOperation"/>.
        /// An example Uri path may look like the following: https://contoso.blob.core.windows.net/backup/mhsm-contoso-2020090117323313.
        /// </param>
        /// <param name="sasToken">Optional Shared Access Signature (SAS) token to authorize access to the blob. If null, Managed Identity will be used to authenticate instead.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentNullException"><paramref name="folderUri"/> or <paramref name="sasToken"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns>A <see cref="KeyVaultRestoreOperation"/> to wait on this long-running operation.</returns>
        [CallerShouldAudit(KeyVaultAdministrationClientOptions.CallerShouldAuditReason)]
        public virtual KeyVaultRestoreOperation StartRestore(Uri folderUri, string sasToken = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(KeyVaultBackupClient)}.{nameof(StartRestore)}");
            scope.Start();
            try
            {
                // Get the folder name from the backupBlobUri returned from a previous BackupOperation
                ParseFolderName(folderUri, out string containerUriString, out string folderName);

                var operation = _restClient.FullRestoreOperation(
                    WaitUntil.Started,
                    new RestoreOperationParameters(
                        new SASTokenParameter(containerUriString, sasToken),
                            folderName),
                    cancellationToken);

                // Rest client returns an Operation without headers, so we need to create a new response with headers.
                var headers = new AzureSecurityKeyVaultAdministrationFullRestoreOperationHeaders(operation.GetRawResponse());
                var responseWithHeaders = ResponseWithHeaders.FromValue(headers, operation.GetRawResponse());

                return new KeyVaultRestoreOperation(this, responseWithHeaders);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Initiates a selective key restore of the Key Vault.
        /// </summary>
        /// <param name="keyName">The name of the key to be restored from the supplied backup.</param>
        /// <param name="folderUri">
        /// The <see cref="Uri"/> for the blob storage resource, including the path to the blob container where the backup resides.
        /// This would be the exact value that is returned as the result of a <see cref="KeyVaultBackupOperation"/>.
        /// An example Uri path may look like the following: https://contoso.blob.core.windows.net/backup/mhsm-contoso-2020090117323313.
        /// </param>
        /// <param name="sasToken">Optional Shared Access Signature (SAS) token to authorize access to the blob. If null, Managed Identity will be used to authenticate instead.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentNullException"><paramref name="folderUri"/> or <paramref name="sasToken"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns>A <see cref="KeyVaultSelectiveKeyRestoreOperation"/> to wait on this long-running operation.</returns>
        [CallerShouldAudit(KeyVaultAdministrationClientOptions.CallerShouldAuditReason)]
        public virtual async Task<KeyVaultSelectiveKeyRestoreOperation> StartSelectiveKeyRestoreAsync(string keyName, Uri folderUri, string sasToken = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(KeyVaultBackupClient)}.{nameof(StartSelectiveKeyRestore)}");
            scope.Start();
            try
            {
                // Get the folder name from the backupBlobUri returned from a previous BackupOperation
                string[] uriSegments = folderUri.Segments;
                string folderName = uriSegments[uriSegments.Length - 1];
                string containerUriString = folderUri.AbsoluteUri.Substring(0, folderUri.AbsoluteUri.LastIndexOf("/", StringComparison.OrdinalIgnoreCase));

                var operation = await _restClient.SelectiveKeyRestoreOperationAsync(
                    WaitUntil.Started,
                    keyName,
                    new SelectiveKeyRestoreOperationParameters(
                            new SASTokenParameter(containerUriString, sasToken),
                                folderName),
                    cancellationToken).ConfigureAwait(false);

                // Rest client returns an Operation without headers, so we need to create a new response with headers.
                var headers = new AzureSecurityKeyVaultAdministrationSelectiveKeyRestoreOperationHeaders(operation.GetRawResponse());
                var responseWithHeaders = ResponseWithHeaders.FromValue(headers, operation.GetRawResponse());

                return new KeyVaultSelectiveKeyRestoreOperation(this, responseWithHeaders);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Initiates a selective key restore of the Key Vault.
        /// </summary>
        /// <param name="keyName">The name of the key to be restored from the supplied backup.</param>
        /// <param name="folderUri">
        /// The <see cref="Uri"/> for the blob storage resource, including the path to the blob container where the backup resides.
        /// This would be the exact value that is returned as the result of a <see cref="KeyVaultBackupOperation"/>.
        /// An example Uri path may look like the following: https://contoso.blob.core.windows.net/backup/mhsm-contoso-2020090117323313.
        /// </param>
        /// <param name="sasToken">Optional Shared Access Signature (SAS) token to authorize access to the blob. If null, Managed Identity will be used to authenticate instead.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentNullException"><paramref name="folderUri"/> or <paramref name="sasToken"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns>A <see cref="KeyVaultSelectiveKeyRestoreOperation"/> to wait on this long-running operation.</returns>
        [CallerShouldAudit(KeyVaultAdministrationClientOptions.CallerShouldAuditReason)]
        public virtual KeyVaultSelectiveKeyRestoreOperation StartSelectiveKeyRestore(string keyName, Uri folderUri, string sasToken = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(KeyVaultBackupClient)}.{nameof(StartSelectiveKeyRestore)}");
            scope.Start();
            try
            {
                // Get the folder name from the backupBlobUri returned from a previous BackupOperation
                string[] uriSegments = folderUri.Segments;
                string folderName = uriSegments[uriSegments.Length - 1];
                string containerUriString = folderUri.AbsoluteUri.Substring(0, folderUri.AbsoluteUri.LastIndexOf("/", StringComparison.OrdinalIgnoreCase));

                var operation = _restClient.SelectiveKeyRestoreOperation(
                    WaitUntil.Started,
                    keyName,
                    new SelectiveKeyRestoreOperationParameters(
                            new SASTokenParameter(containerUriString, sasToken),
                                folderName),
                    cancellationToken);

                // Rest client returns an Operation without headers, so we need to create a new response with headers.
                var headers = new AzureSecurityKeyVaultAdministrationSelectiveKeyRestoreOperationHeaders(operation.GetRawResponse());
                var responseWithHeaders = ResponseWithHeaders.FromValue(headers, operation.GetRawResponse());

                return new KeyVaultSelectiveKeyRestoreOperation(this, responseWithHeaders);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Returns the details of a full key restore operation.
        /// </summary>
        /// <param name="jobId"> The Job Id returned part of the full restore operation. </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentNullException"><paramref name="jobId"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        internal virtual async Task<Response<RestoreDetailsInternal>> GetRestoreDetailsAsync(string jobId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(KeyVaultBackupClient)}.{nameof(GetRestoreDetails)}");
            scope.Start();
            try
            {
                return await _restClient.RestoreStatusAsync(jobId, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Returns the details of a full key restore operation.
        /// </summary>
        /// <param name="jobId"> The Job Id returned part of the full restore operation. </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentNullException"><paramref name="jobId"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        internal virtual Response<RestoreDetailsInternal> GetRestoreDetails(string jobId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(KeyVaultBackupClient)}.{nameof(GetRestoreDetails)}");
            scope.Start();
            try
            {
                return _restClient.RestoreStatus(jobId, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Returns the details of a selective key restore operation.
        /// </summary>
        /// <param name="jobId"> The Job Id returned part of the full restore operation. </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentNullException"><paramref name="jobId"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        internal virtual async Task<Response<SelectiveKeyRestoreDetailsInternal>> GetSelectiveKeyRestoreDetailsAsync(string jobId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(KeyVaultBackupClient)}.{nameof(GetRestoreDetails)}");
            scope.Start();
            try
            {
                var restoreResult = await _restClient.RestoreStatusAsync(jobId, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new SelectiveKeyRestoreDetailsInternal((RestoreDetailsInternal)(object)restoreResult.Value), restoreResult.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Returns the details of a selective key restore operation.
        /// </summary>
        /// <param name="jobId"> The Job Id returned part of the full restore operation. </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentNullException"><paramref name="jobId"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        internal virtual Response<SelectiveKeyRestoreDetailsInternal> GetSelectiveKeyRestoreDetails(string jobId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(KeyVaultBackupClient)}.{nameof(GetRestoreDetails)}");
            scope.Start();
            try
            {
                var restoreResult = _restClient.RestoreStatus(jobId, cancellationToken);
                return Response.FromValue(new SelectiveKeyRestoreDetailsInternal((RestoreDetailsInternal)(object)restoreResult.Value), restoreResult.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Initiate a pre-restore check on a Key Vault. This operation checks if it is possible to restore the entire collection of keys from a Key Vault.
        /// </summary>
        /// <param name="folderUri">
        /// The <see cref="Uri"/> for the blob storage resource, including the path to the blob container where the backup resides.
        /// This would be the exact value that is returned as the result of a <see cref="KeyVaultBackupOperation"/>.
        /// An example <paramref name="folderUri" /> may look like the following: https://contoso.blob.core.windows.net/backup/mhsm-contoso-2020090117323313.
        /// </param>
        /// <param name="sasToken">Optional Shared Access Signature (SAS) token to authorize access to the blob. If null, Managed Identity will be used to authenticate instead.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentNullException"><paramref name="folderUri"/> or <paramref name="sasToken"/> are <c>null</c>.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns>A <see cref="KeyVaultRestoreOperation"/> representing the result of the asynchronous operation.</returns>
        public virtual async Task<KeyVaultRestoreOperation> StartPreRestoreAsync(Uri folderUri, string sasToken = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(folderUri, nameof(folderUri));
            Argument.AssertNotNull(sasToken, nameof(sasToken));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(KeyVaultBackupClient)}.{nameof(StartPreRestore)}");
            scope.Start();
            try
            {
                // Get the folder name from the backupBlobUri returned from a previous BackupOperation
                ParseFolderName(folderUri, out string containerUriString, out string folderName);

                var operation = await _restClient.PreFullRestoreOperationAsync(
                    WaitUntil.Started,
                    new PreRestoreOperationParameters()
                    {
                        SasTokenParameters = new SASTokenParameter(containerUriString, sasToken),
                        FolderToRestore = folderUri.AbsoluteUri
                    },
                    cancellationToken).ConfigureAwait(false);

                // Rest client returns an Operation without headers, so we need to create a new response with headers.
                var headers = new AzureSecurityKeyVaultAdministrationFullRestoreOperationHeaders(operation.GetRawResponse());
                var responseWithHeaders = ResponseWithHeaders.FromValue(headers, operation.GetRawResponse());

                return new KeyVaultRestoreOperation(this, responseWithHeaders);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Initiate a pre-restore check on a Key Vault. This operation checks if it is possible to restore the entire collection of keys from a Key Vault.
        /// </summary>
        /// <param name="folderUri">
        /// The <see cref="Uri"/> for the blob storage resource, including the path to the blob container where the backup resides.
        /// This would be the exact value that is returned as the result of a <see cref="KeyVaultBackupOperation"/>.
        /// An example <paramref name="folderUri" /> path may look like the following: https://contoso.blob.core.windows.net/backup/mhsm-contoso-2020090117323313.
        /// </param>
        /// <param name="sasToken">Optional Shared Access Signature (SAS) token to authorize access to the blob. If null, Managed Identity will be used to authenticate instead.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentNullException"><paramref name="folderUri"/> or <paramref name="sasToken"/> are <c>null</c>.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns>A <see cref="KeyVaultRestoreOperation"/> to wait on this long-running operation.</returns>
        public virtual KeyVaultRestoreOperation StartPreRestore(Uri folderUri, string sasToken = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(folderUri, nameof(folderUri));
            Argument.AssertNotNull(sasToken, nameof(sasToken));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(KeyVaultBackupClient)}.{nameof(StartPreRestore)}");
            scope.Start();
            try
            {
                // Get the folder name from the backupBlobUri returned from a previous BackupOperation
                ParseFolderName(folderUri, out string containerUriString, out string folderName);

                var operation = _restClient.PreFullRestoreOperation(
                    WaitUntil.Started,
                    new PreRestoreOperationParameters()
                    {
                        SasTokenParameters = new SASTokenParameter(containerUriString, sasToken),
                        FolderToRestore = folderUri.AbsoluteUri
                    },
                    cancellationToken);

                // Rest client returns an Operation without headers, so we need to create a new response with headers.
                var headers = new AzureSecurityKeyVaultAdministrationFullRestoreOperationHeaders(operation.GetRawResponse());
                var responseWithHeaders = ResponseWithHeaders.FromValue(headers, operation.GetRawResponse());

                return new KeyVaultRestoreOperation(this, responseWithHeaders);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Returns the details of a full key backup operation.
        /// </summary>
        /// <param name="jobId"> The Job Id returned part of the full backup operation. </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentNullException"><paramref name="jobId"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        internal virtual async Task<Response<FullBackupDetailsInternal>> GetBackupDetailsAsync(string jobId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(KeyVaultBackupClient)}.{nameof(GetBackupDetails)}");
            scope.Start();
            try
            {
                return await _restClient.FullBackupStatusAsync(jobId, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Returns the details of a full key backup operation.
        /// </summary>
        /// <param name="jobId"> The Job Id returned part of the full backup operation. </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentNullException"><paramref name="jobId"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        internal virtual Response<FullBackupDetailsInternal> GetBackupDetails(string jobId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(KeyVaultBackupClient)}.{nameof(GetBackupDetails)}");
            scope.Start();
            try
            {
                return _restClient.FullBackupStatus(jobId, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Initiates a pre-backup check on the Key Vault. This operation checks if it is possible to back up the entire collection of keys from a Key Vault.
        /// </summary>
        /// <param name="blobStorageUri">The <see cref="Uri"/> for the blob storage resource.</param>
        /// <param name="sasToken">Optional Shared Access Signature (SAS) token to authorize access to the blob. If null, Managed Identity will be used to authenticate instead.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentNullException"><paramref name="blobStorageUri"/> or <paramref name="sasToken"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns>A <see cref="KeyVaultBackupOperation"/> representing the result of the asynchronous operation.</returns>
        public virtual async Task<KeyVaultBackupOperation> StartPreBackupAsync(Uri blobStorageUri, string sasToken = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(blobStorageUri, nameof(blobStorageUri));
            Argument.AssertNotNull(sasToken, nameof(sasToken));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(KeyVaultBackupClient)}.{nameof(StartPreBackup)}");
            scope.Start();
            try
            {
                Operation<FullBackupDetailsInternal> operation = await _restClient.PreFullBackupAsync(
                    WaitUntil.Started,
                    new PreBackupOperationParameters()
                    {
                        StorageResourceUri = blobStorageUri.AbsoluteUri,
                        Token = sasToken,
                        UseManagedIdentity = (sasToken == default)
                    },
                    cancellationToken).ConfigureAwait(false);

                // Rest client returns an Operation without headers, so we need to create a new response with headers.
                var headers = new AzureSecurityKeyVaultAdministrationFullBackupHeaders(operation.GetRawResponse());
                var responseWithHeaders = ResponseWithHeaders.FromValue(headers,operation.GetRawResponse());

                return new KeyVaultBackupOperation(this, responseWithHeaders);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Initiates a pre-backup check on the Key Vault. This operation checks if it is possible to back up the entire collection of keys from a Key Vault.
        /// </summary>
        /// <param name="blobStorageUri">The <see cref="Uri"/> for the blob storage resource.</param>
        /// <param name="sasToken">Optional Shared Access Signature (SAS) token to authorize access to the blob. If null, Managed Identity will be used to authenticate instead.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentNullException"><paramref name="blobStorageUri"/> or <paramref name="sasToken"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns>A <see cref="KeyVaultBackupOperation"/> representing the result of the operation.</returns>
        public virtual KeyVaultBackupOperation StartPreBackup(Uri blobStorageUri, string sasToken = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(blobStorageUri, nameof(blobStorageUri));
            Argument.AssertNotNull(sasToken, nameof(sasToken));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(KeyVaultBackupClient)}.{nameof(StartPreBackup)}");
            scope.Start();
            try
            {
                Operation<FullBackupDetailsInternal> operation = _restClient.PreFullBackup(
                    WaitUntil.Started,
                    new PreBackupOperationParameters()
                    {
                        StorageResourceUri = blobStorageUri.AbsoluteUri,
                        Token = sasToken,
                        UseManagedIdentity = (sasToken == default)
                    },
                    cancellationToken);

                // Rest client returns an Operation without headers, so we need to create a new response with headers.
                var headers = new AzureSecurityKeyVaultAdministrationFullBackupHeaders(operation.GetRawResponse());
                var responseWithHeaders = ResponseWithHeaders.FromValue(headers,operation.GetRawResponse());

                return new KeyVaultBackupOperation(this, responseWithHeaders);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        internal static void ParseFolderName(Uri folderUri, out string containerUriString, out string folderName)
        {
            int indexOfContainerBoundary = folderUri.AbsoluteUri.IndexOf('/', folderUri.Scheme.Length + 4);
            indexOfContainerBoundary = folderUri.AbsoluteUri.IndexOf('/', indexOfContainerBoundary + 1) + 1;

            containerUriString = folderUri.AbsoluteUri.Substring(0, indexOfContainerBoundary - 1);
            folderName = folderUri.AbsoluteUri.Substring(indexOfContainerBoundary, folderUri.AbsoluteUri.Length - indexOfContainerBoundary);
        }
    }
}
