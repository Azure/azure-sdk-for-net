// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure
{
    /// <summary>
    /// Represents a long-running operation.
    /// </summary>
#pragma warning disable AZC0012 // Avoid single word type names
    public abstract class Operation
#pragma warning restore AZC0012 // Avoid single word type names
    {
        /// <summary>
        /// Rehydrates an operation from a <see cref="RehydrationToken"/>.
        /// </summary>
        /// <param name="pipeline">The Http pipeline.</param>
        /// <param name="rehydrationToken">The rehydration token.</param>
        /// <param name="options">The client options.</param>
        /// <returns>The long-running operation.</returns>
        public static Operation<T> Rehydrate<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] T>(HttpPipeline pipeline, RehydrationToken rehydrationToken, ClientOptions? options = null) where T : IPersistableModel<T>
        {
            Argument.AssertNotNull(pipeline, nameof(pipeline));
            Argument.AssertNotNull(rehydrationToken, nameof(rehydrationToken));

            IOperationSource<T> source = new GenericOperationSource<T>();
            var nextLinkOperation = (NextLinkOperationImplementation)NextLinkOperationImplementation.Create(pipeline, rehydrationToken);
            var operation = NextLinkOperationImplementation.Create(source, nextLinkOperation);
            var operationState = operation.UpdateStateAsync(async: false, default).EnsureCompleted();
            return new RehydrationOperation<T>(nextLinkOperation, operationState, operation, options);
        }

        /// <summary>
        /// Rehydrates an operation from a <see cref="RehydrationToken"/>.
        /// </summary>
        /// <param name="pipeline">The Http pipeline.</param>
        /// <param name="rehydrationToken">The rehydration token.</param>
        /// <param name="options">The client options.</param>
        /// <returns>The long-running operation.</returns>
        public static Operation Rehydrate(HttpPipeline pipeline, RehydrationToken rehydrationToken, ClientOptions? options = null)
        {
            Argument.AssertNotNull(pipeline, nameof(pipeline));
            Argument.AssertNotNull(rehydrationToken, nameof(rehydrationToken));

            var nextLinkOperation = (NextLinkOperationImplementation)NextLinkOperationImplementation.Create(pipeline, rehydrationToken);
            var operationState = nextLinkOperation.UpdateStateAsync(async: false, default).EnsureCompleted();
            return new RehydrationOperation(nextLinkOperation, operationState);
        }

        /// <summary>
        /// Rehydrates an operation from a <see cref="RehydrationToken"/>.
        /// </summary>
        /// <param name="pipeline">The Http pipeline.</param>
        /// <param name="rehydrationToken">The rehydration token.</param>
        /// <param name="options">The client options.</param>
        /// <returns>The long-running operation.</returns>
        public static async Task<Operation<T>> RehydrateAsync<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] T>(HttpPipeline pipeline, RehydrationToken rehydrationToken, ClientOptions? options = null) where T : IPersistableModel<T>
        {
            Argument.AssertNotNull(pipeline, nameof(pipeline));
            Argument.AssertNotNull(rehydrationToken, nameof(rehydrationToken));

            IOperationSource<T> source = new GenericOperationSource<T>();
            var nextLinkOperation = (NextLinkOperationImplementation)NextLinkOperationImplementation.Create(pipeline, rehydrationToken);
            var operation = NextLinkOperationImplementation.Create(source, nextLinkOperation);
            var operationState = await operation.UpdateStateAsync(async: true, default).ConfigureAwait(false);
            return new RehydrationOperation<T>(nextLinkOperation, operationState, operation, options);
        }

        /// <summary>
        /// Rehydrates an operation from a <see cref="RehydrationToken"/>.
        /// </summary>
        /// <param name="pipeline">The Http pipeline.</param>
        /// <param name="rehydrationToken">The rehydration token.</param>
        /// <param name="options">The client options.</param>
        /// <returns>The long-running operation.</returns>
        public static async Task<Operation> RehydrateAsync(HttpPipeline pipeline, RehydrationToken rehydrationToken, ClientOptions? options = null)
        {
            Argument.AssertNotNull(pipeline, nameof(pipeline));
            Argument.AssertNotNull(rehydrationToken, nameof(rehydrationToken));

            var nextLinkOperation = (NextLinkOperationImplementation)NextLinkOperationImplementation.Create(pipeline, rehydrationToken);
            var operationState = await nextLinkOperation.UpdateStateAsync(async: true, default).ConfigureAwait(false);
            return new RehydrationOperation(nextLinkOperation, operationState);
        }

        /// <summary>
        /// Get a token that can be used to rehydrate the operation.
        /// </summary>
        public virtual RehydrationToken? GetRehydrationToken() => null;

        /// <summary>
        /// Gets an ID representing the operation that can be used to poll for
        /// the status of the long-running operation.
        /// There are cases that operation id is not available, we return "NOT_SET" for unavailable operation id.
        /// </summary>
        public abstract string Id { get; }

        /// <summary>
        /// The last HTTP response received from the server.
        /// </summary>
        /// <remarks>
        /// The last response returned from the server during the lifecycle of this instance.
        /// An instance of <see cref="Operation{T}"/> sends requests to a server in UpdateStatusAsync, UpdateStatus, and other methods.
        /// Responses from these requests can be accessed using GetRawResponse.
        /// </remarks>
        public abstract Response GetRawResponse();

        /// <summary>
        /// Returns true if the long-running operation completed.
        /// </summary>
        public abstract bool HasCompleted { get; }

        /// <summary>
        /// Calls the server to get updated status of the long-running operation.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> used for the service call.</param>
        /// <returns>The HTTP response received from the server.</returns>
        /// <remarks>
        /// This operation will update the value returned from GetRawResponse and might update HasCompleted.
        /// </remarks>
        public abstract ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Calls the server to get updated status of the long-running operation.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> used for the service call.</param>
        /// <returns>The HTTP response received from the server.</returns>
        /// <remarks>
        /// This operation will update the value returned from GetRawResponse and might update HasCompleted.
        /// </remarks>
        public abstract Response UpdateStatus(CancellationToken cancellationToken = default);

        /// <summary>
        /// Periodically calls the server till the long-running operation completes.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> used for the periodical service calls.</param>
        /// <returns>The last HTTP response received from the server.</returns>
        /// <remarks>
        /// This method will periodically call UpdateStatusAsync till HasCompleted is true, then return the final response of the operation.
        /// </remarks>
        public virtual async ValueTask<Response> WaitForCompletionResponseAsync(CancellationToken cancellationToken = default)
        {
            OperationPoller poller = new OperationPoller();
            return await poller.WaitForCompletionResponseAsync(this, null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Periodically calls the server till the long-running operation completes.
        /// </summary>
        /// <param name="pollingInterval">
        /// The interval between status requests to the server.
        /// The interval can change based on information returned from the server.
        /// For example, the server might communicate to the client that there is not reason to poll for status change sooner than some time.
        /// </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> used for the periodical service calls.</param>
        /// <returns>The last HTTP response received from the server.</returns>
        /// <remarks>
        /// This method will periodically call UpdateStatusAsync till HasCompleted is true, then return the final response of the operation.
        /// </remarks>
        public virtual async ValueTask<Response> WaitForCompletionResponseAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default)
        {
            OperationPoller poller = new OperationPoller();
            return await poller.WaitForCompletionResponseAsync(this, pollingInterval, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Periodically calls the server till the long-running operation completes.
        /// </summary>
        /// <param name="delayStrategy">
        /// The strategy to use to determine the delay between status requests to the server. If the server returns retry-after header,
        /// the delay used will be the maximum specified by the strategy and the header value.
        /// </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> used for the periodical service calls.</param>
        /// <returns>The last HTTP response received from the server.</returns>
        /// <remarks>
        /// This method will periodically call UpdateStatusAsync till HasCompleted is true, then return the final response of the operation.
        /// </remarks>
        public virtual async ValueTask<Response> WaitForCompletionResponseAsync(DelayStrategy delayStrategy, CancellationToken cancellationToken = default)
        {
            OperationPoller poller = new OperationPoller(delayStrategy);
            return await poller.WaitForCompletionResponseAsync(this, default, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Periodically calls the server till the long-running operation completes.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> used for the periodical service calls.</param>
        /// <returns>The last HTTP response received from the server.</returns>
        /// <remarks>
        /// This method will periodically call UpdateStatusAsync till HasCompleted is true, then return the final response of the operation.
        /// </remarks>
        public virtual Response WaitForCompletionResponse(CancellationToken cancellationToken = default)
        {
            OperationPoller poller = new OperationPoller();
            return poller.WaitForCompletionResponse(this, null, cancellationToken);
        }

        /// <summary>
        /// Periodically calls the server till the long-running operation completes.
        /// </summary>
        /// <param name="pollingInterval">
        /// The interval between status requests to the server.
        /// The interval can change based on information returned from the server.
        /// For example, the server might communicate to the client that there is not reason to poll for status change sooner than some time.
        /// </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> used for the periodical service calls.</param>
        /// <returns>The last HTTP response received from the server.</returns>
        /// <remarks>
        /// This method will periodically call UpdateStatusAsync till HasCompleted is true, then return the final response of the operation.
        /// </remarks>
        public virtual Response WaitForCompletionResponse(TimeSpan pollingInterval, CancellationToken cancellationToken = default)
        {
            OperationPoller poller = new OperationPoller();
            return poller.WaitForCompletionResponse(this, pollingInterval, cancellationToken);
        }

        /// <summary>
        /// Periodically calls the server till the long-running operation completes.
        /// </summary>
        /// <param name="delayStrategy">
        /// The strategy to use to determine the delay between status requests to the server. If the server returns retry-after header,
        /// the delay used will be the maximum specified by the strategy and the header value.
        /// </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> used for the periodical service calls.</param>
        /// <returns>The last HTTP response received from the server.</returns>
        /// <remarks>
        /// This method will periodically call UpdateStatusAsync till HasCompleted is true, then return the final response of the operation.
        /// </remarks>
        public virtual Response WaitForCompletionResponse(DelayStrategy delayStrategy, CancellationToken cancellationToken = default)
        {
            OperationPoller poller = new OperationPoller(delayStrategy);
            return poller.WaitForCompletionResponse(this, default, cancellationToken);
        }

        internal static T GetValue<T>(ref T? value) where T : class
        {
            if (value is null)
            {
                throw new InvalidOperationException("The operation has not completed yet.");
            }

            return value;
        }

        internal static T GetValue<T>(ref T? value) where T : struct
        {
            if (value == null)
            {
                throw new InvalidOperationException("The operation has not completed yet.");
            }

            return value.Value;
        }

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object? obj) => base.Equals(obj);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string? ToString() => base.ToString();
    }
}
