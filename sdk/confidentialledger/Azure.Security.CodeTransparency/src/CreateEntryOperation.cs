// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Formats.Cbor;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Security.CodeTransparency
{
    /// <summary>
    /// Tracks a Code Transparency registration until the entry has been committed and the receipt
    /// is available.
    /// </summary>
    /// <remarks>
    /// For SCRAPI v09 (<c>api-version=2026-03-26</c>) the operation polls <c>GET /entries/{entryId}</c>,
    /// which returns <c>302 Found</c> (with a <c>Location</c> pointing at the same entry URL) while the
    /// transaction is still pending/uncached, and <c>200 OK</c> with the COSE receipt once it is
    /// committed and indexed. The pending <c>302</c> is treated as a bounded, backing-off poll — never
    /// as a generic redirect — and its <c>Location</c> is validated against the endpoint trust boundary
    /// so entry-status polling can never be redirected to an untrusted host. For legacy servers that
    /// answer an async submit with <c>202 Accepted</c>, the operation falls back to polling the
    /// deprecated <c>GET /operations/{operationId}</c> endpoint.
    /// </remarks>
    internal class CreateEntryOperation : Operation<BinaryData>, IOperation
    {
        private readonly CodeTransparencyClient _client;
        private readonly OperationInternal _operationInternal;
        private readonly BinaryData _value;
        private readonly CodeTransparencyTrustBoundary _trustBoundary;
        private readonly bool _pollEntry;
        private readonly int _maxPollingAttempts;
        private int _pollingAttempts;

        /// <summary>
        /// A constructor for mocking.
        /// </summary>
        protected CreateEntryOperation()
        { }

        /// <summary>
        /// Initializes a legacy operation that polls the deprecated <c>GET /operations/{operationId}</c>
        /// endpoint. Used only when a server answers an async submit with <c>202 Accepted</c> and a CBOR
        /// <c>OperationId</c> (pre-SCRAPI-v09 behavior).
        /// </summary>
        /// <param name="client"> The <see cref="CodeTransparencyClient"/>. </param>
        /// <param name="operationId"> The operation id from a previous call to create the entry. </param>
        public CreateEntryOperation(CodeTransparencyClient client, string operationId)
        {
            _client = client;
            Id = operationId;
            _pollEntry = false;
            _operationInternal = new(this, _client.ClientDiagnostics, rawResponse: null, nameof(CreateEntryOperation), fallbackStrategy: _client.EntryPollingFallbackStrategy);
        }

        /// <summary>
        /// Initializes an operation that polls <c>GET /entries/{entryId}</c> (SCRAPI v09) until the entry
        /// is committed, honoring the pending <c>302 Found</c> response as a bounded, backing-off poll.
        /// </summary>
        /// <param name="client"> The <see cref="CodeTransparencyClient"/>. </param>
        /// <param name="entryId"> The registration transaction id (entry id) to poll. </param>
        /// <param name="trustBoundary"> The trust boundary used to validate a pending 302 Location. </param>
        /// <param name="maxPollingAttempts"> The maximum number of pending (302) polls before failing. </param>
        /// <param name="fallbackStrategy"> The delay strategy between polls when no Retry-After is present. </param>
        /// <param name="initialResponse"> The response that started the poll (for example an async submit response), or null. </param>
        public CreateEntryOperation(CodeTransparencyClient client, string entryId, CodeTransparencyTrustBoundary trustBoundary, int maxPollingAttempts, DelayStrategy fallbackStrategy, Response initialResponse)
        {
            _client = client;
            Id = entryId;
            _trustBoundary = trustBoundary;
            _pollEntry = true;
            _maxPollingAttempts = maxPollingAttempts < 1 ? 1 : maxPollingAttempts;
            _operationInternal = new(this, _client.ClientDiagnostics, rawResponse: initialResponse, nameof(CreateEntryOperation), fallbackStrategy: fallbackStrategy);
        }

        /// <summary>
        /// Initializes a completed operation for an entry that has already been committed by the service
        /// (for example, when the entry was created with waitForCommit set to true).
        /// </summary>
        /// <param name="entryId"> The id of the committed entry. </param>
        /// <param name="rawResponse"> The final response returned by the create entry call. </param>
        /// <param name="value"> The value exposed by the completed operation. </param>
        public CreateEntryOperation(string entryId, Response rawResponse, BinaryData value)
        {
            Id = entryId;
            _value = value;
            _operationInternal = OperationInternal.Succeeded(rawResponse);
        }

        /// <summary>
        /// The operationId of the created entry.
        /// </summary>
        public override string Id { get; }

        /// <inheritdoc />
        public override bool HasCompleted => _operationInternal.HasCompleted;

        /// <inheritdoc />
        public override Response GetRawResponse() => _operationInternal.RawResponse;

        /// <inheritdoc />
        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) =>
            _operationInternal.UpdateStatusAsync(cancellationToken);

        /// <inheritdoc />
        public override Response UpdateStatus(CancellationToken cancellationToken = default) =>
            _operationInternal.UpdateStatus(cancellationToken);

        /// <inheritdoc />
        public override bool HasValue => _operationInternal.HasCompleted && _operationInternal.RawResponse != null;

        /// <inheritdoc />
        public override BinaryData Value => _value ?? _operationInternal.RawResponse.Content;

        /// <summary>
        /// Drives the poll loop (using the LRO poller for backoff / Retry-After handling) until the entry
        /// is committed, and returns the final response whose body is the COSE receipt.
        /// </summary>
        internal ValueTask<Response> WaitForReceiptResponseAsync(CancellationToken cancellationToken) =>
            _operationInternal.WaitForCompletionResponseAsync(cancellationToken);

        /// <inheritdoc cref="WaitForReceiptResponseAsync"/>
        internal Response WaitForReceiptResponse(CancellationToken cancellationToken) =>
            _operationInternal.WaitForCompletionResponse(cancellationToken);

        // Part of IOperation which is used in _operationInternal
        async ValueTask<OperationState> IOperation.UpdateStateAsync(bool async, CancellationToken cancellationToken) =>
            _pollEntry
                ? await UpdateEntryPollStateAsync(async, cancellationToken).ConfigureAwait(false)
                : await UpdateLegacyOperationStateAsync(async, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// SCRAPI v09 poll of <c>GET /entries/{entryId}</c>: 200 = committed (receipt), 302 = pending
        /// (bounded backoff after validating the Location trust boundary), anything else = failure.
        /// </summary>
        private async ValueTask<OperationState> UpdateEntryPollStateAsync(bool async, CancellationToken cancellationToken)
        {
            RequestContext context = new() { CancellationToken = cancellationToken, ErrorOptions = ErrorOptions.NoThrow };
            Response response = async
                ? await _client.GetEntryV09Async(Id, context).ConfigureAwait(false)
                : _client.GetEntryV09(Id, context);

            switch (response.Status)
            {
                case (int)HttpStatusCode.OK:
                    // Committed and indexed: the response body is the COSE receipt.
                    return OperationState.Success(response);

                case (int)HttpStatusCode.Found:
                    // 302 Found: the transaction is still pending/uncached (SCRAPI v09 section 2.4.1).
                    // Refuse to poll a Location outside the endpoint trust boundary.
                    EnsureTrustedPollTarget(response);

                    if (++_pollingAttempts >= _maxPollingAttempts)
                    {
                        return OperationState.Failure(response, new RequestFailedException(
                            $"Timed out waiting for entry '{Id}' to be committed after {_maxPollingAttempts} poll attempts."));
                    }

                    return OperationState.Pending(response);

                default:
                    return OperationState.Failure(response, new RequestFailedException(response));
            }
        }

        /// <summary>
        /// Ensures the <c>Location</c> returned with a pending (302) poll response stays within the
        /// endpoint trust boundary, refusing to poll attacker-controlled hosts.
        /// </summary>
        /// <exception cref="InvalidOperationException">The Location points outside the trust boundary.</exception>
        private void EnsureTrustedPollTarget(Response response)
        {
            if (_trustBoundary == null
                || !response.Headers.TryGetValue("Location", out string location)
                || string.IsNullOrEmpty(location))
            {
                // No Location (or no boundary configured): keep polling the same trusted entry URL.
                return;
            }

            Uri target = CodeTransparencyTrustBoundary.BuildAbsoluteUri(_client.Endpoint, location);
            if (!_trustBoundary.IsTrusted(target))
            {
                throw new InvalidOperationException(
                    $"Confidential Ledger refused to poll entry status at an untrusted redirect target origin: {CodeTransparencyTrustBoundary.FormatOrigin(target)}");
            }
        }

        /// <summary>
        /// Legacy poll of the deprecated <c>GET /operations/{operationId}</c> endpoint for pre-SCRAPI-v09
        /// servers that answer an async submit with <c>202 Accepted</c>.
        /// </summary>
        private async ValueTask<OperationState> UpdateLegacyOperationStateAsync(bool async, CancellationToken cancellationToken)
        {
            Response response = async
                ? await _client.GetOperationV09Async(
                        Id,
                        new RequestContext { CancellationToken = cancellationToken, ErrorOptions = ErrorOptions.NoThrow })
                    .ConfigureAwait(false)
                : _client.GetOperationV09(Id, new RequestContext { CancellationToken = cancellationToken, ErrorOptions = ErrorOptions.NoThrow });

            if (response.Status != (int)HttpStatusCode.OK &&
                response.Status != (int)HttpStatusCode.Created &&
                response.Status != (int)HttpStatusCode.Accepted)
            {
                RequestFailedException ex = new(response);
                return OperationState.Failure(response, new RequestFailedException($"Operation status check failed. OperationId '{Id}'", ex));
            }

            // The content of the response may be empty if we check the OperationStatus immediately after submitting an entry
            if (response.Content == null || response.Content.ToArray().Length == 0)
            {
                return OperationState.Pending(response);
            }

            string status = CborUtils.GetStringValueFromCborMapByKey(response.Content.ToArray(), "Status");

            if (!Enum.TryParse(status, true, out CodeTransparencyOperationStatus parsedStatus))
            {
                RequestFailedException ex = new(response);
                return OperationState.Failure(response, new RequestFailedException($"Operation status check failed. OperationId '{Id}'", ex));
            }
            else
            {
                switch (parsedStatus)
                {
                    case CodeTransparencyOperationStatus.Succeeded:
                        return OperationState.Success(response);
                    case CodeTransparencyOperationStatus.Failed:
                        return OperationState.Failure(response, new RequestFailedException($"Operation failed. OperationId '{Id}'"));
                    case CodeTransparencyOperationStatus.Running:
                        return OperationState.Pending(response);
                    default:
                        RequestFailedException ex = new(response);
                        return OperationState.Failure(response, new RequestFailedException($"Operation status check failed. Unknown Status: '{status}' OperationId '{Id}'", ex));
                }
            }
        }

        // This method is never invoked since we don't override Operation<T>.GetRehydrationToken.
        RehydrationToken IOperation.GetRehydrationToken() =>
            throw new NotSupportedException($"{nameof(GetRehydrationToken)} is not supported.");
    }
}
