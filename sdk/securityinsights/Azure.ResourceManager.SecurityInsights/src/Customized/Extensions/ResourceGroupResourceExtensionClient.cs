// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using Azure.Core;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.SecurityInsights.Models;

namespace Azure.ResourceManager.SecurityInsights
{
    /// <summary> A class to add extension methods to ResourceGroupResource. </summary>
    [CodeGenSuppress("GetSecurityInsightsAlertRules", typeof(string))]
    [CodeGenSuppress("GetSecurityInsightsAlertRuleTemplates", typeof(string))]
    [CodeGenSuppress("GetSecurityInsightsAutomationRules", typeof(string))]
    [CodeGenSuppress("GetSecurityInsightsBookmarks", typeof(string))]
    [CodeGenSuppress("GetSecurityInsightsDataConnectors", typeof(string))]
    [CodeGenSuppress("GetSecurityInsightsIncidents", typeof(string))]
    [CodeGenSuppress("GetSecurityInsightsSentinelOnboardingStates", typeof(string))]
    [CodeGenSuppress("GetSecurityMLAnalyticsSettings", typeof(string))]
    [CodeGenSuppress("GetSecurityInsightsThreatIntelligenceIndicators", typeof(string))]
    [CodeGenSuppress("GetSecurityInsightsWatchlists", typeof(string))]
    [CodeGenSuppress("QueryThreatIntelligenceIndicatorsAsync", typeof(string), typeof(ThreatIntelligenceFilteringCriteria), typeof(CancellationToken))]
    [CodeGenSuppress("QueryThreatIntelligenceIndicators", typeof(string), typeof(ThreatIntelligenceFilteringCriteria), typeof(CancellationToken))]
    [CodeGenSuppress("GetAllThreatIntelligenceIndicatorMetricsAsync", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetAllThreatIntelligenceIndicatorMetrics", typeof(string), typeof(CancellationToken))]
    internal partial class ResourceGroupResourceExtensionClient : ArmResource
    {
    }
}
