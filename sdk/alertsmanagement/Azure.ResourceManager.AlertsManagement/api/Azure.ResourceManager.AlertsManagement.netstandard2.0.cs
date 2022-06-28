namespace Azure.ResourceManager.AlertsManagement
{
    public partial class AlertCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AlertsManagement.AlertResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertsManagement.AlertResource>, System.Collections.IEnumerable
    {
        protected AlertCollection() { }
        public virtual Azure.Response<bool> Exists(string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AlertsManagement.AlertResource> Get(string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AlertsManagement.AlertResource> GetAll(string targetResource = null, string targetResourceType = null, string targetResourceGroup = null, Azure.ResourceManager.AlertsManagement.Models.MonitorService? monitorService = default(Azure.ResourceManager.AlertsManagement.Models.MonitorService?), Azure.ResourceManager.AlertsManagement.Models.MonitorCondition? monitorCondition = default(Azure.ResourceManager.AlertsManagement.Models.MonitorCondition?), Azure.ResourceManager.AlertsManagement.Models.Severity? severity = default(Azure.ResourceManager.AlertsManagement.Models.Severity?), Azure.ResourceManager.AlertsManagement.Models.AlertState? alertState = default(Azure.ResourceManager.AlertsManagement.Models.AlertState?), string alertRule = null, string smartGroupId = null, bool? includeContext = default(bool?), bool? includeEgressConfig = default(bool?), long? pageCount = default(long?), Azure.ResourceManager.AlertsManagement.Models.AlertsSortByField? sortBy = default(Azure.ResourceManager.AlertsManagement.Models.AlertsSortByField?), Azure.ResourceManager.AlertsManagement.Models.SortOrder? sortOrder = default(Azure.ResourceManager.AlertsManagement.Models.SortOrder?), string select = null, Azure.ResourceManager.AlertsManagement.Models.TimeRange? timeRange = default(Azure.ResourceManager.AlertsManagement.Models.TimeRange?), string customTimeRange = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AlertsManagement.AlertResource> GetAllAsync(string targetResource = null, string targetResourceType = null, string targetResourceGroup = null, Azure.ResourceManager.AlertsManagement.Models.MonitorService? monitorService = default(Azure.ResourceManager.AlertsManagement.Models.MonitorService?), Azure.ResourceManager.AlertsManagement.Models.MonitorCondition? monitorCondition = default(Azure.ResourceManager.AlertsManagement.Models.MonitorCondition?), Azure.ResourceManager.AlertsManagement.Models.Severity? severity = default(Azure.ResourceManager.AlertsManagement.Models.Severity?), Azure.ResourceManager.AlertsManagement.Models.AlertState? alertState = default(Azure.ResourceManager.AlertsManagement.Models.AlertState?), string alertRule = null, string smartGroupId = null, bool? includeContext = default(bool?), bool? includeEgressConfig = default(bool?), long? pageCount = default(long?), Azure.ResourceManager.AlertsManagement.Models.AlertsSortByField? sortBy = default(Azure.ResourceManager.AlertsManagement.Models.AlertsSortByField?), Azure.ResourceManager.AlertsManagement.Models.SortOrder? sortOrder = default(Azure.ResourceManager.AlertsManagement.Models.SortOrder?), string select = null, Azure.ResourceManager.AlertsManagement.Models.TimeRange? timeRange = default(Azure.ResourceManager.AlertsManagement.Models.TimeRange?), string customTimeRange = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.AlertResource>> GetAsync(string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AlertsManagement.AlertResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AlertsManagement.AlertResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AlertsManagement.AlertResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertsManagement.AlertResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AlertData : Azure.ResourceManager.Models.ResourceData
    {
        public AlertData() { }
        public Azure.ResourceManager.AlertsManagement.Models.AlertProperties Properties { get { throw null; } set { } }
    }
    public partial class AlertProcessingRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleResource>, System.Collections.IEnumerable
    {
        protected AlertProcessingRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string alertProcessingRuleName, Azure.ResourceManager.AlertsManagement.AlertProcessingRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string alertProcessingRuleName, Azure.ResourceManager.AlertsManagement.AlertProcessingRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string alertProcessingRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string alertProcessingRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleResource> Get(string alertProcessingRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleResource>> GetAsync(string alertProcessingRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AlertProcessingRuleData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public AlertProcessingRuleData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleProperties Properties { get { throw null; } set { } }
    }
    public partial class AlertProcessingRuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AlertProcessingRuleResource() { }
        public virtual Azure.ResourceManager.AlertsManagement.AlertProcessingRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string alertProcessingRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleResource> Update(Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleResource>> UpdateAsync(Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AlertResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AlertResource() { }
        public virtual Azure.ResourceManager.AlertsManagement.AlertData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.AlertsManagement.AlertResource> ChangeState(Azure.ResourceManager.AlertsManagement.Models.AlertState newState, string comment = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.AlertResource>> ChangeStateAsync(Azure.ResourceManager.AlertsManagement.Models.AlertState newState, string comment = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string alertId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AlertsManagement.AlertResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.AlertResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AlertsManagement.Models.AlertModification> GetHistory(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.Models.AlertModification>> GetHistoryAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class AlertsManagementExtensions
    {
        public static Azure.Response<Azure.ResourceManager.AlertsManagement.AlertResource> GetAlert(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.AlertResource>> GetAlertAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleResource> GetAlertProcessingRule(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string alertProcessingRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleResource>> GetAlertProcessingRuleAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string alertProcessingRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.AlertProcessingRuleResource GetAlertProcessingRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.AlertProcessingRuleCollection GetAlertProcessingRules(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleResource> GetAlertProcessingRules(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleResource> GetAlertProcessingRulesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.AlertResource GetAlertResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.AlertCollection GetAlerts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AlertsManagement.SmartGroupResource> GetSmartGroup(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string smartGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.SmartGroupResource>> GetSmartGroupAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string smartGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.SmartGroupResource GetSmartGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.SmartGroupCollection GetSmartGroups(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AlertsManagement.Models.AlertsSummary> GetSummaryAlert(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.AlertsManagement.Models.AlertsSummaryGroupByField groupby, bool? includeSmartGroupsCount = default(bool?), string targetResource = null, string targetResourceType = null, string targetResourceGroup = null, Azure.ResourceManager.AlertsManagement.Models.MonitorService? monitorService = default(Azure.ResourceManager.AlertsManagement.Models.MonitorService?), Azure.ResourceManager.AlertsManagement.Models.MonitorCondition? monitorCondition = default(Azure.ResourceManager.AlertsManagement.Models.MonitorCondition?), Azure.ResourceManager.AlertsManagement.Models.Severity? severity = default(Azure.ResourceManager.AlertsManagement.Models.Severity?), Azure.ResourceManager.AlertsManagement.Models.AlertState? alertState = default(Azure.ResourceManager.AlertsManagement.Models.AlertState?), string alertRule = null, Azure.ResourceManager.AlertsManagement.Models.TimeRange? timeRange = default(Azure.ResourceManager.AlertsManagement.Models.TimeRange?), string customTimeRange = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.Models.AlertsSummary>> GetSummaryAlertAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.AlertsManagement.Models.AlertsSummaryGroupByField groupby, bool? includeSmartGroupsCount = default(bool?), string targetResource = null, string targetResourceType = null, string targetResourceGroup = null, Azure.ResourceManager.AlertsManagement.Models.MonitorService? monitorService = default(Azure.ResourceManager.AlertsManagement.Models.MonitorService?), Azure.ResourceManager.AlertsManagement.Models.MonitorCondition? monitorCondition = default(Azure.ResourceManager.AlertsManagement.Models.MonitorCondition?), Azure.ResourceManager.AlertsManagement.Models.Severity? severity = default(Azure.ResourceManager.AlertsManagement.Models.Severity?), Azure.ResourceManager.AlertsManagement.Models.AlertState? alertState = default(Azure.ResourceManager.AlertsManagement.Models.AlertState?), string alertRule = null, Azure.ResourceManager.AlertsManagement.Models.TimeRange? timeRange = default(Azure.ResourceManager.AlertsManagement.Models.TimeRange?), string customTimeRange = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AlertsManagement.Models.AlertsMetaData> MetaDataAlert(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.AlertsManagement.Models.Identifier identifier, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.Models.AlertsMetaData>> MetaDataAlertAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.AlertsManagement.Models.Identifier identifier, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SmartGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AlertsManagement.SmartGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertsManagement.SmartGroupResource>, System.Collections.IEnumerable
    {
        protected SmartGroupCollection() { }
        public virtual Azure.Response<bool> Exists(string smartGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string smartGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AlertsManagement.SmartGroupResource> Get(string smartGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AlertsManagement.SmartGroupResource> GetAll(string targetResource = null, string targetResourceGroup = null, string targetResourceType = null, Azure.ResourceManager.AlertsManagement.Models.MonitorService? monitorService = default(Azure.ResourceManager.AlertsManagement.Models.MonitorService?), Azure.ResourceManager.AlertsManagement.Models.MonitorCondition? monitorCondition = default(Azure.ResourceManager.AlertsManagement.Models.MonitorCondition?), Azure.ResourceManager.AlertsManagement.Models.Severity? severity = default(Azure.ResourceManager.AlertsManagement.Models.Severity?), Azure.ResourceManager.AlertsManagement.Models.AlertState? smartGroupState = default(Azure.ResourceManager.AlertsManagement.Models.AlertState?), Azure.ResourceManager.AlertsManagement.Models.TimeRange? timeRange = default(Azure.ResourceManager.AlertsManagement.Models.TimeRange?), long? pageCount = default(long?), Azure.ResourceManager.AlertsManagement.Models.SmartGroupsSortByField? sortBy = default(Azure.ResourceManager.AlertsManagement.Models.SmartGroupsSortByField?), Azure.ResourceManager.AlertsManagement.Models.SortOrder? sortOrder = default(Azure.ResourceManager.AlertsManagement.Models.SortOrder?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AlertsManagement.SmartGroupResource> GetAllAsync(string targetResource = null, string targetResourceGroup = null, string targetResourceType = null, Azure.ResourceManager.AlertsManagement.Models.MonitorService? monitorService = default(Azure.ResourceManager.AlertsManagement.Models.MonitorService?), Azure.ResourceManager.AlertsManagement.Models.MonitorCondition? monitorCondition = default(Azure.ResourceManager.AlertsManagement.Models.MonitorCondition?), Azure.ResourceManager.AlertsManagement.Models.Severity? severity = default(Azure.ResourceManager.AlertsManagement.Models.Severity?), Azure.ResourceManager.AlertsManagement.Models.AlertState? smartGroupState = default(Azure.ResourceManager.AlertsManagement.Models.AlertState?), Azure.ResourceManager.AlertsManagement.Models.TimeRange? timeRange = default(Azure.ResourceManager.AlertsManagement.Models.TimeRange?), long? pageCount = default(long?), Azure.ResourceManager.AlertsManagement.Models.SmartGroupsSortByField? sortBy = default(Azure.ResourceManager.AlertsManagement.Models.SmartGroupsSortByField?), Azure.ResourceManager.AlertsManagement.Models.SortOrder? sortOrder = default(Azure.ResourceManager.AlertsManagement.Models.SortOrder?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.SmartGroupResource>> GetAsync(string smartGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AlertsManagement.SmartGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AlertsManagement.SmartGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AlertsManagement.SmartGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertsManagement.SmartGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SmartGroupData : Azure.ResourceManager.Models.ResourceData
    {
        public SmartGroupData() { }
        public long? AlertsCount { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AlertsManagement.Models.SmartGroupAggregatedProperty> AlertSeverities { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AlertsManagement.Models.SmartGroupAggregatedProperty> AlertStates { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public string LastModifiedUserName { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AlertsManagement.Models.SmartGroupAggregatedProperty> MonitorConditions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AlertsManagement.Models.SmartGroupAggregatedProperty> MonitorServices { get { throw null; } }
        public string NextLink { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AlertsManagement.Models.SmartGroupAggregatedProperty> ResourceGroups { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AlertsManagement.Models.SmartGroupAggregatedProperty> Resources { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AlertsManagement.Models.SmartGroupAggregatedProperty> ResourceTypes { get { throw null; } }
        public Azure.ResourceManager.AlertsManagement.Models.Severity? Severity { get { throw null; } }
        public Azure.ResourceManager.AlertsManagement.Models.State? SmartGroupState { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
    }
    public partial class SmartGroupResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SmartGroupResource() { }
        public virtual Azure.ResourceManager.AlertsManagement.SmartGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.AlertsManagement.SmartGroupResource> ChangeState(Azure.ResourceManager.AlertsManagement.Models.AlertState newState, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.SmartGroupResource>> ChangeStateAsync(Azure.ResourceManager.AlertsManagement.Models.AlertState newState, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string smartGroupId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AlertsManagement.SmartGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.SmartGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AlertsManagement.Models.SmartGroupModification> GetHistory(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.Models.SmartGroupModification>> GetHistoryAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.AlertsManagement.Models
{
    public partial class Action
    {
        public Action() { }
    }
    public partial class AddActionGroups : Azure.ResourceManager.AlertsManagement.Models.Action
    {
        public AddActionGroups(System.Collections.Generic.IEnumerable<string> actionGroupIds) { }
        public System.Collections.Generic.IList<string> ActionGroupIds { get { throw null; } }
    }
    public partial class AlertModification : Azure.ResourceManager.Models.ResourceData
    {
        public AlertModification() { }
        public Azure.ResourceManager.AlertsManagement.Models.AlertModificationProperties Properties { get { throw null; } set { } }
    }
    public enum AlertModificationEvent
    {
        AlertCreated = 0,
        StateChange = 1,
        MonitorConditionChange = 2,
        SeverityChange = 3,
        ActionRuleTriggered = 4,
        ActionRuleSuppressed = 5,
        ActionsTriggered = 6,
        ActionsSuppressed = 7,
        ActionsFailed = 8,
    }
    public partial class AlertModificationItem
    {
        public AlertModificationItem() { }
        public string Comments { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.AlertsManagement.Models.AlertModificationEvent? ModificationEvent { get { throw null; } set { } }
        public string ModifiedAt { get { throw null; } set { } }
        public string ModifiedBy { get { throw null; } set { } }
        public string NewValue { get { throw null; } set { } }
        public string OldValue { get { throw null; } set { } }
    }
    public partial class AlertModificationProperties
    {
        public AlertModificationProperties() { }
        public string AlertId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AlertsManagement.Models.AlertModificationItem> Modifications { get { throw null; } }
    }
    public partial class AlertProcessingRulePatch
    {
        public AlertProcessingRulePatch() { }
        public bool? Enabled { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class AlertProcessingRuleProperties
    {
        public AlertProcessingRuleProperties(System.Collections.Generic.IEnumerable<string> scopes, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertsManagement.Models.Action> actions) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.AlertsManagement.Models.Action> Actions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AlertsManagement.Models.Condition> Conditions { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
        public Azure.ResourceManager.AlertsManagement.Models.Schedule Schedule { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Scopes { get { throw null; } }
    }
    public partial class AlertProperties
    {
        public AlertProperties() { }
        public System.BinaryData Context { get { throw null; } }
        public System.BinaryData EgressConfig { get { throw null; } }
        public Azure.ResourceManager.AlertsManagement.Models.Essentials Essentials { get { throw null; } set { } }
    }
    public partial class AlertsMetaData
    {
        internal AlertsMetaData() { }
        public Azure.ResourceManager.AlertsManagement.Models.AlertsMetaDataProperties Properties { get { throw null; } }
    }
    public partial class AlertsMetaDataProperties
    {
        internal AlertsMetaDataProperties() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AlertsSortByField : System.IEquatable<Azure.ResourceManager.AlertsManagement.Models.AlertsSortByField>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AlertsSortByField(string value) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.AlertsSortByField AlertState { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.AlertsSortByField LastModifiedDateTime { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.AlertsSortByField MonitorCondition { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.AlertsSortByField Name { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.AlertsSortByField Severity { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.AlertsSortByField StartDateTime { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.AlertsSortByField TargetResource { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.AlertsSortByField TargetResourceGroup { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.AlertsSortByField TargetResourceName { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.AlertsSortByField TargetResourceType { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AlertsManagement.Models.AlertsSortByField other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AlertsManagement.Models.AlertsSortByField left, Azure.ResourceManager.AlertsManagement.Models.AlertsSortByField right) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertsManagement.Models.AlertsSortByField (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AlertsManagement.Models.AlertsSortByField left, Azure.ResourceManager.AlertsManagement.Models.AlertsSortByField right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AlertsSummary : Azure.ResourceManager.Models.ResourceData
    {
        public AlertsSummary() { }
        public Azure.ResourceManager.AlertsManagement.Models.AlertsSummaryGroup Properties { get { throw null; } set { } }
    }
    public partial class AlertsSummaryGroup
    {
        public AlertsSummaryGroup() { }
        public string Groupedby { get { throw null; } set { } }
        public long? SmartGroupsCount { get { throw null; } set { } }
        public long? Total { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AlertsManagement.Models.AlertsSummaryGroupItem> Values { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AlertsSummaryGroupByField : System.IEquatable<Azure.ResourceManager.AlertsManagement.Models.AlertsSummaryGroupByField>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AlertsSummaryGroupByField(string value) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.AlertsSummaryGroupByField AlertRule { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.AlertsSummaryGroupByField AlertState { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.AlertsSummaryGroupByField MonitorCondition { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.AlertsSummaryGroupByField MonitorService { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.AlertsSummaryGroupByField Severity { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.AlertsSummaryGroupByField SignalType { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AlertsManagement.Models.AlertsSummaryGroupByField other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AlertsManagement.Models.AlertsSummaryGroupByField left, Azure.ResourceManager.AlertsManagement.Models.AlertsSummaryGroupByField right) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertsManagement.Models.AlertsSummaryGroupByField (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AlertsManagement.Models.AlertsSummaryGroupByField left, Azure.ResourceManager.AlertsManagement.Models.AlertsSummaryGroupByField right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AlertsSummaryGroupItem
    {
        public AlertsSummaryGroupItem() { }
        public long? Count { get { throw null; } set { } }
        public string Groupedby { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AlertsManagement.Models.AlertsSummaryGroupItem> Values { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AlertState : System.IEquatable<Azure.ResourceManager.AlertsManagement.Models.AlertState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AlertState(string value) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.AlertState Acknowledged { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.AlertState Closed { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.AlertState New { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AlertsManagement.Models.AlertState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AlertsManagement.Models.AlertState left, Azure.ResourceManager.AlertsManagement.Models.AlertState right) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertsManagement.Models.AlertState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AlertsManagement.Models.AlertState left, Azure.ResourceManager.AlertsManagement.Models.AlertState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Condition
    {
        public Condition() { }
        public Azure.ResourceManager.AlertsManagement.Models.Field? Field { get { throw null; } set { } }
        public Azure.ResourceManager.AlertsManagement.Models.Operator? Operator { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
    }
    public partial class DailyRecurrence : Azure.ResourceManager.AlertsManagement.Models.Recurrence
    {
        public DailyRecurrence() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DaysOfWeek : System.IEquatable<Azure.ResourceManager.AlertsManagement.Models.DaysOfWeek>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DaysOfWeek(string value) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.DaysOfWeek Friday { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.DaysOfWeek Monday { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.DaysOfWeek Saturday { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.DaysOfWeek Sunday { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.DaysOfWeek Thursday { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.DaysOfWeek Tuesday { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.DaysOfWeek Wednesday { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AlertsManagement.Models.DaysOfWeek other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AlertsManagement.Models.DaysOfWeek left, Azure.ResourceManager.AlertsManagement.Models.DaysOfWeek right) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertsManagement.Models.DaysOfWeek (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AlertsManagement.Models.DaysOfWeek left, Azure.ResourceManager.AlertsManagement.Models.DaysOfWeek right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Essentials
    {
        public Essentials() { }
        public string AlertRule { get { throw null; } }
        public Azure.ResourceManager.AlertsManagement.Models.AlertState? AlertState { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public bool? IsSuppressed { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public string LastModifiedUserName { get { throw null; } }
        public Azure.ResourceManager.AlertsManagement.Models.MonitorCondition? MonitorCondition { get { throw null; } }
        public System.DateTimeOffset? MonitorConditionResolvedOn { get { throw null; } }
        public Azure.ResourceManager.AlertsManagement.Models.MonitorService? MonitorService { get { throw null; } }
        public Azure.ResourceManager.AlertsManagement.Models.Severity? Severity { get { throw null; } }
        public Azure.ResourceManager.AlertsManagement.Models.SignalType? SignalType { get { throw null; } }
        public string SmartGroupId { get { throw null; } }
        public string SmartGroupingReason { get { throw null; } }
        public string SourceCreatedId { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string TargetResource { get { throw null; } set { } }
        public string TargetResourceGroup { get { throw null; } set { } }
        public string TargetResourceName { get { throw null; } set { } }
        public string TargetResourceType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Field : System.IEquatable<Azure.ResourceManager.AlertsManagement.Models.Field>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Field(string value) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.Field AlertContext { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.Field AlertRuleId { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.Field AlertRuleName { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.Field Description { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.Field MonitorCondition { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.Field MonitorService { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.Field Severity { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.Field SignalType { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.Field TargetResource { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.Field TargetResourceGroup { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.Field TargetResourceType { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AlertsManagement.Models.Field other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AlertsManagement.Models.Field left, Azure.ResourceManager.AlertsManagement.Models.Field right) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertsManagement.Models.Field (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AlertsManagement.Models.Field left, Azure.ResourceManager.AlertsManagement.Models.Field right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Identifier : System.IEquatable<Azure.ResourceManager.AlertsManagement.Models.Identifier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Identifier(string value) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.Identifier MonitorServiceList { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AlertsManagement.Models.Identifier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AlertsManagement.Models.Identifier left, Azure.ResourceManager.AlertsManagement.Models.Identifier right) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertsManagement.Models.Identifier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AlertsManagement.Models.Identifier left, Azure.ResourceManager.AlertsManagement.Models.Identifier right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MonitorCondition : System.IEquatable<Azure.ResourceManager.AlertsManagement.Models.MonitorCondition>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MonitorCondition(string value) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.MonitorCondition Fired { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.MonitorCondition Resolved { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AlertsManagement.Models.MonitorCondition other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AlertsManagement.Models.MonitorCondition left, Azure.ResourceManager.AlertsManagement.Models.MonitorCondition right) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertsManagement.Models.MonitorCondition (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AlertsManagement.Models.MonitorCondition left, Azure.ResourceManager.AlertsManagement.Models.MonitorCondition right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MonitorService : System.IEquatable<Azure.ResourceManager.AlertsManagement.Models.MonitorService>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MonitorService(string value) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.MonitorService ActivityLogAdministrative { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.MonitorService ActivityLogAutoscale { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.MonitorService ActivityLogPolicy { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.MonitorService ActivityLogRecommendation { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.MonitorService ActivityLogSecurity { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.MonitorService ApplicationInsights { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.MonitorService LogAnalytics { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.MonitorService Nagios { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.MonitorService Platform { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.MonitorService Scom { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.MonitorService ServiceHealth { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.MonitorService SmartDetector { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.MonitorService VmInsights { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.MonitorService Zabbix { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AlertsManagement.Models.MonitorService other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AlertsManagement.Models.MonitorService left, Azure.ResourceManager.AlertsManagement.Models.MonitorService right) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertsManagement.Models.MonitorService (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AlertsManagement.Models.MonitorService left, Azure.ResourceManager.AlertsManagement.Models.MonitorService right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MonitorServiceDetails
    {
        internal MonitorServiceDetails() { }
        public string DisplayName { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class MonitorServiceList : Azure.ResourceManager.AlertsManagement.Models.AlertsMetaDataProperties
    {
        internal MonitorServiceList() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AlertsManagement.Models.MonitorServiceDetails> Data { get { throw null; } }
    }
    public partial class MonthlyRecurrence : Azure.ResourceManager.AlertsManagement.Models.Recurrence
    {
        public MonthlyRecurrence(System.Collections.Generic.IEnumerable<int> daysOfMonth) { }
        public System.Collections.Generic.IList<int> DaysOfMonth { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Operator : System.IEquatable<Azure.ResourceManager.AlertsManagement.Models.Operator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Operator(string value) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.Operator Contains { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.Operator DoesNotContain { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.Operator EqualsValue { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.Operator NotEquals { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AlertsManagement.Models.Operator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AlertsManagement.Models.Operator left, Azure.ResourceManager.AlertsManagement.Models.Operator right) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertsManagement.Models.Operator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AlertsManagement.Models.Operator left, Azure.ResourceManager.AlertsManagement.Models.Operator right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Recurrence
    {
        public Recurrence() { }
        public string EndTime { get { throw null; } set { } }
        public string StartTime { get { throw null; } set { } }
    }
    public partial class RemoveAllActionGroups : Azure.ResourceManager.AlertsManagement.Models.Action
    {
        public RemoveAllActionGroups() { }
    }
    public partial class Schedule
    {
        public Schedule() { }
        public string EffectiveFrom { get { throw null; } set { } }
        public string EffectiveUntil { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AlertsManagement.Models.Recurrence> Recurrences { get { throw null; } }
        public string TimeZone { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Severity : System.IEquatable<Azure.ResourceManager.AlertsManagement.Models.Severity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Severity(string value) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.Severity Sev0 { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.Severity Sev1 { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.Severity Sev2 { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.Severity Sev3 { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.Severity Sev4 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AlertsManagement.Models.Severity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AlertsManagement.Models.Severity left, Azure.ResourceManager.AlertsManagement.Models.Severity right) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertsManagement.Models.Severity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AlertsManagement.Models.Severity left, Azure.ResourceManager.AlertsManagement.Models.Severity right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SignalType : System.IEquatable<Azure.ResourceManager.AlertsManagement.Models.SignalType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SignalType(string value) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.SignalType Log { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.SignalType Metric { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.SignalType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AlertsManagement.Models.SignalType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AlertsManagement.Models.SignalType left, Azure.ResourceManager.AlertsManagement.Models.SignalType right) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertsManagement.Models.SignalType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AlertsManagement.Models.SignalType left, Azure.ResourceManager.AlertsManagement.Models.SignalType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SmartGroupAggregatedProperty
    {
        public SmartGroupAggregatedProperty() { }
        public long? Count { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class SmartGroupModification : Azure.ResourceManager.Models.ResourceData
    {
        public SmartGroupModification() { }
        public Azure.ResourceManager.AlertsManagement.Models.SmartGroupModificationProperties Properties { get { throw null; } set { } }
    }
    public enum SmartGroupModificationEvent
    {
        SmartGroupCreated = 0,
        StateChange = 1,
        AlertAdded = 2,
        AlertRemoved = 3,
    }
    public partial class SmartGroupModificationItem
    {
        public SmartGroupModificationItem() { }
        public string Comments { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.AlertsManagement.Models.SmartGroupModificationEvent? ModificationEvent { get { throw null; } set { } }
        public string ModifiedAt { get { throw null; } set { } }
        public string ModifiedBy { get { throw null; } set { } }
        public string NewValue { get { throw null; } set { } }
        public string OldValue { get { throw null; } set { } }
    }
    public partial class SmartGroupModificationProperties
    {
        public SmartGroupModificationProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.AlertsManagement.Models.SmartGroupModificationItem> Modifications { get { throw null; } }
        public string NextLink { get { throw null; } set { } }
        public string SmartGroupId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SmartGroupsSortByField : System.IEquatable<Azure.ResourceManager.AlertsManagement.Models.SmartGroupsSortByField>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SmartGroupsSortByField(string value) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.SmartGroupsSortByField AlertsCount { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.SmartGroupsSortByField LastModifiedDateTime { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.SmartGroupsSortByField Severity { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.SmartGroupsSortByField StartDateTime { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.SmartGroupsSortByField State { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AlertsManagement.Models.SmartGroupsSortByField other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AlertsManagement.Models.SmartGroupsSortByField left, Azure.ResourceManager.AlertsManagement.Models.SmartGroupsSortByField right) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertsManagement.Models.SmartGroupsSortByField (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AlertsManagement.Models.SmartGroupsSortByField left, Azure.ResourceManager.AlertsManagement.Models.SmartGroupsSortByField right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SortOrder : System.IEquatable<Azure.ResourceManager.AlertsManagement.Models.SortOrder>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SortOrder(string value) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.SortOrder Asc { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.SortOrder Desc { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AlertsManagement.Models.SortOrder other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AlertsManagement.Models.SortOrder left, Azure.ResourceManager.AlertsManagement.Models.SortOrder right) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertsManagement.Models.SortOrder (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AlertsManagement.Models.SortOrder left, Azure.ResourceManager.AlertsManagement.Models.SortOrder right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct State : System.IEquatable<Azure.ResourceManager.AlertsManagement.Models.State>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public State(string value) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.State Acknowledged { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.State Closed { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.State New { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AlertsManagement.Models.State other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AlertsManagement.Models.State left, Azure.ResourceManager.AlertsManagement.Models.State right) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertsManagement.Models.State (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AlertsManagement.Models.State left, Azure.ResourceManager.AlertsManagement.Models.State right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TimeRange : System.IEquatable<Azure.ResourceManager.AlertsManagement.Models.TimeRange>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TimeRange(string value) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.TimeRange OneD { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.TimeRange OneH { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.TimeRange SevenD { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.TimeRange ThirtyD { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AlertsManagement.Models.TimeRange other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AlertsManagement.Models.TimeRange left, Azure.ResourceManager.AlertsManagement.Models.TimeRange right) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertsManagement.Models.TimeRange (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AlertsManagement.Models.TimeRange left, Azure.ResourceManager.AlertsManagement.Models.TimeRange right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WeeklyRecurrence : Azure.ResourceManager.AlertsManagement.Models.Recurrence
    {
        public WeeklyRecurrence(System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertsManagement.Models.DaysOfWeek> daysOfWeek) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.AlertsManagement.Models.DaysOfWeek> DaysOfWeek { get { throw null; } }
    }
}
