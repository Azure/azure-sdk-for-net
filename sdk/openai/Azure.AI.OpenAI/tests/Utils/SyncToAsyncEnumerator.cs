// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.OpenAI.Tests.Utils
{
    /// <summary>
    /// Wraps an <see cref="IEnumerable{T}"/> as an <see cref="IAsyncEnumerable{T}"/>
    /// </summary>
    /// <typeparam name="T">The type of items being enuemrated</typeparam>
    public class SyncToAsyncEnumerator<T> : IAsyncEnumerator<T>
    {
        private IEnumerator<T> _sync;
        private CancellationToken _token;

        /// <summary>
        /// Creates a new isntance
        /// </summary>
        /// <param name="sync">The synchronous enumerator to wrap</param>
        /// <param name="token">(Optional) The cancellation token to use</param>
        /// <exception cref="ArgumentNullException">If the enumerator was null</exception>
        public SyncToAsyncEnumerator(IEnumerator<T> sync, CancellationToken token = default)
        {
            _sync = sync ?? throw new ArgumentNullException(nameof(sync));
            _token = token;
        }

        /// <inheritdoc />
        public T Current => _sync.Current;

        /// <inheritdoc />
        public ValueTask DisposeAsync()
        {
            _sync.Dispose();
            return default;
        }

        /// <inheritdoc />
        public ValueTask<bool> MoveNextAsync()
        {
            _token.ThrowIfCancellationRequested();
            bool ret = _sync.MoveNext();
            return new ValueTask<bool>(ret);
        }
    }

}
