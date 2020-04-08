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
    public class RecognizeReceiptsOperation : Operation<IReadOnlyList<ExtractedReceipt>>
    {
        private Response _response;
        private IReadOnlyList<ExtractedReceipt> _value;
        private bool _hasCompleted;

        private readonly ServiceClient _serviceClient;

        /// <inheritdoc/>
        public override string Id { get; }

        /// <inheritdoc/>
        public override IReadOnlyList<ExtractedReceipt> Value => OperationHelpers.GetValue(ref _value);

        /// <inheritdoc/>
        public override bool HasCompleted => _hasCompleted;

        /// <inheritdoc/>
        public override bool HasValue => _value != null;

        /// <summary>
        /// Initializes a new instance of the <see cref="RecognizeReceiptsOperation"/> class.
        /// </summary>
        /// <param name="operationId"></param>
        /// <param name="client"></param>
        public RecognizeReceiptsOperation(string operationId, FormRecognizerClient client)
        {
            Id = operationId;
            _serviceClient = client.ServiceClient;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RecognizeReceiptsOperation"/> class.
        /// </summary>
        internal RecognizeReceiptsOperation(ServiceClient serviceClient, string operationLocation)
        {
            _serviceClient = serviceClient;

            // TODO: Add validation here
            // https://github.com/Azure/azure-sdk-for-net/issues/10385
            Id = operationLocation.Split('/').Last();
        }

        /// <inheritdoc/>
        public override Response GetRawResponse() => _response;

        /// <inheritdoc/>
        public override Response UpdateStatus(CancellationToken cancellationToken = default) =>
            UpdateStatusAsync(false, cancellationToken).EnsureCompleted();

        /// <inheritdoc/>
        public override async ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) =>
            await UpdateStatusAsync(true, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc/>
        public override ValueTask<Response<IReadOnlyList<ExtractedReceipt>>> WaitForCompletionAsync(CancellationToken cancellationToken = default) =>
            this.DefaultWaitForCompletionAsync(cancellationToken);

        /// <inheritdoc/>
        public override ValueTask<Response<IReadOnlyList<ExtractedReceipt>>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) =>
            this.DefaultWaitForCompletionAsync(pollingInterval, cancellationToken);

        private async ValueTask<Response> UpdateStatusAsync(bool async, CancellationToken cancellationToken)
        {
            if (!_hasCompleted)
            {
                var update = async
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

        private static IReadOnlyList<ExtractedReceipt> ConvertToExtractedReceipts(IReadOnlyList<DocumentResult_internal> documentResults, IReadOnlyList<ReadResult_internal> readResults)
        {
            List<ExtractedReceipt> receipts = new List<ExtractedReceipt>();
            for (int i = 0; i < documentResults.Count; i++)
            {
                receipts.Add(new ExtractedReceipt(documentResults[i], readResults));
            }
            return receipts;
        }
    }
}
