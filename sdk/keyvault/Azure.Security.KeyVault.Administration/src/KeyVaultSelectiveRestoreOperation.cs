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
    /// A long-running operation for <see cref="KeyVaultBackupClient.StartSelectiveRestore"/> or <see cref="KeyVaultBackupClient.StartSelectiveRestoreAsync"/>.
    /// </summary>
    public class KeyVaultSelectiveRestoreOperation : Operation<KeyVaultSelectiveRestoreResult>
    {
        private readonly RestoreOperationInternal<AzureSecurityKeyVaultAdministrationSelectiveKeyRestoreOperationHeaders, KeyVaultSelectiveRestoreResult, SelectiveKeyRestoreDetailsInternal> _operationInternal;

        /// <summary>
        /// Creates an instance of a SelectiveKeyRestoreOperation from a previously started operation. <see cref="UpdateStatus(CancellationToken)"/>, <see cref="UpdateStatusAsync(CancellationToken)"/>,
        ///  <see cref="WaitForCompletionAsync(CancellationToken)"/>, or <see cref="WaitForCompletionAsync(TimeSpan, CancellationToken)"/> must be called
        /// to re-populate the details of this operation.
        /// </summary>
        /// <param name="client">An instance of <see cref="KeyVaultBackupClient" />.</param>
        /// <param name="id">The <see cref="Id" /> from a previous <see cref="KeyVaultBackupOperation" />.</param>
        /// <exception cref="ArgumentNullException"><paramref name="id"/> or <paramref name="client"/> is null.</exception>
        public KeyVaultSelectiveRestoreOperation(KeyVaultBackupClient client, string id)
        {
            _operationInternal = new RestoreOperationInternal<AzureSecurityKeyVaultAdministrationSelectiveKeyRestoreOperationHeaders, KeyVaultSelectiveRestoreResult, SelectiveKeyRestoreDetailsInternal>(client, id);
        }

        /// <summary>
        /// Initializes a new instance of a SelectiveKeyRestoreOperation.
        /// </summary>
        /// <param name="client">An instance of <see cref="KeyVaultBackupClient" />.</param>
        /// <param name="response">The <see cref="ResponseWithHeaders{T, THeaders}" /> returned from <see cref="KeyVaultBackupClient.StartRestore"/> or <see cref="KeyVaultBackupClient.StartRestoreAsync"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="client"/> or <paramref name="response"/> is null.</exception>
        internal KeyVaultSelectiveRestoreOperation(KeyVaultBackupClient client, ResponseWithHeaders<AzureSecurityKeyVaultAdministrationSelectiveKeyRestoreOperationHeaders> response)
        {
            _operationInternal = new RestoreOperationInternal<AzureSecurityKeyVaultAdministrationSelectiveKeyRestoreOperationHeaders, KeyVaultSelectiveRestoreResult, SelectiveKeyRestoreDetailsInternal>(client, response);
        }

        /// <summary>
        /// Initializes a new instance of a SelectiveKeyRestoreOperation for mocking purposes.
        /// </summary>
        /// <param name="value">The <see cref="SelectiveKeyRestoreDetailsInternal" /> that will be used to populate various properties.</param>
        /// <param name="response">The <see cref="Response" /> that will be returned from <see cref="GetRawResponse" />.</param>
        /// <param name="client">An instance of <see cref="KeyVaultBackupClient" />.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> or <paramref name="response"/> or <paramref name="client"/> is null.</exception>
        internal KeyVaultSelectiveRestoreOperation(SelectiveKeyRestoreDetailsInternal value, Response response, KeyVaultBackupClient client)
        {
            _operationInternal = new RestoreOperationInternal<AzureSecurityKeyVaultAdministrationSelectiveKeyRestoreOperationHeaders, KeyVaultSelectiveRestoreResult, SelectiveKeyRestoreDetailsInternal>(value, response, client);
        }

        /// <summary> Initializes a new instance of <see cref="KeyVaultSelectiveRestoreOperation" /> for mocking. </summary>
        protected KeyVaultSelectiveRestoreOperation() {}

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
        public override KeyVaultSelectiveRestoreResult Value => _operationInternal.Value;

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
        public override ValueTask<Response<KeyVaultSelectiveRestoreResult>> WaitForCompletionAsync(CancellationToken cancellationToken = default) =>
            _operationInternal.WaitForCompletionAsync(cancellationToken);

        /// <inheritdoc/>
        public override ValueTask<Response<KeyVaultSelectiveRestoreResult>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken) =>
            _operationInternal.WaitForCompletionAsync(pollingInterval, cancellationToken);
    }
}
