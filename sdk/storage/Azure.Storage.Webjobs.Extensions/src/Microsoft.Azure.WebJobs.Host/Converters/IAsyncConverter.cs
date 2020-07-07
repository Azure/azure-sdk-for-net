// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs
{
    /// <summary>
    /// Interface defining methods for performing asynchronous conversion operations.
    /// </summary>
    /// <typeparam name="TInput">The type to convert from.</typeparam>
    /// <typeparam name="TOutput">The type to convert to.</typeparam>
    public interface IAsyncConverter<TInput, TOutput>
    {
        /// <summary>
        /// Convert the specified input value to the output type.
        /// </summary>
        /// <param name="input">The value to convert.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use</param>
        /// <returns>A task that returns the converted value.</returns>
        Task<TOutput> ConvertAsync(TInput input, CancellationToken cancellationToken);
    }
}
