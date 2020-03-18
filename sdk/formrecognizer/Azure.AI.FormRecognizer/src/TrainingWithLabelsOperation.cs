// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Models;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.FormRecognizer.Custom
{
    internal class TrainingWithLabelsOperation : Operation<CustomLabeledModel>
    {
        private Response _response;
        private CustomLabeledModel _value;
        private bool _hasCompleted;
        private readonly ServiceClient _operations;

        /// <summary>
        /// Get the ID of the training operation. This value can be used to poll for the status of the training outcome.
        /// </summary>
        public override string Id { get; }

        /// <summary>
        /// The final result of the training operation, if the operation completed successfully.
        /// </summary>
        public override CustomLabeledModel Value => OperationHelpers.GetValue(ref _value);

        /// <summary>
        /// True if the training operation completed.
        /// </summary>
        public override bool HasCompleted => _hasCompleted;

        /// <summary>
        /// True if the training operation completed successfully.
        /// </summary>
        public override bool HasValue => _value != null;
        // TODO: This will make the model available even if status is failed to train.
        // is it useful to make the value available if training has failed?
        // https://github.com/Azure/azure-sdk-for-net/issues/10392

        /// <inheritdoc/>
        public override Response GetRawResponse() => _response;

        /// <inheritdoc/>
        public override ValueTask<Response<CustomLabeledModel>> WaitForCompletionAsync(CancellationToken cancellationToken = default) =>
            this.DefaultWaitForCompletionAsync(cancellationToken);

        /// <inheritdoc/>
        public override ValueTask<Response<CustomLabeledModel>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) =>
            this.DefaultWaitForCompletionAsync(pollingInterval, cancellationToken);

        /// <summary>
        /// Initializes a new instance of the <see cref="TrainingOperation"/> class for mocking.
        /// </summary>
        protected TrainingWithLabelsOperation()
        {
        }

        internal TrainingWithLabelsOperation(ServiceClient allOperations, string location)
        {
            _operations = allOperations;

            // TODO: validate this
            // https://github.com/Azure/azure-sdk-for-net/issues/10385
            Id = location.Split('/').Last();
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
                // Include keys is always set to true -- the service does not have a use case for includeKeys: false.
                Response<Model_internal> update = async
                    ? await _operations.GetCustomModelAsync(new Guid(Id), includeKeys: true, cancellationToken).ConfigureAwait(false)
                    : _operations.GetCustomModel(new Guid(Id), includeKeys: true, cancellationToken);

                // TODO: Handle correctly according to returned status code
                // https://github.com/Azure/azure-sdk-for-net/issues/10386
                if (update.Value.ModelInfo.Status != ModelStatus.Training)
                {
                    _hasCompleted = true;
                    _value = new CustomLabeledModel(update.Value);
                }

                _response = update.GetRawResponse();
            }

            return GetRawResponse();
        }
    }
}
