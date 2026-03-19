// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.ServiceBus
{
    /// <summary>
    /// Fixes the diagnostic scope in the generated SBAuthorizationRulesGetAuthorizationRulesCollectionResultOfT.
    /// The generator sets the scope to "ServiceBusNamespaceResource.GetAuthorizationRules" because it misplaces
    /// the List operation onto ServiceBusNamespaceResource (due to @segmentOf casing bug). Our Customized/ GetAll
    /// lives on ServiceBusNamespaceAuthorizationRuleCollection, so the scope must be
    /// "ServiceBusNamespaceAuthorizationRuleCollection.GetAll".
    /// See: https://github.com/Azure/azure-sdk-for-net/issues/57216
    /// </summary>
    internal partial class SBAuthorizationRulesGetAuthorizationRulesCollectionResultOfT
    {
        private Response GetNextResponse(int? pageSizeHint, Uri nextLink)
        {
            HttpMessage message = nextLink != null ? _client.CreateNextGetAuthorizationRulesRequest(nextLink, _subscriptionId, _resourceGroupName, _namespaceName, _context) : _client.CreateGetAuthorizationRulesRequest(_subscriptionId, _resourceGroupName, _namespaceName, _context);
            using DiagnosticScope scope = _client.ClientDiagnostics.CreateScope("ServiceBusNamespaceAuthorizationRuleCollection.GetAll");
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
