// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure;

namespace Azure.ResourceManager.DataFactory
{
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
