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

namespace Azure.AI.FormRecognizer.Training
{
    /// <summary>
    /// Tracks the status of a long-running operation for training a model from a collection of custom forms.
    /// </summary>
    public class TrainingOperation : Operation<CustomFormModel>
    {
        /// <summary>Provides communication with the Form Recognizer Azure Cognitive Service through its REST API.</summary>
        private readonly ServiceRestClient _serviceClient;

        /// <summary>Provides tools for exception creation in case of failure.</summary>
        private readonly ClientDiagnostics _diagnostics;

        /// <summary>The id of the model created.</summary>
        private Guid _modelId;

        /// <summary>The last HTTP response received from the server. <c>null</c> until the first response is received.</summary>
        private Response _response;

        /// <summary>The result of the long-running operation. <c>null</c> until result is received on status update.</summary>
        private CustomFormModel _value;

        /// <summary><c>true</c> if the long-running operation has completed. Otherwise, <c>false</c>.</summary>
        private bool _hasCompleted;

        /// <inheritdoc/>
        public override string Id { get; }

        /// <inheritdoc/>
        public override CustomFormModel Value
        {
            get
            {
                if (HasCompleted && !HasValue)
#pragma warning disable CA1065 // Do not raise exceptions in unexpected locations
                    throw new InvalidOperationException($"Invalid model created with ID {_modelId}.");
#pragma warning restore CA1065 // Do not raise exceptions in unexpected locations
                else
                    return OperationHelpers.GetValue(ref _value);
            }
        }

        /// <inheritdoc/>
        public override bool HasCompleted => _hasCompleted;

        /// <inheritdoc/>
        public override bool HasValue => _value != null;

        /// <inheritdoc/>
        public override Response GetRawResponse() => _response;

        /// <inheritdoc/>
        public override ValueTask<Response<CustomFormModel>> WaitForCompletionAsync(CancellationToken cancellationToken = default) =>
            this.DefaultWaitForCompletionAsync(cancellationToken);

        /// <inheritdoc/>
        public override ValueTask<Response<CustomFormModel>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) =>
            this.DefaultWaitForCompletionAsync(pollingInterval, cancellationToken);

        internal TrainingOperation(string location, ServiceRestClient allOperations, ClientDiagnostics diagnostics)
        {
            _serviceClient = allOperations;
            _diagnostics = diagnostics;

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
            _diagnostics = client.Diagnostics;
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

                _response = update.GetRawResponse();

                if (update.Value.ModelInfo.Status == CustomFormModelStatus.Ready)
                {
                    _hasCompleted = true;
                    _value = new CustomFormModel(update.Value);
                }
                else if (update.Value.ModelInfo.Status == CustomFormModelStatus.Invalid)
                {
                    _hasCompleted = true;
                    _modelId = update.Value.ModelInfo.ModelId;

                    throw await CreateExceptionForFailedOperationAsync(async, update.Value.TrainResult.Errors).ConfigureAwait(false);
                }
            }

            return GetRawResponse();
        }

        private async ValueTask<RequestFailedException> CreateExceptionForFailedOperationAsync(bool async, IReadOnlyList<FormRecognizerError> errors)
        {
            string errorMessage = $"Invalid model created with ID {_modelId}";

            var errorInfo = new Dictionary<string, string>();
            int index = 0;

            foreach (var error in errors)
            {
                errorInfo.Add($"error-{index}", $"{error.ErrorCode}: {error.Message}");
                index++;
            }

            return async
                ? await _diagnostics.CreateRequestFailedExceptionAsync(_response, errorMessage, additionalInfo:errorInfo).ConfigureAwait(false)
                : _diagnostics.CreateRequestFailedException(_response, errorMessage, additionalInfo:errorInfo);
        }
    }
}
