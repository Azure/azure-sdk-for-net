﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    /// <summary>
    /// Tracks the status of a long-running operation for building a custom model.
    /// </summary>
    public class BuildModelOperation : Operation<DocumentModel>, IOperation<DocumentModel>
    {
        private readonly OperationInternal<DocumentModel> _operationInternal;

        /// <summary>Provides communication with the Form Recognizer Azure Cognitive Service through its REST API.</summary>
        private readonly DocumentAnalysisRestClient _serviceClient;

        /// <summary>Provides tools for exception creation in case of failure.</summary>
        private readonly ClientDiagnostics _diagnostics;

        /// <summary>Operation progress (0-100)</summary>
        private int _percentCompleted;

        /// <summary>
        /// Gets operation Id that can be used to poll for the status
        /// of the long-running operation.
        /// </summary>
        public override string Id { get; }

        /// <summary>
        /// Gets the operation progress. Value is from [0-100].
        /// </summary>
        public virtual int PercentCompleted => _percentCompleted;

        /// <summary>
        /// Final result of the long-running operation.
        /// </summary>
        /// <remarks>
        /// This property can be accessed only after the operation completes successfully (HasValue is true).
        /// </remarks>
        public override DocumentModel Value => _operationInternal.Value;

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
        /// An instance of <see cref="BuildModelOperation"/> sends requests to a server in UpdateStatusAsync, UpdateStatus, and other methods.
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
        public override async ValueTask<Response<DocumentModel>> WaitForCompletionAsync(CancellationToken cancellationToken = default) =>
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
        public override async ValueTask<Response<DocumentModel>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) =>
            await _operationInternal.WaitForCompletionAsync(pollingInterval, cancellationToken).ConfigureAwait(false);

        internal BuildModelOperation(
            string location,
            Response postResponse,
            DocumentAnalysisRestClient allOperations,
            ClientDiagnostics diagnostics)
        {
            _serviceClient = allOperations;
            _diagnostics = diagnostics;
            _operationInternal = new(_diagnostics, this, rawResponse: postResponse);

            Id = location.Split('/').Last().Split('?').FirstOrDefault();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BuildModelOperation"/> class which
        /// tracks the status of a long-running operation for creating a custom model.
        /// </summary>
        /// <param name="operationId">The ID of this operation.</param>
        /// <param name="client">The client used to check for completion.</param>
        public BuildModelOperation(string operationId, DocumentModelAdministrationClient client)
        {
            Argument.AssertNotNull(client, nameof(client));

            Id = operationId;
            _diagnostics = client.Diagnostics;
            _serviceClient = client.ServiceClient;
            _operationInternal = new(_diagnostics, this, rawResponse: null, nameof(BuildModelOperation));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BuildModelOperation"/> class. This constructor
        /// is intended to be used for mocking only.
        /// </summary>
        protected BuildModelOperation()
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

        async ValueTask<OperationState<DocumentModel>> IOperation<DocumentModel>.UpdateStateAsync(bool async, CancellationToken cancellationToken)
        {
            Response<ModelOperation> response = async
                ? await _serviceClient.GetOperationAsync(Id, cancellationToken).ConfigureAwait(false)
                : _serviceClient.GetOperation(Id, cancellationToken);

            DocumentOperationStatus status = response.Value.Status;
            Response rawResponse = response.GetRawResponse();
            _percentCompleted = response.Value.PercentCompleted ?? 0;

            if (status == DocumentOperationStatus.Succeeded)
            {
                return OperationState<DocumentModel>.Success(rawResponse, response.Value.Result);
            }
            else if (status == DocumentOperationStatus.Failed)
            {
                RequestFailedException requestFailedException = await ClientCommon
                    .CreateExceptionForFailedOperationAsync(async, _diagnostics, rawResponse, response.Value.Error)
                    .ConfigureAwait(false);

                return OperationState<DocumentModel>.Failure(rawResponse, requestFailedException);
            }
            else if (status == DocumentOperationStatus.Canceled)
            {
                return OperationState<DocumentModel>.Failure(rawResponse, new RequestFailedException("The operation was canceled so no value is available."));
            }

            return OperationState<DocumentModel>.Pending(rawResponse);
        }
    }
}
