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
    /// A long-running operation for <see cref="KeyVaultBackupClient.StartPreRestore"/> or <see cref="KeyVaultBackupClient.StartPreRestoreAsync"/>.
    /// </summary>
    public class KeyVaultPreRestoreOperation : Operation<KeyVaultRestoreResult>
    {
        internal readonly RestoreOperationInternal<AzureSecurityKeyVaultAdministrationPreFullRestoreOperationHeaders, KeyVaultRestoreResult, RestoreDetailsInternal> _operationInternal;

        /// <summary>
        /// Creates an instance of a KeyVaultPreRestoreOperation from a previously started operation. <see cref="UpdateStatus(CancellationToken)"/>, <see cref="UpdateStatusAsync(CancellationToken)"/>,
        ///  <see cref="WaitForCompletionAsync(CancellationToken)"/>, or <see cref="WaitForCompletionAsync(TimeSpan, CancellationToken)"/> must be called
        /// to re-populate the details of this operation.
        /// </summary>
        /// <param name="client">An instance of <see cref="KeyVaultBackupClient" />.</param>
        /// <param name="id">The <see cref="Id" /> from a previous <see cref="KeyVaultBackupOperation" />.</param>
        /// <exception cref="ArgumentNullException"><paramref name="id"/> or <paramref name="client"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="id"/> is empty.</exception>
        public KeyVaultPreRestoreOperation(KeyVaultBackupClient client, string id)
        {
            Argument.AssertNotNull(client, nameof(client));
            Argument.AssertNotNullOrEmpty(id, nameof(id));

            _operationInternal = new RestoreOperationInternal<AzureSecurityKeyVaultAdministrationPreFullRestoreOperationHeaders, KeyVaultRestoreResult, RestoreDetailsInternal>(client, id);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyVaultPreRestoreOperation"/> class.
        /// </summary>
        /// <param name="client">An instance of <see cref="KeyVaultBackupClient" />.</param>
        /// <param name="response">The <see cref="ResponseWithHeaders{T, THeaders}" /> returned from <see cref="KeyVaultBackupClient.StartPreRestore"/> or <see cref="KeyVaultBackupClient.StartPreRestoreAsync"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="client"/> or <paramref name="response"/> is null.</exception>
        internal KeyVaultPreRestoreOperation(KeyVaultBackupClient client, ResponseWithHeaders<AzureSecurityKeyVaultAdministrationPreFullRestoreOperationHeaders> response)
        {
            Argument.AssertNotNull(client, nameof(client));
            Argument.AssertNotNull(response, nameof(response));

            _operationInternal = new RestoreOperationInternal<AzureSecurityKeyVaultAdministrationPreFullRestoreOperationHeaders, KeyVaultRestoreResult, RestoreDetailsInternal>(client, response);
        }

        /// <summary>
        /// Initializes a new instance of a KeyVaultPreRestoreOperation for mocking purposes.
        /// </summary>
        /// <param name="value">The <see cref="RestoreDetailsInternal" /> that will be used to populate various properties.</param>
        /// <param name="response">The <see cref="Response" /> that will be returned from <see cref="GetRawResponse" />.</param>
        /// <param name="client">An instance of <see cref="KeyVaultBackupClient" />.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> or <paramref name="response"/> or <paramref name="client"/> is null.</exception>
        internal KeyVaultPreRestoreOperation(RestoreDetailsInternal value, Response response, KeyVaultBackupClient client)
        {
            Argument.AssertNotNull(value, nameof(value));
            Argument.AssertNotNull(response, nameof(response));
            Argument.AssertNotNull(client, nameof(client));

            _operationInternal = new RestoreOperationInternal<AzureSecurityKeyVaultAdministrationPreFullRestoreOperationHeaders, KeyVaultRestoreResult, RestoreDetailsInternal>(value, response, client);
        }

        /// <summary> Initializes a new instance of <see cref="KeyVaultPreRestoreOperation" /> for mocking. </summary>
        protected KeyVaultPreRestoreOperation() {}

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
        public override KeyVaultRestoreResult Value => _operationInternal.Value;

        /// <inheritdoc/>
        public override bool HasCompleted => _operationInternal.HasCompleted;

        /// <inheritdoc/>
        public override bool HasValue => _operationInternal.HasValue;

        /// <inheritdoc/>
        public override Response GetRawResponse() => _operationInternal.GetRawResponse();

        /// <inheritdoc/>
        public override Response UpdateStatus(CancellationToken cancellationToken = default) => _operationInternal.UpdateStatus(cancellationToken);

        /// <inheritdoc/>
        public override async ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => await _operationInternal.UpdateStatusAsync(cancellationToken).ConfigureAwait(false);

        /// <inheritdoc/>
        public override ValueTask<Response<KeyVaultRestoreResult>> WaitForCompletionAsync(CancellationToken cancellationToken = default) =>
            _operationInternal.WaitForCompletionAsync(cancellationToken);

        /// <inheritdoc/>
        public override ValueTask<Response<KeyVaultRestoreResult>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken) =>
            _operationInternal.WaitForCompletionAsync(pollingInterval, cancellationToken);
    }
}
