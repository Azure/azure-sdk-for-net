// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// </summary>
    public static class OperationExtensions
    {
        /// <summary>
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async ValueTask<Response<T>> WaitForCompletionAsync<T, U>(this Task<U> operation, CancellationToken cancellationToken = default)
            where U : Operation<T>
        {
            U o = await operation.ConfigureAwait(false);
            return await o.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="pollingInterval"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async ValueTask<Response<T>> WaitForCompletionAsync<T, U>(this Task<U> operation, TimeSpan pollingInterval, CancellationToken cancellationToken = default)
            where U : Operation<T>
        {
            U o = await operation.ConfigureAwait(false);
            return await o.WaitForCompletionAsync(pollingInterval, cancellationToken).ConfigureAwait(false);
        }
    }
}
