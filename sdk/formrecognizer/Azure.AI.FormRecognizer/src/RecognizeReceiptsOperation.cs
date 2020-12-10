// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// Tracks the status of a long-running operation for recognizing values from receipts.
    /// </summary>
    public class RecognizeReceiptsOperation : Operation<RecognizedFormCollection>
    {
        /// <summary>Provides communication with the Form Recognizer Azure Cognitive Service through its REST API.</summary>
        private readonly FormRecognizerRestClient _serviceClient;

        /// <summary>Provides tools for exception creation in case of failure.</summary>
        private readonly ClientDiagnostics _diagnostics;

        private RequestFailedException _requestFailedException;

        /// <summary>The last HTTP response received from the server. <c>null</c> until the first response is received.</summary>
        private Response _response;

        /// <summary>The result of the long-running operation. <c>null</c> until result is received on status update.</summary>
        private RecognizedFormCollection _value;

        /// <summary><c>true</c> if the long-running operation has completed. Otherwise, <c>false</c>.</summary>
        private bool _hasCompleted;

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
        public override RecognizedFormCollection Value
        {
            get
            {
                if (HasCompleted && !HasValue)
#pragma warning disable CA1065 // Do not raise exceptions in unexpected locations
                    throw _requestFailedException;
#pragma warning restore CA1065 // Do not raise exceptions in unexpected locations
                else
                    return OperationHelpers.GetValue(ref _value);
            }
        }

        /// <summary>
        /// Returns true if the long-running operation completed.
        /// </summary>
        public override bool HasCompleted => _hasCompleted;

        /// <summary>
        /// Returns true if the long-running operation completed successfully and has produced final result (accessible by Value property).
        /// </summary>
        public override bool HasValue => _value != null;

        /// <summary>
        /// The last HTTP response received from the server.
        /// </summary>
        /// <remarks>
        /// The last response returned from the server during the lifecycle of this instance.
        /// An instance of <see cref="RecognizeReceiptsOperation"/> sends requests to a server in UpdateStatusAsync, UpdateStatus, and other methods.
        /// Responses from these requests can be accessed using GetRawResponse.
        /// </remarks>
        public override Response GetRawResponse() => _response;

        /// <summary>
        /// Initializes a new instance of the <see cref="RecognizeReceiptsOperation"/> class which
        /// tracks the status of a long-running operation for recognizing values from receipts.
        /// </summary>
        /// <param name="operationId">The ID of this operation.</param>
        /// <param name="client">The client used to check for completion.</param>
        public RecognizeReceiptsOperation(string operationId, FormRecognizerClient client)
        {
            Argument.AssertNotNull(client, nameof(client));

            Id = operationId;
            _serviceClient = client.ServiceClient;
            _diagnostics = client.Diagnostics;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RecognizeReceiptsOperation"/> class.
        /// </summary>
        /// <param name="serviceClient">The client for communicating with the Form Recognizer Azure Cognitive Service through its REST API.</param>
        /// <param name="diagnostics">The client diagnostics for exception creation in case of failure.</param>
        /// <param name="operationLocation">The address of the long-running operation. It can be obtained from the response headers upon starting the operation.</param>
        internal RecognizeReceiptsOperation(FormRecognizerRestClient serviceClient, ClientDiagnostics diagnostics, string operationLocation)
        {
            _serviceClient = serviceClient;
            _diagnostics = diagnostics;

            // TODO: Add validation here
            // https://github.com/Azure/azure-sdk-for-net/issues/10385
            Id = operationLocation.Split('/').Last();
        }

        /// <summary>
        /// Periodically calls the server till the long-running operation completes.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> used for the periodical service calls.</param>
        /// <returns>The last HTTP response received from the server.</returns>
        /// <remarks>
        /// This method will periodically call UpdateStatusAsync till HasCompleted is true, then return the final result of the operation.
        /// </remarks>
        public override ValueTask<Response<RecognizedFormCollection>> WaitForCompletionAsync(CancellationToken cancellationToken = default) =>
            this.DefaultWaitForCompletionAsync(cancellationToken);

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
        public override ValueTask<Response<RecognizedFormCollection>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) =>
            this.DefaultWaitForCompletionAsync(pollingInterval, cancellationToken);

        /// <summary>
        /// Calls the server to get updated status of the long-running operation.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> used for the service call.</param>
        /// <returns>The HTTP response received from the server.</returns>
        /// <remarks>
        /// This operation will update the value returned from GetRawResponse and might update HasCompleted, HasValue, and Value.
        /// </remarks>
        public override Response UpdateStatus(CancellationToken cancellationToken = default) =>
            UpdateStatusAsync(false, cancellationToken).EnsureCompleted();

        /// <summary>
        /// Calls the server to get updated status of the long-running operation.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> used for the service call.</param>
        /// <returns>The HTTP response received from the server.</returns>
        /// <remarks>
        /// This operation will update the value returned from GetRawResponse and might update HasCompleted, HasValue, and Value.
        /// </remarks>
        public override async ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) =>
            await UpdateStatusAsync(true, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Calls the server to get updated status of the long-running operation.
        /// </summary>
        /// <param name="async">When <c>true</c>, the method will be executed asynchronously; otherwise, it will execute synchronously.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> used for the service call.</param>
        /// <returns>The HTTP response received from the server.</returns>
        private async ValueTask<Response> UpdateStatusAsync(bool async, CancellationToken cancellationToken)
        {
            if (!_hasCompleted)
            {
                using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(RecognizeReceiptsOperation)}.{nameof(UpdateStatus)}");
                scope.Start();

                try
                {
                    Response<AnalyzeOperationResult> update = async
                        ? await _serviceClient.GetAnalyzeReceiptResultAsync(new Guid(Id), cancellationToken).ConfigureAwait(false)
                        : _serviceClient.GetAnalyzeReceiptResult(new Guid(Id), cancellationToken);

                    _response = update.GetRawResponse();

                    if (update.Value.Status == OperationStatus.Succeeded)
                    {
                        // We need to first assign a value and then mark the operation as completed to avoid a race condition with the getter in Value
                        _value = ClientCommon.ConvertPrebuiltOutputToRecognizedForms(update.Value.AnalyzeResult);
                        _hasCompleted = true;
                    }
                    else if (update.Value.Status == OperationStatus.Failed)
                    {
                        _requestFailedException = await ClientCommon
                            .CreateExceptionForFailedOperationAsync(async, _diagnostics, _response, update.Value.AnalyzeResult.Errors)
                            .ConfigureAwait(false);
                        _hasCompleted = true;
                        throw _requestFailedException;
                    }
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return GetRawResponse();
        }
    }
}
