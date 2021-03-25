// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.Containers.ContainerRegistry
{
    internal static class ContainerRegistryPageableHelpers
    {
        public static Pageable<T> CreateEnumerable<T>(
            Func<int?, Page<T>> firstPageFunc,
            Func<string, int?, Page<T>> firstPageSkipPast,
            Func<string, int?, Page<T>> nextPageFunc,
            int? pageSize = default
            ) where T : notnull
        {
            PageFunc<T> first = (continuationToken, pageSizeHint) => firstPageFunc(pageSizeHint);
            PageFunc<T> skipPast = new PageFunc<T>(firstPageSkipPast);
            PageFunc<T> next =  new PageFunc<T>(nextPageFunc);
            return new FuncPageable<T>(first, skipPast, next, pageSize);
        }

        public static AsyncPageable<T> CreateAsyncEnumerable<T>(
            Func<int?, Task<Page<T>>> firstPageFunc,
            Func<string, int?, Task<Page<T>>> firstPageSkipPast,
            Func<string, int?, Task<Page<T>>> nextPageFunc,
            int? pageSize = default) where T : notnull
        {
            AsyncPageFunc<T> first = (continuationToken, pageSizeHint) => firstPageFunc(pageSizeHint);
            AsyncPageFunc<T> skipPast = new AsyncPageFunc<T>(firstPageSkipPast);
            AsyncPageFunc<T> next = new AsyncPageFunc<T>(nextPageFunc);
            return new FuncAsyncPageable<T>(first, skipPast, next, pageSize);
        }

        internal delegate Task<Page<T>> AsyncPageFunc<T>(string continuationToken = default, int? pageSizeHint = default);
        internal delegate Page<T> PageFunc<T>(string continuationToken = default, int? pageSizeHint = default);

        internal class FuncAsyncPageable<T> : AsyncPageable<T> where T : notnull
        {
            private readonly AsyncPageFunc<T> _firstPageFunc;
            private readonly AsyncPageFunc<T> _skipPastPageFunc;
            private readonly AsyncPageFunc<T> _nextPageFunc;
            private readonly int? _defaultPageSize;

            public FuncAsyncPageable(AsyncPageFunc<T> firstPageFunc, AsyncPageFunc<T> skipPastPageFunc, AsyncPageFunc<T> nextPageFunc, int? defaultPageSize = default)
            {
                _firstPageFunc = firstPageFunc;
                _skipPastPageFunc = skipPastPageFunc;
                _nextPageFunc = nextPageFunc;
                _defaultPageSize = defaultPageSize;
            }

            public override async IAsyncEnumerable<Page<T>> AsPages(string continuationToken = default, int? pageSizeHint = default)
            {
                AsyncPageFunc<T> pageFunc = string.IsNullOrEmpty(continuationToken) ? _firstPageFunc : _skipPastPageFunc;

                if (pageFunc == null)
                {
                    yield break;
                }

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
            private readonly PageFunc<T> _skipPastPageFunc;
            private readonly PageFunc<T> _nextPageFunc;
            private readonly int? _defaultPageSize;

            public FuncPageable(PageFunc<T> firstPageFunc, PageFunc<T> skipPastPageFunc, PageFunc<T> nextPageFunc, int? defaultPageSize = default)
            {
                _firstPageFunc = firstPageFunc;
                _skipPastPageFunc = skipPastPageFunc;
                _nextPageFunc = nextPageFunc;
                _defaultPageSize = defaultPageSize;
            }

            public override IEnumerable<Page<T>> AsPages(string continuationToken = default, int? pageSizeHint = default)
            {
                PageFunc<T> pageFunc = string.IsNullOrEmpty(continuationToken) ? _firstPageFunc : _skipPastPageFunc;

                if (pageFunc == null)
                {
                    yield break;
                }

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
    }
}
