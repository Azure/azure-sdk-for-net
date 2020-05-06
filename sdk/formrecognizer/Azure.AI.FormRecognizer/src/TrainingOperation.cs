// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.FormRecognizer.Training
{
    /// <summary>
    /// Tracks the status of a long-running operation for training a model from a collection of custom forms.
    /// </summary>
    public class TrainingOperation : Operation<CustomFormModel>
    {
        /// <summary>Provides communication with the Form Recognizer Azure Cognitive Service through its REST API.</summary>
        private readonly ServiceClient _serviceClient;

        /// <summary>The last HTTP response received from the server. <c>null</c> until the first response is received.</summary>
        private Response _response;

        /// <summary>The result of the long-running operation. <c>null</c> until result is received on status update.</summary>
        private CustomFormModel _value;

        /// <summary><c>true</c> if the long-running operation has completed. Otherwise, <c>false</c>.</summary>
        private bool _hasCompleted;

        /// <inheritdoc/>
        public override string Id { get; }

        /// <inheritdoc/>
        public override CustomFormModel Value => OperationHelpers.GetValue(ref _value);

        /// <inheritdoc/>
        public override bool HasCompleted => _hasCompleted;

        /// <inheritdoc/>
        public override bool HasValue => _value != null;
        // TODO: This will make the model available even if status is failed to train.
        // is it useful to make the value available if training has failed?
        // https://github.com/Azure/azure-sdk-for-net/issues/10392

        /// <inheritdoc/>
        public override Response GetRawResponse() => _response;

        /// <inheritdoc/>
        public override ValueTask<Response<CustomFormModel>> WaitForCompletionAsync(CancellationToken cancellationToken = default) =>
            this.DefaultWaitForCompletionAsync(cancellationToken);

        /// <inheritdoc/>
        public override ValueTask<Response<CustomFormModel>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) =>
            this.DefaultWaitForCompletionAsync(pollingInterval, cancellationToken);

        /// <summary>
        /// Initializes a new instance of the <see cref="TrainingOperation"/> class for mocking.
        /// </summary>
        protected TrainingOperation()
        {
        }

        internal TrainingOperation(string location, ServiceClient allOperations)
        {
            _serviceClient = allOperations;

            // TODO: validate this
            // https://github.com/Azure/azure-sdk-for-net/issues/10385
            Id = location.Split('/').Last();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TrainingOperation"/> class.
        /// </summary>
        /// <param name="operationId">The ID of this operation.</param>
        /// <param name="client">The client used to check for completion.</param>
        public TrainingOperation(string operationId, FormTrainingClient client)
        {
            Id = operationId;
            _serviceClient = client.ServiceClient;
        }

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
                // Include keys is always set to true -- the service does not have a use case for includeKeys: false.
                Response<Model_internal> update = async
                    ? await _serviceClient.GetCustomModelAsync(new Guid(Id), includeKeys: true, cancellationToken).ConfigureAwait(false)
                    : _serviceClient.GetCustomModel(new Guid(Id), includeKeys: true, cancellationToken);

                if (update.Value.ModelInfo.Status != CustomFormModelStatus.Training)
                {
                    _hasCompleted = true;
                    _value = new CustomFormModel(update.Value);
                }

                _response = update.GetRawResponse();
            }

            return GetRawResponse();
        }
    }
}
