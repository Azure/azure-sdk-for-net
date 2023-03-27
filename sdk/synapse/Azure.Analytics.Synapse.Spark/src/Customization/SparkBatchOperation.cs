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
    /// A long-running operation for spark batch operation.
    /// </summary>
    public class SparkBatchOperation : Operation<SparkBatchJob>
    {
        private static readonly TimeSpan s_defaultPollingInterval = TimeSpan.FromSeconds(5);

        /// <summary>
        /// Provides tools for exception creation in case of failure.
        /// </summary>
        private readonly ClientDiagnostics _diagnostics;

        /// <summary>
        /// Get the completion type of Spark batch job operation.
        /// </summary>
        private readonly SparkBatchOperationCompletionType _completionType;

        /// <summary>
        /// The client used to check for completion.
        /// </summary>
        private readonly SparkBatchClient _client;

        /// <summary>
        /// Whether the operation has completed.
        /// </summary>
        private bool _hasCompleted;

        /// <summary>
        /// Gets the created Spark batch job.
        /// </summary>
        private SparkBatchJob _value;

        /// <summary>
        /// Raw HTTP response.
        /// </summary>
        private Response _rawResponse;

        /// <summary>
        /// <c>true</c> if the long-running operation has a value. Otherwise, <c>false</c>.
        /// </summary>
        private bool _hasValue;

        /// <summary>
        /// Gets the Id of the created Spark batch job.
        /// </summary>
        private int _batchId;

        /// <summary>
        /// Gets a value indicating whether the operation has completed.
        /// </summary>
        public override bool HasCompleted => _hasCompleted;

        /// <inheritdoc/>
        public override bool HasValue => _hasValue;

        /// <inheritdoc/>
        public override string Id => _batchId.ToString(CultureInfo.InvariantCulture);

        /// <summary>
        /// Gets the <see cref="SparkBatchJob"/>.
        /// You should await <see cref="WaitForCompletionAsync(CancellationToken)"/> before attempting to use session in this pending state.
        /// </summary>
        /// <remarks>
        /// Azure Synapse will return a <see cref="SparkBatchJob"/> immediately but may take time to the session to be ready.
        /// </remarks>
        public override SparkBatchJob Value => OperationHelpers.GetValue(ref _value);

        /// <summary>
        /// Get the completion type of Spark batch job operation.
        /// </summary>
        public SparkBatchOperationCompletionType CompletionType => _completionType;

        /// <summary>
        /// Initializes a new instance of the <see cref="SparkBatchOperation"/> class.
        /// </summary>
        /// <param name="batchId">The ID of the Spark batch job.</param>
        /// <param name="client">The client used to check for completion.</param>
        /// <param name="completionType">The operation completion type.</param>
        public SparkBatchOperation(int batchId, SparkBatchClient client, SparkBatchOperationCompletionType completionType = SparkBatchOperationCompletionType.JobSubmission)
        {
            _batchId = batchId;
            _client = client;
            _completionType = completionType;
        }

        internal SparkBatchOperation(SparkBatchClient client, ClientDiagnostics diagnostics, Response<SparkBatchJob> response, SparkBatchOperationCompletionType completionType)
            : this(response.Value.Id, client, completionType)
        {
            _diagnostics = diagnostics;
            _rawResponse = response.GetRawResponse();
        }

        /// <summary> Initializes a new instance of <see cref="SparkBatchOperation" /> for mocking. </summary>
        protected SparkBatchOperation() {}

        /// <inheritdoc/>
        public override Response GetRawResponse() => _rawResponse;

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
            if (!_hasCompleted)
            {
                using DiagnosticScope? scope = _diagnostics?.CreateScope($"{nameof(SparkSessionOperation)}.{nameof(UpdateStatus)}");
                scope?.Start();

                try
                {
                    // Get the latest status
                    Response<SparkBatchJob> update = async
                        ? await _client.GetSparkBatchJobAsync(_batchId, true, cancellationToken).ConfigureAwait(false)
                        : _client.GetSparkBatchJob(_batchId, true, cancellationToken);

                    // Check if the operation is no longer running
                    _hasCompleted = IsJobComplete(update.Value.Result ?? SparkBatchJobResultType.Uncertain, update.Value.State.Value, _completionType);
                    if (_hasCompleted)
                    {
                        _hasValue = true;
                        _value = update.Value;
                    }

                    // Update raw response
                    _rawResponse = update.GetRawResponse();
                }
                catch (Exception e)
                {
                    scope?.Failed(e);
                    throw;
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
