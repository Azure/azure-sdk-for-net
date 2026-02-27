// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Maintenance.Models;

namespace Azure.ResourceManager.Maintenance
{
    /// <summary>
    /// Subscription-level async pageable for listing all maintenance configurations.
    /// Used by the backward-compatible GetMaintenanceConfigurationsAsync(CancellationToken) method.
    /// </summary>
    internal class MaintenanceConfigurationsGetAllAsyncCollectionResult : AsyncPageable<MaintenanceConfigurationData>
    {
        private readonly MaintenanceConfigurations _client;
        private readonly Guid _subscriptionId;
        private readonly RequestContext _context;

        public MaintenanceConfigurationsGetAllAsyncCollectionResult(MaintenanceConfigurations client, Guid subscriptionId, RequestContext context) : base(context?.CancellationToken ?? default)
        {
            _client = client;
            _subscriptionId = subscriptionId;
            _context = context;
        }

        public override async IAsyncEnumerable<Page<MaintenanceConfigurationData>> AsPages(string continuationToken, int? pageSizeHint)
        {
            Uri nextPage = continuationToken != null ? new Uri(continuationToken) : null;
            while (true)
            {
                Response response = await GetNextResponseAsync(pageSizeHint, nextPage).ConfigureAwait(false);
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

        private async ValueTask<Response> GetNextResponseAsync(int? pageSizeHint, Uri nextLink)
        {
            HttpMessage message = nextLink != null ? _client.CreateNextGetAllRequest(nextLink, _subscriptionId, _context) : _client.CreateGetAllRequest(_subscriptionId, _context);
            using DiagnosticScope scope = _client.ClientDiagnostics.CreateScope("MockableMaintenanceSubscriptionResource.GetMaintenanceConfigurations");
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
