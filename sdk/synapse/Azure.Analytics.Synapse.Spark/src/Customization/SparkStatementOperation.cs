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
    /// A long-running operation for CreateSparkStatement
    /// </summary>
    public class SparkStatementOperation : Operation<SparkStatement>
    {
        private static readonly TimeSpan s_defaultPollingInterval = TimeSpan.FromSeconds(5);

        /// <summary>
        /// Provides tools for exception creation in case of failure.
        /// </summary>
        private readonly ClientDiagnostics _diagnostics;

        /// <summary>
        /// The client used to check for completion.
        /// </summary>
        private readonly SparkSessionClient _client;

        /// <summary>
        /// Whether the operation has completed.
        /// </summary>
        private bool _hasCompleted;

        /// <summary>
        /// Gets the created Spark statement.
        /// </summary>
        private SparkStatement _value;

        /// <summary>
        /// Raw HTTP response.
        /// </summary>
        private Response _rawResponse;

        /// <summary>
        /// <c>true</c> if the long-running operation has a value. Otherwise, <c>false</c>.
        /// </summary>
        private bool _hasValue;

        /// <summary>
        /// Gets the Id of the Spark session where the statement executes.
        /// </summary>
        private int _sessionId;

        /// <summary>
        /// Gets the Id of the created Spark statement.
        /// </summary>
        private int _statementId;

        /// <summary>
        /// Gets a value indicating whether the operation has completed.
        /// </summary>
        public override bool HasCompleted => _hasCompleted;

        /// <inheritdoc/>
        public override bool HasValue => _hasValue;

        /// <inheritdoc/>
        public override string Id => _statementId.ToString(CultureInfo.InvariantCulture);

        /// <summary>
        /// Gets the <see cref="SparkStatement"/>.
        /// You should await <see cref="WaitForCompletionAsync(CancellationToken)"/> before attempting to use session in this pending state.
        /// </summary>
        /// <remarks>
        /// Azure Synapse will return a <see cref="SparkStatement"/> immediately but may take time to the statement to be ready.
        /// </remarks>
        public override SparkStatement Value => OperationHelpers.GetValue(ref _value);

        /// <summary>
        /// Initializes a new instance of the <see cref="SparkStatementOperation"/> class.
        /// </summary>
        /// <param name="sessionId">The ID of the Spark session where the statement executes.</param>
        /// <param name="statementId">The ID of the Spark statement.</param>
        /// <param name="client">The client used to check for completion.</param>
        public SparkStatementOperation(int sessionId, int statementId, SparkSessionClient client)
        {
            _sessionId = sessionId;
            _statementId = statementId;
            _client = client;
        }

        internal SparkStatementOperation(SparkSessionClient client, ClientDiagnostics diagnostics, Response<SparkStatement> response, int sessionId)
            : this(sessionId, response.Value.Id, client)
        {
            _rawResponse = response.GetRawResponse();
            _diagnostics = diagnostics;
        }

        /// <summary> Initializes a new instance of <see cref="SparkStatementOperation" /> for mocking. </summary>
        protected SparkStatementOperation() {}

        /// <inheritdoc/>
        public override Response GetRawResponse() => _rawResponse;

        /// <inheritdoc/>
        public override Response UpdateStatus(CancellationToken cancellationToken = default) => UpdateStatusAsync(false, cancellationToken).EnsureCompleted();

        /// <inheritdoc/>
        public override async ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => await UpdateStatusAsync(true, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public override ValueTask<Response<SparkStatement>> WaitForCompletionAsync(CancellationToken cancellationToken = default) =>
            this.DefaultWaitForCompletionAsync(s_defaultPollingInterval, cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<SparkStatement>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken) =>
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
                    Response<SparkStatement> update = async
                        ? await _client.GetSparkStatementAsync(_sessionId, _statementId, cancellationToken).ConfigureAwait(false)
                        : _client.GetSparkStatement(_sessionId, _statementId, cancellationToken);

                    // Check if the operation is no longer running
                    _hasCompleted = IsJobComplete(update.Value.State.Value);
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

        private static bool IsJobComplete(LivyStatementStates livyState)
        {
            return livyState == LivyStatementStates.Available || livyState == LivyStatementStates.Error || livyState == LivyStatementStates.Cancelled;
        }
    }
}
