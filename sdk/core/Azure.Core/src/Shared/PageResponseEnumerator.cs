// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core
{
    internal static class PageResponseEnumerator
    {
        public static IEnumerable<Response<T>> CreateEnumerable<T>(Func<string, Page<T>> pageFunc)
        {
            string nextLink = null;
            do
            {
                Page<T> pageResponse = pageFunc(nextLink);
                foreach (T setting in pageResponse.Values)
                {
                    yield return new Response<T>(pageResponse.GetRawResponse(), setting);
                }
                nextLink = pageResponse.ContinuationToken;
            } while (nextLink != null);
        }

        public static AsyncCollection<T> CreateAsyncEnumerable<T>(Func<string, Task<Page<T>>> pageFunc)
        {
            return new FuncAsyncCollection<T>((continuationToken, pageSizeHint) => pageFunc(continuationToken));
        }

        public static AsyncCollection<T> CreateAsyncEnumerable<T>(Func<string, int?, Task<Page<T>>> pageFunc)
        {
            return new FuncAsyncCollection<T>(pageFunc);
        }

        internal class FuncAsyncCollection<T>: AsyncCollection<T>
        {
            private readonly Func<string, int?, Task<Page<T>>> _pageFunc;

            public FuncAsyncCollection(Func<string, int?, Task<Page<T>>> pageFunc)
            {
                _pageFunc = pageFunc;
            }

            public override async IAsyncEnumerable<Page<T>> ByPage(string continuationToken = default, int? pageSizeHint = default)
            {
                do
                {
                    Page<T> pageResponse = await _pageFunc(continuationToken, pageSizeHint).ConfigureAwait(false);
                    yield return pageResponse;
                    continuationToken = pageResponse.ContinuationToken;
                } while (continuationToken != null);
            }
        }
    }
}
