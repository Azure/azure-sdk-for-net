// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;

namespace Azure.AI.Agents.Persistent.Telemetry
{
    internal class ScopeDisposingAsyncPageable<T> : AsyncPageable<T>
    {
        private readonly AsyncPageable<T> _inner;
        private readonly IDisposable _scope;

        public ScopeDisposingAsyncPageable(AsyncPageable<T> inner, IDisposable scope)
        {
            _inner = inner ?? throw new ArgumentNullException(nameof(inner));
            _scope = scope;
        }

        public override IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            return new ScopeDisposingAsyncEnumerator<T>(_inner.GetAsyncEnumerator(cancellationToken), _scope);
        }

        public override IAsyncEnumerable<Page<T>> AsPages(string continuationToken = null, int? pageSizeHint = null)
        {
            //return _inner.AsPages(continuationToken, pageSizeHint);
            //return new ScopeDisposingAsyncEnumerator<Page<T>>(_inner.AsPages(continuationToken, pageSizeHint).GetAsyncEnumerator(), _scope);
            return new ScopeDisposingAsyncPageEnumerable(_inner.AsPages(continuationToken, pageSizeHint), _scope);
        }

        private class ScopeDisposingAsyncEnumerator<TItem> : IAsyncEnumerator<TItem>
        {
            private readonly IAsyncEnumerator<TItem> _inner;
            private readonly IDisposable _scope;
            private bool _disposed;

            public ScopeDisposingAsyncEnumerator(IAsyncEnumerator<TItem> inner, IDisposable scope)
            {
                _inner = inner ?? throw new ArgumentNullException(nameof(inner));
                _scope = scope;
            }

            public TItem Current => _inner.Current;

            public async ValueTask<bool> MoveNextAsync()
            {
                try
                {
                    return await _inner.MoveNextAsync().ConfigureAwait(false);
                }
                catch
                {
                    await DisposeAsync().ConfigureAwait(false);
                    throw;
                }
            }

            public async ValueTask DisposeAsync()
            {
                if (!_disposed)
                {
                    await _inner.DisposeAsync().ConfigureAwait(false);
                    _scope?.Dispose();
                    _disposed = true;
                }
            }
        }

        private class ScopeDisposingAsyncPageEnumerable : IAsyncEnumerable<Page<T>>
        {
            private readonly IAsyncEnumerable<Page<T>> _inner;
            private readonly IDisposable _scope;

            public ScopeDisposingAsyncPageEnumerable(IAsyncEnumerable<Page<T>> inner, IDisposable scope)
            {
                _inner = inner;
                _scope = scope;
            }

            public IAsyncEnumerator<Page<T>> GetAsyncEnumerator(CancellationToken cancellationToken = default)
            {
                return new ScopeDisposingAsyncPageEnumerator(_inner.GetAsyncEnumerator(cancellationToken), _scope);
            }

            private class ScopeDisposingAsyncPageEnumerator : IAsyncEnumerator<Page<T>>
            {
                private readonly IAsyncEnumerator<Page<T>> _inner;
                private readonly IDisposable _scope;
                private bool _disposed;

                public ScopeDisposingAsyncPageEnumerator(IAsyncEnumerator<Page<T>> inner, IDisposable scope)
                {
                    _inner = inner;
                    _scope = scope;
                }

                public Page<T> Current => _inner.Current;

                public async ValueTask<bool> MoveNextAsync()
                {
                    try
                    {
                        return await _inner.MoveNextAsync().ConfigureAwait(false);
                    }
                    catch
                    {
                        await DisposeAsync().ConfigureAwait(false);
                        throw;
                    }
                }

                public async ValueTask DisposeAsync()
                {
                    if (!_disposed)
                    {
                        await _inner.DisposeAsync().ConfigureAwait(false);
                        _scope?.Dispose();
                        _disposed = true;
                    }
                }
            }
        }
    }
}
