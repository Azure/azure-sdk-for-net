// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azure.ResourceManager.GuestConfiguration
{
    /// <summary> An AsyncPageable that wraps a single-page list result. </summary>
    internal class SinglePageAsyncPageable<T> : AsyncPageable<T> where T : notnull
    {
        private readonly Func<Task<(IList<T> Values, Response RawResponse)>> _getValuesAsync;

        public SinglePageAsyncPageable(Func<Task<(IList<T> Values, Response RawResponse)>> getValuesAsync)
        {
            _getValuesAsync = getValuesAsync;
        }

#pragma warning disable 1998
        public override async IAsyncEnumerable<Page<T>> AsPages(string continuationToken = null, int? pageSizeHint = null)
        {
            var result = await _getValuesAsync().ConfigureAwait(false);
            yield return Page<T>.FromValues(result.Values.ToList().AsReadOnly(), null, result.RawResponse);
        }
#pragma warning restore 1998
    }
}
