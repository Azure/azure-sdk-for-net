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

        // This customization preserves the GA GetAvailabilityStatus* mockable API by unwrapping the generated AvailabilityStatusResource and converting its Data to the old model type.
        /// <summary> Gets current availability status for a single resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<ResourceHealthAvailabilityStatus>> GetAvailabilityStatusAsync(ResourceIdentifier scope, string filter = default, string expand = default, CancellationToken cancellationToken = default)
        {
            Response<AvailabilityStatusResource> response = await GetAvailabilityStatus(scope).GetAsync(filter, expand, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(ResourceHealthAvailabilityStatus.FromData(response.Value.Data), response.GetRawResponse());
        }
        // This customization preserves the GA GetAvailabilityStatus* mockable API by unwrapping the generated AvailabilityStatusResource and converting its Data to the old model type.
        /// <summary> Gets current availability status for a single resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ResourceHealthAvailabilityStatus> GetAvailabilityStatus(ResourceIdentifier scope, string filter = default, string expand = default, CancellationToken cancellationToken = default)
        {
            Response<AvailabilityStatusResource> response = GetAvailabilityStatus(scope).Get(filter, expand, cancellationToken);
            return Response.FromValue(ResourceHealthAvailabilityStatus.FromData(response.Value.Data), response.GetRawResponse());
        }
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

        // The REST layer returns ResourceHealthAvailabilityStatusData items, while the
        // GA-compatible public API returns ResourceHealthAvailabilityStatus items.
        // Wrap the generated pageable and convert each Data instance to the GA model.
        /// <summary> Lists child resource historical availability statuses. </summary>
        public virtual AsyncPageable<ResourceHealthAvailabilityStatus> GetHistoricalAvailabilityStatusesOfChildResourceAsync(ResourceIdentifier scope, string filter = default, string expand = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(scope, nameof(scope));
            AsyncPageable<ResourceHealthAvailabilityStatusData> statuses = new GetHistoricalAvailabilityStatusesOfChildResourceAsyncCollectionResult(ChildAvailabilityStatusesRestClient, scope.ToString(), filter, expand, CreateRequestContext(cancellationToken));
            return new AsyncPageableWrapper<ResourceHealthAvailabilityStatusData, ResourceHealthAvailabilityStatus>(statuses, ResourceHealthAvailabilityStatus.FromData);
        }

        // The REST layer returns ResourceHealthAvailabilityStatusData items, while the
        // GA-compatible public API returns ResourceHealthAvailabilityStatus items.
        // Wrap the generated pageable and convert each Data instance to the GA model.
        /// <summary> Lists child resource historical availability statuses. </summary>
        public virtual Pageable<ResourceHealthAvailabilityStatus> GetHistoricalAvailabilityStatusesOfChildResource(ResourceIdentifier scope, string filter = default, string expand = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(scope, nameof(scope));
            Pageable<ResourceHealthAvailabilityStatusData> statuses = new GetHistoricalAvailabilityStatusesOfChildResourceCollectionResult(ChildAvailabilityStatusesRestClient, scope.ToString(), filter, expand, CreateRequestContext(cancellationToken));
            return new PageableWrapper<ResourceHealthAvailabilityStatusData, ResourceHealthAvailabilityStatus>(statuses, ResourceHealthAvailabilityStatus.FromData);
        }

        // The generated child-resource list operation returns ResourceHealthAvailabilityStatusData
        // and is intentionally named GetAvailabilityStatusOfChildResourceData* to avoid
        // colliding with the GA-compatible GetAvailabilityStatusOfChildResources* methods.
        // C# cannot overload methods by return type only, so the compatibility methods keep
        // the old public names and wrap the generated Data pageable into ResourceHealthAvailabilityStatus.
        /// <summary> Lists child resources and their current health status for a parent resource. </summary>
        public virtual AsyncPageable<ResourceHealthAvailabilityStatus> GetAvailabilityStatusOfChildResourcesAsync(ResourceIdentifier scope, string filter = default, string expand = default, CancellationToken cancellationToken = default)
        {
            AsyncPageable<ResourceHealthAvailabilityStatusData> statuses = GetAvailabilityStatusOfChildResourceDataAsync(scope, filter, expand, cancellationToken);
            return new AsyncPageableWrapper<ResourceHealthAvailabilityStatusData, ResourceHealthAvailabilityStatus>(statuses, ResourceHealthAvailabilityStatus.FromData);
        }

        // The generated child-resource list operation returns ResourceHealthAvailabilityStatusData
        // and is intentionally named GetAvailabilityStatusOfChildResourceData* to avoid
        // colliding with the GA-compatible GetAvailabilityStatusOfChildResources* methods.
        // C# cannot overload methods by return type only, so the compatibility methods keep
        // the old public names and wrap the generated Data pageable into ResourceHealthAvailabilityStatus.
        /// <summary> Lists child resources and their current health status for a parent resource. </summary>
        public virtual Pageable<ResourceHealthAvailabilityStatus> GetAvailabilityStatusOfChildResources(ResourceIdentifier scope, string filter = default, string expand = default, CancellationToken cancellationToken = default)
        {
            Pageable<ResourceHealthAvailabilityStatusData> statuses = GetAvailabilityStatusOfChildResourceData(scope, filter, expand, cancellationToken);
            return new PageableWrapper<ResourceHealthAvailabilityStatusData, ResourceHealthAvailabilityStatus>(statuses, ResourceHealthAvailabilityStatus.FromData);
        }

        // The generated get operation returns a ChildAvailabilityStatusResource wrapper,
        // but the GA-compatible API returns ResourceHealthAvailabilityStatus directly.
        // Unwrap the resource Data and convert it to the GA model while preserving the raw response.
        /// <summary> Gets current availability status for a child resource. </summary>
        public virtual async Task<Response<ResourceHealthAvailabilityStatus>> GetAvailabilityStatusOfChildResourceAsync(ResourceIdentifier scope, string filter = default, string expand = default, CancellationToken cancellationToken = default)
        {
            Response<ChildAvailabilityStatusResource> response = await GetChildAvailabilityStatus(scope).GetAsync(filter, expand, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(ResourceHealthAvailabilityStatus.FromData(response.Value.Data), response.GetRawResponse());
        }

        // The generated get operation returns a ChildAvailabilityStatusResource wrapper,
        // but the GA-compatible API returns ResourceHealthAvailabilityStatus directly.
        // Unwrap the resource Data and convert it to the GA model while preserving the raw response.
        /// <summary> Gets current availability status for a child resource. </summary>
        public virtual Response<ResourceHealthAvailabilityStatus> GetAvailabilityStatusOfChildResource(ResourceIdentifier scope, string filter = default, string expand = default, CancellationToken cancellationToken = default)
        {
            Response<ChildAvailabilityStatusResource> response = GetChildAvailabilityStatus(scope).Get(filter, expand, cancellationToken);
            return Response.FromValue(ResourceHealthAvailabilityStatus.FromData(response.Value.Data), response.GetRawResponse());
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
