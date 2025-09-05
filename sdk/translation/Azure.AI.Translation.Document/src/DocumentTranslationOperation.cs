// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.Translation.Document
{
    /// <summary> Tracks the status of a long-running operation for translating documents. </summary>
    public class DocumentTranslationOperation : PageableOperation<DocumentStatusResult>, IOperation<AsyncPageable<DocumentStatusResult>>
    {
        // TODO: Respect retry after #19442
        private readonly TimeSpan DefaultPollingInterval = TimeSpan.FromSeconds(30);

        private readonly DocumentTranslationClient _serviceClient;
        private readonly ClientDiagnostics _diagnostics;
        private readonly OperationInternal<AsyncPageable<DocumentStatusResult>> _operationInternal;

        private int _documentsTotal;
        private int _documentsFailed;
        private int _documentsSucceeded;
        private int _documentsInProgress;
        private int _documentsNotStarted;
        private int _documentsCanceled;
        private DateTimeOffset _createdOn;
        private DateTimeOffset _lastModified;
        private DocumentTranslationStatus _status;

        /// <summary>
        /// The date time when the translation operation was created.
        /// </summary>
        public virtual DateTimeOffset CreatedOn => ValidateOperationHasResponse(_createdOn);

        /// <summary>
        /// The date time when the translation operation's status was last updated.
        /// </summary>
        public virtual DateTimeOffset LastModified => ValidateOperationHasResponse(_lastModified);

        /// <summary>
        /// The current status of the translation operation.
        /// </summary>
        public virtual DocumentTranslationStatus Status => ValidateOperationHasResponse(_status);

        /// <summary>
        /// Total number of expected translated documents.
        /// </summary>
        public virtual int DocumentsTotal => ValidateOperationHasResponse(_documentsTotal);

        /// <summary>
        /// Number of documents failed to translate.
        /// </summary>
        public virtual int DocumentsFailed => ValidateOperationHasResponse(_documentsFailed);

        /// <summary>
        /// Number of documents translated successfully.
        /// </summary>
        public virtual int DocumentsSucceeded => ValidateOperationHasResponse(_documentsSucceeded);

        /// <summary>
        /// Number of documents in progress.
        /// </summary>
        public virtual int DocumentsInProgress => ValidateOperationHasResponse(_documentsInProgress);

        /// <summary>
        /// Number of documents in queue for translation.
        /// </summary>
        public virtual int DocumentsNotStarted => ValidateOperationHasResponse(_documentsNotStarted);

        /// <summary>
        /// Number of documents canceled.
        /// </summary>
        public virtual int DocumentsCanceled => ValidateOperationHasResponse(_documentsCanceled);

        /// <summary>
        /// Gets an ID representing the translation operation that can be used to poll for the status
        /// of the long-running operation.
        /// </summary>
        public override string Id { get; }

        /// <summary>
        /// Returns true if the long-running operation has completed.
        /// </summary>
        public override bool HasCompleted => _operationInternal.HasCompleted;

        /// <summary>
        /// Final result of the long-running operation.
        /// </summary>
        /// <remarks>
        /// This property can be accessed only after the operation completes successfully (HasValue is true).
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override AsyncPageable<DocumentStatusResult> Value => _operationInternal.Value;

        /// <summary>
        /// Returns true if the long-running operation completed successfully and has produced final result (accessible by Value property).
        /// </summary>
        public override bool HasValue => _operationInternal.HasValue;

        /// <summary>
        /// Protected constructor to allow mocking.
        /// </summary>
        protected DocumentTranslationOperation()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentTranslationOperation"/> class.
        /// </summary>
        /// <param name="translationId">The translation ID of this operation.</param>
        /// <param name="client">The client used to check for completion.</param>
        public DocumentTranslationOperation(string translationId, DocumentTranslationClient client)
        {
            var parsedTranslationId = ClientCommon.ValidateModelId(translationId, nameof(translationId));
            Id = parsedTranslationId.ToString();
            _serviceClient = client._serviceClient;
            _diagnostics = client._clientDiagnostics;

            _operationInternal = new OperationInternal<AsyncPageable<DocumentStatusResult>>(this, _diagnostics, rawResponse: null);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentTranslationOperation"/> class.
        /// </summary>
        /// <param name="serviceClient">The client for communicating with the Translator Cognitive Service through its REST API.</param>
        /// <param name="diagnostics">The client diagnostics for exception creation in case of failure.</param>
        /// <param name="operationLocation">The address of the long-running operation. It can be obtained from the response headers upon starting the operation.</param>
        internal DocumentTranslationOperation(DocumentTranslationClient serviceClient, ClientDiagnostics diagnostics, string operationLocation)
        {
            _serviceClient = serviceClient;
            _diagnostics = diagnostics;
            _operationInternal = new OperationInternal<AsyncPageable<DocumentStatusResult>>(this, _diagnostics, rawResponse: null);

            Id = operationLocation.Split('/').Last().Split('?').First();
        }

        /// <summary>
        /// The last HTTP response received from the server.
        /// </summary>
        /// <remarks>
        /// The last response returned from the server during the lifecycle of this instance.
        /// An instance of <see cref="DocumentTranslationOperation"/> sends requests to a server in UpdateStatusAsync, UpdateStatus, and other methods.
        /// Responses from these requests can be accessed using GetRawResponse.
        /// </remarks>
        public override Response GetRawResponse() => _operationInternal.RawResponse;

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

        /// <summary>
        /// Periodically calls the server till the long-running operation completes.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> used for the periodical service calls.</param>
        /// <returns>The last HTTP response received from the server.</returns>
        /// <remarks>
        /// This method will periodically call UpdateStatusAsync till HasCompleted is true.
        /// An API call is then made to retrieve the status of the documents.
        /// </remarks>
        public override async ValueTask<Response<AsyncPageable<DocumentStatusResult>>> WaitForCompletionAsync(CancellationToken cancellationToken = default) =>
            await _operationInternal.WaitForCompletionAsync(DefaultPollingInterval, cancellationToken).ConfigureAwait(false);

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
        /// This method will periodically call UpdateStatusAsync till HasCompleted is true.
        /// An API call is then made to retrieve the status of the documents.
        /// </remarks>
        public override async ValueTask<Response<AsyncPageable<DocumentStatusResult>>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) =>
            await _operationInternal.WaitForCompletionAsync(pollingInterval, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Calls the server to get updated status of the long-running operation.
        /// </summary>
        /// <param name="async">When <c>true</c>, the method will be executed asynchronously; otherwise, it will execute synchronously.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> used for the service call.</param>
        /// <returns>The HTTP response received from the server.</returns>
        async ValueTask<OperationState<AsyncPageable<DocumentStatusResult>>> IOperation<AsyncPageable<DocumentStatusResult>>.UpdateStateAsync(bool async, CancellationToken cancellationToken)
        {
            var update = async
                        ? await _serviceClient.GetTranslationStatusAsync(new Guid(Id), cancellationToken).ConfigureAwait(false)
                        : _serviceClient.GetTranslationStatus(new Guid(Id), cancellationToken);

            _createdOn = update.Value.CreatedOn;
            _lastModified = update.Value.LastModified;
            _status = update.Value.Status;
            _documentsTotal = update.Value.DocumentsTotal;
            _documentsFailed = update.Value.DocumentsFailed;
            _documentsInProgress = update.Value.DocumentsInProgress;
            _documentsSucceeded = update.Value.DocumentsSucceeded;
            _documentsNotStarted = update.Value.DocumentsNotStarted;
            _documentsCanceled = update.Value.DocumentsCanceled;

            Response rawResponse = update.GetRawResponse();

            if (update.Value.Status == DocumentTranslationStatus.Succeeded || update.Value.Status == DocumentTranslationStatus.Failed)
            {
                return OperationState<AsyncPageable<DocumentStatusResult>>.Success(rawResponse, CreateOperationValueAsync(CancellationToken.None));
            }
            else if (update.Value.Status == DocumentTranslationStatus.ValidationFailed)
            {
                RequestFailedException requestFailedException = new RequestFailedException(
                    rawResponse,
                    null,
                    new DocumentTranslationOperationRequestFailedDetailsParser(update.Value.Error, CreateAdditionalInformation(update.Value.Error)));

                return OperationState<AsyncPageable<DocumentStatusResult>>.Failure(rawResponse, requestFailedException);
            }

            return OperationState<AsyncPageable<DocumentStatusResult>>.Pending(rawResponse);
        }

        // This method is never invoked since we don't override Operation<T>.GetRehydrationToken.
        RehydrationToken IOperation<AsyncPageable<DocumentStatusResult>>.GetRehydrationToken() =>
            throw new NotSupportedException($"{nameof(GetRehydrationToken)} is not supported.");

        private AsyncPageable<DocumentStatusResult> CreateOperationValueAsync(CancellationToken cancellationToken = default)
        {
            return GetDocumentStatusesAsync(cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Get the status of a specific document in the translation operation.
        /// </summary>
        /// <param name="documentId">ID of the document.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> used for the service call.</param>
        public virtual Response<DocumentStatusResult> GetDocumentStatus(string documentId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(DocumentTranslationOperation)}.{nameof(GetDocumentStatus)}");
            scope.Start();

            try
            {
                var parsedDocumentId = ClientCommon.ValidateModelId(documentId, nameof(documentId));
                return _serviceClient.GetDocumentStatus(new Guid(Id), parsedDocumentId, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get the status of a specific document in the translation operation.
        /// </summary>
        /// <param name="documentId">ID of the document.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> used for the service call.</param>
        public virtual async Task<Response<DocumentStatusResult>> GetDocumentStatusAsync(string documentId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(DocumentTranslationOperation)}.{nameof(GetDocumentStatus)}");
            scope.Start();

            try
            {
                var parsedDocumentId = ClientCommon.ValidateModelId(documentId, nameof(documentId));
                return await _serviceClient.GetDocumentStatusAsync(new Guid(Id), parsedDocumentId, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get the status of documents in the translation operation.
        /// </summary>
        /// <param name="options">Options to use when filtering result.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> used for the service call.</param>
        public virtual Pageable<DocumentStatusResult> GetDocumentStatuses(GetDocumentStatusesOptions options = default, CancellationToken cancellationToken = default)
        {
            var idList = options?.Ids.Count > 0 ? options.Ids.Select(id => ClientCommon.ValidateModelId(id, "Id Filter")) : null;
            var statusList = options?.Statuses.Count > 0 ? options.Statuses.Select(status => status.ToString()) : null;
            var orderByList = options?.OrderBy.Count > 0 ? options.OrderBy.Select(order => order.ToGenerated()) : null;

            return _serviceClient.GetDocumentsStatus(
                new Guid(Id),
                documentIds: idList,
                statuses: statusList,
                createdDateTimeUtcStart: options?.CreatedAfter,
                createdDateTimeUtcEnd: options?.CreatedBefore,
                orderby: orderByList,
                cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Get the status of documents in the translation operation.
        /// </summary>
        /// <param name="options">Options to use when filtering result.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> used for the service call.</param>
        public virtual AsyncPageable<DocumentStatusResult> GetDocumentStatusesAsync(GetDocumentStatusesOptions options = default, CancellationToken cancellationToken = default)
        {
            var idList = options?.Ids.Count > 0 ? options.Ids.Select(id => ClientCommon.ValidateModelId(id, "Id Filter")) : null;
            var statusList = options?.Statuses.Count > 0 ? options.Statuses.Select(status => status.ToString()) : null;
            var orderByList = options?.OrderBy.Count > 0 ? options.OrderBy.Select(order => order.ToGenerated()) : null;

            return _serviceClient.GetDocumentsStatusAsync(
                new Guid(Id),
                documentIds: idList,
                statuses: statusList,
                createdDateTimeUtcStart: options?.CreatedAfter,
                createdDateTimeUtcEnd: options?.CreatedBefore,
                orderby: orderByList,
                cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Cancel a running translation operation.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> used for the service call.</param>
        public virtual void Cancel(CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(DocumentTranslationOperation)}.{nameof(Cancel)}");
            scope.Start();

            try
            {
                _serviceClient.CancelTranslation(new Guid(Id), cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Cancel a running translation operation.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> used for the service call.</param>
        public virtual async Task CancelAsync(CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(DocumentTranslationOperation)}.{nameof(Cancel)}");
            scope.Start();

            try
            {
                await _serviceClient.CancelTranslationAsync(new Guid(Id), cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the final result of the long-running operation asynchronously.
        /// </summary>
        /// <remarks>
        /// Operation must complete successfully (HasValue is true) for it to provide values.
        /// </remarks>
        public override AsyncPageable<DocumentStatusResult> GetValuesAsync(CancellationToken cancellationToken = default)
        {
            // Validates that the operation has completed successfully.
            _ = _operationInternal.Value;

            return GetDocumentStatusesAsync(cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Gets the final result of the long-running operation synchronously.
        /// </summary>
        /// <remarks>
        /// Operation must complete successfully (HasValue is true) for it to provide values.
        /// </remarks>
        public override Pageable<DocumentStatusResult> GetValues(CancellationToken cancellationToken = default)
        {
            // Validates that the operation has completed successfully.
            _ = _operationInternal.Value;

            return GetDocumentStatuses(cancellationToken: cancellationToken);
        }

        private T ValidateOperationHasResponse<T>(T value)
        {
            if (_operationInternal.RawResponse == null)
                throw new InvalidOperationException("The operation has not done a request. Make sure to update the operation.");

            return value;
        }

        private static IDictionary<string, string> CreateAdditionalInformation(ResponseError error)
        {
            if (string.IsNullOrEmpty(error.ToString()))
                return null;
            return new Dictionary<string, string>(1) { { "AdditionalInformation", error.ToString() } };
        }

        private class DocumentTranslationOperationRequestFailedDetailsParser : RequestFailedDetailsParser
        {
            private readonly ResponseError _error;
            private readonly IDictionary<string, string> _additionalInfo;

            public DocumentTranslationOperationRequestFailedDetailsParser(ResponseError error, IDictionary<string, string> additionalInfo)
            {
                _error = error;
                _additionalInfo = additionalInfo;
            }
            public override bool TryParse(Response response, out ResponseError error, out IDictionary<string, string> data)
            {
                error = _error;
                data = _additionalInfo;
                return true;
            }
        }
    }
}
