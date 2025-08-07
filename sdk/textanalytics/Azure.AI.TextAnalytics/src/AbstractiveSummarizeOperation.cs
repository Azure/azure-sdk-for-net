// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.TextAnalytics.Models;
using Azure.AI.TextAnalytics.ServiceClients;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// A representation of abstractive summarization being performed on a given set of documents as a pageable,
    /// long-running operation.
    /// </summary>
    public class AbstractiveSummarizeOperation
        : PageableOperation<AbstractiveSummarizeResultCollection>, IOperation<AsyncPageable<AbstractiveSummarizeResultCollection>>
    {
        internal readonly IDictionary<string, int> _idToIndexMap;

        private readonly bool? _showStats;
        private readonly string _jobId;
        private readonly ServiceClient _serviceClient;
        private readonly ClientDiagnostics _diagnostics;
        private readonly OperationInternal<AsyncPageable<AbstractiveSummarizeResultCollection>> _operationInternal;

        private TextAnalyticsOperationStatus _status;
        private DateTimeOffset? _expiresOn;
        private DateTimeOffset _lastModified;
        private DateTimeOffset _createdOn;
        private string _displayName;
        private Page<AbstractiveSummarizeResultCollection> _firstPage;

        /// <summary>
        /// The identifier of the long-running operation, which can be used to poll its current status.
        /// </summary>
        public override string Id { get; }

        /// <summary>
        /// The display name of the long-running operation.
        /// </summary>
        public virtual string DisplayName => _displayName;

        /// <summary>
        /// The time when the long-running operation was created.
        /// </summary>
        public virtual DateTimeOffset CreatedOn => _createdOn;

        /// <summary>
        /// The time when the long-running operation will expire.
        /// </summary>
        public virtual DateTimeOffset? ExpiresOn => _expiresOn;

        /// <summary>
        /// The time when the long-running operation was last modified.
        /// </summary>
        public virtual DateTimeOffset LastModified => _lastModified;

        /// <summary>
        /// The status of the long-running operation.
        /// </summary>
        public virtual TextAnalyticsOperationStatus Status => _status;

        /// <summary>
        /// Indicates whether the long-running operation has completed.
        /// </summary>
        public override bool HasCompleted => _operationInternal.HasCompleted;

        /// <summary>
        /// Indicates whether the long-running operation has completed successfully and produced a final result.
        /// </summary>
        public override bool HasValue => _operationInternal.HasValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractiveSummarizeOperation"/> class.
        /// </summary>
        /// <param name="operationId">The identifier of the long-running operation.</param>
        /// <param name="client">The client used to check for completion.</param>
        /// <exception cref="ArgumentException">
        /// <paramref name="operationId"/> is an empty string or does not represent a valid continuation token from the
        /// <see cref="Id"/> property returned on the original operation.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="operationId"/> or <paramref name="client"/> is null.
        /// </exception>
        public AbstractiveSummarizeOperation(string operationId, TextAnalyticsClient client)
        {
            Argument.AssertNotNullOrEmpty(operationId, nameof(operationId));
            Argument.AssertNotNull(client, nameof(client));

            try
            {
                OperationContinuationToken token = OperationContinuationToken.Deserialize(operationId);

                _jobId = token.JobId;
                _showStats = token.ShowStats;
                _idToIndexMap = token.InputDocumentOrder;
            }
            catch (Exception e)
            {
                throw new ArgumentException($"Invalid value. Please use the {nameof(AbstractiveSummarizeOperation)}.{nameof(Id)} property value.", nameof(operationId), e);
            }

            Id = operationId;
            _serviceClient = client.ServiceClient;
            _diagnostics = _serviceClient.Diagnostics;
            _operationInternal = new(this, _diagnostics, rawResponse: null);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractiveSummarizeOperation"/> class.
        /// </summary>
        internal AbstractiveSummarizeOperation(
            ServiceClient serviceClient,
            ClientDiagnostics diagnostics,
            string operationLocation,
            IDictionary<string, int> idToIndexMap,
            bool? showStats = default)
        {
            _serviceClient = serviceClient;
            _diagnostics = diagnostics;
            _idToIndexMap = idToIndexMap;
            _showStats = showStats;
            _operationInternal = new(this, _diagnostics, rawResponse: null);

            _jobId = operationLocation.Split('/').Last().Split('?')[0];

            Id = OperationContinuationToken.Serialize(_jobId, idToIndexMap, showStats);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractiveSummarizeOperation"/> class. This constructor is only
        /// intended for mocking.
        /// </summary>
        protected AbstractiveSummarizeOperation()
        {
        }

        /// <summary>
        /// Gets the last HTTP response received from the server associated with this long-running operation.
        /// </summary>
        /// <remarks>
        /// An instance of the <see cref="AbstractiveSummarizeOperation"/> class sends requests to the server via methods
        /// such as <see cref="UpdateStatus"/>, <see cref="UpdateStatusAsync"/>, etc.
        /// </remarks>
        public override Response GetRawResponse() => _operationInternal.RawResponse;

        /// <summary>
        /// Updates the status of the long-running operation.
        /// </summary>
        /// <remarks>
        /// This operation will update the value returned by <see cref="GetRawResponse"/> and might also update
        /// <see cref="HasCompleted"/>, <see cref="HasValue"/>, and <see cref="Operation{T}.Value"/>.
        /// </remarks>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> controlling the lifetime of the request.</param>
        /// <returns>The HTTP response received from the server.</returns>
        public override Response UpdateStatus(CancellationToken cancellationToken = default) =>
            _operationInternal.UpdateStatus(cancellationToken);

        /// <summary>
        /// Updates the status of the long-running operation.
        /// </summary>
        /// <remarks>
        /// This operation will update the value returned by <see cref="GetRawResponse"/> and might also update
        /// <see cref="HasCompleted"/>, <see cref="HasValue"/>, and <see cref="Operation{T}.Value"/>.
        /// </remarks>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> controlling the lifetime of the request.</param>
        /// <returns>The HTTP response received from the server.</returns>
        public override async ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) =>
            await _operationInternal.UpdateStatusAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Monitors the status of the long-running operation until it completes.
        /// </summary>
        /// <remarks>
        /// This method will periodically call <see cref="UpdateStatusAsync"/> until <see cref="HasCompleted"/> is
        /// <c>true</c>. It will then return the final result of the operation.
        /// </remarks>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> controlling the lifetime of the request.</param>
        /// <returns>The HTTP response received from the server.</returns>
        public override async ValueTask<Response<AsyncPageable<AbstractiveSummarizeResultCollection>>> WaitForCompletionAsync(CancellationToken cancellationToken = default) =>
            await _operationInternal.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Monitors the status of the long-running operation until it completes.
        /// </summary>
        /// This method will periodically call <see cref="UpdateStatusAsync"/> until <see cref="HasCompleted"/> is
        /// <c>true</c>. It will then return the final result of the operation.
        /// <param name="pollingInterval">
        /// The interval between status requests sent to the server. Note that this behavior can be overriden by the
        /// server if it explicitly communicates to the client that it should wait a specific amount of time before
        /// polling again.
        /// </param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> controlling the lifetime of the request.</param>
        /// <returns>The HTTP response received from the server.</returns>
        public override async ValueTask<Response<AsyncPageable<AbstractiveSummarizeResultCollection>>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) =>
            await _operationInternal.WaitForCompletionAsync(pollingInterval, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Cancels the long-running operation, provided that it is still pending or running.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> controlling the lifetime of the request.</param>
        public virtual void Cancel(CancellationToken cancellationToken = default) =>
            _serviceClient.CancelAnalyzeActionsJob(_jobId, cancellationToken);

        /// <summary>
        /// Cancels the long-running operation, provided that it is still pending or running.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> controlling the lifetime of the request.</param>
        public virtual async Task CancelAsync(CancellationToken cancellationToken = default) =>
            await _serviceClient.CancelAnalyzeActionsJobAsync(_jobId, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Gets the final result of the long-running operation.
        /// </summary>
        /// <remarks>
        /// The operation must have completed successfully (i.e., <see cref="HasValue"/> is <c>true</c>).
        /// </remarks>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> controlling the lifetime of the request.</param>
        public override Pageable<AbstractiveSummarizeResultCollection> GetValues(CancellationToken cancellationToken = default)
        {
            // Validates that the operation has completed successfully.
            _ = _operationInternal.Value;

            Page<AbstractiveSummarizeResultCollection> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = _serviceClient.AnalyzeTextJobStatusNextPage(nextLink, pageSizeHint, _idToIndexMap, cancellationToken);
                return Page.FromValues(new List<AbstractiveSummarizeResultCollection>() { Transforms.ConvertToAbstractiveSummarizeResultCollection(response.Value, _idToIndexMap) }, response.Value.NextLink, response.GetRawResponse());
            }

            return PageableHelpers.CreateEnumerable(_ => _firstPage, NextPageFunc);
        }

        /// <summary>
        /// Gets the final result of the long-running operation.
        /// </summary>
        /// <remarks>
        /// The operation must have completed successfully (i.e., <see cref="HasValue"/> is <c>true</c>).
        /// </remarks>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> controlling the lifetime of the request.</param>
        public override AsyncPageable<AbstractiveSummarizeResultCollection> GetValuesAsync(CancellationToken cancellationToken = default)
        {
            // Validates that the operation has completed successfully.
            _ = _operationInternal.Value;
            return CreateOperationValueAsync(cancellationToken);
        }

        private AsyncPageable<AbstractiveSummarizeResultCollection> CreateOperationValueAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<AbstractiveSummarizeResultCollection>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = await _serviceClient.AnalyzeTextJobStatusNextPageAsync(nextLink, pageSizeHint, _idToIndexMap, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(new List<AbstractiveSummarizeResultCollection>() { Transforms.ConvertToAbstractiveSummarizeResultCollection(response.Value, _idToIndexMap) }, response.Value.NextLink, response.GetRawResponse());
            }

            return PageableHelpers.CreateAsyncEnumerable(_ => Task.FromResult(_firstPage), NextPageFunc);
        }

        async ValueTask<OperationState<AsyncPageable<AbstractiveSummarizeResultCollection>>> IOperation<AsyncPageable<AbstractiveSummarizeResultCollection>>.UpdateStateAsync(bool async, CancellationToken cancellationToken)
        {
            Response<AnalyzeTextJobState> response = async
                ? await _serviceClient.AnalyzeTextJobStatusAsync(_jobId, _showStats, null, null, _idToIndexMap, cancellationToken).ConfigureAwait(false)
                : _serviceClient.AnalyzeTextJobStatus(_jobId, _showStats, null, null, _idToIndexMap, cancellationToken);

            _displayName = response.Value.DisplayName;
            _createdOn = response.Value.CreatedDateTime;
            _expiresOn = response.Value.ExpirationDateTime;
            _lastModified = response.Value.LastUpdatedDateTime;
            _status = response.Value.Status;

            Response rawResponse = response.GetRawResponse();

            if (response.Value.Status == TextAnalyticsOperationStatus.Succeeded)
            {
                string nextLink = response.Value.NextLink;
                _firstPage = Page.FromValues(new List<AbstractiveSummarizeResultCollection>() { Transforms.ConvertToAbstractiveSummarizeResultCollection(response.Value, _idToIndexMap) }, nextLink, rawResponse);

                return OperationState<AsyncPageable<AbstractiveSummarizeResultCollection>>.Success(rawResponse, CreateOperationValueAsync(CancellationToken.None));
            }

            if (response.Value.Status == TextAnalyticsOperationStatus.Running || response.Value.Status == TextAnalyticsOperationStatus.NotStarted || response.Value.Status == TextAnalyticsOperationStatus.Cancelling)
            {
                return OperationState<AsyncPageable<AbstractiveSummarizeResultCollection>>.Pending(rawResponse);
            }

            if (response.Value.Status == TextAnalyticsOperationStatus.Cancelled)
            {
                return OperationState<AsyncPageable<AbstractiveSummarizeResultCollection>>.Failure(rawResponse, new RequestFailedException("The operation was canceled so no value is available."));
            }

            return OperationState<AsyncPageable<AbstractiveSummarizeResultCollection>>.Failure(rawResponse, new RequestFailedException(rawResponse));
        }

        // This method is never invoked since we don't override Operation<T>.GetRehydrationToken.
        RehydrationToken IOperation<AsyncPageable<AbstractiveSummarizeResultCollection>>.GetRehydrationToken() =>
            throw new NotSupportedException($"{nameof(GetRehydrationToken)} is not supported.");
    }
}
