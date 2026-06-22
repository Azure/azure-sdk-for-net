// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.ResourceManager.DataFactory
{
    // Single-page Pageable<T> used only by DataFactoryResource.GetTriggers, which must return
    // Pageable<DataFactoryTriggerResource> (the resource wrapper). @@Legacy.markAsPageable cannot
    // produce that shape because it pages over the TriggerResource data items, so GetTriggers stays
    // hand-written and wraps the single Response<envelope> into a one-page Pageable<TItem> here to
    // match the pre-MPG (AutoRest) API surface without touching the wire format.
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
