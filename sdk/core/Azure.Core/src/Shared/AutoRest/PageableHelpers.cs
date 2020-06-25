// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    internal static class PageableHelpers
    {
        public static Pageable<T> CreateEnumerable<T>(IEnumerable<Page<T>> enumerable) where T : notnull => new PageableWrapper<T>(enumerable);

        public static AsyncPageable<T> CreateAsyncEnumerable<T>(IAsyncEnumerable<Page<T>> enumerable) where T : notnull => new AsyncPageableWrapper<T>(enumerable);

        public static Pageable<T> CreateEnumerable<T>(IEnumerable<Page<T>> enumerable, ClientDiagnostics clientDiagnostics, string scopeName) where T : notnull
            => new PageableWrapper<T>(new EnumerableWithScope<T>(enumerable, clientDiagnostics, scopeName));

        public static AsyncPageable<T> CreateAsyncEnumerable<T>(IAsyncEnumerable<Page<T>> enumerable, ClientDiagnostics clientDiagnostics, string scopeName) where T : notnull
            => new AsyncPageableWrapper<T>(new AsyncEnumerableWithScope<T>(enumerable, clientDiagnostics, scopeName));

        public static Pageable<T> CreateEnumerable<T>(Func<int?, Page<T>> firstPageFunc, Func<string?, int?, Page<T>>? nextPageFunc, int? pageSize = default) where T : notnull
        {
            PageFunc<T> first = (continuationToken, pageSizeHint) => firstPageFunc(pageSizeHint);
            PageFunc<T>? next = nextPageFunc != null ? new PageFunc<T>(nextPageFunc) : null;
            return new FuncPageable<T>(first, next, pageSize);
        }

        public static AsyncPageable<T> CreateAsyncEnumerable<T>(Func<int?, Task<Page<T>>> firstPageFunc, Func<string?, int?, Task<Page<T>>>? nextPageFunc, int? pageSize = default) where T : notnull
        {
            AsyncPageFunc<T> first = (continuationToken, pageSizeHint) => firstPageFunc(pageSizeHint);
            AsyncPageFunc<T>? next = nextPageFunc != null ? new AsyncPageFunc<T>(nextPageFunc) : null;
            return new FuncAsyncPageable<T>(first, next, pageSize);
        }

        internal delegate Task<Page<T>> AsyncPageFunc<T>(string? continuationToken = default, int? pageSizeHint = default);
        internal delegate Page<T> PageFunc<T>(string? continuationToken = default, int? pageSizeHint = default);

        internal class FuncAsyncPageable<T> : AsyncPageable<T> where T : notnull
        {
            private readonly AsyncPageFunc<T> _firstPageFunc;
            private readonly AsyncPageFunc<T>? _nextPageFunc;
            private readonly int? _defaultPageSize;

            public FuncAsyncPageable(AsyncPageFunc<T> firstPageFunc, AsyncPageFunc<T>? nextPageFunc, int? defaultPageSize = default)
            {
                _firstPageFunc = firstPageFunc;
                _nextPageFunc = nextPageFunc;
                _defaultPageSize = defaultPageSize;
            }

            public override async IAsyncEnumerable<Page<T>> AsPages(string? continuationToken = default, int? pageSizeHint = default)
            {
                AsyncPageFunc<T>? pageFunc = _firstPageFunc;
                int? pageSize = pageSizeHint ?? _defaultPageSize;
                do
                {
                    Page<T> pageResponse = await pageFunc(continuationToken, pageSize).ConfigureAwait(false);
                    yield return pageResponse;
                    continuationToken = pageResponse.ContinuationToken;
                    pageFunc = _nextPageFunc;
                } while (!string.IsNullOrEmpty(continuationToken) && pageFunc != null);
            }
        }

        internal class FuncPageable<T> : Pageable<T> where T : notnull
        {
            private readonly PageFunc<T> _firstPageFunc;
            private readonly PageFunc<T>? _nextPageFunc;
            private readonly int? _defaultPageSize;

            public FuncPageable(PageFunc<T> firstPageFunc, PageFunc<T>? nextPageFunc, int? defaultPageSize = default)
            {
                _firstPageFunc = firstPageFunc;
                _nextPageFunc = nextPageFunc;
                _defaultPageSize = defaultPageSize;
            }

            public override IEnumerable<Page<T>> AsPages(string? continuationToken = default, int? pageSizeHint = default)
            {
                PageFunc<T>? pageFunc = _firstPageFunc;
                int? pageSize = pageSizeHint ?? _defaultPageSize;
                do
                {
                    Page<T> pageResponse = pageFunc(continuationToken, pageSize);
                    yield return pageResponse;
                    continuationToken = pageResponse.ContinuationToken;
                    pageFunc = _nextPageFunc;
                } while (!string.IsNullOrEmpty(continuationToken) && pageFunc != null);
            }
        }

        private class PageableWrapper<T> : Pageable<T> where T : notnull
        {
            private readonly IEnumerable<Page<T>> _enumerable;
            public PageableWrapper(IEnumerable<Page<T>> enumerable) => _enumerable = enumerable;
            public override IEnumerable<Page<T>> AsPages(string? continuationToken = null, int? pageSizeHint = null) => _enumerable;
        }

        private class AsyncPageableWrapper<T> : AsyncPageable<T> where T : notnull
        {
            private readonly IAsyncEnumerable<Page<T>> _enumerable;
            public AsyncPageableWrapper(IAsyncEnumerable<Page<T>> enumerable) => _enumerable = enumerable;
            public override IAsyncEnumerable<Page<T>> AsPages(string? continuationToken = null, int? pageSizeHint = null) => _enumerable;
        }

        private class EnumerableWithScope<T> : IEnumerable<Page<T>>
        {
            private readonly IEnumerable<Page<T>> _enumerable;
            private readonly ClientDiagnostics _clientDiagnostics;
            private readonly string _scopeName;

            public EnumerableWithScope(IEnumerable<Page<T>> enumerable, ClientDiagnostics clientDiagnostics, string scopeName)
                => (_enumerable, _clientDiagnostics, _scopeName) = (enumerable, clientDiagnostics, scopeName);

            public IEnumerator<Page<T>> GetEnumerator()
                => new Enumerator(_enumerable.GetEnumerator(), _clientDiagnostics, _scopeName);

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

            private class Enumerator : IEnumerator<Page<T>>
            {
                private readonly IEnumerator<Page<T>> _enumerator;
                private readonly ClientDiagnostics _clientDiagnostics;
                private readonly string _scopeName;

                public Enumerator(IEnumerator<Page<T>> enumerator, ClientDiagnostics clientDiagnostics, string scopeName)
                    => (_enumerator, _clientDiagnostics, _scopeName) = (enumerator, clientDiagnostics, scopeName);

                public Page<T> Current => _enumerator.Current;
                object IEnumerator.Current => _enumerator.Current;

                public bool MoveNext()
                {
                    using DiagnosticScope scope = _clientDiagnostics.CreateScope(_scopeName);
                    scope.Start();
                    try
                    {
                        return _enumerator.MoveNext();
                    }
                    catch (Exception e)
                    {
                        scope.Failed(e);
                        throw;
                    }
                }

                public void Reset() => _enumerator.Reset();
                public void Dispose() => _enumerator.Dispose();
            }
        }

        private class AsyncEnumerableWithScope<T> : IAsyncEnumerable<Page<T>>
        {
            private readonly IAsyncEnumerable<Page<T>> _enumerable;
            private readonly ClientDiagnostics _clientDiagnostics;
            private readonly string _scopeName;

            public AsyncEnumerableWithScope(IAsyncEnumerable<Page<T>> enumerable, ClientDiagnostics clientDiagnostics, string scopeName)
                => (_enumerable, _clientDiagnostics, _scopeName) = (enumerable, clientDiagnostics, scopeName);

            public IAsyncEnumerator<Page<T>> GetAsyncEnumerator(CancellationToken cancellationToken = new CancellationToken())
                => new Enumerator(_enumerable.GetAsyncEnumerator(cancellationToken), _clientDiagnostics, _scopeName);

            private class Enumerator : IAsyncEnumerator<Page<T>>
            {
                private readonly IAsyncEnumerator<Page<T>> _enumerator;
                private readonly ClientDiagnostics _clientDiagnostics;
                private readonly string _scopeName;

                public Enumerator(IAsyncEnumerator<Page<T>> enumerator, ClientDiagnostics clientDiagnostics, string scopeName)
                    => (_enumerator, _clientDiagnostics, _scopeName) = (enumerator, clientDiagnostics, scopeName);

                public ValueTask DisposeAsync() => _enumerator.DisposeAsync();

                public async ValueTask<bool> MoveNextAsync()
                {
                    using DiagnosticScope scope = _clientDiagnostics.CreateScope(_scopeName);
                    scope.Start();
                    try
                    {
                        return await _enumerator.MoveNextAsync().ConfigureAwait(false);
                    }
                    catch (Exception e)
                    {
                        scope.Failed(e);
                        throw;
                    }
                }

                public Page<T> Current => _enumerator.Current;
            }
        }
    }
}
