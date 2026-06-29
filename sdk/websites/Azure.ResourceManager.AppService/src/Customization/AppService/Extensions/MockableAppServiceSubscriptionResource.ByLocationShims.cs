// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.AppService.Models;

// ROOT CAUSE: GA 1.5.0 exposed a number of "by location" helpers on the
// Subscription / Tenant resources, plus a misnamed `GetGetUsagesInLocations`
// and `GetDeletedWebAppByLocationDeletedWebApp`. The new TypeSpec emitter
// exposes them taking `string location` instead of the GA `AzureLocation`,
// and renames the deleted-site-by-location lookups to a collection-based API
// (`GetDeletedSiteAtLocations(location).GetAll/Get`). Add overload shims that
// preserve the GA signatures and project results back to the GA resource
// type (DeletedSiteResource).
namespace Azure.ResourceManager.AppService.Mocking
{
    public partial class MockableAppServiceSubscriptionResource
    {
        /// <summary> Description for Get all deleted apps for a subscription at location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<DeletedSiteResource> GetDeletedSitesByLocationAsync(AzureLocation location, CancellationToken cancellationToken = default)
            => AppServiceCompatShims.ProjectAsyncPageable(
                GetDeletedSiteAtLocations(location.ToString()).GetAllAsync(cancellationToken),
                atLoc => new DeletedSiteResource(Client, atLoc.Data));

        /// <summary> Description for Get all deleted apps for a subscription at location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<DeletedSiteResource> GetDeletedSitesByLocation(AzureLocation location, CancellationToken cancellationToken = default)
            => AppServiceCompatShims.ProjectPageable(
                GetDeletedSiteAtLocations(location.ToString()).GetAll(cancellationToken),
                atLoc => new DeletedSiteResource(Client, atLoc.Data));

        /// <summary> Description for Get a deleted app for a subscription at location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DeletedSiteResource>> GetDeletedWebAppByLocationDeletedWebAppAsync(AzureLocation location, string deletedSiteId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(deletedSiteId, nameof(deletedSiteId));
            Response<DeletedSiteAtLocationResource> response = await GetDeletedSiteAtLocations(location.ToString()).GetAsync(deletedSiteId, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new DeletedSiteResource(Client, response.Value.Data), response.GetRawResponse());
        }

        /// <summary> Description for Get a deleted app for a subscription at location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DeletedSiteResource> GetDeletedWebAppByLocationDeletedWebApp(AzureLocation location, string deletedSiteId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(deletedSiteId, nameof(deletedSiteId));
            Response<DeletedSiteAtLocationResource> response = GetDeletedSiteAtLocations(location.ToString()).Get(deletedSiteId, cancellationToken);
            return Response.FromValue(new DeletedSiteResource(Client, response.Value.Data), response.GetRawResponse());
        }

        /// <summary> Description for Gets the usage quotas for the App Service plans in the given location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<CsmUsageQuota> GetGetUsagesInLocationsAsync(AzureLocation location, CancellationToken cancellationToken = default)
            => GetGetUsagesInLocationsAsync(location.ToString(), cancellationToken);

        /// <summary> Description for Gets the usage quotas for the App Service plans in the given location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<CsmUsageQuota> GetGetUsagesInLocations(AzureLocation location, CancellationToken cancellationToken = default)
            => GetGetUsagesInLocations(location.ToString(), cancellationToken);

        /// <summary> Description for Check the availability of a DNL resource name. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<DnlResourceNameAvailabilityResult>> CheckDnlResourceNameAvailabilityAsync(AzureLocation location, DnlResourceNameAvailabilityContent content, CancellationToken cancellationToken = default)
            => CheckDnlResourceNameAvailabilityAsync(location.ToString(), content, cancellationToken);

        /// <summary> Description for Check the availability of a DNL resource name. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DnlResourceNameAvailabilityResult> CheckDnlResourceNameAvailability(AzureLocation location, DnlResourceNameAvailabilityContent content, CancellationToken cancellationToken = default)
            => CheckDnlResourceNameAvailability(location.ToString(), content, cancellationToken);

        /// <summary> Description for Preview the GitHub Actions workflow for a Static Site. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<StaticSitesWorkflowPreview>> PreviewStaticSiteWorkflowAsync(AzureLocation location, StaticSitesWorkflowPreviewContent content, CancellationToken cancellationToken = default)
            => PreviewStaticSiteWorkflowAsync(location.ToString(), content, cancellationToken);

        /// <summary> Description for Preview the GitHub Actions workflow for a Static Site. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<StaticSitesWorkflowPreview> PreviewStaticSiteWorkflow(AzureLocation location, StaticSitesWorkflowPreviewContent content, CancellationToken cancellationToken = default)
            => PreviewStaticSiteWorkflow(location.ToString(), content, cancellationToken);
    }
}
