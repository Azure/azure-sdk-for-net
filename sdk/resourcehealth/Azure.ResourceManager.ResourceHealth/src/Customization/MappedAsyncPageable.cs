// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure;

namespace Azure.ResourceManager.ResourceHealth
{
    internal sealed class MappedAsyncPageable<TSource, TResult> : AsyncPageable<TResult>
    {
        private readonly AsyncPageable<TSource> _source;
        private readonly Func<TSource, TResult> _selector;

        // This is the async counterpart to MappedPageable and exists for the same GA-compat type conversion,
        // not because the generator failed to recognize the operation as pageable.
        public MappedAsyncPageable(AsyncPageable<TSource> source, Func<TSource, TResult> selector)
        {
            _source = source;
            _selector = selector;
        }

        // Applies the compatibility mapping to every item in every generated async page while preserving paging metadata.
        public override async IAsyncEnumerable<Page<TResult>> AsPages(string continuationToken = null, int? pageSizeHint = null)
        {
            await foreach (Page<TSource> page in _source.AsPages(continuationToken, pageSizeHint).ConfigureAwait(false))
            {
                var items = page.Values.Select(_selector).ToArray();
                yield return Page<TResult>.FromValues(items, page.ContinuationToken, page.GetRawResponse());
            }
        }
    }
}
