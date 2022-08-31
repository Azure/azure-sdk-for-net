namespace Azure.ResourceManager.AlertsManagement
{
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
        public System.Collections.Generic.IList<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleAction> Actions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleCondition> Conditions { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
        public Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleSchedule Schedule { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Scopes { get { throw null; } }
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
    public static partial class AlertsManagementExtensions
    {
        public static Azure.Response<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleResource> GetAlertProcessingRule(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string alertProcessingRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleResource>> GetAlertProcessingRuleAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string alertProcessingRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.AlertProcessingRuleResource GetAlertProcessingRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.AlertProcessingRuleCollection GetAlertProcessingRules(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleResource> GetAlertProcessingRules(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleResource> GetAlertProcessingRulesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AlertsManagement.ServiceAlertResource> GetServiceAlert(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.ServiceAlertResource>> GetServiceAlertAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.ServiceAlertResource GetServiceAlertResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.ServiceAlertCollection GetServiceAlerts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AlertsManagement.SmartGroupResource> GetSmartGroup(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string smartGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.SmartGroupResource>> GetSmartGroupAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string smartGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.SmartGroupResource GetSmartGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.SmartGroupCollection GetSmartGroups(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertsSummary> GetSummaryAlert(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.AlertsManagement.Models.AlertsSummaryGroupByField groupby, bool? includeSmartGroupsCount = default(bool?), string targetResource = null, string targetResourceType = null, string targetResourceGroup = null, Azure.ResourceManager.AlertsManagement.Models.MonitorService? monitorService = default(Azure.ResourceManager.AlertsManagement.Models.MonitorService?), Azure.ResourceManager.AlertsManagement.Models.MonitorCondition? monitorCondition = default(Azure.ResourceManager.AlertsManagement.Models.MonitorCondition?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity? severity = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity?), Azure.ResourceManager.AlertsManagement.Models.AlertState? alertState = default(Azure.ResourceManager.AlertsManagement.Models.AlertState?), string alertRule = null, Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter? timeRange = default(Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter?), string customTimeRange = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertsSummary>> GetSummaryAlertAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.AlertsManagement.Models.AlertsSummaryGroupByField groupby, bool? includeSmartGroupsCount = default(bool?), string targetResource = null, string targetResourceType = null, string targetResourceGroup = null, Azure.ResourceManager.AlertsManagement.Models.MonitorService? monitorService = default(Azure.ResourceManager.AlertsManagement.Models.MonitorService?), Azure.ResourceManager.AlertsManagement.Models.MonitorCondition? monitorCondition = default(Azure.ResourceManager.AlertsManagement.Models.MonitorCondition?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity? severity = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity?), Azure.ResourceManager.AlertsManagement.Models.AlertState? alertState = default(Azure.ResourceManager.AlertsManagement.Models.AlertState?), string alertRule = null, Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter? timeRange = default(Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter?), string customTimeRange = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertsMetaData> MetaDataAlert(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.AlertsManagement.Models.InformationIdentifier identifier, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertsMetaData>> MetaDataAlertAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.AlertsManagement.Models.InformationIdentifier identifier, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceAlertCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AlertsManagement.ServiceAlertResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertsManagement.ServiceAlertResource>, System.Collections.IEnumerable
    {
        protected ServiceAlertCollection() { }
        public virtual Azure.Response<bool> Exists(string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AlertsManagement.ServiceAlertResource> Get(string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AlertsManagement.ServiceAlertResource> GetAll(string targetResource = null, string targetResourceType = null, string targetResourceGroup = null, Azure.ResourceManager.AlertsManagement.Models.MonitorService? monitorService = default(Azure.ResourceManager.AlertsManagement.Models.MonitorService?), Azure.ResourceManager.AlertsManagement.Models.MonitorCondition? monitorCondition = default(Azure.ResourceManager.AlertsManagement.Models.MonitorCondition?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity? severity = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity?), Azure.ResourceManager.AlertsManagement.Models.AlertState? alertState = default(Azure.ResourceManager.AlertsManagement.Models.AlertState?), string alertRule = null, string smartGroupId = null, bool? includeContext = default(bool?), bool? includeEgressConfig = default(bool?), long? pageCount = default(long?), Azure.ResourceManager.AlertsManagement.Models.AlertsSortByField? sortBy = default(Azure.ResourceManager.AlertsManagement.Models.AlertsSortByField?), Azure.ResourceManager.AlertsManagement.Models.SortOrder? sortOrder = default(Azure.ResourceManager.AlertsManagement.Models.SortOrder?), string select = null, Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter? timeRange = default(Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter?), string customTimeRange = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AlertsManagement.ServiceAlertResource> GetAllAsync(string targetResource = null, string targetResourceType = null, string targetResourceGroup = null, Azure.ResourceManager.AlertsManagement.Models.MonitorService? monitorService = default(Azure.ResourceManager.AlertsManagement.Models.MonitorService?), Azure.ResourceManager.AlertsManagement.Models.MonitorCondition? monitorCondition = default(Azure.ResourceManager.AlertsManagement.Models.MonitorCondition?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity? severity = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity?), Azure.ResourceManager.AlertsManagement.Models.AlertState? alertState = default(Azure.ResourceManager.AlertsManagement.Models.AlertState?), string alertRule = null, string smartGroupId = null, bool? includeContext = default(bool?), bool? includeEgressConfig = default(bool?), long? pageCount = default(long?), Azure.ResourceManager.AlertsManagement.Models.AlertsSortByField? sortBy = default(Azure.ResourceManager.AlertsManagement.Models.AlertsSortByField?), Azure.ResourceManager.AlertsManagement.Models.SortOrder? sortOrder = default(Azure.ResourceManager.AlertsManagement.Models.SortOrder?), string select = null, Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter? timeRange = default(Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter?), string customTimeRange = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.ServiceAlertResource>> GetAsync(string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AlertsManagement.ServiceAlertResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AlertsManagement.ServiceAlertResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AlertsManagement.ServiceAlertResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertsManagement.ServiceAlertResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceAlertData : Azure.ResourceManager.Models.ResourceData
    {
        public ServiceAlertData() { }
        public System.BinaryData Context { get { throw null; } }
        public System.BinaryData EgressConfig { get { throw null; } }
        public Azure.ResourceManager.AlertsManagement.Models.ServiceAlertEssentials Essentials { get { throw null; } set { } }
    }
    public partial class ServiceAlertResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServiceAlertResource() { }
        public virtual Azure.ResourceManager.AlertsManagement.ServiceAlertData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.AlertsManagement.ServiceAlertResource> ChangeState(Azure.ResourceManager.AlertsManagement.Models.AlertState newState, string comment = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.ServiceAlertResource>> ChangeStateAsync(Azure.ResourceManager.AlertsManagement.Models.AlertState newState, string comment = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string alertId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AlertsManagement.ServiceAlertResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.ServiceAlertResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModification> GetHistory(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModification>> GetHistoryAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SmartGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AlertsManagement.SmartGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertsManagement.SmartGroupResource>, System.Collections.IEnumerable
    {
        protected SmartGroupCollection() { }
        public virtual Azure.Response<bool> Exists(string smartGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string smartGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AlertsManagement.SmartGroupResource> Get(string smartGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AlertsManagement.SmartGroupResource> GetAll(string targetResource = null, string targetResourceGroup = null, string targetResourceType = null, Azure.ResourceManager.AlertsManagement.Models.MonitorService? monitorService = default(Azure.ResourceManager.AlertsManagement.Models.MonitorService?), Azure.ResourceManager.AlertsManagement.Models.MonitorCondition? monitorCondition = default(Azure.ResourceManager.AlertsManagement.Models.MonitorCondition?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity? severity = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity?), Azure.ResourceManager.AlertsManagement.Models.AlertState? smartGroupState = default(Azure.ResourceManager.AlertsManagement.Models.AlertState?), Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter? timeRange = default(Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter?), long? pageCount = default(long?), Azure.ResourceManager.AlertsManagement.Models.SmartGroupsSortByField? sortBy = default(Azure.ResourceManager.AlertsManagement.Models.SmartGroupsSortByField?), Azure.ResourceManager.AlertsManagement.Models.SortOrder? sortOrder = default(Azure.ResourceManager.AlertsManagement.Models.SortOrder?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AlertsManagement.SmartGroupResource> GetAllAsync(string targetResource = null, string targetResourceGroup = null, string targetResourceType = null, Azure.ResourceManager.AlertsManagement.Models.MonitorService? monitorService = default(Azure.ResourceManager.AlertsManagement.Models.MonitorService?), Azure.ResourceManager.AlertsManagement.Models.MonitorCondition? monitorCondition = default(Azure.ResourceManager.AlertsManagement.Models.MonitorCondition?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity? severity = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity?), Azure.ResourceManager.AlertsManagement.Models.AlertState? smartGroupState = default(Azure.ResourceManager.AlertsManagement.Models.AlertState?), Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter? timeRange = default(Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter?), long? pageCount = default(long?), Azure.ResourceManager.AlertsManagement.Models.SmartGroupsSortByField? sortBy = default(Azure.ResourceManager.AlertsManagement.Models.SmartGroupsSortByField?), Azure.ResourceManager.AlertsManagement.Models.SortOrder? sortOrder = default(Azure.ResourceManager.AlertsManagement.Models.SortOrder?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public string LastModifiedBy { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AlertsManagement.Models.SmartGroupAggregatedProperty> MonitorConditions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AlertsManagement.Models.SmartGroupAggregatedProperty> MonitorServices { get { throw null; } }
        public string NextLink { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AlertsManagement.Models.SmartGroupAggregatedProperty> ResourceGroups { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AlertsManagement.Models.SmartGroupAggregatedProperty> Resources { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AlertsManagement.Models.SmartGroupAggregatedProperty> ResourceTypes { get { throw null; } }
        public Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity? Severity { get { throw null; } }
        public Azure.ResourceManager.AlertsManagement.Models.SmartGroupState? SmartGroupState { get { throw null; } }
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
    public partial class AddActionGroups : Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleAction
    {
        public AddActionGroups(System.Collections.Generic.IEnumerable<string> actionGroupIds) { }
        public System.Collections.Generic.IList<string> ActionGroupIds { get { throw null; } }
    }
    public abstract partial class AlertProcessingRuleAction
    {
        protected AlertProcessingRuleAction() { }
    }
    public partial class AlertProcessingRuleCondition
    {
        public AlertProcessingRuleCondition() { }
        public Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleField? Field { get { throw null; } set { } }
        public Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleOperator? Operator { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AlertProcessingRuleField : System.IEquatable<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleField>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AlertProcessingRuleField(string value) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleField AlertContext { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleField AlertRuleId { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleField AlertRuleName { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleField Description { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleField MonitorCondition { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleField MonitorService { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleField Severity { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleField SignalType { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleField TargetResource { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleField TargetResourceGroup { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleField TargetResourceType { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleField other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleField left, Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleField right) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleField (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleField left, Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleField right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AlertProcessingRuleOperator : System.IEquatable<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AlertProcessingRuleOperator(string value) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleOperator Contains { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleOperator DoesNotContain { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleOperator EqualsValue { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleOperator NotEquals { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleOperator left, Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleOperator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleOperator left, Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AlertProcessingRulePatch
    {
        public AlertProcessingRulePatch() { }
        public bool? IsEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public abstract partial class AlertProcessingRuleRecurrence
    {
        protected AlertProcessingRuleRecurrence() { }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
    }
    public partial class AlertProcessingRuleSchedule
    {
        public AlertProcessingRuleSchedule() { }
        public System.DateTimeOffset? EffectiveFrom { get { throw null; } set { } }
        public System.DateTimeOffset? EffectiveUntil { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleRecurrence> Recurrences { get { throw null; } }
        public string TimeZone { get { throw null; } set { } }
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
    public partial class DailyRecurrence : Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleRecurrence
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InformationIdentifier : System.IEquatable<Azure.ResourceManager.AlertsManagement.Models.InformationIdentifier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InformationIdentifier(string value) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.InformationIdentifier MonitorServiceList { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AlertsManagement.Models.InformationIdentifier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AlertsManagement.Models.InformationIdentifier left, Azure.ResourceManager.AlertsManagement.Models.InformationIdentifier right) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertsManagement.Models.InformationIdentifier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AlertsManagement.Models.InformationIdentifier left, Azure.ResourceManager.AlertsManagement.Models.InformationIdentifier right) { throw null; }
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
    public partial class MonitorServiceList : Azure.ResourceManager.AlertsManagement.Models.ServiceAlertsMetaDataProperties
    {
        internal MonitorServiceList() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AlertsManagement.Models.MonitorServiceDetails> Data { get { throw null; } }
    }
    public partial class MonthlyRecurrence : Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleRecurrence
    {
        public MonthlyRecurrence(System.Collections.Generic.IEnumerable<int> daysOfMonth) { }
        public System.Collections.Generic.IList<int> DaysOfMonth { get { throw null; } }
    }
    public partial class RemoveAllActionGroups : Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleAction
    {
        public RemoveAllActionGroups() { }
    }
    public partial class ServiceAlertEssentials
    {
        public ServiceAlertEssentials() { }
        public string AlertRule { get { throw null; } }
        public Azure.ResourceManager.AlertsManagement.Models.AlertState? AlertState { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public bool? IsSuppressed { get { throw null; } set { } }
        public string LastModifiedBy { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public Azure.ResourceManager.AlertsManagement.Models.MonitorCondition? MonitorCondition { get { throw null; } }
        public System.DateTimeOffset? MonitorConditionResolvedOn { get { throw null; } }
        public Azure.ResourceManager.AlertsManagement.Models.MonitorService? MonitorService { get { throw null; } }
        public Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity? Severity { get { throw null; } }
        public Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSignalType? SignalType { get { throw null; } }
        public string SmartGroupId { get { throw null; } }
        public string SmartGroupingReason { get { throw null; } }
        public string SourceCreatedId { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public string TargetResource { get { throw null; } set { } }
        public string TargetResourceGroup { get { throw null; } set { } }
        public string TargetResourceName { get { throw null; } set { } }
        public string TargetResourceType { get { throw null; } set { } }
    }
    public partial class ServiceAlertModification : Azure.ResourceManager.Models.ResourceData
    {
        public ServiceAlertModification() { }
        public string AlertId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModificationItemData> Modifications { get { throw null; } }
    }
    public enum ServiceAlertModificationEvent
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
    public partial class ServiceAlertModificationItemData
    {
        public ServiceAlertModificationItemData() { }
        public string Comments { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModificationEvent? ModificationEvent { get { throw null; } set { } }
        public string ModifiedBy { get { throw null; } set { } }
        public System.DateTimeOffset? ModifiedOn { get { throw null; } set { } }
        public string NewValue { get { throw null; } set { } }
        public string OldValue { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceAlertSeverity : System.IEquatable<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceAlertSeverity(string value) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity Sev0 { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity Sev1 { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity Sev2 { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity Sev3 { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity Sev4 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity left, Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity right) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity left, Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceAlertSignalType : System.IEquatable<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSignalType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceAlertSignalType(string value) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSignalType Log { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSignalType Metric { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSignalType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSignalType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSignalType left, Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSignalType right) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSignalType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSignalType left, Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSignalType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServiceAlertsMetaData
    {
        internal ServiceAlertsMetaData() { }
        public Azure.ResourceManager.AlertsManagement.Models.ServiceAlertsMetaDataProperties Properties { get { throw null; } }
    }
    public abstract partial class ServiceAlertsMetaDataProperties
    {
        protected ServiceAlertsMetaDataProperties() { }
    }
    public partial class ServiceAlertsSummary : Azure.ResourceManager.Models.ResourceData
    {
        public ServiceAlertsSummary() { }
        public string GroupedBy { get { throw null; } set { } }
        public long? SmartGroupsCount { get { throw null; } set { } }
        public long? Total { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertsSummaryGroupItemData> Values { get { throw null; } }
    }
    public partial class ServiceAlertsSummaryGroupItemData
    {
        public ServiceAlertsSummaryGroupItemData() { }
        public long? Count { get { throw null; } set { } }
        public string GroupedBy { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertsSummaryGroupItemData> Values { get { throw null; } }
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
        public System.Collections.Generic.IList<Azure.ResourceManager.AlertsManagement.Models.SmartGroupModificationItemData> Modifications { get { throw null; } }
        public string NextLink { get { throw null; } set { } }
        public string SmartGroupId { get { throw null; } }
    }
    public enum SmartGroupModificationEvent
    {
        SmartGroupCreated = 0,
        StateChange = 1,
        AlertAdded = 2,
        AlertRemoved = 3,
    }
    public partial class SmartGroupModificationItemData
    {
        public SmartGroupModificationItemData() { }
        public string Comments { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.AlertsManagement.Models.SmartGroupModificationEvent? ModificationEvent { get { throw null; } set { } }
        public string ModifiedBy { get { throw null; } set { } }
        public System.DateTimeOffset? ModifiedOn { get { throw null; } set { } }
        public string NewValue { get { throw null; } set { } }
        public string OldValue { get { throw null; } set { } }
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
    public readonly partial struct SmartGroupState : System.IEquatable<Azure.ResourceManager.AlertsManagement.Models.SmartGroupState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SmartGroupState(string value) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.SmartGroupState Acknowledged { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.SmartGroupState Closed { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.SmartGroupState New { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AlertsManagement.Models.SmartGroupState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AlertsManagement.Models.SmartGroupState left, Azure.ResourceManager.AlertsManagement.Models.SmartGroupState right) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertsManagement.Models.SmartGroupState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AlertsManagement.Models.SmartGroupState left, Azure.ResourceManager.AlertsManagement.Models.SmartGroupState right) { throw null; }
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
    public readonly partial struct TimeRangeFilter : System.IEquatable<Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TimeRangeFilter(string value) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter OneD { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter OneH { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter SevenD { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter ThirtyD { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter left, Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter right) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter left, Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WeeklyRecurrence : Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleRecurrence
    {
        public WeeklyRecurrence(System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertsManagement.Models.DaysOfWeek> daysOfWeek) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.AlertsManagement.Models.DaysOfWeek> DaysOfWeek { get { throw null; } }
    }
}
