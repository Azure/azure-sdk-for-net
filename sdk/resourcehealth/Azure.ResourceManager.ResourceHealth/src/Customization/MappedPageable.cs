// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Infrastructure: generic sync pageable wrapper that transforms each item from TSource to TResult.
// Required because GA 1.0.0 returned Pageable<ResourceHealthAvailabilityStatus> but the new SDK
// returns Pageable<AvailabilityStatusData> or Pageable<AvailabilityStatusResource>. The SDK
// framework does not provide a built-in type-mapping Pageable, so this custom implementation
// wraps an inner pageable and applies a selector function to each item.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure;

namespace Azure.ResourceManager.ResourceHealth
{
    /// <summary> A pageable that transforms each item from TSource to TResult. </summary>
    internal sealed class MappedPageable<TSource, TResult> : Pageable<TResult>
    {
        private readonly Pageable<TSource> _source;
        private readonly Func<TSource, TResult> _selector;

        public MappedPageable(Pageable<TSource> source, Func<TSource, TResult> selector)
        {
            _source = source;
            _selector = selector;
        }

        /// <summary> Enumerates pages, applying the selector to each item in every page. </summary>
        public override IEnumerable<Page<TResult>> AsPages(string continuationToken = null, int? pageSizeHint = null)
        {
            foreach (Page<TSource> page in _source.AsPages(continuationToken, pageSizeHint))
            {
                var items = page.Values.Select(_selector).ToArray();
                yield return Page<TResult>.FromValues(items, page.ContinuationToken, page.GetRawResponse());
            }
        }
    }
}
