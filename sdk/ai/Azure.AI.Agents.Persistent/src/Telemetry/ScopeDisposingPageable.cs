// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.AI.Agents.Persistent.Telemetry
{
    internal class ScopeDisposingPageable<T> : Pageable<T>
    {
        private readonly Pageable<T> _inner;
        private readonly IDisposable _scope;

        public ScopeDisposingPageable(Pageable<T> inner, IDisposable scope)
        {
            _inner = inner;
            _scope = scope;
        }

        public override IEnumerator<T> GetEnumerator()
        {
            return new ScopeDisposingEnumerator<T>(_inner.GetEnumerator(), _scope);
        }

        public override IEnumerable<Page<T>> AsPages(string continuationToken = null, int? pageSizeHint = null)
        {
            // Optionally, you could wrap the page enumerator as well if you want to dispose the scope after page enumeration.
            return new ScopeDisposingEnumerable(_inner.AsPages(continuationToken, pageSizeHint), _scope);
        }

        private class ScopeDisposingEnumerator<TItem> : IEnumerator<TItem>
        {
            private readonly IEnumerator<TItem> _inner;
            private readonly IDisposable _scope;
            private bool _disposed;

            public ScopeDisposingEnumerator(IEnumerator<TItem> inner, IDisposable scope)
            {
                _inner = inner;
                _scope = scope;
            }

            public TItem Current => _inner.Current;
            object System.Collections.IEnumerator.Current => Current;

            public bool MoveNext()
            {
                try
                {
                    return _inner.MoveNext();
                }
                catch
                {
                    Dispose();
                    throw;
                }
            }

            public void Reset() => _inner.Reset();

            public void Dispose()
            {
                if (!_disposed)
                {
                    _inner.Dispose();
                    _scope?.Dispose();
                    _disposed = true;
                }
            }
        }

        private class ScopeDisposingEnumerable : IEnumerable<Page<T>>
        {
            private readonly IEnumerable<Page<T>> _inner;
            private readonly IDisposable _scope;

            public ScopeDisposingEnumerable(IEnumerable<Page<T>> inner, IDisposable scope)
            {
                _inner = inner;
                _scope = scope;
            }

            public IEnumerator<Page<T>> GetEnumerator()
            {
                return new ScopeDisposingPageEnumerator(_inner.GetEnumerator(), _scope);
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();

            private class ScopeDisposingPageEnumerator : IEnumerator<Page<T>>
            {
                private readonly IEnumerator<Page<T>> _inner;
                private readonly IDisposable _scope;
                private bool _disposed;

                public ScopeDisposingPageEnumerator(IEnumerator<Page<T>> inner, IDisposable scope)
                {
                    _inner = inner;
                    _scope = scope;
                }

                public Page<T> Current => _inner.Current;
                object System.Collections.IEnumerator.Current => Current;

                public bool MoveNext()
                {
                    try
                    {
                        return _inner.MoveNext();
                    }
                    catch
                    {
                        Dispose();
                        throw;
                    }
                }

                public void Reset() => _inner.Reset();

                public void Dispose()
                {
                    if (!_disposed)
                    {
                        _inner.Dispose();
                        _scope?.Dispose();
                        _disposed = true;
                    }
                }
            }
        }
    }
}
