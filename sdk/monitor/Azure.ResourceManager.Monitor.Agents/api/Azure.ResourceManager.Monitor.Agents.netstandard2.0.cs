namespace Azure.ResourceManager.Monitor.Agents
{
    public partial class AzureResourceManagerMonitorAgentsContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerMonitorAgentsContext() { }
        public static Azure.ResourceManager.Monitor.Agents.AzureResourceManagerMonitorAgentsContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class MonitorAgentsExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Monitor.Agents.ObservabilityAgentResource> GetObservabilityAgent(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string observabilityAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.Agents.ObservabilityAgentResource>> GetObservabilityAgentAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string observabilityAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Monitor.Agents.ObservabilityAgentResource GetObservabilityAgentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Monitor.Agents.ObservabilityAgentCollection GetObservabilityAgents(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Monitor.Agents.ObservabilityAgentResource> GetObservabilityAgents(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Monitor.Agents.ObservabilityAgentResource> GetObservabilityAgentsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ObservabilityAgentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.Agents.ObservabilityAgentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Agents.ObservabilityAgentResource>, System.Collections.IEnumerable
    {
        protected ObservabilityAgentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.Agents.ObservabilityAgentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string observabilityAgentName, Azure.ResourceManager.Monitor.Agents.ObservabilityAgentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.Agents.ObservabilityAgentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string observabilityAgentName, Azure.ResourceManager.Monitor.Agents.ObservabilityAgentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string observabilityAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string observabilityAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.Agents.ObservabilityAgentResource> Get(string observabilityAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.Agents.ObservabilityAgentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.Agents.ObservabilityAgentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.Agents.ObservabilityAgentResource>> GetAsync(string observabilityAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Monitor.Agents.ObservabilityAgentResource> GetIfExists(string observabilityAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Monitor.Agents.ObservabilityAgentResource>> GetIfExistsAsync(string observabilityAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Monitor.Agents.ObservabilityAgentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.Agents.ObservabilityAgentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Monitor.Agents.ObservabilityAgentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Agents.ObservabilityAgentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ObservabilityAgentData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Agents.ObservabilityAgentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Agents.ObservabilityAgentData>
    {
        public ObservabilityAgentData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Agents.ObservabilityAgentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Agents.ObservabilityAgentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Agents.ObservabilityAgentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Agents.ObservabilityAgentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Agents.ObservabilityAgentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Agents.ObservabilityAgentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Agents.ObservabilityAgentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ObservabilityAgentResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Agents.ObservabilityAgentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Agents.ObservabilityAgentData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ObservabilityAgentResource() { }
        public virtual Azure.ResourceManager.Monitor.Agents.ObservabilityAgentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.Agents.ObservabilityAgentResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.Agents.ObservabilityAgentResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string observabilityAgentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.Agents.ObservabilityAgentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.Agents.ObservabilityAgentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.Agents.ObservabilityAgentResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.Agents.ObservabilityAgentResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.Agents.ObservabilityAgentResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.Agents.ObservabilityAgentResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Monitor.Agents.ObservabilityAgentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Agents.ObservabilityAgentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Agents.ObservabilityAgentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Agents.ObservabilityAgentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Agents.ObservabilityAgentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Agents.ObservabilityAgentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Agents.ObservabilityAgentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.Agents.ObservabilityAgentResource> Update(Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.Agents.ObservabilityAgentResource>> UpdateAsync(Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Monitor.Agents.Mocking
{
    public partial class MockableMonitorAgentsArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableMonitorAgentsArmClient() { }
        public virtual Azure.ResourceManager.Monitor.Agents.ObservabilityAgentResource GetObservabilityAgentResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableMonitorAgentsResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableMonitorAgentsResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.Agents.ObservabilityAgentResource> GetObservabilityAgent(string observabilityAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.Agents.ObservabilityAgentResource>> GetObservabilityAgentAsync(string observabilityAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Monitor.Agents.ObservabilityAgentCollection GetObservabilityAgents() { throw null; }
    }
    public partial class MockableMonitorAgentsSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableMonitorAgentsSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.Agents.ObservabilityAgentResource> GetObservabilityAgents(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.Agents.ObservabilityAgentResource> GetObservabilityAgentsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Monitor.Agents.Models
{
    public static partial class ArmMonitorAgentsModelFactory
    {
        public static Azure.ResourceManager.Monitor.Agents.ObservabilityAgentData ObservabilityAgentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentOperationInfo ObservabilityAgentOperationInfo(Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentOperationType type = default(Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentOperationType), Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentOperationMode? mode = default(Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentOperationMode?), string instructions = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentPatch ObservabilityAgentPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentPatchProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentPatchProperties ObservabilityAgentPatchProperties(Azure.Core.ResourceIdentifier monitoringAccountId = null, bool? isEnabled = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentOperationInfo> operations = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentProperties ObservabilityAgentProperties(Azure.ResourceManager.Monitor.Agents.Models.MonitorAgentProvisioningState? provisioningState = default(Azure.ResourceManager.Monitor.Agents.Models.MonitorAgentProvisioningState?), Azure.Core.ResourceIdentifier monitoringAccountId = null, bool? isEnabled = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentOperationInfo> operations = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MonitorAgentProvisioningState : System.IEquatable<Azure.ResourceManager.Monitor.Agents.Models.MonitorAgentProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MonitorAgentProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Agents.Models.MonitorAgentProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Agents.Models.MonitorAgentProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Agents.Models.MonitorAgentProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Agents.Models.MonitorAgentProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Agents.Models.MonitorAgentProvisioningState left, Azure.ResourceManager.Monitor.Agents.Models.MonitorAgentProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Agents.Models.MonitorAgentProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Agents.Models.MonitorAgentProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Agents.Models.MonitorAgentProvisioningState left, Azure.ResourceManager.Monitor.Agents.Models.MonitorAgentProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ObservabilityAgentOperationInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentOperationInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentOperationInfo>
    {
        public ObservabilityAgentOperationInfo(Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentOperationType type) { }
        public string Instructions { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentOperationMode? Mode { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentOperationType Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentOperationInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentOperationInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentOperationInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentOperationInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentOperationInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentOperationInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentOperationInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentOperationInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentOperationInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ObservabilityAgentOperationMode : System.IEquatable<Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentOperationMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ObservabilityAgentOperationMode(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentOperationMode Auto { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentOperationMode Manual { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentOperationMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentOperationMode left, Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentOperationMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentOperationMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentOperationMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentOperationMode left, Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentOperationMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ObservabilityAgentOperationType : System.IEquatable<Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentOperationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ObservabilityAgentOperationType(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentOperationType Investigation { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentOperationType IssueCreation { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentOperationType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentOperationType left, Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentOperationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentOperationType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentOperationType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentOperationType left, Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentOperationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ObservabilityAgentPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentPatch>
    {
        public ObservabilityAgentPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentPatchProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ObservabilityAgentPatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentPatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentPatchProperties>
    {
        public ObservabilityAgentPatchProperties() { }
        public bool? IsEnabled { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier MonitoringAccountId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentOperationInfo> Operations { get { throw null; } }
        protected virtual Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentPatchProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentPatchProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentPatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentPatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentPatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentPatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentPatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentPatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentPatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ObservabilityAgentProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentProperties>
    {
        public ObservabilityAgentProperties(Azure.Core.ResourceIdentifier monitoringAccountId) { }
        public bool? IsEnabled { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier MonitoringAccountId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentOperationInfo> Operations { get { throw null; } }
        public Azure.ResourceManager.Monitor.Agents.Models.MonitorAgentProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Agents.Models.ObservabilityAgentProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
