// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace Azure.Identity
{
    internal static class AbstractAcquireTokenParameterBuilderExtensions
    {
        public static async Task<AuthenticationResult> ExecuteAsync<T>(this AbstractAcquireTokenParameterBuilder<T> builder, bool async, CancellationToken cancellationToken)
            where T : AbstractAcquireTokenParameterBuilder<T>
        {
            Microsoft.Identity.Client.AuthenticationResult result = async
                ? await builder.ExecuteAsync(cancellationToken).ConfigureAwait(false)
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult(). Use the TaskExtensions.EnsureCompleted() extension method instead.
                : builder.ExecuteAsync(cancellationToken).GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult(). Use the TaskExtensions.EnsureCompleted() extension method instead.

            return result;
        }
    }
}
