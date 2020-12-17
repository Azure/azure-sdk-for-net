// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
    /// <see cref="SparkSessionClient.StartCreateSparkStatementAsync(int, SparkStatementOptions, CancellationToken)"/>,
    /// <see cref="SparkSessionClient.StartCreateSparkStatement(int, SparkStatementOptions, CancellationToken)"/>,
    /// <see cref="SparkSessionClient.StartGetSparkStatementAsync(int, int, CancellationToken)"/>,
    /// <see cref="SparkSessionClient.StartGetSparkStatement(int, int, CancellationToken)"/>
    /// </summary>
    public class SparkStatementOperation : Operation<SparkStatement>
    {
        private static readonly TimeSpan s_defaultPollingInterval = TimeSpan.FromSeconds(5);

        private readonly ClientDiagnostics _diagnostics;

        private int _sessionId;
        private readonly SparkSessionClient _client;
        private readonly SparkStatement _value;
        private Response<SparkStatement> _response;
        private bool _completed;

        internal SparkStatementOperation(SparkSessionClient client, ClientDiagnostics diagnostics, Response<SparkStatement> response, int sessionId)
        {
            _client = client;
            _value = response.Value ?? throw new InvalidOperationException("The response does not contain a value.");
            _response = response;
            _sessionId = sessionId;
            _completed = false;
            _diagnostics = diagnostics;
        }

        /// <inheritdoc/>
        public override string Id => _value.Id.ToString(CultureInfo.InvariantCulture);

        /// <summary>
        /// Gets the <see cref="SparkSession"/>.
        /// You should await <see cref="WaitForCompletionAsync(CancellationToken)"/> before attempting to use session in this pending state.
        /// </summary>
        /// <remarks>
        /// Azure Synapse will return a <see cref="SparkStatement"/> immediately but may take time to the session to be ready.
        /// </remarks>
        public override SparkStatement Value => _value;

        /// <inheritdoc/>
        public override bool HasCompleted => _completed;

        /// <inheritdoc/>
        public override bool HasValue => true;

        /// <inheritdoc/>
        public override Response GetRawResponse() => _response.GetRawResponse();

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
            if (!_completed)
            {
                using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(SparkStatementOperation)}.{nameof(UpdateStatus)}");
                scope.Start();

                try
                {
                    if (async)
                    {
                        _response = await _client.GetSparkStatementAsync(_sessionId, _value.Id, cancellationToken).ConfigureAwait(false);
                    }
                    else
                    {
                        _response = _client.GetSparkStatement(_sessionId, _value.Id, cancellationToken);
                    }
                    _completed = !IsJobRunning(_response.Value.State);
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return GetRawResponse();
        }

        private static List<string> ExecutingStates = new List<string>
        {
            "starting",
            "waiting",
            "running",
            "cancelling"
        };

        private static bool IsJobRunning(string livyState)
        {
            return ExecutingStates.Contains(livyState);
        }
    }
}
