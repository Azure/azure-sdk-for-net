// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.Email
{
    /// <summary> An <see cref="Operation{EmailSendResult}"/> for tracking the status of a
    /// <see cref="EmailClient.SendAsync(WaitUntil, EmailMessage, CancellationToken)"/> request.
    /// Its <see cref="Operation{EmailSendResult}.Value"/> upon successful completion will
    /// be an object which contains the OperationId = <see cref="EmailSendResult.Id"/>, operation status
    /// = <see cref="EmailSendResult.Status"/> and error if any for terminal failed status.
    /// </summary>
    public class EmailSendOperation : Operation<EmailSendResult>
    {
        /// <summary>
        /// The client used to check for completion.
        /// </summary>
        private readonly EmailClient _client;

        /// <summary>
        /// The CancellationToken to use for all status checking.
        /// </summary>
        private readonly CancellationToken _cancellationToken;

        /// <summary>
        /// Whether the operation has completed.
        /// </summary>
        private bool _hasCompleted;

        /// <summary>
        /// Gets the status of the email send operation.
        /// </summary>
        private EmailSendResult _value;

        private Response _rawResponse;

        /// <summary>
        /// Gets a value indicating whether the operation has completed.
        /// </summary>
        public override bool HasCompleted => _hasCompleted;

        /// <summary>
        /// Gets a value indicating whether the operation completed and
        /// successfully produced a value.  The <see cref="Operation{EmailSendResult}.Value"/>
        /// property is the status of the email send operation.
        /// </summary>
        public override bool HasValue => (_value != null);

        /// <inheritdoc />
        public override string Id { get; }

        /// <summary>
        /// Gets the status of the email send operation.
        /// </summary>
        public override EmailSendResult Value => OperationHelpers.GetValue(ref _value);

        /// <inheritdoc />
        public override Response GetRawResponse() => _rawResponse;

        /// <inheritdoc />
        public override ValueTask<Response<EmailSendResult>> WaitForCompletionAsync(CancellationToken cancellationToken = default) =>
            this.DefaultWaitForCompletionAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<EmailSendResult>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken) =>
            this.DefaultWaitForCompletionAsync(pollingInterval, cancellationToken);

        /// <summary>
        /// Initializes a new <see cref="EmailSendOperation"/> instance for
        /// mocking.
        /// </summary>
        protected EmailSendOperation()
        {
        }

        /// <summary>
        /// Initializes a new <see cref="EmailSendOperation"/> instance
        /// </summary>
        /// <param name="client">
        /// The client used to check for completion.
        /// </param>
        /// <param name="id">The ID of this operation.</param>
        public EmailSendOperation(string id, EmailClient client) :
            this(client, id, null, CancellationToken.None)
        {
        }

        /// <summary>
        /// Initializes a new <see cref="EmailSendOperation"/> instance
        /// </summary>
        /// <param name="client">
        /// The client used to check for completion.
        /// </param>
        /// <param name="copyId">The ID of this operation.</param>
        /// <param name="initialResponse">
        /// Either the response from initiating the operation or getting the
        /// status if we're creating an operation from an existing ID.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        internal EmailSendOperation(
            EmailClient client,
            string copyId,
            Response initialResponse,
            CancellationToken cancellationToken)
        {
            Id = copyId;
            _value = null;
            _rawResponse = initialResponse;
            _client = client;
            _cancellationToken = cancellationToken;
        }

        /// <summary>
        /// Check for the latest status of the email send operation.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>The <see cref="Response"/> with the status update.</returns>
        public override Response UpdateStatus(
            CancellationToken cancellationToken = default) =>
            UpdateStatusAsync(false, cancellationToken).EnsureCompleted();

        /// <summary>
        /// Check for the latest status of the email send operation.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>The <see cref="Response"/> with the status update.</returns>
        public override async ValueTask<Response> UpdateStatusAsync(
            CancellationToken cancellationToken = default) =>
            await UpdateStatusAsync(true, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Check for the latest status of the email send operation.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <param name="async" />
        /// <returns>The <see cref="Response"/> with the status update.</returns>
        private async Task<Response> UpdateStatusAsync(bool async, CancellationToken cancellationToken)
        {
            // Short-circuit when already completed (which improves mocking
            // scenarios that won't have a client).
            if (HasCompleted)
            {
                return GetRawResponse();
            }

            // Use our original CancellationToken if the user didn't provide one
            if (cancellationToken == default)
            {
                cancellationToken = _cancellationToken;
            }

            // Get the latest status
            Response<EmailSendResult> update = async
                ? await _client.GetSendResultAsync(Id, cancellationToken: cancellationToken).ConfigureAwait(false)
                : _client.GetSendResult(Id, cancellationToken: cancellationToken);

            // Check if the operation is no longer running
            if (update.Value.Status != EmailSendStatus.NotStarted &&
                update.Value.Status != EmailSendStatus.Running)
            {
                _hasCompleted = true;
            }

            // Check if the operation succeeded
            if (Id == update.Value.Id &&
                update.Value.Status == EmailSendStatus.Succeeded)
            {
                _value = update.Value;
            }
            // Check if the operation aborted or failed
            if (Id == update.Value.Id &&
                (update.Value.Status == EmailSendStatus.Failed ||
                update.Value.Status == EmailSendStatus.Canceled))
            {
                _value = default;
            }

            // Save this update as the latest raw response indicating the state
            // of the copy operation
            Response response = update.GetRawResponse();
            _rawResponse = response;
            return response;
        }
    }
}
