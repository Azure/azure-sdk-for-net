// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#pragma warning disable SA1402, SA1649

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.TypeSpec.Generator.Customizations;

// ROOT CAUSE: GA 1.5.0 exposed GetHybridConnections (and slot variant)
// returning Pageable<HybridConnectionData>. The new TypeSpec emitter returns
// Response<HybridConnectionData> (a single item) because the response is not
// modeled as a paged collection in the spec. The actual ARM endpoint returns
// `{ "value": [...], "nextLink": ... }`. Suppress the generated single-item
// methods and redeclare with the GA Pageable contract that parses the array.
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
                    return ParseHybridConnectionPage(result);
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
                    return ParseHybridConnectionPage(result);
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, (string nextLink, int? pageSizeHint) => null);
        }

        internal static Page<HybridConnectionData> ParseHybridConnectionPage(Response result)
        {
            ModelReaderWriterOptions options = new ModelReaderWriterOptions("W");
            using JsonDocument doc = JsonDocument.Parse(result.Content);
            JsonElement root = doc.RootElement;
            List<HybridConnectionData> items = new List<HybridConnectionData>();
            if (root.ValueKind == JsonValueKind.Object && root.TryGetProperty("value", out JsonElement valueElement) && valueElement.ValueKind == JsonValueKind.Array)
            {
                foreach (JsonElement item in valueElement.EnumerateArray())
                {
                    items.Add(HybridConnectionData.DeserializeHybridConnectionData(item, options));
                }
            }
            else if (root.ValueKind == JsonValueKind.Object && root.TryGetProperty("id", out _))
            {
                items.Add(HybridConnectionData.DeserializeHybridConnectionData(root, options));
            }
            return Page.FromValues(items, null, result);
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
