// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;

namespace Azure.Data.AppConfiguration
{
    internal class AsyncConditionalPageable : AsyncPageable<ConfigurationSetting>
    {
        private readonly ConditionalPageableImplementation _implementation;

        public AsyncConditionalPageable(ConditionalPageableImplementation implementation)
        {
            _implementation = implementation;
        }

        public override IAsyncEnumerator<ConfigurationSetting> GetAsyncEnumerator(CancellationToken cancellationToken = default) => _implementation.GetAsyncEnumerator(cancellationToken);
        public override IAsyncEnumerable<Page<ConfigurationSetting>> AsPages(string continuationToken = null, int? pageSizeHint = null) => _implementation.AsPagesAsync(Array.Empty<MatchConditions>(), continuationToken, pageSizeHint, default);
        public IAsyncEnumerable<Page<ConfigurationSetting>> AsPages(IEnumerable<MatchConditions> conditions, string continuationToken = null, int? pageSizeHint = null) => _implementation.AsPagesAsync(conditions, continuationToken, pageSizeHint, default);
    }
}
