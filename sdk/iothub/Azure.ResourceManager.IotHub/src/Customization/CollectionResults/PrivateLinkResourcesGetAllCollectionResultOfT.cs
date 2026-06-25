// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.IotHub.Models;

namespace Azure.ResourceManager.IotHub
{
    internal partial class PrivateLinkResourcesGetAllCollectionResultOfT : Pageable<IotHubPrivateEndpointGroupInformationData>
    {
        private readonly PrivateLinkResources _client;
        private readonly Guid _subscriptionId;
        private readonly string _resourceGroupName;
        private readonly string _resourceName;
        private readonly RequestContext _context;
        private readonly string _diagnosticScope;

        public PrivateLinkResourcesGetAllCollectionResultOfT(PrivateLinkResources client, Guid subscriptionId, string resourceGroupName, string resourceName, RequestContext context, string diagnosticScope) : base(context?.CancellationToken ?? default)
        {
            _client = client;
            _subscriptionId = subscriptionId;
            _resourceGroupName = resourceGroupName;
            _resourceName = resourceName;
            _context = context;
            _diagnosticScope = diagnosticScope;
        }

        public override IEnumerable<Page<IotHubPrivateEndpointGroupInformationData>> AsPages(string continuationToken, int? pageSizeHint)
        {
            Response response = GetNextResponse(pageSizeHint, null);
            Models.PrivateLinkResources result = Models.PrivateLinkResources.FromResponse(response);
            yield return Page<IotHubPrivateEndpointGroupInformationData>.FromValues((IReadOnlyList<IotHubPrivateEndpointGroupInformationData>)result.Value, null, response);
        }

        private Response GetNextResponse(int? pageSizeHint, string continuationToken)
        {
            HttpMessage message = _client.CreateGetAllRequest(_subscriptionId, _resourceGroupName, _resourceName, _context);
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
