// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
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
    public class EmailSendOperation : Operation<EmailSendResult>, IOperation<EmailSendResult>
    {
        private readonly TimeSpan DefaultPollingInterval = TimeSpan.FromSeconds(5);

        private readonly OperationInternal<EmailSendResult> _operationInternal;

        /// <summary>
        /// The client used to check for completion.
        /// </summary>
        private readonly EmailClient _client;

        /// <summary>
        /// Gets a value indicating whether the operation has completed.
        /// </summary>
        public override bool HasCompleted => _operationInternal.HasCompleted;

        /// <summary>
        /// Gets a value indicating whether the operation completed and
        /// successfully produced a value.  The <see cref="Operation{EmailSendResult}.Value"/>
        /// property is the status of the email send operation.
        /// </summary>
        public override bool HasValue => _operationInternal.HasValue;

        /// <inheritdoc />
        public override string Id { get; }

        /// <summary>
        /// Gets the status of the email send operation.
        /// </summary>
        public override EmailSendResult Value => _operationInternal.Value;

        /// <inheritdoc />
        public override Response GetRawResponse() => _operationInternal.RawResponse;

        /// <inheritdoc />
        public override async ValueTask<Response<EmailSendResult>> WaitForCompletionAsync(CancellationToken cancellationToken = default) =>
            await _operationInternal.WaitForCompletionAsync(DefaultPollingInterval, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Periodically calls the server till the long-running operation completes.
        /// </summary>
        /// <param name="suggestedPollingInterval">
        /// The interval between status requests to the server.
        /// The interval can change based on information returned from the server.
        /// For example, the server might communicate to the client that there is not reason to poll for status change sooner than some time.
        /// In that case, it uses the larger of the values between this value and the one returned from the server.
        /// </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> used for the periodical service calls.</param>
        /// <returns>The last HTTP response received from the server.</returns>
        /// <remarks>
        /// This method will periodically call UpdateStatusAsync till HasCompleted is true, then return the final result of the operation.
        /// </remarks>
        public override async ValueTask<Response<EmailSendResult>> WaitForCompletionAsync(TimeSpan suggestedPollingInterval, CancellationToken cancellationToken) =>
            await _operationInternal.WaitForCompletionAsync(suggestedPollingInterval, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public override Response<EmailSendResult> WaitForCompletion(CancellationToken cancellationToken = default) =>
            _operationInternal.WaitForCompletion(DefaultPollingInterval, cancellationToken);

        /// <summary>
        /// Periodically calls the server till the long-running operation completes.
        /// </summary>
        /// <param name="suggestedPollingInterval">
        /// The interval between status requests to the server.
        /// The interval can change based on information returned from the server.
        /// For example, the server might communicate to the client that there is not reason to poll for status change sooner than some time.
        /// In that case, it uses the larger of the values between this value and the one returned from the server.
        /// </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> used for the periodical service calls.</param>
        /// <returns>The last HTTP response received from the server.</returns>
        /// <remarks>
        /// This method will periodically call UpdateStatus till HasCompleted is true, then return the final result of the operation.
        /// </remarks>
        public override Response<EmailSendResult> WaitForCompletion(TimeSpan suggestedPollingInterval, CancellationToken cancellationToken) =>
            _operationInternal.WaitForCompletion(suggestedPollingInterval, cancellationToken);

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
            this(client, id, null)
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
        internal EmailSendOperation(
            EmailClient client,
            string copyId,
            Response initialResponse)
        {
            Id = copyId;
            _client = client;
            _operationInternal = new OperationInternal<EmailSendResult>(this, _client._clientDiagnostics, initialResponse);
        }

        /// <summary>
        /// Check for the latest status of the email send operation.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The HTTP response received from the server.</returns>
        /// <exception cref="RequestFailedException">Thrown if there's been any issues during the connection, or if the operation has completed with failures.</exception>
        public override Response UpdateStatus(CancellationToken cancellationToken = default) =>
            _operationInternal.UpdateStatus(cancellationToken);

        /// <summary>
        /// Check for the latest status of the email send operation.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The HTTP response received from the server.</returns>
        /// <exception cref="RequestFailedException">Thrown if there's been any issues during the connection, or if the operation has completed with failures.</exception>
        public override async ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) =>
            await _operationInternal.UpdateStatusAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Check for the latest status of the email send operation.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <param name="async" />
        /// <returns>The <see cref="Response"/> with the status update.</returns>
        async ValueTask<OperationState<EmailSendResult>> IOperation<EmailSendResult>.UpdateStateAsync(bool async, CancellationToken cancellationToken)
        {
            // Get the latest status
            Response<EmailSendResult> update = async
                ? await _client.GetSendResultAsync(Id, cancellationToken: cancellationToken).ConfigureAwait(false)
                : _client.GetSendResult(Id, cancellationToken: cancellationToken);

            // Save this update as the latest raw response indicating the state
            // of the copy operation
            Response rawResponse = update.GetRawResponse();

            if (update.Value.Status == EmailSendStatus.Succeeded)
            {
                return OperationState<EmailSendResult>.Success(rawResponse, update.Value);
            }
            else if (update.Value.Status == EmailSendStatus.Failed || update.Value.Status == EmailSendStatus.Canceled)
            {
                return OperationState<EmailSendResult>.Failure(rawResponse);
            }

            return OperationState<EmailSendResult>.Pending(rawResponse);
        }

        // This method is never invoked since we don't override Operation<T>.GetRehydrationToken.
        RehydrationToken IOperation<EmailSendResult>.GetRehydrationToken() =>
            throw new NotSupportedException($"{nameof(GetRehydrationToken)} is not supported.");

        private static IDictionary<string, string> CreateAdditionalInformation(ErrorDetail error)
        {
            if (string.IsNullOrEmpty(error.ToString()))
                return null;

            var additionalInformationToReturn = new Dictionary<string, string>();
            foreach (var additionalInfo in error.AdditionalInfo)
            {
                additionalInformationToReturn.Add(additionalInfo.Type, additionalInfo.Info.ToString());
            }

            return additionalInformationToReturn;
        }
    }
}
