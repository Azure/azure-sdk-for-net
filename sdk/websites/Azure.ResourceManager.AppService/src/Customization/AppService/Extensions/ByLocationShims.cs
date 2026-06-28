// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#pragma warning disable SA1402, SA1649

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

    public partial class MockableAppServiceTenantResource
    {
        /// <summary> Description for Get available Function app frameworks and their versions for location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<FunctionAppStack> GetFunctionAppStacksForLocationProvidersAsync(AzureLocation location, ProviderStackOSType? stackOsType = default, CancellationToken cancellationToken = default)
            => GetFunctionAppStacksForLocationProvidersAsync(location.ToString(), stackOsType, cancellationToken);

        /// <summary> Description for Get available Function app frameworks and their versions for location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<FunctionAppStack> GetFunctionAppStacksForLocationProviders(AzureLocation location, ProviderStackOSType? stackOsType = default, CancellationToken cancellationToken = default)
            => GetFunctionAppStacksForLocationProviders(location.ToString(), stackOsType, cancellationToken);

        /// <summary> Description for Get available Web app frameworks and their versions for location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<WebAppStack> GetWebAppStacksByLocationAsync(AzureLocation location, ProviderStackOSType? stackOsType = default, CancellationToken cancellationToken = default)
            => GetWebAppStacksByLocationAsync(location.ToString(), stackOsType, cancellationToken);

        /// <summary> Description for Get available Web app frameworks and their versions for location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<WebAppStack> GetWebAppStacksByLocation(AzureLocation location, ProviderStackOSType? stackOsType = default, CancellationToken cancellationToken = default)
            => GetWebAppStacksByLocation(location.ToString(), stackOsType, cancellationToken);

        /// <summary> Description for Gets all available operations for the Microsoft.Web resource provider. Also exposes resource metric definitions. NOTE: The underlying REST operation is no longer surfaced by the new generator. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is no longer supported. The underlying REST operation 'Provider_ListOperations' was removed in the latest API version.", false)]
        public virtual AsyncPageable<CsmOperationDescription> GetOperationsProvidersAsync(CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Provider_ListOperations is no longer exposed by the App Service REST API.");

        /// <summary> Description for Gets all available operations for the Microsoft.Web resource provider. NOTE: The underlying REST operation is no longer surfaced by the new generator. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is no longer supported. The underlying REST operation 'Provider_ListOperations' was removed in the latest API version.", false)]
        public virtual Pageable<CsmOperationDescription> GetOperationsProviders(CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Provider_ListOperations is no longer exposed by the App Service REST API.");
    }
}

namespace Azure.ResourceManager.AppService
{
    using Azure.ResourceManager.AppService.Mocking;
    using Azure.ResourceManager.Resources;

    public static partial class AppServiceExtensions
    {
        /// <summary> Description for Get all deleted apps for a subscription at location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<DeletedSiteResource> GetDeletedSitesByLocationAsync(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken = default)
            => GetMockableAppServiceSubscriptionResource(subscriptionResource).GetDeletedSitesByLocationAsync(location, cancellationToken);

        /// <summary> Description for Get all deleted apps for a subscription at location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<DeletedSiteResource> GetDeletedSitesByLocation(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken = default)
            => GetMockableAppServiceSubscriptionResource(subscriptionResource).GetDeletedSitesByLocation(location, cancellationToken);

        /// <summary> Description for Get a deleted app for a subscription at location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Task<Response<DeletedSiteResource>> GetDeletedWebAppByLocationDeletedWebAppAsync(this SubscriptionResource subscriptionResource, AzureLocation location, string deletedSiteId, CancellationToken cancellationToken = default)
            => GetMockableAppServiceSubscriptionResource(subscriptionResource).GetDeletedWebAppByLocationDeletedWebAppAsync(location, deletedSiteId, cancellationToken);

        /// <summary> Description for Get a deleted app for a subscription at location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<DeletedSiteResource> GetDeletedWebAppByLocationDeletedWebApp(this SubscriptionResource subscriptionResource, AzureLocation location, string deletedSiteId, CancellationToken cancellationToken = default)
            => GetMockableAppServiceSubscriptionResource(subscriptionResource).GetDeletedWebAppByLocationDeletedWebApp(location, deletedSiteId, cancellationToken);

        /// <summary> Description for Gets the usage quotas for the App Service plans in the given location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<CsmUsageQuota> GetGetUsagesInLocationsAsync(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken = default)
            => GetMockableAppServiceSubscriptionResource(subscriptionResource).GetGetUsagesInLocationsAsync(location, cancellationToken);

        /// <summary> Description for Gets the usage quotas for the App Service plans in the given location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<CsmUsageQuota> GetGetUsagesInLocations(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken = default)
            => GetMockableAppServiceSubscriptionResource(subscriptionResource).GetGetUsagesInLocations(location, cancellationToken);

        /// <summary> Description for Check the availability of a DNL resource name. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Task<Response<DnlResourceNameAvailabilityResult>> CheckDnlResourceNameAvailabilityAsync(this SubscriptionResource subscriptionResource, AzureLocation location, DnlResourceNameAvailabilityContent content, CancellationToken cancellationToken = default)
            => GetMockableAppServiceSubscriptionResource(subscriptionResource).CheckDnlResourceNameAvailabilityAsync(location, content, cancellationToken);

        /// <summary> Description for Check the availability of a DNL resource name. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<DnlResourceNameAvailabilityResult> CheckDnlResourceNameAvailability(this SubscriptionResource subscriptionResource, AzureLocation location, DnlResourceNameAvailabilityContent content, CancellationToken cancellationToken = default)
            => GetMockableAppServiceSubscriptionResource(subscriptionResource).CheckDnlResourceNameAvailability(location, content, cancellationToken);

        /// <summary> Description for Preview the GitHub Actions workflow for a Static Site. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Task<Response<StaticSitesWorkflowPreview>> PreviewStaticSiteWorkflowAsync(this SubscriptionResource subscriptionResource, AzureLocation location, StaticSitesWorkflowPreviewContent content, CancellationToken cancellationToken = default)
            => GetMockableAppServiceSubscriptionResource(subscriptionResource).PreviewStaticSiteWorkflowAsync(location, content, cancellationToken);

        /// <summary> Description for Preview the GitHub Actions workflow for a Static Site. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<StaticSitesWorkflowPreview> PreviewStaticSiteWorkflow(this SubscriptionResource subscriptionResource, AzureLocation location, StaticSitesWorkflowPreviewContent content, CancellationToken cancellationToken = default)
            => GetMockableAppServiceSubscriptionResource(subscriptionResource).PreviewStaticSiteWorkflow(location, content, cancellationToken);

        /// <summary> Description for Get available Function app frameworks and their versions for location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<FunctionAppStack> GetFunctionAppStacksForLocationProvidersAsync(this TenantResource tenantResource, AzureLocation location, ProviderStackOSType? stackOsType = default, CancellationToken cancellationToken = default)
            => GetMockableAppServiceTenantResource(tenantResource).GetFunctionAppStacksForLocationProvidersAsync(location, stackOsType, cancellationToken);

        /// <summary> Description for Get available Function app frameworks and their versions for location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<FunctionAppStack> GetFunctionAppStacksForLocationProviders(this TenantResource tenantResource, AzureLocation location, ProviderStackOSType? stackOsType = default, CancellationToken cancellationToken = default)
            => GetMockableAppServiceTenantResource(tenantResource).GetFunctionAppStacksForLocationProviders(location, stackOsType, cancellationToken);

        /// <summary> Description for Get available Web app frameworks and their versions for location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<WebAppStack> GetWebAppStacksByLocationAsync(this TenantResource tenantResource, AzureLocation location, ProviderStackOSType? stackOsType = default, CancellationToken cancellationToken = default)
            => GetMockableAppServiceTenantResource(tenantResource).GetWebAppStacksByLocationAsync(location, stackOsType, cancellationToken);

        /// <summary> Description for Get available Web app frameworks and their versions for location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<WebAppStack> GetWebAppStacksByLocation(this TenantResource tenantResource, AzureLocation location, ProviderStackOSType? stackOsType = default, CancellationToken cancellationToken = default)
            => GetMockableAppServiceTenantResource(tenantResource).GetWebAppStacksByLocation(location, stackOsType, cancellationToken);

        /// <summary> Description for Gets all available operations for the Microsoft.Web resource provider. NOTE: No longer supported in the underlying REST API. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is no longer supported. The underlying REST operation 'Provider_ListOperations' was removed in the latest API version.", false)]
        public static AsyncPageable<CsmOperationDescription> GetOperationsProvidersAsync(this TenantResource tenantResource, CancellationToken cancellationToken = default)
            => GetMockableAppServiceTenantResource(tenantResource).GetOperationsProvidersAsync(cancellationToken);

        /// <summary> Description for Gets all available operations for the Microsoft.Web resource provider. NOTE: No longer supported in the underlying REST API. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is no longer supported. The underlying REST operation 'Provider_ListOperations' was removed in the latest API version.", false)]
        public static Pageable<CsmOperationDescription> GetOperationsProviders(this TenantResource tenantResource, CancellationToken cancellationToken = default)
            => GetMockableAppServiceTenantResource(tenantResource).GetOperationsProviders(cancellationToken);
    }
}
