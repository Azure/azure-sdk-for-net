// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.TypeSpec.Generator.Customizations;

// ROOT CAUSE: GA 1.5.0 exposed GetHybridConnectionsSlot returning Pageable<HybridConnectionData>
// on WebSiteSlotResource. The TypeSpec generator emits this as returning Response<HybridConnectionData>
// (a single item) because the response is not modeled as a paged collection in the spec.
// The actual ARM endpoint returns { "value": [...], "nextLink": ... }. Suppress the generated
// single-item method and redeclare with the GA Pageable contract that parses the value array.
// A spec fix would change the REST response shape for all language SDKs.
namespace Azure.ResourceManager.AppService
{
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
                    return WebSiteResource.ParseHybridConnectionPage(result);
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
                    return WebSiteResource.ParseHybridConnectionPage(result);
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
