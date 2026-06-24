// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.ResourceHealth.Models;

namespace Azure.ResourceManager.ResourceHealth.Mocking
{
    // Workaround for https://github.com/Azure/azure-sdk-for-net/issues/60100: the generator emits only the
    // low-level Events REST operation for this extension-scope (arbitrary resourceUri) list. Wrap it in a
    // pageable result so the GA ArmClient/mockable API is preserved.
    // TODO: Remove once the emitter ships the #60102 fix that emits this method directly.
    public partial class MockableResourceHealthArmClient
    {
        private ClientDiagnostics _eventsClientDiagnostics;
        private Events _eventsRestClient;

        private ClientDiagnostics EventsClientDiagnostics => _eventsClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.ResourceHealth.Mocking", ProviderConstants.DefaultProviderNamespace, Diagnostics);
        private Events EventsRestClient => _eventsRestClient ??= new Events(EventsClientDiagnostics, Pipeline, Endpoint, "2025-05-01");

        /// <summary> Lists service health events for a single resource. </summary>
        public virtual AsyncPageable<ResourceHealthEventData> GetHealthEventsOfSingleResourceAsync(ResourceIdentifier scope, string filter = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(scope, nameof(scope));
            return new GetHealthEventsOfSingleResourceAsyncCollectionResult(EventsRestClient, scope.ToString(), filter, CreateRequestContext(cancellationToken));
        }

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
