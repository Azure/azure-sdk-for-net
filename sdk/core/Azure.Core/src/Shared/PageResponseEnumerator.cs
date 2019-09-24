// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.Core
{
    internal static class PageResponseEnumerator
    {

        public static FuncSyncCollection<T> CreateEnumerable<T>(Func<string?, Page<T>> pageFunc) where T : notnull
        {
            return new FuncSyncCollection<T>((continuationToken, pageSizeHint) => pageFunc(continuationToken));
        }

        public static FuncSyncCollection<T> CreateEnumerable<T>(Func<string?, int?, Page<T>> pageFunc) where T : notnull
        {
            return new FuncSyncCollection<T>(pageFunc);
        }

        public static AsyncCollection<T> CreateAsyncEnumerable<T>(Func<string?, Task<Page<T>>> pageFunc) where T : notnull
        {
            return new FuncAsyncCollection<T>((continuationToken, pageSizeHint) => pageFunc(continuationToken));
        }

        public static AsyncCollection<T> CreateAsyncEnumerable<T>(Func<string?, int?, Task<Page<T>>> pageFunc) where T : notnull
        {
            return new FuncAsyncCollection<T>(pageFunc);
        }

        internal class FuncAsyncCollection<T> : AsyncCollection<T> where T : notnull
        {
            private readonly Func<string?, int?, Task<Page<T>>> _pageFunc;

            public FuncAsyncCollection(Func<string?, int?, Task<Page<T>>> pageFunc)
            {
                _pageFunc = pageFunc;
            }

            public override async IAsyncEnumerable<Page<T>> ByPage(string? continuationToken = default, int? pageSizeHint = default)
            {
                do
                {
                    Page<T> pageResponse = await _pageFunc(continuationToken, pageSizeHint).ConfigureAwait(false);
                    yield return pageResponse;
                    continuationToken = pageResponse.ContinuationToken;
                } while (continuationToken != null);
            }
        }

        internal class FuncSyncCollection<T> : SyncCollection<T> where T : notnull
        {
            private readonly Func<string?, int?, Page<T>> _pageFunc;

            public FuncSyncCollection(Func<string?, int?, Page<T>> pageFunc)
            {
                _pageFunc = pageFunc;
            }

            public override IEnumerable<Page<T>> ByPage(string? continuationToken = default, int? pageSizeHint = default)
            {
                do
                {
                    Page<T> pageResponse = _pageFunc(continuationToken, pageSizeHint);
                    yield return pageResponse;
                    continuationToken = pageResponse.ContinuationToken;
                } while (continuationToken != null);
            }
        }
    }
}
