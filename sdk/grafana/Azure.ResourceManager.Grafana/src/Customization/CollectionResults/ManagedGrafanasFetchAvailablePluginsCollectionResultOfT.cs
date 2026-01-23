// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Grafana.Models;

namespace Azure.ResourceManager.Grafana
{
    internal partial class ManagedGrafanasFetchAvailablePluginsCollectionResultOfT : Pageable<GrafanaAvailablePlugin>
    {
        private readonly ManagedGrafanas _client;
        private readonly string _subscriptionId;
        private readonly string _resourceGroupName;
        private readonly string _workspaceName;
        private readonly RequestContext _context;

        /// <summary> Initializes a new instance of ManagedGrafanasFetchAvailablePluginsCollectionResultOfT, which is used to iterate over the pages of a collection. </summary>
        /// <param name="client"> The ManagedGrafanas client used to send requests. </param>
        /// <param name="subscriptionId"> The ID of the target subscription. The value must be an UUID. </param>
        /// <param name="resourceGroupName"> The name of the resource group. The name is case insensitive. </param>
        /// <param name="workspaceName"> The workspace name of Azure Managed Grafana. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public ManagedGrafanasFetchAvailablePluginsCollectionResultOfT(ManagedGrafanas client, string subscriptionId, string resourceGroupName, string workspaceName, RequestContext context) : base(context?.CancellationToken ?? default)
        {
            _client = client;
            _subscriptionId = subscriptionId;
            _resourceGroupName = resourceGroupName;
            _workspaceName = workspaceName;
            _context = context;
        }

        /// <summary> Gets the pages of ManagedGrafanasFetchAvailablePluginsCollectionResultOfT as an enumerable collection. </summary>
        /// <param name="continuationToken"> A continuation token indicating where to resume paging. </param>
        /// <param name="pageSizeHint"> The number of items per page. </param>
        /// <returns> The pages of ManagedGrafanasFetchAvailablePluginsCollectionResultOfT as an enumerable collection. </returns>
        public override IEnumerable<Page<GrafanaAvailablePlugin>> AsPages(string continuationToken, int? pageSizeHint)
        {
            Response response = GetNextResponse(pageSizeHint, null);
            GrafanaAvailablePluginListResult result = GrafanaAvailablePluginListResult.FromResponse(response);
            yield return Page<GrafanaAvailablePlugin>.FromValues((IReadOnlyList<GrafanaAvailablePlugin>)result.Value, null, response);
        }

        /// <summary> Get next page. </summary>
        /// <param name="pageSizeHint"> The number of items per page. </param>
        /// <param name="continuationToken"> A continuation token indicating where to resume paging. </param>
        private Response GetNextResponse(int? pageSizeHint, string continuationToken)
        {
            HttpMessage message = _client.CreateFetchAvailablePluginsRequest(_subscriptionId, _resourceGroupName, _workspaceName, _context);
            using DiagnosticScope scope = _client.ClientDiagnostics.CreateScope("ManagedGrafanaResource.FetchAvailablePlugins");
            scope.Start();
            try
            {
                return _client.Pipeline.ProcessMessage(message, _context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
