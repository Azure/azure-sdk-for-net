// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.ResourceManager.SecurityInsights.Tests.TestCase
{
    internal class OperationalInsightsWorkspaceSecurityInsightsResource
    {
        private readonly ArmClient _client;
        private readonly ResourceIdentifier _workspaceResourceIdentifier;

        public OperationalInsightsWorkspaceSecurityInsightsResource(ArmClient client, ResourceIdentifier workspaceResourceIdentifier)
        {
            _client = client;
            _workspaceResourceIdentifier = workspaceResourceIdentifier;
        }

        public SecurityInsightsAlertRuleCollection GetSecurityInsightsAlertRules()
            => _client.GetSecurityInsightsAlertRules(_workspaceResourceIdentifier);

        public SecurityInsightsAutomationRuleCollection GetSecurityInsightsAutomationRules()
            => _client.GetSecurityInsightsAutomationRules(_workspaceResourceIdentifier);

        public SecurityInsightsBookmarkCollection GetSecurityInsightsBookmarks()
            => _client.GetSecurityInsightsBookmarks(_workspaceResourceIdentifier);

        public SecurityInsightsDataConnectorCollection GetSecurityInsightsDataConnectors()
            => _client.GetSecurityInsightsDataConnectors(_workspaceResourceIdentifier);

        public SecurityInsightsIncidentCollection GetSecurityInsightsIncidents()
            => _client.GetSecurityInsightsIncidents(_workspaceResourceIdentifier);

        public SecurityInsightsSentinelOnboardingStateCollection GetSecurityInsightsSentinelOnboardingStates()
            => _client.GetSecurityInsightsSentinelOnboardingStates(_workspaceResourceIdentifier);

        public SecurityInsightsWatchlistCollection GetSecurityInsightsWatchlists()
            => _client.GetSecurityInsightsWatchlists(_workspaceResourceIdentifier);
    }
}