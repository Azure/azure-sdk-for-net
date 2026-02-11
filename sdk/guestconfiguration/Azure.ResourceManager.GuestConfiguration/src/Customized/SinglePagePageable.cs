// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.ResourceManager.GuestConfiguration
{
    /// <summary> A Pageable that wraps a single-page list result. </summary>
    internal class SinglePagePageable<T> : Pageable<T> where T : notnull
    {
        private readonly Func<(IList<T> Values, Response RawResponse)> _getValues;

        public SinglePagePageable(Func<(IList<T> Values, Response RawResponse)> getValues)
        {
            _getValues = getValues;
        }

        public override IEnumerable<Page<T>> AsPages(string continuationToken = null, int? pageSizeHint = null)
        {
            var result = _getValues();
            yield return Page<T>.FromValues(result.Values.ToList().AsReadOnly(), null, result.RawResponse);
        }
    }
}
