// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.AppService
{
    // ROOT CAUSE: Sibling to ProjectedArmOperation — used by the GA compatibility shims (e.g. the
    // by-location helpers and the GetVipInfo* projection) to translate a generated Pageable<TIn>
    // into the GA Pageable<TOut> the previous SDK version returned. The generator does not emit
    // a pageable-projection helper, so this hand-written wrapper composes an inner Pageable<TIn>
    // with a Func<TIn, TOut> to convert each page.
    internal sealed class ProjectedPageable<TIn, TOut> : Pageable<TOut>
    {
        private readonly Pageable<TIn> _inner;
        private readonly Func<TIn, TOut> _convert;

        public ProjectedPageable(Pageable<TIn> inner, Func<TIn, TOut> convert)
        {
            _inner = inner;
            _convert = convert;
        }

        public override IEnumerable<Page<TOut>> AsPages(string continuationToken = null, int? pageSizeHint = null)
        {
            foreach (var page in _inner.AsPages(continuationToken, pageSizeHint))
            {
                var converted = new List<TOut>(page.Values.Count);
                foreach (var v in page.Values)
                {
                    converted.Add(_convert(v));
                }
                yield return Page<TOut>.FromValues(converted, page.ContinuationToken, page.GetRawResponse());
            }
        }
    }
}
