// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    /// <summary>
    /// A helper class used to build long-running operation instances. In order to use this helper:
    /// <list type="number">
    ///   <item>Make sure your LRO implements the <see cref="IOperation{T}"/> interface.</item>
    ///   <item>Add a private <see cref="OperationInternal{T}"/> field to your LRO, and instantiate it during construction.</item>
    ///   <item>Delegate method calls to the <see cref="OperationInternal{T}"/> implementations.</item>
    /// </list>
    /// Supported members:
    /// <list type="bullet">
    ///   <item>
    ///     <description><see cref="HasValue"/></description>
    ///   </item>
    ///   <item>
    ///     <description><see cref="OperationInternalBase.HasCompleted"/></description>
    ///   </item>
    ///   <item>
    ///     <description><see cref="Value"/></description>
    ///   </item>
    ///   <item>
    ///     <description><see cref="OperationInternalBase.RawResponse"/>, used for <see cref="Operation.GetRawResponse"/></description>
    ///   </item>
    ///   <item>
    ///     <description><see cref="OperationInternalBase.UpdateStatus"/></description>
    ///   </item>
    ///   <item>
    ///     <description><see cref="OperationInternalBase.UpdateStatusAsync(CancellationToken)"/></description>
    ///   </item>
    ///   <item>
    ///     <description><see cref="WaitForCompletionAsync(CancellationToken)"/></description>
    ///   </item>
    ///   <item>
    ///     <description><see cref="WaitForCompletionAsync(TimeSpan, CancellationToken)"/></description>
    ///   </item>
    /// </list>
    /// </summary>
    /// <typeparam name="T">The final result of the long-running operation. Must match the type used in <see cref="Operation{T}"/>.</typeparam>
#pragma warning disable SA1649 // File name should match first type name
    internal class OperationInternal<T> : OperationInternalBase
#pragma warning restore SA1649
    {
        private readonly IOperation<T> _operation;
        private readonly AsyncLockWithValue<OperationState<T>> _stateLock;
        private Response _rawResponse;

        /// <summary>
        /// Initializes a new instance of the <see cref="OperationInternal"/> class in a final successful state.
        /// </summary>
        /// <param name="rawResponse">The final value of <see cref="OperationInternalBase.RawResponse"/>.</param>
        /// <param name="value">The final result of the long-running operation.</param>
        public static OperationInternal<T> Succeeded(Response rawResponse, T value) => new(OperationState<T>.Success(rawResponse, value));

        /// <summary>
        /// Initializes a new instance of the <see cref="OperationInternal"/> class in a final failed state.
        /// </summary>
        /// <param name="rawResponse">The final value of <see cref="OperationInternalBase.RawResponse"/>.</param>
        /// <param name="operationFailedException">The exception that will be thrown by <c>UpdateStatusAsync</c>.</param>
        public static OperationInternal<T> Failed(Response rawResponse, RequestFailedException operationFailedException) => new(OperationState<T>.Failure(rawResponse, operationFailedException));

        /// <summary>
        /// Initializes a new instance of the <see cref="OperationInternal{T}"/> class.
        /// </summary>
        /// <param name="operation">The long-running operation making use of this class. Passing "<c>this</c>" is expected.</param>
        /// <param name="clientDiagnostics">Used for diagnostic scope and exception creation. This is expected to be the instance created during the construction of your main client.</param>
        /// <param name="rawResponse">
        ///     The initial value of <see cref="OperationInternalBase.RawResponse"/>. Usually, long-running operation objects can be instantiated in two ways:
        ///     <list type="bullet">
        ///         <item>
        ///             When calling a client's "<c>Start&lt;OperationName&gt;</c>" method, a service call is made to start the operation, and an <see cref="Operation{T}"/> instance is returned.
        ///             In this case, the response received from this service call can be passed here.
        ///         </item>
        ///         <item>
        ///             When a user instantiates an <see cref="Operation{T}"/> directly using a public constructor, there's no previous service call. In this case, passing <c>null</c> is expected.
        ///         </item>
        ///     </list>
        /// </param>
        /// <param name="operationTypeName">
        ///     The type name of the long-running operation making use of this class. Used when creating diagnostic scopes. If left <c>null</c>, the type name will be inferred based on the
        ///     parameter <paramref name="operation"/>.
        /// </param>
        /// <param name="scopeAttributes">The attributes to use during diagnostic scope creation.</param>
        /// <param name="fallbackStrategy">The delay strategy when Retry-After header is not present.  When it is present, the longer of the two delays will be used.
        ///     Default is <see cref="FixedDelayWithNoJitterStrategy"/>.</param>
        public OperationInternal(IOperation<T> operation,
            ClientDiagnostics clientDiagnostics,
            Response rawResponse,
            string? operationTypeName = null,
            IEnumerable<KeyValuePair<string, string>>? scopeAttributes = null,
            DelayStrategy? fallbackStrategy = null)
            : base(clientDiagnostics, operationTypeName ?? operation.GetType().Name, scopeAttributes, fallbackStrategy)
        {
            _operation = operation;
            _rawResponse = rawResponse;
            _stateLock = new AsyncLockWithValue<OperationState<T>>();
        }

        internal OperationInternal(OperationState<T> finalState)
            : base(finalState.RawResponse)
        {
            // FinalOperation represents operation that is in final state and can't be updated.
            // It implements IOperation<T> and throws exception when UpdateStateAsync is called.
            _operation = new FinalOperation();
            _rawResponse = finalState.RawResponse;
            _stateLock = new AsyncLockWithValue<OperationState<T>>(finalState);
        }

        public override Response RawResponse => _stateLock.TryGetValue(out var state) ? state.RawResponse : _rawResponse;

        public override bool HasCompleted => _stateLock.HasValue;

        /// <summary>
        /// Returns <c>true</c> if the long-running operation completed successfully and has produced a final result.
        /// <example>Usage example:
        /// <code>
        ///   public bool HasValue => _operationInternal.HasValue;
        /// </code>
        /// </example>
        /// </summary>
        public bool HasValue => _stateLock.TryGetValue(out var state) && state.HasSucceeded;

        /// <summary>
        /// The final result of the long-running operation.
        /// <example>Usage example:
        /// <code>
        ///   public T Value => _operationInternal.Value;
        /// </code>
        /// </example>
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when the operation has not completed yet.</exception>
        /// <exception cref="RequestFailedException">Thrown when the operation has completed with failures.</exception>
        public T Value
        {
            get
            {
                if (_stateLock.TryGetValue(out var state))
                {
                    if (state.HasSucceeded)
                    {
                        return state.Value!;
                    }

                    throw state.OperationFailedException!;
                }

                throw new InvalidOperationException("The operation has not completed yet.");
            }
        }
        /// <summary>
        /// Periodically calls <see cref="OperationInternalBase.UpdateStatusAsync(CancellationToken)"/> until the long-running operation completes.
        /// After each service call, a retry-after header may be returned to communicate that there is no reason to poll
        /// for status change until the specified time has passed.
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
        public async ValueTask<Response<T>> WaitForCompletionAsync(CancellationToken cancellationToken)
            => await WaitForCompletionAsync(async: true, null, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Periodically calls <see cref="OperationInternalBase.UpdateStatusAsync(CancellationToken)"/> until the long-running operation completes. The interval
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
        public async ValueTask<Response<T>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken)
            => await WaitForCompletionAsync(async: true, pollingInterval, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Periodically calls <see cref="OperationInternalBase.UpdateStatus(CancellationToken)"/> until the long-running operation completes.
        /// After each service call, a retry-after header may be returned to communicate that there is no reason to poll
        /// for status change until the specified time has passed.
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
        public Response<T> WaitForCompletion(CancellationToken cancellationToken)
            => WaitForCompletionAsync(async: false, null, cancellationToken).EnsureCompleted();

        /// <summary>
        /// Periodically calls <see cref="OperationInternalBase.UpdateStatus(CancellationToken)"/> until the long-running operation completes. The interval
        /// between calls is defined by the <see cref="FixedDelayWithNoJitterStrategy"/>, which takes into account any retry-after header that is returned
        /// from the server.
        /// <example>Usage example:
        /// <code>
        ///   public async ValueTask&lt;Response&lt;T&gt;&gt; WaitForCompletionAsync(CancellationToken cancellationToken) =>
        ///     await _operationInternal.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="pollingInterval">The interval between status requests to the server.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The last HTTP response received from the server, including the final result of the long-running operation.</returns>
        /// <exception cref="RequestFailedException">Thrown if there's been any issues during the connection, or if the operation has completed with failures.</exception>
        public Response<T> WaitForCompletion(TimeSpan pollingInterval, CancellationToken cancellationToken)
            => WaitForCompletionAsync(async: false, pollingInterval, cancellationToken).EnsureCompleted();

        private async ValueTask<Response<T>> WaitForCompletionAsync(bool async, TimeSpan? pollingInterval, CancellationToken cancellationToken)
        {
            var rawResponse = await WaitForCompletionResponseAsync(async, pollingInterval, _waitForCompletionScopeName, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(Value, rawResponse);
        }

        protected override async ValueTask<Response> UpdateStatusAsync(bool async, CancellationToken cancellationToken)
        {
            // If _stateLock has the final state, lockOrValue will contain that state, and no lock is acquired.
            // If _stateLock doesn't have the state, GetLockOrValueAsync will acquire the lock that will be released when lockOrValue is disposed
            // While _responseLock is used for the whole WaitForCompletionResponseAsync, _stateLock is used for individual calls of UpdateStatusAsync
            using var asyncLock = await _stateLock.GetLockOrValueAsync(async, cancellationToken).ConfigureAwait(false);
            if (asyncLock.HasValue)
            {
                return GetResponseFromState(asyncLock.Value);
            }

            using var scope = CreateScope(_updateStatusScopeName);
            try
            {
                var state = await _operation.UpdateStateAsync(async, cancellationToken).ConfigureAwait(false);
                if (!state.HasCompleted)
                {
                    Interlocked.Exchange(ref _rawResponse, state.RawResponse);
                    return state.RawResponse;
                }

                if (!state.HasSucceeded && state.OperationFailedException == null)
                {
                    state = OperationState<T>.Failure(state.RawResponse, new RequestFailedException(state.RawResponse));
                }

                asyncLock.SetValue(state);
                return GetResponseFromState(state);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private static Response GetResponseFromState(OperationState<T> state)
        {
            if (state.HasSucceeded)
            {
                return state.RawResponse;
            }

            throw state.OperationFailedException!;
        }

        private class FinalOperation : IOperation<T>
        {
            public ValueTask<OperationState<T>> UpdateStateAsync(bool async, CancellationToken cancellationToken)
                => throw new NotSupportedException("The operation has already completed");

            // Unreachable path. _operation.GetRehydrationToken() is never invoked.
            public RehydrationToken GetRehydrationToken()
                => throw new NotSupportedException($"Getting the rehydration token of a {nameof(FinalOperation)} is not supported");
        }
    }

    /// <summary>
    /// An interface used by <see cref="OperationInternal{T}"/> for making service calls and updating state. It's expected that
    /// your long-running operation classes implement this interface.
    /// </summary>
    /// <typeparam name="T">The final result of the long-running operation. Must match the type used in <see cref="Operation{T}"/>.</typeparam>
    internal interface IOperation<T>
    {
        /// <summary>
        /// Calls the service and updates the state of the long-running operation. Properties directly handled by the
        /// <see cref="OperationInternal{T}"/> class, such as <see cref="OperationInternalBase.RawResponse"/> or
        /// <see cref="OperationInternal{T}.Value"/>, don't need to be updated. Operation-specific properties, such
        /// as "<c>CreateOn</c>" or "<c>LastModified</c>", must be manually updated by the operation implementing this
        /// method.
        /// <example>Usage example:
        /// <code>
        ///   async ValueTask&lt;OperationState&lt;T&gt;&gt; IOperation&lt;T&gt;.UpdateStateAsync(bool async, CancellationToken cancellationToken)<br/>
        ///   {<br/>
        ///     Response&lt;R&gt; response = async ? &lt;async service call&gt; : &lt;sync service call&gt;;<br/>
        ///     if (&lt;operation succeeded&gt;) return OperationState&lt;T&gt;.Success(response.GetRawResponse(), &lt;parse response&gt;);<br/>
        ///     if (&lt;operation failed&gt;) return OperationState&lt;T&gt;.Failure(response.GetRawResponse());<br/>
        ///     return OperationState&lt;T&gt;.Pending(response.GetRawResponse());<br/>
        ///   }
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="async"><c>true</c> if the call should be executed asynchronously. Otherwise, <c>false</c>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A structure indicating the current operation state. The <see cref="OperationState{T}"/> structure must be instantiated by one of
        /// its static methods:
        /// <list type="bullet">
        ///   <item>Use <see cref="OperationState{T}.Success"/> when the operation has completed successfully.</item>
        ///   <item>Use <see cref="OperationState{T}.Failure"/> when the operation has completed with failures.</item>
        ///   <item>Use <see cref="OperationState{T}.Pending"/> when the operation has not completed yet.</item>
        /// </list>
        /// </returns>
        ValueTask<OperationState<T>> UpdateStateAsync(bool async, CancellationToken cancellationToken);

        /// <summary>
        /// Get a token that can be used to rehydrate the operation.
        /// </summary>
        RehydrationToken GetRehydrationToken();
    }

    /// <summary>
    /// A helper structure passed to <see cref="OperationInternal{T}"/> to indicate the current operation state. This structure must be
    /// instantiated by one of its static methods, depending on the operation state:
    /// <list type="bullet">
    ///   <item>Use <see cref="OperationState{T}.Success"/> when the operation has completed successfully.</item>
    ///   <item>Use <see cref="OperationState{T}.Failure"/> when the operation has completed with failures.</item>
    ///   <item>Use <see cref="OperationState{T}.Pending"/> when the operation has not completed yet.</item>
    /// </list>
    /// </summary>
    /// <typeparam name="T">The final result of the long-running operation. Must match the type used in <see cref="Operation{T}"/>.</typeparam>
    internal readonly struct OperationState<T>
    {
        private OperationState(Response rawResponse, bool hasCompleted, bool hasSucceeded, T? value, RequestFailedException? operationFailedException)
        {
            RawResponse = rawResponse;
            HasCompleted = hasCompleted;
            HasSucceeded = hasSucceeded;
            Value = value;
            OperationFailedException = operationFailedException;
        }

        public Response RawResponse { get; }

        public bool HasCompleted { get; }

        public bool HasSucceeded { get; }

        public T? Value { get; }

        public RequestFailedException? OperationFailedException { get; }

        /// <summary>
        /// Instantiates an <see cref="OperationState{T}"/> indicating the operation has completed successfully.
        /// </summary>
        /// <param name="rawResponse">The HTTP response obtained during the status update.</param>
        /// <param name="value">The final result of the long-running operation.</param>
        /// <returns>A new <see cref="OperationState{T}"/> instance.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="rawResponse"/> or <paramref name="value"/> is <c>null</c>.</exception>
        public static OperationState<T> Success(Response rawResponse, T value)
        {
            if (rawResponse is null)
            {
                throw new ArgumentNullException(nameof(rawResponse));
            }
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return new OperationState<T>(rawResponse, true, true, value, default);
        }

        /// <summary>
        /// Instantiates an <see cref="OperationState{T}"/> indicating the operation has completed with failures.
        /// </summary>
        /// <param name="rawResponse">The HTTP response obtained during the status update.</param>
        /// <param name="operationFailedException">
        /// The exception to throw from <c>UpdateStatus</c> because of the operation failure. The same exception will be thrown when
        /// <see cref="OperationInternal{T}.Value"/> is called. If left <c>null</c>, a default exception is created based on the
        /// <paramref name="rawResponse"/> parameter.
        /// </param>
        /// <returns>A new <see cref="OperationState{T}"/> instance.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="rawResponse"/> is <c>null</c>.</exception>
        public static OperationState<T> Failure(Response rawResponse, RequestFailedException? operationFailedException = null)
        {
            if (rawResponse is null)
            {
                throw new ArgumentNullException(nameof(rawResponse));
            }

            return new OperationState<T>(rawResponse, true, false, default, operationFailedException);
        }

        /// <summary>
        /// Instantiates an <see cref="OperationState{T}"/> indicating the operation has not completed yet.
        /// </summary>
        /// <param name="rawResponse">The HTTP response obtained during the status update.</param>
        /// <returns>A new <see cref="OperationState{T}"/> instance.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="rawResponse"/> is <c>null</c>.</exception>
        public static OperationState<T> Pending(Response rawResponse)
        {
            if (rawResponse is null)
            {
                throw new ArgumentNullException(nameof(rawResponse));
            }

            return new OperationState<T>(rawResponse, false, default, default, default);
        }
    }
}
