// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Security.KeyVault.Administration.Models;

namespace Azure.Security.KeyVault.Administration
{
    /// <summary>
    /// A long-running operation for <see cref="KeyVaultBackupClient.StartBackup(Uri, string, CancellationToken)"/> or <see cref="KeyVaultBackupClient.StartBackupAsync(Uri, string, CancellationToken)"/>.
    /// </summary>
    public class KeyVaultBackupOperation : Operation<KeyVaultBackupResult>
    {
        private readonly BackupOperationInternal<AzureSecurityKeyVaultAdministrationFullBackupHeaders, KeyVaultBackupResult, FullBackupDetailsInternal> _operationInternal;

        /// <summary>
        /// Creates an instance of a KeyVaultBackupOperation from a previously started operation. <see cref="UpdateStatus(CancellationToken)"/>, <see cref="UpdateStatusAsync(CancellationToken)"/>,
        ///  <see cref="WaitForCompletionAsync(CancellationToken)"/>, or <see cref="WaitForCompletionAsync(TimeSpan, CancellationToken)"/> must be called
        /// to re-populate the details of this operation.
        /// </summary>
        /// <param name="client">An instance of <see cref="KeyVaultBackupClient" />.</param>
        /// <param name="id">The <see cref="Id" /> from a previous <see cref="KeyVaultBackupOperation" />.</param>
        /// <exception cref="ArgumentNullException"><paramref name="id"/> or <paramref name="client"/> is null.</exception>
        public KeyVaultBackupOperation(KeyVaultBackupClient client, string id)
        {
            _operationInternal = new BackupOperationInternal<AzureSecurityKeyVaultAdministrationFullBackupHeaders, KeyVaultBackupResult, FullBackupDetailsInternal>(client, id);
        }

        /// <summary>
        /// Initializes a new instance of a KeyVaultBackupOperation.
        /// </summary>
        /// <param name="client">An instance of <see cref="KeyVaultBackupClient" />.</param>
        /// <param name="response">The <see cref="ResponseWithHeaders{T, THeaders}" /> returned from <see cref="KeyVaultBackupClient.StartBackup(Uri, string, CancellationToken)"/> or <see cref="KeyVaultBackupClient.StartBackupAsync(Uri, string, CancellationToken)"/>.</param>
        internal KeyVaultBackupOperation(KeyVaultBackupClient client, ResponseWithHeaders<AzureSecurityKeyVaultAdministrationFullBackupHeaders> response)
        {
            _operationInternal = new BackupOperationInternal<AzureSecurityKeyVaultAdministrationFullBackupHeaders, KeyVaultBackupResult, FullBackupDetailsInternal>(client, response);
        }

        /// <summary>
        /// Initializes a new instance of a KeyVaultBackupOperation for mocking purposes.
        /// </summary>
        /// <param name="value">The <see cref="FullBackupDetailsInternal" /> that will be returned from <see cref="Value" />.</param>
        /// <param name="response">The <see cref="Response" /> that will be returned from <see cref="GetRawResponse" />.</param>
        /// <param name="client">An instance of <see cref="KeyVaultBackupClient" />.</param>
        internal KeyVaultBackupOperation(FullBackupDetailsInternal value, Response response, KeyVaultBackupClient client)
        {
            _operationInternal = new BackupOperationInternal<AzureSecurityKeyVaultAdministrationFullBackupHeaders, KeyVaultBackupResult, FullBackupDetailsInternal>(value, response, client);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyVaultBackupOperation"/> class.
        /// </summary>
        protected KeyVaultBackupOperation() { }

        /// <inheritdoc/>
        public DateTimeOffset? StartTime => _operationInternal.StartTime;

        /// <inheritdoc/>
        public DateTimeOffset? EndTime => _operationInternal.EndTime;

        /// <inheritdoc/>
        public override string Id => _operationInternal.Id;

        /// <inheritdoc/>
        public override KeyVaultBackupResult Value => _operationInternal.Value;

        /// <inheritdoc/>
        public override bool HasCompleted => _operationInternal.HasCompleted;

        /// <inheritdoc/>
        public override bool HasValue => _operationInternal.HasValue;

        /// <inheritdoc/>
        public override Response GetRawResponse() => _operationInternal.GetRawResponse();

        /// <inheritdoc/>
        public override Response UpdateStatus(CancellationToken cancellationToken = default) =>
            _operationInternal.UpdateStatus(cancellationToken);

        /// <inheritdoc/>
        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) =>
            _operationInternal.UpdateStatusAsync(cancellationToken);

        /// <inheritdoc/>
        public override ValueTask<Response<KeyVaultBackupResult>> WaitForCompletionAsync(CancellationToken cancellationToken = default) =>
            _operationInternal.WaitForCompletionAsync(cancellationToken);

        /// <inheritdoc/>
        public override ValueTask<Response<KeyVaultBackupResult>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken) =>
            _operationInternal.WaitForCompletionAsync(pollingInterval, cancellationToken);
    }
}
