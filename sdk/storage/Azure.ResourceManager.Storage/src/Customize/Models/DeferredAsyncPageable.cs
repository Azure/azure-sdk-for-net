// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Helper: Async paging adapter that defers fetch until enumeration and exposes one page.
// Used by backward-compat GetKeysAsync overload that wraps Response as AsyncPageable.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary>
    /// Wraps a single list of items into an AsyncPageable with one page.
    /// Defers the async call to AsPages enumeration time.
    /// </summary>
    internal class DeferredAsyncPageable<T> : AsyncPageable<T>
    {
        private readonly Func<Task<(IReadOnlyList<T> Items, Response Response)>> _factory;

        internal DeferredAsyncPageable(Func<Task<(IReadOnlyList<T> Items, Response Response)>> factory)
        {
            _factory = factory;
        }

        public override async IAsyncEnumerable<Page<T>> AsPages(string continuationToken = null, int? pageSizeHint = null)
        {
            var (items, response) = await _factory().ConfigureAwait(false);
            yield return Page<T>.FromValues(items, null, response);
        }
    }
}
