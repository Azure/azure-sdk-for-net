// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Security.ConfidentialLedger
{
    /// <summary>
    /// Tracks the status of a call to <see cref="ConfidentialLedgerClient.PostLedgerEntry"/> and <see cref="ConfidentialLedgerClient.PostLedgerEntryAsync"/>
    /// until completion.
    /// </summary>
    public class PostLedgerEntryOperation : Operation
    {
        private readonly ConfidentialLedgerClient _client;
        private Response _response;
        private bool _hasCompleted;
        private OperationFailedException _exception;

        /// <summary>
        /// Initializes a previously run operation with the given <paramref name="transactionId"/>.
        /// </summary>
        /// <param name="client"> Tje <see cref="ConfidentialLedgerClient"/>. </param>
        /// <param name="transactionId"> The transaction id from a previous call to
        /// <see cref="ConfidentialLedgerClient.PostLedgerEntry(Azure.Core.RequestContent,string,bool,Azure.RequestOptions)"/>. </param>
        public PostLedgerEntryOperation(ConfidentialLedgerClient client, string transactionId)
        {
            _client = client;
            Id = transactionId;
        }

        /// <summary>
        /// A constructor for mocking.
        /// </summary>
        protected PostLedgerEntryOperation()
        { }

        /// <inheritdoc />
        public override Response GetRawResponse() => _response;

        /// <inheritdoc />
        public override async ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _client._clientDiagnostics.CreateScope($"{nameof(PostLedgerEntryOperation)}.{nameof(UpdateStatus)}");
            scope.Start();

            try
            {
                var statusResponse = await _client.GetTransactionStatusAsync(Id, new RequestOptions { CancellationToken = cancellationToken }).ConfigureAwait(false);
                string status = JsonDocument.Parse(statusResponse.Content)
                    .RootElement
                    .GetProperty("state")
                    .GetString();
                if (status != "Pending")
                {
                    _response = statusResponse;
                    _hasCompleted = true;
                }
            }
            catch (Exception e)
            {
                _exception = new OperationFailedException(e.Message, Id, e);
                scope.Failed(_exception);
                throw _exception;
            }

            return GetRawResponse();
        }

        /// <inheritdoc />
        public override Response UpdateStatus(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _client._clientDiagnostics.CreateScope($"{nameof(PostLedgerEntryOperation)}.{nameof(UpdateStatus)}");
            scope.Start();

            try
            {
                var statusResponse = _client.GetTransactionStatus(Id, new RequestOptions { CancellationToken = cancellationToken });
                string status = JsonDocument.Parse(statusResponse.Content)
                    .RootElement
                    .GetProperty("state")
                    .GetString();
                if (status != "Pending")
                {
                    _response = statusResponse;
                    _hasCompleted = true;
                }
            }
            catch (Exception e)
            {
                _exception = new OperationFailedException(e.Message, Id, e);
                scope.Failed(_exception);
                throw _exception;
            }

            return GetRawResponse();
        }

        /// <inheritdoc />
        public override ValueTask<Response> WaitForCompletionResponseAsync(CancellationToken cancellationToken = default) =>
            this.DefaultWaitForCompletionResponseAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response> WaitForCompletionResponseAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) =>
            this.DefaultWaitForCompletionResponseAsync(pollingInterval, cancellationToken);

        /// <summary>
        /// The transactionId of the posted ledger entry.
        /// </summary>
        public override string Id { get; }

        /// <inheritdoc />
        public override bool HasCompleted => _hasCompleted;
    }
}
