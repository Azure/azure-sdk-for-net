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
        public virtual Azure.NullableResponse<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleActionResource> GetIfExists(string actionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleActionResource>> GetIfExistsAsync(string actionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleActionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleActionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleActionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleActionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SecurityInsightsAlertRuleActionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleActionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleActionData>
    {
        public SecurityInsightsAlertRuleActionData() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier LogicAppResourceId { get { throw null; } set { } }
        public string WorkflowId { get { throw null; } set { } }
        Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleActionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleActionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleActionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleActionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleActionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleActionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleActionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleResource> GetIfExists(string ruleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleResource>> GetIfExistsAsync(string ruleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SecurityInsightsAlertRuleData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleData>
    {
        public SecurityInsightsAlertRuleData() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleTemplateResource> GetIfExists(string alertRuleTemplateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleTemplateResource>> GetIfExistsAsync(string alertRuleTemplateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleTemplateResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleTemplateResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleTemplateResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleTemplateResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SecurityInsightsAlertRuleTemplateData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleTemplateData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleTemplateData>
    {
        public SecurityInsightsAlertRuleTemplateData() { }
        Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleTemplateData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleTemplateData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleTemplateData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleTemplateData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleTemplateData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleTemplateData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleTemplateData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.SecurityInsights.SecurityInsightsAutomationRuleResource> GetIfExists(string automationRuleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SecurityInsights.SecurityInsightsAutomationRuleResource>> GetIfExistsAsync(string automationRuleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityInsights.SecurityInsightsAutomationRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsAutomationRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityInsights.SecurityInsightsAutomationRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsAutomationRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SecurityInsightsAutomationRuleData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsAutomationRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsAutomationRuleData>
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
        Azure.ResourceManager.SecurityInsights.SecurityInsightsAutomationRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsAutomationRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsAutomationRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.SecurityInsightsAutomationRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsAutomationRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsAutomationRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsAutomationRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.SecurityInsights.SecurityInsightsBookmarkResource> GetIfExists(string bookmarkId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SecurityInsights.SecurityInsightsBookmarkResource>> GetIfExistsAsync(string bookmarkId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityInsights.SecurityInsightsBookmarkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsBookmarkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityInsights.SecurityInsightsBookmarkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsBookmarkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SecurityInsightsBookmarkData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsBookmarkData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsBookmarkData>
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
        Azure.ResourceManager.SecurityInsights.SecurityInsightsBookmarkData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsBookmarkData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsBookmarkData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.SecurityInsightsBookmarkData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsBookmarkData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsBookmarkData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsBookmarkData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.SecurityInsights.SecurityInsightsDataConnectorResource> GetIfExists(string dataConnectorId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SecurityInsights.SecurityInsightsDataConnectorResource>> GetIfExistsAsync(string dataConnectorId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityInsights.SecurityInsightsDataConnectorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsDataConnectorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityInsights.SecurityInsightsDataConnectorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsDataConnectorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SecurityInsightsDataConnectorData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsDataConnectorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsDataConnectorData>
    {
        public SecurityInsightsDataConnectorData() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        Azure.ResourceManager.SecurityInsights.SecurityInsightsDataConnectorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsDataConnectorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsDataConnectorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.SecurityInsightsDataConnectorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsDataConnectorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsDataConnectorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsDataConnectorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentResource> GetIfExists(string incidentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentResource>> GetIfExistsAsync(string incidentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentCommentResource> GetIfExists(string incidentCommentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentCommentResource>> GetIfExistsAsync(string incidentCommentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentCommentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentCommentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentCommentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentCommentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SecurityInsightsIncidentCommentData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentCommentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentCommentData>
    {
        public SecurityInsightsIncidentCommentData() { }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsClientInfo Author { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public string Message { get { throw null; } set { } }
        Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentCommentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentCommentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentCommentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentCommentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentCommentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentCommentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentCommentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class SecurityInsightsIncidentData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentData>
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
        Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentRelationResource> GetIfExists(string relationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentRelationResource>> GetIfExistsAsync(string relationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentRelationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentRelationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentRelationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentRelationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SecurityInsightsIncidentRelationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentRelationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentRelationData>
    {
        public SecurityInsightsIncidentRelationData() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RelatedResourceId { get { throw null; } set { } }
        public string RelatedResourceKind { get { throw null; } }
        public string RelatedResourceName { get { throw null; } }
        public Azure.Core.ResourceType? RelatedResourceType { get { throw null; } }
        Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentRelationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentRelationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentRelationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentRelationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentRelationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentRelationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentRelationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.SecurityInsights.SecurityInsightsSentinelOnboardingStateResource> GetIfExists(string sentinelOnboardingStateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SecurityInsights.SecurityInsightsSentinelOnboardingStateResource>> GetIfExistsAsync(string sentinelOnboardingStateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityInsights.SecurityInsightsSentinelOnboardingStateResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsSentinelOnboardingStateResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityInsights.SecurityInsightsSentinelOnboardingStateResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsSentinelOnboardingStateResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SecurityInsightsSentinelOnboardingStateData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsSentinelOnboardingStateData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsSentinelOnboardingStateData>
    {
        public SecurityInsightsSentinelOnboardingStateData() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public bool? IsCustomerManagedKeySet { get { throw null; } set { } }
        Azure.ResourceManager.SecurityInsights.SecurityInsightsSentinelOnboardingStateData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsSentinelOnboardingStateData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsSentinelOnboardingStateData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.SecurityInsightsSentinelOnboardingStateData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsSentinelOnboardingStateData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsSentinelOnboardingStateData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsSentinelOnboardingStateData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class SecurityInsightsThreatIntelligenceIndicatorBaseData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsThreatIntelligenceIndicatorBaseData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsThreatIntelligenceIndicatorBaseData>
    {
        public SecurityInsightsThreatIntelligenceIndicatorBaseData() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        Azure.ResourceManager.SecurityInsights.SecurityInsightsThreatIntelligenceIndicatorBaseData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsThreatIntelligenceIndicatorBaseData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsThreatIntelligenceIndicatorBaseData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.SecurityInsightsThreatIntelligenceIndicatorBaseData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsThreatIntelligenceIndicatorBaseData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsThreatIntelligenceIndicatorBaseData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsThreatIntelligenceIndicatorBaseData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.SecurityInsights.SecurityInsightsThreatIntelligenceIndicatorResource> GetIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SecurityInsights.SecurityInsightsThreatIntelligenceIndicatorResource>> GetIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistResource> GetIfExists(string watchlistAlias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistResource>> GetIfExistsAsync(string watchlistAlias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SecurityInsightsWatchlistData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistData>
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
        Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistItemResource> GetIfExists(string watchlistItemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistItemResource>> GetIfExistsAsync(string watchlistItemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistItemResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistItemResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistItemResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistItemResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SecurityInsightsWatchlistItemData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistItemData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistItemData>
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
        Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistItemData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistItemData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistItemData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistItemData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistItemData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistItemData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistItemData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingResource> GetIfExists(string settingsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingResource>> GetIfExistsAsync(string settingsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SecurityMLAnalyticsSettingData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingData>
    {
        public SecurityMLAnalyticsSettingData() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
namespace Azure.ResourceManager.SecurityInsights.Mocking
{
    public partial class MockableSecurityInsightsArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableSecurityInsightsArmClient() { }
        public virtual Azure.ResourceManager.SecurityInsights.OperationalInsightsWorkspaceSecurityInsightsResource GetOperationalInsightsWorkspaceSecurityInsightsResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleActionResource GetSecurityInsightsAlertRuleActionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleResource GetSecurityInsightsAlertRuleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleTemplateResource GetSecurityInsightsAlertRuleTemplateResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.SecurityInsights.SecurityInsightsAutomationRuleResource GetSecurityInsightsAutomationRuleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.SecurityInsights.SecurityInsightsBookmarkResource GetSecurityInsightsBookmarkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.SecurityInsights.SecurityInsightsDataConnectorResource GetSecurityInsightsDataConnectorResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentCommentResource GetSecurityInsightsIncidentCommentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentRelationResource GetSecurityInsightsIncidentRelationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentResource GetSecurityInsightsIncidentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.SecurityInsights.SecurityInsightsSentinelOnboardingStateResource GetSecurityInsightsSentinelOnboardingStateResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.SecurityInsights.SecurityInsightsThreatIntelligenceIndicatorResource GetSecurityInsightsThreatIntelligenceIndicatorResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistItemResource GetSecurityInsightsWatchlistItemResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistResource GetSecurityInsightsWatchlistResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingResource GetSecurityMLAnalyticsSettingResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableSecurityInsightsResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableSecurityInsightsResourceGroupResource() { }
    }
}
namespace Azure.ResourceManager.SecurityInsights.Models
{
    public partial class AlertRuleTemplateDataSource : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.AlertRuleTemplateDataSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.AlertRuleTemplateDataSource>
    {
        public AlertRuleTemplateDataSource() { }
        public string ConnectorId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DataTypes { get { throw null; } }
        Azure.ResourceManager.SecurityInsights.Models.AlertRuleTemplateDataSource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.AlertRuleTemplateDataSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.AlertRuleTemplateDataSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.AlertRuleTemplateDataSource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.AlertRuleTemplateDataSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.AlertRuleTemplateDataSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.AlertRuleTemplateDataSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AnomalySecurityMLAnalyticsSettings : Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.AnomalySecurityMLAnalyticsSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.AnomalySecurityMLAnalyticsSettings>
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
        Azure.ResourceManager.SecurityInsights.Models.AnomalySecurityMLAnalyticsSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.AnomalySecurityMLAnalyticsSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.AnomalySecurityMLAnalyticsSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.AnomalySecurityMLAnalyticsSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.AnomalySecurityMLAnalyticsSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.AnomalySecurityMLAnalyticsSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.AnomalySecurityMLAnalyticsSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public static partial class ArmSecurityInsightsModelFactory
    {
        public static Azure.ResourceManager.SecurityInsights.Models.AnomalySecurityMLAnalyticsSettings AnomalySecurityMLAnalyticsSettings(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? etag = default(Azure.ETag?), string description = null, string displayName = null, bool? isEnabled = default(bool?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.Models.SecurityMLAnalyticsSettingsDataSource> requiredDataConnectors = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAttackTactic> tactics = null, System.Collections.Generic.IEnumerable<string> techniques = null, string anomalyVersion = null, System.BinaryData customizableObservations = null, System.TimeSpan? frequency = default(System.TimeSpan?), Azure.ResourceManager.SecurityInsights.Models.AnomalySecurityMLAnalyticsSettingsStatus? settingsStatus = default(Azure.ResourceManager.SecurityInsights.Models.AnomalySecurityMLAnalyticsSettingsStatus?), bool? isDefaultSettings = default(bool?), int? anomalySettingsVersion = default(int?), System.Guid? settingsDefinitionId = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.McasDataConnector McasDataConnector(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? etag = default(Azure.ETag?), System.Guid? tenantId = default(System.Guid?), Azure.ResourceManager.SecurityInsights.Models.McasDataConnectorDataTypes dataTypes = null) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.MdatpDataConnector MdatpDataConnector(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? etag = default(Azure.ETag?), System.Guid? tenantId = default(System.Guid?), Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsDataTypeConnectionState? alertsState = default(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsDataTypeConnectionState?)) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.MicrosoftSecurityIncidentCreationAlertRule MicrosoftSecurityIncidentCreationAlertRule(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? etag = default(Azure.ETag?), System.Collections.Generic.IEnumerable<string> displayNamesFilter = null, System.Collections.Generic.IEnumerable<string> displayNamesExcludeFilter = null, Azure.ResourceManager.SecurityInsights.Models.MicrosoftSecurityProductName? productFilter = default(Azure.ResourceManager.SecurityInsights.Models.MicrosoftSecurityProductName?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertSeverity> severitiesFilter = null, string alertRuleTemplateName = null, string description = null, string displayName = null, bool? isEnabled = default(bool?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.MicrosoftSecurityIncidentCreationAlertRuleTemplate MicrosoftSecurityIncidentCreationAlertRuleTemplate(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, int? alertRulesCreatedByTemplateCount = default(int?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?), string description = null, string displayName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.Models.AlertRuleTemplateDataSource> requiredDataConnectors = null, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleTemplateStatus? status = default(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleTemplateStatus?), System.Collections.Generic.IEnumerable<string> displayNamesFilter = null, System.Collections.Generic.IEnumerable<string> displayNamesExcludeFilter = null, Azure.ResourceManager.SecurityInsights.Models.MicrosoftSecurityProductName? productFilter = default(Azure.ResourceManager.SecurityInsights.Models.MicrosoftSecurityProductName?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertSeverity> severitiesFilter = null) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.ScheduledAlertRuleTemplate ScheduledAlertRuleTemplate(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, int? alertRulesCreatedByTemplateCount = default(int?), System.DateTimeOffset? createdDateUTC = default(System.DateTimeOffset?), System.DateTimeOffset? lastUpdatedDateUTC = default(System.DateTimeOffset?), string description = null, string displayName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.Models.AlertRuleTemplateDataSource> requiredDataConnectors = null, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleTemplateStatus? status = default(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleTemplateStatus?), string query = null, System.TimeSpan? queryFrequency = default(System.TimeSpan?), System.TimeSpan? queryPeriod = default(System.TimeSpan?), Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertSeverity? severity = default(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertSeverity?), Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleTriggerOperator? triggerOperator = default(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleTriggerOperator?), int? triggerThreshold = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAttackTactic> tactics = null, System.Collections.Generic.IEnumerable<string> techniques = null, string version = null, Azure.ResourceManager.SecurityInsights.Models.EventGroupingAggregationKind? eventGroupingAggregationKind = default(Azure.ResourceManager.SecurityInsights.Models.EventGroupingAggregationKind?), System.Collections.Generic.IDictionary<string, string> customDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleEntityMapping> entityMappings = null, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertDetailsOverride alertDetailsOverride = null) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAadDataConnector SecurityInsightsAadDataConnector(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? etag = default(Azure.ETag?), System.Guid? tenantId = default(System.Guid?), Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsDataTypeConnectionState? alertsState = default(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsDataTypeConnectionState?)) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAatpDataConnector SecurityInsightsAatpDataConnector(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? etag = default(Azure.ETag?), System.Guid? tenantId = default(System.Guid?), Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsDataTypeConnectionState? alertsState = default(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsDataTypeConnectionState?)) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAccountEntity SecurityInsightsAccountEntity(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> additionalData = null, string friendlyName = null, string aadTenantId = null, string aadUserId = null, string accountName = null, string displayName = null, string hostEntityId = null, bool? isDomainJoined = default(bool?), string ntDomain = null, System.Guid? objectGuid = default(System.Guid?), string puid = null, string sid = null, string upnSuffix = null, string dnsDomain = null) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlert SecurityInsightsAlert(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> additionalData = null, string friendlyName = null, string alertDisplayName = null, string alertType = null, string compromisedEntity = null, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertConfidenceLevel? confidenceLevel = default(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertConfidenceLevel?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertConfidenceReason> confidenceReasons = null, double? confidenceScore = default(double?), Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertConfidenceScoreStatus? confidenceScoreStatus = default(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertConfidenceScoreStatus?), string description = null, System.DateTimeOffset? endOn = default(System.DateTimeOffset?), Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsKillChainIntent? intent = default(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsKillChainIntent?), string providerAlertId = null, System.DateTimeOffset? processingEndOn = default(System.DateTimeOffset?), string productComponentName = null, string productName = null, string productVersion = null, System.Collections.Generic.IEnumerable<string> remediationSteps = null, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertSeverity? severity = default(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertSeverity?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertStatus? status = default(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertStatus?), string systemAlertId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAttackTactic> tactics = null, System.DateTimeOffset? alertGeneratedOn = default(System.DateTimeOffset?), string vendorName = null, string alertLink = null, System.Collections.Generic.IEnumerable<System.BinaryData> resourceIdentifiers = null) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertConfidenceReason SecurityInsightsAlertConfidenceReason(string reason = null, string reasonType = null) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleActionCreateOrUpdateContent SecurityInsightsAlertRuleActionCreateOrUpdateContent(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier logicAppResourceId = null, System.Uri triggerUri = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleActionData SecurityInsightsAlertRuleActionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? etag = default(Azure.ETag?), Azure.Core.ResourceIdentifier logicAppResourceId = null, string workflowId = null) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleData SecurityInsightsAlertRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string kind = "Unknown", Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleTemplateData SecurityInsightsAlertRuleTemplateData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string kind = "Unknown") { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAscDataConnector SecurityInsightsAscDataConnector(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsDataTypeConnectionState? alertsState = default(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsDataTypeConnectionState?), string subscriptionId = null) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.SecurityInsightsAutomationRuleData SecurityInsightsAutomationRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string displayName = null, int order = 0, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAutomationRuleTriggeringLogic triggeringLogic = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAutomationRuleAction> actions = null, System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsClientInfo lastModifiedBy = null, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsClientInfo createdBy = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAwsCloudTrailDataConnector SecurityInsightsAwsCloudTrailDataConnector(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? etag = default(Azure.ETag?), string awsRoleArn = null, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsDataTypeConnectionState? logsState = default(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsDataTypeConnectionState?)) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAzureResourceEntity SecurityInsightsAzureResourceEntity(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> additionalData = null, string friendlyName = null, string resourceId = null, string subscriptionId = null) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.SecurityInsightsBookmarkData SecurityInsightsBookmarkData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsUserInfo createdBy = null, string displayName = null, System.Collections.Generic.IEnumerable<string> labels = null, string notes = null, string query = null, string queryResult = null, System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsUserInfo updatedBy = null, System.DateTimeOffset? eventOn = default(System.DateTimeOffset?), System.DateTimeOffset? queryStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? queryEndOn = default(System.DateTimeOffset?), Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsBookmarkIncidentInfo incidentInfo = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsClientInfo SecurityInsightsClientInfo(string email = null, string name = null, System.Guid? objectId = default(System.Guid?), string userPrincipalName = null) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsCloudApplicationEntity SecurityInsightsCloudApplicationEntity(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> additionalData = null, string friendlyName = null, int? appId = default(int?), string appName = null, string instanceName = null) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.SecurityInsightsDataConnectorData SecurityInsightsDataConnectorData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string kind = "Unknown", Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsDnsEntity SecurityInsightsDnsEntity(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> additionalData = null, string friendlyName = null, string dnsServerIPEntityId = null, string domainName = null, string hostIPAddressEntityId = null, System.Collections.Generic.IEnumerable<string> ipAddressEntityIds = null) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntity SecurityInsightsEntity(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string kind = "Unknown") { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFileEntity SecurityInsightsFileEntity(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> additionalData = null, string friendlyName = null, string directory = null, System.Collections.Generic.IEnumerable<string> fileHashEntityIds = null, string fileName = null, string hostEntityId = null) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFileHashEntity SecurityInsightsFileHashEntity(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> additionalData = null, string friendlyName = null, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFileHashAlgorithm? algorithm = default(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFileHashAlgorithm?), string hashValue = null) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFusionAlertRule SecurityInsightsFusionAlertRule(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? etag = default(Azure.ETag?), string alertRuleTemplateName = null, string description = null, string displayName = null, bool? isEnabled = default(bool?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertSeverity? severity = default(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertSeverity?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAttackTactic> tactics = null, System.Collections.Generic.IEnumerable<string> techniques = null) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFusionAlertRuleTemplate SecurityInsightsFusionAlertRuleTemplate(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, int? alertRulesCreatedByTemplateCount = default(int?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?), string description = null, string displayName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.Models.AlertRuleTemplateDataSource> requiredDataConnectors = null, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleTemplateStatus? status = default(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleTemplateStatus?), Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertSeverity? severity = default(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertSeverity?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAttackTactic> tactics = null, System.Collections.Generic.IEnumerable<string> techniques = null) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsGroupEntity SecurityInsightsGroupEntity(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> additionalData = null, string friendlyName = null, string distinguishedName = null, System.Guid? objectGuid = default(System.Guid?), string sid = null) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsHostEntity SecurityInsightsHostEntity(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> additionalData = null, string friendlyName = null, Azure.Core.ResourceIdentifier azureId = null, string dnsDomain = null, string hostName = null, bool? isDomainJoined = default(bool?), string netBiosName = null, string ntDomain = null, string omsAgentId = null, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsHostOSFamily? osFamily = default(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsHostOSFamily?), string osVersion = null) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsHuntingBookmark SecurityInsightsHuntingBookmark(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> additionalData = null, string friendlyName = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsUserInfo createdBy = null, string displayName = null, System.DateTimeOffset? eventOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<string> labels = null, string notes = null, string query = null, string queryResult = null, System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsUserInfo updatedBy = null, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsBookmarkIncidentInfo incidentInfo = null) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentAdditionalInfo SecurityInsightsIncidentAdditionalInfo(int? alertsCount = default(int?), int? bookmarksCount = default(int?), int? commentsCount = default(int?), System.Collections.Generic.IEnumerable<string> alertProductNames = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAttackTactic> tactics = null) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentCommentData SecurityInsightsIncidentCommentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), string message = null, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsClientInfo author = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentData SecurityInsightsIncidentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentAdditionalInfo additionalInfo = null, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentClassification? classification = default(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentClassification?), string classificationComment = null, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentClassificationReason? classificationReason = default(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentClassificationReason?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), string description = null, System.DateTimeOffset? firstActivityOn = default(System.DateTimeOffset?), System.Uri incidentUri = null, int? incidentNumber = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentLabel> labels = null, System.DateTimeOffset? lastActivityOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentOwnerInfo owner = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> relatedAnalyticRuleIds = null, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentSeverity? severity = default(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentSeverity?), Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentStatus? status = default(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentStatus?), string title = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentEntitiesMetadata SecurityInsightsIncidentEntitiesMetadata(int count = 0, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntityKind entityKind = default(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntityKind)) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentEntitiesResult SecurityInsightsIncidentEntitiesResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntity> entities = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentEntitiesMetadata> metaData = null) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentLabel SecurityInsightsIncidentLabel(string labelName = null, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentLabelType? labelType = default(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentLabelType?)) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.SecurityInsightsIncidentRelationData SecurityInsightsIncidentRelationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier relatedResourceId = null, string relatedResourceName = null, Azure.Core.ResourceType? relatedResourceType = default(Azure.Core.ResourceType?), string relatedResourceKind = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIotDeviceEntity SecurityInsightsIotDeviceEntity(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> additionalData = null, string friendlyName = null, string deviceId = null, string deviceName = null, string source = null, System.Guid? iotSecurityAgentId = default(System.Guid?), string deviceType = null, string vendor = null, string edgeId = null, string macAddress = null, string model = null, string serialNumber = null, string firmwareVersion = null, string operatingSystem = null, string iotHubEntityId = null, string hostEntityId = null, string ipAddressEntityId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsThreatIntelligence> threatIntelligence = null, System.Collections.Generic.IEnumerable<string> protocols = null) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIPEntity SecurityInsightsIPEntity(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> additionalData = null, string friendlyName = null, System.Net.IPAddress address = null, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIPEntityGeoLocation location = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsThreatIntelligence> threatIntelligence = null) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIPEntityGeoLocation SecurityInsightsIPEntityGeoLocation(int? asn = default(int?), string city = null, string countryCode = null, string countryName = null, double? latitude = default(double?), double? longitude = default(double?), string state = null) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsMailboxEntity SecurityInsightsMailboxEntity(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> additionalData = null, string friendlyName = null, string mailboxPrimaryAddress = null, string displayName = null, string upn = null, System.Guid? externalDirectoryObjectId = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsMailClusterEntity SecurityInsightsMailClusterEntity(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> additionalData = null, string friendlyName = null, System.Collections.Generic.IEnumerable<string> networkMessageIds = null, System.BinaryData countByDeliveryStatus = null, System.BinaryData countByThreatType = null, System.BinaryData countByProtectionStatus = null, System.Collections.Generic.IEnumerable<string> threats = null, string query = null, System.DateTimeOffset? queryOn = default(System.DateTimeOffset?), int? mailCount = default(int?), bool? isVolumeAnomaly = default(bool?), string source = null, string clusterSourceIdentifier = null, string clusterSourceType = null, System.DateTimeOffset? clusterQueryStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? clusterQueryEndOn = default(System.DateTimeOffset?), string clusterGroup = null) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsMailMessageEntity SecurityInsightsMailMessageEntity(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> additionalData = null, string friendlyName = null, System.Collections.Generic.IEnumerable<string> fileEntityIds = null, string recipient = null, System.Collections.Generic.IEnumerable<System.Uri> uris = null, System.Collections.Generic.IEnumerable<string> threats = null, string p1Sender = null, string p1SenderDisplayName = null, string p1SenderDomain = null, System.Net.IPAddress senderIP = null, string p2Sender = null, string p2SenderDisplayName = null, string p2SenderDomain = null, System.DateTimeOffset? receiveOn = default(System.DateTimeOffset?), System.Guid? networkMessageId = default(System.Guid?), string internetMessageId = null, string subject = null, string language = null, System.Collections.Generic.IEnumerable<string> threatDetectionMethods = null, int? bodyFingerprintBin1 = default(int?), int? bodyFingerprintBin2 = default(int?), int? bodyFingerprintBin3 = default(int?), int? bodyFingerprintBin4 = default(int?), int? bodyFingerprintBin5 = default(int?), Azure.ResourceManager.SecurityInsights.Models.AntispamMailDirection? antispamDirection = default(Azure.ResourceManager.SecurityInsights.Models.AntispamMailDirection?), Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsMailMessageDeliveryAction? deliveryAction = default(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsMailMessageDeliveryAction?), Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsMailMessageDeliveryLocation? deliveryLocation = default(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsMailMessageDeliveryLocation?)) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsMalwareEntity SecurityInsightsMalwareEntity(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> additionalData = null, string friendlyName = null, string category = null, System.Collections.Generic.IEnumerable<string> fileEntityIds = null, string malwareName = null, System.Collections.Generic.IEnumerable<string> processEntityIds = null) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsOfficeDataConnector SecurityInsightsOfficeDataConnector(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? etag = default(Azure.ETag?), System.Guid? tenantId = default(System.Guid?), Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsOfficeDataConnectorDataTypes dataTypes = null) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsProcessEntity SecurityInsightsProcessEntity(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> additionalData = null, string friendlyName = null, string accountEntityId = null, string commandLine = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsProcessElevationToken? elevationToken = default(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsProcessElevationToken?), string hostEntityId = null, string hostLogonSessionEntityId = null, string imageFileEntityId = null, string parentProcessEntityId = null, string processId = null) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsRegistryKeyEntity SecurityInsightsRegistryKeyEntity(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> additionalData = null, string friendlyName = null, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsRegistryHive? hive = default(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsRegistryHive?), string key = null) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsRegistryValueEntity SecurityInsightsRegistryValueEntity(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> additionalData = null, string friendlyName = null, string keyEntityId = null, string valueData = null, string valueName = null, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsRegistryValueKind? valueType = default(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsRegistryValueKind?)) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsScheduledAlertRule SecurityInsightsScheduledAlertRule(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? etag = default(Azure.ETag?), string query = null, System.TimeSpan? queryFrequency = default(System.TimeSpan?), System.TimeSpan? queryPeriod = default(System.TimeSpan?), Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertSeverity? severity = default(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertSeverity?), Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleTriggerOperator? triggerOperator = default(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleTriggerOperator?), int? triggerThreshold = default(int?), Azure.ResourceManager.SecurityInsights.Models.EventGroupingAggregationKind? eventGroupingAggregationKind = default(Azure.ResourceManager.SecurityInsights.Models.EventGroupingAggregationKind?), System.Collections.Generic.IDictionary<string, string> customDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleEntityMapping> entityMappings = null, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertDetailsOverride alertDetailsOverride = null, string alertRuleTemplateName = null, string templateVersion = null, string description = null, string displayName = null, bool? isEnabled = default(bool?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), System.TimeSpan? suppressionDuration = default(System.TimeSpan?), bool? isSuppressionEnabled = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAttackTactic> tactics = null, System.Collections.Generic.IEnumerable<string> techniques = null, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentConfiguration incidentConfiguration = null) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.SecurityInsightsSentinelOnboardingStateData SecurityInsightsSentinelOnboardingStateData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, bool? isCustomerManagedKeySet = default(bool?), Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsSubmissionMailEntity SecurityInsightsSubmissionMailEntity(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> additionalData = null, string friendlyName = null, System.Guid? networkMessageId = default(System.Guid?), System.Guid? submissionId = default(System.Guid?), string submitter = null, System.DateTimeOffset? submitOn = default(System.DateTimeOffset?), System.DateTimeOffset? messageReceivedOn = default(System.DateTimeOffset?), string recipient = null, string sender = null, System.Net.IPAddress senderIP = null, string subject = null, string reportType = null) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsThreatIntelligence SecurityInsightsThreatIntelligence(double? confidence = default(double?), string providerName = null, string reportLink = null, string threatDescription = null, string threatName = null, string threatType = null) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.SecurityInsightsThreatIntelligenceIndicatorBaseData SecurityInsightsThreatIntelligenceIndicatorBaseData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string kind = "Unknown", Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsThreatIntelligenceIndicatorData SecurityInsightsThreatIntelligenceIndicatorData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? etag = default(Azure.ETag?), System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> additionalData = null, string friendlyName = null, System.Collections.Generic.IEnumerable<string> threatIntelligenceTags = null, System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?), string source = null, string displayName = null, string description = null, System.Collections.Generic.IEnumerable<string> indicatorTypes = null, string pattern = null, string patternType = null, string patternVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceKillChainPhase> killChainPhases = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceParsedPattern> parsedPattern = null, string externalId = null, string createdByRef = null, bool? isDefanged = default(bool?), System.DateTimeOffset? externalLastUpdatedOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceExternalReference> externalReferences = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceGranularMarkingEntity> granularMarkings = null, System.Collections.Generic.IEnumerable<string> labels = null, bool? isRevoked = default(bool?), int? confidence = default(int?), System.Collections.Generic.IEnumerable<string> objectMarkingRefs = null, string language = null, System.Collections.Generic.IEnumerable<string> threatTypes = null, System.DateTimeOffset? validFrom = default(System.DateTimeOffset?), System.DateTimeOffset? validUntil = default(System.DateTimeOffset?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), string modified = null, System.Collections.Generic.IDictionary<string, System.BinaryData> extensions = null) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsTIDataConnector SecurityInsightsTIDataConnector(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? etag = default(Azure.ETag?), System.Guid? tenantId = default(System.Guid?), System.DateTimeOffset? tipLookbackOn = default(System.DateTimeOffset?), Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsDataTypeConnectionState? indicatorsState = default(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsDataTypeConnectionState?)) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsUriEntity SecurityInsightsUriEntity(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> additionalData = null, string friendlyName = null, System.Uri uri = null) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsUserInfo SecurityInsightsUserInfo(string email = null, string name = null, System.Guid? objectId = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistData SecurityInsightsWatchlistData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Guid? watchlistId = default(System.Guid?), string displayName = null, string provider = null, Azure.ResourceManager.SecurityInsights.Models.Source? source = default(Azure.ResourceManager.SecurityInsights.Models.Source?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsUserInfo createdBy = null, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsUserInfo updatedBy = null, string description = null, string watchlistType = null, string watchlistAlias = null, bool? isDeleted = default(bool?), System.Collections.Generic.IEnumerable<string> labels = null, System.TimeSpan? defaultDuration = default(System.TimeSpan?), System.Guid? tenantId = default(System.Guid?), int? numberOfLinesToSkip = default(int?), string rawContent = null, string itemsSearchKey = null, string contentType = null, string uploadStatus = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.SecurityInsightsWatchlistItemData SecurityInsightsWatchlistItemData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string watchlistItemType = null, string watchlistItemId = null, System.Guid? tenantId = default(System.Guid?), bool? isDeleted = default(bool?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsUserInfo createdBy = null, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsUserInfo updatedBy = null, System.BinaryData itemsKeyValue = null, System.BinaryData entityMapping = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingData SecurityMLAnalyticsSettingData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string kind = "Unknown", Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceMetric ThreatIntelligenceMetric(string lastUpdatedOn = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceMetricEntity> threatTypeMetrics = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceMetricEntity> patternTypeMetrics = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceMetricEntity> sourceMetrics = null) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceMetricEntity ThreatIntelligenceMetricEntity(string metricName = null, int? metricValue = default(int?)) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceMetrics ThreatIntelligenceMetrics(Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceMetric properties = null) { throw null; }
    }
    public partial class AutomationRuleModifyPropertiesAction : Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAutomationRuleAction, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.AutomationRuleModifyPropertiesAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.AutomationRuleModifyPropertiesAction>
    {
        public AutomationRuleModifyPropertiesAction(int order) : base (default(int)) { }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentActionConfiguration ActionConfiguration { get { throw null; } set { } }
        Azure.ResourceManager.SecurityInsights.Models.AutomationRuleModifyPropertiesAction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.AutomationRuleModifyPropertiesAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.AutomationRuleModifyPropertiesAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.AutomationRuleModifyPropertiesAction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.AutomationRuleModifyPropertiesAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.AutomationRuleModifyPropertiesAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.AutomationRuleModifyPropertiesAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class AutomationRulePropertyArrayChangedValuesCondition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyArrayChangedValuesCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyArrayChangedValuesCondition>
    {
        public AutomationRulePropertyArrayChangedValuesCondition() { }
        public Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyArrayChangedConditionSupportedArrayType? ArrayType { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyArrayChangedConditionSupportedChangeType? ChangeType { get { throw null; } set { } }
        Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyArrayChangedValuesCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyArrayChangedValuesCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyArrayChangedValuesCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyArrayChangedValuesCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyArrayChangedValuesCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyArrayChangedValuesCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyArrayChangedValuesCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class AutomationRulePropertyValuesChangedCondition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyValuesChangedCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyValuesChangedCondition>
    {
        public AutomationRulePropertyValuesChangedCondition() { }
        public Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyChangedConditionSupportedChangedType? ChangeType { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedOperator? Operator { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyChangedConditionSupportedPropertyType? PropertyName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PropertyValues { get { throw null; } }
        Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyValuesChangedCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyValuesChangedCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyValuesChangedCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyValuesChangedCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyValuesChangedCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyValuesChangedCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyValuesChangedCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AutomationRulePropertyValuesCondition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyValuesCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyValuesCondition>
    {
        public AutomationRulePropertyValuesCondition() { }
        public Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedOperator? Operator { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty? PropertyName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PropertyValues { get { throw null; } }
        Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyValuesCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyValuesCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyValuesCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyValuesCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyValuesCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyValuesCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyValuesCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AutomationRuleRunPlaybookAction : Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAutomationRuleAction, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.AutomationRuleRunPlaybookAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.AutomationRuleRunPlaybookAction>
    {
        public AutomationRuleRunPlaybookAction(int order) : base (default(int)) { }
        public Azure.ResourceManager.SecurityInsights.Models.AutomationRuleRunPlaybookActionProperties ActionConfiguration { get { throw null; } set { } }
        Azure.ResourceManager.SecurityInsights.Models.AutomationRuleRunPlaybookAction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.AutomationRuleRunPlaybookAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.AutomationRuleRunPlaybookAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.AutomationRuleRunPlaybookAction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.AutomationRuleRunPlaybookAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.AutomationRuleRunPlaybookAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.AutomationRuleRunPlaybookAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AutomationRuleRunPlaybookActionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.AutomationRuleRunPlaybookActionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.AutomationRuleRunPlaybookActionProperties>
    {
        public AutomationRuleRunPlaybookActionProperties(Azure.Core.ResourceIdentifier logicAppResourceId) { }
        public Azure.Core.ResourceIdentifier LogicAppResourceId { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        Azure.ResourceManager.SecurityInsights.Models.AutomationRuleRunPlaybookActionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.AutomationRuleRunPlaybookActionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.AutomationRuleRunPlaybookActionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.AutomationRuleRunPlaybookActionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.AutomationRuleRunPlaybookActionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.AutomationRuleRunPlaybookActionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.AutomationRuleRunPlaybookActionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class McasDataConnector : Azure.ResourceManager.SecurityInsights.SecurityInsightsDataConnectorData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.McasDataConnector>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.McasDataConnector>
    {
        public McasDataConnector() { }
        public Azure.ResourceManager.SecurityInsights.Models.McasDataConnectorDataTypes DataTypes { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        Azure.ResourceManager.SecurityInsights.Models.McasDataConnector System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.McasDataConnector>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.McasDataConnector>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.McasDataConnector System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.McasDataConnector>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.McasDataConnector>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.McasDataConnector>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class McasDataConnectorDataTypes : Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertsDataTypeOfDataConnector, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.McasDataConnectorDataTypes>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.McasDataConnectorDataTypes>
    {
        public McasDataConnectorDataTypes() { }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsDataTypeConnectionState? DiscoveryLogsState { get { throw null; } set { } }
        Azure.ResourceManager.SecurityInsights.Models.McasDataConnectorDataTypes System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.McasDataConnectorDataTypes>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.McasDataConnectorDataTypes>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.McasDataConnectorDataTypes System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.McasDataConnectorDataTypes>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.McasDataConnectorDataTypes>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.McasDataConnectorDataTypes>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MdatpDataConnector : Azure.ResourceManager.SecurityInsights.SecurityInsightsDataConnectorData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.MdatpDataConnector>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.MdatpDataConnector>
    {
        public MdatpDataConnector() { }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsDataTypeConnectionState? AlertsState { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        Azure.ResourceManager.SecurityInsights.Models.MdatpDataConnector System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.MdatpDataConnector>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.MdatpDataConnector>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.MdatpDataConnector System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.MdatpDataConnector>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.MdatpDataConnector>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.MdatpDataConnector>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MicrosoftSecurityIncidentCreationAlertRule : Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.MicrosoftSecurityIncidentCreationAlertRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.MicrosoftSecurityIncidentCreationAlertRule>
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
        Azure.ResourceManager.SecurityInsights.Models.MicrosoftSecurityIncidentCreationAlertRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.MicrosoftSecurityIncidentCreationAlertRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.MicrosoftSecurityIncidentCreationAlertRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.MicrosoftSecurityIncidentCreationAlertRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.MicrosoftSecurityIncidentCreationAlertRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.MicrosoftSecurityIncidentCreationAlertRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.MicrosoftSecurityIncidentCreationAlertRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MicrosoftSecurityIncidentCreationAlertRuleTemplate : Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleTemplateData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.MicrosoftSecurityIncidentCreationAlertRuleTemplate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.MicrosoftSecurityIncidentCreationAlertRuleTemplate>
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
        Azure.ResourceManager.SecurityInsights.Models.MicrosoftSecurityIncidentCreationAlertRuleTemplate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.MicrosoftSecurityIncidentCreationAlertRuleTemplate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.MicrosoftSecurityIncidentCreationAlertRuleTemplate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.MicrosoftSecurityIncidentCreationAlertRuleTemplate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.MicrosoftSecurityIncidentCreationAlertRuleTemplate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.MicrosoftSecurityIncidentCreationAlertRuleTemplate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.MicrosoftSecurityIncidentCreationAlertRuleTemplate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ScheduledAlertRuleTemplate : Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleTemplateData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.ScheduledAlertRuleTemplate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.ScheduledAlertRuleTemplate>
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
        Azure.ResourceManager.SecurityInsights.Models.ScheduledAlertRuleTemplate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.ScheduledAlertRuleTemplate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.ScheduledAlertRuleTemplate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.ScheduledAlertRuleTemplate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.ScheduledAlertRuleTemplate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.ScheduledAlertRuleTemplate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.ScheduledAlertRuleTemplate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecurityInsightsAadDataConnector : Azure.ResourceManager.SecurityInsights.SecurityInsightsDataConnectorData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAadDataConnector>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAadDataConnector>
    {
        public SecurityInsightsAadDataConnector() { }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsDataTypeConnectionState? AlertsState { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAadDataConnector System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAadDataConnector>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAadDataConnector>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAadDataConnector System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAadDataConnector>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAadDataConnector>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAadDataConnector>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecurityInsightsAatpDataConnector : Azure.ResourceManager.SecurityInsights.SecurityInsightsDataConnectorData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAatpDataConnector>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAatpDataConnector>
    {
        public SecurityInsightsAatpDataConnector() { }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsDataTypeConnectionState? AlertsState { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAatpDataConnector System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAatpDataConnector>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAatpDataConnector>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAatpDataConnector System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAatpDataConnector>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAatpDataConnector>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAatpDataConnector>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecurityInsightsAccountEntity : Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntity, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAccountEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAccountEntity>
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
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAccountEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAccountEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAccountEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAccountEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAccountEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAccountEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAccountEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecurityInsightsAlert : Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntity, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlert>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlert>
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
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlert System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlert>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlert>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlert System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlert>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlert>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlert>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class SecurityInsightsAlertConfidenceReason : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertConfidenceReason>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertConfidenceReason>
    {
        internal SecurityInsightsAlertConfidenceReason() { }
        public string Reason { get { throw null; } }
        public string ReasonType { get { throw null; } }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertConfidenceReason System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertConfidenceReason>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertConfidenceReason>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertConfidenceReason System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertConfidenceReason>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertConfidenceReason>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertConfidenceReason>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class SecurityInsightsAlertDetailsOverride : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertDetailsOverride>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertDetailsOverride>
    {
        public SecurityInsightsAlertDetailsOverride() { }
        public string AlertDescriptionFormat { get { throw null; } set { } }
        public string AlertDisplayNameFormat { get { throw null; } set { } }
        public string AlertSeverityColumnName { get { throw null; } set { } }
        public string AlertTacticsColumnName { get { throw null; } set { } }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertDetailsOverride System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertDetailsOverride>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertDetailsOverride>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertDetailsOverride System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertDetailsOverride>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertDetailsOverride>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertDetailsOverride>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecurityInsightsAlertRuleActionCreateOrUpdateContent : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleActionCreateOrUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleActionCreateOrUpdateContent>
    {
        public SecurityInsightsAlertRuleActionCreateOrUpdateContent() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier LogicAppResourceId { get { throw null; } set { } }
        public System.Uri TriggerUri { get { throw null; } set { } }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleActionCreateOrUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleActionCreateOrUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleActionCreateOrUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleActionCreateOrUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleActionCreateOrUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleActionCreateOrUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleActionCreateOrUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecurityInsightsAlertRuleEntityMapping : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleEntityMapping>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleEntityMapping>
    {
        public SecurityInsightsAlertRuleEntityMapping() { }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleEntityMappingType? EntityType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFieldMapping> FieldMappings { get { throw null; } }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleEntityMapping System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleEntityMapping>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleEntityMapping>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleEntityMapping System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleEntityMapping>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleEntityMapping>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleEntityMapping>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class SecurityInsightsAlertsDataTypeOfDataConnector : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertsDataTypeOfDataConnector>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertsDataTypeOfDataConnector>
    {
        public SecurityInsightsAlertsDataTypeOfDataConnector() { }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsDataTypeConnectionState? AlertsState { get { throw null; } set { } }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertsDataTypeOfDataConnector System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertsDataTypeOfDataConnector>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertsDataTypeOfDataConnector>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertsDataTypeOfDataConnector System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertsDataTypeOfDataConnector>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertsDataTypeOfDataConnector>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertsDataTypeOfDataConnector>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class SecurityInsightsAscDataConnector : Azure.ResourceManager.SecurityInsights.SecurityInsightsDataConnectorData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAscDataConnector>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAscDataConnector>
    {
        public SecurityInsightsAscDataConnector() { }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsDataTypeConnectionState? AlertsState { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAscDataConnector System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAscDataConnector>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAscDataConnector>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAscDataConnector System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAscDataConnector>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAscDataConnector>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAscDataConnector>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public abstract partial class SecurityInsightsAutomationRuleAction : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAutomationRuleAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAutomationRuleAction>
    {
        protected SecurityInsightsAutomationRuleAction(int order) { }
        public int Order { get { throw null; } set { } }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAutomationRuleAction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAutomationRuleAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAutomationRuleAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAutomationRuleAction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAutomationRuleAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAutomationRuleAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAutomationRuleAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class SecurityInsightsAutomationRuleCondition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAutomationRuleCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAutomationRuleCondition>
    {
        protected SecurityInsightsAutomationRuleCondition() { }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAutomationRuleCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAutomationRuleCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAutomationRuleCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAutomationRuleCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAutomationRuleCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAutomationRuleCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAutomationRuleCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecurityInsightsAutomationRuleTriggeringLogic : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAutomationRuleTriggeringLogic>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAutomationRuleTriggeringLogic>
    {
        public SecurityInsightsAutomationRuleTriggeringLogic(bool isEnabled, Azure.ResourceManager.SecurityInsights.Models.TriggersOn triggersOn, Azure.ResourceManager.SecurityInsights.Models.TriggersWhen triggersWhen) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAutomationRuleCondition> Conditions { get { throw null; } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public bool IsEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.TriggersOn TriggersOn { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.TriggersWhen TriggersWhen { get { throw null; } set { } }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAutomationRuleTriggeringLogic System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAutomationRuleTriggeringLogic>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAutomationRuleTriggeringLogic>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAutomationRuleTriggeringLogic System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAutomationRuleTriggeringLogic>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAutomationRuleTriggeringLogic>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAutomationRuleTriggeringLogic>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecurityInsightsAwsCloudTrailDataConnector : Azure.ResourceManager.SecurityInsights.SecurityInsightsDataConnectorData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAwsCloudTrailDataConnector>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAwsCloudTrailDataConnector>
    {
        public SecurityInsightsAwsCloudTrailDataConnector() { }
        public string AwsRoleArn { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsDataTypeConnectionState? LogsState { get { throw null; } set { } }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAwsCloudTrailDataConnector System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAwsCloudTrailDataConnector>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAwsCloudTrailDataConnector>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAwsCloudTrailDataConnector System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAwsCloudTrailDataConnector>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAwsCloudTrailDataConnector>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAwsCloudTrailDataConnector>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecurityInsightsAzureResourceEntity : Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntity, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAzureResourceEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAzureResourceEntity>
    {
        public SecurityInsightsAzureResourceEntity() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public string ResourceId { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAzureResourceEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAzureResourceEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAzureResourceEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAzureResourceEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAzureResourceEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAzureResourceEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAzureResourceEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecurityInsightsBookmarkIncidentInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsBookmarkIncidentInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsBookmarkIncidentInfo>
    {
        public SecurityInsightsBookmarkIncidentInfo() { }
        public System.Guid? IncidentId { get { throw null; } set { } }
        public string RelationName { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentSeverity? Severity { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsBookmarkIncidentInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsBookmarkIncidentInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsBookmarkIncidentInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsBookmarkIncidentInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsBookmarkIncidentInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsBookmarkIncidentInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsBookmarkIncidentInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecurityInsightsClientInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsClientInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsClientInfo>
    {
        internal SecurityInsightsClientInfo() { }
        public string Email { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Guid? ObjectId { get { throw null; } }
        public string UserPrincipalName { get { throw null; } }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsClientInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsClientInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsClientInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsClientInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsClientInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsClientInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsClientInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecurityInsightsCloudApplicationEntity : Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntity, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsCloudApplicationEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsCloudApplicationEntity>
    {
        public SecurityInsightsCloudApplicationEntity() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public int? AppId { get { throw null; } }
        public string AppName { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public string InstanceName { get { throw null; } }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsCloudApplicationEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsCloudApplicationEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsCloudApplicationEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsCloudApplicationEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsCloudApplicationEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsCloudApplicationEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsCloudApplicationEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class SecurityInsightsDnsEntity : Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntity, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsDnsEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsDnsEntity>
    {
        public SecurityInsightsDnsEntity() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public string DnsServerIPEntityId { get { throw null; } }
        public string DomainName { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public string HostIPAddressEntityId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> IPAddressEntityIds { get { throw null; } }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsDnsEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsDnsEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsDnsEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsDnsEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsDnsEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsDnsEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsDnsEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecurityInsightsEntity : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntity>
    {
        public SecurityInsightsEntity() { }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class SecurityInsightsFieldMapping : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFieldMapping>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFieldMapping>
    {
        public SecurityInsightsFieldMapping() { }
        public string ColumnName { get { throw null; } set { } }
        public string Identifier { get { throw null; } set { } }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFieldMapping System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFieldMapping>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFieldMapping>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFieldMapping System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFieldMapping>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFieldMapping>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFieldMapping>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecurityInsightsFileEntity : Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntity, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFileEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFileEntity>
    {
        public SecurityInsightsFileEntity() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public string Directory { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> FileHashEntityIds { get { throw null; } }
        public string FileName { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public string HostEntityId { get { throw null; } }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFileEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFileEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFileEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFileEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFileEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFileEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFileEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class SecurityInsightsFileHashEntity : Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntity, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFileHashEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFileHashEntity>
    {
        public SecurityInsightsFileHashEntity() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFileHashAlgorithm? Algorithm { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public string HashValue { get { throw null; } }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFileHashEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFileHashEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFileHashEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFileHashEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFileHashEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFileHashEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFileHashEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecurityInsightsFusionAlertRule : Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFusionAlertRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFusionAlertRule>
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
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFusionAlertRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFusionAlertRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFusionAlertRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFusionAlertRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFusionAlertRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFusionAlertRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFusionAlertRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecurityInsightsFusionAlertRuleTemplate : Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleTemplateData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFusionAlertRuleTemplate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFusionAlertRuleTemplate>
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
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFusionAlertRuleTemplate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFusionAlertRuleTemplate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFusionAlertRuleTemplate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFusionAlertRuleTemplate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFusionAlertRuleTemplate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFusionAlertRuleTemplate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsFusionAlertRuleTemplate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecurityInsightsGroupEntity : Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntity, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsGroupEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsGroupEntity>
    {
        public SecurityInsightsGroupEntity() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public string DistinguishedName { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public System.Guid? ObjectGuid { get { throw null; } }
        public string Sid { get { throw null; } }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsGroupEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsGroupEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsGroupEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsGroupEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsGroupEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsGroupEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsGroupEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecurityInsightsGroupingConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsGroupingConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsGroupingConfiguration>
    {
        public SecurityInsightsGroupingConfiguration(bool isEnabled, bool isClosedIncidentReopened, System.TimeSpan lookbackDuration, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsGroupingMatchingMethod matchingMethod) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertDetail> GroupByAlertDetails { get { throw null; } }
        public System.Collections.Generic.IList<string> GroupByCustomDetails { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAlertRuleEntityMappingType> GroupByEntities { get { throw null; } }
        public bool IsClosedIncidentReopened { get { throw null; } set { } }
        public bool IsEnabled { get { throw null; } set { } }
        public System.TimeSpan LookbackDuration { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsGroupingMatchingMethod MatchingMethod { get { throw null; } set { } }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsGroupingConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsGroupingConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsGroupingConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsGroupingConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsGroupingConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsGroupingConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsGroupingConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class SecurityInsightsHostEntity : Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntity, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsHostEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsHostEntity>
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
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsHostEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsHostEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsHostEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsHostEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsHostEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsHostEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsHostEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum SecurityInsightsHostOSFamily
    {
        Unknown = 0,
        Linux = 1,
        Windows = 2,
        Android = 3,
        Ios = 4,
    }
    public partial class SecurityInsightsHuntingBookmark : Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntity, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsHuntingBookmark>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsHuntingBookmark>
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
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsHuntingBookmark System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsHuntingBookmark>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsHuntingBookmark>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsHuntingBookmark System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsHuntingBookmark>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsHuntingBookmark>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsHuntingBookmark>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecurityInsightsIncidentActionConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentActionConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentActionConfiguration>
    {
        public SecurityInsightsIncidentActionConfiguration() { }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentClassification? Classification { get { throw null; } set { } }
        public string ClassificationComment { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentClassificationReason? ClassificationReason { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentLabel> Labels { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentOwnerInfo Owner { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentSeverity? Severity { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentStatus? Status { get { throw null; } set { } }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentActionConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentActionConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentActionConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentActionConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentActionConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentActionConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentActionConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecurityInsightsIncidentAdditionalInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentAdditionalInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentAdditionalInfo>
    {
        internal SecurityInsightsIncidentAdditionalInfo() { }
        public System.Collections.Generic.IReadOnlyList<string> AlertProductNames { get { throw null; } }
        public int? AlertsCount { get { throw null; } }
        public int? BookmarksCount { get { throw null; } }
        public int? CommentsCount { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAttackTactic> Tactics { get { throw null; } }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentAdditionalInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentAdditionalInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentAdditionalInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentAdditionalInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentAdditionalInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentAdditionalInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentAdditionalInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class SecurityInsightsIncidentConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentConfiguration>
    {
        public SecurityInsightsIncidentConfiguration(bool isIncidentCreated) { }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsGroupingConfiguration GroupingConfiguration { get { throw null; } set { } }
        public bool IsIncidentCreated { get { throw null; } set { } }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecurityInsightsIncidentEntitiesMetadata : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentEntitiesMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentEntitiesMetadata>
    {
        internal SecurityInsightsIncidentEntitiesMetadata() { }
        public int Count { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntityKind EntityKind { get { throw null; } }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentEntitiesMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentEntitiesMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentEntitiesMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentEntitiesMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentEntitiesMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentEntitiesMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentEntitiesMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecurityInsightsIncidentEntitiesResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentEntitiesResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentEntitiesResult>
    {
        internal SecurityInsightsIncidentEntitiesResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntity> Entities { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentEntitiesMetadata> MetaData { get { throw null; } }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentEntitiesResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentEntitiesResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentEntitiesResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentEntitiesResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentEntitiesResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentEntitiesResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentEntitiesResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecurityInsightsIncidentLabel : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentLabel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentLabel>
    {
        public SecurityInsightsIncidentLabel(string labelName) { }
        public string LabelName { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentLabelType? LabelType { get { throw null; } }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentLabel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentLabel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentLabel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentLabel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentLabel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentLabel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentLabel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class SecurityInsightsIncidentOwnerInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentOwnerInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentOwnerInfo>
    {
        public SecurityInsightsIncidentOwnerInfo() { }
        public string AssignedTo { get { throw null; } set { } }
        public string Email { get { throw null; } set { } }
        public System.Guid? ObjectId { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentOwnerType? OwnerType { get { throw null; } set { } }
        public string UserPrincipalName { get { throw null; } set { } }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentOwnerInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentOwnerInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentOwnerInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentOwnerInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentOwnerInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentOwnerInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIncidentOwnerInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class SecurityInsightsIotDeviceEntity : Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntity, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIotDeviceEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIotDeviceEntity>
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
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIotDeviceEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIotDeviceEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIotDeviceEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIotDeviceEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIotDeviceEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIotDeviceEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIotDeviceEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecurityInsightsIPEntity : Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntity, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIPEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIPEntity>
    {
        public SecurityInsightsIPEntity() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public System.Net.IPAddress Address { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIPEntityGeoLocation Location { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsThreatIntelligence> ThreatIntelligence { get { throw null; } }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIPEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIPEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIPEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIPEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIPEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIPEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIPEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecurityInsightsIPEntityGeoLocation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIPEntityGeoLocation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIPEntityGeoLocation>
    {
        internal SecurityInsightsIPEntityGeoLocation() { }
        public int? Asn { get { throw null; } }
        public string City { get { throw null; } }
        public string CountryCode { get { throw null; } }
        public string CountryName { get { throw null; } }
        public double? Latitude { get { throw null; } }
        public double? Longitude { get { throw null; } }
        public string State { get { throw null; } }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIPEntityGeoLocation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIPEntityGeoLocation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIPEntityGeoLocation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIPEntityGeoLocation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIPEntityGeoLocation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIPEntityGeoLocation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsIPEntityGeoLocation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class SecurityInsightsMailboxEntity : Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntity, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsMailboxEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsMailboxEntity>
    {
        public SecurityInsightsMailboxEntity() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Guid? ExternalDirectoryObjectId { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public string MailboxPrimaryAddress { get { throw null; } }
        public string Upn { get { throw null; } }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsMailboxEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsMailboxEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsMailboxEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsMailboxEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsMailboxEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsMailboxEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsMailboxEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecurityInsightsMailClusterEntity : Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntity, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsMailClusterEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsMailClusterEntity>
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
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsMailClusterEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsMailClusterEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsMailClusterEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsMailClusterEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsMailClusterEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsMailClusterEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsMailClusterEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class SecurityInsightsMailMessageEntity : Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntity, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsMailMessageEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsMailMessageEntity>
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
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsMailMessageEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsMailMessageEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsMailMessageEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsMailMessageEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsMailMessageEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsMailMessageEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsMailMessageEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecurityInsightsMalwareEntity : Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntity, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsMalwareEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsMalwareEntity>
    {
        public SecurityInsightsMalwareEntity() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public string Category { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> FileEntityIds { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public string MalwareName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ProcessEntityIds { get { throw null; } }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsMalwareEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsMalwareEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsMalwareEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsMalwareEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsMalwareEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsMalwareEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsMalwareEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecurityInsightsOfficeDataConnector : Azure.ResourceManager.SecurityInsights.SecurityInsightsDataConnectorData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsOfficeDataConnector>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsOfficeDataConnector>
    {
        public SecurityInsightsOfficeDataConnector() { }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsOfficeDataConnectorDataTypes DataTypes { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsOfficeDataConnector System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsOfficeDataConnector>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsOfficeDataConnector>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsOfficeDataConnector System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsOfficeDataConnector>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsOfficeDataConnector>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsOfficeDataConnector>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecurityInsightsOfficeDataConnectorDataTypes : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsOfficeDataConnectorDataTypes>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsOfficeDataConnectorDataTypes>
    {
        public SecurityInsightsOfficeDataConnectorDataTypes() { }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsDataTypeConnectionState? ExchangeState { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsDataTypeConnectionState? SharePointState { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsDataTypeConnectionState? TeamsState { get { throw null; } set { } }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsOfficeDataConnectorDataTypes System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsOfficeDataConnectorDataTypes>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsOfficeDataConnectorDataTypes>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsOfficeDataConnectorDataTypes System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsOfficeDataConnectorDataTypes>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsOfficeDataConnectorDataTypes>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsOfficeDataConnectorDataTypes>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum SecurityInsightsProcessElevationToken
    {
        Default = 0,
        Full = 1,
        Limited = 2,
    }
    public partial class SecurityInsightsProcessEntity : Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntity, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsProcessEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsProcessEntity>
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
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsProcessEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsProcessEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsProcessEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsProcessEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsProcessEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsProcessEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsProcessEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecurityInsightsPropertyArrayChangedConditionProperties : Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAutomationRuleCondition, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsPropertyArrayChangedConditionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsPropertyArrayChangedConditionProperties>
    {
        public SecurityInsightsPropertyArrayChangedConditionProperties() { }
        public Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyArrayChangedValuesCondition ConditionProperties { get { throw null; } set { } }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsPropertyArrayChangedConditionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsPropertyArrayChangedConditionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsPropertyArrayChangedConditionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsPropertyArrayChangedConditionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsPropertyArrayChangedConditionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsPropertyArrayChangedConditionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsPropertyArrayChangedConditionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecurityInsightsPropertyChangedConditionProperties : Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAutomationRuleCondition, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsPropertyChangedConditionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsPropertyChangedConditionProperties>
    {
        public SecurityInsightsPropertyChangedConditionProperties() { }
        public Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyValuesChangedCondition ConditionProperties { get { throw null; } set { } }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsPropertyChangedConditionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsPropertyChangedConditionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsPropertyChangedConditionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsPropertyChangedConditionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsPropertyChangedConditionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsPropertyChangedConditionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsPropertyChangedConditionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecurityInsightsPropertyConditionProperties : Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsAutomationRuleCondition, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsPropertyConditionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsPropertyConditionProperties>
    {
        public SecurityInsightsPropertyConditionProperties() { }
        public Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyValuesCondition ConditionProperties { get { throw null; } set { } }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsPropertyConditionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsPropertyConditionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsPropertyConditionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsPropertyConditionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsPropertyConditionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsPropertyConditionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsPropertyConditionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class SecurityInsightsRegistryKeyEntity : Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntity, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsRegistryKeyEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsRegistryKeyEntity>
    {
        public SecurityInsightsRegistryKeyEntity() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsRegistryHive? Hive { get { throw null; } }
        public string Key { get { throw null; } }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsRegistryKeyEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsRegistryKeyEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsRegistryKeyEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsRegistryKeyEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsRegistryKeyEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsRegistryKeyEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsRegistryKeyEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecurityInsightsRegistryValueEntity : Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntity, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsRegistryValueEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsRegistryValueEntity>
    {
        public SecurityInsightsRegistryValueEntity() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public string KeyEntityId { get { throw null; } }
        public string ValueData { get { throw null; } }
        public string ValueName { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsRegistryValueKind? ValueType { get { throw null; } }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsRegistryValueEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsRegistryValueEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsRegistryValueEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsRegistryValueEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsRegistryValueEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsRegistryValueEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsRegistryValueEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class SecurityInsightsScheduledAlertRule : Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsScheduledAlertRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsScheduledAlertRule>
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
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsScheduledAlertRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsScheduledAlertRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsScheduledAlertRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsScheduledAlertRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsScheduledAlertRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsScheduledAlertRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsScheduledAlertRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecurityInsightsSubmissionMailEntity : Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntity, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsSubmissionMailEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsSubmissionMailEntity>
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
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsSubmissionMailEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsSubmissionMailEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsSubmissionMailEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsSubmissionMailEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsSubmissionMailEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsSubmissionMailEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsSubmissionMailEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecurityInsightsThreatIntelligence : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsThreatIntelligence>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsThreatIntelligence>
    {
        internal SecurityInsightsThreatIntelligence() { }
        public double? Confidence { get { throw null; } }
        public string ProviderName { get { throw null; } }
        public string ReportLink { get { throw null; } }
        public string ThreatDescription { get { throw null; } }
        public string ThreatName { get { throw null; } }
        public string ThreatType { get { throw null; } }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsThreatIntelligence System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsThreatIntelligence>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsThreatIntelligence>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsThreatIntelligence System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsThreatIntelligence>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsThreatIntelligence>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsThreatIntelligence>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecurityInsightsThreatIntelligenceIndicatorData : Azure.ResourceManager.SecurityInsights.SecurityInsightsThreatIntelligenceIndicatorBaseData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsThreatIntelligenceIndicatorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsThreatIntelligenceIndicatorData>
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
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsThreatIntelligenceIndicatorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsThreatIntelligenceIndicatorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsThreatIntelligenceIndicatorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsThreatIntelligenceIndicatorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsThreatIntelligenceIndicatorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsThreatIntelligenceIndicatorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsThreatIntelligenceIndicatorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecurityInsightsTIDataConnector : Azure.ResourceManager.SecurityInsights.SecurityInsightsDataConnectorData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsTIDataConnector>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsTIDataConnector>
    {
        public SecurityInsightsTIDataConnector() { }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsDataTypeConnectionState? IndicatorsState { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        public System.DateTimeOffset? TipLookbackOn { get { throw null; } set { } }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsTIDataConnector System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsTIDataConnector>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsTIDataConnector>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsTIDataConnector System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsTIDataConnector>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsTIDataConnector>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsTIDataConnector>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecurityInsightsUriEntity : Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsEntity, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsUriEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsUriEntity>
    {
        public SecurityInsightsUriEntity() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public System.Uri Uri { get { throw null; } }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsUriEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsUriEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsUriEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsUriEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsUriEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsUriEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsUriEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecurityInsightsUserInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsUserInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsUserInfo>
    {
        public SecurityInsightsUserInfo() { }
        public string Email { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Guid? ObjectId { get { throw null; } set { } }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsUserInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsUserInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsUserInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsUserInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsUserInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsUserInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsUserInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecurityMLAnalyticsSettingsDataSource : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityMLAnalyticsSettingsDataSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityMLAnalyticsSettingsDataSource>
    {
        public SecurityMLAnalyticsSettingsDataSource() { }
        public string ConnectorId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DataTypes { get { throw null; } }
        Azure.ResourceManager.SecurityInsights.Models.SecurityMLAnalyticsSettingsDataSource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityMLAnalyticsSettingsDataSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.SecurityMLAnalyticsSettingsDataSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.SecurityMLAnalyticsSettingsDataSource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityMLAnalyticsSettingsDataSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityMLAnalyticsSettingsDataSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.SecurityMLAnalyticsSettingsDataSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ThreatIntelligenceAppendTags : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceAppendTags>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceAppendTags>
    {
        public ThreatIntelligenceAppendTags() { }
        public System.Collections.Generic.IList<string> ThreatIntelligenceTags { get { throw null; } }
        Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceAppendTags System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceAppendTags>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceAppendTags>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceAppendTags System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceAppendTags>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceAppendTags>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceAppendTags>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ThreatIntelligenceExternalReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceExternalReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceExternalReference>
    {
        public ThreatIntelligenceExternalReference() { }
        public string Description { get { throw null; } set { } }
        public string ExternalId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Hashes { get { throw null; } }
        public string SourceName { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceExternalReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceExternalReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceExternalReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceExternalReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceExternalReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceExternalReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceExternalReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ThreatIntelligenceFilteringCriteria : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceFilteringCriteria>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceFilteringCriteria>
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
        Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceFilteringCriteria System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceFilteringCriteria>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceFilteringCriteria>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceFilteringCriteria System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceFilteringCriteria>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceFilteringCriteria>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceFilteringCriteria>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ThreatIntelligenceGranularMarkingEntity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceGranularMarkingEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceGranularMarkingEntity>
    {
        public ThreatIntelligenceGranularMarkingEntity() { }
        public string Language { get { throw null; } set { } }
        public int? MarkingRef { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Selectors { get { throw null; } }
        Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceGranularMarkingEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceGranularMarkingEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceGranularMarkingEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceGranularMarkingEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceGranularMarkingEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceGranularMarkingEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceGranularMarkingEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ThreatIntelligenceKillChainPhase : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceKillChainPhase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceKillChainPhase>
    {
        public ThreatIntelligenceKillChainPhase() { }
        public string KillChainName { get { throw null; } set { } }
        public string PhaseName { get { throw null; } set { } }
        Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceKillChainPhase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceKillChainPhase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceKillChainPhase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceKillChainPhase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceKillChainPhase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceKillChainPhase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceKillChainPhase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ThreatIntelligenceMetric : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceMetric>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceMetric>
    {
        internal ThreatIntelligenceMetric() { }
        public string LastUpdatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceMetricEntity> PatternTypeMetrics { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceMetricEntity> SourceMetrics { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceMetricEntity> ThreatTypeMetrics { get { throw null; } }
        Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceMetric System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceMetric>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceMetric>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceMetric System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceMetric>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceMetric>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceMetric>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ThreatIntelligenceMetricEntity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceMetricEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceMetricEntity>
    {
        internal ThreatIntelligenceMetricEntity() { }
        public string MetricName { get { throw null; } }
        public int? MetricValue { get { throw null; } }
        Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceMetricEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceMetricEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceMetricEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceMetricEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceMetricEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceMetricEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceMetricEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ThreatIntelligenceMetrics : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceMetrics>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceMetrics>
    {
        internal ThreatIntelligenceMetrics() { }
        public Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceMetric Properties { get { throw null; } }
        Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceMetrics System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceMetrics>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceMetrics>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceMetrics System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceMetrics>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceMetrics>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceMetrics>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ThreatIntelligenceParsedPattern : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceParsedPattern>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceParsedPattern>
    {
        public ThreatIntelligenceParsedPattern() { }
        public string PatternTypeKey { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceParsedPatternTypeValue> PatternTypeValues { get { throw null; } }
        Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceParsedPattern System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceParsedPattern>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceParsedPattern>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceParsedPattern System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceParsedPattern>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceParsedPattern>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceParsedPattern>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ThreatIntelligenceParsedPatternTypeValue : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceParsedPatternTypeValue>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceParsedPatternTypeValue>
    {
        public ThreatIntelligenceParsedPatternTypeValue() { }
        public string Value { get { throw null; } set { } }
        public string ValueType { get { throw null; } set { } }
        Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceParsedPatternTypeValue System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceParsedPatternTypeValue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceParsedPatternTypeValue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceParsedPatternTypeValue System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceParsedPatternTypeValue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceParsedPatternTypeValue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceParsedPatternTypeValue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ThreatIntelligenceSortingCriteria : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceSortingCriteria>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceSortingCriteria>
    {
        public ThreatIntelligenceSortingCriteria() { }
        public string ItemKey { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceSortingOrder? SortOrder { get { throw null; } set { } }
        Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceSortingCriteria System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceSortingCriteria>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceSortingCriteria>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceSortingCriteria System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceSortingCriteria>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceSortingCriteria>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceSortingCriteria>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
