namespace Azure.ResourceManager.PortalServicesCopilot
{
    public partial class CopilotSettingsResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PortalServicesCopilot.CopilotSettingsResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PortalServicesCopilot.CopilotSettingsResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CopilotSettingsResource() { }
        public virtual Azure.ResourceManager.PortalServicesCopilot.CopilotSettingsResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PortalServicesCopilot.CopilotSettingsResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.PortalServicesCopilot.CopilotSettingsResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PortalServicesCopilot.CopilotSettingsResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PortalServicesCopilot.CopilotSettingsResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PortalServicesCopilot.CopilotSettingsResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PortalServicesCopilot.CopilotSettingsResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.PortalServicesCopilot.CopilotSettingsResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PortalServicesCopilot.CopilotSettingsResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PortalServicesCopilot.CopilotSettingsResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PortalServicesCopilot.CopilotSettingsResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PortalServicesCopilot.CopilotSettingsResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PortalServicesCopilot.CopilotSettingsResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PortalServicesCopilot.CopilotSettingsResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PortalServicesCopilot.CopilotSettingsResource> Update(Azure.ResourceManager.PortalServicesCopilot.Models.CopilotSettingsResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PortalServicesCopilot.CopilotSettingsResource>> UpdateAsync(Azure.ResourceManager.PortalServicesCopilot.Models.CopilotSettingsResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CopilotSettingsResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PortalServicesCopilot.CopilotSettingsResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PortalServicesCopilot.CopilotSettingsResourceData>
    {
        public CopilotSettingsResourceData() { }
        public Azure.ResourceManager.PortalServicesCopilot.Models.CopilotSettingsProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PortalServicesCopilot.CopilotSettingsResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PortalServicesCopilot.CopilotSettingsResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PortalServicesCopilot.CopilotSettingsResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PortalServicesCopilot.CopilotSettingsResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PortalServicesCopilot.CopilotSettingsResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PortalServicesCopilot.CopilotSettingsResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PortalServicesCopilot.CopilotSettingsResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class PortalServicesCopilotExtensions
    {
        public static Azure.ResourceManager.PortalServicesCopilot.CopilotSettingsResource GetCopilotSettingsResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PortalServicesCopilot.CopilotSettingsResource GetCopilotSettingsResource(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
    }
}
namespace Azure.ResourceManager.PortalServicesCopilot.Mocking
{
    public partial class MockablePortalServicesCopilotArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockablePortalServicesCopilotArmClient() { }
        public virtual Azure.ResourceManager.PortalServicesCopilot.CopilotSettingsResource GetCopilotSettingsResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockablePortalServicesCopilotTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockablePortalServicesCopilotTenantResource() { }
        public virtual Azure.ResourceManager.PortalServicesCopilot.CopilotSettingsResource GetCopilotSettingsResource() { throw null; }
    }
}
namespace Azure.ResourceManager.PortalServicesCopilot.Models
{
    public static partial class ArmPortalServicesCopilotModelFactory
    {
        public static Azure.ResourceManager.PortalServicesCopilot.Models.CopilotSettingsProperties CopilotSettingsProperties(bool accessControlEnabled = false, Azure.ResourceManager.PortalServicesCopilot.Models.ResourceProvisioningState? provisioningState = default(Azure.ResourceManager.PortalServicesCopilot.Models.ResourceProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.PortalServicesCopilot.CopilotSettingsResourceData CopilotSettingsResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.PortalServicesCopilot.Models.CopilotSettingsProperties properties = null) { throw null; }
    }
    public partial class CopilotSettingsProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PortalServicesCopilot.Models.CopilotSettingsProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PortalServicesCopilot.Models.CopilotSettingsProperties>
    {
        public CopilotSettingsProperties(bool accessControlEnabled) { }
        public bool AccessControlEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.PortalServicesCopilot.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PortalServicesCopilot.Models.CopilotSettingsProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PortalServicesCopilot.Models.CopilotSettingsProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PortalServicesCopilot.Models.CopilotSettingsProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PortalServicesCopilot.Models.CopilotSettingsProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PortalServicesCopilot.Models.CopilotSettingsProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PortalServicesCopilot.Models.CopilotSettingsProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PortalServicesCopilot.Models.CopilotSettingsProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CopilotSettingsResourcePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PortalServicesCopilot.Models.CopilotSettingsResourcePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PortalServicesCopilot.Models.CopilotSettingsResourcePatch>
    {
        public CopilotSettingsResourcePatch() { }
        public bool? AccessControlEnabled { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PortalServicesCopilot.Models.CopilotSettingsResourcePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PortalServicesCopilot.Models.CopilotSettingsResourcePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PortalServicesCopilot.Models.CopilotSettingsResourcePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PortalServicesCopilot.Models.CopilotSettingsResourcePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PortalServicesCopilot.Models.CopilotSettingsResourcePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PortalServicesCopilot.Models.CopilotSettingsResourcePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PortalServicesCopilot.Models.CopilotSettingsResourcePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceProvisioningState : System.IEquatable<Azure.ResourceManager.PortalServicesCopilot.Models.ResourceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.PortalServicesCopilot.Models.ResourceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.PortalServicesCopilot.Models.ResourceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.PortalServicesCopilot.Models.ResourceProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PortalServicesCopilot.Models.ResourceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PortalServicesCopilot.Models.ResourceProvisioningState left, Azure.ResourceManager.PortalServicesCopilot.Models.ResourceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PortalServicesCopilot.Models.ResourceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PortalServicesCopilot.Models.ResourceProvisioningState left, Azure.ResourceManager.PortalServicesCopilot.Models.ResourceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
}
