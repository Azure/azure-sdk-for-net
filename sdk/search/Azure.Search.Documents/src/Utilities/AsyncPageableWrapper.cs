// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure;

namespace Azure.Search.Documents.Utilities
{
    internal partial class AsyncPageableWrapper<T, U> : AsyncPageable<U>
    {
        private readonly AsyncPageable<T> _source;
        private readonly Func<T, U> _converter;

        public AsyncPageableWrapper(AsyncPageable<T> source, Func<T, U> converter)
        {
            _source = source;
            _converter = converter;
        }

        public override async IAsyncEnumerable<Page<U>> AsPages(string continuationToken = null, int? pageSizeHint = null)
        {
            await foreach (Page<T> page in _source.AsPages(continuationToken, pageSizeHint).ConfigureAwait(false))
            {
                List<U> convertedItems = new List<U>();
                foreach (T item in page.Values)
                {
                    convertedItems.Add(_converter(item));
                }
                yield return Page<U>.FromValues(convertedItems, page.ContinuationToken, page.GetRawResponse());
            }
        }
    }
}
