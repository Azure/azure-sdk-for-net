// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.ResourceManager.Confluent
{
    /// <summary>
    /// Helper class that wraps a Pageable and maps each item to a different type.
    /// Used for backward-compatible shim methods that return old model types.
    /// </summary>
    internal sealed class MappedPageable<TSource, TTarget> : Pageable<TTarget>
    {
        private readonly Pageable<TSource> _source;
        private readonly Func<TSource, TTarget> _map;

        public MappedPageable(Pageable<TSource> source, Func<TSource, TTarget> map)
        {
            _source = source;
            _map = map;
        }

        public override IEnumerable<Page<TTarget>> AsPages(string continuationToken = null, int? pageSizeHint = null)
        {
            foreach (var page in _source.AsPages(continuationToken, pageSizeHint))
            {
                yield return Page<TTarget>.FromValues(
                    page.Values.Select(_map).ToList(),
                    page.ContinuationToken,
                    page.GetRawResponse());
            }
        }
    }
}
