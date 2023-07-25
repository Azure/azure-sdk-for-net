﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.TextAnalytics.Models;
using Azure.AI.TextAnalytics.ServiceClients;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.TextAnalytics
{
    /// <summary> Pageable operation class for analyzing multiple healthcare documents using long running operation. </summary>
    public class AnalyzeHealthcareEntitiesOperation : PageableOperation<AnalyzeHealthcareEntitiesResultCollection>, IOperation<AsyncPageable<AnalyzeHealthcareEntitiesResultCollection>>
    {
        internal readonly IDictionary<string, int> _idToIndexMap;

        private readonly bool? _showStats;
        private readonly string _jobId;
        private readonly ServiceClient _serviceClient;
        private readonly ClientDiagnostics _diagnostics;
        private readonly OperationInternal<AsyncPageable<AnalyzeHealthcareEntitiesResultCollection>> _operationInternal;

        private TextAnalyticsOperationStatus _status;
        private DateTimeOffset? _expiresOn;
        private DateTimeOffset _lastModified;
        private DateTimeOffset _createdOn;
        private string _displayName;
        private Page<AnalyzeHealthcareEntitiesResultCollection> _firstPage;

        /// <summary>
        /// Gets an ID representing the operation that can be used to poll for the status
        /// of the long-running operation.
        /// </summary>
        public override string Id { get; }

        /// <summary>
        /// Display Name of the operation.
        /// </summary>
        public virtual string DisplayName => _displayName;

        /// <summary>
        /// Time when the operation was created on.
        /// </summary>
        public virtual DateTimeOffset CreatedOn => _createdOn;

        /// <summary>
        /// Time when the operation will expire.
        /// </summary>
        public virtual DateTimeOffset? ExpiresOn => _expiresOn;

        /// <summary>
        /// Time when the operation was last modified on
        /// </summary>
        public virtual DateTimeOffset LastModified => _lastModified;

        /// <summary>
        /// Gets the status of the operation.
        /// </summary>
        public virtual TextAnalyticsOperationStatus Status => _status;

        /// <summary>
        /// Gets the final result of the long-running operation asynchronously.
        /// </summary>
        /// <remarks>
        /// This property can be accessed only after the operation completes successfully (HasValue is true).
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override AsyncPageable<AnalyzeHealthcareEntitiesResultCollection> Value => _operationInternal.Value;

        /// <summary>
        /// Returns true if the long-running operation completed.
        /// </summary>
        public override bool HasCompleted => _operationInternal.HasCompleted;

        /// <summary>
        /// Returns true if the long-running operation completed successfully and has produced final result (accessible by Value property).
        /// </summary>
        public override bool HasValue => _operationInternal.HasValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="AnalyzeHealthcareEntitiesOperation"/> class.
        /// </summary>
        /// <param name="operationId">The ID of this operation.</param>
        /// <param name="client">The client used to check for completion.</param>
        /// <exception cref="ArgumentException"><paramref name="operationId"/> is an empty string or does not represent a valid continuation token from the <see cref="Id"/> property returned on the original operation.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="operationId"/> or <paramref name="client"/> is null.</exception>
        public AnalyzeHealthcareEntitiesOperation(string operationId, TextAnalyticsClient client)
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
                throw new ArgumentException($"Invalid value. Please use the {nameof(AnalyzeHealthcareEntitiesOperation)}.{nameof(Id)} property value.", nameof(operationId), e);
            }

            Id = operationId;
            _serviceClient = client.ServiceClient;
            _diagnostics = _serviceClient.Diagnostics;
            _operationInternal = new(this, _diagnostics, rawResponse: null);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AnalyzeHealthcareEntitiesOperation"/> class.
        /// </summary>
        /// <param name="serviceClient">The client for communicating with the Text Analytics Azure Cognitive Service through its REST API.</param>
        /// <param name="diagnostics">The client diagnostics for exception creation in case of failure.</param>
        /// <param name="operationLocation">The address of the long-running operation. It can be obtained from the response headers upon starting the operation.</param>
        /// <param name="idToIndexMap"></param>
        /// <param name="showStats"></param>
        internal AnalyzeHealthcareEntitiesOperation(ServiceClient serviceClient, ClientDiagnostics diagnostics, string operationLocation, IDictionary<string, int> idToIndexMap, bool? showStats = default)
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
        /// Initializes a new instance of the <see cref="AnalyzeHealthcareEntitiesOperation"/> class. This constructor
        /// is intended to be used for mocking only.
        /// </summary>
        protected AnalyzeHealthcareEntitiesOperation()
        {
        }

        /// <summary>
        /// The last HTTP response received from the server.
        /// </summary>
        /// <remarks>
        /// The last response returned from the server during the lifecycle of this instance.
        /// An instance of <see cref="AnalyzeHealthcareEntitiesOperation"/> sends requests to a server in UpdateStatusAsync, UpdateStatus, and other methods.
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
        /// This method will periodically call UpdateStatusAsync till HasCompleted is true, then return the final result of the operation.
        /// </remarks>
        public override async ValueTask<Response<AsyncPageable<AnalyzeHealthcareEntitiesResultCollection>>> WaitForCompletionAsync(CancellationToken cancellationToken = default) =>
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
        public override async ValueTask<Response<AsyncPageable<AnalyzeHealthcareEntitiesResultCollection>>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) =>
            await _operationInternal.WaitForCompletionAsync(pollingInterval, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Cancels a pending or running <see cref="AnalyzeHealthcareEntitiesOperation"/>.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual void Cancel(CancellationToken cancellationToken = default) =>
            _serviceClient.CancelHealthcareJob(_jobId, cancellationToken);

        /// <summary>
        /// Cancels a pending or running <see cref="AnalyzeHealthcareEntitiesOperation"/>.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Task"/> to track the service request.</returns>
        public virtual async Task CancelAsync(CancellationToken cancellationToken = default) =>
            await _serviceClient.CancelHealthcareJobAsync(_jobId, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Gets the final result of the long-running operation asynchronously.
        /// </summary>
        /// <remarks>
        /// Operation must complete successfully (HasValue is true) for it to provide values.
        /// </remarks>
        public override AsyncPageable<AnalyzeHealthcareEntitiesResultCollection> GetValuesAsync(CancellationToken cancellationToken = default)
        {
            // Validates that the operation has completed successfully.
            _ = _operationInternal.Value;
            return CreateOperationValueAsync(cancellationToken);
        }

        /// <summary>
        /// Gets the final result of the long-running operation in synchronously.
        /// </summary>
        /// <remarks>
        /// Operation must complete successfully (HasValue is true) for it to provide values.
        /// </remarks>
        public override Pageable<AnalyzeHealthcareEntitiesResultCollection> GetValues(CancellationToken cancellationToken = default)
        {
            // Validates that the operation has completed successfully.
            _ = _operationInternal.Value;

            Page<AnalyzeHealthcareEntitiesResultCollection> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = _serviceClient.HealthStatusNextPage(nextLink, pageSizeHint, _idToIndexMap, cancellationToken);
                return Page.FromValues(new List<AnalyzeHealthcareEntitiesResultCollection>() { response.Value.Result }, response.Value.NextLink, response.GetRawResponse());
            }

            return PageableHelpers.CreateEnumerable(_ => _firstPage, NextPageFunc);
        }

        private AsyncPageable<AnalyzeHealthcareEntitiesResultCollection> CreateOperationValueAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<AnalyzeHealthcareEntitiesResultCollection>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = await _serviceClient.HealthStatusNextPageAsync(nextLink, pageSizeHint, _idToIndexMap, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(new List<AnalyzeHealthcareEntitiesResultCollection>() { response.Value.Result }, response.Value.NextLink, response.GetRawResponse());
            }

            return PageableHelpers.CreateAsyncEnumerable(_ => Task.FromResult(_firstPage), NextPageFunc);
        }

        async ValueTask<OperationState<AsyncPageable<AnalyzeHealthcareEntitiesResultCollection>>> IOperation<AsyncPageable<AnalyzeHealthcareEntitiesResultCollection>>.UpdateStateAsync(bool async, CancellationToken cancellationToken)
        {
            Response<HealthcareJobStatusResult> response = async
                ? await _serviceClient.HealthStatusAsync(_jobId, _showStats, null, null, _idToIndexMap, cancellationToken).ConfigureAwait(false)
                : _serviceClient.HealthStatus(_jobId, _showStats, null, null, _idToIndexMap, cancellationToken);

            _displayName = response.Value.DisplayName;
            _createdOn = response.Value.CreatedOn;
            _expiresOn = response.Value.ExpiresOn;
            _lastModified = response.Value.LastModifiedOn;
            _status = response.Value.Status;

            Response rawResponse = response.GetRawResponse();

            if (response.Value.Status == TextAnalyticsOperationStatus.Succeeded)
            {
                string nextLink = response.Value.NextLink;
                _firstPage = Page.FromValues(new List<AnalyzeHealthcareEntitiesResultCollection>() { response.Value.Result }, nextLink, rawResponse);

                return OperationState<AsyncPageable<AnalyzeHealthcareEntitiesResultCollection>>.Success(rawResponse, CreateOperationValueAsync(CancellationToken.None));
            }

            if (response.Value.Status == TextAnalyticsOperationStatus.Running || response.Value.Status == TextAnalyticsOperationStatus.NotStarted || response.Value.Status == TextAnalyticsOperationStatus.Cancelling)
            {
                return OperationState<AsyncPageable<AnalyzeHealthcareEntitiesResultCollection>>.Pending(rawResponse);
            }

            if (response.Value.Status == TextAnalyticsOperationStatus.Cancelled)
            {
                return OperationState<AsyncPageable<AnalyzeHealthcareEntitiesResultCollection>>.Failure(rawResponse, new RequestFailedException("The operation was canceled so no value is available."));
            }

            return OperationState<AsyncPageable<AnalyzeHealthcareEntitiesResultCollection>>.Failure(rawResponse, new RequestFailedException(rawResponse));
        }
    }
}
