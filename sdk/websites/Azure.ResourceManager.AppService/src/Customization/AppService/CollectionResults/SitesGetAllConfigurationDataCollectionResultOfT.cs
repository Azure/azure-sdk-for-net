// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.AppService
{
    internal partial class SitesGetAllConfigurationDataCollectionResultOfT : Pageable<SiteConfigData>
    {
        private readonly Sites _client;
        private readonly Guid _subscriptionId;
        private readonly string _resourceGroupName;
        private readonly string _name;
        private readonly RequestContext _context;
        private readonly string _diagnosticScope;

        public SitesGetAllConfigurationDataCollectionResultOfT(Sites client, Guid subscriptionId, string resourceGroupName, string name, RequestContext context, string diagnosticScope) : base(context?.CancellationToken ?? default)
        {
            _client = client;
            _subscriptionId = subscriptionId;
            _resourceGroupName = resourceGroupName;
            _name = name;
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
            HttpMessage message = nextLink != null ? _client.CreateNextGetAllConfigurationDataRequest(nextLink, _subscriptionId, _resourceGroupName, _name, _context) : _client.CreateGetAllConfigurationDataRequest(_subscriptionId, _resourceGroupName, _name, _context);
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
