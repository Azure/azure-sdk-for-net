// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

#nullable enable

namespace Azure.Core
{
    internal abstract class OperationInternalBase
    {
        private readonly ClientDiagnostics _diagnostics;
        private readonly string _updateStatusScopeName;
        private readonly IReadOnlyDictionary<string, string>? _scopeAttributes;
        private readonly DelayStrategy? _fallbackStrategy;
        private readonly AsyncLockWithValue<OperationState> _operationStateLock;

        protected bool HasSucceeded => _operationStateLock.TryGetValue(out OperationState state) && state.HasSucceeded;

        protected RequestFailedException? OperationFailedException => _operationStateLock.TryGetValue(out var state)
            ? state.OperationFailedException
            : default;

        protected OperationInternalBase(ClientDiagnostics clientDiagnostics, Response rawResponse, string operationTypeName, IEnumerable<KeyValuePair<string, string>>? scopeAttributes = null, DelayStrategy? fallbackStrategy = null, OperationState? finalState = null)
        {
            _diagnostics = clientDiagnostics;
            _updateStatusScopeName = $"{operationTypeName}.UpdateStatus";
            RawResponse = rawResponse;

            if (finalState != null)
            {
                _operationStateLock = new AsyncLockWithValue<OperationState>(finalState.Value);
            }
            else
            {
                _scopeAttributes = scopeAttributes?.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
                _fallbackStrategy = fallbackStrategy;
                _operationStateLock = new AsyncLockWithValue<OperationState>();
            }
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
        public Response RawResponse { get; private set; }

        /// <summary>
        /// Returns <c>true</c> if the long-running operation has completed.
        /// <example>Usage example:
        /// <code>
        ///   public bool HasCompleted => _operationInternal.HasCompleted;
        /// </code>
        /// </example>
        /// </summary>
        public bool HasCompleted => _operationStateLock.HasValue;

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
        /// for status change until the specified time has passed.  The maximum of the retry after value and the fallback <see cref="DelayStrategy"/>
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
        {
            OperationPoller poller = new OperationPoller(_fallbackStrategy);
            return await poller.WaitForCompletionResponseAsync(UpdateStatusAsync, () => HasCompleted, () => RawResponse, null, cancellationToken).ConfigureAwait(false);
        }

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
        {
            OperationPoller poller = new OperationPoller(_fallbackStrategy);
            return await poller.WaitForCompletionResponseAsync(UpdateStatusAsync, () => HasCompleted, () => RawResponse, pollingInterval, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Periodically calls <see cref="UpdateStatus(CancellationToken)"/> until the long-running operation completes.
        /// After each service call, a retry-after header may be returned to communicate that there is no reason to poll
        /// for status change until the specified time has passed.  The maximum of the retry after value and the fallback <see cref="DelayStrategy"/>
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
        {
            OperationPoller poller = new OperationPoller(_fallbackStrategy);
            return poller.WaitForCompletionResponse(UpdateStatus, () => HasCompleted, () => RawResponse, null, cancellationToken);
        }

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
        {
            OperationPoller poller = new OperationPoller(_fallbackStrategy);
            return poller.WaitForCompletionResponse(UpdateStatus, () => HasCompleted, () => RawResponse, pollingInterval, cancellationToken);
        }

        public bool TrySetPendingResponse(Response response, CancellationToken cancellationToken)
            => TrySetPendingResponseAsync(false, response, cancellationToken).EnsureCompleted();

        public async ValueTask<bool> TrySetPendingResponseAsync(Response response, CancellationToken cancellationToken)
            => await TrySetPendingResponseAsync(true, response, cancellationToken).ConfigureAwait(false);

        private async ValueTask<bool> TrySetPendingResponseAsync(bool async, Response response, CancellationToken cancellationToken)
        {
            using var asyncLock = await _operationStateLock.GetLockOrValueAsync(async, cancellationToken).ConfigureAwait(false);
            if (asyncLock.HasValue)
            {
                return false;
            }

            RawResponse = response;
            return true;
        }

        private async ValueTask<Response> UpdateStatusAsync(bool async, CancellationToken cancellationToken)
        {
            using var asyncLock = await _operationStateLock.GetLockOrValueAsync(async, cancellationToken).ConfigureAwait(false);
            if (asyncLock.HasValue)
            {
                return asyncLock.Value.RawResponse;
            }

            using DiagnosticScope scope = _diagnostics.CreateScope(_updateStatusScopeName);

            if (_scopeAttributes != null)
            {
                foreach (KeyValuePair<string, string> attribute in _scopeAttributes)
                {
                    scope.AddAttribute(attribute.Key, attribute.Value);
                }
            }

            scope.Start();

            try
            {
                var state = await UpdateStateAsync(async, cancellationToken).ConfigureAwait(false);
                RawResponse = state.RawResponse;
                if (!state.HasCompleted)
                {
                    return state.RawResponse;
                }

                if (!state.HasSucceeded && state.OperationFailedException == null)
                {
                    var exception = async
                        ? await _diagnostics.CreateRequestFailedExceptionAsync(state.RawResponse).ConfigureAwait(false)
                        : _diagnostics.CreateRequestFailedException(state.RawResponse);
                    state = OperationState.Failure(state.RawResponse, exception);
                }

                asyncLock.SetValue(state);

                if (state.OperationFailedException != null)
                {
                    throw state.OperationFailedException;
                }

                return state.RawResponse;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        protected abstract ValueTask<OperationState> UpdateStateAsync(bool async, CancellationToken cancellationToken);
    }
}
