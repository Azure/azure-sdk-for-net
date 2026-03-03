// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Maintenance.Models;

namespace Azure.ResourceManager.Maintenance
{
    /// <summary>
    /// Backward-compat sync pageable for listing maintenance updates for a specific resource.
    /// Used by MockableMaintenanceResourceGroupResource.GetUpdates().
    /// The generated UpdatesGetUpdatesByParent* has different parameters (it's a different operation).
    /// </summary>
    internal class UpdatesGetUpdatesCollectionResultOfT : Pageable<MaintenanceUpdate>
    {
        private readonly Updates _client;
        private readonly Guid _subscriptionId;
        private readonly string _resourceGroupName;
        private readonly string _providerName;
        private readonly string _resourceType;
        private readonly string _resourceName;
        private readonly RequestContext _context;

        public UpdatesGetUpdatesCollectionResultOfT(Updates client, Guid subscriptionId, string resourceGroupName, string providerName, string resourceType, string resourceName, RequestContext context) : base(context?.CancellationToken ?? default)
        {
            _client = client;
            _subscriptionId = subscriptionId;
            _resourceGroupName = resourceGroupName;
            _providerName = providerName;
            _resourceType = resourceType;
            _resourceName = resourceName;
            _context = context;
        }

        public override IEnumerable<Page<MaintenanceUpdate>> AsPages(string continuationToken, int? pageSizeHint)
        {
            Uri nextPage = continuationToken != null ? new Uri(continuationToken) : null;
            while (true)
            {
                Response response = GetNextResponse(pageSizeHint, nextPage);
                if (response is null)
                {
                    yield break;
                }
                MaintenanceUpdateListResult result = MaintenanceUpdateListResult.FromResponse(response);
                yield return Page<MaintenanceUpdate>.FromValues((IReadOnlyList<MaintenanceUpdate>)result.Value, nextPage?.IsAbsoluteUri == true ? nextPage.AbsoluteUri : nextPage?.OriginalString, response);
                nextPage = result.NextLink;
                if (nextPage == null)
                {
                    yield break;
                }
            }
        }

        private Response GetNextResponse(int? pageSizeHint, Uri nextLink)
        {
            HttpMessage message = nextLink != null ? _client.CreateNextGetAllRequest(nextLink, _subscriptionId, _resourceGroupName, _providerName, _resourceType, _resourceName, _context) : _client.CreateGetAllRequest(_subscriptionId, _resourceGroupName, _providerName, _resourceType, _resourceName, _context);
            using DiagnosticScope scope = _client.ClientDiagnostics.CreateScope("MockableMaintenanceResourceGroupResource.GetUpdates");
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
