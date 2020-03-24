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
    public class RecognizeLabeledFormOperation : Operation<IReadOnlyList<CustomLabeledForm>>
    {
        private Response _response;
        private IReadOnlyList<CustomLabeledForm> _value;
        private bool _hasCompleted;

        private readonly string _modelId;
        private readonly ServiceClient _serviceClient;

        // TODO: use this.
        private CancellationToken _cancellationToken;

        /// <inheritdoc/>
        public override string Id { get; }

        /// <inheritdoc/>
        public override IReadOnlyList<CustomLabeledForm> Value => OperationHelpers.GetValue(ref _value);

        /// <inheritdoc/>
        public override bool HasCompleted => _hasCompleted;

        /// <inheritdoc/>
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
            _serviceClient = operations;
            _modelId = modelId;

            // TODO: Add validation here
            // https://github.com/Azure/azure-sdk-for-net/issues/10385
            Id = operationLocation.Split('/').Last();
        }

        /// <summary>
        /// Initializes a new <see cref="RecognizeLabeledFormOperation"/> instance.
        /// </summary>
        /// <param name="id">The ID of this operation.</param>
        /// <param name="client">The client used to check for completion.</param>
        /// <param name="cancellationToken"></param>
        public RecognizeLabeledFormOperation(string id, FormRecognizerClient client, CancellationToken cancellationToken = default)
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
                    ? await _serviceClient.GetAnalyzeFormResultAsync(new Guid(_modelId), new Guid(Id), cancellationToken).ConfigureAwait(false)
                    : _serviceClient.GetAnalyzeFormResult(new Guid(_modelId), new Guid(Id), cancellationToken);

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
