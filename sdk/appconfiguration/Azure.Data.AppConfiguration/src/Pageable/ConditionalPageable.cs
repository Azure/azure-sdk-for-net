// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Data.AppConfiguration
{
    internal class ConditionalPageable : Pageable<ConfigurationSetting>
    {
        private readonly ConditionalPageableImplementation _implementation;

        public ConditionalPageable(ConditionalPageableImplementation implementation)
        {
            _implementation = implementation;
        }

        public override IEnumerable<Page<ConfigurationSetting>> AsPages(string continuationToken = null, int? pageSizeHint = null) => _implementation.AsPages(Array.Empty<MatchConditions>(), continuationToken, pageSizeHint);
        public IEnumerable<Page<ConfigurationSetting>> AsPages(IEnumerable<MatchConditions> conditions, string continuationToken = null, int? pageSizeHint = null) => _implementation.AsPages(conditions, continuationToken, pageSizeHint);
    }
}
