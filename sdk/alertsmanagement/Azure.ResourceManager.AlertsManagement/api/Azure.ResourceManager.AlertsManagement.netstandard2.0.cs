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
        public virtual Azure.NullableResponse<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleResource> GetIfExists(string alertProcessingRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleResource>> GetIfExistsAsync(string alertProcessingRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AlertProcessingRuleData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleData>
    {
        public AlertProcessingRuleData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.AlertsManagement.AlertProcessingRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.AlertProcessingRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public static Azure.Response<Azure.ResourceManager.AlertsManagement.ServiceAlertResource> GetServiceAlert(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Guid alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.ServiceAlertResource>> GetServiceAlertAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Guid alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertMetadata> GetServiceAlertMetadata(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.AlertsManagement.Models.RetrievedInformationIdentifier identifier, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertMetadata>> GetServiceAlertMetadataAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.AlertsManagement.Models.RetrievedInformationIdentifier identifier, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.ServiceAlertResource GetServiceAlertResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.ServiceAlertCollection GetServiceAlerts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummary> GetServiceAlertSummary(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.AlertsManagement.Models.AlertsSummaryGroupByField groupby, bool? includeSmartGroupsCount = default(bool?), string targetResource = null, string targetResourceType = null, string targetResourceGroup = null, Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert? monitorService = default(Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert?), Azure.ResourceManager.AlertsManagement.Models.MonitorCondition? monitorCondition = default(Azure.ResourceManager.AlertsManagement.Models.MonitorCondition?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity? severity = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState? alertState = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState?), string alertRule = null, Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter? timeRange = default(Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter?), string customTimeRange = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummary> GetServiceAlertSummary(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.AlertsManagement.Models.SubscriptionResourceGetServiceAlertSummaryOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummary>> GetServiceAlertSummaryAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.AlertsManagement.Models.AlertsSummaryGroupByField groupby, bool? includeSmartGroupsCount = default(bool?), string targetResource = null, string targetResourceType = null, string targetResourceGroup = null, Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert? monitorService = default(Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert?), Azure.ResourceManager.AlertsManagement.Models.MonitorCondition? monitorCondition = default(Azure.ResourceManager.AlertsManagement.Models.MonitorCondition?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity? severity = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState? alertState = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState?), string alertRule = null, Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter? timeRange = default(Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter?), string customTimeRange = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummary>> GetServiceAlertSummaryAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.AlertsManagement.Models.SubscriptionResourceGetServiceAlertSummaryOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AlertsManagement.SmartGroupResource> GetSmartGroup(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Guid smartGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.SmartGroupResource>> GetSmartGroupAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Guid smartGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.SmartGroupResource GetSmartGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.SmartGroupCollection GetSmartGroups(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
    }
    public partial class ServiceAlertCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AlertsManagement.ServiceAlertResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertsManagement.ServiceAlertResource>, System.Collections.IEnumerable
    {
        protected ServiceAlertCollection() { }
        public virtual Azure.Response<bool> Exists(System.Guid alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(System.Guid alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AlertsManagement.ServiceAlertResource> Get(System.Guid alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AlertsManagement.ServiceAlertResource> GetAll(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertCollectionGetAllOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AlertsManagement.ServiceAlertResource> GetAll(string targetResource = null, string targetResourceType = null, string targetResourceGroup = null, Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert? monitorService = default(Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert?), Azure.ResourceManager.AlertsManagement.Models.MonitorCondition? monitorCondition = default(Azure.ResourceManager.AlertsManagement.Models.MonitorCondition?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity? severity = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState? alertState = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState?), string alertRule = null, string smartGroupId = null, bool? includeContext = default(bool?), bool? includeEgressConfig = default(bool?), long? pageCount = default(long?), Azure.ResourceManager.AlertsManagement.Models.ListServiceAlertsSortByField? sortBy = default(Azure.ResourceManager.AlertsManagement.Models.ListServiceAlertsSortByField?), Azure.ResourceManager.AlertsManagement.Models.AlertsManagementQuerySortOrder? sortOrder = default(Azure.ResourceManager.AlertsManagement.Models.AlertsManagementQuerySortOrder?), string select = null, Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter? timeRange = default(Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter?), string customTimeRange = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AlertsManagement.ServiceAlertResource> GetAllAsync(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertCollectionGetAllOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AlertsManagement.ServiceAlertResource> GetAllAsync(string targetResource = null, string targetResourceType = null, string targetResourceGroup = null, Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert? monitorService = default(Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert?), Azure.ResourceManager.AlertsManagement.Models.MonitorCondition? monitorCondition = default(Azure.ResourceManager.AlertsManagement.Models.MonitorCondition?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity? severity = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState? alertState = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState?), string alertRule = null, string smartGroupId = null, bool? includeContext = default(bool?), bool? includeEgressConfig = default(bool?), long? pageCount = default(long?), Azure.ResourceManager.AlertsManagement.Models.ListServiceAlertsSortByField? sortBy = default(Azure.ResourceManager.AlertsManagement.Models.ListServiceAlertsSortByField?), Azure.ResourceManager.AlertsManagement.Models.AlertsManagementQuerySortOrder? sortOrder = default(Azure.ResourceManager.AlertsManagement.Models.AlertsManagementQuerySortOrder?), string select = null, Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter? timeRange = default(Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter?), string customTimeRange = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.ServiceAlertResource>> GetAsync(System.Guid alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.AlertsManagement.ServiceAlertResource> GetIfExists(System.Guid alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.AlertsManagement.ServiceAlertResource>> GetIfExistsAsync(System.Guid alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AlertsManagement.ServiceAlertResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AlertsManagement.ServiceAlertResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AlertsManagement.ServiceAlertResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertsManagement.ServiceAlertResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceAlertData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.ServiceAlertData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.ServiceAlertData>
    {
        public ServiceAlertData() { }
        public Azure.ResourceManager.AlertsManagement.Models.ServiceAlertProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.AlertsManagement.ServiceAlertData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.ServiceAlertData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.ServiceAlertData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.ServiceAlertData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.ServiceAlertData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.ServiceAlertData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.ServiceAlertData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServiceAlertResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServiceAlertResource() { }
        public virtual Azure.ResourceManager.AlertsManagement.ServiceAlertData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.AlertsManagement.ServiceAlertResource> ChangeState(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState newState, string comment = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.ServiceAlertResource>> ChangeStateAsync(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState newState, string comment = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, System.Guid alertId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AlertsManagement.ServiceAlertResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.ServiceAlertResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModification> GetHistory(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModification>> GetHistoryAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SmartGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AlertsManagement.SmartGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertsManagement.SmartGroupResource>, System.Collections.IEnumerable
    {
        protected SmartGroupCollection() { }
        public virtual Azure.Response<bool> Exists(System.Guid smartGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(System.Guid smartGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AlertsManagement.SmartGroupResource> Get(System.Guid smartGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AlertsManagement.SmartGroupResource> GetAll(Azure.ResourceManager.AlertsManagement.Models.SmartGroupCollectionGetAllOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AlertsManagement.SmartGroupResource> GetAll(string targetResource = null, string targetResourceGroup = null, string targetResourceType = null, Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert? monitorService = default(Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert?), Azure.ResourceManager.AlertsManagement.Models.MonitorCondition? monitorCondition = default(Azure.ResourceManager.AlertsManagement.Models.MonitorCondition?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity? severity = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState? smartGroupState = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState?), Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter? timeRange = default(Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter?), long? pageCount = default(long?), Azure.ResourceManager.AlertsManagement.Models.SmartGroupsSortByField? sortBy = default(Azure.ResourceManager.AlertsManagement.Models.SmartGroupsSortByField?), Azure.ResourceManager.AlertsManagement.Models.AlertsManagementQuerySortOrder? sortOrder = default(Azure.ResourceManager.AlertsManagement.Models.AlertsManagementQuerySortOrder?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AlertsManagement.SmartGroupResource> GetAllAsync(Azure.ResourceManager.AlertsManagement.Models.SmartGroupCollectionGetAllOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AlertsManagement.SmartGroupResource> GetAllAsync(string targetResource = null, string targetResourceGroup = null, string targetResourceType = null, Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert? monitorService = default(Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert?), Azure.ResourceManager.AlertsManagement.Models.MonitorCondition? monitorCondition = default(Azure.ResourceManager.AlertsManagement.Models.MonitorCondition?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity? severity = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState? smartGroupState = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState?), Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter? timeRange = default(Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter?), long? pageCount = default(long?), Azure.ResourceManager.AlertsManagement.Models.SmartGroupsSortByField? sortBy = default(Azure.ResourceManager.AlertsManagement.Models.SmartGroupsSortByField?), Azure.ResourceManager.AlertsManagement.Models.AlertsManagementQuerySortOrder? sortOrder = default(Azure.ResourceManager.AlertsManagement.Models.AlertsManagementQuerySortOrder?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.SmartGroupResource>> GetAsync(System.Guid smartGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.AlertsManagement.SmartGroupResource> GetIfExists(System.Guid smartGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.AlertsManagement.SmartGroupResource>> GetIfExistsAsync(System.Guid smartGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AlertsManagement.SmartGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AlertsManagement.SmartGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AlertsManagement.SmartGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertsManagement.SmartGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SmartGroupData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.SmartGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.SmartGroupData>
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
        Azure.ResourceManager.AlertsManagement.SmartGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.SmartGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.SmartGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.SmartGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.SmartGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.SmartGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.SmartGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SmartGroupResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SmartGroupResource() { }
        public virtual Azure.ResourceManager.AlertsManagement.SmartGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.AlertsManagement.SmartGroupResource> ChangeState(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState newState, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.SmartGroupResource>> ChangeStateAsync(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState newState, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, System.Guid smartGroupId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AlertsManagement.SmartGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.SmartGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AlertsManagement.Models.SmartGroupModification> GetHistory(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.Models.SmartGroupModification>> GetHistoryAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.AlertsManagement.Mocking
{
    public partial class MockableAlertsManagementArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableAlertsManagementArmClient() { }
        public virtual Azure.ResourceManager.AlertsManagement.AlertProcessingRuleResource GetAlertProcessingRuleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.AlertsManagement.ServiceAlertResource GetServiceAlertResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.AlertsManagement.SmartGroupResource GetSmartGroupResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableAlertsManagementResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableAlertsManagementResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleResource> GetAlertProcessingRule(string alertProcessingRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleResource>> GetAlertProcessingRuleAsync(string alertProcessingRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AlertsManagement.AlertProcessingRuleCollection GetAlertProcessingRules() { throw null; }
    }
    public partial class MockableAlertsManagementSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableAlertsManagementSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleResource> GetAlertProcessingRules(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleResource> GetAlertProcessingRulesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AlertsManagement.ServiceAlertResource> GetServiceAlert(System.Guid alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.ServiceAlertResource>> GetServiceAlertAsync(System.Guid alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AlertsManagement.ServiceAlertCollection GetServiceAlerts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummary> GetServiceAlertSummary(Azure.ResourceManager.AlertsManagement.Models.AlertsSummaryGroupByField groupby, bool? includeSmartGroupsCount = default(bool?), string targetResource = null, string targetResourceType = null, string targetResourceGroup = null, Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert? monitorService = default(Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert?), Azure.ResourceManager.AlertsManagement.Models.MonitorCondition? monitorCondition = default(Azure.ResourceManager.AlertsManagement.Models.MonitorCondition?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity? severity = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState? alertState = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState?), string alertRule = null, Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter? timeRange = default(Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter?), string customTimeRange = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummary> GetServiceAlertSummary(Azure.ResourceManager.AlertsManagement.Models.SubscriptionResourceGetServiceAlertSummaryOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummary>> GetServiceAlertSummaryAsync(Azure.ResourceManager.AlertsManagement.Models.AlertsSummaryGroupByField groupby, bool? includeSmartGroupsCount = default(bool?), string targetResource = null, string targetResourceType = null, string targetResourceGroup = null, Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert? monitorService = default(Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert?), Azure.ResourceManager.AlertsManagement.Models.MonitorCondition? monitorCondition = default(Azure.ResourceManager.AlertsManagement.Models.MonitorCondition?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity? severity = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState? alertState = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState?), string alertRule = null, Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter? timeRange = default(Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter?), string customTimeRange = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummary>> GetServiceAlertSummaryAsync(Azure.ResourceManager.AlertsManagement.Models.SubscriptionResourceGetServiceAlertSummaryOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AlertsManagement.SmartGroupResource> GetSmartGroup(System.Guid smartGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.SmartGroupResource>> GetSmartGroupAsync(System.Guid smartGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AlertsManagement.SmartGroupCollection GetSmartGroups() { throw null; }
    }
    public partial class MockableAlertsManagementTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableAlertsManagementTenantResource() { }
        public virtual Azure.Response<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertMetadata> GetServiceAlertMetadata(Azure.ResourceManager.AlertsManagement.Models.RetrievedInformationIdentifier identifier, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertMetadata>> GetServiceAlertMetadataAsync(Azure.ResourceManager.AlertsManagement.Models.RetrievedInformationIdentifier identifier, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.AlertsManagement.Models
{
    public abstract partial class AlertProcessingRuleAction : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleAction>
    {
        protected AlertProcessingRuleAction() { }
        Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleAction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleAction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AlertProcessingRuleAddGroupsAction : Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleAction, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleAddGroupsAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleAddGroupsAction>
    {
        public AlertProcessingRuleAddGroupsAction(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> actionGroupIds) { }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> ActionGroupIds { get { throw null; } }
        Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleAddGroupsAction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleAddGroupsAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleAddGroupsAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleAddGroupsAction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleAddGroupsAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleAddGroupsAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleAddGroupsAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AlertProcessingRuleCondition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleCondition>
    {
        public AlertProcessingRuleCondition() { }
        public Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleField? Field { get { throw null; } set { } }
        public Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleOperator? Operator { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
        Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class AlertProcessingRuleMonthlyRecurrence : Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleRecurrence, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleMonthlyRecurrence>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleMonthlyRecurrence>
    {
        public AlertProcessingRuleMonthlyRecurrence(System.Collections.Generic.IEnumerable<int> daysOfMonth) { }
        public System.Collections.Generic.IList<int> DaysOfMonth { get { throw null; } }
        Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleMonthlyRecurrence System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleMonthlyRecurrence>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleMonthlyRecurrence>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleMonthlyRecurrence System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleMonthlyRecurrence>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleMonthlyRecurrence>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleMonthlyRecurrence>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class AlertProcessingRulePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRulePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRulePatch>
    {
        public AlertProcessingRulePatch() { }
        public bool? IsEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRulePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRulePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRulePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRulePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRulePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRulePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRulePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AlertProcessingRuleProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleProperties>
    {
        public AlertProcessingRuleProperties(System.Collections.Generic.IEnumerable<string> scopes, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleAction> actions) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleAction> Actions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleCondition> Conditions { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleSchedule Schedule { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Scopes { get { throw null; } }
        Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class AlertProcessingRuleRecurrence : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleRecurrence>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleRecurrence>
    {
        protected AlertProcessingRuleRecurrence() { }
        public System.TimeSpan? EndOn { get { throw null; } set { } }
        public System.TimeSpan? StartOn { get { throw null; } set { } }
        Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleRecurrence System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleRecurrence>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleRecurrence>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleRecurrence System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleRecurrence>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleRecurrence>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleRecurrence>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AlertProcessingRuleRemoveAllGroupsAction : Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleAction, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleRemoveAllGroupsAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleRemoveAllGroupsAction>
    {
        public AlertProcessingRuleRemoveAllGroupsAction() { }
        Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleRemoveAllGroupsAction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleRemoveAllGroupsAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleRemoveAllGroupsAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleRemoveAllGroupsAction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleRemoveAllGroupsAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleRemoveAllGroupsAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleRemoveAllGroupsAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AlertProcessingRuleSchedule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleSchedule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleSchedule>
    {
        public AlertProcessingRuleSchedule() { }
        public System.DateTimeOffset? EffectiveFrom { get { throw null; } set { } }
        public System.DateTimeOffset? EffectiveUntil { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleRecurrence> Recurrences { get { throw null; } }
        public string TimeZone { get { throw null; } set { } }
        Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleSchedule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleSchedule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleSchedule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleSchedule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleSchedule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleSchedule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleSchedule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AlertProcessingRuleWeeklyRecurrence : Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleRecurrence, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleWeeklyRecurrence>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleWeeklyRecurrence>
    {
        public AlertProcessingRuleWeeklyRecurrence(System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertsManagement.Models.AlertsManagementDayOfWeek> daysOfWeek) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.AlertsManagement.Models.AlertsManagementDayOfWeek> DaysOfWeek { get { throw null; } }
        Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleWeeklyRecurrence System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleWeeklyRecurrence>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleWeeklyRecurrence>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleWeeklyRecurrence System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleWeeklyRecurrence>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleWeeklyRecurrence>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleWeeklyRecurrence>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AlertsManagementDayOfWeek : System.IEquatable<Azure.ResourceManager.AlertsManagement.Models.AlertsManagementDayOfWeek>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AlertsManagementDayOfWeek(string value) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.AlertsManagementDayOfWeek Friday { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.AlertsManagementDayOfWeek Monday { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.AlertsManagementDayOfWeek Saturday { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.AlertsManagementDayOfWeek Sunday { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.AlertsManagementDayOfWeek Thursday { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.AlertsManagementDayOfWeek Tuesday { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.AlertsManagementDayOfWeek Wednesday { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AlertsManagement.Models.AlertsManagementDayOfWeek other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AlertsManagement.Models.AlertsManagementDayOfWeek left, Azure.ResourceManager.AlertsManagement.Models.AlertsManagementDayOfWeek right) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertsManagement.Models.AlertsManagementDayOfWeek (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AlertsManagement.Models.AlertsManagementDayOfWeek left, Azure.ResourceManager.AlertsManagement.Models.AlertsManagementDayOfWeek right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AlertsManagementQuerySortOrder : System.IEquatable<Azure.ResourceManager.AlertsManagement.Models.AlertsManagementQuerySortOrder>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AlertsManagementQuerySortOrder(string value) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.AlertsManagementQuerySortOrder Asc { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.AlertsManagementQuerySortOrder Desc { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AlertsManagement.Models.AlertsManagementQuerySortOrder other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AlertsManagement.Models.AlertsManagementQuerySortOrder left, Azure.ResourceManager.AlertsManagement.Models.AlertsManagementQuerySortOrder right) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertsManagement.Models.AlertsManagementQuerySortOrder (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AlertsManagement.Models.AlertsManagementQuerySortOrder left, Azure.ResourceManager.AlertsManagement.Models.AlertsManagementQuerySortOrder right) { throw null; }
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
    public static partial class ArmAlertsManagementModelFactory
    {
        public static Azure.ResourceManager.AlertsManagement.AlertProcessingRuleData AlertProcessingRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleProperties properties = null) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.MonitorServiceDetails MonitorServiceDetails(string name = null, string displayName = null) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.MonitorServiceList MonitorServiceList(System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertsManagement.Models.MonitorServiceDetails> data = null) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.ServiceAlertData ServiceAlertData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.AlertsManagement.Models.ServiceAlertProperties properties = null) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.ServiceAlertEssentials ServiceAlertEssentials(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity? severity = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSignalType? signalType = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSignalType?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState? alertState = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState?), Azure.ResourceManager.AlertsManagement.Models.MonitorCondition? monitorCondition = default(Azure.ResourceManager.AlertsManagement.Models.MonitorCondition?), string targetResource = null, string targetResourceName = null, string targetResourceGroup = null, string targetResourceType = null, Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert? monitorService = default(Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert?), string alertRule = null, string sourceCreatedId = null, System.Guid? smartGroupId = default(System.Guid?), string smartGroupingReason = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), System.DateTimeOffset? monitorConditionResolvedOn = default(System.DateTimeOffset?), string lastModifiedBy = null, bool? isSuppressed = default(bool?), string description = null) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.ServiceAlertMetadata ServiceAlertMetadata(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertMetadataProperties properties = null) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModification ServiceAlertModification(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModificationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModificationProperties ServiceAlertModificationProperties(System.Guid? alertId = default(System.Guid?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModificationItemInfo> modifications = null) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.ServiceAlertProperties ServiceAlertProperties(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertEssentials essentials = null, System.BinaryData context = null, System.BinaryData egressConfig = null) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummary ServiceAlertSummary(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummaryGroup properties = null) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.SmartGroupData SmartGroupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, long? alertsCount = default(long?), Azure.ResourceManager.AlertsManagement.Models.SmartGroupState? smartGroupState = default(Azure.ResourceManager.AlertsManagement.Models.SmartGroupState?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity? severity = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), string lastModifiedBy = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertsManagement.Models.SmartGroupAggregatedProperty> resources = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertsManagement.Models.SmartGroupAggregatedProperty> resourceTypes = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertsManagement.Models.SmartGroupAggregatedProperty> resourceGroups = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertsManagement.Models.SmartGroupAggregatedProperty> monitorServices = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertsManagement.Models.SmartGroupAggregatedProperty> monitorConditions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertsManagement.Models.SmartGroupAggregatedProperty> alertStates = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertsManagement.Models.SmartGroupAggregatedProperty> alertSeverities = null, string nextLink = null) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.SmartGroupModification SmartGroupModification(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.AlertsManagement.Models.SmartGroupModificationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.SmartGroupModificationProperties SmartGroupModificationProperties(System.Guid? smartGroupId = default(System.Guid?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertsManagement.Models.SmartGroupModificationItemInfo> modifications = null, string nextLink = null) { throw null; }
    }
    public partial class DailyRecurrence : Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleRecurrence, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.DailyRecurrence>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.DailyRecurrence>
    {
        public DailyRecurrence() { }
        Azure.ResourceManager.AlertsManagement.Models.DailyRecurrence System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.DailyRecurrence>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.DailyRecurrence>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.DailyRecurrence System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.DailyRecurrence>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.DailyRecurrence>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.DailyRecurrence>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ListServiceAlertsSortByField : System.IEquatable<Azure.ResourceManager.AlertsManagement.Models.ListServiceAlertsSortByField>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ListServiceAlertsSortByField(string value) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.ListServiceAlertsSortByField AlertState { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.ListServiceAlertsSortByField LastModifiedOn { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.ListServiceAlertsSortByField MonitorCondition { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.ListServiceAlertsSortByField Name { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.ListServiceAlertsSortByField Severity { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.ListServiceAlertsSortByField StartOn { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.ListServiceAlertsSortByField TargetResource { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.ListServiceAlertsSortByField TargetResourceGroup { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.ListServiceAlertsSortByField TargetResourceName { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.ListServiceAlertsSortByField TargetResourceType { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AlertsManagement.Models.ListServiceAlertsSortByField other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AlertsManagement.Models.ListServiceAlertsSortByField left, Azure.ResourceManager.AlertsManagement.Models.ListServiceAlertsSortByField right) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertsManagement.Models.ListServiceAlertsSortByField (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AlertsManagement.Models.ListServiceAlertsSortByField left, Azure.ResourceManager.AlertsManagement.Models.ListServiceAlertsSortByField right) { throw null; }
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
    public partial class MonitorServiceDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.MonitorServiceDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.MonitorServiceDetails>
    {
        internal MonitorServiceDetails() { }
        public string DisplayName { get { throw null; } }
        public string Name { get { throw null; } }
        Azure.ResourceManager.AlertsManagement.Models.MonitorServiceDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.MonitorServiceDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.MonitorServiceDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.MonitorServiceDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.MonitorServiceDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.MonitorServiceDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.MonitorServiceDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MonitorServiceList : Azure.ResourceManager.AlertsManagement.Models.ServiceAlertMetadataProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.MonitorServiceList>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.MonitorServiceList>
    {
        internal MonitorServiceList() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AlertsManagement.Models.MonitorServiceDetails> Data { get { throw null; } }
        Azure.ResourceManager.AlertsManagement.Models.MonitorServiceList System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.MonitorServiceList>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.MonitorServiceList>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.MonitorServiceList System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.MonitorServiceList>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.MonitorServiceList>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.MonitorServiceList>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MonitorServiceSourceForAlert : System.IEquatable<Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MonitorServiceSourceForAlert(string value) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert ActivityLogAdministrative { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert ActivityLogAutoscale { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert ActivityLogPolicy { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert ActivityLogRecommendation { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert ActivityLogSecurity { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert ApplicationInsights { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert LogAnalytics { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert Nagios { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert Platform { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert Scom { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert ServiceHealth { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert SmartDetector { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert VmInsights { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert Zabbix { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert left, Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert right) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert left, Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RetrievedInformationIdentifier : System.IEquatable<Azure.ResourceManager.AlertsManagement.Models.RetrievedInformationIdentifier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RetrievedInformationIdentifier(string value) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.RetrievedInformationIdentifier MonitorServiceList { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AlertsManagement.Models.RetrievedInformationIdentifier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AlertsManagement.Models.RetrievedInformationIdentifier left, Azure.ResourceManager.AlertsManagement.Models.RetrievedInformationIdentifier right) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertsManagement.Models.RetrievedInformationIdentifier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AlertsManagement.Models.RetrievedInformationIdentifier left, Azure.ResourceManager.AlertsManagement.Models.RetrievedInformationIdentifier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServiceAlertCollectionGetAllOptions
    {
        public ServiceAlertCollectionGetAllOptions() { }
        public string AlertRule { get { throw null; } set { } }
        public Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState? AlertState { get { throw null; } set { } }
        public string CustomTimeRange { get { throw null; } set { } }
        public bool? IncludeContext { get { throw null; } set { } }
        public bool? IncludeEgressConfig { get { throw null; } set { } }
        public Azure.ResourceManager.AlertsManagement.Models.MonitorCondition? MonitorCondition { get { throw null; } set { } }
        public Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert? MonitorService { get { throw null; } set { } }
        public long? PageCount { get { throw null; } set { } }
        public string Select { get { throw null; } set { } }
        public Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity? Severity { get { throw null; } set { } }
        public string SmartGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.AlertsManagement.Models.ListServiceAlertsSortByField? SortBy { get { throw null; } set { } }
        public Azure.ResourceManager.AlertsManagement.Models.AlertsManagementQuerySortOrder? SortOrder { get { throw null; } set { } }
        public string TargetResource { get { throw null; } set { } }
        public string TargetResourceGroup { get { throw null; } set { } }
        public string TargetResourceType { get { throw null; } set { } }
        public Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter? TimeRange { get { throw null; } set { } }
    }
    public partial class ServiceAlertEssentials : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertEssentials>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertEssentials>
    {
        public ServiceAlertEssentials() { }
        public string AlertRule { get { throw null; } }
        public Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState? AlertState { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public bool? IsSuppressed { get { throw null; } set { } }
        public string LastModifiedBy { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public Azure.ResourceManager.AlertsManagement.Models.MonitorCondition? MonitorCondition { get { throw null; } }
        public System.DateTimeOffset? MonitorConditionResolvedOn { get { throw null; } }
        public Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert? MonitorService { get { throw null; } }
        public Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity? Severity { get { throw null; } }
        public Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSignalType? SignalType { get { throw null; } }
        public System.Guid? SmartGroupId { get { throw null; } }
        public string SmartGroupingReason { get { throw null; } }
        public string SourceCreatedId { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string TargetResource { get { throw null; } set { } }
        public string TargetResourceGroup { get { throw null; } set { } }
        public string TargetResourceName { get { throw null; } set { } }
        public string TargetResourceType { get { throw null; } set { } }
        Azure.ResourceManager.AlertsManagement.Models.ServiceAlertEssentials System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertEssentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertEssentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.ServiceAlertEssentials System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertEssentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertEssentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertEssentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServiceAlertMetadata : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertMetadata>
    {
        internal ServiceAlertMetadata() { }
        public Azure.ResourceManager.AlertsManagement.Models.ServiceAlertMetadataProperties Properties { get { throw null; } }
        Azure.ResourceManager.AlertsManagement.Models.ServiceAlertMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.ServiceAlertMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ServiceAlertMetadataProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertMetadataProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertMetadataProperties>
    {
        protected ServiceAlertMetadataProperties() { }
        Azure.ResourceManager.AlertsManagement.Models.ServiceAlertMetadataProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertMetadataProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertMetadataProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.ServiceAlertMetadataProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertMetadataProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertMetadataProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertMetadataProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServiceAlertModification : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModification>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModification>
    {
        public ServiceAlertModification() { }
        public Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModificationProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModification System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModification>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModification>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModification System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModification>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModification>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModification>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ServiceAlertModificationItemInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModificationItemInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModificationItemInfo>
    {
        public ServiceAlertModificationItemInfo() { }
        public string Comments { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModificationEvent? ModificationEvent { get { throw null; } set { } }
        public string ModifiedAt { get { throw null; } set { } }
        public string ModifiedBy { get { throw null; } set { } }
        public string NewValue { get { throw null; } set { } }
        public string OldValue { get { throw null; } set { } }
        Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModificationItemInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModificationItemInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModificationItemInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModificationItemInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModificationItemInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModificationItemInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModificationItemInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServiceAlertModificationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModificationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModificationProperties>
    {
        public ServiceAlertModificationProperties() { }
        public System.Guid? AlertId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModificationItemInfo> Modifications { get { throw null; } }
        Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModificationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModificationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModificationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModificationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModificationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModificationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModificationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServiceAlertProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertProperties>
    {
        public ServiceAlertProperties() { }
        public System.BinaryData Context { get { throw null; } }
        public System.BinaryData EgressConfig { get { throw null; } }
        public Azure.ResourceManager.AlertsManagement.Models.ServiceAlertEssentials Essentials { get { throw null; } set { } }
        Azure.ResourceManager.AlertsManagement.Models.ServiceAlertProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.ServiceAlertProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceAlertState : System.IEquatable<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceAlertState(string value) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState Acknowledged { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState Closed { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState New { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState left, Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState right) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState left, Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServiceAlertSummary : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummary>
    {
        public ServiceAlertSummary() { }
        public Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummaryGroup Properties { get { throw null; } set { } }
        Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServiceAlertSummaryGroup : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummaryGroup>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummaryGroup>
    {
        public ServiceAlertSummaryGroup() { }
        public string GroupedBy { get { throw null; } set { } }
        public long? SmartGroupsCount { get { throw null; } set { } }
        public long? Total { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummaryGroupItemInfo> Values { get { throw null; } }
        Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummaryGroup System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummaryGroup>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummaryGroup>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummaryGroup System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummaryGroup>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummaryGroup>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummaryGroup>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServiceAlertSummaryGroupItemInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummaryGroupItemInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummaryGroupItemInfo>
    {
        public ServiceAlertSummaryGroupItemInfo() { }
        public long? Count { get { throw null; } set { } }
        public string GroupedBy { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummaryGroupItemInfo> Values { get { throw null; } }
        Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummaryGroupItemInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummaryGroupItemInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummaryGroupItemInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummaryGroupItemInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummaryGroupItemInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummaryGroupItemInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummaryGroupItemInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SmartGroupAggregatedProperty : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.SmartGroupAggregatedProperty>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.SmartGroupAggregatedProperty>
    {
        public SmartGroupAggregatedProperty() { }
        public long? Count { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        Azure.ResourceManager.AlertsManagement.Models.SmartGroupAggregatedProperty System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.SmartGroupAggregatedProperty>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.SmartGroupAggregatedProperty>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.SmartGroupAggregatedProperty System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.SmartGroupAggregatedProperty>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.SmartGroupAggregatedProperty>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.SmartGroupAggregatedProperty>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SmartGroupCollectionGetAllOptions
    {
        public SmartGroupCollectionGetAllOptions() { }
        public Azure.ResourceManager.AlertsManagement.Models.MonitorCondition? MonitorCondition { get { throw null; } set { } }
        public Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert? MonitorService { get { throw null; } set { } }
        public long? PageCount { get { throw null; } set { } }
        public Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity? Severity { get { throw null; } set { } }
        public Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState? SmartGroupState { get { throw null; } set { } }
        public Azure.ResourceManager.AlertsManagement.Models.SmartGroupsSortByField? SortBy { get { throw null; } set { } }
        public Azure.ResourceManager.AlertsManagement.Models.AlertsManagementQuerySortOrder? SortOrder { get { throw null; } set { } }
        public string TargetResource { get { throw null; } set { } }
        public string TargetResourceGroup { get { throw null; } set { } }
        public string TargetResourceType { get { throw null; } set { } }
        public Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter? TimeRange { get { throw null; } set { } }
    }
    public partial class SmartGroupModification : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.SmartGroupModification>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.SmartGroupModification>
    {
        public SmartGroupModification() { }
        public Azure.ResourceManager.AlertsManagement.Models.SmartGroupModificationProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.AlertsManagement.Models.SmartGroupModification System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.SmartGroupModification>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.SmartGroupModification>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.SmartGroupModification System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.SmartGroupModification>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.SmartGroupModification>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.SmartGroupModification>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum SmartGroupModificationEvent
    {
        SmartGroupCreated = 0,
        StateChange = 1,
        AlertAdded = 2,
        AlertRemoved = 3,
    }
    public partial class SmartGroupModificationItemInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.SmartGroupModificationItemInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.SmartGroupModificationItemInfo>
    {
        public SmartGroupModificationItemInfo() { }
        public string Comments { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.AlertsManagement.Models.SmartGroupModificationEvent? ModificationEvent { get { throw null; } set { } }
        public string ModifiedBy { get { throw null; } set { } }
        public System.DateTimeOffset? ModifiedOn { get { throw null; } set { } }
        public string NewValue { get { throw null; } set { } }
        public string OldValue { get { throw null; } set { } }
        Azure.ResourceManager.AlertsManagement.Models.SmartGroupModificationItemInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.SmartGroupModificationItemInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.SmartGroupModificationItemInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.SmartGroupModificationItemInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.SmartGroupModificationItemInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.SmartGroupModificationItemInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.SmartGroupModificationItemInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SmartGroupModificationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.SmartGroupModificationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.SmartGroupModificationProperties>
    {
        public SmartGroupModificationProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.AlertsManagement.Models.SmartGroupModificationItemInfo> Modifications { get { throw null; } }
        public string NextLink { get { throw null; } set { } }
        public System.Guid? SmartGroupId { get { throw null; } }
        Azure.ResourceManager.AlertsManagement.Models.SmartGroupModificationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.SmartGroupModificationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.SmartGroupModificationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.SmartGroupModificationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.SmartGroupModificationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.SmartGroupModificationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.SmartGroupModificationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class SubscriptionResourceGetServiceAlertSummaryOptions
    {
        public SubscriptionResourceGetServiceAlertSummaryOptions(Azure.ResourceManager.AlertsManagement.Models.AlertsSummaryGroupByField groupby) { }
        public string AlertRule { get { throw null; } set { } }
        public Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState? AlertState { get { throw null; } set { } }
        public string CustomTimeRange { get { throw null; } set { } }
        public Azure.ResourceManager.AlertsManagement.Models.AlertsSummaryGroupByField Groupby { get { throw null; } }
        public bool? IncludeSmartGroupsCount { get { throw null; } set { } }
        public Azure.ResourceManager.AlertsManagement.Models.MonitorCondition? MonitorCondition { get { throw null; } set { } }
        public Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert? MonitorService { get { throw null; } set { } }
        public Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity? Severity { get { throw null; } set { } }
        public string TargetResource { get { throw null; } set { } }
        public string TargetResourceGroup { get { throw null; } set { } }
        public string TargetResourceType { get { throw null; } set { } }
        public Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter? TimeRange { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TimeRangeFilter : System.IEquatable<Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TimeRangeFilter(string value) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter OneDay { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter OneHour { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter SevenDays { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter ThirtyDays { get { throw null; } }
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
}
