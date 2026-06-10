// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.EventGrid
{
    // Workaround for https://github.com/Azure/azure-sdk-for-net/issues/59358 — see
    // NetworkSecurityPerimeterConfigurationsGetAllAsyncCollectionResultOfT.cs for context.
    internal partial class NetworkSecurityPerimeterConfigurationsGetAllCollectionResultOfT : Pageable<NetworkSecurityPerimeterConfigurationData>
    {
        private readonly NetworkSecurityPerimeterConfigurations _client;
        private readonly Guid _subscriptionId;
        private readonly string _resourceGroupName;
        private readonly string _resourceType;
        private readonly string _resourceName;
        private readonly RequestContext _context;
        private readonly string _diagnosticScope;

        public NetworkSecurityPerimeterConfigurationsGetAllCollectionResultOfT(
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

        public override IEnumerable<Page<NetworkSecurityPerimeterConfigurationData>> AsPages(string continuationToken, int? pageSizeHint)
        {
            Uri nextPage = continuationToken != null ? new Uri(continuationToken) : null;
            while (true)
            {
                Response response = GetNextResponse(pageSizeHint, nextPage);
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

        private Response GetNextResponse(int? pageSizeHint, Uri nextLink)
        {
            HttpMessage message = nextLink != null
                ? _client.CreateNextGetAllRequest(nextLink, _subscriptionId, _resourceGroupName, _resourceType, _resourceName, _context)
                : _client.CreateGetAllRequest(_subscriptionId, _resourceGroupName, _resourceType, _resourceName, _context);
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
