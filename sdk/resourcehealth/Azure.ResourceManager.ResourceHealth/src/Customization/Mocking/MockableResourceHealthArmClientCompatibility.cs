// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.ResourceHealth.Models;

namespace Azure.ResourceManager.ResourceHealth.Mocking
{
    public partial class MockableResourceHealthArmClient
    {
        private ClientDiagnostics _childAvailabilityStatusesClientDiagnostics;
        private ChildAvailabilityStatuses _childAvailabilityStatusesRestClient;
        private ClientDiagnostics _eventsClientDiagnostics;
        private Events _eventsRestClient;

        private ClientDiagnostics ChildAvailabilityStatusesClientDiagnostics => _childAvailabilityStatusesClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.ResourceHealth.Mocking", ProviderConstants.DefaultProviderNamespace, Diagnostics);
        private ChildAvailabilityStatuses ChildAvailabilityStatusesRestClient => _childAvailabilityStatusesRestClient ??= new ChildAvailabilityStatuses(ChildAvailabilityStatusesClientDiagnostics, Pipeline, Endpoint, "2025-05-01");
        private ClientDiagnostics EventsClientDiagnostics => _eventsClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.ResourceHealth.Mocking", ProviderConstants.DefaultProviderNamespace, Diagnostics);
        private Events EventsRestClient => _eventsRestClient ??= new Events(EventsClientDiagnostics, Pipeline, Endpoint, "2025-05-01");

        // The generator only emits the low-level Events REST operation for this arbitrary resource URI scope.
        // This customization preserves the GA ArmClient/mockable API and wraps that REST operation in a pageable result.
        /// <summary> Lists service health events for a single resource. </summary>
        public virtual AsyncPageable<ResourceHealthEventData> GetHealthEventsOfSingleResourceAsync(ResourceIdentifier scope, string filter = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(scope, nameof(scope));
            return new GetHealthEventsOfSingleResourceAsyncCollectionResult(EventsRestClient, scope.ToString(), filter, CreateRequestContext(cancellationToken));
        }

        // The generator only emits the low-level Events REST operation for this arbitrary resource URI scope.
        // This customization preserves the GA ArmClient/mockable API and wraps that REST operation in a pageable result.
        /// <summary> Lists service health events for a single resource. </summary>
        public virtual Pageable<ResourceHealthEventData> GetHealthEventsOfSingleResource(ResourceIdentifier scope, string filter = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(scope, nameof(scope));
            return new GetHealthEventsOfSingleResourceCollectionResult(EventsRestClient, scope.ToString(), filter, CreateRequestContext(cancellationToken));
        }

        private static RequestContext CreateRequestContext(CancellationToken cancellationToken)
        {
            return new RequestContext
            {
                CancellationToken = cancellationToken
            };
        }
    }
}
