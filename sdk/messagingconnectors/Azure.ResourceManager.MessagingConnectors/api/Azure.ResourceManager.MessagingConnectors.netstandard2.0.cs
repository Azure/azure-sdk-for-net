namespace Azure.ResourceManager.MessagingConnectors
{
    public partial class ConnectorInstanceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MessagingConnectors.ConnectorInstanceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MessagingConnectors.ConnectorInstanceResource>, System.Collections.IEnumerable
    {
        protected ConnectorInstanceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MessagingConnectors.ConnectorInstanceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.MessagingConnectors.ConnectorInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MessagingConnectors.ConnectorInstanceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.MessagingConnectors.ConnectorInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MessagingConnectors.ConnectorInstanceResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MessagingConnectors.ConnectorInstanceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MessagingConnectors.ConnectorInstanceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MessagingConnectors.ConnectorInstanceResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.MessagingConnectors.ConnectorInstanceResource> GetIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.MessagingConnectors.ConnectorInstanceResource>> GetIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MessagingConnectors.ConnectorInstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MessagingConnectors.ConnectorInstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MessagingConnectors.ConnectorInstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MessagingConnectors.ConnectorInstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ConnectorInstanceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MessagingConnectors.ConnectorInstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MessagingConnectors.ConnectorInstanceData>
    {
        public ConnectorInstanceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.MessagingConnectors.Models.Direction? ConnectorDirection { get { throw null; } }
        public Azure.ResourceManager.MessagingConnectors.Models.ConnectorState? ConnectorState { get { throw null; } }
        public Azure.ResourceManager.MessagingConnectors.Models.EventHubConfig EventHubConfig { get { throw null; } set { } }
        public int? MaxTasks { get { throw null; } set { } }
        public Azure.ResourceManager.MessagingConnectors.Models.ConnectorProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.MessagingConnectors.Models.ConverterType? ValueConverter { get { throw null; } set { } }
        Azure.ResourceManager.MessagingConnectors.ConnectorInstanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MessagingConnectors.ConnectorInstanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MessagingConnectors.ConnectorInstanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MessagingConnectors.ConnectorInstanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MessagingConnectors.ConnectorInstanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MessagingConnectors.ConnectorInstanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MessagingConnectors.ConnectorInstanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectorInstanceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ConnectorInstanceResource() { }
        public virtual Azure.ResourceManager.MessagingConnectors.ConnectorInstanceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.MessagingConnectors.ConnectorInstanceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MessagingConnectors.ConnectorInstanceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MessagingConnectors.ConnectorInstanceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MessagingConnectors.ConnectorInstanceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Pause(System.BinaryData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PauseAsync(System.BinaryData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MessagingConnectors.ConnectorInstanceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MessagingConnectors.ConnectorInstanceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Resume(System.BinaryData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ResumeAsync(System.BinaryData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MessagingConnectors.ConnectorInstanceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MessagingConnectors.ConnectorInstanceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MessagingConnectors.ConnectorInstanceResource> Update(Azure.ResourceManager.MessagingConnectors.Models.ConnectorInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MessagingConnectors.ConnectorInstanceResource>> UpdateAsync(Azure.ResourceManager.MessagingConnectors.Models.ConnectorInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class MessagingConnectorsExtensions
    {
        public static Azure.Response<Azure.ResourceManager.MessagingConnectors.ConnectorInstanceResource> GetConnectorInstance(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MessagingConnectors.ConnectorInstanceResource>> GetConnectorInstanceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.MessagingConnectors.ConnectorInstanceResource GetConnectorInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MessagingConnectors.ConnectorInstanceCollection GetConnectorInstances(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.MessagingConnectors.ConnectorInstanceResource> GetConnectorInstances(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.MessagingConnectors.ConnectorInstanceResource> GetConnectorInstancesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.MessagingConnectors.Mocking
{
    public partial class MockableMessagingConnectorsArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableMessagingConnectorsArmClient() { }
        public virtual Azure.ResourceManager.MessagingConnectors.ConnectorInstanceResource GetConnectorInstanceResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableMessagingConnectorsResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableMessagingConnectorsResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.MessagingConnectors.ConnectorInstanceResource> GetConnectorInstance(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MessagingConnectors.ConnectorInstanceResource>> GetConnectorInstanceAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MessagingConnectors.ConnectorInstanceCollection GetConnectorInstances() { throw null; }
    }
    public partial class MockableMessagingConnectorsSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableMessagingConnectorsSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.MessagingConnectors.ConnectorInstanceResource> GetConnectorInstances(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MessagingConnectors.ConnectorInstanceResource> GetConnectorInstancesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.MessagingConnectors.Models
{
    public partial class ConnectorInstancePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MessagingConnectors.Models.ConnectorInstancePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MessagingConnectors.Models.ConnectorInstancePatch>
    {
        public ConnectorInstancePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.MessagingConnectors.Models.ConnectorInstancePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MessagingConnectors.Models.ConnectorInstancePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MessagingConnectors.Models.ConnectorInstancePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MessagingConnectors.Models.ConnectorInstancePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MessagingConnectors.Models.ConnectorInstancePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MessagingConnectors.Models.ConnectorInstancePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MessagingConnectors.Models.ConnectorInstancePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConnectorProvisioningState : System.IEquatable<Azure.ResourceManager.MessagingConnectors.Models.ConnectorProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConnectorProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.MessagingConnectors.Models.ConnectorProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.MessagingConnectors.Models.ConnectorProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.MessagingConnectors.Models.ConnectorProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.MessagingConnectors.Models.ConnectorProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.MessagingConnectors.Models.ConnectorProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.MessagingConnectors.Models.ConnectorProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MessagingConnectors.Models.ConnectorProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MessagingConnectors.Models.ConnectorProvisioningState left, Azure.ResourceManager.MessagingConnectors.Models.ConnectorProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MessagingConnectors.Models.ConnectorProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MessagingConnectors.Models.ConnectorProvisioningState left, Azure.ResourceManager.MessagingConnectors.Models.ConnectorProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConnectorState : System.IEquatable<Azure.ResourceManager.MessagingConnectors.Models.ConnectorState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConnectorState(string value) { throw null; }
        public static Azure.ResourceManager.MessagingConnectors.Models.ConnectorState Creating { get { throw null; } }
        public static Azure.ResourceManager.MessagingConnectors.Models.ConnectorState Degraded { get { throw null; } }
        public static Azure.ResourceManager.MessagingConnectors.Models.ConnectorState Deleting { get { throw null; } }
        public static Azure.ResourceManager.MessagingConnectors.Models.ConnectorState Failed { get { throw null; } }
        public static Azure.ResourceManager.MessagingConnectors.Models.ConnectorState Initializing { get { throw null; } }
        public static Azure.ResourceManager.MessagingConnectors.Models.ConnectorState Paused { get { throw null; } }
        public static Azure.ResourceManager.MessagingConnectors.Models.ConnectorState Running { get { throw null; } }
        public static Azure.ResourceManager.MessagingConnectors.Models.ConnectorState Stopped { get { throw null; } }
        public static Azure.ResourceManager.MessagingConnectors.Models.ConnectorState Unknown { get { throw null; } }
        public static Azure.ResourceManager.MessagingConnectors.Models.ConnectorState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MessagingConnectors.Models.ConnectorState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MessagingConnectors.Models.ConnectorState left, Azure.ResourceManager.MessagingConnectors.Models.ConnectorState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MessagingConnectors.Models.ConnectorState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MessagingConnectors.Models.ConnectorState left, Azure.ResourceManager.MessagingConnectors.Models.ConnectorState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConverterType : System.IEquatable<Azure.ResourceManager.MessagingConnectors.Models.ConverterType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConverterType(string value) { throw null; }
        public static Azure.ResourceManager.MessagingConnectors.Models.ConverterType AvroConverter { get { throw null; } }
        public static Azure.ResourceManager.MessagingConnectors.Models.ConverterType ByteArrayConverter { get { throw null; } }
        public static Azure.ResourceManager.MessagingConnectors.Models.ConverterType CsvConverter { get { throw null; } }
        public static Azure.ResourceManager.MessagingConnectors.Models.ConverterType JsonConverter { get { throw null; } }
        public static Azure.ResourceManager.MessagingConnectors.Models.ConverterType StringConverter { get { throw null; } }
        public static Azure.ResourceManager.MessagingConnectors.Models.ConverterType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MessagingConnectors.Models.ConverterType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MessagingConnectors.Models.ConverterType left, Azure.ResourceManager.MessagingConnectors.Models.ConverterType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MessagingConnectors.Models.ConverterType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MessagingConnectors.Models.ConverterType left, Azure.ResourceManager.MessagingConnectors.Models.ConverterType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Direction : System.IEquatable<Azure.ResourceManager.MessagingConnectors.Models.Direction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Direction(string value) { throw null; }
        public static Azure.ResourceManager.MessagingConnectors.Models.Direction Sink { get { throw null; } }
        public static Azure.ResourceManager.MessagingConnectors.Models.Direction Source { get { throw null; } }
        public static Azure.ResourceManager.MessagingConnectors.Models.Direction Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MessagingConnectors.Models.Direction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MessagingConnectors.Models.Direction left, Azure.ResourceManager.MessagingConnectors.Models.Direction right) { throw null; }
        public static implicit operator Azure.ResourceManager.MessagingConnectors.Models.Direction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MessagingConnectors.Models.Direction left, Azure.ResourceManager.MessagingConnectors.Models.Direction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EventHubConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MessagingConnectors.Models.EventHubConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MessagingConnectors.Models.EventHubConfig>
    {
        public EventHubConfig(string namespaceHostName, string eventHubName, string connectionString) { }
        public string ConnectionString { get { throw null; } set { } }
        public string EventHubName { get { throw null; } set { } }
        public string NamespaceHostName { get { throw null; } set { } }
        Azure.ResourceManager.MessagingConnectors.Models.EventHubConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MessagingConnectors.Models.EventHubConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MessagingConnectors.Models.EventHubConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MessagingConnectors.Models.EventHubConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MessagingConnectors.Models.EventHubConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MessagingConnectors.Models.EventHubConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MessagingConnectors.Models.EventHubConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
