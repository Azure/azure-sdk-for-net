namespace Azure.ResourceManager.SecurityInsights
{
    public partial class OperationalInsightsWorkspaceSecurityInsightsResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OperationalInsightsWorkspaceSecurityInsightsResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceMetrics> GetAllThreatIntelligenceIndicatorMetrics(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceMetrics> GetAllThreatIntelligenceIndicatorMetricsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleResource> GetSecurityInsightsAlertRule(string ruleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleResource>> GetSecurityInsightsAlertRuleAsync(string ruleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleCollection GetSecurityInsightsAlertRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleTemplateResource> GetSecurityInsightsAlertRuleTemplate(string alertRuleTemplateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleTemplateResource>> GetSecurityInsightsAlertRuleTemplateAsync(string alertRuleTemplateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleTemplateCollection GetSecurityInsightsAlertRuleTemplates() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsAutomationRuleResource> GetSecurityInsightsAutomationRule(string automationRuleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsAutomationRuleResource>> GetSecurityInsightsAutomationRuleAsync(string automationRuleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SecurityInsights.SecurityInsightsAutomationRuleCollection GetSecurityInsightsAutomationRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsBookmarkResource> GetSecurityInsightsBookmark(string bookmarkId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsBookmarkResource>> GetSecurityInsightsBookmarkAsync(string bookmarkId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SecurityInsights.SecurityInsightsBookmarkCollection GetSecurityInsightsBookmarks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsDataConnectorResource> GetSecurityInsightsDataConnector(string dataConnectorId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsDataConnectorResource>> GetSecurityInsightsDataConnectorAsync(string dataConnectorId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SecurityInsights.SecurityInsightsDataConnectorCollection GetSecurityInsightsDataConnectors() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentResource> GetSecurityInsightsIncident(string incidentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentResource>> GetSecurityInsightsIncidentAsync(string incidentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentCollection GetSecurityInsightsIncidents() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsSentinelOnboardingStateResource> GetSecurityInsightsSentinelOnboardingState(string sentinelOnboardingStateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsSentinelOnboardingStateResource>> GetSecurityInsightsSentinelOnboardingStateAsync(string sentinelOnboardingStateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SecurityInsights.SecurityInsightsSentinelOnboardingStateCollection GetSecurityInsightsSentinelOnboardingStates() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsThreatIntelligenceIndicatorResource> GetSecurityInsightsThreatIntelligenceIndicator(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsThreatIntelligenceIndicatorResource>> GetSecurityInsightsThreatIntelligenceIndicatorAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SecurityInsights.SecurityInsightsThreatIntelligenceIndicatorCollection GetSecurityInsightsThreatIntelligenceIndicators() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistResource> GetSecurityInsightsWatchlist(string watchlistAlias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistResource>> GetSecurityInsightsWatchlistAsync(string watchlistAlias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistCollection GetSecurityInsightsWatchlists() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingResource> GetSecurityMLAnalyticsSetting(string settingsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingResource>> GetSecurityMLAnalyticsSettingAsync(string settingsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingCollection GetSecurityMLAnalyticsSettings() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityInsights.SecurityInsightsThreatIntelligenceIndicatorResource> QueryThreatIntelligenceIndicators(Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceFilteringCriteria threatIntelligenceFilteringCriteria, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityInsights.SecurityInsightsThreatIntelligenceIndicatorResource> QueryThreatIntelligenceIndicatorsAsync(Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceFilteringCriteria threatIntelligenceFilteringCriteria, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SecurityInsightsAlertRuleActionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleActionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleActionResource>, System.Collections.IEnumerable
    {
        protected SecurityInsightsAlertRuleActionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleActionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string actionId, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleActionCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleActionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string actionId, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleActionCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string actionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string actionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleActionResource> Get(string actionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleActionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleActionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleActionResource>> GetAsync(string actionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleActionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleActionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleActionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleActionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SecurityInsightsAlertRuleActionData : Azure.ResourceManager.Models.ResourceData
    {
        public SecurityInsightsAlertRuleActionData() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier LogicAppResourceId { get { throw null; } set { } }
        public string WorkflowId { get { throw null; } set { } }
    }
    public partial class SecurityInsightsAlertRuleActionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SecurityInsightsAlertRuleActionResource() { }
        public virtual Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleActionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string ruleId, string actionId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleActionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleActionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleActionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleActionCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleActionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleActionCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SecurityInsightsAlertRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleResource>, System.Collections.IEnumerable
    {
        protected SecurityInsightsAlertRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string ruleId, Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string ruleId, Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string ruleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ruleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleResource> Get(string ruleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleResource>> GetAsync(string ruleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SecurityInsightsAlertRuleData : Azure.ResourceManager.Models.ResourceData
    {
        public SecurityInsightsAlertRuleData() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
    }
    public partial class SecurityInsightsAlertRuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SecurityInsightsAlertRuleResource() { }
        public virtual Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string ruleId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleActionResource> GetSecurityInsightsAlertRuleAction(string actionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleActionResource>> GetSecurityInsightsAlertRuleActionAsync(string actionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleActionCollection GetSecurityInsightsAlertRuleActions() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SecurityInsightsAlertRuleTemplateCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleTemplateResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleTemplateResource>, System.Collections.IEnumerable
    {
        protected SecurityInsightsAlertRuleTemplateCollection() { }
        public virtual Azure.Response<bool> Exists(string alertRuleTemplateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string alertRuleTemplateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleTemplateResource> Get(string alertRuleTemplateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleTemplateResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleTemplateResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleTemplateResource>> GetAsync(string alertRuleTemplateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleTemplateResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleTemplateResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleTemplateResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleTemplateResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SecurityInsightsAlertRuleTemplateData : Azure.ResourceManager.Models.ResourceData
    {
        public SecurityInsightsAlertRuleTemplateData() { }
    }
    public partial class SecurityInsightsAlertRuleTemplateResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SecurityInsightsAlertRuleTemplateResource() { }
        public virtual Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleTemplateData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string alertRuleTemplateId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleTemplateResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleTemplateResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SecurityInsightsAutomationRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsAutomationRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsAutomationRuleResource>, System.Collections.IEnumerable
    {
        protected SecurityInsightsAutomationRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SecurityInsightsAutomationRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string automationRuleId, Azure.ResourceManager.SecurityInsights.SecurityInsightsAutomationRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SecurityInsightsAutomationRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string automationRuleId, Azure.ResourceManager.SecurityInsights.SecurityInsightsAutomationRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string automationRuleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string automationRuleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsAutomationRuleResource> Get(string automationRuleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityInsights.SecurityInsightsAutomationRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityInsights.SecurityInsightsAutomationRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsAutomationRuleResource>> GetAsync(string automationRuleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityInsights.SecurityInsightsAutomationRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsAutomationRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityInsights.SecurityInsightsAutomationRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsAutomationRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SecurityInsightsAutomationRuleData : Azure.ResourceManager.Models.ResourceData
    {
        public SecurityInsightsAutomationRuleData(string displayName, int order, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAutomationRuleTriggeringLogic triggeringLogic, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAutomationRuleAction> actions) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAutomationRuleAction> Actions { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsClientInfo CreatedBy { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsClientInfo LastModifiedBy { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public int Order { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAutomationRuleTriggeringLogic TriggeringLogic { get { throw null; } set { } }
    }
    public partial class SecurityInsightsAutomationRuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SecurityInsightsAutomationRuleResource() { }
        public virtual Azure.ResourceManager.SecurityInsights.SecurityInsightsAutomationRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string automationRuleId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<System.BinaryData> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<System.BinaryData>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsAutomationRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsAutomationRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SecurityInsightsAutomationRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.SecurityInsightsAutomationRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SecurityInsightsAutomationRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.SecurityInsightsAutomationRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SecurityInsightsBookmarkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsBookmarkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsBookmarkResource>, System.Collections.IEnumerable
    {
        protected SecurityInsightsBookmarkCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SecurityInsightsBookmarkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string bookmarkId, Azure.ResourceManager.SecurityInsights.SecurityInsightsBookmarkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SecurityInsightsBookmarkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string bookmarkId, Azure.ResourceManager.SecurityInsights.SecurityInsightsBookmarkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string bookmarkId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string bookmarkId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsBookmarkResource> Get(string bookmarkId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityInsights.SecurityInsightsBookmarkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityInsights.SecurityInsightsBookmarkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsBookmarkResource>> GetAsync(string bookmarkId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityInsights.SecurityInsightsBookmarkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsBookmarkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityInsights.SecurityInsightsBookmarkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsBookmarkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SecurityInsightsBookmarkData : Azure.ResourceManager.Models.ResourceData
    {
        public SecurityInsightsBookmarkData() { }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsUserInfo CreatedBy { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public System.DateTimeOffset? EventOn { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsBookmarkIncidentInfo IncidentInfo { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Labels { get { throw null; } }
        public string Notes { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        public System.DateTimeOffset? QueryEndOn { get { throw null; } set { } }
        public string QueryResult { get { throw null; } set { } }
        public System.DateTimeOffset? QueryStartOn { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsUserInfo UpdatedBy { get { throw null; } set { } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } set { } }
    }
    public partial class SecurityInsightsBookmarkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SecurityInsightsBookmarkResource() { }
        public virtual Azure.ResourceManager.SecurityInsights.SecurityInsightsBookmarkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string bookmarkId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsBookmarkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsBookmarkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SecurityInsightsBookmarkResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.SecurityInsightsBookmarkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SecurityInsightsBookmarkResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.SecurityInsightsBookmarkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SecurityInsightsDataConnectorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsDataConnectorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsDataConnectorResource>, System.Collections.IEnumerable
    {
        protected SecurityInsightsDataConnectorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SecurityInsightsDataConnectorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string dataConnectorId, Azure.ResourceManager.SecurityInsights.SecurityInsightsDataConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SecurityInsightsDataConnectorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dataConnectorId, Azure.ResourceManager.SecurityInsights.SecurityInsightsDataConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dataConnectorId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dataConnectorId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsDataConnectorResource> Get(string dataConnectorId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityInsights.SecurityInsightsDataConnectorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityInsights.SecurityInsightsDataConnectorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsDataConnectorResource>> GetAsync(string dataConnectorId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityInsights.SecurityInsightsDataConnectorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsDataConnectorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityInsights.SecurityInsightsDataConnectorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsDataConnectorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SecurityInsightsDataConnectorData : Azure.ResourceManager.Models.ResourceData
    {
        public SecurityInsightsDataConnectorData() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
    }
    public partial class SecurityInsightsDataConnectorResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SecurityInsightsDataConnectorResource() { }
        public virtual Azure.ResourceManager.SecurityInsights.SecurityInsightsDataConnectorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string dataConnectorId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsDataConnectorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsDataConnectorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SecurityInsightsDataConnectorResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.SecurityInsightsDataConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SecurityInsightsDataConnectorResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.SecurityInsightsDataConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class SecurityInsightsExtensions
    {
        public static Azure.ResourceManager.SecurityInsights.OperationalInsightsWorkspaceSecurityInsightsResource GetOperationalInsightsWorkspaceSecurityInsightsResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleActionResource GetSecurityInsightsAlertRuleActionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleResource GetSecurityInsightsAlertRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleTemplateResource GetSecurityInsightsAlertRuleTemplateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.SecurityInsightsAutomationRuleResource GetSecurityInsightsAutomationRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.SecurityInsightsBookmarkResource GetSecurityInsightsBookmarkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.SecurityInsightsDataConnectorResource GetSecurityInsightsDataConnectorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentCommentResource GetSecurityInsightsIncidentCommentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentRelationResource GetSecurityInsightsIncidentRelationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentResource GetSecurityInsightsIncidentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.SecurityInsightsSentinelOnboardingStateResource GetSecurityInsightsSentinelOnboardingStateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.SecurityInsightsThreatIntelligenceIndicatorResource GetSecurityInsightsThreatIntelligenceIndicatorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistItemResource GetSecurityInsightsWatchlistItemResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistResource GetSecurityInsightsWatchlistResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingResource GetSecurityMLAnalyticsSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class SecurityInsightsIncidentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentResource>, System.Collections.IEnumerable
    {
        protected SecurityInsightsIncidentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string incidentId, Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string incidentId, Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string incidentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string incidentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentResource> Get(string incidentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentResource> GetAll(string filter = null, string orderBy = null, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentResource> GetAllAsync(string filter = null, string orderBy = null, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentResource>> GetAsync(string incidentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SecurityInsightsIncidentCommentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentCommentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentCommentResource>, System.Collections.IEnumerable
    {
        protected SecurityInsightsIncidentCommentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentCommentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string incidentCommentId, Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentCommentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentCommentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string incidentCommentId, Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentCommentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string incidentCommentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string incidentCommentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentCommentResource> Get(string incidentCommentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentCommentResource> GetAll(string filter = null, string orderBy = null, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentCommentResource> GetAllAsync(string filter = null, string orderBy = null, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentCommentResource>> GetAsync(string incidentCommentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentCommentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentCommentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentCommentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentCommentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SecurityInsightsIncidentCommentData : Azure.ResourceManager.Models.ResourceData
    {
        public SecurityInsightsIncidentCommentData() { }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsClientInfo Author { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public string Message { get { throw null; } set { } }
    }
    public partial class SecurityInsightsIncidentCommentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SecurityInsightsIncidentCommentResource() { }
        public virtual Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentCommentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string incidentId, string incidentCommentId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentCommentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentCommentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentCommentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentCommentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentCommentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentCommentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SecurityInsightsIncidentData : Azure.ResourceManager.Models.ResourceData
    {
        public SecurityInsightsIncidentData() { }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentAdditionalInfo AdditionalInfo { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentClassification? Classification { get { throw null; } set { } }
        public string ClassificationComment { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentClassificationReason? ClassificationReason { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public System.DateTimeOffset? FirstActivityOn { get { throw null; } set { } }
        public int? IncidentNumber { get { throw null; } }
        public System.Uri IncidentUri { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentLabel> Labels { get { throw null; } }
        public System.DateTimeOffset? LastActivityOn { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentOwnerInfo Owner { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> RelatedAnalyticRuleIds { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentSeverity? Severity { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentStatus? Status { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
    }
    public partial class SecurityInsightsIncidentRelationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentRelationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentRelationResource>, System.Collections.IEnumerable
    {
        protected SecurityInsightsIncidentRelationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentRelationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string relationName, Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentRelationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentRelationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string relationName, Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentRelationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string relationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string relationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentRelationResource> Get(string relationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentRelationResource> GetAll(string filter = null, string orderBy = null, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentRelationResource> GetAllAsync(string filter = null, string orderBy = null, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentRelationResource>> GetAsync(string relationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentRelationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentRelationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentRelationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentRelationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SecurityInsightsIncidentRelationData : Azure.ResourceManager.Models.ResourceData
    {
        public SecurityInsightsIncidentRelationData() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RelatedResourceId { get { throw null; } set { } }
        public string RelatedResourceKind { get { throw null; } }
        public string RelatedResourceName { get { throw null; } }
        public Azure.Core.ResourceType? RelatedResourceType { get { throw null; } }
    }
    public partial class SecurityInsightsIncidentRelationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SecurityInsightsIncidentRelationResource() { }
        public virtual Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentRelationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string incidentId, string relationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentRelationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentRelationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentRelationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentRelationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentRelationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentRelationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SecurityInsightsIncidentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SecurityInsightsIncidentResource() { }
        public virtual Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string incidentId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlert> GetAlerts(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlert> GetAlertsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsHuntingBookmark> GetBookmarks(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsHuntingBookmark> GetBookmarksAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentEntitiesResult> GetEntitiesResult(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentEntitiesResult>> GetEntitiesResultAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentCommentResource> GetSecurityInsightsIncidentComment(string incidentCommentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentCommentResource>> GetSecurityInsightsIncidentCommentAsync(string incidentCommentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentCommentCollection GetSecurityInsightsIncidentComments() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentRelationResource> GetSecurityInsightsIncidentRelation(string relationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentRelationResource>> GetSecurityInsightsIncidentRelationAsync(string relationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentRelationCollection GetSecurityInsightsIncidentRelations() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SecurityInsightsSentinelOnboardingStateCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsSentinelOnboardingStateResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsSentinelOnboardingStateResource>, System.Collections.IEnumerable
    {
        protected SecurityInsightsSentinelOnboardingStateCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SecurityInsightsSentinelOnboardingStateResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string sentinelOnboardingStateName, Azure.ResourceManager.SecurityInsights.SecurityInsightsSentinelOnboardingStateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SecurityInsightsSentinelOnboardingStateResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string sentinelOnboardingStateName, Azure.ResourceManager.SecurityInsights.SecurityInsightsSentinelOnboardingStateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sentinelOnboardingStateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sentinelOnboardingStateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsSentinelOnboardingStateResource> Get(string sentinelOnboardingStateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityInsights.SecurityInsightsSentinelOnboardingStateResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityInsights.SecurityInsightsSentinelOnboardingStateResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsSentinelOnboardingStateResource>> GetAsync(string sentinelOnboardingStateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityInsights.SecurityInsightsSentinelOnboardingStateResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsSentinelOnboardingStateResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityInsights.SecurityInsightsSentinelOnboardingStateResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsSentinelOnboardingStateResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SecurityInsightsSentinelOnboardingStateData : Azure.ResourceManager.Models.ResourceData
    {
        public SecurityInsightsSentinelOnboardingStateData() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public bool? IsCustomerManagedKeySet { get { throw null; } set { } }
    }
    public partial class SecurityInsightsSentinelOnboardingStateResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SecurityInsightsSentinelOnboardingStateResource() { }
        public virtual Azure.ResourceManager.SecurityInsights.SecurityInsightsSentinelOnboardingStateData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string sentinelOnboardingStateName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsSentinelOnboardingStateResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsSentinelOnboardingStateResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SecurityInsightsSentinelOnboardingStateResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.SecurityInsightsSentinelOnboardingStateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SecurityInsightsSentinelOnboardingStateResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.SecurityInsightsSentinelOnboardingStateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SecurityInsightsThreatIntelligenceIndicatorBaseData : Azure.ResourceManager.Models.ResourceData
    {
        public SecurityInsightsThreatIntelligenceIndicatorBaseData() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
    }
    public partial class SecurityInsightsThreatIntelligenceIndicatorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsThreatIntelligenceIndicatorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsThreatIntelligenceIndicatorResource>, System.Collections.IEnumerable
    {
        protected SecurityInsightsThreatIntelligenceIndicatorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SecurityInsightsThreatIntelligenceIndicatorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsThreatIntelligenceIndicatorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SecurityInsightsThreatIntelligenceIndicatorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsThreatIntelligenceIndicatorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsThreatIntelligenceIndicatorResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityInsights.SecurityInsightsThreatIntelligenceIndicatorResource> GetAll(string filter = null, int? top = default(int?), string skipToken = null, string orderBy = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityInsights.SecurityInsightsThreatIntelligenceIndicatorResource> GetAllAsync(string filter = null, int? top = default(int?), string skipToken = null, string orderBy = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsThreatIntelligenceIndicatorResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityInsights.SecurityInsightsThreatIntelligenceIndicatorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsThreatIntelligenceIndicatorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityInsights.SecurityInsightsThreatIntelligenceIndicatorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsThreatIntelligenceIndicatorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SecurityInsightsThreatIntelligenceIndicatorResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SecurityInsightsThreatIntelligenceIndicatorResource() { }
        public virtual Azure.ResourceManager.SecurityInsights.SecurityInsightsThreatIntelligenceIndicatorBaseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response AppendTags(Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceAppendTags threatIntelligenceAppendTags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AppendTagsAsync(Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceAppendTags threatIntelligenceAppendTags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsThreatIntelligenceIndicatorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsThreatIntelligenceIndicatorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SecurityInsightsThreatIntelligenceIndicatorResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsThreatIntelligenceIndicatorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SecurityInsightsThreatIntelligenceIndicatorResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsThreatIntelligenceIndicatorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SecurityInsightsWatchlistCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistResource>, System.Collections.IEnumerable
    {
        protected SecurityInsightsWatchlistCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string watchlistAlias, Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string watchlistAlias, Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string watchlistAlias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string watchlistAlias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistResource> Get(string watchlistAlias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistResource> GetAll(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistResource> GetAllAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistResource>> GetAsync(string watchlistAlias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SecurityInsightsWatchlistData : Azure.ResourceManager.Models.ResourceData
    {
        public SecurityInsightsWatchlistData() { }
        public string ContentType { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsUserInfo CreatedBy { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public System.TimeSpan? DefaultDuration { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public bool? IsDeleted { get { throw null; } set { } }
        public string ItemsSearchKey { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Labels { get { throw null; } }
        public int? NumberOfLinesToSkip { get { throw null; } set { } }
        public string Provider { get { throw null; } set { } }
        public string RawContent { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.Source? Source { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsUserInfo UpdatedBy { get { throw null; } set { } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } set { } }
        public string UploadStatus { get { throw null; } set { } }
        public string WatchlistAlias { get { throw null; } set { } }
        public System.Guid? WatchlistId { get { throw null; } set { } }
        public string WatchlistType { get { throw null; } set { } }
    }
    public partial class SecurityInsightsWatchlistItemCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistItemResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistItemResource>, System.Collections.IEnumerable
    {
        protected SecurityInsightsWatchlistItemCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistItemResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string watchlistItemId, Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistItemData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistItemResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string watchlistItemId, Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistItemData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string watchlistItemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string watchlistItemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistItemResource> Get(string watchlistItemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistItemResource> GetAll(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistItemResource> GetAllAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistItemResource>> GetAsync(string watchlistItemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistItemResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistItemResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistItemResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistItemResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SecurityInsightsWatchlistItemData : Azure.ResourceManager.Models.ResourceData
    {
        public SecurityInsightsWatchlistItemData() { }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsUserInfo CreatedBy { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public System.BinaryData EntityMapping { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public bool? IsDeleted { get { throw null; } set { } }
        public System.BinaryData ItemsKeyValue { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsUserInfo UpdatedBy { get { throw null; } set { } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } set { } }
        public string WatchlistItemId { get { throw null; } set { } }
        public string WatchlistItemType { get { throw null; } set { } }
    }
    public partial class SecurityInsightsWatchlistItemResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SecurityInsightsWatchlistItemResource() { }
        public virtual Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistItemData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string watchlistAlias, string watchlistItemId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistItemResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistItemResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistItemResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistItemData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistItemResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistItemData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SecurityInsightsWatchlistResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SecurityInsightsWatchlistResource() { }
        public virtual Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string watchlistAlias) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistItemResource> GetSecurityInsightsWatchlistItem(string watchlistItemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistItemResource>> GetSecurityInsightsWatchlistItemAsync(string watchlistItemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistItemCollection GetSecurityInsightsWatchlistItems() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SecurityMLAnalyticsSettingCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingResource>, System.Collections.IEnumerable
    {
        protected SecurityMLAnalyticsSettingCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string settingsResourceName, Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string settingsResourceName, Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string settingsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string settingsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingResource> Get(string settingsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingResource>> GetAsync(string settingsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SecurityMLAnalyticsSettingData : Azure.ResourceManager.Models.ResourceData
    {
        public SecurityMLAnalyticsSettingData() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
    }
    public partial class SecurityMLAnalyticsSettingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SecurityMLAnalyticsSettingResource() { }
        public virtual Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string settingsResourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.SecurityInsights.Mock
{
    public partial class ResourceGroupResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected ResourceGroupResourceExtensionClient() { }
    }
}
namespace Azure.ResourceManager.SecurityInsights.Models
{
    public partial class AlertRuleTemplateDataSource
    {
        public AlertRuleTemplateDataSource() { }
        public string ConnectorId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DataTypes { get { throw null; } }
    }
    public partial class AnomalySecurityMLAnalyticsSettings : Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingData
    {
        public AnomalySecurityMLAnalyticsSettings() { }
        public int? AnomalySettingsVersion { get { throw null; } set { } }
        public string AnomalyVersion { get { throw null; } set { } }
        public System.BinaryData CustomizableObservations { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.TimeSpan? Frequency { get { throw null; } set { } }
        public bool? IsDefaultSettings { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.SecurityMLAnalyticsSettingsDataSource> RequiredDataConnectors { get { throw null; } }
        public System.Guid? SettingsDefinitionId { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.AnomalySecurityMLAnalyticsSettingsStatus? SettingsStatus { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAttackTactic> Tactics { get { throw null; } }
        public System.Collections.Generic.IList<string> Techniques { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AnomalySecurityMLAnalyticsSettingsStatus : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.AnomalySecurityMLAnalyticsSettingsStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AnomalySecurityMLAnalyticsSettingsStatus(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.AnomalySecurityMLAnalyticsSettingsStatus Flighting { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AnomalySecurityMLAnalyticsSettingsStatus Production { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.AnomalySecurityMLAnalyticsSettingsStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.AnomalySecurityMLAnalyticsSettingsStatus left, Azure.ResourceManager.SecurityInsights.Models.AnomalySecurityMLAnalyticsSettingsStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.AnomalySecurityMLAnalyticsSettingsStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.AnomalySecurityMLAnalyticsSettingsStatus left, Azure.ResourceManager.SecurityInsights.Models.AnomalySecurityMLAnalyticsSettingsStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AntispamMailDirection : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.AntispamMailDirection>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AntispamMailDirection(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.AntispamMailDirection Inbound { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AntispamMailDirection Intraorg { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AntispamMailDirection Outbound { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AntispamMailDirection Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.AntispamMailDirection other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.AntispamMailDirection left, Azure.ResourceManager.SecurityInsights.Models.AntispamMailDirection right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.AntispamMailDirection (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.AntispamMailDirection left, Azure.ResourceManager.SecurityInsights.Models.AntispamMailDirection right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AutomationRuleModifyPropertiesAction : Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAutomationRuleAction
    {
        public AutomationRuleModifyPropertiesAction(int order) : base (default(int)) { }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentActionConfiguration ActionConfiguration { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutomationRulePropertyArrayChangedConditionSupportedArrayType : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyArrayChangedConditionSupportedArrayType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutomationRulePropertyArrayChangedConditionSupportedArrayType(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyArrayChangedConditionSupportedArrayType Alerts { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyArrayChangedConditionSupportedArrayType Comments { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyArrayChangedConditionSupportedArrayType Labels { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyArrayChangedConditionSupportedArrayType Tactics { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyArrayChangedConditionSupportedArrayType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyArrayChangedConditionSupportedArrayType left, Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyArrayChangedConditionSupportedArrayType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyArrayChangedConditionSupportedArrayType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyArrayChangedConditionSupportedArrayType left, Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyArrayChangedConditionSupportedArrayType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutomationRulePropertyArrayChangedConditionSupportedChangeType : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyArrayChangedConditionSupportedChangeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutomationRulePropertyArrayChangedConditionSupportedChangeType(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyArrayChangedConditionSupportedChangeType Added { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyArrayChangedConditionSupportedChangeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyArrayChangedConditionSupportedChangeType left, Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyArrayChangedConditionSupportedChangeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyArrayChangedConditionSupportedChangeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyArrayChangedConditionSupportedChangeType left, Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyArrayChangedConditionSupportedChangeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AutomationRulePropertyArrayChangedValuesCondition
    {
        public AutomationRulePropertyArrayChangedValuesCondition() { }
        public Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyArrayChangedConditionSupportedArrayType? ArrayType { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyArrayChangedConditionSupportedChangeType? ChangeType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutomationRulePropertyChangedConditionSupportedChangedType : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyChangedConditionSupportedChangedType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutomationRulePropertyChangedConditionSupportedChangedType(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyChangedConditionSupportedChangedType ChangedFrom { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyChangedConditionSupportedChangedType ChangedTo { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyChangedConditionSupportedChangedType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyChangedConditionSupportedChangedType left, Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyChangedConditionSupportedChangedType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyChangedConditionSupportedChangedType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyChangedConditionSupportedChangedType left, Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyChangedConditionSupportedChangedType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutomationRulePropertyChangedConditionSupportedPropertyType : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyChangedConditionSupportedPropertyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutomationRulePropertyChangedConditionSupportedPropertyType(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyChangedConditionSupportedPropertyType IncidentOwner { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyChangedConditionSupportedPropertyType IncidentSeverity { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyChangedConditionSupportedPropertyType IncidentStatus { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyChangedConditionSupportedPropertyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyChangedConditionSupportedPropertyType left, Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyChangedConditionSupportedPropertyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyChangedConditionSupportedPropertyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyChangedConditionSupportedPropertyType left, Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyChangedConditionSupportedPropertyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutomationRulePropertyConditionSupportedOperator : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutomationRulePropertyConditionSupportedOperator(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedOperator Contains { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedOperator EndsWith { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedOperator EqualsValue { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedOperator NotContains { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedOperator NotEndsWith { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedOperator NotEquals { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedOperator NotStartsWith { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedOperator StartsWith { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedOperator left, Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedOperator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedOperator left, Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutomationRulePropertyConditionSupportedProperty : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutomationRulePropertyConditionSupportedProperty(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty AccountAadTenantId { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty AccountAadUserId { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty AccountName { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty AccountNTDomain { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty AccountObjectGuid { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty AccountPuid { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty AccountSid { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty AccountUpnSuffix { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty AlertAnalyticRuleIds { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty AlertProductNames { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty AzureResourceResourceId { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty AzureResourceSubscriptionId { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty CloudApplicationAppId { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty CloudApplicationAppName { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty DnsDomainName { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty FileDirectory { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty FileHashValue { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty FileName { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty HostAzureId { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty HostName { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty HostNetBiosName { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty HostNTDomain { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty HostOSVersion { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty IncidentDescription { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty IncidentLabel { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty IncidentProviderName { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty IncidentRelatedAnalyticRuleIds { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty IncidentSeverity { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty IncidentStatus { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty IncidentTactics { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty IncidentTitle { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty IncidentUpdatedBySource { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty IotDeviceId { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty IotDeviceModel { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty IotDeviceName { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty IotDeviceOperatingSystem { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty IotDeviceType { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty IotDeviceVendor { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty IPAddress { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty MailboxDisplayName { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty MailboxPrimaryAddress { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty MailboxUpn { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty MailMessageDeliveryAction { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty MailMessageDeliveryLocation { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty MailMessageP1Sender { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty MailMessageP2Sender { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty MailMessageRecipient { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty MailMessageSenderIP { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty MailMessageSubject { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty MalwareCategory { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty MalwareName { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty ProcessCommandLine { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty ProcessId { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty RegistryKey { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty RegistryValueData { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty Uri { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty left, Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty left, Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AutomationRulePropertyValuesChangedCondition
    {
        public AutomationRulePropertyValuesChangedCondition() { }
        public Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyChangedConditionSupportedChangedType? ChangeType { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedOperator? Operator { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyChangedConditionSupportedPropertyType? PropertyName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PropertyValues { get { throw null; } }
    }
    public partial class AutomationRulePropertyValuesCondition
    {
        public AutomationRulePropertyValuesCondition() { }
        public Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedOperator? Operator { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty? PropertyName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PropertyValues { get { throw null; } }
    }
    public partial class AutomationRuleRunPlaybookAction : Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAutomationRuleAction
    {
        public AutomationRuleRunPlaybookAction(int order) : base (default(int)) { }
        public Azure.ResourceManager.SecurityInsights.Models.AutomationRuleRunPlaybookActionProperties ActionConfiguration { get { throw null; } set { } }
    }
    public partial class AutomationRuleRunPlaybookActionProperties
    {
        public AutomationRuleRunPlaybookActionProperties(Azure.Core.ResourceIdentifier logicAppResourceId) { }
        public Azure.Core.ResourceIdentifier LogicAppResourceId { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventGroupingAggregationKind : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.EventGroupingAggregationKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventGroupingAggregationKind(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.EventGroupingAggregationKind AlertPerResult { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.EventGroupingAggregationKind SingleAlert { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.EventGroupingAggregationKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.EventGroupingAggregationKind left, Azure.ResourceManager.SecurityInsights.Models.EventGroupingAggregationKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.EventGroupingAggregationKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.EventGroupingAggregationKind left, Azure.ResourceManager.SecurityInsights.Models.EventGroupingAggregationKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class McasDataConnector : Azure.ResourceManager.SecurityInsights.SecurityInsightsDataConnectorData
    {
        public McasDataConnector() { }
        public Azure.ResourceManager.SecurityInsights.Models.McasDataConnectorDataTypes DataTypes { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class McasDataConnectorDataTypes : Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertsDataTypeOfDataConnector
    {
        public McasDataConnectorDataTypes() { }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsDataTypeConnectionState? DiscoveryLogsState { get { throw null; } set { } }
    }
    public partial class MdatpDataConnector : Azure.ResourceManager.SecurityInsights.SecurityInsightsDataConnectorData
    {
        public MdatpDataConnector() { }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsDataTypeConnectionState? AlertsState { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class MicrosoftSecurityIncidentCreationAlertRule : Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleData
    {
        public MicrosoftSecurityIncidentCreationAlertRule() { }
        public string AlertRuleTemplateName { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DisplayNamesExcludeFilter { get { throw null; } }
        public System.Collections.Generic.IList<string> DisplayNamesFilter { get { throw null; } }
        public bool? IsEnabled { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.MicrosoftSecurityProductName? ProductFilter { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertSeverity> SeveritiesFilter { get { throw null; } }
    }
    public partial class MicrosoftSecurityIncidentCreationAlertRuleTemplate : Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleTemplateData
    {
        public MicrosoftSecurityIncidentCreationAlertRuleTemplate() { }
        public int? AlertRulesCreatedByTemplateCount { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DisplayNamesExcludeFilter { get { throw null; } }
        public System.Collections.Generic.IList<string> DisplayNamesFilter { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.MicrosoftSecurityProductName? ProductFilter { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.AlertRuleTemplateDataSource> RequiredDataConnectors { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertSeverity> SeveritiesFilter { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleTemplateStatus? Status { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MicrosoftSecurityProductName : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.MicrosoftSecurityProductName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MicrosoftSecurityProductName(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.MicrosoftSecurityProductName AzureActiveDirectoryIdentityProtection { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.MicrosoftSecurityProductName AzureAdvancedThreatProtection { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.MicrosoftSecurityProductName AzureSecurityCenter { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.MicrosoftSecurityProductName AzureSecurityCenterForIot { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.MicrosoftSecurityProductName MicrosoftCloudAppSecurity { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.MicrosoftSecurityProductName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.MicrosoftSecurityProductName left, Azure.ResourceManager.SecurityInsights.Models.MicrosoftSecurityProductName right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.MicrosoftSecurityProductName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.MicrosoftSecurityProductName left, Azure.ResourceManager.SecurityInsights.Models.MicrosoftSecurityProductName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScheduledAlertRuleTemplate : Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleTemplateData
    {
        public ScheduledAlertRuleTemplate() { }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertDetailsOverride AlertDetailsOverride { get { throw null; } set { } }
        public int? AlertRulesCreatedByTemplateCount { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedDateUTC { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> CustomDetails { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleEntityMapping> EntityMappings { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.EventGroupingAggregationKind? EventGroupingAggregationKind { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdatedDateUTC { get { throw null; } }
        public string Query { get { throw null; } set { } }
        public System.TimeSpan? QueryFrequency { get { throw null; } set { } }
        public System.TimeSpan? QueryPeriod { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.AlertRuleTemplateDataSource> RequiredDataConnectors { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertSeverity? Severity { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleTemplateStatus? Status { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAttackTactic> Tactics { get { throw null; } }
        public System.Collections.Generic.IList<string> Techniques { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleTriggerOperator? TriggerOperator { get { throw null; } set { } }
        public int? TriggerThreshold { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public partial class SecurityInsightsAadDataConnector : Azure.ResourceManager.SecurityInsights.SecurityInsightsDataConnectorData
    {
        public SecurityInsightsAadDataConnector() { }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsDataTypeConnectionState? AlertsState { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class SecurityInsightsAatpDataConnector : Azure.ResourceManager.SecurityInsights.SecurityInsightsDataConnectorData
    {
        public SecurityInsightsAatpDataConnector() { }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsDataTypeConnectionState? AlertsState { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class SecurityInsightsAccountEntity : Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntity
    {
        public SecurityInsightsAccountEntity() { }
        public string AadTenantId { get { throw null; } }
        public string AadUserId { get { throw null; } }
        public string AccountName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string DnsDomain { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public string HostEntityId { get { throw null; } }
        public bool? IsDomainJoined { get { throw null; } }
        public string NtDomain { get { throw null; } }
        public System.Guid? ObjectGuid { get { throw null; } }
        public string Puid { get { throw null; } }
        public string Sid { get { throw null; } }
        public string UpnSuffix { get { throw null; } }
    }
    public partial class SecurityInsightsAlert : Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntity
    {
        public SecurityInsightsAlert() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public string AlertDisplayName { get { throw null; } }
        public System.DateTimeOffset? AlertGeneratedOn { get { throw null; } }
        public string AlertLink { get { throw null; } }
        public string AlertType { get { throw null; } }
        public string CompromisedEntity { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertConfidenceLevel? ConfidenceLevel { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertConfidenceReason> ConfidenceReasons { get { throw null; } }
        public double? ConfidenceScore { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertConfidenceScoreStatus? ConfidenceScoreStatus { get { throw null; } }
        public string Description { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsKillChainIntent? Intent { get { throw null; } }
        public System.DateTimeOffset? ProcessingEndOn { get { throw null; } }
        public string ProductComponentName { get { throw null; } }
        public string ProductName { get { throw null; } }
        public string ProductVersion { get { throw null; } }
        public string ProviderAlertId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RemediationSteps { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.BinaryData> ResourceIdentifiers { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertSeverity? Severity { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertStatus? Status { get { throw null; } }
        public string SystemAlertId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAttackTactic> Tactics { get { throw null; } }
        public string VendorName { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityInsightsAlertConfidenceLevel : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertConfidenceLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityInsightsAlertConfidenceLevel(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertConfidenceLevel High { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertConfidenceLevel Low { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertConfidenceLevel Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertConfidenceLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertConfidenceLevel left, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertConfidenceLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertConfidenceLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertConfidenceLevel left, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertConfidenceLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SecurityInsightsAlertConfidenceReason
    {
        internal SecurityInsightsAlertConfidenceReason() { }
        public string Reason { get { throw null; } }
        public string ReasonType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityInsightsAlertConfidenceScoreStatus : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertConfidenceScoreStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityInsightsAlertConfidenceScoreStatus(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertConfidenceScoreStatus Final { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertConfidenceScoreStatus InProcess { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertConfidenceScoreStatus NotApplicable { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertConfidenceScoreStatus NotFinal { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertConfidenceScoreStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertConfidenceScoreStatus left, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertConfidenceScoreStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertConfidenceScoreStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertConfidenceScoreStatus left, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertConfidenceScoreStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityInsightsAlertDetail : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertDetail>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityInsightsAlertDetail(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertDetail DisplayName { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertDetail Severity { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertDetail other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertDetail left, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertDetail right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertDetail (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertDetail left, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertDetail right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SecurityInsightsAlertDetailsOverride
    {
        public SecurityInsightsAlertDetailsOverride() { }
        public string AlertDescriptionFormat { get { throw null; } set { } }
        public string AlertDisplayNameFormat { get { throw null; } set { } }
        public string AlertSeverityColumnName { get { throw null; } set { } }
        public string AlertTacticsColumnName { get { throw null; } set { } }
    }
    public partial class SecurityInsightsAlertRuleActionCreateOrUpdateContent : Azure.ResourceManager.Models.ResourceData
    {
        public SecurityInsightsAlertRuleActionCreateOrUpdateContent() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier LogicAppResourceId { get { throw null; } set { } }
        public System.Uri TriggerUri { get { throw null; } set { } }
    }
    public partial class SecurityInsightsAlertRuleEntityMapping
    {
        public SecurityInsightsAlertRuleEntityMapping() { }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleEntityMappingType? EntityType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFieldMapping> FieldMappings { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityInsightsAlertRuleEntityMappingType : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleEntityMappingType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityInsightsAlertRuleEntityMappingType(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleEntityMappingType Account { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleEntityMappingType AzureResource { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleEntityMappingType CloudApplication { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleEntityMappingType Dns { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleEntityMappingType File { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleEntityMappingType FileHash { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleEntityMappingType Host { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleEntityMappingType IP { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleEntityMappingType Mailbox { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleEntityMappingType MailCluster { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleEntityMappingType MailMessage { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleEntityMappingType Malware { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleEntityMappingType Process { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleEntityMappingType RegistryKey { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleEntityMappingType RegistryValue { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleEntityMappingType SecurityGroup { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleEntityMappingType SubmissionMail { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleEntityMappingType Uri { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleEntityMappingType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleEntityMappingType left, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleEntityMappingType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleEntityMappingType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleEntityMappingType left, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleEntityMappingType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityInsightsAlertRuleTemplateStatus : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleTemplateStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityInsightsAlertRuleTemplateStatus(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleTemplateStatus Available { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleTemplateStatus Installed { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleTemplateStatus NotAvailable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleTemplateStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleTemplateStatus left, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleTemplateStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleTemplateStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleTemplateStatus left, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleTemplateStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum SecurityInsightsAlertRuleTriggerOperator
    {
        GreaterThan = 0,
        LessThan = 1,
        Equal = 2,
        NotEqual = 3,
    }
    public partial class SecurityInsightsAlertsDataTypeOfDataConnector
    {
        public SecurityInsightsAlertsDataTypeOfDataConnector() { }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsDataTypeConnectionState? AlertsState { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityInsightsAlertSeverity : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertSeverity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityInsightsAlertSeverity(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertSeverity High { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertSeverity Informational { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertSeverity Low { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertSeverity Medium { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertSeverity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertSeverity left, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertSeverity right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertSeverity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertSeverity left, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertSeverity right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityInsightsAlertStatus : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityInsightsAlertStatus(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertStatus Dismissed { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertStatus New { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertStatus Resolved { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertStatus Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertStatus left, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertStatus left, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SecurityInsightsAscDataConnector : Azure.ResourceManager.SecurityInsights.SecurityInsightsDataConnectorData
    {
        public SecurityInsightsAscDataConnector() { }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsDataTypeConnectionState? AlertsState { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityInsightsAttackTactic : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAttackTactic>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityInsightsAttackTactic(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAttackTactic Collection { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAttackTactic CommandAndControl { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAttackTactic CredentialAccess { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAttackTactic DefenseEvasion { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAttackTactic Discovery { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAttackTactic Execution { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAttackTactic Exfiltration { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAttackTactic Impact { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAttackTactic ImpairProcessControl { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAttackTactic InhibitResponseFunction { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAttackTactic InitialAccess { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAttackTactic LateralMovement { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAttackTactic Persistence { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAttackTactic PreAttack { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAttackTactic PrivilegeEscalation { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAttackTactic Reconnaissance { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAttackTactic ResourceDevelopment { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAttackTactic other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAttackTactic left, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAttackTactic right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAttackTactic (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAttackTactic left, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAttackTactic right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class SecurityInsightsAutomationRuleAction
    {
        protected SecurityInsightsAutomationRuleAction(int order) { }
        public int Order { get { throw null; } set { } }
    }
    public abstract partial class SecurityInsightsAutomationRuleCondition
    {
        protected SecurityInsightsAutomationRuleCondition() { }
    }
    public partial class SecurityInsightsAutomationRuleTriggeringLogic
    {
        public SecurityInsightsAutomationRuleTriggeringLogic(bool isEnabled, Azure.ResourceManager.SecurityInsights.Models.TriggersOn triggersOn, Azure.ResourceManager.SecurityInsights.Models.TriggersWhen triggersWhen) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAutomationRuleCondition> Conditions { get { throw null; } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public bool IsEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.TriggersOn TriggersOn { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.TriggersWhen TriggersWhen { get { throw null; } set { } }
    }
    public partial class SecurityInsightsAwsCloudTrailDataConnector : Azure.ResourceManager.SecurityInsights.SecurityInsightsDataConnectorData
    {
        public SecurityInsightsAwsCloudTrailDataConnector() { }
        public string AwsRoleArn { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsDataTypeConnectionState? LogsState { get { throw null; } set { } }
    }
    public partial class SecurityInsightsAzureResourceEntity : Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntity
    {
        public SecurityInsightsAzureResourceEntity() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public string ResourceId { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
    }
    public partial class SecurityInsightsBookmarkIncidentInfo
    {
        public SecurityInsightsBookmarkIncidentInfo() { }
        public System.Guid? IncidentId { get { throw null; } set { } }
        public string RelationName { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentSeverity? Severity { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
    }
    public partial class SecurityInsightsClientInfo
    {
        internal SecurityInsightsClientInfo() { }
        public string Email { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Guid? ObjectId { get { throw null; } }
        public string UserPrincipalName { get { throw null; } }
    }
    public partial class SecurityInsightsCloudApplicationEntity : Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntity
    {
        public SecurityInsightsCloudApplicationEntity() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public int? AppId { get { throw null; } }
        public string AppName { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public string InstanceName { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityInsightsDataTypeConnectionState : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsDataTypeConnectionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityInsightsDataTypeConnectionState(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsDataTypeConnectionState Disabled { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsDataTypeConnectionState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsDataTypeConnectionState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsDataTypeConnectionState left, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsDataTypeConnectionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsDataTypeConnectionState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsDataTypeConnectionState left, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsDataTypeConnectionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SecurityInsightsDnsEntity : Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntity
    {
        public SecurityInsightsDnsEntity() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public string DnsServerIPEntityId { get { throw null; } }
        public string DomainName { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public string HostIPAddressEntityId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> IPAddressEntityIds { get { throw null; } }
    }
    public partial class SecurityInsightsEntity : Azure.ResourceManager.Models.ResourceData
    {
        public SecurityInsightsEntity() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityInsightsEntityKind : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntityKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityInsightsEntityKind(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntityKind Account { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntityKind AzureResource { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntityKind Bookmark { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntityKind CloudApplication { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntityKind DnsResolution { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntityKind File { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntityKind FileHash { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntityKind Host { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntityKind IotDevice { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntityKind IP { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntityKind Mailbox { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntityKind MailCluster { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntityKind MailMessage { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntityKind Malware { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntityKind Process { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntityKind RegistryKey { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntityKind RegistryValue { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntityKind SecurityAlert { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntityKind SecurityGroup { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntityKind SubmissionMail { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntityKind Uri { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntityKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntityKind left, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntityKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntityKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntityKind left, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntityKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SecurityInsightsFieldMapping
    {
        public SecurityInsightsFieldMapping() { }
        public string ColumnName { get { throw null; } set { } }
        public string Identifier { get { throw null; } set { } }
    }
    public partial class SecurityInsightsFileEntity : Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntity
    {
        public SecurityInsightsFileEntity() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public string Directory { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> FileHashEntityIds { get { throw null; } }
        public string FileName { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public string HostEntityId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityInsightsFileHashAlgorithm : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFileHashAlgorithm>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityInsightsFileHashAlgorithm(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFileHashAlgorithm MD5 { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFileHashAlgorithm Sha1 { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFileHashAlgorithm Sha256 { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFileHashAlgorithm Sha256AC { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFileHashAlgorithm Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFileHashAlgorithm other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFileHashAlgorithm left, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFileHashAlgorithm right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFileHashAlgorithm (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFileHashAlgorithm left, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFileHashAlgorithm right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SecurityInsightsFileHashEntity : Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntity
    {
        public SecurityInsightsFileHashEntity() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFileHashAlgorithm? Algorithm { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public string HashValue { get { throw null; } }
    }
    public partial class SecurityInsightsFusionAlertRule : Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleData
    {
        public SecurityInsightsFusionAlertRule() { }
        public string AlertRuleTemplateName { get { throw null; } set { } }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public bool? IsEnabled { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertSeverity? Severity { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAttackTactic> Tactics { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Techniques { get { throw null; } }
    }
    public partial class SecurityInsightsFusionAlertRuleTemplate : Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleTemplateData
    {
        public SecurityInsightsFusionAlertRuleTemplate() { }
        public int? AlertRulesCreatedByTemplateCount { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.AlertRuleTemplateDataSource> RequiredDataConnectors { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertSeverity? Severity { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleTemplateStatus? Status { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAttackTactic> Tactics { get { throw null; } }
        public System.Collections.Generic.IList<string> Techniques { get { throw null; } }
    }
    public partial class SecurityInsightsGroupEntity : Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntity
    {
        public SecurityInsightsGroupEntity() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public string DistinguishedName { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public System.Guid? ObjectGuid { get { throw null; } }
        public string Sid { get { throw null; } }
    }
    public partial class SecurityInsightsGroupingConfiguration
    {
        public SecurityInsightsGroupingConfiguration(bool isEnabled, bool isClosedIncidentReopened, System.TimeSpan lookbackDuration, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsGroupingMatchingMethod matchingMethod) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertDetail> GroupByAlertDetails { get { throw null; } }
        public System.Collections.Generic.IList<string> GroupByCustomDetails { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleEntityMappingType> GroupByEntities { get { throw null; } }
        public bool IsClosedIncidentReopened { get { throw null; } set { } }
        public bool IsEnabled { get { throw null; } set { } }
        public System.TimeSpan LookbackDuration { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsGroupingMatchingMethod MatchingMethod { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityInsightsGroupingMatchingMethod : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsGroupingMatchingMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityInsightsGroupingMatchingMethod(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsGroupingMatchingMethod AllEntities { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsGroupingMatchingMethod AnyAlert { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsGroupingMatchingMethod Selected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsGroupingMatchingMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsGroupingMatchingMethod left, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsGroupingMatchingMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsGroupingMatchingMethod (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsGroupingMatchingMethod left, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsGroupingMatchingMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SecurityInsightsHostEntity : Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntity
    {
        public SecurityInsightsHostEntity() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public Azure.Core.ResourceIdentifier AzureId { get { throw null; } }
        public string DnsDomain { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public string HostName { get { throw null; } }
        public bool? IsDomainJoined { get { throw null; } }
        public string NetBiosName { get { throw null; } }
        public string NtDomain { get { throw null; } }
        public string OmsAgentId { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsHostOSFamily? OSFamily { get { throw null; } set { } }
        public string OSVersion { get { throw null; } }
    }
    public enum SecurityInsightsHostOSFamily
    {
        Unknown = 0,
        Linux = 1,
        Windows = 2,
        Android = 3,
        Ios = 4,
    }
    public partial class SecurityInsightsHuntingBookmark : Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntity
    {
        public SecurityInsightsHuntingBookmark() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsUserInfo CreatedBy { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.DateTimeOffset? EventOn { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsBookmarkIncidentInfo IncidentInfo { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Labels { get { throw null; } }
        public string Notes { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        public string QueryResult { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsUserInfo UpdatedBy { get { throw null; } set { } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } set { } }
    }
    public partial class SecurityInsightsIncidentActionConfiguration
    {
        public SecurityInsightsIncidentActionConfiguration() { }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentClassification? Classification { get { throw null; } set { } }
        public string ClassificationComment { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentClassificationReason? ClassificationReason { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentLabel> Labels { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentOwnerInfo Owner { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentSeverity? Severity { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentStatus? Status { get { throw null; } set { } }
    }
    public partial class SecurityInsightsIncidentAdditionalInfo
    {
        internal SecurityInsightsIncidentAdditionalInfo() { }
        public System.Collections.Generic.IReadOnlyList<string> AlertProductNames { get { throw null; } }
        public int? AlertsCount { get { throw null; } }
        public int? BookmarksCount { get { throw null; } }
        public int? CommentsCount { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAttackTactic> Tactics { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityInsightsIncidentClassification : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentClassification>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityInsightsIncidentClassification(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentClassification BenignPositive { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentClassification FalsePositive { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentClassification TruePositive { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentClassification Undetermined { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentClassification other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentClassification left, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentClassification right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentClassification (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentClassification left, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentClassification right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityInsightsIncidentClassificationReason : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentClassificationReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityInsightsIncidentClassificationReason(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentClassificationReason InaccurateData { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentClassificationReason IncorrectAlertLogic { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentClassificationReason SuspiciousActivity { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentClassificationReason SuspiciousButExpected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentClassificationReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentClassificationReason left, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentClassificationReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentClassificationReason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentClassificationReason left, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentClassificationReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SecurityInsightsIncidentConfiguration
    {
        public SecurityInsightsIncidentConfiguration(bool isIncidentCreated) { }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsGroupingConfiguration GroupingConfiguration { get { throw null; } set { } }
        public bool IsIncidentCreated { get { throw null; } set { } }
    }
    public partial class SecurityInsightsIncidentEntitiesMetadata
    {
        internal SecurityInsightsIncidentEntitiesMetadata() { }
        public int Count { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntityKind EntityKind { get { throw null; } }
    }
    public partial class SecurityInsightsIncidentEntitiesResult
    {
        internal SecurityInsightsIncidentEntitiesResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntity> Entities { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentEntitiesMetadata> MetaData { get { throw null; } }
    }
    public partial class SecurityInsightsIncidentLabel
    {
        public SecurityInsightsIncidentLabel(string labelName) { }
        public string LabelName { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentLabelType? LabelType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityInsightsIncidentLabelType : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentLabelType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityInsightsIncidentLabelType(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentLabelType AutoAssigned { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentLabelType User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentLabelType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentLabelType left, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentLabelType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentLabelType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentLabelType left, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentLabelType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SecurityInsightsIncidentOwnerInfo
    {
        public SecurityInsightsIncidentOwnerInfo() { }
        public string AssignedTo { get { throw null; } set { } }
        public string Email { get { throw null; } set { } }
        public System.Guid? ObjectId { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentOwnerType? OwnerType { get { throw null; } set { } }
        public string UserPrincipalName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityInsightsIncidentOwnerType : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentOwnerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityInsightsIncidentOwnerType(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentOwnerType Group { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentOwnerType Unknown { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentOwnerType User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentOwnerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentOwnerType left, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentOwnerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentOwnerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentOwnerType left, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentOwnerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityInsightsIncidentSeverity : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentSeverity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityInsightsIncidentSeverity(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentSeverity High { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentSeverity Informational { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentSeverity Low { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentSeverity Medium { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentSeverity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentSeverity left, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentSeverity right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentSeverity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentSeverity left, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentSeverity right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityInsightsIncidentStatus : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityInsightsIncidentStatus(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentStatus Active { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentStatus Closed { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentStatus New { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentStatus left, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentStatus left, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SecurityInsightsIotDeviceEntity : Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntity
    {
        public SecurityInsightsIotDeviceEntity() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public string DeviceId { get { throw null; } }
        public string DeviceName { get { throw null; } }
        public string DeviceType { get { throw null; } }
        public string EdgeId { get { throw null; } }
        public string FirmwareVersion { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public string HostEntityId { get { throw null; } }
        public string IotHubEntityId { get { throw null; } }
        public System.Guid? IotSecurityAgentId { get { throw null; } }
        public string IPAddressEntityId { get { throw null; } }
        public string MacAddress { get { throw null; } }
        public string Model { get { throw null; } }
        public string OperatingSystem { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Protocols { get { throw null; } }
        public string SerialNumber { get { throw null; } }
        public string Source { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsThreatIntelligence> ThreatIntelligence { get { throw null; } }
        public string Vendor { get { throw null; } }
    }
    public partial class SecurityInsightsIPEntity : Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntity
    {
        public SecurityInsightsIPEntity() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public System.Net.IPAddress Address { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIPEntityGeoLocation Location { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsThreatIntelligence> ThreatIntelligence { get { throw null; } }
    }
    public partial class SecurityInsightsIPEntityGeoLocation
    {
        internal SecurityInsightsIPEntityGeoLocation() { }
        public int? Asn { get { throw null; } }
        public string City { get { throw null; } }
        public string CountryCode { get { throw null; } }
        public string CountryName { get { throw null; } }
        public double? Latitude { get { throw null; } }
        public double? Longitude { get { throw null; } }
        public string State { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityInsightsKillChainIntent : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsKillChainIntent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityInsightsKillChainIntent(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsKillChainIntent Collection { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsKillChainIntent CommandAndControl { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsKillChainIntent CredentialAccess { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsKillChainIntent DefenseEvasion { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsKillChainIntent Discovery { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsKillChainIntent Execution { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsKillChainIntent Exfiltration { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsKillChainIntent Exploitation { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsKillChainIntent Impact { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsKillChainIntent LateralMovement { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsKillChainIntent Persistence { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsKillChainIntent PrivilegeEscalation { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsKillChainIntent Probing { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsKillChainIntent Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsKillChainIntent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsKillChainIntent left, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsKillChainIntent right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsKillChainIntent (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsKillChainIntent left, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsKillChainIntent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SecurityInsightsMailboxEntity : Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntity
    {
        public SecurityInsightsMailboxEntity() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Guid? ExternalDirectoryObjectId { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public string MailboxPrimaryAddress { get { throw null; } }
        public string Upn { get { throw null; } }
    }
    public partial class SecurityInsightsMailClusterEntity : Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntity
    {
        public SecurityInsightsMailClusterEntity() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public string ClusterGroup { get { throw null; } }
        public System.DateTimeOffset? ClusterQueryEndOn { get { throw null; } }
        public System.DateTimeOffset? ClusterQueryStartOn { get { throw null; } }
        public string ClusterSourceIdentifier { get { throw null; } }
        public string ClusterSourceType { get { throw null; } }
        public System.BinaryData CountByDeliveryStatus { get { throw null; } }
        public System.BinaryData CountByProtectionStatus { get { throw null; } }
        public System.BinaryData CountByThreatType { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public bool? IsVolumeAnomaly { get { throw null; } }
        public int? MailCount { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> NetworkMessageIds { get { throw null; } }
        public string Query { get { throw null; } }
        public System.DateTimeOffset? QueryOn { get { throw null; } }
        public string Source { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Threats { get { throw null; } }
    }
    public enum SecurityInsightsMailMessageDeliveryAction
    {
        Unknown = 0,
        DeliveredAsSpam = 1,
        Delivered = 2,
        Blocked = 3,
        Replaced = 4,
    }
    public enum SecurityInsightsMailMessageDeliveryLocation
    {
        Unknown = 0,
        Inbox = 1,
        JunkFolder = 2,
        DeletedFolder = 3,
        Quarantine = 4,
        External = 5,
        Failed = 6,
        Dropped = 7,
        Forwarded = 8,
    }
    public partial class SecurityInsightsMailMessageEntity : Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntity
    {
        public SecurityInsightsMailMessageEntity() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.AntispamMailDirection? AntispamDirection { get { throw null; } set { } }
        public int? BodyFingerprintBin1 { get { throw null; } set { } }
        public int? BodyFingerprintBin2 { get { throw null; } set { } }
        public int? BodyFingerprintBin3 { get { throw null; } set { } }
        public int? BodyFingerprintBin4 { get { throw null; } set { } }
        public int? BodyFingerprintBin5 { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsMailMessageDeliveryAction? DeliveryAction { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsMailMessageDeliveryLocation? DeliveryLocation { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> FileEntityIds { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public string InternetMessageId { get { throw null; } }
        public string Language { get { throw null; } }
        public System.Guid? NetworkMessageId { get { throw null; } }
        public string P1Sender { get { throw null; } }
        public string P1SenderDisplayName { get { throw null; } }
        public string P1SenderDomain { get { throw null; } }
        public string P2Sender { get { throw null; } }
        public string P2SenderDisplayName { get { throw null; } }
        public string P2SenderDomain { get { throw null; } }
        public System.DateTimeOffset? ReceiveOn { get { throw null; } }
        public string Recipient { get { throw null; } }
        public System.Net.IPAddress SenderIP { get { throw null; } }
        public string Subject { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ThreatDetectionMethods { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Threats { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.Uri> Uris { get { throw null; } }
    }
    public partial class SecurityInsightsMalwareEntity : Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntity
    {
        public SecurityInsightsMalwareEntity() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public string Category { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> FileEntityIds { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public string MalwareName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ProcessEntityIds { get { throw null; } }
    }
    public partial class SecurityInsightsOfficeDataConnector : Azure.ResourceManager.SecurityInsights.SecurityInsightsDataConnectorData
    {
        public SecurityInsightsOfficeDataConnector() { }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsOfficeDataConnectorDataTypes DataTypes { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class SecurityInsightsOfficeDataConnectorDataTypes
    {
        public SecurityInsightsOfficeDataConnectorDataTypes() { }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsDataTypeConnectionState? ExchangeState { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsDataTypeConnectionState? SharePointState { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsDataTypeConnectionState? TeamsState { get { throw null; } set { } }
    }
    public enum SecurityInsightsProcessElevationToken
    {
        Default = 0,
        Full = 1,
        Limited = 2,
    }
    public partial class SecurityInsightsProcessEntity : Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntity
    {
        public SecurityInsightsProcessEntity() { }
        public string AccountEntityId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public string CommandLine { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsProcessElevationToken? ElevationToken { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } }
        public string HostEntityId { get { throw null; } }
        public string HostLogonSessionEntityId { get { throw null; } }
        public string ImageFileEntityId { get { throw null; } }
        public string ParentProcessEntityId { get { throw null; } }
        public string ProcessId { get { throw null; } }
    }
    public partial class SecurityInsightsPropertyArrayChangedConditionProperties : Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAutomationRuleCondition
    {
        public SecurityInsightsPropertyArrayChangedConditionProperties() { }
        public Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyArrayChangedValuesCondition ConditionProperties { get { throw null; } set { } }
    }
    public partial class SecurityInsightsPropertyChangedConditionProperties : Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAutomationRuleCondition
    {
        public SecurityInsightsPropertyChangedConditionProperties() { }
        public Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyValuesChangedCondition ConditionProperties { get { throw null; } set { } }
    }
    public partial class SecurityInsightsPropertyConditionProperties : Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAutomationRuleCondition
    {
        public SecurityInsightsPropertyConditionProperties() { }
        public Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyValuesCondition ConditionProperties { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityInsightsRegistryHive : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsRegistryHive>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityInsightsRegistryHive(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsRegistryHive HkeyA { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsRegistryHive HkeyClassesRoot { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsRegistryHive HkeyCurrentConfig { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsRegistryHive HkeyCurrentUser { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsRegistryHive HkeyCurrentUserLocalSettings { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsRegistryHive HkeyLocalMachine { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsRegistryHive HkeyPerformanceData { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsRegistryHive HkeyPerformanceNlstext { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsRegistryHive HkeyPerformanceText { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsRegistryHive HkeyUsers { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsRegistryHive other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsRegistryHive left, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsRegistryHive right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsRegistryHive (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsRegistryHive left, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsRegistryHive right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SecurityInsightsRegistryKeyEntity : Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntity
    {
        public SecurityInsightsRegistryKeyEntity() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsRegistryHive? Hive { get { throw null; } }
        public string Key { get { throw null; } }
    }
    public partial class SecurityInsightsRegistryValueEntity : Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntity
    {
        public SecurityInsightsRegistryValueEntity() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public string KeyEntityId { get { throw null; } }
        public string ValueData { get { throw null; } }
        public string ValueName { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsRegistryValueKind? ValueType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityInsightsRegistryValueKind : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsRegistryValueKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityInsightsRegistryValueKind(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsRegistryValueKind Binary { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsRegistryValueKind DWord { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsRegistryValueKind ExpandString { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsRegistryValueKind MultiString { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsRegistryValueKind None { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsRegistryValueKind QWord { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsRegistryValueKind String { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsRegistryValueKind Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsRegistryValueKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsRegistryValueKind left, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsRegistryValueKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsRegistryValueKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsRegistryValueKind left, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsRegistryValueKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SecurityInsightsScheduledAlertRule : Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleData
    {
        public SecurityInsightsScheduledAlertRule() { }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertDetailsOverride AlertDetailsOverride { get { throw null; } set { } }
        public string AlertRuleTemplateName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> CustomDetails { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleEntityMapping> EntityMappings { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.EventGroupingAggregationKind? EventGroupingAggregationKind { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentConfiguration IncidentConfiguration { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public bool? IsSuppressionEnabled { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public string Query { get { throw null; } set { } }
        public System.TimeSpan? QueryFrequency { get { throw null; } set { } }
        public System.TimeSpan? QueryPeriod { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertSeverity? Severity { get { throw null; } set { } }
        public System.TimeSpan? SuppressionDuration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAttackTactic> Tactics { get { throw null; } }
        public System.Collections.Generic.IList<string> Techniques { get { throw null; } }
        public string TemplateVersion { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleTriggerOperator? TriggerOperator { get { throw null; } set { } }
        public int? TriggerThreshold { get { throw null; } set { } }
    }
    public partial class SecurityInsightsSubmissionMailEntity : Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntity
    {
        public SecurityInsightsSubmissionMailEntity() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public System.DateTimeOffset? MessageReceivedOn { get { throw null; } }
        public System.Guid? NetworkMessageId { get { throw null; } }
        public string Recipient { get { throw null; } }
        public string ReportType { get { throw null; } }
        public string Sender { get { throw null; } }
        public System.Net.IPAddress SenderIP { get { throw null; } }
        public string Subject { get { throw null; } }
        public System.Guid? SubmissionId { get { throw null; } }
        public System.DateTimeOffset? SubmitOn { get { throw null; } }
        public string Submitter { get { throw null; } }
    }
    public partial class SecurityInsightsThreatIntelligence
    {
        internal SecurityInsightsThreatIntelligence() { }
        public double? Confidence { get { throw null; } }
        public string ProviderName { get { throw null; } }
        public string ReportLink { get { throw null; } }
        public string ThreatDescription { get { throw null; } }
        public string ThreatName { get { throw null; } }
        public string ThreatType { get { throw null; } }
    }
    public partial class SecurityInsightsThreatIntelligenceIndicatorData : Azure.ResourceManager.SecurityInsights.SecurityInsightsThreatIntelligenceIndicatorBaseData
    {
        public SecurityInsightsThreatIntelligenceIndicatorData() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public int? Confidence { get { throw null; } set { } }
        public string CreatedByRef { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Extensions { get { throw null; } }
        public string ExternalId { get { throw null; } set { } }
        public System.DateTimeOffset? ExternalLastUpdatedOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceExternalReference> ExternalReferences { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceGranularMarkingEntity> GranularMarkings { get { throw null; } }
        public System.Collections.Generic.IList<string> IndicatorTypes { get { throw null; } }
        public bool? IsDefanged { get { throw null; } set { } }
        public bool? IsRevoked { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceKillChainPhase> KillChainPhases { get { throw null; } }
        public System.Collections.Generic.IList<string> Labels { get { throw null; } }
        public string Language { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } set { } }
        public string Modified { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ObjectMarkingRefs { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceParsedPattern> ParsedPattern { get { throw null; } }
        public string Pattern { get { throw null; } set { } }
        public string PatternType { get { throw null; } set { } }
        public string PatternVersion { get { throw null; } set { } }
        public string Source { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ThreatIntelligenceTags { get { throw null; } }
        public System.Collections.Generic.IList<string> ThreatTypes { get { throw null; } }
        public System.DateTimeOffset? ValidFrom { get { throw null; } set { } }
        public System.DateTimeOffset? ValidUntil { get { throw null; } set { } }
    }
    public partial class SecurityInsightsTIDataConnector : Azure.ResourceManager.SecurityInsights.SecurityInsightsDataConnectorData
    {
        public SecurityInsightsTIDataConnector() { }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsDataTypeConnectionState? IndicatorsState { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        public System.DateTimeOffset? TipLookbackOn { get { throw null; } set { } }
    }
    public partial class SecurityInsightsUriEntity : Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntity
    {
        public SecurityInsightsUriEntity() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public System.Uri Uri { get { throw null; } }
    }
    public partial class SecurityInsightsUserInfo
    {
        public SecurityInsightsUserInfo() { }
        public string Email { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Guid? ObjectId { get { throw null; } set { } }
    }
    public partial class SecurityMLAnalyticsSettingsDataSource
    {
        public SecurityMLAnalyticsSettingsDataSource() { }
        public string ConnectorId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DataTypes { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Source : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.Source>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Source(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.Source LocalFile { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.Source RemoteStorage { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.Source other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.Source left, Azure.ResourceManager.SecurityInsights.Models.Source right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.Source (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.Source left, Azure.ResourceManager.SecurityInsights.Models.Source right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ThreatIntelligenceAppendTags
    {
        public ThreatIntelligenceAppendTags() { }
        public System.Collections.Generic.IList<string> ThreatIntelligenceTags { get { throw null; } }
    }
    public partial class ThreatIntelligenceExternalReference
    {
        public ThreatIntelligenceExternalReference() { }
        public string Description { get { throw null; } set { } }
        public string ExternalId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Hashes { get { throw null; } }
        public string SourceName { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class ThreatIntelligenceFilteringCriteria
    {
        public ThreatIntelligenceFilteringCriteria() { }
        public System.Collections.Generic.IList<string> Ids { get { throw null; } }
        public bool? IsIncludeDisabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Keywords { get { throw null; } }
        public int? MaxConfidence { get { throw null; } set { } }
        public System.DateTimeOffset? MaxValidUntil { get { throw null; } set { } }
        public int? MinConfidence { get { throw null; } set { } }
        public System.DateTimeOffset? MinValidUntil { get { throw null; } set { } }
        public int? PageSize { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PatternTypes { get { throw null; } }
        public string SkipToken { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceSortingCriteria> SortBy { get { throw null; } }
        public System.Collections.Generic.IList<string> Sources { get { throw null; } }
        public System.Collections.Generic.IList<string> ThreatTypes { get { throw null; } }
    }
    public partial class ThreatIntelligenceGranularMarkingEntity
    {
        public ThreatIntelligenceGranularMarkingEntity() { }
        public string Language { get { throw null; } set { } }
        public int? MarkingRef { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Selectors { get { throw null; } }
    }
    public partial class ThreatIntelligenceKillChainPhase
    {
        public ThreatIntelligenceKillChainPhase() { }
        public string KillChainName { get { throw null; } set { } }
        public string PhaseName { get { throw null; } set { } }
    }
    public partial class ThreatIntelligenceMetric
    {
        internal ThreatIntelligenceMetric() { }
        public string LastUpdatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceMetricEntity> PatternTypeMetrics { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceMetricEntity> SourceMetrics { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceMetricEntity> ThreatTypeMetrics { get { throw null; } }
    }
    public partial class ThreatIntelligenceMetricEntity
    {
        internal ThreatIntelligenceMetricEntity() { }
        public string MetricName { get { throw null; } }
        public int? MetricValue { get { throw null; } }
    }
    public partial class ThreatIntelligenceMetrics
    {
        internal ThreatIntelligenceMetrics() { }
        public Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceMetric Properties { get { throw null; } }
    }
    public partial class ThreatIntelligenceParsedPattern
    {
        public ThreatIntelligenceParsedPattern() { }
        public string PatternTypeKey { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceParsedPatternTypeValue> PatternTypeValues { get { throw null; } }
    }
    public partial class ThreatIntelligenceParsedPatternTypeValue
    {
        public ThreatIntelligenceParsedPatternTypeValue() { }
        public string Value { get { throw null; } set { } }
        public string ValueType { get { throw null; } set { } }
    }
    public partial class ThreatIntelligenceSortingCriteria
    {
        public ThreatIntelligenceSortingCriteria() { }
        public string ItemKey { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceSortingOrder? SortOrder { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ThreatIntelligenceSortingOrder : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceSortingOrder>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ThreatIntelligenceSortingOrder(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceSortingOrder Ascending { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceSortingOrder Descending { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceSortingOrder Unsorted { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceSortingOrder other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceSortingOrder left, Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceSortingOrder right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceSortingOrder (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceSortingOrder left, Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceSortingOrder right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TriggersOn : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.TriggersOn>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TriggersOn(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.TriggersOn Alerts { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.TriggersOn Incidents { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.TriggersOn other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.TriggersOn left, Azure.ResourceManager.SecurityInsights.Models.TriggersOn right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.TriggersOn (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.TriggersOn left, Azure.ResourceManager.SecurityInsights.Models.TriggersOn right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TriggersWhen : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.TriggersWhen>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TriggersWhen(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.TriggersWhen Created { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.TriggersWhen Updated { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.TriggersWhen other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.TriggersWhen left, Azure.ResourceManager.SecurityInsights.Models.TriggersWhen right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.TriggersWhen (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.TriggersWhen left, Azure.ResourceManager.SecurityInsights.Models.TriggersWhen right) { throw null; }
        public override string ToString() { throw null; }
    }
}
