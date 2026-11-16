// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Security.ConfidentialLedger.Models;

namespace Azure.Security.ConfidentialLedger
{
    /// <summary>
    /// Typed view over <see cref="PostLedgerEntryOperation"/> whose <see cref="Value"/> is the
    /// <see cref="LedgerWriteResult"/> of the posted ledger entry.
    /// </summary>
    internal class PostLedgerEntryResultOperation : Operation<LedgerWriteResult>
    {
        private readonly PostLedgerEntryOperation _operation;
        private readonly LedgerWriteResult _initialResult;
        private readonly string _requestedCollectionId;

        internal PostLedgerEntryResultOperation(PostLedgerEntryOperation operation, string requestedCollectionId)
        {
            _operation = operation;
            _requestedCollectionId = requestedCollectionId;
            _initialResult = LedgerWriteResult.TryFromResponse(operation.GetRawResponse());
        }

        /// <summary> A constructor for mocking. </summary>
        protected PostLedgerEntryResultOperation()
        { }

        /// <inheritdoc />
        public override string Id => _operation.Id;

        /// <inheritdoc />
        public override bool HasCompleted => _operation.HasCompleted;

        /// <inheritdoc />
        public override bool HasValue => _operation.CompletedState.HasValue;

        /// <inheritdoc />
        public override LedgerWriteResult Value
        {
            get
            {
                TransactionState state = _operation.CompletedState
                    ?? throw new InvalidOperationException(_operation.HasCompleted
                        ? $"The ledger write operation '{Id}' did not complete successfully."
                        : $"The ledger write operation '{Id}' has not completed. Call WaitForCompletion or UpdateStatus until HasCompleted is true.");

                if (_initialResult != null)
                {
                    return _initialResult.With(Id, _initialResult.CollectionId ?? _requestedCollectionId, state);
                }

                return ConfidentialLedgerModelFactory.LedgerWriteResult(transactionId: Id, collectionId: _requestedCollectionId, state: state);
            }
        }

        /// <inheritdoc />
        public override Response GetRawResponse() => _operation.GetRawResponse();

        /// <inheritdoc />
        public override Response UpdateStatus(CancellationToken cancellationToken = default) =>
            _operation.UpdateStatus(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) =>
            _operation.UpdateStatusAsync(cancellationToken);

        /// <inheritdoc />
        public override Response<LedgerWriteResult> WaitForCompletion(CancellationToken cancellationToken = default)
        {
            Response response = _operation.WaitForCompletionResponse(cancellationToken);
            return Response.FromValue(Value, response);
        }

        /// <inheritdoc />
        public override async ValueTask<Response<LedgerWriteResult>> WaitForCompletionAsync(CancellationToken cancellationToken = default)
        {
            Response response = await _operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
            return Response.FromValue(Value, response);
        }
    }
}
