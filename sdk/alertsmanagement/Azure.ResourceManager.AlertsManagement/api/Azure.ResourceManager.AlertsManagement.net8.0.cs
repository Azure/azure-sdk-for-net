namespace Azure.ResourceManager.AlertsManagement
{
    [System.ObsoleteAttribute("This type is no longer supported.", true)]
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
    [System.ObsoleteAttribute("This type is no longer supported.", true)]
    public partial class AlertProcessingRuleData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleData>
    {
        public AlertProcessingRuleData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.AlertProcessingRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.AlertProcessingRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.ObsoleteAttribute("This type is no longer supported.", true)]
    public partial class AlertProcessingRuleResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleData>
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
        Azure.ResourceManager.AlertsManagement.AlertProcessingRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.AlertProcessingRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleResource> Update(Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleResource>> UpdateAsync(Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AlertResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.ServiceAlertData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.ServiceAlertData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AlertResource() { }
        public virtual Azure.ResourceManager.AlertsManagement.ServiceAlertData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.AlertsManagement.AlertResource> ChangeState(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState newState, Azure.ResourceManager.AlertsManagement.Models.AlertComments comment = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.AlertResource>> ChangeStateAsync(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState newState, Azure.ResourceManager.AlertsManagement.Models.AlertComments comment = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string alertId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AlertsManagement.AlertResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.AlertResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AlertsManagement.Models.AlertEnrichmentResult> GetEnrichments(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AlertsManagement.Models.AlertEnrichmentResult> GetEnrichmentsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModification> GetHistory(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModification>> GetHistoryAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.AlertsManagement.ServiceAlertData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.ServiceAlertData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.ServiceAlertData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.ServiceAlertData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.ServiceAlertData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.ServiceAlertData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.ServiceAlertData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class AlertsManagementExtensions
    {
        public static Azure.Response<Azure.ResourceManager.AlertsManagement.AlertResource> GetAlert(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AlertsManagement.AlertResource> GetAlert(this Azure.ResourceManager.Resources.TenantResource tenantResource, string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.AlertResource>> GetAlertAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.AlertResource>> GetAlertAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("This method is no longer supported.", true)]
        public static Azure.Response<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleResource> GetAlertProcessingRule(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string alertProcessingRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("This method is no longer supported.", true)]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleResource>> GetAlertProcessingRuleAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string alertProcessingRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("This method is no longer supported.", true)]
        public static Azure.ResourceManager.AlertsManagement.AlertProcessingRuleResource GetAlertProcessingRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        [System.ObsoleteAttribute("This method is no longer supported.", true)]
        public static Azure.ResourceManager.AlertsManagement.AlertProcessingRuleCollection GetAlertProcessingRules(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        [System.ObsoleteAttribute("This method is no longer supported.", true)]
        public static Azure.Pageable<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleResource> GetAlertProcessingRules(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("This method is no longer supported.", true)]
        public static Azure.AsyncPageable<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleResource> GetAlertProcessingRulesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.AlertResource GetAlertResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.ServiceAlertCollection GetAlerts(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.ServiceAlertCollection GetAlerts(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        [System.ObsoleteAttribute("This method is no longer supported.", true)]
        public static Azure.Response<Azure.ResourceManager.AlertsManagement.ServiceAlertResource> GetServiceAlert(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Guid alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("This method is no longer supported.", true)]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.ServiceAlertResource>> GetServiceAlertAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Guid alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertMetadata> GetServiceAlertMetadata(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.AlertsManagement.Models.RetrievedInformationIdentifier identifier, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertMetadata>> GetServiceAlertMetadataAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.AlertsManagement.Models.RetrievedInformationIdentifier identifier, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("This method is no longer supported.", true)]
        public static Azure.ResourceManager.AlertsManagement.ServiceAlertResource GetServiceAlertResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.ServiceAlertCollection GetServiceAlerts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummary> GetServiceAlertSummary(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.AlertsManagement.Models.AlertsSummaryGroupByField groupby, bool? includeSmartGroupsCount = default(bool?), string targetResource = null, string targetResourceType = null, string targetResourceGroup = null, Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert? monitorService = default(Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert?), Azure.ResourceManager.AlertsManagement.Models.MonitorCondition? monitorCondition = default(Azure.ResourceManager.AlertsManagement.Models.MonitorCondition?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity? severity = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState? alertState = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState?), string alertRule = null, Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter? timeRange = default(Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter?), string customTimeRange = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummary> GetServiceAlertSummary(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.AlertsManagement.Models.SubscriptionResourceGetServiceAlertSummaryOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummary>> GetServiceAlertSummaryAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.AlertsManagement.Models.AlertsSummaryGroupByField groupby, bool? includeSmartGroupsCount = default(bool?), string targetResource = null, string targetResourceType = null, string targetResourceGroup = null, Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert? monitorService = default(Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert?), Azure.ResourceManager.AlertsManagement.Models.MonitorCondition? monitorCondition = default(Azure.ResourceManager.AlertsManagement.Models.MonitorCondition?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity? severity = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState? alertState = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState?), string alertRule = null, Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter? timeRange = default(Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter?), string customTimeRange = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummary>> GetServiceAlertSummaryAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.AlertsManagement.Models.SubscriptionResourceGetServiceAlertSummaryOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("This method is no longer supported.", true)]
        public static Azure.Response<Azure.ResourceManager.AlertsManagement.SmartGroupResource> GetSmartGroup(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Guid smartGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("This method is no longer supported.", true)]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.SmartGroupResource>> GetSmartGroupAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Guid smartGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("This method is no longer supported.", true)]
        public static Azure.ResourceManager.AlertsManagement.SmartGroupResource GetSmartGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        [System.ObsoleteAttribute("This method is no longer supported.", true)]
        public static Azure.ResourceManager.AlertsManagement.SmartGroupCollection GetSmartGroups(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummary> GetSummary(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.AlertsManagement.Models.AlertsSummaryGroupByField groupby, bool? includeSmartGroupsCount = default(bool?), string targetResource = null, string targetResourceType = null, string targetResourceGroup = null, Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert? monitorService = default(Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert?), Azure.ResourceManager.AlertsManagement.Models.MonitorCondition? monitorCondition = default(Azure.ResourceManager.AlertsManagement.Models.MonitorCondition?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity? severity = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState? alertState = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState?), string alertRule = null, Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter? timeRange = default(Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter?), string customTimeRange = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummary>> GetSummaryAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.AlertsManagement.Models.AlertsSummaryGroupByField groupby, bool? includeSmartGroupsCount = default(bool?), string targetResource = null, string targetResourceType = null, string targetResourceGroup = null, Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert? monitorService = default(Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert?), Azure.ResourceManager.AlertsManagement.Models.MonitorCondition? monitorCondition = default(Azure.ResourceManager.AlertsManagement.Models.MonitorCondition?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity? severity = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState? alertState = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState?), string alertRule = null, Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter? timeRange = default(Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter?), string customTimeRange = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertMetadata> MetaData(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.AlertsManagement.Models.RetrievedInformationIdentifier identifier, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertMetadata>> MetaDataAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.AlertsManagement.Models.RetrievedInformationIdentifier identifier, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AzureResourceManagerAlertsManagementContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerAlertsManagementContext() { }
        public static Azure.ResourceManager.AlertsManagement.AzureResourceManagerAlertsManagementContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class ServiceAlertCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AlertsManagement.AlertResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertsManagement.AlertResource>, System.Collections.IEnumerable
    {
        protected ServiceAlertCollection() { }
        public virtual Azure.Response<bool> Exists(System.Guid alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(System.Guid alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("This method is no longer supported.", true)]
        public virtual Azure.Response<Azure.ResourceManager.AlertsManagement.ServiceAlertResource> Get(System.Guid alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AlertsManagement.AlertResource> Get(string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AlertsManagement.AlertResource> GetAll(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertCollectionGetAllOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AlertsManagement.AlertResource> GetAll(string targetResource = null, string targetResourceType = null, string targetResourceGroup = null, Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert? monitorService = default(Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert?), Azure.ResourceManager.AlertsManagement.Models.MonitorCondition? monitorCondition = default(Azure.ResourceManager.AlertsManagement.Models.MonitorCondition?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity? severity = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState? alertState = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState?), string alertRule = null, string smartGroupId = null, bool? includeContext = default(bool?), bool? includeEgressConfig = default(bool?), long? pageCount = default(long?), Azure.ResourceManager.AlertsManagement.Models.ListServiceAlertsSortByField? sortBy = default(Azure.ResourceManager.AlertsManagement.Models.ListServiceAlertsSortByField?), Azure.ResourceManager.AlertsManagement.Models.AlertsManagementQuerySortOrder? sortOrder = default(Azure.ResourceManager.AlertsManagement.Models.AlertsManagementQuerySortOrder?), string select = null, Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter? timeRange = default(Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter?), string customTimeRange = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AlertsManagement.AlertResource> GetAllAsync(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertCollectionGetAllOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AlertsManagement.AlertResource> GetAllAsync(string targetResource = null, string targetResourceType = null, string targetResourceGroup = null, Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert? monitorService = default(Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert?), Azure.ResourceManager.AlertsManagement.Models.MonitorCondition? monitorCondition = default(Azure.ResourceManager.AlertsManagement.Models.MonitorCondition?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity? severity = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState? alertState = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState?), string alertRule = null, string smartGroupId = null, bool? includeContext = default(bool?), bool? includeEgressConfig = default(bool?), long? pageCount = default(long?), Azure.ResourceManager.AlertsManagement.Models.ListServiceAlertsSortByField? sortBy = default(Azure.ResourceManager.AlertsManagement.Models.ListServiceAlertsSortByField?), Azure.ResourceManager.AlertsManagement.Models.AlertsManagementQuerySortOrder? sortOrder = default(Azure.ResourceManager.AlertsManagement.Models.AlertsManagementQuerySortOrder?), string select = null, Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter? timeRange = default(Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter?), string customTimeRange = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("This method is no longer supported.", true)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.ServiceAlertResource>> GetAsync(System.Guid alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.AlertResource>> GetAsync(string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("This method is no longer supported.", true)]
        public virtual Azure.NullableResponse<Azure.ResourceManager.AlertsManagement.ServiceAlertResource> GetIfExists(System.Guid alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.AlertsManagement.AlertResource> GetIfExists(string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("This method is no longer supported.", true)]
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.AlertsManagement.ServiceAlertResource>> GetIfExistsAsync(System.Guid alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.AlertsManagement.AlertResource>> GetIfExistsAsync(string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AlertsManagement.AlertResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AlertsManagement.AlertResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AlertsManagement.AlertResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertsManagement.AlertResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceAlertData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.ServiceAlertData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.ServiceAlertData>
    {
        public ServiceAlertData() { }
        public Azure.ResourceManager.AlertsManagement.Models.ServiceAlertProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AlertsManagement.ServiceAlertData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.ServiceAlertData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.ServiceAlertData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.ServiceAlertData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.ServiceAlertData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.ServiceAlertData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.ServiceAlertData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.ObsoleteAttribute("This type is no longer supported.", true)]
    public partial class ServiceAlertResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.ServiceAlertData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.ServiceAlertData>
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
        Azure.ResourceManager.AlertsManagement.ServiceAlertData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.ServiceAlertData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.ServiceAlertData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.ServiceAlertData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.ServiceAlertData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.ServiceAlertData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.ServiceAlertData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.ObsoleteAttribute("This type is no longer supported.", true)]
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
    [System.ObsoleteAttribute("This type is no longer supported.", true)]
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.SmartGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.SmartGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.SmartGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.SmartGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.SmartGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.SmartGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.SmartGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.ObsoleteAttribute("This type is no longer supported.", true)]
    public partial class SmartGroupResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.SmartGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.SmartGroupData>
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
        Azure.ResourceManager.AlertsManagement.SmartGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.SmartGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.SmartGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.SmartGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.SmartGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.SmartGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.SmartGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.AlertsManagement.Mocking
{
    public partial class MockableAlertsManagementArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableAlertsManagementArmClient() { }
        public virtual Azure.Response<Azure.ResourceManager.AlertsManagement.AlertResource> GetAlert(Azure.Core.ResourceIdentifier scope, string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.AlertResource>> GetAlertAsync(Azure.Core.ResourceIdentifier scope, string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("This method is no longer supported.", true)]
        public virtual Azure.ResourceManager.AlertsManagement.AlertProcessingRuleResource GetAlertProcessingRuleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.AlertsManagement.AlertResource GetAlertResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.AlertsManagement.ServiceAlertCollection GetAlerts(Azure.Core.ResourceIdentifier scope) { throw null; }
        [System.ObsoleteAttribute("This method is no longer supported.", true)]
        public virtual Azure.ResourceManager.AlertsManagement.ServiceAlertResource GetServiceAlertResource(Azure.Core.ResourceIdentifier id) { throw null; }
        [System.ObsoleteAttribute("This method is no longer supported.", true)]
        public virtual Azure.ResourceManager.AlertsManagement.SmartGroupResource GetSmartGroupResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummary> GetSummary(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.AlertsManagement.Models.AlertsSummaryGroupByField groupby, bool? includeSmartGroupsCount = default(bool?), string targetResource = null, string targetResourceType = null, string targetResourceGroup = null, Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert? monitorService = default(Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert?), Azure.ResourceManager.AlertsManagement.Models.MonitorCondition? monitorCondition = default(Azure.ResourceManager.AlertsManagement.Models.MonitorCondition?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity? severity = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState? alertState = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState?), string alertRule = null, Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter? timeRange = default(Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter?), string customTimeRange = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummary>> GetSummaryAsync(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.AlertsManagement.Models.AlertsSummaryGroupByField groupby, bool? includeSmartGroupsCount = default(bool?), string targetResource = null, string targetResourceType = null, string targetResourceGroup = null, Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert? monitorService = default(Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert?), Azure.ResourceManager.AlertsManagement.Models.MonitorCondition? monitorCondition = default(Azure.ResourceManager.AlertsManagement.Models.MonitorCondition?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity? severity = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState? alertState = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState?), string alertRule = null, Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter? timeRange = default(Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter?), string customTimeRange = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.ObsoleteAttribute("This type is no longer supported.", true)]
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
        [System.ObsoleteAttribute("This method is no longer supported.", true)]
        public virtual Azure.Pageable<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleResource> GetAlertProcessingRules(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("This method is no longer supported.", true)]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AlertsManagement.AlertProcessingRuleResource> GetAlertProcessingRulesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("This method is no longer supported.", true)]
        public virtual Azure.Response<Azure.ResourceManager.AlertsManagement.ServiceAlertResource> GetServiceAlert(System.Guid alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("This method is no longer supported.", true)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.ServiceAlertResource>> GetServiceAlertAsync(System.Guid alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AlertsManagement.ServiceAlertCollection GetServiceAlerts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummary> GetServiceAlertSummary(Azure.ResourceManager.AlertsManagement.Models.AlertsSummaryGroupByField groupby, bool? includeSmartGroupsCount = default(bool?), string targetResource = null, string targetResourceType = null, string targetResourceGroup = null, Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert? monitorService = default(Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert?), Azure.ResourceManager.AlertsManagement.Models.MonitorCondition? monitorCondition = default(Azure.ResourceManager.AlertsManagement.Models.MonitorCondition?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity? severity = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState? alertState = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState?), string alertRule = null, Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter? timeRange = default(Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter?), string customTimeRange = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummary> GetServiceAlertSummary(Azure.ResourceManager.AlertsManagement.Models.SubscriptionResourceGetServiceAlertSummaryOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummary>> GetServiceAlertSummaryAsync(Azure.ResourceManager.AlertsManagement.Models.AlertsSummaryGroupByField groupby, bool? includeSmartGroupsCount = default(bool?), string targetResource = null, string targetResourceType = null, string targetResourceGroup = null, Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert? monitorService = default(Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert?), Azure.ResourceManager.AlertsManagement.Models.MonitorCondition? monitorCondition = default(Azure.ResourceManager.AlertsManagement.Models.MonitorCondition?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity? severity = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState? alertState = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState?), string alertRule = null, Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter? timeRange = default(Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter?), string customTimeRange = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummary>> GetServiceAlertSummaryAsync(Azure.ResourceManager.AlertsManagement.Models.SubscriptionResourceGetServiceAlertSummaryOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("This method is no longer supported.", true)]
        public virtual Azure.Response<Azure.ResourceManager.AlertsManagement.SmartGroupResource> GetSmartGroup(System.Guid smartGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("This method is no longer supported.", true)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.SmartGroupResource>> GetSmartGroupAsync(System.Guid smartGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("This method is no longer supported.", true)]
        public virtual Azure.ResourceManager.AlertsManagement.SmartGroupCollection GetSmartGroups() { throw null; }
    }
    public partial class MockableAlertsManagementTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableAlertsManagementTenantResource() { }
        public virtual Azure.Response<Azure.ResourceManager.AlertsManagement.AlertResource> GetAlert(string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.AlertResource>> GetAlertAsync(string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AlertsManagement.ServiceAlertCollection GetAlerts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertMetadata> GetServiceAlertMetadata(Azure.ResourceManager.AlertsManagement.Models.RetrievedInformationIdentifier identifier, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertMetadata>> GetServiceAlertMetadataAsync(Azure.ResourceManager.AlertsManagement.Models.RetrievedInformationIdentifier identifier, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertMetadata> MetaData(Azure.ResourceManager.AlertsManagement.Models.RetrievedInformationIdentifier identifier, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertMetadata>> MetaDataAsync(Azure.ResourceManager.AlertsManagement.Models.RetrievedInformationIdentifier identifier, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.AlertsManagement.Models
{
    public partial class ActionSuppressedDetails : Azure.ResourceManager.AlertsManagement.Models.BaseDetails, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.ActionSuppressedDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.ActionSuppressedDetails>
    {
        public ActionSuppressedDetails() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.AlertsManagement.Models.TriggeredRule> SuppressedActionGroups { get { throw null; } }
        public System.Collections.Generic.IList<string> SuppressionActionRules { get { throw null; } }
        protected override Azure.ResourceManager.AlertsManagement.Models.BaseDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.AlertsManagement.Models.BaseDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AlertsManagement.Models.ActionSuppressedDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.ActionSuppressedDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.ActionSuppressedDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.ActionSuppressedDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.ActionSuppressedDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.ActionSuppressedDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.ActionSuppressedDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ActionTriggeredDetails : Azure.ResourceManager.AlertsManagement.Models.BaseDetails, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.ActionTriggeredDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.ActionTriggeredDetails>
    {
        public ActionTriggeredDetails() { }
        public Azure.ResourceManager.AlertsManagement.Models.TriggeredRule ActionGroup { get { throw null; } set { } }
        public Azure.ResourceManager.AlertsManagement.Models.NotificationResult NotificationResult { get { throw null; } set { } }
        protected override Azure.ResourceManager.AlertsManagement.Models.BaseDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.AlertsManagement.Models.BaseDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AlertsManagement.Models.ActionTriggeredDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.ActionTriggeredDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.ActionTriggeredDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.ActionTriggeredDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.ActionTriggeredDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.ActionTriggeredDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.ActionTriggeredDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AlertComments : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertComments>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertComments>
    {
        public AlertComments() { }
        public string Comments { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.AlertsManagement.Models.AlertComments JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AlertsManagement.Models.AlertComments PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AlertsManagement.Models.AlertComments System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertComments>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertComments>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.AlertComments System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertComments>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertComments>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertComments>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class AlertEnrichmentItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertEnrichmentItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertEnrichmentItem>
    {
        internal AlertEnrichmentItem() { }
        public string Description { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public Azure.ResourceManager.AlertsManagement.Models.Status Status { get { throw null; } }
        public string Title { get { throw null; } }
        protected virtual Azure.ResourceManager.AlertsManagement.Models.AlertEnrichmentItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AlertsManagement.Models.AlertEnrichmentItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AlertsManagement.Models.AlertEnrichmentItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertEnrichmentItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertEnrichmentItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.AlertEnrichmentItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertEnrichmentItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertEnrichmentItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertEnrichmentItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AlertEnrichmentProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertEnrichmentProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertEnrichmentProperties>
    {
        internal AlertEnrichmentProperties() { }
        public string AlertId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AlertsManagement.Models.AlertEnrichmentItem> Enrichments { get { throw null; } }
        protected virtual Azure.ResourceManager.AlertsManagement.Models.AlertEnrichmentProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AlertsManagement.Models.AlertEnrichmentProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AlertsManagement.Models.AlertEnrichmentProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertEnrichmentProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertEnrichmentProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.AlertEnrichmentProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertEnrichmentProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertEnrichmentProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertEnrichmentProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AlertEnrichmentResult : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertEnrichmentResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertEnrichmentResult>
    {
        internal AlertEnrichmentResult() { }
        public Azure.ResourceManager.AlertsManagement.Models.AlertEnrichmentProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AlertsManagement.Models.AlertEnrichmentResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertEnrichmentResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertEnrichmentResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.AlertEnrichmentResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertEnrichmentResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertEnrichmentResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertEnrichmentResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.ObsoleteAttribute("This type is no longer supported.", true)]
    public abstract partial class AlertProcessingRuleAction : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleAction>
    {
        protected AlertProcessingRuleAction() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleAction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleAction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.ObsoleteAttribute("This type is no longer supported.", true)]
    public partial class AlertProcessingRuleAddGroupsAction : Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleAction, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleAddGroupsAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleAddGroupsAction>
    {
        public AlertProcessingRuleAddGroupsAction(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> actionGroupIds) { }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> ActionGroupIds { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleAddGroupsAction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleAddGroupsAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleAddGroupsAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleAddGroupsAction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleAddGroupsAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleAddGroupsAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleAddGroupsAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.ObsoleteAttribute("This type is no longer supported.", true)]
    public partial class AlertProcessingRuleCondition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleCondition>
    {
        public AlertProcessingRuleCondition() { }
        public Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleField? Field { get { throw null; } set { } }
        public Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleOperator? Operator { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.ObsoleteAttribute("This type is no longer supported.", true)]
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleField left, Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleField right) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleField (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleField left, Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleField right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.ObsoleteAttribute("This type is no longer supported.", true)]
    public partial class AlertProcessingRuleMonthlyRecurrence : Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleRecurrence, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleMonthlyRecurrence>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleMonthlyRecurrence>
    {
        public AlertProcessingRuleMonthlyRecurrence(System.Collections.Generic.IEnumerable<int> daysOfMonth) { }
        public System.Collections.Generic.IList<int> DaysOfMonth { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleMonthlyRecurrence System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleMonthlyRecurrence>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleMonthlyRecurrence>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleMonthlyRecurrence System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleMonthlyRecurrence>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleMonthlyRecurrence>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleMonthlyRecurrence>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.ObsoleteAttribute("This type is no longer supported.", true)]
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleOperator left, Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleOperator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleOperator left, Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.ObsoleteAttribute("This type is no longer supported.", true)]
    public partial class AlertProcessingRulePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRulePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRulePatch>
    {
        public AlertProcessingRulePatch() { }
        public bool? IsEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRulePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRulePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRulePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRulePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRulePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRulePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRulePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.ObsoleteAttribute("This type is no longer supported.", true)]
    public partial class AlertProcessingRuleProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleProperties>
    {
        public AlertProcessingRuleProperties(System.Collections.Generic.IEnumerable<string> scopes, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleAction> actions) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleAction> Actions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleCondition> Conditions { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleSchedule Schedule { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Scopes { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.ObsoleteAttribute("This type is no longer supported.", true)]
    public abstract partial class AlertProcessingRuleRecurrence : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleRecurrence>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleRecurrence>
    {
        protected AlertProcessingRuleRecurrence() { }
        public System.TimeSpan? EndOn { get { throw null; } set { } }
        public System.TimeSpan? StartOn { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleRecurrence System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleRecurrence>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleRecurrence>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleRecurrence System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleRecurrence>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleRecurrence>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleRecurrence>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.ObsoleteAttribute("This type is no longer supported.", true)]
    public partial class AlertProcessingRuleRemoveAllGroupsAction : Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleAction, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleRemoveAllGroupsAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleRemoveAllGroupsAction>
    {
        public AlertProcessingRuleRemoveAllGroupsAction() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleRemoveAllGroupsAction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleRemoveAllGroupsAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleRemoveAllGroupsAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleRemoveAllGroupsAction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleRemoveAllGroupsAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleRemoveAllGroupsAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleRemoveAllGroupsAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.ObsoleteAttribute("This type is no longer supported.", true)]
    public partial class AlertProcessingRuleSchedule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleSchedule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleSchedule>
    {
        public AlertProcessingRuleSchedule() { }
        public System.DateTimeOffset? EffectiveFrom { get { throw null; } set { } }
        public System.DateTimeOffset? EffectiveUntil { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleRecurrence> Recurrences { get { throw null; } }
        public string TimeZone { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleSchedule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleSchedule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleSchedule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleSchedule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleSchedule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleSchedule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleSchedule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.ObsoleteAttribute("This type is no longer supported.", true)]
    public partial class AlertProcessingRuleWeeklyRecurrence : Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleRecurrence, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleWeeklyRecurrence>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleWeeklyRecurrence>
    {
        public AlertProcessingRuleWeeklyRecurrence(System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertsManagement.Models.AlertsManagementDayOfWeek> daysOfWeek) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.AlertsManagement.Models.AlertsManagementDayOfWeek> DaysOfWeek { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleWeeklyRecurrence System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleWeeklyRecurrence>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleWeeklyRecurrence>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleWeeklyRecurrence System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleWeeklyRecurrence>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleWeeklyRecurrence>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleWeeklyRecurrence>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.ObsoleteAttribute("This type is no longer supported.", true)]
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AlertsManagement.Models.AlertsManagementDayOfWeek left, Azure.ResourceManager.AlertsManagement.Models.AlertsManagementDayOfWeek right) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertsManagement.Models.AlertsManagementDayOfWeek (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AlertsManagement.Models.AlertsManagementDayOfWeek left, Azure.ResourceManager.AlertsManagement.Models.AlertsManagementDayOfWeek right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AlertsManagementProxyResource : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertsManagementProxyResource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertsManagementProxyResource>
    {
        public AlertsManagementProxyResource() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.ResourceManager.AlertsManagement.Models.AlertsManagementProxyResource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AlertsManagement.Models.AlertsManagementProxyResource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AlertsManagement.Models.AlertsManagementProxyResource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertsManagementProxyResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertsManagementProxyResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.AlertsManagementProxyResource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertsManagementProxyResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertsManagementProxyResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertsManagementProxyResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AlertsManagement.Models.AlertsManagementQuerySortOrder left, Azure.ResourceManager.AlertsManagement.Models.AlertsManagementQuerySortOrder right) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertsManagement.Models.AlertsManagementQuerySortOrder (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertsManagement.Models.AlertsManagementQuerySortOrder? (string value) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AlertsManagement.Models.AlertsSummaryGroupByField left, Azure.ResourceManager.AlertsManagement.Models.AlertsSummaryGroupByField right) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertsManagement.Models.AlertsSummaryGroupByField (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertsManagement.Models.AlertsSummaryGroupByField? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AlertsManagement.Models.AlertsSummaryGroupByField left, Azure.ResourceManager.AlertsManagement.Models.AlertsSummaryGroupByField right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class ArmAlertsManagementModelFactory
    {
        public static Azure.ResourceManager.AlertsManagement.Models.ActionSuppressedDetails ActionSuppressedDetails(System.Collections.Generic.IEnumerable<string> suppressionActionRules = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertsManagement.Models.TriggeredRule> suppressedActionGroups = null) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.AlertEnrichmentItem AlertEnrichmentItem(string title = null, string description = null, Azure.ResourceManager.AlertsManagement.Models.Status status = default(Azure.ResourceManager.AlertsManagement.Models.Status), string errorMessage = null, string type = null) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.AlertEnrichmentProperties AlertEnrichmentProperties(string alertId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertsManagement.Models.AlertEnrichmentItem> enrichments = null) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.AlertEnrichmentResult AlertEnrichmentResult(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.AlertsManagement.Models.AlertEnrichmentProperties properties = null) { throw null; }
        [System.ObsoleteAttribute("This method is no longer supported.", true)]
        public static Azure.ResourceManager.AlertsManagement.AlertProcessingRuleData AlertProcessingRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleProperties properties = null) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.AlertsManagementProxyResource AlertsManagementProxyResource(string id = null, string type = null, string name = null) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.MonitorServiceDetails MonitorServiceDetails(string name, string displayName) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.MonitorServiceList MonitorServiceList(System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertsManagement.Models.MonitorServiceDetails> data = null) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.PrometheusEnrichmentItem PrometheusEnrichmentItem(string title = null, string description = null, Azure.ResourceManager.AlertsManagement.Models.Status status = default(Azure.ResourceManager.AlertsManagement.Models.Status), string errorMessage = null, string linkToApi = null, System.Collections.Generic.IEnumerable<string> datasources = null, string grafanaExplorePath = null, string query = null) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.PrometheusInstantQuery PrometheusInstantQuery(string title = null, string description = null, Azure.ResourceManager.AlertsManagement.Models.Status status = default(Azure.ResourceManager.AlertsManagement.Models.Status), string errorMessage = null, string linkToApi = null, System.Collections.Generic.IEnumerable<string> datasources = null, string grafanaExplorePath = null, string query = null, string time = null) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.PrometheusRangeQuery PrometheusRangeQuery(string title = null, string description = null, Azure.ResourceManager.AlertsManagement.Models.Status status = default(Azure.ResourceManager.AlertsManagement.Models.Status), string errorMessage = null, string linkToApi = null, System.Collections.Generic.IEnumerable<string> datasources = null, string grafanaExplorePath = null, string query = null, System.DateTimeOffset start = default(System.DateTimeOffset), System.DateTimeOffset end = default(System.DateTimeOffset), string step = null) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.ServiceAlertData ServiceAlertData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.AlertsManagement.Models.ServiceAlertProperties properties = null) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.ServiceAlertEssentials ServiceAlertEssentials(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity? severity = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSignalType? signalType = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSignalType?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState? alertState = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState?), Azure.ResourceManager.AlertsManagement.Models.MonitorCondition? monitorCondition = default(Azure.ResourceManager.AlertsManagement.Models.MonitorCondition?), string targetResource = null, string targetResourceName = null, string targetResourceGroup = null, string targetResourceType = null, Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert? monitorService = default(Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert?), string alertRule = null, string sourceCreatedId = null, System.Guid? smartGroupId = default(System.Guid?), string smartGroupingReason = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), System.DateTimeOffset? monitorConditionResolvedOn = default(System.DateTimeOffset?), string lastModifiedBy = null, bool? isSuppressed = default(bool?), string description = null) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.ServiceAlertMetadata ServiceAlertMetadata(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertMetadataProperties properties = null) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModification ServiceAlertModification(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModificationProperties properties) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModification ServiceAlertModification(string id = null, string type = null, string name = null, Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModificationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModificationProperties ServiceAlertModificationProperties(System.Guid? alertId = default(System.Guid?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModificationItemInfo> modifications = null) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.ServiceAlertProperties ServiceAlertProperties(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertEssentials essentials, System.BinaryData context, System.BinaryData egressConfig) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.ServiceAlertProperties ServiceAlertProperties(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertEssentials essentials = null, System.BinaryData context = null, System.BinaryData egressConfig = null, System.Collections.Generic.IDictionary<string, string> customProperties = null) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummary ServiceAlertSummary(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummaryGroup properties) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummary ServiceAlertSummary(string id = null, string type = null, string name = null, Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummaryGroup properties = null) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummaryGroup ServiceAlertSummaryGroup(long? total = default(long?), long? smartGroupsCount = default(long?), string groupedBy = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummaryGroupItemInfo> values = null) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummaryGroupItemInfo ServiceAlertSummaryGroupItemInfo(string name = null, long? count = default(long?), string groupedBy = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummaryGroupItemInfo> values = null) { throw null; }
        [System.ObsoleteAttribute("This method is no longer supported.", true)]
        public static Azure.ResourceManager.AlertsManagement.SmartGroupData SmartGroupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, long? alertsCount = default(long?), Azure.ResourceManager.AlertsManagement.Models.SmartGroupState? smartGroupState = default(Azure.ResourceManager.AlertsManagement.Models.SmartGroupState?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity? severity = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), string lastModifiedBy = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertsManagement.Models.SmartGroupAggregatedProperty> resources = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertsManagement.Models.SmartGroupAggregatedProperty> resourceTypes = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertsManagement.Models.SmartGroupAggregatedProperty> resourceGroups = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertsManagement.Models.SmartGroupAggregatedProperty> monitorServices = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertsManagement.Models.SmartGroupAggregatedProperty> monitorConditions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertsManagement.Models.SmartGroupAggregatedProperty> alertStates = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertsManagement.Models.SmartGroupAggregatedProperty> alertSeverities = null, string nextLink = null) { throw null; }
        [System.ObsoleteAttribute("This method is no longer supported.", true)]
        public static Azure.ResourceManager.AlertsManagement.Models.SmartGroupModification SmartGroupModification(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.AlertsManagement.Models.SmartGroupModificationProperties properties = null) { throw null; }
        [System.ObsoleteAttribute("This method is no longer supported.", true)]
        public static Azure.ResourceManager.AlertsManagement.Models.SmartGroupModificationProperties SmartGroupModificationProperties(System.Guid? smartGroupId = default(System.Guid?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertsManagement.Models.SmartGroupModificationItemInfo> modifications = null, string nextLink = null) { throw null; }
    }
    public abstract partial class BaseDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.BaseDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.BaseDetails>
    {
        internal BaseDetails() { }
        protected virtual Azure.ResourceManager.AlertsManagement.Models.BaseDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AlertsManagement.Models.BaseDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AlertsManagement.Models.BaseDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.BaseDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.BaseDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.BaseDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.BaseDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.BaseDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.BaseDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.ObsoleteAttribute("This type is no longer supported.", true)]
    public partial class DailyRecurrence : Azure.ResourceManager.AlertsManagement.Models.AlertProcessingRuleRecurrence, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.DailyRecurrence>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.DailyRecurrence>
    {
        public DailyRecurrence() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AlertsManagement.Models.ListServiceAlertsSortByField left, Azure.ResourceManager.AlertsManagement.Models.ListServiceAlertsSortByField right) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertsManagement.Models.ListServiceAlertsSortByField (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertsManagement.Models.ListServiceAlertsSortByField? (string value) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AlertsManagement.Models.MonitorCondition left, Azure.ResourceManager.AlertsManagement.Models.MonitorCondition right) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertsManagement.Models.MonitorCondition (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertsManagement.Models.MonitorCondition? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AlertsManagement.Models.MonitorCondition left, Azure.ResourceManager.AlertsManagement.Models.MonitorCondition right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MonitorServiceDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.MonitorServiceDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.MonitorServiceDetails>
    {
        public MonitorServiceDetails() { }
        public string DisplayName { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.AlertsManagement.Models.MonitorServiceDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AlertsManagement.Models.MonitorServiceDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AlertsManagement.Models.MonitorServiceDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.MonitorServiceDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.MonitorServiceDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.MonitorServiceDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.MonitorServiceDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.MonitorServiceDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.MonitorServiceDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MonitorServiceList : Azure.ResourceManager.AlertsManagement.Models.ServiceAlertMetadataProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.MonitorServiceList>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.MonitorServiceList>
    {
        public MonitorServiceList(System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertsManagement.Models.MonitorServiceDetails> data) { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AlertsManagement.Models.MonitorServiceDetails> Data { get { throw null; } }
        protected override Azure.ResourceManager.AlertsManagement.Models.ServiceAlertMetadataProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.AlertsManagement.Models.ServiceAlertMetadataProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public static Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert ResourceHealth { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert Scom { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert ServiceHealth { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert SmartDetector { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert VmInsights { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert Zabbix { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert left, Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert right) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert left, Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NotificationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.NotificationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.NotificationResult>
    {
        public NotificationResult() { }
        public Azure.ResourceManager.AlertsManagement.Models.ResultStatus? Status { get { throw null; } set { } }
        public string StatusURL { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.AlertsManagement.Models.NotificationResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AlertsManagement.Models.NotificationResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AlertsManagement.Models.NotificationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.NotificationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.NotificationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.NotificationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.NotificationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.NotificationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.NotificationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrometheusEnrichmentItem : Azure.ResourceManager.AlertsManagement.Models.AlertEnrichmentItem, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.PrometheusEnrichmentItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.PrometheusEnrichmentItem>
    {
        internal PrometheusEnrichmentItem() { }
        public System.Collections.Generic.IList<string> Datasources { get { throw null; } }
        public string GrafanaExplorePath { get { throw null; } }
        public string LinkToApi { get { throw null; } }
        public string Query { get { throw null; } }
        protected override Azure.ResourceManager.AlertsManagement.Models.AlertEnrichmentItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.AlertsManagement.Models.AlertEnrichmentItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AlertsManagement.Models.PrometheusEnrichmentItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.PrometheusEnrichmentItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.PrometheusEnrichmentItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.PrometheusEnrichmentItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.PrometheusEnrichmentItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.PrometheusEnrichmentItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.PrometheusEnrichmentItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrometheusInstantQuery : Azure.ResourceManager.AlertsManagement.Models.AlertEnrichmentItem, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.PrometheusInstantQuery>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.PrometheusInstantQuery>
    {
        internal PrometheusInstantQuery() { }
        public System.Collections.Generic.IList<string> Datasources { get { throw null; } }
        public string GrafanaExplorePath { get { throw null; } }
        public string LinkToApi { get { throw null; } }
        public string Query { get { throw null; } }
        public string Time { get { throw null; } }
        protected override Azure.ResourceManager.AlertsManagement.Models.AlertEnrichmentItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.AlertsManagement.Models.AlertEnrichmentItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AlertsManagement.Models.PrometheusInstantQuery System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.PrometheusInstantQuery>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.PrometheusInstantQuery>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.PrometheusInstantQuery System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.PrometheusInstantQuery>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.PrometheusInstantQuery>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.PrometheusInstantQuery>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrometheusRangeQuery : Azure.ResourceManager.AlertsManagement.Models.AlertEnrichmentItem, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.PrometheusRangeQuery>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.PrometheusRangeQuery>
    {
        internal PrometheusRangeQuery() { }
        public System.Collections.Generic.IList<string> Datasources { get { throw null; } }
        public System.DateTimeOffset End { get { throw null; } }
        public string GrafanaExplorePath { get { throw null; } }
        public string LinkToApi { get { throw null; } }
        public string Query { get { throw null; } }
        public System.DateTimeOffset Start { get { throw null; } }
        public string Step { get { throw null; } }
        protected override Azure.ResourceManager.AlertsManagement.Models.AlertEnrichmentItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.AlertsManagement.Models.AlertEnrichmentItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AlertsManagement.Models.PrometheusRangeQuery System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.PrometheusRangeQuery>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.PrometheusRangeQuery>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.PrometheusRangeQuery System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.PrometheusRangeQuery>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.PrometheusRangeQuery>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.PrometheusRangeQuery>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PropertyChangeDetails : Azure.ResourceManager.AlertsManagement.Models.BaseDetails, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.PropertyChangeDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.PropertyChangeDetails>
    {
        public PropertyChangeDetails() { }
        public string Comment { get { throw null; } set { } }
        public string NewValue { get { throw null; } set { } }
        public string OldValue { get { throw null; } set { } }
        protected override Azure.ResourceManager.AlertsManagement.Models.BaseDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.AlertsManagement.Models.BaseDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AlertsManagement.Models.PropertyChangeDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.PropertyChangeDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.PropertyChangeDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.PropertyChangeDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.PropertyChangeDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.PropertyChangeDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.PropertyChangeDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResultStatus : System.IEquatable<Azure.ResourceManager.AlertsManagement.Models.ResultStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResultStatus(string value) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.ResultStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.ResultStatus Inline { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.ResultStatus None { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.ResultStatus Throttled { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.ResultStatus ThrottledByAlertRule { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.ResultStatus ThrottledBySubscription { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AlertsManagement.Models.ResultStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AlertsManagement.Models.ResultStatus left, Azure.ResourceManager.AlertsManagement.Models.ResultStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertsManagement.Models.ResultStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertsManagement.Models.ResultStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AlertsManagement.Models.ResultStatus left, Azure.ResourceManager.AlertsManagement.Models.ResultStatus right) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AlertsManagement.Models.RetrievedInformationIdentifier left, Azure.ResourceManager.AlertsManagement.Models.RetrievedInformationIdentifier right) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertsManagement.Models.RetrievedInformationIdentifier (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertsManagement.Models.RetrievedInformationIdentifier? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AlertsManagement.Models.RetrievedInformationIdentifier left, Azure.ResourceManager.AlertsManagement.Models.RetrievedInformationIdentifier right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RuleType : System.IEquatable<Azure.ResourceManager.AlertsManagement.Models.RuleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RuleType(string value) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.RuleType ActionRule { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.RuleType AlertRule { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AlertsManagement.Models.RuleType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AlertsManagement.Models.RuleType left, Azure.ResourceManager.AlertsManagement.Models.RuleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertsManagement.Models.RuleType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertsManagement.Models.RuleType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AlertsManagement.Models.RuleType left, Azure.ResourceManager.AlertsManagement.Models.RuleType right) { throw null; }
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
        protected virtual Azure.ResourceManager.AlertsManagement.Models.ServiceAlertEssentials JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AlertsManagement.Models.ServiceAlertEssentials PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.AlertsManagement.Models.ServiceAlertMetadata JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AlertsManagement.Models.ServiceAlertMetadata PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AlertsManagement.Models.ServiceAlertMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.ServiceAlertMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ServiceAlertMetadataProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertMetadataProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertMetadataProperties>
    {
        protected ServiceAlertMetadataProperties() { }
        protected virtual Azure.ResourceManager.AlertsManagement.Models.ServiceAlertMetadataProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AlertsManagement.Models.ServiceAlertMetadataProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModification JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModification PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public Azure.ResourceManager.AlertsManagement.Models.BaseDetails Details { get { throw null; } set { } }
        public Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModificationEvent? ModificationEvent { get { throw null; } set { } }
        public string ModifiedAt { get { throw null; } set { } }
        public string ModifiedBy { get { throw null; } set { } }
        public string NewValue { get { throw null; } set { } }
        public string OldValue { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModificationItemInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModificationItemInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModificationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModificationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public System.Collections.Generic.IDictionary<string, string> CustomProperties { get { throw null; } }
        public System.BinaryData EgressConfig { get { throw null; } }
        public Azure.ResourceManager.AlertsManagement.Models.ServiceAlertEssentials Essentials { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.AlertsManagement.Models.ServiceAlertProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AlertsManagement.Models.ServiceAlertProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity left, Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity right) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity? (string value) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSignalType left, Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSignalType right) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSignalType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSignalType? (string value) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState left, Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState right) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState left, Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServiceAlertSummary : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummary>
    {
        public ServiceAlertSummary() { }
        public Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummaryGroup Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummary JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummary PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummaryGroup JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummaryGroup PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummaryGroupItemInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummaryGroupItemInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummaryGroupItemInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummaryGroupItemInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummaryGroupItemInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummaryGroupItemInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummaryGroupItemInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummaryGroupItemInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummaryGroupItemInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.ObsoleteAttribute("This type is no longer supported.", true)]
    public partial class SmartGroupAggregatedProperty : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.SmartGroupAggregatedProperty>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.SmartGroupAggregatedProperty>
    {
        public SmartGroupAggregatedProperty() { }
        public long? Count { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.SmartGroupAggregatedProperty System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.SmartGroupAggregatedProperty>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.SmartGroupAggregatedProperty>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.SmartGroupAggregatedProperty System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.SmartGroupAggregatedProperty>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.SmartGroupAggregatedProperty>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.SmartGroupAggregatedProperty>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.ObsoleteAttribute("This type is no longer supported.", true)]
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
    [System.ObsoleteAttribute("This type is no longer supported.", true)]
    public partial class SmartGroupModification : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.SmartGroupModification>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.SmartGroupModification>
    {
        public SmartGroupModification() { }
        public Azure.ResourceManager.AlertsManagement.Models.SmartGroupModificationProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.SmartGroupModification System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.SmartGroupModification>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.SmartGroupModification>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.SmartGroupModification System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.SmartGroupModification>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.SmartGroupModification>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.SmartGroupModification>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.ObsoleteAttribute("This type is no longer supported.", true)]
    public enum SmartGroupModificationEvent
    {
        SmartGroupCreated = 0,
        StateChange = 1,
        AlertAdded = 2,
        AlertRemoved = 3,
    }
    [System.ObsoleteAttribute("This type is no longer supported.", true)]
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.SmartGroupModificationItemInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.SmartGroupModificationItemInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.SmartGroupModificationItemInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.SmartGroupModificationItemInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.SmartGroupModificationItemInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.SmartGroupModificationItemInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.SmartGroupModificationItemInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.ObsoleteAttribute("This type is no longer supported.", true)]
    public partial class SmartGroupModificationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.SmartGroupModificationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.SmartGroupModificationProperties>
    {
        public SmartGroupModificationProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.AlertsManagement.Models.SmartGroupModificationItemInfo> Modifications { get { throw null; } }
        public string NextLink { get { throw null; } set { } }
        public System.Guid? SmartGroupId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.SmartGroupModificationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.SmartGroupModificationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.SmartGroupModificationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.SmartGroupModificationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.SmartGroupModificationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.SmartGroupModificationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.SmartGroupModificationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.ObsoleteAttribute("This type is no longer supported.", true)]
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AlertsManagement.Models.SmartGroupsSortByField left, Azure.ResourceManager.AlertsManagement.Models.SmartGroupsSortByField right) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertsManagement.Models.SmartGroupsSortByField (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AlertsManagement.Models.SmartGroupsSortByField left, Azure.ResourceManager.AlertsManagement.Models.SmartGroupsSortByField right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.ObsoleteAttribute("This type is no longer supported.", true)]
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AlertsManagement.Models.SmartGroupState left, Azure.ResourceManager.AlertsManagement.Models.SmartGroupState right) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertsManagement.Models.SmartGroupState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AlertsManagement.Models.SmartGroupState left, Azure.ResourceManager.AlertsManagement.Models.SmartGroupState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Status : System.IEquatable<Azure.ResourceManager.AlertsManagement.Models.Status>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Status(string value) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.Status Failed { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.Status Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AlertsManagement.Models.Status other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AlertsManagement.Models.Status left, Azure.ResourceManager.AlertsManagement.Models.Status right) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertsManagement.Models.Status (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertsManagement.Models.Status? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AlertsManagement.Models.Status left, Azure.ResourceManager.AlertsManagement.Models.Status right) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter left, Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter right) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter left, Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TriggeredRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.TriggeredRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.TriggeredRule>
    {
        public TriggeredRule() { }
        public string ActionGroupId { get { throw null; } set { } }
        public string RuleId { get { throw null; } set { } }
        public Azure.ResourceManager.AlertsManagement.Models.RuleType? RuleType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.AlertsManagement.Models.TriggeredRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AlertsManagement.Models.TriggeredRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AlertsManagement.Models.TriggeredRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.TriggeredRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.TriggeredRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.TriggeredRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.TriggeredRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.TriggeredRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.TriggeredRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
