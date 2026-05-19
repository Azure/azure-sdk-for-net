// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.ResourceHealth
{
    internal sealed class HealthEventsBySingleResourcePageable : Pageable<ResourceHealthEventData>
    {
        private readonly ArmClient _client;
        private readonly ResourceIdentifier _scope;
        private readonly string _filter;
        private readonly CancellationToken _cancellationToken;

        // This exists because the EventsOperationGroup.listBySingleResource spec uses ArmProviderActionSync with Response = Azure.Core.Page<Event>,
        // so the mgmt generator emits the REST request builders but does not emit the CollectionResult or public pageable method.
        // @markAsPageable cannot fix that because the operation is already marked as a list; the real fix would be a spec-level custom list-result model with explicit @pageItems/@nextLink.
        public HealthEventsBySingleResourcePageable(ArmClient client, ResourceIdentifier scope, string filter, CancellationToken cancellationToken)
        {
            _client = client;
            _scope = scope;
            _filter = filter;
            _cancellationToken = cancellationToken;
        }

        // Reuses the helper that manually drives the generated REST requests and converts their Azure.Core.Page<Event> payload into SDK pages.
        public override IEnumerable<Page<ResourceHealthEventData>> AsPages(string continuationToken = null, int? pageSizeHint = null)
        {
            var helper = _client.GetCachedClient(c => new EventsBySingleResourceHelper(c, _scope));
            return helper.GetPages(_filter, _cancellationToken);
        }
    }
}
