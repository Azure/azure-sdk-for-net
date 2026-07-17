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
        public static Azure.Response<Azure.ResourceManager.SerialConsole.Models.DisableSerialConsoleResult> DisableConsole(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SerialConsole.Models.DisableSerialConsoleResult>> DisableConsoleAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SerialConsole.Models.EnableSerialConsoleResult> EnableConsole(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SerialConsole.Models.EnableSerialConsoleResult>> EnableConsoleAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SerialConsole.Models.SerialPortListResult> GetAll(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SerialConsole.Models.SerialPortListResult>> GetAllAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SerialConsole.Models.SerialConsoleStatus> GetConsoleStatus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SerialConsole.Models.SerialConsoleStatus>> GetConsoleStatusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SerialConsole.Models.SerialConsoleOperations> GetOperations(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SerialConsole.Models.SerialConsoleOperations>> GetOperationsAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SerialConsole.SerialPortResource> GetSerialPort(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string serialPort, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SerialConsole.SerialPortResource>> GetSerialPortAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string serialPort, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SerialConsole.SerialPortResource GetSerialPortResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SerialConsole.SerialPortCollection GetSerialPorts(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SerialConsole.Models.SerialPortListResult> GetSerialPorts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SerialConsole.Models.SerialPortListResult>> GetSerialPortsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SerialPortCollection : Azure.ResourceManager.ArmCollection
    {
        protected SerialPortCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SerialConsole.SerialPortResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string serialPort, Azure.ResourceManager.SerialConsole.SerialPortData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SerialConsole.SerialPortResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string serialPort, Azure.ResourceManager.SerialConsole.SerialPortData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string serialPort, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string serialPort, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SerialConsole.SerialPortResource> Get(string serialPort, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SerialConsole.SerialPortResource>> GetAsync(string serialPort, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.SerialConsole.SerialPortResource> GetIfExists(string serialPort, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SerialConsole.SerialPortResource>> GetIfExistsAsync(string serialPort, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.SerialConsole.Models.SerialPortConnectResult> Connect(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SerialConsole.Models.SerialPortConnectResult>> ConnectAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceProviderNamespace, string parentResourceType, string parentResource, string serialPort) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SerialConsole.SerialPortResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SerialConsole.SerialPortResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.SerialConsole.SerialPortData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SerialConsole.SerialPortData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SerialConsole.SerialPortData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SerialConsole.SerialPortData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SerialConsole.SerialPortData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SerialConsole.SerialPortData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SerialConsole.SerialPortData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SerialConsole.SerialPortResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SerialConsole.SerialPortData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SerialConsole.SerialPortResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SerialConsole.SerialPortData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.SerialConsole.Mocking
{
    public partial class MockableSerialConsoleArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableSerialConsoleArmClient() { }
        public virtual Azure.Response<Azure.ResourceManager.SerialConsole.Models.SerialPortListResult> GetAll(Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SerialConsole.Models.SerialPortListResult>> GetAllAsync(Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SerialConsole.SerialPortResource> GetSerialPort(Azure.Core.ResourceIdentifier scope, string serialPort, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SerialConsole.SerialPortResource>> GetSerialPortAsync(Azure.Core.ResourceIdentifier scope, string serialPort, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SerialConsole.SerialPortResource GetSerialPortResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.SerialConsole.SerialPortCollection GetSerialPorts(Azure.Core.ResourceIdentifier scope) { throw null; }
    }
    public partial class MockableSerialConsoleSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableSerialConsoleSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.SerialConsole.Models.DisableSerialConsoleResult> DisableConsole(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SerialConsole.Models.DisableSerialConsoleResult>> DisableConsoleAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SerialConsole.Models.EnableSerialConsoleResult> EnableConsole(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SerialConsole.Models.EnableSerialConsoleResult>> EnableConsoleAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SerialConsole.Models.SerialConsoleStatus> GetConsoleStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SerialConsole.Models.SerialConsoleStatus>> GetConsoleStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SerialConsole.Models.SerialPortListResult> GetSerialPorts(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SerialConsole.Models.SerialPortListResult>> GetSerialPortsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableSerialConsoleTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableSerialConsoleTenantResource() { }
        public virtual Azure.Response<Azure.ResourceManager.SerialConsole.Models.SerialConsoleOperations> GetOperations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SerialConsole.Models.SerialConsoleOperations>> GetOperationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.SerialConsole.Models
{
    public static partial class ArmSerialConsoleModelFactory
    {
        public static Azure.ResourceManager.SerialConsole.Models.DisableSerialConsoleResult DisableSerialConsoleResult(bool? disabled = default(bool?)) { throw null; }
        public static Azure.ResourceManager.SerialConsole.Models.EnableSerialConsoleResult EnableSerialConsoleResult(bool? disabled = default(bool?)) { throw null; }
        public static Azure.ResourceManager.SerialConsole.Models.SerialConsoleOperationDisplay SerialConsoleOperationDisplay(string provider = null, string resource = null, string operation = null, string description = null) { throw null; }
        public static Azure.ResourceManager.SerialConsole.Models.SerialConsoleOperationInfo SerialConsoleOperationInfo(string name = null, bool? isDataAction = default(bool?), Azure.ResourceManager.SerialConsole.Models.SerialConsoleOperationDisplay display = null) { throw null; }
        public static Azure.ResourceManager.SerialConsole.Models.SerialConsoleOperations SerialConsoleOperations(System.Collections.Generic.IEnumerable<Azure.ResourceManager.SerialConsole.Models.SerialConsoleOperationInfo> value = null) { throw null; }
        public static Azure.ResourceManager.SerialConsole.Models.SerialConsoleStatus SerialConsoleStatus(bool? disabled = default(bool?)) { throw null; }
        public static Azure.ResourceManager.SerialConsole.Models.SerialPortConnectResult SerialPortConnectResult(string connectionString = null) { throw null; }
        public static Azure.ResourceManager.SerialConsole.SerialPortData SerialPortData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.SerialConsole.Models.SerialPortState? state = default(Azure.ResourceManager.SerialConsole.Models.SerialPortState?), Azure.ResourceManager.SerialConsole.Models.SerialPortConnectionState? connectionState = default(Azure.ResourceManager.SerialConsole.Models.SerialPortConnectionState?)) { throw null; }
        public static Azure.ResourceManager.SerialConsole.Models.SerialPortListResult SerialPortListResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.SerialConsole.SerialPortData> value = null) { throw null; }
    }
    public partial class DisableSerialConsoleResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SerialConsole.Models.DisableSerialConsoleResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SerialConsole.Models.DisableSerialConsoleResult>
    {
        internal DisableSerialConsoleResult() { }
        public bool? Disabled { get { throw null; } }
        protected virtual Azure.ResourceManager.SerialConsole.Models.DisableSerialConsoleResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.SerialConsole.Models.DisableSerialConsoleResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.SerialConsole.Models.DisableSerialConsoleResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SerialConsole.Models.DisableSerialConsoleResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SerialConsole.Models.DisableSerialConsoleResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SerialConsole.Models.DisableSerialConsoleResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SerialConsole.Models.DisableSerialConsoleResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SerialConsole.Models.DisableSerialConsoleResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SerialConsole.Models.DisableSerialConsoleResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EnableSerialConsoleResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SerialConsole.Models.EnableSerialConsoleResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SerialConsole.Models.EnableSerialConsoleResult>
    {
        internal EnableSerialConsoleResult() { }
        public bool? Disabled { get { throw null; } }
        protected virtual Azure.ResourceManager.SerialConsole.Models.EnableSerialConsoleResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.SerialConsole.Models.EnableSerialConsoleResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.SerialConsole.Models.EnableSerialConsoleResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SerialConsole.Models.EnableSerialConsoleResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SerialConsole.Models.EnableSerialConsoleResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SerialConsole.Models.EnableSerialConsoleResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SerialConsole.Models.EnableSerialConsoleResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SerialConsole.Models.EnableSerialConsoleResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SerialConsole.Models.EnableSerialConsoleResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SerialConsoleOperationDisplay : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SerialConsole.Models.SerialConsoleOperationDisplay>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SerialConsole.Models.SerialConsoleOperationDisplay>
    {
        internal SerialConsoleOperationDisplay() { }
        public string Description { get { throw null; } }
        public string Operation { get { throw null; } }
        public string Provider { get { throw null; } }
        public string Resource { get { throw null; } }
        protected virtual Azure.ResourceManager.SerialConsole.Models.SerialConsoleOperationDisplay JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.SerialConsole.Models.SerialConsoleOperationDisplay PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.SerialConsole.Models.SerialConsoleOperationDisplay System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SerialConsole.Models.SerialConsoleOperationDisplay>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SerialConsole.Models.SerialConsoleOperationDisplay>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SerialConsole.Models.SerialConsoleOperationDisplay System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SerialConsole.Models.SerialConsoleOperationDisplay>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SerialConsole.Models.SerialConsoleOperationDisplay>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SerialConsole.Models.SerialConsoleOperationDisplay>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SerialConsoleOperationInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SerialConsole.Models.SerialConsoleOperationInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SerialConsole.Models.SerialConsoleOperationInfo>
    {
        internal SerialConsoleOperationInfo() { }
        public Azure.ResourceManager.SerialConsole.Models.SerialConsoleOperationDisplay Display { get { throw null; } }
        public bool? IsDataAction { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual Azure.ResourceManager.SerialConsole.Models.SerialConsoleOperationInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.SerialConsole.Models.SerialConsoleOperationInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.SerialConsole.Models.SerialConsoleOperationInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SerialConsole.Models.SerialConsoleOperationInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SerialConsole.Models.SerialConsoleOperationInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SerialConsole.Models.SerialConsoleOperationInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SerialConsole.Models.SerialConsoleOperationInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SerialConsole.Models.SerialConsoleOperationInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SerialConsole.Models.SerialConsoleOperationInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SerialConsoleOperations : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SerialConsole.Models.SerialConsoleOperations>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SerialConsole.Models.SerialConsoleOperations>
    {
        internal SerialConsoleOperations() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.SerialConsole.Models.SerialConsoleOperationInfo> Value { get { throw null; } }
        protected virtual Azure.ResourceManager.SerialConsole.Models.SerialConsoleOperations JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.SerialConsole.Models.SerialConsoleOperations PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.SerialConsole.Models.SerialConsoleOperations System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SerialConsole.Models.SerialConsoleOperations>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SerialConsole.Models.SerialConsoleOperations>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SerialConsole.Models.SerialConsoleOperations System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SerialConsole.Models.SerialConsoleOperations>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SerialConsole.Models.SerialConsoleOperations>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SerialConsole.Models.SerialConsoleOperations>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SerialConsoleStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SerialConsole.Models.SerialConsoleStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SerialConsole.Models.SerialConsoleStatus>
    {
        internal SerialConsoleStatus() { }
        public bool? Disabled { get { throw null; } }
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
    public enum SerialPortConnectionState
    {
        Active = 0,
        Inactive = 1,
    }
    public partial class SerialPortConnectResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SerialConsole.Models.SerialPortConnectResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SerialConsole.Models.SerialPortConnectResult>
    {
        internal SerialPortConnectResult() { }
        public string ConnectionString { get { throw null; } }
        protected virtual Azure.ResourceManager.SerialConsole.Models.SerialPortConnectResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.SerialConsole.Models.SerialPortConnectResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.SerialConsole.Models.SerialPortConnectResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SerialConsole.Models.SerialPortConnectResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SerialConsole.Models.SerialPortConnectResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SerialConsole.Models.SerialPortConnectResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SerialConsole.Models.SerialPortConnectResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SerialConsole.Models.SerialPortConnectResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SerialConsole.Models.SerialPortConnectResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SerialPortListResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SerialConsole.Models.SerialPortListResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SerialConsole.Models.SerialPortListResult>
    {
        internal SerialPortListResult() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.SerialConsole.SerialPortData> Value { get { throw null; } }
        protected virtual Azure.ResourceManager.SerialConsole.Models.SerialPortListResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.SerialConsole.Models.SerialPortListResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.SerialConsole.Models.SerialPortListResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SerialConsole.Models.SerialPortListResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SerialConsole.Models.SerialPortListResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SerialConsole.Models.SerialPortListResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SerialConsole.Models.SerialPortListResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SerialConsole.Models.SerialPortListResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SerialConsole.Models.SerialPortListResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum SerialPortState
    {
        Enabled = 0,
        Disabled = 1,
    }
}
