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
        private readonly IOperation _operation;

        /// <summary>
        /// Initializes a new instance of the <see cref="OperationInternal"/> class.
        /// </summary>
        /// <param name="clientDiagnostics">Used for diagnostic scope and exception creation. This is expected to be the instance created during the construction of your main client.</param>
        /// <param name="operation">The long-running operation making use of this class. Passing "<c>this</c>" is expected.</param>
        /// <param name="rawResponse">
        /// The initial value of <see cref="OperationInternalBase.RawResponse"/>. Usually, long-running operation objects can be instantiated in two ways:
        /// <list type="bullet">
        ///   <item>
        ///   When calling a client's "<c>Start&lt;OperationName&gt;</c>" method, a service call is made to start the operation, and an <see cref="Operation"/> instance is returned.
        ///   In this case, the response received from this service call can be passed here.
        ///   </item>
        ///   <item>
        ///   When a user instantiates an <see cref="Operation"/> directly using a public constructor, there's no previous service call. In this case, passing <c>null</c> is expected.
        ///   </item>
        /// </list>
        /// </param>
        /// <param name="operationTypeName">
        /// The type name of the long-running operation making use of this class. Used when creating diagnostic scopes. If left <c>null</c>, the type name will be inferred based on the
        /// parameter <paramref name="operation"/>.
        /// </param>
        /// <param name="scopeAttributes">The attributes to use during diagnostic scope creation.</param>
        public OperationInternal(
            ClientDiagnostics clientDiagnostics,
            IOperation operation,
            Response rawResponse,
            string? operationTypeName = null,
            IEnumerable<KeyValuePair<string, string>>? scopeAttributes = null)
            :base(clientDiagnostics, rawResponse, operationTypeName ?? operation.GetType().Name, scopeAttributes)
        {
            _operation = operation;
        }

        /// <summary>
        /// Sets the <see cref="OperationInternal"/> state immediately.
        /// </summary>
        /// <param name="state">The <see cref="OperationState"/> used to set <see cref="OperationInternalBase.HasCompleted"/> and other members.</param>
        public void SetState(OperationState state)
        {
            ApplyStateAsync(false, state.RawResponse, state.HasCompleted, state.HasSucceeded, state.OperationFailedException, throwIfFailed: false).EnsureCompleted();
        }

        protected override async ValueTask<Response> UpdateStateAsync(bool async, CancellationToken cancellationToken)
        {
            OperationState state = await _operation.UpdateStateAsync(async, cancellationToken).ConfigureAwait(false);
            return await ApplyStateAsync(async, state.RawResponse, state.HasCompleted, state.HasSucceeded, state.OperationFailedException).ConfigureAwait(false);
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
            Argument.AssertNotNull(rawResponse, nameof(rawResponse));

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
            Argument.AssertNotNull(rawResponse, nameof(rawResponse));
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
            Argument.AssertNotNull(rawResponse, nameof(rawResponse));
            return new OperationState(rawResponse, false, default, default);
        }
    }
}
