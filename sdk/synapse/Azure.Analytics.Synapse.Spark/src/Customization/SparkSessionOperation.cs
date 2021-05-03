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
    /// <see cref="SparkSessionClient.StartCreateSparkSession(SparkSessionOptions, bool?, CancellationToken)"/>,
    /// <see cref="SparkSessionClient.StartCreateSparkSessionAsync(SparkSessionOptions, bool?, CancellationToken)"/>,
    /// </summary>
    public class SparkSessionOperation : Operation<SparkSession>, IOperation<SparkSession, SparkSession>
    {
        private static readonly TimeSpan s_defaultPollingInterval = TimeSpan.FromSeconds(5);

        private readonly OperationInternal<SparkSession, SparkSession> _operationInternal;
        private readonly SparkSessionClient _client;
        private readonly SparkSession _value;

        internal SparkSessionOperation(SparkSessionClient client, ClientDiagnostics diagnostics, Response<SparkSession> response)
        {
            _client = client;
            _value = response.Value ?? throw new InvalidOperationException("The response does not contain a value.");
            _operationInternal = new(diagnostics, this)
            {
                DefaultPollingInterval = s_defaultPollingInterval,
                RawResponse = response.GetRawResponse()
            };
        }

        /// <summary> Initializes a new instance of <see cref="SparkSessionOperation" /> for mocking. </summary>
        protected SparkSessionOperation() {}

        /// <inheritdoc/>
        public override string Id => _value.Id.ToString(CultureInfo.InvariantCulture);

        /// <summary>
        /// Gets the <see cref="SparkSession"/>.
        /// You should await <see cref="WaitForCompletionAsync(CancellationToken)"/> before attempting to use session in this pending state.
        /// </summary>
        /// <remarks>
        /// Azure Synapse will return a <see cref="SparkSession"/> immediately but may take time to the session to be ready.
        /// </remarks>
        public override SparkSession Value => _operationInternal.Value;

        /// <inheritdoc/>
        public override bool HasCompleted => _operationInternal.HasCompleted;

        /// <inheritdoc/>
        public override bool HasValue => _operationInternal.HasValue;

        /// <inheritdoc/>
        public override Response GetRawResponse() => _operationInternal.RawResponse;

        /// <inheritdoc/>
        public override Response UpdateStatus(CancellationToken cancellationToken = default) =>
            _operationInternal.UpdateStatus(cancellationToken);

        /// <inheritdoc/>
        public override async ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) =>
            await _operationInternal.UpdateStatusAsync(cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public override async ValueTask<Response<SparkSession>> WaitForCompletionAsync(CancellationToken cancellationToken = default) =>
            await _operationInternal.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public override async ValueTask<Response<SparkSession>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken) =>
            await _operationInternal.WaitForCompletionAsync(pollingInterval, cancellationToken).ConfigureAwait(false);

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

        async Task<Response<SparkSession>> IOperation<SparkSession, SparkSession>.GetResponseAsync(CancellationToken cancellationToken) =>
            await _client.RestClient.GetSparkSessionAsync(_value.Id, true, cancellationToken).ConfigureAwait(false);

        Response<SparkSession> IOperation<SparkSession, SparkSession>.GetResponse(CancellationToken cancellationToken) =>
            _client.RestClient.GetSparkSession(_value.Id, true, cancellationToken);

        OperationState<SparkSession> IOperation<SparkSession, SparkSession>.UpdateState(Response<SparkSession> response)
        {
            if (IsJobComplete(response.Value.Result.ToString(), response.Value.State))
            {
                if (StringComparer.OrdinalIgnoreCase.Equals("error", response?.Value?.State))
                {
                    return OperationState<SparkSession>.Failure(new RequestFailedException("SparkBatchOperation ended in state error"));
                }
                else
                {
                    return OperationState<SparkSession>.Success(_value);
                }
            }

            return default;
        }
    }
}
