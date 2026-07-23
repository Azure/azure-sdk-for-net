// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.AppService.Models;
using Azure.ResourceManager.AppService.Mocking;
using Azure.ResourceManager.Resources;

// ROOT CAUSE: Extension-level companions to MockableAppServiceSubscriptionResource.ByLocationShims /
// MockableAppServiceTenantResource.ByLocationShims. After the spec switched the by-location ops to
// LocationResourceParameter, the generator stopped emitting the per-subscription/per-tenant
// helpers shipped in GA 1.5.0. These extension methods forward to the corresponding mockable
// shims (which in turn call the still-generated REST clients directly).
namespace Azure.ResourceManager.AppService
{
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

        /// <summary> Description for Gets list of consumption usages by Location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<CsmUsageQuota> GetGetUsagesInLocationsAsync(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken = default)
            => GetMockableAppServiceSubscriptionResource(subscriptionResource).GetGetUsagesInLocationsAsync(location, cancellationToken);

        /// <summary> Description for Gets list of consumption usages by Location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<CsmUsageQuota> GetGetUsagesInLocations(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken = default)
            => GetMockableAppServiceSubscriptionResource(subscriptionResource).GetGetUsagesInLocations(location, cancellationToken);

        /// <summary> Description for Check if a name is available for use within a Domain Name Label scope. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Task<Response<DnlResourceNameAvailabilityResult>> CheckDnlResourceNameAvailabilityAsync(this SubscriptionResource subscriptionResource, AzureLocation location, DnlResourceNameAvailabilityContent content, CancellationToken cancellationToken = default)
            => GetMockableAppServiceSubscriptionResource(subscriptionResource).CheckDnlResourceNameAvailabilityAsync(location, content, cancellationToken);

        /// <summary> Description for Check if a name is available for use within a Domain Name Label scope. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<DnlResourceNameAvailabilityResult> CheckDnlResourceNameAvailability(this SubscriptionResource subscriptionResource, AzureLocation location, DnlResourceNameAvailabilityContent content, CancellationToken cancellationToken = default)
            => GetMockableAppServiceSubscriptionResource(subscriptionResource).CheckDnlResourceNameAvailability(location, content, cancellationToken);

        /// <summary> Description for Generates a preview workflow file for the static site. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Task<Response<StaticSitesWorkflowPreview>> PreviewStaticSiteWorkflowAsync(this SubscriptionResource subscriptionResource, AzureLocation location, StaticSitesWorkflowPreviewContent content, CancellationToken cancellationToken = default)
            => GetMockableAppServiceSubscriptionResource(subscriptionResource).PreviewStaticSiteWorkflowAsync(location, content, cancellationToken);

        /// <summary> Description for Generates a preview workflow file for the static site. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<StaticSitesWorkflowPreview> PreviewStaticSiteWorkflow(this SubscriptionResource subscriptionResource, AzureLocation location, StaticSitesWorkflowPreviewContent content, CancellationToken cancellationToken = default)
            => GetMockableAppServiceSubscriptionResource(subscriptionResource).PreviewStaticSiteWorkflow(location, content, cancellationToken);

        /// <summary> Description for Get available Function app frameworks and their versions for location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<FunctionAppStack> GetFunctionAppStacksForLocationProvidersAsync(this TenantResource tenantResource, AzureLocation location, ProviderStackOSType? stackOsType = null, CancellationToken cancellationToken = default)
            => GetMockableAppServiceTenantResource(tenantResource).GetFunctionAppStacksForLocationProvidersAsync(location, stackOsType, cancellationToken);

        /// <summary> Description for Get available Function app frameworks and their versions for location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<FunctionAppStack> GetFunctionAppStacksForLocationProviders(this TenantResource tenantResource, AzureLocation location, ProviderStackOSType? stackOsType = null, CancellationToken cancellationToken = default)
            => GetMockableAppServiceTenantResource(tenantResource).GetFunctionAppStacksForLocationProviders(location, stackOsType, cancellationToken);

        /// <summary> Description for Get available Web app frameworks and their versions for location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<WebAppStack> GetWebAppStacksByLocationAsync(this TenantResource tenantResource, AzureLocation location, ProviderStackOSType? stackOsType = null, CancellationToken cancellationToken = default)
            => GetMockableAppServiceTenantResource(tenantResource).GetWebAppStacksByLocationAsync(location, stackOsType, cancellationToken);

        /// <summary> Description for Get available Web app frameworks and their versions for location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<WebAppStack> GetWebAppStacksByLocation(this TenantResource tenantResource, AzureLocation location, ProviderStackOSType? stackOsType = null, CancellationToken cancellationToken = default)
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
