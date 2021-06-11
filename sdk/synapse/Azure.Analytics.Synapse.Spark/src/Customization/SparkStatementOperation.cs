// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Analytics.Synapse.Spark
{
    /// <summary>
    /// A long-running operation for:
    /// <see cref="SparkSessionClient.StartCreateSparkStatementAsync(int, RequestContent, RequestOptions)"/>,
    /// <see cref="SparkSessionClient.StartCreateSparkStatement(int, RequestContent, RequestOptions)"/>,
    /// </summary>
    public class SparkStatementOperation : Operation<BinaryData>
    {
        private static readonly TimeSpan s_defaultPollingInterval = TimeSpan.FromSeconds(5);

        private readonly ClientDiagnostics _diagnostics;

        private int _sessionId;
        private readonly SparkSessionClient _client;
        private Response _response;
        private bool _completed;
        private RequestFailedException _requestFailedException;

        internal SparkStatementOperation(SparkSessionClient client, ClientDiagnostics diagnostics, Response response, int sessionId)
        {
            _client = client;
            _response = response;
            _sessionId = sessionId;
            _diagnostics = diagnostics;
        }

        /// <summary> Initializes a new instance of <see cref="SparkStatementOperation" /> for mocking. </summary>
        protected SparkStatementOperation() {}

        /// <inheritdoc/>
        public override string Id => JsonDocument.Parse(_response.Content).RootElement.GetProperty(nameof(Id)).GetString();

        /// <summary>
        /// Gets the <see cref="BinaryData"/>.
        /// You should await <see cref="WaitForCompletionAsync(CancellationToken)"/> before attempting to use session in this pending state.
        /// </summary>
        /// <remarks>
        /// Azure Synapse will return a <see cref="BinaryData"/> immediately but may take time to the session to be ready.
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
                using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(SparkStatementOperation)}.{nameof(UpdateStatus)}");
                scope.Start();

                try
                {
                    int id = Int32.Parse(Id, CultureInfo.InvariantCulture);
                    if (async)
                    {
                        _response = await _client.GetSparkStatementAsync(_sessionId, id, new RequestOptions () { CancellationToken = cancellationToken }).ConfigureAwait(false);
                    }
                    else
                    {
                        _response = _client.GetSparkStatement(_sessionId, id, new RequestOptions () { CancellationToken = cancellationToken });
                    }
                    var doc = JsonDocument.Parse(_response.Content);
                    _completed = IsJobComplete(doc.RootElement.GetProperty("State").GetString());
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

        private static bool IsJobComplete(string livyState)
        {
            switch (livyState)
            {
                case "starting":
                case "waiting":
                case "running":
                case "cancelling":
                    return false;
            };
            return true;
        }
    }
}
