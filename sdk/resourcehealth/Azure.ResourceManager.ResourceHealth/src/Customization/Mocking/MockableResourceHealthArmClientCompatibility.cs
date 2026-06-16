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

        /// <summary> Gets current availability status for a single resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<ResourceHealthAvailabilityStatus>> GetAvailabilityStatusAsync(ResourceIdentifier scope, string filter = default, string expand = default, CancellationToken cancellationToken = default)
        {
            Response<AvailabilityStatusResource> response = await GetAvailabilityStatus(scope).GetAsync(filter, expand, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(ResourceHealthAvailabilityStatus.FromData(response.Value.Data), response.GetRawResponse());
        }

        /// <summary> Gets current availability status for a single resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ResourceHealthAvailabilityStatus> GetAvailabilityStatus(ResourceIdentifier scope, string filter = default, string expand = default, CancellationToken cancellationToken = default)
        {
            Response<AvailabilityStatusResource> response = GetAvailabilityStatus(scope).Get(filter, expand, cancellationToken);
            return Response.FromValue(ResourceHealthAvailabilityStatus.FromData(response.Value.Data), response.GetRawResponse());
        }

        /// <summary> Lists the all the children and its current health status for a parent resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<ResourceHealthAvailabilityStatus> GetAvailabilityStatusesAsync(ResourceIdentifier scope, string filter = default, string expand = default, CancellationToken cancellationToken = default)
        {
            return GetAvailabilityStatusOfChildResourcesAsync(scope, filter, expand, cancellationToken);
        }

        /// <summary> Lists the all the children and its current health status for a parent resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<ResourceHealthAvailabilityStatus> GetAvailabilityStatuses(ResourceIdentifier scope, string filter = default, string expand = default, CancellationToken cancellationToken = default)
        {
            return GetAvailabilityStatusOfChildResources(scope, filter, expand, cancellationToken);
        }

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

        /// <summary> Lists child resource historical availability statuses. </summary>
        public virtual AsyncPageable<ResourceHealthAvailabilityStatus> GetHistoricalAvailabilityStatusesOfChildResourceAsync(ResourceIdentifier scope, string filter = default, string expand = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(scope, nameof(scope));
            AsyncPageable<ResourceHealthAvailabilityStatusData> statuses = new GetHistoricalAvailabilityStatusesOfChildResourceAsyncCollectionResult(ChildAvailabilityStatusesRestClient, scope.ToString(), filter, expand, CreateRequestContext(cancellationToken));
            return new AsyncPageableWrapper<ResourceHealthAvailabilityStatusData, ResourceHealthAvailabilityStatus>(statuses, ResourceHealthAvailabilityStatus.FromData);
        }

        /// <summary> Lists child resource historical availability statuses. </summary>
        public virtual Pageable<ResourceHealthAvailabilityStatus> GetHistoricalAvailabilityStatusesOfChildResource(ResourceIdentifier scope, string filter = default, string expand = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(scope, nameof(scope));
            Pageable<ResourceHealthAvailabilityStatusData> statuses = new GetHistoricalAvailabilityStatusesOfChildResourceCollectionResult(ChildAvailabilityStatusesRestClient, scope.ToString(), filter, expand, CreateRequestContext(cancellationToken));
            return new PageableWrapper<ResourceHealthAvailabilityStatusData, ResourceHealthAvailabilityStatus>(statuses, ResourceHealthAvailabilityStatus.FromData);
        }

        /// <summary> Lists child resources and their current health status for a parent resource. </summary>
        public virtual AsyncPageable<ResourceHealthAvailabilityStatus> GetAvailabilityStatusOfChildResourcesAsync(ResourceIdentifier scope, string filter = default, string expand = default, CancellationToken cancellationToken = default)
        {
            AsyncPageable<ResourceHealthAvailabilityStatusData> statuses = GetAvailabilityStatusOfChildResourceDataAsync(scope, filter, expand, cancellationToken);
            return new AsyncPageableWrapper<ResourceHealthAvailabilityStatusData, ResourceHealthAvailabilityStatus>(statuses, ResourceHealthAvailabilityStatus.FromData);
        }

        /// <summary> Lists child resources and their current health status for a parent resource. </summary>
        public virtual Pageable<ResourceHealthAvailabilityStatus> GetAvailabilityStatusOfChildResources(ResourceIdentifier scope, string filter = default, string expand = default, CancellationToken cancellationToken = default)
        {
            Pageable<ResourceHealthAvailabilityStatusData> statuses = GetAvailabilityStatusOfChildResourceData(scope, filter, expand, cancellationToken);
            return new PageableWrapper<ResourceHealthAvailabilityStatusData, ResourceHealthAvailabilityStatus>(statuses, ResourceHealthAvailabilityStatus.FromData);
        }

        /// <summary> Gets current availability status for a child resource. </summary>
        public virtual async Task<Response<ResourceHealthAvailabilityStatus>> GetAvailabilityStatusOfChildResourceAsync(ResourceIdentifier scope, string filter = default, string expand = default, CancellationToken cancellationToken = default)
        {
            Response<ChildAvailabilityStatusResource> response = await GetChildAvailabilityStatus(scope).GetAsync(filter, expand, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(ResourceHealthAvailabilityStatus.FromData(response.Value.Data), response.GetRawResponse());
        }

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
