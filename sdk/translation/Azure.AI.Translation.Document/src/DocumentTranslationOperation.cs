﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Translation.Document.Models;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.Translation.Document
{
    /// <summary> Tracks the status of a long-running operation for translating documents. </summary>
    public class DocumentTranslationOperation : PageableOperation<DocumentStatus>
    {
        // TODO: Respect retry after #19442
        private readonly TimeSpan DefaultPollingInterval = TimeSpan.FromSeconds(30);

        /// <summary>Provides communication with the Translator Cognitive Service through its REST API.</summary>
        private readonly DocumentTranslationRestClient _serviceClient;

        /// <summary>Provides tools for exception creation in case of failure.</summary>
        private readonly ClientDiagnostics _diagnostics;

        /// <summary>
        /// The date time when the translation operation was created.
        /// </summary>
        public virtual DateTimeOffset CreatedOn => _createdOn;

        /// <summary>
        /// The date time when the translation operation's status was last updated.
        /// </summary>
        public virtual DateTimeOffset LastModified => _lastModified;

        /// <summary>
        /// The current status of the translation operation.
        /// </summary>
        public virtual DocumentTranslationStatus Status => _status;

        /// <summary>
        /// Total number of expected translated documents.
        /// </summary>
        public virtual int DocumentsTotal => _documentsTotal;

        /// <summary>
        /// Number of documents failed to translate.
        /// </summary>
        public virtual int DocumentsFailed => _documentsFailed;

        /// <summary>
        /// Number of documents translated successfully.
        /// </summary>
        public virtual int DocumentsSucceeded => _documentsSucceeded;

        /// <summary>
        /// Number of documents in progress.
        /// </summary>
        public virtual int DocumentsInProgress => _documentsInProgress;

        /// <summary>
        /// Number of documents in queue for translation.
        /// </summary>
        public virtual int DocumentsNotStarted => _documentsNotStarted;

        /// <summary>
        /// Number of documents cancelled.
        /// </summary>
        public virtual int DocumentsCancelled => _documentsCancelled;

        private int _documentsTotal;
        private int _documentsFailed;
        private int _documentsSucceeded;
        private int _documentsInProgress;
        private int _documentsNotStarted;
        private int _documentsCancelled;
        private DateTimeOffset _createdOn;
        private DateTimeOffset _lastModified;
        private DocumentTranslationStatus _status;

        /// <summary>
        /// Gets an ID representing the translation operation that can be used to poll for the status
        /// of the long-running operation.
        /// </summary>
        public override string Id { get; }

        /// <summary>
        /// Final result of the long-running operation.
        /// </summary>
        /// <remarks>
        /// This property can be accessed only after the operation completes successfully (HasValue is true).
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override AsyncPageable<DocumentStatus> Value => GetValuesAsync();

        /// <summary>
        /// <c>true</c> if the long-running operation has completed. Otherwise, <c>false</c>.
        /// </summary>
        private bool _hasCompleted;

        /// <summary>
        /// <c>true</c> if the long-running operation has a value. Otherwise, <c>false</c>.
        /// </summary>
        private bool _hasValue;

        /// <summary>
        /// Returns true if the long-running operation completed.
        /// </summary>
        public override bool HasCompleted => _hasCompleted;

        private RequestFailedException _requestFailedException;

        /// <summary>
        /// The last HTTP response received from the server. <c>null</c> until the first response is received.
        /// </summary>
        private Response _response;

        /// <summary>
        /// The last Retry-After Header value from the last HTTP response received from the server. <c>null</c> until the first response is received.
        /// </summary>
        private int? _retryAfterHeaderValue;

        /// <summary>
        /// Provides the results for the first page.
        /// </summary>
        private Page<DocumentStatus> _firstPage;

        /// <summary>
        /// Returns true if the long-running operation completed successfully and has produced final result (accessible by Value property).
        /// </summary>
        public override bool HasValue => _hasValue;

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
            _serviceClient = client._serviceRestClient;
            _diagnostics = client._clientDiagnostics;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentTranslationOperation"/> class.
        /// </summary>
        /// <param name="serviceClient">The client for communicating with the Translator Cognitive Service through its REST API.</param>
        /// <param name="diagnostics">The client diagnostics for exception creation in case of failure.</param>
        /// <param name="operationLocation">The address of the long-running operation. It can be obtained from the response headers upon starting the operation.</param>
        internal DocumentTranslationOperation(DocumentTranslationRestClient serviceClient, ClientDiagnostics diagnostics, string operationLocation)
        {
            _serviceClient = serviceClient;
            _diagnostics = diagnostics;
            Id = operationLocation.Split('/').Last();
        }

        /// <summary>
        /// The last HTTP response received from the server.
        /// </summary>
        /// <remarks>
        /// The last response returned from the server during the lifecycle of this instance.
        /// An instance of <see cref="DocumentTranslationOperation"/> sends requests to a server in UpdateStatusAsync, UpdateStatus, and other methods.
        /// Responses from these requests can be accessed using GetRawResponse.
        /// </remarks>
        public override Response GetRawResponse() => _response;

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
        /// Periodically calls the server till the long-running operation completes.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> used for the periodical service calls.</param>
        /// <returns>The last HTTP response received from the server.</returns>
        /// <remarks>
        /// This method will periodically call UpdateStatusAsync till HasCompleted is true.
        /// An API call is then made to retrieve the status of the documents.
        /// </remarks>
        public override ValueTask<Response<AsyncPageable<DocumentStatus>>> WaitForCompletionAsync(CancellationToken cancellationToken = default) =>
            WaitForCompletionAsync(DefaultPollingInterval, cancellationToken);

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
        public async override ValueTask<Response<AsyncPageable<DocumentStatus>>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default)
        {
            while (true)
            {
                await UpdateStatusAsync(cancellationToken).ConfigureAwait(false);
                if (!HasCompleted)
                {
                    pollingInterval = _retryAfterHeaderValue.HasValue ? TimeSpan.FromSeconds(_retryAfterHeaderValue.Value) : pollingInterval;
                    await Task.Delay(pollingInterval, cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    var response = await _serviceClient.GetDocumentsStatusAsync(new Guid(Id), cancellationToken: cancellationToken).ConfigureAwait(false);
                    _firstPage = Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                    _hasValue = true;
                    async Task<Page<DocumentStatus>> NextPageFunc(string nextLink, int? pageSizeHint)
                    {
                        // TODO: diagnostics scope?
                        try
                        {
                            var response = await _serviceClient.GetDocumentsStatusNextPageAsync(nextLink, new Guid(Id), cancellationToken: cancellationToken).ConfigureAwait(false);

                            return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }

                    var result = PageableHelpers.CreateAsyncEnumerable(_ => Task.FromResult(_firstPage), NextPageFunc);
                    return Response.FromValue(result, response);
                }
            }
        }

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
                using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(DocumentTranslationOperation)}.{nameof(UpdateStatus)}");
                scope.Start();

                try
                {
                    var update = async
                        ? await _serviceClient.GetTranslationStatusAsync(new Guid(Id), cancellationToken).ConfigureAwait(false)
                        : _serviceClient.GetTranslationStatus(new Guid(Id), cancellationToken);

                    _response = update.GetRawResponse();
                    _retryAfterHeaderValue = update.Headers.RetryAfter;

                    _createdOn = update.Value.CreatedOn;
                    _lastModified = update.Value.LastModified;
                    _status = update.Value.Status;
                    _documentsTotal = update.Value.DocumentsTotal;
                    _documentsFailed = update.Value.DocumentsFailed;
                    _documentsInProgress = update.Value.DocumentsInProgress;
                    _documentsSucceeded = update.Value.DocumentsSucceeded;
                    _documentsNotStarted = update.Value.DocumentsNotStarted;
                    _documentsCancelled = update.Value.DocumentsCancelled;

                    if (update.Value.Status == DocumentTranslationStatus.Succeeded
                        || update.Value.Status == DocumentTranslationStatus.Cancelled
                        || update.Value.Status == DocumentTranslationStatus.Failed)
                    {
                        _hasCompleted = true;
                        _hasValue = true;
                    }
                    else if (update.Value.Status == DocumentTranslationStatus.ValidationFailed)
                    {
                        DocumentTranslationError error = update.Value.Error;
                        _requestFailedException = _diagnostics.CreateRequestFailedException(_response, error.Message, error.ErrorCode.ToString(), CreateAdditionalInformation(error));
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

        /// <summary>
        /// Get the status of a specific document in the translation operation.
        /// </summary>
        /// <param name="documentId">ID of the document.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> used for the service call.</param>
        public virtual Response<DocumentStatus> GetDocumentStatus(string documentId, CancellationToken cancellationToken = default)
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
        public virtual async Task<Response<DocumentStatus>> GetDocumentStatusAsync(string documentId, CancellationToken cancellationToken = default)
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
        /// Get the status of all documents in the translation operation.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> used for the service call.</param>
        public virtual Pageable<DocumentStatus> GetAllDocumentStatuses(CancellationToken cancellationToken = default)
        {
            Page<DocumentStatus> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(DocumentTranslationOperation)}.{nameof(GetAllDocumentStatuses)}");
                scope.Start();

                try
                {
                    var response = _serviceClient.GetDocumentsStatus(new Guid(Id), cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<DocumentStatus> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(DocumentTranslationOperation)}.{nameof(GetAllDocumentStatuses)}");
                scope.Start();

                try
                {
                    var response = _serviceClient.GetDocumentsStatusNextPage(nextLink, new Guid(Id), cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Get the status of all documents in the translation operation.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> used for the service call.</param>
        public virtual AsyncPageable<DocumentStatus> GetAllDocumentStatusesAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<DocumentStatus>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(DocumentTranslationOperation)}.{nameof(GetAllDocumentStatuses)}");
                scope.Start();

                try
                {
                    var response = await _serviceClient.GetDocumentsStatusAsync(new Guid(Id), cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            async Task<Page<DocumentStatus>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(DocumentTranslationOperation)}.{nameof(GetAllDocumentStatuses)}");
                scope.Start();

                try
                {
                    var response = await _serviceClient.GetDocumentsStatusNextPageAsync(nextLink, new Guid(Id), cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
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
                Response<TranslationStatus> response = _serviceClient.CancelTranslation(new Guid(Id), cancellationToken);
                _response = response.GetRawResponse();
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
                Response<TranslationStatus> response = await _serviceClient.CancelTranslationAsync(new Guid(Id), cancellationToken).ConfigureAwait(false);
                _response = response.GetRawResponse();
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
        public override AsyncPageable<DocumentStatus> GetValuesAsync(CancellationToken cancellationToken = default)
        {
            ValidateOperationStatus();

            return GetAllDocumentStatusesAsync(cancellationToken);
        }

        /// <summary>
        /// Gets the final result of the long-running operation synchronously.
        /// </summary>
        /// <remarks>
        /// Operation must complete successfully (HasValue is true) for it to provide values.
        /// </remarks>
        public override Pageable<DocumentStatus> GetValues(CancellationToken cancellationToken = default)
        {
            ValidateOperationStatus();

            return GetAllDocumentStatuses(cancellationToken);
        }

        private void ValidateOperationStatus()
        {
            if (!HasCompleted)
                throw new InvalidOperationException("The operation has not completed yet.");
            if (!HasValue)
                throw _requestFailedException;
        }

        private static IDictionary<string, string> CreateAdditionalInformation(DocumentTranslationError error)
        {
            if (string.IsNullOrEmpty(error.Target))
                return null;
            return new Dictionary<string, string> { { "Target", error.Target } };
        }
    }
}
