namespace Azure.ResourceManager.Monitor
{
    public partial class ActionGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.ActionGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.ActionGroupResource>, System.Collections.IEnumerable
    {
        protected ActionGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.ActionGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string actionGroupName, Azure.ResourceManager.Monitor.ActionGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.ActionGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string actionGroupName, Azure.ResourceManager.Monitor.ActionGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string actionGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string actionGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.ActionGroupResource> Get(string actionGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.ActionGroupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.ActionGroupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.ActionGroupResource>> GetAsync(string actionGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Monitor.ActionGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.ActionGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Monitor.ActionGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.ActionGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ActionGroupData : Azure.ResourceManager.Monitor.Models.AzureResource
    {
        public ActionGroupData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
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
    public partial class ActionGroupResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ActionGroupResource() { }
        public virtual Azure.ResourceManager.Monitor.ActionGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.ActionGroupResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.ActionGroupResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string actionGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response EnableReceiver(Azure.ResourceManager.Monitor.Models.EnableContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> EnableReceiverAsync(Azure.ResourceManager.Monitor.Models.EnableContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.ActionGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.ActionGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.ActionGroupResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.ActionGroupResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.ActionGroupResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.ActionGroupResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.ActionGroupResource> Update(Azure.ResourceManager.Monitor.Models.ActionGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.ActionGroupResource>> UpdateAsync(Azure.ResourceManager.Monitor.Models.ActionGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ActivityLogAlertCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.ActivityLogAlertResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.ActivityLogAlertResource>, System.Collections.IEnumerable
    {
        protected ActivityLogAlertCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.ActivityLogAlertResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string activityLogAlertName, Azure.ResourceManager.Monitor.ActivityLogAlertData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.ActivityLogAlertResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string activityLogAlertName, Azure.ResourceManager.Monitor.ActivityLogAlertData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string activityLogAlertName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string activityLogAlertName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.ActivityLogAlertResource> Get(string activityLogAlertName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.ActivityLogAlertResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.ActivityLogAlertResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.ActivityLogAlertResource>> GetAsync(string activityLogAlertName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Monitor.ActivityLogAlertResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.ActivityLogAlertResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Monitor.ActivityLogAlertResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.ActivityLogAlertResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ActivityLogAlertData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ActivityLogAlertData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.ActivityLogAlertActionGroup> ActionsActionGroups { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.ActivityLogAlertLeafCondition> ConditionAllOf { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Scopes { get { throw null; } }
    }
    public partial class ActivityLogAlertResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ActivityLogAlertResource() { }
        public virtual Azure.ResourceManager.Monitor.ActivityLogAlertData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.ActivityLogAlertResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.ActivityLogAlertResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string activityLogAlertName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.ActivityLogAlertResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.ActivityLogAlertResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.ActivityLogAlertResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.ActivityLogAlertResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.ActivityLogAlertResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.ActivityLogAlertResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.ActivityLogAlertResource> Update(Azure.ResourceManager.Monitor.Models.ActivityLogAlertPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.ActivityLogAlertResource>> UpdateAsync(Azure.ResourceManager.Monitor.Models.ActivityLogAlertPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AlertRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.AlertRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.AlertRuleResource>, System.Collections.IEnumerable
    {
        protected AlertRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.AlertRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string ruleName, Azure.ResourceManager.Monitor.AlertRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.AlertRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string ruleName, Azure.ResourceManager.Monitor.AlertRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.AlertRuleResource> Get(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.AlertRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.AlertRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.AlertRuleResource>> GetAsync(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Monitor.AlertRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.AlertRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Monitor.AlertRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.AlertRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AlertRuleData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public AlertRuleData(Azure.Core.AzureLocation location, string namePropertiesName, bool isEnabled, Azure.ResourceManager.Monitor.Models.RuleCondition condition) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Monitor.Models.RuleAction Action { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.RuleAction> Actions { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.RuleCondition Condition { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public bool IsEnabled { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
        public string NamePropertiesName { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } set { } }
    }
    public partial class AlertRuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AlertRuleResource() { }
        public virtual Azure.ResourceManager.Monitor.AlertRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.AlertRuleResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.AlertRuleResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string ruleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.AlertRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.Models.MonitorIncident> GetAlertRuleIncident(string incidentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.Models.MonitorIncident>> GetAlertRuleIncidentAsync(string incidentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.Models.MonitorIncident> GetAlertRuleIncidents(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.Models.MonitorIncident> GetAlertRuleIncidentsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.AlertRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.AlertRuleResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.AlertRuleResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.AlertRuleResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.AlertRuleResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.AlertRuleResource> Update(Azure.ResourceManager.Monitor.Models.AlertRulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.AlertRuleResource>> UpdateAsync(Azure.ResourceManager.Monitor.Models.AlertRulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AutoscaleSettingCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.AutoscaleSettingResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.AutoscaleSettingResource>, System.Collections.IEnumerable
    {
        protected AutoscaleSettingCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.AutoscaleSettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string autoscaleSettingName, Azure.ResourceManager.Monitor.AutoscaleSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.AutoscaleSettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string autoscaleSettingName, Azure.ResourceManager.Monitor.AutoscaleSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string autoscaleSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string autoscaleSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.AutoscaleSettingResource> Get(string autoscaleSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.AutoscaleSettingResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.AutoscaleSettingResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.AutoscaleSettingResource>> GetAsync(string autoscaleSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Monitor.AutoscaleSettingResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.AutoscaleSettingResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Monitor.AutoscaleSettingResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.AutoscaleSettingResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AutoscaleSettingData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public AutoscaleSettingData(Azure.Core.AzureLocation location, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.AutoscaleProfile> profiles) : base (default(Azure.Core.AzureLocation)) { }
        public bool? Enabled { get { throw null; } set { } }
        public string NamePropertiesName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.AutoscaleNotification> Notifications { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.AutoscaleProfile> Profiles { get { throw null; } }
        public string TargetResourceId { get { throw null; } set { } }
        public string TargetResourceLocation { get { throw null; } set { } }
    }
    public partial class AutoscaleSettingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AutoscaleSettingResource() { }
        public virtual Azure.ResourceManager.Monitor.AutoscaleSettingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.AutoscaleSettingResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.AutoscaleSettingResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string autoscaleSettingName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.AutoscaleSettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.AutoscaleSettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.AutoscaleSettingResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.AutoscaleSettingResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.AutoscaleSettingResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.AutoscaleSettingResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.AutoscaleSettingResource> Update(Azure.ResourceManager.Monitor.Models.AutoscaleSettingPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.AutoscaleSettingResource>> UpdateAsync(Azure.ResourceManager.Monitor.Models.AutoscaleSettingPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataCollectionEndpointCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.DataCollectionEndpointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.DataCollectionEndpointResource>, System.Collections.IEnumerable
    {
        protected DataCollectionEndpointCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.DataCollectionEndpointResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string dataCollectionEndpointName, Azure.ResourceManager.Monitor.DataCollectionEndpointData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.DataCollectionEndpointResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dataCollectionEndpointName, Azure.ResourceManager.Monitor.DataCollectionEndpointData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dataCollectionEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dataCollectionEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.DataCollectionEndpointResource> Get(string dataCollectionEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.DataCollectionEndpointResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.DataCollectionEndpointResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.DataCollectionEndpointResource>> GetAsync(string dataCollectionEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Monitor.DataCollectionEndpointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.DataCollectionEndpointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Monitor.DataCollectionEndpointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.DataCollectionEndpointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataCollectionEndpointData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public DataCollectionEndpointData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string Etag { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.KnownDataCollectionEndpointResourceKind? Kind { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.DataCollectionEndpointProperties Properties { get { throw null; } set { } }
    }
    public partial class DataCollectionEndpointResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataCollectionEndpointResource() { }
        public virtual Azure.ResourceManager.Monitor.DataCollectionEndpointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.DataCollectionEndpointResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.DataCollectionEndpointResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string dataCollectionEndpointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.DataCollectionEndpointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.DataCollectionEndpointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.DataCollectionEndpointResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.DataCollectionEndpointResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.DataCollectionEndpointResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.DataCollectionEndpointResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.DataCollectionEndpointResource> Update(Azure.ResourceManager.Monitor.Models.ResourceForUpdate body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.DataCollectionEndpointResource>> UpdateAsync(Azure.ResourceManager.Monitor.Models.ResourceForUpdate body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataCollectionRuleAssociationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.DataCollectionRuleAssociationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.DataCollectionRuleAssociationResource>, System.Collections.IEnumerable
    {
        protected DataCollectionRuleAssociationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.DataCollectionRuleAssociationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string associationName, Azure.ResourceManager.Monitor.DataCollectionRuleAssociationData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.DataCollectionRuleAssociationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string associationName, Azure.ResourceManager.Monitor.DataCollectionRuleAssociationData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.DataCollectionRuleAssociationResource> Get(string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.DataCollectionRuleAssociationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.DataCollectionRuleAssociationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.DataCollectionRuleAssociationResource>> GetAsync(string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Monitor.DataCollectionRuleAssociationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.DataCollectionRuleAssociationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Monitor.DataCollectionRuleAssociationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.DataCollectionRuleAssociationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataCollectionRuleAssociationData : Azure.ResourceManager.Models.ResourceData
    {
        public DataCollectionRuleAssociationData() { }
        public string Etag { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.DataCollectionRuleAssociationProperties Properties { get { throw null; } set { } }
    }
    public partial class DataCollectionRuleAssociationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataCollectionRuleAssociationResource() { }
        public virtual Azure.ResourceManager.Monitor.DataCollectionRuleAssociationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri, string associationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.DataCollectionRuleAssociationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.DataCollectionRuleAssociationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.DataCollectionRuleAssociationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Monitor.DataCollectionRuleAssociationData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.DataCollectionRuleAssociationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Monitor.DataCollectionRuleAssociationData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataCollectionRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.DataCollectionRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.DataCollectionRuleResource>, System.Collections.IEnumerable
    {
        protected DataCollectionRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.DataCollectionRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string dataCollectionRuleName, Azure.ResourceManager.Monitor.DataCollectionRuleData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.DataCollectionRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dataCollectionRuleName, Azure.ResourceManager.Monitor.DataCollectionRuleData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dataCollectionRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dataCollectionRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.DataCollectionRuleResource> Get(string dataCollectionRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.DataCollectionRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.DataCollectionRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.DataCollectionRuleResource>> GetAsync(string dataCollectionRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Monitor.DataCollectionRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.DataCollectionRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Monitor.DataCollectionRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.DataCollectionRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataCollectionRuleData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public DataCollectionRuleData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string Etag { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.KnownDataCollectionRuleResourceKind? Kind { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.DataCollectionRuleProperties Properties { get { throw null; } set { } }
    }
    public partial class DataCollectionRuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataCollectionRuleResource() { }
        public virtual Azure.ResourceManager.Monitor.DataCollectionRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.DataCollectionRuleResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.DataCollectionRuleResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string dataCollectionRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.DataCollectionRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.DataCollectionRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.DataCollectionRuleAssociationResource> GetDataCollectionRuleAssociationsByRule(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.DataCollectionRuleAssociationResource> GetDataCollectionRuleAssociationsByRuleAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.DataCollectionRuleResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.DataCollectionRuleResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.DataCollectionRuleResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.DataCollectionRuleResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.DataCollectionRuleResource> Update(Azure.ResourceManager.Monitor.Models.ResourceForUpdate body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.DataCollectionRuleResource>> UpdateAsync(Azure.ResourceManager.Monitor.Models.ResourceForUpdate body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DiagnosticSettingsCategoryCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.DiagnosticSettingsCategoryResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.DiagnosticSettingsCategoryResource>, System.Collections.IEnumerable
    {
        protected DiagnosticSettingsCategoryCollection() { }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.DiagnosticSettingsCategoryResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.DiagnosticSettingsCategoryResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.DiagnosticSettingsCategoryResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.DiagnosticSettingsCategoryResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Monitor.DiagnosticSettingsCategoryResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.DiagnosticSettingsCategoryResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Monitor.DiagnosticSettingsCategoryResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.DiagnosticSettingsCategoryResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DiagnosticSettingsCategoryData : Azure.ResourceManager.Models.ResourceData
    {
        public DiagnosticSettingsCategoryData() { }
        public Azure.ResourceManager.Monitor.Models.CategoryType? CategoryType { get { throw null; } set { } }
    }
    public partial class DiagnosticSettingsCategoryResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DiagnosticSettingsCategoryResource() { }
        public virtual Azure.ResourceManager.Monitor.DiagnosticSettingsCategoryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri, string name) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.DiagnosticSettingsCategoryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.DiagnosticSettingsCategoryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DiagnosticSettingsCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.DiagnosticSettingsResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.DiagnosticSettingsResource>, System.Collections.IEnumerable
    {
        protected DiagnosticSettingsCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.DiagnosticSettingsResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.Monitor.DiagnosticSettingsData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.DiagnosticSettingsResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.Monitor.DiagnosticSettingsData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.DiagnosticSettingsResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.DiagnosticSettingsResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.DiagnosticSettingsResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.DiagnosticSettingsResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Monitor.DiagnosticSettingsResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.DiagnosticSettingsResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Monitor.DiagnosticSettingsResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.DiagnosticSettingsResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DiagnosticSettingsData : Azure.ResourceManager.Models.ResourceData
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
    public partial class DiagnosticSettingsResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DiagnosticSettingsResource() { }
        public virtual Azure.ResourceManager.Monitor.DiagnosticSettingsData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.DiagnosticSettingsResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.DiagnosticSettingsResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.DiagnosticSettingsResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Monitor.DiagnosticSettingsData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.DiagnosticSettingsResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Monitor.DiagnosticSettingsData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LogProfileCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.LogProfileResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.LogProfileResource>, System.Collections.IEnumerable
    {
        protected LogProfileCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.LogProfileResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string logProfileName, Azure.ResourceManager.Monitor.LogProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.LogProfileResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string logProfileName, Azure.ResourceManager.Monitor.LogProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string logProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string logProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.LogProfileResource> Get(string logProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.LogProfileResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.LogProfileResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.LogProfileResource>> GetAsync(string logProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Monitor.LogProfileResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.LogProfileResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Monitor.LogProfileResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.LogProfileResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LogProfileData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public LogProfileData(Azure.Core.AzureLocation location, System.Collections.Generic.IEnumerable<string> locations, System.Collections.Generic.IEnumerable<string> categories, Azure.ResourceManager.Monitor.Models.RetentionPolicy retentionPolicy) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IList<string> Categories { get { throw null; } }
        public System.Collections.Generic.IList<string> Locations { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.RetentionPolicy RetentionPolicy { get { throw null; } set { } }
        public string ServiceBusRuleId { get { throw null; } set { } }
        public string StorageAccountId { get { throw null; } set { } }
    }
    public partial class LogProfileResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LogProfileResource() { }
        public virtual Azure.ResourceManager.Monitor.LogProfileData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.LogProfileResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.LogProfileResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string logProfileName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.LogProfileResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.LogProfileResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.LogProfileResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.LogProfileResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.LogProfileResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.LogProfileResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.LogProfileResource> Update(Azure.ResourceManager.Monitor.Models.LogProfilePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.LogProfileResource>> UpdateAsync(Azure.ResourceManager.Monitor.Models.LogProfilePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LogSearchRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.LogSearchRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.LogSearchRuleResource>, System.Collections.IEnumerable
    {
        protected LogSearchRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.LogSearchRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string ruleName, Azure.ResourceManager.Monitor.LogSearchRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.LogSearchRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string ruleName, Azure.ResourceManager.Monitor.LogSearchRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.LogSearchRuleResource> Get(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.LogSearchRuleResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.LogSearchRuleResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.LogSearchRuleResource>> GetAsync(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Monitor.LogSearchRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.LogSearchRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Monitor.LogSearchRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.LogSearchRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LogSearchRuleData : Azure.ResourceManager.Monitor.Models.ResourceAutoGenerated
    {
        public LogSearchRuleData(Azure.Core.AzureLocation location, Azure.ResourceManager.Monitor.Models.MonitorSource source, Azure.ResourceManager.Monitor.Models.MonitorAction action) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Monitor.Models.MonitorAction Action { get { throw null; } set { } }
        public bool? AutoMitigate { get { throw null; } set { } }
        public string CreatedWithApiVersion { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.Enabled? Enabled { get { throw null; } set { } }
        public bool? IsLegacyLogAnalyticsRule { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.MonitorSchedule Schedule { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.MonitorSource Source { get { throw null; } set { } }
    }
    public partial class LogSearchRuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LogSearchRuleResource() { }
        public virtual Azure.ResourceManager.Monitor.LogSearchRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.LogSearchRuleResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.LogSearchRuleResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string ruleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.LogSearchRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.LogSearchRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.LogSearchRuleResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.LogSearchRuleResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.LogSearchRuleResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.LogSearchRuleResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.LogSearchRuleResource> Update(Azure.ResourceManager.Monitor.Models.LogSearchRulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.LogSearchRuleResource>> UpdateAsync(Azure.ResourceManager.Monitor.Models.LogSearchRulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MetricAlertCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.MetricAlertResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.MetricAlertResource>, System.Collections.IEnumerable
    {
        protected MetricAlertCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.MetricAlertResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string ruleName, Azure.ResourceManager.Monitor.MetricAlertData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.MetricAlertResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string ruleName, Azure.ResourceManager.Monitor.MetricAlertData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.MetricAlertResource> Get(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.MetricAlertResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.MetricAlertResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.MetricAlertResource>> GetAsync(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Monitor.MetricAlertResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.MetricAlertResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Monitor.MetricAlertResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.MetricAlertResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MetricAlertData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public MetricAlertData(Azure.Core.AzureLocation location, int severity, bool enabled, System.Collections.Generic.IEnumerable<string> scopes, System.TimeSpan evaluationFrequency, System.TimeSpan windowSize, Azure.ResourceManager.Monitor.Models.MetricAlertCriteria criteria) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.MetricAlertAction> Actions { get { throw null; } }
        public bool? AutoMitigate { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.MetricAlertCriteria Criteria { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public bool Enabled { get { throw null; } set { } }
        public System.TimeSpan EvaluationFrequency { get { throw null; } set { } }
        public bool? IsMigrated { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
        public System.Collections.Generic.IList<string> Scopes { get { throw null; } }
        public int Severity { get { throw null; } set { } }
        public string TargetResourceRegion { get { throw null; } set { } }
        public string TargetResourceType { get { throw null; } set { } }
        public System.TimeSpan WindowSize { get { throw null; } set { } }
    }
    public partial class MetricAlertResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MetricAlertResource() { }
        public virtual Azure.ResourceManager.Monitor.MetricAlertData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.MetricAlertResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.MetricAlertResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string ruleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.MetricAlertResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.MetricAlertResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.Models.MetricAlertStatus> GetMetricAlertsStatuses(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.Models.MetricAlertStatus> GetMetricAlertsStatusesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.Models.MetricAlertStatus> GetMetricAlertsStatusesByName(string statusName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.Models.MetricAlertStatus> GetMetricAlertsStatusesByNameAsync(string statusName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.MetricAlertResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.MetricAlertResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.MetricAlertResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.MetricAlertResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.MetricAlertResource> Update(Azure.ResourceManager.Monitor.Models.MetricAlertPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.MetricAlertResource>> UpdateAsync(Azure.ResourceManager.Monitor.Models.MetricAlertPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class MonitorExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Monitor.ActionGroupResource> GetActionGroup(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string actionGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.ActionGroupResource>> GetActionGroupAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string actionGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Monitor.ActionGroupResource GetActionGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Monitor.ActionGroupCollection GetActionGroups(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Monitor.ActionGroupResource> GetActionGroups(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Monitor.ActionGroupResource> GetActionGroupsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Monitor.ActivityLogAlertResource> GetActivityLogAlert(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string activityLogAlertName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.ActivityLogAlertResource>> GetActivityLogAlertAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string activityLogAlertName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Monitor.ActivityLogAlertResource GetActivityLogAlertResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Monitor.ActivityLogAlertCollection GetActivityLogAlerts(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Monitor.ActivityLogAlertResource> GetActivityLogAlerts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Monitor.ActivityLogAlertResource> GetActivityLogAlertsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Monitor.Models.EventData> GetActivityLogs(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter, string select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Monitor.Models.EventData> GetActivityLogsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter, string select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Monitor.AlertRuleResource> GetAlertRule(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.AlertRuleResource>> GetAlertRuleAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Monitor.AlertRuleResource GetAlertRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Monitor.AlertRuleCollection GetAlertRules(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Monitor.AlertRuleResource> GetAlertRules(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Monitor.AlertRuleResource> GetAlertRulesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Monitor.AutoscaleSettingResource> GetAutoscaleSetting(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string autoscaleSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.AutoscaleSettingResource>> GetAutoscaleSettingAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string autoscaleSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Monitor.AutoscaleSettingResource GetAutoscaleSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Monitor.AutoscaleSettingCollection GetAutoscaleSettings(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Monitor.AutoscaleSettingResource> GetAutoscaleSettings(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Monitor.AutoscaleSettingResource> GetAutoscaleSettingsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Monitor.DataCollectionEndpointResource> GetDataCollectionEndpoint(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string dataCollectionEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.DataCollectionEndpointResource>> GetDataCollectionEndpointAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string dataCollectionEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Monitor.DataCollectionEndpointResource GetDataCollectionEndpointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Monitor.DataCollectionEndpointCollection GetDataCollectionEndpoints(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Monitor.DataCollectionEndpointResource> GetDataCollectionEndpoints(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Monitor.DataCollectionEndpointResource> GetDataCollectionEndpointsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Monitor.DataCollectionRuleResource> GetDataCollectionRule(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string dataCollectionRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Monitor.DataCollectionRuleAssociationResource> GetDataCollectionRuleAssociation(this Azure.ResourceManager.ArmResource armResource, string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.DataCollectionRuleAssociationResource>> GetDataCollectionRuleAssociationAsync(this Azure.ResourceManager.ArmResource armResource, string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Monitor.DataCollectionRuleAssociationResource GetDataCollectionRuleAssociationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Monitor.DataCollectionRuleAssociationCollection GetDataCollectionRuleAssociations(this Azure.ResourceManager.ArmResource armResource) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.DataCollectionRuleResource>> GetDataCollectionRuleAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string dataCollectionRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Monitor.DataCollectionRuleResource GetDataCollectionRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Monitor.DataCollectionRuleCollection GetDataCollectionRules(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Monitor.DataCollectionRuleResource> GetDataCollectionRules(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Monitor.DataCollectionRuleResource> GetDataCollectionRulesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Monitor.DiagnosticSettingsCollection GetDiagnosticSettings(this Azure.ResourceManager.ArmResource armResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Monitor.DiagnosticSettingsResource> GetDiagnosticSettings(this Azure.ResourceManager.ArmResource armResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.DiagnosticSettingsResource>> GetDiagnosticSettingsAsync(this Azure.ResourceManager.ArmResource armResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Monitor.DiagnosticSettingsCategoryCollection GetDiagnosticSettingsCategories(this Azure.ResourceManager.ArmResource armResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Monitor.DiagnosticSettingsCategoryResource> GetDiagnosticSettingsCategory(this Azure.ResourceManager.ArmResource armResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.DiagnosticSettingsCategoryResource>> GetDiagnosticSettingsCategoryAsync(this Azure.ResourceManager.ArmResource armResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Monitor.DiagnosticSettingsCategoryResource GetDiagnosticSettingsCategoryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Monitor.DiagnosticSettingsResource GetDiagnosticSettingsResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Monitor.Models.LocalizableString> GetEventCategories(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Monitor.Models.LocalizableString> GetEventCategoriesAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Monitor.LogProfileResource> GetLogProfile(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string logProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.LogProfileResource>> GetLogProfileAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string logProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Monitor.LogProfileResource GetLogProfileResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Monitor.LogProfileCollection GetLogProfiles(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Monitor.LogSearchRuleResource> GetLogSearchRule(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.LogSearchRuleResource>> GetLogSearchRuleAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Monitor.LogSearchRuleResource GetLogSearchRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Monitor.LogSearchRuleCollection GetLogSearchRules(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Monitor.LogSearchRuleResource> GetLogSearchRules(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Monitor.LogSearchRuleResource> GetLogSearchRulesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Monitor.MetricAlertResource> GetMetricAlert(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.MetricAlertResource>> GetMetricAlertAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Monitor.MetricAlertResource GetMetricAlertResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Monitor.MetricAlertCollection GetMetricAlerts(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Monitor.MetricAlertResource> GetMetricAlerts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Monitor.MetricAlertResource> GetMetricAlertsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Monitor.MonitorPrivateEndpointConnectionResource GetMonitorPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Monitor.PrivateLinkResource GetPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Monitor.PrivateLinkScopeResource> GetPrivateLinkScope(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string scopeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.PrivateLinkScopeResource>> GetPrivateLinkScopeAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string scopeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Monitor.Models.OperationStatus> GetPrivateLinkScopeOperationStatu(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string asyncOperationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.Models.OperationStatus>> GetPrivateLinkScopeOperationStatuAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string asyncOperationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Monitor.PrivateLinkScopeResource GetPrivateLinkScopeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Monitor.PrivateLinkScopeCollection GetPrivateLinkScopes(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Monitor.PrivateLinkScopeResource> GetPrivateLinkScopes(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Monitor.PrivateLinkScopeResource> GetPrivateLinkScopesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Monitor.ScopedPrivateLinkResource GetScopedPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Monitor.Models.EventData> GetTenantActivityLogs(this Azure.ResourceManager.Resources.TenantResource tenantResource, string filter = null, string select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Monitor.Models.EventData> GetTenantActivityLogsAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string filter = null, string select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Monitor.Models.TestNotificationDetailsResponse> GetTestNotificationsActionGroup(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string notificationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.Models.TestNotificationDetailsResponse>> GetTestNotificationsActionGroupAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string notificationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Monitor.VmInsightsOnboardingStatusResource GetVmInsightsOnboardingStatus(this Azure.ResourceManager.ArmResource armResource) { throw null; }
        public static Azure.ResourceManager.Monitor.VmInsightsOnboardingStatusResource GetVmInsightsOnboardingStatusResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.Models.TestNotificationResponse> PostTestNotificationsActionGroup(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.WaitUntil waitUntil, Azure.ResourceManager.Monitor.Models.NotificationRequestBody notificationRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.Models.TestNotificationResponse>> PostTestNotificationsActionGroupAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.WaitUntil waitUntil, Azure.ResourceManager.Monitor.Models.NotificationRequestBody notificationRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MonitorPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.MonitorPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.MonitorPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected MonitorPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.MonitorPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.Monitor.MonitorPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.MonitorPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.Monitor.MonitorPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.MonitorPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.MonitorPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.MonitorPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.MonitorPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Monitor.MonitorPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.MonitorPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Monitor.MonitorPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.MonitorPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MonitorPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public MonitorPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.Monitor.Models.MonitorPrivateLinkServiceConnectionStateProperty ConnectionState { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
    }
    public partial class MonitorPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MonitorPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.Monitor.MonitorPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string scopeName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.MonitorPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.MonitorPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.MonitorPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Monitor.MonitorPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.MonitorPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Monitor.MonitorPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateLinkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.PrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.PrivateLinkResource>, System.Collections.IEnumerable
    {
        protected PrivateLinkCollection() { }
        public virtual Azure.Response<bool> Exists(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.PrivateLinkResource> Get(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.PrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.PrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.PrivateLinkResource>> GetAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Monitor.PrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.PrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Monitor.PrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.PrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateLinkData : Azure.ResourceManager.Models.ResourceData
    {
        public PrivateLinkData() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
    }
    public partial class PrivateLinkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PrivateLinkResource() { }
        public virtual Azure.ResourceManager.Monitor.PrivateLinkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string scopeName, string groupName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.PrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.PrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateLinkScopeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.PrivateLinkScopeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.PrivateLinkScopeResource>, System.Collections.IEnumerable
    {
        protected PrivateLinkScopeCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.PrivateLinkScopeResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string scopeName, Azure.ResourceManager.Monitor.PrivateLinkScopeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.PrivateLinkScopeResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string scopeName, Azure.ResourceManager.Monitor.PrivateLinkScopeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string scopeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string scopeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.PrivateLinkScopeResource> Get(string scopeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.PrivateLinkScopeResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.PrivateLinkScopeResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.PrivateLinkScopeResource>> GetAsync(string scopeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Monitor.PrivateLinkScopeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.PrivateLinkScopeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Monitor.PrivateLinkScopeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.PrivateLinkScopeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateLinkScopeData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public PrivateLinkScopeData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Monitor.MonitorPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
    }
    public partial class PrivateLinkScopeResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PrivateLinkScopeResource() { }
        public virtual Azure.ResourceManager.Monitor.PrivateLinkScopeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.PrivateLinkScopeResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.PrivateLinkScopeResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string scopeName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.PrivateLinkScopeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.PrivateLinkScopeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.MonitorPrivateEndpointConnectionResource> GetMonitorPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.MonitorPrivateEndpointConnectionResource>> GetMonitorPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Monitor.MonitorPrivateEndpointConnectionCollection GetMonitorPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.PrivateLinkResource> GetPrivateLink(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.PrivateLinkResource>> GetPrivateLinkAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Monitor.PrivateLinkCollection GetPrivateLinks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.ScopedPrivateLinkResource> GetScopedPrivateLink(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.ScopedPrivateLinkResource>> GetScopedPrivateLinkAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Monitor.ScopedPrivateLinkCollection GetScopedPrivateLinks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.PrivateLinkScopeResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.PrivateLinkScopeResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.PrivateLinkScopeResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.PrivateLinkScopeResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.PrivateLinkScopeResource> Update(Azure.ResourceManager.Monitor.Models.PrivateLinkScopePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.PrivateLinkScopeResource>> UpdateAsync(Azure.ResourceManager.Monitor.Models.PrivateLinkScopePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ScopedPrivateLinkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.ScopedPrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.ScopedPrivateLinkResource>, System.Collections.IEnumerable
    {
        protected ScopedPrivateLinkCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.ScopedPrivateLinkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.Monitor.ScopedPrivateLinkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.ScopedPrivateLinkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.Monitor.ScopedPrivateLinkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.ScopedPrivateLinkResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.ScopedPrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.ScopedPrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.ScopedPrivateLinkResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Monitor.ScopedPrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.ScopedPrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Monitor.ScopedPrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.ScopedPrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ScopedPrivateLinkData : Azure.ResourceManager.Models.ResourceData
    {
        public ScopedPrivateLinkData() { }
        public string LinkedResourceId { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
    }
    public partial class ScopedPrivateLinkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ScopedPrivateLinkResource() { }
        public virtual Azure.ResourceManager.Monitor.ScopedPrivateLinkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string scopeName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.ScopedPrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.ScopedPrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.ScopedPrivateLinkResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Monitor.ScopedPrivateLinkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.ScopedPrivateLinkResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Monitor.ScopedPrivateLinkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VmInsightsOnboardingStatusData : Azure.ResourceManager.Models.ResourceData
    {
        public VmInsightsOnboardingStatusData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.DataContainer> Data { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.DataStatus? DataStatus { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.OnboardingStatus? OnboardingStatus { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
    }
    public partial class VmInsightsOnboardingStatusResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VmInsightsOnboardingStatusResource() { }
        public virtual Azure.ResourceManager.Monitor.VmInsightsOnboardingStatusData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.VmInsightsOnboardingStatusResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.VmInsightsOnboardingStatusResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Monitor.Models
{
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
    public partial class ActionGroupPatch
    {
        public ActionGroupPatch() { }
        public bool? Enabled { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class ActivityLogAlertActionGroup
    {
        public ActivityLogAlertActionGroup(string actionGroupId) { }
        public string ActionGroupId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> WebhookProperties { get { throw null; } }
    }
    public partial class ActivityLogAlertLeafCondition
    {
        public ActivityLogAlertLeafCondition(string field, string equalsValue) { }
        public string EqualsValue { get { throw null; } set { } }
        public string Field { get { throw null; } set { } }
    }
    public partial class ActivityLogAlertPatch
    {
        public ActivityLogAlertPatch() { }
        public bool? Enabled { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
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
    public partial class AlertingAction : Azure.ResourceManager.Monitor.Models.MonitorAction
    {
        public AlertingAction(Azure.ResourceManager.Monitor.Models.AlertSeverity severity, Azure.ResourceManager.Monitor.Models.TriggerCondition trigger) { }
        public Azure.ResourceManager.Monitor.Models.AzNsActionGroup AznsAction { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.AlertSeverity Severity { get { throw null; } set { } }
        public int? ThrottlingInMin { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.TriggerCondition Trigger { get { throw null; } set { } }
    }
    public partial class AlertRulePatch
    {
        public AlertRulePatch() { }
        public Azure.ResourceManager.Monitor.Models.RuleAction Action { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.RuleAction> Actions { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.RuleCondition Condition { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
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
        public System.Uri ServiceUri { get { throw null; } set { } }
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
        public Azure.ResourceManager.Monitor.Models.MonitorRecurrence Recurrence { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.ScaleRule> Rules { get { throw null; } }
    }
    public partial class AutoscaleSettingPatch
    {
        public AutoscaleSettingPatch() { }
        public bool? Enabled { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.AutoscaleNotification> Notifications { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.AutoscaleProfile> Profiles { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string TargetResourceId { get { throw null; } set { } }
        public string TargetResourceLocation { get { throw null; } set { } }
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
        public AzureFunctionReceiver(string name, string functionAppResourceId, string functionName, System.Uri httpTriggerUri) { }
        public string FunctionAppResourceId { get { throw null; } set { } }
        public string FunctionName { get { throw null; } set { } }
        public System.Uri HttpTriggerUri { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public bool? UseCommonAlertSchema { get { throw null; } set { } }
    }
    public partial class AzureResource : Azure.ResourceManager.Models.TrackedResourceData
    {
        public AzureResource(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string Identity { get { throw null; } }
        public string Kind { get { throw null; } }
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
    public partial class Context
    {
        internal Context() { }
        public string ContextType { get { throw null; } }
        public string NotificationSource { get { throw null; } }
    }
    public partial class DataCollectionEndpointProperties : Azure.ResourceManager.Monitor.DataCollectionEndpointData
    {
        public DataCollectionEndpointProperties(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
    }
    public partial class DataCollectionRuleAssociationProperties : Azure.ResourceManager.Monitor.DataCollectionRuleAssociationData
    {
        public DataCollectionRuleAssociationProperties() { }
    }
    public partial class DataCollectionRuleProperties : Azure.ResourceManager.Monitor.DataCollectionRuleData
    {
        public DataCollectionRuleProperties(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
    }
    public partial class DataContainer
    {
        public DataContainer(Azure.ResourceManager.Monitor.Models.WorkspaceInfo workspace) { }
        public Azure.ResourceManager.Monitor.Models.WorkspaceInfo Workspace { get { throw null; } set { } }
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
    public partial class EnableContent
    {
        public EnableContent(string receiverName) { }
        public string ReceiverName { get { throw null; } }
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
    public partial class ErrorAdditionalInfo
    {
        internal ErrorAdditionalInfo() { }
        public string ErrorAdditionalInfoType { get { throw null; } }
        public System.BinaryData Info { get { throw null; } }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Monitor.Models.ErrorAdditionalInfo> AdditionalInfo { get { throw null; } }
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
    public partial class HttpRequestInfo
    {
        internal HttpRequestInfo() { }
        public string ClientIpAddress { get { throw null; } }
        public string ClientRequestId { get { throw null; } }
        public string Method { get { throw null; } }
        public System.Uri Uri { get { throw null; } }
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
    public partial class LogicAppReceiver
    {
        public LogicAppReceiver(string name, string resourceId, System.Uri callbackUri) { }
        public System.Uri CallbackUri { get { throw null; } set { } }
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
    public partial class LogProfilePatch
    {
        public LogProfilePatch() { }
        public System.Collections.Generic.IList<string> Categories { get { throw null; } }
        public System.Collections.Generic.IList<string> Locations { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.RetentionPolicy RetentionPolicy { get { throw null; } set { } }
        public string ServiceBusRuleId { get { throw null; } set { } }
        public string StorageAccountId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class LogSearchRulePatch
    {
        public LogSearchRulePatch() { }
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
    public partial class LogToMetricAction : Azure.ResourceManager.Monitor.Models.MonitorAction
    {
        public LogToMetricAction(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.MonitorCriteria> criteria) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.MonitorCriteria> Criteria { get { throw null; } }
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
    public partial class MetricAlertAction
    {
        public MetricAlertAction() { }
        public string ActionGroupId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> WebHookProperties { get { throw null; } }
    }
    public partial class MetricAlertCriteria
    {
        public MetricAlertCriteria() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
    }
    public partial class MetricAlertMultipleResourceMultipleMetricCriteria : Azure.ResourceManager.Monitor.Models.MetricAlertCriteria
    {
        public MetricAlertMultipleResourceMultipleMetricCriteria() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.MultiMetricCriteria> AllOf { get { throw null; } }
    }
    public partial class MetricAlertPatch
    {
        public MetricAlertPatch() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.MetricAlertAction> Actions { get { throw null; } }
        public bool? AutoMitigate { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.MetricAlertCriteria Criteria { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
        public System.TimeSpan? EvaluationFrequency { get { throw null; } set { } }
        public bool? IsMigrated { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
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
    public partial class MetricAlertStatus : Azure.ResourceManager.Models.ResourceData
    {
        internal MetricAlertStatus() { }
        public Azure.ResourceManager.Monitor.Models.MetricAlertStatusProperties Properties { get { throw null; } }
    }
    public partial class MetricAlertStatusProperties
    {
        internal MetricAlertStatusProperties() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Dimensions { get { throw null; } }
        public string Status { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
    }
    public partial class MetricCriteria : Azure.ResourceManager.Monitor.Models.MultiMetricCriteria
    {
        public MetricCriteria(string name, string metricName, Azure.ResourceManager.Monitor.Models.AggregationTypeEnum timeAggregation, Azure.ResourceManager.Monitor.Models.Operator @operator, double threshold) : base (default(string), default(string), default(Azure.ResourceManager.Monitor.Models.AggregationTypeEnum)) { }
        public Azure.ResourceManager.Monitor.Models.Operator Operator { get { throw null; } set { } }
        public double Threshold { get { throw null; } set { } }
    }
    public partial class MetricDimension
    {
        public MetricDimension(string name, string @operator, System.Collections.Generic.IEnumerable<string> values) { }
        public string Name { get { throw null; } set { } }
        public string Operator { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
    }
    public partial class MetricSettings
    {
        public MetricSettings(bool enabled) { }
        public string Category { get { throw null; } set { } }
        public bool Enabled { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.RetentionPolicy RetentionPolicy { get { throw null; } set { } }
        public System.TimeSpan? TimeGrain { get { throw null; } set { } }
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
        public MetricTrigger(string metricName, string metricResourceId, System.TimeSpan timeGrain, Azure.ResourceManager.Monitor.Models.MetricStatisticType statistic, System.TimeSpan timeWindow, Azure.ResourceManager.Monitor.Models.TimeAggregationType timeAggregation, Azure.ResourceManager.Monitor.Models.ComparisonOperationType @operator, double threshold) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.ScaleRuleMetricDimension> Dimensions { get { throw null; } set { } }
        public bool? DividePerInstance { get { throw null; } set { } }
        public string MetricName { get { throw null; } set { } }
        public string MetricNamespace { get { throw null; } set { } }
        public string MetricResourceId { get { throw null; } set { } }
        public string MetricResourceLocation { get { throw null; } set { } }
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
    public partial class MonitorAction
    {
        public MonitorAction() { }
    }
    public partial class MonitorCriteria
    {
        public MonitorCriteria(string metricName) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.MonitorDimension> Dimensions { get { throw null; } }
        public string MetricName { get { throw null; } set { } }
    }
    public partial class MonitorDimension
    {
        public MonitorDimension(string name, Azure.ResourceManager.Monitor.Models.Operator @operator, System.Collections.Generic.IEnumerable<string> values) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.Operator Operator { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
    }
    public partial class MonitorIncident
    {
        internal MonitorIncident() { }
        public System.DateTimeOffset? ActivatedOn { get { throw null; } }
        public bool? IsActive { get { throw null; } }
        public string Name { get { throw null; } }
        public System.DateTimeOffset? ResolvedOn { get { throw null; } }
        public string RuleName { get { throw null; } }
    }
    public partial class MonitorPrivateLinkServiceConnectionStateProperty
    {
        public MonitorPrivateLinkServiceConnectionStateProperty(string status, string description) { }
        public string ActionsRequired { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
    }
    public partial class MonitorRecurrence
    {
        public MonitorRecurrence(Azure.ResourceManager.Monitor.Models.RecurrenceFrequency frequency, Azure.ResourceManager.Monitor.Models.RecurrentSchedule schedule) { }
        public Azure.ResourceManager.Monitor.Models.RecurrenceFrequency Frequency { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.RecurrentSchedule Schedule { get { throw null; } set { } }
    }
    public partial class MonitorSchedule
    {
        public MonitorSchedule(int frequencyInMinutes, int timeWindowInMinutes) { }
        public int FrequencyInMinutes { get { throw null; } set { } }
        public int TimeWindowInMinutes { get { throw null; } set { } }
    }
    public partial class MonitorSource
    {
        public MonitorSource(string dataSourceId) { }
        public System.Collections.Generic.IList<string> AuthorizedResources { get { throw null; } }
        public string DataSourceId { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.QueryType? QueryType { get { throw null; } set { } }
    }
    public partial class MultiMetricCriteria
    {
        public MultiMetricCriteria(string name, string metricName, Azure.ResourceManager.Monitor.Models.AggregationTypeEnum timeAggregation) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.MetricDimension> Dimensions { get { throw null; } }
        public string MetricName { get { throw null; } set { } }
        public string MetricNamespace { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public bool? SkipMetricValidation { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.AggregationTypeEnum TimeAggregation { get { throw null; } set { } }
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
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.ErrorResponseCommon Error { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
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
    public partial class PrivateLinkScopePatch
    {
        public PrivateLinkScopePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
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
    public partial class ResourceAutoGenerated : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ResourceAutoGenerated(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string Etag { get { throw null; } }
        public string Kind { get { throw null; } }
    }
    public partial class ResourceForUpdate
    {
        public ResourceForUpdate() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
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
        public string ResourceId { get { throw null; } set { } }
        public string ResourceLocation { get { throw null; } set { } }
    }
    public partial class RuleEmailAction : Azure.ResourceManager.Monitor.Models.RuleAction
    {
        public RuleEmailAction() { }
        public System.Collections.Generic.IList<string> CustomEmails { get { throw null; } }
        public bool? SendToServiceOwners { get { throw null; } set { } }
    }
    public partial class RuleManagementEventDataSource : Azure.ResourceManager.Monitor.Models.RuleDataSource
    {
        public RuleManagementEventDataSource() { }
        public string ClaimsEmailAddress { get { throw null; } set { } }
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
        public System.Uri ServiceUri { get { throw null; } set { } }
    }
    public partial class ScaleAction
    {
        public ScaleAction(Azure.ResourceManager.Monitor.Models.ScaleDirection direction, Azure.ResourceManager.Monitor.Models.ScaleType scaleType, System.TimeSpan cooldown) { }
        public System.TimeSpan Cooldown { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.ScaleDirection Direction { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.ScaleType ScaleType { get { throw null; } set { } }
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
    public partial class SenderAuthorization
    {
        internal SenderAuthorization() { }
        public string Action { get { throw null; } }
        public string Role { get { throw null; } }
        public string Scope { get { throw null; } }
    }
    public partial class SmsReceiver
    {
        public SmsReceiver(string name, string countryCode, string phoneNumber) { }
        public string CountryCode { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string PhoneNumber { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.ReceiverStatus? Status { get { throw null; } }
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
        public System.Uri ServiceUri { get { throw null; } set { } }
    }
    public partial class WebhookReceiver
    {
        public WebhookReceiver(string name, System.Uri serviceUri) { }
        public System.Uri IdentifierUri { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string ObjectId { get { throw null; } set { } }
        public System.Uri ServiceUri { get { throw null; } set { } }
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
    public partial class WorkspaceInfo
    {
        public WorkspaceInfo(string id, string location, string customerId) { }
        public string CustomerId { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
    }
}
