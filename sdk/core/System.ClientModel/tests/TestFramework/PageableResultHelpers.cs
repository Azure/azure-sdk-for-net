// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientModel.Tests.Internal;

//internal class PageableResultHelpers
//{
//    public static PageableResult<T> Create<T>(Func<string, ClientPage<T>> getInitialPage, Func<string, ClientPage<T>>? getNextPage) where T : notnull
//        => new FuncPageable<T>(getInitialPage, getNextPage);

//    public static AsyncPageableResult<T> Create<T>(Func<string, Task<ClientPage<T>>> getInitialPage, Func<string, Task<ClientPage<T>>>? getNextPage) where T : notnull
//        => new FuncAsyncPageable<T>(getInitialPage, getNextPage);

//    private class FuncAsyncPageable<T> : AsyncPageableResult<T> where T : notnull
//    {
//        private readonly Func<string, Task<ClientPage<T>>> _getInitialPage;
//        private readonly Func<string, Task<ClientPage<T>>>? _getNextPage;

//        public FuncAsyncPageable(Func<string, Task<ClientPage<T>>> getInitialPage, Func<string, Task<ClientPage<T>>>? getNextPage)
//        {
//            _getInitialPage = getInitialPage;
//            _getNextPage = getNextPage;
//        }

//        protected override async IAsyncEnumerable<ClientPage<T>> AsPagesCore(string pageToken)
//        {
//            Func<string, Task<ClientPage<T>>>? getPage = _getInitialPage;

//            if (getPage == null)
//            {
//                yield break;
//            }

//            string? requestPageToken = pageToken;

//            while (requestPageToken != null && getPage != null)
//            {
//                ClientPage<T> page = await getPage(requestPageToken).ConfigureAwait(false);
//                SetRawResponse(page.GetRawResponse());
//                yield return page;
//                requestPageToken = page.NextPageToken;
//                getPage = _getNextPage;
//            }
//        }
//    }

//    private class FuncPageable<T> : PageableResult<T> where T : notnull
//    {
//        private readonly Func<string, ClientPage<T>> _getInitialPage;
//        private readonly Func<string, ClientPage<T>>? _getNextPage;

//        public FuncPageable(Func<string, ClientPage<T>> getInitialPage, Func<string, ClientPage<T>>? getNextPage)
//        {
//            _getInitialPage = getInitialPage;
//            _getNextPage = getNextPage;
//        }

//        protected override IEnumerable<ClientPage<T>> AsPagesCore(string pageToken)
//        {
//            Func<string, ClientPage<T>>? getPage = _getInitialPage;

//            if (getPage == null)
//            {
//                yield break;
//            }

//            string? requestPageToken = pageToken;

//            while (requestPageToken != null && getPage != null)
//            {
//                ClientPage<T> page = getPage(requestPageToken);
//                SetRawResponse(page.GetRawResponse());
//                yield return page;
//                requestPageToken = page.NextPageToken;
//                getPage = _getNextPage;
//            }
//        }
//    }
//}
