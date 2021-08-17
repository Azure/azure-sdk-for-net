﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Security.ConfidentialLedger
{
    /// <summary>
    /// Tracks the status of a call to <see cref="ConfidentialLedgerClient.PostLedgerEntry(Azure.Core.RequestContent,string,bool,Azure.RequestOptions)"/> and <see cref="ConfidentialLedgerClient.PostLedgerEntryAsync(Azure.Core.RequestContent,string,bool,Azure.RequestOptions)"/>
    /// until completion.
    /// </summary>
    public class PostLedgerEntryOperation : Operation, IOperation
    {
        private readonly ConfidentialLedgerClient _client;
        private OperationInternal _operationInternal;

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
            _operationInternal = new(_client.clientDiagnostics, this, rawResponse: null, nameof(PostLedgerEntryOperation));
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

        /// <inheritdoc />
        public override ValueTask<Response> WaitForCompletionResponseAsync(CancellationToken cancellationToken = default) =>
            this.DefaultWaitForCompletionResponseAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response> WaitForCompletionResponseAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) =>
            this.DefaultWaitForCompletionResponseAsync(pollingInterval, cancellationToken);

        async ValueTask<OperationState> IOperation.UpdateStateAsync(bool async, CancellationToken cancellationToken)
        {
            try
            {
                var statusResponse = async ?
                    await _client.GetTransactionStatusAsync(Id, new RequestOptions { CancellationToken = cancellationToken }).ConfigureAwait(false) :
                    _client.GetTransactionStatus(Id, new RequestOptions { CancellationToken = cancellationToken });

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
            catch (Exception e)
            {
                var exception = new OperationFailedException(e.Message, Id, e);
                return OperationState.Failure(null, exception);
            }
        }

        /// <summary>
        /// The transactionId of the posted ledger entry.
        /// </summary>
        public override string Id { get; }

        /// <inheritdoc />
        public override bool HasCompleted => _operationInternal.HasCompleted;
    }
}
