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
    /// Tracks the status of a long-running operation for recognizing fields and other content from forms by using custom
    /// trained models.
    /// </summary>
    public class RecognizeCustomFormsOperation : Operation<IReadOnlyList<RecognizedForm>>
    {
        /// <summary>Provides communication with the Form Recognizer Azure Cognitive Service through its REST API.</summary>
        private readonly ServiceClient _serviceClient;

        /// <summary>Provides tools for exception creation in case of failure.</summary>
        private readonly ClientDiagnostics _diagnostics;

        /// <summary>The last HTTP response received from the server. <c>null</c> until the first response is received.</summary>
        private Response _response;

        /// <summary>The result of the long-running operation. <c>null</c> until result is received on status update.</summary>
        private IReadOnlyList<RecognizedForm> _value;

        /// <summary><c>true</c> if the long-running operation has completed. Otherwise, <c>false</c>.</summary>
        private bool _hasCompleted;

        /// <summary>The id of the model to use for recognizing form values.</summary>
        private readonly string _modelId;

        /// <summary>An ID representing the operation that can be used along with <see cref="_modelId"/> to poll for the status of the long-running operation.</summary>
        private readonly string _resultId;

        /// <inheritdoc/>
        public override string Id { get; }

        /// <inheritdoc/>
        public override IReadOnlyList<RecognizedForm> Value => OperationHelpers.GetValue(ref _value);

        /// <inheritdoc/>
        public override bool HasCompleted => _hasCompleted;

        /// <inheritdoc/>
        public override bool HasValue => _value != null;

        /// <inheritdoc/>
        public override Response GetRawResponse() => _response;

        /// <inheritdoc/>
        public override ValueTask<Response<IReadOnlyList<RecognizedForm>>> WaitForCompletionAsync(CancellationToken cancellationToken = default) =>
            this.DefaultWaitForCompletionAsync(cancellationToken);

        /// <inheritdoc/>
        public override ValueTask<Response<IReadOnlyList<RecognizedForm>>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) =>
            this.DefaultWaitForCompletionAsync(pollingInterval, cancellationToken);

        /// <summary>
        /// </summary>
        /// <param name="operations"></param>
        /// <param name="diagnostics"></param>
        /// <param name="operationLocation"></param>
        internal RecognizeCustomFormsOperation(ServiceClient operations, ClientDiagnostics diagnostics, string operationLocation)
        {
            _serviceClient = operations;
            _diagnostics = diagnostics;

            // TODO: Use regex to parse ids.
            // https://github.com/Azure/azure-sdk-for-net/issues/11505

            // TODO: Add validation here (should we store _resuldId and _modelId as GUIDs?)
            // https://github.com/Azure/azure-sdk-for-net/issues/10385

            string[] substrs = operationLocation.Split('/');

            _resultId = substrs[substrs.Length - 1];
            _modelId = substrs[substrs.Length - 3];

            Id = string.Join("/", substrs, substrs.Length - 3, 3);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RecognizeCustomFormsOperation"/> class.
        /// </summary>
        /// <param name="operationId">The ID of this operation.</param>
        /// <param name="client">The client used to check for completion.</param>
        public RecognizeCustomFormsOperation(string operationId, FormRecognizerClient client)
        {
            _serviceClient = client.ServiceClient;
            _diagnostics = client.Diagnostics;

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
        /// Initializes a new instance of the <see cref="RecognizeCustomFormsOperation"/> class.
        /// </summary>
        protected RecognizeCustomFormsOperation()
        {
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
                Response<AnalyzeOperationResult_internal> update = async
                    ? await _serviceClient.GetAnalyzeFormResultAsync(new Guid(_modelId), new Guid(_resultId), cancellationToken).ConfigureAwait(false)
                    : _serviceClient.GetAnalyzeFormResult(new Guid(_modelId), new Guid(_resultId), cancellationToken);

                // TODO: Add reasonable null checks.

                _response = update.GetRawResponse();

                if (update.Value.Status == OperationStatus.Succeeded)
                {
                    _hasCompleted = true;
                    _value = ConvertToRecognizedForms(update.Value.AnalyzeResult);
                }
                else if (update.Value.Status == OperationStatus.Failed)
                {
                    _hasCompleted = true;
                    _value = new List<RecognizedForm>();

                    throw await CreateExceptionForFailedOperationAsync(async, update.Value.AnalyzeResult.Errors).ConfigureAwait(false);
                }
            }

            return GetRawResponse();
        }

        private static IReadOnlyList<RecognizedForm> ConvertToRecognizedForms(AnalyzeResult_internal analyzeResult)
        {
            return analyzeResult.DocumentResults?.Count == 0 ?
                ConvertUnsupervisedResult(analyzeResult) :
                ConvertSupervisedResult(analyzeResult);
        }

        private static IReadOnlyList<RecognizedForm> ConvertUnsupervisedResult(AnalyzeResult_internal analyzeResult)
        {
            List<RecognizedForm> forms = new List<RecognizedForm>();
            foreach (var pageResult in analyzeResult.PageResults)
            {
                forms.Add(new RecognizedForm(pageResult, analyzeResult.ReadResults));
            }
            return forms;
        }

        private static IReadOnlyList<RecognizedForm> ConvertSupervisedResult(AnalyzeResult_internal analyzeResult)
        {
            List<RecognizedForm> forms = new List<RecognizedForm>();
            foreach (var documentResult in analyzeResult.DocumentResults)
            {
                forms.Add(new RecognizedForm(documentResult, analyzeResult.PageResults, analyzeResult.ReadResults));
            }
            return forms;
        }

        private async ValueTask<RequestFailedException> CreateExceptionForFailedOperationAsync(bool async, IReadOnlyList<FormRecognizerError> errors)
        {
            string errorMessage = default;
            string errorCode = default;

            if (errors.Count > 0)
            {
                var firstError = errors[0];

                errorMessage = firstError.Message;
                errorCode = firstError.Code;
            }
            else
            {
                errorMessage = "RecognizeCustomForms operation failed.";
            }

            var errorInfo = new Dictionary<string, string>();
            int index = 0;

            foreach (var error in errors)
            {
                errorInfo.Add($"error-{index}", $"{error.Code}: {error.Message}");
                index++;
            }

            return async
                ? await _diagnostics.CreateRequestFailedExceptionAsync(_response, errorMessage, errorCode, errorInfo).ConfigureAwait(false)
                : _diagnostics.CreateRequestFailedException(_response, errorMessage, errorCode, errorInfo);
        }
    }
}
