// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Host.Converters
{
    /// <summary>
    /// An asynchronous converter that delegates to an inner synchronous converter.
    /// </summary>
    /// <typeparam name="TInput">The type to convert from.</typeparam>
    /// <typeparam name="TOutput">The type to convert to.</typeparam>
    internal class AsyncConverter<TInput, TOutput> : IAsyncConverter<TInput, TOutput>
    {
        private readonly IConverter<TInput, TOutput> _innerConverter;

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="innerConverter">The inner converter to delegate to.</param>
        public AsyncConverter(IConverter<TInput, TOutput> innerConverter)
        {
            _innerConverter = innerConverter;
        }

        /// <inheritdoc/>
        public Task<TOutput> ConvertAsync(TInput input, CancellationToken cancellationToken)
        {
            TOutput result = _innerConverter.Convert(input);
            return Task.FromResult(result);
        }
    }
}
