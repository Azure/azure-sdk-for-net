// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure;

namespace Azure.ResourceManager.DataFactory
{
    // Single-page Pageable used to convert MPG-emitted Response<TWrapper> (which contains an IList of items)
    // back to the upstream Pageable<TItem> back-compat surface. The MPG generator dropped the x-ms-pageable
    // marker from the openapi spec when migrating to TypeSpec, so paged list operations are emitted as a
    // single non-paged ProcessMessage call. These helpers wrap that single response into a one-page enumerable
    // so the public API matches the GA surface.
    internal sealed class SinglePagePageable<T> : Pageable<T>
    {
        private readonly Response _rawResponse;
        private readonly IReadOnlyList<T> _values;

        public SinglePagePageable(IReadOnlyList<T> values, Response rawResponse)
        {
            _values = values ?? new List<T>();
            _rawResponse = rawResponse;
        }

        public override IEnumerable<Page<T>> AsPages(string continuationToken = null, int? pageSizeHint = null)
        {
            yield return Page<T>.FromValues(_values, null, _rawResponse);
        }
    }
}
