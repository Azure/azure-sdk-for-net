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
    /// Tracks the status of a long-running operation for copying a custom model into a target Form Recognizer resource.
    /// </summary>
    public class CopyModelOperation : Operation<CustomFormModelInfo>
    {
        /// <summary>Provides communication with the Form Recognizer Azure Cognitive Service through its REST API.</summary>
        private readonly ServiceRestClient _serviceClient;

        /// <summary>Provides tools for exception creation in case of failure.</summary>
        private readonly ClientDiagnostics _diagnostics;

        /// <summary>The last HTTP response received from the server. <c>null</c> until the first response is received.</summary>
        private Response _response;

        /// <summary>The result of the long-running operation. <c>null</c> until result is received on status update.</summary>
        private CustomFormModelInfo _value;

        /// <summary><c>true</c> if the long-running operation has completed. Otherwise, <c>false</c>.</summary>
        private bool _hasCompleted;

        /// <summary>The id of the model to use for copy.</summary>
        private readonly string _modelId;

        /// <summary>The id of the copied model.</summary>
        private readonly string _targetModelId;

        /// <summary>An ID representing the operation that can be used along with <see cref="_modelId"/> to poll for the status of the long-running operation.</summary>
        private readonly string _resultId;

        /// <inheritdoc/>
        public override string Id { get; }

        /// <inheritdoc/>
        public override CustomFormModelInfo Value
        {
            get
            {
                if (HasCompleted && !HasValue)
#pragma warning disable CA1065 // Do not raise exceptions in unexpected locations
                    throw new InvalidOperationException("Copy model operation failed");
#pragma warning restore CA1065 // Do not raise exceptions in unexpected locations
                else
                    return OperationHelpers.GetValue(ref _value);
            }
        }

        /// <inheritdoc/>
        public override bool HasCompleted => _hasCompleted;

        /// <inheritdoc/>
        public override bool HasValue => _value != null;

        /// <summary>
        /// Initializes a new instance of the <see cref="CopyModelOperation"/> class.
        /// </summary>
        /// <param name="operationId">The ID of this operation.</param>
        /// <param name="client">The client used to check for completion.</param>
        /// /// <param name="targetModelId">Model id in the target Form Recognizer Resource.</param>
        public CopyModelOperation(string operationId, string targetModelId, FormTrainingClient client)
        {
            _serviceClient = client.ServiceClient;
            _diagnostics = client.Diagnostics;
            _targetModelId = targetModelId;

            // TODO: Use regex to parse ids.
            // https://github.com/Azure/azure-sdk-for-net/issues/11505

            // TODO: Add validation here (should we store _resuldId and _modelId as GUIDs?)
            // https://github.com/Azure/azure-sdk-for-net/issues/10385

            string[] substrs = operationId.Split('/');

            if (substrs.Length < 3)
            {
                throw new ArgumentException($"Invalid {operationId}. It should be formatted as: '{{modelId}}/analyzeresults/{{resultId}}'.", operationId);
            }

            _resultId = substrs.Last();
            _modelId = substrs.First();

            Id = operationId;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CopyModelOperation"/> class.
        /// </summary>
        /// <param name="serviceClient">The client for communicating with the Form Recognizer Azure Cognitive Service through its REST API.</param>
        /// <param name="diagnostics">The client diagnostics for exception creation in case of failure.</param>
        /// <param name="operationLocation">The address of the long-running operation. It can be obtained from the response headers upon starting the operation.</param>
        /// <param name="targetModelId">Model id in the target Form Recognizer Resource.</param>
        internal CopyModelOperation(ServiceRestClient serviceClient, ClientDiagnostics diagnostics, string operationLocation, string targetModelId)
        {
            _serviceClient = serviceClient;
            _diagnostics = diagnostics;
            _targetModelId = targetModelId;

            // TODO: Use regex to parse ids.
            // https://github.com/Azure/azure-sdk-for-net/issues/11505

            // TODO: Add validation here (should we store _resuldId and _modelId as GUIDs?)
            // https://github.com/Azure/azure-sdk-for-net/issues/10385

            string[] substrs = operationLocation.Split('/');

            if (substrs.Length < 3)
            {
                throw new ArgumentException($"Invalid {operationLocation}. It should be formatted as: '{{modelId}}/analyzeresults/{{resultId}}'.", operationLocation);
            }

            _resultId = substrs[substrs.Length - 1];
            _modelId = substrs[substrs.Length - 3];

            Id = string.Join("/", substrs, substrs.Length - 3, 3);
        }

        /// <inheritdoc/>
        public override Response GetRawResponse() => _response;

        /// <inheritdoc/>
        public override ValueTask<Response<CustomFormModelInfo>> WaitForCompletionAsync(CancellationToken cancellationToken = default) =>
            this.DefaultWaitForCompletionAsync(cancellationToken);

        /// <inheritdoc/>
        public override ValueTask<Response<CustomFormModelInfo>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) =>
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
                Response<CopyOperationResult> update = async
                    ? await _serviceClient.GetCustomModelCopyResultAsync(new Guid(_modelId), new Guid(_resultId), cancellationToken).ConfigureAwait(false)
                    : _serviceClient.GetCustomModelCopyResult(new Guid(_modelId), new Guid(_resultId), cancellationToken);

                _response = update.GetRawResponse();

                if (update.Value.Status == OperationStatus.Succeeded)
                {
                    _hasCompleted = true;
                    _value = ConvertValue(update.Value, _targetModelId, CustomFormModelStatus.Ready);
                }
                else if (update.Value.Status == OperationStatus.Failed)
                {
                    _hasCompleted = true;

                    throw await CreateExceptionForFailedOperationAsync(async, update.Value.CopyResult.Errors).ConfigureAwait(false);
                }
            }

            return GetRawResponse();
        }

        private static CustomFormModelInfo ConvertValue(CopyOperationResult result, string modelId, CustomFormModelStatus status)
        {
            return new CustomFormModelInfo(
                modelId,
                result.CreatedDateTime,
                result.LastUpdatedDateTime,
                status);
        }

        private async ValueTask<RequestFailedException> CreateExceptionForFailedOperationAsync(bool async, IReadOnlyList<FormRecognizerError> errors)
        {
            string errorMessage = default;
            string errorCode = default;

            if (errors.Count > 0)
            {
                var firstError = errors[0];

                errorMessage = firstError.Message;
                errorCode = firstError.ErrorCode;
            }
            else
            {
                errorMessage = "Copy model operation failed.";
            }

            var errorInfo = new Dictionary<string, string>();
            int index = 0;

            foreach (var error in errors)
            {
                errorInfo.Add($"error-{index}", $"{error.ErrorCode}: {error.Message}");
                index++;
            }

            return async
                ? await _diagnostics.CreateRequestFailedExceptionAsync(_response, errorMessage, errorCode, errorInfo).ConfigureAwait(false)
                : _diagnostics.CreateRequestFailedException(_response, errorMessage, errorCode, errorInfo);
        }
    }
}
