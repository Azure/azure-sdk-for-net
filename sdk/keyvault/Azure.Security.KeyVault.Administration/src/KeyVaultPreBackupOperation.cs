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
    /// A long-running operation for <see cref="KeyVaultBackupClient.StartPreBackup"/> or <see cref="KeyVaultBackupClient.StartPreBackupAsync"/>.
    /// </summary>
    public class KeyVaultPreBackupOperation : Operation<KeyVaultBackupResult>
    {
        private readonly BackupOperationInternal<AzureSecurityKeyVaultAdministrationPreFullBackupHeaders, KeyVaultBackupResult, FullBackupDetailsInternal> _operationInternal;

        /// <summary>
        /// Creates an instance of a KeyVaultPreBackupOperation from a previously started operation. <see cref="UpdateStatus(CancellationToken)"/>, <see cref="UpdateStatusAsync(CancellationToken)"/>,
        ///  <see cref="WaitForCompletionAsync(CancellationToken)"/>, or <see cref="WaitForCompletionAsync(TimeSpan, CancellationToken)"/> must be called
        /// to re-populate the details of this operation.
        /// </summary>
        /// <param name="client">An instance of <see cref="KeyVaultBackupClient" />.</param>
        /// <param name="id">The <see cref="Id" /> from a previous <see cref="KeyVaultPreBackupOperation" />.</param>
        /// <exception cref="ArgumentNullException"><paramref name="id"/> or <paramref name="client"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="id"/> is empty.</exception>
        public KeyVaultPreBackupOperation(KeyVaultBackupClient client, string id)
        {
            _operationInternal = new BackupOperationInternal<AzureSecurityKeyVaultAdministrationPreFullBackupHeaders, KeyVaultBackupResult, FullBackupDetailsInternal>(client, id);
        }

        /// <summary>
        /// Initializes a new instance of a KeyVaultPreBackupOperation.
        /// </summary>
        /// <param name="client">An instance of <see cref="KeyVaultBackupClient" />.</param>
        /// <param name="response">The <see cref="ResponseWithHeaders{T,THeaders}"/> returned from <see cref="KeyVaultBackupClient.StartPreBackup(Uri, string, CancellationToken)"/> or <see cref="KeyVaultBackupClient.StartPreBackupAsync(Uri, string, CancellationToken)"/>.</param>
        /// <exception cref="InvalidOperationException"> The server operation does not contains an Id</exception>
        internal KeyVaultPreBackupOperation(KeyVaultBackupClient client, ResponseWithHeaders<AzureSecurityKeyVaultAdministrationPreFullBackupHeaders> response)
        {
            _operationInternal = new BackupOperationInternal<AzureSecurityKeyVaultAdministrationPreFullBackupHeaders, KeyVaultBackupResult, FullBackupDetailsInternal>(client, response);
        }

        /// <summary>
        /// Initializes a new instance of a KeyVaultPreBackupOperation for mocking purposes.
        /// </summary>
        /// <param name="value">The <see cref="FullBackupDetailsInternal" /> that will be returned from <see cref="Value" />.</param>
        /// <param name="response">The <see cref="Response" /> that will be returned from <see cref="GetRawResponse" />.</param>
        /// <param name="client">An instance of <see cref="KeyVaultBackupClient" />.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value"/>, <paramref name="response"/>, or <paramref name="client"/> is null.</exception>
        internal KeyVaultPreBackupOperation(FullBackupDetailsInternal value, Response response, KeyVaultBackupClient client)
        {
            _operationInternal = new BackupOperationInternal<AzureSecurityKeyVaultAdministrationPreFullBackupHeaders, KeyVaultBackupResult, FullBackupDetailsInternal>(value, response, client);
        }

        /// <summary> Initializes a new instance of <see cref="KeyVaultPreBackupOperation" /> for mocking. </summary>
        protected KeyVaultPreBackupOperation() { }

        /// <summary>
        /// The start time of the backup operation.
        /// </summary>
        public DateTimeOffset? StartTime => _operationInternal.StartTime;

        /// <summary>
        /// The end time of the backup operation.
        /// </summary>
        public DateTimeOffset? EndTime => _operationInternal.EndTime;

        /// <inheritdoc/>
        public override string Id => _operationInternal.Id;

        /// <summary>
        /// Gets the <see cref="FullBackupDetailsInternal"/> of the backup operation.
        /// You should await <see cref="WaitForCompletionAsync(CancellationToken)"/> before attempting to use a key in this pending state.
        /// </summary>
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