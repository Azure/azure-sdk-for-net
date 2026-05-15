// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward compatibility: mockable methods for ArmClient extension shims.
// The Azure SDK ValidateMockingPattern test requires that every public extension method on
// ResourceHealthExtensions has a corresponding virtual method with the same name and parameter
// list (minus the 'this' parameter) on the appropriate Mockable* class. These methods implement
// the actual logic that the extension methods delegate to. Without these, the mocking test fails
// because the extension methods would call generated methods directly instead of going through
// the mockable layer.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.ResourceHealth.Models;

namespace Azure.ResourceManager.ResourceHealth.Mocking
{
    public partial class MockableResourceHealthArmClient
    {
        /// <summary> Lists availability statuses for a resource. </summary>
        // Mockable counterpart of ResourceHealthExtensions.GetAvailabilityStatusesAsync(ArmClient, ...).
        // Wraps the generated GetAllAsync() which returns Pageable<AvailabilityStatusData>,
        // converting each item to ResourceHealthAvailabilityStatus via MappedAsyncPageable.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<ResourceHealthAvailabilityStatus> GetAvailabilityStatusesAsync(ResourceIdentifier scope, string filter, string expand, CancellationToken cancellationToken = default)
        {
            AsyncPageable<AvailabilityStatusData> inner = GetAllAsync(scope, filter, expand, cancellationToken);
            return new MappedAsyncPageable<AvailabilityStatusData, ResourceHealthAvailabilityStatus>(inner, ResourceHealthAvailabilityStatus.FromData);
        }

        /// <summary> Lists availability statuses for a resource. </summary>
        // Mockable counterpart of ResourceHealthExtensions.GetAvailabilityStatuses(ArmClient, ...).
        // Sync version of GetAvailabilityStatusesAsync.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<ResourceHealthAvailabilityStatus> GetAvailabilityStatuses(ResourceIdentifier scope, string filter, string expand, CancellationToken cancellationToken = default)
        {
            Pageable<AvailabilityStatusData> inner = GetAll(scope, filter, expand, cancellationToken);
            return new MappedPageable<AvailabilityStatusData, ResourceHealthAvailabilityStatus>(inner, ResourceHealthAvailabilityStatus.FromData);
        }

        /// <summary> Lists child resource availability statuses. </summary>
        // Mockable counterpart of ResourceHealthExtensions.GetAvailabilityStatusOfChildResourcesAsync(ArmClient, ...).
        // Uses the same GetAllAsync() internally — the GA SDK exposed separate methods for
        // parent and child resources but they hit similar REST endpoints.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<ResourceHealthAvailabilityStatus> GetAvailabilityStatusOfChildResourcesAsync(ResourceIdentifier scope, string filter, string expand, CancellationToken cancellationToken = default)
        {
            AsyncPageable<AvailabilityStatusData> inner = GetAllAsync(scope, filter, expand, cancellationToken);
            return new MappedAsyncPageable<AvailabilityStatusData, ResourceHealthAvailabilityStatus>(inner, ResourceHealthAvailabilityStatus.FromData);
        }

        /// <summary> Lists child resource availability statuses. </summary>
        // Mockable counterpart of ResourceHealthExtensions.GetAvailabilityStatusOfChildResources(ArmClient, ...).
        // Sync version of GetAvailabilityStatusOfChildResourcesAsync.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<ResourceHealthAvailabilityStatus> GetAvailabilityStatusOfChildResources(ResourceIdentifier scope, string filter, string expand, CancellationToken cancellationToken = default)
        {
            Pageable<AvailabilityStatusData> inner = GetAll(scope, filter, expand, cancellationToken);
            return new MappedPageable<AvailabilityStatusData, ResourceHealthAvailabilityStatus>(inner, ResourceHealthAvailabilityStatus.FromData);
        }

        /// <summary> Lists historical availability statuses of child resources. </summary>
        // Mockable counterpart of ResourceHealthExtensions.GetHistoricalAvailabilityStatusesOfChildResourceAsync(ArmClient, ...).
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<ResourceHealthAvailabilityStatus> GetHistoricalAvailabilityStatusesOfChildResourceAsync(ResourceIdentifier scope, string filter, string expand, CancellationToken cancellationToken = default)
        {
            AsyncPageable<AvailabilityStatusData> inner = GetAllAsync(scope, filter, expand, cancellationToken);
            return new MappedAsyncPageable<AvailabilityStatusData, ResourceHealthAvailabilityStatus>(inner, ResourceHealthAvailabilityStatus.FromData);
        }

        /// <summary> Lists historical availability statuses of child resources. </summary>
        // Mockable counterpart of ResourceHealthExtensions.GetHistoricalAvailabilityStatusesOfChildResource(ArmClient, ...).
        // Sync version of GetHistoricalAvailabilityStatusesOfChildResourceAsync.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<ResourceHealthAvailabilityStatus> GetHistoricalAvailabilityStatusesOfChildResource(ResourceIdentifier scope, string filter, string expand, CancellationToken cancellationToken = default)
        {
            Pageable<AvailabilityStatusData> inner = GetAll(scope, filter, expand, cancellationToken);
            return new MappedPageable<AvailabilityStatusData, ResourceHealthAvailabilityStatus>(inner, ResourceHealthAvailabilityStatus.FromData);
        }

        /// <summary> Gets current availability status for a single resource. </summary>
        // Mockable counterpart of ResourceHealthExtensions.GetAvailabilityStatusAsync(ArmClient, ...).
        // Gets AvailabilityStatusResource via scope resolver, calls Get(), wraps result.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<ResourceHealthAvailabilityStatus>> GetAvailabilityStatusAsync(ResourceIdentifier scope, string filter, string expand, CancellationToken cancellationToken = default)
        {
            var resource = GetAvailabilityStatus(scope);
            Response<AvailabilityStatusResource> response = await resource.GetAsync(filter, expand, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(ResourceHealthAvailabilityStatus.FromData(response.Value.Data), response.GetRawResponse());
        }

        /// <summary> Gets current availability status for a single resource. </summary>
        // Mockable counterpart of ResourceHealthExtensions.GetAvailabilityStatus(ArmClient, ...).
        // Sync version of GetAvailabilityStatusAsync.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ResourceHealthAvailabilityStatus> GetAvailabilityStatus(ResourceIdentifier scope, string filter, string expand, CancellationToken cancellationToken = default)
        {
            var resource = GetAvailabilityStatus(scope);
            Response<AvailabilityStatusResource> response = resource.Get(filter, expand, cancellationToken);
            return Response.FromValue(ResourceHealthAvailabilityStatus.FromData(response.Value.Data), response.GetRawResponse());
        }

        /// <summary> Gets current availability status for a single child resource. </summary>
        // Mockable counterpart of ResourceHealthExtensions.GetAvailabilityStatusOfChildResourceAsync(ArmClient, ...).
        // Gets ChildAvailabilityStatusResource via scope resolver, calls Get(), wraps result.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<ResourceHealthAvailabilityStatus>> GetAvailabilityStatusOfChildResourceAsync(ResourceIdentifier scope, string filter, string expand, CancellationToken cancellationToken = default)
        {
            var resource = GetChildAvailabilityStatus(scope);
            Response<ChildAvailabilityStatusResource> response = await resource.GetAsync(filter, expand, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(ResourceHealthAvailabilityStatus.FromData(response.Value.Data), response.GetRawResponse());
        }

        /// <summary> Gets current availability status for a single child resource. </summary>
        // Mockable counterpart of ResourceHealthExtensions.GetAvailabilityStatusOfChildResource(ArmClient, ...).
        // Sync version of GetAvailabilityStatusOfChildResourceAsync.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ResourceHealthAvailabilityStatus> GetAvailabilityStatusOfChildResource(ResourceIdentifier scope, string filter, string expand, CancellationToken cancellationToken = default)
        {
            var resource = GetChildAvailabilityStatus(scope);
            Response<ChildAvailabilityStatusResource> response = resource.Get(filter, expand, cancellationToken);
            return Response.FromValue(ResourceHealthAvailabilityStatus.FromData(response.Value.Data), response.GetRawResponse());
        }

        /// <summary> Lists health events for a single resource. </summary>
        // Mockable counterpart of ResourceHealthExtensions.GetHealthEventsOfSingleResourceAsync(ArmClient, ...).
        // Uses custom HealthEventsBySingleResourceAsyncPageable because the generator does not
        // expose Events.getBySingleResource as a public API — only the internal REST client exists.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<ResourceHealthEventData> GetHealthEventsOfSingleResourceAsync(ResourceIdentifier scope, string filter, CancellationToken cancellationToken = default)
        {
            return new HealthEventsBySingleResourceAsyncPageable(Client, scope, filter, cancellationToken);
        }

        /// <summary> Lists health events for a single resource. </summary>
        // Mockable counterpart of ResourceHealthExtensions.GetHealthEventsOfSingleResource(ArmClient, ...).
        // Sync version using HealthEventsBySingleResourcePageable.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<ResourceHealthEventData> GetHealthEventsOfSingleResource(ResourceIdentifier scope, string filter, CancellationToken cancellationToken = default)
        {
            return new HealthEventsBySingleResourcePageable(Client, scope, filter, cancellationToken);
        }
    }
}