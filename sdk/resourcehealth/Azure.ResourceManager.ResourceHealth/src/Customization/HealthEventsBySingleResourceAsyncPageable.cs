// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.ResourceHealth
{
    internal sealed class HealthEventsBySingleResourceAsyncPageable : AsyncPageable<ResourceHealthEventData>
    {
        private readonly ArmClient _client;
        private readonly ResourceIdentifier _scope;
        private readonly string _filter;
        private readonly CancellationToken _cancellationToken;

        // Async counterpart to HealthEventsBySingleResourcePageable for the same generator gap around Azure.Core.Page<Event>
        // in ArmProviderActionSync-based listBySingleResource operations, which would need a spec-level custom list-result model to eliminate this shim.
        public HealthEventsBySingleResourceAsyncPageable(ArmClient client, ResourceIdentifier scope, string filter, CancellationToken cancellationToken)
        {
            _client = client;
            _scope = scope;
            _filter = filter;
            _cancellationToken = cancellationToken;
        }

        // Delegates to the helper because only the REST client methods were generated for this operation, not the public async pageable surface.
        public override async IAsyncEnumerable<Page<ResourceHealthEventData>> AsPages(string continuationToken = null, int? pageSizeHint = null)
        {
            var helper = _client.GetCachedClient(c => new EventsBySingleResourceHelper(c, _scope));
            await foreach (var page in helper.GetPagesAsync(_filter, _cancellationToken).ConfigureAwait(false))
            {
                yield return page;
            }
        }
    }
}
