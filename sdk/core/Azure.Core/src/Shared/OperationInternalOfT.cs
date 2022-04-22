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

        private T? _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="OperationInternal{T}"/> class.
        /// </summary>
        /// <param name="clientDiagnostics">Used for diagnostic scope and exception creation. This is expected to be the instance created during the construction of your main client.</param>
        /// <param name="operation">The long-running operation making use of this class. Passing "<c>this</c>" is expected.</param>
        /// <param name="rawResponse">
        /// The initial value of <see cref="OperationInternalBase.RawResponse"/>. Usually, long-running operation objects can be instantiated in two ways:
        /// <list type="bullet">
        ///   <item>
        ///   When calling a client's "<c>Start&lt;OperationName&gt;</c>" method, a service call is made to start the operation, and an <see cref="Operation{T}"/> instance is returned.
        ///   In this case, the response received from this service call can be passed here.
        ///   </item>
        ///   <item>
        ///   When a user instantiates an <see cref="Operation{T}"/> directly using a public constructor, there's no previous service call. In this case, passing <c>null</c> is expected.
        ///   </item>
        /// </list>
        /// </param>
        /// <param name="operationTypeName">
        /// The type name of the long-running operation making use of this class. Used when creating diagnostic scopes. If left <c>null</c>, the type name will be inferred based on the
        /// parameter <paramref name="operation"/>.
        /// </param>
        /// <param name="scopeAttributes">The attributes to use during diagnostic scope creation.</param>
        public OperationInternal(ClientDiagnostics clientDiagnostics, IOperation<T> operation, Response rawResponse, string? operationTypeName = null, IEnumerable<KeyValuePair<string, string>>? scopeAttributes = null)
            : base(clientDiagnostics, rawResponse, operationTypeName ?? operation.GetType().Name, scopeAttributes)
        {
            _operation = operation;
            RawResponse = rawResponse;
        }

        /// <summary>
        /// Returns <c>true</c> if the long-running operation completed successfully and has produced a final result.
        /// <example>Usage example:
        /// <code>
        ///   public bool HasValue => _operationInternal.HasValue;
        /// </code>
        /// </example>
        /// </summary>
        public bool HasValue { get; private set; }

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
                if (HasValue)
                {
                    return _value!;
                }
                if (OperationFailedException != null)
                {
                    throw OperationFailedException;
                }
                throw new InvalidOperationException("The operation has not completed yet.");
            }
            private set
            {
                _value = value;
                HasValue = true;
            }
        }
        /// <summary>
        /// Periodically calls <see cref="OperationInternalBase.UpdateStatusAsync(CancellationToken)"/> until the long-running operation completes. The interval
        /// between calls is defined by the property <see cref="OperationInternalBase.DefaultPollingInterval"/>, but it can change based on information returned
        /// from the server. After each service call, a retry-after header may be returned to communicate that there is no reason to poll
        /// for status change until the specified time has passed. In this case, the maximum value between the <see cref="OperationInternalBase.DefaultPollingInterval"/>
        /// property and the retry-after header is chosen as the wait interval. Headers supported are: "Retry-After", "retry-after-ms",
        /// and "x-ms-retry-after-ms".
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
        public async ValueTask<Response<T>> WaitForCompletionAsync(CancellationToken cancellationToken) =>
            await WaitForCompletionAsync(DefaultPollingInterval, cancellationToken).ConfigureAwait(false);

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
        {
            var rawResponse = await WaitForCompletionResponseAsync(pollingInterval, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(Value, rawResponse);
        }

        /// <summary>
        /// Sets the <see cref="OperationInternal{T}"/> state immediately.
        /// </summary>
        /// <param name="state">The <see cref="OperationState{T}"/> used to set <see cref="OperationInternalBase.HasCompleted"/> and other members.</param>
        public void SetState(OperationState<T> state)
        {
            if (state.HasCompleted && state.HasSucceeded)
            {
                Value = state.Value!;
            }
            ApplyStateAsync(false, state.RawResponse, state.HasCompleted, state.HasSucceeded, state.OperationFailedException, throwIfFailed: false).EnsureCompleted();
        }

        protected override async ValueTask<Response> UpdateStateAsync(bool async, CancellationToken cancellationToken)
        {
            OperationState<T> state = await _operation.UpdateStateAsync(async, cancellationToken).ConfigureAwait(false);
            if (state.HasCompleted && state.HasSucceeded)
            {
                Value = state.Value!;
            }
            return await ApplyStateAsync(async, state.RawResponse, state.HasCompleted, state.HasSucceeded, state.OperationFailedException).ConfigureAwait(false);
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
            Argument.AssertNotNull(rawResponse, nameof(rawResponse));

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
            Argument.AssertNotNull(rawResponse, nameof(rawResponse));
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
            Argument.AssertNotNull(rawResponse, nameof(rawResponse));
            return new OperationState<T>(rawResponse, false, default, default, default);
        }
    }
}
