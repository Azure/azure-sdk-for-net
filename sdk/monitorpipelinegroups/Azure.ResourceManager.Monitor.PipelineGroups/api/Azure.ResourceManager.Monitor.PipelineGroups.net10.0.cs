namespace Azure.ResourceManager.Monitor.PipelineGroups
{
    public partial class AzureResourceManagerMonitorPipelineGroupsContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerMonitorPipelineGroupsContext() { }
        public static Azure.ResourceManager.Monitor.PipelineGroups.AzureResourceManagerMonitorPipelineGroupsContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class MonitorPipelineGroupsExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Monitor.PipelineGroups.PipelineGroupResource> GetPipelineGroup(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string pipelineGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.PipelineGroups.PipelineGroupResource>> GetPipelineGroupAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string pipelineGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Monitor.PipelineGroups.PipelineGroupResource GetPipelineGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Monitor.PipelineGroups.PipelineGroupCollection GetPipelineGroups(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Monitor.PipelineGroups.PipelineGroupResource> GetPipelineGroups(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Monitor.PipelineGroups.PipelineGroupResource> GetPipelineGroupsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PipelineGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.PipelineGroups.PipelineGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.PipelineGroups.PipelineGroupResource>, System.Collections.IEnumerable
    {
        protected PipelineGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.PipelineGroups.PipelineGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string pipelineGroupName, Azure.ResourceManager.Monitor.PipelineGroups.PipelineGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.PipelineGroups.PipelineGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string pipelineGroupName, Azure.ResourceManager.Monitor.PipelineGroups.PipelineGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string pipelineGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string pipelineGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.PipelineGroups.PipelineGroupResource> Get(string pipelineGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.PipelineGroups.PipelineGroupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.PipelineGroups.PipelineGroupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.PipelineGroups.PipelineGroupResource>> GetAsync(string pipelineGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Monitor.PipelineGroups.PipelineGroupResource> GetIfExists(string pipelineGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Monitor.PipelineGroups.PipelineGroupResource>> GetIfExistsAsync(string pipelineGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Monitor.PipelineGroups.PipelineGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.PipelineGroups.PipelineGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Monitor.PipelineGroups.PipelineGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.PipelineGroups.PipelineGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PipelineGroupData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.PipelineGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.PipelineGroupData>
    {
        public PipelineGroupData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Resources.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.PipelineGroups.PipelineGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.PipelineGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.PipelineGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.PipelineGroups.PipelineGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.PipelineGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.PipelineGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.PipelineGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PipelineGroupResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.PipelineGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.PipelineGroupData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PipelineGroupResource() { }
        public virtual Azure.ResourceManager.Monitor.PipelineGroups.PipelineGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.PipelineGroups.PipelineGroupResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.PipelineGroups.PipelineGroupResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string pipelineGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.PipelineGroups.PipelineGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.PipelineGroups.PipelineGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.PipelineGroups.PipelineGroupResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.PipelineGroups.PipelineGroupResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.PipelineGroups.PipelineGroupResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.PipelineGroups.PipelineGroupResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Monitor.PipelineGroups.PipelineGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.PipelineGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.PipelineGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.PipelineGroups.PipelineGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.PipelineGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.PipelineGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.PipelineGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.PipelineGroups.PipelineGroupResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Monitor.PipelineGroups.PipelineGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.PipelineGroups.PipelineGroupResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Monitor.PipelineGroups.PipelineGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Monitor.PipelineGroups.Mocking
{
    public partial class MockableMonitorPipelineGroupsArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableMonitorPipelineGroupsArmClient() { }
        public virtual Azure.ResourceManager.Monitor.PipelineGroups.PipelineGroupResource GetPipelineGroupResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableMonitorPipelineGroupsResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableMonitorPipelineGroupsResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.PipelineGroups.PipelineGroupResource> GetPipelineGroup(string pipelineGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.PipelineGroups.PipelineGroupResource>> GetPipelineGroupAsync(string pipelineGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Monitor.PipelineGroups.PipelineGroupCollection GetPipelineGroups() { throw null; }
    }
    public partial class MockableMonitorPipelineGroupsSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableMonitorPipelineGroupsSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.PipelineGroups.PipelineGroupResource> GetPipelineGroups(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.PipelineGroups.PipelineGroupResource> GetPipelineGroupsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Monitor.PipelineGroups.Models
{
    public static partial class ArmMonitorPipelineGroupsModelFactory
    {
        public static Azure.ResourceManager.Monitor.PipelineGroups.PipelineGroupData PipelineGroupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupProperties properties = null, Azure.ResourceManager.Resources.Models.ExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupExecutionPlacement PipelineGroupExecutionPlacement(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupPlacementConstraint> constraints = null, int? distributionMaxInstancesPerHost = default(int?)) { throw null; }
        public static Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupPipeline PipelineGroupPipeline(string name = null, Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupPipelineType type = default(Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupPipelineType), System.Collections.Generic.IEnumerable<string> receivers = null, System.Collections.Generic.IEnumerable<string> processors = null, System.Collections.Generic.IEnumerable<string> exporters = null) { throw null; }
        public static Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupPlacementConstraint PipelineGroupPlacementConstraint(string capability = null, Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupCapabilityOperator @operator = default(Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupCapabilityOperator), System.Collections.Generic.IEnumerable<string> values = null) { throw null; }
        public static Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupProperties PipelineGroupProperties(int? replicas = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupReceiver> receivers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupProcessor> processors = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupExporter> exporters = null, Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupService service = null, Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupExecutionPlacement executionPlacement = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupTlsConfiguration> tlsConfigurations = null, Azure.ResourceManager.Monitor.PipelineGroups.Models.MonitorPipelineGroupProvisioningState? provisioningState = default(Azure.ResourceManager.Monitor.PipelineGroups.Models.MonitorPipelineGroupProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupSchemaMap PipelineGroupSchemaMap(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupRecordMap> recordMap = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupResourceMap> resourceMap = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupScopeMap> scopeMap = null) { throw null; }
        public static Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupService PipelineGroupService(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupPipeline> pipelines = null, string persistencePersistentVolumeName = null) { throw null; }
        public static Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupSyslogReceiver PipelineGroupSyslogReceiver(string endpoint = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupAllowedFormat> allowedFormats = null, Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupTransportProtocol? transportProtocol = default(Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupTransportProtocol?), bool? allowSkipPriHeader = default(bool?)) { throw null; }
    }
    public partial class AzureMonitorWorkspaceLogsApiConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.AzureMonitorWorkspaceLogsApiConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.AzureMonitorWorkspaceLogsApiConfig>
    {
        public AzureMonitorWorkspaceLogsApiConfig(string dataCollectionEndpointUri, string stream, string dataCollectionRuleId, Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupSchemaMap schema) { }
        public string DataCollectionEndpointUri { get { throw null; } set { } }
        public string DataCollectionRuleId { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupSchemaMap Schema { get { throw null; } set { } }
        public string Stream { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Monitor.PipelineGroups.Models.AzureMonitorWorkspaceLogsApiConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.PipelineGroups.Models.AzureMonitorWorkspaceLogsApiConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.PipelineGroups.Models.AzureMonitorWorkspaceLogsApiConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.AzureMonitorWorkspaceLogsApiConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.AzureMonitorWorkspaceLogsApiConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.PipelineGroups.Models.AzureMonitorWorkspaceLogsApiConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.AzureMonitorWorkspaceLogsApiConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.AzureMonitorWorkspaceLogsApiConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.AzureMonitorWorkspaceLogsApiConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureMonitorWorkspaceLogsExporter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.AzureMonitorWorkspaceLogsExporter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.AzureMonitorWorkspaceLogsExporter>
    {
        public AzureMonitorWorkspaceLogsExporter(Azure.ResourceManager.Monitor.PipelineGroups.Models.AzureMonitorWorkspaceLogsApiConfig api) { }
        public Azure.ResourceManager.Monitor.PipelineGroups.Models.AzureMonitorWorkspaceLogsApiConfig Api { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupExporterPersistenceConfiguration Persistence { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Monitor.PipelineGroups.Models.AzureMonitorWorkspaceLogsExporter JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.PipelineGroups.Models.AzureMonitorWorkspaceLogsExporter PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.PipelineGroups.Models.AzureMonitorWorkspaceLogsExporter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.AzureMonitorWorkspaceLogsExporter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.AzureMonitorWorkspaceLogsExporter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.PipelineGroups.Models.AzureMonitorWorkspaceLogsExporter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.AzureMonitorWorkspaceLogsExporter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.AzureMonitorWorkspaceLogsExporter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.AzureMonitorWorkspaceLogsExporter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MonitorPipelineGroupProvisioningState : System.IEquatable<Azure.ResourceManager.Monitor.PipelineGroups.Models.MonitorPipelineGroupProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MonitorPipelineGroupProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.PipelineGroups.Models.MonitorPipelineGroupProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Monitor.PipelineGroups.Models.MonitorPipelineGroupProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Monitor.PipelineGroups.Models.MonitorPipelineGroupProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Monitor.PipelineGroups.Models.MonitorPipelineGroupProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Monitor.PipelineGroups.Models.MonitorPipelineGroupProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.PipelineGroups.Models.MonitorPipelineGroupProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.PipelineGroups.Models.MonitorPipelineGroupProvisioningState left, Azure.ResourceManager.Monitor.PipelineGroups.Models.MonitorPipelineGroupProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.PipelineGroups.Models.MonitorPipelineGroupProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.PipelineGroups.Models.MonitorPipelineGroupProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.PipelineGroups.Models.MonitorPipelineGroupProvisioningState left, Azure.ResourceManager.Monitor.PipelineGroups.Models.MonitorPipelineGroupProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PipelineGroupAllowedFormat : System.IEquatable<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupAllowedFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PipelineGroupAllowedFormat(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupAllowedFormat All { get { throw null; } }
        public static Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupAllowedFormat CefRfc3164 { get { throw null; } }
        public static Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupAllowedFormat CefRfc5424 { get { throw null; } }
        public static Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupAllowedFormat RawCef { get { throw null; } }
        public static Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupAllowedFormat SyslogRfc3164 { get { throw null; } }
        public static Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupAllowedFormat SyslogRfc5424 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupAllowedFormat other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupAllowedFormat left, Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupAllowedFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupAllowedFormat (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupAllowedFormat? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupAllowedFormat left, Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupAllowedFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PipelineGroupBatchProcessor : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupBatchProcessor>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupBatchProcessor>
    {
        public PipelineGroupBatchProcessor() { }
        public int? BatchSize { get { throw null; } set { } }
        public int? TimeoutInMilliseconds { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupBatchProcessor JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupBatchProcessor PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupBatchProcessor System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupBatchProcessor>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupBatchProcessor>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupBatchProcessor System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupBatchProcessor>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupBatchProcessor>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupBatchProcessor>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PipelineGroupCapabilityOperator : System.IEquatable<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupCapabilityOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PipelineGroupCapabilityOperator(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupCapabilityOperator DoesNotExist { get { throw null; } }
        public static Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupCapabilityOperator Exists { get { throw null; } }
        public static Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupCapabilityOperator In { get { throw null; } }
        public static Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupCapabilityOperator NotIn { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupCapabilityOperator other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupCapabilityOperator left, Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupCapabilityOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupCapabilityOperator (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupCapabilityOperator? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupCapabilityOperator left, Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupCapabilityOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PipelineGroupCertificateSource : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupCertificateSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupCertificateSource>
    {
        public PipelineGroupCertificateSource(Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupCertificateSourceType type, string location, string subLocation) { }
        public string Location { get { throw null; } set { } }
        public string SubLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupCertificateSourceType Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupCertificateSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupCertificateSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupCertificateSource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupCertificateSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupCertificateSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupCertificateSource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupCertificateSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupCertificateSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupCertificateSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PipelineGroupCertificateSourceType : System.IEquatable<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupCertificateSourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PipelineGroupCertificateSourceType(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupCertificateSourceType KubernetesConfigMap { get { throw null; } }
        public static Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupCertificateSourceType KubernetesSecret { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupCertificateSourceType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupCertificateSourceType left, Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupCertificateSourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupCertificateSourceType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupCertificateSourceType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupCertificateSourceType left, Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupCertificateSourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PipelineGroupCertificateWithKey : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupCertificateWithKey>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupCertificateWithKey>
    {
        public PipelineGroupCertificateWithKey(Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupCertificateSource certificate, Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupPrivateKeySource privateKey) { }
        public Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupCertificateSource Certificate { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupPrivateKeySource PrivateKey { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupCertificateWithKey JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupCertificateWithKey PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupCertificateWithKey System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupCertificateWithKey>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupCertificateWithKey>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupCertificateWithKey System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupCertificateWithKey>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupCertificateWithKey>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupCertificateWithKey>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PipelineGroupExecutionPlacement : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupExecutionPlacement>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupExecutionPlacement>
    {
        public PipelineGroupExecutionPlacement() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupPlacementConstraint> Constraints { get { throw null; } }
        public int? DistributionMaxInstancesPerHost { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupExecutionPlacement JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupExecutionPlacement PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupExecutionPlacement System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupExecutionPlacement>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupExecutionPlacement>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupExecutionPlacement System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupExecutionPlacement>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupExecutionPlacement>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupExecutionPlacement>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PipelineGroupExporter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupExporter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupExporter>
    {
        public PipelineGroupExporter(Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupExporterType type, string name) { }
        public Azure.ResourceManager.Monitor.PipelineGroups.Models.AzureMonitorWorkspaceLogsExporter AzureMonitorWorkspaceLogs { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupExporterType Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupExporter JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupExporter PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupExporter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupExporter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupExporter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupExporter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupExporter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupExporter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupExporter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PipelineGroupExporterPersistenceConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupExporterPersistenceConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupExporterPersistenceConfiguration>
    {
        public PipelineGroupExporterPersistenceConfiguration() { }
        public int? MaxStorageUsageInGigabytes { get { throw null; } set { } }
        public int? RetentionPeriodInMinutes { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupExporterPersistenceConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupExporterPersistenceConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupExporterPersistenceConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupExporterPersistenceConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupExporterPersistenceConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupExporterPersistenceConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupExporterPersistenceConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupExporterPersistenceConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupExporterPersistenceConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PipelineGroupExporterType : System.IEquatable<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupExporterType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PipelineGroupExporterType(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupExporterType AzureMonitorWorkspaceLogs { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupExporterType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupExporterType left, Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupExporterType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupExporterType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupExporterType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupExporterType left, Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupExporterType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PipelineGroupPipeline : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupPipeline>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupPipeline>
    {
        public PipelineGroupPipeline(string name, Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupPipelineType type, System.Collections.Generic.IEnumerable<string> receivers, System.Collections.Generic.IEnumerable<string> exporters) { }
        public System.Collections.Generic.IList<string> Exporters { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Processors { get { throw null; } }
        public System.Collections.Generic.IList<string> Receivers { get { throw null; } }
        public Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupPipelineType Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupPipeline JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupPipeline PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupPipeline System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupPipeline>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupPipeline>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupPipeline System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupPipeline>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupPipeline>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupPipeline>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PipelineGroupPipelineType : System.IEquatable<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupPipelineType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PipelineGroupPipelineType(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupPipelineType Logs { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupPipelineType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupPipelineType left, Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupPipelineType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupPipelineType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupPipelineType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupPipelineType left, Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupPipelineType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PipelineGroupPlacementConstraint : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupPlacementConstraint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupPlacementConstraint>
    {
        public PipelineGroupPlacementConstraint(string capability, Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupCapabilityOperator @operator) { }
        public string Capability { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupCapabilityOperator Operator { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
        protected virtual Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupPlacementConstraint JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupPlacementConstraint PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupPlacementConstraint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupPlacementConstraint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupPlacementConstraint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupPlacementConstraint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupPlacementConstraint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupPlacementConstraint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupPlacementConstraint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PipelineGroupPrivateKeySource : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupPrivateKeySource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupPrivateKeySource>
    {
        public PipelineGroupPrivateKeySource(Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupPrivateKeySourceType type, string location, string subLocation) { }
        public string Location { get { throw null; } set { } }
        public string SubLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupPrivateKeySourceType Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupPrivateKeySource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupPrivateKeySource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupPrivateKeySource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupPrivateKeySource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupPrivateKeySource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupPrivateKeySource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupPrivateKeySource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupPrivateKeySource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupPrivateKeySource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PipelineGroupPrivateKeySourceType : System.IEquatable<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupPrivateKeySourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PipelineGroupPrivateKeySourceType(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupPrivateKeySourceType KubernetesSecret { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupPrivateKeySourceType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupPrivateKeySourceType left, Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupPrivateKeySourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupPrivateKeySourceType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupPrivateKeySourceType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupPrivateKeySourceType left, Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupPrivateKeySourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PipelineGroupProcessor : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupProcessor>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupProcessor>
    {
        public PipelineGroupProcessor(Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupProcessorType type, string name) { }
        public Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupBatchProcessor Batch { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string TransformStatement { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupProcessorType Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupProcessor JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupProcessor PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupProcessor System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupProcessor>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupProcessor>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupProcessor System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupProcessor>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupProcessor>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupProcessor>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PipelineGroupProcessorType : System.IEquatable<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupProcessorType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PipelineGroupProcessorType(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupProcessorType Batch { get { throw null; } }
        public static Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupProcessorType MicrosoftCommonSecurityLog { get { throw null; } }
        public static Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupProcessorType MicrosoftSyslog { get { throw null; } }
        public static Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupProcessorType TransformLanguage { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupProcessorType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupProcessorType left, Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupProcessorType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupProcessorType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupProcessorType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupProcessorType left, Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupProcessorType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PipelineGroupProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupProperties>
    {
        public PipelineGroupProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupReceiver> receivers, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupProcessor> processors, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupExporter> exporters, Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupService service) { }
        public Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupExecutionPlacement ExecutionPlacement { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupExporter> Exporters { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupProcessor> Processors { get { throw null; } }
        public Azure.ResourceManager.Monitor.PipelineGroups.Models.MonitorPipelineGroupProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupReceiver> Receivers { get { throw null; } }
        public int? Replicas { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupService Service { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupTlsConfiguration> TlsConfigurations { get { throw null; } }
        protected virtual Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PipelineGroupReceiver : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupReceiver>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupReceiver>
    {
        public PipelineGroupReceiver(Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupReceiverType type, string name) { }
        public string Name { get { throw null; } set { } }
        public string OtlpEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupSyslogReceiver Syslog { get { throw null; } set { } }
        public string TlsConfigurationName { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupReceiverType Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupReceiver JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupReceiver PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupReceiver System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupReceiver>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupReceiver>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupReceiver System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupReceiver>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupReceiver>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupReceiver>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PipelineGroupReceiverType : System.IEquatable<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupReceiverType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PipelineGroupReceiverType(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupReceiverType Otlp { get { throw null; } }
        public static Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupReceiverType Syslog { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupReceiverType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupReceiverType left, Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupReceiverType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupReceiverType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupReceiverType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupReceiverType left, Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupReceiverType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PipelineGroupRecordMap : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupRecordMap>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupRecordMap>
    {
        public PipelineGroupRecordMap(string from, string to) { }
        public string From { get { throw null; } set { } }
        public string To { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupRecordMap JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupRecordMap PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupRecordMap System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupRecordMap>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupRecordMap>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupRecordMap System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupRecordMap>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupRecordMap>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupRecordMap>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PipelineGroupResourceMap : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupResourceMap>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupResourceMap>
    {
        public PipelineGroupResourceMap(string from, string to) { }
        public string From { get { throw null; } set { } }
        public string To { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupResourceMap JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupResourceMap PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupResourceMap System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupResourceMap>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupResourceMap>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupResourceMap System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupResourceMap>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupResourceMap>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupResourceMap>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PipelineGroupSchemaMap : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupSchemaMap>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupSchemaMap>
    {
        public PipelineGroupSchemaMap(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupRecordMap> recordMap) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupRecordMap> RecordMap { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupResourceMap> ResourceMap { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupScopeMap> ScopeMap { get { throw null; } }
        protected virtual Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupSchemaMap JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupSchemaMap PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupSchemaMap System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupSchemaMap>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupSchemaMap>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupSchemaMap System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupSchemaMap>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupSchemaMap>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupSchemaMap>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PipelineGroupScopeMap : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupScopeMap>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupScopeMap>
    {
        public PipelineGroupScopeMap(string from, string to) { }
        public string From { get { throw null; } set { } }
        public string To { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupScopeMap JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupScopeMap PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupScopeMap System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupScopeMap>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupScopeMap>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupScopeMap System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupScopeMap>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupScopeMap>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupScopeMap>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PipelineGroupService : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupService>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupService>
    {
        public PipelineGroupService(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupPipeline> pipelines) { }
        public string PersistencePersistentVolumeName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupPipeline> Pipelines { get { throw null; } }
        protected virtual Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupService JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupService PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupService System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupService>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupService>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupService System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupService>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupService>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupService>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PipelineGroupSyslogReceiver : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupSyslogReceiver>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupSyslogReceiver>
    {
        public PipelineGroupSyslogReceiver(string endpoint) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupAllowedFormat> AllowedFormats { get { throw null; } }
        public bool? AllowSkipPriHeader { get { throw null; } set { } }
        public string Endpoint { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupTransportProtocol? TransportProtocol { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupSyslogReceiver JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupSyslogReceiver PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupSyslogReceiver System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupSyslogReceiver>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupSyslogReceiver>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupSyslogReceiver System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupSyslogReceiver>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupSyslogReceiver>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupSyslogReceiver>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PipelineGroupTlsConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupTlsConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupTlsConfiguration>
    {
        public PipelineGroupTlsConfiguration(string name) { }
        public Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupCertificateSource ClientCa { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupTlsMode? Mode { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupCertificateWithKey TlsCertificate { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupTlsConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupTlsConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupTlsConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupTlsConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupTlsConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupTlsConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupTlsConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupTlsConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupTlsConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PipelineGroupTlsMode : System.IEquatable<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupTlsMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PipelineGroupTlsMode(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupTlsMode Disabled { get { throw null; } }
        public static Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupTlsMode MutualTls { get { throw null; } }
        public static Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupTlsMode ServerOnly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupTlsMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupTlsMode left, Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupTlsMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupTlsMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupTlsMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupTlsMode left, Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupTlsMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PipelineGroupTransportProtocol : System.IEquatable<Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupTransportProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PipelineGroupTransportProtocol(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupTransportProtocol Tcp { get { throw null; } }
        public static Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupTransportProtocol Udp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupTransportProtocol other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupTransportProtocol left, Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupTransportProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupTransportProtocol (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupTransportProtocol? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupTransportProtocol left, Azure.ResourceManager.Monitor.PipelineGroups.Models.PipelineGroupTransportProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
}
