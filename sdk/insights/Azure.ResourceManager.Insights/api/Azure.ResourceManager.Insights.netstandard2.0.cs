namespace Azure.ResourceManager.Insights
{
    public partial class ActionGroupsOperations
    {
        protected ActionGroupsOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Insights.Models.ActionGroupResource> CreateOrUpdate(string resourceGroupName, string actionGroupName, Azure.ResourceManager.Insights.Models.ActionGroupResource actionGroup, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Insights.Models.ActionGroupResource>> CreateOrUpdateAsync(string resourceGroupName, string actionGroupName, Azure.ResourceManager.Insights.Models.ActionGroupResource actionGroup, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string resourceGroupName, string actionGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string resourceGroupName, string actionGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response EnableReceiver(string resourceGroupName, string actionGroupName, Azure.ResourceManager.Insights.Models.EnableRequest enableRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> EnableReceiverAsync(string resourceGroupName, string actionGroupName, Azure.ResourceManager.Insights.Models.EnableRequest enableRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Insights.Models.ActionGroupResource> Get(string resourceGroupName, string actionGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Insights.Models.ActionGroupResource>> GetAsync(string resourceGroupName, string actionGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Insights.Models.ActionGroupResource> ListByResourceGroup(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Insights.Models.ActionGroupResource> ListByResourceGroupAsync(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Insights.Models.ActionGroupResource> ListBySubscriptionId(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Insights.Models.ActionGroupResource> ListBySubscriptionIdAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Insights.Models.ActionGroupResource> Update(string resourceGroupName, string actionGroupName, Azure.ResourceManager.Insights.Models.ActionGroupPatchBody actionGroupPatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Insights.Models.ActionGroupResource>> UpdateAsync(string resourceGroupName, string actionGroupName, Azure.ResourceManager.Insights.Models.ActionGroupPatchBody actionGroupPatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ActivityLogAlertsOperations
    {
        protected ActivityLogAlertsOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Insights.Models.ActivityLogAlertResource> CreateOrUpdate(string resourceGroupName, string activityLogAlertName, Azure.ResourceManager.Insights.Models.ActivityLogAlertResource activityLogAlert, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Insights.Models.ActivityLogAlertResource>> CreateOrUpdateAsync(string resourceGroupName, string activityLogAlertName, Azure.ResourceManager.Insights.Models.ActivityLogAlertResource activityLogAlert, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string resourceGroupName, string activityLogAlertName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string resourceGroupName, string activityLogAlertName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Insights.Models.ActivityLogAlertResource> Get(string resourceGroupName, string activityLogAlertName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Insights.Models.ActivityLogAlertResource>> GetAsync(string resourceGroupName, string activityLogAlertName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Insights.Models.ActivityLogAlertResource> ListByResourceGroup(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Insights.Models.ActivityLogAlertResource> ListByResourceGroupAsync(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Insights.Models.ActivityLogAlertResource> ListBySubscriptionId(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Insights.Models.ActivityLogAlertResource> ListBySubscriptionIdAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Insights.Models.ActivityLogAlertResource> Update(string resourceGroupName, string activityLogAlertName, Azure.ResourceManager.Insights.Models.ActivityLogAlertPatchBody activityLogAlertPatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Insights.Models.ActivityLogAlertResource>> UpdateAsync(string resourceGroupName, string activityLogAlertName, Azure.ResourceManager.Insights.Models.ActivityLogAlertPatchBody activityLogAlertPatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ActivityLogsOperations
    {
        protected ActivityLogsOperations() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Insights.Models.EventData> List(string filter, string select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Insights.Models.EventData> ListAsync(string filter, string select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AlertRuleIncidentsOperations
    {
        protected AlertRuleIncidentsOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Insights.Models.Incident> Get(string resourceGroupName, string ruleName, string incidentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Insights.Models.Incident>> GetAsync(string resourceGroupName, string ruleName, string incidentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Insights.Models.Incident> ListByAlertRule(string resourceGroupName, string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Insights.Models.Incident> ListByAlertRuleAsync(string resourceGroupName, string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AlertRulesOperations
    {
        protected AlertRulesOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Insights.Models.AlertRuleResource> CreateOrUpdate(string resourceGroupName, string ruleName, Azure.ResourceManager.Insights.Models.AlertRuleResource parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Insights.Models.AlertRuleResource>> CreateOrUpdateAsync(string resourceGroupName, string ruleName, Azure.ResourceManager.Insights.Models.AlertRuleResource parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string resourceGroupName, string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string resourceGroupName, string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Insights.Models.AlertRuleResource> Get(string resourceGroupName, string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Insights.Models.AlertRuleResource>> GetAsync(string resourceGroupName, string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Insights.Models.AlertRuleResource> ListByResourceGroup(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Insights.Models.AlertRuleResource> ListByResourceGroupAsync(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Insights.Models.AlertRuleResource> ListBySubscription(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Insights.Models.AlertRuleResource> ListBySubscriptionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Insights.Models.AlertRuleResource> Update(string resourceGroupName, string ruleName, Azure.ResourceManager.Insights.Models.AlertRuleResourcePatch alertRulesResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Insights.Models.AlertRuleResource>> UpdateAsync(string resourceGroupName, string ruleName, Azure.ResourceManager.Insights.Models.AlertRuleResourcePatch alertRulesResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AutoscaleSettingsOperations
    {
        protected AutoscaleSettingsOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Insights.Models.AutoscaleSettingResource> CreateOrUpdate(string resourceGroupName, string autoscaleSettingName, Azure.ResourceManager.Insights.Models.AutoscaleSettingResource parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Insights.Models.AutoscaleSettingResource>> CreateOrUpdateAsync(string resourceGroupName, string autoscaleSettingName, Azure.ResourceManager.Insights.Models.AutoscaleSettingResource parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string resourceGroupName, string autoscaleSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string resourceGroupName, string autoscaleSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Insights.Models.AutoscaleSettingResource> Get(string resourceGroupName, string autoscaleSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Insights.Models.AutoscaleSettingResource>> GetAsync(string resourceGroupName, string autoscaleSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Insights.Models.AutoscaleSettingResource> ListByResourceGroup(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Insights.Models.AutoscaleSettingResource> ListByResourceGroupAsync(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Insights.Models.AutoscaleSettingResource> ListBySubscription(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Insights.Models.AutoscaleSettingResource> ListBySubscriptionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Insights.Models.AutoscaleSettingResource> Update(string resourceGroupName, string autoscaleSettingName, Azure.ResourceManager.Insights.Models.AutoscaleSettingResourcePatch autoscaleSettingResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Insights.Models.AutoscaleSettingResource>> UpdateAsync(string resourceGroupName, string autoscaleSettingName, Azure.ResourceManager.Insights.Models.AutoscaleSettingResourcePatch autoscaleSettingResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BaselinesOperations
    {
        protected BaselinesOperations() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Insights.Models.SingleMetricBaseline> List(string resourceUri, string metricnames = null, string metricnamespace = null, string timespan = null, System.TimeSpan? interval = default(System.TimeSpan?), string aggregation = null, string sensitivities = null, string filter = null, Azure.ResourceManager.Insights.Models.ResultType? resultType = default(Azure.ResourceManager.Insights.Models.ResultType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Insights.Models.SingleMetricBaseline> ListAsync(string resourceUri, string metricnames = null, string metricnamespace = null, string timespan = null, System.TimeSpan? interval = default(System.TimeSpan?), string aggregation = null, string sensitivities = null, string filter = null, Azure.ResourceManager.Insights.Models.ResultType? resultType = default(Azure.ResourceManager.Insights.Models.ResultType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DiagnosticSettingsCategoryOperations
    {
        protected DiagnosticSettingsCategoryOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Insights.Models.DiagnosticSettingsCategoryResource> Get(string resourceUri, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Insights.Models.DiagnosticSettingsCategoryResource>> GetAsync(string resourceUri, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Insights.Models.DiagnosticSettingsCategoryResourceCollection> List(string resourceUri, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Insights.Models.DiagnosticSettingsCategoryResourceCollection>> ListAsync(string resourceUri, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DiagnosticSettingsOperations
    {
        protected DiagnosticSettingsOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Insights.Models.DiagnosticSettingsResource> CreateOrUpdate(string resourceUri, string name, Azure.ResourceManager.Insights.Models.DiagnosticSettingsResource parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Insights.Models.DiagnosticSettingsResource>> CreateOrUpdateAsync(string resourceUri, string name, Azure.ResourceManager.Insights.Models.DiagnosticSettingsResource parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string resourceUri, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string resourceUri, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Insights.Models.DiagnosticSettingsResource> Get(string resourceUri, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Insights.Models.DiagnosticSettingsResource>> GetAsync(string resourceUri, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Insights.Models.DiagnosticSettingsResourceCollection> List(string resourceUri, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Insights.Models.DiagnosticSettingsResourceCollection>> ListAsync(string resourceUri, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EventCategoriesOperations
    {
        protected EventCategoriesOperations() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Insights.Models.LocalizableString> List(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Insights.Models.LocalizableString> ListAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class InsightsManagementClient
    {
        protected InsightsManagementClient() { }
        public InsightsManagementClient(string subscriptionId, Azure.Core.TokenCredential tokenCredential, Azure.ResourceManager.Insights.InsightsManagementClientOptions options = null) { }
        public InsightsManagementClient(string subscriptionId, System.Uri endpoint, Azure.Core.TokenCredential tokenCredential, Azure.ResourceManager.Insights.InsightsManagementClientOptions options = null) { }
        public virtual Azure.ResourceManager.Insights.ActionGroupsOperations ActionGroups { get { throw null; } }
        public virtual Azure.ResourceManager.Insights.ActivityLogAlertsOperations ActivityLogAlerts { get { throw null; } }
        public virtual Azure.ResourceManager.Insights.ActivityLogsOperations ActivityLogs { get { throw null; } }
        public virtual Azure.ResourceManager.Insights.AlertRuleIncidentsOperations AlertRuleIncidents { get { throw null; } }
        public virtual Azure.ResourceManager.Insights.AlertRulesOperations AlertRules { get { throw null; } }
        public virtual Azure.ResourceManager.Insights.AutoscaleSettingsOperations AutoscaleSettings { get { throw null; } }
        public virtual Azure.ResourceManager.Insights.BaselinesOperations Baselines { get { throw null; } }
        public virtual Azure.ResourceManager.Insights.DiagnosticSettingsOperations DiagnosticSettings { get { throw null; } }
        public virtual Azure.ResourceManager.Insights.DiagnosticSettingsCategoryOperations DiagnosticSettingsCategory { get { throw null; } }
        public virtual Azure.ResourceManager.Insights.EventCategoriesOperations EventCategories { get { throw null; } }
        public virtual Azure.ResourceManager.Insights.LogProfilesOperations LogProfiles { get { throw null; } }
        public virtual Azure.ResourceManager.Insights.MetricAlertsOperations MetricAlerts { get { throw null; } }
        public virtual Azure.ResourceManager.Insights.MetricAlertsStatusOperations MetricAlertsStatus { get { throw null; } }
        public virtual Azure.ResourceManager.Insights.MetricBaselineOperations MetricBaseline { get { throw null; } }
        public virtual Azure.ResourceManager.Insights.MetricDefinitionsOperations MetricDefinitions { get { throw null; } }
        public virtual Azure.ResourceManager.Insights.MetricNamespacesOperations MetricNamespaces { get { throw null; } }
        public virtual Azure.ResourceManager.Insights.MetricsOperations Metrics { get { throw null; } }
        public virtual Azure.ResourceManager.Insights.Operations Operations { get { throw null; } }
        public virtual Azure.ResourceManager.Insights.ScheduledQueryRulesOperations ScheduledQueryRules { get { throw null; } }
        public virtual Azure.ResourceManager.Insights.TenantActivityLogsOperations TenantActivityLogs { get { throw null; } }
        public virtual Azure.ResourceManager.Insights.VMInsightsOperations VMInsights { get { throw null; } }
    }
    public partial class InsightsManagementClientOptions : Azure.Core.ClientOptions
    {
        public InsightsManagementClientOptions() { }
    }
    public partial class LogProfilesOperations
    {
        protected LogProfilesOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Insights.Models.LogProfileResource> CreateOrUpdate(string logProfileName, Azure.ResourceManager.Insights.Models.LogProfileResource parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Insights.Models.LogProfileResource>> CreateOrUpdateAsync(string logProfileName, Azure.ResourceManager.Insights.Models.LogProfileResource parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string logProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string logProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Insights.Models.LogProfileResource> Get(string logProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Insights.Models.LogProfileResource>> GetAsync(string logProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Insights.Models.LogProfileResource> List(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Insights.Models.LogProfileResource> ListAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Insights.Models.LogProfileResource> Update(string logProfileName, Azure.ResourceManager.Insights.Models.LogProfileResourcePatch logProfilesResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Insights.Models.LogProfileResource>> UpdateAsync(string logProfileName, Azure.ResourceManager.Insights.Models.LogProfileResourcePatch logProfilesResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MetricAlertsOperations
    {
        protected MetricAlertsOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Insights.Models.MetricAlertResource> CreateOrUpdate(string resourceGroupName, string ruleName, Azure.ResourceManager.Insights.Models.MetricAlertResource parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Insights.Models.MetricAlertResource>> CreateOrUpdateAsync(string resourceGroupName, string ruleName, Azure.ResourceManager.Insights.Models.MetricAlertResource parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string resourceGroupName, string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string resourceGroupName, string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Insights.Models.MetricAlertResource> Get(string resourceGroupName, string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Insights.Models.MetricAlertResource>> GetAsync(string resourceGroupName, string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Insights.Models.MetricAlertResource> ListByResourceGroup(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Insights.Models.MetricAlertResource> ListByResourceGroupAsync(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Insights.Models.MetricAlertResource> ListBySubscription(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Insights.Models.MetricAlertResource> ListBySubscriptionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Insights.Models.MetricAlertResource> Update(string resourceGroupName, string ruleName, Azure.ResourceManager.Insights.Models.MetricAlertResourcePatch parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Insights.Models.MetricAlertResource>> UpdateAsync(string resourceGroupName, string ruleName, Azure.ResourceManager.Insights.Models.MetricAlertResourcePatch parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MetricAlertsStatusOperations
    {
        protected MetricAlertsStatusOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Insights.Models.MetricAlertStatusCollection> List(string resourceGroupName, string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Insights.Models.MetricAlertStatusCollection>> ListAsync(string resourceGroupName, string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Insights.Models.MetricAlertStatusCollection> ListByName(string resourceGroupName, string ruleName, string statusName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Insights.Models.MetricAlertStatusCollection>> ListByNameAsync(string resourceGroupName, string ruleName, string statusName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MetricBaselineOperations
    {
        protected MetricBaselineOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Insights.Models.CalculateBaselineResponse> CalculateBaseline(string resourceUri, Azure.ResourceManager.Insights.Models.TimeSeriesInformation timeSeriesInformation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Insights.Models.CalculateBaselineResponse>> CalculateBaselineAsync(string resourceUri, Azure.ResourceManager.Insights.Models.TimeSeriesInformation timeSeriesInformation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Insights.Models.BaselineResponse> Get(string resourceUri, string metricName, string timespan = null, System.TimeSpan? interval = default(System.TimeSpan?), string aggregation = null, string sensitivities = null, Azure.ResourceManager.Insights.Models.ResultType? resultType = default(Azure.ResourceManager.Insights.Models.ResultType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Insights.Models.BaselineResponse>> GetAsync(string resourceUri, string metricName, string timespan = null, System.TimeSpan? interval = default(System.TimeSpan?), string aggregation = null, string sensitivities = null, Azure.ResourceManager.Insights.Models.ResultType? resultType = default(Azure.ResourceManager.Insights.Models.ResultType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MetricDefinitionsOperations
    {
        protected MetricDefinitionsOperations() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Insights.Models.MetricDefinition> List(string resourceUri, string metricnamespace = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Insights.Models.MetricDefinition> ListAsync(string resourceUri, string metricnamespace = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MetricNamespacesOperations
    {
        protected MetricNamespacesOperations() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Insights.Models.MetricNamespace> List(string resourceUri, string startTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Insights.Models.MetricNamespace> ListAsync(string resourceUri, string startTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MetricsOperations
    {
        protected MetricsOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Insights.Models.Response> List(string resourceUri, string timespan = null, System.TimeSpan? interval = default(System.TimeSpan?), string metricnames = null, string aggregation = null, int? top = default(int?), string orderby = null, string filter = null, Azure.ResourceManager.Insights.Models.ResultType? resultType = default(Azure.ResourceManager.Insights.Models.ResultType?), string metricnamespace = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Insights.Models.Response>> ListAsync(string resourceUri, string timespan = null, System.TimeSpan? interval = default(System.TimeSpan?), string metricnames = null, string aggregation = null, int? top = default(int?), string orderby = null, string filter = null, Azure.ResourceManager.Insights.Models.ResultType? resultType = default(Azure.ResourceManager.Insights.Models.ResultType?), string metricnamespace = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class Operations
    {
        protected Operations() { }
        public virtual Azure.Response<Azure.ResourceManager.Insights.Models.OperationListResult> List(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Insights.Models.OperationListResult>> ListAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ScheduledQueryRulesOperations
    {
        protected ScheduledQueryRulesOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Insights.Models.LogSearchRuleResource> CreateOrUpdate(string resourceGroupName, string ruleName, Azure.ResourceManager.Insights.Models.LogSearchRuleResource parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Insights.Models.LogSearchRuleResource>> CreateOrUpdateAsync(string resourceGroupName, string ruleName, Azure.ResourceManager.Insights.Models.LogSearchRuleResource parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string resourceGroupName, string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string resourceGroupName, string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Insights.Models.LogSearchRuleResource> Get(string resourceGroupName, string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Insights.Models.LogSearchRuleResource>> GetAsync(string resourceGroupName, string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Insights.Models.LogSearchRuleResource> ListByResourceGroup(string resourceGroupName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Insights.Models.LogSearchRuleResource> ListByResourceGroupAsync(string resourceGroupName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Insights.Models.LogSearchRuleResource> ListBySubscription(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Insights.Models.LogSearchRuleResource> ListBySubscriptionAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Insights.Models.LogSearchRuleResource> Update(string resourceGroupName, string ruleName, Azure.ResourceManager.Insights.Models.LogSearchRuleResourcePatch parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Insights.Models.LogSearchRuleResource>> UpdateAsync(string resourceGroupName, string ruleName, Azure.ResourceManager.Insights.Models.LogSearchRuleResourcePatch parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TenantActivityLogsOperations
    {
        protected TenantActivityLogsOperations() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Insights.Models.EventData> List(string filter = null, string select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Insights.Models.EventData> ListAsync(string filter = null, string select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VMInsightsOperations
    {
        protected VMInsightsOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Insights.Models.VMInsightsOnboardingStatus> GetOnboardingStatus(string resourceUri, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Insights.Models.VMInsightsOnboardingStatus>> GetOnboardingStatusAsync(string resourceUri, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Insights.Models
{
    public partial class Action
    {
        public Action() { }
    }
    public partial class ActionGroupPatchBody
    {
        public ActionGroupPatchBody() { }
        public bool? Enabled { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class ActionGroupResource : Azure.ResourceManager.Insights.Models.Resource
    {
        public ActionGroupResource(string location) : base (default(string)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Insights.Models.ArmRoleReceiver> ArmRoleReceivers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Insights.Models.AutomationRunbookReceiver> AutomationRunbookReceivers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Insights.Models.AzureAppPushReceiver> AzureAppPushReceivers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Insights.Models.AzureFunctionReceiver> AzureFunctionReceivers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Insights.Models.EmailReceiver> EmailReceivers { get { throw null; } }
        public bool? Enabled { get { throw null; } set { } }
        public string GroupShortName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Insights.Models.ItsmReceiver> ItsmReceivers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Insights.Models.LogicAppReceiver> LogicAppReceivers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Insights.Models.SmsReceiver> SmsReceivers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Insights.Models.VoiceReceiver> VoiceReceivers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Insights.Models.WebhookReceiver> WebhookReceivers { get { throw null; } }
    }
    public partial class ActivityLogAlertActionGroup
    {
        public ActivityLogAlertActionGroup(string actionGroupId) { }
        public string ActionGroupId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> WebhookProperties { get { throw null; } }
    }
    public partial class ActivityLogAlertActionList
    {
        public ActivityLogAlertActionList() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Insights.Models.ActivityLogAlertActionGroup> ActionGroups { get { throw null; } }
    }
    public partial class ActivityLogAlertAllOfCondition
    {
        public ActivityLogAlertAllOfCondition(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Insights.Models.ActivityLogAlertLeafCondition> allOf) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Insights.Models.ActivityLogAlertLeafCondition> AllOf { get { throw null; } }
    }
    public partial class ActivityLogAlertLeafCondition
    {
        public ActivityLogAlertLeafCondition(string field, string equalsValue) { }
        public string EqualsValue { get { throw null; } set { } }
        public string Field { get { throw null; } set { } }
    }
    public partial class ActivityLogAlertPatchBody
    {
        public ActivityLogAlertPatchBody() { }
        public bool? Enabled { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class ActivityLogAlertResource : Azure.ResourceManager.Insights.Models.Resource
    {
        public ActivityLogAlertResource(string location) : base (default(string)) { }
        public Azure.ResourceManager.Insights.Models.ActivityLogAlertActionList Actions { get { throw null; } set { } }
        public Azure.ResourceManager.Insights.Models.ActivityLogAlertAllOfCondition Condition { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Scopes { get { throw null; } }
    }
    public enum AggregationType
    {
        None = 0,
        Average = 1,
        Count = 2,
        Minimum = 3,
        Maximum = 4,
        Total = 5,
    }
    public partial class AlertingAction : Azure.ResourceManager.Insights.Models.Action
    {
        public AlertingAction(Azure.ResourceManager.Insights.Models.AlertSeverity severity, Azure.ResourceManager.Insights.Models.TriggerCondition trigger) { }
        public Azure.ResourceManager.Insights.Models.AzNsActionGroup AznsAction { get { throw null; } set { } }
        public Azure.ResourceManager.Insights.Models.AlertSeverity Severity { get { throw null; } set { } }
        public int? ThrottlingInMin { get { throw null; } set { } }
        public Azure.ResourceManager.Insights.Models.TriggerCondition Trigger { get { throw null; } set { } }
    }
    public partial class AlertRuleResource : Azure.ResourceManager.Insights.Models.Resource
    {
        public AlertRuleResource(string location, string namePropertiesName, bool isEnabled, Azure.ResourceManager.Insights.Models.RuleCondition condition) : base (default(string)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Insights.Models.RuleAction> Actions { get { throw null; } }
        public Azure.ResourceManager.Insights.Models.RuleCondition Condition { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public bool IsEnabled { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdatedTime { get { throw null; } }
        public string NamePropertiesName { get { throw null; } set { } }
    }
    public partial class AlertRuleResourcePatch
    {
        public AlertRuleResourcePatch() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Insights.Models.RuleAction> Actions { get { throw null; } }
        public Azure.ResourceManager.Insights.Models.RuleCondition Condition { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdatedTime { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AlertSeverity : System.IEquatable<Azure.ResourceManager.Insights.Models.AlertSeverity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AlertSeverity(string value) { throw null; }
        public static Azure.ResourceManager.Insights.Models.AlertSeverity Four { get { throw null; } }
        public static Azure.ResourceManager.Insights.Models.AlertSeverity One { get { throw null; } }
        public static Azure.ResourceManager.Insights.Models.AlertSeverity Three { get { throw null; } }
        public static Azure.ResourceManager.Insights.Models.AlertSeverity Two { get { throw null; } }
        public static Azure.ResourceManager.Insights.Models.AlertSeverity Zero { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Insights.Models.AlertSeverity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Insights.Models.AlertSeverity left, Azure.ResourceManager.Insights.Models.AlertSeverity right) { throw null; }
        public static implicit operator Azure.ResourceManager.Insights.Models.AlertSeverity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Insights.Models.AlertSeverity left, Azure.ResourceManager.Insights.Models.AlertSeverity right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ArmRoleReceiver
    {
        public ArmRoleReceiver(string name, string roleId, bool useCommonAlertSchema) { }
        public string Name { get { throw null; } set { } }
        public string RoleId { get { throw null; } set { } }
        public bool UseCommonAlertSchema { get { throw null; } set { } }
    }
    public partial class AutomationRunbookReceiver
    {
        public AutomationRunbookReceiver(string automationAccountId, string runbookName, string webhookResourceId, bool isGlobalRunbook, bool useCommonAlertSchema) { }
        public string AutomationAccountId { get { throw null; } set { } }
        public bool IsGlobalRunbook { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string RunbookName { get { throw null; } set { } }
        public string ServiceUri { get { throw null; } set { } }
        public bool UseCommonAlertSchema { get { throw null; } set { } }
        public string WebhookResourceId { get { throw null; } set { } }
    }
    public partial class AutoscaleNotification
    {
        public AutoscaleNotification() { }
        public Azure.ResourceManager.Insights.Models.EmailNotification Email { get { throw null; } set { } }
        public string Operation { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Insights.Models.WebhookNotification> Webhooks { get { throw null; } }
    }
    public partial class AutoscaleProfile
    {
        public AutoscaleProfile(string name, Azure.ResourceManager.Insights.Models.ScaleCapacity capacity, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Insights.Models.ScaleRule> rules) { }
        public Azure.ResourceManager.Insights.Models.ScaleCapacity Capacity { get { throw null; } set { } }
        public Azure.ResourceManager.Insights.Models.TimeWindow FixedDate { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Insights.Models.Recurrence Recurrence { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Insights.Models.ScaleRule> Rules { get { throw null; } }
    }
    public partial class AutoscaleSettingResource : Azure.ResourceManager.Insights.Models.Resource
    {
        public AutoscaleSettingResource(string location, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Insights.Models.AutoscaleProfile> profiles) : base (default(string)) { }
        public bool? Enabled { get { throw null; } set { } }
        public string NamePropertiesName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Insights.Models.AutoscaleNotification> Notifications { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Insights.Models.AutoscaleProfile> Profiles { get { throw null; } }
        public string TargetResourceUri { get { throw null; } set { } }
    }
    public partial class AutoscaleSettingResourcePatch
    {
        public AutoscaleSettingResourcePatch() { }
        public bool? Enabled { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Insights.Models.AutoscaleNotification> Notifications { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Insights.Models.AutoscaleProfile> Profiles { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string TargetResourceUri { get { throw null; } set { } }
    }
    public partial class AzNsActionGroup
    {
        public AzNsActionGroup() { }
        public System.Collections.Generic.IList<string> ActionGroup { get { throw null; } }
        public string CustomWebhookPayload { get { throw null; } set { } }
        public string EmailSubject { get { throw null; } set { } }
    }
    public partial class AzureAppPushReceiver
    {
        public AzureAppPushReceiver(string name, string emailAddress) { }
        public string EmailAddress { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class AzureFunctionReceiver
    {
        public AzureFunctionReceiver(string name, string functionAppResourceId, string functionName, string httpTriggerUrl, bool useCommonAlertSchema) { }
        public string FunctionAppResourceId { get { throw null; } set { } }
        public string FunctionName { get { throw null; } set { } }
        public string HttpTriggerUrl { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public bool UseCommonAlertSchema { get { throw null; } set { } }
    }
    public partial class Baseline
    {
        internal Baseline() { }
        public System.Collections.Generic.IReadOnlyList<double> HighThresholds { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<double> LowThresholds { get { throw null; } }
        public Azure.ResourceManager.Insights.Models.Sensitivity Sensitivity { get { throw null; } }
    }
    public partial class BaselineMetadata
    {
        internal BaselineMetadata() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class BaselineMetadataValue
    {
        internal BaselineMetadataValue() { }
        public Azure.ResourceManager.Insights.Models.LocalizableString Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class BaselineResponse
    {
        internal BaselineResponse() { }
        public string Aggregation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Insights.Models.Baseline> Baseline { get { throw null; } }
        public string Id { get { throw null; } }
        public System.TimeSpan? Interval { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Insights.Models.BaselineMetadataValue> Metadata { get { throw null; } }
        public Azure.ResourceManager.Insights.Models.LocalizableString Name { get { throw null; } }
        public string Timespan { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.DateTimeOffset> Timestamps { get { throw null; } }
        public string Type { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BaselineSensitivity : System.IEquatable<Azure.ResourceManager.Insights.Models.BaselineSensitivity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BaselineSensitivity(string value) { throw null; }
        public static Azure.ResourceManager.Insights.Models.BaselineSensitivity High { get { throw null; } }
        public static Azure.ResourceManager.Insights.Models.BaselineSensitivity Low { get { throw null; } }
        public static Azure.ResourceManager.Insights.Models.BaselineSensitivity Medium { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Insights.Models.BaselineSensitivity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Insights.Models.BaselineSensitivity left, Azure.ResourceManager.Insights.Models.BaselineSensitivity right) { throw null; }
        public static implicit operator Azure.ResourceManager.Insights.Models.BaselineSensitivity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Insights.Models.BaselineSensitivity left, Azure.ResourceManager.Insights.Models.BaselineSensitivity right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CalculateBaselineResponse
    {
        internal CalculateBaselineResponse() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Insights.Models.Baseline> Baseline { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.DateTimeOffset> Timestamps { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public enum CategoryType
    {
        Metrics = 0,
        Logs = 1,
    }
    public enum ComparisonOperationType
    {
        EqualsValue = 0,
        NotEquals = 1,
        GreaterThan = 2,
        GreaterThanOrEqual = 3,
        LessThan = 4,
        LessThanOrEqual = 5,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConditionalOperator : System.IEquatable<Azure.ResourceManager.Insights.Models.ConditionalOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConditionalOperator(string value) { throw null; }
        public static Azure.ResourceManager.Insights.Models.ConditionalOperator Equal { get { throw null; } }
        public static Azure.ResourceManager.Insights.Models.ConditionalOperator GreaterThan { get { throw null; } }
        public static Azure.ResourceManager.Insights.Models.ConditionalOperator LessThan { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Insights.Models.ConditionalOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Insights.Models.ConditionalOperator left, Azure.ResourceManager.Insights.Models.ConditionalOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.Insights.Models.ConditionalOperator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Insights.Models.ConditionalOperator left, Azure.ResourceManager.Insights.Models.ConditionalOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum ConditionOperator
    {
        GreaterThan = 0,
        GreaterThanOrEqual = 1,
        LessThan = 2,
        LessThanOrEqual = 3,
    }
    public partial class Criteria
    {
        public Criteria(string metricName) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Insights.Models.Dimension> Dimensions { get { throw null; } }
        public string MetricName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CriterionType : System.IEquatable<Azure.ResourceManager.Insights.Models.CriterionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CriterionType(string value) { throw null; }
        public static Azure.ResourceManager.Insights.Models.CriterionType DynamicThresholdCriterion { get { throw null; } }
        public static Azure.ResourceManager.Insights.Models.CriterionType StaticThresholdCriterion { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Insights.Models.CriterionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Insights.Models.CriterionType left, Azure.ResourceManager.Insights.Models.CriterionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Insights.Models.CriterionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Insights.Models.CriterionType left, Azure.ResourceManager.Insights.Models.CriterionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataContainer
    {
        internal DataContainer() { }
        public Azure.ResourceManager.Insights.Models.WorkspaceInfo Workspace { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataStatus : System.IEquatable<Azure.ResourceManager.Insights.Models.DataStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataStatus(string value) { throw null; }
        public static Azure.ResourceManager.Insights.Models.DataStatus NotPresent { get { throw null; } }
        public static Azure.ResourceManager.Insights.Models.DataStatus Present { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Insights.Models.DataStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Insights.Models.DataStatus left, Azure.ResourceManager.Insights.Models.DataStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Insights.Models.DataStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Insights.Models.DataStatus left, Azure.ResourceManager.Insights.Models.DataStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiagnosticSettingsCategoryResource : Azure.ResourceManager.Insights.Models.ProxyOnlyResource
    {
        public DiagnosticSettingsCategoryResource() { }
        public Azure.ResourceManager.Insights.Models.CategoryType? CategoryType { get { throw null; } set { } }
    }
    public partial class DiagnosticSettingsCategoryResourceCollection
    {
        internal DiagnosticSettingsCategoryResourceCollection() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Insights.Models.DiagnosticSettingsCategoryResource> Value { get { throw null; } }
    }
    public partial class DiagnosticSettingsResource : Azure.ResourceManager.Insights.Models.ProxyOnlyResource
    {
        public DiagnosticSettingsResource() { }
        public string EventHubAuthorizationRuleId { get { throw null; } set { } }
        public string EventHubName { get { throw null; } set { } }
        public string LogAnalyticsDestinationType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Insights.Models.LogSettings> Logs { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Insights.Models.MetricSettings> Metrics { get { throw null; } }
        public string ServiceBusRuleId { get { throw null; } set { } }
        public string StorageAccountId { get { throw null; } set { } }
        public string WorkspaceId { get { throw null; } set { } }
    }
    public partial class DiagnosticSettingsResourceCollection
    {
        internal DiagnosticSettingsResourceCollection() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Insights.Models.DiagnosticSettingsResource> Value { get { throw null; } }
    }
    public partial class Dimension
    {
        public Dimension(string name, Azure.ResourceManager.Insights.Models.Operator @operator, System.Collections.Generic.IEnumerable<string> values) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Insights.Models.Operator Operator { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
    }
    public partial class DynamicMetricCriteria : Azure.ResourceManager.Insights.Models.MultiMetricCriteria
    {
        public DynamicMetricCriteria(string name, string metricName, Azure.ResourceManager.Insights.Models.AggregationType timeAggregation, Azure.ResourceManager.Insights.Models.DynamicThresholdOperator @operator, Azure.ResourceManager.Insights.Models.DynamicThresholdSensitivity alertSensitivity, Azure.ResourceManager.Insights.Models.DynamicThresholdFailingPeriods failingPeriods) : base (default(string), default(string), default(Azure.ResourceManager.Insights.Models.AggregationType)) { }
        public Azure.ResourceManager.Insights.Models.DynamicThresholdSensitivity AlertSensitivity { get { throw null; } set { } }
        public Azure.ResourceManager.Insights.Models.DynamicThresholdFailingPeriods FailingPeriods { get { throw null; } set { } }
        public System.DateTimeOffset? IgnoreDataBefore { get { throw null; } set { } }
        public Azure.ResourceManager.Insights.Models.DynamicThresholdOperator Operator { get { throw null; } set { } }
    }
    public partial class DynamicThresholdFailingPeriods
    {
        public DynamicThresholdFailingPeriods(float numberOfEvaluationPeriods, float minFailingPeriodsToAlert) { }
        public float MinFailingPeriodsToAlert { get { throw null; } set { } }
        public float NumberOfEvaluationPeriods { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DynamicThresholdOperator : System.IEquatable<Azure.ResourceManager.Insights.Models.DynamicThresholdOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DynamicThresholdOperator(string value) { throw null; }
        public static Azure.ResourceManager.Insights.Models.DynamicThresholdOperator GreaterOrLessThan { get { throw null; } }
        public static Azure.ResourceManager.Insights.Models.DynamicThresholdOperator GreaterThan { get { throw null; } }
        public static Azure.ResourceManager.Insights.Models.DynamicThresholdOperator LessThan { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Insights.Models.DynamicThresholdOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Insights.Models.DynamicThresholdOperator left, Azure.ResourceManager.Insights.Models.DynamicThresholdOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.Insights.Models.DynamicThresholdOperator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Insights.Models.DynamicThresholdOperator left, Azure.ResourceManager.Insights.Models.DynamicThresholdOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DynamicThresholdSensitivity : System.IEquatable<Azure.ResourceManager.Insights.Models.DynamicThresholdSensitivity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DynamicThresholdSensitivity(string value) { throw null; }
        public static Azure.ResourceManager.Insights.Models.DynamicThresholdSensitivity High { get { throw null; } }
        public static Azure.ResourceManager.Insights.Models.DynamicThresholdSensitivity Low { get { throw null; } }
        public static Azure.ResourceManager.Insights.Models.DynamicThresholdSensitivity Medium { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Insights.Models.DynamicThresholdSensitivity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Insights.Models.DynamicThresholdSensitivity left, Azure.ResourceManager.Insights.Models.DynamicThresholdSensitivity right) { throw null; }
        public static implicit operator Azure.ResourceManager.Insights.Models.DynamicThresholdSensitivity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Insights.Models.DynamicThresholdSensitivity left, Azure.ResourceManager.Insights.Models.DynamicThresholdSensitivity right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EmailNotification
    {
        public EmailNotification() { }
        public System.Collections.Generic.IList<string> CustomEmails { get { throw null; } }
        public bool? SendToSubscriptionAdministrator { get { throw null; } set { } }
        public bool? SendToSubscriptionCoAdministrators { get { throw null; } set { } }
    }
    public partial class EmailReceiver
    {
        public EmailReceiver(string name, string emailAddress, bool useCommonAlertSchema) { }
        public string EmailAddress { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Insights.Models.ReceiverStatus? Status { get { throw null; } }
        public bool UseCommonAlertSchema { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Enabled : System.IEquatable<Azure.ResourceManager.Insights.Models.Enabled>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Enabled(string value) { throw null; }
        public static Azure.ResourceManager.Insights.Models.Enabled False { get { throw null; } }
        public static Azure.ResourceManager.Insights.Models.Enabled True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Insights.Models.Enabled other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Insights.Models.Enabled left, Azure.ResourceManager.Insights.Models.Enabled right) { throw null; }
        public static implicit operator Azure.ResourceManager.Insights.Models.Enabled (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Insights.Models.Enabled left, Azure.ResourceManager.Insights.Models.Enabled right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EnableRequest
    {
        public EnableRequest(string receiverName) { }
        public string ReceiverName { get { throw null; } }
    }
    public partial class EventData
    {
        internal EventData() { }
        public Azure.ResourceManager.Insights.Models.SenderAuthorization Authorization { get { throw null; } }
        public string Caller { get { throw null; } }
        public Azure.ResourceManager.Insights.Models.LocalizableString Category { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Claims { get { throw null; } }
        public string CorrelationId { get { throw null; } }
        public string Description { get { throw null; } }
        public string EventDataId { get { throw null; } }
        public Azure.ResourceManager.Insights.Models.LocalizableString EventName { get { throw null; } }
        public System.DateTimeOffset? EventTimestamp { get { throw null; } }
        public Azure.ResourceManager.Insights.Models.HttpRequestInfo HttpRequest { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.ResourceManager.Insights.Models.EventLevel? Level { get { throw null; } }
        public string OperationId { get { throw null; } }
        public Azure.ResourceManager.Insights.Models.LocalizableString OperationName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Properties { get { throw null; } }
        public string ResourceGroupName { get { throw null; } }
        public string ResourceId { get { throw null; } }
        public Azure.ResourceManager.Insights.Models.LocalizableString ResourceProviderName { get { throw null; } }
        public Azure.ResourceManager.Insights.Models.LocalizableString ResourceType { get { throw null; } }
        public Azure.ResourceManager.Insights.Models.LocalizableString Status { get { throw null; } }
        public System.DateTimeOffset? SubmissionTimestamp { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        public Azure.ResourceManager.Insights.Models.LocalizableString SubStatus { get { throw null; } }
        public string TenantId { get { throw null; } }
    }
    public enum EventLevel
    {
        Critical = 0,
        Error = 1,
        Warning = 2,
        Informational = 3,
        Verbose = 4,
    }
    public partial class HttpRequestInfo
    {
        internal HttpRequestInfo() { }
        public string ClientIpAddress { get { throw null; } }
        public string ClientRequestId { get { throw null; } }
        public string Method { get { throw null; } }
        public string Uri { get { throw null; } }
    }
    public partial class Incident
    {
        internal Incident() { }
        public System.DateTimeOffset? ActivatedTime { get { throw null; } }
        public bool? IsActive { get { throw null; } }
        public string Name { get { throw null; } }
        public System.DateTimeOffset? ResolvedTime { get { throw null; } }
        public string RuleName { get { throw null; } }
    }
    public partial class ItsmReceiver
    {
        public ItsmReceiver(string name, string workspaceId, string connectionId, string ticketConfiguration, string region) { }
        public string ConnectionId { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Region { get { throw null; } set { } }
        public string TicketConfiguration { get { throw null; } set { } }
        public string WorkspaceId { get { throw null; } set { } }
    }
    public partial class LocalizableString
    {
        internal LocalizableString() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class LocationThresholdRuleCondition : Azure.ResourceManager.Insights.Models.RuleCondition
    {
        public LocationThresholdRuleCondition(int failedLocationCount) { }
        public int FailedLocationCount { get { throw null; } set { } }
        public System.TimeSpan? WindowSize { get { throw null; } set { } }
    }
    public partial class LogicAppReceiver
    {
        public LogicAppReceiver(string name, string resourceId, string callbackUrl, bool useCommonAlertSchema) { }
        public string CallbackUrl { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
        public bool UseCommonAlertSchema { get { throw null; } set { } }
    }
    public partial class LogMetricTrigger
    {
        public LogMetricTrigger() { }
        public string MetricColumn { get { throw null; } set { } }
        public Azure.ResourceManager.Insights.Models.MetricTriggerType? MetricTriggerType { get { throw null; } set { } }
        public double? Threshold { get { throw null; } set { } }
        public Azure.ResourceManager.Insights.Models.ConditionalOperator? ThresholdOperator { get { throw null; } set { } }
    }
    public partial class LogProfileResource : Azure.ResourceManager.Insights.Models.Resource
    {
        public LogProfileResource(string location, System.Collections.Generic.IEnumerable<string> locations, System.Collections.Generic.IEnumerable<string> categories, Azure.ResourceManager.Insights.Models.RetentionPolicy retentionPolicy) : base (default(string)) { }
        public System.Collections.Generic.IList<string> Categories { get { throw null; } }
        public System.Collections.Generic.IList<string> Locations { get { throw null; } }
        public Azure.ResourceManager.Insights.Models.RetentionPolicy RetentionPolicy { get { throw null; } set { } }
        public string ServiceBusRuleId { get { throw null; } set { } }
        public string StorageAccountId { get { throw null; } set { } }
    }
    public partial class LogProfileResourcePatch
    {
        public LogProfileResourcePatch() { }
        public System.Collections.Generic.IList<string> Categories { get { throw null; } }
        public System.Collections.Generic.IList<string> Locations { get { throw null; } }
        public Azure.ResourceManager.Insights.Models.RetentionPolicy RetentionPolicy { get { throw null; } set { } }
        public string ServiceBusRuleId { get { throw null; } set { } }
        public string StorageAccountId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class LogSearchRuleResource : Azure.ResourceManager.Insights.Models.Resource
    {
        public LogSearchRuleResource(string location, Azure.ResourceManager.Insights.Models.Source source, Azure.ResourceManager.Insights.Models.Action action) : base (default(string)) { }
        public Azure.ResourceManager.Insights.Models.Action Action { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Insights.Models.Enabled? Enabled { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdatedTime { get { throw null; } }
        public Azure.ResourceManager.Insights.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Insights.Models.Schedule Schedule { get { throw null; } set { } }
        public Azure.ResourceManager.Insights.Models.Source Source { get { throw null; } set { } }
    }
    public partial class LogSearchRuleResourcePatch
    {
        public LogSearchRuleResourcePatch() { }
        public Azure.ResourceManager.Insights.Models.Enabled? Enabled { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class LogSettings
    {
        public LogSettings(bool enabled) { }
        public string Category { get { throw null; } set { } }
        public bool Enabled { get { throw null; } set { } }
        public Azure.ResourceManager.Insights.Models.RetentionPolicy RetentionPolicy { get { throw null; } set { } }
    }
    public partial class LogToMetricAction : Azure.ResourceManager.Insights.Models.Action
    {
        public LogToMetricAction(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Insights.Models.Criteria> criteria) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Insights.Models.Criteria> Criteria { get { throw null; } }
    }
    public partial class ManagementEventAggregationCondition
    {
        public ManagementEventAggregationCondition() { }
        public Azure.ResourceManager.Insights.Models.ConditionOperator? Operator { get { throw null; } set { } }
        public double? Threshold { get { throw null; } set { } }
        public System.TimeSpan? WindowSize { get { throw null; } set { } }
    }
    public partial class ManagementEventRuleCondition : Azure.ResourceManager.Insights.Models.RuleCondition
    {
        public ManagementEventRuleCondition() { }
        public Azure.ResourceManager.Insights.Models.ManagementEventAggregationCondition Aggregation { get { throw null; } set { } }
    }
    public partial class MetadataValue
    {
        internal MetadataValue() { }
        public Azure.ResourceManager.Insights.Models.LocalizableString Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class Metric
    {
        internal Metric() { }
        public string Id { get { throw null; } }
        public Azure.ResourceManager.Insights.Models.LocalizableString Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Insights.Models.TimeSeriesElement> Timeseries { get { throw null; } }
        public string Type { get { throw null; } }
        public Azure.ResourceManager.Insights.Models.Unit Unit { get { throw null; } }
    }
    public partial class MetricAlertAction
    {
        public MetricAlertAction() { }
        public string ActionGroupId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> WebHookProperties { get { throw null; } }
    }
    public partial class MetricAlertCriteria : System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.Generic.IDictionary<string, object>, System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.IEnumerable
    {
        public MetricAlertCriteria() { }
        public object this[string key] { get { throw null; } set { } }
        public System.Collections.Generic.ICollection<string> Keys { get { throw null; } }
        int System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Count { get { throw null; } }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.IsReadOnly { get { throw null; } }
        public System.Collections.Generic.ICollection<object> Values { get { throw null; } }
        public void Add(string key, object value) { }
        public bool ContainsKey(string key) { throw null; }
        public System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, object>> GetEnumerator() { throw null; }
        public bool Remove(string key) { throw null; }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Add(System.Collections.Generic.KeyValuePair<string, object> value) { }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Clear() { }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Contains(System.Collections.Generic.KeyValuePair<string, object> value) { throw null; }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.CopyTo(System.Collections.Generic.KeyValuePair<string, object>[] destination, int offset) { }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Remove(System.Collections.Generic.KeyValuePair<string, object> value) { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        public bool TryGetValue(string key, out object value) { throw null; }
    }
    public partial class MetricAlertMultipleResourceMultipleMetricCriteria : Azure.ResourceManager.Insights.Models.MetricAlertCriteria
    {
        public MetricAlertMultipleResourceMultipleMetricCriteria() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Insights.Models.MultiMetricCriteria> AllOf { get { throw null; } }
    }
    public partial class MetricAlertResource : Azure.ResourceManager.Insights.Models.Resource
    {
        public MetricAlertResource(string location, string description, int severity, bool enabled, System.TimeSpan evaluationFrequency, System.TimeSpan windowSize, Azure.ResourceManager.Insights.Models.MetricAlertCriteria criteria) : base (default(string)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Insights.Models.MetricAlertAction> Actions { get { throw null; } }
        public bool? AutoMitigate { get { throw null; } set { } }
        public Azure.ResourceManager.Insights.Models.MetricAlertCriteria Criteria { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public bool Enabled { get { throw null; } set { } }
        public System.TimeSpan EvaluationFrequency { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdatedTime { get { throw null; } }
        public System.Collections.Generic.IList<string> Scopes { get { throw null; } }
        public int Severity { get { throw null; } set { } }
        public string TargetResourceRegion { get { throw null; } set { } }
        public string TargetResourceType { get { throw null; } set { } }
        public System.TimeSpan WindowSize { get { throw null; } set { } }
    }
    public partial class MetricAlertResourcePatch
    {
        public MetricAlertResourcePatch() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Insights.Models.MetricAlertAction> Actions { get { throw null; } }
        public bool? AutoMitigate { get { throw null; } set { } }
        public Azure.ResourceManager.Insights.Models.MetricAlertCriteria Criteria { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
        public System.TimeSpan? EvaluationFrequency { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdatedTime { get { throw null; } }
        public System.Collections.Generic.IList<string> Scopes { get { throw null; } }
        public int? Severity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string TargetResourceRegion { get { throw null; } set { } }
        public string TargetResourceType { get { throw null; } set { } }
        public System.TimeSpan? WindowSize { get { throw null; } set { } }
    }
    public partial class MetricAlertSingleResourceMultipleMetricCriteria : Azure.ResourceManager.Insights.Models.MetricAlertCriteria
    {
        public MetricAlertSingleResourceMultipleMetricCriteria() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Insights.Models.MetricCriteria> AllOf { get { throw null; } }
    }
    public partial class MetricAlertStatus
    {
        internal MetricAlertStatus() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Insights.Models.MetricAlertStatusProperties Properties { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public partial class MetricAlertStatusCollection
    {
        internal MetricAlertStatusCollection() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Insights.Models.MetricAlertStatus> Value { get { throw null; } }
    }
    public partial class MetricAlertStatusProperties
    {
        internal MetricAlertStatusProperties() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Dimensions { get { throw null; } }
        public string Status { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
    }
    public partial class MetricAvailability
    {
        internal MetricAvailability() { }
        public System.TimeSpan? Retention { get { throw null; } }
        public System.TimeSpan? TimeGrain { get { throw null; } }
    }
    public partial class MetricCriteria : Azure.ResourceManager.Insights.Models.MultiMetricCriteria
    {
        public MetricCriteria(string name, string metricName, Azure.ResourceManager.Insights.Models.AggregationType timeAggregation, Azure.ResourceManager.Insights.Models.Operator @operator, double threshold) : base (default(string), default(string), default(Azure.ResourceManager.Insights.Models.AggregationType)) { }
        public Azure.ResourceManager.Insights.Models.Operator Operator { get { throw null; } set { } }
        public double Threshold { get { throw null; } set { } }
    }
    public partial class MetricDefinition
    {
        internal MetricDefinition() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Insights.Models.LocalizableString> Dimensions { get { throw null; } }
        public string Id { get { throw null; } }
        public bool? IsDimensionRequired { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Insights.Models.MetricAvailability> MetricAvailabilities { get { throw null; } }
        public Azure.ResourceManager.Insights.Models.LocalizableString Name { get { throw null; } }
        public string Namespace { get { throw null; } }
        public Azure.ResourceManager.Insights.Models.AggregationType? PrimaryAggregationType { get { throw null; } }
        public string ResourceId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Insights.Models.AggregationType> SupportedAggregationTypes { get { throw null; } }
        public Azure.ResourceManager.Insights.Models.Unit? Unit { get { throw null; } }
    }
    public partial class MetricDimension
    {
        public MetricDimension(string name, string @operator, System.Collections.Generic.IEnumerable<string> values) { }
        public string Name { get { throw null; } set { } }
        public string Operator { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
    }
    public partial class MetricNamespace
    {
        internal MetricNamespace() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Insights.Models.MetricNamespaceName Properties { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public partial class MetricNamespaceName
    {
        internal MetricNamespaceName() { }
        public string MetricNamespaceNameValue { get { throw null; } }
    }
    public partial class MetricSettings
    {
        public MetricSettings(bool enabled) { }
        public string Category { get { throw null; } set { } }
        public bool Enabled { get { throw null; } set { } }
        public Azure.ResourceManager.Insights.Models.RetentionPolicy RetentionPolicy { get { throw null; } set { } }
        public System.TimeSpan? TimeGrain { get { throw null; } set { } }
    }
    public partial class MetricSingleDimension
    {
        internal MetricSingleDimension() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public enum MetricStatisticType
    {
        Average = 0,
        Min = 1,
        Max = 2,
        Sum = 3,
    }
    public partial class MetricTrigger
    {
        public MetricTrigger(string metricName, string metricResourceUri, System.TimeSpan timeGrain, Azure.ResourceManager.Insights.Models.MetricStatisticType statistic, System.TimeSpan timeWindow, Azure.ResourceManager.Insights.Models.TimeAggregationType timeAggregation, Azure.ResourceManager.Insights.Models.ComparisonOperationType @operator, double threshold) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Insights.Models.ScaleRuleMetricDimension> Dimensions { get { throw null; } }
        public string MetricName { get { throw null; } set { } }
        public string MetricNamespace { get { throw null; } set { } }
        public string MetricResourceUri { get { throw null; } set { } }
        public Azure.ResourceManager.Insights.Models.ComparisonOperationType Operator { get { throw null; } set { } }
        public Azure.ResourceManager.Insights.Models.MetricStatisticType Statistic { get { throw null; } set { } }
        public double Threshold { get { throw null; } set { } }
        public Azure.ResourceManager.Insights.Models.TimeAggregationType TimeAggregation { get { throw null; } set { } }
        public System.TimeSpan TimeGrain { get { throw null; } set { } }
        public System.TimeSpan TimeWindow { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MetricTriggerType : System.IEquatable<Azure.ResourceManager.Insights.Models.MetricTriggerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MetricTriggerType(string value) { throw null; }
        public static Azure.ResourceManager.Insights.Models.MetricTriggerType Consecutive { get { throw null; } }
        public static Azure.ResourceManager.Insights.Models.MetricTriggerType Total { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Insights.Models.MetricTriggerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Insights.Models.MetricTriggerType left, Azure.ResourceManager.Insights.Models.MetricTriggerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Insights.Models.MetricTriggerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Insights.Models.MetricTriggerType left, Azure.ResourceManager.Insights.Models.MetricTriggerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MetricValue
    {
        internal MetricValue() { }
        public double? Average { get { throw null; } }
        public double? Count { get { throw null; } }
        public double? Maximum { get { throw null; } }
        public double? Minimum { get { throw null; } }
        public System.DateTimeOffset TimeStamp { get { throw null; } }
        public double? Total { get { throw null; } }
    }
    public partial class MultiMetricCriteria : System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.Generic.IDictionary<string, object>, System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.IEnumerable
    {
        public MultiMetricCriteria(string name, string metricName, Azure.ResourceManager.Insights.Models.AggregationType timeAggregation) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Insights.Models.MetricDimension> Dimensions { get { throw null; } }
        public object this[string key] { get { throw null; } set { } }
        public System.Collections.Generic.ICollection<string> Keys { get { throw null; } }
        public string MetricName { get { throw null; } set { } }
        public string MetricNamespace { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        int System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Count { get { throw null; } }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.IsReadOnly { get { throw null; } }
        public Azure.ResourceManager.Insights.Models.AggregationType TimeAggregation { get { throw null; } set { } }
        public System.Collections.Generic.ICollection<object> Values { get { throw null; } }
        public void Add(string key, object value) { }
        public bool ContainsKey(string key) { throw null; }
        public System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, object>> GetEnumerator() { throw null; }
        public bool Remove(string key) { throw null; }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Add(System.Collections.Generic.KeyValuePair<string, object> value) { }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Clear() { }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Contains(System.Collections.Generic.KeyValuePair<string, object> value) { throw null; }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.CopyTo(System.Collections.Generic.KeyValuePair<string, object>[] destination, int offset) { }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Remove(System.Collections.Generic.KeyValuePair<string, object> value) { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        public bool TryGetValue(string key, out object value) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Odatatype : System.IEquatable<Azure.ResourceManager.Insights.Models.Odatatype>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Odatatype(string value) { throw null; }
        public static Azure.ResourceManager.Insights.Models.Odatatype MicrosoftAzureMonitorMultipleResourceMultipleMetricCriteria { get { throw null; } }
        public static Azure.ResourceManager.Insights.Models.Odatatype MicrosoftAzureMonitorSingleResourceMultipleMetricCriteria { get { throw null; } }
        public static Azure.ResourceManager.Insights.Models.Odatatype MicrosoftAzureMonitorWebtestLocationAvailabilityCriteria { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Insights.Models.Odatatype other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Insights.Models.Odatatype left, Azure.ResourceManager.Insights.Models.Odatatype right) { throw null; }
        public static implicit operator Azure.ResourceManager.Insights.Models.Odatatype (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Insights.Models.Odatatype left, Azure.ResourceManager.Insights.Models.Odatatype right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OnboardingStatus : System.IEquatable<Azure.ResourceManager.Insights.Models.OnboardingStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OnboardingStatus(string value) { throw null; }
        public static Azure.ResourceManager.Insights.Models.OnboardingStatus NotOnboarded { get { throw null; } }
        public static Azure.ResourceManager.Insights.Models.OnboardingStatus Onboarded { get { throw null; } }
        public static Azure.ResourceManager.Insights.Models.OnboardingStatus Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Insights.Models.OnboardingStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Insights.Models.OnboardingStatus left, Azure.ResourceManager.Insights.Models.OnboardingStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Insights.Models.OnboardingStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Insights.Models.OnboardingStatus left, Azure.ResourceManager.Insights.Models.OnboardingStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Operation
    {
        internal Operation() { }
        public Azure.ResourceManager.Insights.Models.OperationDisplay Display { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class OperationDisplay
    {
        internal OperationDisplay() { }
        public string Operation { get { throw null; } }
        public string Provider { get { throw null; } }
        public string Resource { get { throw null; } }
    }
    public partial class OperationListResult
    {
        internal OperationListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Insights.Models.Operation> Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Operator : System.IEquatable<Azure.ResourceManager.Insights.Models.Operator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Operator(string value) { throw null; }
        public static Azure.ResourceManager.Insights.Models.Operator EqualsValue { get { throw null; } }
        public static Azure.ResourceManager.Insights.Models.Operator GreaterThan { get { throw null; } }
        public static Azure.ResourceManager.Insights.Models.Operator GreaterThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.Insights.Models.Operator Include { get { throw null; } }
        public static Azure.ResourceManager.Insights.Models.Operator LessThan { get { throw null; } }
        public static Azure.ResourceManager.Insights.Models.Operator LessThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.Insights.Models.Operator NotEquals { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Insights.Models.Operator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Insights.Models.Operator left, Azure.ResourceManager.Insights.Models.Operator right) { throw null; }
        public static implicit operator Azure.ResourceManager.Insights.Models.Operator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Insights.Models.Operator left, Azure.ResourceManager.Insights.Models.Operator right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.Insights.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Insights.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Insights.Models.ProvisioningState Deploying { get { throw null; } }
        public static Azure.ResourceManager.Insights.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Insights.Models.ProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Insights.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Insights.Models.ProvisioningState left, Azure.ResourceManager.Insights.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Insights.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Insights.Models.ProvisioningState left, Azure.ResourceManager.Insights.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProxyOnlyResource
    {
        public ProxyOnlyResource() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public partial class ProxyResource
    {
        internal ProxyResource() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public string Type { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QueryType : System.IEquatable<Azure.ResourceManager.Insights.Models.QueryType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QueryType(string value) { throw null; }
        public static Azure.ResourceManager.Insights.Models.QueryType ResultCount { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Insights.Models.QueryType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Insights.Models.QueryType left, Azure.ResourceManager.Insights.Models.QueryType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Insights.Models.QueryType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Insights.Models.QueryType left, Azure.ResourceManager.Insights.Models.QueryType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum ReceiverStatus
    {
        NotSpecified = 0,
        Enabled = 1,
        Disabled = 2,
    }
    public partial class Recurrence
    {
        public Recurrence(Azure.ResourceManager.Insights.Models.RecurrenceFrequency frequency, Azure.ResourceManager.Insights.Models.RecurrentSchedule schedule) { }
        public Azure.ResourceManager.Insights.Models.RecurrenceFrequency Frequency { get { throw null; } set { } }
        public Azure.ResourceManager.Insights.Models.RecurrentSchedule Schedule { get { throw null; } set { } }
    }
    public enum RecurrenceFrequency
    {
        None = 0,
        Second = 1,
        Minute = 2,
        Hour = 3,
        Day = 4,
        Week = 5,
        Month = 6,
        Year = 7,
    }
    public partial class RecurrentSchedule
    {
        public RecurrentSchedule(string timeZone, System.Collections.Generic.IEnumerable<string> days, System.Collections.Generic.IEnumerable<int> hours, System.Collections.Generic.IEnumerable<int> minutes) { }
        public System.Collections.Generic.IList<string> Days { get { throw null; } }
        public System.Collections.Generic.IList<int> Hours { get { throw null; } }
        public System.Collections.Generic.IList<int> Minutes { get { throw null; } }
        public string TimeZone { get { throw null; } set { } }
    }
    public partial class Resource
    {
        public Resource(string location) { }
        public string Id { get { throw null; } }
        public string Location { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public partial class Response
    {
        internal Response() { }
        public int? Cost { get { throw null; } }
        public System.TimeSpan? Interval { get { throw null; } }
        public string Namespace { get { throw null; } }
        public string Resourceregion { get { throw null; } }
        public string Timespan { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Insights.Models.Metric> Value { get { throw null; } }
    }
    public enum ResultType
    {
        Data = 0,
        Metadata = 1,
    }
    public partial class RetentionPolicy
    {
        public RetentionPolicy(bool enabled, int days) { }
        public int Days { get { throw null; } set { } }
        public bool Enabled { get { throw null; } set { } }
    }
    public partial class RuleAction
    {
        public RuleAction() { }
    }
    public partial class RuleCondition
    {
        public RuleCondition() { }
        public Azure.ResourceManager.Insights.Models.RuleDataSource DataSource { get { throw null; } set { } }
    }
    public partial class RuleDataSource
    {
        public RuleDataSource() { }
        public string ResourceUri { get { throw null; } set { } }
    }
    public partial class RuleEmailAction : Azure.ResourceManager.Insights.Models.RuleAction
    {
        public RuleEmailAction() { }
        public System.Collections.Generic.IList<string> CustomEmails { get { throw null; } }
        public bool? SendToServiceOwners { get { throw null; } set { } }
    }
    public partial class RuleManagementEventClaimsDataSource
    {
        public RuleManagementEventClaimsDataSource() { }
        public string EmailAddress { get { throw null; } set { } }
    }
    public partial class RuleManagementEventDataSource : Azure.ResourceManager.Insights.Models.RuleDataSource
    {
        public RuleManagementEventDataSource() { }
        public Azure.ResourceManager.Insights.Models.RuleManagementEventClaimsDataSource Claims { get { throw null; } set { } }
        public string EventName { get { throw null; } set { } }
        public string EventSource { get { throw null; } set { } }
        public string Level { get { throw null; } set { } }
        public string OperationName { get { throw null; } set { } }
        public string ResourceGroupName { get { throw null; } set { } }
        public string ResourceProviderName { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
        public string SubStatus { get { throw null; } set { } }
    }
    public partial class RuleMetricDataSource : Azure.ResourceManager.Insights.Models.RuleDataSource
    {
        public RuleMetricDataSource() { }
        public string MetricName { get { throw null; } set { } }
    }
    public partial class RuleWebhookAction : Azure.ResourceManager.Insights.Models.RuleAction
    {
        public RuleWebhookAction() { }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public string ServiceUri { get { throw null; } set { } }
    }
    public partial class ScaleAction
    {
        public ScaleAction(Azure.ResourceManager.Insights.Models.ScaleDirection direction, Azure.ResourceManager.Insights.Models.ScaleType type, System.TimeSpan cooldown) { }
        public System.TimeSpan Cooldown { get { throw null; } set { } }
        public Azure.ResourceManager.Insights.Models.ScaleDirection Direction { get { throw null; } set { } }
        public Azure.ResourceManager.Insights.Models.ScaleType Type { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class ScaleCapacity
    {
        public ScaleCapacity(string minimum, string maximum, string @default) { }
        public string Default { get { throw null; } set { } }
        public string Maximum { get { throw null; } set { } }
        public string Minimum { get { throw null; } set { } }
    }
    public enum ScaleDirection
    {
        None = 0,
        Increase = 1,
        Decrease = 2,
    }
    public partial class ScaleRule
    {
        public ScaleRule(Azure.ResourceManager.Insights.Models.MetricTrigger metricTrigger, Azure.ResourceManager.Insights.Models.ScaleAction scaleAction) { }
        public Azure.ResourceManager.Insights.Models.MetricTrigger MetricTrigger { get { throw null; } set { } }
        public Azure.ResourceManager.Insights.Models.ScaleAction ScaleAction { get { throw null; } set { } }
    }
    public partial class ScaleRuleMetricDimension
    {
        public ScaleRuleMetricDimension(string dimensionName, Azure.ResourceManager.Insights.Models.ScaleRuleMetricDimensionOperationType @operator, System.Collections.Generic.IEnumerable<string> values) { }
        public string DimensionName { get { throw null; } set { } }
        public Azure.ResourceManager.Insights.Models.ScaleRuleMetricDimensionOperationType Operator { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScaleRuleMetricDimensionOperationType : System.IEquatable<Azure.ResourceManager.Insights.Models.ScaleRuleMetricDimensionOperationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScaleRuleMetricDimensionOperationType(string value) { throw null; }
        public static Azure.ResourceManager.Insights.Models.ScaleRuleMetricDimensionOperationType EqualsValue { get { throw null; } }
        public static Azure.ResourceManager.Insights.Models.ScaleRuleMetricDimensionOperationType NotEquals { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Insights.Models.ScaleRuleMetricDimensionOperationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Insights.Models.ScaleRuleMetricDimensionOperationType left, Azure.ResourceManager.Insights.Models.ScaleRuleMetricDimensionOperationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Insights.Models.ScaleRuleMetricDimensionOperationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Insights.Models.ScaleRuleMetricDimensionOperationType left, Azure.ResourceManager.Insights.Models.ScaleRuleMetricDimensionOperationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum ScaleType
    {
        ChangeCount = 0,
        PercentChangeCount = 1,
        ExactCount = 2,
    }
    public partial class Schedule
    {
        public Schedule(int frequencyInMinutes, int timeWindowInMinutes) { }
        public int FrequencyInMinutes { get { throw null; } set { } }
        public int TimeWindowInMinutes { get { throw null; } set { } }
    }
    public partial class SenderAuthorization
    {
        internal SenderAuthorization() { }
        public string Action { get { throw null; } }
        public string Role { get { throw null; } }
        public string Scope { get { throw null; } }
    }
    public enum Sensitivity
    {
        Low = 0,
        Medium = 1,
        High = 2,
    }
    public partial class SingleBaseline
    {
        internal SingleBaseline() { }
        public System.Collections.Generic.IReadOnlyList<double> HighThresholds { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<double> LowThresholds { get { throw null; } }
        public Azure.ResourceManager.Insights.Models.BaselineSensitivity Sensitivity { get { throw null; } }
    }
    public partial class SingleMetricBaseline
    {
        internal SingleMetricBaseline() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Insights.Models.TimeSeriesBaseline> Baselines { get { throw null; } }
        public string Id { get { throw null; } }
        public System.TimeSpan Interval { get { throw null; } }
        public string Name { get { throw null; } }
        public string Namespace { get { throw null; } }
        public string Timespan { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public partial class SmsReceiver
    {
        public SmsReceiver(string name, string countryCode, string phoneNumber) { }
        public string CountryCode { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string PhoneNumber { get { throw null; } set { } }
        public Azure.ResourceManager.Insights.Models.ReceiverStatus? Status { get { throw null; } }
    }
    public partial class Source
    {
        public Source(string dataSourceId) { }
        public System.Collections.Generic.IList<string> AuthorizedResources { get { throw null; } }
        public string DataSourceId { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        public Azure.ResourceManager.Insights.Models.QueryType? QueryType { get { throw null; } set { } }
    }
    public partial class ThresholdRuleCondition : Azure.ResourceManager.Insights.Models.RuleCondition
    {
        public ThresholdRuleCondition(Azure.ResourceManager.Insights.Models.ConditionOperator @operator, double threshold) { }
        public Azure.ResourceManager.Insights.Models.ConditionOperator Operator { get { throw null; } set { } }
        public double Threshold { get { throw null; } set { } }
        public Azure.ResourceManager.Insights.Models.TimeAggregationOperator? TimeAggregation { get { throw null; } set { } }
        public System.TimeSpan? WindowSize { get { throw null; } set { } }
    }
    public enum TimeAggregationOperator
    {
        Average = 0,
        Minimum = 1,
        Maximum = 2,
        Total = 3,
        Last = 4,
    }
    public enum TimeAggregationType
    {
        Average = 0,
        Minimum = 1,
        Maximum = 2,
        Total = 3,
        Count = 4,
        Last = 5,
    }
    public partial class TimeSeriesBaseline
    {
        internal TimeSeriesBaseline() { }
        public string Aggregation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Insights.Models.SingleBaseline> Data { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Insights.Models.MetricSingleDimension> Dimensions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Insights.Models.BaselineMetadata> Metadata { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.DateTimeOffset> Timestamps { get { throw null; } }
    }
    public partial class TimeSeriesElement
    {
        internal TimeSeriesElement() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Insights.Models.MetricValue> Data { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Insights.Models.MetadataValue> Metadatavalues { get { throw null; } }
    }
    public partial class TimeSeriesInformation
    {
        public TimeSeriesInformation(System.Collections.Generic.IEnumerable<string> sensitivities, System.Collections.Generic.IEnumerable<double> values) { }
        public System.Collections.Generic.IList<string> Sensitivities { get { throw null; } }
        public System.Collections.Generic.IList<System.DateTimeOffset> Timestamps { get { throw null; } }
        public System.Collections.Generic.IList<double> Values { get { throw null; } }
    }
    public partial class TimeWindow
    {
        public TimeWindow(System.DateTimeOffset start, System.DateTimeOffset end) { }
        public System.DateTimeOffset End { get { throw null; } set { } }
        public System.DateTimeOffset Start { get { throw null; } set { } }
        public string TimeZone { get { throw null; } set { } }
    }
    public partial class TriggerCondition
    {
        public TriggerCondition(Azure.ResourceManager.Insights.Models.ConditionalOperator thresholdOperator, double threshold) { }
        public Azure.ResourceManager.Insights.Models.LogMetricTrigger MetricTrigger { get { throw null; } set { } }
        public double Threshold { get { throw null; } set { } }
        public Azure.ResourceManager.Insights.Models.ConditionalOperator ThresholdOperator { get { throw null; } set { } }
    }
    public enum Unit
    {
        Count = 0,
        Bytes = 1,
        Seconds = 2,
        CountPerSecond = 3,
        BytesPerSecond = 4,
        Percent = 5,
        MilliSeconds = 6,
        ByteSeconds = 7,
        Unspecified = 8,
        Cores = 9,
        MilliCores = 10,
        NanoCores = 11,
        BitsPerSecond = 12,
    }
    public partial class VMInsightsOnboardingStatus : Azure.ResourceManager.Insights.Models.ProxyResource
    {
        internal VMInsightsOnboardingStatus() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Insights.Models.DataContainer> Data { get { throw null; } }
        public Azure.ResourceManager.Insights.Models.DataStatus? DataStatus { get { throw null; } }
        public Azure.ResourceManager.Insights.Models.OnboardingStatus? OnboardingStatus { get { throw null; } }
        public string ResourceId { get { throw null; } }
    }
    public partial class VoiceReceiver
    {
        public VoiceReceiver(string name, string countryCode, string phoneNumber) { }
        public string CountryCode { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string PhoneNumber { get { throw null; } set { } }
    }
    public partial class WebhookNotification
    {
        public WebhookNotification() { }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public string ServiceUri { get { throw null; } set { } }
    }
    public partial class WebhookReceiver
    {
        public WebhookReceiver(string name, string serviceUri, bool useCommonAlertSchema) { }
        public string IdentifierUri { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string ObjectId { get { throw null; } set { } }
        public string ServiceUri { get { throw null; } set { } }
        public string TenantId { get { throw null; } set { } }
        public bool? UseAadAuth { get { throw null; } set { } }
        public bool UseCommonAlertSchema { get { throw null; } set { } }
    }
    public partial class WebtestLocationAvailabilityCriteria : Azure.ResourceManager.Insights.Models.MetricAlertCriteria
    {
        public WebtestLocationAvailabilityCriteria(string webTestId, string componentId, float failedLocationCount) { }
        public string ComponentId { get { throw null; } set { } }
        public float FailedLocationCount { get { throw null; } set { } }
        public string WebTestId { get { throw null; } set { } }
    }
    public partial class WorkspaceInfo
    {
        internal WorkspaceInfo() { }
        public string CustomerId { get { throw null; } }
        public string Id { get { throw null; } }
        public string Location { get { throw null; } }
    }
}
