// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.AppService.Models;

namespace Azure.ResourceManager.AppService
{
    public partial class SiteSlotProcessResource
    {
        /// <summary> Description for List the threads in a process by its ID (slot, returns flat WebAppProcessThreadInfo). </summary>
        public virtual AsyncPageable<WebAppProcessThreadInfo> GetSiteSlotProcessThreadsAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<WebAppProcessThreadInfo>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _processSlotOperationGroupClientDiagnostics.CreateScope("SiteSlotProcessResource.GetSiteSlotProcessThreads");
                scope.Start();
                try
                {
                    RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                    using HttpMessage message = _processSlotOperationGroupRestClient.CreateGetProcessThreadsSlotRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, context);
                    Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                    WebAppProcessThreadInfoListResult listResult = WebAppProcessThreadInfoListResult.FromResponse(result);
                    return Page.FromValues(listResult.Value, listResult.NextLink?.AbsoluteUri, result);
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<WebAppProcessThreadInfo>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _processSlotOperationGroupClientDiagnostics.CreateScope("SiteSlotProcessResource.GetSiteSlotProcessThreads");
                scope.Start();
                try
                {
                    RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                    using HttpMessage message = _processSlotOperationGroupRestClient.CreateNextGetProcessThreadsSlotRequest(new Uri(nextLink, UriKind.RelativeOrAbsolute), Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, context);
                    Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                    WebAppProcessThreadInfoListResult listResult = WebAppProcessThreadInfoListResult.FromResponse(result);
                    return Page.FromValues(listResult.Value, listResult.NextLink?.AbsoluteUri, result);
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Description for List the threads in a process by its ID (slot, returns flat WebAppProcessThreadInfo). </summary>
        public virtual Pageable<WebAppProcessThreadInfo> GetSiteSlotProcessThreads(CancellationToken cancellationToken = default)
        {
            Page<WebAppProcessThreadInfo> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _processSlotOperationGroupClientDiagnostics.CreateScope("SiteSlotProcessResource.GetSiteSlotProcessThreads");
                scope.Start();
                try
                {
                    RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                    using HttpMessage message = _processSlotOperationGroupRestClient.CreateGetProcessThreadsSlotRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, context);
                    Response result = Pipeline.ProcessMessage(message, context);
                    WebAppProcessThreadInfoListResult listResult = WebAppProcessThreadInfoListResult.FromResponse(result);
                    return Page.FromValues(listResult.Value, listResult.NextLink?.AbsoluteUri, result);
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<WebAppProcessThreadInfo> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _processSlotOperationGroupClientDiagnostics.CreateScope("SiteSlotProcessResource.GetSiteSlotProcessThreads");
                scope.Start();
                try
                {
                    RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                    using HttpMessage message = _processSlotOperationGroupRestClient.CreateNextGetProcessThreadsSlotRequest(new Uri(nextLink, UriKind.RelativeOrAbsolute), Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, context);
                    Response result = Pipeline.ProcessMessage(message, context);
                    WebAppProcessThreadInfoListResult listResult = WebAppProcessThreadInfoListResult.FromResponse(result);
                    return Page.FromValues(listResult.Value, listResult.NextLink?.AbsoluteUri, result);
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
    }
}
