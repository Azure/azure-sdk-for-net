// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.EventGrid
{
    // Workaround for https://github.com/Azure/azure-sdk-for-net/issues/59358
    // (Mgmt CodeGen dynamic-parent expansion: NSP per-parent Collection classes were
    // not emitted by the new MPG generator. We hand-author a pageable result helper
    // and the matching DomainNSPCollection / TopicNSPCollection classes against the
    // generator-produced internal NetworkSecurityPerimeterConfigurations REST client.)
    internal partial class NetworkSecurityPerimeterConfigurationsGetAllAsyncCollectionResultOfT : AsyncPageable<NetworkSecurityPerimeterConfigurationData>
    {
        private readonly NetworkSecurityPerimeterConfigurations _client;
        private readonly Guid _subscriptionId;
        private readonly string _resourceGroupName;
        private readonly string _resourceType;
        private readonly string _resourceName;
        private readonly RequestContext _context;
        private readonly string _diagnosticScope;

        public NetworkSecurityPerimeterConfigurationsGetAllAsyncCollectionResultOfT(
            NetworkSecurityPerimeterConfigurations client,
            Guid subscriptionId,
            string resourceGroupName,
            string resourceType,
            string resourceName,
            RequestContext context,
            string diagnosticScope)
            : base(context?.CancellationToken ?? default)
        {
            _client = client;
            _subscriptionId = subscriptionId;
            _resourceGroupName = resourceGroupName;
            _resourceType = resourceType;
            _resourceName = resourceName;
            _context = context;
            _diagnosticScope = diagnosticScope;
        }

        public override async IAsyncEnumerable<Page<NetworkSecurityPerimeterConfigurationData>> AsPages(string continuationToken, int? pageSizeHint)
        {
            Uri nextPage = continuationToken != null ? new Uri(continuationToken) : null;
            while (true)
            {
                Response response = await GetNextResponseAsync(pageSizeHint, nextPage).ConfigureAwait(false);
                if (response is null)
                {
                    yield break;
                }
                (IReadOnlyList<NetworkSecurityPerimeterConfigurationData> values, Uri nextLink) = NetworkSecurityPerimeterConfigurationListParser.ParsePage(response);
                yield return Page<NetworkSecurityPerimeterConfigurationData>.FromValues(
                    values,
                    nextPage?.IsAbsoluteUri == true ? nextPage.AbsoluteUri : nextPage?.OriginalString,
                    response);
                nextPage = nextLink;
                if (nextPage == null)
                {
                    yield break;
                }
            }
        }

        private async ValueTask<Response> GetNextResponseAsync(int? pageSizeHint, Uri nextLink)
        {
            HttpMessage message = nextLink != null
                ? _client.CreateNextGetAllRequest(nextLink, _subscriptionId, _resourceGroupName, _resourceType, _resourceName, _context)
                : _client.CreateGetAllRequest(_subscriptionId, _resourceGroupName, _resourceType, _resourceName, _context);
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
