// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

#nullable enable

namespace Azure
{
    /// <summary>
    /// Represents a long-running operation that returns a value when it completes.
    /// </summary>
    /// <typeparam name="T">The final result of the long-running operation.</typeparam>
#pragma warning disable SA1649 // File name should match first type name
#pragma warning disable AZC0012 // Avoid single word type names
    public abstract class Operation<T> : Operation where T : notnull
#pragma warning restore AZC0012 // Avoid single word type names
#pragma warning restore SA1649 // File name should match first type name
    {
        /// <summary>
        /// Final result of the long-running operation.
        /// </summary>
        /// <remarks>
        /// This property can be accessed only after the operation completes successfully (HasValue is true).
        /// </remarks>
        public abstract T Value { get; }

        /// <summary>
        /// Returns true if the long-running operation completed successfully and has produced final result (accessible by Value property).
        /// </summary>
        public abstract bool HasValue { get; }

        /// <summary>
        /// Periodically calls the server till the long-running operation completes.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> used for the periodical service calls.</param>
        /// <returns>The last HTTP response received from the server.</returns>
        /// <remarks>
        /// This method will periodically call UpdateStatusAsync till HasCompleted is true, then return the final result of the operation.
        /// </remarks>
        public virtual Response<T> WaitForCompletion(CancellationToken cancellationToken = default)
        {
            OperationPoller poller = new OperationPoller();
            return poller.WaitForCompletion(this, null, cancellationToken);
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
        /// This method will periodically call UpdateStatusAsync till HasCompleted is true, then return the final result of the operation.
        /// </remarks>
        public virtual Response<T> WaitForCompletion(TimeSpan pollingInterval, CancellationToken cancellationToken)
        {
            OperationPoller poller = new OperationPoller();
            return poller.WaitForCompletion(this, pollingInterval, cancellationToken);
        }

        /// <summary>
        /// Periodically calls the server till the long-running operation completes.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> used for the periodical service calls.</param>
        /// <returns>The last HTTP response received from the server.</returns>
        /// <remarks>
        /// This method will periodically call UpdateStatusAsync till HasCompleted is true, then return the final result of the operation.
        /// </remarks>
        public virtual async ValueTask<Response<T>> WaitForCompletionAsync(CancellationToken cancellationToken = default)
        {
            OperationPoller poller = new OperationPoller();
            return await poller.WaitForCompletionAsync(this, null, cancellationToken).ConfigureAwait(false);
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
        /// This method will periodically call UpdateStatusAsync till HasCompleted is true, then return the final result of the operation.
        /// </remarks>
        public virtual async ValueTask<Response<T>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken)
        {
            OperationPoller poller = new OperationPoller();
            return await poller.WaitForCompletionAsync(this, pollingInterval, cancellationToken).ConfigureAwait(false);
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
        /// This method will periodically call UpdateStatusAsync till HasCompleted is true, then return the final result of the operation.
        /// </remarks>
        public virtual Response<T> WaitForCompletion(DelayStrategy delayStrategy, CancellationToken cancellationToken)
        {
            OperationPoller poller = new OperationPoller(delayStrategy);
            return poller.WaitForCompletion(this, default, cancellationToken);
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
        /// This method will periodically call UpdateStatusAsync till HasCompleted is true, then return the final result of the operation.
        /// </remarks>
        public virtual async ValueTask<Response<T>> WaitForCompletionAsync(DelayStrategy delayStrategy, CancellationToken cancellationToken)
        {
            OperationPoller poller = new OperationPoller(delayStrategy);
            return await poller.WaitForCompletionAsync(this, default, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override async ValueTask<Response> WaitForCompletionResponseAsync(CancellationToken cancellationToken = default)
            => (await WaitForCompletionAsync(cancellationToken).ConfigureAwait(false)).GetRawResponse();

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override async ValueTask<Response> WaitForCompletionResponseAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default)
            => (await WaitForCompletionAsync(pollingInterval, cancellationToken).ConfigureAwait(false)).GetRawResponse();
    }
}
