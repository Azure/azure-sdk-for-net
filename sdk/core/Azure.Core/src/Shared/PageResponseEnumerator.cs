// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.Core
{
    internal static class PageResponseEnumerator
    {
        public static IEnumerable<Response<T>> CreateEnumerable<T>(Func<string, PageResponse<T>> pageFunc)
        {
            string nextLink = null;
            do
            {
                PageResponse<T> pageResponse = pageFunc(nextLink);
                foreach (T setting in pageResponse.Values)
                {
                    yield return new Response<T>(pageResponse.Response, setting);
                }
                nextLink = pageResponse.NextLink;
            } while (nextLink != null);
        }

        public static async IAsyncEnumerable<Response<T>> CreateAsyncEnumerable<T>(Func<string, Task<PageResponse<T>>> pageFunc)
        {
            string nextLink = null;
            do
            {
                PageResponse<T> pageResponse = await pageFunc(nextLink).ConfigureAwait(false);
                foreach (T setting in pageResponse.Values)
                {
                    yield return new Response<T>(pageResponse.Response, setting);
                }
                nextLink = pageResponse.NextLink;
            } while (nextLink != null);
        }
    }
}
