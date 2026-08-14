// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.ResourceManager.Confluent
{
    /// <summary>
    /// Helper class that wraps an AsyncPageable and maps each item to a different type.
    /// Used for backward-compatible shim methods that return old model types.
    /// </summary>
    internal sealed class MappedAsyncPageable<TSource, TTarget> : AsyncPageable<TTarget>
    {
        private readonly AsyncPageable<TSource> _source;
        private readonly Func<TSource, TTarget> _map;

        public MappedAsyncPageable(AsyncPageable<TSource> source, Func<TSource, TTarget> map)
        {
            _source = source;
            _map = map;
        }

        public override async IAsyncEnumerable<Page<TTarget>> AsPages(string continuationToken = null, int? pageSizeHint = null)
        {
#pragma warning disable AZC0100 // ConfigureAwait(false) is not supported on IAsyncEnumerable in all target frameworks
            await foreach (var page in _source.AsPages(continuationToken, pageSizeHint))
#pragma warning restore AZC0100
            {
                yield return Page<TTarget>.FromValues(
                    page.Values.Select(_map).ToList(),
                    page.ContinuationToken,
                    page.GetRawResponse());
            }
        }
    }
}
