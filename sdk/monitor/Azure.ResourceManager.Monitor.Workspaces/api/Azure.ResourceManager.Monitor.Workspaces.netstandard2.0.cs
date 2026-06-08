namespace Azure.ResourceManager.Monitor.Workspaces
{
    public partial class AzureResourceManagerMonitorWorkspacesContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerMonitorWorkspacesContext() { }
        public static Azure.ResourceManager.Monitor.Workspaces.AzureResourceManagerMonitorWorkspacesContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class MonitorIssueCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.Workspaces.MonitorIssueResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Workspaces.MonitorIssueResource>, System.Collections.IEnumerable
    {
        protected MonitorIssueCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.Workspaces.MonitorIssueResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string issueName, Azure.ResourceManager.Monitor.Workspaces.MonitorIssueData data, string related = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.Workspaces.MonitorIssueResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string issueName, Azure.ResourceManager.Monitor.Workspaces.MonitorIssueData data, string related = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string issueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string issueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.Workspaces.MonitorIssueResource> Get(string issueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.Workspaces.MonitorIssueResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.Workspaces.MonitorIssueResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.Workspaces.MonitorIssueResource>> GetAsync(string issueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Monitor.Workspaces.MonitorIssueResource> GetIfExists(string issueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Monitor.Workspaces.MonitorIssueResource>> GetIfExistsAsync(string issueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Monitor.Workspaces.MonitorIssueResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.Workspaces.MonitorIssueResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Monitor.Workspaces.MonitorIssueResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Workspaces.MonitorIssueResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MonitorIssueData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.MonitorIssueData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.MonitorIssueData>
    {
        public MonitorIssueData() { }
        public Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Workspaces.MonitorIssueData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.MonitorIssueData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.MonitorIssueData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Workspaces.MonitorIssueData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.MonitorIssueData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.MonitorIssueData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.MonitorIssueData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MonitorIssueResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.MonitorIssueData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.MonitorIssueData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MonitorIssueResource() { }
        public virtual Azure.ResourceManager.Monitor.Workspaces.MonitorIssueData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.Workspaces.Models.IssueInvestigationResult> AddInvestigationResult(Azure.ResourceManager.Monitor.Workspaces.Models.IssueInvestigationResult content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.Workspaces.Models.IssueInvestigationResult>> AddInvestigationResultAsync(Azure.ResourceManager.Monitor.Workspaces.Models.IssueInvestigationResult content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.Workspaces.Models.IssueRelatedAlertInfoList> AddOrUpdateAlerts(Azure.ResourceManager.Monitor.Workspaces.Models.IssueRelatedAlertInfoList content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.Workspaces.Models.IssueRelatedAlertInfoList>> AddOrUpdateAlertsAsync(Azure.ResourceManager.Monitor.Workspaces.Models.IssueRelatedAlertInfoList content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.Workspaces.Models.IssueRelatedResourceInfoList> AddOrUpdateResources(Azure.ResourceManager.Monitor.Workspaces.Models.IssueRelatedResourceInfoList content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.Workspaces.Models.IssueRelatedResourceInfoList>> AddOrUpdateResourcesAsync(Azure.ResourceManager.Monitor.Workspaces.Models.IssueRelatedResourceInfoList content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string azureMonitorWorkspaceName, string issueName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueBackgroundVisualization> FetchBackgroundVisualization(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueBackgroundVisualization>> FetchBackgroundVisualizationAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.Workspaces.Models.IssueInvestigationResult> FetchInvestigationResult(Azure.ResourceManager.Monitor.Workspaces.Models.FetchInvestigationResultContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.Workspaces.Models.IssueInvestigationResult>> FetchInvestigationResultAsync(Azure.ResourceManager.Monitor.Workspaces.Models.FetchInvestigationResultContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.Workspaces.MonitorIssueResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.Workspaces.Models.IssueRelatedAlertInfo> GetAlerts(Azure.ResourceManager.Monitor.Workspaces.Models.IssueListContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.Workspaces.Models.IssueRelatedAlertInfo> GetAlertsAsync(Azure.ResourceManager.Monitor.Workspaces.Models.IssueListContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.Workspaces.MonitorIssueResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.Workspaces.Models.IssueRelatedResourceInfo> GetResources(Azure.ResourceManager.Monitor.Workspaces.Models.IssueListContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.Workspaces.Models.IssueRelatedResourceInfo> GetResourcesAsync(Azure.ResourceManager.Monitor.Workspaces.Models.IssueListContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SetBackgroundVisualization(Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueBackgroundVisualization content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SetBackgroundVisualizationAsync(Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueBackgroundVisualization content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Monitor.Workspaces.MonitorIssueData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.MonitorIssueData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.MonitorIssueData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Workspaces.MonitorIssueData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.MonitorIssueData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.MonitorIssueData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.MonitorIssueData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.Workspaces.MonitorIssueResource> Update(Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssuePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.Workspaces.MonitorIssueResource>> UpdateAsync(Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssuePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MonitorMetricsContainerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.Workspaces.MonitorMetricsContainerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Workspaces.MonitorMetricsContainerResource>, System.Collections.IEnumerable
    {
        protected MonitorMetricsContainerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.Workspaces.MonitorMetricsContainerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string metricsContainerName, Azure.ResourceManager.Monitor.Workspaces.MonitorMetricsContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.Workspaces.MonitorMetricsContainerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string metricsContainerName, Azure.ResourceManager.Monitor.Workspaces.MonitorMetricsContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string metricsContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string metricsContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.Workspaces.MonitorMetricsContainerResource> Get(string metricsContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.Workspaces.MonitorMetricsContainerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.Workspaces.MonitorMetricsContainerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.Workspaces.MonitorMetricsContainerResource>> GetAsync(string metricsContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Monitor.Workspaces.MonitorMetricsContainerResource> GetIfExists(string metricsContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Monitor.Workspaces.MonitorMetricsContainerResource>> GetIfExistsAsync(string metricsContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Monitor.Workspaces.MonitorMetricsContainerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.Workspaces.MonitorMetricsContainerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Monitor.Workspaces.MonitorMetricsContainerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Workspaces.MonitorMetricsContainerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MonitorMetricsContainerData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.MonitorMetricsContainerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.MonitorMetricsContainerData>
    {
        public MonitorMetricsContainerData() { }
        public Azure.ResourceManager.Monitor.Workspaces.Models.MonitorMetricsContainerProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Workspaces.MonitorMetricsContainerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.MonitorMetricsContainerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.MonitorMetricsContainerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Workspaces.MonitorMetricsContainerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.MonitorMetricsContainerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.MonitorMetricsContainerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.MonitorMetricsContainerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MonitorMetricsContainerResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.MonitorMetricsContainerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.MonitorMetricsContainerData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MonitorMetricsContainerResource() { }
        public virtual Azure.ResourceManager.Monitor.Workspaces.MonitorMetricsContainerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string azureMonitorWorkspaceName, string metricsContainerName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.Workspaces.MonitorMetricsContainerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.Workspaces.MonitorMetricsContainerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Monitor.Workspaces.MonitorMetricsContainerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.MonitorMetricsContainerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.MonitorMetricsContainerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Workspaces.MonitorMetricsContainerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.MonitorMetricsContainerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.MonitorMetricsContainerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.MonitorMetricsContainerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.Workspaces.MonitorMetricsContainerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Monitor.Workspaces.MonitorMetricsContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.Workspaces.MonitorMetricsContainerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Monitor.Workspaces.MonitorMetricsContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MonitorWorkspaceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource>, System.Collections.IEnumerable
    {
        protected MonitorWorkspaceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string azureMonitorWorkspaceName, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string azureMonitorWorkspaceName, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string azureMonitorWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string azureMonitorWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource> Get(string azureMonitorWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource>> GetAsync(string azureMonitorWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource> GetIfExists(string azureMonitorWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource>> GetIfExistsAsync(string azureMonitorWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MonitorWorkspaceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData>
    {
        public MonitorWorkspaceData(Azure.Core.AzureLocation location) { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MonitorWorkspaceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MonitorWorkspaceResource() { }
        public virtual Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string azureMonitorWorkspaceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.Workspaces.MonitorIssueResource> GetMonitorIssue(string issueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.Workspaces.MonitorIssueResource>> GetMonitorIssueAsync(string issueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Monitor.Workspaces.MonitorIssueCollection GetMonitorIssues() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.Workspaces.MonitorMetricsContainerResource> GetMonitorMetricsContainer(string metricsContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.Workspaces.MonitorMetricsContainerResource>> GetMonitorMetricsContainerAsync(string metricsContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Monitor.Workspaces.MonitorMetricsContainerCollection GetMonitorMetricsContainers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource> Update(Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource>> UpdateAsync(Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class MonitorWorkspacesExtensions
    {
        public static Azure.ResourceManager.Monitor.Workspaces.MonitorIssueResource GetMonitorIssueResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Monitor.Workspaces.MonitorMetricsContainerResource GetMonitorMetricsContainerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource> GetMonitorWorkspace(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string azureMonitorWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource>> GetMonitorWorkspaceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string azureMonitorWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource GetMonitorWorkspaceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection GetMonitorWorkspaces(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource> GetMonitorWorkspaces(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource> GetMonitorWorkspacesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Monitor.Workspaces.Mocking
{
    public partial class MockableMonitorWorkspacesArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableMonitorWorkspacesArmClient() { }
        public virtual Azure.ResourceManager.Monitor.Workspaces.MonitorIssueResource GetMonitorIssueResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Monitor.Workspaces.MonitorMetricsContainerResource GetMonitorMetricsContainerResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource GetMonitorWorkspaceResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableMonitorWorkspacesResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableMonitorWorkspacesResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource> GetMonitorWorkspace(string azureMonitorWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource>> GetMonitorWorkspaceAsync(string azureMonitorWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection GetMonitorWorkspaces() { throw null; }
    }
    public partial class MockableMonitorWorkspacesSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableMonitorWorkspacesSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource> GetMonitorWorkspaces(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource> GetMonitorWorkspacesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Monitor.Workspaces.Models
{
    public static partial class ArmMonitorWorkspacesModelFactory
    {
        public static Azure.ResourceManager.Monitor.Workspaces.Models.FetchInvestigationResultContent FetchInvestigationResultContent(System.Guid investigationId = default(System.Guid)) { throw null; }
        public static Azure.ResourceManager.Monitor.Workspaces.Models.IssueCreationNotificationType IssueCreationNotificationType() { throw null; }
        public static Azure.ResourceManager.Monitor.Workspaces.Models.IssueInvestigationMetadata IssueInvestigationMetadata(System.Guid id = default(System.Guid), System.DateTimeOffset createdOn = default(System.DateTimeOffset)) { throw null; }
        public static Azure.ResourceManager.Monitor.Workspaces.Models.IssueInvestigationResult IssueInvestigationResult(string id = null, Azure.ResourceManager.Monitor.Workspaces.Models.MonitorEntityOrigin origin = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), string result = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Workspaces.Models.IssueListContent IssueListContent(string filter = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Workspaces.Models.IssueNotifications IssueNotifications(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Workspaces.Models.IssueNotificationType> updateTypes = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> actionGroupIds = null, bool? shouldExcludeDefaultActionGroups = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Monitor.Workspaces.Models.IssueNotificationType IssueNotificationType(string updateType = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Workspaces.Models.IssueRelatedAlertInfo IssueRelatedAlertInfo(Azure.Core.ResourceIdentifier id = null, Azure.ResourceManager.Monitor.Workspaces.Models.MonitorRelevanceStatus relevance = default(Azure.ResourceManager.Monitor.Workspaces.Models.MonitorRelevanceStatus), Azure.ResourceManager.Monitor.Workspaces.Models.MonitorEntityOrigin origin = null, System.DateTimeOffset addedOn = default(System.DateTimeOffset), System.DateTimeOffset lastModifiedOn = default(System.DateTimeOffset)) { throw null; }
        public static Azure.ResourceManager.Monitor.Workspaces.Models.IssueRelatedAlertInfoList IssueRelatedAlertInfoList(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Workspaces.Models.IssueRelatedAlertInfo> value = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Workspaces.Models.IssueRelatedResourceInfo IssueRelatedResourceInfo(Azure.Core.ResourceIdentifier id = null, Azure.ResourceManager.Monitor.Workspaces.Models.MonitorRelevanceStatus relevance = default(Azure.ResourceManager.Monitor.Workspaces.Models.MonitorRelevanceStatus), Azure.ResourceManager.Monitor.Workspaces.Models.MonitorEntityOrigin origin = null, System.DateTimeOffset addedOn = default(System.DateTimeOffset), System.DateTimeOffset lastModifiedOn = default(System.DateTimeOffset)) { throw null; }
        public static Azure.ResourceManager.Monitor.Workspaces.Models.IssueRelatedResourceInfoList IssueRelatedResourceInfoList(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Workspaces.Models.IssueRelatedResourceInfo> value = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Workspaces.Models.MonitorEntityOrigin MonitorEntityOrigin(string addedBy = null, Azure.ResourceManager.Monitor.Workspaces.Models.MonitorEntityType addedByType = default(Azure.ResourceManager.Monitor.Workspaces.Models.MonitorEntityType)) { throw null; }
        public static Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueBackground MonitorIssueBackground(string type = null, string text = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueBackgroundDetails> details = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueBackgroundDetails MonitorIssueBackgroundDetails(string name = null, string value = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueBackgroundVisualization MonitorIssueBackgroundVisualization(string visualization = null, Azure.ResourceManager.Monitor.Workspaces.Models.MonitorEntityOrigin origin = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Workspaces.MonitorIssueData MonitorIssueData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssuePatch MonitorIssuePatch(Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssuePatchProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssuePatchProperties MonitorIssuePatchProperties(string title = null, Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueStatus? status = default(Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueStatus?), string severity = null, System.DateTimeOffset? impactOn = default(System.DateTimeOffset?), Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueBackground background = null, Azure.ResourceManager.Monitor.Workspaces.Models.IssueNotifications notifications = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueProperties MonitorIssueProperties(string title = null, Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueStatus status = default(Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueStatus), string severity = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Workspaces.Models.IssueInvestigationMetadata> investigations = null, System.DateTimeOffset impactOn = default(System.DateTimeOffset), int investigationsCount = 0, Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueBackground background = null, Azure.ResourceManager.Monitor.Workspaces.Models.IssueNotifications notifications = null, Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceProvisioningState? provisioningState = default(Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Monitor.Workspaces.MonitorMetricsContainerData MonitorMetricsContainerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Monitor.Workspaces.Models.MonitorMetricsContainerProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Workspaces.Models.MonitorMetricsContainerProperties MonitorMetricsContainerProperties(Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceProvisioningState? provisioningState = default(Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceProvisioningState?), string version = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData MonitorWorkspaceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ETag? eTag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceDefaultIngestionSettings MonitorWorkspaceDefaultIngestionSettings(Azure.Core.ResourceIdentifier dataCollectionRuleResourceId = null, Azure.Core.ResourceIdentifier dataCollectionEndpointResourceId = null, string dataCollectionRuleImmutableId = null, string ingestionEndpointsMetrics = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceMetrics MonitorWorkspaceMetrics(string prometheusQueryEndpoint = null, string internalId = null, bool? enableAccessUsingResourcePermissions = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePatch MonitorWorkspacePatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateEndpointConnection MonitorWorkspacePrivateEndpointConnection(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateEndpointConnectionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateEndpointConnectionProperties MonitorWorkspacePrivateEndpointConnectionProperties(System.Collections.Generic.IEnumerable<string> groupIds = null, Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateLinkServiceConnectionState privateLinkServiceConnectionState = null, Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateEndpointConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateEndpointConnectionProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateLinkServiceConnectionState MonitorWorkspacePrivateLinkServiceConnectionState(Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateEndpointServiceConnectionStatus? status = default(Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateEndpointServiceConnectionStatus?), string description = null, string actionsRequired = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceProperties MonitorWorkspaceProperties(string accountId = null, Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceMetrics metrics = null, Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceProvisioningState? provisioningState = default(Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceProvisioningState?), Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceDefaultIngestionSettings defaultIngestionSettings = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateEndpointConnection> privateEndpointConnections = null, Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePublicNetworkAccess?)) { throw null; }
        public static Azure.ResourceManager.Monitor.Workspaces.Models.OnChangeNotificationType OnChangeNotificationType() { throw null; }
        public static Azure.ResourceManager.Monitor.Workspaces.Models.TimeBasedUpdatesNotificationType TimeBasedUpdatesNotificationType(string updateInterval = null) { throw null; }
    }
    public partial class FetchInvestigationResultContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.FetchInvestigationResultContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.FetchInvestigationResultContent>
    {
        public FetchInvestigationResultContent(System.Guid investigationId) { }
        public System.Guid InvestigationId { get { throw null; } }
        protected virtual Azure.ResourceManager.Monitor.Workspaces.Models.FetchInvestigationResultContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Workspaces.Models.FetchInvestigationResultContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Workspaces.Models.FetchInvestigationResultContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.FetchInvestigationResultContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.FetchInvestigationResultContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Workspaces.Models.FetchInvestigationResultContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.FetchInvestigationResultContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.FetchInvestigationResultContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.FetchInvestigationResultContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IssueCreationNotificationType : Azure.ResourceManager.Monitor.Workspaces.Models.IssueNotificationType, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueCreationNotificationType>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueCreationNotificationType>
    {
        public IssueCreationNotificationType() { }
        protected override Azure.ResourceManager.Monitor.Workspaces.Models.IssueNotificationType JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Monitor.Workspaces.Models.IssueNotificationType PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Workspaces.Models.IssueCreationNotificationType System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueCreationNotificationType>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueCreationNotificationType>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Workspaces.Models.IssueCreationNotificationType System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueCreationNotificationType>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueCreationNotificationType>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueCreationNotificationType>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IssueInvestigationMetadata : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueInvestigationMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueInvestigationMetadata>
    {
        internal IssueInvestigationMetadata() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.Guid Id { get { throw null; } }
        protected virtual Azure.ResourceManager.Monitor.Workspaces.Models.IssueInvestigationMetadata JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Workspaces.Models.IssueInvestigationMetadata PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Workspaces.Models.IssueInvestigationMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueInvestigationMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueInvestigationMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Workspaces.Models.IssueInvestigationMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueInvestigationMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueInvestigationMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueInvestigationMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IssueInvestigationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueInvestigationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueInvestigationResult>
    {
        public IssueInvestigationResult(string id, string result) { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Workspaces.Models.MonitorEntityOrigin Origin { get { throw null; } set { } }
        public string Result { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Monitor.Workspaces.Models.IssueInvestigationResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Workspaces.Models.IssueInvestigationResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Workspaces.Models.IssueInvestigationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueInvestigationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueInvestigationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Workspaces.Models.IssueInvestigationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueInvestigationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueInvestigationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueInvestigationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IssueListContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueListContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueListContent>
    {
        public IssueListContent() { }
        public string Filter { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Monitor.Workspaces.Models.IssueListContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Workspaces.Models.IssueListContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Workspaces.Models.IssueListContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueListContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueListContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Workspaces.Models.IssueListContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueListContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueListContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueListContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IssueNotifications : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueNotifications>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueNotifications>
    {
        public IssueNotifications() { }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> ActionGroupIds { get { throw null; } }
        public bool? ShouldExcludeDefaultActionGroups { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Workspaces.Models.IssueNotificationType> UpdateTypes { get { throw null; } }
        protected virtual Azure.ResourceManager.Monitor.Workspaces.Models.IssueNotifications JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Workspaces.Models.IssueNotifications PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Workspaces.Models.IssueNotifications System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueNotifications>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueNotifications>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Workspaces.Models.IssueNotifications System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueNotifications>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueNotifications>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueNotifications>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class IssueNotificationType : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueNotificationType>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueNotificationType>
    {
        internal IssueNotificationType() { }
        protected virtual Azure.ResourceManager.Monitor.Workspaces.Models.IssueNotificationType JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Workspaces.Models.IssueNotificationType PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Workspaces.Models.IssueNotificationType System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueNotificationType>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueNotificationType>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Workspaces.Models.IssueNotificationType System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueNotificationType>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueNotificationType>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueNotificationType>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IssueRelatedAlertInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueRelatedAlertInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueRelatedAlertInfo>
    {
        public IssueRelatedAlertInfo(Azure.Core.ResourceIdentifier id, Azure.ResourceManager.Monitor.Workspaces.Models.MonitorRelevanceStatus relevance) { }
        public System.DateTimeOffset AddedOn { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public System.DateTimeOffset LastModifiedOn { get { throw null; } }
        public Azure.ResourceManager.Monitor.Workspaces.Models.MonitorEntityOrigin Origin { get { throw null; } }
        public Azure.ResourceManager.Monitor.Workspaces.Models.MonitorRelevanceStatus Relevance { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Monitor.Workspaces.Models.IssueRelatedAlertInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Workspaces.Models.IssueRelatedAlertInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Workspaces.Models.IssueRelatedAlertInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueRelatedAlertInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueRelatedAlertInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Workspaces.Models.IssueRelatedAlertInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueRelatedAlertInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueRelatedAlertInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueRelatedAlertInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IssueRelatedAlertInfoList : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueRelatedAlertInfoList>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueRelatedAlertInfoList>
    {
        public IssueRelatedAlertInfoList(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Workspaces.Models.IssueRelatedAlertInfo> value) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Workspaces.Models.IssueRelatedAlertInfo> Value { get { throw null; } }
        protected virtual Azure.ResourceManager.Monitor.Workspaces.Models.IssueRelatedAlertInfoList JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Workspaces.Models.IssueRelatedAlertInfoList PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Workspaces.Models.IssueRelatedAlertInfoList System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueRelatedAlertInfoList>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueRelatedAlertInfoList>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Workspaces.Models.IssueRelatedAlertInfoList System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueRelatedAlertInfoList>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueRelatedAlertInfoList>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueRelatedAlertInfoList>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IssueRelatedResourceInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueRelatedResourceInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueRelatedResourceInfo>
    {
        public IssueRelatedResourceInfo(Azure.Core.ResourceIdentifier id, Azure.ResourceManager.Monitor.Workspaces.Models.MonitorRelevanceStatus relevance) { }
        public System.DateTimeOffset AddedOn { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public System.DateTimeOffset LastModifiedOn { get { throw null; } }
        public Azure.ResourceManager.Monitor.Workspaces.Models.MonitorEntityOrigin Origin { get { throw null; } }
        public Azure.ResourceManager.Monitor.Workspaces.Models.MonitorRelevanceStatus Relevance { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Monitor.Workspaces.Models.IssueRelatedResourceInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Workspaces.Models.IssueRelatedResourceInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Workspaces.Models.IssueRelatedResourceInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueRelatedResourceInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueRelatedResourceInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Workspaces.Models.IssueRelatedResourceInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueRelatedResourceInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueRelatedResourceInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueRelatedResourceInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IssueRelatedResourceInfoList : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueRelatedResourceInfoList>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueRelatedResourceInfoList>
    {
        public IssueRelatedResourceInfoList(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Workspaces.Models.IssueRelatedResourceInfo> value) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Workspaces.Models.IssueRelatedResourceInfo> Value { get { throw null; } }
        protected virtual Azure.ResourceManager.Monitor.Workspaces.Models.IssueRelatedResourceInfoList JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Workspaces.Models.IssueRelatedResourceInfoList PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Workspaces.Models.IssueRelatedResourceInfoList System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueRelatedResourceInfoList>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueRelatedResourceInfoList>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Workspaces.Models.IssueRelatedResourceInfoList System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueRelatedResourceInfoList>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueRelatedResourceInfoList>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.IssueRelatedResourceInfoList>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MonitorEntityOrigin : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorEntityOrigin>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorEntityOrigin>
    {
        public MonitorEntityOrigin(string addedBy, Azure.ResourceManager.Monitor.Workspaces.Models.MonitorEntityType addedByType) { }
        public string AddedBy { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Workspaces.Models.MonitorEntityType AddedByType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Monitor.Workspaces.Models.MonitorEntityOrigin JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Workspaces.Models.MonitorEntityOrigin PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Workspaces.Models.MonitorEntityOrigin System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorEntityOrigin>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorEntityOrigin>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Workspaces.Models.MonitorEntityOrigin System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorEntityOrigin>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorEntityOrigin>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorEntityOrigin>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MonitorEntityType : System.IEquatable<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorEntityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MonitorEntityType(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Workspaces.Models.MonitorEntityType Automatic { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Workspaces.Models.MonitorEntityType Manual { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Workspaces.Models.MonitorEntityType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Workspaces.Models.MonitorEntityType left, Azure.ResourceManager.Monitor.Workspaces.Models.MonitorEntityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Workspaces.Models.MonitorEntityType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Workspaces.Models.MonitorEntityType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Workspaces.Models.MonitorEntityType left, Azure.ResourceManager.Monitor.Workspaces.Models.MonitorEntityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MonitorIssueBackground : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueBackground>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueBackground>
    {
        public MonitorIssueBackground() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueBackgroundDetails> Details { get { throw null; } }
        public string Text { get { throw null; } set { } }
        public string Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueBackground JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueBackground PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueBackground System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueBackground>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueBackground>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueBackground System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueBackground>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueBackground>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueBackground>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MonitorIssueBackgroundDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueBackgroundDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueBackgroundDetails>
    {
        public MonitorIssueBackgroundDetails(string name, string value) { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueBackgroundDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueBackgroundDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueBackgroundDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueBackgroundDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueBackgroundDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueBackgroundDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueBackgroundDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueBackgroundDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueBackgroundDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MonitorIssueBackgroundVisualization : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueBackgroundVisualization>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueBackgroundVisualization>
    {
        public MonitorIssueBackgroundVisualization(string visualization) { }
        public Azure.ResourceManager.Monitor.Workspaces.Models.MonitorEntityOrigin Origin { get { throw null; } }
        public string Visualization { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueBackgroundVisualization JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueBackgroundVisualization PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueBackgroundVisualization System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueBackgroundVisualization>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueBackgroundVisualization>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueBackgroundVisualization System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueBackgroundVisualization>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueBackgroundVisualization>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueBackgroundVisualization>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MonitorIssuePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssuePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssuePatch>
    {
        public MonitorIssuePatch() { }
        public Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssuePatchProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssuePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssuePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssuePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssuePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssuePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssuePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssuePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssuePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssuePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MonitorIssuePatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssuePatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssuePatchProperties>
    {
        public MonitorIssuePatchProperties() { }
        public Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueBackground Background { get { throw null; } set { } }
        public System.DateTimeOffset? ImpactOn { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Workspaces.Models.IssueNotifications Notifications { get { throw null; } set { } }
        public string Severity { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueStatus? Status { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssuePatchProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssuePatchProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssuePatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssuePatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssuePatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssuePatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssuePatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssuePatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssuePatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MonitorIssueProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueProperties>
    {
        public MonitorIssueProperties(string title, Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueStatus status, string severity, System.DateTimeOffset impactOn) { }
        public Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueBackground Background { get { throw null; } set { } }
        public System.DateTimeOffset ImpactOn { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Monitor.Workspaces.Models.IssueInvestigationMetadata> Investigations { get { throw null; } }
        public int InvestigationsCount { get { throw null; } }
        public Azure.ResourceManager.Monitor.Workspaces.Models.IssueNotifications Notifications { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceProvisioningState? ProvisioningState { get { throw null; } }
        public string Severity { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueStatus Status { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MonitorIssueStatus : System.IEquatable<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MonitorIssueStatus(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueStatus Closed { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueStatus Mitigated { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueStatus New { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueStatus left, Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueStatus left, Azure.ResourceManager.Monitor.Workspaces.Models.MonitorIssueStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MonitorMetricsContainerProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorMetricsContainerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorMetricsContainerProperties>
    {
        public MonitorMetricsContainerProperties() { }
        public Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceProvisioningState? ProvisioningState { get { throw null; } }
        public string Version { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Monitor.Workspaces.Models.MonitorMetricsContainerProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Workspaces.Models.MonitorMetricsContainerProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Workspaces.Models.MonitorMetricsContainerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorMetricsContainerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorMetricsContainerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Workspaces.Models.MonitorMetricsContainerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorMetricsContainerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorMetricsContainerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorMetricsContainerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MonitorRelevanceStatus : System.IEquatable<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorRelevanceStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MonitorRelevanceStatus(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Workspaces.Models.MonitorRelevanceStatus Irrelevant { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Workspaces.Models.MonitorRelevanceStatus None { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Workspaces.Models.MonitorRelevanceStatus Relevant { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Workspaces.Models.MonitorRelevanceStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Workspaces.Models.MonitorRelevanceStatus left, Azure.ResourceManager.Monitor.Workspaces.Models.MonitorRelevanceStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Workspaces.Models.MonitorRelevanceStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Workspaces.Models.MonitorRelevanceStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Workspaces.Models.MonitorRelevanceStatus left, Azure.ResourceManager.Monitor.Workspaces.Models.MonitorRelevanceStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MonitorWorkspaceDefaultIngestionSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceDefaultIngestionSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceDefaultIngestionSettings>
    {
        internal MonitorWorkspaceDefaultIngestionSettings() { }
        public Azure.Core.ResourceIdentifier DataCollectionEndpointResourceId { get { throw null; } }
        public string DataCollectionRuleImmutableId { get { throw null; } }
        public Azure.Core.ResourceIdentifier DataCollectionRuleResourceId { get { throw null; } }
        public string IngestionEndpointsMetrics { get { throw null; } }
        protected virtual Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceDefaultIngestionSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceDefaultIngestionSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceDefaultIngestionSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceDefaultIngestionSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceDefaultIngestionSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceDefaultIngestionSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceDefaultIngestionSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceDefaultIngestionSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceDefaultIngestionSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MonitorWorkspaceMetrics : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceMetrics>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceMetrics>
    {
        public MonitorWorkspaceMetrics() { }
        public bool? EnableAccessUsingResourcePermissions { get { throw null; } set { } }
        public string InternalId { get { throw null; } }
        public string PrometheusQueryEndpoint { get { throw null; } }
        protected virtual Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceMetrics JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceMetrics PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceMetrics System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceMetrics>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceMetrics>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceMetrics System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceMetrics>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceMetrics>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceMetrics>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MonitorWorkspacePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePatch>
    {
        public MonitorWorkspacePatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MonitorWorkspacePrivateEndpointConnection : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateEndpointConnection>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateEndpointConnection>
    {
        internal MonitorWorkspacePrivateEndpointConnection() { }
        public Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateEndpointConnectionProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateEndpointConnection System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateEndpointConnection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateEndpointConnection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateEndpointConnection System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateEndpointConnection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateEndpointConnection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateEndpointConnection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MonitorWorkspacePrivateEndpointConnectionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateEndpointConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateEndpointConnectionProperties>
    {
        internal MonitorWorkspacePrivateEndpointConnectionProperties() { }
        public System.Collections.Generic.IReadOnlyList<string> GroupIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } }
        public Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateEndpointConnectionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateEndpointConnectionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateEndpointConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateEndpointConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateEndpointConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateEndpointConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateEndpointConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateEndpointConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateEndpointConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MonitorWorkspacePrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MonitorWorkspacePrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateEndpointConnectionProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateEndpointConnectionProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MonitorWorkspacePrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MonitorWorkspacePrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateEndpointServiceConnectionStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateEndpointServiceConnectionStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MonitorWorkspacePrivateLinkServiceConnectionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateLinkServiceConnectionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateLinkServiceConnectionState>
    {
        internal MonitorWorkspacePrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } }
        public string Description { get { throw null; } }
        public Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateEndpointServiceConnectionStatus? Status { get { throw null; } }
        protected virtual Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateLinkServiceConnectionState JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateLinkServiceConnectionState PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateLinkServiceConnectionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateLinkServiceConnectionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateLinkServiceConnectionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateLinkServiceConnectionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateLinkServiceConnectionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateLinkServiceConnectionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateLinkServiceConnectionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MonitorWorkspaceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceProperties>
    {
        public MonitorWorkspaceProperties() { }
        public string AccountId { get { throw null; } }
        public Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceDefaultIngestionSettings DefaultIngestionSettings { get { throw null; } }
        public Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceMetrics Metrics { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePrivateEndpointConnection> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MonitorWorkspaceProvisioningState : System.IEquatable<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MonitorWorkspaceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceProvisioningState left, Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceProvisioningState left, Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspaceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MonitorWorkspacePublicNetworkAccess : System.IEquatable<Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MonitorWorkspacePublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePublicNetworkAccess other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePublicNetworkAccess left, Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePublicNetworkAccess (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePublicNetworkAccess? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePublicNetworkAccess left, Azure.ResourceManager.Monitor.Workspaces.Models.MonitorWorkspacePublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OnChangeNotificationType : Azure.ResourceManager.Monitor.Workspaces.Models.IssueNotificationType, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.OnChangeNotificationType>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.OnChangeNotificationType>
    {
        public OnChangeNotificationType() { }
        protected override Azure.ResourceManager.Monitor.Workspaces.Models.IssueNotificationType JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Monitor.Workspaces.Models.IssueNotificationType PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Workspaces.Models.OnChangeNotificationType System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.OnChangeNotificationType>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.OnChangeNotificationType>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Workspaces.Models.OnChangeNotificationType System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.OnChangeNotificationType>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.OnChangeNotificationType>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.OnChangeNotificationType>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TimeBasedUpdatesNotificationType : Azure.ResourceManager.Monitor.Workspaces.Models.IssueNotificationType, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.TimeBasedUpdatesNotificationType>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.TimeBasedUpdatesNotificationType>
    {
        public TimeBasedUpdatesNotificationType(string updateInterval) { }
        public string UpdateInterval { get { throw null; } set { } }
        protected override Azure.ResourceManager.Monitor.Workspaces.Models.IssueNotificationType JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Monitor.Workspaces.Models.IssueNotificationType PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Workspaces.Models.TimeBasedUpdatesNotificationType System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.TimeBasedUpdatesNotificationType>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Workspaces.Models.TimeBasedUpdatesNotificationType>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Workspaces.Models.TimeBasedUpdatesNotificationType System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.TimeBasedUpdatesNotificationType>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.TimeBasedUpdatesNotificationType>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Workspaces.Models.TimeBasedUpdatesNotificationType>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
