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

// ROOT CAUSE: GA 1.5.0 exposed GetPrivateLinkResources (and slot variant) on
// AppServiceEnvironmentResource, StaticSiteResource, WebSiteResource, and
// WebSiteSlotResource returning Pageable<AppServicePrivateLinkResourceData>.
// The new TypeSpec emitter returns Response<PrivateLinkResourcesWrapper>
// instead. Suppress the generated methods and redeclare with the GA Pageable
// contract by unwrapping wrapper.Value into a single page.
namespace Azure.ResourceManager.AppService
{
    [CodeGenSuppress("GetPrivateLinkResourcesAsync", typeof(CancellationToken))]
    [CodeGenSuppress("GetPrivateLinkResources", typeof(CancellationToken))]
    public partial class AppServiceEnvironmentResource
    {
        /// <summary> Description for Gets the list of private endpoints associated with a hosting environment. </summary>
        public virtual AsyncPageable<AppServicePrivateLinkResourceData> GetPrivateLinkResourcesAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<AppServicePrivateLinkResourceData>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _appServiceEnvironmentResourcesClientDiagnostics.CreateScope("AppServiceEnvironmentResource.GetPrivateLinkResources");
                scope.Start();
                try
                {
                    RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                    using HttpMessage message = _appServiceEnvironmentResourcesRestClient.CreateGetPrivateLinkResourcesRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
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

        /// <summary> Description for Gets the list of private endpoints associated with a hosting environment. </summary>
        public virtual Pageable<AppServicePrivateLinkResourceData> GetPrivateLinkResources(CancellationToken cancellationToken = default)
        {
            Page<AppServicePrivateLinkResourceData> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _appServiceEnvironmentResourcesClientDiagnostics.CreateScope("AppServiceEnvironmentResource.GetPrivateLinkResources");
                scope.Start();
                try
                {
                    RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                    using HttpMessage message = _appServiceEnvironmentResourcesRestClient.CreateGetPrivateLinkResourcesRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
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
