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
    /// Tracks the status of a call to <see cref="ConfidentialLedgerClient.PostLedgerEntry(WaitUntil, RequestContent, string, string, RequestContext)"/>
    /// until completion. Two polling modes are supported:
    /// <list type="bullet">
    ///   <item><description><see cref="PollingMode.Direct"/>: polls <c>GET /app/transactions/{transactionId}/status</c> on CCF.</description></item>
    ///   <item><description><see cref="PollingMode.LedgerGateway"/>: polls <c>GET /app/operations/{operationId}</c> on the Ledger Gateway, then flips <see cref="Id"/> to the CCF transaction id once the operation reaches the <c>committed</c> state.</description></item>
    /// </list>
    /// </summary>
    internal class PostLedgerEntryOperation : Operation, IOperation
    {
        private const int MaxNotFoundRetries = 3;

        /// <summary>
        /// Identifies the wire endpoint to poll for completion.
        /// </summary>
        internal enum PollingMode
        {
            /// <summary>
            /// Poll <c>/app/transactions/{transactionId}/status</c>. <see cref="Id"/> is the CCF
            /// transaction id for the entire lifetime of the operation. This is the legacy mode used
            /// when <see cref="ConfidentialLedgerClientOptions.UseLedgerGateway"/> is <c>false</c>.
            /// </summary>
            Direct,

            /// <summary>
            /// Poll <c>/app/operations/{operationId}</c> on the Ledger Gateway. <see cref="Id"/>
            /// starts as the Ledger Gateway operation id and is replaced with the CCF transaction id
            /// once the gateway reports the operation as <c>committed</c>.
            /// </summary>
            LedgerGateway,
        }

        private readonly ConfidentialLedgerClient _client;
        private readonly PollingMode _mode;
        private OperationInternal _operationInternal;
        private string _id;
        private int _consecutiveNotFoundCount;

        internal string exceptionMessage => _mode switch
        {
            PollingMode.LedgerGateway => $"Ledger Gateway operation '{Id}' did not complete successfully.",
            _ => $"Operation failed. OperationId '{Id}' is the transactionId related to the Ledger entry posted as part of this operation.",
        };

        /// <summary>
        /// Initializes a previously run operation. In <see cref="PollingMode.Direct"/>, <paramref name="id"/>
        /// is the CCF transaction id. In <see cref="PollingMode.LedgerGateway"/>, <paramref name="id"/> is the
        /// gateway operation id (which is later swapped for the transaction id once available).
        /// </summary>
        /// <param name="client"> The <see cref="ConfidentialLedgerClient"/>. </param>
        /// <param name="id"> The transaction id (Direct) or operation id (LedgerGateway) returned by the service. </param>
        /// <param name="mode"> Identifies which endpoint to poll. </param>
        /// <param name="initialResponse"> The raw response that produced <paramref name="id"/>, exposed through <see cref="GetRawResponse"/> until the first poll completes. <c>null</c> for rehydration scenarios where no I/O has occurred yet. </param>
        public PostLedgerEntryOperation(ConfidentialLedgerClient client, string id, PollingMode mode = PollingMode.Direct, Response initialResponse = null)
        {
            _client = client;
            _mode = mode;
            _id = id;
            _operationInternal = new(this, _client.ClientDiagnostics, rawResponse: initialResponse, nameof(PostLedgerEntryOperation));
        }

        /// <summary>
        /// A constructor for mocking.
        /// </summary>
        protected PostLedgerEntryOperation()
        { }

        /// <inheritdoc />
        public override Response GetRawResponse() =>
            _operationInternal.RawResponse
            ?? throw new InvalidOperationException(
                "No response is available yet. This operation was rehydrated via RehydratePostLedgerEntryOperation and has not polled the service. " +
                "Call UpdateStatus/UpdateStatusAsync (or WaitForCompletionResponse) before accessing GetRawResponse().");

        /// <inheritdoc />
        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) =>
            _operationInternal.UpdateStatusAsync(cancellationToken);

        /// <inheritdoc />
        public override Response UpdateStatus(CancellationToken cancellationToken = default) =>
            _operationInternal.UpdateStatus(cancellationToken);

        async ValueTask<OperationState> IOperation.UpdateStateAsync(bool async, CancellationToken cancellationToken)
        {
            return _mode switch
            {
                PollingMode.LedgerGateway => await UpdateLedgerGatewayStateAsync(async, cancellationToken).ConfigureAwait(false),
                _ => await UpdateDirectStateAsync(async, cancellationToken).ConfigureAwait(false),
            };
        }

        private async ValueTask<OperationState> UpdateDirectStateAsync(bool async, CancellationToken cancellationToken)
        {
            var context = new RequestContext { CancellationToken = cancellationToken, ErrorOptions = ErrorOptions.NoThrow };
            // A 404 is deliberately counted by this operation, not by the pipeline retry policy. Mark it
            // non-error for this request so one UpdateStatus call means exactly one HTTP request.
            context.AddClassifier((int)HttpStatusCode.NotFound, isError: false);
            var statusResponse = async
                ? await _client.GetTransactionStatusAsync(
                        Id,
                        context)
                    .ConfigureAwait(false)
                : _client.GetTransactionStatus(Id, context);

            if (statusResponse.Status == (int)HttpStatusCode.NotAcceptable)
            {
                _consecutiveNotFoundCount = 0;
                return OperationState.Pending(statusResponse);
            }

            if (statusResponse.Status == (int)HttpStatusCode.NotFound
                && ++_consecutiveNotFoundCount <= MaxNotFoundRetries)
            {
                return OperationState.Pending(statusResponse);
            }

            if (statusResponse.Status != (int)HttpStatusCode.OK)
            {
                var ex = new RequestFailedException(statusResponse, null, new PostLedgerEntryRequestFailedDetailsParser(exceptionMessage));
                return OperationState.Failure(statusResponse, new RequestFailedException(exceptionMessage, ex));
            }

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

        private async ValueTask<OperationState> UpdateLedgerGatewayStateAsync(bool async, CancellationToken cancellationToken)
        {
            var statusResponse = async
                ? await _client.GetOperationStatusAsync(
                        Id,
                        new RequestContext { CancellationToken = cancellationToken, ErrorOptions = ErrorOptions.NoThrow })
                    .ConfigureAwait(false)
                : _client.GetOperationStatus(Id, new RequestContext { CancellationToken = cancellationToken, ErrorOptions = ErrorOptions.NoThrow });

            // 404 from /app/operations/{id} means the operation status was evicted from the gateway's
            // record store after its retention period. The underlying write may or may not have committed;
            // the operation is terminally unresolvable here and the caller must reconcile out of band.
            if (statusResponse.Status == (int)HttpStatusCode.NotFound)
            {
                var message = $"Ledger Gateway operation '{Id}' was not found (HTTP 404). The operation status has been evicted from the gateway after its retention period and the outcome of the underlying ledger write must be reconciled out of band.";
                return OperationState.Failure(statusResponse, new RequestFailedException(statusResponse.Status, message));
            }

            if (statusResponse.Status != (int)HttpStatusCode.OK)
            {
                var ex = new RequestFailedException(statusResponse, null, new PostLedgerEntryRequestFailedDetailsParser(exceptionMessage));
                return OperationState.Failure(statusResponse, new RequestFailedException(exceptionMessage, ex));
            }

            string status;
            string transactionId = null;
            string code = null;
            string detail = null;
            using (JsonDocument doc = JsonDocument.Parse(statusResponse.Content))
            {
                JsonElement root = doc.RootElement;
                status = root.TryGetProperty("status", out JsonElement statusProp) ? statusProp.GetString() : null;

                if (root.TryGetProperty("transactionId", out JsonElement txIdProp))
                {
                    transactionId = txIdProp.GetString();
                }

                if (root.TryGetProperty("error", out JsonElement errProp) && errProp.ValueKind == JsonValueKind.Object)
                {
                    if (errProp.TryGetProperty("code", out JsonElement codeProp))
                    {
                        code = codeProp.GetString();
                    }
                    if (errProp.TryGetProperty("message", out JsonElement msgProp))
                    {
                        detail = msgProp.GetString();
                    }
                }
            }

            switch (status)
            {
                case "committed":
                    if (string.IsNullOrEmpty(transactionId))
                    {
                        // A committed operation must carry the CCF transaction id; without it the caller
                        // has no usable id for GetReceipt / GetLedgerEntry, so surface a terminal failure
                        // rather than reporting success with the (now meaningless) gateway operation id.
                        return OperationState.Failure(
                            statusResponse,
                            new RequestFailedException(
                                statusResponse.Status,
                                $"Ledger Gateway operation '{Id}' reported status 'committed' without a transactionId; the CCF transaction cannot be resolved and the write must be reconciled out of band."));
                    }

                    // Swap the public Id from the gateway operation id to the CCF transaction id
                    // so downstream code can use it with GetReceipt / GetLedgerEntry / etc.
                    _id = transactionId;
                    return OperationState.Success(statusResponse);

                case "failed":
                    var failureMessage = $"Ledger Gateway operation '{Id}' failed."
                        + (code != null ? $" Code: {code}." : string.Empty)
                        + (detail != null ? $" Detail: {detail}" : string.Empty);
                    return OperationState.Failure(statusResponse, new RequestFailedException(statusResponse.Status, failureMessage, code, innerException: null));

                case "queued":
                    return OperationState.Pending(statusResponse);

                default:
                    // Any other (or missing / mis-cased) status is unexpected. Fail terminally rather than
                    // polling forever - with WaitUntil.Completed and no cancellation token the caller would
                    // otherwise hang indefinitely.
                    return OperationState.Failure(
                        statusResponse,
                        new RequestFailedException(
                            statusResponse.Status,
                            $"Ledger Gateway operation '{Id}' returned an unrecognized status '{status ?? "<null>"}'. Expected 'queued', 'committed', or 'failed'."));
            }
        }

        // This method is never invoked since we don't override Operation<T>.GetRehydrationToken.
        RehydrationToken IOperation.GetRehydrationToken() =>
            throw new NotSupportedException($"{nameof(GetRehydrationToken)} is not supported.");

        /// <summary>
        /// In <see cref="PollingMode.Direct"/>, the CCF transaction id of the posted ledger entry.
        /// In <see cref="PollingMode.LedgerGateway"/>, initially the Ledger Gateway operation id;
        /// once the gateway reports the operation as <c>committed</c>, this is replaced by the CCF
        /// transaction id returned by the gateway.
        /// </summary>
        public override string Id => _id;

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
