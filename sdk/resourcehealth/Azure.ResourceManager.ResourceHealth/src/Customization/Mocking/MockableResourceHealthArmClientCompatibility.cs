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

        // This customization preserves the GA GetAvailabilityStatuses* mockable API while forwarding to the generated child-resource availability status list operation.
        /// <summary> Lists the all the children and its current health status for a parent resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<ResourceHealthAvailabilityStatus> GetAvailabilityStatusesAsync(ResourceIdentifier scope, string filter = default, string expand = default, CancellationToken cancellationToken = default)
        {
            return GetAvailabilityStatusOfChildResourcesAsync(scope, filter, expand, cancellationToken);
        }
        // This customization preserves the GA GetAvailabilityStatuses* mockable API while forwarding to the generated child-resource availability status list operation.
        /// <summary> Lists the all the children and its current health status for a parent resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<ResourceHealthAvailabilityStatus> GetAvailabilityStatuses(ResourceIdentifier scope, string filter = default, string expand = default, CancellationToken cancellationToken = default)
        {
            return GetAvailabilityStatusOfChildResources(scope, filter, expand, cancellationToken);
        }
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

        /// <summary> Lists child resource historical availability statuses. </summary>
        public virtual AsyncPageable<ResourceHealthAvailabilityStatus> GetHistoricalAvailabilityStatusesOfChildResourceAsync(ResourceIdentifier scope, string filter = default, string expand = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(scope, nameof(scope));
            return new GetHistoricalAvailabilityStatusesOfChildResourceAsyncCollectionResult(ChildAvailabilityStatusesRestClient, scope.ToString(), filter, expand, CreateRequestContext(cancellationToken));
        }

        /// <summary> Lists child resource historical availability statuses. </summary>
        public virtual Pageable<ResourceHealthAvailabilityStatus> GetHistoricalAvailabilityStatusesOfChildResource(ResourceIdentifier scope, string filter = default, string expand = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(scope, nameof(scope));
            return new GetHistoricalAvailabilityStatusesOfChildResourceCollectionResult(ChildAvailabilityStatusesRestClient, scope.ToString(), filter, expand, CreateRequestContext(cancellationToken));
        }

        /// <summary> Gets current availability status for a child resource. </summary>
        public virtual async Task<Response<ResourceHealthAvailabilityStatus>> GetAvailabilityStatusOfChildResourceAsync(ResourceIdentifier scope, string filter = default, string expand = default, CancellationToken cancellationToken = default)
        {
            Response response = await GetChildResponseAsync(scope, filter, expand, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(ResourceHealthAvailabilityStatus.FromResponse(response), response);
        }

        /// <summary> Gets current availability status for a child resource. </summary>
        public virtual Response<ResourceHealthAvailabilityStatus> GetAvailabilityStatusOfChildResource(ResourceIdentifier scope, string filter = default, string expand = default, CancellationToken cancellationToken = default)
        {
            Response response = GetChildResponse(scope, filter, expand, cancellationToken);
            return Response.FromValue(ResourceHealthAvailabilityStatus.FromResponse(response), response);
        }

        private async Task<Response> GetChildResponseAsync(ResourceIdentifier scope, string filter, string expand, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(scope, nameof(scope));
            RequestContext context = CreateRequestContext(cancellationToken);
            HttpMessage message = ChildAvailabilityStatusesRestClient.CreateGetAvailabilityStatusOfChildResourceRequest(scope.ToString(), filter, expand, context);
            using DiagnosticScope scopeDiagnostics = ChildAvailabilityStatusesRestClient.ClientDiagnostics.CreateScope("MockableResourceHealthArmClient.GetAvailabilityStatusOfChildResource");
            scopeDiagnostics.Start();
            try
            {
                return await ChildAvailabilityStatusesRestClient.Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scopeDiagnostics.Failed(e);
                throw;
            }
        }

        private Response GetChildResponse(ResourceIdentifier scope, string filter, string expand, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(scope, nameof(scope));
            RequestContext context = CreateRequestContext(cancellationToken);
            HttpMessage message = ChildAvailabilityStatusesRestClient.CreateGetAvailabilityStatusOfChildResourceRequest(scope.ToString(), filter, expand, context);
            using DiagnosticScope scopeDiagnostics = ChildAvailabilityStatusesRestClient.ClientDiagnostics.CreateScope("MockableResourceHealthArmClient.GetAvailabilityStatusOfChildResource");
            scopeDiagnostics.Start();
            try
            {
                return ChildAvailabilityStatusesRestClient.Pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scopeDiagnostics.Failed(e);
                throw;
            }
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
