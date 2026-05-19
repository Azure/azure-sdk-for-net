// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure;

namespace Azure.ResourceManager.ResourceHealth
{
    internal sealed class MappedPageable<TSource, TResult> : Pageable<TResult>
    {
        private readonly Pageable<TSource> _source;
        private readonly Func<TSource, TResult> _selector;

        // This wrapper exists because the pageable operations are already generated correctly as pageable,
        // but GA 1.0.0 returned a different item type. We need to transform each generated item to the GA-compatible type,
        // and @markAsPageable cannot help because this is a type-conversion problem, not pageable recognition.
        public MappedPageable(Pageable<TSource> source, Func<TSource, TResult> selector)
        {
            _source = source;
            _selector = selector;
        }

        // Applies the compatibility mapping to every item in every generated page while preserving continuation tokens and responses.
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
