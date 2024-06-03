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
    public static PageableResult<T> Create<T>(Func<string?, PageResult<T>> getInitialPage, Func<string?, PageResult<T>>? getNextPage) where T : notnull
        => new FuncPageable<T>(getInitialPage, getNextPage);

    public static AsyncPageableResult<T> Create<T>(Func<string?, Task<PageResult<T>>> getInitialPage, Func<string?, Task<PageResult<T>>>? getNextPage) where T : notnull
        => new FuncAsyncPageable<T>(getInitialPage, getNextPage);

    private class FuncAsyncPageable<T> : AsyncPageableResult<T> where T : notnull
    {
        private readonly Func<string?, Task<PageResult<T>>> _getInitialPage;
        private readonly Func<string?, Task<PageResult<T>>>? _getNextPage;

        public FuncAsyncPageable(Func<string?, Task<PageResult<T>>> getInitialPage, Func<string?, Task<PageResult<T>>>? getNextPage)
        {
            _getInitialPage = getInitialPage;
            _getNextPage = getNextPage;
        }

        public override async IAsyncEnumerable<PageResult<T>> AsPages(string? pageToken = default)
        {
            Func<string?, Task<PageResult<T>>>? getPage = _getInitialPage;

            if (getPage == null)
            {
                yield break;
            }

            do
            {
                PageResult<T> page = await getPage(pageToken).ConfigureAwait(false);
                SetRawResponse(page.GetRawResponse());
                yield return page;
                pageToken = page.NextPageToken;
                getPage = _getNextPage;
            }
            while (!string.IsNullOrEmpty(pageToken) && getPage != null);
        }
    }

    private class FuncPageable<T> : PageableResult<T> where T : notnull
    {
        private readonly Func<string?, PageResult<T>> _getInitialPage;
        private readonly Func<string?, PageResult<T>>? _getNextPage;

        public FuncPageable(Func<string?, PageResult<T>> getInitialPage, Func<string?, PageResult<T>>? getNextPage)
        {
            _getInitialPage = getInitialPage;
            _getNextPage = getNextPage;
        }

        public override IEnumerable<PageResult<T>> AsPages(string? pageToken = default)
        {
            Func<string?, PageResult<T>>? getPage = _getInitialPage;

            if (getPage == null)
            {
                yield break;
            }

            do
            {
                PageResult<T> page = getPage(pageToken);
                SetRawResponse(page.GetRawResponse());
                yield return page;
                pageToken = page.NextPageToken;
                getPage = _getNextPage;
            }
            while (!string.IsNullOrEmpty(pageToken) && getPage != null);
        }
    }
}
