// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Infrastructure: generic async pageable wrapper that transforms each item from TSource to TResult.
// Async counterpart of MappedPageable<TSource, TResult>. See MappedPageable.cs for rationale.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure;

namespace Azure.ResourceManager.ResourceHealth
{
    /// <summary> An async pageable that transforms each item from TSource to TResult. </summary>
    internal sealed class MappedAsyncPageable<TSource, TResult> : AsyncPageable<TResult>
    {
        private readonly AsyncPageable<TSource> _source;
        private readonly Func<TSource, TResult> _selector;

        public MappedAsyncPageable(AsyncPageable<TSource> source, Func<TSource, TResult> selector)
        {
            _source = source;
            _selector = selector;
        }

        /// <summary> Asynchronously enumerates pages, applying the selector to each item. </summary>
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
