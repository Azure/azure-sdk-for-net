namespace Azure.ResourceManager.Monitor
{
    public partial class ActionGroup : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected ActionGroup() { }
        public virtual Azure.ResourceManager.Monitor.ActionGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.Monitor.Models.ActionGroupDeleteOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Monitor.Models.ActionGroupDeleteOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response EnableReceiver(Azure.ResourceManager.Monitor.Models.EnableRequest enableRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> EnableReceiverAsync(Azure.ResourceManager.Monitor.Models.EnableRequest enableRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.ActionGroup> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.ActionGroup>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.ActionGroup> Update(Azure.ResourceManager.Monitor.Models.ActionGroupPatchBody actionGroupPatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.ActionGroup>> UpdateAsync(Azure.ResourceManager.Monitor.Models.ActionGroupPatchBody actionGroupPatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ActionGroupCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.ActionGroup>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.ActionGroup>, System.Collections.IEnumerable
    {
        protected ActionGroupCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckIfExists(string actionGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckIfExistsAsync(string actionGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Monitor.Models.ActionGroupCreateOrUpdateOperation CreateOrUpdate(string actionGroupName, Azure.ResourceManager.Monitor.ActionGroupData actionGroup, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Monitor.Models.ActionGroupCreateOrUpdateOperation> CreateOrUpdateAsync(string actionGroupName, Azure.ResourceManager.Monitor.ActionGroupData actionGroup, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.ActionGroup> Get(string actionGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.ActionGroup> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.ActionGroup> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.ActionGroup>> GetAsync(string actionGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.ActionGroup> GetIfExists(string actionGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.ActionGroup>> GetIfExistsAsync(string actionGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Monitor.ActionGroup> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.ActionGroup>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Monitor.ActionGroup> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.ActionGroup>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ActionGroupData : Azure.ResourceManager.Monitor.Models.AzureResource
    {
        public ActionGroupData(Azure.ResourceManager.Resources.Models.Location location) : base (default(Azure.ResourceManager.Resources.Models.Location)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.ArmRoleReceiver> ArmRoleReceivers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.AutomationRunbookReceiver> AutomationRunbookReceivers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.AzureAppPushReceiver> AzureAppPushReceivers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.AzureFunctionReceiver> AzureFunctionReceivers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.EmailReceiver> EmailReceivers { get { throw null; } }
        public bool? Enabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.EventHubReceiver> EventHubReceivers { get { throw null; } }
        public string GroupShortName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.ItsmReceiver> ItsmReceivers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.LogicAppReceiver> LogicAppReceivers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.SmsReceiver> SmsReceivers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.VoiceReceiver> VoiceReceivers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.WebhookReceiver> WebhookReceivers { get { throw null; } }
    }
    public partial class ActivityLogAlert : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected ActivityLogAlert() { }
        public virtual Azure.ResourceManager.Monitor.ActivityLogAlertData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.ActivityLogAlert> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.ActivityLogAlert>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Monitor.Models.ActivityLogAlertDeleteOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Monitor.Models.ActivityLogAlertDeleteOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.ActivityLogAlert> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.ActivityLogAlert>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.ActivityLogAlert> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.ActivityLogAlert>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.ActivityLogAlert> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.ActivityLogAlert>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.ActivityLogAlert> Update(Azure.ResourceManager.Monitor.Models.ActivityLogAlertPatchBody activityLogAlertPatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.ActivityLogAlert>> UpdateAsync(Azure.ResourceManager.Monitor.Models.ActivityLogAlertPatchBody activityLogAlertPatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ActivityLogAlertCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.ActivityLogAlert>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.ActivityLogAlert>, System.Collections.IEnumerable
    {
        protected ActivityLogAlertCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckIfExists(string activityLogAlertName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckIfExistsAsync(string activityLogAlertName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Monitor.Models.ActivityLogAlertCreateOrUpdateOperation CreateOrUpdate(string activityLogAlertName, Azure.ResourceManager.Monitor.ActivityLogAlertData activityLogAlert, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Monitor.Models.ActivityLogAlertCreateOrUpdateOperation> CreateOrUpdateAsync(string activityLogAlertName, Azure.ResourceManager.Monitor.ActivityLogAlertData activityLogAlert, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.ActivityLogAlert> Get(string activityLogAlertName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.ActivityLogAlert> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.ActivityLogAlert> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.ActivityLogAlert>> GetAsync(string activityLogAlertName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.ActivityLogAlert> GetIfExists(string activityLogAlertName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.ActivityLogAlert>> GetIfExistsAsync(string activityLogAlertName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Monitor.ActivityLogAlert> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.ActivityLogAlert>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Monitor.ActivityLogAlert> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.ActivityLogAlert>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ActivityLogAlertData : Azure.ResourceManager.Models.TrackedResource
    {
        public ActivityLogAlertData(Azure.ResourceManager.Resources.Models.Location location) : base (default(Azure.ResourceManager.Resources.Models.Location)) { }
        public Azure.ResourceManager.Monitor.Models.ActivityLogAlertActionList Actions { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.ActivityLogAlertAllOfCondition Condition { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Scopes { get { throw null; } }
    }
    public partial class AlertRule : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected AlertRule() { }
        public virtual Azure.ResourceManager.Monitor.AlertRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.AlertRule> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.AlertRule>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Monitor.Models.AlertRuleDeleteOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Monitor.Models.AlertRuleDeleteOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.AlertRule> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.Models.Incident> GetAlertRuleIncident(string incidentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.Models.Incident>> GetAlertRuleIncidentAsync(string incidentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.Models.Incident> GetAlertRuleIncidents(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.Models.Incident> GetAlertRuleIncidentsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.AlertRule>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.AlertRule> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.AlertRule>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.AlertRule> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.AlertRule>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.AlertRule> Update(Azure.ResourceManager.Monitor.Models.AlertRuleResourcePatch alertRulesResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.AlertRule>> UpdateAsync(Azure.ResourceManager.Monitor.Models.AlertRuleResourcePatch alertRulesResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AlertRuleCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.AlertRule>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.AlertRule>, System.Collections.IEnumerable
    {
        protected AlertRuleCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckIfExists(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckIfExistsAsync(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Monitor.Models.AlertRuleCreateOrUpdateOperation CreateOrUpdate(string ruleName, Azure.ResourceManager.Monitor.AlertRuleData parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Monitor.Models.AlertRuleCreateOrUpdateOperation> CreateOrUpdateAsync(string ruleName, Azure.ResourceManager.Monitor.AlertRuleData parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.AlertRule> Get(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.AlertRule> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.AlertRule> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.AlertRule>> GetAsync(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.AlertRule> GetIfExists(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.AlertRule>> GetIfExistsAsync(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Monitor.AlertRule> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.AlertRule>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Monitor.AlertRule> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.AlertRule>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AlertRuleData : Azure.ResourceManager.Models.TrackedResource
    {
        public AlertRuleData(Azure.ResourceManager.Resources.Models.Location location, string namePropertiesName, bool isEnabled, Azure.ResourceManager.Monitor.Models.RuleCondition condition) : base (default(Azure.ResourceManager.Resources.Models.Location)) { }
        public Azure.ResourceManager.Monitor.Models.RuleAction Action { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.RuleAction> Actions { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.RuleCondition Condition { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public bool IsEnabled { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdatedTime { get { throw null; } }
        public string NamePropertiesName { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } set { } }
    }
    public static partial class ArmClientExtensions
    {
        public static Azure.ResourceManager.Monitor.ActionGroup GetActionGroup(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Monitor.ActivityLogAlert GetActivityLogAlert(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Monitor.AlertRule GetAlertRule(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Monitor.AutoscaleSetting GetAutoscaleSetting(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Monitor.DataCollectionEndpoint GetDataCollectionEndpoint(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Monitor.DataCollectionRule GetDataCollectionRule(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Monitor.DataCollectionRuleAssociation GetDataCollectionRuleAssociation(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Monitor.DiagnosticSettings GetDiagnosticSettings(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Monitor.DiagnosticSettingsCategory GetDiagnosticSettingsCategory(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Monitor.LogProfile GetLogProfile(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Monitor.LogSearchRule GetLogSearchRule(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Monitor.MetricAlert GetMetricAlert(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Monitor.PrivateEndpointConnection GetPrivateEndpointConnection(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Monitor.PrivateLink GetPrivateLink(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Monitor.PrivateLinkScope GetPrivateLinkScope(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Monitor.ScopedPrivateLink GetScopedPrivateLink(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Monitor.VmInsightsOnboardingStatus GetVmInsightsOnboardingStatus(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
    }
    public static partial class ArmResourceExtensions
    {
        public static Azure.ResourceManager.Monitor.DataCollectionRuleAssociationCollection GetDataCollectionRuleAssociations(this Azure.ResourceManager.Core.ArmResource armResource) { throw null; }
        public static Azure.ResourceManager.Monitor.DiagnosticSettingsCollection GetDiagnosticSettings(this Azure.ResourceManager.Core.ArmResource armResource) { throw null; }
        public static Azure.ResourceManager.Monitor.DiagnosticSettingsCategoryCollection GetDiagnosticSettingsCategories(this Azure.ResourceManager.Core.ArmResource armResource) { throw null; }
        public static Azure.ResourceManager.Monitor.VmInsightsOnboardingStatus GetVmInsightsOnboardingStatus(this Azure.ResourceManager.Core.ArmResource armResource) { throw null; }
    }
    public partial class AutoscaleSetting : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected AutoscaleSetting() { }
        public virtual Azure.ResourceManager.Monitor.AutoscaleSettingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.AutoscaleSetting> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.AutoscaleSetting>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Monitor.Models.AutoscaleSettingDeleteOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Monitor.Models.AutoscaleSettingDeleteOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.AutoscaleSetting> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.AutoscaleSetting>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.AutoscaleSetting> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.AutoscaleSetting>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.AutoscaleSetting> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.AutoscaleSetting>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.AutoscaleSetting> Update(Azure.ResourceManager.Monitor.Models.AutoscaleSettingResourcePatch autoscaleSettingResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.AutoscaleSetting>> UpdateAsync(Azure.ResourceManager.Monitor.Models.AutoscaleSettingResourcePatch autoscaleSettingResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AutoscaleSettingCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.AutoscaleSetting>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.AutoscaleSetting>, System.Collections.IEnumerable
    {
        protected AutoscaleSettingCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckIfExists(string autoscaleSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckIfExistsAsync(string autoscaleSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Monitor.Models.AutoscaleSettingCreateOrUpdateOperation CreateOrUpdate(string autoscaleSettingName, Azure.ResourceManager.Monitor.AutoscaleSettingData parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Monitor.Models.AutoscaleSettingCreateOrUpdateOperation> CreateOrUpdateAsync(string autoscaleSettingName, Azure.ResourceManager.Monitor.AutoscaleSettingData parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.AutoscaleSetting> Get(string autoscaleSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.AutoscaleSetting> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.AutoscaleSetting> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.AutoscaleSetting>> GetAsync(string autoscaleSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.AutoscaleSetting> GetIfExists(string autoscaleSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.AutoscaleSetting>> GetIfExistsAsync(string autoscaleSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Monitor.AutoscaleSetting> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.AutoscaleSetting>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Monitor.AutoscaleSetting> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.AutoscaleSetting>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AutoscaleSettingData : Azure.ResourceManager.Models.TrackedResource
    {
        public AutoscaleSettingData(Azure.ResourceManager.Resources.Models.Location location, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.AutoscaleProfile> profiles) : base (default(Azure.ResourceManager.Resources.Models.Location)) { }
        public bool? Enabled { get { throw null; } set { } }
        public string NamePropertiesName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.AutoscaleNotification> Notifications { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.AutoscaleProfile> Profiles { get { throw null; } }
        public string TargetResourceLocation { get { throw null; } set { } }
        public string TargetResourceUri { get { throw null; } set { } }
    }
    public partial class DataCollectionEndpoint : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected DataCollectionEndpoint() { }
        public virtual Azure.ResourceManager.Monitor.DataCollectionEndpointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.DataCollectionEndpoint> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.DataCollectionEndpoint>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Monitor.Models.DataCollectionEndpointDeleteOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Monitor.Models.DataCollectionEndpointDeleteOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.DataCollectionEndpoint> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.DataCollectionEndpoint>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.DataCollectionEndpoint> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.DataCollectionEndpoint>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.DataCollectionEndpoint> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.DataCollectionEndpoint>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.DataCollectionEndpoint> Update(Azure.ResourceManager.Monitor.Models.ResourceForUpdate body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.DataCollectionEndpoint>> UpdateAsync(Azure.ResourceManager.Monitor.Models.ResourceForUpdate body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataCollectionEndpointCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.DataCollectionEndpoint>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.DataCollectionEndpoint>, System.Collections.IEnumerable
    {
        protected DataCollectionEndpointCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckIfExists(string dataCollectionEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckIfExistsAsync(string dataCollectionEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Monitor.Models.DataCollectionEndpointCreateOperation CreateOrUpdate(string dataCollectionEndpointName, Azure.ResourceManager.Monitor.DataCollectionEndpointData body = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Monitor.Models.DataCollectionEndpointCreateOperation> CreateOrUpdateAsync(string dataCollectionEndpointName, Azure.ResourceManager.Monitor.DataCollectionEndpointData body = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.DataCollectionEndpoint> Get(string dataCollectionEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.DataCollectionEndpoint> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.DataCollectionEndpoint> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.DataCollectionEndpoint>> GetAsync(string dataCollectionEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.DataCollectionEndpoint> GetIfExists(string dataCollectionEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.DataCollectionEndpoint>> GetIfExistsAsync(string dataCollectionEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Monitor.DataCollectionEndpoint> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.DataCollectionEndpoint>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Monitor.DataCollectionEndpoint> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.DataCollectionEndpoint>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataCollectionEndpointData : Azure.ResourceManager.Models.TrackedResource
    {
        public DataCollectionEndpointData(Azure.ResourceManager.Resources.Models.Location location) : base (default(Azure.ResourceManager.Resources.Models.Location)) { }
        public Azure.ResourceManager.Monitor.Models.DataCollectionEndpointPropertiesConfigurationAccess ConfigurationAccess { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string Etag { get { throw null; } }
        public string ImmutableId { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.KnownDataCollectionEndpointResourceKind? Kind { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.DataCollectionEndpointPropertiesLogsIngestion LogsIngestion { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.DataCollectionEndpointPropertiesNetworkAcls NetworkAcls { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.KnownDataCollectionEndpointProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
    }
    public partial class DataCollectionRule : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected DataCollectionRule() { }
        public virtual Azure.ResourceManager.Monitor.DataCollectionRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.DataCollectionRule> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.DataCollectionRule>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Monitor.Models.DataCollectionRuleDeleteOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Monitor.Models.DataCollectionRuleDeleteOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.DataCollectionRule> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.DataCollectionRule>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.DataCollectionRuleAssociationData> GetDataCollectionRuleAssociationsByRule(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.DataCollectionRuleAssociationData> GetDataCollectionRuleAssociationsByRuleAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.DataCollectionRule> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.DataCollectionRule>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.DataCollectionRule> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.DataCollectionRule>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.DataCollectionRule> Update(Azure.ResourceManager.Monitor.Models.ResourceForUpdate body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.DataCollectionRule>> UpdateAsync(Azure.ResourceManager.Monitor.Models.ResourceForUpdate body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataCollectionRuleAssociation : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected DataCollectionRuleAssociation() { }
        public virtual Azure.ResourceManager.Monitor.DataCollectionRuleAssociationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.Monitor.Models.DataCollectionRuleAssociationDeleteOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Monitor.Models.DataCollectionRuleAssociationDeleteOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.DataCollectionRuleAssociation> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.DataCollectionRuleAssociation>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataCollectionRuleAssociationCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.DataCollectionRuleAssociation>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.DataCollectionRuleAssociation>, System.Collections.IEnumerable
    {
        protected DataCollectionRuleAssociationCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckIfExists(string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckIfExistsAsync(string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Monitor.Models.DataCollectionRuleAssociationCreateOperation CreateOrUpdate(string associationName, Azure.ResourceManager.Monitor.DataCollectionRuleAssociationData body = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Monitor.Models.DataCollectionRuleAssociationCreateOperation> CreateOrUpdateAsync(string associationName, Azure.ResourceManager.Monitor.DataCollectionRuleAssociationData body = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.DataCollectionRuleAssociation> Get(string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.DataCollectionRuleAssociation> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.DataCollectionRuleAssociation> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.DataCollectionRuleAssociation>> GetAsync(string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.DataCollectionRuleAssociation> GetIfExists(string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.DataCollectionRuleAssociation>> GetIfExistsAsync(string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Monitor.DataCollectionRuleAssociation> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.DataCollectionRuleAssociation>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Monitor.DataCollectionRuleAssociation> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.DataCollectionRuleAssociation>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        protected override void ValidateResourceType(Azure.ResourceManager.ResourceIdentifier identifier) { }
    }
    public partial class DataCollectionRuleAssociationData : Azure.ResourceManager.Models.Resource
    {
        public DataCollectionRuleAssociationData() { }
        public string DataCollectionEndpointId { get { throw null; } set { } }
        public string DataCollectionRuleId { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string Etag { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.KnownDataCollectionRuleAssociationProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
    }
    public partial class DataCollectionRuleCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.DataCollectionRule>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.DataCollectionRule>, System.Collections.IEnumerable
    {
        protected DataCollectionRuleCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckIfExists(string dataCollectionRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckIfExistsAsync(string dataCollectionRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Monitor.Models.DataCollectionRuleCreateOperation CreateOrUpdate(string dataCollectionRuleName, Azure.ResourceManager.Monitor.DataCollectionRuleData body = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Monitor.Models.DataCollectionRuleCreateOperation> CreateOrUpdateAsync(string dataCollectionRuleName, Azure.ResourceManager.Monitor.DataCollectionRuleData body = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.DataCollectionRule> Get(string dataCollectionRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.DataCollectionRule> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.DataCollectionRule> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.DataCollectionRule>> GetAsync(string dataCollectionRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.DataCollectionRule> GetIfExists(string dataCollectionRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.DataCollectionRule>> GetIfExistsAsync(string dataCollectionRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Monitor.DataCollectionRule> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.DataCollectionRule>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Monitor.DataCollectionRule> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.DataCollectionRule>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataCollectionRuleData : Azure.ResourceManager.Models.TrackedResource
    {
        public DataCollectionRuleData(Azure.ResourceManager.Resources.Models.Location location) : base (default(Azure.ResourceManager.Resources.Models.Location)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.DataFlow> DataFlows { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.DataCollectionRulePropertiesDataSources DataSources { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.DataCollectionRulePropertiesDestinations Destinations { get { throw null; } set { } }
        public string Etag { get { throw null; } }
        public string ImmutableId { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.KnownDataCollectionRuleResourceKind? Kind { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.KnownDataCollectionRuleProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
    }
    public partial class DiagnosticSettings : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected DiagnosticSettings() { }
        public virtual Azure.ResourceManager.Monitor.DiagnosticSettingsData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.Monitor.Models.DiagnosticSettingDeleteOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Monitor.Models.DiagnosticSettingDeleteOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.DiagnosticSettings> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.DiagnosticSettings>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DiagnosticSettingsCategory : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected DiagnosticSettingsCategory() { }
        public virtual Azure.ResourceManager.Monitor.DiagnosticSettingsCategoryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.DiagnosticSettingsCategory> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.DiagnosticSettingsCategory>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DiagnosticSettingsCategoryCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.DiagnosticSettingsCategory>, System.Collections.IEnumerable
    {
        protected DiagnosticSettingsCategoryCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.DiagnosticSettingsCategory> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Monitor.DiagnosticSettingsCategory>> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Monitor.DiagnosticSettingsCategory>>> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.DiagnosticSettingsCategory>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.DiagnosticSettingsCategory> GetIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.DiagnosticSettingsCategory>> GetIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Monitor.DiagnosticSettingsCategory> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.DiagnosticSettingsCategory>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        protected override void ValidateResourceType(Azure.ResourceManager.ResourceIdentifier identifier) { }
    }
    public partial class DiagnosticSettingsCategoryData : Azure.ResourceManager.Models.Resource
    {
        public DiagnosticSettingsCategoryData() { }
        public Azure.ResourceManager.Monitor.Models.CategoryType? CategoryType { get { throw null; } set { } }
    }
    public partial class DiagnosticSettingsCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.DiagnosticSettings>, System.Collections.IEnumerable
    {
        protected DiagnosticSettingsCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Monitor.Models.DiagnosticSettingCreateOrUpdateOperation CreateOrUpdate(string name, Azure.ResourceManager.Monitor.DiagnosticSettingsData parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Monitor.Models.DiagnosticSettingCreateOrUpdateOperation> CreateOrUpdateAsync(string name, Azure.ResourceManager.Monitor.DiagnosticSettingsData parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.DiagnosticSettings> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Monitor.DiagnosticSettings>> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Monitor.DiagnosticSettings>>> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.DiagnosticSettings>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.DiagnosticSettings> GetIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.DiagnosticSettings>> GetIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Monitor.DiagnosticSettings> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.DiagnosticSettings>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        protected override void ValidateResourceType(Azure.ResourceManager.ResourceIdentifier identifier) { }
    }
    public partial class DiagnosticSettingsData : Azure.ResourceManager.Models.Resource
    {
        public DiagnosticSettingsData() { }
        public string EventHubAuthorizationRuleId { get { throw null; } set { } }
        public string EventHubName { get { throw null; } set { } }
        public string LogAnalyticsDestinationType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.LogSettings> Logs { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.MetricSettings> Metrics { get { throw null; } }
        public string ServiceBusRuleId { get { throw null; } set { } }
        public string StorageAccountId { get { throw null; } set { } }
        public string WorkspaceId { get { throw null; } set { } }
    }
    public partial class LogProfile : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected LogProfile() { }
        public virtual Azure.ResourceManager.Monitor.LogProfileData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.LogProfile> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.LogProfile>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Monitor.Models.LogProfileDeleteOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Monitor.Models.LogProfileDeleteOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.LogProfile> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.LogProfile>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.LogProfile> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.LogProfile>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.LogProfile> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.LogProfile>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.LogProfile> Update(Azure.ResourceManager.Monitor.Models.LogProfileResourcePatch logProfilesResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.LogProfile>> UpdateAsync(Azure.ResourceManager.Monitor.Models.LogProfileResourcePatch logProfilesResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LogProfileCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.LogProfile>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.LogProfile>, System.Collections.IEnumerable
    {
        protected LogProfileCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckIfExists(string logProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckIfExistsAsync(string logProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Monitor.Models.LogProfileCreateOrUpdateOperation CreateOrUpdate(string logProfileName, Azure.ResourceManager.Monitor.LogProfileData parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Monitor.Models.LogProfileCreateOrUpdateOperation> CreateOrUpdateAsync(string logProfileName, Azure.ResourceManager.Monitor.LogProfileData parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.LogProfile> Get(string logProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.LogProfile> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.LogProfile> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.LogProfile>> GetAsync(string logProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.LogProfile> GetIfExists(string logProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.LogProfile>> GetIfExistsAsync(string logProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Monitor.LogProfile> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.LogProfile>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Monitor.LogProfile> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.LogProfile>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LogProfileData : Azure.ResourceManager.Models.TrackedResource
    {
        public LogProfileData(Azure.ResourceManager.Resources.Models.Location location, System.Collections.Generic.IEnumerable<string> locations, System.Collections.Generic.IEnumerable<string> categories, Azure.ResourceManager.Monitor.Models.RetentionPolicy retentionPolicy) : base (default(Azure.ResourceManager.Resources.Models.Location)) { }
        public System.Collections.Generic.IList<string> Categories { get { throw null; } }
        public System.Collections.Generic.IList<string> Locations { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.RetentionPolicy RetentionPolicy { get { throw null; } set { } }
        public string ServiceBusRuleId { get { throw null; } set { } }
        public string StorageAccountId { get { throw null; } set { } }
    }
    public partial class LogSearchRule : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected LogSearchRule() { }
        public virtual Azure.ResourceManager.Monitor.LogSearchRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.Monitor.Models.ScheduledQueryRuleDeleteOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Monitor.Models.ScheduledQueryRuleDeleteOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.LogSearchRule> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.LogSearchRule>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.LogSearchRule> Update(Azure.ResourceManager.Monitor.Models.LogSearchRuleResourcePatch parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.LogSearchRule>> UpdateAsync(Azure.ResourceManager.Monitor.Models.LogSearchRuleResourcePatch parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LogSearchRuleCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.LogSearchRule>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.LogSearchRule>, System.Collections.IEnumerable
    {
        protected LogSearchRuleCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckIfExists(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckIfExistsAsync(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Monitor.Models.ScheduledQueryRuleCreateOrUpdateOperation CreateOrUpdate(string ruleName, Azure.ResourceManager.Monitor.LogSearchRuleData parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Monitor.Models.ScheduledQueryRuleCreateOrUpdateOperation> CreateOrUpdateAsync(string ruleName, Azure.ResourceManager.Monitor.LogSearchRuleData parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.LogSearchRule> Get(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.LogSearchRule> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.LogSearchRule> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.LogSearchRule>> GetAsync(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.LogSearchRule> GetIfExists(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.LogSearchRule>> GetIfExistsAsync(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Monitor.LogSearchRule> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.LogSearchRule>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Monitor.LogSearchRule> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.LogSearchRule>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LogSearchRuleData : Azure.ResourceManager.Monitor.Models.ResourceAutoGenerated
    {
        public LogSearchRuleData(Azure.ResourceManager.Resources.Models.Location location, Azure.ResourceManager.Monitor.Models.Source source, Azure.ResourceManager.Monitor.Models.Action action) : base (default(Azure.ResourceManager.Resources.Models.Location)) { }
        public Azure.ResourceManager.Monitor.Models.Action Action { get { throw null; } set { } }
        public bool? AutoMitigate { get { throw null; } set { } }
        public string CreatedWithApiVersion { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.Enabled? Enabled { get { throw null; } set { } }
        public bool? IsLegacyLogAnalyticsRule { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedTime { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.Schedule Schedule { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.Source Source { get { throw null; } set { } }
    }
    public partial class MetricAlert : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected MetricAlert() { }
        public virtual Azure.ResourceManager.Monitor.MetricAlertData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.MetricAlert> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.MetricAlert>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Monitor.Models.MetricAlertDeleteOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Monitor.Models.MetricAlertDeleteOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.MetricAlert> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.MetricAlert>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Monitor.Models.MetricAlertStatus>> GetMetricAlertsStatuses(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Monitor.Models.MetricAlertStatus>>> GetMetricAlertsStatusesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Monitor.Models.MetricAlertStatus>> GetMetricAlertsStatusesByName(string statusName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Monitor.Models.MetricAlertStatus>>> GetMetricAlertsStatusesByNameAsync(string statusName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.MetricAlert> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.MetricAlert>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.MetricAlert> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.MetricAlert>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.MetricAlert> Update(Azure.ResourceManager.Monitor.Models.MetricAlertResourcePatch parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.MetricAlert>> UpdateAsync(Azure.ResourceManager.Monitor.Models.MetricAlertResourcePatch parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MetricAlertCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.MetricAlert>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.MetricAlert>, System.Collections.IEnumerable
    {
        protected MetricAlertCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckIfExists(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckIfExistsAsync(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Monitor.Models.MetricAlertCreateOrUpdateOperation CreateOrUpdate(string ruleName, Azure.ResourceManager.Monitor.MetricAlertData parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Monitor.Models.MetricAlertCreateOrUpdateOperation> CreateOrUpdateAsync(string ruleName, Azure.ResourceManager.Monitor.MetricAlertData parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.MetricAlert> Get(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.MetricAlert> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.MetricAlert> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.MetricAlert>> GetAsync(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.MetricAlert> GetIfExists(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.MetricAlert>> GetIfExistsAsync(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Monitor.MetricAlert> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.MetricAlert>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Monitor.MetricAlert> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.MetricAlert>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MetricAlertData : Azure.ResourceManager.Models.TrackedResource
    {
        public MetricAlertData(Azure.ResourceManager.Resources.Models.Location location, int severity, bool enabled, System.Collections.Generic.IEnumerable<string> scopes, System.TimeSpan evaluationFrequency, System.TimeSpan windowSize, Azure.ResourceManager.Monitor.Models.MetricAlertCriteria criteria) : base (default(Azure.ResourceManager.Resources.Models.Location)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.MetricAlertAction> Actions { get { throw null; } }
        public bool? AutoMitigate { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.MetricAlertCriteria Criteria { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public bool Enabled { get { throw null; } set { } }
        public System.TimeSpan EvaluationFrequency { get { throw null; } set { } }
        public bool? IsMigrated { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedTime { get { throw null; } }
        public System.Collections.Generic.IList<string> Scopes { get { throw null; } }
        public int Severity { get { throw null; } set { } }
        public string TargetResourceRegion { get { throw null; } set { } }
        public string TargetResourceType { get { throw null; } set { } }
        public System.TimeSpan WindowSize { get { throw null; } set { } }
    }
    public partial class PrivateEndpointConnection : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected PrivateEndpointConnection() { }
        public virtual Azure.ResourceManager.Monitor.PrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.Monitor.Models.PrivateEndpointConnectionDeleteOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Monitor.Models.PrivateEndpointConnectionDeleteOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.PrivateEndpointConnection> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.PrivateEndpointConnection>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateEndpointConnectionCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.PrivateEndpointConnection>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.PrivateEndpointConnection>, System.Collections.IEnumerable
    {
        protected PrivateEndpointConnectionCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Monitor.Models.PrivateEndpointConnectionCreateOrUpdateOperation CreateOrUpdate(string privateEndpointConnectionName, Azure.ResourceManager.Monitor.PrivateEndpointConnectionData parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Monitor.Models.PrivateEndpointConnectionCreateOrUpdateOperation> CreateOrUpdateAsync(string privateEndpointConnectionName, Azure.ResourceManager.Monitor.PrivateEndpointConnectionData parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.PrivateEndpointConnection> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.PrivateEndpointConnection> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.PrivateEndpointConnection> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.PrivateEndpointConnection>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.PrivateEndpointConnection> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.PrivateEndpointConnection>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Monitor.PrivateEndpointConnection> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.PrivateEndpointConnection>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Monitor.PrivateEndpointConnection> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.PrivateEndpointConnection>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateEndpointConnectionData : Azure.ResourceManager.Models.Resource
    {
        public PrivateEndpointConnectionData() { }
        public Azure.ResourceManager.Resources.Models.WritableSubResource PrivateEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.PrivateLinkServiceConnectionStateProperty PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
    }
    public partial class PrivateLink : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected PrivateLink() { }
        public virtual Azure.ResourceManager.Monitor.PrivateLinkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.PrivateLink> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.PrivateLink>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateLinkCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.PrivateLink>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.PrivateLink>, System.Collections.IEnumerable
    {
        protected PrivateLinkCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckIfExists(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckIfExistsAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.PrivateLink> Get(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.PrivateLink> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.PrivateLink> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.PrivateLink>> GetAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.PrivateLink> GetIfExists(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.PrivateLink>> GetIfExistsAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Monitor.PrivateLink> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.PrivateLink>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Monitor.PrivateLink> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.PrivateLink>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateLinkData : Azure.ResourceManager.Models.Resource
    {
        public PrivateLinkData() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
    }
    public partial class PrivateLinkScope : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected PrivateLinkScope() { }
        public virtual Azure.ResourceManager.Monitor.PrivateLinkScopeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.PrivateLinkScope> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.PrivateLinkScope>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Monitor.Models.PrivateLinkScopeDeleteOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Monitor.Models.PrivateLinkScopeDeleteOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.PrivateLinkScope> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.PrivateLinkScope>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.Monitor.PrivateEndpointConnectionCollection GetPrivateEndpointConnections() { throw null; }
        public Azure.ResourceManager.Monitor.PrivateLinkCollection GetPrivateLinks() { throw null; }
        public Azure.ResourceManager.Monitor.ScopedPrivateLinkCollection GetScopedPrivateLinks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.PrivateLinkScope> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.PrivateLinkScope>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.PrivateLinkScope> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.PrivateLinkScope>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.PrivateLinkScope> Update(Azure.ResourceManager.Monitor.Models.TagsResource privateLinkScopeTags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.PrivateLinkScope>> UpdateAsync(Azure.ResourceManager.Monitor.Models.TagsResource privateLinkScopeTags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateLinkScopeCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.PrivateLinkScope>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.PrivateLinkScope>, System.Collections.IEnumerable
    {
        protected PrivateLinkScopeCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckIfExists(string scopeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckIfExistsAsync(string scopeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Monitor.Models.PrivateLinkScopeCreateOrUpdateOperation CreateOrUpdate(string scopeName, Azure.ResourceManager.Monitor.PrivateLinkScopeData azureMonitorPrivateLinkScopePayload, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Monitor.Models.PrivateLinkScopeCreateOrUpdateOperation> CreateOrUpdateAsync(string scopeName, Azure.ResourceManager.Monitor.PrivateLinkScopeData azureMonitorPrivateLinkScopePayload, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.PrivateLinkScope> Get(string scopeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.PrivateLinkScope> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.PrivateLinkScope> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.PrivateLinkScope>> GetAsync(string scopeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.PrivateLinkScope> GetIfExists(string scopeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.PrivateLinkScope>> GetIfExistsAsync(string scopeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Monitor.PrivateLinkScope> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.PrivateLinkScope>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Monitor.PrivateLinkScope> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.PrivateLinkScope>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateLinkScopeData : Azure.ResourceManager.Models.TrackedResource
    {
        public PrivateLinkScopeData(Azure.ResourceManager.Resources.Models.Location location) : base (default(Azure.ResourceManager.Resources.Models.Location)) { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Monitor.PrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
    }
    public static partial class ResourceGroupExtensions
    {
        public static Azure.ResourceManager.Monitor.ActionGroupCollection GetActionGroups(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
        public static Azure.ResourceManager.Monitor.ActivityLogAlertCollection GetActivityLogAlerts(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
        public static Azure.ResourceManager.Monitor.AlertRuleCollection GetAlertRules(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
        public static Azure.ResourceManager.Monitor.AutoscaleSettingCollection GetAutoscaleSettings(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
        public static Azure.ResourceManager.Monitor.DataCollectionEndpointCollection GetDataCollectionEndpoints(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
        public static Azure.ResourceManager.Monitor.DataCollectionRuleCollection GetDataCollectionRules(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
        public static Azure.ResourceManager.Monitor.LogSearchRuleCollection GetLogSearchRules(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
        public static Azure.ResourceManager.Monitor.MetricAlertCollection GetMetricAlerts(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Monitor.Models.OperationStatus> GetPrivateLinkScopeOperationStatu(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string asyncOperationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.Models.OperationStatus>> GetPrivateLinkScopeOperationStatuAsync(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string asyncOperationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Monitor.PrivateLinkScopeCollection GetPrivateLinkScopes(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
    }
    public partial class ScopedPrivateLink : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected ScopedPrivateLink() { }
        public virtual Azure.ResourceManager.Monitor.ScopedPrivateLinkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.Monitor.Models.PrivateLinkScopedResourceDeleteOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Monitor.Models.PrivateLinkScopedResourceDeleteOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.ScopedPrivateLink> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.ScopedPrivateLink>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ScopedPrivateLinkCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.ScopedPrivateLink>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.ScopedPrivateLink>, System.Collections.IEnumerable
    {
        protected ScopedPrivateLinkCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Monitor.Models.PrivateLinkScopedResourceCreateOrUpdateOperation CreateOrUpdate(string name, Azure.ResourceManager.Monitor.ScopedPrivateLinkData parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Monitor.Models.PrivateLinkScopedResourceCreateOrUpdateOperation> CreateOrUpdateAsync(string name, Azure.ResourceManager.Monitor.ScopedPrivateLinkData parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.ScopedPrivateLink> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.ScopedPrivateLink> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.ScopedPrivateLink> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.ScopedPrivateLink>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.ScopedPrivateLink> GetIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.ScopedPrivateLink>> GetIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Monitor.ScopedPrivateLink> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.ScopedPrivateLink>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Monitor.ScopedPrivateLink> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.ScopedPrivateLink>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ScopedPrivateLinkData : Azure.ResourceManager.Models.Resource
    {
        public ScopedPrivateLinkData() { }
        public string LinkedResourceId { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
    }
    public static partial class SubscriptionExtensions
    {
        public static Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetActionGroupByName(this Azure.ResourceManager.Resources.Subscription subscription, string filter, string expand, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetActionGroupByNameAsync(this Azure.ResourceManager.Resources.Subscription subscription, string filter, string expand, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Monitor.ActionGroup> GetActionGroupsBySubscriptionId(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Monitor.ActionGroup> GetActionGroupsBySubscriptionIdAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetActivityLogAlertByName(this Azure.ResourceManager.Resources.Subscription subscription, string filter, string expand, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetActivityLogAlertByNameAsync(this Azure.ResourceManager.Resources.Subscription subscription, string filter, string expand, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Monitor.ActivityLogAlert> GetActivityLogAlertsBySubscriptionId(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Monitor.ActivityLogAlert> GetActivityLogAlertsBySubscriptionIdAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Monitor.Models.EventData> GetActivityLogs(this Azure.ResourceManager.Resources.Subscription subscription, string filter, string select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Monitor.Models.EventData> GetActivityLogsAsync(this Azure.ResourceManager.Resources.Subscription subscription, string filter, string select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetAlertRuleByName(this Azure.ResourceManager.Resources.Subscription subscription, string filter, string expand, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetAlertRuleByNameAsync(this Azure.ResourceManager.Resources.Subscription subscription, string filter, string expand, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Monitor.AlertRule> GetAlertRules(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Monitor.AlertRule> GetAlertRulesAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetAutoscaleSettingByName(this Azure.ResourceManager.Resources.Subscription subscription, string filter, string expand, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetAutoscaleSettingByNameAsync(this Azure.ResourceManager.Resources.Subscription subscription, string filter, string expand, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Monitor.AutoscaleSetting> GetAutoscaleSettings(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Monitor.AutoscaleSetting> GetAutoscaleSettingsAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetDataCollectionEndpointByName(this Azure.ResourceManager.Resources.Subscription subscription, string filter, string expand, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetDataCollectionEndpointByNameAsync(this Azure.ResourceManager.Resources.Subscription subscription, string filter, string expand, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Monitor.DataCollectionEndpoint> GetDataCollectionEndpoints(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Monitor.DataCollectionEndpoint> GetDataCollectionEndpointsAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetDataCollectionRuleByName(this Azure.ResourceManager.Resources.Subscription subscription, string filter, string expand, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetDataCollectionRuleByNameAsync(this Azure.ResourceManager.Resources.Subscription subscription, string filter, string expand, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Monitor.DataCollectionRule> GetDataCollectionRules(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Monitor.DataCollectionRule> GetDataCollectionRulesAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Monitor.LogProfileCollection GetLogProfiles(this Azure.ResourceManager.Resources.Subscription subscription) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetLogSearchRuleByName(this Azure.ResourceManager.Resources.Subscription subscription, string filter, string expand, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetLogSearchRuleByNameAsync(this Azure.ResourceManager.Resources.Subscription subscription, string filter, string expand, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetMetricAlertByName(this Azure.ResourceManager.Resources.Subscription subscription, string filter, string expand, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetMetricAlertByNameAsync(this Azure.ResourceManager.Resources.Subscription subscription, string filter, string expand, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Monitor.MetricAlert> GetMetricAlerts(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Monitor.MetricAlert> GetMetricAlertsAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetPrivateLinkScopeByName(this Azure.ResourceManager.Resources.Subscription subscription, string filter, string expand, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetPrivateLinkScopeByNameAsync(this Azure.ResourceManager.Resources.Subscription subscription, string filter, string expand, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Monitor.PrivateLinkScope> GetPrivateLinkScopes(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Monitor.PrivateLinkScope> GetPrivateLinkScopesAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Monitor.LogSearchRule> GetScheduledQueryRules(this Azure.ResourceManager.Resources.Subscription subscription, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Monitor.LogSearchRule> GetScheduledQueryRulesAsync(this Azure.ResourceManager.Resources.Subscription subscription, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Monitor.Models.TestNotificationDetailsResponse> GetTestNotificationsActionGroup(this Azure.ResourceManager.Resources.Subscription subscription, string notificationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.Models.TestNotificationDetailsResponse>> GetTestNotificationsActionGroupAsync(this Azure.ResourceManager.Resources.Subscription subscription, string notificationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.ActionGroupPostTestNotificationsOperation PostTestNotificationsActionGroup(this Azure.ResourceManager.Resources.Subscription subscription, Azure.ResourceManager.Monitor.Models.NotificationRequestBody notificationRequest, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.Monitor.Models.ActionGroupPostTestNotificationsOperation> PostTestNotificationsActionGroupAsync(this Azure.ResourceManager.Resources.Subscription subscription, Azure.ResourceManager.Monitor.Models.NotificationRequestBody notificationRequest, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class TenantExtensions
    {
        public static Azure.Pageable<Azure.ResourceManager.Monitor.Models.LocalizableString> GetEventCategories(this Azure.ResourceManager.Resources.Tenant tenant, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Monitor.Models.LocalizableString> GetEventCategoriesAsync(this Azure.ResourceManager.Resources.Tenant tenant, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Monitor.Models.EventData> GetTenantActivityLogs(this Azure.ResourceManager.Resources.Tenant tenant, string filter = null, string select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Monitor.Models.EventData> GetTenantActivityLogsAsync(this Azure.ResourceManager.Resources.Tenant tenant, string filter = null, string select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VmInsightsOnboardingStatus : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected VmInsightsOnboardingStatus() { }
        public virtual Azure.ResourceManager.Monitor.VmInsightsOnboardingStatusData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public Azure.ResourceManager.Core.ArmResource Parent { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.VmInsightsOnboardingStatus> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.VmInsightsOnboardingStatus>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VmInsightsOnboardingStatusData : Azure.ResourceManager.Models.Resource
    {
        public VmInsightsOnboardingStatusData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.DataContainer> Data { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.DataStatus? DataStatus { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.OnboardingStatus? OnboardingStatus { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
    }
}
namespace Azure.ResourceManager.Monitor.Models
{
    public partial class Action
    {
        public Action() { }
    }
    public partial class ActionDetail
    {
        internal ActionDetail() { }
        public string Detail { get { throw null; } }
        public string MechanismType { get { throw null; } }
        public string Name { get { throw null; } }
        public string SendTime { get { throw null; } }
        public string Status { get { throw null; } }
        public string SubState { get { throw null; } }
    }
    public partial class ActionGroupCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Monitor.ActionGroup>
    {
        protected ActionGroupCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Monitor.ActionGroup Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Monitor.ActionGroup>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Monitor.ActionGroup>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ActionGroupDeleteOperation : Azure.Operation
    {
        protected ActionGroupDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ActionGroupPatchBody
    {
        public ActionGroupPatchBody() { }
        public bool? Enabled { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class ActionGroupPostTestNotificationsOperation : Azure.Operation<Azure.ResourceManager.Monitor.Models.TestNotificationResponse>
    {
        protected ActionGroupPostTestNotificationsOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Monitor.Models.TestNotificationResponse Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Monitor.Models.TestNotificationResponse>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Monitor.Models.TestNotificationResponse>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ActionGroupUpdateOperation : Azure.Operation<Azure.ResourceManager.Monitor.ActionGroup>
    {
        protected ActionGroupUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Monitor.ActionGroup Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Monitor.ActionGroup>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Monitor.ActionGroup>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.ActivityLogAlertActionGroup> ActionGroups { get { throw null; } }
    }
    public partial class ActivityLogAlertAllOfCondition
    {
        public ActivityLogAlertAllOfCondition(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.ActivityLogAlertLeafCondition> allOf) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.ActivityLogAlertLeafCondition> AllOf { get { throw null; } }
    }
    public partial class ActivityLogAlertCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Monitor.ActivityLogAlert>
    {
        protected ActivityLogAlertCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Monitor.ActivityLogAlert Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Monitor.ActivityLogAlert>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Monitor.ActivityLogAlert>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ActivityLogAlertDeleteOperation : Azure.Operation
    {
        protected ActivityLogAlertDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class ActivityLogAlertUpdateOperation : Azure.Operation<Azure.ResourceManager.Monitor.ActivityLogAlert>
    {
        protected ActivityLogAlertUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Monitor.ActivityLogAlert Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Monitor.ActivityLogAlert>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Monitor.ActivityLogAlert>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AggregationTypeEnum : System.IEquatable<Azure.ResourceManager.Monitor.Models.AggregationTypeEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AggregationTypeEnum(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.AggregationTypeEnum Average { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.AggregationTypeEnum Count { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.AggregationTypeEnum Maximum { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.AggregationTypeEnum Minimum { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.AggregationTypeEnum Total { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.AggregationTypeEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.AggregationTypeEnum left, Azure.ResourceManager.Monitor.Models.AggregationTypeEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.AggregationTypeEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.AggregationTypeEnum left, Azure.ResourceManager.Monitor.Models.AggregationTypeEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AlertingAction : Azure.ResourceManager.Monitor.Models.Action
    {
        public AlertingAction(Azure.ResourceManager.Monitor.Models.AlertSeverity severity, Azure.ResourceManager.Monitor.Models.TriggerCondition trigger) { }
        public Azure.ResourceManager.Monitor.Models.AzNsActionGroup AznsAction { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.AlertSeverity Severity { get { throw null; } set { } }
        public int? ThrottlingInMin { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.TriggerCondition Trigger { get { throw null; } set { } }
    }
    public partial class AlertRuleCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Monitor.AlertRule>
    {
        protected AlertRuleCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Monitor.AlertRule Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Monitor.AlertRule>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Monitor.AlertRule>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AlertRuleDeleteOperation : Azure.Operation
    {
        protected AlertRuleDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AlertRuleResourcePatch
    {
        public AlertRuleResourcePatch() { }
        public Azure.ResourceManager.Monitor.Models.RuleAction Action { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.RuleAction> Actions { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.RuleCondition Condition { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdatedTime { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class AlertRuleUpdateOperation : Azure.Operation<Azure.ResourceManager.Monitor.AlertRule>
    {
        protected AlertRuleUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Monitor.AlertRule Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Monitor.AlertRule>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Monitor.AlertRule>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AlertSeverity : System.IEquatable<Azure.ResourceManager.Monitor.Models.AlertSeverity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AlertSeverity(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.AlertSeverity Four { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.AlertSeverity One { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.AlertSeverity Three { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.AlertSeverity Two { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.AlertSeverity Zero { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.AlertSeverity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.AlertSeverity left, Azure.ResourceManager.Monitor.Models.AlertSeverity right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.AlertSeverity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.AlertSeverity left, Azure.ResourceManager.Monitor.Models.AlertSeverity right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ArmRoleReceiver
    {
        public ArmRoleReceiver(string name, string roleId) { }
        public string Name { get { throw null; } set { } }
        public string RoleId { get { throw null; } set { } }
        public bool? UseCommonAlertSchema { get { throw null; } set { } }
    }
    public partial class AutomationRunbookReceiver
    {
        public AutomationRunbookReceiver(string automationAccountId, string runbookName, string webhookResourceId, bool isGlobalRunbook) { }
        public string AutomationAccountId { get { throw null; } set { } }
        public bool IsGlobalRunbook { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string RunbookName { get { throw null; } set { } }
        public string ServiceUri { get { throw null; } set { } }
        public bool? UseCommonAlertSchema { get { throw null; } set { } }
        public string WebhookResourceId { get { throw null; } set { } }
    }
    public partial class AutoscaleNotification
    {
        public AutoscaleNotification() { }
        public Azure.ResourceManager.Monitor.Models.EmailNotification Email { get { throw null; } set { } }
        public string Operation { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.WebhookNotification> Webhooks { get { throw null; } }
    }
    public partial class AutoscaleProfile
    {
        public AutoscaleProfile(string name, Azure.ResourceManager.Monitor.Models.ScaleCapacity capacity, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.ScaleRule> rules) { }
        public Azure.ResourceManager.Monitor.Models.ScaleCapacity Capacity { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.TimeWindow FixedDate { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.Recurrence Recurrence { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.ScaleRule> Rules { get { throw null; } }
    }
    public partial class AutoscaleSettingCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Monitor.AutoscaleSetting>
    {
        protected AutoscaleSettingCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Monitor.AutoscaleSetting Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Monitor.AutoscaleSetting>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Monitor.AutoscaleSetting>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AutoscaleSettingDeleteOperation : Azure.Operation
    {
        protected AutoscaleSettingDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AutoscaleSettingResourcePatch
    {
        public AutoscaleSettingResourcePatch() { }
        public bool? Enabled { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.AutoscaleNotification> Notifications { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.AutoscaleProfile> Profiles { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string TargetResourceLocation { get { throw null; } set { } }
        public string TargetResourceUri { get { throw null; } set { } }
    }
    public partial class AutoscaleSettingUpdateOperation : Azure.Operation<Azure.ResourceManager.Monitor.AutoscaleSetting>
    {
        protected AutoscaleSettingUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Monitor.AutoscaleSetting Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Monitor.AutoscaleSetting>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Monitor.AutoscaleSetting>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public AzureFunctionReceiver(string name, string functionAppResourceId, string functionName, string httpTriggerUrl) { }
        public string FunctionAppResourceId { get { throw null; } set { } }
        public string FunctionName { get { throw null; } set { } }
        public string HttpTriggerUrl { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public bool? UseCommonAlertSchema { get { throw null; } set { } }
    }
    public partial class AzureMonitorMetricsDestination
    {
        public AzureMonitorMetricsDestination() { }
        public string Name { get { throw null; } set { } }
    }
    public partial class AzureResource : Azure.ResourceManager.Models.TrackedResource
    {
        public AzureResource(Azure.ResourceManager.Resources.Models.Location location) : base (default(Azure.ResourceManager.Resources.Models.Location)) { }
        public string Identity { get { throw null; } }
        public string Kind { get { throw null; } }
    }
    public partial class BaselineMetadata
    {
        internal BaselineMetadata() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BaselineSensitivity : System.IEquatable<Azure.ResourceManager.Monitor.Models.BaselineSensitivity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BaselineSensitivity(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.BaselineSensitivity High { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.BaselineSensitivity Low { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.BaselineSensitivity Medium { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.BaselineSensitivity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.BaselineSensitivity left, Azure.ResourceManager.Monitor.Models.BaselineSensitivity right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.BaselineSensitivity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.BaselineSensitivity left, Azure.ResourceManager.Monitor.Models.BaselineSensitivity right) { throw null; }
        public override string ToString() { throw null; }
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
    public readonly partial struct ConditionalOperator : System.IEquatable<Azure.ResourceManager.Monitor.Models.ConditionalOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConditionalOperator(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.ConditionalOperator Equal { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.ConditionalOperator GreaterThan { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.ConditionalOperator GreaterThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.ConditionalOperator LessThan { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.ConditionalOperator LessThanOrEqual { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.ConditionalOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.ConditionalOperator left, Azure.ResourceManager.Monitor.Models.ConditionalOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.ConditionalOperator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.ConditionalOperator left, Azure.ResourceManager.Monitor.Models.ConditionalOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum ConditionOperator
    {
        GreaterThan = 0,
        GreaterThanOrEqual = 1,
        LessThan = 2,
        LessThanOrEqual = 3,
    }
    public partial class ConfigurationAccessEndpointSpec
    {
        public ConfigurationAccessEndpointSpec() { }
        public string Endpoint { get { throw null; } }
    }
    public partial class Context
    {
        internal Context() { }
        public string ContextType { get { throw null; } }
        public string NotificationSource { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CreatedByType : System.IEquatable<Azure.ResourceManager.Monitor.Models.CreatedByType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CreatedByType(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.CreatedByType Application { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.CreatedByType Key { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.CreatedByType ManagedIdentity { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.CreatedByType User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.CreatedByType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.CreatedByType left, Azure.ResourceManager.Monitor.Models.CreatedByType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.CreatedByType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.CreatedByType left, Azure.ResourceManager.Monitor.Models.CreatedByType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Criteria
    {
        public Criteria(string metricName) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.Dimension> Dimensions { get { throw null; } }
        public string MetricName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CriterionType : System.IEquatable<Azure.ResourceManager.Monitor.Models.CriterionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CriterionType(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.CriterionType DynamicThresholdCriterion { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.CriterionType StaticThresholdCriterion { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.CriterionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.CriterionType left, Azure.ResourceManager.Monitor.Models.CriterionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.CriterionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.CriterionType left, Azure.ResourceManager.Monitor.Models.CriterionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataCollectionEndpointCreateOperation : Azure.Operation<Azure.ResourceManager.Monitor.DataCollectionEndpoint>
    {
        protected DataCollectionEndpointCreateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Monitor.DataCollectionEndpoint Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Monitor.DataCollectionEndpoint>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Monitor.DataCollectionEndpoint>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataCollectionEndpointDeleteOperation : Azure.Operation
    {
        protected DataCollectionEndpointDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataCollectionEndpointPropertiesConfigurationAccess : Azure.ResourceManager.Monitor.Models.ConfigurationAccessEndpointSpec
    {
        public DataCollectionEndpointPropertiesConfigurationAccess() { }
    }
    public partial class DataCollectionEndpointPropertiesLogsIngestion : Azure.ResourceManager.Monitor.Models.LogsIngestionEndpointSpec
    {
        public DataCollectionEndpointPropertiesLogsIngestion() { }
    }
    public partial class DataCollectionEndpointPropertiesNetworkAcls : Azure.ResourceManager.Monitor.Models.NetworkRuleSet
    {
        public DataCollectionEndpointPropertiesNetworkAcls() { }
    }
    public partial class DataCollectionEndpointUpdateOperation : Azure.Operation<Azure.ResourceManager.Monitor.DataCollectionEndpoint>
    {
        protected DataCollectionEndpointUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Monitor.DataCollectionEndpoint Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Monitor.DataCollectionEndpoint>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Monitor.DataCollectionEndpoint>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataCollectionRuleAssociationCreateOperation : Azure.Operation<Azure.ResourceManager.Monitor.DataCollectionRuleAssociation>
    {
        protected DataCollectionRuleAssociationCreateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Monitor.DataCollectionRuleAssociation Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Monitor.DataCollectionRuleAssociation>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Monitor.DataCollectionRuleAssociation>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataCollectionRuleAssociationDeleteOperation : Azure.Operation
    {
        protected DataCollectionRuleAssociationDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataCollectionRuleCreateOperation : Azure.Operation<Azure.ResourceManager.Monitor.DataCollectionRule>
    {
        protected DataCollectionRuleCreateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Monitor.DataCollectionRule Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Monitor.DataCollectionRule>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Monitor.DataCollectionRule>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataCollectionRuleDeleteOperation : Azure.Operation
    {
        protected DataCollectionRuleDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataCollectionRulePropertiesDataSources : Azure.ResourceManager.Monitor.Models.DataSourcesSpec
    {
        public DataCollectionRulePropertiesDataSources() { }
    }
    public partial class DataCollectionRulePropertiesDestinations : Azure.ResourceManager.Monitor.Models.DestinationsSpec
    {
        public DataCollectionRulePropertiesDestinations() { }
    }
    public partial class DataCollectionRuleUpdateOperation : Azure.Operation<Azure.ResourceManager.Monitor.DataCollectionRule>
    {
        protected DataCollectionRuleUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Monitor.DataCollectionRule Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Monitor.DataCollectionRule>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Monitor.DataCollectionRule>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataContainer
    {
        public DataContainer(Azure.ResourceManager.Monitor.Models.WorkspaceInfo workspace) { }
        public Azure.ResourceManager.Monitor.Models.WorkspaceInfo Workspace { get { throw null; } set { } }
    }
    public partial class DataFlow
    {
        public DataFlow() { }
        public System.Collections.Generic.IList<string> Destinations { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.KnownDataFlowStreams> Streams { get { throw null; } }
    }
    public partial class DataSourcesSpec
    {
        public DataSourcesSpec() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.ExtensionDataSource> Extensions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.PerfCounterDataSource> PerformanceCounters { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.SyslogDataSource> Syslog { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.WindowsEventLogDataSource> WindowsEventLogs { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataStatus : System.IEquatable<Azure.ResourceManager.Monitor.Models.DataStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataStatus(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.DataStatus NotPresent { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.DataStatus Present { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.DataStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.DataStatus left, Azure.ResourceManager.Monitor.Models.DataStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.DataStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.DataStatus left, Azure.ResourceManager.Monitor.Models.DataStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DestinationsSpec
    {
        public DestinationsSpec() { }
        public Azure.ResourceManager.Monitor.Models.DestinationsSpecAzureMonitorMetrics AzureMonitorMetrics { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.LogAnalyticsDestination> LogAnalytics { get { throw null; } }
    }
    public partial class DestinationsSpecAzureMonitorMetrics : Azure.ResourceManager.Monitor.Models.AzureMonitorMetricsDestination
    {
        public DestinationsSpecAzureMonitorMetrics() { }
    }
    public partial class DiagnosticSettingCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Monitor.DiagnosticSettings>
    {
        protected DiagnosticSettingCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Monitor.DiagnosticSettings Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Monitor.DiagnosticSettings>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Monitor.DiagnosticSettings>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DiagnosticSettingDeleteOperation : Azure.Operation
    {
        protected DiagnosticSettingDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DiagnosticSettingsCategoryResourceCollection
    {
        internal DiagnosticSettingsCategoryResourceCollection() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Monitor.DiagnosticSettingsCategoryData> Value { get { throw null; } }
    }
    public partial class DiagnosticSettingsResourceCollection
    {
        internal DiagnosticSettingsResourceCollection() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Monitor.DiagnosticSettingsData> Value { get { throw null; } }
    }
    public partial class Dimension
    {
        public Dimension(string name, Azure.ResourceManager.Monitor.Models.Operator @operator, System.Collections.Generic.IEnumerable<string> values) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.Operator Operator { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
    }
    public partial class DynamicMetricCriteria : Azure.ResourceManager.Monitor.Models.MultiMetricCriteria
    {
        public DynamicMetricCriteria(string name, string metricName, Azure.ResourceManager.Monitor.Models.AggregationTypeEnum timeAggregation, Azure.ResourceManager.Monitor.Models.DynamicThresholdOperator @operator, Azure.ResourceManager.Monitor.Models.DynamicThresholdSensitivity alertSensitivity, Azure.ResourceManager.Monitor.Models.DynamicThresholdFailingPeriods failingPeriods) : base (default(string), default(string), default(Azure.ResourceManager.Monitor.Models.AggregationTypeEnum)) { }
        public Azure.ResourceManager.Monitor.Models.DynamicThresholdSensitivity AlertSensitivity { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.DynamicThresholdFailingPeriods FailingPeriods { get { throw null; } set { } }
        public System.DateTimeOffset? IgnoreDataBefore { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.DynamicThresholdOperator Operator { get { throw null; } set { } }
    }
    public partial class DynamicThresholdFailingPeriods
    {
        public DynamicThresholdFailingPeriods(float numberOfEvaluationPeriods, float minFailingPeriodsToAlert) { }
        public float MinFailingPeriodsToAlert { get { throw null; } set { } }
        public float NumberOfEvaluationPeriods { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DynamicThresholdOperator : System.IEquatable<Azure.ResourceManager.Monitor.Models.DynamicThresholdOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DynamicThresholdOperator(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.DynamicThresholdOperator GreaterOrLessThan { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.DynamicThresholdOperator GreaterThan { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.DynamicThresholdOperator LessThan { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.DynamicThresholdOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.DynamicThresholdOperator left, Azure.ResourceManager.Monitor.Models.DynamicThresholdOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.DynamicThresholdOperator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.DynamicThresholdOperator left, Azure.ResourceManager.Monitor.Models.DynamicThresholdOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DynamicThresholdSensitivity : System.IEquatable<Azure.ResourceManager.Monitor.Models.DynamicThresholdSensitivity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DynamicThresholdSensitivity(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.DynamicThresholdSensitivity High { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.DynamicThresholdSensitivity Low { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.DynamicThresholdSensitivity Medium { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.DynamicThresholdSensitivity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.DynamicThresholdSensitivity left, Azure.ResourceManager.Monitor.Models.DynamicThresholdSensitivity right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.DynamicThresholdSensitivity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.DynamicThresholdSensitivity left, Azure.ResourceManager.Monitor.Models.DynamicThresholdSensitivity right) { throw null; }
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
        public EmailReceiver(string name, string emailAddress) { }
        public string EmailAddress { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.ReceiverStatus? Status { get { throw null; } }
        public bool? UseCommonAlertSchema { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Enabled : System.IEquatable<Azure.ResourceManager.Monitor.Models.Enabled>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Enabled(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.Enabled False { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.Enabled True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.Enabled other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.Enabled left, Azure.ResourceManager.Monitor.Models.Enabled right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.Enabled (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.Enabled left, Azure.ResourceManager.Monitor.Models.Enabled right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EnableRequest
    {
        public EnableRequest(string receiverName) { }
        public string ReceiverName { get { throw null; } }
    }
    public partial class ErrorResponse
    {
        internal ErrorResponse() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
    }
    public partial class ErrorResponseCommon : Azure.ResourceManager.Monitor.Models.ErrorResponse
    {
        internal ErrorResponseCommon() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Models.ErrorAdditionalInfo> AdditionalInfo { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Monitor.Models.ErrorResponseCommon> Details { get { throw null; } }
    }
    public partial class EventData
    {
        internal EventData() { }
        public Azure.ResourceManager.Monitor.Models.SenderAuthorization Authorization { get { throw null; } }
        public string Caller { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.LocalizableString Category { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Claims { get { throw null; } }
        public string CorrelationId { get { throw null; } }
        public string Description { get { throw null; } }
        public string EventDataId { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.LocalizableString EventName { get { throw null; } }
        public System.DateTimeOffset? EventTimestamp { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.HttpRequestInfo HttpRequest { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.EventLevel? Level { get { throw null; } }
        public string OperationId { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.LocalizableString OperationName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Properties { get { throw null; } }
        public string ResourceGroupName { get { throw null; } }
        public string ResourceId { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.LocalizableString ResourceProviderName { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.LocalizableString ResourceType { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.LocalizableString Status { get { throw null; } }
        public System.DateTimeOffset? SubmissionTimestamp { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.LocalizableString SubStatus { get { throw null; } }
        public string TenantId { get { throw null; } }
    }
    public partial class EventHubReceiver
    {
        public EventHubReceiver(string name, string eventHubNameSpace, string eventHubName, string subscriptionId) { }
        public string EventHubName { get { throw null; } set { } }
        public string EventHubNameSpace { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public string TenantId { get { throw null; } set { } }
        public bool? UseCommonAlertSchema { get { throw null; } set { } }
    }
    public enum EventLevel
    {
        Critical = 0,
        Error = 1,
        Warning = 2,
        Informational = 3,
        Verbose = 4,
    }
    public partial class ExtensionDataSource
    {
        public ExtensionDataSource(string extensionName) { }
        public string ExtensionName { get { throw null; } set { } }
        public object ExtensionSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> InputDataSources { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.KnownExtensionDataSourceStreams> Streams { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KnownDataCollectionEndpointProvisioningState : System.IEquatable<Azure.ResourceManager.Monitor.Models.KnownDataCollectionEndpointProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KnownDataCollectionEndpointProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.KnownDataCollectionEndpointProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.KnownDataCollectionEndpointProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.KnownDataCollectionEndpointProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.KnownDataCollectionEndpointProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.KnownDataCollectionEndpointProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.KnownDataCollectionEndpointProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.KnownDataCollectionEndpointProvisioningState left, Azure.ResourceManager.Monitor.Models.KnownDataCollectionEndpointProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.KnownDataCollectionEndpointProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.KnownDataCollectionEndpointProvisioningState left, Azure.ResourceManager.Monitor.Models.KnownDataCollectionEndpointProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KnownDataCollectionEndpointResourceKind : System.IEquatable<Azure.ResourceManager.Monitor.Models.KnownDataCollectionEndpointResourceKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KnownDataCollectionEndpointResourceKind(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.KnownDataCollectionEndpointResourceKind Linux { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.KnownDataCollectionEndpointResourceKind Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.KnownDataCollectionEndpointResourceKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.KnownDataCollectionEndpointResourceKind left, Azure.ResourceManager.Monitor.Models.KnownDataCollectionEndpointResourceKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.KnownDataCollectionEndpointResourceKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.KnownDataCollectionEndpointResourceKind left, Azure.ResourceManager.Monitor.Models.KnownDataCollectionEndpointResourceKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KnownDataCollectionRuleAssociationProvisioningState : System.IEquatable<Azure.ResourceManager.Monitor.Models.KnownDataCollectionRuleAssociationProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KnownDataCollectionRuleAssociationProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.KnownDataCollectionRuleAssociationProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.KnownDataCollectionRuleAssociationProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.KnownDataCollectionRuleAssociationProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.KnownDataCollectionRuleAssociationProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.KnownDataCollectionRuleAssociationProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.KnownDataCollectionRuleAssociationProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.KnownDataCollectionRuleAssociationProvisioningState left, Azure.ResourceManager.Monitor.Models.KnownDataCollectionRuleAssociationProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.KnownDataCollectionRuleAssociationProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.KnownDataCollectionRuleAssociationProvisioningState left, Azure.ResourceManager.Monitor.Models.KnownDataCollectionRuleAssociationProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KnownDataCollectionRuleProvisioningState : System.IEquatable<Azure.ResourceManager.Monitor.Models.KnownDataCollectionRuleProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KnownDataCollectionRuleProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.KnownDataCollectionRuleProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.KnownDataCollectionRuleProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.KnownDataCollectionRuleProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.KnownDataCollectionRuleProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.KnownDataCollectionRuleProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.KnownDataCollectionRuleProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.KnownDataCollectionRuleProvisioningState left, Azure.ResourceManager.Monitor.Models.KnownDataCollectionRuleProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.KnownDataCollectionRuleProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.KnownDataCollectionRuleProvisioningState left, Azure.ResourceManager.Monitor.Models.KnownDataCollectionRuleProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KnownDataCollectionRuleResourceKind : System.IEquatable<Azure.ResourceManager.Monitor.Models.KnownDataCollectionRuleResourceKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KnownDataCollectionRuleResourceKind(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.KnownDataCollectionRuleResourceKind Linux { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.KnownDataCollectionRuleResourceKind Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.KnownDataCollectionRuleResourceKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.KnownDataCollectionRuleResourceKind left, Azure.ResourceManager.Monitor.Models.KnownDataCollectionRuleResourceKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.KnownDataCollectionRuleResourceKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.KnownDataCollectionRuleResourceKind left, Azure.ResourceManager.Monitor.Models.KnownDataCollectionRuleResourceKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KnownDataFlowStreams : System.IEquatable<Azure.ResourceManager.Monitor.Models.KnownDataFlowStreams>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KnownDataFlowStreams(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.KnownDataFlowStreams MicrosoftEvent { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.KnownDataFlowStreams MicrosoftInsightsMetrics { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.KnownDataFlowStreams MicrosoftPerf { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.KnownDataFlowStreams MicrosoftSyslog { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.KnownDataFlowStreams MicrosoftWindowsEvent { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.KnownDataFlowStreams other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.KnownDataFlowStreams left, Azure.ResourceManager.Monitor.Models.KnownDataFlowStreams right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.KnownDataFlowStreams (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.KnownDataFlowStreams left, Azure.ResourceManager.Monitor.Models.KnownDataFlowStreams right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KnownExtensionDataSourceStreams : System.IEquatable<Azure.ResourceManager.Monitor.Models.KnownExtensionDataSourceStreams>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KnownExtensionDataSourceStreams(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.KnownExtensionDataSourceStreams MicrosoftEvent { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.KnownExtensionDataSourceStreams MicrosoftInsightsMetrics { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.KnownExtensionDataSourceStreams MicrosoftPerf { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.KnownExtensionDataSourceStreams MicrosoftSyslog { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.KnownExtensionDataSourceStreams MicrosoftWindowsEvent { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.KnownExtensionDataSourceStreams other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.KnownExtensionDataSourceStreams left, Azure.ResourceManager.Monitor.Models.KnownExtensionDataSourceStreams right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.KnownExtensionDataSourceStreams (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.KnownExtensionDataSourceStreams left, Azure.ResourceManager.Monitor.Models.KnownExtensionDataSourceStreams right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KnownPerfCounterDataSourceStreams : System.IEquatable<Azure.ResourceManager.Monitor.Models.KnownPerfCounterDataSourceStreams>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KnownPerfCounterDataSourceStreams(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.KnownPerfCounterDataSourceStreams MicrosoftInsightsMetrics { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.KnownPerfCounterDataSourceStreams MicrosoftPerf { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.KnownPerfCounterDataSourceStreams other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.KnownPerfCounterDataSourceStreams left, Azure.ResourceManager.Monitor.Models.KnownPerfCounterDataSourceStreams right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.KnownPerfCounterDataSourceStreams (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.KnownPerfCounterDataSourceStreams left, Azure.ResourceManager.Monitor.Models.KnownPerfCounterDataSourceStreams right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KnownPublicNetworkAccessOptions : System.IEquatable<Azure.ResourceManager.Monitor.Models.KnownPublicNetworkAccessOptions>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KnownPublicNetworkAccessOptions(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.KnownPublicNetworkAccessOptions Disabled { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.KnownPublicNetworkAccessOptions Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.KnownPublicNetworkAccessOptions other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.KnownPublicNetworkAccessOptions left, Azure.ResourceManager.Monitor.Models.KnownPublicNetworkAccessOptions right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.KnownPublicNetworkAccessOptions (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.KnownPublicNetworkAccessOptions left, Azure.ResourceManager.Monitor.Models.KnownPublicNetworkAccessOptions right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KnownSyslogDataSourceFacilityNames : System.IEquatable<Azure.ResourceManager.Monitor.Models.KnownSyslogDataSourceFacilityNames>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KnownSyslogDataSourceFacilityNames(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.KnownSyslogDataSourceFacilityNames Asterisk { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.KnownSyslogDataSourceFacilityNames Auth { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.KnownSyslogDataSourceFacilityNames Authpriv { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.KnownSyslogDataSourceFacilityNames Cron { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.KnownSyslogDataSourceFacilityNames Daemon { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.KnownSyslogDataSourceFacilityNames Kern { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.KnownSyslogDataSourceFacilityNames Local0 { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.KnownSyslogDataSourceFacilityNames Local1 { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.KnownSyslogDataSourceFacilityNames Local2 { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.KnownSyslogDataSourceFacilityNames Local3 { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.KnownSyslogDataSourceFacilityNames Local4 { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.KnownSyslogDataSourceFacilityNames Local5 { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.KnownSyslogDataSourceFacilityNames Local6 { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.KnownSyslogDataSourceFacilityNames Local7 { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.KnownSyslogDataSourceFacilityNames Lpr { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.KnownSyslogDataSourceFacilityNames Mail { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.KnownSyslogDataSourceFacilityNames Mark { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.KnownSyslogDataSourceFacilityNames News { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.KnownSyslogDataSourceFacilityNames Syslog { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.KnownSyslogDataSourceFacilityNames User { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.KnownSyslogDataSourceFacilityNames Uucp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.KnownSyslogDataSourceFacilityNames other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.KnownSyslogDataSourceFacilityNames left, Azure.ResourceManager.Monitor.Models.KnownSyslogDataSourceFacilityNames right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.KnownSyslogDataSourceFacilityNames (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.KnownSyslogDataSourceFacilityNames left, Azure.ResourceManager.Monitor.Models.KnownSyslogDataSourceFacilityNames right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KnownSyslogDataSourceLogLevels : System.IEquatable<Azure.ResourceManager.Monitor.Models.KnownSyslogDataSourceLogLevels>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KnownSyslogDataSourceLogLevels(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.KnownSyslogDataSourceLogLevels Alert { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.KnownSyslogDataSourceLogLevels Asterisk { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.KnownSyslogDataSourceLogLevels Critical { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.KnownSyslogDataSourceLogLevels Debug { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.KnownSyslogDataSourceLogLevels Emergency { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.KnownSyslogDataSourceLogLevels Error { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.KnownSyslogDataSourceLogLevels Info { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.KnownSyslogDataSourceLogLevels Notice { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.KnownSyslogDataSourceLogLevels Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.KnownSyslogDataSourceLogLevels other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.KnownSyslogDataSourceLogLevels left, Azure.ResourceManager.Monitor.Models.KnownSyslogDataSourceLogLevels right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.KnownSyslogDataSourceLogLevels (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.KnownSyslogDataSourceLogLevels left, Azure.ResourceManager.Monitor.Models.KnownSyslogDataSourceLogLevels right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KnownSyslogDataSourceStreams : System.IEquatable<Azure.ResourceManager.Monitor.Models.KnownSyslogDataSourceStreams>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KnownSyslogDataSourceStreams(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.KnownSyslogDataSourceStreams MicrosoftSyslog { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.KnownSyslogDataSourceStreams other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.KnownSyslogDataSourceStreams left, Azure.ResourceManager.Monitor.Models.KnownSyslogDataSourceStreams right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.KnownSyslogDataSourceStreams (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.KnownSyslogDataSourceStreams left, Azure.ResourceManager.Monitor.Models.KnownSyslogDataSourceStreams right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KnownWindowsEventLogDataSourceStreams : System.IEquatable<Azure.ResourceManager.Monitor.Models.KnownWindowsEventLogDataSourceStreams>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KnownWindowsEventLogDataSourceStreams(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.KnownWindowsEventLogDataSourceStreams MicrosoftEvent { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.KnownWindowsEventLogDataSourceStreams MicrosoftWindowsEvent { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.KnownWindowsEventLogDataSourceStreams other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.KnownWindowsEventLogDataSourceStreams left, Azure.ResourceManager.Monitor.Models.KnownWindowsEventLogDataSourceStreams right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.KnownWindowsEventLogDataSourceStreams (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.KnownWindowsEventLogDataSourceStreams left, Azure.ResourceManager.Monitor.Models.KnownWindowsEventLogDataSourceStreams right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LocalizableString
    {
        internal LocalizableString() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class LocationThresholdRuleCondition : Azure.ResourceManager.Monitor.Models.RuleCondition
    {
        public LocationThresholdRuleCondition(int failedLocationCount) { }
        public int FailedLocationCount { get { throw null; } set { } }
        public System.TimeSpan? WindowSize { get { throw null; } set { } }
    }
    public partial class LogAnalyticsDestination
    {
        public LogAnalyticsDestination() { }
        public string Name { get { throw null; } set { } }
        public string WorkspaceId { get { throw null; } }
        public string WorkspaceResourceId { get { throw null; } set { } }
    }
    public partial class LogicAppReceiver
    {
        public LogicAppReceiver(string name, string resourceId, string callbackUrl) { }
        public string CallbackUrl { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
        public bool? UseCommonAlertSchema { get { throw null; } set { } }
    }
    public partial class LogMetricTrigger
    {
        public LogMetricTrigger() { }
        public string MetricColumn { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.MetricTriggerType? MetricTriggerType { get { throw null; } set { } }
        public double? Threshold { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.ConditionalOperator? ThresholdOperator { get { throw null; } set { } }
    }
    public partial class LogProfileCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Monitor.LogProfile>
    {
        protected LogProfileCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Monitor.LogProfile Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Monitor.LogProfile>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Monitor.LogProfile>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LogProfileDeleteOperation : Azure.Operation
    {
        protected LogProfileDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LogProfileResourcePatch
    {
        public LogProfileResourcePatch() { }
        public System.Collections.Generic.IList<string> Categories { get { throw null; } }
        public System.Collections.Generic.IList<string> Locations { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.RetentionPolicy RetentionPolicy { get { throw null; } set { } }
        public string ServiceBusRuleId { get { throw null; } set { } }
        public string StorageAccountId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class LogProfileUpdateOperation : Azure.Operation<Azure.ResourceManager.Monitor.LogProfile>
    {
        protected LogProfileUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Monitor.LogProfile Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Monitor.LogProfile>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Monitor.LogProfile>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LogSearchRuleResourcePatch
    {
        public LogSearchRuleResourcePatch() { }
        public Azure.ResourceManager.Monitor.Models.Enabled? Enabled { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class LogSettings
    {
        public LogSettings(bool enabled) { }
        public string Category { get { throw null; } set { } }
        public bool Enabled { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.RetentionPolicy RetentionPolicy { get { throw null; } set { } }
    }
    public partial class LogsIngestionEndpointSpec
    {
        public LogsIngestionEndpointSpec() { }
        public string Endpoint { get { throw null; } }
    }
    public partial class LogToMetricAction : Azure.ResourceManager.Monitor.Models.Action
    {
        public LogToMetricAction(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.Criteria> criteria) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.Criteria> Criteria { get { throw null; } }
    }
    public partial class ManagementEventAggregationCondition
    {
        public ManagementEventAggregationCondition() { }
        public Azure.ResourceManager.Monitor.Models.ConditionOperator? Operator { get { throw null; } set { } }
        public double? Threshold { get { throw null; } set { } }
        public System.TimeSpan? WindowSize { get { throw null; } set { } }
    }
    public partial class ManagementEventRuleCondition : Azure.ResourceManager.Monitor.Models.RuleCondition
    {
        public ManagementEventRuleCondition() { }
        public Azure.ResourceManager.Monitor.Models.ManagementEventAggregationCondition Aggregation { get { throw null; } set { } }
    }
    public partial class MetadataValue
    {
        internal MetadataValue() { }
        public Azure.ResourceManager.Monitor.Models.LocalizableString Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class Metric
    {
        internal Metric() { }
        public string DisplayDescription { get { throw null; } }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.LocalizableString Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Monitor.Models.TimeSeriesElement> Timeseries { get { throw null; } }
        public string Type { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.MetricUnit Unit { get { throw null; } }
    }
    public partial class MetricAlertAction
    {
        public MetricAlertAction() { }
        public string ActionGroupId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> WebHookProperties { get { throw null; } }
    }
    public partial class MetricAlertCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Monitor.MetricAlert>
    {
        protected MetricAlertCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Monitor.MetricAlert Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Monitor.MetricAlert>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Monitor.MetricAlert>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MetricAlertCriteria
    {
        public MetricAlertCriteria() { }
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get { throw null; } }
    }
    public partial class MetricAlertDeleteOperation : Azure.Operation
    {
        protected MetricAlertDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MetricAlertMultipleResourceMultipleMetricCriteria : Azure.ResourceManager.Monitor.Models.MetricAlertCriteria
    {
        public MetricAlertMultipleResourceMultipleMetricCriteria() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.MultiMetricCriteria> AllOf { get { throw null; } }
    }
    public partial class MetricAlertResourcePatch
    {
        public MetricAlertResourcePatch() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.MetricAlertAction> Actions { get { throw null; } }
        public bool? AutoMitigate { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.MetricAlertCriteria Criteria { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
        public System.TimeSpan? EvaluationFrequency { get { throw null; } set { } }
        public bool? IsMigrated { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedTime { get { throw null; } }
        public System.Collections.Generic.IList<string> Scopes { get { throw null; } }
        public int? Severity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string TargetResourceRegion { get { throw null; } set { } }
        public string TargetResourceType { get { throw null; } set { } }
        public System.TimeSpan? WindowSize { get { throw null; } set { } }
    }
    public partial class MetricAlertSingleResourceMultipleMetricCriteria : Azure.ResourceManager.Monitor.Models.MetricAlertCriteria
    {
        public MetricAlertSingleResourceMultipleMetricCriteria() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.MetricCriteria> AllOf { get { throw null; } }
    }
    public partial class MetricAlertStatus : Azure.ResourceManager.Models.Resource
    {
        internal MetricAlertStatus() { }
        public Azure.ResourceManager.Monitor.Models.MetricAlertStatusProperties Properties { get { throw null; } }
    }
    public partial class MetricAlertStatusCollection
    {
        internal MetricAlertStatusCollection() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Monitor.Models.MetricAlertStatus> Value { get { throw null; } }
    }
    public partial class MetricAlertStatusProperties
    {
        internal MetricAlertStatusProperties() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Dimensions { get { throw null; } }
        public string Status { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
    }
    public partial class MetricAlertUpdateOperation : Azure.Operation<Azure.ResourceManager.Monitor.MetricAlert>
    {
        protected MetricAlertUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Monitor.MetricAlert Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Monitor.MetricAlert>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Monitor.MetricAlert>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MetricAvailability
    {
        internal MetricAvailability() { }
        public System.TimeSpan? Retention { get { throw null; } }
        public System.TimeSpan? TimeGrain { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MetricClass : System.IEquatable<Azure.ResourceManager.Monitor.Models.MetricClass>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MetricClass(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.MetricClass Availability { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MetricClass Errors { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MetricClass Latency { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MetricClass Saturation { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MetricClass Transactions { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.MetricClass other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.MetricClass left, Azure.ResourceManager.Monitor.Models.MetricClass right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.MetricClass (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.MetricClass left, Azure.ResourceManager.Monitor.Models.MetricClass right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MetricCriteria : Azure.ResourceManager.Monitor.Models.MultiMetricCriteria
    {
        public MetricCriteria(string name, string metricName, Azure.ResourceManager.Monitor.Models.AggregationTypeEnum timeAggregation, Azure.ResourceManager.Monitor.Models.Operator @operator, double threshold) : base (default(string), default(string), default(Azure.ResourceManager.Monitor.Models.AggregationTypeEnum)) { }
        public Azure.ResourceManager.Monitor.Models.Operator Operator { get { throw null; } set { } }
        public double Threshold { get { throw null; } set { } }
    }
    public partial class MetricDefinition
    {
        internal MetricDefinition() { }
        public string Category { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Monitor.Models.LocalizableString> Dimensions { get { throw null; } }
        public string DisplayDescription { get { throw null; } }
        public string Id { get { throw null; } }
        public bool? IsDimensionRequired { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Monitor.Models.MetricAvailability> MetricAvailabilities { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.MetricClass? MetricClass { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.LocalizableString Name { get { throw null; } }
        public string Namespace { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.AggregationType? PrimaryAggregationType { get { throw null; } }
        public string ResourceId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Monitor.Models.AggregationType> SupportedAggregationTypes { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.MetricUnit? Unit { get { throw null; } }
    }
    public partial class MetricDimension
    {
        public MetricDimension(string name, string @operator, System.Collections.Generic.IEnumerable<string> values) { }
        public string Name { get { throw null; } set { } }
        public string Operator { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
    }
    public partial class MetricNamespace : Azure.ResourceManager.Models.Resource
    {
        internal MetricNamespace() { }
        public Azure.ResourceManager.Monitor.Models.NamespaceClassification? Classification { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.MetricNamespaceName Properties { get { throw null; } }
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
        public Azure.ResourceManager.Monitor.Models.RetentionPolicy RetentionPolicy { get { throw null; } set { } }
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
        Count = 4,
    }
    public partial class MetricTrigger
    {
        public MetricTrigger(string metricName, string metricResourceUri, System.TimeSpan timeGrain, Azure.ResourceManager.Monitor.Models.MetricStatisticType statistic, System.TimeSpan timeWindow, Azure.ResourceManager.Monitor.Models.TimeAggregationType timeAggregation, Azure.ResourceManager.Monitor.Models.ComparisonOperationType @operator, double threshold) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.ScaleRuleMetricDimension> Dimensions { get { throw null; } }
        public bool? DividePerInstance { get { throw null; } set { } }
        public string MetricName { get { throw null; } set { } }
        public string MetricNamespace { get { throw null; } set { } }
        public string MetricResourceLocation { get { throw null; } set { } }
        public string MetricResourceUri { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.ComparisonOperationType Operator { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.MetricStatisticType Statistic { get { throw null; } set { } }
        public double Threshold { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.TimeAggregationType TimeAggregation { get { throw null; } set { } }
        public System.TimeSpan TimeGrain { get { throw null; } set { } }
        public System.TimeSpan TimeWindow { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MetricTriggerType : System.IEquatable<Azure.ResourceManager.Monitor.Models.MetricTriggerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MetricTriggerType(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.MetricTriggerType Consecutive { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MetricTriggerType Total { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.MetricTriggerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.MetricTriggerType left, Azure.ResourceManager.Monitor.Models.MetricTriggerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.MetricTriggerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.MetricTriggerType left, Azure.ResourceManager.Monitor.Models.MetricTriggerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MetricUnit : System.IEquatable<Azure.ResourceManager.Monitor.Models.MetricUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MetricUnit(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.MetricUnit BitsPerSecond { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MetricUnit Bytes { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MetricUnit ByteSeconds { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MetricUnit BytesPerSecond { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MetricUnit Cores { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MetricUnit Count { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MetricUnit CountPerSecond { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MetricUnit MilliCores { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MetricUnit MilliSeconds { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MetricUnit NanoCores { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MetricUnit Percent { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MetricUnit Seconds { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MetricUnit Unspecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.MetricUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.MetricUnit left, Azure.ResourceManager.Monitor.Models.MetricUnit right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.MetricUnit (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.MetricUnit left, Azure.ResourceManager.Monitor.Models.MetricUnit right) { throw null; }
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
    public partial class MultiMetricCriteria
    {
        public MultiMetricCriteria(string name, string metricName, Azure.ResourceManager.Monitor.Models.AggregationTypeEnum timeAggregation) { }
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.MetricDimension> Dimensions { get { throw null; } }
        public string MetricName { get { throw null; } set { } }
        public string MetricNamespace { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public bool? SkipMetricValidation { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.AggregationTypeEnum TimeAggregation { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NamespaceClassification : System.IEquatable<Azure.ResourceManager.Monitor.Models.NamespaceClassification>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NamespaceClassification(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.NamespaceClassification Custom { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.NamespaceClassification Platform { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.NamespaceClassification Qos { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.NamespaceClassification other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.NamespaceClassification left, Azure.ResourceManager.Monitor.Models.NamespaceClassification right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.NamespaceClassification (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.NamespaceClassification left, Azure.ResourceManager.Monitor.Models.NamespaceClassification right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetworkRuleSet
    {
        public NetworkRuleSet() { }
        public Azure.ResourceManager.Monitor.Models.KnownPublicNetworkAccessOptions? PublicNetworkAccess { get { throw null; } set { } }
    }
    public partial class NotificationRequestBody
    {
        public NotificationRequestBody(string alertType) { }
        public string AlertType { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.ArmRoleReceiver> ArmRoleReceivers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.AutomationRunbookReceiver> AutomationRunbookReceivers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.AzureAppPushReceiver> AzureAppPushReceivers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.AzureFunctionReceiver> AzureFunctionReceivers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.EmailReceiver> EmailReceivers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.EventHubReceiver> EventHubReceivers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.ItsmReceiver> ItsmReceivers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.LogicAppReceiver> LogicAppReceivers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.SmsReceiver> SmsReceivers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.VoiceReceiver> VoiceReceivers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.WebhookReceiver> WebhookReceivers { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Odatatype : System.IEquatable<Azure.ResourceManager.Monitor.Models.Odatatype>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Odatatype(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.Odatatype MicrosoftAzureMonitorMultipleResourceMultipleMetricCriteria { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.Odatatype MicrosoftAzureMonitorSingleResourceMultipleMetricCriteria { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.Odatatype MicrosoftAzureMonitorWebtestLocationAvailabilityCriteria { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.Odatatype other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.Odatatype left, Azure.ResourceManager.Monitor.Models.Odatatype right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.Odatatype (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.Odatatype left, Azure.ResourceManager.Monitor.Models.Odatatype right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OnboardingStatus : System.IEquatable<Azure.ResourceManager.Monitor.Models.OnboardingStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OnboardingStatus(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.OnboardingStatus NotOnboarded { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.OnboardingStatus Onboarded { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.OnboardingStatus Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.OnboardingStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.OnboardingStatus left, Azure.ResourceManager.Monitor.Models.OnboardingStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.OnboardingStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.OnboardingStatus left, Azure.ResourceManager.Monitor.Models.OnboardingStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OperationStatus
    {
        internal OperationStatus() { }
        public System.DateTimeOffset? EndTime { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.ErrorResponseCommon Error { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.DateTimeOffset? StartTime { get { throw null; } }
        public string Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Operator : System.IEquatable<Azure.ResourceManager.Monitor.Models.Operator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Operator(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.Operator EqualsValue { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.Operator GreaterThan { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.Operator GreaterThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.Operator Include { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.Operator LessThan { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.Operator LessThanOrEqual { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.Operator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.Operator left, Azure.ResourceManager.Monitor.Models.Operator right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.Operator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.Operator left, Azure.ResourceManager.Monitor.Models.Operator right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PerfCounterDataSource
    {
        public PerfCounterDataSource() { }
        public System.Collections.Generic.IList<string> CounterSpecifiers { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public int? SamplingFrequencyInSeconds { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.KnownPerfCounterDataSourceStreams> Streams { get { throw null; } }
    }
    public partial class PrivateEndpointConnectionCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Monitor.PrivateEndpointConnection>
    {
        protected PrivateEndpointConnectionCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Monitor.PrivateEndpointConnection Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Monitor.PrivateEndpointConnection>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Monitor.PrivateEndpointConnection>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateEndpointConnectionDeleteOperation : Azure.Operation
    {
        protected PrivateEndpointConnectionDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateLinkScopeCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Monitor.PrivateLinkScope>
    {
        protected PrivateLinkScopeCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Monitor.PrivateLinkScope Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Monitor.PrivateLinkScope>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Monitor.PrivateLinkScope>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateLinkScopeDeleteOperation : Azure.Operation
    {
        protected PrivateLinkScopeDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateLinkScopedResourceCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Monitor.ScopedPrivateLink>
    {
        protected PrivateLinkScopedResourceCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Monitor.ScopedPrivateLink Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Monitor.ScopedPrivateLink>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Monitor.ScopedPrivateLink>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateLinkScopedResourceDeleteOperation : Azure.Operation
    {
        protected PrivateLinkScopedResourceDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateLinkScopeUpdateTagsOperation : Azure.Operation<Azure.ResourceManager.Monitor.PrivateLinkScope>
    {
        protected PrivateLinkScopeUpdateTagsOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Monitor.PrivateLinkScope Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Monitor.PrivateLinkScope>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Monitor.PrivateLinkScope>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateLinkServiceConnectionStateProperty
    {
        public PrivateLinkServiceConnectionStateProperty(string status, string description) { }
        public string ActionsRequired { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.Monitor.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.ProvisioningState Deploying { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.ProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.ProvisioningState left, Azure.ResourceManager.Monitor.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.ProvisioningState left, Azure.ResourceManager.Monitor.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QueryType : System.IEquatable<Azure.ResourceManager.Monitor.Models.QueryType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QueryType(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.QueryType ResultCount { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.QueryType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.QueryType left, Azure.ResourceManager.Monitor.Models.QueryType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.QueryType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.QueryType left, Azure.ResourceManager.Monitor.Models.QueryType right) { throw null; }
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
        public Recurrence(Azure.ResourceManager.Monitor.Models.RecurrenceFrequency frequency, Azure.ResourceManager.Monitor.Models.RecurrentSchedule schedule) { }
        public Azure.ResourceManager.Monitor.Models.RecurrenceFrequency Frequency { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.RecurrentSchedule Schedule { get { throw null; } set { } }
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
    public partial class ResourceAutoGenerated : Azure.ResourceManager.Models.TrackedResource
    {
        public ResourceAutoGenerated(Azure.ResourceManager.Resources.Models.Location location) : base (default(Azure.ResourceManager.Resources.Models.Location)) { }
        public string Etag { get { throw null; } }
        public string Kind { get { throw null; } }
    }
    public partial class ResourceForUpdate
    {
        public ResourceForUpdate() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class Response
    {
        internal Response() { }
        public int? Cost { get { throw null; } }
        public System.TimeSpan? Interval { get { throw null; } }
        public string Namespace { get { throw null; } }
        public string Resourceregion { get { throw null; } }
        public string Timespan { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Monitor.Models.Metric> Value { get { throw null; } }
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
        public Azure.ResourceManager.Monitor.Models.RuleDataSource DataSource { get { throw null; } set { } }
    }
    public partial class RuleDataSource
    {
        public RuleDataSource() { }
        public string LegacyResourceId { get { throw null; } set { } }
        public string MetricNamespace { get { throw null; } set { } }
        public string ResourceLocation { get { throw null; } set { } }
        public string ResourceUri { get { throw null; } set { } }
    }
    public partial class RuleEmailAction : Azure.ResourceManager.Monitor.Models.RuleAction
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
    public partial class RuleManagementEventDataSource : Azure.ResourceManager.Monitor.Models.RuleDataSource
    {
        public RuleManagementEventDataSource() { }
        public Azure.ResourceManager.Monitor.Models.RuleManagementEventClaimsDataSource Claims { get { throw null; } set { } }
        public string EventName { get { throw null; } set { } }
        public string EventSource { get { throw null; } set { } }
        public string Level { get { throw null; } set { } }
        public string OperationName { get { throw null; } set { } }
        public string ResourceGroupName { get { throw null; } set { } }
        public string ResourceProviderName { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
        public string SubStatus { get { throw null; } set { } }
    }
    public partial class RuleMetricDataSource : Azure.ResourceManager.Monitor.Models.RuleDataSource
    {
        public RuleMetricDataSource() { }
        public string MetricName { get { throw null; } set { } }
    }
    public partial class RuleWebhookAction : Azure.ResourceManager.Monitor.Models.RuleAction
    {
        public RuleWebhookAction() { }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public string ServiceUri { get { throw null; } set { } }
    }
    public partial class ScaleAction
    {
        public ScaleAction(Azure.ResourceManager.Monitor.Models.ScaleDirection direction, Azure.ResourceManager.Monitor.Models.ScaleType type, System.TimeSpan cooldown) { }
        public System.TimeSpan Cooldown { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.ScaleDirection Direction { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.ScaleType Type { get { throw null; } set { } }
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
        public ScaleRule(Azure.ResourceManager.Monitor.Models.MetricTrigger metricTrigger, Azure.ResourceManager.Monitor.Models.ScaleAction scaleAction) { }
        public Azure.ResourceManager.Monitor.Models.MetricTrigger MetricTrigger { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.ScaleAction ScaleAction { get { throw null; } set { } }
    }
    public partial class ScaleRuleMetricDimension
    {
        public ScaleRuleMetricDimension(string dimensionName, Azure.ResourceManager.Monitor.Models.ScaleRuleMetricDimensionOperationType @operator, System.Collections.Generic.IEnumerable<string> values) { }
        public string DimensionName { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.ScaleRuleMetricDimensionOperationType Operator { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScaleRuleMetricDimensionOperationType : System.IEquatable<Azure.ResourceManager.Monitor.Models.ScaleRuleMetricDimensionOperationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScaleRuleMetricDimensionOperationType(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.ScaleRuleMetricDimensionOperationType EqualsValue { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.ScaleRuleMetricDimensionOperationType NotEquals { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.ScaleRuleMetricDimensionOperationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.ScaleRuleMetricDimensionOperationType left, Azure.ResourceManager.Monitor.Models.ScaleRuleMetricDimensionOperationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.ScaleRuleMetricDimensionOperationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.ScaleRuleMetricDimensionOperationType left, Azure.ResourceManager.Monitor.Models.ScaleRuleMetricDimensionOperationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum ScaleType
    {
        ChangeCount = 0,
        PercentChangeCount = 1,
        ExactCount = 2,
        ServiceAllowedNextValue = 3,
    }
    public partial class Schedule
    {
        public Schedule(int frequencyInMinutes, int timeWindowInMinutes) { }
        public int FrequencyInMinutes { get { throw null; } set { } }
        public int TimeWindowInMinutes { get { throw null; } set { } }
    }
    public partial class ScheduledQueryRuleCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Monitor.LogSearchRule>
    {
        protected ScheduledQueryRuleCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Monitor.LogSearchRule Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Monitor.LogSearchRule>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Monitor.LogSearchRule>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ScheduledQueryRuleDeleteOperation : Azure.Operation
    {
        protected ScheduledQueryRuleDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ScheduledQueryRuleUpdateOperation : Azure.Operation<Azure.ResourceManager.Monitor.LogSearchRule>
    {
        protected ScheduledQueryRuleUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Monitor.LogSearchRule Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Monitor.LogSearchRule>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Monitor.LogSearchRule>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SenderAuthorization
    {
        internal SenderAuthorization() { }
        public string Action { get { throw null; } }
        public string Role { get { throw null; } }
        public string Scope { get { throw null; } }
    }
    public partial class SingleBaseline
    {
        internal SingleBaseline() { }
        public System.Collections.Generic.IReadOnlyList<double> HighThresholds { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<double> LowThresholds { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.BaselineSensitivity Sensitivity { get { throw null; } }
    }
    public partial class SingleMetricBaseline : Azure.ResourceManager.Models.Resource
    {
        internal SingleMetricBaseline() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Monitor.Models.TimeSeriesBaseline> Baselines { get { throw null; } }
        public System.TimeSpan Interval { get { throw null; } }
        public string Namespace { get { throw null; } }
        public string Timespan { get { throw null; } }
    }
    public partial class SmsReceiver
    {
        public SmsReceiver(string name, string countryCode, string phoneNumber) { }
        public string CountryCode { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string PhoneNumber { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.ReceiverStatus? Status { get { throw null; } }
    }
    public partial class Source
    {
        public Source(string dataSourceId) { }
        public System.Collections.Generic.IList<string> AuthorizedResources { get { throw null; } }
        public string DataSourceId { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.QueryType? QueryType { get { throw null; } set { } }
    }
    public partial class SyslogDataSource
    {
        public SyslogDataSource() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.KnownSyslogDataSourceFacilityNames> FacilityNames { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.KnownSyslogDataSourceLogLevels> LogLevels { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.KnownSyslogDataSourceStreams> Streams { get { throw null; } }
    }
    public partial class TagsResource
    {
        public TagsResource() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class TestNotificationDetailsResponse
    {
        internal TestNotificationDetailsResponse() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Monitor.Models.ActionDetail> ActionDetails { get { throw null; } }
        public string CompletedTime { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.Context Context { get { throw null; } }
        public string CreatedTime { get { throw null; } }
        public string State { get { throw null; } }
    }
    public partial class TestNotificationResponse
    {
        internal TestNotificationResponse() { }
        public string CorrelationId { get { throw null; } }
        public string CreatedTime { get { throw null; } }
        public string NotificationId { get { throw null; } }
    }
    public partial class ThresholdRuleCondition : Azure.ResourceManager.Monitor.Models.RuleCondition
    {
        public ThresholdRuleCondition(Azure.ResourceManager.Monitor.Models.ConditionOperator @operator, double threshold) { }
        public Azure.ResourceManager.Monitor.Models.ConditionOperator Operator { get { throw null; } set { } }
        public double Threshold { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.TimeAggregationOperator? TimeAggregation { get { throw null; } set { } }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Monitor.Models.SingleBaseline> Data { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Monitor.Models.MetricSingleDimension> Dimensions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Monitor.Models.BaselineMetadata> MetadataValues { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.DateTimeOffset> Timestamps { get { throw null; } }
    }
    public partial class TimeSeriesElement
    {
        internal TimeSeriesElement() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Monitor.Models.MetricValue> Data { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Monitor.Models.MetadataValue> Metadatavalues { get { throw null; } }
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
        public TriggerCondition(Azure.ResourceManager.Monitor.Models.ConditionalOperator thresholdOperator, double threshold) { }
        public Azure.ResourceManager.Monitor.Models.LogMetricTrigger MetricTrigger { get { throw null; } set { } }
        public double Threshold { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.ConditionalOperator ThresholdOperator { get { throw null; } set { } }
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
        public WebhookReceiver(string name, string serviceUri) { }
        public string IdentifierUri { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string ObjectId { get { throw null; } set { } }
        public string ServiceUri { get { throw null; } set { } }
        public string TenantId { get { throw null; } set { } }
        public bool? UseAadAuth { get { throw null; } set { } }
        public bool? UseCommonAlertSchema { get { throw null; } set { } }
    }
    public partial class WebtestLocationAvailabilityCriteria : Azure.ResourceManager.Monitor.Models.MetricAlertCriteria
    {
        public WebtestLocationAvailabilityCriteria(string webTestId, string componentId, float failedLocationCount) { }
        public string ComponentId { get { throw null; } set { } }
        public float FailedLocationCount { get { throw null; } set { } }
        public string WebTestId { get { throw null; } set { } }
    }
    public partial class WindowsEventLogDataSource
    {
        public WindowsEventLogDataSource() { }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.KnownWindowsEventLogDataSourceStreams> Streams { get { throw null; } }
        public System.Collections.Generic.IList<string> XPathQueries { get { throw null; } }
    }
    public partial class WorkspaceInfo
    {
        public WorkspaceInfo(string id, string location, string customerId) { }
        public string CustomerId { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
    }
}
