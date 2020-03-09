// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// </summary>
    internal class ExtractFormOperation : Operation<ExtractedForm>
    {
        private Response _response;
        private ExtractedForm _value;
        private bool _hasCompleted;

        private readonly string _modelId;
        private readonly ServiceClient _operations;

        public override string Id { get; }

        public override ExtractedForm Value => OperationHelpers.GetValue(ref _value);

        public override bool HasCompleted => _hasCompleted;

        public override bool HasValue => _value != null;

        /// <inheritdoc/>
        public override Response GetRawResponse() => _response;

        /// <inheritdoc/>
        public override ValueTask<Response<ExtractedForm>> WaitForCompletionAsync(CancellationToken cancellationToken = default) =>
            this.DefaultWaitForCompletionAsync(cancellationToken);

        /// <inheritdoc/>
        public override ValueTask<Response<ExtractedForm>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) =>
            this.DefaultWaitForCompletionAsync(pollingInterval, cancellationToken);

        /// <summary>
        /// </summary>
        /// <param name="operations"></param>
        /// <param name="modelId"></param>
        /// <param name="operationLocation"></param>
        internal ExtractFormOperation(ServiceClient operations, string modelId, string operationLocation)
        {
            _operations = operations;
            _modelId = modelId;

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

        private async Task<Response> UpdateStatusAsync(bool async, CancellationToken cancellationToken)
        {
            if (!_hasCompleted)
            {
                Response<AnalyzeOperationResult_internal> update = async
                    ? await _operations.GetAnalyzeFormResultAsync(new Guid(_modelId), new Guid(Id), cancellationToken).ConfigureAwait(false)
                    : _operations.GetAnalyzeFormResult(new Guid(_modelId), new Guid(Id), cancellationToken);

                // TODO: Handle correctly according to returned status code
                // https://github.com/Azure/azure-sdk-for-net/issues/10386
                // TODO: Add reasonable null checks.

                if (update.Value.Status == OperationStatus.Succeeded || update.Value.Status == OperationStatus.Failed)
                {
                    _hasCompleted = true;

                    // TODO: Move this logic into ExtractedForm?  It's a bit convoluted right now.
                    // Determine if the model was supervised or unsupervised
                    if (update.Value.AnalyzeResult.DocumentResults?.Count == 0)
                    {
                        // Unsupervised
                        _value = new ExtractedForm(update.Value.AnalyzeResult.PageResults, update.Value.AnalyzeResult.ReadResults);
                    }
                    else
                    {
                        // TODO: Consider what we'll do when there are multiple DocumentResults
                        // https://github.com/Azure/azure-sdk-for-net/issues/10387
                        // Supervised
                        _value = new ExtractedForm(update.Value.AnalyzeResult.DocumentResults.First(), update.Value.AnalyzeResult.PageResults, update.Value.AnalyzeResult.ReadResults);
                    }
                }

                _response = update.GetRawResponse();
            }

            return GetRawResponse();
        }
    }
}
