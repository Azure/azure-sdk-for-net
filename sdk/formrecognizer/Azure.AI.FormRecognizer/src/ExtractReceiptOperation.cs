// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// </summary>
    public class RecognizeUSReceiptOperation : Operation<IReadOnlyList<UnitedStatesReceipt>>
    {
        private Response _response;
        private IReadOnlyList<UnitedStatesReceipt> _value;
        private bool _hasCompleted;

        // TODO: use this.
        private CancellationToken _cancellationToken;

        private readonly ServiceClient _serviceClient;

        /// <inheritdoc/>
        public override string Id { get; }

        /// <inheritdoc/>
        public override IReadOnlyList<UnitedStatesReceipt> Value => OperationHelpers.GetValue(ref _value);

        /// <inheritdoc/>
        public override bool HasCompleted => _hasCompleted;

        /// <inheritdoc/>
        public override bool HasValue => _value != null;

        /// <inheritdoc/>
        public override Response GetRawResponse() => _response;

        /// <inheritdoc/>
        public override ValueTask<Response<IReadOnlyList<UnitedStatesReceipt>>> WaitForCompletionAsync(CancellationToken cancellationToken = default) =>
            this.DefaultWaitForCompletionAsync(cancellationToken);

        /// <inheritdoc/>
        public override ValueTask<Response<IReadOnlyList<UnitedStatesReceipt>>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) =>
            this.DefaultWaitForCompletionAsync(pollingInterval, cancellationToken);

        internal RecognizeUSReceiptOperation(ServiceClient operations, string operationLocation)
        {
            _serviceClient = operations;

            // TODO: Add validation here
            // https://github.com/Azure/azure-sdk-for-net/issues/10385
            Id = operationLocation.Split('/').Last();
        }

        /// <summary>
        /// Initializes a new <see cref="RecognizeUSReceiptOperation"/> instance.
        /// </summary>
        /// <param name="id">The ID of this operation.</param>
        /// <param name="client">The client used to check for completion.</param>
        /// <param name="cancellationToken"></param>
        public RecognizeUSReceiptOperation(string id, FormRecognizerClient client, CancellationToken cancellationToken = default)
        {
            Id = id;
            _serviceClient = client.ServiceClient;
            _cancellationToken = cancellationToken;
        }

        /// <inheritdoc/>
        public override Response UpdateStatus(CancellationToken cancellationToken = default) =>
            UpdateStatusAsync(false, cancellationToken).EnsureCompleted();

        /// <inheritdoc/>
        public override async ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) =>
            await UpdateStatusAsync(true, cancellationToken).ConfigureAwait(false);

        private async ValueTask<Response> UpdateStatusAsync(bool async, CancellationToken cancellationToken)
        {
            if (!_hasCompleted)
            {
                Response<AnalyzeOperationResult_internal> update = async
                    ? await _serviceClient.GetAnalyzeReceiptResultAsync(new Guid(Id), cancellationToken).ConfigureAwait(false)
                    : _serviceClient.GetAnalyzeReceiptResult(new Guid(Id), cancellationToken);

                // TODO: Handle correctly according to returned status code
                // https://github.com/Azure/azure-sdk-for-net/issues/10386

                if (update.Value.Status == OperationStatus.Succeeded || update.Value.Status == OperationStatus.Failed)
                {
                    _hasCompleted = true;

                    // TODO: When they support extracting more than one receipt, add a pageable method for this.
                    // https://github.com/Azure/azure-sdk-for-net/issues/10389
                    //_value = new ExtractedReceipt(update.Value.AnalyzeResult.DocumentResults.First(), update.Value.AnalyzeResult.ReadResults.First());
                    _value = ConvertToExtractedReceipts(update.Value.AnalyzeResult.DocumentResults, update.Value.AnalyzeResult.ReadResults);
                }

                _response = update.GetRawResponse();
            }

            return GetRawResponse();
        }

        private static IReadOnlyList<UnitedStatesReceipt> ConvertToExtractedReceipts(IList<DocumentResult_internal> documentResults, IList<ReadResult_internal> readResults)
        {
            List<UnitedStatesReceipt> receipts = new List<UnitedStatesReceipt>();
            for (int i = 0; i < documentResults.Count; i++)
            {
                receipts.Add(new UnitedStatesReceipt(documentResults[i], readResults));
            }
            return receipts;
        }
    }
}
