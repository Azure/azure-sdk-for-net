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
    /// A long-running operation for <see cref="KeyVaultBackupClient.StartBackup(Uri, string, CancellationToken)"/> or <see cref="KeyVaultBackupClient.StartBackupAsync(Uri, string, CancellationToken)"/>.
    /// </summary>
    public class BackupOperation : Operation<BackupResult>
    {
        /// <summary>
        /// The number of seconds recommended by the service to delay before checking on completion status.
        /// </summary>
        internal int? _retryAfterSeconds;
        private readonly KeyVaultBackupClient _client;
        private Response _response;
        private FullBackupDetailsInternal _value;
        private readonly string _id;
        private RequestFailedException _requestFailedException;

        /// <summary>
        /// Creates an instance of a BackupOperation from a previously started operation. <see cref="UpdateStatus(CancellationToken)"/>, <see cref="UpdateStatusAsync(CancellationToken)"/>,
        ///  <see cref="WaitForCompletionAsync(CancellationToken)"/>, or <see cref="WaitForCompletionAsync(TimeSpan, CancellationToken)"/> must be called
        /// to re-populate the details of this operation.
        /// </summary>
        /// <param name="client">An instance of <see cref="KeyVaultBackupClient" />.</param>
        /// <param name="id">The <see cref="Id" /> from a previous <see cref="BackupOperation" />.</param>
        /// <exception cref="ArgumentNullException"><paramref name="id"/> or <paramref name="client"/> is null.</exception>
        public BackupOperation(KeyVaultBackupClient client, string id)
        {
            Argument.AssertNotNull(id, nameof(id));
            Argument.AssertNotNull(client, nameof(client));

            _client = client;
            _id = id;
        }

        /// <summary>
        /// Initializes a new instance of a BackupOperation.
        /// </summary>
        /// <param name="client">An instance of <see cref="KeyVaultBackupClient" />.</param>
        /// <param name="response">The <see cref="ResponseWithHeaders{T, THeaders}" /> returned from <see cref="KeyVaultBackupClient.StartBackup(Uri, string, CancellationToken)"/> or <see cref="KeyVaultBackupClient.StartBackupAsync(Uri, string, CancellationToken)"/>.</param>
        internal BackupOperation(KeyVaultBackupClient client, ResponseWithHeaders<AzureSecurityKeyVaultAdministrationFullBackupHeaders> response)
        {
            _client = client;
            _response = response;
            _retryAfterSeconds = response.Headers.RetryAfter;
            _id = response.Headers.JobId() ?? throw new InvalidOperationException("The response does not contain an Id");
        }

        /// <summary>
        /// Initializes a new instance of a BackupOperation for mocking purposes.
        /// </summary>
        /// <param name="value">The <see cref="FullBackupDetailsInternal" /> that will be returned from <see cref="Value" />.</param>
        /// <param name="response">The <see cref="Response" /> that will be returned from <see cref="GetRawResponse" />.</param>
        /// <param name="client">An instance of <see cref="KeyVaultBackupClient" />.</param>
        internal BackupOperation(FullBackupDetailsInternal value, Response response, KeyVaultBackupClient client)
        {
            Argument.AssertNotNull(value, nameof(value));
            Argument.AssertNotNull(response, nameof(response));
            Argument.AssertNotNull(client, nameof(client));

            _response = response;
            _value = value;
            _id = value.JobId;
            _client = client;
        }

        /// <summary>
        /// The start time of the backup operation.
        /// </summary>
        public DateTimeOffset? StartTime => _value?.StartTime;

        /// <summary>
        /// The end time of the backup operation.
        /// </summary>
        public DateTimeOffset? EndTime => _value?.EndTime;

        /// <inheritdoc/>
        public override string Id => _id;

        /// <summary>
        /// Gets the <see cref="FullBackupDetailsInternal"/> of the backup operation.
        /// You should await <see cref="WaitForCompletionAsync(CancellationToken)"/> before attempting to use a key in this pending state.
        /// </summary>
        public override BackupResult Value
        {
            get
            {
#pragma warning disable CA1065 // Do not raise exceptions in unexpected locations
                if (!HasCompleted)
                {
                    throw new InvalidOperationException("The operation is not complete.");
                }
                if (_requestFailedException != null)
                {
                    throw _requestFailedException;
                }
#pragma warning restore CA1065 // Do not raise exceptions in unexpected locations
                return new BackupResult(new Uri(_value.AzureStorageBlobContainerUri), _value.StartTime.Value, _value.EndTime.Value);
            }
        }

        /// <inheritdoc/>
        public override bool HasCompleted => _value?.EndTime.HasValue ?? false;

        /// <inheritdoc/>
        public override bool HasValue => _response != null && _value?.Error == null && HasCompleted;

        /// <inheritdoc/>
        public override Response GetRawResponse() => _response;

        /// <inheritdoc/>
        public override Response UpdateStatus(CancellationToken cancellationToken = default) =>
            UpdateStatusAsync(false, cancellationToken).EnsureCompleted();

        /// <inheritdoc/>
        public override async ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) =>
            await UpdateStatusAsync(true, cancellationToken).ConfigureAwait(false);

        private async ValueTask<Response> UpdateStatusAsync(bool async, CancellationToken cancellationToken = default)
        {
            if (!HasCompleted)
            {
                try
                {
                    Response<FullBackupDetailsInternal> response = async ?
                        await _client.GetBackupDetailsAsync(Id, cancellationToken).ConfigureAwait(false)
                        : _client.GetBackupDetails(Id, cancellationToken);

                    _value = response.Value;
                    _response = response.GetRawResponse();
                }
                catch (RequestFailedException ex)
                {
                    _requestFailedException = ex;
                    throw;
                }
                catch (Exception ex)
                {
                    _requestFailedException = new RequestFailedException("Unexpected failure", ex);
                    throw _requestFailedException;
                }
                if (_value != null && _value.EndTime.HasValue && _value.Error != null)
                {
                    _requestFailedException = new RequestFailedException($"{_value.Error.Message}\nInnerError: {_value.Error.InnerError}\nCode: {_value.Error.Code}");
                    throw _requestFailedException;
                }
            }

            return GetRawResponse();
        }

        /// <inheritdoc/>
        public override ValueTask<Response<BackupResult>> WaitForCompletionAsync(CancellationToken cancellationToken = default) =>
            _retryAfterSeconds.HasValue ? this.DefaultWaitForCompletionAsync(TimeSpan.FromSeconds(_retryAfterSeconds.Value), cancellationToken) :
                this.DefaultWaitForCompletionAsync(cancellationToken);

        /// <inheritdoc/>
        public override ValueTask<Response<BackupResult>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken) =>
                this.DefaultWaitForCompletionAsync(pollingInterval, cancellationToken);
    }
}
