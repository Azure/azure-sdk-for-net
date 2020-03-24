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
    public class RecognizeBusinessCardOperation : Operation<IReadOnlyList<BusinessCard>>
    {
        private Response _response;
        private IReadOnlyList<BusinessCard> _value;
        private bool _hasCompleted;

        private readonly ServiceClient _operations;

        /// <inheritdoc/>
        public override string Id { get; }

        /// <inheritdoc/>
        public override IReadOnlyList<BusinessCard> Value => OperationHelpers.GetValue(ref _value);

        /// <inheritdoc/>
        public override bool HasCompleted => _hasCompleted;

        /// <inheritdoc/>
        public override bool HasValue => _value != null;

        /// <inheritdoc/>
        public override Response GetRawResponse() => _response;

        /// <inheritdoc/>
        public override ValueTask<Response<IReadOnlyList<BusinessCard>>> WaitForCompletionAsync(CancellationToken cancellationToken = default) =>
            this.DefaultWaitForCompletionAsync(cancellationToken);

        /// <inheritdoc/>
        public override ValueTask<Response<IReadOnlyList<BusinessCard>>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) =>
            this.DefaultWaitForCompletionAsync(pollingInterval, cancellationToken);

        internal RecognizeBusinessCardOperation(ServiceClient operations, string operationLocation)
        {
            _operations = operations;

            // TODO: Add validation here
            // https://github.com/Azure/azure-sdk-for-net/issues/10385
            Id = operationLocation.Split('/').Last();
        }

        /// <inheritdoc/>
        public override Response UpdateStatus(CancellationToken cancellationToken = default) =>
            UpdateStatusAsync(false, cancellationToken).EnsureCompleted();

        /// <inheritdoc/>
        public override async ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) =>
            await UpdateStatusAsync(true, cancellationToken).ConfigureAwait(false);

        private async ValueTask<Response> UpdateStatusAsync(bool async, CancellationToken cancellationToken)
        {
            // TODO: Implement once Business Cards are supported by service.
            //if (async)
            //{
            //    await Task.Run(() => { }).ConfigureAwait(false);
            //}

            //throw new NotImplementedException();

            if (!_hasCompleted)
            {
                Response<AnalyzeOperationResult_internal> update = async
                    ? await _operations.GetAnalyzeReceiptResultAsync(new Guid(Id), cancellationToken).ConfigureAwait(false)
                    : _operations.GetAnalyzeReceiptResult(new Guid(Id), cancellationToken);

                // TODO: Handle correctly according to returned status code
                // https://github.com/Azure/azure-sdk-for-net/issues/10386

                if (update.Value.Status == OperationStatus.Succeeded || update.Value.Status == OperationStatus.Failed)
                {
                    _hasCompleted = true;
                    _value = ConvertToExtractedReceipts(update.Value.AnalyzeResult.DocumentResults);
                }

                _response = update.GetRawResponse();
            }

            return GetRawResponse();

        }


        private static IReadOnlyList<BusinessCard> ConvertToExtractedReceipts(IList<DocumentResult_internal> documentResults)
        {
            List<BusinessCard> receipts = new List<BusinessCard>();
            for (int i = 0; i < documentResults.Count; i++)
            {
                receipts.Add(new BusinessCard());
            }
            return receipts;
        }
    }
}
