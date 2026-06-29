// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.AppService.Models;
using Microsoft.TypeSpec.Generator.Customizations;

// ROOT CAUSE: GA 1.5.0 shipped two flavours of "thread listing" methods on
// Site*ProcessResource:
//   * GetInstanceProcessThreads / GetProcessThreads etc. returning
//     Pageable<ProcessThreadInfo> (legacy proxy-resource model).
//   * GetSiteInstanceProcessThreads / GetSiteProcessThreads etc. returning
//     Pageable<WebAppProcessThreadInfo> (the newer flat model).
// The new TypeSpec generator emits only the second family but under the GA
// first-family names (GetInstanceProcessThreads returning
// WebAppProcessThreadInfo). Suppress those and redeclare the GA contract:
// (1) the legacy name returns ProcessThreadInfo (wrapping the flat model);
// (2) add the GetSite*ProcessThreads alias returning the flat model directly.
namespace Azure.ResourceManager.AppService
{
    [CodeGenSuppress("GetInstanceProcessThreadsAsync", typeof(CancellationToken))]
    [CodeGenSuppress("GetInstanceProcessThreads", typeof(CancellationToken))]
    public partial class SiteInstanceProcessResource
    {
        /// <summary> Description for List the threads in a process by its ID for a specific scaled-out instance (returns legacy ProcessThreadInfo). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<ProcessThreadInfo> GetInstanceProcessThreadsAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<ProcessThreadInfo>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _processInfosClientDiagnostics.CreateScope("SiteInstanceProcessResource.GetInstanceProcessThreads");
                scope.Start();
                try
                {
                    RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                    using HttpMessage message = _processInfosRestClient.CreateGetInstanceProcessThreadsRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, context);
                    Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                    WebAppProcessThreadInfoListResult listResult = WebAppProcessThreadInfoListResult.FromResponse(result);
                    return Page.FromValues(listResult.Value.Select(t => new ProcessThreadInfo(t)).ToList(), listResult.NextLink?.AbsoluteUri, result);
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ProcessThreadInfo>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _processInfosClientDiagnostics.CreateScope("SiteInstanceProcessResource.GetInstanceProcessThreads");
                scope.Start();
                try
                {
                    RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                    using HttpMessage message = _processInfosRestClient.CreateNextGetInstanceProcessThreadsRequest(new Uri(nextLink, UriKind.RelativeOrAbsolute), Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, context);
                    Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                    WebAppProcessThreadInfoListResult listResult = WebAppProcessThreadInfoListResult.FromResponse(result);
                    return Page.FromValues(listResult.Value.Select(t => new ProcessThreadInfo(t)).ToList(), listResult.NextLink?.AbsoluteUri, result);
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Description for List the threads in a process by its ID for a specific scaled-out instance (returns legacy ProcessThreadInfo). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<ProcessThreadInfo> GetInstanceProcessThreads(CancellationToken cancellationToken = default)
        {
            Page<ProcessThreadInfo> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _processInfosClientDiagnostics.CreateScope("SiteInstanceProcessResource.GetInstanceProcessThreads");
                scope.Start();
                try
                {
                    RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                    using HttpMessage message = _processInfosRestClient.CreateGetInstanceProcessThreadsRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, context);
                    Response result = Pipeline.ProcessMessage(message, context);
                    WebAppProcessThreadInfoListResult listResult = WebAppProcessThreadInfoListResult.FromResponse(result);
                    return Page.FromValues(listResult.Value.Select(t => new ProcessThreadInfo(t)).ToList(), listResult.NextLink?.AbsoluteUri, result);
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ProcessThreadInfo> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _processInfosClientDiagnostics.CreateScope("SiteInstanceProcessResource.GetInstanceProcessThreads");
                scope.Start();
                try
                {
                    RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                    using HttpMessage message = _processInfosRestClient.CreateNextGetInstanceProcessThreadsRequest(new Uri(nextLink, UriKind.RelativeOrAbsolute), Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, context);
                    Response result = Pipeline.ProcessMessage(message, context);
                    WebAppProcessThreadInfoListResult listResult = WebAppProcessThreadInfoListResult.FromResponse(result);
                    return Page.FromValues(listResult.Value.Select(t => new ProcessThreadInfo(t)).ToList(), listResult.NextLink?.AbsoluteUri, result);
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Description for List the threads in a process by its ID for a specific scaled-out instance (returns flat WebAppProcessThreadInfo). </summary>
        public virtual AsyncPageable<WebAppProcessThreadInfo> GetSiteInstanceProcessThreadsAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new ProcessInfosGetInstanceProcessThreadsAsyncCollectionResultOfT(
                _processInfosRestClient,
                Guid.Parse(Id.SubscriptionId),
                Id.ResourceGroupName,
                Id.Parent.Parent.Name,
                Id.Parent.Name,
                Id.Name,
                context,
                "SiteInstanceProcessResource.GetSiteInstanceProcessThreads");
        }

        /// <summary> Description for List the threads in a process by its ID for a specific scaled-out instance (returns flat WebAppProcessThreadInfo). </summary>
        public virtual Pageable<WebAppProcessThreadInfo> GetSiteInstanceProcessThreads(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new ProcessInfosGetInstanceProcessThreadsCollectionResultOfT(
                _processInfosRestClient,
                Guid.Parse(Id.SubscriptionId),
                Id.ResourceGroupName,
                Id.Parent.Parent.Name,
                Id.Parent.Name,
                Id.Name,
                context,
                "SiteInstanceProcessResource.GetSiteInstanceProcessThreads");
        }
    }
}
