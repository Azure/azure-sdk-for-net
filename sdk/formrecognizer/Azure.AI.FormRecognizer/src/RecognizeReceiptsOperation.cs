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
    /// Tracks the status of a long-running operation for recognizing values from receipts.
    /// </summary>
    public class RecognizeReceiptsOperation : Operation<IReadOnlyList<RecognizedReceipt>>
    {
        /// <summary>Provides communication with the Form Recognizer Azure Cognitive Service through its REST API.</summary>
        private readonly ServiceClient _serviceClient;

        /// <summary>The last HTTP response received from the server. <c>null</c> until the first response is received.</summary>
        private Response _response;

        /// <summary>The result of the long-running operation. <c>null</c> until result is received on status update.</summary>
        private IReadOnlyList<RecognizedReceipt> _value;

        /// <summary><c>true</c> if the long-running operation has completed. Otherwise, <c>false</c>.</summary>
        private bool _hasCompleted;

        /// <inheritdoc/>
        public override string Id { get; }

        /// <inheritdoc/>
        public override IReadOnlyList<RecognizedReceipt> Value => OperationHelpers.GetValue(ref _value);

        /// <inheritdoc/>
        public override bool HasCompleted => _hasCompleted;

        /// <inheritdoc/>
        public override bool HasValue => _value != null;

        /// <inheritdoc/>
        public override Response GetRawResponse() => _response;

        /// <summary>
        /// Initializes a new instance of the <see cref="RecognizeReceiptsOperation"/> class.
        /// </summary>
        /// <param name="operationId">The ID of this operation.</param>
        /// <param name="client">The client used to check for completion.</param>
        public RecognizeReceiptsOperation(string operationId, FormRecognizerClient client)
        {
            // TODO: Add argument validation here.

            Id = operationId;
            _serviceClient = client.ServiceClient;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RecognizeReceiptsOperation"/> class.
        /// </summary>
        /// <param name="serviceClient">The client for communicating with the Form Recognizer Azure Cognitive Service through its REST API.</param>
        /// <param name="operationLocation">The address of the long-running operation. It can be obtained from the response headers upon starting the operation.</param>
        internal RecognizeReceiptsOperation(ServiceClient serviceClient, string operationLocation)
        {
            _serviceClient = serviceClient;

            // TODO: Add validation here
            // https://github.com/Azure/azure-sdk-for-net/issues/10385
            Id = operationLocation.Split('/').Last();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RecognizeReceiptsOperation"/> class.
        /// </summary>
        protected RecognizeReceiptsOperation()
        {
        }

        /// <inheritdoc/>
        public override ValueTask<Response<IReadOnlyList<RecognizedReceipt>>> WaitForCompletionAsync(CancellationToken cancellationToken = default) =>
            this.DefaultWaitForCompletionAsync(cancellationToken);

        /// <inheritdoc/>
        public override ValueTask<Response<IReadOnlyList<RecognizedReceipt>>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) =>
            this.DefaultWaitForCompletionAsync(pollingInterval, cancellationToken);

        /// <inheritdoc/>
        public override Response UpdateStatus(CancellationToken cancellationToken = default) =>
            UpdateStatusAsync(false, cancellationToken).EnsureCompleted();

        /// <inheritdoc/>
        public override async ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) =>
            await UpdateStatusAsync(true, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Calls the server to get updated status of the long-running operation.
        /// </summary>
        /// <param name="async">When <c>true</c>, the method will be executed asynchronously; otherwise, it will execute synchronously.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The HTTP response from the service.</returns>
        private async ValueTask<Response> UpdateStatusAsync(bool async, CancellationToken cancellationToken)
        {
            if (!_hasCompleted)
            {
                Response<AnalyzeOperationResult_internal> update = async
                    ? await _serviceClient.GetAnalyzeReceiptResultAsync(new Guid(Id), cancellationToken).ConfigureAwait(false)
                    : _serviceClient.GetAnalyzeReceiptResult(new Guid(Id), cancellationToken);

                if (update.Value.Status == OperationStatus.Succeeded || update.Value.Status == OperationStatus.Failed)
                {
                    _hasCompleted = true;

                    // TODO: When they support extracting more than one receipt, add a pageable method for this.
                    // https://github.com/Azure/azure-sdk-for-net/issues/10389

                    //_value = ConvertToRecognizedReceipts(update.Value.AnalyzeResult.DocumentResults.ToList(), update.Value.AnalyzeResult.ReadResults.ToList());
                    _value = ConvertToRecognizedReceipts(update.Value.AnalyzeResult);
                }

                _response = update.GetRawResponse();
            }

            return GetRawResponse();
        }

        private static IReadOnlyList<RecognizedReceipt> ConvertToRecognizedReceipts(AnalyzeResult_internal analyzeResult)
        {
            List<RecognizedReceipt> receipts = new List<RecognizedReceipt>();
            for (int i = 0; i < analyzeResult.DocumentResults.Count; i++)
            {
                receipts.Add(new RecognizedReceipt(analyzeResult.DocumentResults[i], analyzeResult.PageResults, analyzeResult.ReadResults));
            }
            return receipts;
        }
    }
}
