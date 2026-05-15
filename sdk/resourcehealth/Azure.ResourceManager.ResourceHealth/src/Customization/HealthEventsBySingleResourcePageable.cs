// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward compatibility: sync pageable for the "Events.getBySingleResource" operation.
// GA 1.0.0 exposed GetHealthEventsOfSingleResource(scope, filter) which listed service health
// events scoped to a single resource. The TypeSpec generator does not expose this operation as
// a public pageable on any generated resource class — only the internal REST client method
// Events.CreateGetBySingleResourceRequest exists. This custom pageable uses
// EventsBySingleResourceHelper (an ArmResource subclass) to access the pipeline and REST client,
// then yields pages of ResourceHealthEventData.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.ResourceHealth
{
    /// <summary> Custom pageable for health events by single resource. </summary>
    internal sealed class HealthEventsBySingleResourcePageable : Pageable<ResourceHealthEventData>
    {
        private readonly ArmClient _client;
        private readonly ResourceIdentifier _scope;
        private readonly string _filter;
        private readonly CancellationToken _cancellationToken;

        public HealthEventsBySingleResourcePageable(ArmClient client, ResourceIdentifier scope, string filter, CancellationToken cancellationToken)
        {
            _client = client;
            _scope = scope;
            _filter = filter;
            _cancellationToken = cancellationToken;
        }

        /// <summary>
        /// Enumerates pages of ResourceHealthEventData by delegating to EventsBySingleResourceHelper.GetPages.
        /// Uses ArmClient.GetCachedClient to reuse the helper across calls for the same scope.
        /// </summary>
        public override IEnumerable<Page<ResourceHealthEventData>> AsPages(string continuationToken = null, int? pageSizeHint = null)
        {
            var helper = _client.GetCachedClient(c => new EventsBySingleResourceHelper(c, _scope));
            return helper.GetPages(_filter, _cancellationToken);
        }
    }
}