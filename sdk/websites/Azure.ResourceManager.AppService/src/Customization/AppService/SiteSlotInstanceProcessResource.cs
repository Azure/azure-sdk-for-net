// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.AppService.Models;

namespace Azure.ResourceManager.AppService
{
    public partial class SiteSlotInstanceProcessResource : ArmResource
    {
        /// <summary>
        /// Description for List the threads in a process by its ID for a specific scaled-out instance in a web site.
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ProcessThreadInfo"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<ProcessThreadInfo> GetInstanceProcessThreadsSlotAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<ProcessThreadInfo>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _instanceProcessSlotOperationGroupClientDiagnostics.CreateScope("SiteSlotInstanceProcessResource.GetInstanceProcessThreadsSlot");
                scope.Start();
                try
                {
                    RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                    using var message = _instanceProcessSlotOperationGroupRestClient.CreateGetInstanceProcessThreadsSlotRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Parent.Name, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, context);
                    var response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                    WebAppProcessThreadInfoListResult result = WebAppProcessThreadInfoListResult.FromResponse(response);
                    return Page.FromValues(result.Value.Select(thread => new ProcessThreadInfo(thread)).ToList(), result.NextLink?.AbsoluteUri, response);
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            async Task<Page<ProcessThreadInfo>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _instanceProcessSlotOperationGroupClientDiagnostics.CreateScope("SiteSlotInstanceProcessResource.GetInstanceProcessThreadsSlot");
                scope.Start();
                try
                {
                    RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                    using var message = _instanceProcessSlotOperationGroupRestClient.CreateNextGetInstanceProcessThreadsSlotRequest(new Uri(nextLink, UriKind.RelativeOrAbsolute), Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Parent.Name, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, context);
                    var response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                    WebAppProcessThreadInfoListResult result = WebAppProcessThreadInfoListResult.FromResponse(response);
                    return Page.FromValues(result.Value.Select(thread => new ProcessThreadInfo(thread)).ToList(), result.NextLink?.AbsoluteUri, response);
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Description for List the threads in a process by its ID for a specific scaled-out instance in a web site.
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ProcessThreadInfo"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<ProcessThreadInfo> GetInstanceProcessThreadsSlot(CancellationToken cancellationToken = default)
        {
            Page<ProcessThreadInfo> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _instanceProcessSlotOperationGroupClientDiagnostics.CreateScope("SiteSlotInstanceProcessResource.GetInstanceProcessThreadsSlot");
                scope.Start();
                try
                {
                    RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                    using var message = _instanceProcessSlotOperationGroupRestClient.CreateGetInstanceProcessThreadsSlotRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Parent.Name, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, context);
                    var response = Pipeline.ProcessMessage(message, context);
                    WebAppProcessThreadInfoListResult result = WebAppProcessThreadInfoListResult.FromResponse(response);
                    return Page.FromValues(result.Value.Select(thread => new ProcessThreadInfo(thread)).ToList(), result.NextLink?.AbsoluteUri, response);
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<ProcessThreadInfo> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _instanceProcessSlotOperationGroupClientDiagnostics.CreateScope("SiteSlotInstanceProcessResource.GetInstanceProcessThreadsSlot");
                scope.Start();
                try
                {
                    RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                    using var message = _instanceProcessSlotOperationGroupRestClient.CreateNextGetInstanceProcessThreadsSlotRequest(new Uri(nextLink, UriKind.RelativeOrAbsolute), Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Parent.Name, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, context);
                    var response = Pipeline.ProcessMessage(message, context);
                    WebAppProcessThreadInfoListResult result = WebAppProcessThreadInfoListResult.FromResponse(response);
                    return Page.FromValues(result.Value.Select(thread => new ProcessThreadInfo(thread)).ToList(), result.NextLink?.AbsoluteUri, response);
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
