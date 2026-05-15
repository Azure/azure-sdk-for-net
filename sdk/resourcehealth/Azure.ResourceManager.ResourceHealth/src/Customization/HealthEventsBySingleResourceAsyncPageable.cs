// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward compatibility: async pageable for the "Events.getBySingleResource" operation.
// Async counterpart of HealthEventsBySingleResourcePageable. See that file for rationale.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.ResourceHealth
{
    /// <summary> Custom async pageable for health events by single resource. </summary>
    internal sealed class HealthEventsBySingleResourceAsyncPageable : AsyncPageable<ResourceHealthEventData>
    {
        private readonly ArmClient _client;
        private readonly ResourceIdentifier _scope;
        private readonly string _filter;
        private readonly CancellationToken _cancellationToken;

        public HealthEventsBySingleResourceAsyncPageable(ArmClient client, ResourceIdentifier scope, string filter, CancellationToken cancellationToken)
        {
            _client = client;
            _scope = scope;
            _filter = filter;
            _cancellationToken = cancellationToken;
        }

        /// <summary>
        /// Asynchronously enumerates pages by delegating to EventsBySingleResourceHelper.GetPagesAsync.
        /// </summary>
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
