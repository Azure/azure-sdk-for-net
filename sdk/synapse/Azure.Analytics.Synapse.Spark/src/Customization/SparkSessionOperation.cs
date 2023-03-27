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
    /// A long-running operation for spark session operation.
    /// </summary>
    public class SparkSessionOperation : Operation<SparkSession>
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
        /// Gets the created Spark session.
        /// </summary>
        private SparkSession _value;

        /// <summary>
        /// Raw HTTP response.
        /// </summary>
        private Response _rawResponse;

        /// <summary>
        /// <c>true</c> if the long-running operation has a value. Otherwise, <c>false</c>.
        /// </summary>
        private bool _hasValue;

        /// <summary>
        /// Gets the Id of the created Spark session.
        /// </summary>
        private int _sessionId;

        /// <summary>
        /// Gets a value indicating whether the operation has completed.
        /// </summary>
        public override bool HasCompleted => _hasCompleted;

        /// <inheritdoc/>
        public override bool HasValue => _hasValue;

        /// <inheritdoc/>
        public override string Id => _sessionId.ToString(CultureInfo.InvariantCulture);

        /// <summary>
        /// Gets the <see cref="SparkSession"/>.
        /// You should await <see cref="WaitForCompletionAsync(CancellationToken)"/> before attempting to use session in this pending state.
        /// </summary>
        /// <remarks>
        /// Azure Synapse will return a <see cref="SparkSession"/> immediately but may take time to the session to be ready.
        /// </remarks>
        public override SparkSession Value => OperationHelpers.GetValue(ref _value);

        /// <summary>
        /// Initializes a new instance of the <see cref="SparkSessionOperation"/> class.
        /// </summary>
        /// <param name="sessionId">The ID of the Spark session.</param>
        /// <param name="client">The client used to check for completion.</param>
        public SparkSessionOperation(int sessionId, SparkSessionClient client)
        {
            _sessionId = sessionId;
            _client = client;
        }

        internal SparkSessionOperation(SparkSessionClient client, ClientDiagnostics diagnostics, Response<SparkSession> response)
            : this(response.Value.Id, client)
        {
            _rawResponse = response.GetRawResponse();
            _diagnostics = diagnostics;
        }

        /// <summary> Initializes a new instance of <see cref="SparkSessionOperation" /> for mocking. </summary>
        protected SparkSessionOperation() {}

        /// <inheritdoc/>
        public override Response GetRawResponse() => _rawResponse;

        /// <inheritdoc/>
        public override Response UpdateStatus(CancellationToken cancellationToken = default) => UpdateStatusAsync(false, cancellationToken).EnsureCompleted();

        /// <inheritdoc/>
        public override async ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => await UpdateStatusAsync(true, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public override ValueTask<Response<SparkSession>> WaitForCompletionAsync(CancellationToken cancellationToken = default) =>
            this.DefaultWaitForCompletionAsync(s_defaultPollingInterval, cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<SparkSession>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken) =>
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
                    Response<SparkSession> update = async
                        ? await _client.GetSparkSessionAsync(_sessionId, true, cancellationToken).ConfigureAwait(false)
                        : _client.GetSparkSession(_sessionId, true, cancellationToken);

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

        private static bool IsJobComplete(LivyStates livyState)
        {
            if (livyState == LivyStates.Error || livyState == LivyStates.Dead || livyState == LivyStates.Success || livyState == LivyStates.Killed || livyState == LivyStates.Idle)
            {
                return true;
            }

            return false;
        }
    }
}
