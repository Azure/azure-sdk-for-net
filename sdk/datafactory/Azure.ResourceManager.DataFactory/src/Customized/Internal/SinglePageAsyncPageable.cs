// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.ResourceManager.DataFactory
{
    // Async counterpart of SinglePagePageable<T>; see that file for the full rationale. Wraps the
    // single Response<Wrapper> emitted by the MPG generator for spec-paged operations into a
    // one-page AsyncPageable<TItem>, matching the pre-MPG AutoRest SDK API surface.
    internal sealed class SinglePageAsyncPageable<T> : AsyncPageable<T>
    {
        private readonly Response _rawResponse;
        private readonly IReadOnlyList<T> _values;

        public SinglePageAsyncPageable(IReadOnlyList<T> values, Response rawResponse)
        {
            _values = values ?? new List<T>();
            _rawResponse = rawResponse;
        }

        public override async IAsyncEnumerable<Page<T>> AsPages(string continuationToken = null, int? pageSizeHint = null)
        {
            await Task.CompletedTask.ConfigureAwait(false);
            yield return Page<T>.FromValues(_values, null, _rawResponse);
        }
    }
}
