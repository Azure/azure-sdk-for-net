// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Security.ConfidentialLedger
{
    /// <summary>
    /// Tracks the status of a call to and until completion.
    /// </summary>
    internal class PostLedgerEntryOperation : Operation, IOperation
    {
        /// <summary>
        /// Maximum number of consecutive 404 (Not Found) responses to tolerate
        /// while polling for the posted ledger entry before treating the
        /// transaction as failed.
        /// </summary>
        private const int MaxNotFoundRetries = 3;

        private readonly ConfidentialLedgerClient _client;
        private OperationInternal _operationInternal;
        private int _consecutiveNotFoundCount;

        internal string exceptionMessage =>
            $"Operation failed. OperationId '{Id}' is the transactionId related to the Ledger entry posted as part of this operation.";

        /// <summary>
        /// Initializes a previously run operation with the given <paramref name="transactionId"/>.
        /// </summary>
        /// <param name="client"> Tje <see cref="ConfidentialLedgerClient"/>. </param>
        /// <param name="transactionId"> The transaction id from a previous call to. </param>
        public PostLedgerEntryOperation(ConfidentialLedgerClient client, string transactionId)
        {
            _client = client;
            Id = transactionId;
            _operationInternal = new(this, _client.ClientDiagnostics, rawResponse: null, nameof(PostLedgerEntryOperation));
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

            // 406: node knows the transaction but it hasn't committed yet.
            // This is expected during consensus — keep polling indefinitely.
            if (statusResponse.Status == (int)HttpStatusCode.NotAcceptable)
            {
                _consecutiveNotFoundCount = 0;
                return OperationState.Pending(statusResponse);
            }

            // 404: node doesn't know about the transaction yet (replication lag).
            // Retry up to MaxNotFoundRetries times; after that, treat as a real failure.
            if (statusResponse.Status == (int)HttpStatusCode.NotFound)
            {
                if (++_consecutiveNotFoundCount <= MaxNotFoundRetries)
                {
                    return OperationState.Pending(statusResponse);
                }
                // Fall through to the failure path below.
            }

            if (statusResponse.Status != (int)HttpStatusCode.OK)
            {
                var ex = new RequestFailedException(statusResponse, null, new PostLedgerEntryRequestFailedDetailsParser(exceptionMessage));
                return OperationState.Failure(statusResponse, new RequestFailedException(exceptionMessage, ex));
            }

            // Got a successful response — reset the 404 counter.
            _consecutiveNotFoundCount = 0;

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

        // This method is never invoked since we don't override Operation<T>.GetRehydrationToken.
        RehydrationToken IOperation.GetRehydrationToken() =>
            throw new NotSupportedException($"{nameof(GetRehydrationToken)} is not supported.");

        /// <summary>
        /// The transactionId of the posted ledger entry.
        /// </summary>
        public override string Id { get; }

        /// <inheritdoc />
        public override bool HasCompleted => _operationInternal.HasCompleted;

        private class PostLedgerEntryRequestFailedDetailsParser : RequestFailedDetailsParser
        {
            private readonly string _message;

            public PostLedgerEntryRequestFailedDetailsParser(string message)
            {
                _message = message;
            }
            public override bool TryParse(Response response, out ResponseError error, out IDictionary<string, string> data)
            {
                error = new ResponseError(null, _message);
                data = null;
                return true;
            }
        }
    }
}
