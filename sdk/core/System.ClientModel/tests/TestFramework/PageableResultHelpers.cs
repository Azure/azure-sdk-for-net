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
    public static PageableCollection<T> Create<T>(Func<string?, PageResult<T>> firstPageFunc, Func<string?, PageResult<T>>? nextPageFunc) where T : notnull
        => new FuncPageable<T>(firstPageFunc, nextPageFunc);

    public static AsyncPageableCollection<T> Create<T>(Func<string?, Task<PageResult<T>>> firstPageFunc, Func<string?, Task<PageResult<T>>>? nextPageFunc) where T : notnull
        => new FuncAsyncPageable<T>(firstPageFunc, nextPageFunc);

    private class FuncAsyncPageable<T> : AsyncPageableCollection<T> where T : notnull
    {
        private readonly Func<string?, Task<PageResult<T>>> _firstPageFunc;
        private readonly Func<string?, Task<PageResult<T>>>? _nextPageFunc;

        public FuncAsyncPageable(Func<string?, Task<PageResult<T>>> firstPageFunc, Func<string?, Task<PageResult<T>>>? nextPageFunc)
        {
            _firstPageFunc = firstPageFunc;
            _nextPageFunc = nextPageFunc;
        }

        public override async IAsyncEnumerable<PageResult<T>> AsPagesAsync(string? continuationToken = default)
        {
            Func<string?, Task<PageResult<T>>>? pageFunc = _firstPageFunc;

            if (pageFunc == null)
            {
                yield break;
            }

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

        public FuncPageable(Func<string?, PageResult<T>> firstPageFunc, Func<string?, PageResult<T>>? nextPageFunc)
        {
            _firstPageFunc = firstPageFunc;
            _nextPageFunc = nextPageFunc;
        }

        public override IEnumerable<PageResult<T>> AsPages(string? continuationToken = default)
        {
            Func<string?, PageResult<T>>? pageFunc = _firstPageFunc;

            if (pageFunc == null)
            {
                yield break;
            }

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
