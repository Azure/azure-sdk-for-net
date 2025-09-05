// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

#nullable enable

namespace Azure.Core
{
    /// <summary>
    /// A helper class used to build long-running operation instances. In order to use this helper:
    /// <list type="number">
    ///   <item>Make sure your LRO implements the <see cref="IOperation"/> interface.</item>
    ///   <item>Add a private <see cref="OperationInternal"/> field to your LRO, and instantiate it during construction.</item>
    ///   <item>Delegate method calls to the <see cref="OperationInternal"/> implementations.</item>
    /// </list>
    /// Supported members:
    /// <list type="bullet">
    ///   <item>
    ///     <description><see cref="OperationInternalBase.HasCompleted"/></description>
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
    ///     <description><see cref="OperationInternalBase.WaitForCompletionResponseAsync(CancellationToken)"/></description>
    ///   </item>
    ///   <item>
    ///     <description><see cref="OperationInternalBase.WaitForCompletionResponseAsync(TimeSpan, CancellationToken)"/></description>
    ///   </item>
    /// </list>
    /// </summary>
    internal class OperationInternal : OperationInternalBase
    {
        // To minimize code duplication and avoid introduction of another type,
        // OperationInternal delegates implementation to the OperationInternal<VoidValue>.
        // VoidValue is a private empty struct which only purpose is to be used as generic parameter.
        private readonly OperationInternal<VoidValue> _internalOperation;

        /// <summary>
        /// Initializes a new instance of the <see cref="OperationInternal"/> class in a final successful state.
        /// </summary>
        /// <param name="rawResponse">The final value of <see cref="OperationInternalBase.RawResponse"/>.</param>
        public static OperationInternal Succeeded(Response rawResponse) => new(OperationState.Success(rawResponse));

        /// <summary>
        /// Initializes a new instance of the <see cref="OperationInternal"/> class in a final failed state.
        /// </summary>
        /// <param name="rawResponse">The final value of <see cref="OperationInternalBase.RawResponse"/>.</param>
        /// <param name="operationFailedException">The exception that will be thrown by <c>UpdateStatusAsync</c>.</param>
        public static OperationInternal Failed(Response rawResponse, RequestFailedException operationFailedException) => new(OperationState.Failure(rawResponse, operationFailedException));

        /// <summary>
        /// Initializes a new instance of the <see cref="OperationInternal"/> class.
        /// </summary>
        /// <param name="operation">The long-running operation making use of this class. Passing "<c>this</c>" is expected.</param>
        /// <param name="clientDiagnostics">Used for diagnostic scope and exception creation. This is expected to be the instance created during the construction of your main client.</param>
        /// <param name="rawResponse">
        ///     The initial value of <see cref="OperationInternalBase.RawResponse"/>. Usually, long-running operation objects can be instantiated in two ways:
        ///     <list type="bullet">
        ///         <item>
        ///             When calling a client's "<c>Start&lt;OperationName&gt;</c>" method, a service call is made to start the operation, and an <see cref="Operation"/> instance is returned.
        ///             In this case, the response received from this service call can be passed here.
        ///         </item>
        ///         <item>
        ///             When a user instantiates an <see cref="Operation"/> directly using a public constructor, there's no previous service call. In this case, passing <c>null</c> is expected.
        ///         </item>
        ///     </list>
        /// </param>
        /// <param name="operationTypeName">
        ///     The type name of the long-running operation making use of this class. Used when creating diagnostic scopes. If left <c>null</c>, the type name will be inferred based on the
        ///     parameter <paramref name="operation"/>.
        /// </param>
        /// <param name="scopeAttributes">The attributes to use during diagnostic scope creation.</param>
        /// <param name="fallbackStrategy"> The delay strategy to use. Default is <see cref="FixedDelayWithNoJitterStrategy"/>.</param>
        public OperationInternal(IOperation operation,
            ClientDiagnostics clientDiagnostics,
            Response rawResponse,
            string? operationTypeName = null,
            IEnumerable<KeyValuePair<string, string>>? scopeAttributes = null,
            DelayStrategy? fallbackStrategy = null)
            : base(clientDiagnostics, operationTypeName ?? operation.GetType().Name, scopeAttributes, fallbackStrategy)
        {
            _internalOperation = new OperationInternal<VoidValue>(new OperationToOperationOfTProxy(operation), clientDiagnostics, rawResponse, operationTypeName ?? operation.GetType().Name, scopeAttributes, fallbackStrategy);
        }

        internal OperationInternal(OperationState finalState)
            : base(finalState.RawResponse)
        {
            _internalOperation = finalState.HasSucceeded
                ? OperationInternal<VoidValue>.Succeeded(finalState.RawResponse, default)
                : OperationInternal<VoidValue>.Failed(finalState.RawResponse, finalState.OperationFailedException!);
        }

        public override Response RawResponse => _internalOperation.RawResponse;

        public override bool HasCompleted => _internalOperation.HasCompleted;

        protected override async ValueTask<Response> UpdateStatusAsync(bool async, CancellationToken cancellationToken) =>
            async ? await _internalOperation.UpdateStatusAsync(cancellationToken).ConfigureAwait(false) : _internalOperation.UpdateStatus(cancellationToken);

        // Wrapper type that converts OperationState to OperationState<T> and can be passed to `OperationInternal<T>` constructor.
        private class OperationToOperationOfTProxy : IOperation<VoidValue>
        {
            private readonly IOperation _operation;

            public OperationToOperationOfTProxy(IOperation operation)
            {
                _operation = operation;
            }

            public RehydrationToken GetRehydrationToken() => _operation.GetRehydrationToken();

            public async ValueTask<OperationState<VoidValue>> UpdateStateAsync(bool async, CancellationToken cancellationToken)
            {
                var state = await _operation.UpdateStateAsync(async, cancellationToken).ConfigureAwait(false);
                if (!state.HasCompleted)
                {
                    return OperationState<VoidValue>.Pending(state.RawResponse);
                }

                if (state.HasSucceeded)
                {
                    return OperationState<VoidValue>.Success(state.RawResponse, new VoidValue());
                }

                return OperationState<VoidValue>.Failure(state.RawResponse, state.OperationFailedException);
            }
        }
    }

    /// <summary>
    /// An interface used by <see cref="OperationInternal"/> for making service calls and updating state. It's expected that
    /// your long-running operation classes implement this interface.
    /// </summary>
    internal interface IOperation
    {
        /// <summary>
        /// Calls the service and updates the state of the long-running operation. Properties directly handled by the
        /// <see cref="OperationInternal"/> class, such as <see cref="OperationInternalBase.RawResponse"/>
        /// don't need to be updated. Operation-specific properties, such as "<c>CreateOn</c>" or "<c>LastModified</c>",
        /// must be manually updated by the operation implementing this method.
        /// <example>Usage example:
        /// <code>
        ///   async ValueTask&lt;OperationState&gt; IOperation.UpdateStateAsync(bool async, CancellationToken cancellationToken)<br/>
        ///   {<br/>
        ///     Response&lt;R&gt; response = async ? &lt;async service call&gt; : &lt;sync service call&gt;;<br/>
        ///     if (&lt;operation succeeded&gt;) return OperationState.Success(response.GetRawResponse(), &lt;parse response&gt;);<br/>
        ///     if (&lt;operation failed&gt;) return OperationState.Failure(response.GetRawResponse());<br/>
        ///     return OperationState.Pending(response.GetRawResponse());<br/>
        ///   }
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="async"><c>true</c> if the call should be executed asynchronously. Otherwise, <c>false</c>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A structure indicating the current operation state. The <see cref="OperationState"/> structure must be instantiated by one of
        /// its static methods:
        /// <list type="bullet">
        ///   <item>Use <see cref="OperationState.Success"/> when the operation has completed successfully.</item>
        ///   <item>Use <see cref="OperationState.Failure"/> when the operation has completed with failures.</item>
        ///   <item>Use <see cref="OperationState.Pending"/> when the operation has not completed yet.</item>
        /// </list>
        /// </returns>
        ValueTask<OperationState> UpdateStateAsync(bool async, CancellationToken cancellationToken);

        /// <summary>
        /// Get a token that can be used to rehydrate the operation.
        /// </summary>
        RehydrationToken GetRehydrationToken();
    }

    /// <summary>
    /// A helper structure passed to <see cref="OperationInternal"/> to indicate the current operation state. This structure must be
    /// instantiated by one of its static methods, depending on the operation state:
    /// <list type="bullet">
    ///   <item>Use <see cref="OperationState.Success"/> when the operation has completed successfully.</item>
    ///   <item>Use <see cref="OperationState.Failure"/> when the operation has completed with failures.</item>
    ///   <item>Use <see cref="OperationState.Pending"/> when the operation has not completed yet.</item>
    /// </list>
    /// </summary>
    internal readonly struct OperationState
    {
        private OperationState(Response rawResponse, bool hasCompleted, bool hasSucceeded, RequestFailedException? operationFailedException)
        {
            RawResponse = rawResponse;
            HasCompleted = hasCompleted;
            HasSucceeded = hasSucceeded;
            OperationFailedException = operationFailedException;
        }

        public Response RawResponse { get; }

        public bool HasCompleted { get; }

        public bool HasSucceeded { get; }

        public RequestFailedException? OperationFailedException { get; }

        /// <summary>
        /// Instantiates an <see cref="OperationState"/> indicating the operation has completed successfully.
        /// </summary>
        /// <param name="rawResponse">The HTTP response obtained during the status update.</param>
        /// <returns>A new <see cref="OperationState"/> instance.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="rawResponse"/> is <c>null</c>.</exception>
        public static OperationState Success(Response rawResponse)
        {
            if (rawResponse is null)
            {
                throw new ArgumentNullException(nameof(rawResponse));
            }

            return new OperationState(rawResponse, true, true, default);
        }

        /// <summary>
        /// Instantiates an <see cref="OperationState"/> indicating the operation has completed with failures.
        /// </summary>
        /// <param name="rawResponse">The HTTP response obtained during the status update.</param>
        /// <param name="operationFailedException">
        /// The exception to throw from <c>UpdateStatus</c> because of the operation failure. If left <c>null</c>,
        /// a default exception is created based on the <paramref name="rawResponse"/> parameter.
        /// </param>
        /// <returns>A new <see cref="OperationState"/> instance.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="rawResponse"/> is <c>null</c>.</exception>
        public static OperationState Failure(Response rawResponse, RequestFailedException? operationFailedException = null)
        {
            if (rawResponse is null)
            {
                throw new ArgumentNullException(nameof(rawResponse));
            }

            return new OperationState(rawResponse, true, false, operationFailedException);
        }

        /// <summary>
        /// Instantiates an <see cref="OperationState"/> indicating the operation has not completed yet.
        /// </summary>
        /// <param name="rawResponse">The HTTP response obtained during the status update.</param>
        /// <returns>A new <see cref="OperationState"/> instance.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="rawResponse"/> is <c>null</c>.</exception>
        public static OperationState Pending(Response rawResponse)
        {
            if (rawResponse is null)
            {
                throw new ArgumentNullException(nameof(rawResponse));
            }

            return new OperationState(rawResponse, false, default, default);
        }
    }
}
