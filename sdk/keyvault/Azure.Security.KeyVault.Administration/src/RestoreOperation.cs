﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Security.KeyVault.Administration.Models;

namespace Azure.Security.KeyVault.Administration
{
    /// <summary>
    /// A long-running operation for <see cref="KeyVaultBackupClient.StartRestore(Uri, string, string, CancellationToken)"/> or <see cref="KeyVaultBackupClient.StartRestoreAsync(Uri, string, string, CancellationToken)"/>.
    /// </summary>
    public class RestoreOperation : Operation<Response>
    {
        /// <summary>
        /// The number of seconds recommended by the service to delay before checking on completion status.
        /// </summary>
        private readonly int? _retryAfterSeconds;
        private readonly KeyVaultBackupClient _client;
        private Response _response;
        private RestoreDetailsInternal _value;
        private readonly string _id;

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
            Argument.AssertNotNull(id, nameof(id));
            Argument.AssertNotNull(client, nameof(client));

            _client = client;
            _id = id;
        }

        /// <summary>
        /// Initializes a new instance of a RestoreOperation.
        /// </summary>
        /// <param name="client">An instance of <see cref="KeyVaultBackupClient" />.</param>
        /// <param name="response">The <see cref="ResponseWithHeaders{T, THeaders}" /> returned from <see cref="KeyVaultBackupClient.StartRestore(Uri, string, string, CancellationToken)"/> or <see cref="KeyVaultBackupClient.StartRestoreAsync(Uri, string, string, CancellationToken)"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="client"/> or <paramref name="response"/> is null.</exception>
        internal RestoreOperation(KeyVaultBackupClient client, ResponseWithHeaders<ServiceFullRestoreOperationHeaders> response)
        {
            Argument.AssertNotNull(client, nameof(client));
            Argument.AssertNotNull(response, nameof(response));

            _id = response.Headers.JobId() ?? throw new InvalidOperationException("The response does not contain an Id");
            _client = client;
            _response = response.GetRawResponse();
            _retryAfterSeconds = response.Headers.RetryAfter;
        }

        /// <summary>
        /// Initializes a new instance of a RestoreOperation.
        /// </summary>
        /// <param name="client">An instance of <see cref="KeyVaultBackupClient" />.</param>
        /// <param name="response">The <see cref="ResponseWithHeaders{T, THeaders}" /> returned from <see cref="KeyVaultBackupClient.StartSelectiveRestore(string, Uri, string, string, CancellationToken)"/> or <see cref="KeyVaultBackupClient.StartSelectiveRestoreAsync(string, Uri, string, string, CancellationToken)"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="client"/> or <paramref name="response"/> is null.</exception>
        internal RestoreOperation(KeyVaultBackupClient client, ResponseWithHeaders<ServiceSelectiveKeyRestoreOperationHeaders> response)
        {
            Argument.AssertNotNull(client, nameof(client));
            Argument.AssertNotNull(response, nameof(response));

            _id = response.Headers.JobId() ?? throw new InvalidOperationException("The response does not contain an Id");
            _client = client;
            _response = response.GetRawResponse();
            _retryAfterSeconds = response.Headers.RetryAfter;
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
            Argument.AssertNotNull(value, nameof(value));
            Argument.AssertNotNull(response, nameof(response));
            Argument.AssertNotNull(client, nameof(client));

            _client = client;
            _response = response;
            _value = value;
            _id = value.JobId;
        }

        /// <summary>
        /// The start time of the restore operation.
        /// </summary>
        public DateTimeOffset? StartTime => _value?.StartTime;

        /// <summary>
        /// The end time of the restore operation.
        /// </summary>
        public DateTimeOffset? EndTime => _value?.EndTime;

        /// <inheritdoc/>
        public override string Id => _id;

        /// <inheritdoc/>
        public override Response Value
        {
            get
            {
#pragma warning disable CA1065 // Do not raise exceptions in unexpected locations
                if (!HasCompleted)
                {
                    throw new InvalidOperationException("The operation is not complete.");
                }
                if (EndTime.HasValue && _value.Error != null)
                {
                    throw new RequestFailedException($"{_value.Error.Message}\nInnerError: {_value.Error.InnerError}\nCode: {_value.Error.Code}");
                }
#pragma warning restore CA1065 // Do not raise exceptions in unexpected locations
                return _response;
            }
        }

        /// <inheritdoc/>
        public override bool HasCompleted => EndTime.HasValue;

        /// <inheritdoc/>
        public override bool HasValue => _response != null && _value?.Error == null && HasCompleted;

        /// <inheritdoc/>
        public override Response GetRawResponse() => _response;

        /// <inheritdoc/>
        public override Response UpdateStatus(CancellationToken cancellationToken = default)
        {
            if (!HasCompleted)
            {
                Response<RestoreDetailsInternal> response = _client.GetRestoreDetails(Id, cancellationToken);
                _value = response.Value;
                _response = response.GetRawResponse();
            }

            return GetRawResponse();
        }

        /// <inheritdoc/>
        public override async ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
        {
            if (!HasCompleted)
            {
                Response<RestoreDetailsInternal> response = await _client.GetRestoreDetailsAsync(Id, cancellationToken).ConfigureAwait(false);
                _value = response.Value;
                _response = response.GetRawResponse();
            }

            return GetRawResponse();
        }

        /// <inheritdoc/>
        public override ValueTask<Response<Response>> WaitForCompletionAsync(CancellationToken cancellationToken = default) =>
            _retryAfterSeconds.HasValue ? this.DefaultWaitForCompletionAsync(TimeSpan.FromSeconds(_retryAfterSeconds.Value), cancellationToken) :
                this.DefaultWaitForCompletionAsync(cancellationToken);

        /// <inheritdoc/>
        public override ValueTask<Response<Response>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken) =>
            this.DefaultWaitForCompletionAsync(pollingInterval, cancellationToken);
    }
}
