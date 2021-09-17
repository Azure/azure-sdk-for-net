// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Analytics.Synapse.Spark.Models;

namespace Azure.Analytics.Synapse.Spark
{
    /// <summary>
    /// A long-running operation for:
    /// <see cref="SparkBatchClient.StartCreateSparkBatchJobAsync(SparkBatchJobOptions, bool?, CancellationToken)"/>,
    /// <see cref="SparkBatchClient.StartCreateSparkBatchJob(SparkBatchJobOptions, bool?, CancellationToken)"/>,
    /// </summary>
    public class SparkBatchOperation : Operation<SparkBatchJob>
    {
        private static readonly TimeSpan s_defaultPollingInterval = TimeSpan.FromSeconds(5);

        private readonly ClientDiagnostics _diagnostics;
        private readonly SparkBatchClient _client;
        private Response<SparkBatchJob> _response;
        private bool _completed;
        private RequestFailedException _requestFailedException;
        private readonly SparkBatchOperationCompletionType _completionType;

        internal SparkBatchOperation(SparkBatchClient client, ClientDiagnostics diagnostics, SparkBatchOperationCompletionType completionType, Response<SparkBatchJob> response)
        {
            _client = client;
            _response = response;
            _diagnostics = diagnostics;
            _completionType = completionType;
        }

        /// <summary> Initializes a new instance of <see cref="SparkBatchOperation" /> for mocking. </summary>
        protected SparkBatchOperation() {}

        /// <inheritdoc/>
        public override string Id => _response.Value.Id.ToString(CultureInfo.InvariantCulture);

        /// <summary>
        /// Gets the <see cref="SparkBatchJob"/>.
        /// You should await <see cref="WaitForCompletionAsync(CancellationToken)"/> before attempting to use session in this pending state.
        /// </summary>
        /// <remarks>
        /// Azure Synapse will return a <see cref="SparkBatchJob"/> immediately but may take time to the session to be ready.
        /// </remarks>
        public override SparkBatchJob Value
        {
            get
            {
#pragma warning disable CA1065 // Do not raise exceptions in unexpected locations
                if (!HasCompleted)
                {
                    throw new InvalidOperationException("The operation is not complete.");
                }
                if (_requestFailedException != null)
                {
                    throw _requestFailedException;
                }
#pragma warning restore CA1065 // Do not raise exceptions in unexpected locations
                return _response.Value;
            }
        }

        /// <inheritdoc/>
        public override bool HasCompleted => _completed;

        /// <inheritdoc/>
        public override bool HasValue => !_responseHasError && HasCompleted;

        private bool _responseHasError => StringComparer.OrdinalIgnoreCase.Equals ("error", _response?.Value?.State);

        /// <inheritdoc/>
        public override Response GetRawResponse() => _response.GetRawResponse();

        /// <inheritdoc/>
        public override Response UpdateStatus(CancellationToken cancellationToken = default) => UpdateStatusAsync(false, cancellationToken).EnsureCompleted();

        /// <inheritdoc/>
        public override async ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => await UpdateStatusAsync(true, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public override ValueTask<Response<SparkBatchJob>> WaitForCompletionAsync(CancellationToken cancellationToken = default) =>
            this.DefaultWaitForCompletionAsync(s_defaultPollingInterval, cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<SparkBatchJob>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken) =>
            this.DefaultWaitForCompletionAsync(pollingInterval, cancellationToken);

        private async ValueTask<Response> UpdateStatusAsync(bool async, CancellationToken cancellationToken)
        {
            if (!_completed)
            {
                using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(SparkSessionOperation)}.{nameof(UpdateStatus)}");
                scope.Start();

                try
                {
                    if (async)
                    {
                        _response = await _client.RestClient.GetSparkBatchJobAsync(_response.Value.Id, true, cancellationToken).ConfigureAwait(false);
                    }
                    else
                    {
                        _response = _client.RestClient.GetSparkBatchJob(_response.Value.Id, true, cancellationToken);
                    }
                    _completed = IsJobComplete(_response.Value.Result ?? SparkBatchJobResultType.Uncertain, _response.Value.State.Value, _completionType);
                }
                catch (RequestFailedException e)
                {
                    _requestFailedException = e;
                    scope.Failed(e);
                    throw;
                }
                catch (Exception e)
                {
                    _requestFailedException = new RequestFailedException("Unexpected failure", e);
                    scope.Failed(e);
                    throw _requestFailedException;
                }
                if (_responseHasError)
                {
                    _requestFailedException = new RequestFailedException("SparkBatchOperation ended in state: 'error'");
                    scope.Failed(_requestFailedException);
                    throw _requestFailedException;
                }
            }

            return GetRawResponse();
        }

        private static bool IsJobComplete(SparkBatchJobResultType jobState, LivyStates livyState, SparkBatchOperationCompletionType creationCompletionType)
        {
            if (jobState == SparkBatchJobResultType.Succeeded || jobState == SparkBatchJobResultType.Failed || jobState == SparkBatchJobResultType.Cancelled)
            {
                return true;
            }

            return creationCompletionType == SparkBatchOperationCompletionType.JobSubmission
                && (livyState == LivyStates.Starting
                || livyState == LivyStates.Running
                || livyState == LivyStates.Error
                || livyState == LivyStates.Dead
                || livyState == LivyStates.Success
                || livyState == LivyStates.Killed);
        }
    }
}
