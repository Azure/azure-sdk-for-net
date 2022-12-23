// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.SecurityInsights.Models;

namespace Azure.ResourceManager.SecurityInsights
{
    /// <summary>
    /// A class extending from the OperationalInsightsWorkspaceResource in Azure.ResourceManager.SecurityInsights along with the instance operations that can be performed on it.
    /// You can only construct an <see cref="OperationalInsightsWorkspaceSecurityInsightsResource" /> from a <see cref="ResourceIdentifier" /> with a resource type of Microsoft.OperationalInsights/workspaces.
    /// </summary>
    public partial class OperationalInsightsWorkspaceSecurityInsightsResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="OperationalInsightsWorkspaceSecurityInsightsResource"/> instance. </summary>
        internal static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _threatIntelligenceIndicatorClientDiagnostics;
        private readonly ThreatIntelligenceIndicatorRestOperations _threatIntelligenceIndicatorRestClient;
        private readonly ClientDiagnostics _threatIntelligenceIndicatorMetricsClientDiagnostics;
        private readonly ThreatIntelligenceIndicatorMetricsRestOperations _threatIntelligenceIndicatorMetricsRestClient;

        /// <summary> Initializes a new instance of the <see cref="OperationalInsightsWorkspaceSecurityInsightsResource"/> class for mocking. </summary>
        protected OperationalInsightsWorkspaceSecurityInsightsResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="OperationalInsightsWorkspaceSecurityInsightsResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal OperationalInsightsWorkspaceSecurityInsightsResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _threatIntelligenceIndicatorClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.SecurityInsights", ProviderConstants.DefaultProviderNamespace, Diagnostics);
            _threatIntelligenceIndicatorRestClient = new ThreatIntelligenceIndicatorRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);
            _threatIntelligenceIndicatorMetricsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.SecurityInsights", ProviderConstants.DefaultProviderNamespace, Diagnostics);
            _threatIntelligenceIndicatorMetricsRestClient = new ThreatIntelligenceIndicatorMetricsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.OperationalInsights/workspaces";

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
        }

        /// <summary> Gets a collection of SecurityInsightsAlertRuleResources in the OperationalInsightsWorkspaceSecurityInsights. </summary>
        /// <returns> An object representing collection of SecurityInsightsAlertRuleResources and their operations over a SecurityInsightsAlertRuleResource. </returns>
        public virtual SecurityInsightsAlertRuleCollection GetSecurityInsightsAlertRules()
        {
            return GetCachedClient(Client => new SecurityInsightsAlertRuleCollection(Client, Id));
        }

        /// <summary>
        /// Gets the alert rule.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/alertRules/{ruleId}
        /// Operation Id: AlertRules_Get
        /// </summary>
        /// <param name="ruleId"> Alert rule ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="ruleId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="ruleId"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<SecurityInsightsAlertRuleResource>> GetSecurityInsightsAlertRuleAsync(string ruleId, CancellationToken cancellationToken = default)
        {
            return await GetSecurityInsightsAlertRules().GetAsync(ruleId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the alert rule.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/alertRules/{ruleId}
        /// Operation Id: AlertRules_Get
        /// </summary>
        /// <param name="ruleId"> Alert rule ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="ruleId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="ruleId"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<SecurityInsightsAlertRuleResource> GetSecurityInsightsAlertRule(string ruleId, CancellationToken cancellationToken = default)
        {
            return GetSecurityInsightsAlertRules().Get(ruleId, cancellationToken);
        }

        /// <summary> Gets a collection of SecurityInsightsAlertRuleTemplateResources in the OperationalInsightsWorkspaceSecurityInsights. </summary>
        /// <returns> An object representing collection of SecurityInsightsAlertRuleTemplateResources and their operations over a SecurityInsightsAlertRuleTemplateResource. </returns>
        public virtual SecurityInsightsAlertRuleTemplateCollection GetSecurityInsightsAlertRuleTemplates()
        {
            return GetCachedClient(Client => new SecurityInsightsAlertRuleTemplateCollection(Client, Id));
        }

        /// <summary>
        /// Gets the alert rule template.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/alertRuleTemplates/{alertRuleTemplateId}
        /// Operation Id: AlertRuleTemplates_Get
        /// </summary>
        /// <param name="alertRuleTemplateId"> Alert rule template ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="alertRuleTemplateId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="alertRuleTemplateId"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<SecurityInsightsAlertRuleTemplateResource>> GetSecurityInsightsAlertRuleTemplateAsync(string alertRuleTemplateId, CancellationToken cancellationToken = default)
        {
            return await GetSecurityInsightsAlertRuleTemplates().GetAsync(alertRuleTemplateId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the alert rule template.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/alertRuleTemplates/{alertRuleTemplateId}
        /// Operation Id: AlertRuleTemplates_Get
        /// </summary>
        /// <param name="alertRuleTemplateId"> Alert rule template ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="alertRuleTemplateId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="alertRuleTemplateId"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<SecurityInsightsAlertRuleTemplateResource> GetSecurityInsightsAlertRuleTemplate(string alertRuleTemplateId, CancellationToken cancellationToken = default)
        {
            return GetSecurityInsightsAlertRuleTemplates().Get(alertRuleTemplateId, cancellationToken);
        }

        /// <summary> Gets a collection of SecurityInsightsAutomationRuleResources in the OperationalInsightsWorkspaceSecurityInsights. </summary>
        /// <returns> An object representing collection of SecurityInsightsAutomationRuleResources and their operations over a SecurityInsightsAutomationRuleResource. </returns>
        public virtual SecurityInsightsAutomationRuleCollection GetSecurityInsightsAutomationRules()
        {
            return GetCachedClient(Client => new SecurityInsightsAutomationRuleCollection(Client, Id));
        }

        /// <summary>
        /// Gets the automation rule.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/automationRules/{automationRuleId}
        /// Operation Id: AutomationRules_Get
        /// </summary>
        /// <param name="automationRuleId"> Automation rule ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="automationRuleId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="automationRuleId"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<SecurityInsightsAutomationRuleResource>> GetSecurityInsightsAutomationRuleAsync(string automationRuleId, CancellationToken cancellationToken = default)
        {
            return await GetSecurityInsightsAutomationRules().GetAsync(automationRuleId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the automation rule.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/automationRules/{automationRuleId}
        /// Operation Id: AutomationRules_Get
        /// </summary>
        /// <param name="automationRuleId"> Automation rule ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="automationRuleId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="automationRuleId"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<SecurityInsightsAutomationRuleResource> GetSecurityInsightsAutomationRule(string automationRuleId, CancellationToken cancellationToken = default)
        {
            return GetSecurityInsightsAutomationRules().Get(automationRuleId, cancellationToken);
        }

        /// <summary> Gets a collection of SecurityInsightsBookmarkResources in the OperationalInsightsWorkspaceSecurityInsights. </summary>
        /// <returns> An object representing collection of SecurityInsightsBookmarkResources and their operations over a SecurityInsightsBookmarkResource. </returns>
        public virtual SecurityInsightsBookmarkCollection GetSecurityInsightsBookmarks()
        {
            return GetCachedClient(Client => new SecurityInsightsBookmarkCollection(Client, Id));
        }

        /// <summary>
        /// Gets a bookmark.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/bookmarks/{bookmarkId}
        /// Operation Id: Bookmarks_Get
        /// </summary>
        /// <param name="bookmarkId"> Bookmark ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="bookmarkId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="bookmarkId"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<SecurityInsightsBookmarkResource>> GetSecurityInsightsBookmarkAsync(string bookmarkId, CancellationToken cancellationToken = default)
        {
            return await GetSecurityInsightsBookmarks().GetAsync(bookmarkId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a bookmark.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/bookmarks/{bookmarkId}
        /// Operation Id: Bookmarks_Get
        /// </summary>
        /// <param name="bookmarkId"> Bookmark ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="bookmarkId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="bookmarkId"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<SecurityInsightsBookmarkResource> GetSecurityInsightsBookmark(string bookmarkId, CancellationToken cancellationToken = default)
        {
            return GetSecurityInsightsBookmarks().Get(bookmarkId, cancellationToken);
        }

        /// <summary> Gets a collection of SecurityInsightsDataConnectorResources in the OperationalInsightsWorkspaceSecurityInsights. </summary>
        /// <returns> An object representing collection of SecurityInsightsDataConnectorResources and their operations over a SecurityInsightsDataConnectorResource. </returns>
        public virtual SecurityInsightsDataConnectorCollection GetSecurityInsightsDataConnectors()
        {
            return GetCachedClient(Client => new SecurityInsightsDataConnectorCollection(Client, Id));
        }

        /// <summary>
        /// Gets a data connector.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/dataConnectors/{dataConnectorId}
        /// Operation Id: DataConnectors_Get
        /// </summary>
        /// <param name="dataConnectorId"> Connector ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="dataConnectorId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="dataConnectorId"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<SecurityInsightsDataConnectorResource>> GetSecurityInsightsDataConnectorAsync(string dataConnectorId, CancellationToken cancellationToken = default)
        {
            return await GetSecurityInsightsDataConnectors().GetAsync(dataConnectorId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a data connector.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/dataConnectors/{dataConnectorId}
        /// Operation Id: DataConnectors_Get
        /// </summary>
        /// <param name="dataConnectorId"> Connector ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="dataConnectorId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="dataConnectorId"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<SecurityInsightsDataConnectorResource> GetSecurityInsightsDataConnector(string dataConnectorId, CancellationToken cancellationToken = default)
        {
            return GetSecurityInsightsDataConnectors().Get(dataConnectorId, cancellationToken);
        }

        /// <summary> Gets a collection of SecurityInsightsIncidentResources in the OperationalInsightsWorkspaceSecurityInsights. </summary>
        /// <returns> An object representing collection of SecurityInsightsIncidentResources and their operations over a SecurityInsightsIncidentResource. </returns>
        public virtual SecurityInsightsIncidentCollection GetSecurityInsightsIncidents()
        {
            return GetCachedClient(Client => new SecurityInsightsIncidentCollection(Client, Id));
        }

        /// <summary>
        /// Gets a given incident.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/incidents/{incidentId}
        /// Operation Id: Incidents_Get
        /// </summary>
        /// <param name="incidentId"> Incident ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="incidentId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="incidentId"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<SecurityInsightsIncidentResource>> GetSecurityInsightsIncidentAsync(string incidentId, CancellationToken cancellationToken = default)
        {
            return await GetSecurityInsightsIncidents().GetAsync(incidentId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a given incident.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/incidents/{incidentId}
        /// Operation Id: Incidents_Get
        /// </summary>
        /// <param name="incidentId"> Incident ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="incidentId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="incidentId"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<SecurityInsightsIncidentResource> GetSecurityInsightsIncident(string incidentId, CancellationToken cancellationToken = default)
        {
            return GetSecurityInsightsIncidents().Get(incidentId, cancellationToken);
        }

        /// <summary> Gets a collection of SecurityInsightsSentinelOnboardingStateResources in the OperationalInsightsWorkspaceSecurityInsights. </summary>
        /// <returns> An object representing collection of SecurityInsightsSentinelOnboardingStateResources and their operations over a SecurityInsightsSentinelOnboardingStateResource. </returns>
        public virtual SecurityInsightsSentinelOnboardingStateCollection GetSecurityInsightsSentinelOnboardingStates()
        {
            return GetCachedClient(Client => new SecurityInsightsSentinelOnboardingStateCollection(Client, Id));
        }

        /// <summary>
        /// Get Sentinel onboarding state
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/onboardingStates/{sentinelOnboardingStateName}
        /// Operation Id: SentinelOnboardingStates_Get
        /// </summary>
        /// <param name="sentinelOnboardingStateName"> The Sentinel onboarding state name. Supports - default. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="sentinelOnboardingStateName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="sentinelOnboardingStateName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<SecurityInsightsSentinelOnboardingStateResource>> GetSecurityInsightsSentinelOnboardingStateAsync(string sentinelOnboardingStateName, CancellationToken cancellationToken = default)
        {
            return await GetSecurityInsightsSentinelOnboardingStates().GetAsync(sentinelOnboardingStateName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get Sentinel onboarding state
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/onboardingStates/{sentinelOnboardingStateName}
        /// Operation Id: SentinelOnboardingStates_Get
        /// </summary>
        /// <param name="sentinelOnboardingStateName"> The Sentinel onboarding state name. Supports - default. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="sentinelOnboardingStateName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="sentinelOnboardingStateName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<SecurityInsightsSentinelOnboardingStateResource> GetSecurityInsightsSentinelOnboardingState(string sentinelOnboardingStateName, CancellationToken cancellationToken = default)
        {
            return GetSecurityInsightsSentinelOnboardingStates().Get(sentinelOnboardingStateName, cancellationToken);
        }

        /// <summary> Gets a collection of SecurityMLAnalyticsSettingResources in the OperationalInsightsWorkspaceSecurityInsights. </summary>
        /// <returns> An object representing collection of SecurityMLAnalyticsSettingResources and their operations over a SecurityMLAnalyticsSettingResource. </returns>
        public virtual SecurityMLAnalyticsSettingCollection GetSecurityMLAnalyticsSettings()
        {
            return GetCachedClient(Client => new SecurityMLAnalyticsSettingCollection(Client, Id));
        }

        /// <summary>
        /// Gets the Security ML Analytics Settings.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/securityMLAnalyticsSettings/{settingsResourceName}
        /// Operation Id: SecurityMLAnalyticsSettings_Get
        /// </summary>
        /// <param name="settingsResourceName"> Security ML Analytics Settings resource name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="settingsResourceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="settingsResourceName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<SecurityMLAnalyticsSettingResource>> GetSecurityMLAnalyticsSettingAsync(string settingsResourceName, CancellationToken cancellationToken = default)
        {
            return await GetSecurityMLAnalyticsSettings().GetAsync(settingsResourceName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the Security ML Analytics Settings.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/securityMLAnalyticsSettings/{settingsResourceName}
        /// Operation Id: SecurityMLAnalyticsSettings_Get
        /// </summary>
        /// <param name="settingsResourceName"> Security ML Analytics Settings resource name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="settingsResourceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="settingsResourceName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<SecurityMLAnalyticsSettingResource> GetSecurityMLAnalyticsSetting(string settingsResourceName, CancellationToken cancellationToken = default)
        {
            return GetSecurityMLAnalyticsSettings().Get(settingsResourceName, cancellationToken);
        }

        /// <summary> Gets a collection of SecurityInsightsThreatIntelligenceIndicatorResources in the OperationalInsightsWorkspaceSecurityInsights. </summary>
        /// <returns> An object representing collection of SecurityInsightsThreatIntelligenceIndicatorResources and their operations over a SecurityInsightsThreatIntelligenceIndicatorResource. </returns>
        public virtual SecurityInsightsThreatIntelligenceIndicatorCollection GetSecurityInsightsThreatIntelligenceIndicators()
        {
            return GetCachedClient(Client => new SecurityInsightsThreatIntelligenceIndicatorCollection(Client, Id));
        }

        /// <summary>
        /// View a threat intelligence indicator by name.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/threatIntelligence/main/indicators/{name}
        /// Operation Id: ThreatIntelligenceIndicators_Get
        /// </summary>
        /// <param name="name"> Threat intelligence indicator name field. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<SecurityInsightsThreatIntelligenceIndicatorResource>> GetSecurityInsightsThreatIntelligenceIndicatorAsync(string name, CancellationToken cancellationToken = default)
        {
            return await GetSecurityInsightsThreatIntelligenceIndicators().GetAsync(name, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// View a threat intelligence indicator by name.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/threatIntelligence/main/indicators/{name}
        /// Operation Id: ThreatIntelligenceIndicators_Get
        /// </summary>
        /// <param name="name"> Threat intelligence indicator name field. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<SecurityInsightsThreatIntelligenceIndicatorResource> GetSecurityInsightsThreatIntelligenceIndicator(string name, CancellationToken cancellationToken = default)
        {
            return GetSecurityInsightsThreatIntelligenceIndicators().Get(name, cancellationToken);
        }

        /// <summary> Gets a collection of SecurityInsightsWatchlistResources in the OperationalInsightsWorkspaceSecurityInsights. </summary>
        /// <returns> An object representing collection of SecurityInsightsWatchlistResources and their operations over a SecurityInsightsWatchlistResource. </returns>
        public virtual SecurityInsightsWatchlistCollection GetSecurityInsightsWatchlists()
        {
            return GetCachedClient(Client => new SecurityInsightsWatchlistCollection(Client, Id));
        }

        /// <summary>
        /// Get a watchlist, without its watchlist items.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/watchlists/{watchlistAlias}
        /// Operation Id: Watchlists_Get
        /// </summary>
        /// <param name="watchlistAlias"> The watchlist alias. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="watchlistAlias"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="watchlistAlias"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<SecurityInsightsWatchlistResource>> GetSecurityInsightsWatchlistAsync(string watchlistAlias, CancellationToken cancellationToken = default)
        {
            return await GetSecurityInsightsWatchlists().GetAsync(watchlistAlias, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get a watchlist, without its watchlist items.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/watchlists/{watchlistAlias}
        /// Operation Id: Watchlists_Get
        /// </summary>
        /// <param name="watchlistAlias"> The watchlist alias. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="watchlistAlias"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="watchlistAlias"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<SecurityInsightsWatchlistResource> GetSecurityInsightsWatchlist(string watchlistAlias, CancellationToken cancellationToken = default)
        {
            return GetSecurityInsightsWatchlists().Get(watchlistAlias, cancellationToken);
        }

        /// <summary>
        /// Query threat intelligence indicators as per filtering criteria.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/threatIntelligence/main/queryIndicators
        /// Operation Id: ThreatIntelligenceIndicator_QueryIndicators
        /// </summary>
        /// <param name="threatIntelligenceFilteringCriteria"> Filtering criteria for querying threat intelligence indicators. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="threatIntelligenceFilteringCriteria"/> is null. </exception>
        /// <returns> An async collection of <see cref="SecurityInsightsThreatIntelligenceIndicatorResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SecurityInsightsThreatIntelligenceIndicatorResource> QueryThreatIntelligenceIndicatorsAsync(ThreatIntelligenceFilteringCriteria threatIntelligenceFilteringCriteria, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(threatIntelligenceFilteringCriteria, nameof(threatIntelligenceFilteringCriteria));

            async Task<Page<SecurityInsightsThreatIntelligenceIndicatorResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _threatIntelligenceIndicatorClientDiagnostics.CreateScope("OperationalInsightsWorkspaceSecurityInsightsResource.QueryThreatIntelligenceIndicators");
                scope.Start();
                try
                {
                    var response = await _threatIntelligenceIndicatorRestClient.QueryIndicatorsAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, threatIntelligenceFilteringCriteria, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SecurityInsightsThreatIntelligenceIndicatorResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<SecurityInsightsThreatIntelligenceIndicatorResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _threatIntelligenceIndicatorClientDiagnostics.CreateScope("OperationalInsightsWorkspaceSecurityInsightsResource.QueryThreatIntelligenceIndicators");
                scope.Start();
                try
                {
                    var response = await _threatIntelligenceIndicatorRestClient.QueryIndicatorsNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, threatIntelligenceFilteringCriteria, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SecurityInsightsThreatIntelligenceIndicatorResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Query threat intelligence indicators as per filtering criteria.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/threatIntelligence/main/queryIndicators
        /// Operation Id: ThreatIntelligenceIndicator_QueryIndicators
        /// </summary>
        /// <param name="threatIntelligenceFilteringCriteria"> Filtering criteria for querying threat intelligence indicators. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="threatIntelligenceFilteringCriteria"/> is null. </exception>
        /// <returns> A collection of <see cref="SecurityInsightsThreatIntelligenceIndicatorResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SecurityInsightsThreatIntelligenceIndicatorResource> QueryThreatIntelligenceIndicators(ThreatIntelligenceFilteringCriteria threatIntelligenceFilteringCriteria, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(threatIntelligenceFilteringCriteria, nameof(threatIntelligenceFilteringCriteria));

            Page<SecurityInsightsThreatIntelligenceIndicatorResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _threatIntelligenceIndicatorClientDiagnostics.CreateScope("OperationalInsightsWorkspaceSecurityInsightsResource.QueryThreatIntelligenceIndicators");
                scope.Start();
                try
                {
                    var response = _threatIntelligenceIndicatorRestClient.QueryIndicators(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, threatIntelligenceFilteringCriteria, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SecurityInsightsThreatIntelligenceIndicatorResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<SecurityInsightsThreatIntelligenceIndicatorResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _threatIntelligenceIndicatorClientDiagnostics.CreateScope("OperationalInsightsWorkspaceSecurityInsightsResource.QueryThreatIntelligenceIndicators");
                scope.Start();
                try
                {
                    var response = _threatIntelligenceIndicatorRestClient.QueryIndicatorsNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, threatIntelligenceFilteringCriteria, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SecurityInsightsThreatIntelligenceIndicatorResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Get threat intelligence indicators metrics (Indicators counts by Type, Threat Type, Source).
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/threatIntelligence/main/metrics
        /// Operation Id: ThreatIntelligenceIndicatorMetrics_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ThreatIntelligenceMetrics" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ThreatIntelligenceMetrics> GetAllThreatIntelligenceIndicatorMetricsAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<ThreatIntelligenceMetrics>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _threatIntelligenceIndicatorMetricsClientDiagnostics.CreateScope("OperationalInsightsWorkspaceSecurityInsightsResource.GetAllThreatIntelligenceIndicatorMetrics");
                scope.Start();
                try
                {
                    var response = await _threatIntelligenceIndicatorMetricsRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        /// <summary>
        /// Get threat intelligence indicators metrics (Indicators counts by Type, Threat Type, Source).
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/threatIntelligence/main/metrics
        /// Operation Id: ThreatIntelligenceIndicatorMetrics_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ThreatIntelligenceMetrics" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ThreatIntelligenceMetrics> GetAllThreatIntelligenceIndicatorMetrics(CancellationToken cancellationToken = default)
        {
            Page<ThreatIntelligenceMetrics> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _threatIntelligenceIndicatorMetricsClientDiagnostics.CreateScope("OperationalInsightsWorkspaceSecurityInsightsResource.GetAllThreatIntelligenceIndicatorMetrics");
                scope.Start();
                try
                {
                    var response = _threatIntelligenceIndicatorMetricsRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }
    }
}
