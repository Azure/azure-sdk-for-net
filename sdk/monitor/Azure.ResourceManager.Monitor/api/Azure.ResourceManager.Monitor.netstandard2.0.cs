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
        public virtual Azure.NullableResponse<Azure.ResourceManager.Monitor.ActionGroupResource> GetIfExists(string actionGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Monitor.ActionGroupResource>> GetIfExistsAsync(string actionGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Monitor.ActionGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.ActionGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Monitor.ActionGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.ActionGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ActionGroupData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ActionGroupData(Azure.Core.AzureLocation location) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.MonitorArmRoleReceiver> ArmRoleReceivers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.MonitorAutomationRunbookReceiver> AutomationRunbookReceivers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.MonitorAzureAppPushReceiver> AzureAppPushReceivers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.MonitorAzureFunctionReceiver> AzureFunctionReceivers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.MonitorEmailReceiver> EmailReceivers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.MonitorEventHubReceiver> EventHubReceivers { get { throw null; } }
        public string GroupShortName { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.MonitorItsmReceiver> ItsmReceivers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.MonitorLogicAppReceiver> LogicAppReceivers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.MonitorSmsReceiver> SmsReceivers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.MonitorVoiceReceiver> VoiceReceivers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.MonitorWebhookReceiver> WebhookReceivers { get { throw null; } }
    }
    public partial class ActionGroupResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ActionGroupResource() { }
        public virtual Azure.ResourceManager.Monitor.ActionGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.ActionGroupResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.ActionGroupResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.Models.NotificationStatus> CreateNotifications(Azure.WaitUntil waitUntil, Azure.ResourceManager.Monitor.Models.NotificationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.Models.NotificationStatus>> CreateNotificationsAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Monitor.Models.NotificationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string actionGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response EnableReceiver(Azure.ResourceManager.Monitor.Models.ActionGroupEnableContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> EnableReceiverAsync(Azure.ResourceManager.Monitor.Models.ActionGroupEnableContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.ActionGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.ActionGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.Models.NotificationStatus> GetNotificationStatus(string notificationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.Models.NotificationStatus>> GetNotificationStatusAsync(string notificationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.Monitor.ActivityLogAlertResource> GetIfExists(string activityLogAlertName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Monitor.ActivityLogAlertResource>> GetIfExistsAsync(string activityLogAlertName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Monitor.ActivityLogAlertResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.ActivityLogAlertResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Monitor.ActivityLogAlertResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.ActivityLogAlertResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ActivityLogAlertData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ActivityLogAlertData(Azure.Core.AzureLocation location) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.ActivityLogAlertActionGroup> ActionsActionGroups { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.ActivityLogAlertAnyOfOrLeafCondition> ConditionAllOf { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.Monitor.AlertRuleResource> GetIfExists(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Monitor.AlertRuleResource>> GetIfExistsAsync(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Monitor.AlertRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.AlertRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Monitor.AlertRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.AlertRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AlertRuleData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public AlertRuleData(Azure.Core.AzureLocation location, string alertRuleName, bool isEnabled, Azure.ResourceManager.Monitor.Models.AlertRuleCondition condition) { }
        public Azure.ResourceManager.Monitor.Models.AlertRuleAction Action { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.AlertRuleAction> Actions { get { throw null; } }
        public string AlertRuleName { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.AlertRuleCondition Condition { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public bool IsEnabled { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.Monitor.AutoscaleSettingResource> GetIfExists(string autoscaleSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Monitor.AutoscaleSettingResource>> GetIfExistsAsync(string autoscaleSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Monitor.AutoscaleSettingResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.AutoscaleSettingResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Monitor.AutoscaleSettingResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.AutoscaleSettingResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AutoscaleSettingData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public AutoscaleSettingData(Azure.Core.AzureLocation location, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.AutoscaleProfile> profiles) { }
        public string AutoscaleSettingName { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.AutoscaleNotification> Notifications { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.PredictiveAutoscalePolicy PredictiveAutoscalePolicy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.AutoscaleProfile> Profiles { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetResourceId { get { throw null; } set { } }
        public Azure.Core.AzureLocation? TargetResourceLocation { get { throw null; } set { } }
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
        public virtual Azure.Response<Azure.ResourceManager.Monitor.Models.AutoscaleSettingPredicativeResult> GetPredictiveMetric(string timespan, System.TimeSpan interval, string metricNamespace, string metricName, string aggregation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.Models.AutoscaleSettingPredicativeResult>> GetPredictiveMetricAsync(string timespan, System.TimeSpan interval, string metricNamespace, string metricName, string aggregation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.DataCollectionEndpointResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string dataCollectionEndpointName, Azure.ResourceManager.Monitor.DataCollectionEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.DataCollectionEndpointResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dataCollectionEndpointName, Azure.ResourceManager.Monitor.DataCollectionEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dataCollectionEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dataCollectionEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.DataCollectionEndpointResource> Get(string dataCollectionEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.DataCollectionEndpointResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.DataCollectionEndpointResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.DataCollectionEndpointResource>> GetAsync(string dataCollectionEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Monitor.DataCollectionEndpointResource> GetIfExists(string dataCollectionEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Monitor.DataCollectionEndpointResource>> GetIfExistsAsync(string dataCollectionEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Monitor.DataCollectionEndpointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.DataCollectionEndpointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Monitor.DataCollectionEndpointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.DataCollectionEndpointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataCollectionEndpointData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public DataCollectionEndpointData(Azure.Core.AzureLocation location) { }
        public string ConfigurationAccessEndpoint { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.DataCollectionEndpointFailoverConfiguration FailoverConfiguration { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string ImmutableId { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.DataCollectionEndpointResourceKind? Kind { get { throw null; } set { } }
        public string LogsIngestionEndpoint { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.DataCollectionEndpointMetadata Metadata { get { throw null; } }
        public string MetricsIngestionEndpoint { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Monitor.Models.DataCollectionRulePrivateLinkScopedResourceInfo> PrivateLinkScopedResources { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.DataCollectionEndpointProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.MonitorPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
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
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.DataCollectionRuleAssociationResource> GetDataCollectionRuleAssociations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.DataCollectionRuleAssociationResource> GetDataCollectionRuleAssociationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.DataCollectionRuleAssociationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string associationName, Azure.ResourceManager.Monitor.DataCollectionRuleAssociationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.DataCollectionRuleAssociationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string associationName, Azure.ResourceManager.Monitor.DataCollectionRuleAssociationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.DataCollectionRuleAssociationResource> Get(string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.DataCollectionRuleAssociationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.DataCollectionRuleAssociationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.DataCollectionRuleAssociationResource>> GetAsync(string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Monitor.DataCollectionRuleAssociationResource> GetIfExists(string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Monitor.DataCollectionRuleAssociationResource>> GetIfExistsAsync(string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Monitor.DataCollectionRuleAssociationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.DataCollectionRuleAssociationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Monitor.DataCollectionRuleAssociationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.DataCollectionRuleAssociationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataCollectionRuleAssociationData : Azure.ResourceManager.Models.ResourceData
    {
        public DataCollectionRuleAssociationData() { }
        public Azure.Core.ResourceIdentifier DataCollectionEndpointId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier DataCollectionRuleId { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.DataCollectionRuleAssociationMetadata Metadata { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string MetadataProvisionedBy { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.DataCollectionRuleAssociationProvisioningState? ProvisioningState { get { throw null; } }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.DataCollectionRuleAssociationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Monitor.DataCollectionRuleAssociationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.DataCollectionRuleAssociationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Monitor.DataCollectionRuleAssociationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataCollectionRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.DataCollectionRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.DataCollectionRuleResource>, System.Collections.IEnumerable
    {
        protected DataCollectionRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.DataCollectionRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string dataCollectionRuleName, Azure.ResourceManager.Monitor.DataCollectionRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.DataCollectionRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dataCollectionRuleName, Azure.ResourceManager.Monitor.DataCollectionRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dataCollectionRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dataCollectionRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.DataCollectionRuleResource> Get(string dataCollectionRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.DataCollectionRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.DataCollectionRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.DataCollectionRuleResource>> GetAsync(string dataCollectionRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Monitor.DataCollectionRuleResource> GetIfExists(string dataCollectionRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Monitor.DataCollectionRuleResource>> GetIfExistsAsync(string dataCollectionRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Monitor.DataCollectionRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.DataCollectionRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Monitor.DataCollectionRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.DataCollectionRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataCollectionRuleData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public DataCollectionRuleData(Azure.Core.AzureLocation location) { }
        public Azure.Core.ResourceIdentifier DataCollectionEndpointId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.DataFlow> DataFlows { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.DataCollectionRuleDataSources DataSources { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.DataCollectionRuleDestinations Destinations { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string ImmutableId { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.DataCollectionRuleResourceKind? Kind { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.DataCollectionRuleMetadata Metadata { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string MetadataProvisionedBy { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.DataCollectionRuleProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Monitor.Models.DataStreamDeclaration> StreamDeclarations { get { throw null; } }
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
    public partial class DiagnosticSettingCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.DiagnosticSettingResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.DiagnosticSettingResource>, System.Collections.IEnumerable
    {
        protected DiagnosticSettingCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.DiagnosticSettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.Monitor.DiagnosticSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.DiagnosticSettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.Monitor.DiagnosticSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.DiagnosticSettingResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.DiagnosticSettingResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.DiagnosticSettingResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.DiagnosticSettingResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Monitor.DiagnosticSettingResource> GetIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Monitor.DiagnosticSettingResource>> GetIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Monitor.DiagnosticSettingResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.DiagnosticSettingResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Monitor.DiagnosticSettingResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.DiagnosticSettingResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DiagnosticSettingData : Azure.ResourceManager.Models.ResourceData
    {
        public DiagnosticSettingData() { }
        public Azure.Core.ResourceIdentifier EventHubAuthorizationRuleId { get { throw null; } set { } }
        public string EventHubName { get { throw null; } set { } }
        public string LogAnalyticsDestinationType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.LogSettings> Logs { get { throw null; } }
        public Azure.Core.ResourceIdentifier MarketplacePartnerId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.MetricSettings> Metrics { get { throw null; } }
        public Azure.Core.ResourceIdentifier ServiceBusRuleId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier StorageAccountId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier WorkspaceId { get { throw null; } set { } }
    }
    public partial class DiagnosticSettingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DiagnosticSettingResource() { }
        public virtual Azure.ResourceManager.Monitor.DiagnosticSettingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.DiagnosticSettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.DiagnosticSettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.DiagnosticSettingResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Monitor.DiagnosticSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.DiagnosticSettingResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Monitor.DiagnosticSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.Monitor.DiagnosticSettingsCategoryResource> GetIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Monitor.DiagnosticSettingsCategoryResource>> GetIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Monitor.DiagnosticSettingsCategoryResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.DiagnosticSettingsCategoryResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Monitor.DiagnosticSettingsCategoryResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.DiagnosticSettingsCategoryResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DiagnosticSettingsCategoryData : Azure.ResourceManager.Models.ResourceData
    {
        public DiagnosticSettingsCategoryData() { }
        public System.Collections.Generic.IList<string> CategoryGroups { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.MonitorCategoryType? CategoryType { get { throw null; } set { } }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.Monitor.LogProfileResource> GetIfExists(string logProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Monitor.LogProfileResource>> GetIfExistsAsync(string logProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Monitor.LogProfileResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.LogProfileResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Monitor.LogProfileResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.LogProfileResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LogProfileData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public LogProfileData(Azure.Core.AzureLocation location, System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> locations, System.Collections.Generic.IEnumerable<string> categories, Azure.ResourceManager.Monitor.Models.RetentionPolicy retentionPolicy) { }
        public System.Collections.Generic.IList<string> Categories { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.AzureLocation> Locations { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.RetentionPolicy RetentionPolicy { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ServiceBusRuleId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier StorageAccountId { get { throw null; } set { } }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.Monitor.MetricAlertResource> GetIfExists(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Monitor.MetricAlertResource>> GetIfExistsAsync(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Monitor.MetricAlertResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.MetricAlertResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Monitor.MetricAlertResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.MetricAlertResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MetricAlertData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public MetricAlertData(Azure.Core.AzureLocation location, int severity, bool isEnabled, System.Collections.Generic.IEnumerable<string> scopes, System.TimeSpan evaluationFrequency, System.TimeSpan windowSize, Azure.ResourceManager.Monitor.Models.MetricAlertCriteria criteria) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.MetricAlertAction> Actions { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.MetricAlertCriteria Criteria { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.TimeSpan EvaluationFrequency { get { throw null; } set { } }
        public bool? IsAutoMitigateEnabled { get { throw null; } set { } }
        public bool IsEnabled { get { throw null; } set { } }
        public bool? IsMigrated { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
        public System.Collections.Generic.IList<string> Scopes { get { throw null; } }
        public int Severity { get { throw null; } set { } }
        public Azure.Core.AzureLocation? TargetResourceRegion { get { throw null; } set { } }
        public Azure.Core.ResourceType? TargetResourceType { get { throw null; } set { } }
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
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.Models.MetricAlertStatus> GetAllMetricAlertsStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.Models.MetricAlertStatus> GetAllMetricAlertsStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.Models.MetricAlertStatus> GetAllMetricAlertsStatusByName(string statusName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.Models.MetricAlertStatus> GetAllMetricAlertsStatusByNameAsync(string statusName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.MetricAlertResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.MetricAlertResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.MetricAlertResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.MetricAlertResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.MetricAlertResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.MetricAlertResource> Update(Azure.ResourceManager.Monitor.Models.MetricAlertPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.MetricAlertResource>> UpdateAsync(Azure.ResourceManager.Monitor.Models.MetricAlertPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class MonitorExtensions
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.Models.NotificationStatus> CreateNotifications(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.WaitUntil waitUntil, Azure.ResourceManager.Monitor.Models.NotificationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.Models.NotificationStatus> CreateNotifications(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.WaitUntil waitUntil, Azure.ResourceManager.Monitor.Models.NotificationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.Models.NotificationStatus>> CreateNotificationsAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.WaitUntil waitUntil, Azure.ResourceManager.Monitor.Models.NotificationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.Models.NotificationStatus>> CreateNotificationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.WaitUntil waitUntil, Azure.ResourceManager.Monitor.Models.NotificationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public static Azure.Pageable<Azure.ResourceManager.Monitor.Models.EventDataInfo> GetActivityLogs(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter, string select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Monitor.Models.EventDataInfo> GetActivityLogsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter, string select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public static Azure.Response<Azure.ResourceManager.Monitor.DataCollectionRuleAssociationResource> GetDataCollectionRuleAssociation(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.DataCollectionRuleAssociationResource>> GetDataCollectionRuleAssociationAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Monitor.DataCollectionRuleAssociationResource GetDataCollectionRuleAssociationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Monitor.DataCollectionRuleAssociationCollection GetDataCollectionRuleAssociations(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.DataCollectionRuleResource>> GetDataCollectionRuleAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string dataCollectionRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Monitor.DataCollectionRuleResource GetDataCollectionRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Monitor.DataCollectionRuleCollection GetDataCollectionRules(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Monitor.DataCollectionRuleResource> GetDataCollectionRules(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Monitor.DataCollectionRuleResource> GetDataCollectionRulesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Monitor.DiagnosticSettingResource> GetDiagnosticSetting(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.DiagnosticSettingResource>> GetDiagnosticSettingAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Monitor.DiagnosticSettingResource GetDiagnosticSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Monitor.DiagnosticSettingCollection GetDiagnosticSettings(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.Monitor.DiagnosticSettingsCategoryCollection GetDiagnosticSettingsCategories(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Monitor.DiagnosticSettingsCategoryResource> GetDiagnosticSettingsCategory(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.DiagnosticSettingsCategoryResource>> GetDiagnosticSettingsCategoryAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Monitor.DiagnosticSettingsCategoryResource GetDiagnosticSettingsCategoryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Monitor.Models.MonitorLocalizableString> GetEventCategories(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Monitor.Models.MonitorLocalizableString> GetEventCategoriesAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Monitor.LogProfileResource> GetLogProfile(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string logProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.LogProfileResource>> GetLogProfileAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string logProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Monitor.LogProfileResource GetLogProfileResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Monitor.LogProfileCollection GetLogProfiles(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Monitor.MetricAlertResource> GetMetricAlert(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.MetricAlertResource>> GetMetricAlertAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Monitor.MetricAlertResource GetMetricAlertResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Monitor.MetricAlertCollection GetMetricAlerts(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Monitor.MetricAlertResource> GetMetricAlerts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Monitor.MetricAlertResource> GetMetricAlertsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Monitor.Models.MonitorSingleMetricBaseline> GetMonitorMetricBaselines(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.Monitor.Models.ArmResourceGetMonitorMetricBaselinesOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Monitor.Models.MonitorSingleMetricBaseline> GetMonitorMetricBaselinesAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.Monitor.Models.ArmResourceGetMonitorMetricBaselinesOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Monitor.Models.MonitorMetricDefinition> GetMonitorMetricDefinitions(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string metricnamespace = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Monitor.Models.MonitorMetricDefinition> GetMonitorMetricDefinitionsAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string metricnamespace = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Monitor.Models.MonitorMetricNamespace> GetMonitorMetricNamespaces(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string startTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Monitor.Models.MonitorMetricNamespace> GetMonitorMetricNamespacesAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string startTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Monitor.Models.MonitorMetric> GetMonitorMetrics(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.Monitor.Models.ArmResourceGetMonitorMetricsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Monitor.Models.SubscriptionMonitorMetric> GetMonitorMetrics(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Monitor.Models.SubscriptionResourceGetMonitorMetricsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Monitor.Models.MonitorMetric> GetMonitorMetricsAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.Monitor.Models.ArmResourceGetMonitorMetricsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Monitor.Models.SubscriptionMonitorMetric> GetMonitorMetricsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Monitor.Models.SubscriptionResourceGetMonitorMetricsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Monitor.Models.SubscriptionMonitorMetric> GetMonitorMetricsWithPost(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Monitor.Models.SubscriptionResourceGetMonitorMetricsWithPostOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Monitor.Models.SubscriptionMonitorMetric> GetMonitorMetricsWithPostAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Monitor.Models.SubscriptionResourceGetMonitorMetricsWithPostOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Monitor.MonitorPrivateEndpointConnectionResource GetMonitorPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Monitor.MonitorPrivateLinkResource GetMonitorPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Monitor.MonitorPrivateLinkScopeResource> GetMonitorPrivateLinkScope(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string scopeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.MonitorPrivateLinkScopeResource>> GetMonitorPrivateLinkScopeAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string scopeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Monitor.MonitorPrivateLinkScopedResource GetMonitorPrivateLinkScopedResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Monitor.MonitorPrivateLinkScopeResource GetMonitorPrivateLinkScopeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Monitor.MonitorPrivateLinkScopeCollection GetMonitorPrivateLinkScopes(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Monitor.MonitorPrivateLinkScopeResource> GetMonitorPrivateLinkScopes(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Monitor.MonitorPrivateLinkScopeResource> GetMonitorPrivateLinkScopesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Monitor.MonitorWorkspaceResource GetMonitorWorkspaceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Monitor.MonitorWorkspaceResource> GetMonitorWorkspaceResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string azureMonitorWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.MonitorWorkspaceResource>> GetMonitorWorkspaceResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string azureMonitorWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Monitor.MonitorWorkspaceResourceCollection GetMonitorWorkspaceResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Monitor.MonitorWorkspaceResource> GetMonitorWorkspaceResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Monitor.MonitorWorkspaceResource> GetMonitorWorkspaceResourcesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Response<Azure.ResourceManager.Monitor.Models.NotificationStatus> GetNotificationStatus(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string notificationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Response<Azure.ResourceManager.Monitor.Models.NotificationStatus> GetNotificationStatus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string notificationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.Models.NotificationStatus>> GetNotificationStatusAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string notificationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.Models.NotificationStatus>> GetNotificationStatusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string notificationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Monitor.Models.MonitorPrivateLinkScopeOperationStatus> GetPrivateLinkScopeOperationStatus(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string asyncOperationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.Models.MonitorPrivateLinkScopeOperationStatus>> GetPrivateLinkScopeOperationStatusAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string asyncOperationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Monitor.ScheduledQueryRuleResource> GetScheduledQueryRule(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.ScheduledQueryRuleResource>> GetScheduledQueryRuleAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Monitor.ScheduledQueryRuleResource GetScheduledQueryRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Monitor.ScheduledQueryRuleCollection GetScheduledQueryRules(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Monitor.ScheduledQueryRuleResource> GetScheduledQueryRules(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Monitor.ScheduledQueryRuleResource> GetScheduledQueryRulesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Monitor.Models.EventDataInfo> GetTenantActivityLogs(this Azure.ResourceManager.Resources.TenantResource tenantResource, string filter = null, string select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Monitor.Models.EventDataInfo> GetTenantActivityLogsAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string filter = null, string select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Monitor.VmInsightsOnboardingStatusResource GetVmInsightsOnboardingStatus(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.Monitor.VmInsightsOnboardingStatusResource GetVmInsightsOnboardingStatusResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.Monitor.MonitorPrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Monitor.MonitorPrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Monitor.MonitorPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.MonitorPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Monitor.MonitorPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.MonitorPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MonitorPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public MonitorPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.Monitor.Models.MonitorPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
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
    public partial class MonitorPrivateLinkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MonitorPrivateLinkResource() { }
        public virtual Azure.ResourceManager.Monitor.MonitorPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string scopeName, string groupName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.MonitorPrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.MonitorPrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MonitorPrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.MonitorPrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.MonitorPrivateLinkResource>, System.Collections.IEnumerable
    {
        protected MonitorPrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.MonitorPrivateLinkResource> Get(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.MonitorPrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.MonitorPrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.MonitorPrivateLinkResource>> GetAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Monitor.MonitorPrivateLinkResource> GetIfExists(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Monitor.MonitorPrivateLinkResource>> GetIfExistsAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Monitor.MonitorPrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.MonitorPrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Monitor.MonitorPrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.MonitorPrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MonitorPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public MonitorPrivateLinkResourceData() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
    }
    public partial class MonitorPrivateLinkScopeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.MonitorPrivateLinkScopeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.MonitorPrivateLinkScopeResource>, System.Collections.IEnumerable
    {
        protected MonitorPrivateLinkScopeCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.MonitorPrivateLinkScopeResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string scopeName, Azure.ResourceManager.Monitor.MonitorPrivateLinkScopeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.MonitorPrivateLinkScopeResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string scopeName, Azure.ResourceManager.Monitor.MonitorPrivateLinkScopeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string scopeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string scopeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.MonitorPrivateLinkScopeResource> Get(string scopeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.MonitorPrivateLinkScopeResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.MonitorPrivateLinkScopeResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.MonitorPrivateLinkScopeResource>> GetAsync(string scopeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Monitor.MonitorPrivateLinkScopeResource> GetIfExists(string scopeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Monitor.MonitorPrivateLinkScopeResource>> GetIfExistsAsync(string scopeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Monitor.MonitorPrivateLinkScopeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.MonitorPrivateLinkScopeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Monitor.MonitorPrivateLinkScopeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.MonitorPrivateLinkScopeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MonitorPrivateLinkScopeData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public MonitorPrivateLinkScopeData(Azure.Core.AzureLocation location, Azure.ResourceManager.Monitor.Models.MonitorPrivateLinkAccessModeSettings accessModeSettings) { }
        public Azure.ResourceManager.Monitor.Models.MonitorPrivateLinkAccessModeSettings AccessModeSettings { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Monitor.MonitorPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
    }
    public partial class MonitorPrivateLinkScopedResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MonitorPrivateLinkScopedResource() { }
        public virtual Azure.ResourceManager.Monitor.MonitorPrivateLinkScopedResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string scopeName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.MonitorPrivateLinkScopedResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.MonitorPrivateLinkScopedResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.MonitorPrivateLinkScopedResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Monitor.MonitorPrivateLinkScopedResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.MonitorPrivateLinkScopedResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Monitor.MonitorPrivateLinkScopedResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MonitorPrivateLinkScopedResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.MonitorPrivateLinkScopedResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.MonitorPrivateLinkScopedResource>, System.Collections.IEnumerable
    {
        protected MonitorPrivateLinkScopedResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.MonitorPrivateLinkScopedResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.Monitor.MonitorPrivateLinkScopedResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.MonitorPrivateLinkScopedResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.Monitor.MonitorPrivateLinkScopedResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.MonitorPrivateLinkScopedResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.MonitorPrivateLinkScopedResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.MonitorPrivateLinkScopedResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.MonitorPrivateLinkScopedResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Monitor.MonitorPrivateLinkScopedResource> GetIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Monitor.MonitorPrivateLinkScopedResource>> GetIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Monitor.MonitorPrivateLinkScopedResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.MonitorPrivateLinkScopedResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Monitor.MonitorPrivateLinkScopedResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.MonitorPrivateLinkScopedResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MonitorPrivateLinkScopedResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public MonitorPrivateLinkScopedResourceData() { }
        public Azure.Core.ResourceIdentifier LinkedResourceId { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
    }
    public partial class MonitorPrivateLinkScopeResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MonitorPrivateLinkScopeResource() { }
        public virtual Azure.ResourceManager.Monitor.MonitorPrivateLinkScopeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.MonitorPrivateLinkScopeResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.MonitorPrivateLinkScopeResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string scopeName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.MonitorPrivateLinkScopeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.MonitorPrivateLinkScopeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.MonitorPrivateEndpointConnectionResource> GetMonitorPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.MonitorPrivateEndpointConnectionResource>> GetMonitorPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Monitor.MonitorPrivateEndpointConnectionCollection GetMonitorPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.MonitorPrivateLinkResource> GetMonitorPrivateLinkResource(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.MonitorPrivateLinkResource>> GetMonitorPrivateLinkResourceAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Monitor.MonitorPrivateLinkResourceCollection GetMonitorPrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.MonitorPrivateLinkScopedResource> GetMonitorPrivateLinkScopedResource(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.MonitorPrivateLinkScopedResource>> GetMonitorPrivateLinkScopedResourceAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Monitor.MonitorPrivateLinkScopedResourceCollection GetMonitorPrivateLinkScopedResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.MonitorPrivateLinkScopeResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.MonitorPrivateLinkScopeResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.MonitorPrivateLinkScopeResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.MonitorPrivateLinkScopeResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.MonitorPrivateLinkScopeResource> Update(Azure.ResourceManager.Monitor.Models.MonitorPrivateLinkScopePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.MonitorPrivateLinkScopeResource>> UpdateAsync(Azure.ResourceManager.Monitor.Models.MonitorPrivateLinkScopePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MonitorWorkspaceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MonitorWorkspaceResource() { }
        public virtual Azure.ResourceManager.Monitor.MonitorWorkspaceResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.MonitorWorkspaceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.MonitorWorkspaceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string azureMonitorWorkspaceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.MonitorWorkspaceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.MonitorWorkspaceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.MonitorWorkspaceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.MonitorWorkspaceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.MonitorWorkspaceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.MonitorWorkspaceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.MonitorWorkspaceResource> Update(Azure.ResourceManager.Monitor.Models.MonitorWorkspaceResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.MonitorWorkspaceResource>> UpdateAsync(Azure.ResourceManager.Monitor.Models.MonitorWorkspaceResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MonitorWorkspaceResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.MonitorWorkspaceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.MonitorWorkspaceResource>, System.Collections.IEnumerable
    {
        protected MonitorWorkspaceResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.MonitorWorkspaceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string azureMonitorWorkspaceName, Azure.ResourceManager.Monitor.MonitorWorkspaceResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.MonitorWorkspaceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string azureMonitorWorkspaceName, Azure.ResourceManager.Monitor.MonitorWorkspaceResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string azureMonitorWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string azureMonitorWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.MonitorWorkspaceResource> Get(string azureMonitorWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.MonitorWorkspaceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.MonitorWorkspaceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.MonitorWorkspaceResource>> GetAsync(string azureMonitorWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Monitor.MonitorWorkspaceResource> GetIfExists(string azureMonitorWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Monitor.MonitorWorkspaceResource>> GetIfExistsAsync(string azureMonitorWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Monitor.MonitorWorkspaceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.MonitorWorkspaceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Monitor.MonitorWorkspaceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.MonitorWorkspaceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MonitorWorkspaceResourceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public MonitorWorkspaceResourceData(Azure.Core.AzureLocation location) { }
        public string AccountId { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.MonitorWorkspaceDefaultIngestionSettings DefaultIngestionSettings { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.MonitorWorkspaceMetrics Metrics { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Monitor.Models.MonitorWorkspacePrivateEndpointConnection> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.MonitorProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.MonitorWorkspacePublicNetworkAccess? PublicNetworkAccess { get { throw null; } }
    }
    public partial class ScheduledQueryRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.ScheduledQueryRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.ScheduledQueryRuleResource>, System.Collections.IEnumerable
    {
        protected ScheduledQueryRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.ScheduledQueryRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string ruleName, Azure.ResourceManager.Monitor.ScheduledQueryRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.ScheduledQueryRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string ruleName, Azure.ResourceManager.Monitor.ScheduledQueryRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.ScheduledQueryRuleResource> Get(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.ScheduledQueryRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.ScheduledQueryRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.ScheduledQueryRuleResource>> GetAsync(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Monitor.ScheduledQueryRuleResource> GetIfExists(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Monitor.ScheduledQueryRuleResource>> GetIfExistsAsync(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Monitor.ScheduledQueryRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.ScheduledQueryRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Monitor.ScheduledQueryRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.ScheduledQueryRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ScheduledQueryRuleData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ScheduledQueryRuleData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Monitor.Models.ScheduledQueryRuleActions Actions { get { throw null; } set { } }
        public bool? AutoMitigate { get { throw null; } set { } }
        public bool? CheckWorkspaceAlertsStorageConfigured { get { throw null; } set { } }
        public string CreatedWithApiVersion { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.ScheduledQueryRuleCondition> CriteriaAllOf { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public System.TimeSpan? EvaluationFrequency { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public bool? IsLegacyLogAnalyticsRule { get { throw null; } }
        public bool? IsWorkspaceAlertsStorageConfigured { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.ScheduledQueryRuleKind? Kind { get { throw null; } set { } }
        public System.TimeSpan? MuteActionsDuration { get { throw null; } set { } }
        public System.TimeSpan? OverrideQueryTimeRange { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Scopes { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.AlertSeverity? Severity { get { throw null; } set { } }
        public bool? SkipQueryValidation { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> TargetResourceTypes { get { throw null; } }
        public System.TimeSpan? WindowSize { get { throw null; } set { } }
    }
    public partial class ScheduledQueryRuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ScheduledQueryRuleResource() { }
        public virtual Azure.ResourceManager.Monitor.ScheduledQueryRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.ScheduledQueryRuleResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.ScheduledQueryRuleResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string ruleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.ScheduledQueryRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.ScheduledQueryRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.ScheduledQueryRuleResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.ScheduledQueryRuleResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.ScheduledQueryRuleResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.ScheduledQueryRuleResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.ScheduledQueryRuleResource> Update(Azure.ResourceManager.Monitor.Models.ScheduledQueryRulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.ScheduledQueryRuleResource>> UpdateAsync(Azure.ResourceManager.Monitor.Models.ScheduledQueryRulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VmInsightsOnboardingStatusData : Azure.ResourceManager.Models.ResourceData
    {
        internal VmInsightsOnboardingStatusData() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Monitor.Models.DataContainer> Data { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.DataStatus? DataStatus { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.OnboardingStatus? OnboardingStatus { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
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
namespace Azure.ResourceManager.Monitor.Mocking
{
    public partial class MockableMonitorArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableMonitorArmClient() { }
        public virtual Azure.ResourceManager.Monitor.ActionGroupResource GetActionGroupResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Monitor.ActivityLogAlertResource GetActivityLogAlertResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Monitor.AlertRuleResource GetAlertRuleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Monitor.AutoscaleSettingResource GetAutoscaleSettingResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Monitor.DataCollectionEndpointResource GetDataCollectionEndpointResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.DataCollectionRuleAssociationResource> GetDataCollectionRuleAssociation(Azure.Core.ResourceIdentifier scope, string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.DataCollectionRuleAssociationResource>> GetDataCollectionRuleAssociationAsync(Azure.Core.ResourceIdentifier scope, string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Monitor.DataCollectionRuleAssociationResource GetDataCollectionRuleAssociationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Monitor.DataCollectionRuleAssociationCollection GetDataCollectionRuleAssociations(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.Monitor.DataCollectionRuleResource GetDataCollectionRuleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.DiagnosticSettingResource> GetDiagnosticSetting(Azure.Core.ResourceIdentifier scope, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.DiagnosticSettingResource>> GetDiagnosticSettingAsync(Azure.Core.ResourceIdentifier scope, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Monitor.DiagnosticSettingResource GetDiagnosticSettingResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Monitor.DiagnosticSettingCollection GetDiagnosticSettings(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.Monitor.DiagnosticSettingsCategoryCollection GetDiagnosticSettingsCategories(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.DiagnosticSettingsCategoryResource> GetDiagnosticSettingsCategory(Azure.Core.ResourceIdentifier scope, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.DiagnosticSettingsCategoryResource>> GetDiagnosticSettingsCategoryAsync(Azure.Core.ResourceIdentifier scope, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Monitor.DiagnosticSettingsCategoryResource GetDiagnosticSettingsCategoryResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Monitor.LogProfileResource GetLogProfileResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Monitor.MetricAlertResource GetMetricAlertResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.Models.MonitorSingleMetricBaseline> GetMonitorMetricBaselines(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.Monitor.Models.ArmResourceGetMonitorMetricBaselinesOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.Models.MonitorSingleMetricBaseline> GetMonitorMetricBaselinesAsync(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.Monitor.Models.ArmResourceGetMonitorMetricBaselinesOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.Models.MonitorMetricDefinition> GetMonitorMetricDefinitions(Azure.Core.ResourceIdentifier scope, string metricnamespace = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.Models.MonitorMetricDefinition> GetMonitorMetricDefinitionsAsync(Azure.Core.ResourceIdentifier scope, string metricnamespace = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.Models.MonitorMetricNamespace> GetMonitorMetricNamespaces(Azure.Core.ResourceIdentifier scope, string startTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.Models.MonitorMetricNamespace> GetMonitorMetricNamespacesAsync(Azure.Core.ResourceIdentifier scope, string startTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.Models.MonitorMetric> GetMonitorMetrics(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.Monitor.Models.ArmResourceGetMonitorMetricsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.Models.MonitorMetric> GetMonitorMetricsAsync(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.Monitor.Models.ArmResourceGetMonitorMetricsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Monitor.MonitorPrivateEndpointConnectionResource GetMonitorPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Monitor.MonitorPrivateLinkResource GetMonitorPrivateLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Monitor.MonitorPrivateLinkScopedResource GetMonitorPrivateLinkScopedResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Monitor.MonitorPrivateLinkScopeResource GetMonitorPrivateLinkScopeResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Monitor.MonitorWorkspaceResource GetMonitorWorkspaceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Monitor.ScheduledQueryRuleResource GetScheduledQueryRuleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Monitor.VmInsightsOnboardingStatusResource GetVmInsightsOnboardingStatus(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.Monitor.VmInsightsOnboardingStatusResource GetVmInsightsOnboardingStatusResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableMonitorResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableMonitorResourceGroupResource() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.Models.NotificationStatus> CreateNotifications(Azure.WaitUntil waitUntil, Azure.ResourceManager.Monitor.Models.NotificationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.Models.NotificationStatus>> CreateNotificationsAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Monitor.Models.NotificationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.ActionGroupResource> GetActionGroup(string actionGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.ActionGroupResource>> GetActionGroupAsync(string actionGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Monitor.ActionGroupCollection GetActionGroups() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.ActivityLogAlertResource> GetActivityLogAlert(string activityLogAlertName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.ActivityLogAlertResource>> GetActivityLogAlertAsync(string activityLogAlertName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Monitor.ActivityLogAlertCollection GetActivityLogAlerts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.AlertRuleResource> GetAlertRule(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.AlertRuleResource>> GetAlertRuleAsync(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Monitor.AlertRuleCollection GetAlertRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.AutoscaleSettingResource> GetAutoscaleSetting(string autoscaleSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.AutoscaleSettingResource>> GetAutoscaleSettingAsync(string autoscaleSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Monitor.AutoscaleSettingCollection GetAutoscaleSettings() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.DataCollectionEndpointResource> GetDataCollectionEndpoint(string dataCollectionEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.DataCollectionEndpointResource>> GetDataCollectionEndpointAsync(string dataCollectionEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Monitor.DataCollectionEndpointCollection GetDataCollectionEndpoints() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.DataCollectionRuleResource> GetDataCollectionRule(string dataCollectionRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.DataCollectionRuleResource>> GetDataCollectionRuleAsync(string dataCollectionRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Monitor.DataCollectionRuleCollection GetDataCollectionRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.MetricAlertResource> GetMetricAlert(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.MetricAlertResource>> GetMetricAlertAsync(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Monitor.MetricAlertCollection GetMetricAlerts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.MonitorPrivateLinkScopeResource> GetMonitorPrivateLinkScope(string scopeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.MonitorPrivateLinkScopeResource>> GetMonitorPrivateLinkScopeAsync(string scopeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Monitor.MonitorPrivateLinkScopeCollection GetMonitorPrivateLinkScopes() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.MonitorWorkspaceResource> GetMonitorWorkspaceResource(string azureMonitorWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.MonitorWorkspaceResource>> GetMonitorWorkspaceResourceAsync(string azureMonitorWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Monitor.MonitorWorkspaceResourceCollection GetMonitorWorkspaceResources() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.ResourceManager.Monitor.Models.NotificationStatus> GetNotificationStatus(string notificationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.Models.NotificationStatus>> GetNotificationStatusAsync(string notificationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.Models.MonitorPrivateLinkScopeOperationStatus> GetPrivateLinkScopeOperationStatus(string asyncOperationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.Models.MonitorPrivateLinkScopeOperationStatus>> GetPrivateLinkScopeOperationStatusAsync(string asyncOperationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.ScheduledQueryRuleResource> GetScheduledQueryRule(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.ScheduledQueryRuleResource>> GetScheduledQueryRuleAsync(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Monitor.ScheduledQueryRuleCollection GetScheduledQueryRules() { throw null; }
    }
    public partial class MockableMonitorSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableMonitorSubscriptionResource() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.Models.NotificationStatus> CreateNotifications(Azure.WaitUntil waitUntil, Azure.ResourceManager.Monitor.Models.NotificationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.Models.NotificationStatus>> CreateNotificationsAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Monitor.Models.NotificationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.ActionGroupResource> GetActionGroups(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.ActionGroupResource> GetActionGroupsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.ActivityLogAlertResource> GetActivityLogAlerts(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.ActivityLogAlertResource> GetActivityLogAlertsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.Models.EventDataInfo> GetActivityLogs(string filter, string select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.Models.EventDataInfo> GetActivityLogsAsync(string filter, string select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.AlertRuleResource> GetAlertRules(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.AlertRuleResource> GetAlertRulesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.AutoscaleSettingResource> GetAutoscaleSettings(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.AutoscaleSettingResource> GetAutoscaleSettingsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.DataCollectionEndpointResource> GetDataCollectionEndpoints(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.DataCollectionEndpointResource> GetDataCollectionEndpointsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.DataCollectionRuleResource> GetDataCollectionRules(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.DataCollectionRuleResource> GetDataCollectionRulesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.LogProfileResource> GetLogProfile(string logProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.LogProfileResource>> GetLogProfileAsync(string logProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Monitor.LogProfileCollection GetLogProfiles() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.MetricAlertResource> GetMetricAlerts(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.MetricAlertResource> GetMetricAlertsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.Models.SubscriptionMonitorMetric> GetMonitorMetrics(Azure.ResourceManager.Monitor.Models.SubscriptionResourceGetMonitorMetricsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.Models.SubscriptionMonitorMetric> GetMonitorMetricsAsync(Azure.ResourceManager.Monitor.Models.SubscriptionResourceGetMonitorMetricsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.Models.SubscriptionMonitorMetric> GetMonitorMetricsWithPost(Azure.ResourceManager.Monitor.Models.SubscriptionResourceGetMonitorMetricsWithPostOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.Models.SubscriptionMonitorMetric> GetMonitorMetricsWithPostAsync(Azure.ResourceManager.Monitor.Models.SubscriptionResourceGetMonitorMetricsWithPostOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.MonitorPrivateLinkScopeResource> GetMonitorPrivateLinkScopes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.MonitorPrivateLinkScopeResource> GetMonitorPrivateLinkScopesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.MonitorWorkspaceResource> GetMonitorWorkspaceResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.MonitorWorkspaceResource> GetMonitorWorkspaceResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.ResourceManager.Monitor.Models.NotificationStatus> GetNotificationStatus(string notificationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.Models.NotificationStatus>> GetNotificationStatusAsync(string notificationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.ScheduledQueryRuleResource> GetScheduledQueryRules(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.ScheduledQueryRuleResource> GetScheduledQueryRulesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableMonitorTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableMonitorTenantResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.Models.MonitorLocalizableString> GetEventCategories(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.Models.MonitorLocalizableString> GetEventCategoriesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.Models.EventDataInfo> GetTenantActivityLogs(string filter = null, string select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.Models.EventDataInfo> GetTenantActivityLogsAsync(string filter = null, string select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Monitor.Models
{
    public partial class ActionGroupEnableContent
    {
        public ActionGroupEnableContent(string receiverName) { }
        public string ReceiverName { get { throw null; } }
    }
    public partial class ActionGroupPatch
    {
        public ActionGroupPatch() { }
        public bool? IsEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class ActivityLogAlertActionGroup
    {
        public ActivityLogAlertActionGroup(Azure.Core.ResourceIdentifier actionGroupId) { }
        public Azure.Core.ResourceIdentifier ActionGroupId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> WebhookProperties { get { throw null; } }
    }
    public partial class ActivityLogAlertAnyOfOrLeafCondition : Azure.ResourceManager.Monitor.Models.AlertRuleLeafCondition
    {
        public ActivityLogAlertAnyOfOrLeafCondition() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.AlertRuleLeafCondition> AnyOf { get { throw null; } }
    }
    public partial class ActivityLogAlertPatch
    {
        public ActivityLogAlertPatch() { }
        public bool? IsEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public abstract partial class AlertRuleAction
    {
        protected AlertRuleAction() { }
    }
    public abstract partial class AlertRuleCondition
    {
        protected AlertRuleCondition() { }
        public Azure.ResourceManager.Monitor.Models.RuleDataSource DataSource { get { throw null; } set { } }
    }
    public partial class AlertRuleLeafCondition
    {
        public AlertRuleLeafCondition() { }
        public System.Collections.Generic.IList<string> ContainsAny { get { throw null; } }
        public string EqualsValue { get { throw null; } set { } }
        public string Field { get { throw null; } set { } }
    }
    public partial class AlertRulePatch
    {
        public AlertRulePatch() { }
        public Azure.ResourceManager.Monitor.Models.AlertRuleAction Action { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.AlertRuleAction> Actions { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.AlertRuleCondition Condition { get { throw null; } set { } }
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
        private readonly int _dummyPrimitive;
        public AlertSeverity(long value) { throw null; }
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
        public static implicit operator Azure.ResourceManager.Monitor.Models.AlertSeverity (long value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.AlertSeverity left, Azure.ResourceManager.Monitor.Models.AlertSeverity right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class ArmMonitorModelFactory
    {
        public static Azure.ResourceManager.Monitor.ActionGroupData ActionGroupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string groupShortName = null, bool? isEnabled = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.MonitorEmailReceiver> emailReceivers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.MonitorSmsReceiver> smsReceivers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.MonitorWebhookReceiver> webhookReceivers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.MonitorItsmReceiver> itsmReceivers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.MonitorAzureAppPushReceiver> azureAppPushReceivers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.MonitorAutomationRunbookReceiver> automationRunbookReceivers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.MonitorVoiceReceiver> voiceReceivers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.MonitorLogicAppReceiver> logicAppReceivers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.MonitorAzureFunctionReceiver> azureFunctionReceivers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.MonitorArmRoleReceiver> armRoleReceivers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.MonitorEventHubReceiver> eventHubReceivers = null) { throw null; }
        public static Azure.ResourceManager.Monitor.ActivityLogAlertData ActivityLogAlertData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<string> scopes = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.ActivityLogAlertAnyOfOrLeafCondition> conditionAllOf = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.ActivityLogAlertActionGroup> actionsActionGroups = null, bool? isEnabled = default(bool?), string description = null) { throw null; }
        public static Azure.ResourceManager.Monitor.AlertRuleData AlertRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string alertRuleName = null, string description = null, string provisioningState = null, bool isEnabled = false, Azure.ResourceManager.Monitor.Models.AlertRuleCondition condition = null, Azure.ResourceManager.Monitor.Models.AlertRuleAction action = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.AlertRuleAction> actions = null, System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.AutoscaleNotification AutoscaleNotification(Azure.ResourceManager.Monitor.Models.MonitorOperationType operation = default(Azure.ResourceManager.Monitor.Models.MonitorOperationType), Azure.ResourceManager.Monitor.Models.EmailNotification email = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.WebhookNotification> webhooks = null) { throw null; }
        public static Azure.ResourceManager.Monitor.AutoscaleSettingData AutoscaleSettingData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.AutoscaleProfile> profiles = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.AutoscaleNotification> notifications = null, bool? isEnabled = default(bool?), Azure.ResourceManager.Monitor.Models.PredictiveAutoscalePolicy predictiveAutoscalePolicy = null, string autoscaleSettingName = null, Azure.Core.ResourceIdentifier targetResourceId = null, Azure.Core.AzureLocation? targetResourceLocation = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.AutoscaleSettingPredicativeResult AutoscaleSettingPredicativeResult(string timespan = null, System.TimeSpan? interval = default(System.TimeSpan?), string metricName = null, Azure.Core.ResourceIdentifier targetResourceId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.PredictiveValue> data = null) { throw null; }
        public static Azure.ResourceManager.Monitor.DataCollectionEndpointData DataCollectionEndpointData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Monitor.Models.DataCollectionEndpointResourceKind? kind = default(Azure.ResourceManager.Monitor.Models.DataCollectionEndpointResourceKind?), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ETag? etag = default(Azure.ETag?), string description = null, string immutableId = null, string configurationAccessEndpoint = null, string logsIngestionEndpoint = null, string metricsIngestionEndpoint = null, Azure.ResourceManager.Monitor.Models.MonitorPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.Monitor.Models.MonitorPublicNetworkAccess?), Azure.ResourceManager.Monitor.Models.DataCollectionEndpointProvisioningState? provisioningState = default(Azure.ResourceManager.Monitor.Models.DataCollectionEndpointProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.DataCollectionRulePrivateLinkScopedResourceInfo> privateLinkScopedResources = null, Azure.ResourceManager.Monitor.Models.DataCollectionEndpointFailoverConfiguration failoverConfiguration = null, Azure.ResourceManager.Monitor.Models.DataCollectionEndpointMetadata metadata = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.DataCollectionEndpointFailoverConfiguration DataCollectionEndpointFailoverConfiguration(string activeLocation = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.DataCollectionRuleBcdrLocationSpec> locations = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.DataCollectionEndpointMetadata DataCollectionEndpointMetadata(string provisionedBy = null, string provisionedByResourceId = null) { throw null; }
        public static Azure.ResourceManager.Monitor.DataCollectionRuleAssociationData DataCollectionRuleAssociationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? etag = default(Azure.ETag?), string description = null, Azure.Core.ResourceIdentifier dataCollectionRuleId = null, Azure.Core.ResourceIdentifier dataCollectionEndpointId = null, Azure.ResourceManager.Monitor.Models.DataCollectionRuleAssociationProvisioningState? provisioningState = default(Azure.ResourceManager.Monitor.Models.DataCollectionRuleAssociationProvisioningState?), Azure.ResourceManager.Monitor.Models.DataCollectionRuleAssociationMetadata metadata = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.DataCollectionRuleAssociationMetadata DataCollectionRuleAssociationMetadata(string provisionedBy = null, string provisionedByResourceId = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.DataCollectionRuleBcdrFailoverConfigurationSpec DataCollectionRuleBcdrFailoverConfigurationSpec(string activeLocation = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.DataCollectionRuleBcdrLocationSpec> locations = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.DataCollectionRuleBcdrLocationSpec DataCollectionRuleBcdrLocationSpec(Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.Monitor.Models.DataCollectionRuleBcdrLocationSpecProvisioningStatus? provisioningStatus = default(Azure.ResourceManager.Monitor.Models.DataCollectionRuleBcdrLocationSpecProvisioningStatus?)) { throw null; }
        public static Azure.ResourceManager.Monitor.DataCollectionRuleData DataCollectionRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Monitor.Models.DataCollectionRuleResourceKind? kind = default(Azure.ResourceManager.Monitor.Models.DataCollectionRuleResourceKind?), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ETag? etag = default(Azure.ETag?), string description = null, string immutableId = null, Azure.Core.ResourceIdentifier dataCollectionEndpointId = null, Azure.ResourceManager.Monitor.Models.DataCollectionRuleMetadata metadata = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Monitor.Models.DataStreamDeclaration> streamDeclarations = null, Azure.ResourceManager.Monitor.Models.DataCollectionRuleDataSources dataSources = null, Azure.ResourceManager.Monitor.Models.DataCollectionRuleDestinations destinations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.DataFlow> dataFlows = null, Azure.ResourceManager.Monitor.Models.DataCollectionRuleProvisioningState? provisioningState = default(Azure.ResourceManager.Monitor.Models.DataCollectionRuleProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.DataCollectionRuleMetadata DataCollectionRuleMetadata(string provisionedBy = null, string provisionedByResourceId = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.DataCollectionRulePrivateLinkScopedResourceInfo DataCollectionRulePrivateLinkScopedResourceInfo(Azure.Core.ResourceIdentifier resourceId = null, string scopeId = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.DataCollectionRuleRelatedResourceMetadata DataCollectionRuleRelatedResourceMetadata(string provisionedBy = null, string provisionedByResourceId = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.DataContainer DataContainer(Azure.ResourceManager.Monitor.Models.DataContainerWorkspace workspace = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.DataContainerWorkspace DataContainerWorkspace(Azure.Core.ResourceIdentifier id = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string customerId = null) { throw null; }
        public static Azure.ResourceManager.Monitor.DiagnosticSettingData DiagnosticSettingData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier storageAccountId = null, Azure.Core.ResourceIdentifier serviceBusRuleId = null, Azure.Core.ResourceIdentifier eventHubAuthorizationRuleId = null, string eventHubName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.MetricSettings> metrics = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.LogSettings> logs = null, Azure.Core.ResourceIdentifier workspaceId = null, Azure.Core.ResourceIdentifier marketplacePartnerId = null, string logAnalyticsDestinationType = null) { throw null; }
        public static Azure.ResourceManager.Monitor.DiagnosticSettingsCategoryData DiagnosticSettingsCategoryData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Monitor.Models.MonitorCategoryType? categoryType = default(Azure.ResourceManager.Monitor.Models.MonitorCategoryType?), System.Collections.Generic.IEnumerable<string> categoryGroups = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.EventDataHttpRequestInfo EventDataHttpRequestInfo(string clientRequestId = null, System.Net.IPAddress clientIPAddress = null, string method = null, System.Uri uri = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.EventDataInfo EventDataInfo(Azure.ResourceManager.Monitor.Models.SenderAuthorization authorization = null, System.Collections.Generic.IReadOnlyDictionary<string, string> claims = null, string caller = null, string description = null, string id = null, string eventDataId = null, string correlationId = null, Azure.ResourceManager.Monitor.Models.MonitorLocalizableString eventName = null, Azure.ResourceManager.Monitor.Models.MonitorLocalizableString category = null, Azure.ResourceManager.Monitor.Models.EventDataHttpRequestInfo httpRequest = null, Azure.ResourceManager.Monitor.Models.MonitorEventLevel? level = default(Azure.ResourceManager.Monitor.Models.MonitorEventLevel?), string resourceGroupName = null, Azure.ResourceManager.Monitor.Models.MonitorLocalizableString resourceProviderName = null, Azure.Core.ResourceIdentifier resourceId = null, Azure.ResourceManager.Monitor.Models.MonitorLocalizableString resourceType = null, string operationId = null, Azure.ResourceManager.Monitor.Models.MonitorLocalizableString operationName = null, System.Collections.Generic.IReadOnlyDictionary<string, string> properties = null, Azure.ResourceManager.Monitor.Models.MonitorLocalizableString status = null, Azure.ResourceManager.Monitor.Models.MonitorLocalizableString subStatus = null, System.DateTimeOffset? eventTimestamp = default(System.DateTimeOffset?), System.DateTimeOffset? submissionTimestamp = default(System.DateTimeOffset?), string subscriptionId = null, System.Guid? tenantId = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.LogAnalyticsDestination LogAnalyticsDestination(Azure.Core.ResourceIdentifier workspaceResourceId = null, string workspaceId = null, string name = null) { throw null; }
        public static Azure.ResourceManager.Monitor.LogProfileData LogProfileData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.Core.ResourceIdentifier storageAccountId = null, Azure.Core.ResourceIdentifier serviceBusRuleId = null, System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> locations = null, System.Collections.Generic.IEnumerable<string> categories = null, Azure.ResourceManager.Monitor.Models.RetentionPolicy retentionPolicy = null) { throw null; }
        public static Azure.ResourceManager.Monitor.MetricAlertData MetricAlertData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string description = null, int severity = 0, bool isEnabled = false, System.Collections.Generic.IEnumerable<string> scopes = null, System.TimeSpan evaluationFrequency = default(System.TimeSpan), System.TimeSpan windowSize = default(System.TimeSpan), Azure.Core.ResourceType? targetResourceType = default(Azure.Core.ResourceType?), Azure.Core.AzureLocation? targetResourceRegion = default(Azure.Core.AzureLocation?), Azure.ResourceManager.Monitor.Models.MetricAlertCriteria criteria = null, bool? isAutoMitigateEnabled = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.MetricAlertAction> actions = null, System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?), bool? isMigrated = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.MetricAlertStatus MetricAlertStatus(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Monitor.Models.MetricAlertStatusProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.MetricAlertStatusProperties MetricAlertStatusProperties(System.Collections.Generic.IReadOnlyDictionary<string, string> dimensions = null, string status = null, System.DateTimeOffset? timestamp = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.MonitorBaselineMetadata MonitorBaselineMetadata(string name = null, string value = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.MonitorEmailReceiver MonitorEmailReceiver(string name = null, string emailAddress = null, bool? useCommonAlertSchema = default(bool?), Azure.ResourceManager.Monitor.Models.MonitorReceiverStatus? status = default(Azure.ResourceManager.Monitor.Models.MonitorReceiverStatus?)) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.MonitorIncident MonitorIncident(string name = null, string ruleName = null, bool? isActive = default(bool?), System.DateTimeOffset? activatedOn = default(System.DateTimeOffset?), System.DateTimeOffset? resolvedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.MonitoringAccountDestination MonitoringAccountDestination(Azure.Core.ResourceIdentifier accountResourceId = null, string accountId = null, string name = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.MonitorLocalizableString MonitorLocalizableString(string value = null, string localizedValue = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.MonitorMetadataValue MonitorMetadataValue(Azure.ResourceManager.Monitor.Models.MonitorLocalizableString name = null, string value = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.MonitorMetric MonitorMetric(string id = null, string metricType = null, Azure.ResourceManager.Monitor.Models.MonitorLocalizableString name = null, string displayDescription = null, string errorCode = null, string errorMessage = null, Azure.ResourceManager.Monitor.Models.MonitorMetricUnit unit = default(Azure.ResourceManager.Monitor.Models.MonitorMetricUnit), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.MonitorTimeSeriesElement> timeseries = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.MonitorMetricAvailability MonitorMetricAvailability(System.TimeSpan? timeGrain = default(System.TimeSpan?), System.TimeSpan? retention = default(System.TimeSpan?)) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.MonitorMetricDefinition MonitorMetricDefinition(bool? isDimensionRequired = default(bool?), string resourceId = null, string @namespace = null, Azure.ResourceManager.Monitor.Models.MonitorLocalizableString name = null, string displayDescription = null, string category = null, Azure.ResourceManager.Monitor.Models.MonitorMetricClass? metricClass = default(Azure.ResourceManager.Monitor.Models.MonitorMetricClass?), Azure.ResourceManager.Monitor.Models.MonitorMetricUnit? unit = default(Azure.ResourceManager.Monitor.Models.MonitorMetricUnit?), Azure.ResourceManager.Monitor.Models.MonitorAggregationType? primaryAggregationType = default(Azure.ResourceManager.Monitor.Models.MonitorAggregationType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.MonitorAggregationType> supportedAggregationTypes = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.MonitorMetricAvailability> metricAvailabilities = null, string id = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.MonitorLocalizableString> dimensions = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.MonitorMetricNamespace MonitorMetricNamespace(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Monitor.Models.MonitorNamespaceClassification? classification = default(Azure.ResourceManager.Monitor.Models.MonitorNamespaceClassification?), string metricNamespaceNameValue = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.MonitorMetricSingleDimension MonitorMetricSingleDimension(string name = null, string value = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.MonitorMetricValue MonitorMetricValue(System.DateTimeOffset timeStamp = default(System.DateTimeOffset), double? average = default(double?), double? minimum = default(double?), double? maximum = default(double?), double? total = default(double?), double? count = default(double?)) { throw null; }
        public static Azure.ResourceManager.Monitor.MonitorPrivateEndpointConnectionData MonitorPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.Monitor.Models.MonitorPrivateLinkServiceConnectionState connectionState = null, Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointConnectionProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Monitor.MonitorPrivateLinkResourceData MonitorPrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null) { throw null; }
        public static Azure.ResourceManager.Monitor.MonitorPrivateLinkScopeData MonitorPrivateLinkScopeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string provisioningState = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.MonitorPrivateEndpointConnectionData> privateEndpointConnections = null, Azure.ResourceManager.Monitor.Models.MonitorPrivateLinkAccessModeSettings accessModeSettings = null) { throw null; }
        public static Azure.ResourceManager.Monitor.MonitorPrivateLinkScopedResourceData MonitorPrivateLinkScopedResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier linkedResourceId = null, string provisioningState = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.MonitorPrivateLinkScopeOperationStatus MonitorPrivateLinkScopeOperationStatus(string id = null, string name = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string status = null, Azure.ResponseError error = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.MonitorSingleBaseline MonitorSingleBaseline(Azure.ResourceManager.Monitor.Models.MonitorBaselineSensitivity sensitivity = default(Azure.ResourceManager.Monitor.Models.MonitorBaselineSensitivity), System.Collections.Generic.IEnumerable<double> lowThresholds = null, System.Collections.Generic.IEnumerable<double> highThresholds = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.MonitorSingleMetricBaseline MonitorSingleMetricBaseline(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string timespan = null, System.TimeSpan interval = default(System.TimeSpan), string @namespace = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.MonitorTimeSeriesBaseline> baselines = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.MonitorSmsReceiver MonitorSmsReceiver(string name = null, string countryCode = null, string phoneNumber = null, Azure.ResourceManager.Monitor.Models.MonitorReceiverStatus? status = default(Azure.ResourceManager.Monitor.Models.MonitorReceiverStatus?)) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.MonitorTimeSeriesBaseline MonitorTimeSeriesBaseline(string aggregation = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.MonitorMetricSingleDimension> dimensions = null, System.Collections.Generic.IEnumerable<System.DateTimeOffset> timestamps = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.MonitorSingleBaseline> data = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.MonitorBaselineMetadata> metadataValues = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.MonitorTimeSeriesElement MonitorTimeSeriesElement(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.MonitorMetadataValue> metadatavalues = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.MonitorMetricValue> data = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.MonitorWorkspaceDefaultIngestionSettings MonitorWorkspaceDefaultIngestionSettings(Azure.Core.ResourceIdentifier dataCollectionRuleResourceId = null, Azure.Core.ResourceIdentifier dataCollectionEndpointResourceId = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.MonitorWorkspaceIngestionSettings MonitorWorkspaceIngestionSettings(Azure.Core.ResourceIdentifier dataCollectionRuleResourceId = null, Azure.Core.ResourceIdentifier dataCollectionEndpointResourceId = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.MonitorWorkspaceMetricProperties MonitorWorkspaceMetricProperties(string prometheusQueryEndpoint = null, string internalId = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.MonitorWorkspaceMetrics MonitorWorkspaceMetrics(string prometheusQueryEndpoint = null, string internalId = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.MonitorWorkspacePrivateEndpointConnection MonitorWorkspacePrivateEndpointConnection(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<string> groupIds = null, Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.Monitor.Models.MonitorPrivateLinkServiceConnectionState connectionState = null, Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointConnectionProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Monitor.MonitorWorkspaceResourceData MonitorWorkspaceResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), string accountId = null, Azure.ResourceManager.Monitor.Models.MonitorWorkspaceMetrics metrics = null, Azure.ResourceManager.Monitor.Models.MonitorProvisioningState? provisioningState = default(Azure.ResourceManager.Monitor.Models.MonitorProvisioningState?), Azure.ResourceManager.Monitor.Models.MonitorWorkspaceDefaultIngestionSettings defaultIngestionSettings = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.MonitorWorkspacePrivateEndpointConnection> privateEndpointConnections = null, Azure.ResourceManager.Monitor.Models.MonitorWorkspacePublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.Monitor.Models.MonitorWorkspacePublicNetworkAccess?)) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.NotificationActionDetail NotificationActionDetail(string mechanismType = null, string name = null, string status = null, string subState = null, System.DateTimeOffset? sendOn = default(System.DateTimeOffset?), string detail = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.NotificationContext NotificationContext(string notificationSource = null, string contextType = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.NotificationStatus NotificationStatus(Azure.ResourceManager.Monitor.Models.NotificationContext context = null, string state = null, System.DateTimeOffset? completedOn = default(System.DateTimeOffset?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.NotificationActionDetail> actionDetails = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.PredictiveValue PredictiveValue(System.DateTimeOffset timeStamp = default(System.DateTimeOffset), double value = 0) { throw null; }
        public static Azure.ResourceManager.Monitor.ScheduledQueryRuleData ScheduledQueryRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Monitor.Models.ScheduledQueryRuleKind? kind = default(Azure.ResourceManager.Monitor.Models.ScheduledQueryRuleKind?), Azure.ETag? etag = default(Azure.ETag?), string createdWithApiVersion = null, bool? isLegacyLogAnalyticsRule = default(bool?), string description = null, string displayName = null, Azure.ResourceManager.Monitor.Models.AlertSeverity? severity = default(Azure.ResourceManager.Monitor.Models.AlertSeverity?), bool? isEnabled = default(bool?), System.Collections.Generic.IEnumerable<string> scopes = null, System.TimeSpan? evaluationFrequency = default(System.TimeSpan?), System.TimeSpan? windowSize = default(System.TimeSpan?), System.TimeSpan? overrideQueryTimeRange = default(System.TimeSpan?), System.Collections.Generic.IEnumerable<string> targetResourceTypes = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.ScheduledQueryRuleCondition> criteriaAllOf = null, System.TimeSpan? muteActionsDuration = default(System.TimeSpan?), Azure.ResourceManager.Monitor.Models.ScheduledQueryRuleActions actions = null, bool? isWorkspaceAlertsStorageConfigured = default(bool?), bool? checkWorkspaceAlertsStorageConfigured = default(bool?), bool? skipQueryValidation = default(bool?), bool? autoMitigate = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.SenderAuthorization SenderAuthorization(string action = null, string role = null, string scope = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.SubscriptionMonitorMetric SubscriptionMonitorMetric(string id = null, string subscriptionScopeMetricType = null, Azure.ResourceManager.Monitor.Models.MonitorLocalizableString name = null, string displayDescription = null, string errorCode = null, string errorMessage = null, Azure.ResourceManager.Monitor.Models.MonitorMetricUnit unit = default(Azure.ResourceManager.Monitor.Models.MonitorMetricUnit), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.MonitorTimeSeriesElement> timeseries = null) { throw null; }
        public static Azure.ResourceManager.Monitor.VmInsightsOnboardingStatusData VmInsightsOnboardingStatusData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier resourceId = null, Azure.ResourceManager.Monitor.Models.OnboardingStatus? onboardingStatus = default(Azure.ResourceManager.Monitor.Models.OnboardingStatus?), Azure.ResourceManager.Monitor.Models.DataStatus? dataStatus = default(Azure.ResourceManager.Monitor.Models.DataStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.DataContainer> data = null) { throw null; }
    }
    public partial class ArmResourceGetMonitorMetricBaselinesOptions
    {
        public ArmResourceGetMonitorMetricBaselinesOptions() { }
        public string Aggregation { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public System.TimeSpan? Interval { get { throw null; } set { } }
        public string Metricnames { get { throw null; } set { } }
        public string Metricnamespace { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.MonitorResultType? ResultType { get { throw null; } set { } }
        public string Sensitivities { get { throw null; } set { } }
        public string Timespan { get { throw null; } set { } }
    }
    public partial class ArmResourceGetMonitorMetricsOptions
    {
        public ArmResourceGetMonitorMetricsOptions() { }
        public string Aggregation { get { throw null; } set { } }
        public bool? AutoAdjustTimegrain { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public System.TimeSpan? Interval { get { throw null; } set { } }
        public string Metricnames { get { throw null; } set { } }
        public string Metricnamespace { get { throw null; } set { } }
        public string Orderby { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.MonitorResultType? ResultType { get { throw null; } set { } }
        public string Timespan { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
        public bool? ValidateDimensions { get { throw null; } set { } }
    }
    public partial class AutoscaleNotification
    {
        public AutoscaleNotification() { }
        public Azure.ResourceManager.Monitor.Models.EmailNotification Email { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.MonitorOperationType Operation { get { throw null; } [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)] set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.WebhookNotification> Webhooks { get { throw null; } }
    }
    public partial class AutoscaleProfile
    {
        public AutoscaleProfile(string name, Azure.ResourceManager.Monitor.Models.MonitorScaleCapacity capacity, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.AutoscaleRule> rules) { }
        public Azure.ResourceManager.Monitor.Models.MonitorScaleCapacity Capacity { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.MonitorTimeWindow FixedDate { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.MonitorRecurrence Recurrence { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.AutoscaleRule> Rules { get { throw null; } }
    }
    public partial class AutoscaleRule
    {
        public AutoscaleRule(Azure.ResourceManager.Monitor.Models.MetricTrigger metricTrigger, Azure.ResourceManager.Monitor.Models.MonitorScaleAction scaleAction) { }
        public Azure.ResourceManager.Monitor.Models.MetricTrigger MetricTrigger { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.MonitorScaleAction ScaleAction { get { throw null; } set { } }
    }
    public partial class AutoscaleRuleMetricDimension
    {
        public AutoscaleRuleMetricDimension(string dimensionName, Azure.ResourceManager.Monitor.Models.ScaleRuleMetricDimensionOperationType @operator, System.Collections.Generic.IEnumerable<string> values) { }
        public string DimensionName { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.ScaleRuleMetricDimensionOperationType Operator { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
    }
    public partial class AutoscaleSettingPatch
    {
        public AutoscaleSettingPatch() { }
        public string AutoscaleSettingName { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.AutoscaleNotification> Notifications { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.PredictiveAutoscalePolicy PredictiveAutoscalePolicy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.AutoscaleProfile> Profiles { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetResourceId { get { throw null; } set { } }
        public Azure.Core.AzureLocation? TargetResourceLocation { get { throw null; } set { } }
    }
    public partial class AutoscaleSettingPredicativeResult
    {
        internal AutoscaleSettingPredicativeResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Monitor.Models.PredictiveValue> Data { get { throw null; } }
        public System.TimeSpan? Interval { get { throw null; } }
        public string MetricName { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetResourceId { get { throw null; } }
        public string Timespan { get { throw null; } }
    }
    public partial class ConditionFailingPeriods
    {
        public ConditionFailingPeriods() { }
        public long? MinFailingPeriodsToAlert { get { throw null; } set { } }
        public long? NumberOfEvaluationPeriods { get { throw null; } set { } }
    }
    public partial class DataCollectionEndpointFailoverConfiguration : Azure.ResourceManager.Monitor.Models.DataCollectionRuleBcdrFailoverConfigurationSpec
    {
        internal DataCollectionEndpointFailoverConfiguration() { }
    }
    public partial class DataCollectionEndpointMetadata : Azure.ResourceManager.Monitor.Models.DataCollectionRuleRelatedResourceMetadata
    {
        internal DataCollectionEndpointMetadata() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataCollectionEndpointProvisioningState : System.IEquatable<Azure.ResourceManager.Monitor.Models.DataCollectionEndpointProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataCollectionEndpointProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.DataCollectionEndpointProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.DataCollectionEndpointProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.DataCollectionEndpointProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.DataCollectionEndpointProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.DataCollectionEndpointProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.DataCollectionEndpointProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.DataCollectionEndpointProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.DataCollectionEndpointProvisioningState left, Azure.ResourceManager.Monitor.Models.DataCollectionEndpointProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.DataCollectionEndpointProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.DataCollectionEndpointProvisioningState left, Azure.ResourceManager.Monitor.Models.DataCollectionEndpointProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataCollectionEndpointResourceKind : System.IEquatable<Azure.ResourceManager.Monitor.Models.DataCollectionEndpointResourceKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataCollectionEndpointResourceKind(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.DataCollectionEndpointResourceKind Linux { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.DataCollectionEndpointResourceKind Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.DataCollectionEndpointResourceKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.DataCollectionEndpointResourceKind left, Azure.ResourceManager.Monitor.Models.DataCollectionEndpointResourceKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.DataCollectionEndpointResourceKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.DataCollectionEndpointResourceKind left, Azure.ResourceManager.Monitor.Models.DataCollectionEndpointResourceKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataCollectionRuleAssociationMetadata : Azure.ResourceManager.Monitor.Models.DataCollectionRuleRelatedResourceMetadata
    {
        internal DataCollectionRuleAssociationMetadata() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataCollectionRuleAssociationProvisioningState : System.IEquatable<Azure.ResourceManager.Monitor.Models.DataCollectionRuleAssociationProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataCollectionRuleAssociationProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.DataCollectionRuleAssociationProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.DataCollectionRuleAssociationProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.DataCollectionRuleAssociationProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.DataCollectionRuleAssociationProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.DataCollectionRuleAssociationProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.DataCollectionRuleAssociationProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.DataCollectionRuleAssociationProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.DataCollectionRuleAssociationProvisioningState left, Azure.ResourceManager.Monitor.Models.DataCollectionRuleAssociationProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.DataCollectionRuleAssociationProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.DataCollectionRuleAssociationProvisioningState left, Azure.ResourceManager.Monitor.Models.DataCollectionRuleAssociationProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataCollectionRuleBcdrFailoverConfigurationSpec
    {
        internal DataCollectionRuleBcdrFailoverConfigurationSpec() { }
        public string ActiveLocation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Monitor.Models.DataCollectionRuleBcdrLocationSpec> Locations { get { throw null; } }
    }
    public partial class DataCollectionRuleBcdrLocationSpec
    {
        internal DataCollectionRuleBcdrLocationSpec() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.DataCollectionRuleBcdrLocationSpecProvisioningStatus? ProvisioningStatus { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataCollectionRuleBcdrLocationSpecProvisioningStatus : System.IEquatable<Azure.ResourceManager.Monitor.Models.DataCollectionRuleBcdrLocationSpecProvisioningStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataCollectionRuleBcdrLocationSpecProvisioningStatus(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.DataCollectionRuleBcdrLocationSpecProvisioningStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.DataCollectionRuleBcdrLocationSpecProvisioningStatus Creating { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.DataCollectionRuleBcdrLocationSpecProvisioningStatus Deleting { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.DataCollectionRuleBcdrLocationSpecProvisioningStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.DataCollectionRuleBcdrLocationSpecProvisioningStatus Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.DataCollectionRuleBcdrLocationSpecProvisioningStatus Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.DataCollectionRuleBcdrLocationSpecProvisioningStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.DataCollectionRuleBcdrLocationSpecProvisioningStatus left, Azure.ResourceManager.Monitor.Models.DataCollectionRuleBcdrLocationSpecProvisioningStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.DataCollectionRuleBcdrLocationSpecProvisioningStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.DataCollectionRuleBcdrLocationSpecProvisioningStatus left, Azure.ResourceManager.Monitor.Models.DataCollectionRuleBcdrLocationSpecProvisioningStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataCollectionRuleDataSources : Azure.ResourceManager.Monitor.Models.DataSourcesSpec
    {
        public DataCollectionRuleDataSources() { }
    }
    public partial class DataCollectionRuleDestinations : Azure.ResourceManager.Monitor.Models.DestinationsSpec
    {
        public DataCollectionRuleDestinations() { }
    }
    public partial class DataCollectionRuleEventHubDataSource
    {
        public DataCollectionRuleEventHubDataSource() { }
        public string ConsumerGroup { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Stream { get { throw null; } set { } }
    }
    public partial class DataCollectionRuleEventHubDestination
    {
        public DataCollectionRuleEventHubDestination() { }
        public Azure.Core.ResourceIdentifier EventHubResourceId { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class DataCollectionRuleEventHubDirectDestination
    {
        public DataCollectionRuleEventHubDirectDestination() { }
        public Azure.Core.ResourceIdentifier EventHubResourceId { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataCollectionRuleKnownPrometheusForwarderDataSourceStream : System.IEquatable<Azure.ResourceManager.Monitor.Models.DataCollectionRuleKnownPrometheusForwarderDataSourceStream>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataCollectionRuleKnownPrometheusForwarderDataSourceStream(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.DataCollectionRuleKnownPrometheusForwarderDataSourceStream MicrosoftPrometheusMetrics { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.DataCollectionRuleKnownPrometheusForwarderDataSourceStream other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.DataCollectionRuleKnownPrometheusForwarderDataSourceStream left, Azure.ResourceManager.Monitor.Models.DataCollectionRuleKnownPrometheusForwarderDataSourceStream right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.DataCollectionRuleKnownPrometheusForwarderDataSourceStream (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.DataCollectionRuleKnownPrometheusForwarderDataSourceStream left, Azure.ResourceManager.Monitor.Models.DataCollectionRuleKnownPrometheusForwarderDataSourceStream right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataCollectionRuleMetadata : Azure.ResourceManager.Monitor.Models.DataCollectionRuleRelatedResourceMetadata
    {
        internal DataCollectionRuleMetadata() { }
    }
    public partial class DataCollectionRulePrivateLinkScopedResourceInfo
    {
        internal DataCollectionRulePrivateLinkScopedResourceInfo() { }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public string ScopeId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataCollectionRuleProvisioningState : System.IEquatable<Azure.ResourceManager.Monitor.Models.DataCollectionRuleProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataCollectionRuleProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.DataCollectionRuleProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.DataCollectionRuleProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.DataCollectionRuleProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.DataCollectionRuleProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.DataCollectionRuleProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.DataCollectionRuleProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.DataCollectionRuleProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.DataCollectionRuleProvisioningState left, Azure.ResourceManager.Monitor.Models.DataCollectionRuleProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.DataCollectionRuleProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.DataCollectionRuleProvisioningState left, Azure.ResourceManager.Monitor.Models.DataCollectionRuleProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataCollectionRuleRelatedResourceMetadata
    {
        internal DataCollectionRuleRelatedResourceMetadata() { }
        public string ProvisionedBy { get { throw null; } }
        public string ProvisionedByResourceId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataCollectionRuleResourceKind : System.IEquatable<Azure.ResourceManager.Monitor.Models.DataCollectionRuleResourceKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataCollectionRuleResourceKind(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.DataCollectionRuleResourceKind Linux { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.DataCollectionRuleResourceKind Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.DataCollectionRuleResourceKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.DataCollectionRuleResourceKind left, Azure.ResourceManager.Monitor.Models.DataCollectionRuleResourceKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.DataCollectionRuleResourceKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.DataCollectionRuleResourceKind left, Azure.ResourceManager.Monitor.Models.DataCollectionRuleResourceKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataCollectionRuleStorageBlobDestination
    {
        public DataCollectionRuleStorageBlobDestination() { }
        public string ContainerName { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier StorageAccountResourceId { get { throw null; } set { } }
    }
    public partial class DataCollectionRuleStorageTableDestination
    {
        public DataCollectionRuleStorageTableDestination() { }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier StorageAccountResourceId { get { throw null; } set { } }
        public string TableName { get { throw null; } set { } }
    }
    public partial class DataColumnDefinition
    {
        public DataColumnDefinition() { }
        public Azure.ResourceManager.Monitor.Models.DataColumnDefinitionType? DefinitionType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataColumnDefinitionType : System.IEquatable<Azure.ResourceManager.Monitor.Models.DataColumnDefinitionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataColumnDefinitionType(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.DataColumnDefinitionType Boolean { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.DataColumnDefinitionType Datetime { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.DataColumnDefinitionType Dynamic { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.DataColumnDefinitionType Int { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.DataColumnDefinitionType Long { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.DataColumnDefinitionType Real { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.DataColumnDefinitionType String { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.DataColumnDefinitionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.DataColumnDefinitionType left, Azure.ResourceManager.Monitor.Models.DataColumnDefinitionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.DataColumnDefinitionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.DataColumnDefinitionType left, Azure.ResourceManager.Monitor.Models.DataColumnDefinitionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataContainer
    {
        internal DataContainer() { }
        public Azure.ResourceManager.Monitor.Models.DataContainerWorkspace Workspace { get { throw null; } }
    }
    public partial class DataContainerWorkspace
    {
        internal DataContainerWorkspace() { }
        public string CustomerId { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public Azure.Core.AzureLocation Location { get { throw null; } }
    }
    public partial class DataFlow
    {
        public DataFlow() { }
        public string BuiltInTransform { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Destinations { get { throw null; } }
        public string OutputStream { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.DataFlowStream> Streams { get { throw null; } }
        public string TransformKql { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataFlowStream : System.IEquatable<Azure.ResourceManager.Monitor.Models.DataFlowStream>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataFlowStream(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.DataFlowStream MicrosoftEvent { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.DataFlowStream MicrosoftInsightsMetrics { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.DataFlowStream MicrosoftPerf { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.DataFlowStream MicrosoftSyslog { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.DataFlowStream MicrosoftWindowsEvent { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.DataFlowStream other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.DataFlowStream left, Azure.ResourceManager.Monitor.Models.DataFlowStream right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.DataFlowStream (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.DataFlowStream left, Azure.ResourceManager.Monitor.Models.DataFlowStream right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataImportSourcesEventHub : Azure.ResourceManager.Monitor.Models.DataCollectionRuleEventHubDataSource
    {
        public DataImportSourcesEventHub() { }
    }
    public partial class DataSourcesSpec
    {
        public DataSourcesSpec() { }
        public Azure.ResourceManager.Monitor.Models.DataImportSourcesEventHub DataImportsEventHub { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.ExtensionDataSource> Extensions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.IisLogsDataSource> IisLogs { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.LogFilesDataSource> LogFiles { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.PerfCounterDataSource> PerformanceCounters { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.PlatformTelemetryDataSource> PlatformTelemetry { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.PrometheusForwarderDataSource> PrometheusForwarder { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.SyslogDataSource> Syslog { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.WindowsEventLogDataSource> WindowsEventLogs { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.WindowsFirewallLogsDataSource> WindowsFirewallLogs { get { throw null; } }
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
    public partial class DataStreamDeclaration
    {
        public DataStreamDeclaration() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.DataColumnDefinition> Columns { get { throw null; } }
    }
    public partial class DestinationsSpec
    {
        public DestinationsSpec() { }
        public string AzureMonitorMetricsName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.DataCollectionRuleEventHubDestination> EventHubs { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.DataCollectionRuleEventHubDirectDestination> EventHubsDirect { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.LogAnalyticsDestination> LogAnalytics { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.MonitoringAccountDestination> MonitoringAccounts { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.DataCollectionRuleStorageBlobDestination> StorageAccounts { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.DataCollectionRuleStorageBlobDestination> StorageBlobsDirect { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.DataCollectionRuleStorageTableDestination> StorageTablesDirect { get { throw null; } }
    }
    public partial class DynamicMetricCriteria : Azure.ResourceManager.Monitor.Models.MultiMetricCriteria
    {
        public DynamicMetricCriteria(string name, string metricName, Azure.ResourceManager.Monitor.Models.MetricCriteriaTimeAggregationType timeAggregation, Azure.ResourceManager.Monitor.Models.DynamicThresholdOperator @operator, Azure.ResourceManager.Monitor.Models.DynamicThresholdSensitivity alertSensitivity, Azure.ResourceManager.Monitor.Models.DynamicThresholdFailingPeriods failingPeriods) : base (default(string), default(string), default(Azure.ResourceManager.Monitor.Models.MetricCriteriaTimeAggregationType)) { }
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
    public partial class EventDataHttpRequestInfo
    {
        internal EventDataHttpRequestInfo() { }
        public System.Net.IPAddress ClientIPAddress { get { throw null; } }
        public string ClientRequestId { get { throw null; } }
        public string Method { get { throw null; } }
        public System.Uri Uri { get { throw null; } }
    }
    public partial class EventDataInfo
    {
        internal EventDataInfo() { }
        public Azure.ResourceManager.Monitor.Models.SenderAuthorization Authorization { get { throw null; } }
        public string Caller { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.MonitorLocalizableString Category { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Claims { get { throw null; } }
        public string CorrelationId { get { throw null; } }
        public string Description { get { throw null; } }
        public string EventDataId { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.MonitorLocalizableString EventName { get { throw null; } }
        public System.DateTimeOffset? EventTimestamp { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.EventDataHttpRequestInfo HttpRequest { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.MonitorEventLevel? Level { get { throw null; } }
        public string OperationId { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.MonitorLocalizableString OperationName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Properties { get { throw null; } }
        public string ResourceGroupName { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.MonitorLocalizableString ResourceProviderName { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.MonitorLocalizableString ResourceType { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.MonitorLocalizableString Status { get { throw null; } }
        public System.DateTimeOffset? SubmissionTimestamp { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.MonitorLocalizableString SubStatus { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
    }
    public partial class ExtensionDataSource
    {
        public ExtensionDataSource(string extensionName) { }
        public string ExtensionName { get { throw null; } set { } }
        public System.BinaryData ExtensionSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> InputDataSources { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.ExtensionDataSourceStream> Streams { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExtensionDataSourceStream : System.IEquatable<Azure.ResourceManager.Monitor.Models.ExtensionDataSourceStream>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExtensionDataSourceStream(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.ExtensionDataSourceStream MicrosoftEvent { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.ExtensionDataSourceStream MicrosoftInsightsMetrics { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.ExtensionDataSourceStream MicrosoftPerf { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.ExtensionDataSourceStream MicrosoftSyslog { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.ExtensionDataSourceStream MicrosoftWindowsEvent { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.ExtensionDataSourceStream other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.ExtensionDataSourceStream left, Azure.ResourceManager.Monitor.Models.ExtensionDataSourceStream right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.ExtensionDataSourceStream (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.ExtensionDataSourceStream left, Azure.ResourceManager.Monitor.Models.ExtensionDataSourceStream right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IisLogsDataSource
    {
        public IisLogsDataSource(System.Collections.Generic.IEnumerable<string> streams) { }
        public System.Collections.Generic.IList<string> LogDirectories { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Streams { get { throw null; } }
    }
    public partial class LocationThresholdRuleCondition : Azure.ResourceManager.Monitor.Models.AlertRuleCondition
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
        public Azure.Core.ResourceIdentifier WorkspaceResourceId { get { throw null; } set { } }
    }
    public partial class LogFilesDataSource
    {
        public LogFilesDataSource(System.Collections.Generic.IEnumerable<string> streams, System.Collections.Generic.IEnumerable<string> filePatterns, Azure.ResourceManager.Monitor.Models.LogFilesDataSourceFormat format) { }
        public System.Collections.Generic.IList<string> FilePatterns { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.LogFilesDataSourceFormat Format { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Streams { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.LogFileTextSettingsRecordStartTimestampFormat? TextRecordStartTimestampFormat { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogFilesDataSourceFormat : System.IEquatable<Azure.ResourceManager.Monitor.Models.LogFilesDataSourceFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogFilesDataSourceFormat(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.LogFilesDataSourceFormat Text { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.LogFilesDataSourceFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.LogFilesDataSourceFormat left, Azure.ResourceManager.Monitor.Models.LogFilesDataSourceFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.LogFilesDataSourceFormat (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.LogFilesDataSourceFormat left, Azure.ResourceManager.Monitor.Models.LogFilesDataSourceFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogFileTextSettingsRecordStartTimestampFormat : System.IEquatable<Azure.ResourceManager.Monitor.Models.LogFileTextSettingsRecordStartTimestampFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogFileTextSettingsRecordStartTimestampFormat(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.LogFileTextSettingsRecordStartTimestampFormat DdMmmYyyyHhMmSsZzz { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.LogFileTextSettingsRecordStartTimestampFormat DdMMyyHhMmSs { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.LogFileTextSettingsRecordStartTimestampFormat ISO8601 { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.LogFileTextSettingsRecordStartTimestampFormat MDYyyyHhMmSsAMPM { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.LogFileTextSettingsRecordStartTimestampFormat MmmDHhMmSs { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.LogFileTextSettingsRecordStartTimestampFormat MonDdYyyyHhMmSs { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.LogFileTextSettingsRecordStartTimestampFormat YyMMddHhMmSs { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.LogFileTextSettingsRecordStartTimestampFormat YyyyMmDdHhMmSs { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.LogFileTextSettingsRecordStartTimestampFormat YyyyMmDdTHHMmSsK { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.LogFileTextSettingsRecordStartTimestampFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.LogFileTextSettingsRecordStartTimestampFormat left, Azure.ResourceManager.Monitor.Models.LogFileTextSettingsRecordStartTimestampFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.LogFileTextSettingsRecordStartTimestampFormat (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.LogFileTextSettingsRecordStartTimestampFormat left, Azure.ResourceManager.Monitor.Models.LogFileTextSettingsRecordStartTimestampFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LogProfilePatch
    {
        public LogProfilePatch() { }
        public System.Collections.Generic.IList<string> Categories { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.AzureLocation> Locations { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.RetentionPolicy RetentionPolicy { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ServiceBusRuleId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier StorageAccountId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class LogSettings
    {
        public LogSettings(bool isEnabled) { }
        public string Category { get { throw null; } set { } }
        public string CategoryGroup { get { throw null; } set { } }
        public bool IsEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.RetentionPolicy RetentionPolicy { get { throw null; } set { } }
    }
    public partial class ManagementEventAggregationCondition
    {
        public ManagementEventAggregationCondition() { }
        public Azure.ResourceManager.Monitor.Models.MonitorConditionOperator? Operator { get { throw null; } set { } }
        public double? Threshold { get { throw null; } set { } }
        public System.TimeSpan? WindowSize { get { throw null; } set { } }
    }
    public partial class ManagementEventRuleCondition : Azure.ResourceManager.Monitor.Models.AlertRuleCondition
    {
        public ManagementEventRuleCondition() { }
        public Azure.ResourceManager.Monitor.Models.ManagementEventAggregationCondition Aggregation { get { throw null; } set { } }
    }
    public partial class MetricAlertAction
    {
        public MetricAlertAction() { }
        public Azure.Core.ResourceIdentifier ActionGroupId { get { throw null; } set { } }
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
        public Azure.ResourceManager.Monitor.Models.MetricAlertCriteria Criteria { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.TimeSpan? EvaluationFrequency { get { throw null; } set { } }
        public bool? IsAutoMitigateEnabled { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public bool? IsMigrated { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
        public System.Collections.Generic.IList<string> Scopes { get { throw null; } }
        public int? Severity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.Core.AzureLocation? TargetResourceRegion { get { throw null; } set { } }
        public Azure.Core.ResourceType? TargetResourceType { get { throw null; } set { } }
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
        public MetricCriteria(string name, string metricName, Azure.ResourceManager.Monitor.Models.MetricCriteriaTimeAggregationType timeAggregation, Azure.ResourceManager.Monitor.Models.MetricCriteriaOperator @operator, double threshold) : base (default(string), default(string), default(Azure.ResourceManager.Monitor.Models.MetricCriteriaTimeAggregationType)) { }
        public Azure.ResourceManager.Monitor.Models.MetricCriteriaOperator Operator { get { throw null; } set { } }
        public double Threshold { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MetricCriteriaOperator : System.IEquatable<Azure.ResourceManager.Monitor.Models.MetricCriteriaOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MetricCriteriaOperator(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.MetricCriteriaOperator EqualsValue { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MetricCriteriaOperator GreaterThan { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MetricCriteriaOperator GreaterThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MetricCriteriaOperator LessThan { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MetricCriteriaOperator LessThanOrEqual { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.MetricCriteriaOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.MetricCriteriaOperator left, Azure.ResourceManager.Monitor.Models.MetricCriteriaOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.MetricCriteriaOperator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.MetricCriteriaOperator left, Azure.ResourceManager.Monitor.Models.MetricCriteriaOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MetricCriteriaTimeAggregationType : System.IEquatable<Azure.ResourceManager.Monitor.Models.MetricCriteriaTimeAggregationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MetricCriteriaTimeAggregationType(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.MetricCriteriaTimeAggregationType Average { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MetricCriteriaTimeAggregationType Count { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MetricCriteriaTimeAggregationType Maximum { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MetricCriteriaTimeAggregationType Minimum { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MetricCriteriaTimeAggregationType Total { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.MetricCriteriaTimeAggregationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.MetricCriteriaTimeAggregationType left, Azure.ResourceManager.Monitor.Models.MetricCriteriaTimeAggregationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.MetricCriteriaTimeAggregationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.MetricCriteriaTimeAggregationType left, Azure.ResourceManager.Monitor.Models.MetricCriteriaTimeAggregationType right) { throw null; }
        public override string ToString() { throw null; }
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
        public MetricSettings(bool isEnabled) { }
        public string Category { get { throw null; } set { } }
        public bool IsEnabled { get { throw null; } set { } }
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
        public MetricTrigger(string metricName, Azure.Core.ResourceIdentifier metricResourceId, System.TimeSpan timeGrain, Azure.ResourceManager.Monitor.Models.MetricStatisticType statistic, System.TimeSpan timeWindow, Azure.ResourceManager.Monitor.Models.MetricTriggerTimeAggregationType timeAggregation, Azure.ResourceManager.Monitor.Models.MetricTriggerComparisonOperation @operator, double threshold) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.AutoscaleRuleMetricDimension> Dimensions { get { throw null; } set { } }
        public bool? IsDividedPerInstance { get { throw null; } set { } }
        public string MetricName { get { throw null; } set { } }
        public string MetricNamespace { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier MetricResourceId { get { throw null; } set { } }
        public Azure.Core.AzureLocation? MetricResourceLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.MetricTriggerComparisonOperation Operator { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.MetricStatisticType Statistic { get { throw null; } set { } }
        public double Threshold { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.MetricTriggerTimeAggregationType TimeAggregation { get { throw null; } set { } }
        public System.TimeSpan TimeGrain { get { throw null; } set { } }
        public System.TimeSpan TimeWindow { get { throw null; } set { } }
    }
    public enum MetricTriggerComparisonOperation
    {
        EqualsValue = 0,
        NotEquals = 1,
        GreaterThan = 2,
        GreaterThanOrEqual = 3,
        LessThan = 4,
        LessThanOrEqual = 5,
    }
    public enum MetricTriggerTimeAggregationType
    {
        Average = 0,
        Minimum = 1,
        Maximum = 2,
        Total = 3,
        Count = 4,
        Last = 5,
    }
    public enum MonitorAggregationType
    {
        None = 0,
        Average = 1,
        Count = 2,
        Minimum = 3,
        Maximum = 4,
        Total = 5,
    }
    public partial class MonitorArmRoleReceiver
    {
        public MonitorArmRoleReceiver(string name, string roleId) { }
        public string Name { get { throw null; } set { } }
        public string RoleId { get { throw null; } set { } }
        public bool? UseCommonAlertSchema { get { throw null; } set { } }
    }
    public partial class MonitorAutomationRunbookReceiver
    {
        public MonitorAutomationRunbookReceiver(Azure.Core.ResourceIdentifier automationAccountId, string runbookName, Azure.Core.ResourceIdentifier webhookResourceId, bool isGlobalRunbook) { }
        public Azure.Core.ResourceIdentifier AutomationAccountId { get { throw null; } set { } }
        public bool IsGlobalRunbook { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string RunbookName { get { throw null; } set { } }
        public System.Uri ServiceUri { get { throw null; } set { } }
        public bool? UseCommonAlertSchema { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier WebhookResourceId { get { throw null; } set { } }
    }
    public partial class MonitorAzureAppPushReceiver
    {
        public MonitorAzureAppPushReceiver(string name, string emailAddress) { }
        public string EmailAddress { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class MonitorAzureFunctionReceiver
    {
        public MonitorAzureFunctionReceiver(string name, Azure.Core.ResourceIdentifier functionAppResourceId, string functionName, System.Uri httpTriggerUri) { }
        public Azure.Core.ResourceIdentifier FunctionAppResourceId { get { throw null; } set { } }
        public string FunctionName { get { throw null; } set { } }
        public System.Uri HttpTriggerUri { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public bool? UseCommonAlertSchema { get { throw null; } set { } }
    }
    public partial class MonitorBaselineMetadata
    {
        internal MonitorBaselineMetadata() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MonitorBaselineSensitivity : System.IEquatable<Azure.ResourceManager.Monitor.Models.MonitorBaselineSensitivity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MonitorBaselineSensitivity(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.MonitorBaselineSensitivity High { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MonitorBaselineSensitivity Low { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MonitorBaselineSensitivity Medium { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.MonitorBaselineSensitivity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.MonitorBaselineSensitivity left, Azure.ResourceManager.Monitor.Models.MonitorBaselineSensitivity right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.MonitorBaselineSensitivity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.MonitorBaselineSensitivity left, Azure.ResourceManager.Monitor.Models.MonitorBaselineSensitivity right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MonitorCategoryType : System.IEquatable<Azure.ResourceManager.Monitor.Models.MonitorCategoryType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MonitorCategoryType(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.MonitorCategoryType Logs { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MonitorCategoryType Metrics { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.MonitorCategoryType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.MonitorCategoryType left, Azure.ResourceManager.Monitor.Models.MonitorCategoryType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.MonitorCategoryType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.MonitorCategoryType left, Azure.ResourceManager.Monitor.Models.MonitorCategoryType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum MonitorConditionOperator
    {
        GreaterThan = 0,
        GreaterThanOrEqual = 1,
        LessThan = 2,
        LessThanOrEqual = 3,
        EqualsValue = 4,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MonitorDayOfWeek : System.IEquatable<Azure.ResourceManager.Monitor.Models.MonitorDayOfWeek>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MonitorDayOfWeek(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.MonitorDayOfWeek Friday { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MonitorDayOfWeek Monday { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MonitorDayOfWeek Saturday { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MonitorDayOfWeek Sunday { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MonitorDayOfWeek Thursday { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MonitorDayOfWeek Tuesday { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MonitorDayOfWeek Wednesday { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.MonitorDayOfWeek other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.MonitorDayOfWeek left, Azure.ResourceManager.Monitor.Models.MonitorDayOfWeek right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.MonitorDayOfWeek (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.MonitorDayOfWeek left, Azure.ResourceManager.Monitor.Models.MonitorDayOfWeek right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MonitorDimension
    {
        public MonitorDimension(string name, Azure.ResourceManager.Monitor.Models.MonitorDimensionOperator @operator, System.Collections.Generic.IEnumerable<string> values) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.MonitorDimensionOperator Operator { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MonitorDimensionOperator : System.IEquatable<Azure.ResourceManager.Monitor.Models.MonitorDimensionOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MonitorDimensionOperator(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.MonitorDimensionOperator Exclude { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MonitorDimensionOperator Include { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.MonitorDimensionOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.MonitorDimensionOperator left, Azure.ResourceManager.Monitor.Models.MonitorDimensionOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.MonitorDimensionOperator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.MonitorDimensionOperator left, Azure.ResourceManager.Monitor.Models.MonitorDimensionOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MonitorEmailReceiver
    {
        public MonitorEmailReceiver(string name, string emailAddress) { }
        public string EmailAddress { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.MonitorReceiverStatus? Status { get { throw null; } }
        public bool? UseCommonAlertSchema { get { throw null; } set { } }
    }
    public partial class MonitorEventHubReceiver
    {
        public MonitorEventHubReceiver(string name, string eventHubNameSpace, string eventHubName, string subscriptionId) { }
        public string EventHubName { get { throw null; } set { } }
        public string EventHubNameSpace { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        public bool? UseCommonAlertSchema { get { throw null; } set { } }
    }
    public enum MonitorEventLevel
    {
        Critical = 0,
        Error = 1,
        Warning = 2,
        Informational = 3,
        Verbose = 4,
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
    public partial class MonitoringAccountDestination
    {
        public MonitoringAccountDestination() { }
        public string AccountId { get { throw null; } }
        public Azure.Core.ResourceIdentifier AccountResourceId { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class MonitorItsmReceiver
    {
        public MonitorItsmReceiver(string name, string workspaceId, string connectionId, string ticketConfiguration, Azure.Core.AzureLocation region) { }
        public string ConnectionId { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Core.AzureLocation Region { get { throw null; } set { } }
        public string TicketConfiguration { get { throw null; } set { } }
        public string WorkspaceId { get { throw null; } set { } }
    }
    public partial class MonitorLocalizableString
    {
        internal MonitorLocalizableString() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class MonitorLogicAppReceiver
    {
        public MonitorLogicAppReceiver(string name, Azure.Core.ResourceIdentifier resourceId, System.Uri callbackUri) { }
        public System.Uri CallbackUri { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        public bool? UseCommonAlertSchema { get { throw null; } set { } }
    }
    public partial class MonitorMetadataValue
    {
        internal MonitorMetadataValue() { }
        public Azure.ResourceManager.Monitor.Models.MonitorLocalizableString Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class MonitorMetric
    {
        internal MonitorMetric() { }
        public string DisplayDescription { get { throw null; } }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public string Id { get { throw null; } }
        public string MetricType { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.MonitorLocalizableString Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Monitor.Models.MonitorTimeSeriesElement> Timeseries { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.MonitorMetricUnit Unit { get { throw null; } }
    }
    public partial class MonitorMetricAvailability
    {
        internal MonitorMetricAvailability() { }
        public System.TimeSpan? Retention { get { throw null; } }
        public System.TimeSpan? TimeGrain { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MonitorMetricClass : System.IEquatable<Azure.ResourceManager.Monitor.Models.MonitorMetricClass>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MonitorMetricClass(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.MonitorMetricClass Availability { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MonitorMetricClass Errors { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MonitorMetricClass Latency { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MonitorMetricClass Saturation { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MonitorMetricClass Transactions { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.MonitorMetricClass other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.MonitorMetricClass left, Azure.ResourceManager.Monitor.Models.MonitorMetricClass right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.MonitorMetricClass (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.MonitorMetricClass left, Azure.ResourceManager.Monitor.Models.MonitorMetricClass right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MonitorMetricDefinition
    {
        internal MonitorMetricDefinition() { }
        public string Category { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Monitor.Models.MonitorLocalizableString> Dimensions { get { throw null; } }
        public string DisplayDescription { get { throw null; } }
        public string Id { get { throw null; } }
        public bool? IsDimensionRequired { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Monitor.Models.MonitorMetricAvailability> MetricAvailabilities { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.MonitorMetricClass? MetricClass { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.MonitorLocalizableString Name { get { throw null; } }
        public string Namespace { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.MonitorAggregationType? PrimaryAggregationType { get { throw null; } }
        public string ResourceId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Monitor.Models.MonitorAggregationType> SupportedAggregationTypes { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.MonitorMetricUnit? Unit { get { throw null; } }
    }
    public partial class MonitorMetricNamespace : Azure.ResourceManager.Models.ResourceData
    {
        internal MonitorMetricNamespace() { }
        public Azure.ResourceManager.Monitor.Models.MonitorNamespaceClassification? Classification { get { throw null; } }
        public string MetricNamespaceNameValue { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MonitorMetricResultType : System.IEquatable<Azure.ResourceManager.Monitor.Models.MonitorMetricResultType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MonitorMetricResultType(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.MonitorMetricResultType Data { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MonitorMetricResultType Metadata { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.MonitorMetricResultType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.MonitorMetricResultType left, Azure.ResourceManager.Monitor.Models.MonitorMetricResultType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.MonitorMetricResultType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.MonitorMetricResultType left, Azure.ResourceManager.Monitor.Models.MonitorMetricResultType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MonitorMetricSingleDimension
    {
        internal MonitorMetricSingleDimension() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MonitorMetricUnit : System.IEquatable<Azure.ResourceManager.Monitor.Models.MonitorMetricUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MonitorMetricUnit(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.MonitorMetricUnit BitsPerSecond { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MonitorMetricUnit Bytes { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MonitorMetricUnit ByteSeconds { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MonitorMetricUnit BytesPerSecond { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MonitorMetricUnit Cores { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MonitorMetricUnit Count { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MonitorMetricUnit CountPerSecond { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MonitorMetricUnit MilliCores { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MonitorMetricUnit MilliSeconds { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MonitorMetricUnit NanoCores { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MonitorMetricUnit Percent { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MonitorMetricUnit Seconds { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MonitorMetricUnit Unspecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.MonitorMetricUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.MonitorMetricUnit left, Azure.ResourceManager.Monitor.Models.MonitorMetricUnit right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.MonitorMetricUnit (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.MonitorMetricUnit left, Azure.ResourceManager.Monitor.Models.MonitorMetricUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MonitorMetricValue
    {
        internal MonitorMetricValue() { }
        public double? Average { get { throw null; } }
        public double? Count { get { throw null; } }
        public double? Maximum { get { throw null; } }
        public double? Minimum { get { throw null; } }
        public System.DateTimeOffset TimeStamp { get { throw null; } }
        public double? Total { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MonitorNamespaceClassification : System.IEquatable<Azure.ResourceManager.Monitor.Models.MonitorNamespaceClassification>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MonitorNamespaceClassification(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.MonitorNamespaceClassification Custom { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MonitorNamespaceClassification Platform { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MonitorNamespaceClassification Qos { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.MonitorNamespaceClassification other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.MonitorNamespaceClassification left, Azure.ResourceManager.Monitor.Models.MonitorNamespaceClassification right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.MonitorNamespaceClassification (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.MonitorNamespaceClassification left, Azure.ResourceManager.Monitor.Models.MonitorNamespaceClassification right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MonitorOperationType : System.IEquatable<Azure.ResourceManager.Monitor.Models.MonitorOperationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MonitorOperationType(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.MonitorOperationType Scale { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.MonitorOperationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.MonitorOperationType left, Azure.ResourceManager.Monitor.Models.MonitorOperationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.MonitorOperationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.MonitorOperationType left, Azure.ResourceManager.Monitor.Models.MonitorOperationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MonitorPrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MonitorPrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MonitorPrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MonitorPrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MonitorPrivateLinkAccessMode : System.IEquatable<Azure.ResourceManager.Monitor.Models.MonitorPrivateLinkAccessMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MonitorPrivateLinkAccessMode(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.MonitorPrivateLinkAccessMode Open { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MonitorPrivateLinkAccessMode PrivateOnly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.MonitorPrivateLinkAccessMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.MonitorPrivateLinkAccessMode left, Azure.ResourceManager.Monitor.Models.MonitorPrivateLinkAccessMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.MonitorPrivateLinkAccessMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.MonitorPrivateLinkAccessMode left, Azure.ResourceManager.Monitor.Models.MonitorPrivateLinkAccessMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MonitorPrivateLinkAccessModeSettings
    {
        public MonitorPrivateLinkAccessModeSettings(Azure.ResourceManager.Monitor.Models.MonitorPrivateLinkAccessMode queryAccessMode, Azure.ResourceManager.Monitor.Models.MonitorPrivateLinkAccessMode ingestionAccessMode) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.MonitorPrivateLinkAccessModeSettingsExclusion> Exclusions { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.MonitorPrivateLinkAccessMode IngestionAccessMode { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.MonitorPrivateLinkAccessMode QueryAccessMode { get { throw null; } set { } }
    }
    public partial class MonitorPrivateLinkAccessModeSettingsExclusion
    {
        public MonitorPrivateLinkAccessModeSettingsExclusion() { }
        public Azure.ResourceManager.Monitor.Models.MonitorPrivateLinkAccessMode? IngestionAccessMode { get { throw null; } set { } }
        public string PrivateEndpointConnectionName { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.MonitorPrivateLinkAccessMode? QueryAccessMode { get { throw null; } set { } }
    }
    public partial class MonitorPrivateLinkScopeOperationStatus
    {
        internal MonitorPrivateLinkScopeOperationStatus() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class MonitorPrivateLinkScopePatch
    {
        public MonitorPrivateLinkScopePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class MonitorPrivateLinkServiceConnectionState
    {
        public MonitorPrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MonitorProvisioningState : System.IEquatable<Azure.ResourceManager.Monitor.Models.MonitorProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MonitorProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.MonitorProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MonitorProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MonitorProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MonitorProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MonitorProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.MonitorProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.MonitorProvisioningState left, Azure.ResourceManager.Monitor.Models.MonitorProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.MonitorProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.MonitorProvisioningState left, Azure.ResourceManager.Monitor.Models.MonitorProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MonitorPublicNetworkAccess : System.IEquatable<Azure.ResourceManager.Monitor.Models.MonitorPublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MonitorPublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.MonitorPublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MonitorPublicNetworkAccess Enabled { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MonitorPublicNetworkAccess SecuredByPerimeter { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.MonitorPublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.MonitorPublicNetworkAccess left, Azure.ResourceManager.Monitor.Models.MonitorPublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.MonitorPublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.MonitorPublicNetworkAccess left, Azure.ResourceManager.Monitor.Models.MonitorPublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum MonitorReceiverStatus
    {
        NotSpecified = 0,
        Enabled = 1,
        Disabled = 2,
    }
    public partial class MonitorRecurrence
    {
        public MonitorRecurrence(Azure.ResourceManager.Monitor.Models.RecurrenceFrequency frequency, Azure.ResourceManager.Monitor.Models.RecurrentSchedule schedule) { }
        public Azure.ResourceManager.Monitor.Models.RecurrenceFrequency Frequency { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.RecurrentSchedule Schedule { get { throw null; } set { } }
    }
    public enum MonitorResultType
    {
        Data = 0,
        Metadata = 1,
    }
    public partial class MonitorScaleAction
    {
        public MonitorScaleAction(Azure.ResourceManager.Monitor.Models.MonitorScaleDirection direction, Azure.ResourceManager.Monitor.Models.MonitorScaleType scaleType, System.TimeSpan cooldown) { }
        public System.TimeSpan Cooldown { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.MonitorScaleDirection Direction { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.MonitorScaleType ScaleType { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class MonitorScaleCapacity
    {
        public MonitorScaleCapacity(int minimum, int maximum, int @default) { }
        public int Default { get { throw null; } set { } }
        public int Maximum { get { throw null; } set { } }
        public int Minimum { get { throw null; } set { } }
    }
    public enum MonitorScaleDirection
    {
        None = 0,
        Increase = 1,
        Decrease = 2,
    }
    public enum MonitorScaleType
    {
        ChangeCount = 0,
        PercentChangeCount = 1,
        ExactCount = 2,
        ServiceAllowedNextValue = 3,
    }
    public partial class MonitorSingleBaseline
    {
        internal MonitorSingleBaseline() { }
        public System.Collections.Generic.IReadOnlyList<double> HighThresholds { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<double> LowThresholds { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.MonitorBaselineSensitivity Sensitivity { get { throw null; } }
    }
    public partial class MonitorSingleMetricBaseline : Azure.ResourceManager.Models.ResourceData
    {
        internal MonitorSingleMetricBaseline() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Monitor.Models.MonitorTimeSeriesBaseline> Baselines { get { throw null; } }
        public System.TimeSpan Interval { get { throw null; } }
        public string Namespace { get { throw null; } }
        public string Timespan { get { throw null; } }
    }
    public partial class MonitorSmsReceiver
    {
        public MonitorSmsReceiver(string name, string countryCode, string phoneNumber) { }
        public string CountryCode { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string PhoneNumber { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.MonitorReceiverStatus? Status { get { throw null; } }
    }
    public partial class MonitorTimeSeriesBaseline
    {
        internal MonitorTimeSeriesBaseline() { }
        public string Aggregation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Monitor.Models.MonitorSingleBaseline> Data { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Monitor.Models.MonitorMetricSingleDimension> Dimensions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Monitor.Models.MonitorBaselineMetadata> MetadataValues { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.DateTimeOffset> Timestamps { get { throw null; } }
    }
    public partial class MonitorTimeSeriesElement
    {
        internal MonitorTimeSeriesElement() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Monitor.Models.MonitorMetricValue> Data { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Monitor.Models.MonitorMetadataValue> Metadatavalues { get { throw null; } }
    }
    public partial class MonitorTimeWindow
    {
        public MonitorTimeWindow(System.DateTimeOffset startOn, System.DateTimeOffset endOn) { }
        public System.DateTimeOffset EndOn { get { throw null; } set { } }
        public System.DateTimeOffset StartOn { get { throw null; } set { } }
        public string TimeZone { get { throw null; } set { } }
    }
    public partial class MonitorVoiceReceiver
    {
        public MonitorVoiceReceiver(string name, string countryCode, string phoneNumber) { }
        public string CountryCode { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string PhoneNumber { get { throw null; } set { } }
    }
    public partial class MonitorWebhookReceiver
    {
        public MonitorWebhookReceiver(string name, System.Uri serviceUri) { }
        public System.Uri IdentifierUri { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string ObjectId { get { throw null; } set { } }
        public System.Uri ServiceUri { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        public bool? UseAadAuth { get { throw null; } set { } }
        public bool? UseCommonAlertSchema { get { throw null; } set { } }
    }
    public partial class MonitorWorkspaceDefaultIngestionSettings : Azure.ResourceManager.Monitor.Models.MonitorWorkspaceIngestionSettings
    {
        internal MonitorWorkspaceDefaultIngestionSettings() { }
    }
    public partial class MonitorWorkspaceIngestionSettings
    {
        internal MonitorWorkspaceIngestionSettings() { }
        public Azure.Core.ResourceIdentifier DataCollectionEndpointResourceId { get { throw null; } }
        public Azure.Core.ResourceIdentifier DataCollectionRuleResourceId { get { throw null; } }
    }
    public partial class MonitorWorkspaceMetricProperties
    {
        internal MonitorWorkspaceMetricProperties() { }
        public string InternalId { get { throw null; } }
        public string PrometheusQueryEndpoint { get { throw null; } }
    }
    public partial class MonitorWorkspaceMetrics : Azure.ResourceManager.Monitor.Models.MonitorWorkspaceMetricProperties
    {
        internal MonitorWorkspaceMetrics() { }
    }
    public partial class MonitorWorkspacePrivateEndpointConnection : Azure.ResourceManager.Models.ResourceData
    {
        internal MonitorWorkspacePrivateEndpointConnection() { }
        public Azure.ResourceManager.Monitor.Models.MonitorPrivateLinkServiceConnectionState ConnectionState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> GroupIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.MonitorPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MonitorWorkspacePublicNetworkAccess : System.IEquatable<Azure.ResourceManager.Monitor.Models.MonitorWorkspacePublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MonitorWorkspacePublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.MonitorWorkspacePublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.MonitorWorkspacePublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.MonitorWorkspacePublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.MonitorWorkspacePublicNetworkAccess left, Azure.ResourceManager.Monitor.Models.MonitorWorkspacePublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.MonitorWorkspacePublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.MonitorWorkspacePublicNetworkAccess left, Azure.ResourceManager.Monitor.Models.MonitorWorkspacePublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MonitorWorkspaceResourcePatch
    {
        public MonitorWorkspaceResourcePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class MultiMetricCriteria
    {
        public MultiMetricCriteria(string name, string metricName, Azure.ResourceManager.Monitor.Models.MetricCriteriaTimeAggregationType timeAggregation) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.MetricDimension> Dimensions { get { throw null; } }
        public string MetricName { get { throw null; } set { } }
        public string MetricNamespace { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public bool? SkipMetricValidation { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.MetricCriteriaTimeAggregationType TimeAggregation { get { throw null; } set { } }
    }
    public partial class NotificationActionDetail
    {
        internal NotificationActionDetail() { }
        public string Detail { get { throw null; } }
        public string MechanismType { get { throw null; } }
        public string Name { get { throw null; } }
        public System.DateTimeOffset? SendOn { get { throw null; } }
        public string Status { get { throw null; } }
        public string SubState { get { throw null; } }
    }
    public partial class NotificationContent
    {
        public NotificationContent(string alertType) { }
        public string AlertType { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.MonitorArmRoleReceiver> ArmRoleReceivers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.MonitorAutomationRunbookReceiver> AutomationRunbookReceivers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.MonitorAzureAppPushReceiver> AzureAppPushReceivers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.MonitorAzureFunctionReceiver> AzureFunctionReceivers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.MonitorEmailReceiver> EmailReceivers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.MonitorEventHubReceiver> EventHubReceivers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.MonitorItsmReceiver> ItsmReceivers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.MonitorLogicAppReceiver> LogicAppReceivers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.MonitorSmsReceiver> SmsReceivers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.MonitorVoiceReceiver> VoiceReceivers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.MonitorWebhookReceiver> WebhookReceivers { get { throw null; } }
    }
    public partial class NotificationContext
    {
        internal NotificationContext() { }
        public string ContextType { get { throw null; } }
        public string NotificationSource { get { throw null; } }
    }
    public partial class NotificationStatus
    {
        internal NotificationStatus() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Monitor.Models.NotificationActionDetail> ActionDetails { get { throw null; } }
        public System.DateTimeOffset? CompletedOn { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.NotificationContext Context { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string State { get { throw null; } }
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
    public partial class PerfCounterDataSource
    {
        public PerfCounterDataSource() { }
        public System.Collections.Generic.IList<string> CounterSpecifiers { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public int? SamplingFrequencyInSeconds { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.PerfCounterDataSourceStream> Streams { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PerfCounterDataSourceStream : System.IEquatable<Azure.ResourceManager.Monitor.Models.PerfCounterDataSourceStream>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PerfCounterDataSourceStream(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.PerfCounterDataSourceStream MicrosoftInsightsMetrics { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.PerfCounterDataSourceStream MicrosoftPerf { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.PerfCounterDataSourceStream other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.PerfCounterDataSourceStream left, Azure.ResourceManager.Monitor.Models.PerfCounterDataSourceStream right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.PerfCounterDataSourceStream (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.PerfCounterDataSourceStream left, Azure.ResourceManager.Monitor.Models.PerfCounterDataSourceStream right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PlatformTelemetryDataSource
    {
        public PlatformTelemetryDataSource(System.Collections.Generic.IEnumerable<string> streams) { }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Streams { get { throw null; } }
    }
    public partial class PredictiveAutoscalePolicy
    {
        public PredictiveAutoscalePolicy(Azure.ResourceManager.Monitor.Models.PredictiveAutoscalePolicyScaleMode scaleMode) { }
        public System.TimeSpan? ScaleLookAheadTime { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.PredictiveAutoscalePolicyScaleMode ScaleMode { get { throw null; } set { } }
    }
    public enum PredictiveAutoscalePolicyScaleMode
    {
        Disabled = 0,
        ForecastOnly = 1,
        Enabled = 2,
    }
    public partial class PredictiveValue
    {
        internal PredictiveValue() { }
        public System.DateTimeOffset TimeStamp { get { throw null; } }
        public double Value { get { throw null; } }
    }
    public partial class PrometheusForwarderDataSource
    {
        public PrometheusForwarderDataSource() { }
        public System.Collections.Generic.IDictionary<string, string> LabelIncludeFilter { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.DataCollectionRuleKnownPrometheusForwarderDataSourceStream> Streams { get { throw null; } }
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
        public RecurrentSchedule(string timeZone, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Models.MonitorDayOfWeek> days, System.Collections.Generic.IEnumerable<int> hours, System.Collections.Generic.IEnumerable<int> minutes) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.MonitorDayOfWeek> Days { get { throw null; } }
        public System.Collections.Generic.IList<int> Hours { get { throw null; } }
        public System.Collections.Generic.IList<int> Minutes { get { throw null; } }
        public string TimeZone { get { throw null; } set { } }
    }
    public partial class ResourceForUpdate
    {
        public ResourceForUpdate() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class RetentionPolicy
    {
        public RetentionPolicy(bool isEnabled, int days) { }
        public int Days { get { throw null; } set { } }
        public bool IsEnabled { get { throw null; } set { } }
    }
    public abstract partial class RuleDataSource
    {
        protected RuleDataSource() { }
        public Azure.Core.ResourceIdentifier LegacyResourceId { get { throw null; } set { } }
        public string MetricNamespace { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        public string ResourceLocation { get { throw null; } set { } }
    }
    public partial class RuleEmailAction : Azure.ResourceManager.Monitor.Models.AlertRuleAction
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
    public partial class RuleWebhookAction : Azure.ResourceManager.Monitor.Models.AlertRuleAction
    {
        public RuleWebhookAction() { }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public System.Uri ServiceUri { get { throw null; } set { } }
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
    public partial class ScheduledQueryRuleActions
    {
        public ScheduledQueryRuleActions() { }
        public System.Collections.Generic.IList<string> ActionGroups { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> CustomProperties { get { throw null; } }
    }
    public partial class ScheduledQueryRuleCondition
    {
        public ScheduledQueryRuleCondition() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.MonitorDimension> Dimensions { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.ConditionFailingPeriods FailingPeriods { get { throw null; } set { } }
        public string MetricMeasureColumn { get { throw null; } set { } }
        public string MetricName { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.MonitorConditionOperator? Operator { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        public string ResourceIdColumn { get { throw null; } set { } }
        public double? Threshold { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.ScheduledQueryRuleTimeAggregationType? TimeAggregation { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScheduledQueryRuleKind : System.IEquatable<Azure.ResourceManager.Monitor.Models.ScheduledQueryRuleKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScheduledQueryRuleKind(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.ScheduledQueryRuleKind LogAlert { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.ScheduledQueryRuleKind LogToMetric { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.ScheduledQueryRuleKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.ScheduledQueryRuleKind left, Azure.ResourceManager.Monitor.Models.ScheduledQueryRuleKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.ScheduledQueryRuleKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.ScheduledQueryRuleKind left, Azure.ResourceManager.Monitor.Models.ScheduledQueryRuleKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScheduledQueryRulePatch
    {
        public ScheduledQueryRulePatch() { }
        public Azure.ResourceManager.Monitor.Models.ScheduledQueryRuleActions Actions { get { throw null; } set { } }
        public bool? AutoMitigate { get { throw null; } set { } }
        public bool? CheckWorkspaceAlertsStorageConfigured { get { throw null; } set { } }
        public string CreatedWithApiVersion { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.ScheduledQueryRuleCondition> CriteriaAllOf { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.TimeSpan? EvaluationFrequency { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public bool? IsLegacyLogAnalyticsRule { get { throw null; } }
        public bool? IsWorkspaceAlertsStorageConfigured { get { throw null; } }
        public System.TimeSpan? MuteActionsDuration { get { throw null; } set { } }
        public System.TimeSpan? OverrideQueryTimeRange { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Scopes { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.AlertSeverity? Severity { get { throw null; } set { } }
        public bool? SkipQueryValidation { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.Collections.Generic.IList<string> TargetResourceTypes { get { throw null; } }
        public System.TimeSpan? WindowSize { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScheduledQueryRuleTimeAggregationType : System.IEquatable<Azure.ResourceManager.Monitor.Models.ScheduledQueryRuleTimeAggregationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScheduledQueryRuleTimeAggregationType(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.ScheduledQueryRuleTimeAggregationType Average { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.ScheduledQueryRuleTimeAggregationType Count { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.ScheduledQueryRuleTimeAggregationType Maximum { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.ScheduledQueryRuleTimeAggregationType Minimum { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.ScheduledQueryRuleTimeAggregationType Total { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.ScheduledQueryRuleTimeAggregationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.ScheduledQueryRuleTimeAggregationType left, Azure.ResourceManager.Monitor.Models.ScheduledQueryRuleTimeAggregationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.ScheduledQueryRuleTimeAggregationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.ScheduledQueryRuleTimeAggregationType left, Azure.ResourceManager.Monitor.Models.ScheduledQueryRuleTimeAggregationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SenderAuthorization
    {
        internal SenderAuthorization() { }
        public string Action { get { throw null; } }
        public string Role { get { throw null; } }
        public string Scope { get { throw null; } }
    }
    public partial class SubscriptionMonitorMetric
    {
        internal SubscriptionMonitorMetric() { }
        public string DisplayDescription { get { throw null; } }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.MonitorLocalizableString Name { get { throw null; } }
        public string SubscriptionScopeMetricType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Monitor.Models.MonitorTimeSeriesElement> Timeseries { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.MonitorMetricUnit Unit { get { throw null; } }
    }
    public partial class SubscriptionResourceGetMonitorMetricsOptions
    {
        public SubscriptionResourceGetMonitorMetricsOptions(string region) { }
        public string Aggregation { get { throw null; } set { } }
        public bool? AutoAdjustTimegrain { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public System.TimeSpan? Interval { get { throw null; } set { } }
        public string Metricnames { get { throw null; } set { } }
        public string Metricnamespace { get { throw null; } set { } }
        public string Orderby { get { throw null; } set { } }
        public string Region { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.MonitorMetricResultType? ResultType { get { throw null; } set { } }
        public string Timespan { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
        public bool? ValidateDimensions { get { throw null; } set { } }
    }
    public partial class SubscriptionResourceGetMonitorMetricsWithPostContent
    {
        public SubscriptionResourceGetMonitorMetricsWithPostContent() { }
        public string Aggregation { get { throw null; } set { } }
        public bool? AutoAdjustTimegrain { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public System.TimeSpan? Interval { get { throw null; } set { } }
        public string MetricNames { get { throw null; } set { } }
        public string MetricNamespace { get { throw null; } set { } }
        public string OrderBy { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.MonitorMetricResultType? ResultType { get { throw null; } set { } }
        public string RollUpBy { get { throw null; } set { } }
        public System.TimeSpan? Timespan { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
        public bool? ValidateDimensions { get { throw null; } set { } }
    }
    public partial class SubscriptionResourceGetMonitorMetricsWithPostOptions
    {
        public SubscriptionResourceGetMonitorMetricsWithPostOptions(string region) { }
        public string Aggregation { get { throw null; } set { } }
        public bool? AutoAdjustTimegrain { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.SubscriptionResourceGetMonitorMetricsWithPostContent Content { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public System.TimeSpan? Interval { get { throw null; } set { } }
        public string Metricnames { get { throw null; } set { } }
        public string Metricnamespace { get { throw null; } set { } }
        public string Orderby { get { throw null; } set { } }
        public string Region { get { throw null; } }
        public Azure.ResourceManager.Monitor.Models.MonitorMetricResultType? ResultType { get { throw null; } set { } }
        public string Timespan { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
        public bool? ValidateDimensions { get { throw null; } set { } }
    }
    public partial class SyslogDataSource
    {
        public SyslogDataSource() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.SyslogDataSourceFacilityName> FacilityNames { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.SyslogDataSourceLogLevel> LogLevels { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.SyslogDataSourceStream> Streams { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SyslogDataSourceFacilityName : System.IEquatable<Azure.ResourceManager.Monitor.Models.SyslogDataSourceFacilityName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SyslogDataSourceFacilityName(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.SyslogDataSourceFacilityName Asterisk { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.SyslogDataSourceFacilityName Auth { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.SyslogDataSourceFacilityName Authpriv { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.SyslogDataSourceFacilityName Cron { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.SyslogDataSourceFacilityName Daemon { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.SyslogDataSourceFacilityName Kern { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.SyslogDataSourceFacilityName Local0 { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.SyslogDataSourceFacilityName Local1 { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.SyslogDataSourceFacilityName Local2 { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.SyslogDataSourceFacilityName Local3 { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.SyslogDataSourceFacilityName Local4 { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.SyslogDataSourceFacilityName Local5 { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.SyslogDataSourceFacilityName Local6 { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.SyslogDataSourceFacilityName Local7 { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.SyslogDataSourceFacilityName Lpr { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.SyslogDataSourceFacilityName Mail { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.SyslogDataSourceFacilityName Mark { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.SyslogDataSourceFacilityName News { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.SyslogDataSourceFacilityName Syslog { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.SyslogDataSourceFacilityName User { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.SyslogDataSourceFacilityName Uucp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.SyslogDataSourceFacilityName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.SyslogDataSourceFacilityName left, Azure.ResourceManager.Monitor.Models.SyslogDataSourceFacilityName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.SyslogDataSourceFacilityName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.SyslogDataSourceFacilityName left, Azure.ResourceManager.Monitor.Models.SyslogDataSourceFacilityName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SyslogDataSourceLogLevel : System.IEquatable<Azure.ResourceManager.Monitor.Models.SyslogDataSourceLogLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SyslogDataSourceLogLevel(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.SyslogDataSourceLogLevel Alert { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.SyslogDataSourceLogLevel Asterisk { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.SyslogDataSourceLogLevel Critical { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.SyslogDataSourceLogLevel Debug { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.SyslogDataSourceLogLevel Emergency { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.SyslogDataSourceLogLevel Error { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.SyslogDataSourceLogLevel Info { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.SyslogDataSourceLogLevel Notice { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.SyslogDataSourceLogLevel Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.SyslogDataSourceLogLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.SyslogDataSourceLogLevel left, Azure.ResourceManager.Monitor.Models.SyslogDataSourceLogLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.SyslogDataSourceLogLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.SyslogDataSourceLogLevel left, Azure.ResourceManager.Monitor.Models.SyslogDataSourceLogLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SyslogDataSourceStream : System.IEquatable<Azure.ResourceManager.Monitor.Models.SyslogDataSourceStream>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SyslogDataSourceStream(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.SyslogDataSourceStream MicrosoftSyslog { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.SyslogDataSourceStream other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.SyslogDataSourceStream left, Azure.ResourceManager.Monitor.Models.SyslogDataSourceStream right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.SyslogDataSourceStream (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.SyslogDataSourceStream left, Azure.ResourceManager.Monitor.Models.SyslogDataSourceStream right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ThresholdRuleCondition : Azure.ResourceManager.Monitor.Models.AlertRuleCondition
    {
        public ThresholdRuleCondition(Azure.ResourceManager.Monitor.Models.MonitorConditionOperator @operator, double threshold) { }
        public Azure.ResourceManager.Monitor.Models.MonitorConditionOperator Operator { get { throw null; } set { } }
        public double Threshold { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Models.ThresholdRuleConditionTimeAggregationType? TimeAggregation { get { throw null; } set { } }
        public System.TimeSpan? WindowSize { get { throw null; } set { } }
    }
    public enum ThresholdRuleConditionTimeAggregationType
    {
        Average = 0,
        Minimum = 1,
        Maximum = 2,
        Total = 3,
        Last = 4,
    }
    public partial class WebhookNotification
    {
        public WebhookNotification() { }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public System.Uri ServiceUri { get { throw null; } set { } }
    }
    public partial class WebtestLocationAvailabilityCriteria : Azure.ResourceManager.Monitor.Models.MetricAlertCriteria
    {
        public WebtestLocationAvailabilityCriteria(Azure.Core.ResourceIdentifier webTestId, Azure.Core.ResourceIdentifier componentId, float failedLocationCount) { }
        public Azure.Core.ResourceIdentifier ComponentId { get { throw null; } set { } }
        public float FailedLocationCount { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier WebTestId { get { throw null; } set { } }
    }
    public partial class WindowsEventLogDataSource
    {
        public WindowsEventLogDataSource() { }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Models.WindowsEventLogDataSourceStream> Streams { get { throw null; } }
        public System.Collections.Generic.IList<string> XPathQueries { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WindowsEventLogDataSourceStream : System.IEquatable<Azure.ResourceManager.Monitor.Models.WindowsEventLogDataSourceStream>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WindowsEventLogDataSourceStream(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Models.WindowsEventLogDataSourceStream MicrosoftEvent { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Models.WindowsEventLogDataSourceStream MicrosoftWindowsEvent { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Models.WindowsEventLogDataSourceStream other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Models.WindowsEventLogDataSourceStream left, Azure.ResourceManager.Monitor.Models.WindowsEventLogDataSourceStream right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Models.WindowsEventLogDataSourceStream (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Models.WindowsEventLogDataSourceStream left, Azure.ResourceManager.Monitor.Models.WindowsEventLogDataSourceStream right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WindowsFirewallLogsDataSource
    {
        public WindowsFirewallLogsDataSource(System.Collections.Generic.IEnumerable<string> streams) { }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Streams { get { throw null; } }
    }
}
