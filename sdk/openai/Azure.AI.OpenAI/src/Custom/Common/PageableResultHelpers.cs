// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;

#nullable enable

namespace Azure.AI.OpenAI;

internal class PageableResultHelpers
{
    public static PageableCollection<T> Create<T>(Func<int?, ResultPage<T>> firstPageFunc, Func<string?, int?, ResultPage<T>>? nextPageFunc, int? pageSize = default) where T : notnull
    {
        ResultPage<T> first(string? _, int? pageSizeHint) => firstPageFunc(pageSizeHint);
        return new FuncPageable<T>(first, nextPageFunc, pageSize);
    }

    public static AsyncPageableCollection<T> Create<T>(Func<int?, Task<ResultPage<T>>> firstPageFunc, Func<string?, int?, Task<ResultPage<T>>>? nextPageFunc, int? pageSize = default) where T : notnull
    {
        Task<ResultPage<T>> first(string? _, int? pageSizeHint) => firstPageFunc(pageSizeHint);
        return new FuncAsyncPageable<T>(first, nextPageFunc, pageSize);
    }

    private class FuncAsyncPageable<T> : AsyncPageableCollection<T> where T : notnull
    {
        private readonly Func<string?, int?, Task<ResultPage<T>>> _firstPageFunc;
        private readonly Func<string?, int?, Task<ResultPage<T>>>? _nextPageFunc;
        private readonly int? _defaultPageSize;

        public FuncAsyncPageable(Func<string?, int?, Task<ResultPage<T>>> firstPageFunc, Func<string?, int?, Task<ResultPage<T>>>? nextPageFunc, int? defaultPageSize = default)
        {
            _firstPageFunc = firstPageFunc;
            _nextPageFunc = nextPageFunc;
            _defaultPageSize = defaultPageSize;
        }

        public override async IAsyncEnumerable<ResultPage<T>> AsPages(string? continuationToken = default, int? pageSizeHint = default)
        {
            Func<string?, int?, Task<ResultPage<T>>>? pageFunc = string.IsNullOrEmpty(continuationToken) ? _firstPageFunc : _nextPageFunc;

            if (pageFunc == null)
            {
                yield break;
            }

            int? pageSize = pageSizeHint ?? _defaultPageSize;
            do
            {
                ResultPage<T> page = await pageFunc(continuationToken, pageSize).ConfigureAwait(false);
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
        private readonly Func<string?, int?, ResultPage<T>> _firstPageFunc;
        private readonly Func<string?, int?, ResultPage<T>>? _nextPageFunc;
        private readonly int? _defaultPageSize;

        public FuncPageable(Func<string?, int?, ResultPage<T>> firstPageFunc, Func<string?, int?, ResultPage<T>>? nextPageFunc, int? defaultPageSize = default)
        {
            _firstPageFunc = firstPageFunc;
            _nextPageFunc = nextPageFunc;
            _defaultPageSize = defaultPageSize;
        }

        public override IEnumerable<ResultPage<T>> AsPages(string? continuationToken = default, int? pageSizeHint = default)
        {
            Func<string?, int?, ResultPage<T>>? pageFunc = string.IsNullOrEmpty(continuationToken) ? _firstPageFunc : _nextPageFunc;

            if (pageFunc == null)
            {
                yield break;
            }

            int? pageSize = pageSizeHint ?? _defaultPageSize;
            do
            {
                ResultPage<T> page = pageFunc(continuationToken, pageSize);
                SetRawResponse(page.GetRawResponse());
                yield return page;
                continuationToken = page.ContinuationToken;
                pageFunc = _nextPageFunc;
            }
            while (!string.IsNullOrEmpty(continuationToken) && pageFunc != null);
        }
    }
}
