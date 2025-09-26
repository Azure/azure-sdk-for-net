namespace Azure.ResourceManager.PortalServicesCopilot
{
    public partial class AzureResourceManagerPortalServicesCopilotContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerPortalServicesCopilotContext() { }
        public static Azure.ResourceManager.PortalServicesCopilot.AzureResourceManagerPortalServicesCopilotContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class PortalServicesCopilotExtensions
    {
        public static Azure.ResourceManager.PortalServicesCopilot.PortalServicesCopilotSettingResource GetPortalServicesCopilotSetting(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.ResourceManager.PortalServicesCopilot.PortalServicesCopilotSettingResource GetPortalServicesCopilotSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class PortalServicesCopilotSettingData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PortalServicesCopilot.PortalServicesCopilotSettingData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PortalServicesCopilot.PortalServicesCopilotSettingData>
    {
        public PortalServicesCopilotSettingData() { }
        public Azure.ResourceManager.PortalServicesCopilot.Models.PortalServicesCopilotSettingsProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PortalServicesCopilot.PortalServicesCopilotSettingData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PortalServicesCopilot.PortalServicesCopilotSettingData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PortalServicesCopilot.PortalServicesCopilotSettingData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PortalServicesCopilot.PortalServicesCopilotSettingData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PortalServicesCopilot.PortalServicesCopilotSettingData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PortalServicesCopilot.PortalServicesCopilotSettingData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PortalServicesCopilot.PortalServicesCopilotSettingData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PortalServicesCopilotSettingResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PortalServicesCopilot.PortalServicesCopilotSettingData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PortalServicesCopilot.PortalServicesCopilotSettingData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PortalServicesCopilotSettingResource() { }
        public virtual Azure.ResourceManager.PortalServicesCopilot.PortalServicesCopilotSettingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PortalServicesCopilot.PortalServicesCopilotSettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.PortalServicesCopilot.PortalServicesCopilotSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PortalServicesCopilot.PortalServicesCopilotSettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PortalServicesCopilot.PortalServicesCopilotSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PortalServicesCopilot.PortalServicesCopilotSettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PortalServicesCopilot.PortalServicesCopilotSettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.PortalServicesCopilot.PortalServicesCopilotSettingData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PortalServicesCopilot.PortalServicesCopilotSettingData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PortalServicesCopilot.PortalServicesCopilotSettingData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PortalServicesCopilot.PortalServicesCopilotSettingData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PortalServicesCopilot.PortalServicesCopilotSettingData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PortalServicesCopilot.PortalServicesCopilotSettingData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PortalServicesCopilot.PortalServicesCopilotSettingData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PortalServicesCopilot.PortalServicesCopilotSettingResource> Update(Azure.ResourceManager.PortalServicesCopilot.Models.PortalServicesCopilotSettingPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PortalServicesCopilot.PortalServicesCopilotSettingResource>> UpdateAsync(Azure.ResourceManager.PortalServicesCopilot.Models.PortalServicesCopilotSettingPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.PortalServicesCopilot.Mocking
{
    public partial class MockablePortalServicesCopilotArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockablePortalServicesCopilotArmClient() { }
        public virtual Azure.ResourceManager.PortalServicesCopilot.PortalServicesCopilotSettingResource GetPortalServicesCopilotSettingResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockablePortalServicesCopilotTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockablePortalServicesCopilotTenantResource() { }
        public virtual Azure.ResourceManager.PortalServicesCopilot.PortalServicesCopilotSettingResource GetPortalServicesCopilotSetting() { throw null; }
    }
}
namespace Azure.ResourceManager.PortalServicesCopilot.Models
{
    public static partial class ArmPortalServicesCopilotModelFactory
    {
        public static Azure.ResourceManager.PortalServicesCopilot.PortalServicesCopilotSettingData PortalServicesCopilotSettingData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.PortalServicesCopilot.Models.PortalServicesCopilotSettingsProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PortalServicesCopilot.Models.PortalServicesCopilotSettingsProperties PortalServicesCopilotSettingsProperties(bool accessControlEnabled = false, Azure.ResourceManager.PortalServicesCopilot.Models.PortalServicesResourceProvisioningState? provisioningState = default(Azure.ResourceManager.PortalServicesCopilot.Models.PortalServicesResourceProvisioningState?)) { throw null; }
    }
    public partial class PortalServicesCopilotSettingPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PortalServicesCopilot.Models.PortalServicesCopilotSettingPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PortalServicesCopilot.Models.PortalServicesCopilotSettingPatch>
    {
        public PortalServicesCopilotSettingPatch() { }
        public bool? AccessControlEnabled { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PortalServicesCopilot.Models.PortalServicesCopilotSettingPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PortalServicesCopilot.Models.PortalServicesCopilotSettingPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PortalServicesCopilot.Models.PortalServicesCopilotSettingPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PortalServicesCopilot.Models.PortalServicesCopilotSettingPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PortalServicesCopilot.Models.PortalServicesCopilotSettingPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PortalServicesCopilot.Models.PortalServicesCopilotSettingPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PortalServicesCopilot.Models.PortalServicesCopilotSettingPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PortalServicesCopilotSettingsProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PortalServicesCopilot.Models.PortalServicesCopilotSettingsProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PortalServicesCopilot.Models.PortalServicesCopilotSettingsProperties>
    {
        public PortalServicesCopilotSettingsProperties(bool accessControlEnabled) { }
        public bool AccessControlEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.PortalServicesCopilot.Models.PortalServicesResourceProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PortalServicesCopilot.Models.PortalServicesCopilotSettingsProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PortalServicesCopilot.Models.PortalServicesCopilotSettingsProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PortalServicesCopilot.Models.PortalServicesCopilotSettingsProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PortalServicesCopilot.Models.PortalServicesCopilotSettingsProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PortalServicesCopilot.Models.PortalServicesCopilotSettingsProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PortalServicesCopilot.Models.PortalServicesCopilotSettingsProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PortalServicesCopilot.Models.PortalServicesCopilotSettingsProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PortalServicesResourceProvisioningState : System.IEquatable<Azure.ResourceManager.PortalServicesCopilot.Models.PortalServicesResourceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PortalServicesResourceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.PortalServicesCopilot.Models.PortalServicesResourceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.PortalServicesCopilot.Models.PortalServicesResourceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.PortalServicesCopilot.Models.PortalServicesResourceProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PortalServicesCopilot.Models.PortalServicesResourceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PortalServicesCopilot.Models.PortalServicesResourceProvisioningState left, Azure.ResourceManager.PortalServicesCopilot.Models.PortalServicesResourceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PortalServicesCopilot.Models.PortalServicesResourceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PortalServicesCopilot.Models.PortalServicesResourceProvisioningState left, Azure.ResourceManager.PortalServicesCopilot.Models.PortalServicesResourceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
}
