﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
    /// Tracks the status of a long-running operation for composing a model.
    /// </summary>
    public class ComposeDocumentModelOperation : Operation<DocumentModelDetails>, IOperation<DocumentModelDetails>
    {
        private readonly OperationInternal<DocumentModelDetails> _operationInternal;

        /// <summary>Provides communication with the Form Recognizer Azure Cognitive Service through its REST API.</summary>
        private readonly DocumentAnalysisRestClient _serviceClient;

        /// <summary>Provides tools for exception creation in case of failure.</summary>
        private readonly ClientDiagnostics _diagnostics;

        /// <summary>Operation progress (0-100)</summary>
        private int? _percentCompleted;

        /// <summary>
        /// Gets operation Id that can be used to poll for the status
        /// of the long-running operation.
        /// </summary>
        public override string Id { get; }

        /// <summary>
        /// Gets the operation progress. Value is from [0-100].
        /// </summary>
        /// <remarks>
        /// This property can be accessed only after an update request. Make sure to call UpdateStatus first.
        /// </remarks>
        public virtual int PercentCompleted
        {
            get
            {
                if (_percentCompleted.HasValue)
                {
                    return _percentCompleted.Value;
                }

                throw new InvalidOperationException("The operation has not done an update request yet. Make sure to call UpdateStatus first.");
            }
        }

        /// <summary>
        /// Final result of the long-running operation.
        /// </summary>
        /// <remarks>
        /// This property can be accessed only after the operation completes successfully (HasValue is true).
        /// </remarks>
        public override DocumentModelDetails Value => _operationInternal.Value;

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
        /// An instance of <see cref="ComposeDocumentModelOperation"/> sends requests to a server in UpdateStatusAsync, UpdateStatus, and other methods.
        /// Responses from these requests can be accessed using GetRawResponse.
        /// </remarks>
        public override Response GetRawResponse() => _operationInternal.RawResponse;

        /// <summary>
        /// Periodically calls the server till the long-running operation completes.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> used for the periodical service calls.</param>
        /// <returns>The last HTTP response received from the server.</returns>
        /// <remarks>
        /// This method will periodically call UpdateStatusAsync till HasCompleted is true, then return the final result of the operation.
        /// </remarks>
        public override async ValueTask<Response<DocumentModelDetails>> WaitForCompletionAsync(CancellationToken cancellationToken = default) =>
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
        public override async ValueTask<Response<DocumentModelDetails>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) =>
            await _operationInternal.WaitForCompletionAsync(pollingInterval, cancellationToken).ConfigureAwait(false);

        internal ComposeDocumentModelOperation(
            string location,
            Response postResponse,
            DocumentAnalysisRestClient allOperations,
            ClientDiagnostics diagnostics)
        {
            _serviceClient = allOperations;
            _diagnostics = diagnostics;
            _operationInternal = new(this, _diagnostics, rawResponse: postResponse);

            Id = location.Split('/').Last().Split('?').FirstOrDefault();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ComposeDocumentModelOperation"/> class which
        /// tracks the status of a long-running operation for composing a custom model.
        /// </summary>
        /// <param name="operationId">The ID of this operation.</param>
        /// <param name="client">The client used to check for completion.</param>
        public ComposeDocumentModelOperation(string operationId, DocumentModelAdministrationClient client)
        {
            Argument.AssertNotNull(client, nameof(client));

            Id = operationId;
            _diagnostics = client.Diagnostics;
            _serviceClient = client.ServiceClient;
            _operationInternal = new(this, _diagnostics, rawResponse: null, nameof(ComposeDocumentModelOperation));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ComposeDocumentModelOperation"/> class. This constructor
        /// is intended to be used for mocking only.
        /// </summary>
        protected ComposeDocumentModelOperation()
        {
        }

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

        async ValueTask<OperationState<DocumentModelDetails>> IOperation<DocumentModelDetails>.UpdateStateAsync(bool async, CancellationToken cancellationToken)
        {
            Response<OperationDetails> response = async
                ? await _serviceClient.MiscellaneousGetOperationAsync(Id, cancellationToken).ConfigureAwait(false)
                : _serviceClient.MiscellaneousGetOperation(Id, cancellationToken);

            DocumentOperationStatus status = response.Value.Status;
            Response rawResponse = response.GetRawResponse();
            _percentCompleted = response.Value.PercentCompleted ?? 0;

            if (status == DocumentOperationStatus.Succeeded)
            {
                var composeOperation = response.Value as DocumentModelComposeOperationDetails;
                return OperationState<DocumentModelDetails>.Success(rawResponse, composeOperation.Result);
            }
            else if (status == DocumentOperationStatus.Failed)
            {
                RequestFailedException requestFailedException = ClientCommon.CreateExceptionForFailedOperation(rawResponse, response.Value.Error);

                return OperationState<DocumentModelDetails>.Failure(rawResponse, requestFailedException);
            }
            else if (status == DocumentOperationStatus.Canceled)
            {
                return OperationState<DocumentModelDetails>.Failure(rawResponse, new RequestFailedException("The operation was canceled so no value is available."));
            }

            return OperationState<DocumentModelDetails>.Pending(rawResponse);
        }
    }
}
