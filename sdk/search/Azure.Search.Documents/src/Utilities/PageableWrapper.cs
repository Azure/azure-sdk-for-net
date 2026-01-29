// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure;

namespace Azure.Search.Documents.Utilities
{
    internal partial class PageableWrapper<T, U> : Pageable<U>
    {
        private readonly Pageable<T> _source;
        private readonly Func<T, U> _converter;

        public PageableWrapper(Pageable<T> source, Func<T, U> converter)
        {
            _source = source;
            _converter = converter;
        }

        public override IEnumerable<Page<U>> AsPages(string continuationToken = null, int? pageSizeHint = null)
        {
            foreach (Page<T> page in _source.AsPages(continuationToken, pageSizeHint))
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
