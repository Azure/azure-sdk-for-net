// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using System.Text.Json;

namespace Azure.Analytics.Synapse.Spark
{
    #pragma warning disable AZC0002

    /// <summary>
    /// A long-running operation for:
    /// <see cref="SparkBatchClient.StartCreateSparkBatchJobAsync(RequestContent, bool?, RequestOptions)"/>,
    /// <see cref="SparkBatchClient.StartCreateSparkBatchJob(RequestContent, bool?, RequestOptions)"/>,
    /// </summary>
    public class SparkBatchOperation : Operation<BinaryData>
    {
        private static readonly TimeSpan s_defaultPollingInterval = TimeSpan.FromSeconds(5);

        private readonly ClientDiagnostics _diagnostics;
        private readonly SparkBatchClient _client;
        private Response _response;
        private bool _completed;
        private RequestFailedException _requestFailedException;

        internal SparkBatchOperation(SparkBatchClient client, ClientDiagnostics diagnostics, Response response)
        {
            _client = client;
            _response = response;
            _diagnostics = diagnostics;
        }

        /// <summary> Initializes a new instance of <see cref="SparkBatchOperation" /> for mocking. </summary>
        protected SparkBatchOperation() {}

        /// <inheritdoc/>
        public override string Id => JsonDocument.Parse(_response.Content).RootElement.GetProperty(nameof(Id)).GetString();

        /// <summary>
        /// Gets the <see cref="Response"/>.
        /// You should await <see cref="WaitForCompletionAsync(CancellationToken)"/> before attempting to use session in this pending state.
        /// </summary>
        /// <remarks>
        /// Azure Synapse will return a <see cref="Response"/> immediately but may take time to the session to be ready.
        /// </remarks>
        public override BinaryData Value
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
                return _response.Content;
            }
        }

        /// <inheritdoc/>
        public override bool HasCompleted => _completed;

        /// <inheritdoc/>
        public override bool HasValue => !_responseHasError && HasCompleted;

        private bool _responseHasError => StringComparer.OrdinalIgnoreCase.Equals ("error", JsonDocument.Parse(_response.Content).RootElement.GetProperty("State").GetString());

        /// <inheritdoc/>
        public override Response GetRawResponse() => _response;

        /// <inheritdoc/>
        public override Response UpdateStatus(CancellationToken cancellationToken = default) => UpdateStatusAsync(false, cancellationToken).EnsureCompleted();

        /// <inheritdoc/>
        public override async ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => await UpdateStatusAsync(true, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public override ValueTask<Response<BinaryData>> WaitForCompletionAsync(CancellationToken cancellationToken = default) =>
            this.DefaultWaitForCompletionAsync(s_defaultPollingInterval, cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<BinaryData>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken) =>
            this.DefaultWaitForCompletionAsync(pollingInterval, cancellationToken);

        private async ValueTask<Response> UpdateStatusAsync(bool async, CancellationToken cancellationToken)
        {
            if (!_completed)
            {
                using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(SparkBatchOperation)}.{nameof(UpdateStatus)}");
                scope.Start();

                try
                {
                    int id = Int32.Parse(Id, CultureInfo.InvariantCulture);
                    if (async)
                    {
                        _response = await _client.GetSparkBatchJobAsync(id, true, new RequestOptions () { CancellationToken = cancellationToken }).ConfigureAwait(false);
                    }
                    else
                    {
                        _response = _client.GetSparkBatchJob(id, true, new RequestOptions () { CancellationToken = cancellationToken });
                    }
                    var doc = JsonDocument.Parse(_response.Content);
                    _completed = IsJobComplete(doc.RootElement.GetProperty("Result").GetString(), doc.RootElement.GetProperty("State").GetString());
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
                case "starting":
                case "error":
                case "dead":
                case "success":
                case "killed":
                    return true;
            }

            return false;
        }
    }

    #pragma warning restore AZC0002
}
