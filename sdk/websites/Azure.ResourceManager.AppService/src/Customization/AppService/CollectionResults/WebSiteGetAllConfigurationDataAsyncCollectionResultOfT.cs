// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.AppService
{
    // Compatibility shim: GA 1.5.0 exposed WebSiteResource.GetAllConfigurationData[Async] returning
    // Pageable<SiteConfigData>. The generator emits Sites.CreateGetAllConfigurationDataRequest but no
    // CollectionResult, so this wrapper is needed to preserve the GA public surface.
    internal partial class WebSiteGetAllConfigurationDataAsyncCollectionResultOfT : AsyncPageable<SiteConfigData>
    {
        private readonly Sites _client;
        private readonly Guid _subscriptionId;
        private readonly string _resourceGroupName;
        private readonly string _name;
        private readonly RequestContext _context;
        private readonly string _diagnosticScope;

        public WebSiteGetAllConfigurationDataAsyncCollectionResultOfT(Sites client, Guid subscriptionId, string resourceGroupName, string name, RequestContext context, string diagnosticScope) : base(context?.CancellationToken ?? default)
        {
            _client = client;
            _subscriptionId = subscriptionId;
            _resourceGroupName = resourceGroupName;
            _name = name;
            _context = context;
            _diagnosticScope = diagnosticScope;
        }

        public override async IAsyncEnumerable<Page<SiteConfigData>> AsPages(string continuationToken, int? pageSizeHint)
        {
            Uri nextPage = continuationToken != null ? new Uri(continuationToken) : null;
            while (true)
            {
                Response response = await GetNextResponseAsync(pageSizeHint, nextPage).ConfigureAwait(false);
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

        private async ValueTask<Response> GetNextResponseAsync(int? pageSizeHint, Uri nextLink)
        {
            HttpMessage message = nextLink != null ? _client.CreateNextGetAllConfigurationDataRequest(nextLink, _subscriptionId, _resourceGroupName, _name, _context) : _client.CreateGetAllConfigurationDataRequest(_subscriptionId, _resourceGroupName, _name, _context);
            using DiagnosticScope scope = _client.ClientDiagnostics.CreateScope(_diagnosticScope);
            scope.Start();
            try
            {
                return await _client.Pipeline.ProcessMessageAsync(message, _context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
