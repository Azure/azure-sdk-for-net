// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using System.Linq;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// </summary>
    public class ExtractFormOperation : Operation<AnalyzeResult>
    {
        private Response _response;
        private AnalyzeResult _value;
        private bool _hasCompleted;

        private readonly string _modelId;
        private readonly AllOperations _operations;

        public override string Id { get; }

        public override AnalyzeResult Value => OperationHelpers.GetValue(ref _value);

        public override bool HasCompleted => _hasCompleted;

        public override bool HasValue => _value != null;

        /// <inheritdoc/>
        public override Response GetRawResponse() => _response;

        /// <inheritdoc/>
        public override ValueTask<Response<AnalyzeResult>> WaitForCompletionAsync(CancellationToken cancellationToken = default) =>
            this.DefaultWaitForCompletionAsync(cancellationToken);

        /// <inheritdoc/>
        public override ValueTask<Response<AnalyzeResult>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) =>
            this.DefaultWaitForCompletionAsync(pollingInterval, cancellationToken);

        /// <summary>
        /// </summary>
        /// <param name="operations"></param>
        /// <param name="modelId"></param>
        /// <param name="operationLocation"></param>
        internal ExtractFormOperation(AllOperations operations, string modelId, string operationLocation)
        {
            _operations = operations;
            _modelId = modelId;

            // TODO: Add validation here?
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
                Response<AnalyzeOperationResult> update = async
                    ? await _operations.GetAnalyzeFormResultAsync(new Guid(_modelId), new Guid(Id), cancellationToken).ConfigureAwait(false)
                    : _operations.GetAnalyzeFormResult(new Guid(_modelId), new Guid(Id), cancellationToken);

                // TODO: check status code?  What if a failure status code is returned?

                if (update.Value.Status == OperationStatus.Succeeded || update.Value.Status == OperationStatus.Failed)
                {
                    _hasCompleted = true;
                    _value = update.Value.AnalyzeResult;
                }

                _response = update.GetRawResponse();
            }

            return GetRawResponse();
        }
    }
}
