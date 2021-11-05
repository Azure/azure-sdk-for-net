// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;

#nullable enable

namespace Azure
{
    /// <summary>
    /// Represents a pageable long-running operation that exposes the results
    /// in either synchronous or asynchronous format.
    /// </summary>
    /// <typeparam name="T"></typeparam>
#pragma warning disable SA1649 // File name should match first type name
    public abstract class PageableOperation<T> : Operation<AsyncPageable<T>> where T : notnull
#pragma warning restore SA1649 // File name should match first type name
    {
        /// <summary>
        /// Gets the final result of the long-running operation asynchronously.
        /// </summary>
        /// <remarks>
        /// This property can be accessed only after the operation completes successfully (HasValue is true).
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override AsyncPageable<T> Value => GetValuesAsync();

        /// <summary>
        /// Gets the final result of the long-running operation asynchronously.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> used for the periodical service calls.</param>
        /// <returns>The final result of the long-running operation asynchronously.</returns>
        /// <remarks>
        /// Operation must complete successfully (HasValue is true) for it to provide values.
        /// </remarks>
        public abstract AsyncPageable<T> GetValuesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the final result of the long-running operation synchronously.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> used for the periodical service calls.</param>
        /// <returns>The final result of the long-running operation synchronously.</returns>
        /// <remarks>
        /// Operation must complete successfully (HasValue is true) for it to provide values.
        /// </remarks>
        public abstract Pageable<T> GetValues(CancellationToken cancellationToken = default);
    }
}
