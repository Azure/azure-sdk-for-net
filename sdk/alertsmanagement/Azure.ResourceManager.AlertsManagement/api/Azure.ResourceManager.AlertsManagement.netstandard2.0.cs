namespace Azure.ResourceManager.AlertsManagement
{
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
        public static Azure.ResourceManager.AlertsManagement.AlertResource GetAlertResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.ServiceAlertCollection GetAlerts(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.ServiceAlertCollection GetAlerts(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummary> GetServiceAlertSummary(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.AlertsManagement.Models.GetServiceAlertSummaryGroupByField groupby, bool? includeSmartGroupsCount = default(bool?), string targetResource = null, string targetResourceType = null, string targetResourceGroup = null, Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert? monitorService = default(Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert?), Azure.ResourceManager.AlertsManagement.Models.MonitorCondition? monitorCondition = default(Azure.ResourceManager.AlertsManagement.Models.MonitorCondition?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity? severity = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState? alertState = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState?), string alertRule = null, Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter? timeRange = default(Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter?), string customTimeRange = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummary> GetServiceAlertSummary(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.AlertsManagement.Models.SubscriptionResourceGetServiceAlertSummaryOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummary>> GetServiceAlertSummaryAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.AlertsManagement.Models.GetServiceAlertSummaryGroupByField groupby, bool? includeSmartGroupsCount = default(bool?), string targetResource = null, string targetResourceType = null, string targetResourceGroup = null, Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert? monitorService = default(Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert?), Azure.ResourceManager.AlertsManagement.Models.MonitorCondition? monitorCondition = default(Azure.ResourceManager.AlertsManagement.Models.MonitorCondition?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity? severity = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState? alertState = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState?), string alertRule = null, Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter? timeRange = default(Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter?), string customTimeRange = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummary>> GetServiceAlertSummaryAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.AlertsManagement.Models.SubscriptionResourceGetServiceAlertSummaryOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummary> GetSummary(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.AlertsManagement.Models.GetServiceAlertSummaryGroupByField groupby, bool? includeSmartGroupsCount = default(bool?), string targetResource = null, string targetResourceType = null, string targetResourceGroup = null, Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert? monitorService = default(Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert?), Azure.ResourceManager.AlertsManagement.Models.MonitorCondition? monitorCondition = default(Azure.ResourceManager.AlertsManagement.Models.MonitorCondition?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity? severity = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState? alertState = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState?), string alertRule = null, Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter? timeRange = default(Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter?), string customTimeRange = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummary>> GetSummaryAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.AlertsManagement.Models.GetServiceAlertSummaryGroupByField groupby, bool? includeSmartGroupsCount = default(bool?), string targetResource = null, string targetResourceType = null, string targetResourceGroup = null, Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert? monitorService = default(Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert?), Azure.ResourceManager.AlertsManagement.Models.MonitorCondition? monitorCondition = default(Azure.ResourceManager.AlertsManagement.Models.MonitorCondition?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity? severity = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState? alertState = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState?), string alertRule = null, Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter? timeRange = default(Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter?), string customTimeRange = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Response<bool> Exists(string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AlertsManagement.AlertResource> Get(string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AlertsManagement.AlertResource> GetAll(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertCollectionGetAllOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AlertsManagement.AlertResource> GetAll(string targetResource = null, string targetResourceType = null, string targetResourceGroup = null, Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert? monitorService = default(Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert?), Azure.ResourceManager.AlertsManagement.Models.MonitorCondition? monitorCondition = default(Azure.ResourceManager.AlertsManagement.Models.MonitorCondition?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity? severity = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState? alertState = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState?), string alertRule = null, string smartGroupId = null, bool? includeContext = default(bool?), bool? includeEgressConfig = default(bool?), long? pageCount = default(long?), Azure.ResourceManager.AlertsManagement.Models.ListServiceAlertsSortByField? sortBy = default(Azure.ResourceManager.AlertsManagement.Models.ListServiceAlertsSortByField?), Azure.ResourceManager.AlertsManagement.Models.AlertsManagementQuerySortOrder? sortOrder = default(Azure.ResourceManager.AlertsManagement.Models.AlertsManagementQuerySortOrder?), string select = null, Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter? timeRange = default(Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter?), string customTimeRange = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AlertsManagement.AlertResource> GetAllAsync(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertCollectionGetAllOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AlertsManagement.AlertResource> GetAllAsync(string targetResource = null, string targetResourceType = null, string targetResourceGroup = null, Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert? monitorService = default(Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert?), Azure.ResourceManager.AlertsManagement.Models.MonitorCondition? monitorCondition = default(Azure.ResourceManager.AlertsManagement.Models.MonitorCondition?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity? severity = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState? alertState = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState?), string alertRule = null, string smartGroupId = null, bool? includeContext = default(bool?), bool? includeEgressConfig = default(bool?), long? pageCount = default(long?), Azure.ResourceManager.AlertsManagement.Models.ListServiceAlertsSortByField? sortBy = default(Azure.ResourceManager.AlertsManagement.Models.ListServiceAlertsSortByField?), Azure.ResourceManager.AlertsManagement.Models.AlertsManagementQuerySortOrder? sortOrder = default(Azure.ResourceManager.AlertsManagement.Models.AlertsManagementQuerySortOrder?), string select = null, Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter? timeRange = default(Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter?), string customTimeRange = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.AlertResource>> GetAsync(string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.AlertsManagement.AlertResource> GetIfExists(string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.AlertsManagement.AlertResource>> GetIfExistsAsync(string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AlertsManagement.AlertResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AlertsManagement.AlertResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AlertsManagement.AlertResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertsManagement.AlertResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceAlertData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.ServiceAlertData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.ServiceAlertData>
    {
        internal ServiceAlertData() { }
        public Azure.ResourceManager.AlertsManagement.Models.ServiceAlertProperties Properties { get { throw null; } }
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
}
namespace Azure.ResourceManager.AlertsManagement.Mocking
{
    public partial class MockableAlertsManagementArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableAlertsManagementArmClient() { }
        public virtual Azure.Response<Azure.ResourceManager.AlertsManagement.AlertResource> GetAlert(Azure.Core.ResourceIdentifier scope, string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.AlertResource>> GetAlertAsync(Azure.Core.ResourceIdentifier scope, string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AlertsManagement.AlertResource GetAlertResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.AlertsManagement.ServiceAlertCollection GetAlerts(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummary> GetSummary(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.AlertsManagement.Models.GetServiceAlertSummaryGroupByField groupby, bool? includeSmartGroupsCount = default(bool?), string targetResource = null, string targetResourceType = null, string targetResourceGroup = null, Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert? monitorService = default(Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert?), Azure.ResourceManager.AlertsManagement.Models.MonitorCondition? monitorCondition = default(Azure.ResourceManager.AlertsManagement.Models.MonitorCondition?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity? severity = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState? alertState = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState?), string alertRule = null, Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter? timeRange = default(Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter?), string customTimeRange = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummary>> GetSummaryAsync(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.AlertsManagement.Models.GetServiceAlertSummaryGroupByField groupby, bool? includeSmartGroupsCount = default(bool?), string targetResource = null, string targetResourceType = null, string targetResourceGroup = null, Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert? monitorService = default(Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert?), Azure.ResourceManager.AlertsManagement.Models.MonitorCondition? monitorCondition = default(Azure.ResourceManager.AlertsManagement.Models.MonitorCondition?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity? severity = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState? alertState = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState?), string alertRule = null, Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter? timeRange = default(Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter?), string customTimeRange = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableAlertsManagementSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        internal MockableAlertsManagementSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummary> GetServiceAlertSummary(Azure.ResourceManager.AlertsManagement.Models.GetServiceAlertSummaryGroupByField groupby, bool? includeSmartGroupsCount = default(bool?), string targetResource = null, string targetResourceType = null, string targetResourceGroup = null, Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert? monitorService = default(Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert?), Azure.ResourceManager.AlertsManagement.Models.MonitorCondition? monitorCondition = default(Azure.ResourceManager.AlertsManagement.Models.MonitorCondition?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity? severity = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState? alertState = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState?), string alertRule = null, Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter? timeRange = default(Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter?), string customTimeRange = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummary> GetServiceAlertSummary(Azure.ResourceManager.AlertsManagement.Models.SubscriptionResourceGetServiceAlertSummaryOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummary>> GetServiceAlertSummaryAsync(Azure.ResourceManager.AlertsManagement.Models.GetServiceAlertSummaryGroupByField groupby, bool? includeSmartGroupsCount = default(bool?), string targetResource = null, string targetResourceType = null, string targetResourceGroup = null, Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert? monitorService = default(Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert?), Azure.ResourceManager.AlertsManagement.Models.MonitorCondition? monitorCondition = default(Azure.ResourceManager.AlertsManagement.Models.MonitorCondition?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity? severity = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState? alertState = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState?), string alertRule = null, Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter? timeRange = default(Azure.ResourceManager.AlertsManagement.Models.TimeRangeFilter?), string customTimeRange = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummary>> GetServiceAlertSummaryAsync(Azure.ResourceManager.AlertsManagement.Models.SubscriptionResourceGetServiceAlertSummaryOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableAlertsManagementTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableAlertsManagementTenantResource() { }
        public virtual Azure.Response<Azure.ResourceManager.AlertsManagement.AlertResource> GetAlert(string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.AlertResource>> GetAlertAsync(string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AlertsManagement.ServiceAlertCollection GetAlerts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertMetadata> MetaData(Azure.ResourceManager.AlertsManagement.Models.RetrievedInformationIdentifier identifier, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertMetadata>> MetaDataAsync(Azure.ResourceManager.AlertsManagement.Models.RetrievedInformationIdentifier identifier, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.AlertsManagement.Models
{
    public partial class ActionSuppressedDetails : Azure.ResourceManager.AlertsManagement.Models.BaseDetails, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.ActionSuppressedDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.ActionSuppressedDetails>
    {
        internal ActionSuppressedDetails() { }
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
        internal ActionTriggeredDetails() { }
        public Azure.ResourceManager.AlertsManagement.Models.TriggeredRule ActionGroup { get { throw null; } }
        public Azure.ResourceManager.AlertsManagement.Models.NotificationResult NotificationResult { get { throw null; } }
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
    public partial class AlertsManagementProxyResource : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.AlertsManagementProxyResource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.AlertsManagementProxyResource>
    {
        internal AlertsManagementProxyResource() { }
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
    public static partial class ArmAlertsManagementModelFactory
    {
        public static Azure.ResourceManager.AlertsManagement.Models.ActionSuppressedDetails ActionSuppressedDetails(System.Collections.Generic.IEnumerable<string> suppressionActionRules = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertsManagement.Models.TriggeredRule> suppressedActionGroups = null) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.ActionTriggeredDetails ActionTriggeredDetails(Azure.ResourceManager.AlertsManagement.Models.TriggeredRule actionGroup = null, Azure.ResourceManager.AlertsManagement.Models.NotificationResult notificationResult = null) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.AlertEnrichmentItem AlertEnrichmentItem(string title = null, string description = null, Azure.ResourceManager.AlertsManagement.Models.Status status = default(Azure.ResourceManager.AlertsManagement.Models.Status), string errorMessage = null, string type = null) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.AlertEnrichmentProperties AlertEnrichmentProperties(string alertId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertsManagement.Models.AlertEnrichmentItem> enrichments = null) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.AlertEnrichmentResult AlertEnrichmentResult(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.AlertsManagement.Models.AlertEnrichmentProperties properties = null) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.AlertsManagementProxyResource AlertsManagementProxyResource(string id = null, string type = null, string name = null) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.MonitorServiceDetails MonitorServiceDetails(string name = null, string displayName = null) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.MonitorServiceList MonitorServiceList(System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertsManagement.Models.MonitorServiceDetails> data = null) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.NotificationResult NotificationResult(string statusURL = null, Azure.ResourceManager.AlertsManagement.Models.ResultStatus? status = default(Azure.ResourceManager.AlertsManagement.Models.ResultStatus?)) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.PrometheusEnrichmentItem PrometheusEnrichmentItem(string title = null, string description = null, Azure.ResourceManager.AlertsManagement.Models.Status status = default(Azure.ResourceManager.AlertsManagement.Models.Status), string errorMessage = null, string linkToApi = null, System.Collections.Generic.IEnumerable<string> datasources = null, string grafanaExplorePath = null, string query = null) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.PrometheusInstantQuery PrometheusInstantQuery(string title = null, string description = null, Azure.ResourceManager.AlertsManagement.Models.Status status = default(Azure.ResourceManager.AlertsManagement.Models.Status), string errorMessage = null, string linkToApi = null, System.Collections.Generic.IEnumerable<string> datasources = null, string grafanaExplorePath = null, string query = null, string time = null) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.PrometheusRangeQuery PrometheusRangeQuery(string title = null, string description = null, Azure.ResourceManager.AlertsManagement.Models.Status status = default(Azure.ResourceManager.AlertsManagement.Models.Status), string errorMessage = null, string linkToApi = null, System.Collections.Generic.IEnumerable<string> datasources = null, string grafanaExplorePath = null, string query = null, System.DateTimeOffset start = default(System.DateTimeOffset), System.DateTimeOffset end = default(System.DateTimeOffset), string step = null) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.PropertyChangeDetails PropertyChangeDetails(string oldValue = null, string newValue = null, string comment = null) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.ServiceAlertData ServiceAlertData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.AlertsManagement.Models.ServiceAlertProperties properties = null) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.ServiceAlertEssentials ServiceAlertEssentials(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity? severity = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSignalType? signalType = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSignalType?), Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState? alertState = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState?), Azure.ResourceManager.AlertsManagement.Models.MonitorCondition? monitorCondition = default(Azure.ResourceManager.AlertsManagement.Models.MonitorCondition?), string targetResource = null, string targetResourceName = null, string targetResourceGroup = null, string targetResourceType = null, Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert? monitorService = default(Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert?), string alertRule = null, string sourceCreatedId = null, string smartGroupId = null, string smartGroupingReason = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), System.DateTimeOffset? monitorConditionResolvedOn = default(System.DateTimeOffset?), string lastModifiedBy = null, bool? isSuppressed = default(bool?), string description = null) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.ServiceAlertMetadata ServiceAlertMetadata(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertMetadataProperties properties = null) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModification ServiceAlertModification(string id = null, string type = null, string name = null, Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModificationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModificationItemInfo ServiceAlertModificationItemInfo(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModificationEvent? modificationEvent = default(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModificationEvent?), string oldValue = null, string newValue = null, string modifiedAt = null, string modifiedBy = null, string comments = null, string description = null, Azure.ResourceManager.AlertsManagement.Models.BaseDetails details = null) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModificationProperties ServiceAlertModificationProperties(string alertId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModificationItemInfo> modifications = null) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.ServiceAlertProperties ServiceAlertProperties(Azure.ResourceManager.AlertsManagement.Models.ServiceAlertEssentials essentials = null, System.BinaryData context = null, System.BinaryData egressConfig = null, System.Collections.Generic.IDictionary<string, string> customProperties = null) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummary ServiceAlertSummary(string id = null, string type = null, string name = null, Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummaryGroup properties = null) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummaryGroup ServiceAlertSummaryGroup(long? total = default(long?), long? smartGroupsCount = default(long?), string groupedby = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummaryGroupItemInfo> values = null) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummaryGroupItemInfo ServiceAlertSummaryGroupItemInfo(string name = null, long? count = default(long?), string groupedby = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummaryGroupItemInfo> values = null) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.TriggeredRule TriggeredRule(string actionGroupId = null, string ruleId = null, Azure.ResourceManager.AlertsManagement.Models.RuleType? ruleType = default(Azure.ResourceManager.AlertsManagement.Models.RuleType?)) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GetServiceAlertSummaryGroupByField : System.IEquatable<Azure.ResourceManager.AlertsManagement.Models.GetServiceAlertSummaryGroupByField>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GetServiceAlertSummaryGroupByField(string value) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.GetServiceAlertSummaryGroupByField AlertRule { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.GetServiceAlertSummaryGroupByField AlertState { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.GetServiceAlertSummaryGroupByField MonitorCondition { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.GetServiceAlertSummaryGroupByField MonitorService { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.GetServiceAlertSummaryGroupByField Severity { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.GetServiceAlertSummaryGroupByField SignalType { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AlertsManagement.Models.GetServiceAlertSummaryGroupByField other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AlertsManagement.Models.GetServiceAlertSummaryGroupByField left, Azure.ResourceManager.AlertsManagement.Models.GetServiceAlertSummaryGroupByField right) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertsManagement.Models.GetServiceAlertSummaryGroupByField (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertsManagement.Models.GetServiceAlertSummaryGroupByField? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AlertsManagement.Models.GetServiceAlertSummaryGroupByField left, Azure.ResourceManager.AlertsManagement.Models.GetServiceAlertSummaryGroupByField right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ListServiceAlertsSortByField : System.IEquatable<Azure.ResourceManager.AlertsManagement.Models.ListServiceAlertsSortByField>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ListServiceAlertsSortByField(string value) { throw null; }
        public static Azure.ResourceManager.AlertsManagement.Models.ListServiceAlertsSortByField AlertState { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.ListServiceAlertsSortByField LastModifiedDateTime { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.ListServiceAlertsSortByField MonitorCondition { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.ListServiceAlertsSortByField Name { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.ListServiceAlertsSortByField Severity { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.ListServiceAlertsSortByField StartDateTime { get { throw null; } }
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
        internal MonitorServiceDetails() { }
        public string DisplayName { get { throw null; } }
        public string Name { get { throw null; } }
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
        internal MonitorServiceList() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.AlertsManagement.Models.MonitorServiceDetails> Data { get { throw null; } }
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
        public static Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert SCOM { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert ServiceHealth { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert SmartDetector { get { throw null; } }
        public static Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert VMInsights { get { throw null; } }
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
        internal NotificationResult() { }
        public Azure.ResourceManager.AlertsManagement.Models.ResultStatus? Status { get { throw null; } }
        public string StatusURL { get { throw null; } }
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
        internal PropertyChangeDetails() { }
        public string Comment { get { throw null; } }
        public string NewValue { get { throw null; } }
        public string OldValue { get { throw null; } }
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
        internal ServiceAlertEssentials() { }
        public string AlertRule { get { throw null; } }
        public Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState? AlertState { get { throw null; } }
        public string Description { get { throw null; } }
        public bool? IsSuppressed { get { throw null; } }
        public string LastModifiedBy { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public Azure.ResourceManager.AlertsManagement.Models.MonitorCondition? MonitorCondition { get { throw null; } }
        public System.DateTimeOffset? MonitorConditionResolvedOn { get { throw null; } }
        public Azure.ResourceManager.AlertsManagement.Models.MonitorServiceSourceForAlert? MonitorService { get { throw null; } }
        public Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSeverity? Severity { get { throw null; } }
        public Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSignalType? SignalType { get { throw null; } }
        public string SmartGroupId { get { throw null; } }
        public string SmartGroupingReason { get { throw null; } }
        public string SourceCreatedId { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string TargetResource { get { throw null; } }
        public string TargetResourceGroup { get { throw null; } }
        public string TargetResourceName { get { throw null; } }
        public string TargetResourceType { get { throw null; } }
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
        internal ServiceAlertMetadataProperties() { }
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
    public partial class ServiceAlertModification : Azure.ResourceManager.AlertsManagement.Models.AlertsManagementProxyResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModification>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModification>
    {
        internal ServiceAlertModification() { }
        public Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModificationProperties Properties { get { throw null; } }
        protected override Azure.ResourceManager.AlertsManagement.Models.AlertsManagementProxyResource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.AlertsManagement.Models.AlertsManagementProxyResource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        SeverityChange = 2,
        MonitorConditionChange = 3,
        ActionsTriggered = 4,
        ActionsSuppressed = 5,
    }
    public partial class ServiceAlertModificationItemInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModificationItemInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModificationItemInfo>
    {
        internal ServiceAlertModificationItemInfo() { }
        public string Comments { get { throw null; } }
        public string Description { get { throw null; } }
        public Azure.ResourceManager.AlertsManagement.Models.BaseDetails Details { get { throw null; } }
        public Azure.ResourceManager.AlertsManagement.Models.ServiceAlertModificationEvent? ModificationEvent { get { throw null; } }
        public string ModifiedAt { get { throw null; } }
        public string ModifiedBy { get { throw null; } }
        public string NewValue { get { throw null; } }
        public string OldValue { get { throw null; } }
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
        internal ServiceAlertModificationProperties() { }
        public string AlertId { get { throw null; } }
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
        internal ServiceAlertProperties() { }
        public System.BinaryData Context { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> CustomProperties { get { throw null; } }
        public System.BinaryData EgressConfig { get { throw null; } }
        public Azure.ResourceManager.AlertsManagement.Models.ServiceAlertEssentials Essentials { get { throw null; } }
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
    public partial class ServiceAlertSummary : Azure.ResourceManager.AlertsManagement.Models.AlertsManagementProxyResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummary>
    {
        internal ServiceAlertSummary() { }
        public Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummaryGroup Properties { get { throw null; } }
        protected override Azure.ResourceManager.AlertsManagement.Models.AlertsManagementProxyResource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.AlertsManagement.Models.AlertsManagementProxyResource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServiceAlertSummaryGroup : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummaryGroup>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertsManagement.Models.ServiceAlertSummaryGroup>
    {
        internal ServiceAlertSummaryGroup() { }
        public string Groupedby { get { throw null; } }
        public long? SmartGroupsCount { get { throw null; } }
        public long? Total { get { throw null; } }
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
        internal ServiceAlertSummaryGroupItemInfo() { }
        public long? Count { get { throw null; } }
        public string Groupedby { get { throw null; } }
        public string Name { get { throw null; } }
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
        public SubscriptionResourceGetServiceAlertSummaryOptions(Azure.ResourceManager.AlertsManagement.Models.GetServiceAlertSummaryGroupByField groupby) { }
        public string AlertRule { get { throw null; } set { } }
        public Azure.ResourceManager.AlertsManagement.Models.ServiceAlertState? AlertState { get { throw null; } set { } }
        public string CustomTimeRange { get { throw null; } set { } }
        public Azure.ResourceManager.AlertsManagement.Models.GetServiceAlertSummaryGroupByField Groupby { get { throw null; } }
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
        internal TriggeredRule() { }
        public string ActionGroupId { get { throw null; } }
        public string RuleId { get { throw null; } }
        public Azure.ResourceManager.AlertsManagement.Models.RuleType? RuleType { get { throw null; } }
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
