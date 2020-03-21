// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Models;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.FormRecognizer
{
    /// <summary>
    /// </summary>
    internal class RecognizeLabeledFormOperation : Operation<IReadOnlyList<CustomLabeledForm>>
    {
        private Response _response;
        private IReadOnlyList<CustomLabeledForm> _value;
        private bool _hasCompleted;

        private readonly string _modelId;
        private readonly ServiceClient _operations;

        public override string Id { get; }

        public override IReadOnlyList<CustomLabeledForm> Value => OperationHelpers.GetValue(ref _value);

        public override bool HasCompleted => _hasCompleted;

        public override bool HasValue => _value != null;

        /// <inheritdoc/>
        public override Response GetRawResponse() => _response;

        /// <inheritdoc/>
        public override ValueTask<Response<IReadOnlyList<CustomLabeledForm>>> WaitForCompletionAsync(CancellationToken cancellationToken = default) =>
            this.DefaultWaitForCompletionAsync(cancellationToken);

        /// <inheritdoc/>
        public override ValueTask<Response<IReadOnlyList<CustomLabeledForm>>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) =>
            this.DefaultWaitForCompletionAsync(pollingInterval, cancellationToken);

        /// <summary>
        /// </summary>
        /// <param name="operations"></param>
        /// <param name="modelId"></param>
        /// <param name="operationLocation"></param>
        internal RecognizeLabeledFormOperation(ServiceClient operations, string modelId, string operationLocation)
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

        private async ValueTask<Response> UpdateStatusAsync(bool async, CancellationToken cancellationToken)
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

                    // TODO: Consider what we'll do when there are multiple DocumentResults
                    // https://github.com/Azure/azure-sdk-for-net/issues/10387
                    // Supervised
                    _value = ConvertToExtractedLabeledForms(update.Value.AnalyzeResult.DocumentResults, update.Value.AnalyzeResult.PageResults, update.Value.AnalyzeResult.ReadResults);
                }

                _response = update.GetRawResponse();
            }

            return GetRawResponse();
        }

        private static IReadOnlyList<CustomLabeledForm> ConvertToExtractedLabeledForms(IList<DocumentResult_internal> documentResults, IList<PageResult_internal> pageResults, IList<ReadResult_internal> readResults)
        {
            List<CustomLabeledForm> forms = new List<CustomLabeledForm>();
            for (int i = 0; i < documentResults.Count; i++)
            {
                forms.Add(new CustomLabeledForm(documentResults[i], pageResults, readResults));
            }
            return forms;
        }
    }
}
