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
    public static PageableCollection<T> Create<T>(Func<int?, ClientPage<T>> firstPageFunc, Func<string?, int?, ClientPage<T>>? nextPageFunc, int? pageSize = default) where T : notnull
    {
        ClientPage<T> first(string? _, int? pageSizeHint) => firstPageFunc(pageSizeHint);
        return new FuncPageable<T>(first, nextPageFunc, pageSize);
    }

    public static AsyncPageableCollection<T> Create<T>(Func<int?, Task<ClientPage<T>>> firstPageFunc, Func<string?, int?, Task<ClientPage<T>>>? nextPageFunc, int? pageSize = default) where T : notnull
    {
        Task<ClientPage<T>> first(string? _, int? pageSizeHint) => firstPageFunc(pageSizeHint);
        return new FuncAsyncPageable<T>(first, nextPageFunc, pageSize);
    }

    public static ClientPage<T> CreatePage<T>(IEnumerable<T> items,
            string? continuationToken,
            PipelineResponse response)
        => new EnumerablePage<T>(items, continuationToken, response);

    private class FuncAsyncPageable<T> : AsyncPageableCollection<T> where T : notnull
    {
        private readonly Func<string?, int?, Task<ClientPage<T>>> _firstPageFunc;
        private readonly Func<string?, int?, Task<ClientPage<T>>>? _nextPageFunc;
        private readonly int? _defaultPageSize;

        public FuncAsyncPageable(Func<string?, int?, Task<ClientPage<T>>> firstPageFunc, Func<string?, int?, Task<ClientPage<T>>>? nextPageFunc, int? defaultPageSize = default)
        {
            _firstPageFunc = firstPageFunc;
            _nextPageFunc = nextPageFunc;
            _defaultPageSize = defaultPageSize;
        }

        public override async IAsyncEnumerable<ClientPage<T>> AsPages(string? continuationToken = default, int? pageSizeHint = default)
        {
            Func<string?, int?, Task<ClientPage<T>>>? pageFunc = string.IsNullOrEmpty(continuationToken) ? _firstPageFunc : _nextPageFunc;

            if (pageFunc == null)
            {
                yield break;
            }

            int? pageSize = pageSizeHint ?? _defaultPageSize;
            do
            {
                ClientPage<T> pageResponse = await pageFunc(continuationToken, pageSize).ConfigureAwait(false);
                yield return pageResponse;
                continuationToken = pageResponse.ContinuationToken;
                pageFunc = _nextPageFunc;
            }
            while (!string.IsNullOrEmpty(continuationToken) && pageFunc != null);
        }
    }

    private class FuncPageable<T> : PageableCollection<T> where T : notnull
    {
        private readonly Func<string?, int?, ClientPage<T>> _firstPageFunc;
        private readonly Func<string?, int?, ClientPage<T>>? _nextPageFunc;
        private readonly int? _defaultPageSize;

        public FuncPageable(Func<string?, int?, ClientPage<T>> firstPageFunc, Func<string?, int?, ClientPage<T>>? nextPageFunc, int? defaultPageSize = default)
        {
            _firstPageFunc = firstPageFunc;
            _nextPageFunc = nextPageFunc;
            _defaultPageSize = defaultPageSize;
        }

        public override IEnumerable<ClientPage<T>> AsPages(string? continuationToken = default, int? pageSizeHint = default)
        {
            Func<string?, int?, ClientPage<T>>? pageFunc = string.IsNullOrEmpty(continuationToken) ? _firstPageFunc : _nextPageFunc;

            if (pageFunc == null)
            {
                yield break;
            }

            int? pageSize = pageSizeHint ?? _defaultPageSize;
            do
            {
                ClientPage<T> pageResponse = pageFunc(continuationToken, pageSize);
                yield return pageResponse;
                continuationToken = pageResponse.ContinuationToken;
                pageFunc = _nextPageFunc;
            }
            while (!string.IsNullOrEmpty(continuationToken) && pageFunc != null);
        }
    }

    private class EnumerablePage<T> : ClientPage<T>
    {
        private readonly IEnumerable<T> _items;

        public EnumerablePage(IEnumerable<T> items,
            string? continuationToken,
            PipelineResponse response)
            : base(response)
        {
            _items = items;
            ContinuationToken = continuationToken;
        }

        public override IEnumerator<T> GetEnumerator()
            => _items.GetEnumerator();
    }
}
