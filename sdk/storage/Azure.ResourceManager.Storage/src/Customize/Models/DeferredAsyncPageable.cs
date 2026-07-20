// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Helper: Async paging adapter that defers fetch until enumeration and exposes one page.
// Used by backward-compat GetKeysAsync/RegenerateKeyAsync overloads that wrap
// Response as AsyncPageable.
//
// Uses a concrete IAsyncEnumerator rather than an async iterator (yield return)
// so that diagnostic scope events fire inside a regular async MoveNextAsync call,
// allowing the test framework's per-page DiagnosticScope validation to detect them.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary>
    /// Wraps a single list of items into an AsyncPageable with one page.
    /// Defers the async call to AsPages enumeration time.
    /// </summary>
    internal class DeferredAsyncPageable<T> : AsyncPageable<T>
    {
        private readonly Func<Task<(IReadOnlyList<T> Items, Response Response)>> _factory;

        internal DeferredAsyncPageable(Func<Task<(IReadOnlyList<T> Items, Response Response)>> factory)
        {
            _factory = factory;
        }

        public override IAsyncEnumerable<Page<T>> AsPages(string continuationToken = null, int? pageSizeHint = null)
        {
            return new SinglePageAsyncEnumerable(_factory);
        }

        private sealed class SinglePageAsyncEnumerable : IAsyncEnumerable<Page<T>>
        {
            private readonly Func<Task<(IReadOnlyList<T> Items, Response Response)>> _factory;

            public SinglePageAsyncEnumerable(Func<Task<(IReadOnlyList<T> Items, Response Response)>> factory)
            {
                _factory = factory;
            }

            public IAsyncEnumerator<Page<T>> GetAsyncEnumerator(CancellationToken cancellationToken = default)
            {
                return new SinglePageAsyncEnumerator(_factory);
            }
        }

        private sealed class SinglePageAsyncEnumerator : IAsyncEnumerator<Page<T>>
        {
            private readonly Func<Task<(IReadOnlyList<T> Items, Response Response)>> _factory;
            private Page<T> _current;
            private bool _moved;

            public SinglePageAsyncEnumerator(Func<Task<(IReadOnlyList<T> Items, Response Response)>> factory)
            {
                _factory = factory;
            }

            public Page<T> Current => _current;

            public async ValueTask<bool> MoveNextAsync()
            {
                if (_moved)
                    return false;
                _moved = true;
                var (items, response) = await _factory().ConfigureAwait(false);
                _current = Page<T>.FromValues(items, null, response);
                return true;
            }

            public ValueTask DisposeAsync() => default;
        }
    }
}
