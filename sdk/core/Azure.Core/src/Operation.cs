// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure
{
    /// <summary>
    /// Represents a long-running operation.
    /// </summary>
#pragma warning disable AZC0012 // Avoid single word type names
    public abstract class Operation
#pragma warning restore AZC0012 // Avoid single word type names
    {
        private const string RetryAfterHeaderName = "Retry-After";
        private const string RetryAfterMsHeaderName = "retry-after-ms";
        private const string XRetryAfterMsHeaderName = "x-ms-retry-after-ms";
        internal static TimeSpan DefaultPollingInterval { get; } = TimeSpan.FromSeconds(1);

        /// <summary>
        /// Gets an ID representing the operation that can be used to poll for
        /// the status of the long-running operation.
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
        public virtual ValueTask<Response> WaitForCompletionResponseAsync(CancellationToken cancellationToken = default)
            => WaitForCompletionResponseAsync(DefaultPollingInterval, cancellationToken);

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
            while (true)
            {
                Response response = await UpdateStatusAsync(cancellationToken).ConfigureAwait(false);
                if (HasCompleted)
                {
                    return GetRawResponse();
                }
                TimeSpan delay = GetServerDelay(response, pollingInterval);
                await Task.Delay(delay, cancellationToken).ConfigureAwait(false);
            }
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
            => WaitForCompletionResponse(DefaultPollingInterval, cancellationToken);

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
            while (true)
            {
                Response response = UpdateStatus(cancellationToken);

                if (HasCompleted)
                {
                    return GetRawResponse();
                }
                TimeSpan delay = GetServerDelay(response, pollingInterval);
                Thread.Sleep(delay);
            }
        }

        /// <summary>
        /// Calculates the delay to be used for calls to WaitForCompletion.
        /// </summary>
        /// <param name="response">The <see cref="Response"/>.</param>
        /// <param name="pollingInterval">The polling interval specified by the call to WaitForCompletion.</param>
        /// <returns></returns>
        internal static TimeSpan GetServerDelay(Response response, TimeSpan pollingInterval)
        {
            if (pollingInterval == TimeSpan.Zero)
            {
                // Respect when zero is explicitly used (recorded tests use this, for example)
                return pollingInterval;
            }
            TimeSpan serverDelay = pollingInterval;
            if (response.Headers.TryGetValue(RetryAfterMsHeaderName, out string? retryAfterValue) ||
                response.Headers.TryGetValue(XRetryAfterMsHeaderName, out retryAfterValue))
            {
                if (int.TryParse(retryAfterValue, out int serverDelayInMilliseconds))
                {
                    serverDelay = TimeSpan.FromMilliseconds(serverDelayInMilliseconds);
                }
            }
            else if (response.Headers.TryGetValue(RetryAfterHeaderName, out retryAfterValue))
            {
                if (int.TryParse(retryAfterValue, out int serverDelayInSeconds))
                {
                    serverDelay = TimeSpan.FromSeconds(serverDelayInSeconds);
                }
            }

            return serverDelay > pollingInterval
                ? serverDelay
                : pollingInterval;
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
