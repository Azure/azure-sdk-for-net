// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Helper: Sync paging adapter wrapping an in-memory list as a single-page Pageable<T>.
// Used by backward-compat GetKeys overload that wraps Response as Pageable.

using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary>
    /// Wraps a single list of items into a Pageable with one page.
    /// Used for backward-compat where the old API returned Pageable but the new returns Response.
    /// </summary>
    internal class SinglePagePageable<T> : Pageable<T>
    {
        private readonly IReadOnlyList<T> _items;
        private readonly Response _response;

        internal SinglePagePageable(IReadOnlyList<T> items, Response response)
        {
            _items = items;
            _response = response;
        }

        public override IEnumerable<Page<T>> AsPages(string continuationToken = null, int? pageSizeHint = null)
        {
            yield return Page<T>.FromValues(_items, null, _response);
        }
    }
}
