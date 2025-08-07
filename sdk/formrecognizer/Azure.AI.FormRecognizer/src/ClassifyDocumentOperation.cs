// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    /// <summary>
    /// Tracks the status of a long-running operation for classifying documents.
    /// </summary>
    public class ClassifyDocumentOperation : Operation<AnalyzeResult>, IOperation<AnalyzeResult>
    {
        private readonly OperationInternal<AnalyzeResult> _operationInternal;

        /// <summary>Provides communication with the Form Recognizer Azure Cognitive Service through its REST API.</summary>
        private readonly DocumentAnalysisRestClient _serviceClient;

        /// <summary>Provides tools for exception creation in case of failure.</summary>
        private readonly ClientDiagnostics _diagnostics;

        /// <summary>The ID of the classifier to use for classifying documents.</summary>
        private readonly string _classifierId;

        /// <summary>An ID representing the operation that can be used along with <see cref="_classifierId"/> to poll for the status of the long-running operation.</summary>
        private readonly string _resultId;

        /// <summary>
        /// Gets an ID representing the operation that can be used to poll for the status
        /// of the long-running operation.
        /// </summary>
        public override string Id { get; }

        /// <summary>
        /// Final result of the long-running operation.
        /// </summary>
        /// <remarks>
        /// This property can be accessed only after the operation completes successfully (HasValue is true).
        /// </remarks>
        public override AnalyzeResult Value => _operationInternal.Value;

        /// <summary>
        /// Returns true if the long-running operation completed.
        /// </summary>
        public override bool HasCompleted => _operationInternal.HasCompleted;

        /// <summary>
        /// Returns true if the long-running operation completed successfully and has produced final result (accessible by Value property).
        /// </summary>
        public override bool HasValue => _operationInternal.HasValue;

        /// <summary>
        /// The last HTTP response received from the server.
        /// </summary>
        /// <remarks>
        /// The last response returned from the server during the lifecycle of this instance.
        /// An instance of <see cref="ClassifyDocumentOperation"/> sends requests to a server in UpdateStatusAsync, UpdateStatus, and other methods.
        /// Responses from these requests can be accessed using GetRawResponse.
        /// </remarks>
        public override Response GetRawResponse() => _operationInternal.RawResponse;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClassifyDocumentOperation"/> class which
        /// tracks the status of a long-running operation for classifying documents.
        /// </summary>
        /// <param name="operationId">The ID of this operation.</param>
        /// <param name="client">The client used to check for completion.</param>
        public ClassifyDocumentOperation(string operationId, DocumentAnalysisClient client)
        {
            Argument.AssertNotNullOrEmpty(operationId, nameof(operationId));
            Argument.AssertNotNull(client, nameof(client));

            _serviceClient = client.ServiceClient;
            _diagnostics = client.Diagnostics;
            _operationInternal = new(this, _diagnostics, rawResponse: null);

            string[] substrs = operationId.Split('/');

            if (substrs.Length < 3)
            {
                throw new ArgumentException($"Invalid '{nameof(operationId)}'. It should be formatted as: '{{classifierId}}/analyzeresults/{{resultId}}'.", nameof(operationId));
            }

            _resultId = substrs.Last();
            _classifierId = substrs.First();

            Id = operationId;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClassifyDocumentOperation"/> class.
        /// </summary>
        /// <param name="serviceClient">The client for communicating with the Form Recognizer Azure Cognitive Service through its REST API.</param>
        /// <param name="diagnostics">The client diagnostics for exception creation in case of failure.</param>
        /// <param name="operationLocation">The address of the long-running operation. It can be obtained from the response headers upon starting the operation.</param>
        /// <param name="postResponse">Response from the POST request that initiated the operation.</param>
        internal ClassifyDocumentOperation(DocumentAnalysisRestClient serviceClient, ClientDiagnostics diagnostics, string operationLocation, Response postResponse)
        {
            _serviceClient = serviceClient;
            _diagnostics = diagnostics;
            _operationInternal = new(this, _diagnostics, rawResponse: postResponse);

            string[] substrs = operationLocation.Split('/', '?');

            _resultId = substrs[substrs.Length - 2];
            _classifierId = substrs[substrs.Length - 4];

            Id = string.Join("/", substrs, substrs.Length - 4, 3);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClassifyDocumentOperation"/> class. This constructor
        /// is intended to be used for mocking only.
        /// </summary>
        protected ClassifyDocumentOperation()
        {
        }

        /// <summary>
        /// Periodically calls the server till the long-running operation completes.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> used for the periodical service calls.</param>
        /// <returns>The last HTTP response received from the server.</returns>
        /// <remarks>
        /// This method will periodically call UpdateStatusAsync till HasCompleted is true, then return the final result of the operation.
        /// </remarks>
        public override async ValueTask<Response<AnalyzeResult>> WaitForCompletionAsync(CancellationToken cancellationToken = default) =>
            await _operationInternal.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Periodically calls the server till the long-running operation completes.
        /// </summary>
        /// <param name="pollingInterval">
        /// The interval between status requests to the server.
        /// The interval can change based on information returned from the server.
        /// For example, the server might communicate to the client that there is not reason to poll for status change sooner than some time.
        /// </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> used for the periodical service calls.</param>
        /// <returns>The last HTTP response received from the server.</returns>
        /// <remarks>
        /// This method will periodically call UpdateStatusAsync till HasCompleted is true, then return the final result of the operation.
        /// </remarks>
        public override async ValueTask<Response<AnalyzeResult>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) =>
            await _operationInternal.WaitForCompletionAsync(pollingInterval, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Calls the server to get updated status of the long-running operation.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> used for the service call.</param>
        /// <returns>The HTTP response received from the server.</returns>
        /// <remarks>
        /// This operation will update the value returned from GetRawResponse and might update HasCompleted, HasValue, and Value.
        /// </remarks>
        public override Response UpdateStatus(CancellationToken cancellationToken = default) =>
            _operationInternal.UpdateStatus(cancellationToken);

        /// <summary>
        /// Calls the server to get updated status of the long-running operation.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> used for the service call.</param>
        /// <returns>The HTTP response received from the server.</returns>
        /// <remarks>
        /// This operation will update the value returned from GetRawResponse and might update HasCompleted, HasValue, and Value.
        /// </remarks>
        public override async ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) =>
            await _operationInternal.UpdateStatusAsync(cancellationToken).ConfigureAwait(false);

        async ValueTask<OperationState<AnalyzeResult>> IOperation<AnalyzeResult>.UpdateStateAsync(bool async, CancellationToken cancellationToken)
        {
            Response<AnalyzeResultOperation> response = async
                ? await _serviceClient.DocumentClassifiersGetClassifyResultAsync(_classifierId, _resultId, cancellationToken).ConfigureAwait(false)
                : _serviceClient.DocumentClassifiersGetClassifyResult(_classifierId, _resultId, cancellationToken);

            AnalyzeResultOperationStatus status = response.Value.Status;
            Response rawResponse = response.GetRawResponse();

            if (status == AnalyzeResultOperationStatus.Succeeded)
            {
                return OperationState<AnalyzeResult>.Success(rawResponse,
                    response.Value.AnalyzeResult);
            }
            else if (status == AnalyzeResultOperationStatus.Failed)
            {
                RequestFailedException requestFailedException = ClientCommon.CreateExceptionForFailedOperation(rawResponse, response.Value.Error);

                return OperationState<AnalyzeResult>.Failure(rawResponse, requestFailedException);
            }

            return OperationState<AnalyzeResult>.Pending(rawResponse);
        }

        // This method is never invoked since we don't override Operation<T>.GetRehydrationToken.
        RehydrationToken IOperation<AnalyzeResult>.GetRehydrationToken() =>
            throw new NotSupportedException($"{nameof(GetRehydrationToken)} is not supported.");
    }
}
