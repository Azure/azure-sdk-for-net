// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.AppService.Models;

// ROOT CAUSE: GA 1.5.0 shipped GetInstanceProcessThreadsSlot returning Pageable<WebAppProcessThreadInfo>
// directly via the GetSiteSlotInstanceProcessThreads name. This file adds the new flat-model method name
// as a companion to the legacy ProcessThreadInfo methods in SiteSlotInstanceProcessResource.cs.
// The generated code emits only the old name; this adds the preferred new name returning the flat model.
namespace Azure.ResourceManager.AppService
{
    public partial class SiteSlotInstanceProcessResource
    {
        /// <summary> Description for List the threads in a process by its ID for a specific scaled-out instance (slot, returns flat WebAppProcessThreadInfo). </summary>
        public virtual AsyncPageable<WebAppProcessThreadInfo> GetSiteSlotInstanceProcessThreadsAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<WebAppProcessThreadInfo>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _instanceProcessSlotOperationGroupClientDiagnostics.CreateScope("SiteSlotInstanceProcessResource.GetSiteSlotInstanceProcessThreads");
                scope.Start();
                try
                {
                    RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                    using HttpMessage message = _instanceProcessSlotOperationGroupRestClient.CreateGetInstanceProcessThreadsSlotRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Parent.Name, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, context);
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
                using DiagnosticScope scope = _instanceProcessSlotOperationGroupClientDiagnostics.CreateScope("SiteSlotInstanceProcessResource.GetSiteSlotInstanceProcessThreads");
                scope.Start();
                try
                {
                    RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                    using HttpMessage message = _instanceProcessSlotOperationGroupRestClient.CreateNextGetInstanceProcessThreadsSlotRequest(new Uri(nextLink, UriKind.RelativeOrAbsolute), Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Parent.Name, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, context);
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

        /// <summary> Description for List the threads in a process by its ID for a specific scaled-out instance (slot, returns flat WebAppProcessThreadInfo). </summary>
        public virtual Pageable<WebAppProcessThreadInfo> GetSiteSlotInstanceProcessThreads(CancellationToken cancellationToken = default)
        {
            Page<WebAppProcessThreadInfo> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _instanceProcessSlotOperationGroupClientDiagnostics.CreateScope("SiteSlotInstanceProcessResource.GetSiteSlotInstanceProcessThreads");
                scope.Start();
                try
                {
                    RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                    using HttpMessage message = _instanceProcessSlotOperationGroupRestClient.CreateGetInstanceProcessThreadsSlotRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Parent.Name, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, context);
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
                using DiagnosticScope scope = _instanceProcessSlotOperationGroupClientDiagnostics.CreateScope("SiteSlotInstanceProcessResource.GetSiteSlotInstanceProcessThreads");
                scope.Start();
                try
                {
                    RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                    using HttpMessage message = _instanceProcessSlotOperationGroupRestClient.CreateNextGetInstanceProcessThreadsSlotRequest(new Uri(nextLink, UriKind.RelativeOrAbsolute), Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Parent.Name, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, context);
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
