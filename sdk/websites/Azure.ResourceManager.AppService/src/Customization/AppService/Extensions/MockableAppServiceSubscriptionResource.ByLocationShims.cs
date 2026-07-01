// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.AppService.Models;

// ROOT CAUSE: After the spec switched these by-location ops to LocationResourceParameter,
// the generator no longer emits the per-subscription helpers (GetGetUsagesInLocations,
// CheckDnlResourceNameAvailability, PreviewStaticSiteWorkflow) that shipped in GA 1.5.0.
// The shims below restore those methods by calling the still-generated REST clients
// (GetUsagesInLocationOperationGroup, WebClient, StaticSitesOperationGroup) directly.
//
// The deleted-site-by-location overloads remain because the generator now produces a
// resource-collection API (GetDeletedSiteAtLocations(AzureLocation).GetAll/Get) returning
// DeletedSiteAtLocationResource, while GA 1.5.0 exposed flat GetDeletedSitesByLocation* /
// GetDeletedWebAppByLocationDeletedWebApp* helpers returning DeletedSiteResource. The shims
// below collapse the collection-based API back to the GA-flat shape and project the result
// resource type back to DeletedSiteResource.
namespace Azure.ResourceManager.AppService.Mocking
{
    public partial class MockableAppServiceSubscriptionResource
    {
        /// <summary> Description for Get all deleted apps for a subscription at location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<DeletedSiteResource> GetDeletedSitesByLocationAsync(AzureLocation location, CancellationToken cancellationToken = default)
            => AppServiceCompatShims.ProjectAsyncPageable(
                GetDeletedSiteAtLocations(location).GetAllAsync(cancellationToken),
                atLoc => new DeletedSiteResource(Client, atLoc.Data));

        /// <summary> Description for Get all deleted apps for a subscription at location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<DeletedSiteResource> GetDeletedSitesByLocation(AzureLocation location, CancellationToken cancellationToken = default)
            => AppServiceCompatShims.ProjectPageable(
                GetDeletedSiteAtLocations(location).GetAll(cancellationToken),
                atLoc => new DeletedSiteResource(Client, atLoc.Data));

        /// <summary> Description for Get a deleted app for a subscription at location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DeletedSiteResource>> GetDeletedWebAppByLocationDeletedWebAppAsync(AzureLocation location, string deletedSiteId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(deletedSiteId, nameof(deletedSiteId));
            Response<DeletedSiteAtLocationResource> response = await GetDeletedSiteAtLocations(location).GetAsync(deletedSiteId, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new DeletedSiteResource(Client, response.Value.Data), response.GetRawResponse());
        }

        /// <summary> Description for Get a deleted app for a subscription at location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DeletedSiteResource> GetDeletedWebAppByLocationDeletedWebApp(AzureLocation location, string deletedSiteId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(deletedSiteId, nameof(deletedSiteId));
            Response<DeletedSiteAtLocationResource> response = GetDeletedSiteAtLocations(location).Get(deletedSiteId, cancellationToken);
            return Response.FromValue(new DeletedSiteResource(Client, response.Value.Data), response.GetRawResponse());
        }

        /// <summary> Description for Gets list of consumption usages by Location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<CsmUsageQuota> GetGetUsagesInLocationsAsync(AzureLocation location, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new CompatGetGetUsagesInLocationsAsyncCollectionResultOfT(
                GetUsagesInLocationOperationGroupRestClient,
                Guid.Parse(Id.SubscriptionId),
                location,
                context,
                "MockableAppServiceSubscriptionResource.GetGetUsagesInLocations");
        }

        /// <summary> Description for Gets list of consumption usages by Location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<CsmUsageQuota> GetGetUsagesInLocations(AzureLocation location, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new CompatGetGetUsagesInLocationsCollectionResultOfT(
                GetUsagesInLocationOperationGroupRestClient,
                Guid.Parse(Id.SubscriptionId),
                location,
                context,
                "MockableAppServiceSubscriptionResource.GetGetUsagesInLocations");
        }

        /// <summary> Description for Check if a name is available for use within a Domain Name Label scope. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DnlResourceNameAvailabilityResult>> CheckDnlResourceNameAvailabilityAsync(AzureLocation location, DnlResourceNameAvailabilityContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = WebClientClientDiagnostics.CreateScope("MockableAppServiceSubscriptionResource.CheckDnlResourceNameAvailability");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = WebClientRestClient.CreateCheckDnlResourceNameAvailabilityRequest(Guid.Parse(Id.SubscriptionId), location, DnlResourceNameAvailabilityContent.ToRequestContent(content), context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<DnlResourceNameAvailabilityResult> response = Response.FromValue(DnlResourceNameAvailabilityResult.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Description for Check if a name is available for use within a Domain Name Label scope. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DnlResourceNameAvailabilityResult> CheckDnlResourceNameAvailability(AzureLocation location, DnlResourceNameAvailabilityContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = WebClientClientDiagnostics.CreateScope("MockableAppServiceSubscriptionResource.CheckDnlResourceNameAvailability");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = WebClientRestClient.CreateCheckDnlResourceNameAvailabilityRequest(Guid.Parse(Id.SubscriptionId), location, DnlResourceNameAvailabilityContent.ToRequestContent(content), context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<DnlResourceNameAvailabilityResult> response = Response.FromValue(DnlResourceNameAvailabilityResult.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Description for Generates a preview workflow file for the static site. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<StaticSitesWorkflowPreview>> PreviewStaticSiteWorkflowAsync(AzureLocation location, StaticSitesWorkflowPreviewContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = StaticSitesOperationGroupClientDiagnostics.CreateScope("MockableAppServiceSubscriptionResource.PreviewStaticSiteWorkflow");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = StaticSitesOperationGroupRestClient.CreatePreviewStaticSiteWorkflowRequest(Guid.Parse(Id.SubscriptionId), location, StaticSitesWorkflowPreviewContent.ToRequestContent(content), context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<StaticSitesWorkflowPreview> response = Response.FromValue(StaticSitesWorkflowPreview.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Description for Generates a preview workflow file for the static site. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<StaticSitesWorkflowPreview> PreviewStaticSiteWorkflow(AzureLocation location, StaticSitesWorkflowPreviewContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = StaticSitesOperationGroupClientDiagnostics.CreateScope("MockableAppServiceSubscriptionResource.PreviewStaticSiteWorkflow");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = StaticSitesOperationGroupRestClient.CreatePreviewStaticSiteWorkflowRequest(Guid.Parse(Id.SubscriptionId), location, StaticSitesWorkflowPreviewContent.ToRequestContent(content), context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<StaticSitesWorkflowPreview> response = Response.FromValue(StaticSitesWorkflowPreview.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
