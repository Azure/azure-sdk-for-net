// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    internal abstract class OperationInternalBase
    {
        private readonly ClientDiagnostics _diagnostics;
        private readonly IReadOnlyDictionary<string, string>? _scopeAttributes;
        private readonly Delay? _strategy;
        private readonly AsyncLockWithValue<Response> _responseLock;

        private readonly string _waitForCompletionResponseScopeName;
        protected readonly string _updateStatusScopeName;
        protected readonly string _waitForCompletionScopeName;

        protected OperationInternalBase(Response rawResponse)
        {
            _diagnostics = new ClientDiagnostics(ClientOptions.Default);
            _updateStatusScopeName = string.Empty;
            _waitForCompletionResponseScopeName = string.Empty;
            _waitForCompletionScopeName = string.Empty;
            _scopeAttributes = default;
            _strategy = default;
            _responseLock = new AsyncLockWithValue<Response>(rawResponse);
        }

        protected OperationInternalBase(ClientDiagnostics clientDiagnostics, string operationTypeName, IEnumerable<KeyValuePair<string, string>>? scopeAttributes = null, Delay? strategy = null)
        {
            _diagnostics = clientDiagnostics;
            _updateStatusScopeName = $"{operationTypeName}.{nameof(UpdateStatus)}";
            _waitForCompletionResponseScopeName = $"{operationTypeName}.{nameof(WaitForCompletionResponse)}";
            _waitForCompletionScopeName = $"{operationTypeName}.WaitForCompletion";
            _scopeAttributes = scopeAttributes?.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            _strategy = strategy;
            _responseLock = new AsyncLockWithValue<Response>();
        }

        /// <summary>
        /// The last HTTP response received from the server. Its update already handled in calls to "<c>UpdateStatus</c>" and
        /// "<c>WaitForCompletionAsync</c>", but custom methods not supported by this class, such as "<c>CancelOperation</c>",
        /// must update it as well.
        /// <example>Usage example:
        /// <code>
        ///   public Response GetRawResponse() => _operationInternal.RawResponse;
        /// </code>
        /// </example>
        /// </summary>
        public abstract Response RawResponse { get; }

        /// <summary>
        /// Returns <c>true</c> if the long-running operation has completed.
        /// <example>Usage example:
        /// <code>
        ///   public bool HasCompleted => _operationInternal.HasCompleted;
        /// </code>
        /// </example>
        /// </summary>
        public abstract bool HasCompleted { get; }

        /// <summary>
        /// Calls the server to get the latest status of the long-running operation, handling diagnostic scope creation for distributed
        /// tracing. The default scope name can be changed with the "<c>operationTypeName</c>" parameter passed to the constructor.
        /// <example>Usage example:
        /// <code>
        ///   public async ValueTask&lt;Response&gt; UpdateStatusAsync(CancellationToken cancellationToken) =>
        ///     await _operationInternal.UpdateStatusAsync(cancellationToken).ConfigureAwait(false);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The HTTP response received from the server.</returns>
        /// <remarks>
        /// After a successful run, this method will update <see cref="RawResponse"/> and might update <see cref="HasCompleted"/>.
        /// </remarks>
        /// <exception cref="RequestFailedException">Thrown if there's been any issues during the connection, or if the operation has completed with failures.</exception>
        public async ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken) =>
            await UpdateStatusAsync(async: true, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Calls the server to get the latest status of the long-running operation, handling diagnostic scope creation for distributed
        /// tracing. The default scope name can be changed with the "<c>operationTypeName</c>" parameter passed to the constructor.
        /// <example>Usage example:
        /// <code>
        ///   public Response UpdateStatus(CancellationToken cancellationToken) => _operationInternal.UpdateStatus(cancellationToken);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The HTTP response received from the server.</returns>
        /// <remarks>
        /// After a successful run, this method will update <see cref="RawResponse"/> and might update <see cref="HasCompleted"/>.
        /// </remarks>
        /// <exception cref="RequestFailedException">Thrown if there's been any issues during the connection, or if the operation has completed with failures.</exception>
        public Response UpdateStatus(CancellationToken cancellationToken) =>
            UpdateStatusAsync(async: false, cancellationToken).EnsureCompleted();

        /// <summary>
        /// Periodically calls <see cref="UpdateStatusAsync(CancellationToken)"/> until the long-running operation completes.
        /// After each service call, a retry-after header may be returned to communicate that there is no reason to poll
        /// for status change until the specified time has passed.  The maximum of the retry after value and the fallback <see cref="Delay"/>
        /// is then used as the wait interval.
        /// Headers supported are: "Retry-After", "retry-after-ms", and "x-ms-retry-after-ms",
        /// <example>Usage example:
        /// <code>
        ///   public async ValueTask&lt;Response&lt;T&gt;&gt; WaitForCompletionAsync(CancellationToken cancellationToken) =>
        ///     await _operationInternal.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The last HTTP response received from the server, including the final result of the long-running operation.</returns>
        /// <exception cref="RequestFailedException">Thrown if there's been any issues during the connection, or if the operation has completed with failures.</exception>
        public async ValueTask<Response> WaitForCompletionResponseAsync(CancellationToken cancellationToken)
            => await WaitForCompletionResponseAsync(async: true, null, _waitForCompletionResponseScopeName, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Periodically calls <see cref="UpdateStatusAsync(CancellationToken)"/> until the long-running operation completes. The interval
        /// between calls is defined by the parameter <paramref name="pollingInterval"/>, but it can change based on information returned
        /// from the server. After each service call, a retry-after header may be returned to communicate that there is no reason to poll
        /// for status change until the specified time has passed. In this case, the maximum value between the <paramref name="pollingInterval"/>
        /// parameter and the retry-after header is chosen as the wait interval. Headers supported are: "Retry-After", "retry-after-ms",
        /// and "x-ms-retry-after-ms".
        /// <example>Usage example:
        /// <code>
        ///   public async ValueTask&lt;Response&lt;T&gt;&gt; WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken) =>
        ///     await _operationInternal.WaitForCompletionAsync(pollingInterval, cancellationToken).ConfigureAwait(false);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="pollingInterval">The interval between status requests to the server. <strong></strong></param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The last HTTP response received from the server, including the final result of the long-running operation.</returns>
        /// <exception cref="RequestFailedException">Thrown if there's been any issues during the connection, or if the operation has completed with failures.</exception>
        public async ValueTask<Response> WaitForCompletionResponseAsync(TimeSpan pollingInterval, CancellationToken cancellationToken)
            => await WaitForCompletionResponseAsync(async: true, pollingInterval, _waitForCompletionResponseScopeName, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Periodically calls <see cref="UpdateStatus(CancellationToken)"/> until the long-running operation completes.
        /// After each service call, a retry-after header may be returned to communicate that there is no reason to poll
        /// for status change until the specified time has passed.  The maximum of the retry after value and the fallback <see cref="Delay"/>
        /// is then used as the wait interval.
        /// Headers supported are: "Retry-After", "retry-after-ms", and "x-ms-retry-after-ms",
        /// and "x-ms-retry-after-ms".
        /// <example>Usage example:
        /// <code>
        ///   public async ValueTask&lt;Response&lt;T&gt;&gt; WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken) =>
        ///     await _operationInternal.WaitForCompletionAsync(pollingInterval, cancellationToken).ConfigureAwait(false);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The last HTTP response received from the server, including the final result of the long-running operation.</returns>
        /// <exception cref="RequestFailedException">Thrown if there's been any issues during the connection, or if the operation has completed with failures.</exception>
        public Response WaitForCompletionResponse(CancellationToken cancellationToken)
            => WaitForCompletionResponseAsync(async: false, null, _waitForCompletionResponseScopeName, cancellationToken).EnsureCompleted();

        /// <summary>
        /// Periodically calls <see cref="UpdateStatus(CancellationToken)"/> until the long-running operation completes. The interval
        /// between calls is defined by the parameter <paramref name="pollingInterval"/>, but it can change based on information returned
        /// from the server. After each service call, a retry-after header may be returned to communicate that there is no reason to poll
        /// for status change until the specified time has passed. In this case, the maximum value between the <paramref name="pollingInterval"/>
        /// parameter and the retry-after header is chosen as the wait interval. Headers supported are: "Retry-After", "retry-after-ms",
        /// and "x-ms-retry-after-ms".
        /// <example>Usage example:
        /// <code>
        ///   public async ValueTask&lt;Response&lt;T&gt;&gt; WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken) =>
        ///     await _operationInternal.WaitForCompletionAsync(pollingInterval, cancellationToken).ConfigureAwait(false);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="pollingInterval">The interval between status requests to the server.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The last HTTP response received from the server, including the final result of the long-running operation.</returns>
        /// <exception cref="RequestFailedException">Thrown if there's been any issues during the connection, or if the operation has completed with failures.</exception>
        public Response WaitForCompletionResponse(TimeSpan pollingInterval, CancellationToken cancellationToken)
            => WaitForCompletionResponseAsync(async: false, pollingInterval, _waitForCompletionResponseScopeName, cancellationToken).EnsureCompleted();

        protected async ValueTask<Response> WaitForCompletionResponseAsync(bool async, TimeSpan? pollingInterval, string scopeName, CancellationToken cancellationToken)
        {
            // If _responseLock has the value, lockOrValue will contain that value, and no lock is acquired.
            // If _responseLock doesn't have the value, GetLockOrValueAsync will acquire the lock that will be released when lockOrValue is disposed
            using var lockOrValue = await _responseLock.GetLockOrValueAsync(async, cancellationToken).ConfigureAwait(false);
            if (lockOrValue.HasValue)
            {
                return lockOrValue.Value;
            }

            using var scope = CreateScope(scopeName);
            try
            {
                var poller = new OperationPoller(_strategy);
                var response = async
                    ? await poller.WaitForCompletionResponseAsync(this, pollingInterval, cancellationToken).ConfigureAwait(false)
                    : poller.WaitForCompletionResponse(this, pollingInterval, cancellationToken);

                lockOrValue.SetValue(response);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        protected abstract ValueTask<Response> UpdateStatusAsync(bool async, CancellationToken cancellationToken);

        protected DiagnosticScope CreateScope(string scopeName)
        {
            DiagnosticScope scope = _diagnostics.CreateScope(scopeName);

            if (_scopeAttributes != null)
            {
                foreach (KeyValuePair<string, string> attribute in _scopeAttributes)
                {
                    scope.AddAttribute(attribute.Key, attribute.Value);
                }
            }

            scope.Start();
            return scope;
        }

        protected async ValueTask<RequestFailedException> CreateException(bool async, Response response) => async
            ? await _diagnostics.CreateRequestFailedExceptionAsync(response).ConfigureAwait(false)
            : _diagnostics.CreateRequestFailedException(response);
    }
}
