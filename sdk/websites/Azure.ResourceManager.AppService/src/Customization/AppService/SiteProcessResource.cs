// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.AppService.Models;
using Microsoft.TypeSpec.Generator.Customizations;

// ROOT CAUSE: GA 1.5.0 shipped two related customizations on SiteProcessResource:
//
// (1) Thread listing (merged from ProcessThreads): GA shipped GetProcessThreads returning
//     Pageable<ProcessThreadInfo> (legacy proxy-resource model). The new TypeSpec generator
//     emits GetProcessThreads returning Pageable<WebAppProcessThreadInfo> (the newer flat
//     model). Suppress the generated method and redeclare two variants: the legacy name
//     returning ProcessThreadInfo (wrapping the flat model) for backward compatibility,
//     and a new GetSiteProcessThreads returning WebAppProcessThreadInfo directly. Renaming
//     in the spec would change the REST operation name used by other language SDKs.
//
// (2) Process dump (merged from Streams): GA shipped GetProcessDump returning
//     Response<Stream>. The new TypeSpec generator emits this as Response<BinaryData>.
//     Suppress and redeclare with the GA Stream-returning contract.
namespace Azure.ResourceManager.AppService
{
    [CodeGenSuppress("GetProcessThreadsAsync", typeof(CancellationToken))]
    [CodeGenSuppress("GetProcessThreads", typeof(CancellationToken))]
    [CodeGenSuppress("GetProcessDumpAsync", typeof(CancellationToken))]
    [CodeGenSuppress("GetProcessDump", typeof(CancellationToken))]
    public partial class SiteProcessResource
    {
        /// <summary> Description for List the threads in a process by its ID (returns legacy ProcessThreadInfo). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<ProcessThreadInfo> GetProcessThreadsAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<ProcessThreadInfo>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _processInfoOperationGroupClientDiagnostics.CreateScope("SiteProcessResource.GetProcessThreads");
                scope.Start();
                try
                {
                    RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                    using HttpMessage message = _processInfoOperationGroupRestClient.CreateGetProcessThreadsRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, context);
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
                using DiagnosticScope scope = _processInfoOperationGroupClientDiagnostics.CreateScope("SiteProcessResource.GetProcessThreads");
                scope.Start();
                try
                {
                    RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                    using HttpMessage message = _processInfoOperationGroupRestClient.CreateNextGetProcessThreadsRequest(new Uri(nextLink, UriKind.RelativeOrAbsolute), Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, context);
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

        /// <summary> Description for List the threads in a process by its ID (returns legacy ProcessThreadInfo). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<ProcessThreadInfo> GetProcessThreads(CancellationToken cancellationToken = default)
        {
            Page<ProcessThreadInfo> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _processInfoOperationGroupClientDiagnostics.CreateScope("SiteProcessResource.GetProcessThreads");
                scope.Start();
                try
                {
                    RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                    using HttpMessage message = _processInfoOperationGroupRestClient.CreateGetProcessThreadsRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, context);
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
                using DiagnosticScope scope = _processInfoOperationGroupClientDiagnostics.CreateScope("SiteProcessResource.GetProcessThreads");
                scope.Start();
                try
                {
                    RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                    using HttpMessage message = _processInfoOperationGroupRestClient.CreateNextGetProcessThreadsRequest(new Uri(nextLink, UriKind.RelativeOrAbsolute), Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, context);
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

        /// <summary> Description for List the threads in a process by its ID (returns flat WebAppProcessThreadInfo). </summary>
        public virtual AsyncPageable<WebAppProcessThreadInfo> GetSiteProcessThreadsAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new ProcessInfoOperationGroupGetProcessThreadsAsyncCollectionResultOfT(
                _processInfoOperationGroupRestClient,
                Guid.Parse(Id.SubscriptionId),
                Id.ResourceGroupName,
                Id.Parent.Name,
                Id.Name,
                context,
                "SiteProcessResource.GetSiteProcessThreads");
        }

        /// <summary> Description for List the threads in a process by its ID (returns flat WebAppProcessThreadInfo). </summary>
        public virtual Pageable<WebAppProcessThreadInfo> GetSiteProcessThreads(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new ProcessInfoOperationGroupGetProcessThreadsCollectionResultOfT(
                _processInfoOperationGroupRestClient,
                Guid.Parse(Id.SubscriptionId),
                Id.ResourceGroupName,
                Id.Parent.Name,
                Id.Name,
                context,
                "SiteProcessResource.GetSiteProcessThreads");
        }

        /// <summary> Description for Get a memory dump of a process by its ID. </summary>
        public virtual async Task<Response<Stream>> GetProcessDumpAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _processInfoOperationGroupClientDiagnostics.CreateScope("SiteProcessResource.GetProcessDump");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _processInfoOperationGroupRestClient.CreateGetProcessDumpRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                return Response.FromValue(result.ContentStream, result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Description for Get a memory dump of a process by its ID. </summary>
        public virtual Response<Stream> GetProcessDump(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _processInfoOperationGroupClientDiagnostics.CreateScope("SiteProcessResource.GetProcessDump");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _processInfoOperationGroupRestClient.CreateGetProcessDumpRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, context);
                Response result = Pipeline.ProcessMessage(message, context);
                return Response.FromValue(result.ContentStream, result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
