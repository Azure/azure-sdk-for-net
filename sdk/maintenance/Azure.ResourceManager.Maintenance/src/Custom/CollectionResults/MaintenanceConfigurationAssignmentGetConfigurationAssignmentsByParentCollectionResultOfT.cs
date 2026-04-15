// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Custom code: the generator dropped this CollectionResult type after [CodeGenType] rename
// of ConfigurationAssignmentResource to MaintenanceConfigurationAssignmentResource.
// Re-created from the old generated code, using MaintenanceConfigurationAssignment REST client.

#nullable disable

using System;
using System.Collections.Generic;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Maintenance.Models;

namespace Azure.ResourceManager.Maintenance
{
    internal partial class MaintenanceConfigurationAssignmentGetConfigurationAssignmentsByParentCollectionResultOfT : Pageable<MaintenanceConfigurationAssignmentData>
    {
        private readonly MaintenanceConfigurationAssignment _client;
        private readonly Guid _subscriptionId;
        private readonly string _resourceGroupName;
        private readonly string _providerName;
        private readonly string _resourceParentType;
        private readonly string _resourceParentName;
        private readonly string _resourceType;
        private readonly string _resourceName;
        private readonly RequestContext _context;
        private readonly string _diagnosticScope;

        public MaintenanceConfigurationAssignmentGetConfigurationAssignmentsByParentCollectionResultOfT(MaintenanceConfigurationAssignment client, Guid subscriptionId, string resourceGroupName, string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, RequestContext context, string diagnosticScope) : base(context?.CancellationToken ?? default)
        {
            _client = client;
            _subscriptionId = subscriptionId;
            _resourceGroupName = resourceGroupName;
            _providerName = providerName;
            _resourceParentType = resourceParentType;
            _resourceParentName = resourceParentName;
            _resourceType = resourceType;
            _resourceName = resourceName;
            _context = context;
            _diagnosticScope = diagnosticScope;
        }

        public override IEnumerable<Page<MaintenanceConfigurationAssignmentData>> AsPages(string continuationToken, int? pageSizeHint)
        {
            Uri nextPage = continuationToken != null ? new Uri(continuationToken) : null;
            while (true)
            {
                HttpMessage message = nextPage != null
                    ? _client.CreateNextGetConfigurationAssignmentsByParentRequest(nextPage, _subscriptionId, _resourceGroupName, _providerName, _resourceParentType, _resourceParentName, _resourceType, _resourceName, _context)
                    : _client.CreateGetConfigurationAssignmentsByParentRequest(_subscriptionId, _resourceGroupName, _providerName, _resourceParentType, _resourceParentName, _resourceType, _resourceName, _context);
                using DiagnosticScope scope = _client.ClientDiagnostics.CreateScope(_diagnosticScope);
                scope.Start();
                Response response;
                try
                {
                    response = _client.Pipeline.ProcessMessage(message, _context);
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
                MaintenanceConfigurationAssignmentListResult result = MaintenanceConfigurationAssignmentListResult.FromResponse(response);
                yield return Page<MaintenanceConfigurationAssignmentData>.FromValues((IReadOnlyList<MaintenanceConfigurationAssignmentData>)result.Value, nextPage?.IsAbsoluteUri == true ? nextPage.AbsoluteUri : nextPage?.OriginalString, response);
                nextPage = result.NextLink;
                if (nextPage == null)
                {
                    yield break;
                }
            }
        }
    }
}
