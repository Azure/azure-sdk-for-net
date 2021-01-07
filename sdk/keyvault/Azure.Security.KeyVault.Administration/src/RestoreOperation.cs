// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Security.KeyVault.Administration.Models;

namespace Azure.Security.KeyVault.Administration
{
    /// <summary>
    /// A long-running operation for <see cref="KeyVaultBackupClient.StartRestore"/> or <see cref="KeyVaultBackupClient.StartRestoreAsync"/>.
    /// </summary>
    public class RestoreOperation : Operation<RestoreResult>
    {
        internal readonly RestoreOperationInternal<AzureSecurityKeyVaultAdministrationFullRestoreOperationHeaders, RestoreResult, RestoreDetailsInternal> _operationInternal;

        /// <summary>
        /// Creates an instance of a RestoreOperation from a previously started operation. <see cref="UpdateStatus(CancellationToken)"/>, <see cref="UpdateStatusAsync(CancellationToken)"/>,
        ///  <see cref="WaitForCompletionAsync(CancellationToken)"/>, or <see cref="WaitForCompletionAsync(TimeSpan, CancellationToken)"/> must be called
        /// to re-populate the details of this operation.
        /// </summary>
        /// <param name="client">An instance of <see cref="KeyVaultBackupClient" />.</param>
        /// <param name="id">The <see cref="Id" /> from a previous <see cref="BackupOperation" />.</param>
        /// <exception cref="ArgumentNullException"><paramref name="id"/> or <paramref name="client"/> is null.</exception>
        public RestoreOperation(KeyVaultBackupClient client, string id)
        {
            _operationInternal = new RestoreOperationInternal<AzureSecurityKeyVaultAdministrationFullRestoreOperationHeaders, RestoreResult, RestoreDetailsInternal>(client, id);
        }

        /// <summary>
        /// Initializes a new instance of a RestoreOperation.
        /// </summary>
        /// <param name="client">An instance of <see cref="KeyVaultBackupClient" />.</param>
        /// <param name="response">The <see cref="ResponseWithHeaders{T, THeaders}" /> returned from <see cref="KeyVaultBackupClient.StartRestore"/> or <see cref="KeyVaultBackupClient.StartRestoreAsync"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="client"/> or <paramref name="response"/> is null.</exception>
        internal RestoreOperation(KeyVaultBackupClient client, ResponseWithHeaders<AzureSecurityKeyVaultAdministrationFullRestoreOperationHeaders> response)
        {
            _operationInternal = new RestoreOperationInternal<AzureSecurityKeyVaultAdministrationFullRestoreOperationHeaders, RestoreResult, RestoreDetailsInternal>(client, response);
        }

        /// <summary>
        /// Initializes a new instance of a RestoreOperation for mocking purposes.
        /// </summary>
        /// <param name="value">The <see cref="RestoreDetailsInternal" /> that will be used to populate various properties.</param>
        /// <param name="response">The <see cref="Response" /> that will be returned from <see cref="GetRawResponse" />.</param>
        /// <param name="client">An instance of <see cref="KeyVaultBackupClient" />.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> or <paramref name="response"/> or <paramref name="client"/> is null.</exception>
        internal RestoreOperation(RestoreDetailsInternal value, Response response, KeyVaultBackupClient client)
        {
            _operationInternal = new RestoreOperationInternal<AzureSecurityKeyVaultAdministrationFullRestoreOperationHeaders, RestoreResult, RestoreDetailsInternal>(value, response, client);
        }

        /// <summary>
        /// The start time of the restore operation.
        /// </summary>
        public DateTimeOffset? StartTime => _operationInternal.StartTime;

        /// <summary>
        /// The end time of the restore operation.
        /// </summary>
        public DateTimeOffset? EndTime => _operationInternal.EndTime;

        /// <inheritdoc/>
        public override string Id => _operationInternal.Id;

        /// <inheritdoc/>
        public override RestoreResult Value => _operationInternal.Value;

        /// <inheritdoc/>
        public override bool HasCompleted => _operationInternal.HasCompleted;

        /// <inheritdoc/>
        public override bool HasValue => _operationInternal.HasValue;

        /// <inheritdoc/>
        public override Response GetRawResponse() => _operationInternal.GetRawResponse();

        /// <inheritdoc/>
        public override Response UpdateStatus(CancellationToken cancellationToken = default) => _operationInternal.UpdateStatus(cancellationToken);

        /// <inheritdoc/>
        public override async ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) =>
            await _operationInternal.UpdateStatusAsync(cancellationToken).ConfigureAwait(false);

        /// <inheritdoc/>
        public override ValueTask<Response<RestoreResult>> WaitForCompletionAsync(CancellationToken cancellationToken = default) =>
            _operationInternal.WaitForCompletionAsync(cancellationToken);

        /// <inheritdoc/>
        public override ValueTask<Response<RestoreResult>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken) =>
            _operationInternal.WaitForCompletionAsync(pollingInterval, cancellationToken);
    }
}
