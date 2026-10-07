namespace Azure.ResourceManager.SerialConsole
{
    public partial class AzureResourceManagerSerialConsoleContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerSerialConsoleContext() { }
        public static Azure.ResourceManager.SerialConsole.AzureResourceManagerSerialConsoleContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class SerialConsoleExtensions
    {
        public static Azure.Response<Azure.ResourceManager.SerialConsole.Models.SerialConsoleStatus> DisableConsole(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SerialConsole.Models.SerialConsoleStatus>> DisableConsoleAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SerialConsole.Models.SerialConsoleStatus> EnableConsole(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SerialConsole.Models.SerialConsoleStatus>> EnableConsoleAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SerialConsole.Models.SerialConsoleStatus> GetConsoleStatus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SerialConsole.Models.SerialConsoleStatus>> GetConsoleStatusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SerialConsole.SerialPortResource> GetSerialPort(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string serialPort, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SerialConsole.SerialPortResource>> GetSerialPortAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string serialPort, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SerialConsole.SerialPortResource GetSerialPortResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SerialConsole.SerialPortCollection GetSerialPorts(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SerialConsole.SerialPortResource> GetSerialPorts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SerialConsole.SerialPortResource> GetSerialPortsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SerialPortCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SerialConsole.SerialPortResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SerialConsole.SerialPortResource>, System.Collections.IEnumerable
    {
        protected SerialPortCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SerialConsole.SerialPortResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string serialPort, Azure.ResourceManager.SerialConsole.SerialPortData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SerialConsole.SerialPortResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string serialPort, Azure.ResourceManager.SerialConsole.SerialPortData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string serialPort, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string serialPort, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SerialConsole.SerialPortResource> Get(string serialPort, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SerialConsole.SerialPortResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SerialConsole.SerialPortResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SerialConsole.SerialPortResource>> GetAsync(string serialPort, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.SerialConsole.SerialPortResource> GetIfExists(string serialPort, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SerialConsole.SerialPortResource>> GetIfExistsAsync(string serialPort, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SerialConsole.SerialPortResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SerialConsole.SerialPortResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SerialConsole.SerialPortResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SerialConsole.SerialPortResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SerialPortData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SerialConsole.SerialPortData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SerialConsole.SerialPortData>
    {
        public SerialPortData() { }
        public Azure.ResourceManager.SerialConsole.Models.SerialPortConnectionState? ConnectionState { get { throw null; } set { } }
        public Azure.ResourceManager.SerialConsole.Models.SerialPortState? State { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.SerialConsole.SerialPortData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SerialConsole.SerialPortData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SerialConsole.SerialPortData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SerialConsole.SerialPortData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SerialConsole.SerialPortData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SerialConsole.SerialPortData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SerialConsole.SerialPortData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SerialPortResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SerialConsole.SerialPortData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SerialConsole.SerialPortData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SerialPortResource() { }
        public virtual Azure.ResourceManager.SerialConsole.SerialPortData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.SerialConsole.Models.SerialPortConnectionInfo> Connect(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SerialConsole.Models.SerialPortConnectionInfo>> ConnectAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceProviderNamespace, string parentResourceType, string parentResource, string serialPort) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SerialConsole.SerialPortResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SerialConsole.SerialPortResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.SerialConsole.SerialPortData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SerialConsole.SerialPortData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SerialConsole.SerialPortData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SerialConsole.SerialPortData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SerialConsole.SerialPortData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SerialConsole.SerialPortData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SerialConsole.SerialPortData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.SerialConsole.Mocking
{
    public partial class MockableSerialConsoleArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableSerialConsoleArmClient() { }
        public virtual Azure.Response<Azure.ResourceManager.SerialConsole.SerialPortResource> GetSerialPort(Azure.Core.ResourceIdentifier scope, string serialPort, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SerialConsole.SerialPortResource>> GetSerialPortAsync(Azure.Core.ResourceIdentifier scope, string serialPort, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SerialConsole.SerialPortResource GetSerialPortResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.SerialConsole.SerialPortCollection GetSerialPorts(Azure.Core.ResourceIdentifier scope) { throw null; }
    }
    public partial class MockableSerialConsoleSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableSerialConsoleSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.SerialConsole.Models.SerialConsoleStatus> DisableConsole(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SerialConsole.Models.SerialConsoleStatus>> DisableConsoleAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SerialConsole.Models.SerialConsoleStatus> EnableConsole(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SerialConsole.Models.SerialConsoleStatus>> EnableConsoleAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SerialConsole.Models.SerialConsoleStatus> GetConsoleStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SerialConsole.Models.SerialConsoleStatus>> GetConsoleStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SerialConsole.SerialPortResource> GetSerialPorts(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SerialConsole.SerialPortResource> GetSerialPortsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableSerialConsoleTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableSerialConsoleTenantResource() { }
    }
}
namespace Azure.ResourceManager.SerialConsole.Models
{
    public static partial class ArmSerialConsoleModelFactory
    {
        public static Azure.ResourceManager.SerialConsole.Models.SerialConsoleStatus SerialConsoleStatus(bool? isDisabled = default(bool?)) { throw null; }
        public static Azure.ResourceManager.SerialConsole.Models.SerialPortConnectionInfo SerialPortConnectionInfo(string connectionString = null) { throw null; }
        public static Azure.ResourceManager.SerialConsole.SerialPortData SerialPortData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.SerialConsole.Models.SerialPortState? state = default(Azure.ResourceManager.SerialConsole.Models.SerialPortState?), Azure.ResourceManager.SerialConsole.Models.SerialPortConnectionState? connectionState = default(Azure.ResourceManager.SerialConsole.Models.SerialPortConnectionState?)) { throw null; }
    }
    public partial class SerialConsoleStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SerialConsole.Models.SerialConsoleStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SerialConsole.Models.SerialConsoleStatus>
    {
        internal SerialConsoleStatus() { }
        public bool? IsDisabled { get { throw null; } }
        protected virtual Azure.ResourceManager.SerialConsole.Models.SerialConsoleStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.SerialConsole.Models.SerialConsoleStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.SerialConsole.Models.SerialConsoleStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SerialConsole.Models.SerialConsoleStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SerialConsole.Models.SerialConsoleStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SerialConsole.Models.SerialConsoleStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SerialConsole.Models.SerialConsoleStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SerialConsole.Models.SerialConsoleStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SerialConsole.Models.SerialConsoleStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SerialPortConnectionInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SerialConsole.Models.SerialPortConnectionInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SerialConsole.Models.SerialPortConnectionInfo>
    {
        internal SerialPortConnectionInfo() { }
        public string ConnectionString { get { throw null; } }
        protected virtual Azure.ResourceManager.SerialConsole.Models.SerialPortConnectionInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.SerialConsole.Models.SerialPortConnectionInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.SerialConsole.Models.SerialPortConnectionInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SerialConsole.Models.SerialPortConnectionInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SerialConsole.Models.SerialPortConnectionInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SerialConsole.Models.SerialPortConnectionInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SerialConsole.Models.SerialPortConnectionInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SerialConsole.Models.SerialPortConnectionInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SerialConsole.Models.SerialPortConnectionInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum SerialPortConnectionState
    {
        Active = 0,
        Inactive = 1,
    }
    public enum SerialPortState
    {
        Enabled = 0,
        Disabled = 1,
    }
}
