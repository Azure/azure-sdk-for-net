// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.TextAnalytics.Models;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.TextAnalytics
{
    /// <summary> Pageable operation class for analyzing multiple actions using long running operation. </summary>
    public class AnalyzeBatchActionsOperation : PageableOperation<AnalyzeBatchActionsResult>
    {
        /// <summary>Provides communication with the Form Recognizer Azure Cognitive Service through its REST API.</summary>
        private readonly TextAnalyticsRestClient _serviceClient;

        /// <summary>Provides tools for exception creation in case of failure.</summary>
        private readonly ClientDiagnostics _diagnostics;

        /// <summary>
        /// Total actions failed in the operation
        /// </summary>
        public int ActionsFailed => _actionsFailed;

        /// <summary>
        /// Total actions in progress in the operation
        /// </summary>
        public int ActionsInProgress => _actionsInProgress;

        /// <summary>
        /// Total actions succeeded in the operation
        /// </summary>
        public int ActionsSucceeded => _actionSucceeded;

        /// <summary>
        /// Time when the operation was created on.
        /// </summary>
        public DateTimeOffset CreatedOn => _createdOn;

        /// <summary>
        /// Display Name of the operation
        /// </summary>
        public string DisplayName => _displayName;

        /// <summary>
        /// Time when the operation will expire.
        /// </summary>
        public DateTimeOffset? ExpiresOn => _expiresOn;

        /// <summary>
        /// Time when the operation was last modified on.
        /// </summary>
        public DateTimeOffset LastModified => _lastModified;

        /// <summary>
        /// The current status of the operation.
        /// </summary>
        public TextAnalyticsOperationStatus Status => _status;

        /// <summary>
        /// Total actions executed in the operation
        /// </summary>
        public int TotalActions => _totalActions;

        /// <summary>
        /// Gets an ID representing the operation that can be used to poll for the status
        /// of the long-running operation.
        /// </summary>
        public override string Id { get; }

        /// <summary>
        /// Provides the input to be part of AnalyzeOperation class
        /// </summary>
        internal readonly IDictionary<string, int> _idToIndexMap;

        /// <summary>
        /// Final result of the long-running operation.
        /// </summary>
        /// <remarks>
        /// This property can be accessed only after the operation completes successfully (HasValue is true).
        /// </remarks>
        public override AsyncPageable<AnalyzeBatchActionsResult> Value => GetValuesAsync();

        /// <summary>
        /// <c>true</c> if the long-running operation has completed. Otherwise, <c>false</c>.
        /// </summary>
        private bool _hasCompleted;

        private int _totalActions;
        private int _actionsFailed;
        private int _actionSucceeded;
        private int _actionsInProgress;
        private DateTimeOffset _createdOn;
        private DateTimeOffset? _expiresOn;
        private DateTimeOffset _lastModified;
        private TextAnalyticsOperationStatus _status;
        private string _displayName;

        /// <summary>
        /// Returns true if the long-running operation completed.
        /// </summary>
        public override bool HasCompleted => _hasCompleted;

        /// <summary>
        /// The last HTTP response received from the server. <c>null</c> until the first response is received.
        /// </summary>
        private Response _response;

        /// <summary>
        /// Provides the results for the first page.
        /// </summary>
        private Page<AnalyzeBatchActionsResult> _firstPage;

        /// <summary>
        /// Represents the desire of the user to request statistics.
        /// This is used in every GET request.
        /// </summary>
        private bool? _showStats { get; }

        /// <summary>
        /// Returns true if the long-running operation completed successfully and has produced final result (accessible by Value property).
        /// </summary>
        public override bool HasValue => _firstPage != null;

        /// <summary>
        /// Initializes a new instance of the <see cref="AnalyzeBatchActionsOperation"/> class.
        /// </summary>
        /// <param name="operationId">The ID of this operation.</param>
        /// <param name="client">The client used to check for completion.</param>
        public AnalyzeBatchActionsOperation(string operationId, TextAnalyticsClient client)
        {
            // TODO: Add argument validation here.

            Id = operationId;
            _serviceClient = client._serviceRestClient;
            _diagnostics = client._clientDiagnostics;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AnalyzeBatchActionsOperation"/> class.
        /// </summary>
        /// <param name="serviceClient">The client for communicating with the Form Recognizer Azure Cognitive Service through its REST API.</param>
        /// <param name="diagnostics">The client diagnostics for exception creation in case of failure.</param>
        /// <param name="operationLocation">The address of the long-running operation. It can be obtained from the response headers upon starting the operation.</param>
        /// <param name="idToIndexMap"></param>
        /// <param name="showStats"></param>
        internal AnalyzeBatchActionsOperation(TextAnalyticsRestClient serviceClient, ClientDiagnostics diagnostics, string operationLocation, IDictionary<string, int> idToIndexMap, bool? showStats = default)
        {
            _serviceClient = serviceClient;
            _diagnostics = diagnostics;
            _idToIndexMap = idToIndexMap;
            _showStats = showStats;

            // TODO: Add validation here
            // https://github.com/Azure/azure-sdk-for-net/issues/11505
            Id = operationLocation.Split('/').Last();
        }

        /// <summary>
        /// The last HTTP response received from the server.
        /// </summary>
        /// <remarks>
        /// The last response returned from the server during the lifecycle of this instance.
        /// An instance of <see cref="AnalyzeBatchActionsOperation"/> sends requests to a server in UpdateStatusAsync, UpdateStatus, and other methods.
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
        /// This method will periodically call UpdateStatusAsync till HasCompleted is true, then return the final result of the operation.
        /// </remarks>
        public override ValueTask<Response<AsyncPageable<AnalyzeBatchActionsResult>>> WaitForCompletionAsync(CancellationToken cancellationToken = default) =>
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
        public override ValueTask<Response<AsyncPageable<AnalyzeBatchActionsResult>>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) =>
            this.DefaultWaitForCompletionAsync(pollingInterval, cancellationToken);

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
                using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(AnalyzeBatchActionsOperation)}.{nameof(UpdateStatus)}");
                scope.Start();

                try
                {
                    Response<AnalyzeJobState> update = async
                        ? await _serviceClient.AnalyzeStatusAsync(Id, _showStats, null, null, cancellationToken).ConfigureAwait(false)
                        : _serviceClient.AnalyzeStatus(Id, _showStats, null, null, cancellationToken);

                    _response = update.GetRawResponse();

                    _displayName = update.Value.DisplayName;
                    _createdOn = update.Value.CreatedDateTime;
                    _expiresOn = update.Value.ExpirationDateTime;
                    _lastModified = update.Value.LastUpdateDateTime;
                    _status = update.Value.Status;
                    _actionsFailed = update.Value.Tasks.Failed;
                    _actionsInProgress = update.Value.Tasks.InProgress;
                    _actionSucceeded = update.Value.Tasks.Completed;
                    _totalActions = update.Value.Tasks.Total;

                    // TODO - Remove PartiallySucceeded once service deploys this to WestUS2
                    if (update.Value.Status == TextAnalyticsOperationStatus.Succeeded ||
                        update.Value.Status == TextAnalyticsOperationStatus.PartiallySucceeded ||
                        update.Value.Status == TextAnalyticsOperationStatus.PartiallyCompleted ||
                        update.Value.Status == TextAnalyticsOperationStatus.Failed)
                    {
                        // we need to first assign a value and then mark the operation as completed to avoid race conditions
                        var nextLink = update.Value.NextLink;
                        var value = Transforms.ConvertToAnalyzeOperationResult(update.Value, _idToIndexMap);
                        _firstPage = Page.FromValues(new List<AnalyzeBatchActionsResult>() { value }, nextLink, _response);
                        _hasCompleted = true;
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
        /// Gets the final result of the long-running operation asynchronously.
        /// </summary>
        /// <remarks>
        /// Operation must complete successfully (HasValue is true) for it to provide values.
        /// </remarks>
        public override AsyncPageable<AnalyzeBatchActionsResult> GetValuesAsync()
        {
            ValidateOperationStatus();

            async Task<Page<AnalyzeBatchActionsResult>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                //diagnostics scope?
                try
                {
                    Response<AnalyzeJobState> jobState = await _serviceClient.AnalyzeStatusNextPageAsync(nextLink, _showStats).ConfigureAwait(false);

                    AnalyzeBatchActionsResult result = Transforms.ConvertToAnalyzeOperationResult(jobState.Value, _idToIndexMap);
                    return Page.FromValues(new List<AnalyzeBatchActionsResult>() { result }, jobState.Value.NextLink, jobState.GetRawResponse());
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return PageableHelpers.CreateAsyncEnumerable(_ => Task.FromResult(_firstPage), NextPageFunc);
        }

        /// <summary>
        /// Gets the final result of the long-running operation synchronously.
        /// </summary>
        /// <remarks>
        /// Operation must complete successfully (HasValue is true) for it to provide values.
        /// </remarks>
        public override Pageable<AnalyzeBatchActionsResult> GetValues()
        {
            ValidateOperationStatus();

            Page<AnalyzeBatchActionsResult> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                //diagnostics scope?
                try
                {
                    Response<AnalyzeJobState> jobState = _serviceClient.AnalyzeStatusNextPage(nextLink, _showStats);

                    AnalyzeBatchActionsResult result = Transforms.ConvertToAnalyzeOperationResult(jobState.Value, _idToIndexMap);
                    return Page.FromValues(new List<AnalyzeBatchActionsResult>() { result }, jobState.Value.NextLink, jobState.GetRawResponse());
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return PageableHelpers.CreateEnumerable(_ => _firstPage, NextPageFunc);
        }

        private void ValidateOperationStatus()
        {
            if (!HasCompleted)
                throw new InvalidOperationException("The operation has not completed yet.");
        }
    }
}
