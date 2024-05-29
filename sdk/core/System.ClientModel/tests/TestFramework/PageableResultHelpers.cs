// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientModel.Tests.Internal;

internal class PageableResultHelpers
{
    public static PageableCollection<T> Create<T>(Func<PageResult<T>> firstPageFunc, Func<string?, PageResult<T>>? nextPageFunc) where T : notnull
    {
        PageResult<T> first(string? _) => firstPageFunc();
        return new FuncPageable<T>(first, nextPageFunc);
    }

    public static AsyncPageableCollection<T> Create<T>(Func<Task<PageResult<T>>> firstPageFunc, Func<string?, Task<PageResult<T>>>? nextPageFunc) where T : notnull
    {
        Task<PageResult<T>> first(string? _) => firstPageFunc();
        return new FuncAsyncPageable<T>(first, nextPageFunc);
    }

    private class FuncAsyncPageable<T> : AsyncPageableCollection<T> where T : notnull
    {
        private readonly Func<string?, Task<PageResult<T>>> _firstPageFunc;
        private readonly Func<string?, Task<PageResult<T>>>? _nextPageFunc;

        public FuncAsyncPageable(Func<string?, Task<PageResult<T>>> firstPageFunc, Func<string?, Task<PageResult<T>>>? nextPageFunc)
        {
            _firstPageFunc = firstPageFunc;
            _nextPageFunc = nextPageFunc;
        }

        public override async IAsyncEnumerable<PageResult<T>> AsPagesAsync()
        {
            Func<string?, Task<PageResult<T>>>? pageFunc = _firstPageFunc;

            if (pageFunc == null)
            {
                yield break;
            }

            // contract in this experiment is that first call to pagefunc includes
            // the collection's page offset in a closure.
            string? continuationToken = null;

            do
            {
                PageResult<T> page = await pageFunc(continuationToken).ConfigureAwait(false);
                SetRawResponse(page.GetRawResponse());
                yield return page;
                continuationToken = page.ContinuationToken;
                pageFunc = _nextPageFunc;
            }
            while (!string.IsNullOrEmpty(continuationToken) && pageFunc != null);
        }
    }

    private class FuncPageable<T> : PageableCollection<T> where T : notnull
    {
        private readonly Func<string?, PageResult<T>> _firstPageFunc;
        private readonly Func<string?, PageResult<T>>? _nextPageFunc;

        public FuncPageable(Func<string?, PageResult<T>> firstPageFunc, Func<string?, PageResult<T>>? nextPageFunc, int? defaultPageSize = default)
        {
            _firstPageFunc = firstPageFunc;
            _nextPageFunc = nextPageFunc;
        }

        public override IEnumerable<PageResult<T>> AsPages()
        {
            Func<string?, PageResult<T>>? pageFunc = _firstPageFunc;

            if (pageFunc == null)
            {
                yield break;
            }

            string? continuationToken = null;

            do
            {
                PageResult<T> page = pageFunc(continuationToken);
                SetRawResponse(page.GetRawResponse());
                yield return page;
                continuationToken = page.ContinuationToken;
                pageFunc = _nextPageFunc;
            }
            while (!string.IsNullOrEmpty(continuationToken) && pageFunc != null);
        }
    }
}
