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

        protected OperationInternalBase(ClientDiagnostics clientDiagnostics, Response rawResponse, string operationTypeName, IEnumerable<KeyValuePair<string, string>>? scopeAttributes = null, DelayStrategy? fallbackStrategy = null)
        {
            _diagnostics = clientDiagnostics;
            _updateStatusScopeName = $"{operationTypeName}.UpdateStatus";
            _scopeAttributes = scopeAttributes?.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            RawResponse = rawResponse;
            _fallbackStrategy = fallbackStrategy;
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
        public Response RawResponse { get; set; }

        /// <summary>
        /// Returns <c>true</c> if the long-running operation has completed.
        /// <example>Usage example:
        /// <code>
        ///   public bool HasCompleted => _operationInternal.HasCompleted;
        /// </code>
        /// </example>
        /// </summary>
        public bool HasCompleted { get; protected set; }

        protected RequestFailedException? OperationFailedException { get; private set; }

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
        public virtual async ValueTask<Response> WaitForCompletionResponseAsync(CancellationToken cancellationToken)
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
        public virtual async ValueTask<Response> WaitForCompletionResponseAsync(TimeSpan pollingInterval, CancellationToken cancellationToken)
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
        public virtual Response WaitForCompletionResponse(CancellationToken cancellationToken)
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
        public virtual Response WaitForCompletionResponse(TimeSpan pollingInterval, CancellationToken cancellationToken)
        {
            OperationPoller poller = new OperationPoller(_fallbackStrategy);
            return poller.WaitForCompletionResponse(UpdateStatus, () => HasCompleted, () => RawResponse, pollingInterval, cancellationToken);
        }

        private async ValueTask<Response> UpdateStatusAsync(bool async, CancellationToken cancellationToken)
        {
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
                return await UpdateStateAsync(async, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        protected async ValueTask<Response> ApplyStateAsync(bool async, Response response, bool hasCompleted, bool hasSucceeded, RequestFailedException? requestFailedException, bool throwIfFailed = true)
        {
            RawResponse = response;

            if (!hasCompleted)
            {
                return response;
            }

            HasCompleted = true;
            if (hasSucceeded)
            {
                return response;
            }

            OperationFailedException = requestFailedException ??
                (async
                    ? await _diagnostics.CreateRequestFailedExceptionAsync(response).ConfigureAwait(false)
                    : _diagnostics.CreateRequestFailedException(response));

            if (throwIfFailed)
            {
                throw OperationFailedException;
            }

            return response;
        }

        protected abstract ValueTask<Response> UpdateStateAsync(bool async, CancellationToken cancellationToken);
    }
}
