// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.SecurityInsights.Models;

namespace Azure.ResourceManager.SecurityInsights
{
    /// <summary> A class to add extension methods to Azure.ResourceManager.SecurityInsights. </summary>
    [CodeGenSuppress("GetSecurityInsightsAlertRules", typeof(ResourceGroupResource), typeof(string))]
    [CodeGenSuppress("GetSecurityInsightsAlertRuleAsync", typeof(ResourceGroupResource), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetSecurityInsightsAlertRule", typeof(ResourceGroupResource), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetSecurityInsightsAlertRuleTemplates", typeof(ResourceGroupResource), typeof(string))]
    [CodeGenSuppress("GetSecurityInsightsAlertRuleTemplateAsync", typeof(ResourceGroupResource), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetSecurityInsightsAlertRuleTemplate", typeof(ResourceGroupResource), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetSecurityInsightsAutomationRules", typeof(ResourceGroupResource), typeof(string))]
    [CodeGenSuppress("GetSecurityInsightsAutomationRuleAsync", typeof(ResourceGroupResource), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetSecurityInsightsAutomationRule", typeof(ResourceGroupResource), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetSecurityInsightsBookmarks", typeof(ResourceGroupResource), typeof(string))]
    [CodeGenSuppress("GetSecurityInsightsBookmarkAsync", typeof(ResourceGroupResource), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetSecurityInsightsBookmark", typeof(ResourceGroupResource), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetSecurityInsightsDataConnectors", typeof(ResourceGroupResource), typeof(string))]
    [CodeGenSuppress("GetSecurityInsightsDataConnectorAsync", typeof(ResourceGroupResource), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetSecurityInsightsDataConnector", typeof(ResourceGroupResource), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetSecurityInsightsIncidents", typeof(ResourceGroupResource), typeof(string))]
    [CodeGenSuppress("GetSecurityInsightsIncidentAsync", typeof(ResourceGroupResource), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetSecurityInsightsIncident", typeof(ResourceGroupResource), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetSecurityInsightsSentinelOnboardingStates", typeof(ResourceGroupResource), typeof(string))]
    [CodeGenSuppress("GetSecurityInsightsSentinelOnboardingStateAsync", typeof(ResourceGroupResource), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetSecurityInsightsSentinelOnboardingState", typeof(ResourceGroupResource), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetSecurityMLAnalyticsSettings", typeof(ResourceGroupResource), typeof(string))]
    [CodeGenSuppress("GetSecurityMLAnalyticsSettingAsync", typeof(ResourceGroupResource), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetSecurityMLAnalyticsSetting", typeof(ResourceGroupResource), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetSecurityInsightsThreatIntelligenceIndicators", typeof(ResourceGroupResource), typeof(string))]
    [CodeGenSuppress("GetSecurityInsightsThreatIntelligenceIndicatorAsync", typeof(ResourceGroupResource), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetSecurityInsightsThreatIntelligenceIndicator", typeof(ResourceGroupResource), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetSecurityInsightsWatchlists", typeof(ResourceGroupResource), typeof(string))]
    [CodeGenSuppress("GetSecurityInsightsWatchlistAsync", typeof(ResourceGroupResource), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetSecurityInsightsWatchlist", typeof(ResourceGroupResource), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("QueryThreatIntelligenceIndicatorsAsync", typeof(ResourceGroupResource), typeof(string), typeof(ThreatIntelligenceFilteringCriteria), typeof(CancellationToken))]
    [CodeGenSuppress("QueryThreatIntelligenceIndicators", typeof(ResourceGroupResource), typeof(string), typeof(ThreatIntelligenceFilteringCriteria), typeof(CancellationToken))]
    [CodeGenSuppress("GetAllThreatIntelligenceIndicatorMetricsAsync", typeof(ResourceGroupResource), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetAllThreatIntelligenceIndicatorMetrics", typeof(ResourceGroupResource), typeof(string), typeof(CancellationToken))]
    public static partial class SecurityInsightsExtensions
    {
        #region OperationalInsightsWorkspaceSecurityInsightsResource
        /// <summary>
        /// Gets an object representing an <see cref="OperationalInsightsWorkspaceSecurityInsightsResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="OperationalInsightsWorkspaceSecurityInsightsResource.CreateResourceIdentifier" /> to create an <see cref="OperationalInsightsWorkspaceSecurityInsightsResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="OperationalInsightsWorkspaceSecurityInsightsResource" /> object. </returns>
        public static OperationalInsightsWorkspaceSecurityInsightsResource GetOperationalInsightsWorkspaceSecurityInsightsResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient<OperationalInsightsWorkspaceSecurityInsightsResource>(() =>
            {
                OperationalInsightsWorkspaceSecurityInsightsResource.ValidateResourceId(id);
                return new OperationalInsightsWorkspaceSecurityInsightsResource(client, id);
            }
            );
        }
        #endregion
    }
}
