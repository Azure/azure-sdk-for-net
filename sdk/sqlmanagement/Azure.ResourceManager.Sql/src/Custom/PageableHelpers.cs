// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Sql
{
    internal static class PageableHelpers
    {
        public static Pageable<TOut> Wrap<TIn, TOut>(Pageable<TIn> source, Func<TIn, TOut> selector)
        {
            return Pageable<TOut>.FromPages(WrapPages(source, selector));
        }

        public static AsyncPageable<TOut> WrapAsync<TIn, TOut>(AsyncPageable<TIn> source, Func<TIn, TOut> selector)
        {
            return new WrappedAsyncPageable<TIn, TOut>(source, selector);
        }

        private static IEnumerable<Page<TOut>> WrapPages<TIn, TOut>(Pageable<TIn> source, Func<TIn, TOut> selector)
        {
            foreach (Page<TIn> page in source.AsPages())
            {
                yield return Page<TOut>.FromValues(page.Values.Select(selector).ToList(), page.ContinuationToken, page.GetRawResponse());
            }
        }

        private sealed class WrappedAsyncPageable<TIn, TOut> : AsyncPageable<TOut>
        {
            private readonly AsyncPageable<TIn> _source;
            private readonly Func<TIn, TOut> _selector;

            public WrappedAsyncPageable(AsyncPageable<TIn> source, Func<TIn, TOut> selector)
            {
                _source = source;
                _selector = selector;
            }

            public override async IAsyncEnumerable<Page<TOut>> AsPages(string continuationToken = null, int? pageSizeHint = null)
            {
                await foreach (Page<TIn> page in _source.AsPages(continuationToken, pageSizeHint).ConfigureAwait(false))
                {
                    yield return Page<TOut>.FromValues(page.Values.Select(_selector).ToList(), page.ContinuationToken, page.GetRawResponse());
                }
            }
        }
    }
}
