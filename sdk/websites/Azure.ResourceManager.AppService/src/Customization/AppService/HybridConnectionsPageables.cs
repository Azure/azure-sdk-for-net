// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#pragma warning disable SA1402, SA1649

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.TypeSpec.Generator.Customizations;

// ROOT CAUSE: GA 1.5.0 exposed GetHybridConnections (and slot variant)
// returning Pageable<HybridConnectionData>. The new TypeSpec emitter returns
// Response<HybridConnectionData> (a single item). Suppress the generated
// methods and redeclare with the GA Pageable contract by wrapping the single
// response in a one-element page.
namespace Azure.ResourceManager.AppService
{
    [CodeGenSuppress("GetHybridConnectionsAsync", typeof(CancellationToken))]
    [CodeGenSuppress("GetHybridConnections", typeof(CancellationToken))]
    public partial class WebSiteResource
    {
        /// <summary> Description for Retrieves all Service Bus Hybrid Connections used by this Web App. </summary>
        public virtual AsyncPageable<HybridConnectionData> GetHybridConnectionsAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<HybridConnectionData>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _sitesClientDiagnostics.CreateScope("WebSiteResource.GetHybridConnections");
                scope.Start();
                try
                {
                    RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                    using HttpMessage message = _sitesRestClient.CreateGetHybridConnectionsRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
                    Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                    HybridConnectionData data = HybridConnectionData.FromResponse(result);
                    return Page.FromValues(data is null ? Array.Empty<HybridConnectionData>() : new[] { data }, null, result);
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, (string nextLink, int? pageSizeHint) => Task.FromResult<Page<HybridConnectionData>>(null));
        }

        /// <summary> Description for Retrieves all Service Bus Hybrid Connections used by this Web App. </summary>
        public virtual Pageable<HybridConnectionData> GetHybridConnections(CancellationToken cancellationToken = default)
        {
            Page<HybridConnectionData> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _sitesClientDiagnostics.CreateScope("WebSiteResource.GetHybridConnections");
                scope.Start();
                try
                {
                    RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                    using HttpMessage message = _sitesRestClient.CreateGetHybridConnectionsRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
                    Response result = Pipeline.ProcessMessage(message, context);
                    HybridConnectionData data = HybridConnectionData.FromResponse(result);
                    return Page.FromValues(data is null ? Array.Empty<HybridConnectionData>() : new[] { data }, null, result);
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

    [CodeGenSuppress("GetHybridConnectionsSlotAsync", typeof(CancellationToken))]
    [CodeGenSuppress("GetHybridConnectionsSlot", typeof(CancellationToken))]
    public partial class WebSiteSlotResource
    {
        /// <summary> Description for Retrieves all Service Bus Hybrid Connections used by this Web App (slot). </summary>
        public virtual AsyncPageable<HybridConnectionData> GetHybridConnectionsSlotAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<HybridConnectionData>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _webAppsClientDiagnostics.CreateScope("WebSiteSlotResource.GetHybridConnectionsSlot");
                scope.Start();
                try
                {
                    RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                    using HttpMessage message = _webAppsRestClient.CreateGetHybridConnectionsSlotRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, context);
                    Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                    HybridConnectionData data = HybridConnectionData.FromResponse(result);
                    return Page.FromValues(data is null ? Array.Empty<HybridConnectionData>() : new[] { data }, null, result);
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, (string nextLink, int? pageSizeHint) => Task.FromResult<Page<HybridConnectionData>>(null));
        }

        /// <summary> Description for Retrieves all Service Bus Hybrid Connections used by this Web App (slot). </summary>
        public virtual Pageable<HybridConnectionData> GetHybridConnectionsSlot(CancellationToken cancellationToken = default)
        {
            Page<HybridConnectionData> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _webAppsClientDiagnostics.CreateScope("WebSiteSlotResource.GetHybridConnectionsSlot");
                scope.Start();
                try
                {
                    RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                    using HttpMessage message = _webAppsRestClient.CreateGetHybridConnectionsSlotRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, context);
                    Response result = Pipeline.ProcessMessage(message, context);
                    HybridConnectionData data = HybridConnectionData.FromResponse(result);
                    return Page.FromValues(data is null ? Array.Empty<HybridConnectionData>() : new[] { data }, null, result);
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
