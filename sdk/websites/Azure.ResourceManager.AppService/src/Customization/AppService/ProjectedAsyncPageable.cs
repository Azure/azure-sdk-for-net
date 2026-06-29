// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.AppService
{
    internal sealed class ProjectedAsyncPageable<TIn, TOut> : AsyncPageable<TOut>
    {
        private readonly AsyncPageable<TIn> _inner;
        private readonly Func<TIn, TOut> _convert;

        public ProjectedAsyncPageable(AsyncPageable<TIn> inner, Func<TIn, TOut> convert)
        {
            _inner = inner;
            _convert = convert;
        }

        public override async IAsyncEnumerable<Page<TOut>> AsPages(string continuationToken = null, int? pageSizeHint = null)
        {
#pragma warning disable AZC0100
            await foreach (var page in _inner.AsPages(continuationToken, pageSizeHint))
#pragma warning restore AZC0100
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
