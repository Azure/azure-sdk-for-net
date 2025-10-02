// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Data.AppConfiguration
{
    internal class ConditionalPageable<T> : Pageable<T>
    {
        private readonly ConditionalPageableImplementation<T> _implementation;

        public ConditionalPageable(ConditionalPageableImplementation<T> implementation)
        {
            _implementation = implementation;
        }

        public override IEnumerable<Page<T>> AsPages(string continuationToken = null, int? pageSizeHint = null) => _implementation.AsPages(Array.Empty<MatchConditions>(), continuationToken, pageSizeHint);
        public IEnumerable<Page<T>> AsPages(IEnumerable<MatchConditions> conditions, string continuationToken = null, int? pageSizeHint = null) => _implementation.AsPages(conditions, continuationToken, pageSizeHint);
    }
}
