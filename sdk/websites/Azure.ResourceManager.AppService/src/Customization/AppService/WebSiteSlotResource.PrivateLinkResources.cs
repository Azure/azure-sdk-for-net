// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.AppService.Models;
using Microsoft.TypeSpec.Generator.Customizations;

// ROOT CAUSE: GA 1.5.0 exposed GetPrivateLinkResourcesSlot returning Pageable<AppServicePrivateLinkResourceData>
// on WebSiteSlotResource. The TypeSpec generator emits this method returning
// Response<PrivateLinkResourcesWrapper> (a single-value response wrapping the list).
// Suppress the generated single-response method and redeclare with the GA Pageable contract
// by unwrapping wrapper.Value into a single page. A spec fix would change the return type
// contract for all language SDKs.
namespace Azure.ResourceManager.AppService
{
    [CodeGenSuppress("GetPrivateLinkResourcesSlotAsync", typeof(CancellationToken))]
    [CodeGenSuppress("GetPrivateLinkResourcesSlot", typeof(CancellationToken))]
    public partial class WebSiteSlotResource
    {
        /// <summary> Description for Gets the list of private endpoints associated with the site (slot). </summary>
        public virtual AsyncPageable<AppServicePrivateLinkResourceData> GetPrivateLinkResourcesSlotAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<AppServicePrivateLinkResourceData>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _webAppsClientDiagnostics.CreateScope("WebSiteSlotResource.GetPrivateLinkResourcesSlot");
                scope.Start();
                try
                {
                    RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                    using HttpMessage message = _webAppsRestClient.CreateGetPrivateLinkResourcesSlotRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, context);
                    Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                    PrivateLinkResourcesWrapper wrapper = PrivateLinkResourcesWrapper.FromResponse(result);
                    return Page.FromValues(wrapper?.Value ?? Array.Empty<AppServicePrivateLinkResourceData>(), null, result);
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, (string nextLink, int? pageSizeHint) => Task.FromResult<Page<AppServicePrivateLinkResourceData>>(null));
        }

        /// <summary> Description for Gets the list of private endpoints associated with the site (slot). </summary>
        public virtual Pageable<AppServicePrivateLinkResourceData> GetPrivateLinkResourcesSlot(CancellationToken cancellationToken = default)
        {
            Page<AppServicePrivateLinkResourceData> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _webAppsClientDiagnostics.CreateScope("WebSiteSlotResource.GetPrivateLinkResourcesSlot");
                scope.Start();
                try
                {
                    RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                    using HttpMessage message = _webAppsRestClient.CreateGetPrivateLinkResourcesSlotRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, context);
                    Response result = Pipeline.ProcessMessage(message, context);
                    PrivateLinkResourcesWrapper wrapper = PrivateLinkResourcesWrapper.FromResponse(result);
                    return Page.FromValues(wrapper?.Value ?? Array.Empty<AppServicePrivateLinkResourceData>(), null, result);
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, (string nextLink, int? pageSizeHint) => null);
        }
    }
}
