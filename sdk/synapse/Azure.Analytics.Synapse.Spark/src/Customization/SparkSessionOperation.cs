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
    /// <see cref="SparkSessionClient.StartCreateSparkSession(SparkSessionOptions, bool?, CancellationToken)"/>,
    /// <see cref="SparkSessionClient.StartCreateSparkSessionAsync(SparkSessionOptions, bool?, CancellationToken)"/>,
    /// <see cref="SparkSessionClient.StartGetSparkSession(int, bool?, CancellationToken)"/>,
    /// <see cref="SparkSessionClient.StartGetSparkSessionAsync(int, bool?, CancellationToken)"/>
    /// </summary>
    public class SparkSessionOperation : Operation<SparkSession>
    {
        private static readonly TimeSpan s_defaultPollingInterval = TimeSpan.FromSeconds(5);

        private readonly ClientDiagnostics _diagnostics;

        private readonly SparkSessionClient _client;
        private readonly SparkSession _value;
        private Response<SparkSession> _response;
        private bool _completed;

        internal SparkSessionOperation(SparkSessionClient client, ClientDiagnostics diagnostics, Response<SparkSession> response)
        {
            _client = client;
            _value = response.Value ?? throw new InvalidOperationException("The response does not contain a value.");
            _response = response;
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
        /// Azure Synapse will return a <see cref="SparkSession"/> immediately but may take time to the session to be ready.
        /// </remarks>
        public override SparkSession Value => _value;

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
        public override ValueTask<Response<SparkSession>> WaitForCompletionAsync(CancellationToken cancellationToken = default) =>
            this.DefaultWaitForCompletionAsync(s_defaultPollingInterval, cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<SparkSession>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken) =>
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
                        _response = await _client.GetSparkSessionAsync(_value.Id, true, cancellationToken).ConfigureAwait(false);
                    }
                    else
                    {
                        _response = _client.GetSparkSession(_value.Id, true, cancellationToken);
                    }
                    _completed = !IsJobRunning(_response.Value.Result.ToString(), _response.Value.State);
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return GetRawResponse();
        }

        private static List<string> SessionSubmissionFinalStates = new List<string>
        {
            "idle",
            "error",
            "dead",
            "success",
            "killed"
        };

        private static bool IsJobRunning(string jobState, string livyState)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals ("Succeeded", jobState) ||
                StringComparer.OrdinalIgnoreCase.Equals ("Failed", jobState) ||
                StringComparer.OrdinalIgnoreCase.Equals ("Cancelled", jobState))
            {
                return false;
            }

            return !SessionSubmissionFinalStates.Contains(livyState);
        }
    }
}
