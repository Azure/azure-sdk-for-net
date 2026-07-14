// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.AppService
{
    // Compatibility shim: GA 1.5.0 exposed WebSiteSlotResource.GetAllConfigurationSlotData returning
    // Pageable<SiteConfigData>. The generator emits WebApps.CreateGetAllConfigurationSlotDataRequest
    // but no CollectionResult, so this synchronous wrapper is needed to preserve the GA public surface.
    // Sibling: WebSiteSlotGetAllConfigurationSlotDataAsyncCollectionResultOfT for the async path.
    internal partial class WebSiteSlotGetAllConfigurationSlotDataCollectionResultOfT : Pageable<SiteConfigData>
    {
        private readonly WebApps _client;
        private readonly Guid _subscriptionId;
        private readonly string _resourceGroupName;
        private readonly string _name;
        private readonly string _slot;
        private readonly RequestContext _context;
        private readonly string _diagnosticScope;

        public WebSiteSlotGetAllConfigurationSlotDataCollectionResultOfT(WebApps client, Guid subscriptionId, string resourceGroupName, string name, string slot, RequestContext context, string diagnosticScope) : base(context?.CancellationToken ?? default)
        {
            _client = client;
            _subscriptionId = subscriptionId;
            _resourceGroupName = resourceGroupName;
            _name = name;
            _slot = slot;
            _context = context;
            _diagnosticScope = diagnosticScope;
        }

        public override IEnumerable<Page<SiteConfigData>> AsPages(string continuationToken, int? pageSizeHint)
        {
            Uri nextPage = continuationToken != null ? new Uri(continuationToken) : null;
            while (true)
            {
                Response response = GetNextResponse(pageSizeHint, nextPage);
                if (response is null)
                {
                    yield break;
                }
                (IReadOnlyList<SiteConfigData> values, Uri nextLink) = SitesGetAllConfigurationDataPageParser.Parse(response);
                yield return Page<SiteConfigData>.FromValues(values, nextPage?.IsAbsoluteUri == true ? nextPage.AbsoluteUri : nextPage?.OriginalString, response);
                nextPage = nextLink;
                if (nextPage == null)
                {
                    yield break;
                }
            }
        }

        private Response GetNextResponse(int? pageSizeHint, Uri nextLink)
        {
            HttpMessage message = nextLink != null ? _client.CreateNextGetAllConfigurationSlotDataRequest(nextLink, _subscriptionId, _resourceGroupName, _name, _slot, _context) : _client.CreateGetAllConfigurationSlotDataRequest(_subscriptionId, _resourceGroupName, _name, _slot, _context);
            using DiagnosticScope scope = _client.ClientDiagnostics.CreateScope(_diagnosticScope);
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
