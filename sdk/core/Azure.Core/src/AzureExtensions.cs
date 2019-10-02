// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;

namespace Azure
{
    public static class AzureExtensions
    {
        public static async ValueTask<Response<T>> WaitCompletionAsync<T>(this Task<Operation<T>> operation, CancellationToken cancellationToken = default) where T : notnull
        {
            Operation<T> o = await operation.ConfigureAwait(false);
            return await o.WaitCompletionAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
