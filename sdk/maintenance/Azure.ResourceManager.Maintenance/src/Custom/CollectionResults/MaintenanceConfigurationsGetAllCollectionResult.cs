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
    /// Subscription-level pageable for listing all maintenance configurations.
    /// Used by the backward-compatible GetMaintenanceConfigurations(CancellationToken) method.
    /// </summary>
    internal class MaintenanceConfigurationsGetAllCollectionResult : Pageable<MaintenanceConfigurationData>
    {
        private readonly MaintenanceConfigurations _client;
        private readonly Guid _subscriptionId;
        private readonly RequestContext _context;

        public MaintenanceConfigurationsGetAllCollectionResult(MaintenanceConfigurations client, Guid subscriptionId, RequestContext context) : base(context?.CancellationToken ?? default)
        {
            _client = client;
            _subscriptionId = subscriptionId;
            _context = context;
        }

        public override IEnumerable<Page<MaintenanceConfigurationData>> AsPages(string continuationToken, int? pageSizeHint)
        {
            Uri nextPage = continuationToken != null ? new Uri(continuationToken) : null;
            while (true)
            {
                Response response = GetNextResponse(pageSizeHint, nextPage);
                if (response is null)
                {
                    yield break;
                }
                MaintenanceConfigurationListResult result = MaintenanceConfigurationListResult.FromResponse(response);
                yield return Page<MaintenanceConfigurationData>.FromValues((IReadOnlyList<MaintenanceConfigurationData>)result.Value, nextPage?.IsAbsoluteUri == true ? nextPage.AbsoluteUri : nextPage?.OriginalString, response);
                nextPage = result.NextLink;
                if (nextPage == null)
                {
                    yield break;
                }
            }
        }

        private Response GetNextResponse(int? pageSizeHint, Uri nextLink)
        {
            HttpMessage message = nextLink != null ? _client.CreateNextGetAllRequest(nextLink, _subscriptionId, _context) : _client.CreateGetAllRequest(_subscriptionId, _context);
            using DiagnosticScope scope = _client.ClientDiagnostics.CreateScope("MockableMaintenanceSubscriptionResource.GetMaintenanceConfigurations");
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
