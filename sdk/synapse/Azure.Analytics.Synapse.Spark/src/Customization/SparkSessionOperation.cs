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
    /// </summary>
    public class SparkSessionOperation : Operation<SparkSession>
    {
        private static readonly TimeSpan s_defaultPollingInterval = TimeSpan.FromSeconds(5);

        private readonly ClientDiagnostics _diagnostics;

        private readonly SparkSessionClient _client;
        private readonly SparkSession _value;
        private Response<SparkSession> _response;
        private bool _completed;
        private RequestFailedException _requestFailedException;

        internal SparkSessionOperation(SparkSessionClient client, ClientDiagnostics diagnostics, Response<SparkSession> response)
        {
            _client = client;
            _value = response.Value ?? throw new InvalidOperationException("The response does not contain a value.");
            _response = response;
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
        public override SparkSession Value
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
                return _value;
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
                        _response = await _client.RestClient.GetSparkSessionAsync(_value.Id, true, cancellationToken).ConfigureAwait(false);
                    }
                    else
                    {
                        _response = _client.RestClient.GetSparkSession(_value.Id, true, cancellationToken);
                    }
                    _completed = IsJobComplete(_response.Value.Result.ToString(), _response.Value.State);
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
                    _requestFailedException = new RequestFailedException("SparkBatchOperation ended in state error");
                    scope.Failed(_requestFailedException);
                    throw _requestFailedException;
                }
            }

            return GetRawResponse();
        }

        private static bool IsJobComplete(string jobState, string livyState)
        {
            switch (jobState)
            {
                case "succeeded":
                case "failed":
                case "cancelled":
                    return true;
            }

            switch (livyState)
            {
                case "error":
                case "dead":
                case "success":
                case "killed":
                case "idle":
                    return true;
            }

            return false;
        }
    }
}
