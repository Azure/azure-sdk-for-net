// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

namespace Azure.AI.Translator.DocumentTranslation
{
    /// <summary>
    /// Represents a pageable long-running operation that exposes the results
    /// in either synchronous or asynchronous format.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class PageableOperation<T> : Operation<AsyncPageable<T>> where T : notnull
    {
        /// <summary>
        /// Gets the final result of the long-running operation asynchronously.
        /// </summary>
        /// <remarks>
        /// This property can be accessed only after the operation completes successfully (HasValue is true).
        /// </remarks>
        public override AsyncPageable<T> Value => GetValuesAsync();

        /// <summary>
        /// Gets the final result of the long-running operation asynchronously.
        /// </summary>
        /// <remarks>
        /// Operation must complete successfully (HasValue is true) for it to provide values.
        /// </remarks>
        public abstract AsyncPageable<T> GetValuesAsync();

        /// <summary>
        /// Gets the final result of the long-running operation synchronously.
        /// </summary>
        /// <remarks>
        /// Operation must complete successfully (HasValue is true) for it to provide values.
        /// </remarks>
        public abstract Pageable<T> GetValues();
    }
}
