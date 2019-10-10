// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure
{
    public static class AzureExtensions
    {
        public static async ValueTask<Response<T>> WaitForCompletionAsync<T, TOperation>(this Task<TOperation> operation, CancellationToken cancellationToken = default)
            where T : notnull
            where TOperation: Operation<T>
        {
            Operation<T> o = await operation.ConfigureAwait(false);
            return await o.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
        }

        public static async ValueTask<Response<T>> WaitForCompletionAsync<T, TOperation>(this Task<TOperation> operation, TimeSpan? interval, CancellationToken cancellationToken)
            where T : notnull
            where TOperation: Operation<T>
        {
            Operation<T> o = await operation.ConfigureAwait(false);
            return await o.WaitForCompletionAsync(interval, cancellationToken).ConfigureAwait(false);
        }
    }
}
