// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;

namespace Azure.Data.AppConfiguration
{
    internal class AsyncConditionalPageable<T> : AsyncPageable<T>
    {
        private readonly ConditionalPageableImplementation<T> _implementation;

        public AsyncConditionalPageable(ConditionalPageableImplementation<T> implementation)
        {
            _implementation = implementation;
        }

        public override IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default) => _implementation.GetAsyncEnumerator(cancellationToken);
        public override IAsyncEnumerable<Page<T>> AsPages(string continuationToken = null, int? pageSizeHint = null) => _implementation.AsPagesAsync(Array.Empty<MatchConditions>(), continuationToken, pageSizeHint, default);
        public IAsyncEnumerable<Page<T>> AsPages(IEnumerable<MatchConditions> conditions, string continuationToken = null, int? pageSizeHint = null) => _implementation.AsPagesAsync(conditions, continuationToken, pageSizeHint, default);
    }
}
