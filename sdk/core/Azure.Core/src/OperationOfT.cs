// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

#nullable enable

namespace Azure
{
    /// <summary>
    /// Represents a long-running operation.
    /// </summary>
    /// <typeparam name="T">The final result of the long-running operation.</typeparam>
#pragma warning disable SA1649 // File name should match first type name
    public abstract class Operation<T> where T : notnull
#pragma warning restore SA1649 // File name should match first type name
    {
        /// <summary>
        /// Gets an ID representing the operation that can be used to poll for
        /// the status of the long-running operation.
        /// </summary>
        public abstract string Id { get; }

        /// <summary>
        /// Final result of the long-running operation.
        /// </summary>
        /// <remarks>
        /// This property can be accessed only after the operation completes successfully (HasValue is true).
        /// </remarks>
        public abstract T Value { get; }

        /// <summary>
        /// The last HTTP response received from the server.
        /// </summary>
        /// <remarks>
        /// The last response returned from the server during the lifecycle of this instance.
        /// An instance of Operation<typeparamref name="T"/> sends requests to a server in UpdateStatusAsync, UpdateStatus, and other methods.
        /// Responses from these requests can be accessed using GetRawResponse.
        /// </remarks>
        public abstract Response GetRawResponse();

        /// <summary>
        /// Returns true if the long-running operation completed.
        /// </summary>
        public abstract bool HasCompleted { get; }

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
        public abstract ValueTask<Response<T>> WaitForCompletionAsync(CancellationToken cancellationToken = default);

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
        public abstract ValueTask<Response<T>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken);

        /// <summary>
        /// Calls the server to get updated status of the long-running operation.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> used for the service call.</param>
        /// <returns>The HTTP response received from the server.</returns>
        /// <remarks>
        /// This operation will update the value returned from GetRawResponse and might update HasCompleted, HasValue, and Value.
        /// </remarks>
        public abstract ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Calls the server to get updated status of the long-running operation.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> used for the service call.</param>
        /// <returns>The HTTP response received from the server.</returns>
        /// <remarks>
        /// This operation will update the value returned from GetRawResponse and might update HasCompleted, HasValue, and Value.
        /// </remarks>
        public abstract Response UpdateStatus(CancellationToken cancellationToken = default);

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
