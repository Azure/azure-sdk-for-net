// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Security.ConfidentialLedger
{
    /// <summary>
    /// Tracks the status of a call to <see cref="ConfidentialLedgerClient.PostLedgerEntry"/> and <see cref="ConfidentialLedgerClient.PostLedgerEntryAsync"/>
    /// until completion.
    /// </summary>
    internal class PostLedgerEntryOperation : Operation, IOperation
    {
        private readonly ConfidentialLedgerClient _client;
        private OperationInternal _operationInternal;

        internal string exceptionMessage =>
            $"Operation failed. OperationId '{Id}' is the transactionId related to the Ledger entry posted as part of this operation.";

        /// <summary>
        /// Initializes a previously run operation with the given <paramref name="transactionId"/>.
        /// </summary>
        /// <param name="client"> Tje <see cref="ConfidentialLedgerClient"/>. </param>
        /// <param name="transactionId"> The transaction id from a previous call to
        /// <see cref="ConfidentialLedgerClient.PostLedgerEntry"/>.</param>
        public PostLedgerEntryOperation(ConfidentialLedgerClient client, string transactionId)
        {
            _client = client;
            Id = transactionId;
            _operationInternal = new(_client.ClientDiagnostics, this, rawResponse: null, nameof(PostLedgerEntryOperation));
        }

        /// <summary>
        /// A constructor for mocking.
        /// </summary>
        protected PostLedgerEntryOperation()
        { }

        /// <inheritdoc />
        public override Response GetRawResponse() => _operationInternal.RawResponse;

        /// <inheritdoc />
        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) =>
            _operationInternal.UpdateStatusAsync(cancellationToken);

        /// <inheritdoc />
        public override Response UpdateStatus(CancellationToken cancellationToken = default) =>
            _operationInternal.UpdateStatus(cancellationToken);

        async ValueTask<OperationState> IOperation.UpdateStateAsync(bool async, CancellationToken cancellationToken)
        {
            var statusResponse = async
                ? await _client.GetTransactionStatusAsync(
                        Id,
                        new RequestContext { CancellationToken = cancellationToken, ErrorOptions = ErrorOptions.NoThrow })
                    .ConfigureAwait(false)
                : _client.GetTransactionStatus(Id, new RequestContext { CancellationToken = cancellationToken, ErrorOptions = ErrorOptions.NoThrow });

            if (statusResponse.Status != (int)HttpStatusCode.OK)
            {
                var error = new ResponseError(null, exceptionMessage);
                var ex = async
                    ? await _client.ClientDiagnostics.CreateRequestFailedExceptionAsync(statusResponse, error).ConfigureAwait(false)
                    : _client.ClientDiagnostics.CreateRequestFailedException(statusResponse, error);
                return OperationState.Failure(statusResponse, new RequestFailedException(exceptionMessage, ex));
            }

            string status = JsonDocument.Parse(statusResponse.Content)
                .RootElement
                .GetProperty("state")
                .GetString();
            if (status != "Pending")
            {
                return OperationState.Success(statusResponse);
            }
            return OperationState.Pending(statusResponse);
        }

        /// <summary>
        /// The transactionId of the posted ledger entry.
        /// </summary>
        public override string Id { get; }

        /// <inheritdoc />
        public override bool HasCompleted => _operationInternal.HasCompleted;
    }
}
