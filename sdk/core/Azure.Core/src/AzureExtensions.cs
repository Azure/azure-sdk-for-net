// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure
{
    public static class AzureExtensions
    {
        /// <summary>
        /// Periodically calls the server till the LRO completes.
        /// </summary>
        /// <param name="operation">The <see cref="Task{TResult}"/> representing a result of starting the operation.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <remarks>
        /// This method will periodically call UpdateStatusAsync till HasCompleted is true, then return the final result of the operation.
        /// </remarks>
        public static async ValueTask<Response<T>> WaitForCompletionAsync<T, TOperation>(this Task<TOperation> operation, CancellationToken cancellationToken = default)
            where T : notnull
            where TOperation: Operation<T>
        {
            Operation<T> o = await operation.ConfigureAwait(false);
            return await o.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Periodically calls the server till the LRO completes.
        /// </summary>
        /// <param name="operation">The <see cref="Task{TResult}"/> representing a result of starting the operation.</param>
        /// <param name="pollingInterval">
        /// The interval between status requests to the server.
        /// The interval can change based on information returned from the server.
        /// For example, the server might communicate to the client that there is not reason to poll for status change sooner than some time.
        /// </param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <remarks>
        /// This method will periodically call UpdateStatusAsync till HasCompleted is true, then return the final result of the operation.
        /// </remarks>
        public static async ValueTask<Response<T>> WaitForCompletionAsync<T, TOperation>(this Task<TOperation> operation, TimeSpan pollingInterval, CancellationToken cancellationToken)
            where T : notnull
            where TOperation: Operation<T>
        {
            Operation<T> o = await operation.ConfigureAwait(false);
            return await o.WaitForCompletionAsync(pollingInterval, cancellationToken).ConfigureAwait(false);
        }
    }
}
